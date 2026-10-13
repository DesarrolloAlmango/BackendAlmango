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
   public class parametromudanzageneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public parametromudanzageneral( )
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

      public parametromudanzageneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ParametroMudanzaId )
      {
         this.A730ParametroMudanzaId = aP0_ParametroMudanzaId;
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
         cmbParametroMudanzaTipo = new GXCombobox();
         cmbParametroMudanzaUnidad = new GXCombobox();
         chkParametroMudanzaActivo = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ParametroMudanzaId");
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
                  A730ParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( GetPar( "ParametroMudanzaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A730ParametroMudanzaId});
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
                  gxfirstwebparm = GetFirstPar( "ParametroMudanzaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ParametroMudanzaId");
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
            PAFU2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ParametroMudanzaGeneral";
               WSFU2( ) ;
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
            context.SendWebValue( context.GetMessage( "Parametro Mudanza General", "")) ;
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
            GXEncryptionTmp = "parametromudanzageneral.aspx"+UrlEncode(StringUtil.LTrimStr(A730ParametroMudanzaId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parametromudanzageneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA730ParametroMudanzaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA730ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseFormFU2( )
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
         return "ParametroMudanzaGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Parametro Mudanza General", "") ;
      }

      protected void WBFU0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "parametromudanzageneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroMudanzaId_Internalname, context.GetMessage( "Mudanza Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtParametroMudanzaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A730ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtParametroMudanzaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9") : context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroMudanzaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanzaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbParametroMudanzaTipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbParametroMudanzaTipo_Internalname, context.GetMessage( "Mudanza Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbParametroMudanzaTipo, cmbParametroMudanzaTipo_Internalname, StringUtil.RTrim( A731ParametroMudanzaTipo), 1, cmbParametroMudanzaTipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbParametroMudanzaTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "", true, 0, "HLP_ParametroMudanzaGeneral.htm");
            cmbParametroMudanzaTipo.CurrentValue = StringUtil.RTrim( A731ParametroMudanzaTipo);
            AssignProp(sPrefix, false, cmbParametroMudanzaTipo_Internalname, "Values", (string)(cmbParametroMudanzaTipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaTitulo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroMudanzaTitulo_Internalname, context.GetMessage( "Título tarjetas", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtParametroMudanzaTitulo_Internalname, A869ParametroMudanzaTitulo, StringUtil.RTrim( context.localUtil.Format( A869ParametroMudanzaTitulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaTitulo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroMudanzaTitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ParametroMudanzaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroMudanzaNombre_Internalname, context.GetMessage( "Mudanza Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtParametroMudanzaNombre_Internalname, A732ParametroMudanzaNombre, StringUtil.RTrim( context.localUtil.Format( A732ParametroMudanzaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroMudanzaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "ParametroNombre", "start", true, "", "HLP_ParametroMudanzaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaDescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroMudanzaDescripcion_Internalname, context.GetMessage( "INFORMACIÓN", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtParametroMudanzaDescripcion_Internalname, A812ParametroMudanzaDescripcion, StringUtil.RTrim( context.localUtil.Format( A812ParametroMudanzaDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaDescripcion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroMudanzaDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "ParametroNombre", "start", true, "", "HLP_ParametroMudanzaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaValor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroMudanzaValor_Internalname, context.GetMessage( "Mudanza Valor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtParametroMudanzaValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A733ParametroMudanzaValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtParametroMudanzaValor_Enabled!=0) ? context.localUtil.Format( A733ParametroMudanzaValor, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A733ParametroMudanzaValor, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroMudanzaValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "ParametroValor", "end", false, "", "HLP_ParametroMudanzaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbParametroMudanzaUnidad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbParametroMudanzaUnidad_Internalname, context.GetMessage( "Mudanza Unidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbParametroMudanzaUnidad, cmbParametroMudanzaUnidad_Internalname, StringUtil.RTrim( A734ParametroMudanzaUnidad), 1, cmbParametroMudanzaUnidad_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbParametroMudanzaUnidad.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_ParametroMudanzaGeneral.htm");
            cmbParametroMudanzaUnidad.CurrentValue = StringUtil.RTrim( A734ParametroMudanzaUnidad);
            AssignProp(sPrefix, false, cmbParametroMudanzaUnidad_Internalname, "Values", (string)(cmbParametroMudanzaUnidad.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroMudanzaPisoElev_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtParametroMudanzaPisoElev_Internalname, context.GetMessage( "PISO (Elevación)", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtParametroMudanzaPisoElev_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A818ParametroMudanzaPisoElev), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtParametroMudanzaPisoElev_Enabled!=0) ? context.localUtil.Format( (decimal)(A818ParametroMudanzaPisoElev), "ZZZ9") : context.localUtil.Format( (decimal)(A818ParametroMudanzaPisoElev), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroMudanzaPisoElev_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroMudanzaPisoElev_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanzaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgParametroMudanzaImagen_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Mudanza Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "AttributeFL";
            StyleString = "";
            A870ParametroMudanzaImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ParametroMudanzaImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.PathToRelativeUrl( A870ParametroMudanzaImagen));
            GxWebStd.gx_bitmap( context, imgParametroMudanzaImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A870ParametroMudanzaImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ParametroMudanzaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkParametroMudanzaActivo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkParametroMudanzaActivo_Internalname, context.GetMessage( "¿Activo?", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkParametroMudanzaActivo_Internalname, StringUtil.BoolToStr( A877ParametroMudanzaActivo), "", context.GetMessage( "¿Activo?", ""), 1, chkParametroMudanzaActivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanzaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanzaGeneral.htm");
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

      protected void STARTFU2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Parametro Mudanza General", ""), 0) ;
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
               STRUPFU0( ) ;
            }
         }
      }

      protected void WSFU2( )
      {
         STARTFU2( ) ;
         EVTFU2( ) ;
      }

      protected void EVTFU2( )
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
                                 STRUPFU0( ) ;
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
                                 STRUPFU0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11FU2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPFU0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12FU2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPFU0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13FU2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPFU0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14FU2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPFU0( ) ;
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
                                 STRUPFU0( ) ;
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

      protected void WEFU2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormFU2( ) ;
            }
         }
      }

      protected void PAFU2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "parametromudanzageneral.aspx")), "parametromudanzageneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "parametromudanzageneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ParametroMudanzaId");
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
         if ( cmbParametroMudanzaTipo.ItemCount > 0 )
         {
            A731ParametroMudanzaTipo = cmbParametroMudanzaTipo.getValidValue(A731ParametroMudanzaTipo);
            AssignAttri(sPrefix, false, "A731ParametroMudanzaTipo", A731ParametroMudanzaTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbParametroMudanzaTipo.CurrentValue = StringUtil.RTrim( A731ParametroMudanzaTipo);
            AssignProp(sPrefix, false, cmbParametroMudanzaTipo_Internalname, "Values", cmbParametroMudanzaTipo.ToJavascriptSource(), true);
         }
         if ( cmbParametroMudanzaUnidad.ItemCount > 0 )
         {
            A734ParametroMudanzaUnidad = cmbParametroMudanzaUnidad.getValidValue(A734ParametroMudanzaUnidad);
            AssignAttri(sPrefix, false, "A734ParametroMudanzaUnidad", A734ParametroMudanzaUnidad);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbParametroMudanzaUnidad.CurrentValue = StringUtil.RTrim( A734ParametroMudanzaUnidad);
            AssignProp(sPrefix, false, cmbParametroMudanzaUnidad_Internalname, "Values", cmbParametroMudanzaUnidad.ToJavascriptSource(), true);
         }
         A877ParametroMudanzaActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A877ParametroMudanzaActivo));
         AssignAttri(sPrefix, false, "A877ParametroMudanzaActivo", A877ParametroMudanzaActivo);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFFU2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ParametroMudanzaGeneral";
      }

      protected void RFFU2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00FU2 */
            pr_default.execute(0, new Object[] {A730ParametroMudanzaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A877ParametroMudanzaActivo = H00FU2_A877ParametroMudanzaActivo[0];
               AssignAttri(sPrefix, false, "A877ParametroMudanzaActivo", A877ParametroMudanzaActivo);
               A40000ParametroMudanzaImagen_GXI = H00FU2_A40000ParametroMudanzaImagen_GXI[0];
               AssignProp(sPrefix, false, imgParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), true);
               AssignProp(sPrefix, false, imgParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
               A818ParametroMudanzaPisoElev = H00FU2_A818ParametroMudanzaPisoElev[0];
               AssignAttri(sPrefix, false, "A818ParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(A818ParametroMudanzaPisoElev), 4, 0));
               A734ParametroMudanzaUnidad = H00FU2_A734ParametroMudanzaUnidad[0];
               AssignAttri(sPrefix, false, "A734ParametroMudanzaUnidad", A734ParametroMudanzaUnidad);
               A733ParametroMudanzaValor = H00FU2_A733ParametroMudanzaValor[0];
               AssignAttri(sPrefix, false, "A733ParametroMudanzaValor", StringUtil.LTrimStr( A733ParametroMudanzaValor, 18, 2));
               A812ParametroMudanzaDescripcion = H00FU2_A812ParametroMudanzaDescripcion[0];
               AssignAttri(sPrefix, false, "A812ParametroMudanzaDescripcion", A812ParametroMudanzaDescripcion);
               A732ParametroMudanzaNombre = H00FU2_A732ParametroMudanzaNombre[0];
               AssignAttri(sPrefix, false, "A732ParametroMudanzaNombre", A732ParametroMudanzaNombre);
               A869ParametroMudanzaTitulo = H00FU2_A869ParametroMudanzaTitulo[0];
               AssignAttri(sPrefix, false, "A869ParametroMudanzaTitulo", A869ParametroMudanzaTitulo);
               A731ParametroMudanzaTipo = H00FU2_A731ParametroMudanzaTipo[0];
               AssignAttri(sPrefix, false, "A731ParametroMudanzaTipo", A731ParametroMudanzaTipo);
               A870ParametroMudanzaImagen = H00FU2_A870ParametroMudanzaImagen[0];
               AssignAttri(sPrefix, false, "A870ParametroMudanzaImagen", A870ParametroMudanzaImagen);
               AssignProp(sPrefix, false, imgParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), true);
               AssignProp(sPrefix, false, imgParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
               /* Execute user event: Load */
               E12FU2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WBFU0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesFU2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ParametroMudanzaGeneral";
         edtParametroMudanzaId_Enabled = 0;
         AssignProp(sPrefix, false, edtParametroMudanzaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaId_Enabled), 5, 0), true);
         cmbParametroMudanzaTipo.Enabled = 0;
         AssignProp(sPrefix, false, cmbParametroMudanzaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbParametroMudanzaTipo.Enabled), 5, 0), true);
         edtParametroMudanzaTitulo_Enabled = 0;
         AssignProp(sPrefix, false, edtParametroMudanzaTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaTitulo_Enabled), 5, 0), true);
         edtParametroMudanzaNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtParametroMudanzaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaNombre_Enabled), 5, 0), true);
         edtParametroMudanzaDescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtParametroMudanzaDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaDescripcion_Enabled), 5, 0), true);
         edtParametroMudanzaValor_Enabled = 0;
         AssignProp(sPrefix, false, edtParametroMudanzaValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaValor_Enabled), 5, 0), true);
         cmbParametroMudanzaUnidad.Enabled = 0;
         AssignProp(sPrefix, false, cmbParametroMudanzaUnidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbParametroMudanzaUnidad.Enabled), 5, 0), true);
         edtParametroMudanzaPisoElev_Enabled = 0;
         AssignProp(sPrefix, false, edtParametroMudanzaPisoElev_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaPisoElev_Enabled), 5, 0), true);
         imgParametroMudanzaImagen_Enabled = 0;
         AssignProp(sPrefix, false, imgParametroMudanzaImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgParametroMudanzaImagen_Enabled), 5, 0), true);
         chkParametroMudanzaActivo.Enabled = 0;
         AssignProp(sPrefix, false, chkParametroMudanzaActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkParametroMudanzaActivo.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPFU0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11FU2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA730ParametroMudanzaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA730ParametroMudanzaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            cmbParametroMudanzaTipo.CurrentValue = cgiGet( cmbParametroMudanzaTipo_Internalname);
            A731ParametroMudanzaTipo = cgiGet( cmbParametroMudanzaTipo_Internalname);
            AssignAttri(sPrefix, false, "A731ParametroMudanzaTipo", A731ParametroMudanzaTipo);
            A869ParametroMudanzaTitulo = cgiGet( edtParametroMudanzaTitulo_Internalname);
            AssignAttri(sPrefix, false, "A869ParametroMudanzaTitulo", A869ParametroMudanzaTitulo);
            A732ParametroMudanzaNombre = cgiGet( edtParametroMudanzaNombre_Internalname);
            AssignAttri(sPrefix, false, "A732ParametroMudanzaNombre", A732ParametroMudanzaNombre);
            A812ParametroMudanzaDescripcion = cgiGet( edtParametroMudanzaDescripcion_Internalname);
            AssignAttri(sPrefix, false, "A812ParametroMudanzaDescripcion", A812ParametroMudanzaDescripcion);
            A733ParametroMudanzaValor = context.localUtil.CToN( cgiGet( edtParametroMudanzaValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A733ParametroMudanzaValor", StringUtil.LTrimStr( A733ParametroMudanzaValor, 18, 2));
            cmbParametroMudanzaUnidad.CurrentValue = cgiGet( cmbParametroMudanzaUnidad_Internalname);
            A734ParametroMudanzaUnidad = cgiGet( cmbParametroMudanzaUnidad_Internalname);
            AssignAttri(sPrefix, false, "A734ParametroMudanzaUnidad", A734ParametroMudanzaUnidad);
            A818ParametroMudanzaPisoElev = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtParametroMudanzaPisoElev_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A818ParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(A818ParametroMudanzaPisoElev), 4, 0));
            A870ParametroMudanzaImagen = cgiGet( imgParametroMudanzaImagen_Internalname);
            AssignAttri(sPrefix, false, "A870ParametroMudanzaImagen", A870ParametroMudanzaImagen);
            A877ParametroMudanzaActivo = StringUtil.StrToBool( cgiGet( chkParametroMudanzaActivo_Internalname));
            AssignAttri(sPrefix, false, "A877ParametroMudanzaActivo", A877ParametroMudanzaActivo);
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
         E11FU2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11FU2( )
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

      protected void E12FU2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13FU2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "parametromudanza.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A730ParametroMudanzaId,4,0));
         CallWebObject(formatLink("parametromudanza.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14FU2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "parametromudanza.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A730ParametroMudanzaId,4,0));
         CallWebObject(formatLink("parametromudanza.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Transactionname = "ParametroMudanza";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A730ParametroMudanzaId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
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
         PAFU2( ) ;
         WSFU2( ) ;
         WEFU2( ) ;
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
         sCtrlA730ParametroMudanzaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAFU2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "parametromudanzageneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAFU2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A730ParametroMudanzaId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
         }
         wcpOA730ParametroMudanzaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA730ParametroMudanzaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A730ParametroMudanzaId != wcpOA730ParametroMudanzaId ) ) )
         {
            setjustcreated();
         }
         wcpOA730ParametroMudanzaId = A730ParametroMudanzaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA730ParametroMudanzaId = cgiGet( sPrefix+"A730ParametroMudanzaId_CTRL");
         if ( StringUtil.Len( sCtrlA730ParametroMudanzaId) > 0 )
         {
            A730ParametroMudanzaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA730ParametroMudanzaId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A730ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(A730ParametroMudanzaId), 4, 0));
         }
         else
         {
            A730ParametroMudanzaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A730ParametroMudanzaId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PAFU2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSFU2( ) ;
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
         WSFU2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A730ParametroMudanzaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A730ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA730ParametroMudanzaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A730ParametroMudanzaId_CTRL", StringUtil.RTrim( sCtrlA730ParametroMudanzaId));
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
         WEFU2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021153633", true, true, false);
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
         context.AddJavascriptSource("parametromudanzageneral.js", "?202673021153633", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbParametroMudanzaTipo.Name = "PARAMETROMUDANZATIPO";
         cmbParametroMudanzaTipo.WebTags = "";
         cmbParametroMudanzaTipo.addItem("TipoInmuebleCasa", context.GetMessage( "Tipo Inmueble Casa", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoEstacionamiento", context.GetMessage( "Tipo Estacionamiento", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoVehiculo", context.GetMessage( "Tipo Vehiculo", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaHogar", context.GetMessage( "Electro Hogar", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemAdicional", context.GetMessage( "Item Adicional", ""), 0);
         cmbParametroMudanzaTipo.addItem("Peaje", context.GetMessage( "Peaje", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoInmuebleApto", context.GetMessage( "Tipo Inmueble Apto", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaMobiliario", context.GetMessage( "Mobiliario", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaExterior", context.GetMessage( "Exterior y Jardín", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaDecoracion", context.GetMessage( "Decoración", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaOtros", context.GetMessage( "Otros", ""), 0);
         cmbParametroMudanzaTipo.addItem("Escalera", context.GetMessage( "Escalera", ""), 0);
         cmbParametroMudanzaTipo.addItem("Ascensor", context.GetMessage( "Ascensor", ""), 0);
         cmbParametroMudanzaTipo.addItem("EscaAsce", context.GetMessage( "Esca+Asce", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioEmbalaje", context.GetMessage( "Precio Embalaje", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioElevacion", context.GetMessage( "Precio Elevacion", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioBase", context.GetMessage( "Precio Base", ""), 0);
         cmbParametroMudanzaTipo.addItem("TiempoxKm", context.GetMessage( "Tiempox Km", ""), 0);
         cmbParametroMudanzaTipo.addItem("TiempoxM3", context.GetMessage( "Tiempox M3", ""), 0);
         if ( cmbParametroMudanzaTipo.ItemCount > 0 )
         {
         }
         cmbParametroMudanzaUnidad.Name = "PARAMETROMUDANZAUNIDAD";
         cmbParametroMudanzaUnidad.WebTags = "";
         cmbParametroMudanzaUnidad.addItem("m3", context.GetMessage( "m3", ""), 0);
         cmbParametroMudanzaUnidad.addItem("$", context.GetMessage( "Pesos", ""), 0);
         cmbParametroMudanzaUnidad.addItem("u", context.GetMessage( "Unidades", ""), 0);
         cmbParametroMudanzaUnidad.addItem("mi", context.GetMessage( "Minutos", ""), 0);
         cmbParametroMudanzaUnidad.addItem("%", "%", 0);
         cmbParametroMudanzaUnidad.addItem("mm", context.GetMessage( "Min/m3", ""), 0);
         if ( cmbParametroMudanzaUnidad.ItemCount > 0 )
         {
         }
         chkParametroMudanzaActivo.Name = "PARAMETROMUDANZAACTIVO";
         chkParametroMudanzaActivo.WebTags = "";
         chkParametroMudanzaActivo.Caption = context.GetMessage( "¿Activo?", "");
         AssignProp(sPrefix, false, chkParametroMudanzaActivo_Internalname, "TitleCaption", chkParametroMudanzaActivo.Caption, true);
         chkParametroMudanzaActivo.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtParametroMudanzaId_Internalname = sPrefix+"PARAMETROMUDANZAID";
         cmbParametroMudanzaTipo_Internalname = sPrefix+"PARAMETROMUDANZATIPO";
         edtParametroMudanzaTitulo_Internalname = sPrefix+"PARAMETROMUDANZATITULO";
         edtParametroMudanzaNombre_Internalname = sPrefix+"PARAMETROMUDANZANOMBRE";
         edtParametroMudanzaDescripcion_Internalname = sPrefix+"PARAMETROMUDANZADESCRIPCION";
         edtParametroMudanzaValor_Internalname = sPrefix+"PARAMETROMUDANZAVALOR";
         cmbParametroMudanzaUnidad_Internalname = sPrefix+"PARAMETROMUDANZAUNIDAD";
         edtParametroMudanzaPisoElev_Internalname = sPrefix+"PARAMETROMUDANZAPISOELEV";
         imgParametroMudanzaImagen_Internalname = sPrefix+"PARAMETROMUDANZAIMAGEN";
         chkParametroMudanzaActivo_Internalname = sPrefix+"PARAMETROMUDANZAACTIVO";
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
         chkParametroMudanzaActivo.Caption = context.GetMessage( "¿Activo?", "");
         imgParametroMudanzaImagen_Enabled = 0;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         chkParametroMudanzaActivo.Enabled = 0;
         edtParametroMudanzaPisoElev_Jsonclick = "";
         edtParametroMudanzaPisoElev_Enabled = 0;
         cmbParametroMudanzaUnidad_Jsonclick = "";
         cmbParametroMudanzaUnidad.Enabled = 0;
         edtParametroMudanzaValor_Jsonclick = "";
         edtParametroMudanzaValor_Enabled = 0;
         edtParametroMudanzaDescripcion_Jsonclick = "";
         edtParametroMudanzaDescripcion_Enabled = 0;
         edtParametroMudanzaNombre_Jsonclick = "";
         edtParametroMudanzaNombre_Enabled = 0;
         edtParametroMudanzaTitulo_Jsonclick = "";
         edtParametroMudanzaTitulo_Enabled = 0;
         cmbParametroMudanzaTipo_Jsonclick = "";
         cmbParametroMudanzaTipo.Enabled = 0;
         edtParametroMudanzaId_Jsonclick = "";
         edtParametroMudanzaId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A730ParametroMudanzaId',fld:'PARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'A877ParametroMudanzaActivo',fld:'PARAMETROMUDANZAACTIVO',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13FU2',iparms:[{av:'A730ParametroMudanzaId',fld:'PARAMETROMUDANZAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E14FU2',iparms:[{av:'A730ParametroMudanzaId',fld:'PARAMETROMUDANZAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROMUDANZAID","{handler:'Valid_Parametromudanzaid',iparms:[]");
         setEventMetadata("VALID_PARAMETROMUDANZAID",",oparms:[]}");
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
         A731ParametroMudanzaTipo = "";
         A869ParametroMudanzaTitulo = "";
         A732ParametroMudanzaNombre = "";
         A812ParametroMudanzaDescripcion = "";
         A734ParametroMudanzaUnidad = "";
         ClassString = "";
         StyleString = "";
         A870ParametroMudanzaImagen = "";
         A40000ParametroMudanzaImagen_GXI = "";
         sImgUrl = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00FU2_A730ParametroMudanzaId = new short[1] ;
         H00FU2_A877ParametroMudanzaActivo = new bool[] {false} ;
         H00FU2_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         H00FU2_A818ParametroMudanzaPisoElev = new short[1] ;
         H00FU2_A734ParametroMudanzaUnidad = new string[] {""} ;
         H00FU2_A733ParametroMudanzaValor = new decimal[1] ;
         H00FU2_A812ParametroMudanzaDescripcion = new string[] {""} ;
         H00FU2_A732ParametroMudanzaNombre = new string[] {""} ;
         H00FU2_A869ParametroMudanzaTitulo = new string[] {""} ;
         H00FU2_A731ParametroMudanzaTipo = new string[] {""} ;
         H00FU2_A870ParametroMudanzaImagen = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA730ParametroMudanzaId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametromudanzageneral__default(),
            new Object[][] {
                new Object[] {
               H00FU2_A730ParametroMudanzaId, H00FU2_A877ParametroMudanzaActivo, H00FU2_A40000ParametroMudanzaImagen_GXI, H00FU2_A818ParametroMudanzaPisoElev, H00FU2_A734ParametroMudanzaUnidad, H00FU2_A733ParametroMudanzaValor, H00FU2_A812ParametroMudanzaDescripcion, H00FU2_A732ParametroMudanzaNombre, H00FU2_A869ParametroMudanzaTitulo, H00FU2_A731ParametroMudanzaTipo,
               H00FU2_A870ParametroMudanzaImagen
               }
            }
         );
         AV13Pgmname = "ParametroMudanzaGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ParametroMudanzaGeneral";
      }

      private short A730ParametroMudanzaId ;
      private short wcpOA730ParametroMudanzaId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A818ParametroMudanzaPisoElev ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtParametroMudanzaId_Enabled ;
      private int edtParametroMudanzaTitulo_Enabled ;
      private int edtParametroMudanzaNombre_Enabled ;
      private int edtParametroMudanzaDescripcion_Enabled ;
      private int edtParametroMudanzaValor_Enabled ;
      private int edtParametroMudanzaPisoElev_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int imgParametroMudanzaImagen_Enabled ;
      private int idxLst ;
      private decimal A733ParametroMudanzaValor ;
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
      private string edtParametroMudanzaId_Internalname ;
      private string TempTags ;
      private string edtParametroMudanzaId_Jsonclick ;
      private string cmbParametroMudanzaTipo_Internalname ;
      private string cmbParametroMudanzaTipo_Jsonclick ;
      private string edtParametroMudanzaTitulo_Internalname ;
      private string edtParametroMudanzaTitulo_Jsonclick ;
      private string edtParametroMudanzaNombre_Internalname ;
      private string edtParametroMudanzaNombre_Jsonclick ;
      private string edtParametroMudanzaDescripcion_Internalname ;
      private string edtParametroMudanzaDescripcion_Jsonclick ;
      private string edtParametroMudanzaValor_Internalname ;
      private string edtParametroMudanzaValor_Jsonclick ;
      private string cmbParametroMudanzaUnidad_Internalname ;
      private string A734ParametroMudanzaUnidad ;
      private string cmbParametroMudanzaUnidad_Jsonclick ;
      private string edtParametroMudanzaPisoElev_Internalname ;
      private string edtParametroMudanzaPisoElev_Jsonclick ;
      private string imgParametroMudanzaImagen_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string chkParametroMudanzaActivo_Internalname ;
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
      private string sCtrlA730ParametroMudanzaId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A870ParametroMudanzaImagen_IsBlob ;
      private bool A877ParametroMudanzaActivo ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A731ParametroMudanzaTipo ;
      private string A869ParametroMudanzaTitulo ;
      private string A732ParametroMudanzaNombre ;
      private string A812ParametroMudanzaDescripcion ;
      private string A40000ParametroMudanzaImagen_GXI ;
      private string A870ParametroMudanzaImagen ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbParametroMudanzaTipo ;
      private GXCombobox cmbParametroMudanzaUnidad ;
      private GXCheckbox chkParametroMudanzaActivo ;
      private IDataStoreProvider pr_default ;
      private short[] H00FU2_A730ParametroMudanzaId ;
      private bool[] H00FU2_A877ParametroMudanzaActivo ;
      private string[] H00FU2_A40000ParametroMudanzaImagen_GXI ;
      private short[] H00FU2_A818ParametroMudanzaPisoElev ;
      private string[] H00FU2_A734ParametroMudanzaUnidad ;
      private decimal[] H00FU2_A733ParametroMudanzaValor ;
      private string[] H00FU2_A812ParametroMudanzaDescripcion ;
      private string[] H00FU2_A732ParametroMudanzaNombre ;
      private string[] H00FU2_A869ParametroMudanzaTitulo ;
      private string[] H00FU2_A731ParametroMudanzaTipo ;
      private string[] H00FU2_A870ParametroMudanzaImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class parametromudanzageneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00FU2;
          prmH00FU2 = new Object[] {
          new ParDef("@ParametroMudanzaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00FU2", "SELECT [ParametroMudanzaId], [ParametroMudanzaActivo], [ParametroMudanzaImagen_GXI], [ParametroMudanzaPisoElev], [ParametroMudanzaUnidad], [ParametroMudanzaValor], [ParametroMudanzaDescripcion], [ParametroMudanzaNombre], [ParametroMudanzaTitulo], [ParametroMudanzaTipo], [ParametroMudanzaImagen] FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @ParametroMudanzaId ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FU2,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 2);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(3));
                return;
       }
    }

 }

}
