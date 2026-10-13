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
   public class postulacionesgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public postulacionesgeneral( )
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

      public postulacionesgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_PostulacionesId )
      {
         this.A422PostulacionesId = aP0_PostulacionesId;
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
         chkPostulacionesReqSuministros = new GXCheckbox();
         cmbPostulacionesRgoHoraservicio = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "PostulacionesId");
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
                  A422PostulacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesId"), "."), 18, MidpointRounding.ToEven));
                  n422PostulacionesId = false;
                  AssignAttri(sPrefix, false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A422PostulacionesId});
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
                  gxfirstwebparm = GetFirstPar( "PostulacionesId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "PostulacionesId");
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
            PAKN2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "PostulacionesGeneral";
               /* Using cursor H00KN3 */
               pr_default.execute(0, new Object[] {n422PostulacionesId, A422PostulacionesId});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A970PostulacionesSolicitudesId = H00KN3_A970PostulacionesSolicitudesId[0];
                  n970PostulacionesSolicitudesId = H00KN3_n970PostulacionesSolicitudesId[0];
                  AssignAttri(sPrefix, false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
               }
               else
               {
                  A970PostulacionesSolicitudesId = 0;
                  n970PostulacionesSolicitudesId = false;
                  AssignAttri(sPrefix, false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
               }
               pr_default.close(0);
               WSKN2( ) ;
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
            context.SendWebValue( context.GetMessage( "Postulaciones General", "")) ;
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
            GXEncryptionTmp = "postulacionesgeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A422PostulacionesId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("postulacionesgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"PostulacionesGeneral");
         forbiddenHiddens.Add("PostulacionesProveedorId", context.localUtil.Format( (decimal)(A945PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("ServiciosId", context.localUtil.Format( (decimal)(A942ServiciosId), "ZZZZZZZZZZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("postulacionesgeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA422PostulacionesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA422PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseFormKN2( )
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
         return "PostulacionesGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Postulaciones General", "") ;
      }

      protected void WBKN0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "postulacionesgeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesApellidoNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesApellidoNombre_Internalname, context.GetMessage( "Apellido Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPostulacionesApellidoNombre_Internalname, StringUtil.RTrim( A950PostulacionesApellidoNombre), StringUtil.RTrim( context.localUtil.Format( A950PostulacionesApellidoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesApellidoNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesApellidoNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesMail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesMail_Internalname, context.GetMessage( "Mail", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPostulacionesMail_Internalname, A951PostulacionesMail, StringUtil.RTrim( context.localUtil.Format( A951PostulacionesMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A951PostulacionesMail, "", "", "", edtPostulacionesMail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesMail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesTelefono_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesTelefono_Internalname, context.GetMessage( "Telefono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A952PostulacionesTelefono);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPostulacionesTelefono_Internalname, StringUtil.RTrim( A952PostulacionesTelefono), StringUtil.RTrim( context.localUtil.Format( A952PostulacionesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtPostulacionesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesProveedorId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesProveedorId_Internalname, context.GetMessage( "Proveedor Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPostulacionesProveedorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A945PostulacionesProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPostulacionesProveedorId_Enabled!=0) ? context.localUtil.Format( (decimal)(A945PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A945PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesProveedorId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesProveedorId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesProveedorNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesProveedorNombre_Internalname, context.GetMessage( "Proveedor Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPostulacionesProveedorNombre_Internalname, StringUtil.RTrim( A969PostulacionesProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A969PostulacionesProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtPostulacionesProveedorNombre_Link, "", "", "", edtPostulacionesProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesPrecio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesPrecio_Internalname, context.GetMessage( "Cotización", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPostulacionesPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A946PostulacionesPrecio, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPostulacionesPrecio_Enabled!=0) ? context.localUtil.Format( A946PostulacionesPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A946PostulacionesPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,37);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesPrecio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesPrecio_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesDescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesDescripcion_Internalname, context.GetMessage( "Descripción General", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtPostulacionesDescripcion_Internalname, StringUtil.RTrim( A936PostulacionesDescripcion), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", 0, 1, edtPostulacionesDescripcion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkPostulacionesReqSuministros_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkPostulacionesReqSuministros_Internalname, context.GetMessage( "¿Req. Suministros?", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkPostulacionesReqSuministros_Internalname, StringUtil.BoolToStr( A937PostulacionesReqSuministros), "", context.GetMessage( "¿Req. Suministros?", ""), 1, chkPostulacionesReqSuministros.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(46, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,46);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesSuministrosDescri_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesSuministrosDescri_Internalname, context.GetMessage( "Descripción de Suministros", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtPostulacionesSuministrosDescri_Internalname, StringUtil.RTrim( A938PostulacionesSuministrosDescri), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", 0, 1, edtPostulacionesSuministrosDescri_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "Descripcion", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesFechaCierre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesFechaCierre_Internalname, context.GetMessage( "Fecha Cierre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtPostulacionesFechaCierre_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPostulacionesFechaCierre_Internalname, context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"), context.localUtil.Format( A939PostulacionesFechaCierre, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,55);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesFechaCierre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesFechaCierre_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPostulacionesFechaCierre_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPostulacionesFechaCierre_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_PostulacionesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesHoraCierre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesHoraCierre_Internalname, context.GetMessage( "Hora Cierre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPostulacionesHoraCierre_Internalname, A940PostulacionesHoraCierre, StringUtil.RTrim( context.localUtil.Format( A940PostulacionesHoraCierre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesHoraCierre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesHoraCierre_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesFechaTrabajo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesFechaTrabajo_Internalname, context.GetMessage( "Fecha Instalacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtPostulacionesFechaTrabajo_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPostulacionesFechaTrabajo_Internalname, context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99"), context.localUtil.Format( A947PostulacionesFechaTrabajo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesFechaTrabajo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesFechaTrabajo_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPostulacionesFechaTrabajo_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPostulacionesFechaTrabajo_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_PostulacionesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPostulacionesRgoHoraservicio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbPostulacionesRgoHoraservicio_Internalname, context.GetMessage( "Hora Instalación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbPostulacionesRgoHoraservicio, cmbPostulacionesRgoHoraservicio_Internalname, StringUtil.RTrim( A949PostulacionesRgoHoraservicio), 1, cmbPostulacionesRgoHoraservicio_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbPostulacionesRgoHoraservicio.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_PostulacionesGeneral.htm");
            cmbPostulacionesRgoHoraservicio.CurrentValue = StringUtil.RTrim( A949PostulacionesRgoHoraservicio);
            AssignProp(sPrefix, false, cmbPostulacionesRgoHoraservicio_Internalname, "Values", (string)(cmbPostulacionesRgoHoraservicio.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtServiciosNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtServiciosNombre_Internalname, context.GetMessage( "Servicio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtServiciosNombre_Internalname, StringUtil.RTrim( A943ServiciosNombre), StringUtil.RTrim( context.localUtil.Format( A943ServiciosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtServiciosNombre_Link, "", "", "", edtServiciosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtServiciosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPostulacionesSolicitudesId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPostulacionesSolicitudesId_Internalname, context.GetMessage( "Solicitudes Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtPostulacionesSolicitudesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A970PostulacionesSolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtPostulacionesSolicitudesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A970PostulacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A970PostulacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,77);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesSolicitudesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPostulacionesSolicitudesId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PostulacionesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PostulacionesGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtPostulacionesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesId_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesId_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PostulacionesGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtServiciosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A942ServiciosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A942ServiciosId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtServiciosId_Jsonclick, 0, "Attribute", "", "", "", "", edtServiciosId_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PostulacionesGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPostulacionesTipoFecha_Internalname, A941PostulacionesTipoFecha, StringUtil.RTrim( context.localUtil.Format( A941PostulacionesTipoFecha, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesTipoFecha_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesTipoFecha_Visible, 0, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PostulacionesGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPostulacionesEstado_Internalname, StringUtil.RTrim( A424PostulacionesEstado), StringUtil.RTrim( context.localUtil.Format( A424PostulacionesEstado, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesEstado_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesEstado_Visible, 0, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "Estado", "start", true, "", "HLP_PostulacionesGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPostulacionesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPostulacionesFechaAlta_Internalname, context.localUtil.TToC( A425PostulacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A425PostulacionesFechaAlta, "99/99/99 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesFechaAlta_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesFechaAlta_Visible, 0, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPostulacionesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPostulacionesFechaAlta_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_PostulacionesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPostulacionesSecUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A948PostulacionesSecUserId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A948PostulacionesSecUserId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesSecUserId_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PostulacionesGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPostulacionesMultimediaSerial_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A961PostulacionesMultimediaSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A961PostulacionesMultimediaSerial), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesMultimediaSerial_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesMultimediaSerial_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PostulacionesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTKN2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Postulaciones General", ""), 0) ;
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
               STRUPKN0( ) ;
            }
         }
      }

      protected void WSKN2( )
      {
         STARTKN2( ) ;
         EVTKN2( ) ;
      }

      protected void EVTKN2( )
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
                                 STRUPKN0( ) ;
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
                                 STRUPKN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11KN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12KN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13KN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKN0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14KN2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKN0( ) ;
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
                                 STRUPKN0( ) ;
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

      protected void WEKN2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormKN2( ) ;
            }
         }
      }

      protected void PAKN2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "postulacionesgeneral.aspx")), "postulacionesgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "postulacionesgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "PostulacionesId");
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
         A937PostulacionesReqSuministros = StringUtil.StrToBool( StringUtil.BoolToStr( A937PostulacionesReqSuministros));
         AssignAttri(sPrefix, false, "A937PostulacionesReqSuministros", A937PostulacionesReqSuministros);
         if ( cmbPostulacionesRgoHoraservicio.ItemCount > 0 )
         {
            A949PostulacionesRgoHoraservicio = cmbPostulacionesRgoHoraservicio.getValidValue(A949PostulacionesRgoHoraservicio);
            AssignAttri(sPrefix, false, "A949PostulacionesRgoHoraservicio", A949PostulacionesRgoHoraservicio);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPostulacionesRgoHoraservicio.CurrentValue = StringUtil.RTrim( A949PostulacionesRgoHoraservicio);
            AssignProp(sPrefix, false, cmbPostulacionesRgoHoraservicio_Internalname, "Values", cmbPostulacionesRgoHoraservicio.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFKN2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "PostulacionesGeneral";
      }

      protected void RFKN2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00KN5 */
            pr_default.execute(1, new Object[] {n422PostulacionesId, A422PostulacionesId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A961PostulacionesMultimediaSerial = H00KN5_A961PostulacionesMultimediaSerial[0];
               AssignAttri(sPrefix, false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
               A948PostulacionesSecUserId = H00KN5_A948PostulacionesSecUserId[0];
               AssignAttri(sPrefix, false, "A948PostulacionesSecUserId", StringUtil.LTrimStr( (decimal)(A948PostulacionesSecUserId), 18, 0));
               A425PostulacionesFechaAlta = H00KN5_A425PostulacionesFechaAlta[0];
               AssignAttri(sPrefix, false, "A425PostulacionesFechaAlta", context.localUtil.TToC( A425PostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A424PostulacionesEstado = H00KN5_A424PostulacionesEstado[0];
               AssignAttri(sPrefix, false, "A424PostulacionesEstado", A424PostulacionesEstado);
               A941PostulacionesTipoFecha = H00KN5_A941PostulacionesTipoFecha[0];
               AssignAttri(sPrefix, false, "A941PostulacionesTipoFecha", A941PostulacionesTipoFecha);
               A942ServiciosId = H00KN5_A942ServiciosId[0];
               n942ServiciosId = H00KN5_n942ServiciosId[0];
               AssignAttri(sPrefix, false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
               A943ServiciosNombre = H00KN5_A943ServiciosNombre[0];
               AssignAttri(sPrefix, false, "A943ServiciosNombre", A943ServiciosNombre);
               A949PostulacionesRgoHoraservicio = H00KN5_A949PostulacionesRgoHoraservicio[0];
               AssignAttri(sPrefix, false, "A949PostulacionesRgoHoraservicio", A949PostulacionesRgoHoraservicio);
               A947PostulacionesFechaTrabajo = H00KN5_A947PostulacionesFechaTrabajo[0];
               AssignAttri(sPrefix, false, "A947PostulacionesFechaTrabajo", context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99"));
               A940PostulacionesHoraCierre = H00KN5_A940PostulacionesHoraCierre[0];
               AssignAttri(sPrefix, false, "A940PostulacionesHoraCierre", A940PostulacionesHoraCierre);
               A939PostulacionesFechaCierre = H00KN5_A939PostulacionesFechaCierre[0];
               AssignAttri(sPrefix, false, "A939PostulacionesFechaCierre", context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"));
               A938PostulacionesSuministrosDescri = H00KN5_A938PostulacionesSuministrosDescri[0];
               AssignAttri(sPrefix, false, "A938PostulacionesSuministrosDescri", A938PostulacionesSuministrosDescri);
               A937PostulacionesReqSuministros = H00KN5_A937PostulacionesReqSuministros[0];
               AssignAttri(sPrefix, false, "A937PostulacionesReqSuministros", A937PostulacionesReqSuministros);
               A936PostulacionesDescripcion = H00KN5_A936PostulacionesDescripcion[0];
               AssignAttri(sPrefix, false, "A936PostulacionesDescripcion", A936PostulacionesDescripcion);
               A946PostulacionesPrecio = H00KN5_A946PostulacionesPrecio[0];
               AssignAttri(sPrefix, false, "A946PostulacionesPrecio", StringUtil.LTrimStr( A946PostulacionesPrecio, 18, 2));
               A969PostulacionesProveedorNombre = H00KN5_A969PostulacionesProveedorNombre[0];
               AssignAttri(sPrefix, false, "A969PostulacionesProveedorNombre", A969PostulacionesProveedorNombre);
               A945PostulacionesProveedorId = H00KN5_A945PostulacionesProveedorId[0];
               AssignAttri(sPrefix, false, "A945PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(A945PostulacionesProveedorId), 18, 0));
               A952PostulacionesTelefono = H00KN5_A952PostulacionesTelefono[0];
               AssignAttri(sPrefix, false, "A952PostulacionesTelefono", A952PostulacionesTelefono);
               A951PostulacionesMail = H00KN5_A951PostulacionesMail[0];
               AssignAttri(sPrefix, false, "A951PostulacionesMail", A951PostulacionesMail);
               A950PostulacionesApellidoNombre = H00KN5_A950PostulacionesApellidoNombre[0];
               AssignAttri(sPrefix, false, "A950PostulacionesApellidoNombre", A950PostulacionesApellidoNombre);
               A970PostulacionesSolicitudesId = H00KN5_A970PostulacionesSolicitudesId[0];
               n970PostulacionesSolicitudesId = H00KN5_n970PostulacionesSolicitudesId[0];
               AssignAttri(sPrefix, false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
               A943ServiciosNombre = H00KN5_A943ServiciosNombre[0];
               AssignAttri(sPrefix, false, "A943ServiciosNombre", A943ServiciosNombre);
               A969PostulacionesProveedorNombre = H00KN5_A969PostulacionesProveedorNombre[0];
               AssignAttri(sPrefix, false, "A969PostulacionesProveedorNombre", A969PostulacionesProveedorNombre);
               A970PostulacionesSolicitudesId = H00KN5_A970PostulacionesSolicitudesId[0];
               n970PostulacionesSolicitudesId = H00KN5_n970PostulacionesSolicitudesId[0];
               AssignAttri(sPrefix, false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
               /* Execute user event: Load */
               E12KN2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WBKN0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesKN2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "PostulacionesGeneral";
         /* Using cursor H00KN7 */
         pr_default.execute(2, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A970PostulacionesSolicitudesId = H00KN7_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = H00KN7_n970PostulacionesSolicitudesId[0];
            AssignAttri(sPrefix, false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
         }
         else
         {
            A970PostulacionesSolicitudesId = 0;
            n970PostulacionesSolicitudesId = false;
            AssignAttri(sPrefix, false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
         }
         pr_default.close(2);
         edtPostulacionesApellidoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesApellidoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesApellidoNombre_Enabled), 5, 0), true);
         edtPostulacionesMail_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesMail_Enabled), 5, 0), true);
         edtPostulacionesTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesTelefono_Enabled), 5, 0), true);
         edtPostulacionesProveedorId_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesProveedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesProveedorId_Enabled), 5, 0), true);
         edtPostulacionesProveedorNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesProveedorNombre_Enabled), 5, 0), true);
         edtPostulacionesPrecio_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesPrecio_Enabled), 5, 0), true);
         edtPostulacionesDescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesDescripcion_Enabled), 5, 0), true);
         chkPostulacionesReqSuministros.Enabled = 0;
         AssignProp(sPrefix, false, chkPostulacionesReqSuministros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkPostulacionesReqSuministros.Enabled), 5, 0), true);
         edtPostulacionesSuministrosDescri_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesSuministrosDescri_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesSuministrosDescri_Enabled), 5, 0), true);
         edtPostulacionesFechaCierre_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesFechaCierre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesFechaCierre_Enabled), 5, 0), true);
         edtPostulacionesHoraCierre_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesHoraCierre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesHoraCierre_Enabled), 5, 0), true);
         edtPostulacionesFechaTrabajo_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesFechaTrabajo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesFechaTrabajo_Enabled), 5, 0), true);
         cmbPostulacionesRgoHoraservicio.Enabled = 0;
         AssignProp(sPrefix, false, cmbPostulacionesRgoHoraservicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPostulacionesRgoHoraservicio.Enabled), 5, 0), true);
         edtServiciosNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtServiciosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServiciosNombre_Enabled), 5, 0), true);
         edtPostulacionesSolicitudesId_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesSolicitudesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesSolicitudesId_Enabled), 5, 0), true);
         edtPostulacionesId_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesId_Enabled), 5, 0), true);
         edtServiciosId_Enabled = 0;
         AssignProp(sPrefix, false, edtServiciosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtServiciosId_Enabled), 5, 0), true);
         edtPostulacionesTipoFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesTipoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesTipoFecha_Enabled), 5, 0), true);
         edtPostulacionesEstado_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesEstado_Enabled), 5, 0), true);
         edtPostulacionesFechaAlta_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesFechaAlta_Enabled), 5, 0), true);
         edtPostulacionesSecUserId_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesSecUserId_Enabled), 5, 0), true);
         edtPostulacionesMultimediaSerial_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesMultimediaSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesMultimediaSerial_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPKN0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11KN2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA422PostulacionesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A950PostulacionesApellidoNombre = cgiGet( edtPostulacionesApellidoNombre_Internalname);
            AssignAttri(sPrefix, false, "A950PostulacionesApellidoNombre", A950PostulacionesApellidoNombre);
            A951PostulacionesMail = cgiGet( edtPostulacionesMail_Internalname);
            AssignAttri(sPrefix, false, "A951PostulacionesMail", A951PostulacionesMail);
            A952PostulacionesTelefono = cgiGet( edtPostulacionesTelefono_Internalname);
            AssignAttri(sPrefix, false, "A952PostulacionesTelefono", A952PostulacionesTelefono);
            A945PostulacionesProveedorId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesProveedorId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A945PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(A945PostulacionesProveedorId), 18, 0));
            A969PostulacionesProveedorNombre = cgiGet( edtPostulacionesProveedorNombre_Internalname);
            AssignAttri(sPrefix, false, "A969PostulacionesProveedorNombre", A969PostulacionesProveedorNombre);
            A946PostulacionesPrecio = context.localUtil.CToN( cgiGet( edtPostulacionesPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A946PostulacionesPrecio", StringUtil.LTrimStr( A946PostulacionesPrecio, 18, 2));
            A936PostulacionesDescripcion = cgiGet( edtPostulacionesDescripcion_Internalname);
            AssignAttri(sPrefix, false, "A936PostulacionesDescripcion", A936PostulacionesDescripcion);
            A937PostulacionesReqSuministros = StringUtil.StrToBool( cgiGet( chkPostulacionesReqSuministros_Internalname));
            AssignAttri(sPrefix, false, "A937PostulacionesReqSuministros", A937PostulacionesReqSuministros);
            A938PostulacionesSuministrosDescri = cgiGet( edtPostulacionesSuministrosDescri_Internalname);
            AssignAttri(sPrefix, false, "A938PostulacionesSuministrosDescri", A938PostulacionesSuministrosDescri);
            A939PostulacionesFechaCierre = context.localUtil.CToD( cgiGet( edtPostulacionesFechaCierre_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri(sPrefix, false, "A939PostulacionesFechaCierre", context.localUtil.Format(A939PostulacionesFechaCierre, "99/99/99"));
            A940PostulacionesHoraCierre = cgiGet( edtPostulacionesHoraCierre_Internalname);
            AssignAttri(sPrefix, false, "A940PostulacionesHoraCierre", A940PostulacionesHoraCierre);
            A947PostulacionesFechaTrabajo = context.localUtil.CToD( cgiGet( edtPostulacionesFechaTrabajo_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri(sPrefix, false, "A947PostulacionesFechaTrabajo", context.localUtil.Format(A947PostulacionesFechaTrabajo, "99/99/99"));
            cmbPostulacionesRgoHoraservicio.CurrentValue = cgiGet( cmbPostulacionesRgoHoraservicio_Internalname);
            A949PostulacionesRgoHoraservicio = cgiGet( cmbPostulacionesRgoHoraservicio_Internalname);
            AssignAttri(sPrefix, false, "A949PostulacionesRgoHoraservicio", A949PostulacionesRgoHoraservicio);
            A943ServiciosNombre = cgiGet( edtServiciosNombre_Internalname);
            AssignAttri(sPrefix, false, "A943ServiciosNombre", A943ServiciosNombre);
            A970PostulacionesSolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesSolicitudesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n970PostulacionesSolicitudesId = false;
            AssignAttri(sPrefix, false, "A970PostulacionesSolicitudesId", StringUtil.LTrimStr( (decimal)(A970PostulacionesSolicitudesId), 18, 0));
            A942ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtServiciosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n942ServiciosId = false;
            AssignAttri(sPrefix, false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
            A941PostulacionesTipoFecha = cgiGet( edtPostulacionesTipoFecha_Internalname);
            AssignAttri(sPrefix, false, "A941PostulacionesTipoFecha", A941PostulacionesTipoFecha);
            A424PostulacionesEstado = cgiGet( edtPostulacionesEstado_Internalname);
            AssignAttri(sPrefix, false, "A424PostulacionesEstado", A424PostulacionesEstado);
            A425PostulacionesFechaAlta = context.localUtil.CToT( cgiGet( edtPostulacionesFechaAlta_Internalname));
            AssignAttri(sPrefix, false, "A425PostulacionesFechaAlta", context.localUtil.TToC( A425PostulacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A948PostulacionesSecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A948PostulacionesSecUserId", StringUtil.LTrimStr( (decimal)(A948PostulacionesSecUserId), 18, 0));
            A961PostulacionesMultimediaSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesMultimediaSerial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A961PostulacionesMultimediaSerial", StringUtil.LTrimStr( (decimal)(A961PostulacionesMultimediaSerial), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"PostulacionesGeneral");
            A945PostulacionesProveedorId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesProveedorId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A945PostulacionesProveedorId", StringUtil.LTrimStr( (decimal)(A945PostulacionesProveedorId), 18, 0));
            forbiddenHiddens.Add("PostulacionesProveedorId", context.localUtil.Format( (decimal)(A945PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9"));
            A942ServiciosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtServiciosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n942ServiciosId = false;
            AssignAttri(sPrefix, false, "A942ServiciosId", StringUtil.LTrimStr( (decimal)(A942ServiciosId), 18, 0));
            forbiddenHiddens.Add("ServiciosId", context.localUtil.Format( (decimal)(A942ServiciosId), "ZZZZZZZZZZZZZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("postulacionesgeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E11KN2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11KN2( )
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

      protected void E12KN2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( AV12TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "proveedorview.aspx"+UrlEncode(StringUtil.LTrimStr(A945PostulacionesProveedorId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtPostulacionesProveedorNombre_Link = formatLink("proveedorview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtPostulacionesProveedorNombre_Internalname, "Link", edtPostulacionesProveedorNombre_Link, true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWServicios", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( AV12TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "serviciosview.aspx"+UrlEncode(StringUtil.LTrimStr(A942ServiciosId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtServiciosNombre_Link = formatLink("serviciosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtServiciosNombre_Internalname, "Link", edtServiciosNombre_Link, true);
         }
         edtPostulacionesId_Visible = 0;
         AssignProp(sPrefix, false, edtPostulacionesId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesId_Visible), 5, 0), true);
         edtServiciosId_Visible = 0;
         AssignProp(sPrefix, false, edtServiciosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtServiciosId_Visible), 5, 0), true);
         edtPostulacionesTipoFecha_Visible = 0;
         AssignProp(sPrefix, false, edtPostulacionesTipoFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesTipoFecha_Visible), 5, 0), true);
         edtPostulacionesEstado_Visible = 0;
         AssignProp(sPrefix, false, edtPostulacionesEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesEstado_Visible), 5, 0), true);
         edtPostulacionesFechaAlta_Visible = 0;
         AssignProp(sPrefix, false, edtPostulacionesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesFechaAlta_Visible), 5, 0), true);
         edtPostulacionesSecUserId_Visible = 0;
         AssignProp(sPrefix, false, edtPostulacionesSecUserId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesSecUserId_Visible), 5, 0), true);
         edtPostulacionesMultimediaSerial_Visible = 0;
         AssignProp(sPrefix, false, edtPostulacionesMultimediaSerial_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesMultimediaSerial_Visible), 5, 0), true);
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13KN2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "postulaciones.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A422PostulacionesId,18,0));
         CallWebObject(formatLink("postulaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14KN2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "postulaciones.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A422PostulacionesId,18,0));
         CallWebObject(formatLink("postulaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Transactionname = "Postulaciones";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A422PostulacionesId = Convert.ToInt64(getParm(obj,0));
         n422PostulacionesId = false;
         AssignAttri(sPrefix, false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
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
         PAKN2( ) ;
         WSKN2( ) ;
         WEKN2( ) ;
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
         sCtrlA422PostulacionesId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAKN2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "postulacionesgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAKN2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A422PostulacionesId = Convert.ToInt64(getParm(obj,2));
            n422PostulacionesId = false;
            AssignAttri(sPrefix, false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
         }
         wcpOA422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA422PostulacionesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A422PostulacionesId != wcpOA422PostulacionesId ) ) )
         {
            setjustcreated();
         }
         wcpOA422PostulacionesId = A422PostulacionesId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA422PostulacionesId = cgiGet( sPrefix+"A422PostulacionesId_CTRL");
         if ( StringUtil.Len( sCtrlA422PostulacionesId) > 0 )
         {
            A422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA422PostulacionesId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n422PostulacionesId = false;
            AssignAttri(sPrefix, false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
         }
         else
         {
            A422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A422PostulacionesId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n422PostulacionesId = false;
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
         PAKN2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSKN2( ) ;
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
         WSKN2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A422PostulacionesId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA422PostulacionesId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A422PostulacionesId_CTRL", StringUtil.RTrim( sCtrlA422PostulacionesId));
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
         WEKN2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932041422", true, true, false);
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
         context.AddJavascriptSource("postulacionesgeneral.js", "?2026932041422", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkPostulacionesReqSuministros.Name = "POSTULACIONESREQSUMINISTROS";
         chkPostulacionesReqSuministros.WebTags = "";
         chkPostulacionesReqSuministros.Caption = context.GetMessage( "¿Req. Suministros?", "");
         AssignProp(sPrefix, false, chkPostulacionesReqSuministros_Internalname, "TitleCaption", chkPostulacionesReqSuministros.Caption, true);
         chkPostulacionesReqSuministros.CheckedValue = "false";
         cmbPostulacionesRgoHoraservicio.Name = "POSTULACIONESRGOHORASERVICIO";
         cmbPostulacionesRgoHoraservicio.WebTags = "";
         cmbPostulacionesRgoHoraservicio.addItem("1", context.GetMessage( "Turno 1, 8:00-12:00", ""), 0);
         cmbPostulacionesRgoHoraservicio.addItem("2", context.GetMessage( "Turno 2, 12:00-16:00", ""), 0);
         cmbPostulacionesRgoHoraservicio.addItem("3", context.GetMessage( "Turno 3, 16:00-20:00", ""), 0);
         if ( cmbPostulacionesRgoHoraservicio.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtPostulacionesApellidoNombre_Internalname = sPrefix+"POSTULACIONESAPELLIDONOMBRE";
         edtPostulacionesMail_Internalname = sPrefix+"POSTULACIONESMAIL";
         edtPostulacionesTelefono_Internalname = sPrefix+"POSTULACIONESTELEFONO";
         edtPostulacionesProveedorId_Internalname = sPrefix+"POSTULACIONESPROVEEDORID";
         edtPostulacionesProveedorNombre_Internalname = sPrefix+"POSTULACIONESPROVEEDORNOMBRE";
         edtPostulacionesPrecio_Internalname = sPrefix+"POSTULACIONESPRECIO";
         edtPostulacionesDescripcion_Internalname = sPrefix+"POSTULACIONESDESCRIPCION";
         chkPostulacionesReqSuministros_Internalname = sPrefix+"POSTULACIONESREQSUMINISTROS";
         edtPostulacionesSuministrosDescri_Internalname = sPrefix+"POSTULACIONESSUMINISTROSDESCRI";
         edtPostulacionesFechaCierre_Internalname = sPrefix+"POSTULACIONESFECHACIERRE";
         edtPostulacionesHoraCierre_Internalname = sPrefix+"POSTULACIONESHORACIERRE";
         edtPostulacionesFechaTrabajo_Internalname = sPrefix+"POSTULACIONESFECHATRABAJO";
         cmbPostulacionesRgoHoraservicio_Internalname = sPrefix+"POSTULACIONESRGOHORASERVICIO";
         edtServiciosNombre_Internalname = sPrefix+"SERVICIOSNOMBRE";
         edtPostulacionesSolicitudesId_Internalname = sPrefix+"POSTULACIONESSOLICITUDESID";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtPostulacionesId_Internalname = sPrefix+"POSTULACIONESID";
         edtServiciosId_Internalname = sPrefix+"SERVICIOSID";
         edtPostulacionesTipoFecha_Internalname = sPrefix+"POSTULACIONESTIPOFECHA";
         edtPostulacionesEstado_Internalname = sPrefix+"POSTULACIONESESTADO";
         edtPostulacionesFechaAlta_Internalname = sPrefix+"POSTULACIONESFECHAALTA";
         edtPostulacionesSecUserId_Internalname = sPrefix+"POSTULACIONESSECUSERID";
         edtPostulacionesMultimediaSerial_Internalname = sPrefix+"POSTULACIONESMULTIMEDIASERIAL";
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
         chkPostulacionesReqSuministros.Caption = context.GetMessage( "¿Req. Suministros?", "");
         edtPostulacionesMultimediaSerial_Enabled = 0;
         edtPostulacionesSecUserId_Enabled = 0;
         edtPostulacionesFechaAlta_Enabled = 0;
         edtPostulacionesEstado_Enabled = 0;
         edtPostulacionesTipoFecha_Enabled = 0;
         edtServiciosId_Enabled = 0;
         edtPostulacionesId_Enabled = 0;
         edtPostulacionesMultimediaSerial_Jsonclick = "";
         edtPostulacionesMultimediaSerial_Visible = 1;
         edtPostulacionesSecUserId_Jsonclick = "";
         edtPostulacionesSecUserId_Visible = 1;
         edtPostulacionesFechaAlta_Jsonclick = "";
         edtPostulacionesFechaAlta_Visible = 1;
         edtPostulacionesEstado_Jsonclick = "";
         edtPostulacionesEstado_Visible = 1;
         edtPostulacionesTipoFecha_Jsonclick = "";
         edtPostulacionesTipoFecha_Visible = 1;
         edtServiciosId_Jsonclick = "";
         edtServiciosId_Visible = 1;
         edtPostulacionesId_Jsonclick = "";
         edtPostulacionesId_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtPostulacionesSolicitudesId_Jsonclick = "";
         edtPostulacionesSolicitudesId_Enabled = 0;
         edtServiciosNombre_Jsonclick = "";
         edtServiciosNombre_Link = "";
         edtServiciosNombre_Enabled = 0;
         cmbPostulacionesRgoHoraservicio_Jsonclick = "";
         cmbPostulacionesRgoHoraservicio.Enabled = 0;
         edtPostulacionesFechaTrabajo_Jsonclick = "";
         edtPostulacionesFechaTrabajo_Enabled = 0;
         edtPostulacionesHoraCierre_Jsonclick = "";
         edtPostulacionesHoraCierre_Enabled = 0;
         edtPostulacionesFechaCierre_Jsonclick = "";
         edtPostulacionesFechaCierre_Enabled = 0;
         edtPostulacionesSuministrosDescri_Enabled = 0;
         chkPostulacionesReqSuministros.Enabled = 0;
         edtPostulacionesDescripcion_Enabled = 0;
         edtPostulacionesPrecio_Jsonclick = "";
         edtPostulacionesPrecio_Enabled = 0;
         edtPostulacionesProveedorNombre_Jsonclick = "";
         edtPostulacionesProveedorNombre_Link = "";
         edtPostulacionesProveedorNombre_Enabled = 0;
         edtPostulacionesProveedorId_Jsonclick = "";
         edtPostulacionesProveedorId_Enabled = 0;
         edtPostulacionesTelefono_Jsonclick = "";
         edtPostulacionesTelefono_Enabled = 0;
         edtPostulacionesMail_Jsonclick = "";
         edtPostulacionesMail_Enabled = 0;
         edtPostulacionesApellidoNombre_Jsonclick = "";
         edtPostulacionesApellidoNombre_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A422PostulacionesId',fld:'POSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A937PostulacionesReqSuministros',fld:'POSTULACIONESREQSUMINISTROS',pic:'',type:'boolean'},{av:'A945PostulacionesProveedorId',fld:'POSTULACIONESPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A942ServiciosId',fld:'SERVICIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13KN2',iparms:[{av:'A422PostulacionesId',fld:'POSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E14KN2',iparms:[{av:'A422PostulacionesId',fld:'POSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORID","{handler:'Valid_Postulacionesproveedorid',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESPROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_POSTULACIONESID","{handler:'Valid_Postulacionesid',iparms:[]");
         setEventMetadata("VALID_POSTULACIONESID",",oparms:[]}");
         setEventMetadata("VALID_SERVICIOSID","{handler:'Valid_Serviciosid',iparms:[]");
         setEventMetadata("VALID_SERVICIOSID",",oparms:[]}");
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
         H00KN3_A970PostulacionesSolicitudesId = new long[1] ;
         H00KN3_n970PostulacionesSolicitudesId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         TempTags = "";
         A950PostulacionesApellidoNombre = "";
         A951PostulacionesMail = "";
         gxphoneLink = "";
         A952PostulacionesTelefono = "";
         A969PostulacionesProveedorNombre = "";
         ClassString = "";
         StyleString = "";
         A936PostulacionesDescripcion = "";
         A938PostulacionesSuministrosDescri = "";
         A939PostulacionesFechaCierre = DateTime.MinValue;
         A940PostulacionesHoraCierre = "";
         A947PostulacionesFechaTrabajo = DateTime.MinValue;
         A949PostulacionesRgoHoraservicio = "";
         A943ServiciosNombre = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A941PostulacionesTipoFecha = "";
         A424PostulacionesEstado = "";
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00KN5_A422PostulacionesId = new long[1] ;
         H00KN5_n422PostulacionesId = new bool[] {false} ;
         H00KN5_A961PostulacionesMultimediaSerial = new short[1] ;
         H00KN5_A948PostulacionesSecUserId = new long[1] ;
         H00KN5_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00KN5_A424PostulacionesEstado = new string[] {""} ;
         H00KN5_A941PostulacionesTipoFecha = new string[] {""} ;
         H00KN5_A942ServiciosId = new long[1] ;
         H00KN5_n942ServiciosId = new bool[] {false} ;
         H00KN5_A943ServiciosNombre = new string[] {""} ;
         H00KN5_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         H00KN5_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         H00KN5_A940PostulacionesHoraCierre = new string[] {""} ;
         H00KN5_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         H00KN5_A938PostulacionesSuministrosDescri = new string[] {""} ;
         H00KN5_A937PostulacionesReqSuministros = new bool[] {false} ;
         H00KN5_A936PostulacionesDescripcion = new string[] {""} ;
         H00KN5_A946PostulacionesPrecio = new decimal[1] ;
         H00KN5_A969PostulacionesProveedorNombre = new string[] {""} ;
         H00KN5_A945PostulacionesProveedorId = new long[1] ;
         H00KN5_A952PostulacionesTelefono = new string[] {""} ;
         H00KN5_A951PostulacionesMail = new string[] {""} ;
         H00KN5_A950PostulacionesApellidoNombre = new string[] {""} ;
         H00KN5_A970PostulacionesSolicitudesId = new long[1] ;
         H00KN5_n970PostulacionesSolicitudesId = new bool[] {false} ;
         H00KN7_A970PostulacionesSolicitudesId = new long[1] ;
         H00KN7_n970PostulacionesSolicitudesId = new bool[] {false} ;
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA422PostulacionesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.postulacionesgeneral__default(),
            new Object[][] {
                new Object[] {
               H00KN3_A970PostulacionesSolicitudesId, H00KN3_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               H00KN5_A422PostulacionesId, H00KN5_A961PostulacionesMultimediaSerial, H00KN5_A948PostulacionesSecUserId, H00KN5_A425PostulacionesFechaAlta, H00KN5_A424PostulacionesEstado, H00KN5_A941PostulacionesTipoFecha, H00KN5_A942ServiciosId, H00KN5_n942ServiciosId, H00KN5_A943ServiciosNombre, H00KN5_A949PostulacionesRgoHoraservicio,
               H00KN5_A947PostulacionesFechaTrabajo, H00KN5_A940PostulacionesHoraCierre, H00KN5_A939PostulacionesFechaCierre, H00KN5_A938PostulacionesSuministrosDescri, H00KN5_A937PostulacionesReqSuministros, H00KN5_A936PostulacionesDescripcion, H00KN5_A946PostulacionesPrecio, H00KN5_A969PostulacionesProveedorNombre, H00KN5_A945PostulacionesProveedorId, H00KN5_A952PostulacionesTelefono,
               H00KN5_A951PostulacionesMail, H00KN5_A950PostulacionesApellidoNombre, H00KN5_A970PostulacionesSolicitudesId, H00KN5_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               H00KN7_A970PostulacionesSolicitudesId, H00KN7_n970PostulacionesSolicitudesId
               }
            }
         );
         AV13Pgmname = "PostulacionesGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "PostulacionesGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A961PostulacionesMultimediaSerial ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtPostulacionesApellidoNombre_Enabled ;
      private int edtPostulacionesMail_Enabled ;
      private int edtPostulacionesTelefono_Enabled ;
      private int edtPostulacionesProveedorId_Enabled ;
      private int edtPostulacionesProveedorNombre_Enabled ;
      private int edtPostulacionesPrecio_Enabled ;
      private int edtPostulacionesDescripcion_Enabled ;
      private int edtPostulacionesSuministrosDescri_Enabled ;
      private int edtPostulacionesFechaCierre_Enabled ;
      private int edtPostulacionesHoraCierre_Enabled ;
      private int edtPostulacionesFechaTrabajo_Enabled ;
      private int edtServiciosNombre_Enabled ;
      private int edtPostulacionesSolicitudesId_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtPostulacionesId_Visible ;
      private int edtServiciosId_Visible ;
      private int edtPostulacionesTipoFecha_Visible ;
      private int edtPostulacionesEstado_Visible ;
      private int edtPostulacionesFechaAlta_Visible ;
      private int edtPostulacionesSecUserId_Visible ;
      private int edtPostulacionesMultimediaSerial_Visible ;
      private int edtPostulacionesId_Enabled ;
      private int edtServiciosId_Enabled ;
      private int edtPostulacionesTipoFecha_Enabled ;
      private int edtPostulacionesEstado_Enabled ;
      private int edtPostulacionesFechaAlta_Enabled ;
      private int edtPostulacionesSecUserId_Enabled ;
      private int edtPostulacionesMultimediaSerial_Enabled ;
      private int idxLst ;
      private long A422PostulacionesId ;
      private long wcpOA422PostulacionesId ;
      private long A970PostulacionesSolicitudesId ;
      private long A945PostulacionesProveedorId ;
      private long A942ServiciosId ;
      private long A948PostulacionesSecUserId ;
      private decimal A946PostulacionesPrecio ;
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
      private string edtPostulacionesApellidoNombre_Internalname ;
      private string TempTags ;
      private string A950PostulacionesApellidoNombre ;
      private string edtPostulacionesApellidoNombre_Jsonclick ;
      private string edtPostulacionesMail_Internalname ;
      private string edtPostulacionesMail_Jsonclick ;
      private string edtPostulacionesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A952PostulacionesTelefono ;
      private string edtPostulacionesTelefono_Jsonclick ;
      private string edtPostulacionesProveedorId_Internalname ;
      private string edtPostulacionesProveedorId_Jsonclick ;
      private string edtPostulacionesProveedorNombre_Internalname ;
      private string A969PostulacionesProveedorNombre ;
      private string edtPostulacionesProveedorNombre_Link ;
      private string edtPostulacionesProveedorNombre_Jsonclick ;
      private string edtPostulacionesPrecio_Internalname ;
      private string edtPostulacionesPrecio_Jsonclick ;
      private string edtPostulacionesDescripcion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string A936PostulacionesDescripcion ;
      private string chkPostulacionesReqSuministros_Internalname ;
      private string edtPostulacionesSuministrosDescri_Internalname ;
      private string A938PostulacionesSuministrosDescri ;
      private string edtPostulacionesFechaCierre_Internalname ;
      private string edtPostulacionesFechaCierre_Jsonclick ;
      private string edtPostulacionesHoraCierre_Internalname ;
      private string edtPostulacionesHoraCierre_Jsonclick ;
      private string edtPostulacionesFechaTrabajo_Internalname ;
      private string edtPostulacionesFechaTrabajo_Jsonclick ;
      private string cmbPostulacionesRgoHoraservicio_Internalname ;
      private string A949PostulacionesRgoHoraservicio ;
      private string cmbPostulacionesRgoHoraservicio_Jsonclick ;
      private string edtServiciosNombre_Internalname ;
      private string A943ServiciosNombre ;
      private string edtServiciosNombre_Link ;
      private string edtServiciosNombre_Jsonclick ;
      private string edtPostulacionesSolicitudesId_Internalname ;
      private string edtPostulacionesSolicitudesId_Jsonclick ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtPostulacionesId_Internalname ;
      private string edtPostulacionesId_Jsonclick ;
      private string edtServiciosId_Internalname ;
      private string edtServiciosId_Jsonclick ;
      private string edtPostulacionesTipoFecha_Internalname ;
      private string edtPostulacionesTipoFecha_Jsonclick ;
      private string edtPostulacionesEstado_Internalname ;
      private string A424PostulacionesEstado ;
      private string edtPostulacionesEstado_Jsonclick ;
      private string edtPostulacionesFechaAlta_Internalname ;
      private string edtPostulacionesFechaAlta_Jsonclick ;
      private string edtPostulacionesSecUserId_Internalname ;
      private string edtPostulacionesSecUserId_Jsonclick ;
      private string edtPostulacionesMultimediaSerial_Internalname ;
      private string edtPostulacionesMultimediaSerial_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string hsh ;
      private string sCtrlA422PostulacionesId ;
      private DateTime A425PostulacionesFechaAlta ;
      private DateTime A939PostulacionesFechaCierre ;
      private DateTime A947PostulacionesFechaTrabajo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n422PostulacionesId ;
      private bool n970PostulacionesSolicitudesId ;
      private bool wbLoad ;
      private bool A937PostulacionesReqSuministros ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n942ServiciosId ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A951PostulacionesMail ;
      private string A940PostulacionesHoraCierre ;
      private string A941PostulacionesTipoFecha ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkPostulacionesReqSuministros ;
      private GXCombobox cmbPostulacionesRgoHoraservicio ;
      private IDataStoreProvider pr_default ;
      private long[] H00KN3_A970PostulacionesSolicitudesId ;
      private bool[] H00KN3_n970PostulacionesSolicitudesId ;
      private long[] H00KN5_A422PostulacionesId ;
      private bool[] H00KN5_n422PostulacionesId ;
      private short[] H00KN5_A961PostulacionesMultimediaSerial ;
      private long[] H00KN5_A948PostulacionesSecUserId ;
      private DateTime[] H00KN5_A425PostulacionesFechaAlta ;
      private string[] H00KN5_A424PostulacionesEstado ;
      private string[] H00KN5_A941PostulacionesTipoFecha ;
      private long[] H00KN5_A942ServiciosId ;
      private bool[] H00KN5_n942ServiciosId ;
      private string[] H00KN5_A943ServiciosNombre ;
      private string[] H00KN5_A949PostulacionesRgoHoraservicio ;
      private DateTime[] H00KN5_A947PostulacionesFechaTrabajo ;
      private string[] H00KN5_A940PostulacionesHoraCierre ;
      private DateTime[] H00KN5_A939PostulacionesFechaCierre ;
      private string[] H00KN5_A938PostulacionesSuministrosDescri ;
      private bool[] H00KN5_A937PostulacionesReqSuministros ;
      private string[] H00KN5_A936PostulacionesDescripcion ;
      private decimal[] H00KN5_A946PostulacionesPrecio ;
      private string[] H00KN5_A969PostulacionesProveedorNombre ;
      private long[] H00KN5_A945PostulacionesProveedorId ;
      private string[] H00KN5_A952PostulacionesTelefono ;
      private string[] H00KN5_A951PostulacionesMail ;
      private string[] H00KN5_A950PostulacionesApellidoNombre ;
      private long[] H00KN5_A970PostulacionesSolicitudesId ;
      private bool[] H00KN5_n970PostulacionesSolicitudesId ;
      private long[] H00KN7_A970PostulacionesSolicitudesId ;
      private bool[] H00KN7_n970PostulacionesSolicitudesId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class postulacionesgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00KN3;
          prmH00KN3 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
          };
          Object[] prmH00KN5;
          prmH00KN5 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
          };
          Object[] prmH00KN7;
          prmH00KN7 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("H00KN3", "SELECT COALESCE( T1.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KN3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00KN5", "SELECT T1.[PostulacionesId], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesEstado], T1.[PostulacionesTipoFecha], T1.[ServiciosId], T2.[ServiciosNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4 WHERE T1.[PostulacionesId] = @PostulacionesId ORDER BY T1.[PostulacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KN5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00KN7", "SELECT COALESCE( T1.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KN7,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((string[]) buf[9])[0] = rslt.getString(9, 5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 250);
                ((bool[]) buf[14])[0] = rslt.getBool(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 2000);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 80);
                ((long[]) buf[18])[0] = rslt.getLong(18);
                ((string[]) buf[19])[0] = rslt.getString(19, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 80);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
