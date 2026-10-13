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
   public class comisionesgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public comisionesgeneral( )
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

      public comisionesgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ComisionesID )
      {
         this.A503ComisionesID = aP0_ComisionesID;
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
         cmbComisionesEstado = new GXCombobox();
         cmbComisionesTipo = new GXCombobox();
         chkComisionesGlobal = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ComisionesID");
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
                  A503ComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "ComisionesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A503ComisionesID});
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
                  gxfirstwebparm = GetFirstPar( "ComisionesID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ComisionesID");
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
            PA4B2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ComisionesGeneral";
               WS4B2( ) ;
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
            context.SendWebValue( context.GetMessage( "Comisiones General", "")) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 74760), false, true, false);
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
            GXEncryptionTmp = "comisionesgeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A503ComisionesID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comisionesgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ComisionesGeneral");
         forbiddenHiddens.Add("ComisionesTipo", StringUtil.RTrim( context.localUtil.Format( A505ComisionesTipo, "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("comisionesgeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA503ComisionesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA503ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseForm4B2( )
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
         return "ComisionesGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Comisiones General", "") ;
      }

      protected void WB4B0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "comisionesgeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComisionesID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtComisionesID_Internalname, context.GetMessage( "Código", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtComisionesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A503ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtComisionesID_Enabled!=0) ? context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtComisionesID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ComisionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbComisionesEstado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbComisionesEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbComisionesEstado, cmbComisionesEstado_Internalname, StringUtil.RTrim( A511ComisionesEstado), 1, cmbComisionesEstado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbComisionesEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "", true, 0, "HLP_ComisionesGeneral.htm");
            cmbComisionesEstado.CurrentValue = StringUtil.RTrim( A511ComisionesEstado);
            AssignProp(sPrefix, false, cmbComisionesEstado_Internalname, "Values", (string)(cmbComisionesEstado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tb1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbComisionesTipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbComisionesTipo_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbComisionesTipo, cmbComisionesTipo_Internalname, StringUtil.RTrim( A505ComisionesTipo), 1, cmbComisionesTipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbComisionesTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_ComisionesGeneral.htm");
            cmbComisionesTipo.CurrentValue = StringUtil.RTrim( A505ComisionesTipo);
            AssignProp(sPrefix, false, cmbComisionesTipo_Internalname, "Values", (string)(cmbComisionesTipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComisionesNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtComisionesNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtComisionesNombre_Internalname, StringUtil.RTrim( A504ComisionesNombre), StringUtil.RTrim( context.localUtil.Format( A504ComisionesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtComisionesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ComisionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComisionesDefault_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtComisionesDefault_Internalname, context.GetMessage( "Comisión por Defecto %", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtComisionesDefault_Internalname, StringUtil.LTrim( StringUtil.NToC( A506ComisionesDefault, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtComisionesDefault_Enabled!=0) ? context.localUtil.Format( A506ComisionesDefault, "ZZ9.99") : context.localUtil.Format( A506ComisionesDefault, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesDefault_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtComisionesDefault_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ComisionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComisionesglobal_cell_Internalname, 1, 0, "px", 0, "px", divComisionesglobal_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkComisionesGlobal.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkComisionesGlobal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkComisionesGlobal_Internalname, context.GetMessage( "Comisión Global", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkComisionesGlobal_Internalname, StringUtil.BoolToStr( A520ComisionesGlobal), "", context.GetMessage( "Comisión Global", ""), chkComisionesGlobal.Visible, chkComisionesGlobal.Enabled, "true", context.GetMessage( "¿Es una comisión global?", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(41, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,41);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tb2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgComisionesImagen_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen Promisional", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "AttributeFL";
            StyleString = "";
            A519ComisionesImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ComisionesImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : context.PathToRelativeUrl( A519ComisionesImagen));
            GxWebStd.gx_bitmap( context, imgComisionesImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A519ComisionesImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ComisionesGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComisionesComentario_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtComisionesComentario_Internalname, context.GetMessage( "Comentario", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtComisionesComentario_Internalname, A518ComisionesComentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", 0, 1, edtComisionesComentario_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ComisionesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ComisionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ComisionesGeneral.htm");
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
            context.WriteHtmlText( "<div id=\""+edtComisionesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtComisionesFechaAlta_Internalname, context.localUtil.TToC( A507ComisionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A507ComisionesFechaAlta, "99/99/99 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesFechaAlta_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesFechaAlta_Visible, 0, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ComisionesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtComisionesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtComisionesFechaAlta_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ComisionesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtComisionesEspermanente_Internalname, StringUtil.BoolToStr( A508ComisionesEspermanente), StringUtil.BoolToStr( A508ComisionesEspermanente), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesEspermanente_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesEspermanente_Visible, 0, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_ComisionesGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtComisionesFechaVigencia_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtComisionesFechaVigencia_Internalname, context.localUtil.TToC( A509ComisionesFechaVigencia, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A509ComisionesFechaVigencia, "99/99/99 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesFechaVigencia_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesFechaVigencia_Visible, 0, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ComisionesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtComisionesFechaVigencia_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtComisionesFechaVigencia_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ComisionesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtComisionesFechaVencimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtComisionesFechaVencimiento_Internalname, context.localUtil.TToC( A510ComisionesFechaVencimiento, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A510ComisionesFechaVencimiento, "99/99/99 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesFechaVencimiento_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesFechaVencimiento_Visible, 0, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ComisionesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtComisionesFechaVencimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtComisionesFechaVencimiento_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ComisionesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtComisionesInventarioEnum_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A512ComisionesInventarioEnum), 6, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A512ComisionesInventarioEnum), "ZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesInventarioEnum_Jsonclick, 0, "Attribute", "", "", "", "", edtComisionesInventarioEnum_Visible, 0, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ComisionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4B2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Comisiones General", ""), 0) ;
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
               STRUP4B0( ) ;
            }
         }
      }

      protected void WS4B2( )
      {
         START4B2( ) ;
         EVT4B2( ) ;
      }

      protected void EVT4B2( )
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
                                 STRUP4B0( ) ;
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
                                 STRUP4B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E114B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E124B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E134B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4B0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E144B2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4B0( ) ;
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
                                 STRUP4B0( ) ;
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

      protected void WE4B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4B2( ) ;
            }
         }
      }

      protected void PA4B2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "comisionesgeneral.aspx")), "comisionesgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "comisionesgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ComisionesID");
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
         if ( cmbComisionesEstado.ItemCount > 0 )
         {
            A511ComisionesEstado = cmbComisionesEstado.getValidValue(A511ComisionesEstado);
            n511ComisionesEstado = false;
            AssignAttri(sPrefix, false, "A511ComisionesEstado", A511ComisionesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbComisionesEstado.CurrentValue = StringUtil.RTrim( A511ComisionesEstado);
            AssignProp(sPrefix, false, cmbComisionesEstado_Internalname, "Values", cmbComisionesEstado.ToJavascriptSource(), true);
         }
         if ( cmbComisionesTipo.ItemCount > 0 )
         {
            A505ComisionesTipo = cmbComisionesTipo.getValidValue(A505ComisionesTipo);
            AssignAttri(sPrefix, false, "A505ComisionesTipo", A505ComisionesTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbComisionesTipo.CurrentValue = StringUtil.RTrim( A505ComisionesTipo);
            AssignProp(sPrefix, false, cmbComisionesTipo_Internalname, "Values", cmbComisionesTipo.ToJavascriptSource(), true);
         }
         A520ComisionesGlobal = StringUtil.StrToBool( StringUtil.BoolToStr( A520ComisionesGlobal));
         n520ComisionesGlobal = false;
         AssignAttri(sPrefix, false, "A520ComisionesGlobal", A520ComisionesGlobal);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ComisionesGeneral";
      }

      protected void RF4B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H004B2 */
            pr_default.execute(0, new Object[] {A503ComisionesID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A512ComisionesInventarioEnum = H004B2_A512ComisionesInventarioEnum[0];
               n512ComisionesInventarioEnum = H004B2_n512ComisionesInventarioEnum[0];
               AssignAttri(sPrefix, false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
               A510ComisionesFechaVencimiento = H004B2_A510ComisionesFechaVencimiento[0];
               n510ComisionesFechaVencimiento = H004B2_n510ComisionesFechaVencimiento[0];
               AssignAttri(sPrefix, false, "A510ComisionesFechaVencimiento", context.localUtil.TToC( A510ComisionesFechaVencimiento, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A509ComisionesFechaVigencia = H004B2_A509ComisionesFechaVigencia[0];
               n509ComisionesFechaVigencia = H004B2_n509ComisionesFechaVigencia[0];
               AssignAttri(sPrefix, false, "A509ComisionesFechaVigencia", context.localUtil.TToC( A509ComisionesFechaVigencia, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A508ComisionesEspermanente = H004B2_A508ComisionesEspermanente[0];
               n508ComisionesEspermanente = H004B2_n508ComisionesEspermanente[0];
               AssignAttri(sPrefix, false, "A508ComisionesEspermanente", A508ComisionesEspermanente);
               A507ComisionesFechaAlta = H004B2_A507ComisionesFechaAlta[0];
               n507ComisionesFechaAlta = H004B2_n507ComisionesFechaAlta[0];
               AssignAttri(sPrefix, false, "A507ComisionesFechaAlta", context.localUtil.TToC( A507ComisionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A518ComisionesComentario = H004B2_A518ComisionesComentario[0];
               n518ComisionesComentario = H004B2_n518ComisionesComentario[0];
               AssignAttri(sPrefix, false, "A518ComisionesComentario", A518ComisionesComentario);
               A40000ComisionesImagen_GXI = H004B2_A40000ComisionesImagen_GXI[0];
               n40000ComisionesImagen_GXI = H004B2_n40000ComisionesImagen_GXI[0];
               AssignProp(sPrefix, false, imgComisionesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A519ComisionesImagen))), true);
               AssignProp(sPrefix, false, imgComisionesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A519ComisionesImagen), true);
               A520ComisionesGlobal = H004B2_A520ComisionesGlobal[0];
               n520ComisionesGlobal = H004B2_n520ComisionesGlobal[0];
               AssignAttri(sPrefix, false, "A520ComisionesGlobal", A520ComisionesGlobal);
               A506ComisionesDefault = H004B2_A506ComisionesDefault[0];
               n506ComisionesDefault = H004B2_n506ComisionesDefault[0];
               AssignAttri(sPrefix, false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
               A504ComisionesNombre = H004B2_A504ComisionesNombre[0];
               AssignAttri(sPrefix, false, "A504ComisionesNombre", A504ComisionesNombre);
               A505ComisionesTipo = H004B2_A505ComisionesTipo[0];
               AssignAttri(sPrefix, false, "A505ComisionesTipo", A505ComisionesTipo);
               A511ComisionesEstado = H004B2_A511ComisionesEstado[0];
               n511ComisionesEstado = H004B2_n511ComisionesEstado[0];
               AssignAttri(sPrefix, false, "A511ComisionesEstado", A511ComisionesEstado);
               A519ComisionesImagen = H004B2_A519ComisionesImagen[0];
               n519ComisionesImagen = H004B2_n519ComisionesImagen[0];
               AssignAttri(sPrefix, false, "A519ComisionesImagen", A519ComisionesImagen);
               AssignProp(sPrefix, false, imgComisionesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A519ComisionesImagen))), true);
               AssignProp(sPrefix, false, imgComisionesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A519ComisionesImagen), true);
               /* Execute user event: Load */
               E124B2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB4B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4B2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ComisionesGeneral";
         edtComisionesID_Enabled = 0;
         AssignProp(sPrefix, false, edtComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesID_Enabled), 5, 0), true);
         cmbComisionesEstado.Enabled = 0;
         AssignProp(sPrefix, false, cmbComisionesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComisionesEstado.Enabled), 5, 0), true);
         cmbComisionesTipo.Enabled = 0;
         AssignProp(sPrefix, false, cmbComisionesTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComisionesTipo.Enabled), 5, 0), true);
         edtComisionesNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtComisionesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesNombre_Enabled), 5, 0), true);
         edtComisionesDefault_Enabled = 0;
         AssignProp(sPrefix, false, edtComisionesDefault_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesDefault_Enabled), 5, 0), true);
         chkComisionesGlobal.Enabled = 0;
         AssignProp(sPrefix, false, chkComisionesGlobal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkComisionesGlobal.Enabled), 5, 0), true);
         imgComisionesImagen_Enabled = 0;
         AssignProp(sPrefix, false, imgComisionesImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgComisionesImagen_Enabled), 5, 0), true);
         edtComisionesComentario_Enabled = 0;
         AssignProp(sPrefix, false, edtComisionesComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesComentario_Enabled), 5, 0), true);
         edtComisionesFechaAlta_Enabled = 0;
         AssignProp(sPrefix, false, edtComisionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesFechaAlta_Enabled), 5, 0), true);
         edtComisionesEspermanente_Enabled = 0;
         AssignProp(sPrefix, false, edtComisionesEspermanente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesEspermanente_Enabled), 5, 0), true);
         edtComisionesFechaVigencia_Enabled = 0;
         AssignProp(sPrefix, false, edtComisionesFechaVigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesFechaVigencia_Enabled), 5, 0), true);
         edtComisionesFechaVencimiento_Enabled = 0;
         AssignProp(sPrefix, false, edtComisionesFechaVencimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesFechaVencimiento_Enabled), 5, 0), true);
         edtComisionesInventarioEnum_Enabled = 0;
         AssignProp(sPrefix, false, edtComisionesInventarioEnum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesInventarioEnum_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114B2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA503ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA503ComisionesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            cmbComisionesEstado.CurrentValue = cgiGet( cmbComisionesEstado_Internalname);
            A511ComisionesEstado = cgiGet( cmbComisionesEstado_Internalname);
            n511ComisionesEstado = false;
            AssignAttri(sPrefix, false, "A511ComisionesEstado", A511ComisionesEstado);
            cmbComisionesTipo.CurrentValue = cgiGet( cmbComisionesTipo_Internalname);
            A505ComisionesTipo = cgiGet( cmbComisionesTipo_Internalname);
            AssignAttri(sPrefix, false, "A505ComisionesTipo", A505ComisionesTipo);
            A504ComisionesNombre = cgiGet( edtComisionesNombre_Internalname);
            AssignAttri(sPrefix, false, "A504ComisionesNombre", A504ComisionesNombre);
            A506ComisionesDefault = context.localUtil.CToN( cgiGet( edtComisionesDefault_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n506ComisionesDefault = false;
            AssignAttri(sPrefix, false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
            A520ComisionesGlobal = StringUtil.StrToBool( cgiGet( chkComisionesGlobal_Internalname));
            n520ComisionesGlobal = false;
            AssignAttri(sPrefix, false, "A520ComisionesGlobal", A520ComisionesGlobal);
            A519ComisionesImagen = cgiGet( imgComisionesImagen_Internalname);
            n519ComisionesImagen = false;
            AssignAttri(sPrefix, false, "A519ComisionesImagen", A519ComisionesImagen);
            A518ComisionesComentario = cgiGet( edtComisionesComentario_Internalname);
            n518ComisionesComentario = false;
            AssignAttri(sPrefix, false, "A518ComisionesComentario", A518ComisionesComentario);
            A507ComisionesFechaAlta = context.localUtil.CToT( cgiGet( edtComisionesFechaAlta_Internalname));
            n507ComisionesFechaAlta = false;
            AssignAttri(sPrefix, false, "A507ComisionesFechaAlta", context.localUtil.TToC( A507ComisionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A508ComisionesEspermanente = StringUtil.StrToBool( cgiGet( edtComisionesEspermanente_Internalname));
            n508ComisionesEspermanente = false;
            AssignAttri(sPrefix, false, "A508ComisionesEspermanente", A508ComisionesEspermanente);
            A509ComisionesFechaVigencia = context.localUtil.CToT( cgiGet( edtComisionesFechaVigencia_Internalname));
            n509ComisionesFechaVigencia = false;
            AssignAttri(sPrefix, false, "A509ComisionesFechaVigencia", context.localUtil.TToC( A509ComisionesFechaVigencia, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A510ComisionesFechaVencimiento = context.localUtil.CToT( cgiGet( edtComisionesFechaVencimiento_Internalname));
            n510ComisionesFechaVencimiento = false;
            AssignAttri(sPrefix, false, "A510ComisionesFechaVencimiento", context.localUtil.TToC( A510ComisionesFechaVencimiento, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A512ComisionesInventarioEnum = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtComisionesInventarioEnum_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n512ComisionesInventarioEnum = false;
            AssignAttri(sPrefix, false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ComisionesGeneral");
            A505ComisionesTipo = cgiGet( cmbComisionesTipo_Internalname);
            AssignAttri(sPrefix, false, "A505ComisionesTipo", A505ComisionesTipo);
            forbiddenHiddens.Add("ComisionesTipo", StringUtil.RTrim( context.localUtil.Format( A505ComisionesTipo, "")));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("comisionesgeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E114B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E114B2( )
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

      protected void E124B2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtComisionesFechaAlta_Visible = 0;
         AssignProp(sPrefix, false, edtComisionesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComisionesFechaAlta_Visible), 5, 0), true);
         edtComisionesEspermanente_Visible = 0;
         AssignProp(sPrefix, false, edtComisionesEspermanente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComisionesEspermanente_Visible), 5, 0), true);
         edtComisionesFechaVigencia_Visible = 0;
         AssignProp(sPrefix, false, edtComisionesFechaVigencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComisionesFechaVigencia_Visible), 5, 0), true);
         edtComisionesFechaVencimiento_Visible = 0;
         AssignProp(sPrefix, false, edtComisionesFechaVencimiento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComisionesFechaVencimiento_Visible), 5, 0), true);
         edtComisionesInventarioEnum_Visible = 0;
         AssignProp(sPrefix, false, edtComisionesInventarioEnum_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtComisionesInventarioEnum_Visible), 5, 0), true);
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisiones_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisiones_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) )
         {
            chkComisionesGlobal.Visible = 0;
            AssignProp(sPrefix, false, chkComisionesGlobal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkComisionesGlobal.Visible), 5, 0), true);
            divComisionesglobal_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divComisionesglobal_cell_Internalname, "Class", divComisionesglobal_cell_Class, true);
         }
         else
         {
            chkComisionesGlobal.Visible = 1;
            AssignProp(sPrefix, false, chkComisionesGlobal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkComisionesGlobal.Visible), 5, 0), true);
            divComisionesglobal_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp(sPrefix, false, divComisionesglobal_cell_Internalname, "Class", divComisionesglobal_cell_Class, true);
         }
      }

      protected void E134B2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "comisiones.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A503ComisionesID,18,0));
         CallWebObject(formatLink("comisiones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E144B2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "comisiones.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A503ComisionesID,18,0));
         CallWebObject(formatLink("comisiones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Transactionname = "Comisiones";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A503ComisionesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
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
         PA4B2( ) ;
         WS4B2( ) ;
         WE4B2( ) ;
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
         sCtrlA503ComisionesID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4B2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "comisionesgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4B2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A503ComisionesID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
         }
         wcpOA503ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA503ComisionesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A503ComisionesID != wcpOA503ComisionesID ) ) )
         {
            setjustcreated();
         }
         wcpOA503ComisionesID = A503ComisionesID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA503ComisionesID = cgiGet( sPrefix+"A503ComisionesID_CTRL");
         if ( StringUtil.Len( sCtrlA503ComisionesID) > 0 )
         {
            A503ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA503ComisionesID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
         }
         else
         {
            A503ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A503ComisionesID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA4B2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4B2( ) ;
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
         WS4B2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A503ComisionesID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A503ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA503ComisionesID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A503ComisionesID_CTRL", StringUtil.RTrim( sCtrlA503ComisionesID));
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
         WE4B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932074531", true, true, false);
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
         context.AddJavascriptSource("comisionesgeneral.js", "?2026932074531", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbComisionesEstado.Name = "COMISIONESESTADO";
         cmbComisionesEstado.WebTags = "";
         cmbComisionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbComisionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbComisionesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbComisionesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbComisionesEstado.ItemCount > 0 )
         {
         }
         cmbComisionesTipo.Name = "COMISIONESTIPO";
         cmbComisionesTipo.WebTags = "";
         cmbComisionesTipo.addItem("P", context.GetMessage( "Profesional", ""), 0);
         cmbComisionesTipo.addItem("C", context.GetMessage( "Comercio", ""), 0);
         cmbComisionesTipo.addItem("Z", context.GetMessage( "Zona", ""), 0);
         if ( cmbComisionesTipo.ItemCount > 0 )
         {
         }
         chkComisionesGlobal.Name = "COMISIONESGLOBAL";
         chkComisionesGlobal.WebTags = "";
         chkComisionesGlobal.Caption = context.GetMessage( "Comisión Global", "");
         AssignProp(sPrefix, false, chkComisionesGlobal_Internalname, "TitleCaption", chkComisionesGlobal.Caption, true);
         chkComisionesGlobal.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtComisionesID_Internalname = sPrefix+"COMISIONESID";
         cmbComisionesEstado_Internalname = sPrefix+"COMISIONESESTADO";
         cmbComisionesTipo_Internalname = sPrefix+"COMISIONESTIPO";
         edtComisionesNombre_Internalname = sPrefix+"COMISIONESNOMBRE";
         edtComisionesDefault_Internalname = sPrefix+"COMISIONESDEFAULT";
         chkComisionesGlobal_Internalname = sPrefix+"COMISIONESGLOBAL";
         divComisionesglobal_cell_Internalname = sPrefix+"COMISIONESGLOBAL_CELL";
         divTransactiondetail_tb1_Internalname = sPrefix+"TRANSACTIONDETAIL_TB1";
         imgComisionesImagen_Internalname = sPrefix+"COMISIONESIMAGEN";
         divTransactiondetail_tb2_Internalname = sPrefix+"TRANSACTIONDETAIL_TB2";
         edtComisionesComentario_Internalname = sPrefix+"COMISIONESCOMENTARIO";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtComisionesFechaAlta_Internalname = sPrefix+"COMISIONESFECHAALTA";
         edtComisionesEspermanente_Internalname = sPrefix+"COMISIONESESPERMANENTE";
         edtComisionesFechaVigencia_Internalname = sPrefix+"COMISIONESFECHAVIGENCIA";
         edtComisionesFechaVencimiento_Internalname = sPrefix+"COMISIONESFECHAVENCIMIENTO";
         edtComisionesInventarioEnum_Internalname = sPrefix+"COMISIONESINVENTARIOENUM";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
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
         chkComisionesGlobal.Caption = context.GetMessage( "Comisión Global", "");
         edtComisionesInventarioEnum_Enabled = 0;
         edtComisionesFechaVencimiento_Enabled = 0;
         edtComisionesFechaVigencia_Enabled = 0;
         edtComisionesEspermanente_Enabled = 0;
         edtComisionesFechaAlta_Enabled = 0;
         imgComisionesImagen_Enabled = 0;
         edtComisionesInventarioEnum_Jsonclick = "";
         edtComisionesInventarioEnum_Visible = 1;
         edtComisionesFechaVencimiento_Jsonclick = "";
         edtComisionesFechaVencimiento_Visible = 1;
         edtComisionesFechaVigencia_Jsonclick = "";
         edtComisionesFechaVigencia_Visible = 1;
         edtComisionesEspermanente_Jsonclick = "";
         edtComisionesEspermanente_Visible = 1;
         edtComisionesFechaAlta_Jsonclick = "";
         edtComisionesFechaAlta_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtComisionesComentario_Enabled = 0;
         chkComisionesGlobal.Enabled = 0;
         chkComisionesGlobal.Visible = 1;
         divComisionesglobal_cell_Class = "col-xs-12";
         edtComisionesDefault_Jsonclick = "";
         edtComisionesDefault_Enabled = 0;
         edtComisionesNombre_Jsonclick = "";
         edtComisionesNombre_Enabled = 0;
         cmbComisionesTipo_Jsonclick = "";
         cmbComisionesTipo.Enabled = 0;
         cmbComisionesEstado_Jsonclick = "";
         cmbComisionesEstado.Enabled = 0;
         edtComisionesID_Jsonclick = "";
         edtComisionesID_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A503ComisionesID',fld:'COMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A520ComisionesGlobal',fld:'COMISIONESGLOBAL',pic:'',type:'boolean'},{av:'cmbComisionesTipo'},{av:'A505ComisionesTipo',fld:'COMISIONESTIPO',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E134B2',iparms:[{av:'A503ComisionesID',fld:'COMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E144B2',iparms:[{av:'A503ComisionesID',fld:'COMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_COMISIONESID","{handler:'Valid_Comisionesid',iparms:[]");
         setEventMetadata("VALID_COMISIONESID",",oparms:[]}");
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
         A505ComisionesTipo = "";
         GX_FocusControl = "";
         TempTags = "";
         A511ComisionesEstado = "";
         A504ComisionesNombre = "";
         ClassString = "";
         StyleString = "";
         A519ComisionesImagen = "";
         A40000ComisionesImagen_GXI = "";
         sImgUrl = "";
         A518ComisionesComentario = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A507ComisionesFechaAlta = (DateTime)(DateTime.MinValue);
         A509ComisionesFechaVigencia = (DateTime)(DateTime.MinValue);
         A510ComisionesFechaVencimiento = (DateTime)(DateTime.MinValue);
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H004B2_A503ComisionesID = new long[1] ;
         H004B2_A512ComisionesInventarioEnum = new int[1] ;
         H004B2_n512ComisionesInventarioEnum = new bool[] {false} ;
         H004B2_A510ComisionesFechaVencimiento = new DateTime[] {DateTime.MinValue} ;
         H004B2_n510ComisionesFechaVencimiento = new bool[] {false} ;
         H004B2_A509ComisionesFechaVigencia = new DateTime[] {DateTime.MinValue} ;
         H004B2_n509ComisionesFechaVigencia = new bool[] {false} ;
         H004B2_A508ComisionesEspermanente = new bool[] {false} ;
         H004B2_n508ComisionesEspermanente = new bool[] {false} ;
         H004B2_A507ComisionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H004B2_n507ComisionesFechaAlta = new bool[] {false} ;
         H004B2_A518ComisionesComentario = new string[] {""} ;
         H004B2_n518ComisionesComentario = new bool[] {false} ;
         H004B2_A40000ComisionesImagen_GXI = new string[] {""} ;
         H004B2_n40000ComisionesImagen_GXI = new bool[] {false} ;
         H004B2_A520ComisionesGlobal = new bool[] {false} ;
         H004B2_n520ComisionesGlobal = new bool[] {false} ;
         H004B2_A506ComisionesDefault = new decimal[1] ;
         H004B2_n506ComisionesDefault = new bool[] {false} ;
         H004B2_A504ComisionesNombre = new string[] {""} ;
         H004B2_A505ComisionesTipo = new string[] {""} ;
         H004B2_A511ComisionesEstado = new string[] {""} ;
         H004B2_n511ComisionesEstado = new bool[] {false} ;
         H004B2_A519ComisionesImagen = new string[] {""} ;
         H004B2_n519ComisionesImagen = new bool[] {false} ;
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA503ComisionesID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesgeneral__default(),
            new Object[][] {
                new Object[] {
               H004B2_A503ComisionesID, H004B2_A512ComisionesInventarioEnum, H004B2_n512ComisionesInventarioEnum, H004B2_A510ComisionesFechaVencimiento, H004B2_n510ComisionesFechaVencimiento, H004B2_A509ComisionesFechaVigencia, H004B2_n509ComisionesFechaVigencia, H004B2_A508ComisionesEspermanente, H004B2_n508ComisionesEspermanente, H004B2_A507ComisionesFechaAlta,
               H004B2_n507ComisionesFechaAlta, H004B2_A518ComisionesComentario, H004B2_n518ComisionesComentario, H004B2_A40000ComisionesImagen_GXI, H004B2_n40000ComisionesImagen_GXI, H004B2_A520ComisionesGlobal, H004B2_n520ComisionesGlobal, H004B2_A506ComisionesDefault, H004B2_n506ComisionesDefault, H004B2_A504ComisionesNombre,
               H004B2_A505ComisionesTipo, H004B2_A511ComisionesEstado, H004B2_n511ComisionesEstado, H004B2_A519ComisionesImagen, H004B2_n519ComisionesImagen
               }
            }
         );
         AV13Pgmname = "ComisionesGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ComisionesGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtComisionesID_Enabled ;
      private int edtComisionesNombre_Enabled ;
      private int edtComisionesDefault_Enabled ;
      private int edtComisionesComentario_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtComisionesFechaAlta_Visible ;
      private int edtComisionesEspermanente_Visible ;
      private int edtComisionesFechaVigencia_Visible ;
      private int edtComisionesFechaVencimiento_Visible ;
      private int A512ComisionesInventarioEnum ;
      private int edtComisionesInventarioEnum_Visible ;
      private int imgComisionesImagen_Enabled ;
      private int edtComisionesFechaAlta_Enabled ;
      private int edtComisionesEspermanente_Enabled ;
      private int edtComisionesFechaVigencia_Enabled ;
      private int edtComisionesFechaVencimiento_Enabled ;
      private int edtComisionesInventarioEnum_Enabled ;
      private int idxLst ;
      private long A503ComisionesID ;
      private long wcpOA503ComisionesID ;
      private decimal A506ComisionesDefault ;
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
      private string A505ComisionesTipo ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtComisionesID_Internalname ;
      private string TempTags ;
      private string edtComisionesID_Jsonclick ;
      private string cmbComisionesEstado_Internalname ;
      private string A511ComisionesEstado ;
      private string cmbComisionesEstado_Jsonclick ;
      private string divTransactiondetail_tb1_Internalname ;
      private string cmbComisionesTipo_Internalname ;
      private string cmbComisionesTipo_Jsonclick ;
      private string edtComisionesNombre_Internalname ;
      private string A504ComisionesNombre ;
      private string edtComisionesNombre_Jsonclick ;
      private string edtComisionesDefault_Internalname ;
      private string edtComisionesDefault_Jsonclick ;
      private string divComisionesglobal_cell_Internalname ;
      private string divComisionesglobal_cell_Class ;
      private string chkComisionesGlobal_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTransactiondetail_tb2_Internalname ;
      private string imgComisionesImagen_Internalname ;
      private string sImgUrl ;
      private string edtComisionesComentario_Internalname ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtComisionesFechaAlta_Internalname ;
      private string edtComisionesFechaAlta_Jsonclick ;
      private string edtComisionesEspermanente_Internalname ;
      private string edtComisionesEspermanente_Jsonclick ;
      private string edtComisionesFechaVigencia_Internalname ;
      private string edtComisionesFechaVigencia_Jsonclick ;
      private string edtComisionesFechaVencimiento_Internalname ;
      private string edtComisionesFechaVencimiento_Jsonclick ;
      private string edtComisionesInventarioEnum_Internalname ;
      private string edtComisionesInventarioEnum_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string hsh ;
      private string sCtrlA503ComisionesID ;
      private DateTime A507ComisionesFechaAlta ;
      private DateTime A509ComisionesFechaVigencia ;
      private DateTime A510ComisionesFechaVencimiento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A520ComisionesGlobal ;
      private bool A519ComisionesImagen_IsBlob ;
      private bool A508ComisionesEspermanente ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n511ComisionesEstado ;
      private bool n520ComisionesGlobal ;
      private bool gxdyncontrolsrefreshing ;
      private bool n512ComisionesInventarioEnum ;
      private bool n510ComisionesFechaVencimiento ;
      private bool n509ComisionesFechaVigencia ;
      private bool n508ComisionesEspermanente ;
      private bool n507ComisionesFechaAlta ;
      private bool n518ComisionesComentario ;
      private bool n40000ComisionesImagen_GXI ;
      private bool n506ComisionesDefault ;
      private bool n519ComisionesImagen ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A518ComisionesComentario ;
      private string A40000ComisionesImagen_GXI ;
      private string A519ComisionesImagen ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbComisionesEstado ;
      private GXCombobox cmbComisionesTipo ;
      private GXCheckbox chkComisionesGlobal ;
      private IDataStoreProvider pr_default ;
      private long[] H004B2_A503ComisionesID ;
      private int[] H004B2_A512ComisionesInventarioEnum ;
      private bool[] H004B2_n512ComisionesInventarioEnum ;
      private DateTime[] H004B2_A510ComisionesFechaVencimiento ;
      private bool[] H004B2_n510ComisionesFechaVencimiento ;
      private DateTime[] H004B2_A509ComisionesFechaVigencia ;
      private bool[] H004B2_n509ComisionesFechaVigencia ;
      private bool[] H004B2_A508ComisionesEspermanente ;
      private bool[] H004B2_n508ComisionesEspermanente ;
      private DateTime[] H004B2_A507ComisionesFechaAlta ;
      private bool[] H004B2_n507ComisionesFechaAlta ;
      private string[] H004B2_A518ComisionesComentario ;
      private bool[] H004B2_n518ComisionesComentario ;
      private string[] H004B2_A40000ComisionesImagen_GXI ;
      private bool[] H004B2_n40000ComisionesImagen_GXI ;
      private bool[] H004B2_A520ComisionesGlobal ;
      private bool[] H004B2_n520ComisionesGlobal ;
      private decimal[] H004B2_A506ComisionesDefault ;
      private bool[] H004B2_n506ComisionesDefault ;
      private string[] H004B2_A504ComisionesNombre ;
      private string[] H004B2_A505ComisionesTipo ;
      private string[] H004B2_A511ComisionesEstado ;
      private bool[] H004B2_n511ComisionesEstado ;
      private string[] H004B2_A519ComisionesImagen ;
      private bool[] H004B2_n519ComisionesImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class comisionesgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004B2;
          prmH004B2 = new Object[] {
          new ParDef("@ComisionesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004B2", "SELECT [ComisionesID], [ComisionesInventarioEnum], [ComisionesFechaVencimiento], [ComisionesFechaVigencia], [ComisionesEspermanente], [ComisionesFechaAlta], [ComisionesComentario], [ComisionesImagen_GXI], [ComisionesGlobal], [ComisionesDefault], [ComisionesNombre], [ComisionesTipo], [ComisionesEstado], [ComisionesImagen] FROM [Comisiones] WHERE [ComisionesID] = @ComisionesID ORDER BY [ComisionesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004B2,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getMultimediaUri(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getString(11, 80);
                ((string[]) buf[20])[0] = rslt.getString(12, 1);
                ((string[]) buf[21])[0] = rslt.getString(13, 3);
                ((bool[]) buf[22])[0] = rslt.wasNull(13);
                ((string[]) buf[23])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(8));
                ((bool[]) buf[24])[0] = rslt.wasNull(14);
                return;
       }
    }

 }

}
