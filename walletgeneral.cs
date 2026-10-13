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
namespace GeneXus.Programs {
   public class walletgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public walletgeneral( )
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

      public walletgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WalletId )
      {
         this.A637WalletId = aP0_WalletId;
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
         cmbTipoCuentaConcepto = new GXCombobox();
         cmbWalletEstado = new GXCombobox();
         cmbWalletTipoEntidad = new GXCombobox();
         dynMonedaId = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WalletId");
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
                  A637WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A637WalletId});
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
                  gxfirstwebparm = GetFirstPar( "WalletId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WalletId");
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
            PAAS2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "WalletGeneral";
               GXt_decimal1 = A646WalletTotalDebito;
               new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal1) ;
               A646WalletTotalDebito = GXt_decimal1;
               AssignAttri(sPrefix, false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
               GXt_decimal1 = A647WalletTotalCredito;
               new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal1) ;
               A647WalletTotalCredito = GXt_decimal1;
               AssignAttri(sPrefix, false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
               A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
               AssignAttri(sPrefix, false, "A648WalletSaldo", StringUtil.LTrimStr( A648WalletSaldo, 18, 2));
               WSAS2( ) ;
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
            context.SendWebValue( context.GetMessage( "Wallet General", "")) ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "walletgeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A637WalletId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("walletgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WalletGeneral");
         forbiddenHiddens.Add("TipoCuentaId", context.localUtil.Format( (decimal)(A483TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("walletgeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA637WalletId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA637WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseFormAS2( )
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
            context.WriteHtmlTextNl( "</form>") ;
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
         return "WalletGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Wallet General", "") ;
      }

      protected void WBAS0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "walletgeneral.aspx");
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
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWalletId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWalletId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletId_Enabled!=0) ? context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_WalletGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoCuentaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTipoCuentaId_Internalname, context.GetMessage( "Clasificación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtTipoCuentaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A483TipoCuentaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtTipoCuentaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A483TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A483TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoCuentaId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTipoCuentaId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_WalletGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTipoCuentaConcepto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbTipoCuentaConcepto_Internalname, context.GetMessage( "Tipo de Concepto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbTipoCuentaConcepto, cmbTipoCuentaConcepto_Internalname, StringUtil.RTrim( A636TipoCuentaConcepto), 1, cmbTipoCuentaConcepto_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbTipoCuentaConcepto.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_WalletGeneral.htm");
            cmbTipoCuentaConcepto.CurrentValue = StringUtil.RTrim( A636TipoCuentaConcepto);
            AssignProp(sPrefix, false, cmbTipoCuentaConcepto_Internalname, "Values", (string)(cmbTipoCuentaConcepto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWalletEstado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbWalletEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbWalletEstado, cmbWalletEstado_Internalname, StringUtil.RTrim( A665WalletEstado), 1, cmbWalletEstado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbWalletEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_WalletGeneral.htm");
            cmbWalletEstado.CurrentValue = StringUtil.RTrim( A665WalletEstado);
            AssignProp(sPrefix, false, cmbWalletEstado_Internalname, "Values", (string)(cmbWalletEstado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWalletTipoEntidad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbWalletTipoEntidad_Internalname, context.GetMessage( "Tipo Entidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbWalletTipoEntidad, cmbWalletTipoEntidad_Internalname, StringUtil.RTrim( A638WalletTipoEntidad), 1, cmbWalletTipoEntidad_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbWalletTipoEntidad.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 0, "HLP_WalletGeneral.htm");
            cmbWalletTipoEntidad.CurrentValue = StringUtil.RTrim( A638WalletTipoEntidad);
            AssignProp(sPrefix, false, cmbWalletTipoEntidad_Internalname, "Values", (string)(cmbWalletTipoEntidad.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletCodRefencia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWalletCodRefencia_Internalname, context.GetMessage( "Código de Refencia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWalletCodRefencia_Internalname, StringUtil.RTrim( A639WalletCodRefencia), StringUtil.RTrim( context.localUtil.Format( A639WalletCodRefencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletCodRefencia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletCodRefencia_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WalletGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWalletNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWalletNombre_Internalname, StringUtil.RTrim( A715WalletNombre), StringUtil.RTrim( context.localUtil.Format( A715WalletNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_WalletGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoCuentaNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTipoCuentaNombre_Internalname, context.GetMessage( "Nombre del Tipo de Cuenta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtTipoCuentaNombre_Internalname, StringUtil.RTrim( A484TipoCuentaNombre), StringUtil.RTrim( context.localUtil.Format( A484TipoCuentaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtTipoCuentaNombre_Link, "", "", "", edtTipoCuentaNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTipoCuentaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "NombreLargo", "start", true, "", "HLP_WalletGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynMonedaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynMonedaId_Internalname, context.GetMessage( "Moneda", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynMonedaId, dynMonedaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0)), 1, dynMonedaId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynMonedaId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 0, "HLP_WalletGeneral.htm");
            dynMonedaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0));
            AssignProp(sPrefix, false, dynMonedaId_Internalname, "Values", (string)(dynMonedaId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletTotalDebito_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWalletTotalDebito_Internalname, context.GetMessage( "Total Debito", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWalletTotalDebito_Internalname, StringUtil.LTrim( StringUtil.NToC( A646WalletTotalDebito, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletTotalDebito_Enabled!=0) ? context.localUtil.Format( A646WalletTotalDebito, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A646WalletTotalDebito, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletTotalDebito_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletTotalDebito_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_WalletGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletTotalCredito_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWalletTotalCredito_Internalname, context.GetMessage( "Total Credito", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWalletTotalCredito_Internalname, StringUtil.LTrim( StringUtil.NToC( A647WalletTotalCredito, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletTotalCredito_Enabled!=0) ? context.localUtil.Format( A647WalletTotalCredito, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A647WalletTotalCredito, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,56);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletTotalCredito_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletTotalCredito_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_WalletGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletSaldo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWalletSaldo_Internalname, context.GetMessage( "SALDO CONSOLIDADO", ""), " AttributeFLLabel AttributeSizeLargeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWalletSaldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A648WalletSaldo, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletSaldo_Enabled!=0) ? context.localUtil.Format( A648WalletSaldo, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A648WalletSaldo, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,61);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletSaldo_Jsonclick, 0, "AttributeFL AttributeSizeLarge", "", "", "", "", 1, edtWalletSaldo_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_WalletGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletSaldoAlDia_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWalletSaldoAlDia_Internalname, context.GetMessage( "Saldo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWalletSaldoAlDia_Internalname, StringUtil.LTrim( StringUtil.NToC( A1008WalletSaldoAlDia, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletSaldoAlDia_Enabled!=0) ? context.localUtil.Format( A1008WalletSaldoAlDia, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A1008WalletSaldoAlDia, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,65);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletSaldoAlDia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletSaldoAlDia_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_WalletGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWalletSolicitudesPendientes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWalletSolicitudesPendientes_Internalname, context.GetMessage( "Saldo Pendiente", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWalletSolicitudesPendientes_Internalname, StringUtil.LTrim( StringUtil.NToC( A1007WalletSolicitudesPendientes, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtWalletSolicitudesPendientes_Enabled!=0) ? context.localUtil.Format( A1007WalletSolicitudesPendientes, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A1007WalletSolicitudesPendientes, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWalletSolicitudesPendientes_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtWalletSolicitudesPendientes_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Importe", "end", false, "", "HLP_WalletGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WalletGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WalletGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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

      protected void STARTAS2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Wallet General", ""), 0) ;
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
               STRUPAS0( ) ;
            }
         }
      }

      protected void WSAS2( )
      {
         STARTAS2( ) ;
         EVTAS2( ) ;
      }

      protected void EVTAS2( )
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
                                 STRUPAS0( ) ;
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
                                 STRUPAS0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11AS2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPAS0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12AS2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPAS0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13AS2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPAS0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14AS2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPAS0( ) ;
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
                                 STRUPAS0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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

      protected void WEAS2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormAS2( ) ;
            }
         }
      }

      protected void PAAS2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "walletgeneral.aspx")), "walletgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "walletgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "WalletId");
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLAMONEDAIDAS1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMONEDAID_dataAS1( ) ;
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

      protected void GXAMONEDAID_htmlAS1( )
      {
         short gxdynajaxvalue;
         GXDLAMONEDAID_dataAS1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynMonedaId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynMonedaId.ItemCount > 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n118MonedaId = false;
            AssignAttri(sPrefix, false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
         }
      }

      protected void GXDLAMONEDAID_dataAS1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00AS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00AS2_A118MonedaId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00AS2_A119MonedaISOSimbolo[0]));
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
            dynMonedaId.Name = "MONEDAID";
            dynMonedaId.WebTags = "";
            dynMonedaId.removeAllItems();
            /* Using cursor H00AS3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00AS3_A118MonedaId[0]), 4, 0)), H00AS3_A119MonedaISOSimbolo[0], 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( dynMonedaId.ItemCount > 0 )
            {
               A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
               n118MonedaId = false;
               AssignAttri(sPrefix, false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbTipoCuentaConcepto.ItemCount > 0 )
         {
            A636TipoCuentaConcepto = cmbTipoCuentaConcepto.getValidValue(A636TipoCuentaConcepto);
            AssignAttri(sPrefix, false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTipoCuentaConcepto.CurrentValue = StringUtil.RTrim( A636TipoCuentaConcepto);
            AssignProp(sPrefix, false, cmbTipoCuentaConcepto_Internalname, "Values", cmbTipoCuentaConcepto.ToJavascriptSource(), true);
         }
         if ( cmbWalletEstado.ItemCount > 0 )
         {
            A665WalletEstado = cmbWalletEstado.getValidValue(A665WalletEstado);
            AssignAttri(sPrefix, false, "A665WalletEstado", A665WalletEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWalletEstado.CurrentValue = StringUtil.RTrim( A665WalletEstado);
            AssignProp(sPrefix, false, cmbWalletEstado_Internalname, "Values", cmbWalletEstado.ToJavascriptSource(), true);
         }
         if ( cmbWalletTipoEntidad.ItemCount > 0 )
         {
            A638WalletTipoEntidad = cmbWalletTipoEntidad.getValidValue(A638WalletTipoEntidad);
            AssignAttri(sPrefix, false, "A638WalletTipoEntidad", A638WalletTipoEntidad);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWalletTipoEntidad.CurrentValue = StringUtil.RTrim( A638WalletTipoEntidad);
            AssignProp(sPrefix, false, cmbWalletTipoEntidad_Internalname, "Values", cmbWalletTipoEntidad.ToJavascriptSource(), true);
         }
         if ( dynMonedaId.ItemCount > 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            n118MonedaId = false;
            AssignAttri(sPrefix, false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMonedaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0));
            AssignProp(sPrefix, false, dynMonedaId_Internalname, "Values", dynMonedaId.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFAS2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "WalletGeneral";
      }

      protected void RFAS2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00AS4 */
            pr_default.execute(2, new Object[] {A637WalletId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A118MonedaId = H00AS4_A118MonedaId[0];
               n118MonedaId = H00AS4_n118MonedaId[0];
               AssignAttri(sPrefix, false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
               A484TipoCuentaNombre = H00AS4_A484TipoCuentaNombre[0];
               AssignAttri(sPrefix, false, "A484TipoCuentaNombre", A484TipoCuentaNombre);
               A665WalletEstado = H00AS4_A665WalletEstado[0];
               AssignAttri(sPrefix, false, "A665WalletEstado", A665WalletEstado);
               A636TipoCuentaConcepto = H00AS4_A636TipoCuentaConcepto[0];
               AssignAttri(sPrefix, false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
               A483TipoCuentaId = H00AS4_A483TipoCuentaId[0];
               AssignAttri(sPrefix, false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
               A638WalletTipoEntidad = H00AS4_A638WalletTipoEntidad[0];
               AssignAttri(sPrefix, false, "A638WalletTipoEntidad", A638WalletTipoEntidad);
               A639WalletCodRefencia = H00AS4_A639WalletCodRefencia[0];
               AssignAttri(sPrefix, false, "A639WalletCodRefencia", A639WalletCodRefencia);
               A484TipoCuentaNombre = H00AS4_A484TipoCuentaNombre[0];
               AssignAttri(sPrefix, false, "A484TipoCuentaNombre", A484TipoCuentaNombre);
               A636TipoCuentaConcepto = H00AS4_A636TipoCuentaConcepto[0];
               AssignAttri(sPrefix, false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
               GXt_char2 = A715WalletNombre;
               new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char2) ;
               A715WalletNombre = GXt_char2;
               AssignAttri(sPrefix, false, "A715WalletNombre", A715WalletNombre);
               GXt_decimal1 = A1007WalletSolicitudesPendientes;
               new owalletsaldosolpendientes(context ).execute(  A639WalletCodRefencia, out  GXt_decimal1) ;
               A1007WalletSolicitudesPendientes = GXt_decimal1;
               AssignAttri(sPrefix, false, "A1007WalletSolicitudesPendientes", StringUtil.LTrimStr( A1007WalletSolicitudesPendientes, 18, 2));
               A1008WalletSaldoAlDia = (decimal)(A648WalletSaldo+A1007WalletSolicitudesPendientes);
               AssignAttri(sPrefix, false, "A1008WalletSaldoAlDia", StringUtil.LTrimStr( A1008WalletSaldoAlDia, 18, 2));
               /* Execute user event: Load */
               E12AS2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            WBAS0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesAS2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "WalletGeneral";
         GXt_decimal1 = A646WalletTotalDebito;
         new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal1) ;
         A646WalletTotalDebito = GXt_decimal1;
         AssignAttri(sPrefix, false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
         GXt_decimal1 = A647WalletTotalCredito;
         new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal1) ;
         A647WalletTotalCredito = GXt_decimal1;
         AssignAttri(sPrefix, false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
         A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
         AssignAttri(sPrefix, false, "A648WalletSaldo", StringUtil.LTrimStr( A648WalletSaldo, 18, 2));
         edtWalletId_Enabled = 0;
         AssignProp(sPrefix, false, edtWalletId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletId_Enabled), 5, 0), true);
         edtTipoCuentaId_Enabled = 0;
         AssignProp(sPrefix, false, edtTipoCuentaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoCuentaId_Enabled), 5, 0), true);
         cmbTipoCuentaConcepto.Enabled = 0;
         AssignProp(sPrefix, false, cmbTipoCuentaConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTipoCuentaConcepto.Enabled), 5, 0), true);
         cmbWalletEstado.Enabled = 0;
         AssignProp(sPrefix, false, cmbWalletEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletEstado.Enabled), 5, 0), true);
         cmbWalletTipoEntidad.Enabled = 0;
         AssignProp(sPrefix, false, cmbWalletTipoEntidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWalletTipoEntidad.Enabled), 5, 0), true);
         edtWalletCodRefencia_Enabled = 0;
         AssignProp(sPrefix, false, edtWalletCodRefencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletCodRefencia_Enabled), 5, 0), true);
         edtWalletNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtWalletNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletNombre_Enabled), 5, 0), true);
         edtTipoCuentaNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtTipoCuentaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoCuentaNombre_Enabled), 5, 0), true);
         dynMonedaId.Enabled = 0;
         AssignProp(sPrefix, false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), true);
         edtWalletTotalDebito_Enabled = 0;
         AssignProp(sPrefix, false, edtWalletTotalDebito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletTotalDebito_Enabled), 5, 0), true);
         edtWalletTotalCredito_Enabled = 0;
         AssignProp(sPrefix, false, edtWalletTotalCredito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletTotalCredito_Enabled), 5, 0), true);
         edtWalletSaldo_Enabled = 0;
         AssignProp(sPrefix, false, edtWalletSaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletSaldo_Enabled), 5, 0), true);
         edtWalletSaldoAlDia_Enabled = 0;
         AssignProp(sPrefix, false, edtWalletSaldoAlDia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletSaldoAlDia_Enabled), 5, 0), true);
         edtWalletSolicitudesPendientes_Enabled = 0;
         AssignProp(sPrefix, false, edtWalletSolicitudesPendientes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWalletSolicitudesPendientes_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAS0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11AS2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA637WalletId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A483TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoCuentaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
            cmbTipoCuentaConcepto.CurrentValue = cgiGet( cmbTipoCuentaConcepto_Internalname);
            A636TipoCuentaConcepto = cgiGet( cmbTipoCuentaConcepto_Internalname);
            AssignAttri(sPrefix, false, "A636TipoCuentaConcepto", A636TipoCuentaConcepto);
            cmbWalletEstado.CurrentValue = cgiGet( cmbWalletEstado_Internalname);
            A665WalletEstado = cgiGet( cmbWalletEstado_Internalname);
            AssignAttri(sPrefix, false, "A665WalletEstado", A665WalletEstado);
            cmbWalletTipoEntidad.CurrentValue = cgiGet( cmbWalletTipoEntidad_Internalname);
            A638WalletTipoEntidad = cgiGet( cmbWalletTipoEntidad_Internalname);
            AssignAttri(sPrefix, false, "A638WalletTipoEntidad", A638WalletTipoEntidad);
            A639WalletCodRefencia = cgiGet( edtWalletCodRefencia_Internalname);
            AssignAttri(sPrefix, false, "A639WalletCodRefencia", A639WalletCodRefencia);
            A715WalletNombre = cgiGet( edtWalletNombre_Internalname);
            AssignAttri(sPrefix, false, "A715WalletNombre", A715WalletNombre);
            A484TipoCuentaNombre = cgiGet( edtTipoCuentaNombre_Internalname);
            AssignAttri(sPrefix, false, "A484TipoCuentaNombre", A484TipoCuentaNombre);
            dynMonedaId.CurrentValue = cgiGet( dynMonedaId_Internalname);
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynMonedaId_Internalname), "."), 18, MidpointRounding.ToEven));
            n118MonedaId = false;
            AssignAttri(sPrefix, false, "A118MonedaId", StringUtil.LTrimStr( (decimal)(A118MonedaId), 4, 0));
            A646WalletTotalDebito = context.localUtil.CToN( cgiGet( edtWalletTotalDebito_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
            A647WalletTotalCredito = context.localUtil.CToN( cgiGet( edtWalletTotalCredito_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
            A648WalletSaldo = context.localUtil.CToN( cgiGet( edtWalletSaldo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A648WalletSaldo", StringUtil.LTrimStr( A648WalletSaldo, 18, 2));
            A1008WalletSaldoAlDia = context.localUtil.CToN( cgiGet( edtWalletSaldoAlDia_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A1008WalletSaldoAlDia", StringUtil.LTrimStr( A1008WalletSaldoAlDia, 18, 2));
            A1007WalletSolicitudesPendientes = context.localUtil.CToN( cgiGet( edtWalletSolicitudesPendientes_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A1007WalletSolicitudesPendientes", StringUtil.LTrimStr( A1007WalletSolicitudesPendientes, 18, 2));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"WalletGeneral");
            A483TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoCuentaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A483TipoCuentaId", StringUtil.LTrimStr( (decimal)(A483TipoCuentaId), 18, 0));
            forbiddenHiddens.Add("TipoCuentaId", context.localUtil.Format( (decimal)(A483TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("walletgeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E11AS2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11AS2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12AS2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean3 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWTipoCuenta", out  GXt_boolean3) ;
         AV12TempBoolean = GXt_boolean3;
         if ( AV12TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "tipocuentaview.aspx"+UrlEncode(StringUtil.LTrimStr(A483TipoCuentaId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtTipoCuentaNombre_Link = formatLink("tipocuentaview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtTipoCuentaNombre_Internalname, "Link", edtTipoCuentaNombre_Link, true);
         }
         GXt_boolean3 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet_Update", out  GXt_boolean3) ;
         AV12TempBoolean = GXt_boolean3;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean3 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet_Delete", out  GXt_boolean3) ;
         AV12TempBoolean = GXt_boolean3;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13AS2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wallet.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A637WalletId,18,0));
         CallWebObject(formatLink("wallet.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14AS2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wallet.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A637WalletId,18,0));
         CallWebObject(formatLink("wallet.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Wallet";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A637WalletId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
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
         PAAS2( ) ;
         WSAS2( ) ;
         WEAS2( ) ;
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
         sCtrlA637WalletId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAAS2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "walletgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAAS2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A637WalletId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
         }
         wcpOA637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA637WalletId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A637WalletId != wcpOA637WalletId ) ) )
         {
            setjustcreated();
         }
         wcpOA637WalletId = A637WalletId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA637WalletId = cgiGet( sPrefix+"A637WalletId_CTRL");
         if ( StringUtil.Len( sCtrlA637WalletId) > 0 )
         {
            A637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA637WalletId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A637WalletId", StringUtil.LTrimStr( (decimal)(A637WalletId), 18, 0));
         }
         else
         {
            A637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A637WalletId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PAAS2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSAS2( ) ;
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
         WSAS2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A637WalletId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA637WalletId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A637WalletId_CTRL", StringUtil.RTrim( sCtrlA637WalletId));
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
         WEAS2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269282140849", true, true, false);
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
         context.AddJavascriptSource("walletgeneral.js", "?20269282140849", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbTipoCuentaConcepto.Name = "TIPOCUENTACONCEPTO";
         cmbTipoCuentaConcepto.WebTags = "";
         cmbTipoCuentaConcepto.addItem("SAL", context.GetMessage( "Saldo por Cuentas", ""), 0);
         cmbTipoCuentaConcepto.addItem("COS", context.GetMessage( "Usada En Centro Costo", ""), 0);
         cmbTipoCuentaConcepto.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         if ( cmbTipoCuentaConcepto.ItemCount > 0 )
         {
         }
         cmbWalletEstado.Name = "WALLETESTADO";
         cmbWalletEstado.WebTags = "";
         cmbWalletEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbWalletEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbWalletEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbWalletEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbWalletEstado.ItemCount > 0 )
         {
         }
         cmbWalletTipoEntidad.Name = "WALLETTIPOENTIDAD";
         cmbWalletTipoEntidad.WebTags = "";
         cmbWalletTipoEntidad.addItem("CLI", context.GetMessage( "Clientes", ""), 0);
         cmbWalletTipoEntidad.addItem("COM", context.GetMessage( "Comercios", ""), 0);
         cmbWalletTipoEntidad.addItem("PRO", context.GetMessage( "Profesionales", ""), 0);
         cmbWalletTipoEntidad.addItem("EMP", context.GetMessage( "Empleados", ""), 0);
         cmbWalletTipoEntidad.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         if ( cmbWalletTipoEntidad.ItemCount > 0 )
         {
         }
         dynMonedaId.Name = "MONEDAID";
         dynMonedaId.WebTags = "";
         dynMonedaId.removeAllItems();
         /* Using cursor H00AS5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00AS5_A118MonedaId[0]), 4, 0)), H00AS5_A119MonedaISOSimbolo[0], 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( dynMonedaId.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtWalletId_Internalname = sPrefix+"WALLETID";
         edtTipoCuentaId_Internalname = sPrefix+"TIPOCUENTAID";
         cmbTipoCuentaConcepto_Internalname = sPrefix+"TIPOCUENTACONCEPTO";
         cmbWalletEstado_Internalname = sPrefix+"WALLETESTADO";
         cmbWalletTipoEntidad_Internalname = sPrefix+"WALLETTIPOENTIDAD";
         edtWalletCodRefencia_Internalname = sPrefix+"WALLETCODREFENCIA";
         edtWalletNombre_Internalname = sPrefix+"WALLETNOMBRE";
         edtTipoCuentaNombre_Internalname = sPrefix+"TIPOCUENTANOMBRE";
         dynMonedaId_Internalname = sPrefix+"MONEDAID";
         edtWalletTotalDebito_Internalname = sPrefix+"WALLETTOTALDEBITO";
         edtWalletTotalCredito_Internalname = sPrefix+"WALLETTOTALCREDITO";
         edtWalletSaldo_Internalname = sPrefix+"WALLETSALDO";
         edtWalletSaldoAlDia_Internalname = sPrefix+"WALLETSALDOALDIA";
         edtWalletSolicitudesPendientes_Internalname = sPrefix+"WALLETSOLICITUDESPENDIENTES";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
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
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtWalletSolicitudesPendientes_Jsonclick = "";
         edtWalletSolicitudesPendientes_Enabled = 0;
         edtWalletSaldoAlDia_Jsonclick = "";
         edtWalletSaldoAlDia_Enabled = 0;
         edtWalletSaldo_Jsonclick = "";
         edtWalletSaldo_Enabled = 0;
         edtWalletTotalCredito_Jsonclick = "";
         edtWalletTotalCredito_Enabled = 0;
         edtWalletTotalDebito_Jsonclick = "";
         edtWalletTotalDebito_Enabled = 0;
         dynMonedaId_Jsonclick = "";
         dynMonedaId.Enabled = 0;
         edtTipoCuentaNombre_Jsonclick = "";
         edtTipoCuentaNombre_Link = "";
         edtTipoCuentaNombre_Enabled = 0;
         edtWalletNombre_Jsonclick = "";
         edtWalletNombre_Enabled = 0;
         edtWalletCodRefencia_Jsonclick = "";
         edtWalletCodRefencia_Enabled = 0;
         cmbWalletTipoEntidad_Jsonclick = "";
         cmbWalletTipoEntidad.Enabled = 0;
         cmbWalletEstado_Jsonclick = "";
         cmbWalletEstado.Enabled = 0;
         cmbTipoCuentaConcepto_Jsonclick = "";
         cmbTipoCuentaConcepto.Enabled = 0;
         edtTipoCuentaId_Jsonclick = "";
         edtTipoCuentaId_Enabled = 0;
         edtWalletId_Jsonclick = "";
         edtWalletId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A637WalletId',fld:'WALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynMonedaId'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'},{av:'A483TipoCuentaId',fld:'TIPOCUENTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13AS2',iparms:[{av:'A637WalletId',fld:'WALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E14AS2',iparms:[{av:'A637WalletId',fld:'WALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_WALLETID","{handler:'Valid_Walletid',iparms:[]");
         setEventMetadata("VALID_WALLETID",",oparms:[]}");
         setEventMetadata("VALID_TIPOCUENTAID","{handler:'Valid_Tipocuentaid',iparms:[]");
         setEventMetadata("VALID_TIPOCUENTAID",",oparms:[]}");
         setEventMetadata("VALID_WALLETTIPOENTIDAD","{handler:'Valid_Wallettipoentidad',iparms:[]");
         setEventMetadata("VALID_WALLETTIPOENTIDAD",",oparms:[]}");
         setEventMetadata("VALID_WALLETCODREFENCIA","{handler:'Valid_Walletcodrefencia',iparms:[]");
         setEventMetadata("VALID_WALLETCODREFENCIA",",oparms:[]}");
         setEventMetadata("VALID_WALLETTOTALDEBITO","{handler:'Valid_Wallettotaldebito',iparms:[]");
         setEventMetadata("VALID_WALLETTOTALDEBITO",",oparms:[]}");
         setEventMetadata("VALID_WALLETTOTALCREDITO","{handler:'Valid_Wallettotalcredito',iparms:[]");
         setEventMetadata("VALID_WALLETTOTALCREDITO",",oparms:[]}");
         setEventMetadata("VALID_WALLETSALDO","{handler:'Valid_Walletsaldo',iparms:[]");
         setEventMetadata("VALID_WALLETSALDO",",oparms:[]}");
         setEventMetadata("VALID_WALLETSOLICITUDESPENDIENTES","{handler:'Valid_Walletsolicitudespendientes',iparms:[]");
         setEventMetadata("VALID_WALLETSOLICITUDESPENDIENTES",",oparms:[]}");
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
         sPrefix = "";
         AV13Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         TempTags = "";
         A636TipoCuentaConcepto = "";
         A665WalletEstado = "";
         A638WalletTipoEntidad = "";
         A639WalletCodRefencia = "";
         A715WalletNombre = "";
         A484TipoCuentaNombre = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00AS2_A118MonedaId = new short[1] ;
         H00AS2_n118MonedaId = new bool[] {false} ;
         H00AS2_A119MonedaISOSimbolo = new string[] {""} ;
         H00AS3_A118MonedaId = new short[1] ;
         H00AS3_n118MonedaId = new bool[] {false} ;
         H00AS3_A119MonedaISOSimbolo = new string[] {""} ;
         H00AS4_A118MonedaId = new short[1] ;
         H00AS4_n118MonedaId = new bool[] {false} ;
         H00AS4_A484TipoCuentaNombre = new string[] {""} ;
         H00AS4_A665WalletEstado = new string[] {""} ;
         H00AS4_A636TipoCuentaConcepto = new string[] {""} ;
         H00AS4_A483TipoCuentaId = new long[1] ;
         H00AS4_A637WalletId = new long[1] ;
         H00AS4_A638WalletTipoEntidad = new string[] {""} ;
         H00AS4_A639WalletCodRefencia = new string[] {""} ;
         GXt_char2 = "";
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA637WalletId = "";
         H00AS5_A118MonedaId = new short[1] ;
         H00AS5_n118MonedaId = new bool[] {false} ;
         H00AS5_A119MonedaISOSimbolo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.walletgeneral__default(),
            new Object[][] {
                new Object[] {
               H00AS2_A118MonedaId, H00AS2_A119MonedaISOSimbolo
               }
               , new Object[] {
               H00AS3_A118MonedaId, H00AS3_A119MonedaISOSimbolo
               }
               , new Object[] {
               H00AS4_A118MonedaId, H00AS4_n118MonedaId, H00AS4_A484TipoCuentaNombre, H00AS4_A665WalletEstado, H00AS4_A636TipoCuentaConcepto, H00AS4_A483TipoCuentaId, H00AS4_A637WalletId, H00AS4_A638WalletTipoEntidad, H00AS4_A639WalletCodRefencia
               }
               , new Object[] {
               H00AS5_A118MonedaId, H00AS5_A119MonedaISOSimbolo
               }
            }
         );
         AV13Pgmname = "WalletGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "WalletGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A118MonedaId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtWalletId_Enabled ;
      private int edtTipoCuentaId_Enabled ;
      private int edtWalletCodRefencia_Enabled ;
      private int edtWalletNombre_Enabled ;
      private int edtTipoCuentaNombre_Enabled ;
      private int edtWalletTotalDebito_Enabled ;
      private int edtWalletTotalCredito_Enabled ;
      private int edtWalletSaldo_Enabled ;
      private int edtWalletSaldoAlDia_Enabled ;
      private int edtWalletSolicitudesPendientes_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private long A637WalletId ;
      private long wcpOA637WalletId ;
      private long A483TipoCuentaId ;
      private decimal A646WalletTotalDebito ;
      private decimal A647WalletTotalCredito ;
      private decimal A648WalletSaldo ;
      private decimal A1008WalletSaldoAlDia ;
      private decimal A1007WalletSolicitudesPendientes ;
      private decimal GXt_decimal1 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtWalletId_Internalname ;
      private string TempTags ;
      private string edtWalletId_Jsonclick ;
      private string edtTipoCuentaId_Internalname ;
      private string edtTipoCuentaId_Jsonclick ;
      private string cmbTipoCuentaConcepto_Internalname ;
      private string A636TipoCuentaConcepto ;
      private string cmbTipoCuentaConcepto_Jsonclick ;
      private string cmbWalletEstado_Internalname ;
      private string A665WalletEstado ;
      private string cmbWalletEstado_Jsonclick ;
      private string cmbWalletTipoEntidad_Internalname ;
      private string A638WalletTipoEntidad ;
      private string cmbWalletTipoEntidad_Jsonclick ;
      private string edtWalletCodRefencia_Internalname ;
      private string A639WalletCodRefencia ;
      private string edtWalletCodRefencia_Jsonclick ;
      private string edtWalletNombre_Internalname ;
      private string A715WalletNombre ;
      private string edtWalletNombre_Jsonclick ;
      private string edtTipoCuentaNombre_Internalname ;
      private string A484TipoCuentaNombre ;
      private string edtTipoCuentaNombre_Link ;
      private string edtTipoCuentaNombre_Jsonclick ;
      private string dynMonedaId_Internalname ;
      private string dynMonedaId_Jsonclick ;
      private string edtWalletTotalDebito_Internalname ;
      private string edtWalletTotalDebito_Jsonclick ;
      private string edtWalletTotalCredito_Internalname ;
      private string edtWalletTotalCredito_Jsonclick ;
      private string edtWalletSaldo_Internalname ;
      private string edtWalletSaldo_Jsonclick ;
      private string edtWalletSaldoAlDia_Internalname ;
      private string edtWalletSaldoAlDia_Jsonclick ;
      private string edtWalletSolicitudesPendientes_Internalname ;
      private string edtWalletSolicitudesPendientes_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string GXt_char2 ;
      private string hsh ;
      private string sCtrlA637WalletId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n118MonedaId ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean3 ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTipoCuentaConcepto ;
      private GXCombobox cmbWalletEstado ;
      private GXCombobox cmbWalletTipoEntidad ;
      private GXCombobox dynMonedaId ;
      private IDataStoreProvider pr_default ;
      private short[] H00AS2_A118MonedaId ;
      private bool[] H00AS2_n118MonedaId ;
      private string[] H00AS2_A119MonedaISOSimbolo ;
      private short[] H00AS3_A118MonedaId ;
      private bool[] H00AS3_n118MonedaId ;
      private string[] H00AS3_A119MonedaISOSimbolo ;
      private short[] H00AS4_A118MonedaId ;
      private bool[] H00AS4_n118MonedaId ;
      private string[] H00AS4_A484TipoCuentaNombre ;
      private string[] H00AS4_A665WalletEstado ;
      private string[] H00AS4_A636TipoCuentaConcepto ;
      private long[] H00AS4_A483TipoCuentaId ;
      private long[] H00AS4_A637WalletId ;
      private string[] H00AS4_A638WalletTipoEntidad ;
      private string[] H00AS4_A639WalletCodRefencia ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] H00AS5_A118MonedaId ;
      private bool[] H00AS5_n118MonedaId ;
      private string[] H00AS5_A119MonedaISOSimbolo ;
   }

   public class walletgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00AS2;
          prmH00AS2 = new Object[] {
          };
          Object[] prmH00AS3;
          prmH00AS3 = new Object[] {
          };
          Object[] prmH00AS4;
          prmH00AS4 = new Object[] {
          new ParDef("@WalletId",GXType.Decimal,18,0)
          };
          Object[] prmH00AS5;
          prmH00AS5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00AS2", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AS2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00AS3", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AS3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00AS4", "SELECT T1.[MonedaId], T2.[TipoCuentaNombre], T1.[WalletEstado], T2.[TipoCuentaConcepto], T1.[TipoCuentaId], T1.[WalletId], T1.[WalletTipoEntidad], T1.[WalletCodRefencia] FROM ([Wallet] T1 INNER JOIN [TipoCuenta] T2 ON T2.[TipoCuentaId] = T1.[TipoCuentaId]) WHERE T1.[WalletId] = @WalletId ORDER BY T1.[WalletId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AS4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00AS5", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AS5,0, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 120);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 25);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
       }
    }

 }

}
