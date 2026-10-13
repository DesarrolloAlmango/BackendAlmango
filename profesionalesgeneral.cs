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
   public class profesionalesgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public profesionalesgeneral( )
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

      public profesionalesgeneral( IGxContext context )
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
         chkProfesionalesEsRUT = new GXCheckbox();
         cmbProfesionalesVerDatPerSol = new GXCombobox();
         dynBancoId = new GXCombobox();
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"BANCOID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLABANCOID6G2( ) ;
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
            PA6G2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ProfesionalesGeneral";
               GXABANCOID_html6G2( ) ;
               WS6G2( ) ;
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
            context.SendWebValue( context.GetMessage( "Profesionales General", "")) ;
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
            GXEncryptionTmp = "profesionalesgeneral.aspx"+UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profesionalesgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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

      protected void RenderHtmlCloseForm6G2( )
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
         return "ProfesionalesGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Profesionales General", "") ;
      }

      protected void WB6G0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "profesionalesgeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesId_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId), StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtProfesionalesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesId_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NoIdentidad", "start", true, "", "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosGenericosId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEstadosGenericosId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtEstadosGenericosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9") : context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosGenericosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosGenericosId_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkProfesionalesEsRUT_Internalname, context.GetMessage( "El Documento es RUT", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkProfesionalesEsRUT_Internalname, StringUtil.BoolToStr( A676ProfesionalesEsRUT), "", context.GetMessage( "El Documento es RUT", ""), 1, chkProfesionalesEsRUT.Enabled, "true", context.GetMessage( "EL DOCUMENTO ES RUT?", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(22, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,22);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesPrimerNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesPrimerNombre_Internalname, context.GetMessage( "Primer Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre), StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesPrimerNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesPrimerNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesSegundoNombre_Internalname, StringUtil.RTrim( A191ProfesionalesSegundoNombre), StringUtil.RTrim( context.localUtil.Format( A191ProfesionalesSegundoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesSegundoNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesSegundoNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero), StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoPrimero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesApellidoPrimero_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoSegundo_Internalname, StringUtil.RTrim( A192ProfesionalesApellidoSegundo), StringUtil.RTrim( context.localUtil.Format( A192ProfesionalesApellidoSegundo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoSegundo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesApellidoSegundo_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesGeneral.htm");
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
            GxWebStd.gx_bitmap( context, imgProfesionalesPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A169ProfesionalesPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesFeedBackCant_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A268ProfesionalesFeedBackCant), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfesionalesFeedBackCant_Enabled!=0) ? context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,57);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFeedBackCant_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesFeedBackCant_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesTelefono_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesTelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesTelefono_Internalname, StringUtil.RTrim( A170ProfesionalesTelefono), StringUtil.RTrim( context.localUtil.Format( A170ProfesionalesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProfesionalesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesEmail_Internalname, A193ProfesionalesEmail, StringUtil.RTrim( context.localUtil.Format( A193ProfesionalesEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A193ProfesionalesEmail, "", "", context.GetMessage( "email@correo.com", ""), edtProfesionalesEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesDireccion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtProfesionalesDireccion_Internalname, A198ProfesionalesDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A198ProfesionalesDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", 0, 1, edtProfesionalesDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProfesionalesVerDatPerSol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbProfesionalesVerDatPerSol_Internalname, context.GetMessage( "Ver datos personales de solicitudes", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbProfesionalesVerDatPerSol, cmbProfesionalesVerDatPerSol_Internalname, StringUtil.RTrim( A267ProfesionalesVerDatPerSol), 1, cmbProfesionalesVerDatPerSol_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProfesionalesVerDatPerSol.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "", true, 0, "HLP_ProfesionalesGeneral.htm");
            cmbProfesionalesVerDatPerSol.CurrentValue = StringUtil.RTrim( A267ProfesionalesVerDatPerSol);
            AssignProp(sPrefix, false, cmbProfesionalesVerDatPerSol_Internalname, "Values", (string)(cmbProfesionalesVerDatPerSol.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesLimitOSF_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesLimitOSF_Internalname, context.GetMessage( "Limite ordenes sin finalizar", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesLimitOSF_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A617ProfesionalesLimitOSF), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfesionalesLimitOSF_Enabled!=0) ? context.localUtil.Format( (decimal)(A617ProfesionalesLimitOSF), "ZZZ9") : context.localUtil.Format( (decimal)(A617ProfesionalesLimitOSF), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,85);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesLimitOSF_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesLimitOSF_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesAceptoTerminos_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesAceptoTerminos_Internalname, context.GetMessage( "Aceptó Terminos y Condiciones", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtProfesionalesAceptoTerminos_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtProfesionalesAceptoTerminos_Internalname, context.localUtil.TToC( A678ProfesionalesAceptoTerminos, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A678ProfesionalesAceptoTerminos, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,90);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesAceptoTerminos_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesAceptoTerminos_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtProfesionalesAceptoTerminos_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProfesionalesAceptoTerminos_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ProfesionalesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesDeclaroDatosV_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesDeclaroDatosV_Internalname, context.GetMessage( "Declaró que los Datos Registrados son Verdaderos", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtProfesionalesDeclaroDatosV_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtProfesionalesDeclaroDatosV_Internalname, context.localUtil.TToC( A679ProfesionalesDeclaroDatosV, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A679ProfesionalesDeclaroDatosV, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,94);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesDeclaroDatosV_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesDeclaroDatosV_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtProfesionalesDeclaroDatosV_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProfesionalesDeclaroDatosV_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ProfesionalesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynBancoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynBancoId_Internalname, context.GetMessage( "Banco", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynBancoId, dynBancoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0)), 1, dynBancoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynBancoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 0, "HLP_ProfesionalesGeneral.htm");
            dynBancoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0));
            AssignProp(sPrefix, false, dynBancoId_Internalname, "Values", (string)(dynBancoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesCuentaBancaria_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProfesionalesCuentaBancaria_Internalname, context.GetMessage( "Cuenta Bancaria", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProfesionalesCuentaBancaria_Internalname, StringUtil.RTrim( A680ProfesionalesCuentaBancaria), StringUtil.RTrim( context.localUtil.Format( A680ProfesionalesCuentaBancaria, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesCuentaBancaria_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesCuentaBancaria_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "CuentaBancari", "start", true, "", "HLP_ProfesionalesGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo), StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosTipo_Jsonclick, 0, "Attribute", "", "", "", "", edtEstadosTipo_Visible, 0, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProfesionalesCapacidadProducti_Internalname, StringUtil.LTrim( StringUtil.NToC( A800ProfesionalesCapacidadProducti, 10, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( A800ProfesionalesCapacidadProducti, "ZZZZZZ9.99")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesCapacidadProducti_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesCapacidadProducti_Visible, 0, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "HoraCapacidadProductiva", "end", false, "", "HLP_ProfesionalesGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProfesionalesPerAltShop_Internalname, StringUtil.RTrim( A436ProfesionalesPerAltShop), StringUtil.RTrim( context.localUtil.Format( A436ProfesionalesPerAltShop, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesPerAltShop_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesPerAltShop_Visible, 0, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtProfesionalesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtProfesionalesFechaAlta_Internalname, context.localUtil.TToC( A199ProfesionalesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A199ProfesionalesFechaAlta, "99/99/99 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFechaAlta_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesFechaAlta_Visible, 0, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtProfesionalesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtProfesionalesFechaAlta_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ProfesionalesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtProfesionalesFechaActualizado_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtProfesionalesFechaActualizado_Internalname, context.localUtil.TToC( A200ProfesionalesFechaActualizado, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A200ProfesionalesFechaActualizado, "99/99/99 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFechaActualizado_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesFechaActualizado_Visible, 0, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtProfesionalesFechaActualizado_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtProfesionalesFechaActualizado_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ProfesionalesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProfesionalesFeedBackProm_Internalname, StringUtil.LTrim( StringUtil.NToC( A269ProfesionalesFeedBackProm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( A269ProfesionalesFeedBackProm, "ZZZZZZZZZZZZZZ9.99")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFeedBackProm_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesFeedBackProm_Visible, 0, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START6G2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Profesionales General", ""), 0) ;
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
               STRUP6G0( ) ;
            }
         }
      }

      protected void WS6G2( )
      {
         START6G2( ) ;
         EVT6G2( ) ;
      }

      protected void EVT6G2( )
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
                                 STRUP6G0( ) ;
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
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E116G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E126G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E136G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E146G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP6G0( ) ;
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
                                 STRUP6G0( ) ;
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

      protected void WE6G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm6G2( ) ;
            }
         }
      }

      protected void PA6G2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "profesionalesgeneral.aspx")), "profesionalesgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "profesionalesgeneral.aspx")))) ;
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

      protected void GXDLABANCOID6G2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLABANCOID_data6G2( ) ;
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

      protected void GXABANCOID_html6G2( )
      {
         long gxdynajaxvalue;
         GXDLABANCOID_data6G2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynBancoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynBancoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLABANCOID_data6G2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H006G2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H006G2_A673BancoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H006G2_A674BancoNombre[0]));
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
            GXABANCOID_html6G2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         A676ProfesionalesEsRUT = StringUtil.StrToBool( StringUtil.BoolToStr( A676ProfesionalesEsRUT));
         n676ProfesionalesEsRUT = false;
         AssignAttri(sPrefix, false, "A676ProfesionalesEsRUT", A676ProfesionalesEsRUT);
         if ( cmbProfesionalesVerDatPerSol.ItemCount > 0 )
         {
            A267ProfesionalesVerDatPerSol = cmbProfesionalesVerDatPerSol.getValidValue(A267ProfesionalesVerDatPerSol);
            AssignAttri(sPrefix, false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProfesionalesVerDatPerSol.CurrentValue = StringUtil.RTrim( A267ProfesionalesVerDatPerSol);
            AssignProp(sPrefix, false, cmbProfesionalesVerDatPerSol_Internalname, "Values", cmbProfesionalesVerDatPerSol.ToJavascriptSource(), true);
         }
         if ( dynBancoId.ItemCount > 0 )
         {
            A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n673BancoId = false;
            AssignAttri(sPrefix, false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynBancoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0));
            AssignProp(sPrefix, false, dynBancoId_Internalname, "Values", dynBancoId.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ProfesionalesGeneral";
      }

      protected void RF6G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H006G3 */
            pr_default.execute(1, new Object[] {A120ProfesionalesId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A200ProfesionalesFechaActualizado = H006G3_A200ProfesionalesFechaActualizado[0];
               AssignAttri(sPrefix, false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A199ProfesionalesFechaAlta = H006G3_A199ProfesionalesFechaAlta[0];
               AssignAttri(sPrefix, false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A436ProfesionalesPerAltShop = H006G3_A436ProfesionalesPerAltShop[0];
               n436ProfesionalesPerAltShop = H006G3_n436ProfesionalesPerAltShop[0];
               AssignAttri(sPrefix, false, "A436ProfesionalesPerAltShop", A436ProfesionalesPerAltShop);
               A800ProfesionalesCapacidadProducti = H006G3_A800ProfesionalesCapacidadProducti[0];
               AssignAttri(sPrefix, false, "A800ProfesionalesCapacidadProducti", StringUtil.LTrimStr( A800ProfesionalesCapacidadProducti, 10, 2));
               A107EstadosTipo = H006G3_A107EstadosTipo[0];
               AssignAttri(sPrefix, false, "A107EstadosTipo", A107EstadosTipo);
               A680ProfesionalesCuentaBancaria = H006G3_A680ProfesionalesCuentaBancaria[0];
               n680ProfesionalesCuentaBancaria = H006G3_n680ProfesionalesCuentaBancaria[0];
               AssignAttri(sPrefix, false, "A680ProfesionalesCuentaBancaria", A680ProfesionalesCuentaBancaria);
               A673BancoId = H006G3_A673BancoId[0];
               n673BancoId = H006G3_n673BancoId[0];
               AssignAttri(sPrefix, false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
               A679ProfesionalesDeclaroDatosV = H006G3_A679ProfesionalesDeclaroDatosV[0];
               n679ProfesionalesDeclaroDatosV = H006G3_n679ProfesionalesDeclaroDatosV[0];
               AssignAttri(sPrefix, false, "A679ProfesionalesDeclaroDatosV", context.localUtil.TToC( A679ProfesionalesDeclaroDatosV, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A678ProfesionalesAceptoTerminos = H006G3_A678ProfesionalesAceptoTerminos[0];
               n678ProfesionalesAceptoTerminos = H006G3_n678ProfesionalesAceptoTerminos[0];
               AssignAttri(sPrefix, false, "A678ProfesionalesAceptoTerminos", context.localUtil.TToC( A678ProfesionalesAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A617ProfesionalesLimitOSF = H006G3_A617ProfesionalesLimitOSF[0];
               n617ProfesionalesLimitOSF = H006G3_n617ProfesionalesLimitOSF[0];
               AssignAttri(sPrefix, false, "A617ProfesionalesLimitOSF", StringUtil.LTrimStr( (decimal)(A617ProfesionalesLimitOSF), 4, 0));
               A267ProfesionalesVerDatPerSol = H006G3_A267ProfesionalesVerDatPerSol[0];
               AssignAttri(sPrefix, false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
               A198ProfesionalesDireccion = H006G3_A198ProfesionalesDireccion[0];
               AssignAttri(sPrefix, false, "A198ProfesionalesDireccion", A198ProfesionalesDireccion);
               A193ProfesionalesEmail = H006G3_A193ProfesionalesEmail[0];
               n193ProfesionalesEmail = H006G3_n193ProfesionalesEmail[0];
               AssignAttri(sPrefix, false, "A193ProfesionalesEmail", A193ProfesionalesEmail);
               A170ProfesionalesTelefono = H006G3_A170ProfesionalesTelefono[0];
               AssignAttri(sPrefix, false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
               A40000ProfesionalesPhoto_GXI = H006G3_A40000ProfesionalesPhoto_GXI[0];
               AssignProp(sPrefix, false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
               AssignProp(sPrefix, false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               A192ProfesionalesApellidoSegundo = H006G3_A192ProfesionalesApellidoSegundo[0];
               AssignAttri(sPrefix, false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
               A167ProfesionalesApellidoPrimero = H006G3_A167ProfesionalesApellidoPrimero[0];
               AssignAttri(sPrefix, false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
               A191ProfesionalesSegundoNombre = H006G3_A191ProfesionalesSegundoNombre[0];
               AssignAttri(sPrefix, false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
               A166ProfesionalesPrimerNombre = H006G3_A166ProfesionalesPrimerNombre[0];
               AssignAttri(sPrefix, false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
               A676ProfesionalesEsRUT = H006G3_A676ProfesionalesEsRUT[0];
               n676ProfesionalesEsRUT = H006G3_n676ProfesionalesEsRUT[0];
               AssignAttri(sPrefix, false, "A676ProfesionalesEsRUT", A676ProfesionalesEsRUT);
               A108EstadosGenericosId = H006G3_A108EstadosGenericosId[0];
               AssignAttri(sPrefix, false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
               A268ProfesionalesFeedBackCant = H006G3_A268ProfesionalesFeedBackCant[0];
               AssignAttri(sPrefix, false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
               A269ProfesionalesFeedBackProm = H006G3_A269ProfesionalesFeedBackProm[0];
               AssignAttri(sPrefix, false, "A269ProfesionalesFeedBackProm", StringUtil.LTrimStr( A269ProfesionalesFeedBackProm, 18, 2));
               A169ProfesionalesPhoto = H006G3_A169ProfesionalesPhoto[0];
               AssignAttri(sPrefix, false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
               AssignProp(sPrefix, false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
               AssignProp(sPrefix, false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               GXABANCOID_html6G2( ) ;
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
               E126G2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB6G0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes6G2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ProfesionalesGeneral";
         GXABANCOID_html6G2( ) ;
         edtProfesionalesId_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         edtEstadosGenericosId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), true);
         chkProfesionalesEsRUT.Enabled = 0;
         AssignProp(sPrefix, false, chkProfesionalesEsRUT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProfesionalesEsRUT.Enabled), 5, 0), true);
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
         edtProfesionalesFeedBackCant_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesFeedBackCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackCant_Enabled), 5, 0), true);
         edtProfesionalesTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesTelefono_Enabled), 5, 0), true);
         edtProfesionalesEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesEmail_Enabled), 5, 0), true);
         edtProfesionalesDireccion_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesDireccion_Enabled), 5, 0), true);
         cmbProfesionalesVerDatPerSol.Enabled = 0;
         AssignProp(sPrefix, false, cmbProfesionalesVerDatPerSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProfesionalesVerDatPerSol.Enabled), 5, 0), true);
         edtProfesionalesLimitOSF_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesLimitOSF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesLimitOSF_Enabled), 5, 0), true);
         edtProfesionalesAceptoTerminos_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesAceptoTerminos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesAceptoTerminos_Enabled), 5, 0), true);
         edtProfesionalesDeclaroDatosV_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesDeclaroDatosV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesDeclaroDatosV_Enabled), 5, 0), true);
         dynBancoId.Enabled = 0;
         AssignProp(sPrefix, false, dynBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBancoId.Enabled), 5, 0), true);
         edtProfesionalesCuentaBancaria_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesCuentaBancaria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesCuentaBancaria_Enabled), 5, 0), true);
         edtEstadosTipo_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         edtProfesionalesCapacidadProducti_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesCapacidadProducti_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesCapacidadProducti_Enabled), 5, 0), true);
         edtProfesionalesPerAltShop_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesPerAltShop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPerAltShop_Enabled), 5, 0), true);
         edtProfesionalesFechaAlta_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaAlta_Enabled), 5, 0), true);
         edtProfesionalesFechaActualizado_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesFechaActualizado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaActualizado_Enabled), 5, 0), true);
         edtProfesionalesFeedBackProm_Enabled = 0;
         AssignProp(sPrefix, false, edtProfesionalesFeedBackProm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackProm_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116G2 ();
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
            A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            A676ProfesionalesEsRUT = StringUtil.StrToBool( cgiGet( chkProfesionalesEsRUT_Internalname));
            n676ProfesionalesEsRUT = false;
            AssignAttri(sPrefix, false, "A676ProfesionalesEsRUT", A676ProfesionalesEsRUT);
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
            A268ProfesionalesFeedBackCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
            A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
            AssignAttri(sPrefix, false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
            A193ProfesionalesEmail = cgiGet( edtProfesionalesEmail_Internalname);
            n193ProfesionalesEmail = false;
            AssignAttri(sPrefix, false, "A193ProfesionalesEmail", A193ProfesionalesEmail);
            A198ProfesionalesDireccion = cgiGet( edtProfesionalesDireccion_Internalname);
            AssignAttri(sPrefix, false, "A198ProfesionalesDireccion", A198ProfesionalesDireccion);
            cmbProfesionalesVerDatPerSol.CurrentValue = cgiGet( cmbProfesionalesVerDatPerSol_Internalname);
            A267ProfesionalesVerDatPerSol = cgiGet( cmbProfesionalesVerDatPerSol_Internalname);
            AssignAttri(sPrefix, false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
            A617ProfesionalesLimitOSF = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesLimitOSF_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n617ProfesionalesLimitOSF = false;
            AssignAttri(sPrefix, false, "A617ProfesionalesLimitOSF", StringUtil.LTrimStr( (decimal)(A617ProfesionalesLimitOSF), 4, 0));
            A678ProfesionalesAceptoTerminos = context.localUtil.CToT( cgiGet( edtProfesionalesAceptoTerminos_Internalname));
            n678ProfesionalesAceptoTerminos = false;
            AssignAttri(sPrefix, false, "A678ProfesionalesAceptoTerminos", context.localUtil.TToC( A678ProfesionalesAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A679ProfesionalesDeclaroDatosV = context.localUtil.CToT( cgiGet( edtProfesionalesDeclaroDatosV_Internalname));
            n679ProfesionalesDeclaroDatosV = false;
            AssignAttri(sPrefix, false, "A679ProfesionalesDeclaroDatosV", context.localUtil.TToC( A679ProfesionalesDeclaroDatosV, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            dynBancoId.CurrentValue = cgiGet( dynBancoId_Internalname);
            A673BancoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynBancoId_Internalname), "."), 18, MidpointRounding.ToEven));
            n673BancoId = false;
            AssignAttri(sPrefix, false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            A680ProfesionalesCuentaBancaria = cgiGet( edtProfesionalesCuentaBancaria_Internalname);
            n680ProfesionalesCuentaBancaria = false;
            AssignAttri(sPrefix, false, "A680ProfesionalesCuentaBancaria", A680ProfesionalesCuentaBancaria);
            A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
            AssignAttri(sPrefix, false, "A107EstadosTipo", A107EstadosTipo);
            A800ProfesionalesCapacidadProducti = context.localUtil.CToN( cgiGet( edtProfesionalesCapacidadProducti_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A800ProfesionalesCapacidadProducti", StringUtil.LTrimStr( A800ProfesionalesCapacidadProducti, 10, 2));
            A436ProfesionalesPerAltShop = cgiGet( edtProfesionalesPerAltShop_Internalname);
            n436ProfesionalesPerAltShop = false;
            AssignAttri(sPrefix, false, "A436ProfesionalesPerAltShop", A436ProfesionalesPerAltShop);
            A199ProfesionalesFechaAlta = context.localUtil.CToT( cgiGet( edtProfesionalesFechaAlta_Internalname));
            AssignAttri(sPrefix, false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A200ProfesionalesFechaActualizado = context.localUtil.CToT( cgiGet( edtProfesionalesFechaActualizado_Internalname));
            AssignAttri(sPrefix, false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A269ProfesionalesFeedBackProm = context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackProm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A269ProfesionalesFeedBackProm", StringUtil.LTrimStr( A269ProfesionalesFeedBackProm, 18, 2));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            GXABANCOID_html6G2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E116G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E116G2( )
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

      protected void E126G2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtEstadosTipo_Visible = 0;
         AssignProp(sPrefix, false, edtEstadosTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Visible), 5, 0), true);
         edtProfesionalesCapacidadProducti_Visible = 0;
         AssignProp(sPrefix, false, edtProfesionalesCapacidadProducti_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesCapacidadProducti_Visible), 5, 0), true);
         edtProfesionalesPerAltShop_Visible = 0;
         AssignProp(sPrefix, false, edtProfesionalesPerAltShop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesPerAltShop_Visible), 5, 0), true);
         edtProfesionalesFechaAlta_Visible = 0;
         AssignProp(sPrefix, false, edtProfesionalesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaAlta_Visible), 5, 0), true);
         edtProfesionalesFechaActualizado_Visible = 0;
         AssignProp(sPrefix, false, edtProfesionalesFechaActualizado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaActualizado_Visible), 5, 0), true);
         edtProfesionalesFeedBackProm_Visible = 0;
         AssignProp(sPrefix, false, edtProfesionalesFeedBackProm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackProm_Visible), 5, 0), true);
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E136G2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
         CallWebObject(formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E146G2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
         CallWebObject(formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Transactionname = "Profesionales";
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
         PA6G2( ) ;
         WS6G2( ) ;
         WE6G2( ) ;
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
         PA6G2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "profesionalesgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA6G2( ) ;
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
         PA6G2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS6G2( ) ;
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
         WS6G2( ) ;
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
         WE6G2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932012427", true, true, false);
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
         context.AddJavascriptSource("profesionalesgeneral.js", "?2026932012427", false, true, false);
         context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
         context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkProfesionalesEsRUT.Name = "PROFESIONALESESRUT";
         chkProfesionalesEsRUT.WebTags = "";
         chkProfesionalesEsRUT.Caption = context.GetMessage( "El Documento es RUT", "");
         AssignProp(sPrefix, false, chkProfesionalesEsRUT_Internalname, "TitleCaption", chkProfesionalesEsRUT.Caption, true);
         chkProfesionalesEsRUT.CheckedValue = "false";
         cmbProfesionalesVerDatPerSol.Name = "PROFESIONALESVERDATPERSOL";
         cmbProfesionalesVerDatPerSol.WebTags = "";
         cmbProfesionalesVerDatPerSol.addItem("S", context.GetMessage( "SI", ""), 0);
         cmbProfesionalesVerDatPerSol.addItem("N", context.GetMessage( "NO", ""), 0);
         if ( cmbProfesionalesVerDatPerSol.ItemCount > 0 )
         {
         }
         dynBancoId.Name = "BANCOID";
         dynBancoId.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID";
         edtEstadosGenericosId_Internalname = sPrefix+"ESTADOSGENERICOSID";
         chkProfesionalesEsRUT_Internalname = sPrefix+"PROFESIONALESESRUT";
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO";
         divTransactiondetail_tb1_Internalname = sPrefix+"TRANSACTIONDETAIL_TB1";
         imgProfesionalesPhoto_Internalname = sPrefix+"PROFESIONALESPHOTO";
         edtProfesionalesFeedBackCant_Internalname = sPrefix+"PROFESIONALESFEEDBACKCANT";
         Profesionalesfeedback_Internalname = sPrefix+"PROFESIONALESFEEDBACK";
         divTransactiondetail_tb2_Internalname = sPrefix+"TRANSACTIONDETAIL_TB2";
         edtProfesionalesTelefono_Internalname = sPrefix+"PROFESIONALESTELEFONO";
         edtProfesionalesEmail_Internalname = sPrefix+"PROFESIONALESEMAIL";
         edtProfesionalesDireccion_Internalname = sPrefix+"PROFESIONALESDIRECCION";
         cmbProfesionalesVerDatPerSol_Internalname = sPrefix+"PROFESIONALESVERDATPERSOL";
         edtProfesionalesLimitOSF_Internalname = sPrefix+"PROFESIONALESLIMITOSF";
         edtProfesionalesAceptoTerminos_Internalname = sPrefix+"PROFESIONALESACEPTOTERMINOS";
         edtProfesionalesDeclaroDatosV_Internalname = sPrefix+"PROFESIONALESDECLARODATOSV";
         dynBancoId_Internalname = sPrefix+"BANCOID";
         edtProfesionalesCuentaBancaria_Internalname = sPrefix+"PROFESIONALESCUENTABANCARIA";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtEstadosTipo_Internalname = sPrefix+"ESTADOSTIPO";
         edtProfesionalesCapacidadProducti_Internalname = sPrefix+"PROFESIONALESCAPACIDADPRODUCTI";
         edtProfesionalesPerAltShop_Internalname = sPrefix+"PROFESIONALESPERALTSHOP";
         edtProfesionalesFechaAlta_Internalname = sPrefix+"PROFESIONALESFECHAALTA";
         edtProfesionalesFechaActualizado_Internalname = sPrefix+"PROFESIONALESFECHAACTUALIZADO";
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
         chkProfesionalesEsRUT.Caption = context.GetMessage( "El Documento es RUT", "");
         edtProfesionalesFeedBackProm_Enabled = 0;
         edtProfesionalesFechaActualizado_Enabled = 0;
         edtProfesionalesFechaAlta_Enabled = 0;
         edtProfesionalesPerAltShop_Enabled = 0;
         edtProfesionalesCapacidadProducti_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         imgProfesionalesPhoto_Enabled = 0;
         edtProfesionalesFeedBackProm_Jsonclick = "";
         edtProfesionalesFeedBackProm_Visible = 1;
         edtProfesionalesFechaActualizado_Jsonclick = "";
         edtProfesionalesFechaActualizado_Visible = 1;
         edtProfesionalesFechaAlta_Jsonclick = "";
         edtProfesionalesFechaAlta_Visible = 1;
         edtProfesionalesPerAltShop_Jsonclick = "";
         edtProfesionalesPerAltShop_Visible = 1;
         edtProfesionalesCapacidadProducti_Jsonclick = "";
         edtProfesionalesCapacidadProducti_Visible = 1;
         edtEstadosTipo_Jsonclick = "";
         edtEstadosTipo_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtProfesionalesCuentaBancaria_Jsonclick = "";
         edtProfesionalesCuentaBancaria_Enabled = 0;
         dynBancoId_Jsonclick = "";
         dynBancoId.Enabled = 0;
         edtProfesionalesDeclaroDatosV_Jsonclick = "";
         edtProfesionalesDeclaroDatosV_Enabled = 0;
         edtProfesionalesAceptoTerminos_Jsonclick = "";
         edtProfesionalesAceptoTerminos_Enabled = 0;
         edtProfesionalesLimitOSF_Jsonclick = "";
         edtProfesionalesLimitOSF_Enabled = 0;
         cmbProfesionalesVerDatPerSol_Jsonclick = "";
         cmbProfesionalesVerDatPerSol.Enabled = 0;
         edtProfesionalesDireccion_Enabled = 0;
         edtProfesionalesEmail_Jsonclick = "";
         edtProfesionalesEmail_Enabled = 0;
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesTelefono_Enabled = 0;
         Profesionalesfeedback_Enabled = Convert.ToBoolean( 0);
         edtProfesionalesFeedBackCant_Jsonclick = "";
         edtProfesionalesFeedBackCant_Enabled = 0;
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Enabled = 0;
         chkProfesionalesEsRUT.Enabled = 0;
         edtEstadosGenericosId_Jsonclick = "";
         edtEstadosGenericosId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E136G2',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E146G2',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'}]");
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
         ClassString = "";
         StyleString = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A169ProfesionalesPhoto = "";
         A40000ProfesionalesPhoto_GXI = "";
         sImgUrl = "";
         ucProfesionalesfeedback = new GXUserControl();
         gxphoneLink = "";
         A170ProfesionalesTelefono = "";
         A193ProfesionalesEmail = "";
         A198ProfesionalesDireccion = "";
         A267ProfesionalesVerDatPerSol = "";
         A678ProfesionalesAceptoTerminos = (DateTime)(DateTime.MinValue);
         A679ProfesionalesDeclaroDatosV = (DateTime)(DateTime.MinValue);
         A680ProfesionalesCuentaBancaria = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A107EstadosTipo = "";
         A436ProfesionalesPerAltShop = "";
         A199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
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
         H006G2_A673BancoId = new long[1] ;
         H006G2_n673BancoId = new bool[] {false} ;
         H006G2_A674BancoNombre = new string[] {""} ;
         H006G2_A675BancoEstado = new string[] {""} ;
         H006G3_A120ProfesionalesId = new string[] {""} ;
         H006G3_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         H006G3_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H006G3_A436ProfesionalesPerAltShop = new string[] {""} ;
         H006G3_n436ProfesionalesPerAltShop = new bool[] {false} ;
         H006G3_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         H006G3_A107EstadosTipo = new string[] {""} ;
         H006G3_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         H006G3_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         H006G3_A673BancoId = new long[1] ;
         H006G3_n673BancoId = new bool[] {false} ;
         H006G3_A679ProfesionalesDeclaroDatosV = new DateTime[] {DateTime.MinValue} ;
         H006G3_n679ProfesionalesDeclaroDatosV = new bool[] {false} ;
         H006G3_A678ProfesionalesAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         H006G3_n678ProfesionalesAceptoTerminos = new bool[] {false} ;
         H006G3_A617ProfesionalesLimitOSF = new short[1] ;
         H006G3_n617ProfesionalesLimitOSF = new bool[] {false} ;
         H006G3_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         H006G3_A198ProfesionalesDireccion = new string[] {""} ;
         H006G3_A193ProfesionalesEmail = new string[] {""} ;
         H006G3_n193ProfesionalesEmail = new bool[] {false} ;
         H006G3_A170ProfesionalesTelefono = new string[] {""} ;
         H006G3_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         H006G3_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H006G3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H006G3_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H006G3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H006G3_A676ProfesionalesEsRUT = new bool[] {false} ;
         H006G3_n676ProfesionalesEsRUT = new bool[] {false} ;
         H006G3_A108EstadosGenericosId = new int[1] ;
         H006G3_A268ProfesionalesFeedBackCant = new long[1] ;
         H006G3_A269ProfesionalesFeedBackProm = new decimal[1] ;
         H006G3_A169ProfesionalesPhoto = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesgeneral__default(),
            new Object[][] {
                new Object[] {
               H006G2_A673BancoId, H006G2_A674BancoNombre, H006G2_A675BancoEstado
               }
               , new Object[] {
               H006G3_A120ProfesionalesId, H006G3_A200ProfesionalesFechaActualizado, H006G3_A199ProfesionalesFechaAlta, H006G3_A436ProfesionalesPerAltShop, H006G3_n436ProfesionalesPerAltShop, H006G3_A800ProfesionalesCapacidadProducti, H006G3_A107EstadosTipo, H006G3_A680ProfesionalesCuentaBancaria, H006G3_n680ProfesionalesCuentaBancaria, H006G3_A673BancoId,
               H006G3_n673BancoId, H006G3_A679ProfesionalesDeclaroDatosV, H006G3_n679ProfesionalesDeclaroDatosV, H006G3_A678ProfesionalesAceptoTerminos, H006G3_n678ProfesionalesAceptoTerminos, H006G3_A617ProfesionalesLimitOSF, H006G3_n617ProfesionalesLimitOSF, H006G3_A267ProfesionalesVerDatPerSol, H006G3_A198ProfesionalesDireccion, H006G3_A193ProfesionalesEmail,
               H006G3_n193ProfesionalesEmail, H006G3_A170ProfesionalesTelefono, H006G3_A40000ProfesionalesPhoto_GXI, H006G3_A192ProfesionalesApellidoSegundo, H006G3_A167ProfesionalesApellidoPrimero, H006G3_A191ProfesionalesSegundoNombre, H006G3_A166ProfesionalesPrimerNombre, H006G3_A676ProfesionalesEsRUT, H006G3_n676ProfesionalesEsRUT, H006G3_A108EstadosGenericosId,
               H006G3_A268ProfesionalesFeedBackCant, H006G3_A269ProfesionalesFeedBackProm, H006G3_A169ProfesionalesPhoto
               }
            }
         );
         AV13Pgmname = "ProfesionalesGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ProfesionalesGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A617ProfesionalesLimitOSF ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtProfesionalesId_Enabled ;
      private int A108EstadosGenericosId ;
      private int edtEstadosGenericosId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtProfesionalesFeedBackCant_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int edtProfesionalesEmail_Enabled ;
      private int edtProfesionalesDireccion_Enabled ;
      private int edtProfesionalesLimitOSF_Enabled ;
      private int edtProfesionalesAceptoTerminos_Enabled ;
      private int edtProfesionalesDeclaroDatosV_Enabled ;
      private int edtProfesionalesCuentaBancaria_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtEstadosTipo_Visible ;
      private int edtProfesionalesCapacidadProducti_Visible ;
      private int edtProfesionalesPerAltShop_Visible ;
      private int edtProfesionalesFechaAlta_Visible ;
      private int edtProfesionalesFechaActualizado_Visible ;
      private int edtProfesionalesFeedBackProm_Visible ;
      private int gxdynajaxindex ;
      private int imgProfesionalesPhoto_Enabled ;
      private int edtEstadosTipo_Enabled ;
      private int edtProfesionalesCapacidadProducti_Enabled ;
      private int edtProfesionalesPerAltShop_Enabled ;
      private int edtProfesionalesFechaAlta_Enabled ;
      private int edtProfesionalesFechaActualizado_Enabled ;
      private int edtProfesionalesFeedBackProm_Enabled ;
      private int idxLst ;
      private long A268ProfesionalesFeedBackCant ;
      private long A673BancoId ;
      private decimal A270ProfesionalesFeedback ;
      private decimal ProfesionalesFeedback ;
      private decimal A800ProfesionalesCapacidadProducti ;
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
      private string edtEstadosGenericosId_Internalname ;
      private string edtEstadosGenericosId_Jsonclick ;
      private string chkProfesionalesEsRUT_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTransactiondetail_tb1_Internalname ;
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
      private string divTransactiondetail_tb2_Internalname ;
      private string imgProfesionalesPhoto_Internalname ;
      private string sImgUrl ;
      private string edtProfesionalesFeedBackCant_Internalname ;
      private string edtProfesionalesFeedBackCant_Jsonclick ;
      private string Profesionalesfeedback_Internalname ;
      private string edtProfesionalesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A170ProfesionalesTelefono ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string edtProfesionalesEmail_Internalname ;
      private string edtProfesionalesEmail_Jsonclick ;
      private string edtProfesionalesDireccion_Internalname ;
      private string cmbProfesionalesVerDatPerSol_Internalname ;
      private string A267ProfesionalesVerDatPerSol ;
      private string cmbProfesionalesVerDatPerSol_Jsonclick ;
      private string edtProfesionalesLimitOSF_Internalname ;
      private string edtProfesionalesLimitOSF_Jsonclick ;
      private string edtProfesionalesAceptoTerminos_Internalname ;
      private string edtProfesionalesAceptoTerminos_Jsonclick ;
      private string edtProfesionalesDeclaroDatosV_Internalname ;
      private string edtProfesionalesDeclaroDatosV_Jsonclick ;
      private string dynBancoId_Internalname ;
      private string dynBancoId_Jsonclick ;
      private string edtProfesionalesCuentaBancaria_Internalname ;
      private string A680ProfesionalesCuentaBancaria ;
      private string edtProfesionalesCuentaBancaria_Jsonclick ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtEstadosTipo_Internalname ;
      private string A107EstadosTipo ;
      private string edtEstadosTipo_Jsonclick ;
      private string edtProfesionalesCapacidadProducti_Internalname ;
      private string edtProfesionalesCapacidadProducti_Jsonclick ;
      private string edtProfesionalesPerAltShop_Internalname ;
      private string A436ProfesionalesPerAltShop ;
      private string edtProfesionalesPerAltShop_Jsonclick ;
      private string edtProfesionalesFechaAlta_Internalname ;
      private string edtProfesionalesFechaAlta_Jsonclick ;
      private string edtProfesionalesFechaActualizado_Internalname ;
      private string edtProfesionalesFechaActualizado_Jsonclick ;
      private string edtProfesionalesFeedBackProm_Internalname ;
      private string edtProfesionalesFeedBackProm_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string sCtrlA120ProfesionalesId ;
      private DateTime A678ProfesionalesAceptoTerminos ;
      private DateTime A679ProfesionalesDeclaroDatosV ;
      private DateTime A199ProfesionalesFechaAlta ;
      private DateTime A200ProfesionalesFechaActualizado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Profesionalesfeedback_Enabled ;
      private bool wbLoad ;
      private bool A676ProfesionalesEsRUT ;
      private bool A169ProfesionalesPhoto_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n676ProfesionalesEsRUT ;
      private bool n673BancoId ;
      private bool n436ProfesionalesPerAltShop ;
      private bool n680ProfesionalesCuentaBancaria ;
      private bool n679ProfesionalesDeclaroDatosV ;
      private bool n678ProfesionalesAceptoTerminos ;
      private bool n617ProfesionalesLimitOSF ;
      private bool n193ProfesionalesEmail ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string A193ProfesionalesEmail ;
      private string A198ProfesionalesDireccion ;
      private string A169ProfesionalesPhoto ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucProfesionalesfeedback ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkProfesionalesEsRUT ;
      private GXCombobox cmbProfesionalesVerDatPerSol ;
      private GXCombobox dynBancoId ;
      private IDataStoreProvider pr_default ;
      private long[] H006G2_A673BancoId ;
      private bool[] H006G2_n673BancoId ;
      private string[] H006G2_A674BancoNombre ;
      private string[] H006G2_A675BancoEstado ;
      private string[] H006G3_A120ProfesionalesId ;
      private DateTime[] H006G3_A200ProfesionalesFechaActualizado ;
      private DateTime[] H006G3_A199ProfesionalesFechaAlta ;
      private string[] H006G3_A436ProfesionalesPerAltShop ;
      private bool[] H006G3_n436ProfesionalesPerAltShop ;
      private decimal[] H006G3_A800ProfesionalesCapacidadProducti ;
      private string[] H006G3_A107EstadosTipo ;
      private string[] H006G3_A680ProfesionalesCuentaBancaria ;
      private bool[] H006G3_n680ProfesionalesCuentaBancaria ;
      private long[] H006G3_A673BancoId ;
      private bool[] H006G3_n673BancoId ;
      private DateTime[] H006G3_A679ProfesionalesDeclaroDatosV ;
      private bool[] H006G3_n679ProfesionalesDeclaroDatosV ;
      private DateTime[] H006G3_A678ProfesionalesAceptoTerminos ;
      private bool[] H006G3_n678ProfesionalesAceptoTerminos ;
      private short[] H006G3_A617ProfesionalesLimitOSF ;
      private bool[] H006G3_n617ProfesionalesLimitOSF ;
      private string[] H006G3_A267ProfesionalesVerDatPerSol ;
      private string[] H006G3_A198ProfesionalesDireccion ;
      private string[] H006G3_A193ProfesionalesEmail ;
      private bool[] H006G3_n193ProfesionalesEmail ;
      private string[] H006G3_A170ProfesionalesTelefono ;
      private string[] H006G3_A40000ProfesionalesPhoto_GXI ;
      private string[] H006G3_A192ProfesionalesApellidoSegundo ;
      private string[] H006G3_A167ProfesionalesApellidoPrimero ;
      private string[] H006G3_A191ProfesionalesSegundoNombre ;
      private string[] H006G3_A166ProfesionalesPrimerNombre ;
      private bool[] H006G3_A676ProfesionalesEsRUT ;
      private bool[] H006G3_n676ProfesionalesEsRUT ;
      private int[] H006G3_A108EstadosGenericosId ;
      private long[] H006G3_A268ProfesionalesFeedBackCant ;
      private decimal[] H006G3_A269ProfesionalesFeedBackProm ;
      private string[] H006G3_A169ProfesionalesPhoto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class profesionalesgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH006G2;
          prmH006G2 = new Object[] {
          };
          Object[] prmH006G3;
          prmH006G3 = new Object[] {
          new ParDef("@ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006G2", "SELECT [BancoId], [BancoNombre], [BancoEstado] FROM [Banco] WHERE [BancoEstado] = 'HAB' ORDER BY [BancoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006G2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006G3", "SELECT [ProfesionalesId], [ProfesionalesFechaActualizado], [ProfesionalesFechaAlta], [ProfesionalesPerAltShop], [ProfesionalesCapacidadProducti], [EstadosTipo], [ProfesionalesCuentaBancaria], [BancoId], [ProfesionalesDeclaroDatosV], [ProfesionalesAceptoTerminos], [ProfesionalesLimitOSF], [ProfesionalesVerDatPerSol], [ProfesionalesDireccion], [ProfesionalesEmail], [ProfesionalesTelefono], [ProfesionalesPhoto_GXI], [ProfesionalesApellidoSegundo], [ProfesionalesApellidoPrimero], [ProfesionalesSegundoNombre], [ProfesionalesPrimerNombre], [ProfesionalesEsRUT], [EstadosGenericosId], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [ProfesionalesPhoto] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006G3,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((string[]) buf[7])[0] = rslt.getString(7, 50);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((long[]) buf[9])[0] = rslt.getLong(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((short[]) buf[15])[0] = rslt.getShort(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((string[]) buf[17])[0] = rslt.getString(12, 1);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((string[]) buf[19])[0] = rslt.getVarchar(14);
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                ((string[]) buf[21])[0] = rslt.getString(15, 20);
                ((string[]) buf[22])[0] = rslt.getMultimediaUri(16);
                ((string[]) buf[23])[0] = rslt.getString(17, 30);
                ((string[]) buf[24])[0] = rslt.getString(18, 30);
                ((string[]) buf[25])[0] = rslt.getString(19, 30);
                ((string[]) buf[26])[0] = rslt.getString(20, 30);
                ((bool[]) buf[27])[0] = rslt.getBool(21);
                ((bool[]) buf[28])[0] = rslt.wasNull(21);
                ((int[]) buf[29])[0] = rslt.getInt(22);
                ((long[]) buf[30])[0] = rslt.getLong(23);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(24);
                ((string[]) buf[32])[0] = rslt.getMultimediaFile(25, rslt.getVarchar(16));
                return;
       }
    }

 }

}
