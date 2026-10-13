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
   public class clientesgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public clientesgeneral( )
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

      public clientesgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ClientesId )
      {
         this.A106ClientesId = aP0_ClientesId;
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
         cmbClientesEstado = new GXCombobox();
         dynDepartamentoId = new GXCombobox();
         dynDepartamentoMunicipioId = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ClientesId");
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
                  A106ClientesId = (long)(Math.Round(NumberUtil.Val( GetPar( "ClientesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A106ClientesId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"DEPARTAMENTOMUNICIPIOID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLADEPARTAMENTOMUNICIPIOID3G2( ) ;
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
                  gxfirstwebparm = GetFirstPar( "ClientesId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ClientesId");
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
            PA3G2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ClientesGeneral";
               GXADEPARTAMENTOMUNICIPIOID_html3G2( ) ;
               WS3G2( ) ;
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
            context.SendWebValue( context.GetMessage( "Clientes General", "")) ;
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
            GXEncryptionTmp = "clientesgeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A106ClientesId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clientesgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA106ClientesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA106ClientesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseForm3G2( )
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
         return "ClientesGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Clientes General", "") ;
      }

      protected void WB3G0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "clientesgeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClientesId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtClientesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106ClientesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtClientesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A106ClientesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A106ClientesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClientesId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbClientesEstado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbClientesEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbClientesEstado, cmbClientesEstado_Internalname, StringUtil.RTrim( A435ClientesEstado), 1, cmbClientesEstado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbClientesEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "", true, 0, "HLP_ClientesGeneral.htm");
            cmbClientesEstado.CurrentValue = StringUtil.RTrim( A435ClientesEstado);
            AssignProp(sPrefix, false, cmbClientesEstado_Internalname, "Values", (string)(cmbClientesEstado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClientesNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtClientesNombre_Internalname, StringUtil.RTrim( A160ClientesNombre), StringUtil.RTrim( context.localUtil.Format( A160ClientesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClientesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesIdentidad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClientesIdentidad_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtClientesIdentidad_Internalname, StringUtil.RTrim( A434ClientesIdentidad), StringUtil.RTrim( context.localUtil.Format( A434ClientesIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesIdentidad_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClientesIdentidad_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesTelefono_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClientesTelefono_Internalname, context.GetMessage( "Telefóno", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A161ClientesTelefono);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtClientesTelefono_Internalname, StringUtil.RTrim( A161ClientesTelefono), StringUtil.RTrim( context.localUtil.Format( A161ClientesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtClientesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClientesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClientesEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtClientesEmail_Internalname, A162ClientesEmail, StringUtil.RTrim( context.localUtil.Format( A162ClientesEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A162ClientesEmail, "", "", "", edtClientesEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClientesEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynDepartamentoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynDepartamentoId_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoId, dynDepartamentoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0)), 1, dynDepartamentoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "", true, 0, "HLP_ClientesGeneral.htm");
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoId_Internalname, "Values", (string)(dynDepartamentoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynDepartamentoMunicipioId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynDepartamentoMunicipioId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoMunicipioId, dynDepartamentoMunicipioId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0)), 1, dynDepartamentoMunicipioId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoMunicipioId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_ClientesGeneral.htm");
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoMunicipioId_Internalname, "Values", (string)(dynDepartamentoMunicipioId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClientesDireccion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClientesDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtClientesDireccion_Internalname, A163ClientesDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A163ClientesDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtClientesDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgClientesImagen_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "AttributeFL";
            StyleString = "";
            A164ClientesImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ClientesImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.PathToRelativeUrl( A164ClientesImagen));
            GxWebStd.gx_bitmap( context, imgClientesImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A164ClientesImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ClientesGeneral.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClientesGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.RTrim( A116PaisID), StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "Attribute", "", "", "", "", edtPaisID_Visible, 0, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3G2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Clientes General", ""), 0) ;
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
               STRUP3G0( ) ;
            }
         }
      }

      protected void WS3G2( )
      {
         START3G2( ) ;
         EVT3G2( ) ;
      }

      protected void EVT3G2( )
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
                                 STRUP3G0( ) ;
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
                                 STRUP3G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E113G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E123G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E133G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E143G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3G0( ) ;
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
                                 STRUP3G0( ) ;
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

      protected void WE3G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3G2( ) ;
            }
         }
      }

      protected void PA3G2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "clientesgeneral.aspx")), "clientesgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "clientesgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ClientesId");
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

      protected void GXDLADEPARTAMENTOID3G1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOID_data3G1( ) ;
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

      protected void GXADEPARTAMENTOID_html3G1( )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOID_data3G1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynDepartamentoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
      }

      protected void GXDLADEPARTAMENTOID_data3G1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H003G2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H003G2_A112DepartamentoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H003G2_A113DepartamentoDepartamento[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID3G2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOMUNICIPIOID_data3G2( ) ;
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

      protected void GXADEPARTAMENTOMUNICIPIOID_html3G2( )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOMUNICIPIOID_data3G2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynDepartamentoMunicipioId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynDepartamentoMunicipioId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID_data3G2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H003G3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H003G3_A114DepartamentoMunicipioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H003G3_A115DepartamentoMunicipioNombre[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXADEPARTAMENTOMUNICIPIOID_html3G2( ) ;
            dynDepartamentoId.Name = "DEPARTAMENTOID";
            dynDepartamentoId.WebTags = "";
            dynDepartamentoId.removeAllItems();
            /* Using cursor H003G4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H003G4_A112DepartamentoId[0]), 18, 0)), H003G4_A113DepartamentoDepartamento[0], 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( dynDepartamentoId.ItemCount > 0 )
            {
               A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbClientesEstado.ItemCount > 0 )
         {
            A435ClientesEstado = cmbClientesEstado.getValidValue(A435ClientesEstado);
            AssignAttri(sPrefix, false, "A435ClientesEstado", A435ClientesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbClientesEstado.CurrentValue = StringUtil.RTrim( A435ClientesEstado);
            AssignProp(sPrefix, false, cmbClientesEstado_Internalname, "Values", cmbClientesEstado.ToJavascriptSource(), true);
         }
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoId_Internalname, "Values", dynDepartamentoId.ToJavascriptSource(), true);
         }
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoMunicipioId_Internalname, "Values", dynDepartamentoMunicipioId.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ClientesGeneral";
      }

      protected void RF3G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H003G5 */
            pr_default.execute(3, new Object[] {A106ClientesId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A116PaisID = H003G5_A116PaisID[0];
               AssignAttri(sPrefix, false, "A116PaisID", A116PaisID);
               A40000ClientesImagen_GXI = H003G5_A40000ClientesImagen_GXI[0];
               AssignProp(sPrefix, false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
               AssignProp(sPrefix, false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
               A163ClientesDireccion = H003G5_A163ClientesDireccion[0];
               AssignAttri(sPrefix, false, "A163ClientesDireccion", A163ClientesDireccion);
               A114DepartamentoMunicipioId = H003G5_A114DepartamentoMunicipioId[0];
               AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
               A112DepartamentoId = H003G5_A112DepartamentoId[0];
               AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               A162ClientesEmail = H003G5_A162ClientesEmail[0];
               AssignAttri(sPrefix, false, "A162ClientesEmail", A162ClientesEmail);
               A161ClientesTelefono = H003G5_A161ClientesTelefono[0];
               AssignAttri(sPrefix, false, "A161ClientesTelefono", A161ClientesTelefono);
               A434ClientesIdentidad = H003G5_A434ClientesIdentidad[0];
               AssignAttri(sPrefix, false, "A434ClientesIdentidad", A434ClientesIdentidad);
               A160ClientesNombre = H003G5_A160ClientesNombre[0];
               AssignAttri(sPrefix, false, "A160ClientesNombre", A160ClientesNombre);
               A435ClientesEstado = H003G5_A435ClientesEstado[0];
               AssignAttri(sPrefix, false, "A435ClientesEstado", A435ClientesEstado);
               A164ClientesImagen = H003G5_A164ClientesImagen[0];
               AssignAttri(sPrefix, false, "A164ClientesImagen", A164ClientesImagen);
               AssignProp(sPrefix, false, imgClientesImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A164ClientesImagen)) ? A40000ClientesImagen_GXI : context.convertURL( context.PathToRelativeUrl( A164ClientesImagen))), true);
               AssignProp(sPrefix, false, imgClientesImagen_Internalname, "SrcSet", context.GetImageSrcSet( A164ClientesImagen), true);
               A116PaisID = H003G5_A116PaisID[0];
               AssignAttri(sPrefix, false, "A116PaisID", A116PaisID);
               GXADEPARTAMENTOMUNICIPIOID_html3G2( ) ;
               /* Execute user event: Load */
               E123G2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            WB3G0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3G2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ClientesGeneral";
         GXADEPARTAMENTOMUNICIPIOID_html3G2( ) ;
         edtClientesId_Enabled = 0;
         AssignProp(sPrefix, false, edtClientesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesId_Enabled), 5, 0), true);
         cmbClientesEstado.Enabled = 0;
         AssignProp(sPrefix, false, cmbClientesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbClientesEstado.Enabled), 5, 0), true);
         edtClientesNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtClientesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesNombre_Enabled), 5, 0), true);
         edtClientesIdentidad_Enabled = 0;
         AssignProp(sPrefix, false, edtClientesIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesIdentidad_Enabled), 5, 0), true);
         edtClientesTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtClientesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesTelefono_Enabled), 5, 0), true);
         edtClientesEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtClientesEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesEmail_Enabled), 5, 0), true);
         dynDepartamentoId.Enabled = 0;
         AssignProp(sPrefix, false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), true);
         dynDepartamentoMunicipioId.Enabled = 0;
         AssignProp(sPrefix, false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), true);
         edtClientesDireccion_Enabled = 0;
         AssignProp(sPrefix, false, edtClientesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesDireccion_Enabled), 5, 0), true);
         imgClientesImagen_Enabled = 0;
         AssignProp(sPrefix, false, imgClientesImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgClientesImagen_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp(sPrefix, false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113G2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA106ClientesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA106ClientesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            cmbClientesEstado.CurrentValue = cgiGet( cmbClientesEstado_Internalname);
            A435ClientesEstado = cgiGet( cmbClientesEstado_Internalname);
            AssignAttri(sPrefix, false, "A435ClientesEstado", A435ClientesEstado);
            A160ClientesNombre = cgiGet( edtClientesNombre_Internalname);
            AssignAttri(sPrefix, false, "A160ClientesNombre", A160ClientesNombre);
            A434ClientesIdentidad = cgiGet( edtClientesIdentidad_Internalname);
            AssignAttri(sPrefix, false, "A434ClientesIdentidad", A434ClientesIdentidad);
            A161ClientesTelefono = cgiGet( edtClientesTelefono_Internalname);
            AssignAttri(sPrefix, false, "A161ClientesTelefono", A161ClientesTelefono);
            A162ClientesEmail = cgiGet( edtClientesEmail_Internalname);
            AssignAttri(sPrefix, false, "A162ClientesEmail", A162ClientesEmail);
            dynDepartamentoId.CurrentValue = cgiGet( dynDepartamentoId_Internalname);
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoId_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            dynDepartamentoMunicipioId.CurrentValue = cgiGet( dynDepartamentoMunicipioId_Internalname);
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoMunicipioId_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            A163ClientesDireccion = cgiGet( edtClientesDireccion_Internalname);
            AssignAttri(sPrefix, false, "A163ClientesDireccion", A163ClientesDireccion);
            A164ClientesImagen = cgiGet( imgClientesImagen_Internalname);
            AssignAttri(sPrefix, false, "A164ClientesImagen", A164ClientesImagen);
            A116PaisID = cgiGet( edtPaisID_Internalname);
            AssignAttri(sPrefix, false, "A116PaisID", A116PaisID);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            GXADEPARTAMENTOMUNICIPIOID_html3G2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E113G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E113G2( )
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

      protected void E123G2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtPaisID_Visible = 0;
         AssignProp(sPrefix, false, edtPaisID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaisID_Visible), 5, 0), true);
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWClientes_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWClientes_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E133G2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "clientes.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A106ClientesId,18,0));
         CallWebObject(formatLink("clientes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E143G2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "clientes.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A106ClientesId,18,0));
         CallWebObject(formatLink("clientes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Transactionname = "Clientes";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A106ClientesId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
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
         PA3G2( ) ;
         WS3G2( ) ;
         WE3G2( ) ;
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
         sCtrlA106ClientesId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3G2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "clientesgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3G2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A106ClientesId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
         }
         wcpOA106ClientesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA106ClientesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A106ClientesId != wcpOA106ClientesId ) ) )
         {
            setjustcreated();
         }
         wcpOA106ClientesId = A106ClientesId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA106ClientesId = cgiGet( sPrefix+"A106ClientesId_CTRL");
         if ( StringUtil.Len( sCtrlA106ClientesId) > 0 )
         {
            A106ClientesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA106ClientesId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A106ClientesId", StringUtil.LTrimStr( (decimal)(A106ClientesId), 18, 0));
         }
         else
         {
            A106ClientesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A106ClientesId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA3G2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3G2( ) ;
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
         WS3G2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A106ClientesId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106ClientesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA106ClientesId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A106ClientesId_CTRL", StringUtil.RTrim( sCtrlA106ClientesId));
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
         WE3G2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269319583856", true, true, false);
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
         context.AddJavascriptSource("clientesgeneral.js", "?20269319583856", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbClientesEstado.Name = "CLIENTESESTADO";
         cmbClientesEstado.WebTags = "";
         cmbClientesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbClientesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbClientesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbClientesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbClientesEstado.ItemCount > 0 )
         {
         }
         dynDepartamentoId.Name = "DEPARTAMENTOID";
         dynDepartamentoId.WebTags = "";
         dynDepartamentoId.removeAllItems();
         /* Using cursor H003G6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H003G6_A112DepartamentoId[0]), 18, 0)), H003G6_A113DepartamentoDepartamento[0], 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( dynDepartamentoId.ItemCount > 0 )
         {
         }
         dynDepartamentoMunicipioId.Name = "DEPARTAMENTOMUNICIPIOID";
         dynDepartamentoMunicipioId.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtClientesId_Internalname = sPrefix+"CLIENTESID";
         cmbClientesEstado_Internalname = sPrefix+"CLIENTESESTADO";
         edtClientesNombre_Internalname = sPrefix+"CLIENTESNOMBRE";
         edtClientesIdentidad_Internalname = sPrefix+"CLIENTESIDENTIDAD";
         edtClientesTelefono_Internalname = sPrefix+"CLIENTESTELEFONO";
         edtClientesEmail_Internalname = sPrefix+"CLIENTESEMAIL";
         dynDepartamentoId_Internalname = sPrefix+"DEPARTAMENTOID";
         dynDepartamentoMunicipioId_Internalname = sPrefix+"DEPARTAMENTOMUNICIPIOID";
         edtClientesDireccion_Internalname = sPrefix+"CLIENTESDIRECCION";
         imgClientesImagen_Internalname = sPrefix+"CLIENTESIMAGEN";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtPaisID_Internalname = sPrefix+"PAISID";
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
         edtPaisID_Enabled = 0;
         imgClientesImagen_Enabled = 0;
         edtPaisID_Jsonclick = "";
         edtPaisID_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtClientesDireccion_Enabled = 0;
         dynDepartamentoMunicipioId_Jsonclick = "";
         dynDepartamentoMunicipioId.Enabled = 0;
         dynDepartamentoId_Jsonclick = "";
         dynDepartamentoId.Enabled = 0;
         edtClientesEmail_Jsonclick = "";
         edtClientesEmail_Enabled = 0;
         edtClientesTelefono_Jsonclick = "";
         edtClientesTelefono_Enabled = 0;
         edtClientesIdentidad_Jsonclick = "";
         edtClientesIdentidad_Enabled = 0;
         edtClientesNombre_Jsonclick = "";
         edtClientesNombre_Enabled = 0;
         cmbClientesEstado_Jsonclick = "";
         cmbClientesEstado.Enabled = 0;
         edtClientesId_Jsonclick = "";
         edtClientesId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A106ClientesId',fld:'CLIENTESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E133G2',iparms:[{av:'A106ClientesId',fld:'CLIENTESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E143G2',iparms:[{av:'A106ClientesId',fld:'CLIENTESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_CLIENTESID","{handler:'Valid_Clientesid',iparms:[]");
         setEventMetadata("VALID_CLIENTESID",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[]}");
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
         GX_FocusControl = "";
         TempTags = "";
         A435ClientesEstado = "";
         A160ClientesNombre = "";
         A434ClientesIdentidad = "";
         gxphoneLink = "";
         A161ClientesTelefono = "";
         A162ClientesEmail = "";
         ClassString = "";
         StyleString = "";
         A163ClientesDireccion = "";
         A164ClientesImagen = "";
         A40000ClientesImagen_GXI = "";
         sImgUrl = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A116PaisID = "";
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
         H003G2_A112DepartamentoId = new long[1] ;
         H003G2_A113DepartamentoDepartamento = new string[] {""} ;
         H003G3_A112DepartamentoId = new long[1] ;
         H003G3_A114DepartamentoMunicipioId = new long[1] ;
         H003G3_A115DepartamentoMunicipioNombre = new string[] {""} ;
         H003G4_A112DepartamentoId = new long[1] ;
         H003G4_A113DepartamentoDepartamento = new string[] {""} ;
         H003G5_A106ClientesId = new long[1] ;
         H003G5_A116PaisID = new string[] {""} ;
         H003G5_A40000ClientesImagen_GXI = new string[] {""} ;
         H003G5_A163ClientesDireccion = new string[] {""} ;
         H003G5_A114DepartamentoMunicipioId = new long[1] ;
         H003G5_A112DepartamentoId = new long[1] ;
         H003G5_A162ClientesEmail = new string[] {""} ;
         H003G5_A161ClientesTelefono = new string[] {""} ;
         H003G5_A434ClientesIdentidad = new string[] {""} ;
         H003G5_A160ClientesNombre = new string[] {""} ;
         H003G5_A435ClientesEstado = new string[] {""} ;
         H003G5_A164ClientesImagen = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA106ClientesId = "";
         H003G6_A112DepartamentoId = new long[1] ;
         H003G6_A113DepartamentoDepartamento = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientesgeneral__default(),
            new Object[][] {
                new Object[] {
               H003G2_A112DepartamentoId, H003G2_A113DepartamentoDepartamento
               }
               , new Object[] {
               H003G3_A112DepartamentoId, H003G3_A114DepartamentoMunicipioId, H003G3_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               H003G4_A112DepartamentoId, H003G4_A113DepartamentoDepartamento
               }
               , new Object[] {
               H003G5_A106ClientesId, H003G5_A116PaisID, H003G5_A40000ClientesImagen_GXI, H003G5_A163ClientesDireccion, H003G5_A114DepartamentoMunicipioId, H003G5_A112DepartamentoId, H003G5_A162ClientesEmail, H003G5_A161ClientesTelefono, H003G5_A434ClientesIdentidad, H003G5_A160ClientesNombre,
               H003G5_A435ClientesEstado, H003G5_A164ClientesImagen
               }
               , new Object[] {
               H003G6_A112DepartamentoId, H003G6_A113DepartamentoDepartamento
               }
            }
         );
         AV13Pgmname = "ClientesGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ClientesGeneral";
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
      private int edtClientesId_Enabled ;
      private int edtClientesNombre_Enabled ;
      private int edtClientesIdentidad_Enabled ;
      private int edtClientesTelefono_Enabled ;
      private int edtClientesEmail_Enabled ;
      private int edtClientesDireccion_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtPaisID_Visible ;
      private int gxdynajaxindex ;
      private int imgClientesImagen_Enabled ;
      private int edtPaisID_Enabled ;
      private int idxLst ;
      private long A106ClientesId ;
      private long wcpOA106ClientesId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
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
      private string edtClientesId_Internalname ;
      private string TempTags ;
      private string edtClientesId_Jsonclick ;
      private string cmbClientesEstado_Internalname ;
      private string A435ClientesEstado ;
      private string cmbClientesEstado_Jsonclick ;
      private string edtClientesNombre_Internalname ;
      private string A160ClientesNombre ;
      private string edtClientesNombre_Jsonclick ;
      private string edtClientesIdentidad_Internalname ;
      private string A434ClientesIdentidad ;
      private string edtClientesIdentidad_Jsonclick ;
      private string edtClientesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A161ClientesTelefono ;
      private string edtClientesTelefono_Jsonclick ;
      private string edtClientesEmail_Internalname ;
      private string edtClientesEmail_Jsonclick ;
      private string dynDepartamentoId_Internalname ;
      private string dynDepartamentoId_Jsonclick ;
      private string dynDepartamentoMunicipioId_Internalname ;
      private string dynDepartamentoMunicipioId_Jsonclick ;
      private string edtClientesDireccion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string imgClientesImagen_Internalname ;
      private string sImgUrl ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtPaisID_Internalname ;
      private string A116PaisID ;
      private string edtPaisID_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string sCtrlA106ClientesId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A164ClientesImagen_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A162ClientesEmail ;
      private string A163ClientesDireccion ;
      private string A40000ClientesImagen_GXI ;
      private string A164ClientesImagen ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbClientesEstado ;
      private GXCombobox dynDepartamentoId ;
      private GXCombobox dynDepartamentoMunicipioId ;
      private IDataStoreProvider pr_default ;
      private long[] H003G2_A112DepartamentoId ;
      private string[] H003G2_A113DepartamentoDepartamento ;
      private long[] H003G3_A112DepartamentoId ;
      private long[] H003G3_A114DepartamentoMunicipioId ;
      private string[] H003G3_A115DepartamentoMunicipioNombre ;
      private long[] H003G4_A112DepartamentoId ;
      private string[] H003G4_A113DepartamentoDepartamento ;
      private long[] H003G5_A106ClientesId ;
      private string[] H003G5_A116PaisID ;
      private string[] H003G5_A40000ClientesImagen_GXI ;
      private string[] H003G5_A163ClientesDireccion ;
      private long[] H003G5_A114DepartamentoMunicipioId ;
      private long[] H003G5_A112DepartamentoId ;
      private string[] H003G5_A162ClientesEmail ;
      private string[] H003G5_A161ClientesTelefono ;
      private string[] H003G5_A434ClientesIdentidad ;
      private string[] H003G5_A160ClientesNombre ;
      private string[] H003G5_A435ClientesEstado ;
      private string[] H003G5_A164ClientesImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H003G6_A112DepartamentoId ;
      private string[] H003G6_A113DepartamentoDepartamento ;
   }

   public class clientesgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003G2;
          prmH003G2 = new Object[] {
          };
          Object[] prmH003G3;
          prmH003G3 = new Object[] {
          };
          Object[] prmH003G4;
          prmH003G4 = new Object[] {
          };
          Object[] prmH003G5;
          prmH003G5 = new Object[] {
          new ParDef("@ClientesId",GXType.Decimal,18,0)
          };
          Object[] prmH003G6;
          prmH003G6 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H003G2", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003G2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003G3", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE [DepartamentoMunicipioId] < 9999 ORDER BY [DepartamentoMunicipioNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003G3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003G4", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003G4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003G5", "SELECT T1.[ClientesId], T2.[PaisID], T1.[ClientesImagen_GXI], T1.[ClientesDireccion], T1.[DepartamentoMunicipioId], T1.[DepartamentoId], T1.[ClientesEmail], T1.[ClientesTelefono], T1.[ClientesIdentidad], T1.[ClientesNombre], T1.[ClientesEstado], T1.[ClientesImagen] FROM ([Clientes] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) WHERE T1.[ClientesId] = @ClientesId ORDER BY T1.[ClientesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003G5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H003G6", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003G6,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 120);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getString(9, 25);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((string[]) buf[10])[0] = rslt.getString(11, 3);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(3));
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
       }
    }

 }

}
