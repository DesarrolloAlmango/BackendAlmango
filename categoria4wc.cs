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
   public class categoria4wc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public categoria4wc( )
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

      public categoria4wc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MudanzaId )
      {
         this.AV24MudanzaId = aP0_MudanzaId;
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
         cmbavSdtcarga__cantidad = new GXCombobox();
         chkavSdtcarga__embalaje = new GXCheckbox();
         chkavSdtcarga__elevacion = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "MudanzaId");
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
                  AV24MudanzaId = (long)(Math.Round(NumberUtil.Val( GetPar( "MudanzaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV24MudanzaId", StringUtil.LTrimStr( (decimal)(AV24MudanzaId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV24MudanzaId});
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
                  gxfirstwebparm = GetFirstPar( "MudanzaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "MudanzaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freestylegrid1") == 0 )
               {
                  gxnrFreestylegrid1_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Freestylegrid1") == 0 )
               {
                  gxgrFreestylegrid1_refresh_invoke( ) ;
                  return  ;
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

      protected void gxnrFreestylegrid1_newrow_invoke( )
      {
         nRC_GXsfl_40 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_40"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_40_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_40_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_40_idx = GetPar( "sGXsfl_40_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreestylegrid1_newrow( ) ;
         /* End function gxnrFreestylegrid1_newrow_invoke */
      }

      protected void gxgrFreestylegrid1_refresh_invoke( )
      {
         ajax_req_read_hidden_sdt(GetNextPar( ), AV13SDTCarga);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreestylegrid1_refresh( AV13SDTCarga, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreestylegrid1_refresh_invoke */
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
            PAGO2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdtcarga__nombre_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdtcarga__nombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtcarga__nombre_Enabled), 5, 0), !bGXsfl_40_Refreshing);
               edtavSdtcarga__embalajecant_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdtcarga__embalajecant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtcarga__embalajecant_Enabled), 5, 0), !bGXsfl_40_Refreshing);
               edtavSdtcarga__elevacioncant_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdtcarga__elevacioncant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtcarga__elevacioncant_Enabled), 5, 0), !bGXsfl_40_Refreshing);
               WSGO2( ) ;
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
            context.SendWebValue( context.GetMessage( "Adicional", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
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
            GXEncryptionTmp = "categoria4wc.aspx"+UrlEncode(StringUtil.LTrimStr(AV24MudanzaId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("categoria4wc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdtcarga", AV13SDTCarga);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdtcarga", AV13SDTCarga);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_40", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_40), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV24MudanzaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV24MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDTCARGA", AV13SDTCarga);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDTCARGA", AV13SDTCarga);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vCANTIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Cantidad), 2, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vEMBELV", AV29EmbElv);
         GxWebStd.gx_hidden_field( context, sPrefix+"vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30Id), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PARAMETROMUDANZAVALOR", StringUtil.LTrim( StringUtil.NToC( A733ParametroMudanzaValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PARAMETROMUDANZANOMBRE", A732ParametroMudanzaNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"CANTIDADEMBELEV_MODAL_Width", StringUtil.RTrim( Cantidadembelev_modal_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"CANTIDADEMBELEV_MODAL_Title", StringUtil.RTrim( Cantidadembelev_modal_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"CANTIDADEMBELEV_MODAL_Confirmtype", StringUtil.RTrim( Cantidadembelev_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"CANTIDADEMBELEV_MODAL_Bodytype", StringUtil.RTrim( Cantidadembelev_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, sPrefix+"CANTIDADEMBELEV2_MODAL_Width", StringUtil.RTrim( Cantidadembelev2_modal_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"CANTIDADEMBELEV2_MODAL_Title", StringUtil.RTrim( Cantidadembelev2_modal_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"CANTIDADEMBELEV2_MODAL_Confirmtype", StringUtil.RTrim( Cantidadembelev2_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"CANTIDADEMBELEV2_MODAL_Bodytype", StringUtil.RTrim( Cantidadembelev2_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DESCRIPCION_MODAL_Width", StringUtil.RTrim( Descripcion_modal_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DESCRIPCION_MODAL_Title", StringUtil.RTrim( Descripcion_modal_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DESCRIPCION_MODAL_Confirmtype", StringUtil.RTrim( Descripcion_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DESCRIPCION_MODAL_Bodytype", StringUtil.RTrim( Descripcion_modal_Bodytype));
      }

      protected void RenderHtmlCloseFormGO2( )
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
            if ( ! ( WebComp_Wwpaux_wc == null ) )
            {
               WebComp_Wwpaux_wc.componentjscripts();
            }
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
         return "Categoria4WC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Adicional", "") ;
      }

      protected void WBGO0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "categoria4wc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "top-10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_freestylegrid1_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            wb_table1_10_GO2( true) ;
         }
         else
         {
            wb_table1_10_GO2( false) ;
         }
         return  ;
      }

      protected void wb_table1_10_GO2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            wb_table2_88_GO2( true) ;
         }
         else
         {
            wb_table2_88_GO2( false) ;
         }
         return  ;
      }

      protected void wb_table2_88_GO2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_93_GO2( true) ;
         }
         else
         {
            wb_table3_93_GO2( false) ;
         }
         return  ;
      }

      protected void wb_table3_93_GO2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table4_98_GO2( true) ;
         }
         else
         {
            wb_table4_98_GO2( false) ;
         }
         return  ;
      }

      protected void wb_table4_98_GO2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0104"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0104"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_40_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0104"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 40 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Freestylegrid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV42GXV1 = nGXsfl_40_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTGO2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Adicional", ""), 0) ;
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
               STRUPGO0( ) ;
            }
         }
      }

      protected void WSGO2( )
      {
         STARTGO2( ) ;
         EVTGO2( ) ;
      }

      protected void EVTGO2( )
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
                                 STRUPGO0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "CANTIDADEMBELEV_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPGO0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Cantidadembelev_modal.Close */
                                    E11GO2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CANTIDADEMBELEV_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPGO0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Cantidadembelev_modal.Onloadcomponent */
                                    E12GO2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CANTIDADEMBELEV2_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPGO0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Cantidadembelev2_modal.Close */
                                    E13GO2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CANTIDADEMBELEV2_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPGO0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Cantidadembelev2_modal.Onloadcomponent */
                                    E14GO2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DESCRIPCION_MODAL.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPGO0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Descripcion_modal.Close */
                                    E15GO2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DESCRIPCION_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPGO0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Descripcion_modal.Onloadcomponent */
                                    E16GO2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.EMBALAJEELEVACION4") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPGO0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E17GO2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPGO0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "'DOSUBTRACT'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "'DOADD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 38), "SDTCARGA__CANTIDAD.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "SDTCARGA__EMBALAJE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "SDTCARGA__ELEVACION.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "SDTCARGA__NOMBRE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "SDTCARGA__NOMBRE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "'DOSUBTRACT'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "'DOADD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "SDTCARGA__EMBALAJE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "SDTCARGA__ELEVACION.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPGO0( ) ;
                              }
                              nGXsfl_40_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
                              SubsflControlProps_402( ) ;
                              AV42GXV1 = nGXsfl_40_idx;
                              if ( ( AV13SDTCarga.Count >= AV42GXV1 ) && ( AV42GXV1 > 0 ) )
                              {
                                 AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E18GO2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E19GO2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Freestylegrid1.Load */
                                          E20GO2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOSUBTRACT'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoSubtract' */
                                          E21GO2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOADD'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoAdd' */
                                          E22GO2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SDTCARGA__CANTIDAD.CONTROLVALUECHANGED") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Sdtcarga__cantidad.Controlvaluechanged */
                                          E23GO2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SDTCARGA__EMBALAJE.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Sdtcarga__embalaje.Click */
                                          E24GO2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SDTCARGA__ELEVACION.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Sdtcarga__elevacion.Click */
                                          E25GO2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SDTCARGA__NOMBRE.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Sdtcarga__nombre.Click */
                                          E26GO2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
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
                                       STRUPGO0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdtcarga__nombre_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 104 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0104");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0104", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEGO2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormGO2( ) ;
            }
         }
      }

      protected void PAGO2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "categoria4wc.aspx")), "categoria4wc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "categoria4wc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "MudanzaId");
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

      protected void gxnrFreestylegrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_402( ) ;
         while ( nGXsfl_40_idx <= nRC_GXsfl_40 )
         {
            sendrow_402( ) ;
            nGXsfl_40_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_40_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Freestylegrid1Container)) ;
         /* End function gxnrFreestylegrid1_newrow */
      }

      protected void gxgrFreestylegrid1_refresh( GXBaseCollection<SdtSDTCarga_SDTCargaItem> AV13SDTCarga ,
                                                 string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREESTYLEGRID1_nCurrentRecord = 0;
         RFGO2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrFreestylegrid1_refresh */
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
         RFGO2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdtcarga__nombre_Enabled = 0;
         edtavSdtcarga__embalajecant_Enabled = 0;
         edtavSdtcarga__elevacioncant_Enabled = 0;
      }

      protected void RFGO2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Freestylegrid1Container.ClearRows();
         }
         wbStart = 40;
         /* Execute user event: Refresh */
         E19GO2 ();
         nGXsfl_40_idx = 1;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         bGXsfl_40_Refreshing = true;
         Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         Freestylegrid1Container.AddObjectProperty("CmpContext", sPrefix);
         Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
         Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( subFreestylegrid1_Class));
         Freestylegrid1Container.AddObjectProperty("Class", subFreestylegrid1_Class);
         Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
         Freestylegrid1Container.PageSize = subFreestylegrid1_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_402( ) ;
            /* Execute user event: Freestylegrid1.Load */
            E20GO2 ();
            wbEnd = 40;
            WBGO0( ) ;
         }
         bGXsfl_40_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesGO2( )
      {
      }

      protected int subFreestylegrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFreestylegrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdtcarga__nombre_Enabled = 0;
         edtavSdtcarga__embalajecant_Enabled = 0;
         edtavSdtcarga__elevacioncant_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPGO0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18GO2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdtcarga"), AV13SDTCarga);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDTCARGA"), AV13SDTCarga);
            /* Read saved values. */
            nRC_GXsfl_40 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_40"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV24MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV24MudanzaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Cantidadembelev_modal_Width = cgiGet( sPrefix+"CANTIDADEMBELEV_MODAL_Width");
            Cantidadembelev_modal_Title = cgiGet( sPrefix+"CANTIDADEMBELEV_MODAL_Title");
            Cantidadembelev_modal_Confirmtype = cgiGet( sPrefix+"CANTIDADEMBELEV_MODAL_Confirmtype");
            Cantidadembelev_modal_Bodytype = cgiGet( sPrefix+"CANTIDADEMBELEV_MODAL_Bodytype");
            Cantidadembelev2_modal_Width = cgiGet( sPrefix+"CANTIDADEMBELEV2_MODAL_Width");
            Cantidadembelev2_modal_Title = cgiGet( sPrefix+"CANTIDADEMBELEV2_MODAL_Title");
            Cantidadembelev2_modal_Confirmtype = cgiGet( sPrefix+"CANTIDADEMBELEV2_MODAL_Confirmtype");
            Cantidadembelev2_modal_Bodytype = cgiGet( sPrefix+"CANTIDADEMBELEV2_MODAL_Bodytype");
            Descripcion_modal_Width = cgiGet( sPrefix+"DESCRIPCION_MODAL_Width");
            Descripcion_modal_Title = cgiGet( sPrefix+"DESCRIPCION_MODAL_Title");
            Descripcion_modal_Confirmtype = cgiGet( sPrefix+"DESCRIPCION_MODAL_Confirmtype");
            Descripcion_modal_Bodytype = cgiGet( sPrefix+"DESCRIPCION_MODAL_Bodytype");
            nRC_GXsfl_40 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_40"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_40_fel_idx = 0;
            while ( nGXsfl_40_fel_idx < nRC_GXsfl_40 )
            {
               nGXsfl_40_fel_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_40_fel_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_fel_idx+1);
               sGXsfl_40_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_402( ) ;
               AV42GXV1 = nGXsfl_40_fel_idx;
               if ( ( AV13SDTCarga.Count >= AV42GXV1 ) && ( AV42GXV1 > 0 ) )
               {
                  AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
               }
            }
            if ( nGXsfl_40_fel_idx == 0 )
            {
               nGXsfl_40_idx = 1;
               sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
               SubsflControlProps_402( ) ;
            }
            nGXsfl_40_fel_idx = 1;
            /* Read variables values. */
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
         E18GO2 ();
         if (returnInSub) return;
      }

      protected void E18GO2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV25Mudanza.Load(AV24MudanzaId);
         if ( AV25Mudanza.Success() )
         {
            AV13SDTCarga.Clear();
            gx_BV40 = true;
            /* Using cursor H00GO2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A731ParametroMudanzaTipo = H00GO2_A731ParametroMudanzaTipo[0];
               A730ParametroMudanzaId = H00GO2_A730ParametroMudanzaId[0];
               A732ParametroMudanzaNombre = H00GO2_A732ParametroMudanzaNombre[0];
               A812ParametroMudanzaDescripcion = H00GO2_A812ParametroMudanzaDescripcion[0];
               A733ParametroMudanzaValor = H00GO2_A733ParametroMudanzaValor[0];
               A734ParametroMudanzaUnidad = H00GO2_A734ParametroMudanzaUnidad[0];
               AV16SDTCargaItem = new SdtSDTCarga_SDTCargaItem(context);
               AV16SDTCargaItem.gxTpr_Id = A730ParametroMudanzaId;
               AV16SDTCargaItem.gxTpr_Nombre = A732ParametroMudanzaNombre;
               AV50GXV8 = 1;
               while ( AV50GXV8 <= AV25Mudanza.gxTpr_Carga.Count )
               {
                  AV26MudanzaCargaItem = ((SdtMudanza_Carga)AV25Mudanza.gxTpr_Carga.Item(AV50GXV8));
                  if ( AV26MudanzaCargaItem.gxTpr_Itemcargaid == A730ParametroMudanzaId )
                  {
                     AV16SDTCargaItem.gxTpr_Cantidad = AV26MudanzaCargaItem.gxTpr_Itemcargacantidad;
                     AV16SDTCargaItem.gxTpr_Embalaje = AV26MudanzaCargaItem.gxTpr_Itemcargaembalaje;
                     AV16SDTCargaItem.gxTpr_Elevacion = AV26MudanzaCargaItem.gxTpr_Itemcargaelevacion;
                     AV16SDTCargaItem.gxTpr_Embalajecant = AV26MudanzaCargaItem.gxTpr_Itemcargaembcant;
                     AV16SDTCargaItem.gxTpr_Elevacioncant = AV26MudanzaCargaItem.gxTpr_Itemcargaelevcant;
                     if (true) break;
                  }
                  AV50GXV8 = (int)(AV50GXV8+1);
               }
               AV16SDTCargaItem.gxTpr_Descripcion = A812ParametroMudanzaDescripcion;
               AV16SDTCargaItem.gxTpr_Valor = A733ParametroMudanzaValor;
               AV16SDTCargaItem.gxTpr_Unidad = A734ParametroMudanzaUnidad;
               AV13SDTCarga.Add(AV16SDTCargaItem, 0);
               gx_BV40 = true;
               AV23Valor = (decimal)(AV23Valor+((AV16SDTCargaItem.gxTpr_Cantidad*AV16SDTCargaItem.gxTpr_Valor)));
               AssignAttri(sPrefix, false, "AV23Valor", StringUtil.LTrimStr( AV23Valor, 8, 2));
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV22WebSession.Set(context.GetMessage( "SDTCargaJson", ""), AV21SDTCargaJson);
            AV22WebSession.Set(context.GetMessage( "ValorCategoria4", ""), StringUtil.Str( AV23Valor, 8, 2));
         }
         else
         {
            AV13SDTCarga.Clear();
            gx_BV40 = true;
            /* Using cursor H00GO3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A731ParametroMudanzaTipo = H00GO3_A731ParametroMudanzaTipo[0];
               A730ParametroMudanzaId = H00GO3_A730ParametroMudanzaId[0];
               A732ParametroMudanzaNombre = H00GO3_A732ParametroMudanzaNombre[0];
               A733ParametroMudanzaValor = H00GO3_A733ParametroMudanzaValor[0];
               A734ParametroMudanzaUnidad = H00GO3_A734ParametroMudanzaUnidad[0];
               A812ParametroMudanzaDescripcion = H00GO3_A812ParametroMudanzaDescripcion[0];
               AV16SDTCargaItem = new SdtSDTCarga_SDTCargaItem(context);
               AV16SDTCargaItem.gxTpr_Id = A730ParametroMudanzaId;
               AV16SDTCargaItem.gxTpr_Nombre = A732ParametroMudanzaNombre;
               AV16SDTCargaItem.gxTpr_Valor = A733ParametroMudanzaValor;
               AV16SDTCargaItem.gxTpr_Unidad = A734ParametroMudanzaUnidad;
               AV16SDTCargaItem.gxTpr_Descripcion = A812ParametroMudanzaDescripcion;
               AV13SDTCarga.Add(AV16SDTCargaItem, 0);
               gx_BV40 = true;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
      }

      protected void E19GO2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      private void E20GO2( )
      {
         /* Freestylegrid1_Load Routine */
         returnInSub = false;
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV13SDTCarga.Count )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
            edtavSdtcarga__nombre_Fontsize = 13;
            cmbavSdtcarga__cantidad.FontSize = 13;
            lblAdd_Fontsize = 20;
            lblSubtract_Fontsize = 20;
            lblSdtcarga__nombre_tags_Caption = "";
            if ( StringUtil.StrCmp(((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Descripcion, "") != 0 )
            {
               lblSdtcarga__nombre_tags_Caption = lblSdtcarga__nombre_tags_Caption+"<i class='fa fa-info-circle FontColorIconInfo TagAfterText'></i>";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 40;
            }
            sendrow_402( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_40_Refreshing )
            {
               context.DoAjaxLoad(40, Freestylegrid1Row);
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E12GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* Cantidadembelev_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "CategoriaEmbElevWP")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "categoriaembelevwp", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "CategoriaEmbElevWP";
            WebComp_Wwpaux_wc_Component = "CategoriaEmbElevWP";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0104",(string)"",((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Id,((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad,(short)4});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0104"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E14GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* Cantidadembelev2_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "CategoriaEmbElev2WP")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "categoriaembelev2wp", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "CategoriaEmbElev2WP";
            WebComp_Wwpaux_wc_Component = "CategoriaEmbElev2WP";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0104",(string)"",((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Id,((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad,(short)4});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0104"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E16GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* Descripcion_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "DescripcionProducto")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "descripcionproducto", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "DescripcionProducto";
            WebComp_Wwpaux_wc_Component = "DescripcionProducto";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0104",(string)"",(short)4,((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Nombre,((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Descripcion});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0104"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E15GO2( )
      {
         /* Descripcion_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E21GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* 'DoSubtract' Routine */
         returnInSub = false;
         if ( ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Embalaje ) && ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad >= 1 ) && ! ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion ) )
         {
            GX_msglist.addItem(context.GetMessage( "Destildar Embalaje para disminuir la cantidad", ""));
         }
         else if ( ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion ) && ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad >= 1 ) && ! ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Embalaje ) )
         {
            GX_msglist.addItem(context.GetMessage( "Destildar Elevación para disminuir la cantidad", ""));
         }
         else if ( ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Embalaje ) && ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion ) )
         {
            GX_msglist.addItem(context.GetMessage( "Destildar Embalaje/ Elevación para disminuir la cantidad", ""));
         }
         else
         {
            AV23Valor = 0;
            AssignAttri(sPrefix, false, "AV23Valor", StringUtil.LTrimStr( AV23Valor, 8, 2));
            if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad != 0 )
            {
               ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad = (short)(((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad-1);
            }
            AV20SDTCarga2 = AV13SDTCarga;
            AV52GXV9 = 1;
            while ( AV52GXV9 <= AV20SDTCarga2.Count )
            {
               AV19SDTCargaItem2 = ((SdtSDTCarga_SDTCargaItem)AV20SDTCarga2.Item(AV52GXV9));
               AV23Valor = (decimal)(AV23Valor+((AV19SDTCargaItem2.gxTpr_Cantidad*AV19SDTCargaItem2.gxTpr_Valor)));
               AssignAttri(sPrefix, false, "AV23Valor", StringUtil.LTrimStr( AV23Valor, 8, 2));
               AV52GXV9 = (int)(AV52GXV9+1);
            }
            AV21SDTCargaJson = AV13SDTCarga.ToJSonString(false);
            AssignAttri(sPrefix, false, "AV21SDTCargaJson", AV21SDTCargaJson);
            AV22WebSession.Set(context.GetMessage( "SDTCargaJson4", ""), AV21SDTCargaJson);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "VolumenEstimado", new Object[] {(decimal)AV23Valor,(short)4}, true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDTCarga", AV13SDTCarga);
         nGXsfl_40_bak_idx = nGXsfl_40_idx;
         gxgrFreestylegrid1_refresh( AV13SDTCarga, sPrefix) ;
         nGXsfl_40_idx = nGXsfl_40_bak_idx;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
      }

      protected void E22GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* 'DoAdd' Routine */
         returnInSub = false;
         if ( ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Embalaje ) && ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad >= 1 ) && ! ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion ) )
         {
            GX_msglist.addItem(context.GetMessage( "Destildar Embalaje para aumentar la cantidad", ""));
         }
         else if ( ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion ) && ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad >= 1 ) && ! ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Embalaje ) )
         {
            GX_msglist.addItem(context.GetMessage( "Destildar Elevación para aumentar la cantidad", ""));
         }
         else if ( ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Embalaje ) && ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion ) )
         {
            GX_msglist.addItem(context.GetMessage( "Destildar Embalaje/ Elevación para aumentar la cantidad", ""));
         }
         else
         {
            AV23Valor = 0;
            AssignAttri(sPrefix, false, "AV23Valor", StringUtil.LTrimStr( AV23Valor, 8, 2));
            ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad = (short)(((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad+1);
            AV20SDTCarga2 = AV13SDTCarga;
            AV53GXV10 = 1;
            while ( AV53GXV10 <= AV20SDTCarga2.Count )
            {
               AV19SDTCargaItem2 = ((SdtSDTCarga_SDTCargaItem)AV20SDTCarga2.Item(AV53GXV10));
               AV23Valor = (decimal)(AV23Valor+((AV19SDTCargaItem2.gxTpr_Cantidad*AV19SDTCargaItem2.gxTpr_Valor)));
               AssignAttri(sPrefix, false, "AV23Valor", StringUtil.LTrimStr( AV23Valor, 8, 2));
               AV53GXV10 = (int)(AV53GXV10+1);
            }
            AV21SDTCargaJson = AV13SDTCarga.ToJSonString(false);
            AssignAttri(sPrefix, false, "AV21SDTCargaJson", AV21SDTCargaJson);
            AV22WebSession.Set(context.GetMessage( "SDTCargaJson4", ""), AV21SDTCargaJson);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "VolumenEstimado", new Object[] {(decimal)AV23Valor,(short)4}, true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDTCarga", AV13SDTCarga);
         nGXsfl_40_bak_idx = nGXsfl_40_idx;
         gxgrFreestylegrid1_refresh( AV13SDTCarga, sPrefix) ;
         nGXsfl_40_idx = nGXsfl_40_bak_idx;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
      }

      protected void S112( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV31IsAuthorized_CantidadEmbElev;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "CategoriaEmbElevWP", out  GXt_boolean1) ;
         AV31IsAuthorized_CantidadEmbElev = GXt_boolean1;
         if ( ! ( AV31IsAuthorized_CantidadEmbElev ) )
         {
            bttBtncantidadembelev_Visible = 0;
            AssignProp(sPrefix, false, bttBtncantidadembelev_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncantidadembelev_Visible), 5, 0), !bGXsfl_40_Refreshing);
         }
         GXt_boolean1 = AV32IsAuthorized_CantidadEmbElev2;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "CategoriaEmbElevWP", out  GXt_boolean1) ;
         AV32IsAuthorized_CantidadEmbElev2 = GXt_boolean1;
         if ( ! ( AV32IsAuthorized_CantidadEmbElev2 ) )
         {
            bttBtncantidadembelev2_Visible = 0;
            AssignProp(sPrefix, false, bttBtncantidadembelev2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtncantidadembelev2_Visible), 5, 0), !bGXsfl_40_Refreshing);
         }
         GXt_boolean1 = AV41IsAuthorized_Descripcion;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "DescripcionProducto", out  GXt_boolean1) ;
         AV41IsAuthorized_Descripcion = GXt_boolean1;
         if ( ! ( AV41IsAuthorized_Descripcion ) )
         {
            bttBtndescripcion_Visible = 0;
            AssignProp(sPrefix, false, bttBtndescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndescripcion_Visible), 5, 0), !bGXsfl_40_Refreshing);
         }
      }

      protected void E23GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* Sdtcarga__cantidad_Controlvaluechanged Routine */
         returnInSub = false;
         AV21SDTCargaJson = AV22WebSession.Get(context.GetMessage( "SDTCargaJson4", ""));
         AssignAttri(sPrefix, false, "AV21SDTCargaJson", AV21SDTCargaJson);
         AV20SDTCarga2.FromJSonString(AV21SDTCargaJson, null);
         if ( ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Embalaje ) && ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad >= 1 ) && ! ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion ) )
         {
            AV54GXV11 = 1;
            while ( AV54GXV11 <= AV20SDTCarga2.Count )
            {
               AV19SDTCargaItem2 = ((SdtSDTCarga_SDTCargaItem)AV20SDTCarga2.Item(AV54GXV11));
               if ( StringUtil.StrCmp(AV19SDTCargaItem2.gxTpr_Nombre, ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Nombre) == 0 )
               {
                  ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad = AV19SDTCargaItem2.gxTpr_Cantidad;
               }
               AV54GXV11 = (int)(AV54GXV11+1);
            }
            GX_msglist.addItem(context.GetMessage( "Destildar Embalaje para cambiar la cantidad", ""));
         }
         else if ( ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion ) && ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad >= 1 ) && ! ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Embalaje ) )
         {
            AV55GXV12 = 1;
            while ( AV55GXV12 <= AV20SDTCarga2.Count )
            {
               AV19SDTCargaItem2 = ((SdtSDTCarga_SDTCargaItem)AV20SDTCarga2.Item(AV55GXV12));
               if ( StringUtil.StrCmp(AV19SDTCargaItem2.gxTpr_Nombre, ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Nombre) == 0 )
               {
                  ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad = AV19SDTCargaItem2.gxTpr_Cantidad;
               }
               AV55GXV12 = (int)(AV55GXV12+1);
            }
            GX_msglist.addItem(context.GetMessage( "Destildar Elevación para cambiar aumentar la cantidad", ""));
         }
         else if ( ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Embalaje ) && ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion ) )
         {
            AV56GXV13 = 1;
            while ( AV56GXV13 <= AV20SDTCarga2.Count )
            {
               AV19SDTCargaItem2 = ((SdtSDTCarga_SDTCargaItem)AV20SDTCarga2.Item(AV56GXV13));
               if ( StringUtil.StrCmp(AV19SDTCargaItem2.gxTpr_Nombre, ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Nombre) == 0 )
               {
                  ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad = AV19SDTCargaItem2.gxTpr_Cantidad;
               }
               AV56GXV13 = (int)(AV56GXV13+1);
            }
            GX_msglist.addItem(context.GetMessage( "Destildar Embalaje/ Elevación para cambiar la cantidad", ""));
         }
         else
         {
            AV23Valor = 0;
            AssignAttri(sPrefix, false, "AV23Valor", StringUtil.LTrimStr( AV23Valor, 8, 2));
            AV20SDTCarga2 = AV13SDTCarga;
            AV57GXV14 = 1;
            while ( AV57GXV14 <= AV20SDTCarga2.Count )
            {
               AV19SDTCargaItem2 = ((SdtSDTCarga_SDTCargaItem)AV20SDTCarga2.Item(AV57GXV14));
               AV23Valor = (decimal)(AV23Valor+((AV19SDTCargaItem2.gxTpr_Cantidad*AV19SDTCargaItem2.gxTpr_Valor)));
               AssignAttri(sPrefix, false, "AV23Valor", StringUtil.LTrimStr( AV23Valor, 8, 2));
               AV57GXV14 = (int)(AV57GXV14+1);
            }
            AV21SDTCargaJson = AV13SDTCarga.ToJSonString(false);
            AssignAttri(sPrefix, false, "AV21SDTCargaJson", AV21SDTCargaJson);
            AV22WebSession.Set(context.GetMessage( "SDTCargaJson4", ""), AV21SDTCargaJson);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "VolumenEstimado", new Object[] {(decimal)AV23Valor,(short)4}, true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDTCarga", AV13SDTCarga);
         nGXsfl_40_bak_idx = nGXsfl_40_idx;
         gxgrFreestylegrid1_refresh( AV13SDTCarga, sPrefix) ;
         nGXsfl_40_idx = nGXsfl_40_bak_idx;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
      }

      protected void E11GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* Cantidadembelev_modal_Close Routine */
         returnInSub = false;
         ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Embalaje = false;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDTCarga", AV13SDTCarga);
         nGXsfl_40_bak_idx = nGXsfl_40_idx;
         gxgrFreestylegrid1_refresh( AV13SDTCarga, sPrefix) ;
         nGXsfl_40_idx = nGXsfl_40_bak_idx;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
      }

      protected void E13GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* Cantidadembelev2_modal_Close Routine */
         returnInSub = false;
         ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion = false;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDTCarga", AV13SDTCarga);
         nGXsfl_40_bak_idx = nGXsfl_40_idx;
         gxgrFreestylegrid1_refresh( AV13SDTCarga, sPrefix) ;
         nGXsfl_40_idx = nGXsfl_40_bak_idx;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
      }

      protected void E17GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* General\GlobalEvents_Embalajeelevacion4 Routine */
         returnInSub = false;
         /* Using cursor H00GO4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A732ParametroMudanzaNombre = H00GO4_A732ParametroMudanzaNombre[0];
            A733ParametroMudanzaValor = H00GO4_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "PrecioEmbMetro3", "")) == 0 )
            {
               AV37PrecioEmbMetro3 = A733ParametroMudanzaValor;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor H00GO5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A732ParametroMudanzaNombre = H00GO5_A732ParametroMudanzaNombre[0];
            A733ParametroMudanzaValor = H00GO5_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "PrecioElevPiso", "")) == 0 )
            {
               AV36PrecioElevPiso = A733ParametroMudanzaValor;
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV60GXV15 = 1;
         while ( AV60GXV15 <= AV13SDTCarga.Count )
         {
            AV16SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV60GXV15));
            if ( AV16SDTCargaItem.gxTpr_Id == AV30Id )
            {
               if ( StringUtil.StrCmp(AV29EmbElv, context.GetMessage( "Emb", "")) == 0 )
               {
                  AV16SDTCargaItem.gxTpr_Embalajecant = AV14Cantidad;
                  AV34ParametroValor = AV16SDTCargaItem.gxTpr_Valor;
                  AV40ValorEmb = (decimal)(AV14Cantidad*AV34ParametroValor*AV37PrecioEmbMetro3);
                  this.executeUsercontrolMethod(sPrefix, false, "CANTIDADEMBELEV_MODALContainer", "CloseConfirmPanel", "", new Object[] {});
                  this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "CalculoEmbElv", new Object[] {(decimal)AV40ValorEmb}, true);
               }
               if ( StringUtil.StrCmp(AV29EmbElv, context.GetMessage( "Elv", "")) == 0 )
               {
                  AV35Piso = (short)(Math.Round(NumberUtil.Val( AV22WebSession.Get(context.GetMessage( "PisoElevacion", "")), "."), 18, MidpointRounding.ToEven));
                  AV16SDTCargaItem.gxTpr_Elevacioncant = AV14Cantidad;
                  AV39ValorElv = (decimal)(AV14Cantidad*AV35Piso*AV36PrecioElevPiso);
                  this.executeUsercontrolMethod(sPrefix, false, "CANTIDADEMBELEV2_MODALContainer", "CloseConfirmPanel", "", new Object[] {});
                  this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "CalculoEmbElv", new Object[] {(decimal)AV39ValorElv}, true);
               }
               if (true) break;
            }
            AV60GXV15 = (int)(AV60GXV15+1);
         }
         AV21SDTCargaJson = AV13SDTCarga.ToJSonString(false);
         AssignAttri(sPrefix, false, "AV21SDTCargaJson", AV21SDTCargaJson);
         AV22WebSession.Set(context.GetMessage( "SDTCargaJson4", ""), AV21SDTCargaJson);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDTCarga", AV13SDTCarga);
         nGXsfl_40_bak_idx = nGXsfl_40_idx;
         gxgrFreestylegrid1_refresh( AV13SDTCarga, sPrefix) ;
         nGXsfl_40_idx = nGXsfl_40_bak_idx;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
      }

      protected void E24GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* Sdtcarga__embalaje_Click Routine */
         returnInSub = false;
         /* Using cursor H00GO6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A732ParametroMudanzaNombre = H00GO6_A732ParametroMudanzaNombre[0];
            A733ParametroMudanzaValor = H00GO6_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "PrecioEmbMetro3", "")) == 0 )
            {
               AV37PrecioEmbMetro3 = A733ParametroMudanzaValor;
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
         AV30Id = ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Id;
         AssignAttri(sPrefix, false, "AV30Id", StringUtil.LTrimStr( (decimal)(AV30Id), 18, 0));
         if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Embalaje )
         {
            AV62GXV16 = 1;
            while ( AV62GXV16 <= AV13SDTCarga.Count )
            {
               AV16SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV62GXV16));
               if ( AV16SDTCargaItem.gxTpr_Id == AV30Id )
               {
                  AV16SDTCargaItem.gxTpr_Embalaje = true;
                  if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad == 1 )
                  {
                     AV16SDTCargaItem.gxTpr_Embalajecant = 1;
                     AV34ParametroValor = AV16SDTCargaItem.gxTpr_Valor;
                     AV40ValorEmb = (decimal)(1*AV34ParametroValor*AV37PrecioEmbMetro3);
                     this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "CalculoEmbElv", new Object[] {(decimal)AV40ValorEmb}, true);
                     AV40ValorEmb = 0;
                     AV34ParametroValor = 0;
                  }
                  if (true) break;
               }
               AV62GXV16 = (int)(AV62GXV16+1);
            }
            if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad > 1 )
            {
               this.executeUsercontrolMethod(sPrefix, false, "CANTIDADEMBELEV_MODALContainer", "Confirm", "", new Object[] {});
            }
            if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad == 0 )
            {
               AV16SDTCargaItem.gxTpr_Embalaje = false;
            }
         }
         else
         {
            AV63GXV17 = 1;
            while ( AV63GXV17 <= AV13SDTCarga.Count )
            {
               AV16SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV63GXV17));
               if ( AV16SDTCargaItem.gxTpr_Id == AV30Id )
               {
                  AV16SDTCargaItem.gxTpr_Embalaje = false;
                  AV14Cantidad = AV16SDTCargaItem.gxTpr_Embalajecant;
                  AssignAttri(sPrefix, false, "AV14Cantidad", StringUtil.LTrimStr( (decimal)(AV14Cantidad), 2, 0));
                  AV34ParametroValor = AV16SDTCargaItem.gxTpr_Valor;
                  if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad == 1 )
                  {
                     AV40ValorEmb = (decimal)(1*AV34ParametroValor*AV37PrecioEmbMetro3);
                  }
                  else
                  {
                     AV40ValorEmb = (decimal)(AV14Cantidad*AV34ParametroValor*AV37PrecioEmbMetro3);
                  }
                  AV40ValorEmb = (decimal)(AV40ValorEmb*(-1));
                  this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "CalculoEmbElv", new Object[] {(decimal)AV40ValorEmb}, true);
                  AV40ValorEmb = 0;
                  AV34ParametroValor = 0;
                  AV16SDTCargaItem.gxTpr_Embalajecant = 0;
                  if (true) break;
               }
               AV63GXV17 = (int)(AV63GXV17+1);
            }
         }
         AV21SDTCargaJson = AV13SDTCarga.ToJSonString(false);
         AssignAttri(sPrefix, false, "AV21SDTCargaJson", AV21SDTCargaJson);
         AV22WebSession.Set(context.GetMessage( "SDTCargaJson4", ""), AV21SDTCargaJson);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDTCarga", AV13SDTCarga);
         nGXsfl_40_bak_idx = nGXsfl_40_idx;
         gxgrFreestylegrid1_refresh( AV13SDTCarga, sPrefix) ;
         nGXsfl_40_idx = nGXsfl_40_bak_idx;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
      }

      protected void E25GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* Sdtcarga__elevacion_Click Routine */
         returnInSub = false;
         /* Using cursor H00GO7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A732ParametroMudanzaNombre = H00GO7_A732ParametroMudanzaNombre[0];
            A733ParametroMudanzaValor = H00GO7_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "PrecioElevPiso", "")) == 0 )
            {
               AV36PrecioElevPiso = A733ParametroMudanzaValor;
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
         AV35Piso = (short)(Math.Round(NumberUtil.Val( AV22WebSession.Get(context.GetMessage( "PisoElevacion", "")), "."), 18, MidpointRounding.ToEven));
         if ( AV35Piso == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "No indicó niveles para esta mudanza", ""));
            ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion = false;
         }
         else
         {
            AV30Id = ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Id;
            AssignAttri(sPrefix, false, "AV30Id", StringUtil.LTrimStr( (decimal)(AV30Id), 18, 0));
            if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Elevacion )
            {
               AV65GXV18 = 1;
               while ( AV65GXV18 <= AV13SDTCarga.Count )
               {
                  AV16SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV65GXV18));
                  if ( AV16SDTCargaItem.gxTpr_Id == AV30Id )
                  {
                     AV16SDTCargaItem.gxTpr_Elevacion = true;
                     if (true) break;
                  }
                  AV65GXV18 = (int)(AV65GXV18+1);
               }
               if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad > 1 )
               {
                  this.executeUsercontrolMethod(sPrefix, false, "CANTIDADEMBELEV2_MODALContainer", "Confirm", "", new Object[] {});
               }
               if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad == 0 )
               {
                  AV16SDTCargaItem.gxTpr_Elevacion = false;
               }
               if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad == 1 )
               {
                  AV16SDTCargaItem.gxTpr_Elevacioncant = 1;
                  AV40ValorEmb = (decimal)(AV35Piso*AV36PrecioElevPiso);
                  this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "CalculoEmbElv", new Object[] {(decimal)AV40ValorEmb}, true);
                  AV40ValorEmb = 0;
               }
            }
            else
            {
               AV66GXV19 = 1;
               while ( AV66GXV19 <= AV13SDTCarga.Count )
               {
                  AV16SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV66GXV19));
                  if ( AV16SDTCargaItem.gxTpr_Id == AV30Id )
                  {
                     AV16SDTCargaItem.gxTpr_Elevacion = false;
                     AV14Cantidad = AV16SDTCargaItem.gxTpr_Elevacioncant;
                     AssignAttri(sPrefix, false, "AV14Cantidad", StringUtil.LTrimStr( (decimal)(AV14Cantidad), 2, 0));
                     if ( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Cantidad == 1 )
                     {
                        AV40ValorEmb = (decimal)(AV35Piso*AV36PrecioElevPiso);
                     }
                     else
                     {
                        AV40ValorEmb = (decimal)(AV14Cantidad*AV35Piso*AV36PrecioElevPiso);
                     }
                     AV40ValorEmb = (decimal)(AV40ValorEmb*(-1));
                     this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "CalculoEmbElv", new Object[] {(decimal)AV40ValorEmb}, true);
                     AV40ValorEmb = 0;
                     AV16SDTCargaItem.gxTpr_Elevacioncant = 0;
                     if (true) break;
                  }
                  AV66GXV19 = (int)(AV66GXV19+1);
               }
            }
            AV21SDTCargaJson = AV13SDTCarga.ToJSonString(false);
            AssignAttri(sPrefix, false, "AV21SDTCargaJson", AV21SDTCargaJson);
            AV22WebSession.Set(context.GetMessage( "SDTCargaJson4", ""), AV21SDTCargaJson);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13SDTCarga", AV13SDTCarga);
         nGXsfl_40_bak_idx = nGXsfl_40_idx;
         gxgrFreestylegrid1_refresh( AV13SDTCarga, sPrefix) ;
         nGXsfl_40_idx = nGXsfl_40_bak_idx;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
      }

      protected void E26GO2( )
      {
         AV42GXV1 = nGXsfl_40_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) )
         {
            AV13SDTCarga.CurrentItem = ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1));
         }
         /* Sdtcarga__nombre_Click Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDTCarga_SDTCargaItem)(AV13SDTCarga.CurrentItem)).gxTpr_Descripcion)) )
         {
            this.executeUsercontrolMethod(sPrefix, false, "DESCRIPCION_MODALContainer", "Confirm", "", new Object[] {});
         }
      }

      protected void wb_table4_98_GO2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledescripcion_modal_Internalname, tblTabledescripcion_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDescripcion_modal.SetProperty("Width", Descripcion_modal_Width);
            ucDescripcion_modal.SetProperty("Title", Descripcion_modal_Title);
            ucDescripcion_modal.SetProperty("ConfirmType", Descripcion_modal_Confirmtype);
            ucDescripcion_modal.SetProperty("BodyType", Descripcion_modal_Bodytype);
            ucDescripcion_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Descripcion_modal_Internalname, sPrefix+"DESCRIPCION_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DESCRIPCION_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_98_GO2e( true) ;
         }
         else
         {
            wb_table4_98_GO2e( false) ;
         }
      }

      protected void wb_table3_93_GO2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablecantidadembelev2_modal_Internalname, tblTablecantidadembelev2_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucCantidadembelev2_modal.SetProperty("Width", Cantidadembelev2_modal_Width);
            ucCantidadembelev2_modal.SetProperty("Title", Cantidadembelev2_modal_Title);
            ucCantidadembelev2_modal.SetProperty("ConfirmType", Cantidadembelev2_modal_Confirmtype);
            ucCantidadembelev2_modal.SetProperty("BodyType", Cantidadembelev2_modal_Bodytype);
            ucCantidadembelev2_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Cantidadembelev2_modal_Internalname, sPrefix+"CANTIDADEMBELEV2_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"CANTIDADEMBELEV2_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_93_GO2e( true) ;
         }
         else
         {
            wb_table3_93_GO2e( false) ;
         }
      }

      protected void wb_table2_88_GO2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablecantidadembelev_modal_Internalname, tblTablecantidadembelev_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucCantidadembelev_modal.SetProperty("Width", Cantidadembelev_modal_Width);
            ucCantidadembelev_modal.SetProperty("Title", Cantidadembelev_modal_Title);
            ucCantidadembelev_modal.SetProperty("ConfirmType", Cantidadembelev_modal_Confirmtype);
            ucCantidadembelev_modal.SetProperty("BodyType", Cantidadembelev_modal_Bodytype);
            ucCantidadembelev_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Cantidadembelev_modal_Internalname, sPrefix+"CANTIDADEMBELEV_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"CANTIDADEMBELEV_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_88_GO2e( true) ;
         }
         else
         {
            wb_table2_88_GO2e( false) ;
         }
      }

      protected void wb_table1_10_GO2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblFreestylegrid1_headertable_Internalname, tblFreestylegrid1_headertable_Internalname, "", "", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='TableFSHeader'>") ;
            wb_table5_13_GO2( true) ;
         }
         else
         {
            wb_table5_13_GO2( false) ;
         }
         return  ;
      }

      protected void wb_table5_13_GO2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            StartGridControl40( ) ;
         }
         if ( wbEnd == 40 )
         {
            wbEnd = 0;
            nRC_GXsfl_40 = (int)(nGXsfl_40_idx-1);
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV42GXV1 = nGXsfl_40_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_10_GO2e( true) ;
         }
         else
         {
            wb_table1_10_GO2e( false) ;
         }
      }

      protected void wb_table5_13_GO2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblFreestylegrid1_descriptionstable_Internalname, tblFreestylegrid1_descriptionstable_Internalname, "", "FSSingleLine FreeStyleGridWithHeader TableFSHeader", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td style=\""+CSSHelper.Prettify( "width:310px")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksdtcarga__nombre_Internalname, context.GetMessage( "Item", ""), "", "", lblTextblocksdtcarga__nombre_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockFSWithHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_Categoria4WC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td style=\""+CSSHelper.Prettify( "width:120px")+"\">") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td style=\""+CSSHelper.Prettify( "width:60px")+"\">") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;width:50px")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksdtcarga__embalaje_Internalname, context.GetMessage( "Embalaje", ""), "", "", lblTextblocksdtcarga__embalaje_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockFSWithHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_Categoria4WC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td style=\""+CSSHelper.Prettify( "width:20px")+"\">") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td style=\""+CSSHelper.Prettify( "width:50px")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksdtcarga__embalajecant_Internalname, "", "", "", lblTextblocksdtcarga__embalajecant_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockFSWithHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_Categoria4WC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center;width:50px")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksdtcarga__elevacion_Internalname, context.GetMessage( "Elevación", ""), "", "", lblTextblocksdtcarga__elevacion_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockFSWithHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_Categoria4WC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td style=\""+CSSHelper.Prettify( "width:20px")+"\">") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td style=\""+CSSHelper.Prettify( "width:50px")+"\">") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellTitlecantidadembelev_cell_Internalname+"\"  class=''>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellTitlecantidadembelev2_cell_Internalname+"\"  class=''>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellTitledescripcion_cell_Internalname+"\"  class=''>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_13_GO2e( true) ;
         }
         else
         {
            wb_table5_13_GO2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV24MudanzaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV24MudanzaId", StringUtil.LTrimStr( (decimal)(AV24MudanzaId), 18, 0));
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
         PAGO2( ) ;
         WSGO2( ) ;
         WEGO2( ) ;
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
         sCtrlAV24MudanzaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAGO2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "categoria4wc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAGO2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV24MudanzaId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV24MudanzaId", StringUtil.LTrimStr( (decimal)(AV24MudanzaId), 18, 0));
         }
         wcpOAV24MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV24MudanzaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV24MudanzaId != wcpOAV24MudanzaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV24MudanzaId = AV24MudanzaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV24MudanzaId = cgiGet( sPrefix+"AV24MudanzaId_CTRL");
         if ( StringUtil.Len( sCtrlAV24MudanzaId) > 0 )
         {
            AV24MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV24MudanzaId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV24MudanzaId", StringUtil.LTrimStr( (decimal)(AV24MudanzaId), 18, 0));
         }
         else
         {
            AV24MudanzaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV24MudanzaId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PAGO2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSGO2( ) ;
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
         WSGO2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV24MudanzaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV24MudanzaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV24MudanzaId_CTRL", StringUtil.RTrim( sCtrlAV24MudanzaId));
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
         WEGO2( ) ;
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026921224424", true, true, false);
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
         context.AddJavascriptSource("categoria4wc.js", "?2026921224424", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_402( )
      {
         edtavSdtcarga__nombre_Internalname = sPrefix+"SDTCARGA__NOMBRE_"+sGXsfl_40_idx;
         lblSdtcarga__nombre_tags_Internalname = sPrefix+"SDTCARGA__NOMBRE_TAGS_"+sGXsfl_40_idx;
         lblSubtract_Internalname = sPrefix+"SUBTRACT_"+sGXsfl_40_idx;
         cmbavSdtcarga__cantidad_Internalname = sPrefix+"SDTCARGA__CANTIDAD_"+sGXsfl_40_idx;
         lblAdd_Internalname = sPrefix+"ADD_"+sGXsfl_40_idx;
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1_"+sGXsfl_40_idx;
         chkavSdtcarga__embalaje_Internalname = sPrefix+"SDTCARGA__EMBALAJE_"+sGXsfl_40_idx;
         lblTextblock2_Internalname = sPrefix+"TEXTBLOCK2_"+sGXsfl_40_idx;
         edtavSdtcarga__embalajecant_Internalname = sPrefix+"SDTCARGA__EMBALAJECANT_"+sGXsfl_40_idx;
         chkavSdtcarga__elevacion_Internalname = sPrefix+"SDTCARGA__ELEVACION_"+sGXsfl_40_idx;
         lblTextblock3_Internalname = sPrefix+"TEXTBLOCK3_"+sGXsfl_40_idx;
         edtavSdtcarga__elevacioncant_Internalname = sPrefix+"SDTCARGA__ELEVACIONCANT_"+sGXsfl_40_idx;
      }

      protected void SubsflControlProps_fel_402( )
      {
         edtavSdtcarga__nombre_Internalname = sPrefix+"SDTCARGA__NOMBRE_"+sGXsfl_40_fel_idx;
         lblSdtcarga__nombre_tags_Internalname = sPrefix+"SDTCARGA__NOMBRE_TAGS_"+sGXsfl_40_fel_idx;
         lblSubtract_Internalname = sPrefix+"SUBTRACT_"+sGXsfl_40_fel_idx;
         cmbavSdtcarga__cantidad_Internalname = sPrefix+"SDTCARGA__CANTIDAD_"+sGXsfl_40_fel_idx;
         lblAdd_Internalname = sPrefix+"ADD_"+sGXsfl_40_fel_idx;
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1_"+sGXsfl_40_fel_idx;
         chkavSdtcarga__embalaje_Internalname = sPrefix+"SDTCARGA__EMBALAJE_"+sGXsfl_40_fel_idx;
         lblTextblock2_Internalname = sPrefix+"TEXTBLOCK2_"+sGXsfl_40_fel_idx;
         edtavSdtcarga__embalajecant_Internalname = sPrefix+"SDTCARGA__EMBALAJECANT_"+sGXsfl_40_fel_idx;
         chkavSdtcarga__elevacion_Internalname = sPrefix+"SDTCARGA__ELEVACION_"+sGXsfl_40_fel_idx;
         lblTextblock3_Internalname = sPrefix+"TEXTBLOCK3_"+sGXsfl_40_fel_idx;
         edtavSdtcarga__elevacioncant_Internalname = sPrefix+"SDTCARGA__ELEVACIONCANT_"+sGXsfl_40_fel_idx;
      }

      protected void sendrow_402( )
      {
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         WBGO0( ) ;
         Freestylegrid1Row = GXWebRow.GetNew(context,Freestylegrid1Container);
         if ( subFreestylegrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFreestylegrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
            }
         }
         else if ( subFreestylegrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFreestylegrid1_Backstyle = 0;
            subFreestylegrid1_Backcolor = subFreestylegrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Uniform";
            }
         }
         else if ( subFreestylegrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFreestylegrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
            {
               subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
            }
            subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFreestylegrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFreestylegrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_40_idx) % (2))) == 0 )
            {
               subFreestylegrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Even";
               }
            }
            else
            {
               subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFreestylegrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_40_idx+"\">") ;
         }
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)subFreestylegrid1_Linesclass,(string)""});
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Table start */
         Freestylegrid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTablemergedsdtcarga__nombre_Internalname+"_"+sGXsfl_40_idx,(short)1,(string)"TableMerged",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)0,(short)0,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'" + sGXsfl_40_idx + "',40)\"";
         ROClassString = edtavSdtcarga__nombre_Class;
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtcarga__nombre_Internalname,((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Nombre,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ESDTCARGA__NOMBRE.CLICK."+sGXsfl_40_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtcarga__nombre_Jsonclick,(short)5,(string)edtavSdtcarga__nombre_Class,"font-size:"+StringUtil.Str( (decimal)(edtavSdtcarga__nombre_Fontsize), 3, 0)+"pt;",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdtcarga__nombre_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblSdtcarga__nombre_tags_Internalname,(string)lblSdtcarga__nombre_tags_Caption,(string)"",(string)"",(string)lblSdtcarga__nombre_tags_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("row");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("table");
         }
         /* End of table */
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Table start */
         Freestylegrid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtable1_Internalname+"_"+sGXsfl_40_idx,(short)1,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblSubtract_Internalname,context.GetMessage( "<i class=\"AttributeColorInfo fas fa-square-minus\"></i>", ""),(string)"",(string)"",(string)lblSubtract_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOSUBTRACT\\'."+sGXsfl_40_idx+"'","font-size:"+StringUtil.Str( (decimal)(lblSubtract_Fontsize), 3, 0)+"pt;",(string)"TextBlock",(short)5,(string)"",(short)1,(short)1,(short)0,(short)1});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_40_idx + "',40)\"";
         if ( ( cmbavSdtcarga__cantidad.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "SDTCARGA__CANTIDAD_" + sGXsfl_40_idx;
            cmbavSdtcarga__cantidad.Name = GXCCtl;
            cmbavSdtcarga__cantidad.WebTags = "";
            cmbavSdtcarga__cantidad.addItem("0", "0", 0);
            cmbavSdtcarga__cantidad.addItem("1", "1", 0);
            cmbavSdtcarga__cantidad.addItem("2", "2", 0);
            cmbavSdtcarga__cantidad.addItem("3", "3", 0);
            cmbavSdtcarga__cantidad.addItem("4", "4", 0);
            cmbavSdtcarga__cantidad.addItem("5", "5", 0);
            cmbavSdtcarga__cantidad.addItem("6", "6", 0);
            cmbavSdtcarga__cantidad.addItem("7", "7", 0);
            cmbavSdtcarga__cantidad.addItem("8", "8", 0);
            cmbavSdtcarga__cantidad.addItem("9", "9", 0);
            cmbavSdtcarga__cantidad.addItem("10", "10", 0);
            cmbavSdtcarga__cantidad.addItem("11", "11", 0);
            cmbavSdtcarga__cantidad.addItem("12", "12", 0);
            cmbavSdtcarga__cantidad.addItem("13", "13", 0);
            cmbavSdtcarga__cantidad.addItem("14", "14", 0);
            cmbavSdtcarga__cantidad.addItem("15", "15", 0);
            cmbavSdtcarga__cantidad.addItem("16", "16", 0);
            cmbavSdtcarga__cantidad.addItem("17", "17", 0);
            cmbavSdtcarga__cantidad.addItem("18", "18", 0);
            cmbavSdtcarga__cantidad.addItem("19", "19", 0);
            cmbavSdtcarga__cantidad.addItem("20", "20", 0);
            cmbavSdtcarga__cantidad.addItem("21", "21", 0);
            cmbavSdtcarga__cantidad.addItem("22", "22", 0);
            cmbavSdtcarga__cantidad.addItem("23", "23", 0);
            cmbavSdtcarga__cantidad.addItem("24", "24", 0);
            cmbavSdtcarga__cantidad.addItem("25", "25", 0);
            cmbavSdtcarga__cantidad.addItem("26", "26", 0);
            cmbavSdtcarga__cantidad.addItem("27", "27", 0);
            cmbavSdtcarga__cantidad.addItem("28", "28", 0);
            cmbavSdtcarga__cantidad.addItem("29", "29", 0);
            cmbavSdtcarga__cantidad.addItem("30", "30", 0);
            cmbavSdtcarga__cantidad.addItem("31", "31", 0);
            cmbavSdtcarga__cantidad.addItem("32", "32", 0);
            cmbavSdtcarga__cantidad.addItem("33", "33", 0);
            cmbavSdtcarga__cantidad.addItem("34", "34", 0);
            cmbavSdtcarga__cantidad.addItem("35", "35", 0);
            cmbavSdtcarga__cantidad.addItem("36", "36", 0);
            cmbavSdtcarga__cantidad.addItem("37", "37", 0);
            cmbavSdtcarga__cantidad.addItem("38", "38", 0);
            cmbavSdtcarga__cantidad.addItem("39", "39", 0);
            cmbavSdtcarga__cantidad.addItem("40", "40", 0);
            cmbavSdtcarga__cantidad.addItem("41", "41", 0);
            cmbavSdtcarga__cantidad.addItem("42", "42", 0);
            cmbavSdtcarga__cantidad.addItem("43", "43", 0);
            cmbavSdtcarga__cantidad.addItem("44", "44", 0);
            cmbavSdtcarga__cantidad.addItem("45", "45", 0);
            cmbavSdtcarga__cantidad.addItem("46", "46", 0);
            cmbavSdtcarga__cantidad.addItem("47", "47", 0);
            cmbavSdtcarga__cantidad.addItem("48", "48", 0);
            cmbavSdtcarga__cantidad.addItem("49", "49", 0);
            cmbavSdtcarga__cantidad.addItem("50", "50", 0);
            cmbavSdtcarga__cantidad.addItem("51", "51", 0);
            cmbavSdtcarga__cantidad.addItem("52", "52", 0);
            cmbavSdtcarga__cantidad.addItem("53", "53", 0);
            cmbavSdtcarga__cantidad.addItem("54", "54", 0);
            cmbavSdtcarga__cantidad.addItem("55", "55", 0);
            cmbavSdtcarga__cantidad.addItem("56", "56", 0);
            cmbavSdtcarga__cantidad.addItem("57", "57", 0);
            cmbavSdtcarga__cantidad.addItem("58", "58", 0);
            cmbavSdtcarga__cantidad.addItem("59", "59", 0);
            cmbavSdtcarga__cantidad.addItem("60", "60", 0);
            cmbavSdtcarga__cantidad.addItem("61", "61", 0);
            cmbavSdtcarga__cantidad.addItem("62", "62", 0);
            cmbavSdtcarga__cantidad.addItem("63", "63", 0);
            cmbavSdtcarga__cantidad.addItem("64", "64", 0);
            cmbavSdtcarga__cantidad.addItem("65", "65", 0);
            cmbavSdtcarga__cantidad.addItem("66", "66", 0);
            cmbavSdtcarga__cantidad.addItem("67", "67", 0);
            cmbavSdtcarga__cantidad.addItem("68", "68", 0);
            cmbavSdtcarga__cantidad.addItem("69", "69", 0);
            cmbavSdtcarga__cantidad.addItem("70", "70", 0);
            cmbavSdtcarga__cantidad.addItem("71", "71", 0);
            cmbavSdtcarga__cantidad.addItem("72", "72", 0);
            cmbavSdtcarga__cantidad.addItem("73", "73", 0);
            cmbavSdtcarga__cantidad.addItem("74", "74", 0);
            cmbavSdtcarga__cantidad.addItem("75", "75", 0);
            cmbavSdtcarga__cantidad.addItem("76", "76", 0);
            cmbavSdtcarga__cantidad.addItem("77", "77", 0);
            cmbavSdtcarga__cantidad.addItem("78", "78", 0);
            cmbavSdtcarga__cantidad.addItem("79", "79", 0);
            cmbavSdtcarga__cantidad.addItem("80", "80", 0);
            cmbavSdtcarga__cantidad.addItem("81", "81", 0);
            cmbavSdtcarga__cantidad.addItem("82", "82", 0);
            cmbavSdtcarga__cantidad.addItem("83", "83", 0);
            cmbavSdtcarga__cantidad.addItem("84", "84", 0);
            cmbavSdtcarga__cantidad.addItem("85", "85", 0);
            cmbavSdtcarga__cantidad.addItem("86", "86", 0);
            cmbavSdtcarga__cantidad.addItem("87", "87", 0);
            cmbavSdtcarga__cantidad.addItem("88", "88", 0);
            cmbavSdtcarga__cantidad.addItem("89", "89", 0);
            cmbavSdtcarga__cantidad.addItem("90", "90", 0);
            cmbavSdtcarga__cantidad.addItem("91", "91", 0);
            cmbavSdtcarga__cantidad.addItem("92", "92", 0);
            cmbavSdtcarga__cantidad.addItem("93", "93", 0);
            cmbavSdtcarga__cantidad.addItem("94", "94", 0);
            cmbavSdtcarga__cantidad.addItem("95", "95", 0);
            cmbavSdtcarga__cantidad.addItem("96", "96", 0);
            cmbavSdtcarga__cantidad.addItem("97", "97", 0);
            cmbavSdtcarga__cantidad.addItem("98", "98", 0);
            cmbavSdtcarga__cantidad.addItem("99", "99", 0);
            if ( cmbavSdtcarga__cantidad.ItemCount > 0 )
            {
               if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) && (0==((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Cantidad) )
               {
                  ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Cantidad = (short)(Math.Round(NumberUtil.Val( cmbavSdtcarga__cantidad.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Cantidad), 2, 0))), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         /* ComboBox */
         Freestylegrid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdtcarga__cantidad,(string)cmbavSdtcarga__cantidad_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Cantidad), 2, 0)),(short)1,(string)cmbavSdtcarga__cantidad_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)1,(short)1,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"","font-size:"+StringUtil.Str( (decimal)(cmbavSdtcarga__cantidad.FontSize), 3, 0)+"pt;",(string)cmbavSdtcarga__cantidad_Class,(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"",(bool)true,(short)0});
         cmbavSdtcarga__cantidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Cantidad), 2, 0));
         AssignProp(sPrefix, false, cmbavSdtcarga__cantidad_Internalname, "Values", (string)(cmbavSdtcarga__cantidad.ToJavascriptSource()), !bGXsfl_40_Refreshing);
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblAdd_Internalname,context.GetMessage( "<i class=\"fas fa-square-plus\"></i>", ""),(string)"",(string)"",(string)lblAdd_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOADD\\'."+sGXsfl_40_idx+"'","font-size:"+StringUtil.Str( (decimal)(lblAdd_Fontsize), 3, 0)+"pt;",(string)"TextBlock",(short)5,(string)"",(short)1,(short)1,(short)0,(short)1});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("row");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("table");
         }
         /* End of table */
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTextblock1_Internalname,(string)" ",(string)"",(string)"",(string)lblTextblock1_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'" + sGXsfl_40_idx + "',40)\"";
         ClassString = chkavSdtcarga__embalaje_Class;
         StyleString = "";
         GXCCtl = "SDTCARGA__EMBALAJE_" + sGXsfl_40_idx;
         chkavSdtcarga__embalaje.Name = GXCCtl;
         chkavSdtcarga__embalaje.WebTags = "";
         chkavSdtcarga__embalaje.Caption = "";
         AssignProp(sPrefix, false, chkavSdtcarga__embalaje_Internalname, "TitleCaption", chkavSdtcarga__embalaje.Caption, !bGXsfl_40_Refreshing);
         chkavSdtcarga__embalaje.CheckedValue = "false";
         Freestylegrid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSdtcarga__embalaje_Internalname,StringUtil.BoolToStr( ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Embalaje),(string)"",(string)"",(short)1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onblur=\""+""+";gx.evt.onblur(this,61);\""});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTextblock2_Internalname,(string)" ",(string)"",(string)"",(string)lblTextblock2_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'" + sPrefix + "',false,'" + sGXsfl_40_idx + "',40)\"";
         ROClassString = edtavSdtcarga__embalajecant_Class;
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtcarga__embalajecant_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Embalajecant), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavSdtcarga__embalajecant_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Embalajecant), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Embalajecant), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,65);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtcarga__embalajecant_Jsonclick,(short)0,(string)edtavSdtcarga__embalajecant_Class,(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdtcarga__embalajecant_Enabled,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'" + sGXsfl_40_idx + "',40)\"";
         ClassString = chkavSdtcarga__elevacion_Class;
         StyleString = "";
         GXCCtl = "SDTCARGA__ELEVACION_" + sGXsfl_40_idx;
         chkavSdtcarga__elevacion.Name = GXCCtl;
         chkavSdtcarga__elevacion.WebTags = "";
         chkavSdtcarga__elevacion.Caption = "";
         AssignProp(sPrefix, false, chkavSdtcarga__elevacion_Internalname, "TitleCaption", chkavSdtcarga__elevacion.Caption, !bGXsfl_40_Refreshing);
         chkavSdtcarga__elevacion.CheckedValue = "false";
         Freestylegrid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSdtcarga__elevacion_Internalname,StringUtil.BoolToStr( ((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Elevacion),(string)"",(string)"",(short)1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onblur=\""+""+";gx.evt.onblur(this,67);\""});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         sendrow_40230( ) ;
      }

      protected void sendrow_40230( )
      {
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Text block */
         Freestylegrid1Row.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTextblock3_Internalname,(string)" ",(string)"",(string)"",(string)lblTextblock3_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'" + sGXsfl_40_idx + "',40)\"";
         ROClassString = edtavSdtcarga__elevacioncant_Class;
         Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtcarga__elevacioncant_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Elevacioncant), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavSdtcarga__elevacioncant_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Elevacioncant), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Elevacioncant), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,71);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtcarga__elevacioncant_Jsonclick,(short)0,(string)edtavSdtcarga__elevacioncant_Class,(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdtcarga__elevacioncant_Enabled,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("row");
         }
         Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)subFreestylegrid1_Linesclass,(string)""});
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",""+" style=\""+CSSHelper.Prettify( "width:310px")+"\"",(string)""});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         Freestylegrid1Row.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttBtncantidadembelev_Internalname+"_"+sGXsfl_40_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");",context.GetMessage( "Prueba", ""),(string)bttBtncantidadembelev_Jsonclick,(short)7,context.GetMessage( "Prueba", ""),(string)"",(string)StyleString,(string)ClassString,(int)bttBtncantidadembelev_Visible,(short)1,(string)"standard",(string)"'"+sPrefix+"'"+",false,"+"'"+"e27go2_client"+"'",(string)TempTags,(string)"",(short)2});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",""+" style=\""+CSSHelper.Prettify( "width:120px")+"\"",(string)""});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         Freestylegrid1Row.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttBtncantidadembelev2_Internalname+"_"+sGXsfl_40_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");",context.GetMessage( "Prueba", ""),(string)bttBtncantidadembelev2_Jsonclick,(short)7,context.GetMessage( "Prueba", ""),(string)"",(string)StyleString,(string)ClassString,(int)bttBtncantidadembelev2_Visible,(short)1,(string)"standard",(string)"'"+sPrefix+"'"+",false,"+"'"+"e28go2_client"+"'",(string)TempTags,(string)"",(short)2});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",""+" style=\""+CSSHelper.Prettify( "width:60px")+"\"",(string)""});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         Freestylegrid1Row.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttBtndescripcion_Internalname+"_"+sGXsfl_40_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");",context.GetMessage( "Tooltip", ""),(string)bttBtndescripcion_Jsonclick,(short)7,context.GetMessage( "Tooltip", ""),(string)"",(string)StyleString,(string)ClassString,(int)bttBtndescripcion_Visible,(short)1,(string)"standard",(string)"'"+sPrefix+"'"+",false,"+"'"+"e29go2_client"+"'",(string)TempTags,(string)"",(short)2});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("cell");
         }
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            Freestylegrid1Container.CloseTag("row");
         }
         send_integrity_lvl_hashesGO2( ) ;
         /* End of Columns property logic. */
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            if ( 1 > 0 )
            {
               if ( ((int)((nGXsfl_40_idx) % (1))) == 0 )
               {
                  context.WriteHtmlTextNl( "</tr>") ;
               }
            }
         }
         Freestylegrid1Container.AddRow(Freestylegrid1Row);
         nGXsfl_40_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_40_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         /* End function sendrow_402 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SDTCARGA__CANTIDAD_" + sGXsfl_40_idx;
         cmbavSdtcarga__cantidad.Name = GXCCtl;
         cmbavSdtcarga__cantidad.WebTags = "";
         cmbavSdtcarga__cantidad.addItem("0", "0", 0);
         cmbavSdtcarga__cantidad.addItem("1", "1", 0);
         cmbavSdtcarga__cantidad.addItem("2", "2", 0);
         cmbavSdtcarga__cantidad.addItem("3", "3", 0);
         cmbavSdtcarga__cantidad.addItem("4", "4", 0);
         cmbavSdtcarga__cantidad.addItem("5", "5", 0);
         cmbavSdtcarga__cantidad.addItem("6", "6", 0);
         cmbavSdtcarga__cantidad.addItem("7", "7", 0);
         cmbavSdtcarga__cantidad.addItem("8", "8", 0);
         cmbavSdtcarga__cantidad.addItem("9", "9", 0);
         cmbavSdtcarga__cantidad.addItem("10", "10", 0);
         cmbavSdtcarga__cantidad.addItem("11", "11", 0);
         cmbavSdtcarga__cantidad.addItem("12", "12", 0);
         cmbavSdtcarga__cantidad.addItem("13", "13", 0);
         cmbavSdtcarga__cantidad.addItem("14", "14", 0);
         cmbavSdtcarga__cantidad.addItem("15", "15", 0);
         cmbavSdtcarga__cantidad.addItem("16", "16", 0);
         cmbavSdtcarga__cantidad.addItem("17", "17", 0);
         cmbavSdtcarga__cantidad.addItem("18", "18", 0);
         cmbavSdtcarga__cantidad.addItem("19", "19", 0);
         cmbavSdtcarga__cantidad.addItem("20", "20", 0);
         cmbavSdtcarga__cantidad.addItem("21", "21", 0);
         cmbavSdtcarga__cantidad.addItem("22", "22", 0);
         cmbavSdtcarga__cantidad.addItem("23", "23", 0);
         cmbavSdtcarga__cantidad.addItem("24", "24", 0);
         cmbavSdtcarga__cantidad.addItem("25", "25", 0);
         cmbavSdtcarga__cantidad.addItem("26", "26", 0);
         cmbavSdtcarga__cantidad.addItem("27", "27", 0);
         cmbavSdtcarga__cantidad.addItem("28", "28", 0);
         cmbavSdtcarga__cantidad.addItem("29", "29", 0);
         cmbavSdtcarga__cantidad.addItem("30", "30", 0);
         cmbavSdtcarga__cantidad.addItem("31", "31", 0);
         cmbavSdtcarga__cantidad.addItem("32", "32", 0);
         cmbavSdtcarga__cantidad.addItem("33", "33", 0);
         cmbavSdtcarga__cantidad.addItem("34", "34", 0);
         cmbavSdtcarga__cantidad.addItem("35", "35", 0);
         cmbavSdtcarga__cantidad.addItem("36", "36", 0);
         cmbavSdtcarga__cantidad.addItem("37", "37", 0);
         cmbavSdtcarga__cantidad.addItem("38", "38", 0);
         cmbavSdtcarga__cantidad.addItem("39", "39", 0);
         cmbavSdtcarga__cantidad.addItem("40", "40", 0);
         cmbavSdtcarga__cantidad.addItem("41", "41", 0);
         cmbavSdtcarga__cantidad.addItem("42", "42", 0);
         cmbavSdtcarga__cantidad.addItem("43", "43", 0);
         cmbavSdtcarga__cantidad.addItem("44", "44", 0);
         cmbavSdtcarga__cantidad.addItem("45", "45", 0);
         cmbavSdtcarga__cantidad.addItem("46", "46", 0);
         cmbavSdtcarga__cantidad.addItem("47", "47", 0);
         cmbavSdtcarga__cantidad.addItem("48", "48", 0);
         cmbavSdtcarga__cantidad.addItem("49", "49", 0);
         cmbavSdtcarga__cantidad.addItem("50", "50", 0);
         cmbavSdtcarga__cantidad.addItem("51", "51", 0);
         cmbavSdtcarga__cantidad.addItem("52", "52", 0);
         cmbavSdtcarga__cantidad.addItem("53", "53", 0);
         cmbavSdtcarga__cantidad.addItem("54", "54", 0);
         cmbavSdtcarga__cantidad.addItem("55", "55", 0);
         cmbavSdtcarga__cantidad.addItem("56", "56", 0);
         cmbavSdtcarga__cantidad.addItem("57", "57", 0);
         cmbavSdtcarga__cantidad.addItem("58", "58", 0);
         cmbavSdtcarga__cantidad.addItem("59", "59", 0);
         cmbavSdtcarga__cantidad.addItem("60", "60", 0);
         cmbavSdtcarga__cantidad.addItem("61", "61", 0);
         cmbavSdtcarga__cantidad.addItem("62", "62", 0);
         cmbavSdtcarga__cantidad.addItem("63", "63", 0);
         cmbavSdtcarga__cantidad.addItem("64", "64", 0);
         cmbavSdtcarga__cantidad.addItem("65", "65", 0);
         cmbavSdtcarga__cantidad.addItem("66", "66", 0);
         cmbavSdtcarga__cantidad.addItem("67", "67", 0);
         cmbavSdtcarga__cantidad.addItem("68", "68", 0);
         cmbavSdtcarga__cantidad.addItem("69", "69", 0);
         cmbavSdtcarga__cantidad.addItem("70", "70", 0);
         cmbavSdtcarga__cantidad.addItem("71", "71", 0);
         cmbavSdtcarga__cantidad.addItem("72", "72", 0);
         cmbavSdtcarga__cantidad.addItem("73", "73", 0);
         cmbavSdtcarga__cantidad.addItem("74", "74", 0);
         cmbavSdtcarga__cantidad.addItem("75", "75", 0);
         cmbavSdtcarga__cantidad.addItem("76", "76", 0);
         cmbavSdtcarga__cantidad.addItem("77", "77", 0);
         cmbavSdtcarga__cantidad.addItem("78", "78", 0);
         cmbavSdtcarga__cantidad.addItem("79", "79", 0);
         cmbavSdtcarga__cantidad.addItem("80", "80", 0);
         cmbavSdtcarga__cantidad.addItem("81", "81", 0);
         cmbavSdtcarga__cantidad.addItem("82", "82", 0);
         cmbavSdtcarga__cantidad.addItem("83", "83", 0);
         cmbavSdtcarga__cantidad.addItem("84", "84", 0);
         cmbavSdtcarga__cantidad.addItem("85", "85", 0);
         cmbavSdtcarga__cantidad.addItem("86", "86", 0);
         cmbavSdtcarga__cantidad.addItem("87", "87", 0);
         cmbavSdtcarga__cantidad.addItem("88", "88", 0);
         cmbavSdtcarga__cantidad.addItem("89", "89", 0);
         cmbavSdtcarga__cantidad.addItem("90", "90", 0);
         cmbavSdtcarga__cantidad.addItem("91", "91", 0);
         cmbavSdtcarga__cantidad.addItem("92", "92", 0);
         cmbavSdtcarga__cantidad.addItem("93", "93", 0);
         cmbavSdtcarga__cantidad.addItem("94", "94", 0);
         cmbavSdtcarga__cantidad.addItem("95", "95", 0);
         cmbavSdtcarga__cantidad.addItem("96", "96", 0);
         cmbavSdtcarga__cantidad.addItem("97", "97", 0);
         cmbavSdtcarga__cantidad.addItem("98", "98", 0);
         cmbavSdtcarga__cantidad.addItem("99", "99", 0);
         if ( cmbavSdtcarga__cantidad.ItemCount > 0 )
         {
            if ( ( AV42GXV1 > 0 ) && ( AV13SDTCarga.Count >= AV42GXV1 ) && (0==((SdtSDTCarga_SDTCargaItem)AV13SDTCarga.Item(AV42GXV1)).gxTpr_Cantidad) )
            {
            }
         }
         GXCCtl = "SDTCARGA__EMBALAJE_" + sGXsfl_40_idx;
         chkavSdtcarga__embalaje.Name = GXCCtl;
         chkavSdtcarga__embalaje.WebTags = "";
         chkavSdtcarga__embalaje.Caption = "";
         AssignProp(sPrefix, false, chkavSdtcarga__embalaje_Internalname, "TitleCaption", chkavSdtcarga__embalaje.Caption, !bGXsfl_40_Refreshing);
         chkavSdtcarga__embalaje.CheckedValue = "false";
         GXCCtl = "SDTCARGA__ELEVACION_" + sGXsfl_40_idx;
         chkavSdtcarga__elevacion.Name = GXCCtl;
         chkavSdtcarga__elevacion.WebTags = "";
         chkavSdtcarga__elevacion.Caption = "";
         AssignProp(sPrefix, false, chkavSdtcarga__elevacion_Internalname, "TitleCaption", chkavSdtcarga__elevacion.Caption, !bGXsfl_40_Refreshing);
         chkavSdtcarga__elevacion.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl40( )
      {
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Freestylegrid1Container"+"DivS\" data-gxgridid=\"40\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreestylegrid1_Internalname, subFreestylegrid1_Internalname, "", subFreestylegrid1_Class, 0, "", "", 1, 2, sStyleString, "", "", 0);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         }
         else
         {
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
            Freestylegrid1Container.AddObjectProperty("Header", subFreestylegrid1_Header);
            Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( subFreestylegrid1_Class));
            Freestylegrid1Container.AddObjectProperty("Class", subFreestylegrid1_Class);
            Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("CmpContext", sPrefix);
            Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Fontsize", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtcarga__nombre_Fontsize), 9, 0, ".", "")));
            Freestylegrid1Column.AddObjectProperty("Class", StringUtil.RTrim( edtavSdtcarga__nombre_Class));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtcarga__nombre_Enabled), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblSdtcarga__nombre_tags_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblSubtract_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Fontsize", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdtcarga__cantidad.FontSize), 9, 0, ".", "")));
            Freestylegrid1Column.AddObjectProperty("Class", StringUtil.RTrim( cmbavSdtcarga__cantidad_Class));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblAdd_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblTextblock1_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Class", StringUtil.RTrim( chkavSdtcarga__embalaje_Class));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblTextblock1_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Class", StringUtil.RTrim( edtavSdtcarga__embalajecant_Class));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtcarga__embalajecant_Enabled), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Class", StringUtil.RTrim( chkavSdtcarga__elevacion_Class));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", lblTextblock1_Caption);
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Class", StringUtil.RTrim( edtavSdtcarga__elevacioncant_Class));
            Freestylegrid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtcarga__elevacioncant_Enabled), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectedindex), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowselection), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectioncolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowhovering), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Hoveringcolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowcollapsing), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblocksdtcarga__nombre_Internalname = sPrefix+"TEXTBLOCKSDTCARGA__NOMBRE";
         lblTextblocksdtcarga__embalaje_Internalname = sPrefix+"TEXTBLOCKSDTCARGA__EMBALAJE";
         lblTextblocksdtcarga__embalajecant_Internalname = sPrefix+"TEXTBLOCKSDTCARGA__EMBALAJECANT";
         lblTextblocksdtcarga__elevacion_Internalname = sPrefix+"TEXTBLOCKSDTCARGA__ELEVACION";
         cellTitlecantidadembelev_cell_Internalname = sPrefix+"TITLECANTIDADEMBELEV_CELL";
         cellTitlecantidadembelev2_cell_Internalname = sPrefix+"TITLECANTIDADEMBELEV2_CELL";
         cellTitledescripcion_cell_Internalname = sPrefix+"TITLEDESCRIPCION_CELL";
         tblFreestylegrid1_descriptionstable_Internalname = sPrefix+"FREESTYLEGRID1_DESCRIPTIONSTABLE";
         edtavSdtcarga__nombre_Internalname = sPrefix+"SDTCARGA__NOMBRE";
         lblSdtcarga__nombre_tags_Internalname = sPrefix+"SDTCARGA__NOMBRE_TAGS";
         tblTablemergedsdtcarga__nombre_Internalname = sPrefix+"TABLEMERGEDSDTCARGA__NOMBRE";
         lblSubtract_Internalname = sPrefix+"SUBTRACT";
         cmbavSdtcarga__cantidad_Internalname = sPrefix+"SDTCARGA__CANTIDAD";
         lblAdd_Internalname = sPrefix+"ADD";
         tblUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1";
         chkavSdtcarga__embalaje_Internalname = sPrefix+"SDTCARGA__EMBALAJE";
         lblTextblock2_Internalname = sPrefix+"TEXTBLOCK2";
         edtavSdtcarga__embalajecant_Internalname = sPrefix+"SDTCARGA__EMBALAJECANT";
         chkavSdtcarga__elevacion_Internalname = sPrefix+"SDTCARGA__ELEVACION";
         lblTextblock3_Internalname = sPrefix+"TEXTBLOCK3";
         edtavSdtcarga__elevacioncant_Internalname = sPrefix+"SDTCARGA__ELEVACIONCANT";
         bttBtncantidadembelev_Internalname = sPrefix+"BTNCANTIDADEMBELEV";
         cellCantidadembelev_cell_Internalname = sPrefix+"CANTIDADEMBELEV_CELL";
         bttBtncantidadembelev2_Internalname = sPrefix+"BTNCANTIDADEMBELEV2";
         cellCantidadembelev2_cell_Internalname = sPrefix+"CANTIDADEMBELEV2_CELL";
         bttBtndescripcion_Internalname = sPrefix+"BTNDESCRIPCION";
         cellDescripcion_cell_Internalname = sPrefix+"DESCRIPCION_CELL";
         tblFreestylegrid1_headertable_Internalname = sPrefix+"FREESTYLEGRID1_HEADERTABLE";
         divHtml_freestylegrid1_Internalname = sPrefix+"HTML_FREESTYLEGRID1";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Cantidadembelev_modal_Internalname = sPrefix+"CANTIDADEMBELEV_MODAL";
         tblTablecantidadembelev_modal_Internalname = sPrefix+"TABLECANTIDADEMBELEV_MODAL";
         Cantidadembelev2_modal_Internalname = sPrefix+"CANTIDADEMBELEV2_MODAL";
         tblTablecantidadembelev2_modal_Internalname = sPrefix+"TABLECANTIDADEMBELEV2_MODAL";
         Descripcion_modal_Internalname = sPrefix+"DESCRIPCION_MODAL";
         tblTabledescripcion_modal_Internalname = sPrefix+"TABLEDESCRIPCION_MODAL";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subFreestylegrid1_Internalname = sPrefix+"FREESTYLEGRID1";
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
         subFreestylegrid1_Allowcollapsing = 0;
         lblTextblock1_Caption = " ";
         lblAdd_Caption = context.GetMessage( "<i class=\"fas fa-square-plus\"></i>", "");
         lblSubtract_Caption = context.GetMessage( "<i class=\"AttributeColorInfo fas fa-square-minus\"></i>", "");
         lblSdtcarga__nombre_tags_Caption = context.GetMessage( "Text Block", "");
         bttBtndescripcion_Visible = 1;
         bttBtncantidadembelev2_Visible = 1;
         bttBtncantidadembelev_Visible = 1;
         edtavSdtcarga__elevacioncant_Jsonclick = "";
         edtavSdtcarga__elevacioncant_Class = "AttributeColorDanger";
         edtavSdtcarga__elevacioncant_Enabled = 0;
         chkavSdtcarga__elevacion.Caption = "";
         chkavSdtcarga__elevacion_Class = "Attribute";
         edtavSdtcarga__embalajecant_Jsonclick = "";
         edtavSdtcarga__embalajecant_Class = "AttributeColorDanger";
         edtavSdtcarga__embalajecant_Enabled = 0;
         chkavSdtcarga__embalaje.Caption = "";
         chkavSdtcarga__embalaje_Class = "Attribute";
         lblAdd_Fontsize = (int)(Math.Round(12.0m, 18, MidpointRounding.ToEven));
         cmbavSdtcarga__cantidad_Jsonclick = "";
         cmbavSdtcarga__cantidad_Class = "Attribute";
         cmbavSdtcarga__cantidad.FontSize = (int)(Math.Round(12.0m, 18, MidpointRounding.ToEven));
         lblSubtract_Fontsize = (int)(Math.Round(12.0m, 18, MidpointRounding.ToEven));
         edtavSdtcarga__nombre_Jsonclick = "";
         edtavSdtcarga__nombre_Class = "Attribute";
         edtavSdtcarga__nombre_Fontsize = (int)(Math.Round(12.0m, 18, MidpointRounding.ToEven));
         edtavSdtcarga__nombre_Enabled = 0;
         subFreestylegrid1_Allbackcolor = (int)(0xFFFFFF);
         lblSdtcarga__nombre_tags_Caption = context.GetMessage( "Text Block", "");
         subFreestylegrid1_Backcolorstyle = 1;
         subFreestylegrid1_Class = "FSSingleLine FreeStyleGridWithHeader";
         Descripcion_modal_Bodytype = "WebComponent";
         Descripcion_modal_Confirmtype = "";
         Descripcion_modal_Title = context.GetMessage( "Descripcion Producto", "");
         Descripcion_modal_Width = "800";
         Cantidadembelev2_modal_Bodytype = "WebComponent";
         Cantidadembelev2_modal_Confirmtype = "";
         Cantidadembelev2_modal_Title = context.GetMessage( "Elevación: seleccione la cantidad...", "");
         Cantidadembelev2_modal_Width = "400";
         Cantidadembelev_modal_Bodytype = "WebComponent";
         Cantidadembelev_modal_Confirmtype = "";
         Cantidadembelev_modal_Title = context.GetMessage( "Embalaje: seleccione la cantidad...", "");
         Cantidadembelev_modal_Width = "400";
         edtavSdtcarga__elevacioncant_Enabled = -1;
         edtavSdtcarga__embalajecant_Enabled = -1;
         edtavSdtcarga__nombre_Enabled = -1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'BTNCANTIDADEMBELEV',prop:'Visible'},{ctrl:'BTNCANTIDADEMBELEV2',prop:'Visible'},{ctrl:'BTNDESCRIPCION',prop:'Visible'}]}");
         setEventMetadata("FREESTYLEGRID1.LOAD","{handler:'E20GO2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'}]");
         setEventMetadata("FREESTYLEGRID1.LOAD",",oparms:[{ctrl:'SDTCARGA__NOMBRE',prop:'Fontsize'},{ctrl:'SDTCARGA__CANTIDAD',prop:'Fontsize'},{av:'lblAdd_Fontsize',ctrl:'ADD',prop:'Fontsize'},{av:'lblSubtract_Fontsize',ctrl:'SUBTRACT',prop:'Fontsize'},{av:'lblSdtcarga__nombre_tags_Caption',ctrl:'SDTCARGA__NOMBRE_TAGS',prop:'Caption'}]}");
         setEventMetadata("'DOCANTIDADEMBELEV'","{handler:'E27GO2',iparms:[]");
         setEventMetadata("'DOCANTIDADEMBELEV'",",oparms:[]}");
         setEventMetadata("CANTIDADEMBELEV_MODAL.ONLOADCOMPONENT","{handler:'E12GO2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'}]");
         setEventMetadata("CANTIDADEMBELEV_MODAL.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("'DOCANTIDADEMBELEV2'","{handler:'E28GO2',iparms:[]");
         setEventMetadata("'DOCANTIDADEMBELEV2'",",oparms:[]}");
         setEventMetadata("CANTIDADEMBELEV2_MODAL.ONLOADCOMPONENT","{handler:'E14GO2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'}]");
         setEventMetadata("CANTIDADEMBELEV2_MODAL.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("'DODESCRIPCION'","{handler:'E29GO2',iparms:[]");
         setEventMetadata("'DODESCRIPCION'",",oparms:[]}");
         setEventMetadata("DESCRIPCION_MODAL.ONLOADCOMPONENT","{handler:'E16GO2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'}]");
         setEventMetadata("DESCRIPCION_MODAL.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("DESCRIPCION_MODAL.CLOSE","{handler:'E15GO2',iparms:[{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("DESCRIPCION_MODAL.CLOSE",",oparms:[{ctrl:'BTNCANTIDADEMBELEV',prop:'Visible'},{ctrl:'BTNCANTIDADEMBELEV2',prop:'Visible'},{ctrl:'BTNDESCRIPCION',prop:'Visible'}]}");
         setEventMetadata("'DOSUBTRACT'","{handler:'E21GO2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("'DOSUBTRACT'",",oparms:[{av:'AV23Valor',fld:'vVALOR',pic:'ZZZZ9.99',type:'decimal'},{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'AV21SDTCargaJson',fld:'vSDTCARGAJSON',pic:'',type:'vchar'}]}");
         setEventMetadata("'DOADD'","{handler:'E22GO2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("'DOADD'",",oparms:[{av:'AV23Valor',fld:'vVALOR',pic:'ZZZZ9.99',type:'decimal'},{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'AV21SDTCargaJson',fld:'vSDTCARGAJSON',pic:'',type:'vchar'}]}");
         setEventMetadata("SDTCARGA__CANTIDAD.CONTROLVALUECHANGED","{handler:'E23GO2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("SDTCARGA__CANTIDAD.CONTROLVALUECHANGED",",oparms:[{av:'AV21SDTCargaJson',fld:'vSDTCARGAJSON',pic:'',type:'vchar'},{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'AV23Valor',fld:'vVALOR',pic:'ZZZZ9.99',type:'decimal'}]}");
         setEventMetadata("CANTIDADEMBELEV_MODAL.CLOSE","{handler:'E11GO2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("CANTIDADEMBELEV_MODAL.CLOSE",",oparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'}]}");
         setEventMetadata("CANTIDADEMBELEV2_MODAL.CLOSE","{handler:'E13GO2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("CANTIDADEMBELEV2_MODAL.CLOSE",",oparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'}]}");
         setEventMetadata("GLOBALEVENTS.EMBALAJEELEVACION4","{handler:'E17GO2',iparms:[{av:'AV14Cantidad',fld:'vCANTIDAD',pic:'Z9',type:'int'},{av:'AV29EmbElv',fld:'vEMBELV',pic:'',type:'svchar'},{av:'AV30Id',fld:'vID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A732ParametroMudanzaNombre',fld:'PARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'A733ParametroMudanzaValor',fld:'PARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("GLOBALEVENTS.EMBALAJEELEVACION4",",oparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'AV21SDTCargaJson',fld:'vSDTCARGAJSON',pic:'',type:'vchar'}]}");
         setEventMetadata("SDTCARGA__EMBALAJE.CLICK","{handler:'E24GO2',iparms:[{av:'A732ParametroMudanzaNombre',fld:'PARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'A733ParametroMudanzaValor',fld:'PARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("SDTCARGA__EMBALAJE.CLICK",",oparms:[{av:'AV30Id',fld:'vID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'AV14Cantidad',fld:'vCANTIDAD',pic:'Z9',type:'int'},{av:'AV21SDTCargaJson',fld:'vSDTCARGAJSON',pic:'',type:'vchar'}]}");
         setEventMetadata("SDTCARGA__ELEVACION.CLICK","{handler:'E25GO2',iparms:[{av:'A732ParametroMudanzaNombre',fld:'PARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'A733ParametroMudanzaValor',fld:'PARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'FREESTYLEGRID1_nEOF',type:'int'},{av:'sPrefix',type:'char'}]");
         setEventMetadata("SDTCARGA__ELEVACION.CLICK",",oparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'},{av:'AV30Id',fld:'vID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14Cantidad',fld:'vCANTIDAD',pic:'Z9',type:'int'},{av:'AV21SDTCargaJson',fld:'vSDTCARGAJSON',pic:'',type:'vchar'}]}");
         setEventMetadata("SDTCARGA__NOMBRE.CLICK","{handler:'E26GO2',iparms:[{av:'AV13SDTCarga',fld:'vSDTCARGA',grid:40,pic:''},{av:'nGXsfl_40_idx',ctrl:'GRID',prop:'GridCurrRow',grid:40},{av:'FREESTYLEGRID1_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_40',ctrl:'FREESTYLEGRID1',prop:'GridRC',grid:40,type:'int'}]");
         setEventMetadata("SDTCARGA__NOMBRE.CLICK",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         AV13SDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>( context, "SDTCargaItem", "AlmangoX");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV29EmbElv = "";
         A732ParametroMudanzaNombre = "";
         GX_FocusControl = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Freestylegrid1Container = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV25Mudanza = new SdtMudanza(context);
         H00GO2_A731ParametroMudanzaTipo = new string[] {""} ;
         H00GO2_A730ParametroMudanzaId = new short[1] ;
         H00GO2_A732ParametroMudanzaNombre = new string[] {""} ;
         H00GO2_A812ParametroMudanzaDescripcion = new string[] {""} ;
         H00GO2_A733ParametroMudanzaValor = new decimal[1] ;
         H00GO2_A734ParametroMudanzaUnidad = new string[] {""} ;
         A731ParametroMudanzaTipo = "";
         A812ParametroMudanzaDescripcion = "";
         A734ParametroMudanzaUnidad = "";
         AV16SDTCargaItem = new SdtSDTCarga_SDTCargaItem(context);
         AV26MudanzaCargaItem = new SdtMudanza_Carga(context);
         AV22WebSession = context.GetSession();
         AV21SDTCargaJson = "";
         H00GO3_A731ParametroMudanzaTipo = new string[] {""} ;
         H00GO3_A730ParametroMudanzaId = new short[1] ;
         H00GO3_A732ParametroMudanzaNombre = new string[] {""} ;
         H00GO3_A733ParametroMudanzaValor = new decimal[1] ;
         H00GO3_A734ParametroMudanzaUnidad = new string[] {""} ;
         H00GO3_A812ParametroMudanzaDescripcion = new string[] {""} ;
         Freestylegrid1Row = new GXWebRow();
         AV20SDTCarga2 = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>( context, "SDTCargaItem", "AlmangoX");
         AV19SDTCargaItem2 = new SdtSDTCarga_SDTCargaItem(context);
         H00GO4_A730ParametroMudanzaId = new short[1] ;
         H00GO4_A732ParametroMudanzaNombre = new string[] {""} ;
         H00GO4_A733ParametroMudanzaValor = new decimal[1] ;
         H00GO5_A730ParametroMudanzaId = new short[1] ;
         H00GO5_A732ParametroMudanzaNombre = new string[] {""} ;
         H00GO5_A733ParametroMudanzaValor = new decimal[1] ;
         H00GO6_A730ParametroMudanzaId = new short[1] ;
         H00GO6_A732ParametroMudanzaNombre = new string[] {""} ;
         H00GO6_A733ParametroMudanzaValor = new decimal[1] ;
         H00GO7_A730ParametroMudanzaId = new short[1] ;
         H00GO7_A732ParametroMudanzaNombre = new string[] {""} ;
         H00GO7_A733ParametroMudanzaValor = new decimal[1] ;
         ucDescripcion_modal = new GXUserControl();
         ucCantidadembelev2_modal = new GXUserControl();
         ucCantidadembelev_modal = new GXUserControl();
         lblTextblocksdtcarga__nombre_Jsonclick = "";
         lblTextblocksdtcarga__embalaje_Jsonclick = "";
         lblTextblocksdtcarga__embalajecant_Jsonclick = "";
         lblTextblocksdtcarga__elevacion_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV24MudanzaId = "";
         subFreestylegrid1_Linesclass = "";
         TempTags = "";
         ROClassString = "";
         lblSdtcarga__nombre_tags_Jsonclick = "";
         lblSubtract_Jsonclick = "";
         GXCCtl = "";
         lblAdd_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         bttBtncantidadembelev_Jsonclick = "";
         bttBtncantidadembelev2_Jsonclick = "";
         bttBtndescripcion_Jsonclick = "";
         subFreestylegrid1_Header = "";
         Freestylegrid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoria4wc__default(),
            new Object[][] {
                new Object[] {
               H00GO2_A731ParametroMudanzaTipo, H00GO2_A730ParametroMudanzaId, H00GO2_A732ParametroMudanzaNombre, H00GO2_A812ParametroMudanzaDescripcion, H00GO2_A733ParametroMudanzaValor, H00GO2_A734ParametroMudanzaUnidad
               }
               , new Object[] {
               H00GO3_A731ParametroMudanzaTipo, H00GO3_A730ParametroMudanzaId, H00GO3_A732ParametroMudanzaNombre, H00GO3_A733ParametroMudanzaValor, H00GO3_A734ParametroMudanzaUnidad, H00GO3_A812ParametroMudanzaDescripcion
               }
               , new Object[] {
               H00GO4_A730ParametroMudanzaId, H00GO4_A732ParametroMudanzaNombre, H00GO4_A733ParametroMudanzaValor
               }
               , new Object[] {
               H00GO5_A730ParametroMudanzaId, H00GO5_A732ParametroMudanzaNombre, H00GO5_A733ParametroMudanzaValor
               }
               , new Object[] {
               H00GO6_A730ParametroMudanzaId, H00GO6_A732ParametroMudanzaNombre, H00GO6_A733ParametroMudanzaValor
               }
               , new Object[] {
               H00GO7_A730ParametroMudanzaId, H00GO7_A732ParametroMudanzaNombre, H00GO7_A733ParametroMudanzaValor
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavSdtcarga__nombre_Enabled = 0;
         edtavSdtcarga__embalajecant_Enabled = 0;
         edtavSdtcarga__elevacioncant_Enabled = 0;
      }

      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14Cantidad ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subFreestylegrid1_Backcolorstyle ;
      private short A730ParametroMudanzaId ;
      private short FREESTYLEGRID1_nEOF ;
      private short AV35Piso ;
      private short nGXWrapped ;
      private short subFreestylegrid1_Backstyle ;
      private short subFreestylegrid1_Allowselection ;
      private short subFreestylegrid1_Allowhovering ;
      private short subFreestylegrid1_Allowcollapsing ;
      private short subFreestylegrid1_Collapsed ;
      private int nRC_GXsfl_40 ;
      private int nGXsfl_40_idx=1 ;
      private int edtavSdtcarga__nombre_Enabled ;
      private int edtavSdtcarga__embalajecant_Enabled ;
      private int edtavSdtcarga__elevacioncant_Enabled ;
      private int AV42GXV1 ;
      private int subFreestylegrid1_Islastpage ;
      private int nGXsfl_40_fel_idx=1 ;
      private int AV50GXV8 ;
      private int edtavSdtcarga__nombre_Fontsize ;
      private int lblAdd_Fontsize ;
      private int lblSubtract_Fontsize ;
      private int AV52GXV9 ;
      private int nGXsfl_40_bak_idx=1 ;
      private int AV53GXV10 ;
      private int bttBtncantidadembelev_Visible ;
      private int bttBtncantidadembelev2_Visible ;
      private int bttBtndescripcion_Visible ;
      private int AV54GXV11 ;
      private int AV55GXV12 ;
      private int AV56GXV13 ;
      private int AV57GXV14 ;
      private int AV60GXV15 ;
      private int AV62GXV16 ;
      private int AV63GXV17 ;
      private int AV65GXV18 ;
      private int AV66GXV19 ;
      private int idxLst ;
      private int subFreestylegrid1_Backcolor ;
      private int subFreestylegrid1_Allbackcolor ;
      private int subFreestylegrid1_Selectedindex ;
      private int subFreestylegrid1_Selectioncolor ;
      private int subFreestylegrid1_Hoveringcolor ;
      private long AV24MudanzaId ;
      private long wcpOAV24MudanzaId ;
      private long AV30Id ;
      private long FREESTYLEGRID1_nCurrentRecord ;
      private long FREESTYLEGRID1_nFirstRecordOnPage ;
      private decimal A733ParametroMudanzaValor ;
      private decimal AV23Valor ;
      private decimal AV37PrecioEmbMetro3 ;
      private decimal AV36PrecioElevPiso ;
      private decimal AV34ParametroValor ;
      private decimal AV40ValorEmb ;
      private decimal AV39ValorElv ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_40_idx="0001" ;
      private string edtavSdtcarga__nombre_Internalname ;
      private string edtavSdtcarga__embalajecant_Internalname ;
      private string edtavSdtcarga__elevacioncant_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Cantidadembelev_modal_Width ;
      private string Cantidadembelev_modal_Title ;
      private string Cantidadembelev_modal_Confirmtype ;
      private string Cantidadembelev_modal_Bodytype ;
      private string Cantidadembelev2_modal_Width ;
      private string Cantidadembelev2_modal_Title ;
      private string Cantidadembelev2_modal_Confirmtype ;
      private string Cantidadembelev2_modal_Bodytype ;
      private string Descripcion_modal_Width ;
      private string Descripcion_modal_Title ;
      private string Descripcion_modal_Confirmtype ;
      private string Descripcion_modal_Bodytype ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divHtml_freestylegrid1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sStyleString ;
      private string subFreestylegrid1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string subFreestylegrid1_Class ;
      private string sGXsfl_40_fel_idx="0001" ;
      private string A734ParametroMudanzaUnidad ;
      private string lblSdtcarga__nombre_tags_Caption ;
      private string bttBtncantidadembelev_Internalname ;
      private string bttBtncantidadembelev2_Internalname ;
      private string bttBtndescripcion_Internalname ;
      private string tblTabledescripcion_modal_Internalname ;
      private string Descripcion_modal_Internalname ;
      private string tblTablecantidadembelev2_modal_Internalname ;
      private string Cantidadembelev2_modal_Internalname ;
      private string tblTablecantidadembelev_modal_Internalname ;
      private string Cantidadembelev_modal_Internalname ;
      private string tblFreestylegrid1_headertable_Internalname ;
      private string tblFreestylegrid1_descriptionstable_Internalname ;
      private string lblTextblocksdtcarga__nombre_Internalname ;
      private string lblTextblocksdtcarga__nombre_Jsonclick ;
      private string lblTextblocksdtcarga__embalaje_Internalname ;
      private string lblTextblocksdtcarga__embalaje_Jsonclick ;
      private string lblTextblocksdtcarga__embalajecant_Internalname ;
      private string lblTextblocksdtcarga__embalajecant_Jsonclick ;
      private string lblTextblocksdtcarga__elevacion_Internalname ;
      private string lblTextblocksdtcarga__elevacion_Jsonclick ;
      private string cellTitlecantidadembelev_cell_Internalname ;
      private string cellTitlecantidadembelev2_cell_Internalname ;
      private string cellTitledescripcion_cell_Internalname ;
      private string sCtrlAV24MudanzaId ;
      private string lblSdtcarga__nombre_tags_Internalname ;
      private string lblSubtract_Internalname ;
      private string cmbavSdtcarga__cantidad_Internalname ;
      private string lblAdd_Internalname ;
      private string lblTextblock1_Internalname ;
      private string chkavSdtcarga__embalaje_Internalname ;
      private string lblTextblock2_Internalname ;
      private string chkavSdtcarga__elevacion_Internalname ;
      private string lblTextblock3_Internalname ;
      private string subFreestylegrid1_Linesclass ;
      private string tblTablemergedsdtcarga__nombre_Internalname ;
      private string TempTags ;
      private string ROClassString ;
      private string edtavSdtcarga__nombre_Class ;
      private string edtavSdtcarga__nombre_Jsonclick ;
      private string lblSdtcarga__nombre_tags_Jsonclick ;
      private string tblUnnamedtable1_Internalname ;
      private string lblSubtract_Jsonclick ;
      private string GXCCtl ;
      private string cmbavSdtcarga__cantidad_Jsonclick ;
      private string cmbavSdtcarga__cantidad_Class ;
      private string lblAdd_Jsonclick ;
      private string lblTextblock1_Jsonclick ;
      private string ClassString ;
      private string chkavSdtcarga__embalaje_Class ;
      private string StyleString ;
      private string lblTextblock2_Jsonclick ;
      private string edtavSdtcarga__embalajecant_Class ;
      private string edtavSdtcarga__embalajecant_Jsonclick ;
      private string chkavSdtcarga__elevacion_Class ;
      private string lblTextblock3_Jsonclick ;
      private string edtavSdtcarga__elevacioncant_Class ;
      private string edtavSdtcarga__elevacioncant_Jsonclick ;
      private string bttBtncantidadembelev_Jsonclick ;
      private string bttBtncantidadembelev2_Jsonclick ;
      private string bttBtndescripcion_Jsonclick ;
      private string subFreestylegrid1_Header ;
      private string lblSubtract_Caption ;
      private string lblAdd_Caption ;
      private string lblTextblock1_Caption ;
      private string cellCantidadembelev_cell_Internalname ;
      private string cellCantidadembelev2_cell_Internalname ;
      private string cellDescripcion_cell_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_40_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV40 ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV31IsAuthorized_CantidadEmbElev ;
      private bool AV32IsAuthorized_CantidadEmbElev2 ;
      private bool AV41IsAuthorized_Descripcion ;
      private bool GXt_boolean1 ;
      private string AV21SDTCargaJson ;
      private string AV29EmbElv ;
      private string A732ParametroMudanzaNombre ;
      private string A731ParametroMudanzaTipo ;
      private string A812ParametroMudanzaDescripcion ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid Freestylegrid1Container ;
      private GXWebRow Freestylegrid1Row ;
      private GXWebColumn Freestylegrid1Column ;
      private GXUserControl ucDescripcion_modal ;
      private GXUserControl ucCantidadembelev2_modal ;
      private GXUserControl ucCantidadembelev_modal ;
      private GXWebForm Form ;
      private IGxSession AV22WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavSdtcarga__cantidad ;
      private GXCheckbox chkavSdtcarga__embalaje ;
      private GXCheckbox chkavSdtcarga__elevacion ;
      private GXBaseCollection<SdtSDTCarga_SDTCargaItem> AV13SDTCarga ;
      private SdtMudanza AV25Mudanza ;
      private IDataStoreProvider pr_default ;
      private string[] H00GO2_A731ParametroMudanzaTipo ;
      private short[] H00GO2_A730ParametroMudanzaId ;
      private string[] H00GO2_A732ParametroMudanzaNombre ;
      private string[] H00GO2_A812ParametroMudanzaDescripcion ;
      private decimal[] H00GO2_A733ParametroMudanzaValor ;
      private string[] H00GO2_A734ParametroMudanzaUnidad ;
      private SdtSDTCarga_SDTCargaItem AV16SDTCargaItem ;
      private SdtMudanza_Carga AV26MudanzaCargaItem ;
      private string[] H00GO3_A731ParametroMudanzaTipo ;
      private short[] H00GO3_A730ParametroMudanzaId ;
      private string[] H00GO3_A732ParametroMudanzaNombre ;
      private decimal[] H00GO3_A733ParametroMudanzaValor ;
      private string[] H00GO3_A734ParametroMudanzaUnidad ;
      private string[] H00GO3_A812ParametroMudanzaDescripcion ;
      private GXBaseCollection<SdtSDTCarga_SDTCargaItem> AV20SDTCarga2 ;
      private SdtSDTCarga_SDTCargaItem AV19SDTCargaItem2 ;
      private short[] H00GO4_A730ParametroMudanzaId ;
      private string[] H00GO4_A732ParametroMudanzaNombre ;
      private decimal[] H00GO4_A733ParametroMudanzaValor ;
      private short[] H00GO5_A730ParametroMudanzaId ;
      private string[] H00GO5_A732ParametroMudanzaNombre ;
      private decimal[] H00GO5_A733ParametroMudanzaValor ;
      private short[] H00GO6_A730ParametroMudanzaId ;
      private string[] H00GO6_A732ParametroMudanzaNombre ;
      private decimal[] H00GO6_A733ParametroMudanzaValor ;
      private short[] H00GO7_A730ParametroMudanzaId ;
      private string[] H00GO7_A732ParametroMudanzaNombre ;
      private decimal[] H00GO7_A733ParametroMudanzaValor ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class categoria4wc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00GO2;
          prmH00GO2 = new Object[] {
          };
          Object[] prmH00GO3;
          prmH00GO3 = new Object[] {
          };
          Object[] prmH00GO4;
          prmH00GO4 = new Object[] {
          };
          Object[] prmH00GO5;
          prmH00GO5 = new Object[] {
          };
          Object[] prmH00GO6;
          prmH00GO6 = new Object[] {
          };
          Object[] prmH00GO7;
          prmH00GO7 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00GO2", "SELECT [ParametroMudanzaTipo], [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaDescripcion], [ParametroMudanzaValor], [ParametroMudanzaUnidad] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'ItemCargaDecoracion' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00GO3", "SELECT [ParametroMudanzaTipo], [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaDescripcion] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'ItemCargaDecoracion' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GO3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00GO4", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaValor] FROM [ParametroMudanza] ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GO4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00GO5", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaValor] FROM [ParametroMudanza] ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GO5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00GO6", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaValor] FROM [ParametroMudanza] ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GO6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00GO7", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaValor] FROM [ParametroMudanza] ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GO7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 2);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
       }
    }

 }

}
