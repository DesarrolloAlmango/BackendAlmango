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
   public class profesionalesprofesionalesdatos : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public profesionalesprofesionalesdatos( )
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

      public profesionalesprofesionalesdatos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId )
      {
         this.A120ProfesionalesId = aP0_ProfesionalesId;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ProfesionalesId");
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
                  A120ProfesionalesId = GetPar( "ProfesionalesId");
                  AssignAttri(sPrefix, false, "A120ProfesionalesId", A120ProfesionalesId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)A120ProfesionalesId});
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
                  gxfirstwebparm = GetFirstPar( "ProfesionalesId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProfesionalesId");
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
            PA6K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ProfesionalesProfesionalesDatos";
               WS6K2( ) ;
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
            context.SendWebValue( context.GetMessage( "Profesionales Profesionales Datos", "")) ;
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
         context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
         context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
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
            GXEncryptionTmp = "profesionalesprofesionalesdatos.aspx"+UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profesionalesprofesionalesdatos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA120ProfesionalesId", StringUtil.RTrim( wcpOA120ProfesionalesId));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFESIONALESFEEDBACK", StringUtil.LTrim( StringUtil.NToC( A270ProfesionalesFeedback, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFESIONALESFEEDBACK_Enabled", StringUtil.BoolToStr( Profesionalesfeedback_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFESIONALESFEEDBACK_Captionclass", StringUtil.RTrim( Profesionalesfeedback_Captionclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFESIONALESFEEDBACK_Captionstyle", StringUtil.RTrim( Profesionalesfeedback_Captionstyle));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFESIONALESFEEDBACK_Captionposition", StringUtil.RTrim( Profesionalesfeedback_Captionposition));
      }

      protected void RenderHtmlCloseForm6K2( )
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
         return "ProfesionalesProfesionalesDatos" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Profesionales Profesionales Datos", "") ;
      }

      protected void WB6K0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "profesionalesprofesionalesdatos.aspx");
               context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
               context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesId_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId), StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtProfesionalesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesId_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NoIdentidad", "start", true, "", "HLP_ProfesionalesProfesionalesDatos.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre), StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesPrimerNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesPrimerNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesSegundoNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesSegundoNombre_Internalname, context.GetMessage( "Segundo Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesSegundoNombre_Internalname, StringUtil.RTrim( A191ProfesionalesSegundoNombre), StringUtil.RTrim( context.localUtil.Format( A191ProfesionalesSegundoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesSegundoNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesSegundoNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesProfesionalesDatos.htm");
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
            GxWebStd.gx_label_element( context, edtProfesionalesApellidoPrimero_Internalname, context.GetMessage( "Primer Apellido ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero), StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoPrimero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesApellidoPrimero_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesApellidoSegundo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesApellidoSegundo_Internalname, context.GetMessage( "Segundo Apellido ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoSegundo_Internalname, StringUtil.RTrim( A192ProfesionalesApellidoSegundo), StringUtil.RTrim( context.localUtil.Format( A192ProfesionalesApellidoSegundo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoSegundo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesApellidoSegundo_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProfesionalesPhoto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "AttributeFL";
            StyleString = "";
            A169ProfesionalesPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProfesionalesPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.PathToRelativeUrl( A169ProfesionalesPhoto));
            GxWebStd.gx_bitmap( context, imgProfesionalesPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A169ProfesionalesPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesTelefono_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesTelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesTelefono_Internalname, StringUtil.RTrim( A170ProfesionalesTelefono), StringUtil.RTrim( context.localUtil.Format( A170ProfesionalesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProfesionalesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesEmail_Internalname, A193ProfesionalesEmail, StringUtil.RTrim( context.localUtil.Format( A193ProfesionalesEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A193ProfesionalesEmail, "", "", context.GetMessage( "email@correo.com", ""), edtProfesionalesEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesDireccion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtProfesionalesDireccion_Internalname, A198ProfesionalesDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A198ProfesionalesDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtProfesionalesDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosGenericosId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEstadosGenericosId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtEstadosGenericosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9") : context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosGenericosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosGenericosId_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesFeedBackCant_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesFeedBackCant_Internalname, context.GetMessage( "FeedBack", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesFeedBackCant_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A268ProfesionalesFeedBackCant), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfesionalesFeedBackCant_Enabled!=0) ? context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFeedBackCant_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesFeedBackCant_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Profesionalesfeedback_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucProfesionalesfeedback.SetProperty("Attribute", ProfesionalesFeedback);
            ucProfesionalesfeedback.SetProperty("CaptionClass", Profesionalesfeedback_Captionclass);
            ucProfesionalesfeedback.SetProperty("CaptionStyle", Profesionalesfeedback_Captionstyle);
            ucProfesionalesfeedback.SetProperty("CaptionPosition", Profesionalesfeedback_Captionposition);
            ucProfesionalesfeedback.Render(context, "rating", Profesionalesfeedback_Internalname, sPrefix+"PROFESIONALESFEEDBACKContainer");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesProfesionalesDatos.htm");
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
            GxWebStd.gx_single_line_edit( context, edtProfesionalesAutoEnumerar_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A196ProfesionalesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A196ProfesionalesAutoEnumerar), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesAutoEnumerar_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesAutoEnumerar_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProfesionalesAutoEnuZona_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A197ProfesionalesAutoEnuZona), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesAutoEnuZona_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesAutoEnuZona_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo), StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosTipo_Jsonclick, 0, "Attribute", "", "", "", "", edtEstadosTipo_Visible, 0, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtProfesionalesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtProfesionalesFechaAlta_Internalname, context.localUtil.TToC( A199ProfesionalesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A199ProfesionalesFechaAlta, "99/99/99 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFechaAlta_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesFechaAlta_Visible, 0, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_bitmap( context, edtProfesionalesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtProfesionalesFechaAlta_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ProfesionalesProfesionalesDatos.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtProfesionalesFechaActualizado_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtProfesionalesFechaActualizado_Internalname, context.localUtil.TToC( A200ProfesionalesFechaActualizado, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A200ProfesionalesFechaActualizado, "99/99/99 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFechaActualizado_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesFechaActualizado_Visible, 0, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_bitmap( context, edtProfesionalesFechaActualizado_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtProfesionalesFechaActualizado_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ProfesionalesProfesionalesDatos.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProfesionalesVerDatPerSol_Internalname, StringUtil.RTrim( A267ProfesionalesVerDatPerSol), StringUtil.RTrim( context.localUtil.Format( A267ProfesionalesVerDatPerSol, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesVerDatPerSol_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesVerDatPerSol_Visible, 0, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProfesionalesFeedBackProm_Internalname, StringUtil.LTrim( StringUtil.NToC( A269ProfesionalesFeedBackProm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( A269ProfesionalesFeedBackProm, "ZZZZZZZZZZZZZZ9.99")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFeedBackProm_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesFeedBackProm_Visible, 0, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesProfesionalesDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6K2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Profesionales Profesionales Datos", ""), 0) ;
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
               STRUP6K0( ) ;
            }
         }
      }

      protected void WS6K2( )
      {
         START6K2( ) ;
         EVT6K2( ) ;
      }

      protected void EVT6K2( )
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
                                 STRUP6K0( ) ;
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
                                 STRUP6K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E116K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E126K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E136K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E146K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6K0( ) ;
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
                                 STRUP6K0( ) ;
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

      protected void WE6K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6K2( ) ;
            }
         }
      }

      protected void PA6K2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "profesionalesprofesionalesdatos.aspx")), "profesionalesprofesionalesdatos.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "profesionalesprofesionalesdatos.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ProfesionalesId");
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ProfesionalesProfesionalesDatos";
      }

      protected void RF6K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H006K2 */
            pr_default.execute(0, new Object[] {A120ProfesionalesId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A267ProfesionalesVerDatPerSol = H006K2_A267ProfesionalesVerDatPerSol[0];
               AssignAttri(sPrefix, false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
               A200ProfesionalesFechaActualizado = H006K2_A200ProfesionalesFechaActualizado[0];
               AssignAttri(sPrefix, false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A199ProfesionalesFechaAlta = H006K2_A199ProfesionalesFechaAlta[0];
               AssignAttri(sPrefix, false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A107EstadosTipo = H006K2_A107EstadosTipo[0];
               AssignAttri(sPrefix, false, "A107EstadosTipo", A107EstadosTipo);
               A197ProfesionalesAutoEnuZona = H006K2_A197ProfesionalesAutoEnuZona[0];
               AssignAttri(sPrefix, false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
               A196ProfesionalesAutoEnumerar = H006K2_A196ProfesionalesAutoEnumerar[0];
               AssignAttri(sPrefix, false, "A196ProfesionalesAutoEnumerar", StringUtil.LTrimStr( (decimal)(A196ProfesionalesAutoEnumerar), 4, 0));
               A108EstadosGenericosId = H006K2_A108EstadosGenericosId[0];
               AssignAttri(sPrefix, false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
               A198ProfesionalesDireccion = H006K2_A198ProfesionalesDireccion[0];
               AssignAttri(sPrefix, false, "A198ProfesionalesDireccion", A198ProfesionalesDireccion);
               A193ProfesionalesEmail = H006K2_A193ProfesionalesEmail[0];
               n193ProfesionalesEmail = H006K2_n193ProfesionalesEmail[0];
               AssignAttri(sPrefix, false, "A193ProfesionalesEmail", A193ProfesionalesEmail);
               A170ProfesionalesTelefono = H006K2_A170ProfesionalesTelefono[0];
               AssignAttri(sPrefix, false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
               A40000ProfesionalesPhoto_GXI = H006K2_A40000ProfesionalesPhoto_GXI[0];
               AssignProp(sPrefix, false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
               AssignProp(sPrefix, false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               A192ProfesionalesApellidoSegundo = H006K2_A192ProfesionalesApellidoSegundo[0];
               AssignAttri(sPrefix, false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
               A167ProfesionalesApellidoPrimero = H006K2_A167ProfesionalesApellidoPrimero[0];
               AssignAttri(sPrefix, false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
               A191ProfesionalesSegundoNombre = H006K2_A191ProfesionalesSegundoNombre[0];
               AssignAttri(sPrefix, false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
               A166ProfesionalesPrimerNombre = H006K2_A166ProfesionalesPrimerNombre[0];
               AssignAttri(sPrefix, false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
               A268ProfesionalesFeedBackCant = H006K2_A268ProfesionalesFeedBackCant[0];
               AssignAttri(sPrefix, false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
               A269ProfesionalesFeedBackProm = H006K2_A269ProfesionalesFeedBackProm[0];
               AssignAttri(sPrefix, false, "A269ProfesionalesFeedBackProm", StringUtil.LTrimStr( A269ProfesionalesFeedBackProm, 18, 2));
               A169ProfesionalesPhoto = H006K2_A169ProfesionalesPhoto[0];
               AssignAttri(sPrefix, false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
               AssignProp(sPrefix, false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
               AssignProp(sPrefix, false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               if ( A268ProfesionalesFeedBackCant > 0 )
               {
                  A270ProfesionalesFeedback = (decimal)(A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant));
                  AssignAttri(sPrefix, false, "A270ProfesionalesFeedback", StringUtil.LTrimStr( A270ProfesionalesFeedback, 10, 2));
               }
               else
               {
                  A270ProfesionalesFeedback = 0;
                  AssignAttri(sPrefix, false, "A270ProfesionalesFeedback", StringUtil.LTrimStr( A270ProfesionalesFeedback, 10, 2));
               }
               /* Execute user event: Load */
               E126K2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB6K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6K2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ProfesionalesProfesionalesDatos";
         edtProfesionalesId_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         edtProfesionalesPrimerNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesPrimerNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0), true);
         edtProfesionalesSegundoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesSegundoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0), true);
         edtProfesionalesApellidoPrimero_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesApellidoPrimero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0), true);
         edtProfesionalesApellidoSegundo_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesApellidoSegundo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0), true);
         imgProfesionalesPhoto_Enabled = 0;
         AssignProp(sPrefix, false, imgProfesionalesPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProfesionalesPhoto_Enabled), 5, 0), true);
         edtProfesionalesTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesTelefono_Enabled), 5, 0), true);
         edtProfesionalesEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesEmail_Enabled), 5, 0), true);
         edtProfesionalesDireccion_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesDireccion_Enabled), 5, 0), true);
         edtEstadosGenericosId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), true);
         edtProfesionalesFeedBackCant_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesFeedBackCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackCant_Enabled), 5, 0), true);
         edtProfesionalesAutoEnumerar_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesAutoEnumerar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesAutoEnumerar_Enabled), 5, 0), true);
         edtProfesionalesAutoEnuZona_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesAutoEnuZona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesAutoEnuZona_Enabled), 5, 0), true);
         edtEstadosTipo_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         edtProfesionalesFechaAlta_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaAlta_Enabled), 5, 0), true);
         edtProfesionalesFechaActualizado_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesFechaActualizado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaActualizado_Enabled), 5, 0), true);
         edtProfesionalesVerDatPerSol_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesVerDatPerSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesVerDatPerSol_Enabled), 5, 0), true);
         edtProfesionalesFeedBackProm_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesFeedBackProm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackProm_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116K2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            A270ProfesionalesFeedback = context.localUtil.CToN( cgiGet( sPrefix+"PROFESIONALESFEEDBACK"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            wcpOA120ProfesionalesId = cgiGet( sPrefix+"wcpOA120ProfesionalesId");
            Profesionalesfeedback_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"PROFESIONALESFEEDBACK_Enabled"));
            Profesionalesfeedback_Captionclass = cgiGet( sPrefix+"PROFESIONALESFEEDBACK_Captionclass");
            Profesionalesfeedback_Captionstyle = cgiGet( sPrefix+"PROFESIONALESFEEDBACK_Captionstyle");
            Profesionalesfeedback_Captionposition = cgiGet( sPrefix+"PROFESIONALESFEEDBACK_Captionposition");
            /* Read variables values. */
            A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
            AssignAttri(sPrefix, false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
            AssignAttri(sPrefix, false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
            A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
            AssignAttri(sPrefix, false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
            AssignAttri(sPrefix, false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
            A169ProfesionalesPhoto = cgiGet( imgProfesionalesPhoto_Internalname);
            AssignAttri(sPrefix, false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
            A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
            AssignAttri(sPrefix, false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
            A193ProfesionalesEmail = cgiGet( edtProfesionalesEmail_Internalname);
            n193ProfesionalesEmail = false;
            AssignAttri(sPrefix, false, "A193ProfesionalesEmail", A193ProfesionalesEmail);
            A198ProfesionalesDireccion = cgiGet( edtProfesionalesDireccion_Internalname);
            AssignAttri(sPrefix, false, "A198ProfesionalesDireccion", A198ProfesionalesDireccion);
            A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            A268ProfesionalesFeedBackCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
            A196ProfesionalesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesAutoEnumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A196ProfesionalesAutoEnumerar", StringUtil.LTrimStr( (decimal)(A196ProfesionalesAutoEnumerar), 4, 0));
            A197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesAutoEnuZona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
            AssignAttri(sPrefix, false, "A107EstadosTipo", A107EstadosTipo);
            A199ProfesionalesFechaAlta = context.localUtil.CToT( cgiGet( edtProfesionalesFechaAlta_Internalname));
            AssignAttri(sPrefix, false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A200ProfesionalesFechaActualizado = context.localUtil.CToT( cgiGet( edtProfesionalesFechaActualizado_Internalname));
            AssignAttri(sPrefix, false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A267ProfesionalesVerDatPerSol = cgiGet( edtProfesionalesVerDatPerSol_Internalname);
            AssignAttri(sPrefix, false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
            A269ProfesionalesFeedBackProm = context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackProm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A269ProfesionalesFeedBackProm", StringUtil.LTrimStr( A269ProfesionalesFeedBackProm, 18, 2));
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
         E116K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E116K2( )
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

      protected void E126K2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtProfesionalesAutoEnumerar_Visible = 0;
         AssignProp(sPrefix, false, edtProfesionalesAutoEnumerar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesAutoEnumerar_Visible), 5, 0), true);
         edtProfesionalesAutoEnuZona_Visible = 0;
         AssignProp(sPrefix, false, edtProfesionalesAutoEnuZona_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesAutoEnuZona_Visible), 5, 0), true);
         edtEstadosTipo_Visible = 0;
         AssignProp(sPrefix, false, edtEstadosTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Visible), 5, 0), true);
         edtProfesionalesFechaAlta_Visible = 0;
         AssignProp(sPrefix, false, edtProfesionalesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaAlta_Visible), 5, 0), true);
         edtProfesionalesFechaActualizado_Visible = 0;
         AssignProp(sPrefix, false, edtProfesionalesFechaActualizado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaActualizado_Visible), 5, 0), true);
         edtProfesionalesVerDatPerSol_Visible = 0;
         AssignProp(sPrefix, false, edtProfesionalesVerDatPerSol_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesVerDatPerSol_Visible), 5, 0), true);
         edtProfesionalesFeedBackProm_Visible = 0;
         AssignProp(sPrefix, false, edtProfesionalesFeedBackProm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackProm_Visible), 5, 0), true);
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyobjectname(context ).execute(  "ProfesionalesDatos", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyobjectname(context ).execute(  "ProfesionalesDatos", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E136K2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionalesdatos.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
         CallWebObject(formatLink("profesionalesdatos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E146K2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionalesdatos.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
         CallWebObject(formatLink("profesionalesdatos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Transactionname = "ProfesionalesDatos";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A120ProfesionalesId = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "A120ProfesionalesId", A120ProfesionalesId);
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
         PA6K2( ) ;
         WS6K2( ) ;
         WE6K2( ) ;
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
         sCtrlA120ProfesionalesId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA6K2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "profesionalesprofesionalesdatos", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6K2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A120ProfesionalesId = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "A120ProfesionalesId", A120ProfesionalesId);
         }
         wcpOA120ProfesionalesId = cgiGet( sPrefix+"wcpOA120ProfesionalesId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(A120ProfesionalesId, wcpOA120ProfesionalesId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOA120ProfesionalesId = A120ProfesionalesId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA120ProfesionalesId = cgiGet( sPrefix+"A120ProfesionalesId_CTRL");
         if ( StringUtil.Len( sCtrlA120ProfesionalesId) > 0 )
         {
            A120ProfesionalesId = cgiGet( sCtrlA120ProfesionalesId);
            AssignAttri(sPrefix, false, "A120ProfesionalesId", A120ProfesionalesId);
         }
         else
         {
            A120ProfesionalesId = cgiGet( sPrefix+"A120ProfesionalesId_PARM");
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
         PA6K2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6K2( ) ;
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
         WS6K2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A120ProfesionalesId_PARM", StringUtil.RTrim( A120ProfesionalesId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA120ProfesionalesId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A120ProfesionalesId_CTRL", StringUtil.RTrim( sCtrlA120ProfesionalesId));
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
         WE6K2( ) ;
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
         AddStyleSheetFile("Rating/rating.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021111597", true, true, false);
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
         context.AddJavascriptSource("profesionalesprofesionalesdatos.js", "?202673021111597", false, true, false);
         context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
         context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO";
         imgProfesionalesPhoto_Internalname = sPrefix+"PROFESIONALESPHOTO";
         edtProfesionalesTelefono_Internalname = sPrefix+"PROFESIONALESTELEFONO";
         edtProfesionalesEmail_Internalname = sPrefix+"PROFESIONALESEMAIL";
         edtProfesionalesDireccion_Internalname = sPrefix+"PROFESIONALESDIRECCION";
         edtEstadosGenericosId_Internalname = sPrefix+"ESTADOSGENERICOSID";
         edtProfesionalesFeedBackCant_Internalname = sPrefix+"PROFESIONALESFEEDBACKCANT";
         Profesionalesfeedback_Internalname = sPrefix+"PROFESIONALESFEEDBACK";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtProfesionalesAutoEnumerar_Internalname = sPrefix+"PROFESIONALESAUTOENUMERAR";
         edtProfesionalesAutoEnuZona_Internalname = sPrefix+"PROFESIONALESAUTOENUZONA";
         edtEstadosTipo_Internalname = sPrefix+"ESTADOSTIPO";
         edtProfesionalesFechaAlta_Internalname = sPrefix+"PROFESIONALESFECHAALTA";
         edtProfesionalesFechaActualizado_Internalname = sPrefix+"PROFESIONALESFECHAACTUALIZADO";
         edtProfesionalesVerDatPerSol_Internalname = sPrefix+"PROFESIONALESVERDATPERSOL";
         edtProfesionalesFeedBackProm_Internalname = sPrefix+"PROFESIONALESFEEDBACKPROM";
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
         edtProfesionalesFeedBackProm_Enabled = 0;
         edtProfesionalesVerDatPerSol_Enabled = 0;
         edtProfesionalesFechaActualizado_Enabled = 0;
         edtProfesionalesFechaAlta_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         edtProfesionalesAutoEnuZona_Enabled = 0;
         edtProfesionalesAutoEnumerar_Enabled = 0;
         imgProfesionalesPhoto_Enabled = 0;
         edtProfesionalesFeedBackProm_Jsonclick = "";
         edtProfesionalesFeedBackProm_Visible = 1;
         edtProfesionalesVerDatPerSol_Jsonclick = "";
         edtProfesionalesVerDatPerSol_Visible = 1;
         edtProfesionalesFechaActualizado_Jsonclick = "";
         edtProfesionalesFechaActualizado_Visible = 1;
         edtProfesionalesFechaAlta_Jsonclick = "";
         edtProfesionalesFechaAlta_Visible = 1;
         edtEstadosTipo_Jsonclick = "";
         edtEstadosTipo_Visible = 1;
         edtProfesionalesAutoEnuZona_Jsonclick = "";
         edtProfesionalesAutoEnuZona_Visible = 1;
         edtProfesionalesAutoEnumerar_Jsonclick = "";
         edtProfesionalesAutoEnumerar_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         Profesionalesfeedback_Enabled = Convert.ToBoolean( 0);
         edtProfesionalesFeedBackCant_Jsonclick = "";
         edtProfesionalesFeedBackCant_Enabled = 0;
         edtEstadosGenericosId_Jsonclick = "";
         edtEstadosGenericosId_Enabled = 0;
         edtProfesionalesDireccion_Enabled = 0;
         edtProfesionalesEmail_Jsonclick = "";
         edtProfesionalesEmail_Enabled = 0;
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Jsonclick = "";
         edtProfesionalesId_Enabled = 0;
         Profesionalesfeedback_Captionposition = "Left";
         Profesionalesfeedback_Captionstyle = "";
         Profesionalesfeedback_Captionclass = "col-sm-3 AttributeFLLabel";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E136K2',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E146K2',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKCANT","{handler:'Valid_Profesionalesfeedbackcant',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKCANT",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKPROM","{handler:'Valid_Profesionalesfeedbackprom',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKPROM",",oparms:[]}");
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
         wcpOA120ProfesionalesId = "";
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
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         ClassString = "";
         StyleString = "";
         A169ProfesionalesPhoto = "";
         A40000ProfesionalesPhoto_GXI = "";
         sImgUrl = "";
         gxphoneLink = "";
         A170ProfesionalesTelefono = "";
         A193ProfesionalesEmail = "";
         A198ProfesionalesDireccion = "";
         ucProfesionalesfeedback = new GXUserControl();
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A107EstadosTipo = "";
         A199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         A267ProfesionalesVerDatPerSol = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H006K2_A120ProfesionalesId = new string[] {""} ;
         H006K2_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         H006K2_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         H006K2_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H006K2_A107EstadosTipo = new string[] {""} ;
         H006K2_A197ProfesionalesAutoEnuZona = new short[1] ;
         H006K2_A196ProfesionalesAutoEnumerar = new short[1] ;
         H006K2_A108EstadosGenericosId = new int[1] ;
         H006K2_A198ProfesionalesDireccion = new string[] {""} ;
         H006K2_A193ProfesionalesEmail = new string[] {""} ;
         H006K2_n193ProfesionalesEmail = new bool[] {false} ;
         H006K2_A170ProfesionalesTelefono = new string[] {""} ;
         H006K2_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         H006K2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H006K2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H006K2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H006K2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H006K2_A268ProfesionalesFeedBackCant = new long[1] ;
         H006K2_A269ProfesionalesFeedBackProm = new decimal[1] ;
         H006K2_A169ProfesionalesPhoto = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesprofesionalesdatos__default(),
            new Object[][] {
                new Object[] {
               H006K2_A120ProfesionalesId, H006K2_A267ProfesionalesVerDatPerSol, H006K2_A200ProfesionalesFechaActualizado, H006K2_A199ProfesionalesFechaAlta, H006K2_A107EstadosTipo, H006K2_A197ProfesionalesAutoEnuZona, H006K2_A196ProfesionalesAutoEnumerar, H006K2_A108EstadosGenericosId, H006K2_A198ProfesionalesDireccion, H006K2_A193ProfesionalesEmail,
               H006K2_n193ProfesionalesEmail, H006K2_A170ProfesionalesTelefono, H006K2_A40000ProfesionalesPhoto_GXI, H006K2_A192ProfesionalesApellidoSegundo, H006K2_A167ProfesionalesApellidoPrimero, H006K2_A191ProfesionalesSegundoNombre, H006K2_A166ProfesionalesPrimerNombre, H006K2_A268ProfesionalesFeedBackCant, H006K2_A269ProfesionalesFeedBackProm, H006K2_A169ProfesionalesPhoto
               }
            }
         );
         AV13Pgmname = "ProfesionalesProfesionalesDatos";
         /* GeneXus formulas. */
         AV13Pgmname = "ProfesionalesProfesionalesDatos";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A196ProfesionalesAutoEnumerar ;
      private short A197ProfesionalesAutoEnuZona ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int edtProfesionalesEmail_Enabled ;
      private int edtProfesionalesDireccion_Enabled ;
      private int A108EstadosGenericosId ;
      private int edtEstadosGenericosId_Enabled ;
      private int edtProfesionalesFeedBackCant_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtProfesionalesAutoEnumerar_Visible ;
      private int edtProfesionalesAutoEnuZona_Visible ;
      private int edtEstadosTipo_Visible ;
      private int edtProfesionalesFechaAlta_Visible ;
      private int edtProfesionalesFechaActualizado_Visible ;
      private int edtProfesionalesVerDatPerSol_Visible ;
      private int edtProfesionalesFeedBackProm_Visible ;
      private int imgProfesionalesPhoto_Enabled ;
      private int edtProfesionalesAutoEnumerar_Enabled ;
      private int edtProfesionalesAutoEnuZona_Enabled ;
      private int edtEstadosTipo_Enabled ;
      private int edtProfesionalesFechaAlta_Enabled ;
      private int edtProfesionalesFechaActualizado_Enabled ;
      private int edtProfesionalesVerDatPerSol_Enabled ;
      private int edtProfesionalesFeedBackProm_Enabled ;
      private int idxLst ;
      private long A268ProfesionalesFeedBackCant ;
      private decimal A270ProfesionalesFeedback ;
      private decimal ProfesionalesFeedback ;
      private decimal A269ProfesionalesFeedBackProm ;
      private string A120ProfesionalesId ;
      private string wcpOA120ProfesionalesId ;
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
      private string Profesionalesfeedback_Captionclass ;
      private string Profesionalesfeedback_Captionstyle ;
      private string Profesionalesfeedback_Captionposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtProfesionalesId_Internalname ;
      private string TempTags ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string A166ProfesionalesPrimerNombre ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Internalname ;
      private string A191ProfesionalesSegundoNombre ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Internalname ;
      private string A192ProfesionalesApellidoSegundo ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string imgProfesionalesPhoto_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string edtProfesionalesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A170ProfesionalesTelefono ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string edtProfesionalesEmail_Internalname ;
      private string edtProfesionalesEmail_Jsonclick ;
      private string edtProfesionalesDireccion_Internalname ;
      private string edtEstadosGenericosId_Internalname ;
      private string edtEstadosGenericosId_Jsonclick ;
      private string edtProfesionalesFeedBackCant_Internalname ;
      private string edtProfesionalesFeedBackCant_Jsonclick ;
      private string Profesionalesfeedback_Internalname ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtProfesionalesAutoEnumerar_Internalname ;
      private string edtProfesionalesAutoEnumerar_Jsonclick ;
      private string edtProfesionalesAutoEnuZona_Internalname ;
      private string edtProfesionalesAutoEnuZona_Jsonclick ;
      private string edtEstadosTipo_Internalname ;
      private string A107EstadosTipo ;
      private string edtEstadosTipo_Jsonclick ;
      private string edtProfesionalesFechaAlta_Internalname ;
      private string edtProfesionalesFechaAlta_Jsonclick ;
      private string edtProfesionalesFechaActualizado_Internalname ;
      private string edtProfesionalesFechaActualizado_Jsonclick ;
      private string edtProfesionalesVerDatPerSol_Internalname ;
      private string A267ProfesionalesVerDatPerSol ;
      private string edtProfesionalesVerDatPerSol_Jsonclick ;
      private string edtProfesionalesFeedBackProm_Internalname ;
      private string edtProfesionalesFeedBackProm_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlA120ProfesionalesId ;
      private DateTime A199ProfesionalesFechaAlta ;
      private DateTime A200ProfesionalesFechaActualizado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Profesionalesfeedback_Enabled ;
      private bool wbLoad ;
      private bool A169ProfesionalesPhoto_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n193ProfesionalesEmail ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string A193ProfesionalesEmail ;
      private string A198ProfesionalesDireccion ;
      private string A169ProfesionalesPhoto ;
      private GXUserControl ucProfesionalesfeedback ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H006K2_A120ProfesionalesId ;
      private string[] H006K2_A267ProfesionalesVerDatPerSol ;
      private DateTime[] H006K2_A200ProfesionalesFechaActualizado ;
      private DateTime[] H006K2_A199ProfesionalesFechaAlta ;
      private string[] H006K2_A107EstadosTipo ;
      private short[] H006K2_A197ProfesionalesAutoEnuZona ;
      private short[] H006K2_A196ProfesionalesAutoEnumerar ;
      private int[] H006K2_A108EstadosGenericosId ;
      private string[] H006K2_A198ProfesionalesDireccion ;
      private string[] H006K2_A193ProfesionalesEmail ;
      private bool[] H006K2_n193ProfesionalesEmail ;
      private string[] H006K2_A170ProfesionalesTelefono ;
      private string[] H006K2_A40000ProfesionalesPhoto_GXI ;
      private string[] H006K2_A192ProfesionalesApellidoSegundo ;
      private string[] H006K2_A167ProfesionalesApellidoPrimero ;
      private string[] H006K2_A191ProfesionalesSegundoNombre ;
      private string[] H006K2_A166ProfesionalesPrimerNombre ;
      private long[] H006K2_A268ProfesionalesFeedBackCant ;
      private decimal[] H006K2_A269ProfesionalesFeedBackProm ;
      private string[] H006K2_A169ProfesionalesPhoto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class profesionalesprofesionalesdatos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH006K2;
          prmH006K2 = new Object[] {
          new ParDef("@ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006K2", "SELECT [ProfesionalesId], [ProfesionalesVerDatPerSol], [ProfesionalesFechaActualizado], [ProfesionalesFechaAlta], [EstadosTipo], [ProfesionalesAutoEnuZona], [ProfesionalesAutoEnumerar], [EstadosGenericosId], [ProfesionalesDireccion], [ProfesionalesEmail], [ProfesionalesTelefono], [ProfesionalesPhoto_GXI], [ProfesionalesApellidoSegundo], [ProfesionalesApellidoPrimero], [ProfesionalesSegundoNombre], [ProfesionalesPrimerNombre], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [ProfesionalesPhoto] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006K2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((string[]) buf[12])[0] = rslt.getMultimediaUri(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 30);
                ((string[]) buf[14])[0] = rslt.getString(14, 30);
                ((string[]) buf[15])[0] = rslt.getString(15, 30);
                ((string[]) buf[16])[0] = rslt.getString(16, 30);
                ((long[]) buf[17])[0] = rslt.getLong(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((string[]) buf[19])[0] = rslt.getMultimediaFile(19, rslt.getVarchar(12));
                return;
       }
    }

 }

}
