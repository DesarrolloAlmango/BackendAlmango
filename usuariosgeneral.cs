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
   public class usuariosgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public usuariosgeneral( )
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

      public usuariosgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_usuariosId )
      {
         this.A145usuariosId = aP0_usuariosId;
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
         cmbusuariosTipo = new GXCombobox();
         cmbusuariosEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "usuariosId");
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
                  A145usuariosId = GetPar( "usuariosId");
                  AssignAttri(sPrefix, false, "A145usuariosId", A145usuariosId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)A145usuariosId});
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
                  gxfirstwebparm = GetFirstPar( "usuariosId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "usuariosId");
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
            PABY2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "usuariosGeneral";
               WSBY2( ) ;
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
            context.SendWebValue( context.GetMessage( "usuarios General", "")) ;
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
            GXEncryptionTmp = "usuariosgeneral.aspx"+UrlEncode(StringUtil.RTrim(A145usuariosId));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usuariosgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA145usuariosId", StringUtil.RTrim( wcpOA145usuariosId));
      }

      protected void RenderHtmlCloseFormBY2( )
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
         return "usuariosGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "usuarios General", "") ;
      }

      protected void WBBY0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "usuariosgeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtusuariosId_Internalname, context.GetMessage( "Name", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtusuariosId_Internalname, StringUtil.RTrim( A145usuariosId), StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosId_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NickName", "start", true, "", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbusuariosTipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbusuariosTipo_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbusuariosTipo, cmbusuariosTipo_Internalname, StringUtil.RTrim( A225usuariosTipo), 1, cmbusuariosTipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbusuariosTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "", true, 0, "HLP_usuariosGeneral.htm");
            cmbusuariosTipo.CurrentValue = StringUtil.RTrim( A225usuariosTipo);
            AssignProp(sPrefix, false, cmbusuariosTipo_Internalname, "Values", (string)(cmbusuariosTipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtusuariosNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtusuariosNombre_Internalname, StringUtil.RTrim( A222usuariosNombre), StringUtil.RTrim( context.localUtil.Format( A222usuariosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosCorreo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtusuariosCorreo_Internalname, context.GetMessage( "Correo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtusuariosCorreo_Internalname, A224usuariosCorreo, StringUtil.RTrim( context.localUtil.Format( A224usuariosCorreo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A224usuariosCorreo, "", "", "", edtusuariosCorreo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosCorreo_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPaisID_Internalname, context.GetMessage( "PaisId", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPaisID_Internalname, StringUtil.RTrim( A116PaisID), StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisID_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPaisNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPaisNombre_Internalname, context.GetMessage( "Pais", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPaisNombre_Internalname, StringUtil.RTrim( A165PaisNombre), StringUtil.RTrim( context.localUtil.Format( A165PaisNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPaisNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosDireccion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtusuariosDireccion_Internalname, context.GetMessage( "Direccion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtusuariosDireccion_Internalname, A230usuariosDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A230usuariosDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtusuariosDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgusuariosImagen_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen 800x800", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "AttributeFL";
            StyleString = "";
            A266usuariosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000usuariosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.PathToRelativeUrl( A266usuariosImagen));
            GxWebStd.gx_bitmap( context, imgusuariosImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A266usuariosImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosPasw_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtusuariosPasw_Internalname, context.GetMessage( "Paswword", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtusuariosPasw_Internalname, StringUtil.RTrim( A223usuariosPasw), StringUtil.RTrim( context.localUtil.Format( A223usuariosPasw, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosPasw_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosPasw_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Pasword", "start", true, "", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosCPostal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtusuariosCPostal_Internalname, context.GetMessage( "Postal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtusuariosCPostal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A231usuariosCPostal), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtusuariosCPostal_Enabled!=0) ? context.localUtil.Format( (decimal)(A231usuariosCPostal), "ZZZZ9") : context.localUtil.Format( (decimal)(A231usuariosCPostal), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosCPostal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosCPostal_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosTelefono_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtusuariosTelefono_Internalname, context.GetMessage( "Telefono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A232usuariosTelefono);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtusuariosTelefono_Internalname, StringUtil.RTrim( A232usuariosTelefono), StringUtil.RTrim( context.localUtil.Format( A232usuariosTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtusuariosTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbusuariosEstado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbusuariosEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbusuariosEstado, cmbusuariosEstado_Internalname, StringUtil.RTrim( A226usuariosEstado), 1, cmbusuariosEstado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbusuariosEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 0, "HLP_usuariosGeneral.htm");
            cmbusuariosEstado.CurrentValue = StringUtil.RTrim( A226usuariosEstado);
            AssignProp(sPrefix, false, cmbusuariosEstado_Internalname, "Values", (string)(cmbusuariosEstado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtusuariosNumeroIdentidad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtusuariosNumeroIdentidad_Internalname, context.GetMessage( "Numero de Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtusuariosNumeroIdentidad_Internalname, StringUtil.RTrim( A240usuariosNumeroIdentidad), StringUtil.RTrim( context.localUtil.Format( A240usuariosNumeroIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosNumeroIdentidad_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtusuariosNumeroIdentidad_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_usuariosGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_usuariosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_usuariosGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtusuariosEstadoOnOffLine_Internalname, StringUtil.RTrim( A227usuariosEstadoOnOffLine), StringUtil.RTrim( context.localUtil.Format( A227usuariosEstadoOnOffLine, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosEstadoOnOffLine_Jsonclick, 0, "Attribute", "", "", "", "", edtusuariosEstadoOnOffLine_Visible, 0, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "Estado", "start", true, "", "HLP_usuariosGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtusuariosFechaEstadoOnOff_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtusuariosFechaEstadoOnOff_Internalname, context.localUtil.Format(A228usuariosFechaEstadoOnOff, "99/99/99"), context.localUtil.Format( A228usuariosFechaEstadoOnOff, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosFechaEstadoOnOff_Jsonclick, 0, "Attribute", "", "", "", "", edtusuariosFechaEstadoOnOff_Visible, 0, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_bitmap( context, edtusuariosFechaEstadoOnOff_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtusuariosFechaEstadoOnOff_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_usuariosGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtusuariosHoraEstadoOnOff_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtusuariosHoraEstadoOnOff_Internalname, context.localUtil.TToC( A229usuariosHoraEstadoOnOff, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A229usuariosHoraEstadoOnOff, "99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtusuariosHoraEstadoOnOff_Jsonclick, 0, "Attribute", "", "", "", "", edtusuariosHoraEstadoOnOff_Visible, 0, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Time", "end", false, "", "HLP_usuariosGeneral.htm");
            GxWebStd.gx_bitmap( context, edtusuariosHoraEstadoOnOff_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtusuariosHoraEstadoOnOff_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_usuariosGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTBY2( )
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
            Form.Meta.addItem("description", context.GetMessage( "usuarios General", ""), 0) ;
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
               STRUPBY0( ) ;
            }
         }
      }

      protected void WSBY2( )
      {
         STARTBY2( ) ;
         EVTBY2( ) ;
      }

      protected void EVTBY2( )
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
                                 STRUPBY0( ) ;
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
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11BY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12BY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13BY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14BY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBY0( ) ;
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
                                 STRUPBY0( ) ;
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

      protected void WEBY2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormBY2( ) ;
            }
         }
      }

      protected void PABY2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "usuariosgeneral.aspx")), "usuariosgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "usuariosgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "usuariosId");
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
         if ( cmbusuariosTipo.ItemCount > 0 )
         {
            A225usuariosTipo = cmbusuariosTipo.getValidValue(A225usuariosTipo);
            AssignAttri(sPrefix, false, "A225usuariosTipo", A225usuariosTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbusuariosTipo.CurrentValue = StringUtil.RTrim( A225usuariosTipo);
            AssignProp(sPrefix, false, cmbusuariosTipo_Internalname, "Values", cmbusuariosTipo.ToJavascriptSource(), true);
         }
         if ( cmbusuariosEstado.ItemCount > 0 )
         {
            A226usuariosEstado = cmbusuariosEstado.getValidValue(A226usuariosEstado);
            AssignAttri(sPrefix, false, "A226usuariosEstado", A226usuariosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbusuariosEstado.CurrentValue = StringUtil.RTrim( A226usuariosEstado);
            AssignProp(sPrefix, false, cmbusuariosEstado_Internalname, "Values", cmbusuariosEstado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFBY2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "usuariosGeneral";
      }

      protected void RFBY2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00BY2 */
            pr_default.execute(0, new Object[] {A145usuariosId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A229usuariosHoraEstadoOnOff = H00BY2_A229usuariosHoraEstadoOnOff[0];
               AssignAttri(sPrefix, false, "A229usuariosHoraEstadoOnOff", context.localUtil.TToC( A229usuariosHoraEstadoOnOff, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A228usuariosFechaEstadoOnOff = H00BY2_A228usuariosFechaEstadoOnOff[0];
               AssignAttri(sPrefix, false, "A228usuariosFechaEstadoOnOff", context.localUtil.Format(A228usuariosFechaEstadoOnOff, "99/99/99"));
               A227usuariosEstadoOnOffLine = H00BY2_A227usuariosEstadoOnOffLine[0];
               AssignAttri(sPrefix, false, "A227usuariosEstadoOnOffLine", A227usuariosEstadoOnOffLine);
               A240usuariosNumeroIdentidad = H00BY2_A240usuariosNumeroIdentidad[0];
               AssignAttri(sPrefix, false, "A240usuariosNumeroIdentidad", A240usuariosNumeroIdentidad);
               A226usuariosEstado = H00BY2_A226usuariosEstado[0];
               AssignAttri(sPrefix, false, "A226usuariosEstado", A226usuariosEstado);
               A232usuariosTelefono = H00BY2_A232usuariosTelefono[0];
               AssignAttri(sPrefix, false, "A232usuariosTelefono", A232usuariosTelefono);
               A231usuariosCPostal = H00BY2_A231usuariosCPostal[0];
               AssignAttri(sPrefix, false, "A231usuariosCPostal", StringUtil.LTrimStr( (decimal)(A231usuariosCPostal), 5, 0));
               A223usuariosPasw = H00BY2_A223usuariosPasw[0];
               AssignAttri(sPrefix, false, "A223usuariosPasw", A223usuariosPasw);
               A40000usuariosImagen_GXI = H00BY2_A40000usuariosImagen_GXI[0];
               AssignProp(sPrefix, false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
               AssignProp(sPrefix, false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
               A230usuariosDireccion = H00BY2_A230usuariosDireccion[0];
               AssignAttri(sPrefix, false, "A230usuariosDireccion", A230usuariosDireccion);
               A165PaisNombre = H00BY2_A165PaisNombre[0];
               AssignAttri(sPrefix, false, "A165PaisNombre", A165PaisNombre);
               A116PaisID = H00BY2_A116PaisID[0];
               AssignAttri(sPrefix, false, "A116PaisID", A116PaisID);
               A224usuariosCorreo = H00BY2_A224usuariosCorreo[0];
               AssignAttri(sPrefix, false, "A224usuariosCorreo", A224usuariosCorreo);
               A222usuariosNombre = H00BY2_A222usuariosNombre[0];
               AssignAttri(sPrefix, false, "A222usuariosNombre", A222usuariosNombre);
               A225usuariosTipo = H00BY2_A225usuariosTipo[0];
               AssignAttri(sPrefix, false, "A225usuariosTipo", A225usuariosTipo);
               A266usuariosImagen = H00BY2_A266usuariosImagen[0];
               AssignAttri(sPrefix, false, "A266usuariosImagen", A266usuariosImagen);
               AssignProp(sPrefix, false, imgusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), true);
               AssignProp(sPrefix, false, imgusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
               A165PaisNombre = H00BY2_A165PaisNombre[0];
               AssignAttri(sPrefix, false, "A165PaisNombre", A165PaisNombre);
               /* Execute user event: Load */
               E12BY2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WBBY0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesBY2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "usuariosGeneral";
         edtusuariosId_Enabled = 0;
         AssignProp(sPrefix, false, edtusuariosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosId_Enabled), 5, 0), true);
         cmbusuariosTipo.Enabled = 0;
         AssignProp(sPrefix, false, cmbusuariosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbusuariosTipo.Enabled), 5, 0), true);
         edtusuariosNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtusuariosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNombre_Enabled), 5, 0), true);
         edtusuariosCorreo_Enabled = 0;
         AssignProp(sPrefix, false, edtusuariosCorreo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosCorreo_Enabled), 5, 0), true);
         edtPaisID_Enabled = 0;
         AssignProp(sPrefix, false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), true);
         edtPaisNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtPaisNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisNombre_Enabled), 5, 0), true);
         edtusuariosDireccion_Enabled = 0;
         AssignProp(sPrefix, false, edtusuariosDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosDireccion_Enabled), 5, 0), true);
         imgusuariosImagen_Enabled = 0;
         AssignProp(sPrefix, false, imgusuariosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgusuariosImagen_Enabled), 5, 0), true);
         edtusuariosPasw_Enabled = 0;
         AssignProp(sPrefix, false, edtusuariosPasw_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosPasw_Enabled), 5, 0), true);
         edtusuariosCPostal_Enabled = 0;
         AssignProp(sPrefix, false, edtusuariosCPostal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosCPostal_Enabled), 5, 0), true);
         edtusuariosTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtusuariosTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosTelefono_Enabled), 5, 0), true);
         cmbusuariosEstado.Enabled = 0;
         AssignProp(sPrefix, false, cmbusuariosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbusuariosEstado.Enabled), 5, 0), true);
         edtusuariosNumeroIdentidad_Enabled = 0;
         AssignProp(sPrefix, false, edtusuariosNumeroIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosNumeroIdentidad_Enabled), 5, 0), true);
         edtusuariosEstadoOnOffLine_Enabled = 0;
         AssignProp(sPrefix, false, edtusuariosEstadoOnOffLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosEstadoOnOffLine_Enabled), 5, 0), true);
         edtusuariosFechaEstadoOnOff_Enabled = 0;
         AssignProp(sPrefix, false, edtusuariosFechaEstadoOnOff_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosFechaEstadoOnOff_Enabled), 5, 0), true);
         edtusuariosHoraEstadoOnOff_Enabled = 0;
         AssignProp(sPrefix, false, edtusuariosHoraEstadoOnOff_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtusuariosHoraEstadoOnOff_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBY0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11BY2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA145usuariosId = cgiGet( sPrefix+"wcpOA145usuariosId");
            /* Read variables values. */
            cmbusuariosTipo.CurrentValue = cgiGet( cmbusuariosTipo_Internalname);
            A225usuariosTipo = cgiGet( cmbusuariosTipo_Internalname);
            AssignAttri(sPrefix, false, "A225usuariosTipo", A225usuariosTipo);
            A222usuariosNombre = cgiGet( edtusuariosNombre_Internalname);
            AssignAttri(sPrefix, false, "A222usuariosNombre", A222usuariosNombre);
            A224usuariosCorreo = cgiGet( edtusuariosCorreo_Internalname);
            AssignAttri(sPrefix, false, "A224usuariosCorreo", A224usuariosCorreo);
            A116PaisID = cgiGet( edtPaisID_Internalname);
            AssignAttri(sPrefix, false, "A116PaisID", A116PaisID);
            A165PaisNombre = cgiGet( edtPaisNombre_Internalname);
            AssignAttri(sPrefix, false, "A165PaisNombre", A165PaisNombre);
            A230usuariosDireccion = cgiGet( edtusuariosDireccion_Internalname);
            AssignAttri(sPrefix, false, "A230usuariosDireccion", A230usuariosDireccion);
            A266usuariosImagen = cgiGet( imgusuariosImagen_Internalname);
            AssignAttri(sPrefix, false, "A266usuariosImagen", A266usuariosImagen);
            A223usuariosPasw = cgiGet( edtusuariosPasw_Internalname);
            AssignAttri(sPrefix, false, "A223usuariosPasw", A223usuariosPasw);
            A231usuariosCPostal = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtusuariosCPostal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A231usuariosCPostal", StringUtil.LTrimStr( (decimal)(A231usuariosCPostal), 5, 0));
            A232usuariosTelefono = cgiGet( edtusuariosTelefono_Internalname);
            AssignAttri(sPrefix, false, "A232usuariosTelefono", A232usuariosTelefono);
            cmbusuariosEstado.CurrentValue = cgiGet( cmbusuariosEstado_Internalname);
            A226usuariosEstado = cgiGet( cmbusuariosEstado_Internalname);
            AssignAttri(sPrefix, false, "A226usuariosEstado", A226usuariosEstado);
            A240usuariosNumeroIdentidad = cgiGet( edtusuariosNumeroIdentidad_Internalname);
            AssignAttri(sPrefix, false, "A240usuariosNumeroIdentidad", A240usuariosNumeroIdentidad);
            A227usuariosEstadoOnOffLine = cgiGet( edtusuariosEstadoOnOffLine_Internalname);
            AssignAttri(sPrefix, false, "A227usuariosEstadoOnOffLine", A227usuariosEstadoOnOffLine);
            A228usuariosFechaEstadoOnOff = context.localUtil.CToD( cgiGet( edtusuariosFechaEstadoOnOff_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri(sPrefix, false, "A228usuariosFechaEstadoOnOff", context.localUtil.Format(A228usuariosFechaEstadoOnOff, "99/99/99"));
            A229usuariosHoraEstadoOnOff = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtusuariosHoraEstadoOnOff_Internalname)));
            AssignAttri(sPrefix, false, "A229usuariosHoraEstadoOnOff", context.localUtil.TToC( A229usuariosHoraEstadoOnOff, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
         E11BY2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11BY2( )
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

      protected void E12BY2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtusuariosEstadoOnOffLine_Visible = 0;
         AssignProp(sPrefix, false, edtusuariosEstadoOnOffLine_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtusuariosEstadoOnOffLine_Visible), 5, 0), true);
         edtusuariosFechaEstadoOnOff_Visible = 0;
         AssignProp(sPrefix, false, edtusuariosFechaEstadoOnOff_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtusuariosFechaEstadoOnOff_Visible), 5, 0), true);
         edtusuariosHoraEstadoOnOff_Visible = 0;
         AssignProp(sPrefix, false, edtusuariosHoraEstadoOnOff_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtusuariosHoraEstadoOnOff_Visible), 5, 0), true);
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13BY2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A145usuariosId));
         CallWebObject(formatLink("usuarios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14BY2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A145usuariosId));
         CallWebObject(formatLink("usuarios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Transactionname = "usuarios";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A145usuariosId = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "A145usuariosId", A145usuariosId);
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
         PABY2( ) ;
         WSBY2( ) ;
         WEBY2( ) ;
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
         sCtrlA145usuariosId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PABY2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "usuariosgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PABY2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A145usuariosId = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "A145usuariosId", A145usuariosId);
         }
         wcpOA145usuariosId = cgiGet( sPrefix+"wcpOA145usuariosId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(A145usuariosId, wcpOA145usuariosId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOA145usuariosId = A145usuariosId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA145usuariosId = cgiGet( sPrefix+"A145usuariosId_CTRL");
         if ( StringUtil.Len( sCtrlA145usuariosId) > 0 )
         {
            A145usuariosId = cgiGet( sCtrlA145usuariosId);
            AssignAttri(sPrefix, false, "A145usuariosId", A145usuariosId);
         }
         else
         {
            A145usuariosId = cgiGet( sPrefix+"A145usuariosId_PARM");
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
         PABY2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSBY2( ) ;
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
         WSBY2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A145usuariosId_PARM", StringUtil.RTrim( A145usuariosId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA145usuariosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A145usuariosId_CTRL", StringUtil.RTrim( sCtrlA145usuariosId));
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
         WEBY2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932024762", true, true, false);
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
         context.AddJavascriptSource("usuariosgeneral.js", "?2026932024762", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbusuariosTipo.Name = "USUARIOSTIPO";
         cmbusuariosTipo.WebTags = "";
         cmbusuariosTipo.addItem("A", context.GetMessage( "Administrador Sistema", ""), 0);
         cmbusuariosTipo.addItem("P", context.GetMessage( "Proveedor de Servicio", ""), 0);
         cmbusuariosTipo.addItem("G", context.GetMessage( "Administrador de Agencia", ""), 0);
         cmbusuariosTipo.addItem("S", context.GetMessage( "Agente de Servicios", ""), 0);
         cmbusuariosTipo.addItem("C", context.GetMessage( "Cliente", ""), 0);
         cmbusuariosTipo.addItem("R", context.GetMessage( "Usuario Registrado", ""), 0);
         cmbusuariosTipo.addItem("U", context.GetMessage( "Usuario Sin Registrar", ""), 0);
         if ( cmbusuariosTipo.ItemCount > 0 )
         {
         }
         cmbusuariosEstado.Name = "USUARIOSESTADO";
         cmbusuariosEstado.WebTags = "";
         cmbusuariosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbusuariosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbusuariosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbusuariosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbusuariosEstado.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtusuariosId_Internalname = sPrefix+"USUARIOSID";
         cmbusuariosTipo_Internalname = sPrefix+"USUARIOSTIPO";
         edtusuariosNombre_Internalname = sPrefix+"USUARIOSNOMBRE";
         edtusuariosCorreo_Internalname = sPrefix+"USUARIOSCORREO";
         edtPaisID_Internalname = sPrefix+"PAISID";
         edtPaisNombre_Internalname = sPrefix+"PAISNOMBRE";
         edtusuariosDireccion_Internalname = sPrefix+"USUARIOSDIRECCION";
         imgusuariosImagen_Internalname = sPrefix+"USUARIOSIMAGEN";
         edtusuariosPasw_Internalname = sPrefix+"USUARIOSPASW";
         edtusuariosCPostal_Internalname = sPrefix+"USUARIOSCPOSTAL";
         edtusuariosTelefono_Internalname = sPrefix+"USUARIOSTELEFONO";
         cmbusuariosEstado_Internalname = sPrefix+"USUARIOSESTADO";
         edtusuariosNumeroIdentidad_Internalname = sPrefix+"USUARIOSNUMEROIDENTIDAD";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtusuariosEstadoOnOffLine_Internalname = sPrefix+"USUARIOSESTADOONOFFLINE";
         edtusuariosFechaEstadoOnOff_Internalname = sPrefix+"USUARIOSFECHAESTADOONOFF";
         edtusuariosHoraEstadoOnOff_Internalname = sPrefix+"USUARIOSHORAESTADOONOFF";
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
         edtusuariosHoraEstadoOnOff_Enabled = 0;
         edtusuariosFechaEstadoOnOff_Enabled = 0;
         edtusuariosEstadoOnOffLine_Enabled = 0;
         imgusuariosImagen_Enabled = 0;
         edtusuariosHoraEstadoOnOff_Jsonclick = "";
         edtusuariosHoraEstadoOnOff_Visible = 1;
         edtusuariosFechaEstadoOnOff_Jsonclick = "";
         edtusuariosFechaEstadoOnOff_Visible = 1;
         edtusuariosEstadoOnOffLine_Jsonclick = "";
         edtusuariosEstadoOnOffLine_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtusuariosNumeroIdentidad_Jsonclick = "";
         edtusuariosNumeroIdentidad_Enabled = 0;
         cmbusuariosEstado_Jsonclick = "";
         cmbusuariosEstado.Enabled = 0;
         edtusuariosTelefono_Jsonclick = "";
         edtusuariosTelefono_Enabled = 0;
         edtusuariosCPostal_Jsonclick = "";
         edtusuariosCPostal_Enabled = 0;
         edtusuariosPasw_Jsonclick = "";
         edtusuariosPasw_Enabled = 0;
         edtusuariosDireccion_Enabled = 0;
         edtPaisNombre_Jsonclick = "";
         edtPaisNombre_Enabled = 0;
         edtPaisID_Jsonclick = "";
         edtPaisID_Enabled = 0;
         edtusuariosCorreo_Jsonclick = "";
         edtusuariosCorreo_Enabled = 0;
         edtusuariosNombre_Jsonclick = "";
         edtusuariosNombre_Enabled = 0;
         cmbusuariosTipo_Jsonclick = "";
         cmbusuariosTipo.Enabled = 0;
         edtusuariosId_Jsonclick = "";
         edtusuariosId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13BY2',iparms:[{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E14BY2',iparms:[{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[]");
         setEventMetadata("VALID_PAISID",",oparms:[]}");
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
         wcpOA145usuariosId = "";
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
         A225usuariosTipo = "";
         A222usuariosNombre = "";
         A224usuariosCorreo = "";
         A116PaisID = "";
         A165PaisNombre = "";
         ClassString = "";
         StyleString = "";
         A230usuariosDireccion = "";
         A266usuariosImagen = "";
         A40000usuariosImagen_GXI = "";
         sImgUrl = "";
         A223usuariosPasw = "";
         gxphoneLink = "";
         A232usuariosTelefono = "";
         A226usuariosEstado = "";
         A240usuariosNumeroIdentidad = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A227usuariosEstadoOnOffLine = "";
         A228usuariosFechaEstadoOnOff = DateTime.MinValue;
         A229usuariosHoraEstadoOnOff = (DateTime)(DateTime.MinValue);
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00BY2_A145usuariosId = new string[] {""} ;
         H00BY2_A229usuariosHoraEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         H00BY2_A228usuariosFechaEstadoOnOff = new DateTime[] {DateTime.MinValue} ;
         H00BY2_A227usuariosEstadoOnOffLine = new string[] {""} ;
         H00BY2_A240usuariosNumeroIdentidad = new string[] {""} ;
         H00BY2_A226usuariosEstado = new string[] {""} ;
         H00BY2_A232usuariosTelefono = new string[] {""} ;
         H00BY2_A231usuariosCPostal = new int[1] ;
         H00BY2_A223usuariosPasw = new string[] {""} ;
         H00BY2_A40000usuariosImagen_GXI = new string[] {""} ;
         H00BY2_A230usuariosDireccion = new string[] {""} ;
         H00BY2_A165PaisNombre = new string[] {""} ;
         H00BY2_A116PaisID = new string[] {""} ;
         H00BY2_A224usuariosCorreo = new string[] {""} ;
         H00BY2_A222usuariosNombre = new string[] {""} ;
         H00BY2_A225usuariosTipo = new string[] {""} ;
         H00BY2_A266usuariosImagen = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA145usuariosId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuariosgeneral__default(),
            new Object[][] {
                new Object[] {
               H00BY2_A145usuariosId, H00BY2_A229usuariosHoraEstadoOnOff, H00BY2_A228usuariosFechaEstadoOnOff, H00BY2_A227usuariosEstadoOnOffLine, H00BY2_A240usuariosNumeroIdentidad, H00BY2_A226usuariosEstado, H00BY2_A232usuariosTelefono, H00BY2_A231usuariosCPostal, H00BY2_A223usuariosPasw, H00BY2_A40000usuariosImagen_GXI,
               H00BY2_A230usuariosDireccion, H00BY2_A165PaisNombre, H00BY2_A116PaisID, H00BY2_A224usuariosCorreo, H00BY2_A222usuariosNombre, H00BY2_A225usuariosTipo, H00BY2_A266usuariosImagen
               }
            }
         );
         AV13Pgmname = "usuariosGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "usuariosGeneral";
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
      private int edtusuariosId_Enabled ;
      private int edtusuariosNombre_Enabled ;
      private int edtusuariosCorreo_Enabled ;
      private int edtPaisID_Enabled ;
      private int edtPaisNombre_Enabled ;
      private int edtusuariosDireccion_Enabled ;
      private int edtusuariosPasw_Enabled ;
      private int A231usuariosCPostal ;
      private int edtusuariosCPostal_Enabled ;
      private int edtusuariosTelefono_Enabled ;
      private int edtusuariosNumeroIdentidad_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtusuariosEstadoOnOffLine_Visible ;
      private int edtusuariosFechaEstadoOnOff_Visible ;
      private int edtusuariosHoraEstadoOnOff_Visible ;
      private int imgusuariosImagen_Enabled ;
      private int edtusuariosEstadoOnOffLine_Enabled ;
      private int edtusuariosFechaEstadoOnOff_Enabled ;
      private int edtusuariosHoraEstadoOnOff_Enabled ;
      private int idxLst ;
      private string A145usuariosId ;
      private string wcpOA145usuariosId ;
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
      private string edtusuariosId_Internalname ;
      private string TempTags ;
      private string edtusuariosId_Jsonclick ;
      private string cmbusuariosTipo_Internalname ;
      private string A225usuariosTipo ;
      private string cmbusuariosTipo_Jsonclick ;
      private string edtusuariosNombre_Internalname ;
      private string A222usuariosNombre ;
      private string edtusuariosNombre_Jsonclick ;
      private string edtusuariosCorreo_Internalname ;
      private string edtusuariosCorreo_Jsonclick ;
      private string edtPaisID_Internalname ;
      private string A116PaisID ;
      private string edtPaisID_Jsonclick ;
      private string edtPaisNombre_Internalname ;
      private string A165PaisNombre ;
      private string edtPaisNombre_Jsonclick ;
      private string edtusuariosDireccion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string imgusuariosImagen_Internalname ;
      private string sImgUrl ;
      private string edtusuariosPasw_Internalname ;
      private string A223usuariosPasw ;
      private string edtusuariosPasw_Jsonclick ;
      private string edtusuariosCPostal_Internalname ;
      private string edtusuariosCPostal_Jsonclick ;
      private string edtusuariosTelefono_Internalname ;
      private string gxphoneLink ;
      private string A232usuariosTelefono ;
      private string edtusuariosTelefono_Jsonclick ;
      private string cmbusuariosEstado_Internalname ;
      private string A226usuariosEstado ;
      private string cmbusuariosEstado_Jsonclick ;
      private string edtusuariosNumeroIdentidad_Internalname ;
      private string A240usuariosNumeroIdentidad ;
      private string edtusuariosNumeroIdentidad_Jsonclick ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtusuariosEstadoOnOffLine_Internalname ;
      private string A227usuariosEstadoOnOffLine ;
      private string edtusuariosEstadoOnOffLine_Jsonclick ;
      private string edtusuariosFechaEstadoOnOff_Internalname ;
      private string edtusuariosFechaEstadoOnOff_Jsonclick ;
      private string edtusuariosHoraEstadoOnOff_Internalname ;
      private string edtusuariosHoraEstadoOnOff_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlA145usuariosId ;
      private DateTime A229usuariosHoraEstadoOnOff ;
      private DateTime A228usuariosFechaEstadoOnOff ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A266usuariosImagen_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A224usuariosCorreo ;
      private string A230usuariosDireccion ;
      private string A40000usuariosImagen_GXI ;
      private string A266usuariosImagen ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbusuariosTipo ;
      private GXCombobox cmbusuariosEstado ;
      private IDataStoreProvider pr_default ;
      private string[] H00BY2_A145usuariosId ;
      private DateTime[] H00BY2_A229usuariosHoraEstadoOnOff ;
      private DateTime[] H00BY2_A228usuariosFechaEstadoOnOff ;
      private string[] H00BY2_A227usuariosEstadoOnOffLine ;
      private string[] H00BY2_A240usuariosNumeroIdentidad ;
      private string[] H00BY2_A226usuariosEstado ;
      private string[] H00BY2_A232usuariosTelefono ;
      private int[] H00BY2_A231usuariosCPostal ;
      private string[] H00BY2_A223usuariosPasw ;
      private string[] H00BY2_A40000usuariosImagen_GXI ;
      private string[] H00BY2_A230usuariosDireccion ;
      private string[] H00BY2_A165PaisNombre ;
      private string[] H00BY2_A116PaisID ;
      private string[] H00BY2_A224usuariosCorreo ;
      private string[] H00BY2_A222usuariosNombre ;
      private string[] H00BY2_A225usuariosTipo ;
      private string[] H00BY2_A266usuariosImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class usuariosgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00BY2;
          prmH00BY2 = new Object[] {
          new ParDef("@usuariosId",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BY2", "SELECT T1.[usuariosId], T1.[usuariosHoraEstadoOnOff], T1.[usuariosFechaEstadoOnOff], T1.[usuariosEstadoOnOffLine], T1.[usuariosNumeroIdentidad], T1.[usuariosEstado], T1.[usuariosTelefono], T1.[usuariosCPostal], T1.[usuariosPasw], T1.[usuariosImagen_GXI], T1.[usuariosDireccion], T2.[PaisNombre], T1.[PaisID], T1.[usuariosCorreo], T1.[usuariosNombre], T1.[usuariosTipo], T1.[usuariosImagen] FROM ([usuarios] T1 INNER JOIN [Pais] T2 ON T2.[PaisID] = T1.[PaisID]) WHERE T1.[usuariosId] = @usuariosId ORDER BY T1.[usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BY2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 80);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 80);
                ((string[]) buf[12])[0] = rslt.getString(13, 2);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getString(15, 80);
                ((string[]) buf[15])[0] = rslt.getString(16, 1);
                ((string[]) buf[16])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(10));
                return;
       }
    }

 }

}
