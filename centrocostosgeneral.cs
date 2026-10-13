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
   public class centrocostosgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public centrocostosgeneral( )
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

      public centrocostosgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CentroCostosId ,
                           long aP1_CentroCostosRef )
      {
         this.A461CentroCostosId = aP0_CentroCostosId;
         this.A462CentroCostosRef = aP1_CentroCostosRef;
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
         cmbCentroCostosTipoRef = new GXCombobox();
         cmbCentroCostosEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "CentroCostosId");
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
                  A461CentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
                  A462CentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosRef"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A461CentroCostosId,(long)A462CentroCostosRef});
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
                  gxfirstwebparm = GetFirstPar( "CentroCostosId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "CentroCostosId");
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
            PA3T2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV14Pgmname = "CentroCostosGeneral";
               /* Using cursor H003T3 */
               pr_default.execute(0, new Object[] {A461CentroCostosId});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A469CentroCostosSubTotal = H003T3_A469CentroCostosSubTotal[0];
                  n469CentroCostosSubTotal = H003T3_n469CentroCostosSubTotal[0];
                  AssignAttri(sPrefix, false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               }
               else
               {
                  A469CentroCostosSubTotal = 0;
                  n469CentroCostosSubTotal = false;
                  AssignAttri(sPrefix, false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               }
               pr_default.close(0);
               WS3T2( ) ;
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
            context.SendWebValue( context.GetMessage( "Centro Costos General", "")) ;
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
            GXEncryptionTmp = "centrocostosgeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A462CentroCostosRef,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("centrocostosgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA461CentroCostosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA462CentroCostosRef", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseForm3T2( )
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
         return "CentroCostosGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Centro Costos General", "") ;
      }

      protected void WB3T0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "centrocostosgeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCentroCostosId_Internalname, context.GetMessage( "Código CC:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCentroCostosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbCentroCostosTipoRef_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbCentroCostosTipoRef_Internalname, context.GetMessage( "Tipo Referencia:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbCentroCostosTipoRef, cmbCentroCostosTipoRef_Internalname, StringUtil.RTrim( A487CentroCostosTipoRef), 1, cmbCentroCostosTipoRef_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbCentroCostosTipoRef.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "", true, 0, "HLP_CentroCostosGeneral.htm");
            cmbCentroCostosTipoRef.CurrentValue = StringUtil.RTrim( A487CentroCostosTipoRef);
            AssignProp(sPrefix, false, cmbCentroCostosTipoRef_Internalname, "Values", (string)(cmbCentroCostosTipoRef.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosRef_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCentroCostosRef_Internalname, context.GetMessage( "Referencia Nro:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCentroCostosRef_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosRef_Enabled!=0) ? context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosRef_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosRef_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCentroCostosNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCentroCostosNombre_Internalname, StringUtil.RTrim( A463CentroCostosNombre), StringUtil.RTrim( context.localUtil.Format( A463CentroCostosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosPrecioFinal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCentroCostosPrecioFinal_Internalname, context.GetMessage( "Precio Final:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCentroCostosPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosPrecioFinal_Enabled!=0) ? context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosPrecioFinal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosPrecioFinal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgavNuevoitem_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Nuevo Item", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "AttributeFL" + " " + ((StringUtil.StrCmp(imgavNuevoitem_gximage, "")==0) ? "" : "GX_Image_"+imgavNuevoitem_gximage+"_Class");
            StyleString = "";
            AV12NuevoItem_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV12NuevoItem))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Nuevoitem_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV12NuevoItem)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV12NuevoItem)) ? AV15Nuevoitem_GXI : context.PathToRelativeUrl( AV12NuevoItem));
            GxWebStd.gx_bitmap( context, imgavNuevoitem_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV12NuevoItem_IsBlob, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosSubTotal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCentroCostosSubTotal_Internalname, context.GetMessage( "Sub Total", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCentroCostosSubTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A469CentroCostosSubTotal, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosSubTotal_Enabled!=0) ? context.localUtil.Format( A469CentroCostosSubTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A469CentroCostosSubTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosSubTotal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosSubTotal_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "Total", "end", false, "", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosCosto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCentroCostosCosto_Internalname, context.GetMessage( "Costo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCentroCostosCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosCosto_Enabled!=0) ? context.localUtil.Format( A475CentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A475CentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosCosto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosCosto_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosGam_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCentroCostosGam_Internalname, context.GetMessage( "Ganancia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCentroCostosGam_Internalname, StringUtil.LTrim( StringUtil.NToC( A474CentroCostosGam, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosGam_Enabled!=0) ? context.localUtil.Format( A474CentroCostosGam, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A474CentroCostosGam, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosGam_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosGam_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosUsrAlta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCentroCostosUsrAlta_Internalname, context.GetMessage( "Usuario de Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCentroCostosUsrAlta_Internalname, StringUtil.RTrim( A478CentroCostosUsrAlta), StringUtil.RTrim( context.localUtil.Format( A478CentroCostosUsrAlta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosUsrAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosUsrAlta_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "Usuario", "start", true, "", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosUsrMod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCentroCostosUsrMod_Internalname, context.GetMessage( "Usuario de Modificiación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtCentroCostosUsrMod_Internalname, StringUtil.RTrim( A479CentroCostosUsrMod), StringUtil.RTrim( context.localUtil.Format( A479CentroCostosUsrMod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosUsrMod_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosUsrMod_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "Usuario", "start", true, "", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosHoraAlt_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCentroCostosHoraAlt_Internalname, context.GetMessage( "Hora de Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtCentroCostosHoraAlt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtCentroCostosHoraAlt_Internalname, context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"), context.localUtil.Format( A480CentroCostosHoraAlt, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosHoraAlt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosHoraAlt_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_bitmap( context, edtCentroCostosHoraAlt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCentroCostosHoraAlt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_CentroCostosGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosHoraMod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCentroCostosHoraMod_Internalname, context.GetMessage( "Hora de Modificiación", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtCentroCostosHoraMod_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtCentroCostosHoraMod_Internalname, context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"), context.localUtil.Format( A481CentroCostosHoraMod, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosHoraMod_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosHoraMod_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_bitmap( context, edtCentroCostosHoraMod_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCentroCostosHoraMod_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_CentroCostosGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbCentroCostosEstado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbCentroCostosEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbCentroCostosEstado, cmbCentroCostosEstado_Internalname, StringUtil.RTrim( A482CentroCostosEstado), 1, cmbCentroCostosEstado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbCentroCostosEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_CentroCostosGeneral.htm");
            cmbCentroCostosEstado.CurrentValue = StringUtil.RTrim( A482CentroCostosEstado);
            AssignProp(sPrefix, false, cmbCentroCostosEstado_Internalname, "Values", (string)(cmbCentroCostosEstado.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroCostosGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroCostosGeneral.htm");
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

      protected void START3T2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Centro Costos General", ""), 0) ;
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
               STRUP3T0( ) ;
            }
         }
      }

      protected void WS3T2( )
      {
         START3T2( ) ;
         EVT3T2( ) ;
      }

      protected void EVT3T2( )
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
                                 STRUP3T0( ) ;
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
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E113T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E123T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E133T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E143T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3T0( ) ;
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
                                 STRUP3T0( ) ;
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

      protected void WE3T2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3T2( ) ;
            }
         }
      }

      protected void PA3T2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "centrocostosgeneral.aspx")), "centrocostosgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "centrocostosgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "CentroCostosId");
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
         if ( cmbCentroCostosTipoRef.ItemCount > 0 )
         {
            A487CentroCostosTipoRef = cmbCentroCostosTipoRef.getValidValue(A487CentroCostosTipoRef);
            AssignAttri(sPrefix, false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCentroCostosTipoRef.CurrentValue = StringUtil.RTrim( A487CentroCostosTipoRef);
            AssignProp(sPrefix, false, cmbCentroCostosTipoRef_Internalname, "Values", cmbCentroCostosTipoRef.ToJavascriptSource(), true);
         }
         if ( cmbCentroCostosEstado.ItemCount > 0 )
         {
            A482CentroCostosEstado = cmbCentroCostosEstado.getValidValue(A482CentroCostosEstado);
            AssignAttri(sPrefix, false, "A482CentroCostosEstado", A482CentroCostosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCentroCostosEstado.CurrentValue = StringUtil.RTrim( A482CentroCostosEstado);
            AssignProp(sPrefix, false, cmbCentroCostosEstado_Internalname, "Values", cmbCentroCostosEstado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV14Pgmname = "CentroCostosGeneral";
      }

      protected void RF3T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H003T5 */
            pr_default.execute(1, new Object[] {A461CentroCostosId, A462CentroCostosRef});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A482CentroCostosEstado = H003T5_A482CentroCostosEstado[0];
               AssignAttri(sPrefix, false, "A482CentroCostosEstado", A482CentroCostosEstado);
               A481CentroCostosHoraMod = H003T5_A481CentroCostosHoraMod[0];
               AssignAttri(sPrefix, false, "A481CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
               A480CentroCostosHoraAlt = H003T5_A480CentroCostosHoraAlt[0];
               AssignAttri(sPrefix, false, "A480CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
               A479CentroCostosUsrMod = H003T5_A479CentroCostosUsrMod[0];
               AssignAttri(sPrefix, false, "A479CentroCostosUsrMod", A479CentroCostosUsrMod);
               A478CentroCostosUsrAlta = H003T5_A478CentroCostosUsrAlta[0];
               AssignAttri(sPrefix, false, "A478CentroCostosUsrAlta", A478CentroCostosUsrAlta);
               A463CentroCostosNombre = H003T5_A463CentroCostosNombre[0];
               AssignAttri(sPrefix, false, "A463CentroCostosNombre", A463CentroCostosNombre);
               A487CentroCostosTipoRef = H003T5_A487CentroCostosTipoRef[0];
               AssignAttri(sPrefix, false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
               A469CentroCostosSubTotal = H003T5_A469CentroCostosSubTotal[0];
               n469CentroCostosSubTotal = H003T5_n469CentroCostosSubTotal[0];
               AssignAttri(sPrefix, false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               A475CentroCostosCosto = H003T5_A475CentroCostosCosto[0];
               AssignAttri(sPrefix, false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
               A464CentroCostosPrecioFinal = H003T5_A464CentroCostosPrecioFinal[0];
               AssignAttri(sPrefix, false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
               A469CentroCostosSubTotal = H003T5_A469CentroCostosSubTotal[0];
               n469CentroCostosSubTotal = H003T5_n469CentroCostosSubTotal[0];
               AssignAttri(sPrefix, false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               A474CentroCostosGam = (decimal)(A464CentroCostosPrecioFinal-A475CentroCostosCosto);
               AssignAttri(sPrefix, false, "A474CentroCostosGam", StringUtil.LTrimStr( A474CentroCostosGam, 18, 2));
               /* Execute user event: Load */
               E123T2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB3T0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3T2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV14Pgmname = "CentroCostosGeneral";
         /* Using cursor H003T7 */
         pr_default.execute(2, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A469CentroCostosSubTotal = H003T7_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = H003T7_n469CentroCostosSubTotal[0];
            AssignAttri(sPrefix, false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         else
         {
            A469CentroCostosSubTotal = 0;
            n469CentroCostosSubTotal = false;
            AssignAttri(sPrefix, false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         pr_default.close(2);
         edtCentroCostosId_Enabled = 0;
         AssignProp(sPrefix, false, edtCentroCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosId_Enabled), 5, 0), true);
         cmbCentroCostosTipoRef.Enabled = 0;
         AssignProp(sPrefix, false, cmbCentroCostosTipoRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosTipoRef.Enabled), 5, 0), true);
         edtCentroCostosRef_Enabled = 0;
         AssignProp(sPrefix, false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
         edtCentroCostosNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
         edtCentroCostosPrecioFinal_Enabled = 0;
         AssignProp(sPrefix, false, edtCentroCostosPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Enabled), 5, 0), true);
         edtCentroCostosSubTotal_Enabled = 0;
         AssignProp(sPrefix, false, edtCentroCostosSubTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosSubTotal_Enabled), 5, 0), true);
         edtCentroCostosCosto_Enabled = 0;
         AssignProp(sPrefix, false, edtCentroCostosCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosCosto_Enabled), 5, 0), true);
         edtCentroCostosGam_Enabled = 0;
         AssignProp(sPrefix, false, edtCentroCostosGam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosGam_Enabled), 5, 0), true);
         edtCentroCostosUsrAlta_Enabled = 0;
         AssignProp(sPrefix, false, edtCentroCostosUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosUsrAlta_Enabled), 5, 0), true);
         edtCentroCostosUsrMod_Enabled = 0;
         AssignProp(sPrefix, false, edtCentroCostosUsrMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosUsrMod_Enabled), 5, 0), true);
         edtCentroCostosHoraAlt_Enabled = 0;
         AssignProp(sPrefix, false, edtCentroCostosHoraAlt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosHoraAlt_Enabled), 5, 0), true);
         edtCentroCostosHoraMod_Enabled = 0;
         AssignProp(sPrefix, false, edtCentroCostosHoraMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosHoraMod_Enabled), 5, 0), true);
         cmbCentroCostosEstado.Enabled = 0;
         AssignProp(sPrefix, false, cmbCentroCostosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosEstado.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113T2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA461CentroCostosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOA462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA462CentroCostosRef"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            cmbCentroCostosTipoRef.CurrentValue = cgiGet( cmbCentroCostosTipoRef_Internalname);
            A487CentroCostosTipoRef = cgiGet( cmbCentroCostosTipoRef_Internalname);
            AssignAttri(sPrefix, false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
            A463CentroCostosNombre = cgiGet( edtCentroCostosNombre_Internalname);
            AssignAttri(sPrefix, false, "A463CentroCostosNombre", A463CentroCostosNombre);
            A464CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( edtCentroCostosPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
            AV12NuevoItem = cgiGet( imgavNuevoitem_Internalname);
            A469CentroCostosSubTotal = context.localUtil.CToN( cgiGet( edtCentroCostosSubTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n469CentroCostosSubTotal = false;
            AssignAttri(sPrefix, false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            A475CentroCostosCosto = context.localUtil.CToN( cgiGet( edtCentroCostosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
            A474CentroCostosGam = context.localUtil.CToN( cgiGet( edtCentroCostosGam_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A474CentroCostosGam", StringUtil.LTrimStr( A474CentroCostosGam, 18, 2));
            A478CentroCostosUsrAlta = cgiGet( edtCentroCostosUsrAlta_Internalname);
            AssignAttri(sPrefix, false, "A478CentroCostosUsrAlta", A478CentroCostosUsrAlta);
            A479CentroCostosUsrMod = cgiGet( edtCentroCostosUsrMod_Internalname);
            AssignAttri(sPrefix, false, "A479CentroCostosUsrMod", A479CentroCostosUsrMod);
            A480CentroCostosHoraAlt = context.localUtil.CToD( cgiGet( edtCentroCostosHoraAlt_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri(sPrefix, false, "A480CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
            A481CentroCostosHoraMod = context.localUtil.CToD( cgiGet( edtCentroCostosHoraMod_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri(sPrefix, false, "A481CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
            cmbCentroCostosEstado.CurrentValue = cgiGet( cmbCentroCostosEstado_Internalname);
            A482CentroCostosEstado = cgiGet( cmbCentroCostosEstado_Internalname);
            AssignAttri(sPrefix, false, "A482CentroCostosEstado", A482CentroCostosEstado);
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
         E113T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E113T2( )
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

      protected void E123T2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV13TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Update", out  GXt_boolean1) ;
         AV13TempBoolean = GXt_boolean1;
         if ( ! ( AV13TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Delete", out  GXt_boolean1) ;
         AV13TempBoolean = GXt_boolean1;
         if ( ! ( AV13TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E133T2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "centrocostos.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0));
         CallWebObject(formatLink("centrocostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E143T2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "centrocostos.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0));
         CallWebObject(formatLink("centrocostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV14Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "CentroCostos";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A461CentroCostosId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
         A462CentroCostosRef = Convert.ToInt64(getParm(obj,1));
         AssignAttri(sPrefix, false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
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
         PA3T2( ) ;
         WS3T2( ) ;
         WE3T2( ) ;
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
         sCtrlA461CentroCostosId = (string)((string)getParm(obj,0));
         sCtrlA462CentroCostosRef = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3T2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "centrocostosgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3T2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A461CentroCostosId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
            A462CentroCostosRef = Convert.ToInt64(getParm(obj,3));
            AssignAttri(sPrefix, false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
         }
         wcpOA461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA461CentroCostosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOA462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA462CentroCostosRef"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A461CentroCostosId != wcpOA461CentroCostosId ) || ( A462CentroCostosRef != wcpOA462CentroCostosRef ) ) )
         {
            setjustcreated();
         }
         wcpOA461CentroCostosId = A461CentroCostosId;
         wcpOA462CentroCostosRef = A462CentroCostosRef;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA461CentroCostosId = cgiGet( sPrefix+"A461CentroCostosId_CTRL");
         if ( StringUtil.Len( sCtrlA461CentroCostosId) > 0 )
         {
            A461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA461CentroCostosId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
         }
         else
         {
            A461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A461CentroCostosId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlA462CentroCostosRef = cgiGet( sPrefix+"A462CentroCostosRef_CTRL");
         if ( StringUtil.Len( sCtrlA462CentroCostosRef) > 0 )
         {
            A462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA462CentroCostosRef), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
         }
         else
         {
            A462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A462CentroCostosRef_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA3T2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3T2( ) ;
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
         WS3T2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A461CentroCostosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA461CentroCostosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A461CentroCostosId_CTRL", StringUtil.RTrim( sCtrlA461CentroCostosId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A462CentroCostosRef_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA462CentroCostosRef)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A462CentroCostosRef_CTRL", StringUtil.RTrim( sCtrlA462CentroCostosRef));
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
         WE3T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302114626", true, true, false);
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
         context.AddJavascriptSource("centrocostosgeneral.js", "?20267302114626", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbCentroCostosTipoRef.Name = "CENTROCOSTOSTIPOREF";
         cmbCentroCostosTipoRef.WebTags = "";
         cmbCentroCostosTipoRef.addItem("S", context.GetMessage( "Servicios", ""), 0);
         cmbCentroCostosTipoRef.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbCentroCostosTipoRef.ItemCount > 0 )
         {
         }
         cmbCentroCostosEstado.Name = "CENTROCOSTOSESTADO";
         cmbCentroCostosEstado.WebTags = "";
         cmbCentroCostosEstado.addItem("HAB", context.GetMessage( "Aprobado", ""), 0);
         cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbCentroCostosEstado.addItem("PND", context.GetMessage( "Pendiente de Aprobación", ""), 0);
         cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Desaprobado", ""), 0);
         if ( cmbCentroCostosEstado.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtCentroCostosId_Internalname = sPrefix+"CENTROCOSTOSID";
         cmbCentroCostosTipoRef_Internalname = sPrefix+"CENTROCOSTOSTIPOREF";
         edtCentroCostosRef_Internalname = sPrefix+"CENTROCOSTOSREF";
         edtCentroCostosNombre_Internalname = sPrefix+"CENTROCOSTOSNOMBRE";
         edtCentroCostosPrecioFinal_Internalname = sPrefix+"CENTROCOSTOSPRECIOFINAL";
         imgavNuevoitem_Internalname = sPrefix+"vNUEVOITEM";
         edtCentroCostosSubTotal_Internalname = sPrefix+"CENTROCOSTOSSUBTOTAL";
         edtCentroCostosCosto_Internalname = sPrefix+"CENTROCOSTOSCOSTO";
         edtCentroCostosGam_Internalname = sPrefix+"CENTROCOSTOSGAM";
         edtCentroCostosUsrAlta_Internalname = sPrefix+"CENTROCOSTOSUSRALTA";
         edtCentroCostosUsrMod_Internalname = sPrefix+"CENTROCOSTOSUSRMOD";
         edtCentroCostosHoraAlt_Internalname = sPrefix+"CENTROCOSTOSHORAALT";
         edtCentroCostosHoraMod_Internalname = sPrefix+"CENTROCOSTOSHORAMOD";
         cmbCentroCostosEstado_Internalname = sPrefix+"CENTROCOSTOSESTADO";
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
         cmbCentroCostosEstado_Jsonclick = "";
         cmbCentroCostosEstado.Enabled = 0;
         edtCentroCostosHoraMod_Jsonclick = "";
         edtCentroCostosHoraMod_Enabled = 0;
         edtCentroCostosHoraAlt_Jsonclick = "";
         edtCentroCostosHoraAlt_Enabled = 0;
         edtCentroCostosUsrMod_Jsonclick = "";
         edtCentroCostosUsrMod_Enabled = 0;
         edtCentroCostosUsrAlta_Jsonclick = "";
         edtCentroCostosUsrAlta_Enabled = 0;
         edtCentroCostosGam_Jsonclick = "";
         edtCentroCostosGam_Enabled = 0;
         edtCentroCostosCosto_Jsonclick = "";
         edtCentroCostosCosto_Enabled = 0;
         edtCentroCostosSubTotal_Jsonclick = "";
         edtCentroCostosSubTotal_Enabled = 0;
         imgavNuevoitem_gximage = "";
         edtCentroCostosPrecioFinal_Jsonclick = "";
         edtCentroCostosPrecioFinal_Enabled = 0;
         edtCentroCostosNombre_Jsonclick = "";
         edtCentroCostosNombre_Enabled = 0;
         edtCentroCostosRef_Jsonclick = "";
         edtCentroCostosRef_Enabled = 0;
         cmbCentroCostosTipoRef_Jsonclick = "";
         cmbCentroCostosTipoRef.Enabled = 0;
         edtCentroCostosId_Jsonclick = "";
         edtCentroCostosId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A462CentroCostosRef',fld:'CENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E133T2',iparms:[{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E143T2',iparms:[{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSID","{handler:'Valid_Centrocostosid',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSID",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSPRECIOFINAL","{handler:'Valid_Centrocostospreciofinal',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSCOSTO","{handler:'Valid_Centrocostoscosto',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSCOSTO",",oparms:[]}");
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
         AV14Pgmname = "";
         H003T3_A469CentroCostosSubTotal = new decimal[1] ;
         H003T3_n469CentroCostosSubTotal = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         A487CentroCostosTipoRef = "";
         A463CentroCostosNombre = "";
         ClassString = "";
         StyleString = "";
         AV12NuevoItem = "";
         AV15Nuevoitem_GXI = "";
         sImgUrl = "";
         A478CentroCostosUsrAlta = "";
         A479CentroCostosUsrMod = "";
         A480CentroCostosHoraAlt = DateTime.MinValue;
         A481CentroCostosHoraMod = DateTime.MinValue;
         A482CentroCostosEstado = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H003T5_A461CentroCostosId = new long[1] ;
         H003T5_A462CentroCostosRef = new long[1] ;
         H003T5_A482CentroCostosEstado = new string[] {""} ;
         H003T5_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         H003T5_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         H003T5_A479CentroCostosUsrMod = new string[] {""} ;
         H003T5_A478CentroCostosUsrAlta = new string[] {""} ;
         H003T5_A463CentroCostosNombre = new string[] {""} ;
         H003T5_A487CentroCostosTipoRef = new string[] {""} ;
         H003T5_A469CentroCostosSubTotal = new decimal[1] ;
         H003T5_n469CentroCostosSubTotal = new bool[] {false} ;
         H003T5_A475CentroCostosCosto = new decimal[1] ;
         H003T5_A464CentroCostosPrecioFinal = new decimal[1] ;
         H003T7_A469CentroCostosSubTotal = new decimal[1] ;
         H003T7_n469CentroCostosSubTotal = new bool[] {false} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA461CentroCostosId = "";
         sCtrlA462CentroCostosRef = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.centrocostosgeneral__default(),
            new Object[][] {
                new Object[] {
               H003T3_A469CentroCostosSubTotal, H003T3_n469CentroCostosSubTotal
               }
               , new Object[] {
               H003T5_A461CentroCostosId, H003T5_A462CentroCostosRef, H003T5_A482CentroCostosEstado, H003T5_A481CentroCostosHoraMod, H003T5_A480CentroCostosHoraAlt, H003T5_A479CentroCostosUsrMod, H003T5_A478CentroCostosUsrAlta, H003T5_A463CentroCostosNombre, H003T5_A487CentroCostosTipoRef, H003T5_A469CentroCostosSubTotal,
               H003T5_n469CentroCostosSubTotal, H003T5_A475CentroCostosCosto, H003T5_A464CentroCostosPrecioFinal
               }
               , new Object[] {
               H003T7_A469CentroCostosSubTotal, H003T7_n469CentroCostosSubTotal
               }
            }
         );
         AV14Pgmname = "CentroCostosGeneral";
         /* GeneXus formulas. */
         AV14Pgmname = "CentroCostosGeneral";
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
      private int edtCentroCostosId_Enabled ;
      private int edtCentroCostosRef_Enabled ;
      private int edtCentroCostosNombre_Enabled ;
      private int edtCentroCostosPrecioFinal_Enabled ;
      private int edtCentroCostosSubTotal_Enabled ;
      private int edtCentroCostosCosto_Enabled ;
      private int edtCentroCostosGam_Enabled ;
      private int edtCentroCostosUsrAlta_Enabled ;
      private int edtCentroCostosUsrMod_Enabled ;
      private int edtCentroCostosHoraAlt_Enabled ;
      private int edtCentroCostosHoraMod_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int idxLst ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long wcpOA461CentroCostosId ;
      private long wcpOA462CentroCostosRef ;
      private decimal A469CentroCostosSubTotal ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A475CentroCostosCosto ;
      private decimal A474CentroCostosGam ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV14Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtCentroCostosId_Internalname ;
      private string TempTags ;
      private string edtCentroCostosId_Jsonclick ;
      private string cmbCentroCostosTipoRef_Internalname ;
      private string A487CentroCostosTipoRef ;
      private string cmbCentroCostosTipoRef_Jsonclick ;
      private string edtCentroCostosRef_Internalname ;
      private string edtCentroCostosRef_Jsonclick ;
      private string edtCentroCostosNombre_Internalname ;
      private string A463CentroCostosNombre ;
      private string edtCentroCostosNombre_Jsonclick ;
      private string edtCentroCostosPrecioFinal_Internalname ;
      private string edtCentroCostosPrecioFinal_Jsonclick ;
      private string imgavNuevoitem_Internalname ;
      private string ClassString ;
      private string imgavNuevoitem_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string edtCentroCostosSubTotal_Internalname ;
      private string edtCentroCostosSubTotal_Jsonclick ;
      private string edtCentroCostosCosto_Internalname ;
      private string edtCentroCostosCosto_Jsonclick ;
      private string edtCentroCostosGam_Internalname ;
      private string edtCentroCostosGam_Jsonclick ;
      private string edtCentroCostosUsrAlta_Internalname ;
      private string A478CentroCostosUsrAlta ;
      private string edtCentroCostosUsrAlta_Jsonclick ;
      private string edtCentroCostosUsrMod_Internalname ;
      private string A479CentroCostosUsrMod ;
      private string edtCentroCostosUsrMod_Jsonclick ;
      private string edtCentroCostosHoraAlt_Internalname ;
      private string edtCentroCostosHoraAlt_Jsonclick ;
      private string edtCentroCostosHoraMod_Internalname ;
      private string edtCentroCostosHoraMod_Jsonclick ;
      private string cmbCentroCostosEstado_Internalname ;
      private string A482CentroCostosEstado ;
      private string cmbCentroCostosEstado_Jsonclick ;
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
      private string sCtrlA461CentroCostosId ;
      private string sCtrlA462CentroCostosRef ;
      private DateTime A480CentroCostosHoraAlt ;
      private DateTime A481CentroCostosHoraMod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n469CentroCostosSubTotal ;
      private bool wbLoad ;
      private bool AV12NuevoItem_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV13TempBoolean ;
      private bool GXt_boolean1 ;
      private string AV15Nuevoitem_GXI ;
      private string AV12NuevoItem ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCentroCostosTipoRef ;
      private GXCombobox cmbCentroCostosEstado ;
      private IDataStoreProvider pr_default ;
      private decimal[] H003T3_A469CentroCostosSubTotal ;
      private bool[] H003T3_n469CentroCostosSubTotal ;
      private long[] H003T5_A461CentroCostosId ;
      private long[] H003T5_A462CentroCostosRef ;
      private string[] H003T5_A482CentroCostosEstado ;
      private DateTime[] H003T5_A481CentroCostosHoraMod ;
      private DateTime[] H003T5_A480CentroCostosHoraAlt ;
      private string[] H003T5_A479CentroCostosUsrMod ;
      private string[] H003T5_A478CentroCostosUsrAlta ;
      private string[] H003T5_A463CentroCostosNombre ;
      private string[] H003T5_A487CentroCostosTipoRef ;
      private decimal[] H003T5_A469CentroCostosSubTotal ;
      private bool[] H003T5_n469CentroCostosSubTotal ;
      private decimal[] H003T5_A475CentroCostosCosto ;
      private decimal[] H003T5_A464CentroCostosPrecioFinal ;
      private decimal[] H003T7_A469CentroCostosSubTotal ;
      private bool[] H003T7_n469CentroCostosSubTotal ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class centrocostosgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003T3;
          prmH003T3 = new Object[] {
          new ParDef("@CentroCostosId",GXType.Decimal,18,0)
          };
          Object[] prmH003T5;
          prmH003T5 = new Object[] {
          new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@CentroCostosRef",GXType.Decimal,18,0)
          };
          Object[] prmH003T7;
          prmH003T7 = new Object[] {
          new ParDef("@CentroCostosId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003T3", "SELECT COALESCE( T1.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T1 WHERE T1.[CentroCostosId] = @CentroCostosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H003T5", "SELECT T1.[CentroCostosId], T1.[CentroCostosRef], T1.[CentroCostosEstado], T1.[CentroCostosHoraMod], T1.[CentroCostosHoraAlt], T1.[CentroCostosUsrMod], T1.[CentroCostosUsrAlta], T1.[CentroCostosNombre], T1.[CentroCostosTipoRef], COALESCE( T2.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal, T1.[CentroCostosCosto], T1.[CentroCostosPrecioFinal] FROM ([CentroCostos] T1 LEFT JOIN (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) WHERE (T1.[CentroCostosId] = @CentroCostosId) AND (T1.[CentroCostosRef] = @CentroCostosRef) ORDER BY T1.[CentroCostosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H003T7", "SELECT COALESCE( T1.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T1 WHERE T1.[CentroCostosId] = @CentroCostosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T7,1, GxCacheFrequency.OFF ,true,true )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((string[]) buf[6])[0] = rslt.getString(7, 30);
                ((string[]) buf[7])[0] = rslt.getString(8, 80);
                ((string[]) buf[8])[0] = rslt.getString(9, 1);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
