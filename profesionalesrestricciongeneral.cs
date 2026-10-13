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
   public class profesionalesrestricciongeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public profesionalesrestricciongeneral( )
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

      public profesionalesrestricciongeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProfesionalesRestriccionId )
      {
         this.A976ProfesionalesRestriccionId = aP0_ProfesionalesRestriccionId;
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
         cmbListaEstado = new GXCombobox();
         cmbListaTipo = new GXCombobox();
         cmbRestriccionesEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ProfesionalesRestriccionId");
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
                  A976ProfesionalesRestriccionId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProfesionalesRestriccionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A976ProfesionalesRestriccionId});
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
                  gxfirstwebparm = GetFirstPar( "ProfesionalesRestriccionId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProfesionalesRestriccionId");
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
            PAKY2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ProfesionalesRestriccionGeneral";
               WSKY2( ) ;
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
            context.SendWebValue( context.GetMessage( "Profesionales Restriccion General", "")) ;
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
            GXEncryptionTmp = "profesionalesrestricciongeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A976ProfesionalesRestriccionId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profesionalesrestricciongeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ProfesionalesRestriccionGeneral");
         forbiddenHiddens.Add("Listaid", context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("profesionalesrestricciongeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA976ProfesionalesRestriccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA976ProfesionalesRestriccionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseFormKY2( )
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
         return "ProfesionalesRestriccionGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Profesionales Restriccion General", "") ;
      }

      protected void WBKY0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "profesionalesrestricciongeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesRestriccionId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesRestriccionId_Internalname, context.GetMessage( "Restriccion Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesRestriccionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A976ProfesionalesRestriccionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfesionalesRestriccionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A976ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A976ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesRestriccionId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesRestriccionId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProfesionalesRestriccionGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesId_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId), StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtProfesionalesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesId_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NoIdentidad", "start", true, "", "HLP_ProfesionalesRestriccionGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesPrimerNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesPrimerNombre_Internalname, context.GetMessage( "Primer Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre), StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesPrimerNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesPrimerNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccionGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesApellidoPrimero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesApellidoPrimero_Internalname, context.GetMessage( "Primero Apellido ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero), StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoPrimero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesApellidoPrimero_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccionGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtListaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtListaid_Internalname, context.GetMessage( "Listaid", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtListaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A590Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtListaid_Enabled!=0) ? context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtListaid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesRestriccionGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtListaNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtListaNombre_Internalname, context.GetMessage( "Lista Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtListaNombre_Internalname, StringUtil.RTrim( A592ListaNombre), StringUtil.RTrim( context.localUtil.Format( A592ListaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtListaNombre_Link, "", "", "", edtListaNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtListaNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ProfesionalesRestriccionGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbListaEstado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbListaEstado_Internalname, context.GetMessage( "Lista Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbListaEstado, cmbListaEstado_Internalname, StringUtil.RTrim( A593ListaEstado), 1, cmbListaEstado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbListaEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_ProfesionalesRestriccionGeneral.htm");
            cmbListaEstado.CurrentValue = StringUtil.RTrim( A593ListaEstado);
            AssignProp(sPrefix, false, cmbListaEstado_Internalname, "Values", (string)(cmbListaEstado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbListaTipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbListaTipo_Internalname, context.GetMessage( "Lista Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbListaTipo, cmbListaTipo_Internalname, StringUtil.RTrim( A591ListaTipo), 1, cmbListaTipo_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbListaTipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_ProfesionalesRestriccionGeneral.htm");
            cmbListaTipo.CurrentValue = StringUtil.RTrim( A591ListaTipo);
            AssignProp(sPrefix, false, cmbListaTipo_Internalname, "Values", (string)(cmbListaTipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRestriccionesFechaAlta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtRestriccionesFechaAlta_Internalname, context.GetMessage( "Fecha Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtRestriccionesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtRestriccionesFechaAlta_Internalname, context.localUtil.TToC( A973RestriccionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A973RestriccionesFechaAlta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRestriccionesFechaAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRestriccionesFechaAlta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesRestriccionGeneral.htm");
            GxWebStd.gx_bitmap( context, edtRestriccionesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtRestriccionesFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ProfesionalesRestriccionGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbRestriccionesEstado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbRestriccionesEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbRestriccionesEstado, cmbRestriccionesEstado_Internalname, StringUtil.RTrim( A974RestriccionesEstado), 1, cmbRestriccionesEstado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbRestriccionesEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_ProfesionalesRestriccionGeneral.htm");
            cmbRestriccionesEstado.CurrentValue = StringUtil.RTrim( A974RestriccionesEstado);
            AssignProp(sPrefix, false, cmbRestriccionesEstado_Internalname, "Values", (string)(cmbRestriccionesEstado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRestriccionesObservacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtRestriccionesObservacion_Internalname, context.GetMessage( "Observacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtRestriccionesObservacion_Internalname, A975RestriccionesObservacion, StringUtil.RTrim( context.localUtil.Format( A975RestriccionesObservacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRestriccionesObservacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRestriccionesObservacion_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccionGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesRestriccionGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesRestriccionGeneral.htm");
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

      protected void STARTKY2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Profesionales Restriccion General", ""), 0) ;
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
               STRUPKY0( ) ;
            }
         }
      }

      protected void WSKY2( )
      {
         STARTKY2( ) ;
         EVTKY2( ) ;
      }

      protected void EVTKY2( )
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
                                 STRUPKY0( ) ;
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
                                 STRUPKY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11KY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12KY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13KY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKY0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14KY2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKY0( ) ;
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
                                 STRUPKY0( ) ;
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

      protected void WEKY2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormKY2( ) ;
            }
         }
      }

      protected void PAKY2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "profesionalesrestricciongeneral.aspx")), "profesionalesrestricciongeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "profesionalesrestricciongeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ProfesionalesRestriccionId");
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
         if ( cmbListaEstado.ItemCount > 0 )
         {
            A593ListaEstado = cmbListaEstado.getValidValue(A593ListaEstado);
            n593ListaEstado = false;
            AssignAttri(sPrefix, false, "A593ListaEstado", A593ListaEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbListaEstado.CurrentValue = StringUtil.RTrim( A593ListaEstado);
            AssignProp(sPrefix, false, cmbListaEstado_Internalname, "Values", cmbListaEstado.ToJavascriptSource(), true);
         }
         if ( cmbListaTipo.ItemCount > 0 )
         {
            A591ListaTipo = cmbListaTipo.getValidValue(A591ListaTipo);
            AssignAttri(sPrefix, false, "A591ListaTipo", A591ListaTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbListaTipo.CurrentValue = StringUtil.RTrim( A591ListaTipo);
            AssignProp(sPrefix, false, cmbListaTipo_Internalname, "Values", cmbListaTipo.ToJavascriptSource(), true);
         }
         if ( cmbRestriccionesEstado.ItemCount > 0 )
         {
            A974RestriccionesEstado = cmbRestriccionesEstado.getValidValue(A974RestriccionesEstado);
            n974RestriccionesEstado = false;
            AssignAttri(sPrefix, false, "A974RestriccionesEstado", A974RestriccionesEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRestriccionesEstado.CurrentValue = StringUtil.RTrim( A974RestriccionesEstado);
            AssignProp(sPrefix, false, cmbRestriccionesEstado_Internalname, "Values", cmbRestriccionesEstado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFKY2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ProfesionalesRestriccionGeneral";
      }

      protected void RFKY2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00KY2 */
            pr_default.execute(0, new Object[] {A976ProfesionalesRestriccionId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A975RestriccionesObservacion = H00KY2_A975RestriccionesObservacion[0];
               n975RestriccionesObservacion = H00KY2_n975RestriccionesObservacion[0];
               AssignAttri(sPrefix, false, "A975RestriccionesObservacion", A975RestriccionesObservacion);
               A974RestriccionesEstado = H00KY2_A974RestriccionesEstado[0];
               n974RestriccionesEstado = H00KY2_n974RestriccionesEstado[0];
               AssignAttri(sPrefix, false, "A974RestriccionesEstado", A974RestriccionesEstado);
               A973RestriccionesFechaAlta = H00KY2_A973RestriccionesFechaAlta[0];
               n973RestriccionesFechaAlta = H00KY2_n973RestriccionesFechaAlta[0];
               AssignAttri(sPrefix, false, "A973RestriccionesFechaAlta", context.localUtil.TToC( A973RestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A591ListaTipo = H00KY2_A591ListaTipo[0];
               AssignAttri(sPrefix, false, "A591ListaTipo", A591ListaTipo);
               A593ListaEstado = H00KY2_A593ListaEstado[0];
               n593ListaEstado = H00KY2_n593ListaEstado[0];
               AssignAttri(sPrefix, false, "A593ListaEstado", A593ListaEstado);
               A592ListaNombre = H00KY2_A592ListaNombre[0];
               AssignAttri(sPrefix, false, "A592ListaNombre", A592ListaNombre);
               A590Listaid = H00KY2_A590Listaid[0];
               AssignAttri(sPrefix, false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
               A167ProfesionalesApellidoPrimero = H00KY2_A167ProfesionalesApellidoPrimero[0];
               AssignAttri(sPrefix, false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
               A166ProfesionalesPrimerNombre = H00KY2_A166ProfesionalesPrimerNombre[0];
               AssignAttri(sPrefix, false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
               A120ProfesionalesId = H00KY2_A120ProfesionalesId[0];
               AssignAttri(sPrefix, false, "A120ProfesionalesId", A120ProfesionalesId);
               A591ListaTipo = H00KY2_A591ListaTipo[0];
               AssignAttri(sPrefix, false, "A591ListaTipo", A591ListaTipo);
               A593ListaEstado = H00KY2_A593ListaEstado[0];
               n593ListaEstado = H00KY2_n593ListaEstado[0];
               AssignAttri(sPrefix, false, "A593ListaEstado", A593ListaEstado);
               A592ListaNombre = H00KY2_A592ListaNombre[0];
               AssignAttri(sPrefix, false, "A592ListaNombre", A592ListaNombre);
               A167ProfesionalesApellidoPrimero = H00KY2_A167ProfesionalesApellidoPrimero[0];
               AssignAttri(sPrefix, false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
               A166ProfesionalesPrimerNombre = H00KY2_A166ProfesionalesPrimerNombre[0];
               AssignAttri(sPrefix, false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
               /* Execute user event: Load */
               E12KY2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WBKY0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesKY2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ProfesionalesRestriccionGeneral";
         edtProfesionalesRestriccionId_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesRestriccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesRestriccionId_Enabled), 5, 0), true);
         edtProfesionalesId_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         edtProfesionalesPrimerNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesPrimerNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0), true);
         edtProfesionalesApellidoPrimero_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesApellidoPrimero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0), true);
         edtListaid_Enabled = 0;
         AssignProp(sPrefix, false, edtListaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaid_Enabled), 5, 0), true);
         edtListaNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtListaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaNombre_Enabled), 5, 0), true);
         cmbListaEstado.Enabled = 0;
         AssignProp(sPrefix, false, cmbListaEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbListaEstado.Enabled), 5, 0), true);
         cmbListaTipo.Enabled = 0;
         AssignProp(sPrefix, false, cmbListaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbListaTipo.Enabled), 5, 0), true);
         edtRestriccionesFechaAlta_Enabled = 0;
         AssignProp(sPrefix, false, edtRestriccionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRestriccionesFechaAlta_Enabled), 5, 0), true);
         cmbRestriccionesEstado.Enabled = 0;
         AssignProp(sPrefix, false, cmbRestriccionesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRestriccionesEstado.Enabled), 5, 0), true);
         edtRestriccionesObservacion_Enabled = 0;
         AssignProp(sPrefix, false, edtRestriccionesObservacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRestriccionesObservacion_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPKY0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11KY2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA976ProfesionalesRestriccionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA976ProfesionalesRestriccionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
            AssignAttri(sPrefix, false, "A120ProfesionalesId", A120ProfesionalesId);
            A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
            AssignAttri(sPrefix, false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
            AssignAttri(sPrefix, false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            A590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            A592ListaNombre = cgiGet( edtListaNombre_Internalname);
            AssignAttri(sPrefix, false, "A592ListaNombre", A592ListaNombre);
            cmbListaEstado.CurrentValue = cgiGet( cmbListaEstado_Internalname);
            A593ListaEstado = cgiGet( cmbListaEstado_Internalname);
            n593ListaEstado = false;
            AssignAttri(sPrefix, false, "A593ListaEstado", A593ListaEstado);
            cmbListaTipo.CurrentValue = cgiGet( cmbListaTipo_Internalname);
            A591ListaTipo = cgiGet( cmbListaTipo_Internalname);
            AssignAttri(sPrefix, false, "A591ListaTipo", A591ListaTipo);
            A973RestriccionesFechaAlta = context.localUtil.CToT( cgiGet( edtRestriccionesFechaAlta_Internalname));
            n973RestriccionesFechaAlta = false;
            AssignAttri(sPrefix, false, "A973RestriccionesFechaAlta", context.localUtil.TToC( A973RestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            cmbRestriccionesEstado.CurrentValue = cgiGet( cmbRestriccionesEstado_Internalname);
            A974RestriccionesEstado = cgiGet( cmbRestriccionesEstado_Internalname);
            n974RestriccionesEstado = false;
            AssignAttri(sPrefix, false, "A974RestriccionesEstado", A974RestriccionesEstado);
            A975RestriccionesObservacion = cgiGet( edtRestriccionesObservacion_Internalname);
            n975RestriccionesObservacion = false;
            AssignAttri(sPrefix, false, "A975RestriccionesObservacion", A975RestriccionesObservacion);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ProfesionalesRestriccionGeneral");
            A590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A590Listaid", StringUtil.LTrimStr( (decimal)(A590Listaid), 18, 0));
            forbiddenHiddens.Add("Listaid", context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("profesionalesrestricciongeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E11KY2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11KY2( )
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

      protected void E12KY2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWLista", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( AV12TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "listaview.aspx"+UrlEncode(StringUtil.LTrimStr(A590Listaid,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtListaNombre_Link = formatLink("listaview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtListaNombre_Internalname, "Link", edtListaNombre_Link, true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionalesRestriccion_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionalesRestriccion_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13KY2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionalesrestriccion.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A976ProfesionalesRestriccionId,18,0));
         CallWebObject(formatLink("profesionalesrestriccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14KY2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionalesrestriccion.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A976ProfesionalesRestriccionId,18,0));
         CallWebObject(formatLink("profesionalesrestriccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Transactionname = "ProfesionalesRestriccion";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A976ProfesionalesRestriccionId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
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
         PAKY2( ) ;
         WSKY2( ) ;
         WEKY2( ) ;
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
         sCtrlA976ProfesionalesRestriccionId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAKY2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "profesionalesrestricciongeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAKY2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A976ProfesionalesRestriccionId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
         }
         wcpOA976ProfesionalesRestriccionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA976ProfesionalesRestriccionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A976ProfesionalesRestriccionId != wcpOA976ProfesionalesRestriccionId ) ) )
         {
            setjustcreated();
         }
         wcpOA976ProfesionalesRestriccionId = A976ProfesionalesRestriccionId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA976ProfesionalesRestriccionId = cgiGet( sPrefix+"A976ProfesionalesRestriccionId_CTRL");
         if ( StringUtil.Len( sCtrlA976ProfesionalesRestriccionId) > 0 )
         {
            A976ProfesionalesRestriccionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA976ProfesionalesRestriccionId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A976ProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(A976ProfesionalesRestriccionId), 18, 0));
         }
         else
         {
            A976ProfesionalesRestriccionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A976ProfesionalesRestriccionId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PAKY2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSKY2( ) ;
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
         WSKY2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A976ProfesionalesRestriccionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A976ProfesionalesRestriccionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA976ProfesionalesRestriccionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A976ProfesionalesRestriccionId_CTRL", StringUtil.RTrim( sCtrlA976ProfesionalesRestriccionId));
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
         WEKY2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320113229", true, true, false);
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
         context.AddJavascriptSource("profesionalesrestricciongeneral.js", "?20269320113229", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbListaEstado.Name = "LISTAESTADO";
         cmbListaEstado.WebTags = "";
         cmbListaEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbListaEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbListaEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbListaEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbListaEstado.ItemCount > 0 )
         {
         }
         cmbListaTipo.Name = "LISTATIPO";
         cmbListaTipo.WebTags = "";
         cmbListaTipo.addItem("PROV", context.GetMessage( "Proveedor", ""), 0);
         cmbListaTipo.addItem("PROF", context.GetMessage( "Profesional", ""), 0);
         cmbListaTipo.addItem("ADM", context.GetMessage( "Administrativa", ""), 0);
         cmbListaTipo.addItem("RST", context.GetMessage( "Restriccion", ""), 0);
         if ( cmbListaTipo.ItemCount > 0 )
         {
         }
         cmbRestriccionesEstado.Name = "RESTRICCIONESESTADO";
         cmbRestriccionesEstado.WebTags = "";
         cmbRestriccionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbRestriccionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbRestriccionesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbRestriccionesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbRestriccionesEstado.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtProfesionalesRestriccionId_Internalname = sPrefix+"PROFESIONALESRESTRICCIONID";
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO";
         edtListaid_Internalname = sPrefix+"LISTAID";
         edtListaNombre_Internalname = sPrefix+"LISTANOMBRE";
         cmbListaEstado_Internalname = sPrefix+"LISTAESTADO";
         cmbListaTipo_Internalname = sPrefix+"LISTATIPO";
         edtRestriccionesFechaAlta_Internalname = sPrefix+"RESTRICCIONESFECHAALTA";
         cmbRestriccionesEstado_Internalname = sPrefix+"RESTRICCIONESESTADO";
         edtRestriccionesObservacion_Internalname = sPrefix+"RESTRICCIONESOBSERVACION";
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
         edtRestriccionesObservacion_Jsonclick = "";
         edtRestriccionesObservacion_Enabled = 0;
         cmbRestriccionesEstado_Jsonclick = "";
         cmbRestriccionesEstado.Enabled = 0;
         edtRestriccionesFechaAlta_Jsonclick = "";
         edtRestriccionesFechaAlta_Enabled = 0;
         cmbListaTipo_Jsonclick = "";
         cmbListaTipo.Enabled = 0;
         cmbListaEstado_Jsonclick = "";
         cmbListaEstado.Enabled = 0;
         edtListaNombre_Jsonclick = "";
         edtListaNombre_Link = "";
         edtListaNombre_Enabled = 0;
         edtListaid_Jsonclick = "";
         edtListaid_Enabled = 0;
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Jsonclick = "";
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesRestriccionId_Jsonclick = "";
         edtProfesionalesRestriccionId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A976ProfesionalesRestriccionId',fld:'PROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13KY2',iparms:[{av:'A976ProfesionalesRestriccionId',fld:'PROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E14KY2',iparms:[{av:'A976ProfesionalesRestriccionId',fld:'PROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESRESTRICCIONID","{handler:'Valid_Profesionalesrestriccionid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESRESTRICCIONID",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[]}");
         setEventMetadata("VALID_LISTAID","{handler:'Valid_Listaid',iparms:[]");
         setEventMetadata("VALID_LISTAID",",oparms:[]}");
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
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A592ListaNombre = "";
         A593ListaEstado = "";
         A591ListaTipo = "";
         A973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         A974RestriccionesEstado = "";
         A975RestriccionesObservacion = "";
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
         H00KY2_A976ProfesionalesRestriccionId = new long[1] ;
         H00KY2_A975RestriccionesObservacion = new string[] {""} ;
         H00KY2_n975RestriccionesObservacion = new bool[] {false} ;
         H00KY2_A974RestriccionesEstado = new string[] {""} ;
         H00KY2_n974RestriccionesEstado = new bool[] {false} ;
         H00KY2_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00KY2_n973RestriccionesFechaAlta = new bool[] {false} ;
         H00KY2_A591ListaTipo = new string[] {""} ;
         H00KY2_A593ListaEstado = new string[] {""} ;
         H00KY2_n593ListaEstado = new bool[] {false} ;
         H00KY2_A592ListaNombre = new string[] {""} ;
         H00KY2_A590Listaid = new long[1] ;
         H00KY2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00KY2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00KY2_A120ProfesionalesId = new string[] {""} ;
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA976ProfesionalesRestriccionId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesrestricciongeneral__default(),
            new Object[][] {
                new Object[] {
               H00KY2_A976ProfesionalesRestriccionId, H00KY2_A975RestriccionesObservacion, H00KY2_n975RestriccionesObservacion, H00KY2_A974RestriccionesEstado, H00KY2_n974RestriccionesEstado, H00KY2_A973RestriccionesFechaAlta, H00KY2_n973RestriccionesFechaAlta, H00KY2_A591ListaTipo, H00KY2_A593ListaEstado, H00KY2_n593ListaEstado,
               H00KY2_A592ListaNombre, H00KY2_A590Listaid, H00KY2_A167ProfesionalesApellidoPrimero, H00KY2_A166ProfesionalesPrimerNombre, H00KY2_A120ProfesionalesId
               }
            }
         );
         AV13Pgmname = "ProfesionalesRestriccionGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ProfesionalesRestriccionGeneral";
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
      private int edtProfesionalesRestriccionId_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtListaid_Enabled ;
      private int edtListaNombre_Enabled ;
      private int edtRestriccionesFechaAlta_Enabled ;
      private int edtRestriccionesObservacion_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int idxLst ;
      private long A976ProfesionalesRestriccionId ;
      private long wcpOA976ProfesionalesRestriccionId ;
      private long A590Listaid ;
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
      private string edtProfesionalesRestriccionId_Internalname ;
      private string TempTags ;
      private string edtProfesionalesRestriccionId_Jsonclick ;
      private string edtProfesionalesId_Internalname ;
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string A166ProfesionalesPrimerNombre ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtListaid_Internalname ;
      private string edtListaid_Jsonclick ;
      private string edtListaNombre_Internalname ;
      private string A592ListaNombre ;
      private string edtListaNombre_Link ;
      private string edtListaNombre_Jsonclick ;
      private string cmbListaEstado_Internalname ;
      private string A593ListaEstado ;
      private string cmbListaEstado_Jsonclick ;
      private string cmbListaTipo_Internalname ;
      private string A591ListaTipo ;
      private string cmbListaTipo_Jsonclick ;
      private string edtRestriccionesFechaAlta_Internalname ;
      private string edtRestriccionesFechaAlta_Jsonclick ;
      private string cmbRestriccionesEstado_Internalname ;
      private string A974RestriccionesEstado ;
      private string cmbRestriccionesEstado_Jsonclick ;
      private string edtRestriccionesObservacion_Internalname ;
      private string edtRestriccionesObservacion_Jsonclick ;
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
      private string hsh ;
      private string sCtrlA976ProfesionalesRestriccionId ;
      private DateTime A973RestriccionesFechaAlta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n593ListaEstado ;
      private bool n974RestriccionesEstado ;
      private bool gxdyncontrolsrefreshing ;
      private bool n975RestriccionesObservacion ;
      private bool n973RestriccionesFechaAlta ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A975RestriccionesObservacion ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbListaEstado ;
      private GXCombobox cmbListaTipo ;
      private GXCombobox cmbRestriccionesEstado ;
      private IDataStoreProvider pr_default ;
      private long[] H00KY2_A976ProfesionalesRestriccionId ;
      private string[] H00KY2_A975RestriccionesObservacion ;
      private bool[] H00KY2_n975RestriccionesObservacion ;
      private string[] H00KY2_A974RestriccionesEstado ;
      private bool[] H00KY2_n974RestriccionesEstado ;
      private DateTime[] H00KY2_A973RestriccionesFechaAlta ;
      private bool[] H00KY2_n973RestriccionesFechaAlta ;
      private string[] H00KY2_A591ListaTipo ;
      private string[] H00KY2_A593ListaEstado ;
      private bool[] H00KY2_n593ListaEstado ;
      private string[] H00KY2_A592ListaNombre ;
      private long[] H00KY2_A590Listaid ;
      private string[] H00KY2_A167ProfesionalesApellidoPrimero ;
      private string[] H00KY2_A166ProfesionalesPrimerNombre ;
      private string[] H00KY2_A120ProfesionalesId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class profesionalesrestricciongeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00KY2;
          prmH00KY2 = new Object[] {
          new ParDef("@ProfesionalesRestriccionId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00KY2", "SELECT T1.[ProfesionalesRestriccionId], T1.[RestriccionesObservacion], T1.[RestriccionesEstado], T1.[RestriccionesFechaAlta], T2.[ListaTipo], T2.[ListaEstado], T2.[ListaNombre], T1.[Listaid], T3.[ProfesionalesApellidoPrimero], T3.[ProfesionalesPrimerNombre], T1.[ProfesionalesId] FROM (([ProfesionalesRestriccion] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE T1.[ProfesionalesRestriccionId] = @ProfesionalesRestriccionId ORDER BY T1.[ProfesionalesRestriccionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KY2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 4);
                ((string[]) buf[8])[0] = rslt.getString(6, 3);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getString(7, 80);
                ((long[]) buf[11])[0] = rslt.getLong(8);
                ((string[]) buf[12])[0] = rslt.getString(9, 30);
                ((string[]) buf[13])[0] = rslt.getString(10, 30);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                return;
       }
    }

 }

}
