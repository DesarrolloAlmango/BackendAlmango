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
   public class parametromudanzaadicionalmudanzawc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public parametromudanzaadicionalmudanzawc( )
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

      public parametromudanzaadicionalmudanzawc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ItemAdicionalId )
      {
         this.A766ItemAdicionalId = aP0_ItemAdicionalId;
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
         radavOpcion1 = new GXRadio();
         dynTipoInmuebleOrigenId = new GXCombobox();
         dynTipoEstacionamOrigenId = new GXCombobox();
         radavOpcion11 = new GXRadio();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ItemAdicionalId");
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
                  A766ItemAdicionalId = (short)(Math.Round(NumberUtil.Val( GetPar( "ItemAdicionalId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A766ItemAdicionalId", StringUtil.LTrimStr( (decimal)(A766ItemAdicionalId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A766ItemAdicionalId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"TIPOINMUEBLEORIGENID") == 0 )
               {
                  AV13Opcion1 = GetPar( "Opcion1");
                  AssignAttri(sPrefix, false, "AV13Opcion1", AV13Opcion1);
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vOPCION1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV13Opcion1, "")), context));
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLATIPOINMUEBLEORIGENIDG02( AV13Opcion1) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"TIPOESTACIONAMORIGENID") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLATIPOESTACIONAMORIGENIDG02( ) ;
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
                  gxfirstwebparm = GetFirstPar( "ItemAdicionalId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ItemAdicionalId");
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
            PAG02( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV18Pgmname = "ParametroMudanzaAdicionalMudanzaWC";
               radavOpcion1.Enabled = 0;
               AssignProp(sPrefix, false, radavOpcion1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavOpcion1.Enabled), 5, 0), true);
               radavOpcion11.Enabled = 0;
               AssignProp(sPrefix, false, radavOpcion11_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavOpcion11.Enabled), 5, 0), true);
               GXATIPOESTACIONAMORIGENID_htmlG02( ) ;
               WSG02( ) ;
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
            context.SendWebValue( context.GetMessage( "Parametro Mudanza Adicional Mudanza WC", "")) ;
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
            GXEncryptionTmp = "parametromudanzaadicionalmudanzawc.aspx"+UrlEncode(StringUtil.LTrimStr(A766ItemAdicionalId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parametromudanzaadicionalmudanzawc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vOPCION1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV13Opcion1, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"MUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_MUDANZAID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14ProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROVEEDORID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14ProveedorId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSECUSERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV17SecUserId), "ZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ParametroMudanzaAdicionalMudanzaWC");
         forbiddenHiddens.Add("Opcion1", StringUtil.RTrim( context.localUtil.Format( AV13Opcion1, "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("parametromudanzaadicionalmudanzawc:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA766ItemAdicionalId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA766ItemAdicionalId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"MUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_MUDANZAID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14ProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROVEEDORID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14ProveedorId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSECUSERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV17SecUserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"ITEMADICIONALID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A766ItemAdicionalId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseFormG02( )
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
         return "ParametroMudanzaAdicionalMudanzaWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Parametro Mudanza Adicional Mudanza WC", "") ;
      }

      protected void WBG00( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "parametromudanzaadicionalmudanzawc.aspx");
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-canvas"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-canvas-cell"+" ", "position:absolute;z-index:0;display:inline-block;right:0px;left:0px;top:0px;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblock2_Internalname, context.GetMessage( "DIRECCIÓN DE ORIGEN", ""), "", "", lblTransactiondetail_textblock2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaAdicionalMudanzaWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMudanzaDireccionOrigen_Internalname, context.GetMessage( "Mudanza Direccion Origen", ""), "col-sm-3 AttributeFLLabel", 0, true, "");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtMudanzaDireccionOrigen_Internalname, A740MudanzaDireccionOrigen, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", 0, 1, edtMudanzaDireccionOrigen_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ParametroMudanzaAdicionalMudanzaWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 top16", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_canva1_Internalname, 1, 100, "%", divTransactiondetail_canva1_Height, "px", "Table", "start", "top", " "+"data-gx-canvas"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-canvas-cell"+" ", "position:absolute;z-index:0;display:inline-block;right:0px;left:0px;top:-20px;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Opcion1", ""), "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Radio button */
            ClassString = "AttributeFL";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavOpcion1, radavOpcion1_Internalname, StringUtil.RTrim( AV13Opcion1), "", 1, radavOpcion1.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radavOpcion1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "HLP_ParametroMudanzaAdicionalMudanzaWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 left70", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "PositionRelative", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 100, "%", divUnnamedtable5_Height, "px", "Table", "start", "top", " "+"data-gx-canvas"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-canvas-cell"+" ", "position:absolute;z-index:0;display:inline-block;right:0px;left:-60px;top:14px;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMudanzaPisoDptoOrigen_Internalname, context.GetMessage( "Mudanza Piso Dpto Origen", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtMudanzaPisoDptoOrigen_Internalname, StringUtil.RTrim( A777MudanzaPisoDptoOrigen), StringUtil.RTrim( context.localUtil.Format( A777MudanzaPisoDptoOrigen, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMudanzaPisoDptoOrigen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMudanzaPisoDptoOrigen_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ParametroMudanzaAdicionalMudanzaWC.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynTipoInmuebleOrigenId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynTipoInmuebleOrigenId_Internalname, context.GetMessage( "Tipo Inmueble", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynTipoInmuebleOrigenId, dynTipoInmuebleOrigenId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A743TipoInmuebleOrigenId), 4, 0)), 1, dynTipoInmuebleOrigenId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTipoInmuebleOrigenId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_ParametroMudanzaAdicionalMudanzaWC.htm");
            dynTipoInmuebleOrigenId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A743TipoInmuebleOrigenId), 4, 0));
            AssignProp(sPrefix, false, dynTipoInmuebleOrigenId_Internalname, "Values", (string)(dynTipoInmuebleOrigenId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-7 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynTipoEstacionamOrigenId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynTipoEstacionamOrigenId_Internalname, context.GetMessage( "¿Dónde estacionamos?", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynTipoEstacionamOrigenId, dynTipoEstacionamOrigenId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A747TipoEstacionamOrigenId), 4, 0)), 1, dynTipoEstacionamOrigenId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTipoEstacionamOrigenId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_ParametroMudanzaAdicionalMudanzaWC.htm");
            dynTipoEstacionamOrigenId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A747TipoEstacionamOrigenId), 4, 0));
            AssignProp(sPrefix, false, dynTipoEstacionamOrigenId_Internalname, "Values", (string)(dynTipoEstacionamOrigenId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableopcion1_Internalname, divTransactiondetail_tableopcion1_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCellFL", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Opcion11", ""), "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Radio button */
            ClassString = "AttributeFL";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavOpcion11, radavOpcion11_Internalname, StringUtil.RTrim( AV15Opcion11), "", 1, radavOpcion11.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radavOpcion11_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "HLP_ParametroMudanzaAdicionalMudanzaWC.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 7, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11g01_client"+"'", TempTags, "", 2, "HLP_ParametroMudanzaAdicionalMudanzaWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 7, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e12g01_client"+"'", TempTags, "", 2, "HLP_ParametroMudanzaAdicionalMudanzaWC.htm");
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
            GxWebStd.gx_single_line_edit( context, edtTipoInmuebleOrigenNombre_Internalname, A755TipoInmuebleOrigenNombre, StringUtil.RTrim( context.localUtil.Format( A755TipoInmuebleOrigenNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoInmuebleOrigenNombre_Jsonclick, 0, "Attribute", "", "", "", "", edtTipoInmuebleOrigenNombre_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "ParametroNombre", "start", true, "", "HLP_ParametroMudanzaAdicionalMudanzaWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTG02( )
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
            Form.Meta.addItem("description", context.GetMessage( "Parametro Mudanza Adicional Mudanza WC", ""), 0) ;
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
               STRUPG00( ) ;
            }
         }
      }

      protected void WSG02( )
      {
         STARTG02( ) ;
         EVTG02( ) ;
      }

      protected void EVTG02( )
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
                                 STRUPG00( ) ;
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
                                 STRUPG00( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13G02 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPG00( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14G02 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPG00( ) ;
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
                                 STRUPG00( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = radavOpcion1_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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

      protected void WEG02( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormG02( ) ;
            }
         }
      }

      protected void PAG02( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "parametromudanzaadicionalmudanzawc.aspx")), "parametromudanzaadicionalmudanzawc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "parametromudanzaadicionalmudanzawc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ItemAdicionalId");
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
               GX_FocusControl = radavOpcion1_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         GXATIPOINMUEBLEORIGENID_htmlG02( AV13Opcion1) ;
         /* End function dynload_actions */
      }

      protected void GXDLATIPOINMUEBLEORIGENIDG02( string AV13Opcion1 )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATIPOINMUEBLEORIGENID_dataG02( AV13Opcion1) ;
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

      protected void GXATIPOINMUEBLEORIGENID_htmlG02( string AV13Opcion1 )
      {
         short gxdynajaxvalue;
         GXDLATIPOINMUEBLEORIGENID_dataG02( AV13Opcion1) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynTipoInmuebleOrigenId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynTipoInmuebleOrigenId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLATIPOINMUEBLEORIGENID_dataG02( string AV13Opcion1 )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "Elegir...", ""));
         /* Using cursor H00G02 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            if ( StringUtil.StrCmp(H00G02_A731ParametroMudanzaTipo[0], ((StringUtil.StrCmp(AV13Opcion1, context.GetMessage( "Casa", ""))==0) ? "TipoInmuebleCasa" : "TipoInmuebleApto")) == 0 )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00G02_A730ParametroMudanzaId[0]), 4, 0, ".", "")));
               gxdynajaxctrldescr.Add(H00G02_A732ParametroMudanzaNombre[0]);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLATIPOESTACIONAMORIGENIDG02( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATIPOESTACIONAMORIGENID_dataG02( ) ;
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

      protected void GXATIPOESTACIONAMORIGENID_htmlG02( )
      {
         short gxdynajaxvalue;
         GXDLATIPOESTACIONAMORIGENID_dataG02( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynTipoEstacionamOrigenId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynTipoEstacionamOrigenId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLATIPOESTACIONAMORIGENID_dataG02( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "Elegir...", ""));
         /* Using cursor H00G03 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00G03_A747TipoEstacionamOrigenId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00G03_A748TipoEstacionamOrigenNombre[0]);
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
            GXATIPOINMUEBLEORIGENID_htmlG02( AV13Opcion1) ;
            GXATIPOESTACIONAMORIGENID_htmlG02( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         AssignAttri(sPrefix, false, "AV13Opcion1", AV13Opcion1);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vOPCION1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV13Opcion1, "")), context));
         if ( dynTipoInmuebleOrigenId.ItemCount > 0 )
         {
            A743TipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( dynTipoInmuebleOrigenId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A743TipoInmuebleOrigenId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A743TipoInmuebleOrigenId", StringUtil.LTrimStr( (decimal)(A743TipoInmuebleOrigenId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTipoInmuebleOrigenId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A743TipoInmuebleOrigenId), 4, 0));
            AssignProp(sPrefix, false, dynTipoInmuebleOrigenId_Internalname, "Values", dynTipoInmuebleOrigenId.ToJavascriptSource(), true);
         }
         if ( dynTipoEstacionamOrigenId.ItemCount > 0 )
         {
            A747TipoEstacionamOrigenId = (short)(Math.Round(NumberUtil.Val( dynTipoEstacionamOrigenId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A747TipoEstacionamOrigenId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A747TipoEstacionamOrigenId", StringUtil.LTrimStr( (decimal)(A747TipoEstacionamOrigenId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTipoEstacionamOrigenId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A747TipoEstacionamOrigenId), 4, 0));
            AssignProp(sPrefix, false, dynTipoEstacionamOrigenId_Internalname, "Values", dynTipoEstacionamOrigenId.ToJavascriptSource(), true);
         }
         AssignAttri(sPrefix, false, "AV15Opcion11", AV15Opcion11);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFG02( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV18Pgmname = "ParametroMudanzaAdicionalMudanzaWC";
         radavOpcion1.Enabled = 0;
         AssignProp(sPrefix, false, radavOpcion1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavOpcion1.Enabled), 5, 0), true);
         radavOpcion11.Enabled = 0;
         AssignProp(sPrefix, false, radavOpcion11_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavOpcion11.Enabled), 5, 0), true);
      }

      protected void RFG02( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00G04 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               A735MudanzaId = H00G04_A735MudanzaId[0];
               A755TipoInmuebleOrigenNombre = H00G04_A755TipoInmuebleOrigenNombre[0];
               AssignAttri(sPrefix, false, "A755TipoInmuebleOrigenNombre", A755TipoInmuebleOrigenNombre);
               A747TipoEstacionamOrigenId = H00G04_A747TipoEstacionamOrigenId[0];
               AssignAttri(sPrefix, false, "A747TipoEstacionamOrigenId", StringUtil.LTrimStr( (decimal)(A747TipoEstacionamOrigenId), 4, 0));
               A743TipoInmuebleOrigenId = H00G04_A743TipoInmuebleOrigenId[0];
               AssignAttri(sPrefix, false, "A743TipoInmuebleOrigenId", StringUtil.LTrimStr( (decimal)(A743TipoInmuebleOrigenId), 4, 0));
               A777MudanzaPisoDptoOrigen = H00G04_A777MudanzaPisoDptoOrigen[0];
               AssignAttri(sPrefix, false, "A777MudanzaPisoDptoOrigen", A777MudanzaPisoDptoOrigen);
               A740MudanzaDireccionOrigen = H00G04_A740MudanzaDireccionOrigen[0];
               AssignAttri(sPrefix, false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
               A755TipoInmuebleOrigenNombre = H00G04_A755TipoInmuebleOrigenNombre[0];
               AssignAttri(sPrefix, false, "A755TipoInmuebleOrigenNombre", A755TipoInmuebleOrigenNombre);
               GXATIPOESTACIONAMORIGENID_htmlG02( ) ;
               GXATIPOINMUEBLEORIGENID_htmlG02( AV13Opcion1) ;
               /* Execute user event: Load */
               E14G02 ();
               pr_default.readNext(2);
            }
            pr_default.close(2);
            WBG00( ) ;
         }
      }

      protected void send_integrity_lvl_hashesG02( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vOPCION1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV13Opcion1, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"MUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A735MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_MUDANZAID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14ProveedorId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROVEEDORID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV14ProveedorId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSECUSERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV17SecUserId), "ZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         AV18Pgmname = "ParametroMudanzaAdicionalMudanzaWC";
         radavOpcion1.Enabled = 0;
         AssignProp(sPrefix, false, radavOpcion1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavOpcion1.Enabled), 5, 0), true);
         radavOpcion11.Enabled = 0;
         AssignProp(sPrefix, false, radavOpcion11_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavOpcion11.Enabled), 5, 0), true);
         GXATIPOESTACIONAMORIGENID_htmlG02( ) ;
         edtMudanzaDireccionOrigen_Enabled = 0;
         AssignProp(sPrefix, false, edtMudanzaDireccionOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMudanzaDireccionOrigen_Enabled), 5, 0), true);
         edtMudanzaPisoDptoOrigen_Enabled = 0;
         AssignProp(sPrefix, false, edtMudanzaPisoDptoOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMudanzaPisoDptoOrigen_Enabled), 5, 0), true);
         dynTipoInmuebleOrigenId.Enabled = 0;
         AssignProp(sPrefix, false, dynTipoInmuebleOrigenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipoInmuebleOrigenId.Enabled), 5, 0), true);
         dynTipoEstacionamOrigenId.Enabled = 0;
         AssignProp(sPrefix, false, dynTipoEstacionamOrigenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipoEstacionamOrigenId.Enabled), 5, 0), true);
         edtTipoInmuebleOrigenNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtTipoInmuebleOrigenNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoInmuebleOrigenNombre_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPG00( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13G02 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA766ItemAdicionalId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA766ItemAdicionalId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV17SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vSECUSERID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV14ProveedorId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A735MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"MUDANZAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A740MudanzaDireccionOrigen = cgiGet( edtMudanzaDireccionOrigen_Internalname);
            AssignAttri(sPrefix, false, "A740MudanzaDireccionOrigen", A740MudanzaDireccionOrigen);
            AV13Opcion1 = cgiGet( radavOpcion1_Internalname);
            AssignAttri(sPrefix, false, "AV13Opcion1", AV13Opcion1);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vOPCION1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV13Opcion1, "")), context));
            A777MudanzaPisoDptoOrigen = cgiGet( edtMudanzaPisoDptoOrigen_Internalname);
            AssignAttri(sPrefix, false, "A777MudanzaPisoDptoOrigen", A777MudanzaPisoDptoOrigen);
            dynTipoInmuebleOrigenId.CurrentValue = cgiGet( dynTipoInmuebleOrigenId_Internalname);
            A743TipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynTipoInmuebleOrigenId_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A743TipoInmuebleOrigenId", StringUtil.LTrimStr( (decimal)(A743TipoInmuebleOrigenId), 4, 0));
            dynTipoEstacionamOrigenId.CurrentValue = cgiGet( dynTipoEstacionamOrigenId_Internalname);
            A747TipoEstacionamOrigenId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynTipoEstacionamOrigenId_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A747TipoEstacionamOrigenId", StringUtil.LTrimStr( (decimal)(A747TipoEstacionamOrigenId), 4, 0));
            AV15Opcion11 = cgiGet( radavOpcion11_Internalname);
            AssignAttri(sPrefix, false, "AV15Opcion11", AV15Opcion11);
            A755TipoInmuebleOrigenNombre = cgiGet( edtTipoInmuebleOrigenNombre_Internalname);
            AssignAttri(sPrefix, false, "A755TipoInmuebleOrigenNombre", A755TipoInmuebleOrigenNombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ParametroMudanzaAdicionalMudanzaWC");
            AV13Opcion1 = cgiGet( radavOpcion1_Internalname);
            AssignAttri(sPrefix, false, "AV13Opcion1", AV13Opcion1);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vOPCION1", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV13Opcion1, "")), context));
            forbiddenHiddens.Add("Opcion1", StringUtil.RTrim( context.localUtil.Format( AV13Opcion1, "")));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("parametromudanzaadicionalmudanzawc:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            GXATIPOESTACIONAMORIGENID_htmlG02( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13G02 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13G02( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         divUnnamedtable5_Height = 50;
         AssignProp(sPrefix, false, divUnnamedtable5_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divUnnamedtable5_Height), 9, 0), true);
         divTransactiondetail_canva1_Height = 40;
         AssignProp(sPrefix, false, divTransactiondetail_canva1_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTransactiondetail_canva1_Height), 9, 0), true);
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

      protected void E14G02( )
      {
         /* Load Routine */
         returnInSub = false;
         edtTipoInmuebleOrigenNombre_Visible = 0;
         AssignProp(sPrefix, false, edtTipoInmuebleOrigenNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipoInmuebleOrigenNombre_Visible), 5, 0), true);
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         divTransactiondetail_tableopcion1_Visible = (((StringUtil.StrCmp(AV13Opcion1, context.GetMessage( "Apto", ""))==0)&&(StringUtil.StrCmp(A755TipoInmuebleOrigenNombre, context.GetMessage( "Planta Baja", ""))!=0)&&!String.IsNullOrEmpty(StringUtil.RTrim( A755TipoInmuebleOrigenNombre))) ? 1 : 0);
         AssignProp(sPrefix, false, divTransactiondetail_tableopcion1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTransactiondetail_tableopcion1_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV18Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Mudanza";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A766ItemAdicionalId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A766ItemAdicionalId", StringUtil.LTrimStr( (decimal)(A766ItemAdicionalId), 4, 0));
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
         PAG02( ) ;
         WSG02( ) ;
         WEG02( ) ;
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
         sCtrlA766ItemAdicionalId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAG02( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "parametromudanzaadicionalmudanzawc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAG02( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A766ItemAdicionalId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A766ItemAdicionalId", StringUtil.LTrimStr( (decimal)(A766ItemAdicionalId), 4, 0));
         }
         wcpOA766ItemAdicionalId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA766ItemAdicionalId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A766ItemAdicionalId != wcpOA766ItemAdicionalId ) ) )
         {
            setjustcreated();
         }
         wcpOA766ItemAdicionalId = A766ItemAdicionalId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA766ItemAdicionalId = cgiGet( sPrefix+"A766ItemAdicionalId_CTRL");
         if ( StringUtil.Len( sCtrlA766ItemAdicionalId) > 0 )
         {
            A766ItemAdicionalId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA766ItemAdicionalId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A766ItemAdicionalId", StringUtil.LTrimStr( (decimal)(A766ItemAdicionalId), 4, 0));
         }
         else
         {
            A766ItemAdicionalId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A766ItemAdicionalId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PAG02( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSG02( ) ;
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
         WSG02( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A766ItemAdicionalId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A766ItemAdicionalId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA766ItemAdicionalId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A766ItemAdicionalId_CTRL", StringUtil.RTrim( sCtrlA766ItemAdicionalId));
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
         WEG02( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20268622495619", true, true, false);
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
         context.AddJavascriptSource("parametromudanzaadicionalmudanzawc.js", "?20268622495620", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         radavOpcion1.Name = "vOPCION1";
         radavOpcion1.WebTags = "";
         radavOpcion1.addItem("Casa", context.GetMessage( "Casa", ""), 0);
         radavOpcion1.addItem("Apto", context.GetMessage( "Apartamento", ""), 0);
         dynTipoInmuebleOrigenId.Name = "TIPOINMUEBLEORIGENID";
         dynTipoInmuebleOrigenId.WebTags = "";
         dynTipoEstacionamOrigenId.Name = "TIPOESTACIONAMORIGENID";
         dynTipoEstacionamOrigenId.WebTags = "";
         radavOpcion11.Name = "vOPCION11";
         radavOpcion11.WebTags = "";
         radavOpcion11.addItem("Escalera", context.GetMessage( "Escalera", ""), 0);
         radavOpcion11.addItem("Ascensor", context.GetMessage( "Ascensor", ""), 0);
         radavOpcion11.addItem("EscaAsce", context.GetMessage( "Escalera + Ascensor", ""), 0);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTransactiondetail_textblock2_Internalname = sPrefix+"TRANSACTIONDETAIL_TEXTBLOCK2";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         edtMudanzaDireccionOrigen_Internalname = sPrefix+"MUDANZADIRECCIONORIGEN";
         radavOpcion1_Internalname = sPrefix+"vOPCION1";
         divTransactiondetail_canva1_Internalname = sPrefix+"TRANSACTIONDETAIL_CANVA1";
         edtMudanzaPisoDptoOrigen_Internalname = sPrefix+"MUDANZAPISODPTOORIGEN";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         divUnnamedtable4_Internalname = sPrefix+"UNNAMEDTABLE4";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         dynTipoInmuebleOrigenId_Internalname = sPrefix+"TIPOINMUEBLEORIGENID";
         dynTipoEstacionamOrigenId_Internalname = sPrefix+"TIPOESTACIONAMORIGENID";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         radavOpcion11_Internalname = sPrefix+"vOPCION11";
         divTransactiondetail_tableopcion1_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEOPCION1";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtTipoInmuebleOrigenNombre_Internalname = sPrefix+"TIPOINMUEBLEORIGENNOMBRE";
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
         edtTipoInmuebleOrigenNombre_Enabled = 0;
         edtTipoInmuebleOrigenNombre_Jsonclick = "";
         edtTipoInmuebleOrigenNombre_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         radavOpcion11_Jsonclick = "";
         radavOpcion11.Enabled = 1;
         divTransactiondetail_tableopcion1_Visible = 1;
         dynTipoEstacionamOrigenId_Jsonclick = "";
         dynTipoEstacionamOrigenId.Enabled = 0;
         dynTipoInmuebleOrigenId_Jsonclick = "";
         dynTipoInmuebleOrigenId.Enabled = 0;
         edtMudanzaPisoDptoOrigen_Jsonclick = "";
         edtMudanzaPisoDptoOrigen_Enabled = 0;
         divUnnamedtable5_Height = 50;
         radavOpcion1_Jsonclick = "";
         radavOpcion1.Enabled = 1;
         divTransactiondetail_canva1_Height = 40;
         edtMudanzaDireccionOrigen_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public void Validv_Opcion1( )
      {
         A743TipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( dynTipoInmuebleOrigenId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A747TipoEstacionamOrigenId = (short)(Math.Round(NumberUtil.Val( dynTipoEstacionamOrigenId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         GXATIPOINMUEBLEORIGENID_htmlG02( AV13Opcion1) ;
         dynload_actions( ) ;
         if ( dynTipoInmuebleOrigenId.ItemCount > 0 )
         {
            A743TipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( dynTipoInmuebleOrigenId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A743TipoInmuebleOrigenId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTipoInmuebleOrigenId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A743TipoInmuebleOrigenId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A743TipoInmuebleOrigenId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A743TipoInmuebleOrigenId), 4, 0, ".", "")));
         dynTipoInmuebleOrigenId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A743TipoInmuebleOrigenId), 4, 0));
         AssignProp(sPrefix, false, dynTipoInmuebleOrigenId_Internalname, "Values", dynTipoInmuebleOrigenId.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynTipoInmuebleOrigenId'},{av:'A743TipoInmuebleOrigenId',fld:'TIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'dynTipoEstacionamOrigenId'},{av:'A747TipoEstacionamOrigenId',fld:'TIPOESTACIONAMORIGENID',pic:'ZZZ9',type:'int'},{av:'radavOpcion11'},{av:'AV15Opcion11',fld:'vOPCION11',pic:'',type:'svchar'},{av:'AV14ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV17SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'radavOpcion1'},{av:'AV13Opcion1',fld:'vOPCION1',pic:'',hsh:true,type:'svchar'},{av:'A735MudanzaId',fld:'MUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E11G01',iparms:[{av:'A735MudanzaId',fld:'MUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV14ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV17SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E12G01',iparms:[{av:'A735MudanzaId',fld:'MUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV14ProveedorId',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV17SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALIDV_OPCION1","{handler:'Validv_Opcion1',iparms:[{av:'radavOpcion1'},{av:'AV13Opcion1',fld:'vOPCION1',pic:'',hsh:true,type:'svchar'},{av:'dynTipoInmuebleOrigenId'},{av:'A743TipoInmuebleOrigenId',fld:'TIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'},{av:'dynTipoEstacionamOrigenId'},{av:'A747TipoEstacionamOrigenId',fld:'TIPOESTACIONAMORIGENID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALIDV_OPCION1",",oparms:[{av:'dynTipoInmuebleOrigenId'},{av:'A743TipoInmuebleOrigenId',fld:'TIPOINMUEBLEORIGENID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_TIPOINMUEBLEORIGENID","{handler:'Valid_Tipoinmuebleorigenid',iparms:[]");
         setEventMetadata("VALID_TIPOINMUEBLEORIGENID",",oparms:[]}");
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
         AV13Opcion1 = "";
         AV18Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         lblTransactiondetail_textblock2_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         A740MudanzaDireccionOrigen = "";
         A777MudanzaPisoDptoOrigen = "";
         AV15Opcion11 = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A755TipoInmuebleOrigenNombre = "";
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
         H00G02_A730ParametroMudanzaId = new short[1] ;
         H00G02_A732ParametroMudanzaNombre = new string[] {""} ;
         H00G02_A731ParametroMudanzaTipo = new string[] {""} ;
         H00G02_n731ParametroMudanzaTipo = new bool[] {false} ;
         H00G03_A747TipoEstacionamOrigenId = new short[1] ;
         H00G03_A748TipoEstacionamOrigenNombre = new string[] {""} ;
         H00G03_A731ParametroMudanzaTipo = new string[] {""} ;
         H00G03_n731ParametroMudanzaTipo = new bool[] {false} ;
         H00G04_A735MudanzaId = new long[1] ;
         H00G04_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         H00G04_A747TipoEstacionamOrigenId = new short[1] ;
         H00G04_A743TipoInmuebleOrigenId = new short[1] ;
         H00G04_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         H00G04_A740MudanzaDireccionOrigen = new string[] {""} ;
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA766ItemAdicionalId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametromudanzaadicionalmudanzawc__default(),
            new Object[][] {
                new Object[] {
               H00G02_A730ParametroMudanzaId, H00G02_A732ParametroMudanzaNombre, H00G02_A731ParametroMudanzaTipo
               }
               , new Object[] {
               H00G03_A747TipoEstacionamOrigenId, H00G03_A748TipoEstacionamOrigenNombre, H00G03_A731ParametroMudanzaTipo, H00G03_n731ParametroMudanzaTipo
               }
               , new Object[] {
               H00G04_A735MudanzaId, H00G04_A755TipoInmuebleOrigenNombre, H00G04_A747TipoEstacionamOrigenId, H00G04_A743TipoInmuebleOrigenId, H00G04_A777MudanzaPisoDptoOrigen, H00G04_A740MudanzaDireccionOrigen
               }
            }
         );
         AV18Pgmname = "ParametroMudanzaAdicionalMudanzaWC";
         /* GeneXus formulas. */
         AV18Pgmname = "ParametroMudanzaAdicionalMudanzaWC";
         radavOpcion1.Enabled = 0;
         radavOpcion11.Enabled = 0;
      }

      private short A766ItemAdicionalId ;
      private short wcpOA766ItemAdicionalId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A743TipoInmuebleOrigenId ;
      private short A747TipoEstacionamOrigenId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private short Z743TipoInmuebleOrigenId ;
      private int edtMudanzaDireccionOrigen_Enabled ;
      private int divTransactiondetail_canva1_Height ;
      private int divUnnamedtable5_Height ;
      private int edtMudanzaPisoDptoOrigen_Enabled ;
      private int divTransactiondetail_tableopcion1_Visible ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtTipoInmuebleOrigenNombre_Visible ;
      private int gxdynajaxindex ;
      private int edtTipoInmuebleOrigenNombre_Enabled ;
      private int idxLst ;
      private long A735MudanzaId ;
      private long AV14ProveedorId ;
      private long AV17SecUserId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV18Pgmname ;
      private string radavOpcion1_Internalname ;
      private string radavOpcion11_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string lblTransactiondetail_textblock2_Internalname ;
      private string lblTransactiondetail_textblock2_Jsonclick ;
      private string edtMudanzaDireccionOrigen_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string divUnnamedtable2_Internalname ;
      private string divTransactiondetail_canva1_Internalname ;
      private string radavOpcion1_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string edtMudanzaPisoDptoOrigen_Internalname ;
      private string A777MudanzaPisoDptoOrigen ;
      private string edtMudanzaPisoDptoOrigen_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string dynTipoInmuebleOrigenId_Internalname ;
      private string dynTipoInmuebleOrigenId_Jsonclick ;
      private string dynTipoEstacionamOrigenId_Internalname ;
      private string dynTipoEstacionamOrigenId_Jsonclick ;
      private string divTransactiondetail_tableopcion1_Internalname ;
      private string radavOpcion11_Jsonclick ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTipoInmuebleOrigenNombre_Internalname ;
      private string edtTipoInmuebleOrigenNombre_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string hsh ;
      private string sCtrlA766ItemAdicionalId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string AV13Opcion1 ;
      private string A740MudanzaDireccionOrigen ;
      private string AV15Opcion11 ;
      private string A755TipoInmuebleOrigenNombre ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXRadio radavOpcion1 ;
      private GXCombobox dynTipoInmuebleOrigenId ;
      private GXCombobox dynTipoEstacionamOrigenId ;
      private GXRadio radavOpcion11 ;
      private IDataStoreProvider pr_default ;
      private short[] H00G02_A730ParametroMudanzaId ;
      private string[] H00G02_A732ParametroMudanzaNombre ;
      private string[] H00G02_A731ParametroMudanzaTipo ;
      private bool[] H00G02_n731ParametroMudanzaTipo ;
      private short[] H00G03_A747TipoEstacionamOrigenId ;
      private string[] H00G03_A748TipoEstacionamOrigenNombre ;
      private string[] H00G03_A731ParametroMudanzaTipo ;
      private bool[] H00G03_n731ParametroMudanzaTipo ;
      private long[] H00G04_A735MudanzaId ;
      private string[] H00G04_A755TipoInmuebleOrigenNombre ;
      private short[] H00G04_A747TipoEstacionamOrigenId ;
      private short[] H00G04_A743TipoInmuebleOrigenId ;
      private string[] H00G04_A777MudanzaPisoDptoOrigen ;
      private string[] H00G04_A740MudanzaDireccionOrigen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class parametromudanzaadicionalmudanzawc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00G02;
          prmH00G02 = new Object[] {
          };
          Object[] prmH00G03;
          prmH00G03 = new Object[] {
          };
          Object[] prmH00G04;
          prmH00G04 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00G02", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaTipo] FROM [ParametroMudanza] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00G02,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00G03", "SELECT [ParametroMudanzaId] AS TipoEstacionamOrigenId, [ParametroMudanzaNombre] AS TipoEstacionamOrigenNombre, [ParametroMudanzaTipo] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'TipoEstacionamiento' ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00G03,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00G04", "SELECT T1.[MudanzaId], T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T1.[TipoEstacionamOrigenId] AS TipoEstacionamOrigenId, T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T1.[MudanzaPisoDptoOrigen], T1.[MudanzaDireccionOrigen] FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId]) ORDER BY T1.[MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00G04,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
