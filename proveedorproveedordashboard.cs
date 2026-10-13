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
   public class proveedorproveedordashboard : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public proveedorproveedordashboard( )
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

      public proveedorproveedordashboard( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID )
      {
         this.A133ProveedorID = aP0_ProveedorID;
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
         cmbProveedorEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ProveedorID");
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
                  A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A133ProveedorID});
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
                  gxfirstwebparm = GetFirstPar( "ProveedorID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProveedorID");
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
            PA4V2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ProveedorProveedorDashboard";
               WS4V2( ) ;
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
            context.SendWebValue( context.GetMessage( "Proveedor Proveedor Dashboard", "")) ;
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
            GXEncryptionTmp = "proveedorproveedordashboard.aspx"+UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("proveedorproveedordashboard.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseForm4V2( )
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
         return "ProveedorProveedorDashboard" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Proveedor Proveedor Dashboard", "") ;
      }

      protected void WB4V0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "proveedorproveedordashboard.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_b1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorID_Internalname, context.GetMessage( "Código del Proveedor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProveedorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,17);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorRazonSocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorRazonSocial_Internalname, context.GetMessage( "Razón Social", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorRazonSocial_Internalname, StringUtil.RTrim( A682ProveedorRazonSocial), StringUtil.RTrim( context.localUtil.Format( A682ProveedorRazonSocial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorRazonSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorRazonSocial_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorTelefono_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorTelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A430ProveedorTelefono);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorTelefono_Internalname, StringUtil.RTrim( A430ProveedorTelefono), StringUtil.RTrim( context.localUtil.Format( A430ProveedorTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProveedorTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorDireccion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtProveedorDireccion_Internalname, A431ProveedorDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A431ProveedorDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", 0, 1, edtProveedorDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorEmail_Internalname, A433ProveedorEmail, StringUtil.RTrim( context.localUtil.Format( A433ProveedorEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A433ProveedorEmail, "", "", "", edtProveedorEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorContacto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorContacto_Internalname, context.GetMessage( "Nombre del Contacto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorContacto_Internalname, StringUtil.RTrim( A683ProveedorContacto), StringUtil.RTrim( context.localUtil.Format( A683ProveedorContacto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorContacto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorContacto_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorContactoCell_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorContactoCell_Internalname, context.GetMessage( "Número del Contacto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A684ProveedorContactoCell);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorContactoCell_Internalname, StringUtil.RTrim( A684ProveedorContactoCell), StringUtil.RTrim( context.localUtil.Format( A684ProveedorContactoCell, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProveedorContactoCell_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorContactoCell_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_b2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProveedorEstado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbProveedorEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbProveedorEstado, cmbProveedorEstado_Internalname, StringUtil.RTrim( A344ProveedorEstado), 1, cmbProveedorEstado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProveedorEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_ProveedorProveedorDashboard.htm");
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
            AssignProp(sPrefix, false, cmbProveedorEstado_Internalname, "Values", (string)(cmbProveedorEstado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProveedorImagen_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "AttributeFL";
            StyleString = "";
            A432ProveedorImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen));
            GxWebStd.gx_bitmap( context, imgProveedorImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A432ProveedorImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorCuentaBancaria_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProveedorCuentaBancaria_Internalname, context.GetMessage( "Cuenta Bancaria", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProveedorCuentaBancaria_Internalname, StringUtil.RTrim( A687ProveedorCuentaBancaria), StringUtil.RTrim( context.localUtil.Format( A687ProveedorCuentaBancaria, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorCuentaBancaria_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorCuentaBancaria_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "CuentaBancari", "start", true, "", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBancoNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtBancoNombre_Internalname, context.GetMessage( "Entidad Financiera", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtBancoNombre_Internalname, StringUtil.RTrim( A674BancoNombre), StringUtil.RTrim( context.localUtil.Format( A674BancoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtBancoNombre_Link, "", "", "", edtBancoNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtBancoNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorProveedorDashboard.htm");
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
            GxWebStd.gx_single_line_edit( context, edtProveedoresTipoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A151ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedoresTipoId_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedoresTipoId_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProveedorProveedorDashboard.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProveedoresTipoNombre_Internalname, StringUtil.RTrim( A278ProveedoresTipoNombre), StringUtil.RTrim( context.localUtil.Format( A278ProveedoresTipoNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedoresTipoNombre_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedoresTipoNombre_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProveedorProveedorDashboard.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProveedorDocIdentidad_Internalname, StringUtil.RTrim( A338ProveedorDocIdentidad), StringUtil.RTrim( context.localUtil.Format( A338ProveedorDocIdentidad, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorDocIdentidad_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedorDocIdentidad_Visible, 0, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProveedorProveedorDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4V2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Proveedor Proveedor Dashboard", ""), 0) ;
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
               STRUP4V0( ) ;
            }
         }
      }

      protected void WS4V2( )
      {
         START4V2( ) ;
         EVT4V2( ) ;
      }

      protected void EVT4V2( )
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
                                 STRUP4V0( ) ;
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
                                 STRUP4V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E114V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E124V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E134V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E144V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4V0( ) ;
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
                                 STRUP4V0( ) ;
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

      protected void WE4V2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4V2( ) ;
            }
         }
      }

      protected void PA4V2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "proveedorproveedordashboard.aspx")), "proveedorproveedordashboard.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "proveedorproveedordashboard.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ProveedorID");
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
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
            AssignAttri(sPrefix, false, "A344ProveedorEstado", A344ProveedorEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
            AssignProp(sPrefix, false, cmbProveedorEstado_Internalname, "Values", cmbProveedorEstado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ProveedorProveedorDashboard";
      }

      protected void RF4V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H004V2 */
            pr_default.execute(0, new Object[] {A133ProveedorID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A673BancoId = H004V2_A673BancoId[0];
               n673BancoId = H004V2_n673BancoId[0];
               A338ProveedorDocIdentidad = H004V2_A338ProveedorDocIdentidad[0];
               AssignAttri(sPrefix, false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
               A278ProveedoresTipoNombre = H004V2_A278ProveedoresTipoNombre[0];
               AssignAttri(sPrefix, false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
               A151ProveedoresTipoId = H004V2_A151ProveedoresTipoId[0];
               AssignAttri(sPrefix, false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
               A674BancoNombre = H004V2_A674BancoNombre[0];
               AssignAttri(sPrefix, false, "A674BancoNombre", A674BancoNombre);
               A687ProveedorCuentaBancaria = H004V2_A687ProveedorCuentaBancaria[0];
               n687ProveedorCuentaBancaria = H004V2_n687ProveedorCuentaBancaria[0];
               AssignAttri(sPrefix, false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
               A40000ProveedorImagen_GXI = H004V2_A40000ProveedorImagen_GXI[0];
               n40000ProveedorImagen_GXI = H004V2_n40000ProveedorImagen_GXI[0];
               AssignProp(sPrefix, false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
               AssignProp(sPrefix, false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
               A344ProveedorEstado = H004V2_A344ProveedorEstado[0];
               AssignAttri(sPrefix, false, "A344ProveedorEstado", A344ProveedorEstado);
               A684ProveedorContactoCell = H004V2_A684ProveedorContactoCell[0];
               n684ProveedorContactoCell = H004V2_n684ProveedorContactoCell[0];
               AssignAttri(sPrefix, false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
               A683ProveedorContacto = H004V2_A683ProveedorContacto[0];
               n683ProveedorContacto = H004V2_n683ProveedorContacto[0];
               AssignAttri(sPrefix, false, "A683ProveedorContacto", A683ProveedorContacto);
               A433ProveedorEmail = H004V2_A433ProveedorEmail[0];
               n433ProveedorEmail = H004V2_n433ProveedorEmail[0];
               AssignAttri(sPrefix, false, "A433ProveedorEmail", A433ProveedorEmail);
               A431ProveedorDireccion = H004V2_A431ProveedorDireccion[0];
               n431ProveedorDireccion = H004V2_n431ProveedorDireccion[0];
               AssignAttri(sPrefix, false, "A431ProveedorDireccion", A431ProveedorDireccion);
               A430ProveedorTelefono = H004V2_A430ProveedorTelefono[0];
               n430ProveedorTelefono = H004V2_n430ProveedorTelefono[0];
               AssignAttri(sPrefix, false, "A430ProveedorTelefono", A430ProveedorTelefono);
               A682ProveedorRazonSocial = H004V2_A682ProveedorRazonSocial[0];
               n682ProveedorRazonSocial = H004V2_n682ProveedorRazonSocial[0];
               AssignAttri(sPrefix, false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
               A282ProveedorNombre = H004V2_A282ProveedorNombre[0];
               AssignAttri(sPrefix, false, "A282ProveedorNombre", A282ProveedorNombre);
               A432ProveedorImagen = H004V2_A432ProveedorImagen[0];
               n432ProveedorImagen = H004V2_n432ProveedorImagen[0];
               AssignAttri(sPrefix, false, "A432ProveedorImagen", A432ProveedorImagen);
               AssignProp(sPrefix, false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
               AssignProp(sPrefix, false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
               A674BancoNombre = H004V2_A674BancoNombre[0];
               AssignAttri(sPrefix, false, "A674BancoNombre", A674BancoNombre);
               A278ProveedoresTipoNombre = H004V2_A278ProveedoresTipoNombre[0];
               AssignAttri(sPrefix, false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
               /* Execute user event: Load */
               E124V2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB4V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4V2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ProveedorProveedorDashboard";
         edtProveedorID_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         edtProveedorRazonSocial_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorRazonSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorRazonSocial_Enabled), 5, 0), true);
         edtProveedorTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorTelefono_Enabled), 5, 0), true);
         edtProveedorDireccion_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDireccion_Enabled), 5, 0), true);
         edtProveedorEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorEmail_Enabled), 5, 0), true);
         edtProveedorContacto_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorContacto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorContacto_Enabled), 5, 0), true);
         edtProveedorContactoCell_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorContactoCell_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorContactoCell_Enabled), 5, 0), true);
         cmbProveedorEstado.Enabled = 0;
         AssignProp(sPrefix, false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), true);
         imgProveedorImagen_Enabled = 0;
         AssignProp(sPrefix, false, imgProveedorImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProveedorImagen_Enabled), 5, 0), true);
         edtProveedorCuentaBancaria_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorCuentaBancaria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorCuentaBancaria_Enabled), 5, 0), true);
         edtBancoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtBancoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBancoNombre_Enabled), 5, 0), true);
         edtProveedoresTipoId_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedoresTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoId_Enabled), 5, 0), true);
         edtProveedoresTipoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedoresTipoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoNombre_Enabled), 5, 0), true);
         edtProveedorDocIdentidad_Enabled = 0;
         AssignProp(sPrefix, false, edtProveedorDocIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114V2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
            AssignAttri(sPrefix, false, "A282ProveedorNombre", A282ProveedorNombre);
            A682ProveedorRazonSocial = cgiGet( edtProveedorRazonSocial_Internalname);
            n682ProveedorRazonSocial = false;
            AssignAttri(sPrefix, false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
            A430ProveedorTelefono = cgiGet( edtProveedorTelefono_Internalname);
            n430ProveedorTelefono = false;
            AssignAttri(sPrefix, false, "A430ProveedorTelefono", A430ProveedorTelefono);
            A431ProveedorDireccion = cgiGet( edtProveedorDireccion_Internalname);
            n431ProveedorDireccion = false;
            AssignAttri(sPrefix, false, "A431ProveedorDireccion", A431ProveedorDireccion);
            A433ProveedorEmail = cgiGet( edtProveedorEmail_Internalname);
            n433ProveedorEmail = false;
            AssignAttri(sPrefix, false, "A433ProveedorEmail", A433ProveedorEmail);
            A683ProveedorContacto = cgiGet( edtProveedorContacto_Internalname);
            n683ProveedorContacto = false;
            AssignAttri(sPrefix, false, "A683ProveedorContacto", A683ProveedorContacto);
            A684ProveedorContactoCell = cgiGet( edtProveedorContactoCell_Internalname);
            n684ProveedorContactoCell = false;
            AssignAttri(sPrefix, false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
            cmbProveedorEstado.CurrentValue = cgiGet( cmbProveedorEstado_Internalname);
            A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
            AssignAttri(sPrefix, false, "A344ProveedorEstado", A344ProveedorEstado);
            A432ProveedorImagen = cgiGet( imgProveedorImagen_Internalname);
            n432ProveedorImagen = false;
            AssignAttri(sPrefix, false, "A432ProveedorImagen", A432ProveedorImagen);
            A687ProveedorCuentaBancaria = cgiGet( edtProveedorCuentaBancaria_Internalname);
            n687ProveedorCuentaBancaria = false;
            AssignAttri(sPrefix, false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
            A674BancoNombre = cgiGet( edtBancoNombre_Internalname);
            AssignAttri(sPrefix, false, "A674BancoNombre", A674BancoNombre);
            A151ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedoresTipoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            A278ProveedoresTipoNombre = cgiGet( edtProveedoresTipoNombre_Internalname);
            AssignAttri(sPrefix, false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
            A338ProveedorDocIdentidad = cgiGet( edtProveedorDocIdentidad_Internalname);
            AssignAttri(sPrefix, false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
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
         E114V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E114V2( )
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

      protected void E124V2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWBanco", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( AV12TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "bancoview.aspx"+UrlEncode(StringUtil.LTrimStr(A673BancoId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtBancoNombre_Link = formatLink("bancoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtBancoNombre_Internalname, "Link", edtBancoNombre_Link, true);
         }
         edtProveedoresTipoId_Visible = 0;
         AssignProp(sPrefix, false, edtProveedoresTipoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoId_Visible), 5, 0), true);
         edtProveedoresTipoNombre_Visible = 0;
         AssignProp(sPrefix, false, edtProveedoresTipoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedoresTipoNombre_Visible), 5, 0), true);
         edtProveedorDocIdentidad_Visible = 0;
         AssignProp(sPrefix, false, edtProveedorDocIdentidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorDocIdentidad_Visible), 5, 0), true);
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercio_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercio_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E134V2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "comercio.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
         CallWebObject(formatLink("comercio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E144V2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "comercio.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
         CallWebObject(formatLink("comercio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Transactionname = "Comercio";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A133ProveedorID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
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
         PA4V2( ) ;
         WS4V2( ) ;
         WE4V2( ) ;
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
         sCtrlA133ProveedorID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4V2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "proveedorproveedordashboard", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4V2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A133ProveedorID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
         wcpOA133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A133ProveedorID != wcpOA133ProveedorID ) ) )
         {
            setjustcreated();
         }
         wcpOA133ProveedorID = A133ProveedorID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA133ProveedorID = cgiGet( sPrefix+"A133ProveedorID_CTRL");
         if ( StringUtil.Len( sCtrlA133ProveedorID) > 0 )
         {
            A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA133ProveedorID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
         else
         {
            A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A133ProveedorID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA4V2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4V2( ) ;
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
         WS4V2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A133ProveedorID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA133ProveedorID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A133ProveedorID_CTRL", StringUtil.RTrim( sCtrlA133ProveedorID));
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
         WE4V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932033817", true, true, false);
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
         context.AddJavascriptSource("proveedorproveedordashboard.js", "?2026932033818", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbProveedorEstado.Name = "PROVEEDORESTADO";
         cmbProveedorEstado.WebTags = "";
         cmbProveedorEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbProveedorEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbProveedorEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbProveedorEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtProveedorID_Internalname = sPrefix+"PROVEEDORID";
         edtProveedorNombre_Internalname = sPrefix+"PROVEEDORNOMBRE";
         edtProveedorRazonSocial_Internalname = sPrefix+"PROVEEDORRAZONSOCIAL";
         edtProveedorTelefono_Internalname = sPrefix+"PROVEEDORTELEFONO";
         edtProveedorDireccion_Internalname = sPrefix+"PROVEEDORDIRECCION";
         edtProveedorEmail_Internalname = sPrefix+"PROVEEDOREMAIL";
         edtProveedorContacto_Internalname = sPrefix+"PROVEEDORCONTACTO";
         edtProveedorContactoCell_Internalname = sPrefix+"PROVEEDORCONTACTOCELL";
         divTransactiondetail_b1_Internalname = sPrefix+"TRANSACTIONDETAIL_B1";
         cmbProveedorEstado_Internalname = sPrefix+"PROVEEDORESTADO";
         imgProveedorImagen_Internalname = sPrefix+"PROVEEDORIMAGEN";
         edtProveedorCuentaBancaria_Internalname = sPrefix+"PROVEEDORCUENTABANCARIA";
         edtBancoNombre_Internalname = sPrefix+"BANCONOMBRE";
         divTransactiondetail_b2_Internalname = sPrefix+"TRANSACTIONDETAIL_B2";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtProveedoresTipoId_Internalname = sPrefix+"PROVEEDORESTIPOID";
         edtProveedoresTipoNombre_Internalname = sPrefix+"PROVEEDORESTIPONOMBRE";
         edtProveedorDocIdentidad_Internalname = sPrefix+"PROVEEDORDOCIDENTIDAD";
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
         edtProveedorDocIdentidad_Enabled = 0;
         edtProveedoresTipoNombre_Enabled = 0;
         edtProveedoresTipoId_Enabled = 0;
         imgProveedorImagen_Enabled = 0;
         edtProveedorDocIdentidad_Jsonclick = "";
         edtProveedorDocIdentidad_Visible = 1;
         edtProveedoresTipoNombre_Jsonclick = "";
         edtProveedoresTipoNombre_Visible = 1;
         edtProveedoresTipoId_Jsonclick = "";
         edtProveedoresTipoId_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtBancoNombre_Jsonclick = "";
         edtBancoNombre_Link = "";
         edtBancoNombre_Enabled = 0;
         edtProveedorCuentaBancaria_Jsonclick = "";
         edtProveedorCuentaBancaria_Enabled = 0;
         cmbProveedorEstado_Jsonclick = "";
         cmbProveedorEstado.Enabled = 0;
         edtProveedorContactoCell_Jsonclick = "";
         edtProveedorContactoCell_Enabled = 0;
         edtProveedorContacto_Jsonclick = "";
         edtProveedorContacto_Enabled = 0;
         edtProveedorEmail_Jsonclick = "";
         edtProveedorEmail_Enabled = 0;
         edtProveedorDireccion_Enabled = 0;
         edtProveedorTelefono_Jsonclick = "";
         edtProveedorTelefono_Enabled = 0;
         edtProveedorRazonSocial_Jsonclick = "";
         edtProveedorRazonSocial_Enabled = 0;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Jsonclick = "";
         edtProveedorID_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E134V2',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E144V2',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORESTIPOID","{handler:'Valid_Proveedorestipoid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORESTIPOID",",oparms:[]}");
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
         A282ProveedorNombre = "";
         A682ProveedorRazonSocial = "";
         gxphoneLink = "";
         A430ProveedorTelefono = "";
         ClassString = "";
         StyleString = "";
         A431ProveedorDireccion = "";
         A433ProveedorEmail = "";
         A683ProveedorContacto = "";
         A684ProveedorContactoCell = "";
         A344ProveedorEstado = "";
         A432ProveedorImagen = "";
         A40000ProveedorImagen_GXI = "";
         sImgUrl = "";
         A687ProveedorCuentaBancaria = "";
         A674BancoNombre = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A278ProveedoresTipoNombre = "";
         A338ProveedorDocIdentidad = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H004V2_A133ProveedorID = new long[1] ;
         H004V2_A673BancoId = new long[1] ;
         H004V2_n673BancoId = new bool[] {false} ;
         H004V2_A338ProveedorDocIdentidad = new string[] {""} ;
         H004V2_A278ProveedoresTipoNombre = new string[] {""} ;
         H004V2_A151ProveedoresTipoId = new long[1] ;
         H004V2_A674BancoNombre = new string[] {""} ;
         H004V2_A687ProveedorCuentaBancaria = new string[] {""} ;
         H004V2_n687ProveedorCuentaBancaria = new bool[] {false} ;
         H004V2_A40000ProveedorImagen_GXI = new string[] {""} ;
         H004V2_n40000ProveedorImagen_GXI = new bool[] {false} ;
         H004V2_A344ProveedorEstado = new string[] {""} ;
         H004V2_A684ProveedorContactoCell = new string[] {""} ;
         H004V2_n684ProveedorContactoCell = new bool[] {false} ;
         H004V2_A683ProveedorContacto = new string[] {""} ;
         H004V2_n683ProveedorContacto = new bool[] {false} ;
         H004V2_A433ProveedorEmail = new string[] {""} ;
         H004V2_n433ProveedorEmail = new bool[] {false} ;
         H004V2_A431ProveedorDireccion = new string[] {""} ;
         H004V2_n431ProveedorDireccion = new bool[] {false} ;
         H004V2_A430ProveedorTelefono = new string[] {""} ;
         H004V2_n430ProveedorTelefono = new bool[] {false} ;
         H004V2_A682ProveedorRazonSocial = new string[] {""} ;
         H004V2_n682ProveedorRazonSocial = new bool[] {false} ;
         H004V2_A282ProveedorNombre = new string[] {""} ;
         H004V2_A432ProveedorImagen = new string[] {""} ;
         H004V2_n432ProveedorImagen = new bool[] {false} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA133ProveedorID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedorproveedordashboard__default(),
            new Object[][] {
                new Object[] {
               H004V2_A133ProveedorID, H004V2_A673BancoId, H004V2_n673BancoId, H004V2_A338ProveedorDocIdentidad, H004V2_A278ProveedoresTipoNombre, H004V2_A151ProveedoresTipoId, H004V2_A674BancoNombre, H004V2_A687ProveedorCuentaBancaria, H004V2_n687ProveedorCuentaBancaria, H004V2_A40000ProveedorImagen_GXI,
               H004V2_n40000ProveedorImagen_GXI, H004V2_A344ProveedorEstado, H004V2_A684ProveedorContactoCell, H004V2_n684ProveedorContactoCell, H004V2_A683ProveedorContacto, H004V2_n683ProveedorContacto, H004V2_A433ProveedorEmail, H004V2_n433ProveedorEmail, H004V2_A431ProveedorDireccion, H004V2_n431ProveedorDireccion,
               H004V2_A430ProveedorTelefono, H004V2_n430ProveedorTelefono, H004V2_A682ProveedorRazonSocial, H004V2_n682ProveedorRazonSocial, H004V2_A282ProveedorNombre, H004V2_A432ProveedorImagen, H004V2_n432ProveedorImagen
               }
            }
         );
         AV13Pgmname = "ProveedorProveedorDashboard";
         /* GeneXus formulas. */
         AV13Pgmname = "ProveedorProveedorDashboard";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtProveedorRazonSocial_Enabled ;
      private int edtProveedorTelefono_Enabled ;
      private int edtProveedorDireccion_Enabled ;
      private int edtProveedorEmail_Enabled ;
      private int edtProveedorContacto_Enabled ;
      private int edtProveedorContactoCell_Enabled ;
      private int edtProveedorCuentaBancaria_Enabled ;
      private int edtBancoNombre_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtProveedoresTipoId_Visible ;
      private int edtProveedoresTipoNombre_Visible ;
      private int edtProveedorDocIdentidad_Visible ;
      private int imgProveedorImagen_Enabled ;
      private int edtProveedoresTipoId_Enabled ;
      private int edtProveedoresTipoNombre_Enabled ;
      private int edtProveedorDocIdentidad_Enabled ;
      private int idxLst ;
      private long A133ProveedorID ;
      private long wcpOA133ProveedorID ;
      private long A151ProveedoresTipoId ;
      private long A673BancoId ;
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
      private string divTransactiondetail_b1_Internalname ;
      private string edtProveedorID_Internalname ;
      private string TempTags ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtProveedorRazonSocial_Internalname ;
      private string A682ProveedorRazonSocial ;
      private string edtProveedorRazonSocial_Jsonclick ;
      private string edtProveedorTelefono_Internalname ;
      private string gxphoneLink ;
      private string A430ProveedorTelefono ;
      private string edtProveedorTelefono_Jsonclick ;
      private string edtProveedorDireccion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string edtProveedorEmail_Internalname ;
      private string edtProveedorEmail_Jsonclick ;
      private string edtProveedorContacto_Internalname ;
      private string A683ProveedorContacto ;
      private string edtProveedorContacto_Jsonclick ;
      private string edtProveedorContactoCell_Internalname ;
      private string A684ProveedorContactoCell ;
      private string edtProveedorContactoCell_Jsonclick ;
      private string divTransactiondetail_b2_Internalname ;
      private string cmbProveedorEstado_Internalname ;
      private string A344ProveedorEstado ;
      private string cmbProveedorEstado_Jsonclick ;
      private string imgProveedorImagen_Internalname ;
      private string sImgUrl ;
      private string edtProveedorCuentaBancaria_Internalname ;
      private string A687ProveedorCuentaBancaria ;
      private string edtProveedorCuentaBancaria_Jsonclick ;
      private string edtBancoNombre_Internalname ;
      private string A674BancoNombre ;
      private string edtBancoNombre_Link ;
      private string edtBancoNombre_Jsonclick ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtProveedoresTipoId_Internalname ;
      private string edtProveedoresTipoId_Jsonclick ;
      private string edtProveedoresTipoNombre_Internalname ;
      private string A278ProveedoresTipoNombre ;
      private string edtProveedoresTipoNombre_Jsonclick ;
      private string edtProveedorDocIdentidad_Internalname ;
      private string A338ProveedorDocIdentidad ;
      private string edtProveedorDocIdentidad_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlA133ProveedorID ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A432ProveedorImagen_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n673BancoId ;
      private bool n687ProveedorCuentaBancaria ;
      private bool n40000ProveedorImagen_GXI ;
      private bool n684ProveedorContactoCell ;
      private bool n683ProveedorContacto ;
      private bool n433ProveedorEmail ;
      private bool n431ProveedorDireccion ;
      private bool n430ProveedorTelefono ;
      private bool n682ProveedorRazonSocial ;
      private bool n432ProveedorImagen ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A431ProveedorDireccion ;
      private string A433ProveedorEmail ;
      private string A40000ProveedorImagen_GXI ;
      private string A432ProveedorImagen ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProveedorEstado ;
      private IDataStoreProvider pr_default ;
      private long[] H004V2_A133ProveedorID ;
      private long[] H004V2_A673BancoId ;
      private bool[] H004V2_n673BancoId ;
      private string[] H004V2_A338ProveedorDocIdentidad ;
      private string[] H004V2_A278ProveedoresTipoNombre ;
      private long[] H004V2_A151ProveedoresTipoId ;
      private string[] H004V2_A674BancoNombre ;
      private string[] H004V2_A687ProveedorCuentaBancaria ;
      private bool[] H004V2_n687ProveedorCuentaBancaria ;
      private string[] H004V2_A40000ProveedorImagen_GXI ;
      private bool[] H004V2_n40000ProveedorImagen_GXI ;
      private string[] H004V2_A344ProveedorEstado ;
      private string[] H004V2_A684ProveedorContactoCell ;
      private bool[] H004V2_n684ProveedorContactoCell ;
      private string[] H004V2_A683ProveedorContacto ;
      private bool[] H004V2_n683ProveedorContacto ;
      private string[] H004V2_A433ProveedorEmail ;
      private bool[] H004V2_n433ProveedorEmail ;
      private string[] H004V2_A431ProveedorDireccion ;
      private bool[] H004V2_n431ProveedorDireccion ;
      private string[] H004V2_A430ProveedorTelefono ;
      private bool[] H004V2_n430ProveedorTelefono ;
      private string[] H004V2_A682ProveedorRazonSocial ;
      private bool[] H004V2_n682ProveedorRazonSocial ;
      private string[] H004V2_A282ProveedorNombre ;
      private string[] H004V2_A432ProveedorImagen ;
      private bool[] H004V2_n432ProveedorImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class proveedorproveedordashboard__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004V2;
          prmH004V2 = new Object[] {
          new ParDef("@ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004V2", "SELECT T1.[ProveedorID], T1.[BancoId], T1.[ProveedorDocIdentidad], T3.[ProveedoresTipoNombre], T1.[ProveedoresTipoId], T2.[BancoNombre], T1.[ProveedorCuentaBancaria], T1.[ProveedorImagen_GXI], T1.[ProveedorEstado], T1.[ProveedorContactoCell], T1.[ProveedorContacto], T1.[ProveedorEmail], T1.[ProveedorDireccion], T1.[ProveedorTelefono], T1.[ProveedorRazonSocial], T1.[ProveedorNombre], T1.[ProveedorImagen] FROM (([Proveedor] T1 LEFT JOIN [Banco] T2 ON T2.[BancoId] = T1.[BancoId]) INNER JOIN [ProveedoresTipo] T3 ON T3.[ProveedoresTipoId] = T1.[ProveedoresTipoId]) WHERE T1.[ProveedorID] = @ProveedorID ORDER BY T1.[ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004V2,1, GxCacheFrequency.OFF ,true,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 25);
                ((string[]) buf[4])[0] = rslt.getString(4, 120);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((string[]) buf[7])[0] = rslt.getString(7, 50);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 3);
                ((string[]) buf[12])[0] = rslt.getString(10, 20);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 128);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getVarchar(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((string[]) buf[20])[0] = rslt.getString(14, 20);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((string[]) buf[22])[0] = rslt.getString(15, 25);
                ((bool[]) buf[23])[0] = rslt.wasNull(15);
                ((string[]) buf[24])[0] = rslt.getString(16, 80);
                ((string[]) buf[25])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(8));
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                return;
       }
    }

 }

}
