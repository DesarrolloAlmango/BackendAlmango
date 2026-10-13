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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class solicitudmudanza : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public solicitudmudanza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudmudanza( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           long aP1_MudanzaId )
      {
         this.AV12TrnMode = aP0_TrnMode;
         this.AV16MudanzaId = aP1_MudanzaId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavMudanza_mudanzahoraservicio = new GXCombobox();
         dynavMudanza_tipoinmuebleorigenid = new GXCombobox();
         dynavMudanza_tipoestacionamorigenid = new GXCombobox();
         dynavMudanza_tipoinmuebledestinoid = new GXCombobox();
         dynavMudanza_tipoestacionamdestinoid = new GXCombobox();
         cmbavMudanza_mudanzavehiculosugerido = new GXCombobox();
         cmbavMudanza_tipoestacionamorigennombre = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TrnMode");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"MUDANZA_TIPOINMUEBLEORIGENID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVMUDANZA_TIPOINMUEBLEORIGENIDEH2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"MUDANZA_TIPOESTACIONAMORIGENID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVMUDANZA_TIPOESTACIONAMORIGENIDEH2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"MUDANZA_TIPOINMUEBLEDESTINOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVMUDANZA_TIPOINMUEBLEDESTINOIDEH2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"MUDANZA_TIPOESTACIONAMDESTINOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVMUDANZA_TIPOESTACIONAMDESTINOIDEH2( ) ;
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
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_carga") == 0 )
            {
               gxnrGridlevel_carga_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridlevel_carga") == 0 )
            {
               gxgrGridlevel_carga_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_adicional") == 0 )
            {
               gxnrGridlevel_adicional_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridlevel_adicional") == 0 )
            {
               gxgrGridlevel_adicional_refresh_invoke( ) ;
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_carga_newrow_invoke( )
      {
         nRC_GXsfl_75 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_75"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_75_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_75_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_75_idx = GetPar( "sGXsfl_75_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_carga_newrow( ) ;
         /* End function gxnrGridlevel_carga_newrow_invoke */
      }

      protected void gxgrGridlevel_carga_refresh_invoke( )
      {
         subGridlevel_carga_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridlevel_carga_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridlevel_adicional_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridlevel_adicional_Rows"), "."), 18, MidpointRounding.ToEven));
         AV12TrnMode = GetPar( "TrnMode");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV7Mudanza);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21MudanzaCargaDeleted);
         AV16MudanzaId = (long)(Math.Round(NumberUtil.Val( GetPar( "MudanzaId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridlevel_carga_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV21MudanzaCargaDeleted, AV16MudanzaId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridlevel_carga_refresh_invoke */
      }

      protected void gxnrGridlevel_adicional_newrow_invoke( )
      {
         nRC_GXsfl_89 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_89"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_89_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_89_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_89_idx = GetPar( "sGXsfl_89_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_adicional_newrow( ) ;
         /* End function gxnrGridlevel_adicional_newrow_invoke */
      }

      protected void gxgrGridlevel_adicional_refresh_invoke( )
      {
         subGridlevel_carga_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridlevel_carga_Rows"), "."), 18, MidpointRounding.ToEven));
         subGridlevel_adicional_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridlevel_adicional_Rows"), "."), 18, MidpointRounding.ToEven));
         AV12TrnMode = GetPar( "TrnMode");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV7Mudanza);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV19MudanzaAdicionalDeleted);
         AV16MudanzaId = (long)(Math.Round(NumberUtil.Val( GetPar( "MudanzaId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridlevel_adicional_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV19MudanzaAdicionalDeleted, AV16MudanzaId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridlevel_adicional_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PAEH2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTEH2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "solicitudmudanza.aspx"+UrlEncode(StringUtil.RTrim(AV12TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV16MudanzaId,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("solicitudmudanza.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV12TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Mudanza", AV7Mudanza);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Mudanza", AV7Mudanza);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_75", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_75), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_89", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_89), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMUDANZA_CARGA__ITEMCARGAID_DATA", AV22Mudanza_Carga__ItemCargaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMUDANZA_CARGA__ITEMCARGAID_DATA", AV22Mudanza_Carga__ItemCargaId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV12TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMUDANZAADICIONALDELETED", AV19MudanzaAdicionalDeleted);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMUDANZAADICIONALDELETED", AV19MudanzaAdicionalDeleted);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMUDANZACARGADELETED", AV21MudanzaCargaDeleted);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMUDANZACARGADELETED", AV21MudanzaCargaDeleted);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV14CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV11Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV11Messages);
         }
         GxWebStd.gx_hidden_field( context, "vMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16MudanzaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_CARGA_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_ADICIONAL_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_CARGA_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_ADICIONAL_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMUDANZA", AV7Mudanza);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMUDANZA", AV7Mudanza);
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_MUDANZA_CARGA__ITEMCARGAID_Cls", StringUtil.RTrim( Combo_mudanza_carga__itemcargaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MUDANZA_CARGA__ITEMCARGAID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_mudanza_carga__itemcargaid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_MUDANZA_CARGA__ITEMCARGAID_Isgriditem", StringUtil.BoolToStr( Combo_mudanza_carga__itemcargaid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_MUDANZA_CARGA__ITEMCARGAID_Emptyitem", StringUtil.BoolToStr( Combo_mudanza_carga__itemcargaid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridlevel_adicional_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridlevel_carga_empowerer_Gridinternalname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+2+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WEEH2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTEH2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "solicitudmudanza.aspx"+UrlEncode(StringUtil.RTrim(AV12TrnMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV16MudanzaId,18,0));
         return formatLink("solicitudmudanza.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SolicitudMudanza" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Solicitud Mudanza", "") ;
      }

      protected void WBEH0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMudanza_mudanzafechaservicio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMudanza_mudanzafechaservicio_Internalname, context.GetMessage( "Fecha Servicio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'" + sGXsfl_75_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavMudanza_mudanzafechaservicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavMudanza_mudanzafechaservicio_Internalname, context.localUtil.Format(AV7Mudanza.gxTpr_Mudanzafechaservicio, "99/99/99"), context.localUtil.Format( AV7Mudanza.gxTpr_Mudanzafechaservicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_mudanzafechaservicio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMudanza_mudanzafechaservicio_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            GxWebStd.gx_bitmap( context, edtavMudanza_mudanzafechaservicio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavMudanza_mudanzafechaservicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudMudanza.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavMudanza_mudanzahoraservicio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMudanza_mudanzahoraservicio_Internalname, context.GetMessage( "Hora Servicio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_75_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMudanza_mudanzahoraservicio, cmbavMudanza_mudanzahoraservicio_Internalname, StringUtil.RTrim( AV7Mudanza.gxTpr_Mudanzahoraservicio), 1, cmbavMudanza_mudanzahoraservicio_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavMudanza_mudanzahoraservicio.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "", true, 0, "HLP_SolicitudMudanza.htm");
            cmbavMudanza_mudanzahoraservicio.CurrentValue = StringUtil.RTrim( AV7Mudanza.gxTpr_Mudanzahoraservicio);
            AssignProp("", false, cmbavMudanza_mudanzahoraservicio_Internalname, "Values", (string)(cmbavMudanza_mudanzahoraservicio.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Origen", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_SolicitudMudanza.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavMudanza_tipoinmuebleorigenid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavMudanza_tipoinmuebleorigenid_Internalname, context.GetMessage( "Inmueble", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_75_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavMudanza_tipoinmuebleorigenid, dynavMudanza_tipoinmuebleorigenid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoinmuebleorigenid), 4, 0)), 1, dynavMudanza_tipoinmuebleorigenid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavMudanza_tipoinmuebleorigenid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_SolicitudMudanza.htm");
            dynavMudanza_tipoinmuebleorigenid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoinmuebleorigenid), 4, 0));
            AssignProp("", false, dynavMudanza_tipoinmuebleorigenid_Internalname, "Values", (string)(dynavMudanza_tipoinmuebleorigenid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavMudanza_tipoestacionamorigenid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavMudanza_tipoestacionamorigenid_Internalname, context.GetMessage( "Estacionamiento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_75_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavMudanza_tipoestacionamorigenid, dynavMudanza_tipoestacionamorigenid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoestacionamorigenid), 4, 0)), 1, dynavMudanza_tipoestacionamorigenid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavMudanza_tipoestacionamorigenid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_SolicitudMudanza.htm");
            dynavMudanza_tipoestacionamorigenid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoestacionamorigenid), 4, 0));
            AssignProp("", false, dynavMudanza_tipoestacionamorigenid_Internalname, "Values", (string)(dynavMudanza_tipoestacionamorigenid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, context.GetMessage( "Destino", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_SolicitudMudanza.htm");
            wb_table1_37_EH2( true) ;
         }
         else
         {
            wb_table1_37_EH2( false) ;
         }
         return  ;
      }

      protected void wb_table1_37_EH2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMudanza_mudanzapeajecantidad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMudanza_mudanzapeajecantidad_Internalname, context.GetMessage( "Peaje Cantidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_mudanzapeajecantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Mudanza.gxTpr_Mudanzapeajecantidad), 1, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7Mudanza.gxTpr_Mudanzapeajecantidad), "9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_mudanzapeajecantidad_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMudanza_mudanzapeajecantidad_Enabled, 1, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavMudanza_mudanzavehiculosugerido_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMudanza_mudanzavehiculosugerido_Internalname, context.GetMessage( "Vehiculo Sugerido", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_75_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMudanza_mudanzavehiculosugerido, cmbavMudanza_mudanzavehiculosugerido_Internalname, StringUtil.RTrim( AV7Mudanza.gxTpr_Mudanzavehiculosugerido), 1, cmbavMudanza_mudanzavehiculosugerido_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavMudanza_mudanzavehiculosugerido.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "", true, 0, "HLP_SolicitudMudanza.htm");
            cmbavMudanza_mudanzavehiculosugerido.CurrentValue = StringUtil.RTrim( AV7Mudanza.gxTpr_Mudanzavehiculosugerido);
            AssignProp("", false, cmbavMudanza_mudanzavehiculosugerido_Internalname, "Values", (string)(cmbavMudanza_mudanzavehiculosugerido.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMudanza_mudanzatiempomaximo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMudanza_mudanzatiempomaximo_Internalname, context.GetMessage( "Tiempo Maximo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_mudanzatiempomaximo_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Mudanza.gxTpr_Mudanzatiempomaximo, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavMudanza_mudanzatiempomaximo_Enabled!=0) ? context.localUtil.Format( AV7Mudanza.gxTpr_Mudanzatiempomaximo, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV7Mudanza.gxTpr_Mudanzatiempomaximo, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_mudanzatiempomaximo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMudanza_mudanzatiempomaximo_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMudanza_mudanzacargavolumenestimado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMudanza_mudanzacargavolumenestimado_Internalname, context.GetMessage( "Volumen Estimado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_mudanzacargavolumenestimado_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Mudanza.gxTpr_Mudanzacargavolumenestimado, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV7Mudanza.gxTpr_Mudanzacargavolumenestimado, "ZZZZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_mudanzacargavolumenestimado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMudanza_mudanzacargavolumenestimado_Enabled, 1, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMudanza_mudanzapreciofinal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMudanza_mudanzapreciofinal_Internalname, context.GetMessage( "Precio Final", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_mudanzapreciofinal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Mudanza.gxTpr_Mudanzapreciofinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavMudanza_mudanzapreciofinal_Enabled!=0) ? context.localUtil.Format( AV7Mudanza.gxTpr_Mudanzapreciofinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV7Mudanza.gxTpr_Mudanzapreciofinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_mudanzapreciofinal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavMudanza_mudanzapreciofinal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableleaflevel_carga_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridlevel_cargaContainer.SetWrapped(nGXWrapped);
            StartGridControl75( ) ;
         }
         if ( wbEnd == 75 )
         {
            wbEnd = 0;
            nRC_GXsfl_75 = (int)(nGXsfl_75_idx-1);
            if ( Gridlevel_cargaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridlevel_cargaContainer.AddObjectProperty("GRIDLEVEL_CARGA_nEOF", GRIDLEVEL_CARGA_nEOF);
               Gridlevel_cargaContainer.AddObjectProperty("GRIDLEVEL_CARGA_nFirstRecordOnPage", GRIDLEVEL_CARGA_nFirstRecordOnPage);
               AV35GXV12 = nGXsfl_75_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Gridlevel_cargaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_carga", Gridlevel_cargaContainer, subGridlevel_carga_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridlevel_cargaContainerData", Gridlevel_cargaContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridlevel_cargaContainerData"+"V", Gridlevel_cargaContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_cargaContainerData"+"V"+"\" value='"+Gridlevel_cargaContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ButtonAddGridLineCell", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "ButtonAddNewRow";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaddgridlinegridlevel_carga_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(75), 2, 0)+","+"null"+");", context.GetMessage( "WWP_AddGridLine", ""), bttBtnaddgridlinegridlevel_carga_Jsonclick, 5, context.GetMessage( "WWP_AddGridLine", ""), "", StyleString, ClassString, bttBtnaddgridlinegridlevel_carga_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOADDGRIDLINEGRIDLEVEL_CARGA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudMudanza.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableleaflevel_adicional_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridlevel_adicionalContainer.SetWrapped(nGXWrapped);
            StartGridControl89( ) ;
         }
         if ( wbEnd == 89 )
         {
            wbEnd = 0;
            nRC_GXsfl_89 = (int)(nGXsfl_89_idx-1);
            if ( Gridlevel_adicionalContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridlevel_adicionalContainer.AddObjectProperty("GRIDLEVEL_ADICIONAL_nEOF", GRIDLEVEL_ADICIONAL_nEOF);
               Gridlevel_adicionalContainer.AddObjectProperty("GRIDLEVEL_ADICIONAL_nFirstRecordOnPage", GRIDLEVEL_ADICIONAL_nFirstRecordOnPage);
               AV40GXV17 = nGXsfl_89_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Gridlevel_adicionalContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_adicional", Gridlevel_adicionalContainer, subGridlevel_adicional_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridlevel_adicionalContainerData", Gridlevel_adicionalContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridlevel_adicionalContainerData"+"V", Gridlevel_adicionalContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_adicionalContainerData"+"V"+"\" value='"+Gridlevel_adicionalContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ButtonAddGridLineCell", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "ButtonAddNewRow";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaddgridlinegridlevel_adicional_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(75), 2, 0)+","+"null"+");", context.GetMessage( "WWP_AddGridLine", ""), bttBtnaddgridlinegridlevel_adicional_Jsonclick, 5, context.GetMessage( "WWP_AddGridLine", ""), "", StyleString, ClassString, bttBtnaddgridlinegridlevel_adicional_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOADDGRIDLINEGRIDLEVEL_ADICIONAL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudMudanza.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(75), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudMudanza.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(75), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SolicitudMudanza.htm");
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
            /* User Defined Control */
            ucCombo_mudanza_carga__itemcargaid.SetProperty("Caption", Combo_mudanza_carga__itemcargaid_Caption);
            ucCombo_mudanza_carga__itemcargaid.SetProperty("Cls", Combo_mudanza_carga__itemcargaid_Cls);
            ucCombo_mudanza_carga__itemcargaid.SetProperty("IsGridItem", Combo_mudanza_carga__itemcargaid_Isgriditem);
            ucCombo_mudanza_carga__itemcargaid.SetProperty("EmptyItem", Combo_mudanza_carga__itemcargaid_Emptyitem);
            ucCombo_mudanza_carga__itemcargaid.SetProperty("DropDownOptionsData", AV22Mudanza_Carga__ItemCargaId_Data);
            ucCombo_mudanza_carga__itemcargaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_mudanza_carga__itemcargaid_Internalname, "COMBO_MUDANZA_CARGA__ITEMCARGAIDContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_mudanzaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Mudanza.gxTpr_Mudanzaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7Mudanza.gxTpr_Mudanzaid), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_mudanzaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_mudanzaid_Visible, 1, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_mudanzaasesor_Internalname, AV7Mudanza.gxTpr_Mudanzaasesor, StringUtil.RTrim( context.localUtil.Format( AV7Mudanza.gxTpr_Mudanzaasesor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_mudanzaasesor_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_mudanzaasesor_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudMudanza.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_75_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavMudanza_mudanzafechaalta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavMudanza_mudanzafechaalta_Internalname, context.localUtil.Format(AV7Mudanza.gxTpr_Mudanzafechaalta, "99/99/99"), context.localUtil.Format( AV7Mudanza.gxTpr_Mudanzafechaalta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_mudanzafechaalta_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_mudanzafechaalta_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            GxWebStd.gx_bitmap( context, edtavMudanza_mudanzafechaalta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavMudanza_mudanzafechaalta_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_SolicitudMudanza.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_mudanzapeajevalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Mudanza.gxTpr_Mudanzapeajevalor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV7Mudanza.gxTpr_Mudanzapeajevalor, "ZZZZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_mudanzapeajevalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_mudanzapeajevalor_Visible, 1, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'" + sGXsfl_75_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavMudanza_mudanzadirecciondestino_Internalname, AV7Mudanza.gxTpr_Mudanzadirecciondestino, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", 0, edtavMudanza_mudanzadirecciondestino_Visible, 1, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudMudanza.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_tipoinmuebledestinonombre_Internalname, AV7Mudanza.gxTpr_Tipoinmuebledestinonombre, StringUtil.RTrim( context.localUtil.Format( AV7Mudanza.gxTpr_Tipoinmuebledestinonombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_tipoinmuebledestinonombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_tipoinmuebledestinonombre_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudMudanza.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_tipoinmuebledestinovalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Mudanza.gxTpr_Tipoinmuebledestinovalor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV7Mudanza.gxTpr_Tipoinmuebledestinovalor, "ZZZZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_tipoinmuebledestinovalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_tipoinmuebledestinovalor_Visible, 1, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_tipoestacionamdestinonombre_Internalname, AV7Mudanza.gxTpr_Tipoestacionamdestinonombre, StringUtil.RTrim( context.localUtil.Format( AV7Mudanza.gxTpr_Tipoestacionamdestinonombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_tipoestacionamdestinonombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_tipoestacionamdestinonombre_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudMudanza.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_tipoestacionamdestinovalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Mudanza.gxTpr_Tipoestacionamdestinovalor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV7Mudanza.gxTpr_Tipoestacionamdestinovalor, "ZZZZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_tipoestacionamdestinovalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_tipoestacionamdestinovalor_Visible, 1, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_75_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavMudanza_mudanzadireccionorigen_Internalname, AV7Mudanza.gxTpr_Mudanzadireccionorigen, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", 0, edtavMudanza_mudanzadireccionorigen_Visible, 1, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SolicitudMudanza.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_mudanzadistancia_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Mudanza.gxTpr_Mudanzadistancia, 10, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV7Mudanza.gxTpr_Mudanzadistancia, "ZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_mudanzadistancia_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_mudanzadistancia_Visible, 1, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_tipoinmuebleorigennombre_Internalname, AV7Mudanza.gxTpr_Tipoinmuebleorigennombre, StringUtil.RTrim( context.localUtil.Format( AV7Mudanza.gxTpr_Tipoinmuebleorigennombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_tipoinmuebleorigennombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_tipoinmuebleorigennombre_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudMudanza.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_tipoinmuebleorigenvalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Mudanza.gxTpr_Tipoinmuebleorigenvalor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV7Mudanza.gxTpr_Tipoinmuebleorigenvalor, "ZZZZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_tipoinmuebleorigenvalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_tipoinmuebleorigenvalor_Visible, 1, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'" + sGXsfl_75_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMudanza_tipoestacionamorigennombre, cmbavMudanza_tipoestacionamorigennombre_Internalname, StringUtil.RTrim( AV7Mudanza.gxTpr_Tipoestacionamorigennombre), 1, cmbavMudanza_tipoestacionamorigennombre_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavMudanza_tipoestacionamorigennombre.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "", true, 0, "HLP_SolicitudMudanza.htm");
            cmbavMudanza_tipoestacionamorigennombre.CurrentValue = StringUtil.RTrim( AV7Mudanza.gxTpr_Tipoestacionamorigennombre);
            AssignProp("", false, cmbavMudanza_tipoestacionamorigennombre_Internalname, "Values", (string)(cmbavMudanza_tipoestacionamorigennombre.ToJavascriptSource()), true);
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_75_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMudanza_tipoestacionamorigenvalor_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Mudanza.gxTpr_Tipoestacionamorigenvalor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV7Mudanza.gxTpr_Tipoestacionamorigenvalor, "ZZZZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMudanza_tipoestacionamorigenvalor_Jsonclick, 0, "Attribute", "", "", "", "", edtavMudanza_tipoestacionamorigenvalor_Visible, 1, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SolicitudMudanza.htm");
            /* User Defined Control */
            ucGridlevel_adicional_empowerer.Render(context, "wwp.gridempowerer", Gridlevel_adicional_empowerer_Internalname, "GRIDLEVEL_ADICIONAL_EMPOWERERContainer");
            /* User Defined Control */
            ucGridlevel_carga_empowerer.Render(context, "wwp.gridempowerer", Gridlevel_carga_empowerer_Internalname, "GRIDLEVEL_CARGA_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 75 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridlevel_cargaContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridlevel_cargaContainer.AddObjectProperty("GRIDLEVEL_CARGA_nEOF", GRIDLEVEL_CARGA_nEOF);
                  Gridlevel_cargaContainer.AddObjectProperty("GRIDLEVEL_CARGA_nFirstRecordOnPage", GRIDLEVEL_CARGA_nFirstRecordOnPage);
                  AV35GXV12 = nGXsfl_75_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Gridlevel_cargaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_carga", Gridlevel_cargaContainer, subGridlevel_carga_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridlevel_cargaContainerData", Gridlevel_cargaContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridlevel_cargaContainerData"+"V", Gridlevel_cargaContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_cargaContainerData"+"V"+"\" value='"+Gridlevel_cargaContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 89 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridlevel_adicionalContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridlevel_adicionalContainer.AddObjectProperty("GRIDLEVEL_ADICIONAL_nEOF", GRIDLEVEL_ADICIONAL_nEOF);
                  Gridlevel_adicionalContainer.AddObjectProperty("GRIDLEVEL_ADICIONAL_nFirstRecordOnPage", GRIDLEVEL_ADICIONAL_nFirstRecordOnPage);
                  AV40GXV17 = nGXsfl_89_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Gridlevel_adicionalContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_adicional", Gridlevel_adicionalContainer, subGridlevel_adicional_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridlevel_adicionalContainerData", Gridlevel_adicionalContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridlevel_adicionalContainerData"+"V", Gridlevel_adicionalContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_adicionalContainerData"+"V"+"\" value='"+Gridlevel_adicionalContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTEH2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Solicitud Mudanza", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPEH0( ) ;
      }

      protected void WSEH2( )
      {
         STARTEH2( ) ;
         EVTEH2( ) ;
      }

      protected void EVTEH2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADDGRIDLINEGRIDLEVEL_ADICIONAL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAddGridLineGridLevel_Adicional' */
                              E11EH2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADDGRIDLINEGRIDLEVEL_CARGA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAddGridLineGridLevel_Carga' */
                              E12EH2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E13EH2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDLEVEL_CARGAPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDLEVEL_CARGAPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridlevel_carga_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridlevel_carga_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridlevel_carga_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridlevel_carga_lastpage( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDLEVEL_ADICIONALPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDLEVEL_ADICIONALPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridlevel_adicional_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridlevel_adicional_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridlevel_adicional_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridlevel_adicional_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "GRIDLEVEL_CARGA.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 36), "VDELETEGRIDLINEGRIDLEVEL_CARGA.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 36), "VDELETEGRIDLINEGRIDLEVEL_CARGA.CLICK") == 0 ) )
                           {
                              nGXsfl_75_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_75_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_75_idx), 4, 0), 4, "0");
                              SubsflControlProps_752( ) ;
                              AV35GXV12 = (int)(nGXsfl_75_idx+GRIDLEVEL_CARGA_nFirstRecordOnPage);
                              if ( ( AV7Mudanza.gxTpr_Carga.Count >= AV35GXV12 ) && ( AV35GXV12 > 0 ) )
                              {
                                 AV7Mudanza.gxTpr_Carga.CurrentItem = ((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12));
                                 AV9DeleteGridLineGridLevel_Carga = cgiGet( edtavDeletegridlinegridlevel_carga_Internalname);
                                 AssignAttri("", false, edtavDeletegridlinegridlevel_carga_Internalname, AV9DeleteGridLineGridLevel_Carga);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E14EH2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E15EH2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDLEVEL_CARGA.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridlevel_carga.Load */
                                    E16EH2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETEGRIDLINEGRIDLEVEL_CARGA.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E17EH2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "GRIDLEVEL_ADICIONAL.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 40), "VDELETEGRIDLINEGRIDLEVEL_ADICIONAL.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 40), "VDELETEGRIDLINEGRIDLEVEL_ADICIONAL.CLICK") == 0 ) )
                           {
                              nGXsfl_89_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_89_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_89_idx), 4, 0), 4, "0");
                              SubsflControlProps_893( ) ;
                              AV40GXV17 = (int)(nGXsfl_89_idx+GRIDLEVEL_ADICIONAL_nFirstRecordOnPage);
                              if ( ( AV7Mudanza.gxTpr_Adicional.Count >= AV40GXV17 ) && ( AV40GXV17 > 0 ) )
                              {
                                 AV7Mudanza.gxTpr_Adicional.CurrentItem = ((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17));
                                 AV8DeleteGridLineGridLevel_Adicional = cgiGet( edtavDeletegridlinegridlevel_adicional_Internalname);
                                 AssignAttri("", false, edtavDeletegridlinegridlevel_adicional_Internalname, AV8DeleteGridLineGridLevel_Adicional);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDLEVEL_ADICIONAL.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridlevel_adicional.Load */
                                    E18EH3 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETEGRIDLINEGRIDLEVEL_ADICIONAL.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E19EH2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEEH2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PAEH2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "solicitudmudanza.aspx")), "solicitudmudanza.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "solicitudmudanza.aspx")))) ;
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
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "TrnMode");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV12TrnMode = gxfirstwebparm;
                     AssignAttri("", false, "AV12TrnMode", AV12TrnMode);
                     GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV16MudanzaId = (long)(Math.Round(NumberUtil.Val( GetPar( "MudanzaId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV16MudanzaId", StringUtil.LTrimStr( (decimal)(AV16MudanzaId), 18, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
                     }
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
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavMudanza_mudanzafechaservicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVMUDANZA_TIPOINMUEBLEORIGENIDEH2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVMUDANZA_TIPOINMUEBLEORIGENID_dataEH2( ) ;
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

      protected void GXVMUDANZA_TIPOINMUEBLEORIGENID_htmlEH2( )
      {
         short gxdynajaxvalue;
         GXDLVMUDANZA_TIPOINMUEBLEORIGENID_dataEH2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavMudanza_tipoinmuebleorigenid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavMudanza_tipoinmuebleorigenid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavMudanza_tipoinmuebleorigenid.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Tipoinmuebleorigenid = (short)(Math.Round(NumberUtil.Val( dynavMudanza_tipoinmuebleorigenid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoinmuebleorigenid), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
      }

      protected void GXDLVMUDANZA_TIPOINMUEBLEORIGENID_dataEH2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00EH2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00EH2_A743TipoInmuebleOrigenId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00EH2_A755TipoInmuebleOrigenNombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVMUDANZA_TIPOESTACIONAMORIGENIDEH2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVMUDANZA_TIPOESTACIONAMORIGENID_dataEH2( ) ;
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

      protected void GXVMUDANZA_TIPOESTACIONAMORIGENID_htmlEH2( )
      {
         short gxdynajaxvalue;
         GXDLVMUDANZA_TIPOESTACIONAMORIGENID_dataEH2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavMudanza_tipoestacionamorigenid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavMudanza_tipoestacionamorigenid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavMudanza_tipoestacionamorigenid.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Tipoestacionamorigenid = (short)(Math.Round(NumberUtil.Val( dynavMudanza_tipoestacionamorigenid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoestacionamorigenid), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
      }

      protected void GXDLVMUDANZA_TIPOESTACIONAMORIGENID_dataEH2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00EH3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00EH3_A749TipoEstacionamDestinoId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00EH3_A750TipoEstacionamDestinoNombre[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVMUDANZA_TIPOINMUEBLEDESTINOIDEH2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVMUDANZA_TIPOINMUEBLEDESTINOID_dataEH2( ) ;
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

      protected void GXVMUDANZA_TIPOINMUEBLEDESTINOID_htmlEH2( )
      {
         short gxdynajaxvalue;
         GXDLVMUDANZA_TIPOINMUEBLEDESTINOID_dataEH2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavMudanza_tipoinmuebledestinoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavMudanza_tipoinmuebledestinoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavMudanza_tipoinmuebledestinoid.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Tipoinmuebledestinoid = (short)(Math.Round(NumberUtil.Val( dynavMudanza_tipoinmuebledestinoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoinmuebledestinoid), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
      }

      protected void GXDLVMUDANZA_TIPOINMUEBLEDESTINOID_dataEH2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00EH4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00EH4_A745TipoInmuebleDestinoId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00EH4_A746TipoInmuebleDestinoNombre[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void GXDLVMUDANZA_TIPOESTACIONAMDESTINOIDEH2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVMUDANZA_TIPOESTACIONAMDESTINOID_dataEH2( ) ;
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

      protected void GXVMUDANZA_TIPOESTACIONAMDESTINOID_htmlEH2( )
      {
         short gxdynajaxvalue;
         GXDLVMUDANZA_TIPOESTACIONAMDESTINOID_dataEH2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavMudanza_tipoestacionamdestinoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavMudanza_tipoestacionamdestinoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavMudanza_tipoestacionamdestinoid.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Tipoestacionamdestinoid = (short)(Math.Round(NumberUtil.Val( dynavMudanza_tipoestacionamdestinoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoestacionamdestinoid), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
      }

      protected void GXDLVMUDANZA_TIPOESTACIONAMDESTINOID_dataEH2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00EH5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00EH5_A749TipoEstacionamDestinoId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00EH5_A750TipoEstacionamDestinoNombre[0]);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void gxnrGridlevel_carga_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_752( ) ;
         while ( nGXsfl_75_idx <= nRC_GXsfl_75 )
         {
            sendrow_752( ) ;
            nGXsfl_75_idx = ((subGridlevel_carga_Islastpage==1)&&(nGXsfl_75_idx+1>subGridlevel_carga_fnc_Recordsperpage( )) ? 1 : nGXsfl_75_idx+1);
            sGXsfl_75_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_75_idx), 4, 0), 4, "0");
            SubsflControlProps_752( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_cargaContainer)) ;
         /* End function gxnrGridlevel_carga_newrow */
      }

      protected void gxnrGridlevel_adicional_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_893( ) ;
         while ( nGXsfl_89_idx <= nRC_GXsfl_89 )
         {
            sendrow_893( ) ;
            nGXsfl_89_idx = ((subGridlevel_adicional_Islastpage==1)&&(nGXsfl_89_idx+1>subGridlevel_adicional_fnc_Recordsperpage( )) ? 1 : nGXsfl_89_idx+1);
            sGXsfl_89_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_89_idx), 4, 0), 4, "0");
            SubsflControlProps_893( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_adicionalContainer)) ;
         /* End function gxnrGridlevel_adicional_newrow */
      }

      protected void gxgrGridlevel_carga_refresh( int subGridlevel_carga_Rows ,
                                                  int subGridlevel_adicional_Rows ,
                                                  string AV12TrnMode ,
                                                  SdtMudanza AV7Mudanza ,
                                                  GxSimpleCollection<short> AV21MudanzaCargaDeleted ,
                                                  long AV16MudanzaId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDLEVEL_CARGA_nCurrentRecord = 0;
         RFEH2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridlevel_carga_refresh */
      }

      protected void gxgrGridlevel_adicional_refresh( int subGridlevel_carga_Rows ,
                                                      int subGridlevel_adicional_Rows ,
                                                      string AV12TrnMode ,
                                                      SdtMudanza AV7Mudanza ,
                                                      GxSimpleCollection<short> AV19MudanzaAdicionalDeleted ,
                                                      long AV16MudanzaId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDLEVEL_ADICIONAL_nCurrentRecord = 0;
         RFEH3( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridlevel_adicional_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVMUDANZA_TIPOINMUEBLEORIGENID_htmlEH2( ) ;
            GXVMUDANZA_TIPOESTACIONAMORIGENID_htmlEH2( ) ;
            GXVMUDANZA_TIPOINMUEBLEDESTINOID_htmlEH2( ) ;
            GXVMUDANZA_TIPOESTACIONAMDESTINOID_htmlEH2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavMudanza_mudanzahoraservicio.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Mudanzahoraservicio = cmbavMudanza_mudanzahoraservicio.getValidValue(AV7Mudanza.gxTpr_Mudanzahoraservicio);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMudanza_mudanzahoraservicio.CurrentValue = StringUtil.RTrim( AV7Mudanza.gxTpr_Mudanzahoraservicio);
            AssignProp("", false, cmbavMudanza_mudanzahoraservicio_Internalname, "Values", cmbavMudanza_mudanzahoraservicio.ToJavascriptSource(), true);
         }
         if ( dynavMudanza_tipoinmuebleorigenid.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Tipoinmuebleorigenid = (short)(Math.Round(NumberUtil.Val( dynavMudanza_tipoinmuebleorigenid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoinmuebleorigenid), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavMudanza_tipoinmuebleorigenid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoinmuebleorigenid), 4, 0));
            AssignProp("", false, dynavMudanza_tipoinmuebleorigenid_Internalname, "Values", dynavMudanza_tipoinmuebleorigenid.ToJavascriptSource(), true);
         }
         if ( dynavMudanza_tipoestacionamorigenid.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Tipoestacionamorigenid = (short)(Math.Round(NumberUtil.Val( dynavMudanza_tipoestacionamorigenid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoestacionamorigenid), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavMudanza_tipoestacionamorigenid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoestacionamorigenid), 4, 0));
            AssignProp("", false, dynavMudanza_tipoestacionamorigenid_Internalname, "Values", dynavMudanza_tipoestacionamorigenid.ToJavascriptSource(), true);
         }
         if ( dynavMudanza_tipoinmuebledestinoid.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Tipoinmuebledestinoid = (short)(Math.Round(NumberUtil.Val( dynavMudanza_tipoinmuebledestinoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoinmuebledestinoid), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavMudanza_tipoinmuebledestinoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoinmuebledestinoid), 4, 0));
            AssignProp("", false, dynavMudanza_tipoinmuebledestinoid_Internalname, "Values", dynavMudanza_tipoinmuebledestinoid.ToJavascriptSource(), true);
         }
         if ( dynavMudanza_tipoestacionamdestinoid.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Tipoestacionamdestinoid = (short)(Math.Round(NumberUtil.Val( dynavMudanza_tipoestacionamdestinoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoestacionamdestinoid), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavMudanza_tipoestacionamdestinoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoestacionamdestinoid), 4, 0));
            AssignProp("", false, dynavMudanza_tipoestacionamdestinoid_Internalname, "Values", dynavMudanza_tipoestacionamdestinoid.ToJavascriptSource(), true);
         }
         if ( cmbavMudanza_mudanzavehiculosugerido.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Mudanzavehiculosugerido = cmbavMudanza_mudanzavehiculosugerido.getValidValue(AV7Mudanza.gxTpr_Mudanzavehiculosugerido);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMudanza_mudanzavehiculosugerido.CurrentValue = StringUtil.RTrim( AV7Mudanza.gxTpr_Mudanzavehiculosugerido);
            AssignProp("", false, cmbavMudanza_mudanzavehiculosugerido_Internalname, "Values", cmbavMudanza_mudanzavehiculosugerido.ToJavascriptSource(), true);
         }
         if ( cmbavMudanza_tipoestacionamorigennombre.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Tipoestacionamorigennombre = cmbavMudanza_tipoestacionamorigennombre.getValidValue(AV7Mudanza.gxTpr_Tipoestacionamorigennombre);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMudanza_tipoestacionamorigennombre.CurrentValue = StringUtil.RTrim( AV7Mudanza.gxTpr_Tipoestacionamorigennombre);
            AssignProp("", false, cmbavMudanza_tipoestacionamorigennombre_Internalname, "Values", cmbavMudanza_tipoestacionamorigennombre.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFEH2( ) ;
         RFEH3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV60Pgmname = "SolicitudMudanza";
         cmbavMudanza_mudanzavehiculosugerido.Enabled = 0;
         AssignProp("", false, cmbavMudanza_mudanzavehiculosugerido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavMudanza_mudanzavehiculosugerido.Enabled), 5, 0), true);
         edtavMudanza_mudanzatiempomaximo_Enabled = 0;
         AssignProp("", false, edtavMudanza_mudanzatiempomaximo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzatiempomaximo_Enabled), 5, 0), true);
         edtavMudanza_mudanzapreciofinal_Enabled = 0;
         AssignProp("", false, edtavMudanza_mudanzapreciofinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzapreciofinal_Enabled), 5, 0), true);
         edtavDeletegridlinegridlevel_carga_Enabled = 0;
         edtavMudanza_carga__itemcarganombre_Enabled = 0;
         edtavMudanza_carga__itemcargavolumen_Enabled = 0;
         edtavDeletegridlinegridlevel_adicional_Enabled = 0;
         edtavMudanza_adicional__itemadicionalnombre_Enabled = 0;
         edtavMudanza_adicional__itemadicionalvalor_Enabled = 0;
      }

      protected void RFEH2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridlevel_cargaContainer.ClearRows();
         }
         wbStart = 75;
         /* Execute user event: Refresh */
         E15EH2 ();
         nGXsfl_75_idx = 1;
         sGXsfl_75_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_75_idx), 4, 0), 4, "0");
         SubsflControlProps_752( ) ;
         bGXsfl_75_Refreshing = true;
         Gridlevel_cargaContainer.AddObjectProperty("GridName", "Gridlevel_carga");
         Gridlevel_cargaContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_cargaContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_cargaContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_cargaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_cargaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_cargaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_cargaContainer.PageSize = subGridlevel_carga_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_752( ) ;
            /* Execute user event: Gridlevel_carga.Load */
            E16EH2 ();
            if ( ( subGridlevel_carga_Islastpage == 0 ) && ( GRIDLEVEL_CARGA_nCurrentRecord > 0 ) && ( GRIDLEVEL_CARGA_nGridOutOfScope == 0 ) && ( nGXsfl_75_idx == 1 ) )
            {
               GRIDLEVEL_CARGA_nCurrentRecord = 0;
               GRIDLEVEL_CARGA_nGridOutOfScope = 1;
               subgridlevel_carga_firstpage( ) ;
               /* Execute user event: Gridlevel_carga.Load */
               E16EH2 ();
            }
            wbEnd = 75;
            WBEH0( ) ;
         }
         bGXsfl_75_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesEH2( )
      {
      }

      protected void RFEH3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridlevel_adicionalContainer.ClearRows();
         }
         wbStart = 89;
         /* Execute user event: Refresh */
         E15EH2 ();
         nGXsfl_89_idx = 1;
         sGXsfl_89_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_89_idx), 4, 0), 4, "0");
         SubsflControlProps_893( ) ;
         bGXsfl_89_Refreshing = true;
         Gridlevel_adicionalContainer.AddObjectProperty("GridName", "Gridlevel_adicional");
         Gridlevel_adicionalContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_adicionalContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_adicionalContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_adicionalContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_adicionalContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_adicionalContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_adicionalContainer.PageSize = subGridlevel_adicional_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_893( ) ;
            /* Execute user event: Gridlevel_adicional.Load */
            E18EH3 ();
            if ( ( subGridlevel_adicional_Islastpage == 0 ) && ( GRIDLEVEL_ADICIONAL_nCurrentRecord > 0 ) && ( GRIDLEVEL_ADICIONAL_nGridOutOfScope == 0 ) && ( nGXsfl_89_idx == 1 ) )
            {
               GRIDLEVEL_ADICIONAL_nCurrentRecord = 0;
               GRIDLEVEL_ADICIONAL_nGridOutOfScope = 1;
               subgridlevel_adicional_firstpage( ) ;
               /* Execute user event: Gridlevel_adicional.Load */
               E18EH3 ();
            }
            wbEnd = 89;
            WBEH0( ) ;
         }
         bGXsfl_89_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesEH3( )
      {
      }

      protected int subGridlevel_carga_fnc_Pagecount( )
      {
         GRIDLEVEL_CARGA_nRecordCount = subGridlevel_carga_fnc_Recordcount( );
         if ( ((long)((GRIDLEVEL_CARGA_nRecordCount) % (subGridlevel_carga_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_CARGA_nRecordCount/ (decimal)(subGridlevel_carga_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_CARGA_nRecordCount/ (decimal)(subGridlevel_carga_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridlevel_carga_fnc_Recordcount( )
      {
         return AV7Mudanza.gxTpr_Carga.Count ;
      }

      protected int subGridlevel_carga_fnc_Recordsperpage( )
      {
         if ( subGridlevel_carga_Rows > 0 )
         {
            return subGridlevel_carga_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridlevel_carga_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_CARGA_nFirstRecordOnPage/ (decimal)(subGridlevel_carga_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridlevel_carga_firstpage( )
      {
         GRIDLEVEL_CARGA_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_CARGA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_carga_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV21MudanzaCargaDeleted, AV16MudanzaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlevel_carga_nextpage( )
      {
         GRIDLEVEL_CARGA_nRecordCount = subGridlevel_carga_fnc_Recordcount( );
         if ( ( GRIDLEVEL_CARGA_nRecordCount >= subGridlevel_carga_fnc_Recordsperpage( ) ) && ( GRIDLEVEL_CARGA_nEOF == 0 ) )
         {
            GRIDLEVEL_CARGA_nFirstRecordOnPage = (long)(GRIDLEVEL_CARGA_nFirstRecordOnPage+subGridlevel_carga_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_CARGA_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridlevel_cargaContainer.AddObjectProperty("GRIDLEVEL_CARGA_nFirstRecordOnPage", GRIDLEVEL_CARGA_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_carga_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV21MudanzaCargaDeleted, AV16MudanzaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDLEVEL_CARGA_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridlevel_carga_previouspage( )
      {
         if ( GRIDLEVEL_CARGA_nFirstRecordOnPage >= subGridlevel_carga_fnc_Recordsperpage( ) )
         {
            GRIDLEVEL_CARGA_nFirstRecordOnPage = (long)(GRIDLEVEL_CARGA_nFirstRecordOnPage-subGridlevel_carga_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_CARGA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_carga_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV21MudanzaCargaDeleted, AV16MudanzaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlevel_carga_lastpage( )
      {
         GRIDLEVEL_CARGA_nRecordCount = subGridlevel_carga_fnc_Recordcount( );
         if ( GRIDLEVEL_CARGA_nRecordCount > subGridlevel_carga_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRIDLEVEL_CARGA_nRecordCount) % (subGridlevel_carga_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDLEVEL_CARGA_nFirstRecordOnPage = (long)(GRIDLEVEL_CARGA_nRecordCount-subGridlevel_carga_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDLEVEL_CARGA_nFirstRecordOnPage = (long)(GRIDLEVEL_CARGA_nRecordCount-((long)((GRIDLEVEL_CARGA_nRecordCount) % (subGridlevel_carga_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDLEVEL_CARGA_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_CARGA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_carga_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV21MudanzaCargaDeleted, AV16MudanzaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridlevel_carga_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDLEVEL_CARGA_nFirstRecordOnPage = (long)(subGridlevel_carga_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDLEVEL_CARGA_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_CARGA_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_carga_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV21MudanzaCargaDeleted, AV16MudanzaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGridlevel_adicional_fnc_Pagecount( )
      {
         GRIDLEVEL_ADICIONAL_nRecordCount = subGridlevel_adicional_fnc_Recordcount( );
         if ( ((long)((GRIDLEVEL_ADICIONAL_nRecordCount) % (subGridlevel_adicional_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_ADICIONAL_nRecordCount/ (decimal)(subGridlevel_adicional_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_ADICIONAL_nRecordCount/ (decimal)(subGridlevel_adicional_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridlevel_adicional_fnc_Recordcount( )
      {
         return AV7Mudanza.gxTpr_Adicional.Count ;
      }

      protected int subGridlevel_adicional_fnc_Recordsperpage( )
      {
         if ( subGridlevel_adicional_Rows > 0 )
         {
            return subGridlevel_adicional_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridlevel_adicional_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_ADICIONAL_nFirstRecordOnPage/ (decimal)(subGridlevel_adicional_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridlevel_adicional_firstpage( )
      {
         GRIDLEVEL_ADICIONAL_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_ADICIONAL_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_adicional_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV19MudanzaAdicionalDeleted, AV16MudanzaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlevel_adicional_nextpage( )
      {
         GRIDLEVEL_ADICIONAL_nRecordCount = subGridlevel_adicional_fnc_Recordcount( );
         if ( ( GRIDLEVEL_ADICIONAL_nRecordCount >= subGridlevel_adicional_fnc_Recordsperpage( ) ) && ( GRIDLEVEL_ADICIONAL_nEOF == 0 ) )
         {
            GRIDLEVEL_ADICIONAL_nFirstRecordOnPage = (long)(GRIDLEVEL_ADICIONAL_nFirstRecordOnPage+subGridlevel_adicional_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_ADICIONAL_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridlevel_adicionalContainer.AddObjectProperty("GRIDLEVEL_ADICIONAL_nFirstRecordOnPage", GRIDLEVEL_ADICIONAL_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_adicional_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV19MudanzaAdicionalDeleted, AV16MudanzaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDLEVEL_ADICIONAL_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridlevel_adicional_previouspage( )
      {
         if ( GRIDLEVEL_ADICIONAL_nFirstRecordOnPage >= subGridlevel_adicional_fnc_Recordsperpage( ) )
         {
            GRIDLEVEL_ADICIONAL_nFirstRecordOnPage = (long)(GRIDLEVEL_ADICIONAL_nFirstRecordOnPage-subGridlevel_adicional_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_ADICIONAL_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_adicional_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV19MudanzaAdicionalDeleted, AV16MudanzaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlevel_adicional_lastpage( )
      {
         GRIDLEVEL_ADICIONAL_nRecordCount = subGridlevel_adicional_fnc_Recordcount( );
         if ( GRIDLEVEL_ADICIONAL_nRecordCount > subGridlevel_adicional_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRIDLEVEL_ADICIONAL_nRecordCount) % (subGridlevel_adicional_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDLEVEL_ADICIONAL_nFirstRecordOnPage = (long)(GRIDLEVEL_ADICIONAL_nRecordCount-subGridlevel_adicional_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDLEVEL_ADICIONAL_nFirstRecordOnPage = (long)(GRIDLEVEL_ADICIONAL_nRecordCount-((long)((GRIDLEVEL_ADICIONAL_nRecordCount) % (subGridlevel_adicional_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDLEVEL_ADICIONAL_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_ADICIONAL_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_adicional_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV19MudanzaAdicionalDeleted, AV16MudanzaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridlevel_adicional_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDLEVEL_ADICIONAL_nFirstRecordOnPage = (long)(subGridlevel_adicional_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDLEVEL_ADICIONAL_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_ADICIONAL_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_adicional_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV19MudanzaAdicionalDeleted, AV16MudanzaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV60Pgmname = "SolicitudMudanza";
         cmbavMudanza_mudanzavehiculosugerido.Enabled = 0;
         AssignProp("", false, cmbavMudanza_mudanzavehiculosugerido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavMudanza_mudanzavehiculosugerido.Enabled), 5, 0), true);
         edtavMudanza_mudanzatiempomaximo_Enabled = 0;
         AssignProp("", false, edtavMudanza_mudanzatiempomaximo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzatiempomaximo_Enabled), 5, 0), true);
         edtavMudanza_mudanzapreciofinal_Enabled = 0;
         AssignProp("", false, edtavMudanza_mudanzapreciofinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzapreciofinal_Enabled), 5, 0), true);
         edtavDeletegridlinegridlevel_carga_Enabled = 0;
         edtavMudanza_carga__itemcarganombre_Enabled = 0;
         edtavMudanza_carga__itemcargavolumen_Enabled = 0;
         edtavDeletegridlinegridlevel_adicional_Enabled = 0;
         edtavMudanza_adicional__itemadicionalnombre_Enabled = 0;
         edtavMudanza_adicional__itemadicionalvalor_Enabled = 0;
         GXVMUDANZA_TIPOINMUEBLEORIGENID_htmlEH2( ) ;
         GXVMUDANZA_TIPOESTACIONAMORIGENID_htmlEH2( ) ;
         GXVMUDANZA_TIPOINMUEBLEDESTINOID_htmlEH2( ) ;
         GXVMUDANZA_TIPOESTACIONAMDESTINOID_htmlEH2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPEH0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14EH2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMUDANZA"), AV7Mudanza);
            ajax_req_read_hidden_sdt(cgiGet( "Mudanza"), AV7Mudanza);
            ajax_req_read_hidden_sdt(cgiGet( "vMUDANZA_CARGA__ITEMCARGAID_DATA"), AV22Mudanza_Carga__ItemCargaId_Data);
            /* Read saved values. */
            nRC_GXsfl_75 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_75"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nRC_GXsfl_89 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_89"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDLEVEL_CARGA_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_CARGA_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDLEVEL_ADICIONAL_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_ADICIONAL_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDLEVEL_CARGA_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_CARGA_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDLEVEL_ADICIONAL_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_ADICIONAL_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridlevel_carga_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_CARGA_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Rows), 6, 0, ".", "")));
            subGridlevel_adicional_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_ADICIONAL_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Rows), 6, 0, ".", "")));
            Combo_mudanza_carga__itemcargaid_Cls = cgiGet( "COMBO_MUDANZA_CARGA__ITEMCARGAID_Cls");
            Combo_mudanza_carga__itemcargaid_Titlecontrolidtoreplace = cgiGet( "COMBO_MUDANZA_CARGA__ITEMCARGAID_Titlecontrolidtoreplace");
            Combo_mudanza_carga__itemcargaid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_MUDANZA_CARGA__ITEMCARGAID_Isgriditem"));
            Combo_mudanza_carga__itemcargaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_MUDANZA_CARGA__ITEMCARGAID_Emptyitem"));
            Gridlevel_adicional_empowerer_Gridinternalname = cgiGet( "GRIDLEVEL_ADICIONAL_EMPOWERER_Gridinternalname");
            Gridlevel_carga_empowerer_Gridinternalname = cgiGet( "GRIDLEVEL_CARGA_EMPOWERER_Gridinternalname");
            nRC_GXsfl_75 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_75"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_75_fel_idx = 0;
            while ( nGXsfl_75_fel_idx < nRC_GXsfl_75 )
            {
               nGXsfl_75_fel_idx = ((subGridlevel_carga_Islastpage==1)&&(nGXsfl_75_fel_idx+1>subGridlevel_carga_fnc_Recordsperpage( )) ? 1 : nGXsfl_75_fel_idx+1);
               sGXsfl_75_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_75_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_752( ) ;
               AV35GXV12 = (int)(nGXsfl_75_fel_idx+GRIDLEVEL_CARGA_nFirstRecordOnPage);
               if ( ( AV7Mudanza.gxTpr_Carga.Count >= AV35GXV12 ) && ( AV35GXV12 > 0 ) )
               {
                  AV7Mudanza.gxTpr_Carga.CurrentItem = ((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12));
                  AV9DeleteGridLineGridLevel_Carga = cgiGet( edtavDeletegridlinegridlevel_carga_Internalname);
               }
            }
            if ( nGXsfl_75_fel_idx == 0 )
            {
               nGXsfl_75_idx = 1;
               sGXsfl_75_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_75_idx), 4, 0), 4, "0");
               SubsflControlProps_752( ) ;
            }
            nGXsfl_75_fel_idx = 1;
            nRC_GXsfl_89 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_89"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_89_fel_idx = 0;
            while ( nGXsfl_89_fel_idx < nRC_GXsfl_89 )
            {
               nGXsfl_89_fel_idx = ((subGridlevel_adicional_Islastpage==1)&&(nGXsfl_89_fel_idx+1>subGridlevel_adicional_fnc_Recordsperpage( )) ? 1 : nGXsfl_89_fel_idx+1);
               sGXsfl_89_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_89_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_893( ) ;
               AV40GXV17 = (int)(nGXsfl_89_fel_idx+GRIDLEVEL_ADICIONAL_nFirstRecordOnPage);
               if ( ( AV7Mudanza.gxTpr_Adicional.Count >= AV40GXV17 ) && ( AV40GXV17 > 0 ) )
               {
                  AV7Mudanza.gxTpr_Adicional.CurrentItem = ((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17));
                  AV8DeleteGridLineGridLevel_Adicional = cgiGet( edtavDeletegridlinegridlevel_adicional_Internalname);
               }
            }
            if ( nGXsfl_89_fel_idx == 0 )
            {
               nGXsfl_89_idx = 1;
               sGXsfl_89_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_89_idx), 4, 0), 4, "0");
               SubsflControlProps_893( ) ;
            }
            nGXsfl_89_fel_idx = 1;
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavMudanza_mudanzafechaservicio_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Mudanza Fecha Servicio", "")}), 1, "MUDANZA_MUDANZAFECHASERVICIO");
               GX_FocusControl = edtavMudanza_mudanzafechaservicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Mudanzafechaservicio = DateTime.MinValue;
            }
            else
            {
               AV7Mudanza.gxTpr_Mudanzafechaservicio = context.localUtil.CToD( cgiGet( edtavMudanza_mudanzafechaservicio_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            cmbavMudanza_mudanzahoraservicio.Name = cmbavMudanza_mudanzahoraservicio_Internalname;
            cmbavMudanza_mudanzahoraservicio.CurrentValue = cgiGet( cmbavMudanza_mudanzahoraservicio_Internalname);
            AV7Mudanza.gxTpr_Mudanzahoraservicio = cgiGet( cmbavMudanza_mudanzahoraservicio_Internalname);
            dynavMudanza_tipoinmuebleorigenid.Name = dynavMudanza_tipoinmuebleorigenid_Internalname;
            dynavMudanza_tipoinmuebleorigenid.CurrentValue = cgiGet( dynavMudanza_tipoinmuebleorigenid_Internalname);
            AV7Mudanza.gxTpr_Tipoinmuebleorigenid = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavMudanza_tipoinmuebleorigenid_Internalname), "."), 18, MidpointRounding.ToEven));
            dynavMudanza_tipoestacionamorigenid.Name = dynavMudanza_tipoestacionamorigenid_Internalname;
            dynavMudanza_tipoestacionamorigenid.CurrentValue = cgiGet( dynavMudanza_tipoestacionamorigenid_Internalname);
            AV7Mudanza.gxTpr_Tipoestacionamorigenid = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavMudanza_tipoestacionamorigenid_Internalname), "."), 18, MidpointRounding.ToEven));
            dynavMudanza_tipoinmuebledestinoid.Name = dynavMudanza_tipoinmuebledestinoid_Internalname;
            dynavMudanza_tipoinmuebledestinoid.CurrentValue = cgiGet( dynavMudanza_tipoinmuebledestinoid_Internalname);
            AV7Mudanza.gxTpr_Tipoinmuebledestinoid = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavMudanza_tipoinmuebledestinoid_Internalname), "."), 18, MidpointRounding.ToEven));
            dynavMudanza_tipoestacionamdestinoid.Name = dynavMudanza_tipoestacionamdestinoid_Internalname;
            dynavMudanza_tipoestacionamdestinoid.CurrentValue = cgiGet( dynavMudanza_tipoestacionamdestinoid_Internalname);
            AV7Mudanza.gxTpr_Tipoestacionamdestinoid = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavMudanza_tipoestacionamdestinoid_Internalname), "."), 18, MidpointRounding.ToEven));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzapeajecantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzapeajecantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZA_MUDANZAPEAJECANTIDAD");
               GX_FocusControl = edtavMudanza_mudanzapeajecantidad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Mudanzapeajecantidad = 0;
            }
            else
            {
               AV7Mudanza.gxTpr_Mudanzapeajecantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavMudanza_mudanzapeajecantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            cmbavMudanza_mudanzavehiculosugerido.Name = cmbavMudanza_mudanzavehiculosugerido_Internalname;
            cmbavMudanza_mudanzavehiculosugerido.CurrentValue = cgiGet( cmbavMudanza_mudanzavehiculosugerido_Internalname);
            AV7Mudanza.gxTpr_Mudanzavehiculosugerido = cgiGet( cmbavMudanza_mudanzavehiculosugerido_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzatiempomaximo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzatiempomaximo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZA_MUDANZATIEMPOMAXIMO");
               GX_FocusControl = edtavMudanza_mudanzatiempomaximo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Mudanzatiempomaximo = 0;
            }
            else
            {
               AV7Mudanza.gxTpr_Mudanzatiempomaximo = context.localUtil.CToN( cgiGet( edtavMudanza_mudanzatiempomaximo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzacargavolumenestimado_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzacargavolumenestimado_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZA_MUDANZACARGAVOLUMENESTIMADO");
               GX_FocusControl = edtavMudanza_mudanzacargavolumenestimado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Mudanzacargavolumenestimado = 0;
            }
            else
            {
               AV7Mudanza.gxTpr_Mudanzacargavolumenestimado = context.localUtil.CToN( cgiGet( edtavMudanza_mudanzacargavolumenestimado_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzapreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzapreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZA_MUDANZAPRECIOFINAL");
               GX_FocusControl = edtavMudanza_mudanzapreciofinal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Mudanzapreciofinal = 0;
            }
            else
            {
               AV7Mudanza.gxTpr_Mudanzapreciofinal = context.localUtil.CToN( cgiGet( edtavMudanza_mudanzapreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZA_MUDANZAID");
               GX_FocusControl = edtavMudanza_mudanzaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Mudanzaid = 0;
            }
            else
            {
               AV7Mudanza.gxTpr_Mudanzaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavMudanza_mudanzaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            }
            AV7Mudanza.gxTpr_Mudanzaasesor = cgiGet( edtavMudanza_mudanzaasesor_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavMudanza_mudanzafechaalta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Mudanza Fecha Alta", "")}), 1, "MUDANZA_MUDANZAFECHAALTA");
               GX_FocusControl = edtavMudanza_mudanzafechaalta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Mudanzafechaalta = DateTime.MinValue;
            }
            else
            {
               AV7Mudanza.gxTpr_Mudanzafechaalta = context.localUtil.CToD( cgiGet( edtavMudanza_mudanzafechaalta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzapeajevalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzapeajevalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZA_MUDANZAPEAJEVALOR");
               GX_FocusControl = edtavMudanza_mudanzapeajevalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Mudanzapeajevalor = 0;
            }
            else
            {
               AV7Mudanza.gxTpr_Mudanzapeajevalor = context.localUtil.CToN( cgiGet( edtavMudanza_mudanzapeajevalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            AV7Mudanza.gxTpr_Mudanzadirecciondestino = cgiGet( edtavMudanza_mudanzadirecciondestino_Internalname);
            AV7Mudanza.gxTpr_Tipoinmuebledestinonombre = cgiGet( edtavMudanza_tipoinmuebledestinonombre_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMudanza_tipoinmuebledestinovalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMudanza_tipoinmuebledestinovalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZA_TIPOINMUEBLEDESTINOVALOR");
               GX_FocusControl = edtavMudanza_tipoinmuebledestinovalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Tipoinmuebledestinovalor = 0;
            }
            else
            {
               AV7Mudanza.gxTpr_Tipoinmuebledestinovalor = context.localUtil.CToN( cgiGet( edtavMudanza_tipoinmuebledestinovalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            AV7Mudanza.gxTpr_Tipoestacionamdestinonombre = cgiGet( edtavMudanza_tipoestacionamdestinonombre_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMudanza_tipoestacionamdestinovalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMudanza_tipoestacionamdestinovalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZA_TIPOESTACIONAMDESTINOVALOR");
               GX_FocusControl = edtavMudanza_tipoestacionamdestinovalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Tipoestacionamdestinovalor = 0;
            }
            else
            {
               AV7Mudanza.gxTpr_Tipoestacionamdestinovalor = context.localUtil.CToN( cgiGet( edtavMudanza_tipoestacionamdestinovalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            AV7Mudanza.gxTpr_Mudanzadireccionorigen = cgiGet( edtavMudanza_mudanzadireccionorigen_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzadistancia_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMudanza_mudanzadistancia_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZA_MUDANZADISTANCIA");
               GX_FocusControl = edtavMudanza_mudanzadistancia_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Mudanzadistancia = 0;
            }
            else
            {
               AV7Mudanza.gxTpr_Mudanzadistancia = context.localUtil.CToN( cgiGet( edtavMudanza_mudanzadistancia_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            AV7Mudanza.gxTpr_Tipoinmuebleorigennombre = cgiGet( edtavMudanza_tipoinmuebleorigennombre_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMudanza_tipoinmuebleorigenvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMudanza_tipoinmuebleorigenvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZA_TIPOINMUEBLEORIGENVALOR");
               GX_FocusControl = edtavMudanza_tipoinmuebleorigenvalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Tipoinmuebleorigenvalor = 0;
            }
            else
            {
               AV7Mudanza.gxTpr_Tipoinmuebleorigenvalor = context.localUtil.CToN( cgiGet( edtavMudanza_tipoinmuebleorigenvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            cmbavMudanza_tipoestacionamorigennombre.Name = cmbavMudanza_tipoestacionamorigennombre_Internalname;
            cmbavMudanza_tipoestacionamorigennombre.CurrentValue = cgiGet( cmbavMudanza_tipoestacionamorigennombre_Internalname);
            AV7Mudanza.gxTpr_Tipoestacionamorigennombre = cgiGet( cmbavMudanza_tipoestacionamorigennombre_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavMudanza_tipoestacionamorigenvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavMudanza_tipoestacionamorigenvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUDANZA_TIPOESTACIONAMORIGENVALOR");
               GX_FocusControl = edtavMudanza_tipoestacionamorigenvalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Mudanza.gxTpr_Tipoestacionamorigenvalor = 0;
            }
            else
            {
               AV7Mudanza.gxTpr_Tipoestacionamorigenvalor = context.localUtil.CToN( cgiGet( edtavMudanza_tipoestacionamorigenvalor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E14EH2 ();
         if (returnInSub) return;
      }

      protected void E14EH2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV13LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV12TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV12TrnMode, "INS") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context).executeUdp(  "WWServicioMudanza_Insert") ) || ( ( StringUtil.StrCmp(AV12TrnMode, "UPD") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context).executeUdp(  "WWServicioMudanza_Update") ) || ( ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 ) && new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context).executeUdp(  "WWServicioMudanza_Delete") ) )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "INS") != 0 )
            {
               AV7Mudanza.Load(AV16MudanzaId);
               gx_BV75 = true;
               AV13LoadSuccess = AV7Mudanza.Success();
               if ( ! AV13LoadSuccess )
               {
                  AV11Messages = AV7Mudanza.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV12TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 ) )
               {
                  edtavMudanza_mudanzafechaservicio_Enabled = 0;
                  AssignProp("", false, edtavMudanza_mudanzafechaservicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzafechaservicio_Enabled), 5, 0), true);
                  cmbavMudanza_mudanzahoraservicio.Enabled = 0;
                  AssignProp("", false, cmbavMudanza_mudanzahoraservicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavMudanza_mudanzahoraservicio.Enabled), 5, 0), true);
                  edtavMudanza_mudanzapeajecantidad_Enabled = 0;
                  AssignProp("", false, edtavMudanza_mudanzapeajecantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzapeajecantidad_Enabled), 5, 0), true);
                  edtavMudanza_mudanzacargavolumenestimado_Enabled = 0;
                  AssignProp("", false, edtavMudanza_mudanzacargavolumenestimado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzacargavolumenestimado_Enabled), 5, 0), true);
                  dynavMudanza_tipoinmuebledestinoid.Enabled = 0;
                  AssignProp("", false, dynavMudanza_tipoinmuebledestinoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavMudanza_tipoinmuebledestinoid.Enabled), 5, 0), true);
                  dynavMudanza_tipoestacionamdestinoid.Enabled = 0;
                  AssignProp("", false, dynavMudanza_tipoestacionamdestinoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavMudanza_tipoestacionamdestinoid.Enabled), 5, 0), true);
                  dynavMudanza_tipoinmuebleorigenid.Enabled = 0;
                  AssignProp("", false, dynavMudanza_tipoinmuebleorigenid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavMudanza_tipoinmuebleorigenid.Enabled), 5, 0), true);
                  dynavMudanza_tipoestacionamorigenid.Enabled = 0;
                  AssignProp("", false, dynavMudanza_tipoestacionamorigenid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavMudanza_tipoestacionamorigenid.Enabled), 5, 0), true);
               }
            }
         }
         else
         {
            AV13LoadSuccess = false;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV60Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         if ( AV13LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""));
            }
         }
         Combo_mudanza_carga__itemcargaid_Titlecontrolidtoreplace = edtavMudanza_carga__itemcargaid_Internalname;
         ucCombo_mudanza_carga__itemcargaid.SendProperty(context, "", false, Combo_mudanza_carga__itemcargaid_Internalname, "TitleControlIdToReplace", Combo_mudanza_carga__itemcargaid_Titlecontrolidtoreplace);
         edtavMudanza_carga__itemcargaid_Horizontalalignment = "Left";
         AssignProp("", false, edtavMudanza_carga__itemcargaid_Internalname, "Horizontalalignment", edtavMudanza_carga__itemcargaid_Horizontalalignment, !bGXsfl_75_Refreshing);
         /* Execute user subroutine: 'LOADCOMBOMUDANZA_CARGA__ITEMCARGAID' */
         S122 ();
         if (returnInSub) return;
         edtavMudanza_mudanzaid_Visible = 0;
         AssignProp("", false, edtavMudanza_mudanzaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzaid_Visible), 5, 0), true);
         edtavMudanza_mudanzaasesor_Visible = 0;
         AssignProp("", false, edtavMudanza_mudanzaasesor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzaasesor_Visible), 5, 0), true);
         edtavMudanza_mudanzafechaalta_Visible = 0;
         AssignProp("", false, edtavMudanza_mudanzafechaalta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzafechaalta_Visible), 5, 0), true);
         edtavMudanza_mudanzapeajevalor_Visible = 0;
         AssignProp("", false, edtavMudanza_mudanzapeajevalor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzapeajevalor_Visible), 5, 0), true);
         edtavMudanza_mudanzadirecciondestino_Visible = 0;
         AssignProp("", false, edtavMudanza_mudanzadirecciondestino_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzadirecciondestino_Visible), 5, 0), true);
         edtavMudanza_tipoinmuebledestinonombre_Visible = 0;
         AssignProp("", false, edtavMudanza_tipoinmuebledestinonombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_tipoinmuebledestinonombre_Visible), 5, 0), true);
         edtavMudanza_tipoinmuebledestinovalor_Visible = 0;
         AssignProp("", false, edtavMudanza_tipoinmuebledestinovalor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_tipoinmuebledestinovalor_Visible), 5, 0), true);
         edtavMudanza_tipoestacionamdestinonombre_Visible = 0;
         AssignProp("", false, edtavMudanza_tipoestacionamdestinonombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_tipoestacionamdestinonombre_Visible), 5, 0), true);
         edtavMudanza_tipoestacionamdestinovalor_Visible = 0;
         AssignProp("", false, edtavMudanza_tipoestacionamdestinovalor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_tipoestacionamdestinovalor_Visible), 5, 0), true);
         edtavMudanza_mudanzadireccionorigen_Visible = 0;
         AssignProp("", false, edtavMudanza_mudanzadireccionorigen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzadireccionorigen_Visible), 5, 0), true);
         edtavMudanza_mudanzadistancia_Visible = 0;
         AssignProp("", false, edtavMudanza_mudanzadistancia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_mudanzadistancia_Visible), 5, 0), true);
         edtavMudanza_tipoinmuebleorigennombre_Visible = 0;
         AssignProp("", false, edtavMudanza_tipoinmuebleorigennombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_tipoinmuebleorigennombre_Visible), 5, 0), true);
         edtavMudanza_tipoinmuebleorigenvalor_Visible = 0;
         AssignProp("", false, edtavMudanza_tipoinmuebleorigenvalor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_tipoinmuebleorigenvalor_Visible), 5, 0), true);
         cmbavMudanza_tipoestacionamorigennombre.Visible = 0;
         AssignProp("", false, cmbavMudanza_tipoestacionamorigennombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMudanza_tipoestacionamorigennombre.Visible), 5, 0), true);
         edtavMudanza_tipoestacionamorigenvalor_Visible = 0;
         AssignProp("", false, edtavMudanza_tipoestacionamorigenvalor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMudanza_tipoestacionamorigenvalor_Visible), 5, 0), true);
         Gridlevel_adicional_empowerer_Gridinternalname = subGridlevel_adicional_Internalname;
         ucGridlevel_adicional_empowerer.SendProperty(context, "", false, Gridlevel_adicional_empowerer_Internalname, "GridInternalName", Gridlevel_adicional_empowerer_Gridinternalname);
         subGridlevel_adicional_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Rows), 6, 0, ".", "")));
         Gridlevel_carga_empowerer_Gridinternalname = subGridlevel_carga_Internalname;
         ucGridlevel_carga_empowerer.SendProperty(context, "", false, Gridlevel_carga_empowerer_Internalname, "GridInternalName", Gridlevel_carga_empowerer_Gridinternalname);
         subGridlevel_carga_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Rows), 6, 0, ".", "")));
      }

      protected void E15EH2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         edtavDeletegridlinegridlevel_adicional_Columnheaderclass = "WWIconActionColumn";
         AssignProp("", false, edtavDeletegridlinegridlevel_adicional_Internalname, "Columnheaderclass", edtavDeletegridlinegridlevel_adicional_Columnheaderclass, !bGXsfl_89_Refreshing);
         edtavMudanza_adicional__itemadicionalid_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavMudanza_adicional__itemadicionalid_Internalname, "Columnheaderclass", edtavMudanza_adicional__itemadicionalid_Columnheaderclass, !bGXsfl_89_Refreshing);
         edtavMudanza_adicional__itemadicionalnombre_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavMudanza_adicional__itemadicionalnombre_Internalname, "Columnheaderclass", edtavMudanza_adicional__itemadicionalnombre_Columnheaderclass, !bGXsfl_89_Refreshing);
         edtavMudanza_adicional__itemadicionalcantidad_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavMudanza_adicional__itemadicionalcantidad_Internalname, "Columnheaderclass", edtavMudanza_adicional__itemadicionalcantidad_Columnheaderclass, !bGXsfl_89_Refreshing);
         edtavMudanza_adicional__itemadicionalvalor_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavMudanza_adicional__itemadicionalvalor_Internalname, "Columnheaderclass", edtavMudanza_adicional__itemadicionalvalor_Columnheaderclass, !bGXsfl_89_Refreshing);
         edtavDeletegridlinegridlevel_carga_Columnheaderclass = "WWIconActionColumn";
         AssignProp("", false, edtavDeletegridlinegridlevel_carga_Internalname, "Columnheaderclass", edtavDeletegridlinegridlevel_carga_Columnheaderclass, !bGXsfl_75_Refreshing);
         edtavMudanza_carga__itemcargaid_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavMudanza_carga__itemcargaid_Internalname, "Columnheaderclass", edtavMudanza_carga__itemcargaid_Columnheaderclass, !bGXsfl_75_Refreshing);
         edtavMudanza_carga__itemcargacantidad_Columnheaderclass = "WWColumn ColumnAlignCenter";
         AssignProp("", false, edtavMudanza_carga__itemcargacantidad_Internalname, "Columnheaderclass", edtavMudanza_carga__itemcargacantidad_Columnheaderclass, !bGXsfl_75_Refreshing);
         edtavMudanza_carga__itemcargavolumen_Columnheaderclass = "WWColumn ColumnAlignCenter";
         AssignProp("", false, edtavMudanza_carga__itemcargavolumen_Internalname, "Columnheaderclass", edtavMudanza_carga__itemcargavolumen_Columnheaderclass, !bGXsfl_75_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E16EH2( )
      {
         /* Gridlevel_carga_Load Routine */
         returnInSub = false;
         AV35GXV12 = 1;
         while ( AV35GXV12 <= AV7Mudanza.gxTpr_Carga.Count )
         {
            AV7Mudanza.gxTpr_Carga.CurrentItem = ((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12));
            AV15LineDeleted = (bool)(((AV21MudanzaCargaDeleted.IndexOf((short)(AV7Mudanza.gxTpr_Carga.IndexOf(AV7Mudanza.gxTpr_Carga.CurrentItem)))>0)));
            edtavMudanza_carga__itemcargaid_Enabled = (((StringUtil.StrCmp(AV12TrnMode, "INS")==0)||(StringUtil.StrCmp(AV12TrnMode, "UPD")==0))&&(!AV15LineDeleted)&&StringUtil.Contains( AV7Mudanza.gxTpr_Carga.CurrentItem.ToXml(false, true, "", ""), "<Mode>INS</Mode>") ? 1 : 0);
            edtavMudanza_carga__itemcargacantidad_Enabled = (((StringUtil.StrCmp(AV12TrnMode, "INS")==0)||(StringUtil.StrCmp(AV12TrnMode, "UPD")==0))&&(!AV15LineDeleted) ? 1 : 0);
            AV9DeleteGridLineGridLevel_Carga = "<i class=\"fa fa-times TrnGridDelete\"></i>";
            AssignAttri("", false, edtavDeletegridlinegridlevel_carga_Internalname, AV9DeleteGridLineGridLevel_Carga);
            if ( ( StringUtil.StrCmp(AV12TrnMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV12TrnMode, "UPD") == 0 ) )
            {
               edtavDeletegridlinegridlevel_carga_Class = "Attribute";
            }
            else
            {
               edtavDeletegridlinegridlevel_carga_Class = "Invisible";
            }
            edtavDeletegridlinegridlevel_carga_Columnclass = (AV15LineDeleted ? "WWIconActionColumn WWColumnLineThrough WWColumnLineThroughFirstColumn" : "WWIconActionColumn");
            edtavMudanza_carga__itemcargaid_Columnclass = (AV15LineDeleted ? "WWColumn WWColumnLineThrough" : "WWColumn");
            edtavMudanza_carga__itemcargacantidad_Columnclass = (AV15LineDeleted ? "WWColumn WWColumnLineThrough ColumnAlignCenter" : "WWColumn ColumnAlignCenter");
            edtavMudanza_carga__itemcargavolumen_Columnclass = (AV15LineDeleted ? "WWColumn WWColumnLineThrough ColumnAlignCenter" : "WWColumn ColumnAlignCenter");
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 75;
            }
            if ( ( subGridlevel_carga_Islastpage == 1 ) || ( subGridlevel_carga_Rows == 0 ) || ( ( GRIDLEVEL_CARGA_nCurrentRecord >= GRIDLEVEL_CARGA_nFirstRecordOnPage ) && ( GRIDLEVEL_CARGA_nCurrentRecord < GRIDLEVEL_CARGA_nFirstRecordOnPage + subGridlevel_carga_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_752( ) ;
            }
            GRIDLEVEL_CARGA_nEOF = (short)(((subGridlevel_carga_Rows==0)||(GRIDLEVEL_CARGA_nCurrentRecord<GRIDLEVEL_CARGA_nFirstRecordOnPage+subGridlevel_carga_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDLEVEL_CARGA_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_CARGA_nEOF), 1, 0, ".", "")));
            GRIDLEVEL_CARGA_nCurrentRecord = (long)(GRIDLEVEL_CARGA_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_75_Refreshing )
            {
               context.DoAjaxLoad(75, Gridlevel_cargaRow);
            }
            AV35GXV12 = (int)(AV35GXV12+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E11EH2( )
      {
         AV35GXV12 = (int)(nGXsfl_75_idx+GRIDLEVEL_CARGA_nFirstRecordOnPage);
         if ( ( AV35GXV12 > 0 ) && ( AV7Mudanza.gxTpr_Carga.Count >= AV35GXV12 ) )
         {
            AV7Mudanza.gxTpr_Carga.CurrentItem = ((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12));
         }
         AV40GXV17 = (int)(nGXsfl_89_idx+GRIDLEVEL_ADICIONAL_nFirstRecordOnPage);
         if ( ( AV40GXV17 > 0 ) && ( AV7Mudanza.gxTpr_Adicional.Count >= AV40GXV17 ) )
         {
            AV7Mudanza.gxTpr_Adicional.CurrentItem = ((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17));
         }
         /* 'DoAddGridLineGridLevel_Adicional' Routine */
         returnInSub = false;
         AV17MudanzaAdicionalItem = new SdtMudanza_Adicional(context);
         AV7Mudanza.gxTpr_Adicional.Add(AV17MudanzaAdicionalItem, 0);
         gx_BV89 = true;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Mudanza", AV7Mudanza);
         nGXsfl_75_bak_idx = nGXsfl_75_idx;
         gxgrGridlevel_carga_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV21MudanzaCargaDeleted, AV16MudanzaId) ;
         nGXsfl_75_idx = nGXsfl_75_bak_idx;
         sGXsfl_75_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_75_idx), 4, 0), 4, "0");
         SubsflControlProps_752( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Mudanza", AV7Mudanza);
         nGXsfl_89_bak_idx = nGXsfl_89_idx;
         gxgrGridlevel_adicional_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV19MudanzaAdicionalDeleted, AV16MudanzaId) ;
         nGXsfl_89_idx = nGXsfl_89_bak_idx;
         sGXsfl_89_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_89_idx), 4, 0), 4, "0");
         SubsflControlProps_893( ) ;
      }

      protected void E12EH2( )
      {
         AV35GXV12 = (int)(nGXsfl_75_idx+GRIDLEVEL_CARGA_nFirstRecordOnPage);
         if ( ( AV35GXV12 > 0 ) && ( AV7Mudanza.gxTpr_Carga.Count >= AV35GXV12 ) )
         {
            AV7Mudanza.gxTpr_Carga.CurrentItem = ((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12));
         }
         AV40GXV17 = (int)(nGXsfl_89_idx+GRIDLEVEL_ADICIONAL_nFirstRecordOnPage);
         if ( ( AV40GXV17 > 0 ) && ( AV7Mudanza.gxTpr_Adicional.Count >= AV40GXV17 ) )
         {
            AV7Mudanza.gxTpr_Adicional.CurrentItem = ((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17));
         }
         /* 'DoAddGridLineGridLevel_Carga' Routine */
         returnInSub = false;
         AV20MudanzaCargaItem = new SdtMudanza_Carga(context);
         AV7Mudanza.gxTpr_Carga.Add(AV20MudanzaCargaItem, 0);
         gx_BV75 = true;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Mudanza", AV7Mudanza);
         nGXsfl_75_bak_idx = nGXsfl_75_idx;
         gxgrGridlevel_carga_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV21MudanzaCargaDeleted, AV16MudanzaId) ;
         nGXsfl_75_idx = nGXsfl_75_bak_idx;
         sGXsfl_75_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_75_idx), 4, 0), 4, "0");
         SubsflControlProps_752( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Mudanza", AV7Mudanza);
         nGXsfl_89_bak_idx = nGXsfl_89_idx;
         gxgrGridlevel_adicional_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV19MudanzaAdicionalDeleted, AV16MudanzaId) ;
         nGXsfl_89_idx = nGXsfl_89_bak_idx;
         sGXsfl_89_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_89_idx), 4, 0), 4, "0");
         SubsflControlProps_893( ) ;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E13EH2 ();
         if (returnInSub) return;
      }

      protected void E13EH2( )
      {
         AV35GXV12 = (int)(nGXsfl_75_idx+GRIDLEVEL_CARGA_nFirstRecordOnPage);
         if ( ( AV35GXV12 > 0 ) && ( AV7Mudanza.gxTpr_Carga.Count >= AV35GXV12 ) )
         {
            AV7Mudanza.gxTpr_Carga.CurrentItem = ((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12));
         }
         AV40GXV17 = (int)(nGXsfl_89_idx+GRIDLEVEL_ADICIONAL_nFirstRecordOnPage);
         if ( ( AV40GXV17 > 0 ) && ( AV7Mudanza.gxTpr_Adicional.Count >= AV40GXV17 ) )
         {
            AV7Mudanza.gxTpr_Adicional.CurrentItem = ((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV12TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV12TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S142 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 ) || AV14CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV12TrnMode, "DLT") == 0 )
               {
                  AV7Mudanza.Delete();
                  gx_BV75 = true;
               }
               else
               {
                  AV19MudanzaAdicionalDeleted.Sort("");
                  while ( AV19MudanzaAdicionalDeleted.Count > 0 )
                  {
                     AV7Mudanza.gxTpr_Adicional.RemoveItem((int)(AV19MudanzaAdicionalDeleted.GetNumeric(AV19MudanzaAdicionalDeleted.Count)));
                     gx_BV89 = true;
                     AV19MudanzaAdicionalDeleted.RemoveItem(AV19MudanzaAdicionalDeleted.Count);
                  }
                  AV21MudanzaCargaDeleted.Sort("");
                  while ( AV21MudanzaCargaDeleted.Count > 0 )
                  {
                     AV7Mudanza.gxTpr_Carga.RemoveItem((int)(AV21MudanzaCargaDeleted.GetNumeric(AV21MudanzaCargaDeleted.Count)));
                     gx_BV75 = true;
                     AV21MudanzaCargaDeleted.RemoveItem(AV21MudanzaCargaDeleted.Count);
                  }
                  AV7Mudanza.Save();
                  gx_BV75 = true;
               }
               if ( AV7Mudanza.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S152 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV11Messages = AV7Mudanza.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19MudanzaAdicionalDeleted", AV19MudanzaAdicionalDeleted);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21MudanzaCargaDeleted", AV21MudanzaCargaDeleted);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Mudanza", AV7Mudanza);
         nGXsfl_75_bak_idx = nGXsfl_75_idx;
         gxgrGridlevel_carga_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV21MudanzaCargaDeleted, AV16MudanzaId) ;
         nGXsfl_75_idx = nGXsfl_75_bak_idx;
         sGXsfl_75_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_75_idx), 4, 0), 4, "0");
         SubsflControlProps_752( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Mudanza", AV7Mudanza);
         nGXsfl_89_bak_idx = nGXsfl_89_idx;
         gxgrGridlevel_adicional_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV19MudanzaAdicionalDeleted, AV16MudanzaId) ;
         nGXsfl_89_idx = nGXsfl_89_bak_idx;
         sGXsfl_89_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_89_idx), 4, 0), 4, "0");
         SubsflControlProps_893( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11Messages", AV11Messages);
      }

      protected void E19EH2( )
      {
         AV35GXV12 = (int)(nGXsfl_75_idx+GRIDLEVEL_CARGA_nFirstRecordOnPage);
         if ( ( AV35GXV12 > 0 ) && ( AV7Mudanza.gxTpr_Carga.Count >= AV35GXV12 ) )
         {
            AV7Mudanza.gxTpr_Carga.CurrentItem = ((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12));
         }
         AV40GXV17 = (int)(nGXsfl_89_idx+GRIDLEVEL_ADICIONAL_nFirstRecordOnPage);
         if ( ( AV40GXV17 > 0 ) && ( AV7Mudanza.gxTpr_Adicional.Count >= AV40GXV17 ) )
         {
            AV7Mudanza.gxTpr_Adicional.CurrentItem = ((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17));
         }
         /* Deletegridlinegridlevel_adicional_Click Routine */
         returnInSub = false;
         AV18Index = (short)(AV7Mudanza.gxTpr_Adicional.IndexOf(AV7Mudanza.gxTpr_Adicional.CurrentItem));
         if ( AV19MudanzaAdicionalDeleted.IndexOf(AV18Index) > 0 )
         {
            AV19MudanzaAdicionalDeleted.RemoveItem(AV19MudanzaAdicionalDeleted.IndexOf(AV18Index));
         }
         else
         {
            AV19MudanzaAdicionalDeleted.Add(AV18Index, 0);
         }
         gxgrGridlevel_adicional_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV19MudanzaAdicionalDeleted, AV16MudanzaId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19MudanzaAdicionalDeleted", AV19MudanzaAdicionalDeleted);
      }

      protected void E17EH2( )
      {
         AV35GXV12 = (int)(nGXsfl_75_idx+GRIDLEVEL_CARGA_nFirstRecordOnPage);
         if ( ( AV35GXV12 > 0 ) && ( AV7Mudanza.gxTpr_Carga.Count >= AV35GXV12 ) )
         {
            AV7Mudanza.gxTpr_Carga.CurrentItem = ((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12));
         }
         AV40GXV17 = (int)(nGXsfl_89_idx+GRIDLEVEL_ADICIONAL_nFirstRecordOnPage);
         if ( ( AV40GXV17 > 0 ) && ( AV7Mudanza.gxTpr_Adicional.Count >= AV40GXV17 ) )
         {
            AV7Mudanza.gxTpr_Adicional.CurrentItem = ((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17));
         }
         /* Deletegridlinegridlevel_carga_Click Routine */
         returnInSub = false;
         AV18Index = (short)(AV7Mudanza.gxTpr_Carga.IndexOf(AV7Mudanza.gxTpr_Carga.CurrentItem));
         if ( AV21MudanzaCargaDeleted.IndexOf(AV18Index) > 0 )
         {
            AV21MudanzaCargaDeleted.RemoveItem(AV21MudanzaCargaDeleted.IndexOf(AV18Index));
         }
         else
         {
            AV21MudanzaCargaDeleted.Add(AV18Index, 0);
         }
         gxgrGridlevel_carga_refresh( subGridlevel_carga_Rows, subGridlevel_adicional_Rows, AV12TrnMode, AV7Mudanza, AV21MudanzaCargaDeleted, AV16MudanzaId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21MudanzaCargaDeleted", AV21MudanzaCargaDeleted);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV12TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV12TrnMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV12TrnMode, "UPD") == 0 ) ) )
         {
            bttBtnaddgridlinegridlevel_adicional_Visible = 0;
            AssignProp("", false, bttBtnaddgridlinegridlevel_adicional_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnaddgridlinegridlevel_adicional_Visible), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV12TrnMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV12TrnMode, "UPD") == 0 ) ) )
         {
            bttBtnaddgridlinegridlevel_carga_Visible = 0;
            AssignProp("", false, bttBtnaddgridlinegridlevel_carga_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnaddgridlinegridlevel_carga_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOMUDANZA_CARGA__ITEMCARGAID' Routine */
         returnInSub = false;
         /* Using cursor H00EH6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A751ItemCargaId = H00EH6_A751ItemCargaId[0];
            AV23Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV23Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A751ItemCargaId), 4, 0));
            AV23Combo_DataItem.gxTpr_Title = StringUtil.Trim( context.localUtil.Format( (decimal)(A751ItemCargaId), "ZZZ9"));
            AV22Mudanza_Carga__ItemCargaId_Data.Add(AV23Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV62GXV37 = 1;
         while ( AV62GXV37 <= AV11Messages.Count )
         {
            AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(AV62GXV37));
            GX_msglist.addItem(AV10Message.gxTpr_Description);
            AV62GXV37 = (int)(AV62GXV37+1);
         }
      }

      protected void S152( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("solicitudmudanza",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S142( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV14CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV14CheckRequiredFieldsResult", AV14CheckRequiredFieldsResult);
      }

      private void E18EH3( )
      {
         /* Gridlevel_adicional_Load Routine */
         returnInSub = false;
         AV40GXV17 = 1;
         while ( AV40GXV17 <= AV7Mudanza.gxTpr_Adicional.Count )
         {
            AV7Mudanza.gxTpr_Adicional.CurrentItem = ((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17));
            AV15LineDeleted = (bool)(((AV19MudanzaAdicionalDeleted.IndexOf((short)(AV7Mudanza.gxTpr_Adicional.IndexOf(AV7Mudanza.gxTpr_Adicional.CurrentItem)))>0)));
            edtavMudanza_adicional__itemadicionalid_Enabled = (((StringUtil.StrCmp(AV12TrnMode, "INS")==0)||(StringUtil.StrCmp(AV12TrnMode, "UPD")==0))&&(!AV15LineDeleted)&&StringUtil.Contains( AV7Mudanza.gxTpr_Adicional.CurrentItem.ToXml(false, true, "", ""), "<Mode>INS</Mode>") ? 1 : 0);
            edtavMudanza_adicional__itemadicionalcantidad_Enabled = (((StringUtil.StrCmp(AV12TrnMode, "INS")==0)||(StringUtil.StrCmp(AV12TrnMode, "UPD")==0))&&(!AV15LineDeleted) ? 1 : 0);
            AV8DeleteGridLineGridLevel_Adicional = "<i class=\"fa fa-times TrnGridDelete\"></i>";
            AssignAttri("", false, edtavDeletegridlinegridlevel_adicional_Internalname, AV8DeleteGridLineGridLevel_Adicional);
            if ( ( StringUtil.StrCmp(AV12TrnMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV12TrnMode, "UPD") == 0 ) )
            {
               edtavDeletegridlinegridlevel_adicional_Class = "Attribute";
            }
            else
            {
               edtavDeletegridlinegridlevel_adicional_Class = "Invisible";
            }
            edtavDeletegridlinegridlevel_adicional_Columnclass = (AV15LineDeleted ? "WWIconActionColumn WWColumnLineThrough WWColumnLineThroughFirstColumn" : "WWIconActionColumn");
            edtavMudanza_adicional__itemadicionalid_Columnclass = (AV15LineDeleted ? "WWColumn WWColumnLineThrough" : "WWColumn");
            edtavMudanza_adicional__itemadicionalnombre_Columnclass = (AV15LineDeleted ? "WWColumn WWColumnLineThrough" : "WWColumn");
            edtavMudanza_adicional__itemadicionalcantidad_Columnclass = (AV15LineDeleted ? "WWColumn WWColumnLineThrough" : "WWColumn");
            edtavMudanza_adicional__itemadicionalvalor_Columnclass = (AV15LineDeleted ? "WWColumn WWColumnLineThrough" : "WWColumn");
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 89;
            }
            if ( ( subGridlevel_adicional_Islastpage == 1 ) || ( subGridlevel_adicional_Rows == 0 ) || ( ( GRIDLEVEL_ADICIONAL_nCurrentRecord >= GRIDLEVEL_ADICIONAL_nFirstRecordOnPage ) && ( GRIDLEVEL_ADICIONAL_nCurrentRecord < GRIDLEVEL_ADICIONAL_nFirstRecordOnPage + subGridlevel_adicional_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_893( ) ;
            }
            GRIDLEVEL_ADICIONAL_nEOF = (short)(((subGridlevel_adicional_Rows==0)||(GRIDLEVEL_ADICIONAL_nCurrentRecord<GRIDLEVEL_ADICIONAL_nFirstRecordOnPage+subGridlevel_adicional_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDLEVEL_ADICIONAL_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_ADICIONAL_nEOF), 1, 0, ".", "")));
            GRIDLEVEL_ADICIONAL_nCurrentRecord = (long)(GRIDLEVEL_ADICIONAL_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_89_Refreshing )
            {
               context.DoAjaxLoad(89, Gridlevel_adicionalRow);
            }
            AV40GXV17 = (int)(AV40GXV17+1);
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table1_37_EH2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtable2_Internalname, tblUnnamedtable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynavMudanza_tipoinmuebledestinoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavMudanza_tipoinmuebledestinoid_Internalname, context.GetMessage( "inmueble", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_75_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavMudanza_tipoinmuebledestinoid, dynavMudanza_tipoinmuebledestinoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoinmuebledestinoid), 4, 0)), 1, dynavMudanza_tipoinmuebledestinoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavMudanza_tipoinmuebledestinoid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_SolicitudMudanza.htm");
            dynavMudanza_tipoinmuebledestinoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoinmuebledestinoid), 4, 0));
            AssignProp("", false, dynavMudanza_tipoinmuebledestinoid_Internalname, "Values", (string)(dynavMudanza_tipoinmuebledestinoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynavMudanza_tipoestacionamdestinoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavMudanza_tipoestacionamdestinoid_Internalname, context.GetMessage( "Estacionamiento", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_75_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavMudanza_tipoestacionamdestinoid, dynavMudanza_tipoestacionamdestinoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoestacionamdestinoid), 4, 0)), 1, dynavMudanza_tipoestacionamdestinoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavMudanza_tipoestacionamdestinoid.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_SolicitudMudanza.htm");
            dynavMudanza_tipoestacionamdestinoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Mudanza.gxTpr_Tipoestacionamdestinoid), 4, 0));
            AssignProp("", false, dynavMudanza_tipoestacionamdestinoid_Internalname, "Values", (string)(dynavMudanza_tipoestacionamdestinoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_37_EH2e( true) ;
         }
         else
         {
            wb_table1_37_EH2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV12TrnMode", AV12TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12TrnMode, "")), context));
         AV16MudanzaId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV16MudanzaId", StringUtil.LTrimStr( (decimal)(AV16MudanzaId), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16MudanzaId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         PAEH2( ) ;
         WSEH2( ) ;
         WEEH2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20268622571588", true, true, false);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true, false);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("solicitudmudanza.js", "?20268622571589", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_752( )
      {
         edtavDeletegridlinegridlevel_carga_Internalname = "vDELETEGRIDLINEGRIDLEVEL_CARGA_"+sGXsfl_75_idx;
         edtavMudanza_carga__itemcargaid_Internalname = "MUDANZA_CARGA__ITEMCARGAID_"+sGXsfl_75_idx;
         edtavMudanza_carga__itemcarganombre_Internalname = "MUDANZA_CARGA__ITEMCARGANOMBRE_"+sGXsfl_75_idx;
         edtavMudanza_carga__itemcargacantidad_Internalname = "MUDANZA_CARGA__ITEMCARGACANTIDAD_"+sGXsfl_75_idx;
         edtavMudanza_carga__itemcargavolumen_Internalname = "MUDANZA_CARGA__ITEMCARGAVOLUMEN_"+sGXsfl_75_idx;
      }

      protected void SubsflControlProps_fel_752( )
      {
         edtavDeletegridlinegridlevel_carga_Internalname = "vDELETEGRIDLINEGRIDLEVEL_CARGA_"+sGXsfl_75_fel_idx;
         edtavMudanza_carga__itemcargaid_Internalname = "MUDANZA_CARGA__ITEMCARGAID_"+sGXsfl_75_fel_idx;
         edtavMudanza_carga__itemcarganombre_Internalname = "MUDANZA_CARGA__ITEMCARGANOMBRE_"+sGXsfl_75_fel_idx;
         edtavMudanza_carga__itemcargacantidad_Internalname = "MUDANZA_CARGA__ITEMCARGACANTIDAD_"+sGXsfl_75_fel_idx;
         edtavMudanza_carga__itemcargavolumen_Internalname = "MUDANZA_CARGA__ITEMCARGAVOLUMEN_"+sGXsfl_75_fel_idx;
      }

      protected void sendrow_752( )
      {
         sGXsfl_75_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_75_idx), 4, 0), 4, "0");
         SubsflControlProps_752( ) ;
         WBEH0( ) ;
         if ( ( subGridlevel_carga_Rows * 1 == 0 ) || ( nGXsfl_75_idx <= subGridlevel_carga_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridlevel_cargaRow = GXWebRow.GetNew(context,Gridlevel_cargaContainer);
            if ( subGridlevel_carga_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridlevel_carga_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridlevel_carga_Class, "") != 0 )
               {
                  subGridlevel_carga_Linesclass = subGridlevel_carga_Class+"Odd";
               }
            }
            else if ( subGridlevel_carga_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridlevel_carga_Backstyle = 0;
               subGridlevel_carga_Backcolor = subGridlevel_carga_Allbackcolor;
               if ( StringUtil.StrCmp(subGridlevel_carga_Class, "") != 0 )
               {
                  subGridlevel_carga_Linesclass = subGridlevel_carga_Class+"Uniform";
               }
            }
            else if ( subGridlevel_carga_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridlevel_carga_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridlevel_carga_Class, "") != 0 )
               {
                  subGridlevel_carga_Linesclass = subGridlevel_carga_Class+"Odd";
               }
               subGridlevel_carga_Backcolor = (int)(0x0);
            }
            else if ( subGridlevel_carga_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridlevel_carga_Backstyle = 1;
               if ( ((int)((nGXsfl_75_idx) % (2))) == 0 )
               {
                  subGridlevel_carga_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlevel_carga_Class, "") != 0 )
                  {
                     subGridlevel_carga_Linesclass = subGridlevel_carga_Class+"Even";
                  }
               }
               else
               {
                  subGridlevel_carga_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlevel_carga_Class, "") != 0 )
                  {
                     subGridlevel_carga_Linesclass = subGridlevel_carga_Class+"Odd";
                  }
               }
            }
            if ( Gridlevel_cargaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_75_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridlevel_cargaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_75_idx + "',75)\"";
            ROClassString = edtavDeletegridlinegridlevel_carga_Class;
            Gridlevel_cargaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeletegridlinegridlevel_carga_Internalname,StringUtil.RTrim( AV9DeleteGridLineGridLevel_Carga),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"","'"+""+"'"+",false,"+"'"+"EVDELETEGRIDLINEGRIDLEVEL_CARGA.CLICK."+sGXsfl_75_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDeletegridlinegridlevel_carga_Jsonclick,(short)5,(string)edtavDeletegridlinegridlevel_carga_Class,(string)"",(string)ROClassString,(string)edtavDeletegridlinegridlevel_carga_Columnclass,(string)edtavDeletegridlinegridlevel_carga_Columnheaderclass,(short)-1,(int)edtavDeletegridlinegridlevel_carga_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)75,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridlevel_cargaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+edtavMudanza_carga__itemcargaid_Horizontalalignment+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_75_idx + "',75)\"";
            ROClassString = "Attribute";
            Gridlevel_cargaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMudanza_carga__itemcargaid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12)).gxTpr_Itemcargaid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12)).gxTpr_Itemcargaid), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,77);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMudanza_carga__itemcargaid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavMudanza_carga__itemcargaid_Columnclass,(string)edtavMudanza_carga__itemcargaid_Columnheaderclass,(short)-1,(int)edtavMudanza_carga__itemcargaid_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)75,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)edtavMudanza_carga__itemcargaid_Horizontalalignment,(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridlevel_cargaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridlevel_cargaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMudanza_carga__itemcarganombre_Internalname,((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12)).gxTpr_Itemcarganombre,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMudanza_carga__itemcarganombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavMudanza_carga__itemcarganombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)75,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridlevel_cargaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_75_idx + "',75)\"";
            ROClassString = "Attribute";
            Gridlevel_cargaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMudanza_carga__itemcargacantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12)).gxTpr_Itemcargacantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12)).gxTpr_Itemcargacantidad), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMudanza_carga__itemcargacantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavMudanza_carga__itemcargacantidad_Columnclass,(string)edtavMudanza_carga__itemcargacantidad_Columnheaderclass,(short)-1,(int)edtavMudanza_carga__itemcargacantidad_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)75,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridlevel_cargaContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_75_idx + "',75)\"";
            ROClassString = "Attribute";
            Gridlevel_cargaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMudanza_carga__itemcargavolumen_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12)).gxTpr_Itemcargavolumen, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavMudanza_carga__itemcargavolumen_Enabled!=0) ? context.localUtil.Format( ((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12)).gxTpr_Itemcargavolumen, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtMudanza_Carga)AV7Mudanza.gxTpr_Carga.Item(AV35GXV12)).gxTpr_Itemcargavolumen, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,80);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMudanza_carga__itemcargavolumen_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavMudanza_carga__itemcargavolumen_Columnclass,(string)edtavMudanza_carga__itemcargavolumen_Columnheaderclass,(short)-1,(int)edtavMudanza_carga__itemcargavolumen_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)75,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesEH2( ) ;
            Gridlevel_cargaContainer.AddRow(Gridlevel_cargaRow);
            nGXsfl_75_idx = ((subGridlevel_carga_Islastpage==1)&&(nGXsfl_75_idx+1>subGridlevel_carga_fnc_Recordsperpage( )) ? 1 : nGXsfl_75_idx+1);
            sGXsfl_75_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_75_idx), 4, 0), 4, "0");
            SubsflControlProps_752( ) ;
         }
         /* End function sendrow_752 */
      }

      protected void SubsflControlProps_893( )
      {
         edtavDeletegridlinegridlevel_adicional_Internalname = "vDELETEGRIDLINEGRIDLEVEL_ADICIONAL_"+sGXsfl_89_idx;
         edtavMudanza_adicional__itemadicionalid_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALID_"+sGXsfl_89_idx;
         edtavMudanza_adicional__itemadicionalnombre_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE_"+sGXsfl_89_idx;
         edtavMudanza_adicional__itemadicionalcantidad_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD_"+sGXsfl_89_idx;
         edtavMudanza_adicional__itemadicionalvalor_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALVALOR_"+sGXsfl_89_idx;
      }

      protected void SubsflControlProps_fel_893( )
      {
         edtavDeletegridlinegridlevel_adicional_Internalname = "vDELETEGRIDLINEGRIDLEVEL_ADICIONAL_"+sGXsfl_89_fel_idx;
         edtavMudanza_adicional__itemadicionalid_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALID_"+sGXsfl_89_fel_idx;
         edtavMudanza_adicional__itemadicionalnombre_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE_"+sGXsfl_89_fel_idx;
         edtavMudanza_adicional__itemadicionalcantidad_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD_"+sGXsfl_89_fel_idx;
         edtavMudanza_adicional__itemadicionalvalor_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALVALOR_"+sGXsfl_89_fel_idx;
      }

      protected void sendrow_893( )
      {
         sGXsfl_89_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_89_idx), 4, 0), 4, "0");
         SubsflControlProps_893( ) ;
         WBEH0( ) ;
         if ( ( subGridlevel_adicional_Rows * 1 == 0 ) || ( nGXsfl_89_idx <= subGridlevel_adicional_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridlevel_adicionalRow = GXWebRow.GetNew(context,Gridlevel_adicionalContainer);
            if ( subGridlevel_adicional_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridlevel_adicional_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridlevel_adicional_Class, "") != 0 )
               {
                  subGridlevel_adicional_Linesclass = subGridlevel_adicional_Class+"Odd";
               }
            }
            else if ( subGridlevel_adicional_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridlevel_adicional_Backstyle = 0;
               subGridlevel_adicional_Backcolor = subGridlevel_adicional_Allbackcolor;
               if ( StringUtil.StrCmp(subGridlevel_adicional_Class, "") != 0 )
               {
                  subGridlevel_adicional_Linesclass = subGridlevel_adicional_Class+"Uniform";
               }
            }
            else if ( subGridlevel_adicional_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridlevel_adicional_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridlevel_adicional_Class, "") != 0 )
               {
                  subGridlevel_adicional_Linesclass = subGridlevel_adicional_Class+"Odd";
               }
               subGridlevel_adicional_Backcolor = (int)(0x0);
            }
            else if ( subGridlevel_adicional_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridlevel_adicional_Backstyle = 1;
               if ( ((int)((nGXsfl_89_idx) % (2))) == 0 )
               {
                  subGridlevel_adicional_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlevel_adicional_Class, "") != 0 )
                  {
                     subGridlevel_adicional_Linesclass = subGridlevel_adicional_Class+"Even";
                  }
               }
               else
               {
                  subGridlevel_adicional_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlevel_adicional_Class, "") != 0 )
                  {
                     subGridlevel_adicional_Linesclass = subGridlevel_adicional_Class+"Odd";
                  }
               }
            }
            if ( Gridlevel_adicionalContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_89_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridlevel_adicionalContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_89_idx + "',89)\"";
            ROClassString = edtavDeletegridlinegridlevel_adicional_Class;
            Gridlevel_adicionalRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeletegridlinegridlevel_adicional_Internalname,StringUtil.RTrim( AV8DeleteGridLineGridLevel_Adicional),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"","'"+""+"'"+",false,"+"'"+"EVDELETEGRIDLINEGRIDLEVEL_ADICIONAL.CLICK."+sGXsfl_89_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDeletegridlinegridlevel_adicional_Jsonclick,(short)5,(string)edtavDeletegridlinegridlevel_adicional_Class,(string)"",(string)ROClassString,(string)edtavDeletegridlinegridlevel_adicional_Columnclass,(string)edtavDeletegridlinegridlevel_adicional_Columnheaderclass,(short)-1,(int)edtavDeletegridlinegridlevel_adicional_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)89,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridlevel_adicionalContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_89_idx + "',89)\"";
            ROClassString = "Attribute";
            Gridlevel_adicionalRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMudanza_adicional__itemadicionalid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17)).gxTpr_Itemadicionalid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17)).gxTpr_Itemadicionalid), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,91);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMudanza_adicional__itemadicionalid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavMudanza_adicional__itemadicionalid_Columnclass,(string)edtavMudanza_adicional__itemadicionalid_Columnheaderclass,(short)-1,(int)edtavMudanza_adicional__itemadicionalid_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)89,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridlevel_adicionalContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_89_idx + "',89)\"";
            ROClassString = "Attribute";
            Gridlevel_adicionalRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMudanza_adicional__itemadicionalnombre_Internalname,((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17)).gxTpr_Itemadicionalnombre,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMudanza_adicional__itemadicionalnombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavMudanza_adicional__itemadicionalnombre_Columnclass,(string)edtavMudanza_adicional__itemadicionalnombre_Columnheaderclass,(short)-1,(int)edtavMudanza_adicional__itemadicionalnombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)89,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridlevel_adicionalContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_89_idx + "',89)\"";
            ROClassString = "Attribute";
            Gridlevel_adicionalRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMudanza_adicional__itemadicionalcantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17)).gxTpr_Itemadicionalcantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17)).gxTpr_Itemadicionalcantidad), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,93);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMudanza_adicional__itemadicionalcantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavMudanza_adicional__itemadicionalcantidad_Columnclass,(string)edtavMudanza_adicional__itemadicionalcantidad_Columnheaderclass,(short)-1,(int)edtavMudanza_adicional__itemadicionalcantidad_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)89,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridlevel_adicionalContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_89_idx + "',89)\"";
            ROClassString = "Attribute";
            Gridlevel_adicionalRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavMudanza_adicional__itemadicionalvalor_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17)).gxTpr_Itemadicionalvalor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavMudanza_adicional__itemadicionalvalor_Enabled!=0) ? context.localUtil.Format( ((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17)).gxTpr_Itemadicionalvalor, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtMudanza_Adicional)AV7Mudanza.gxTpr_Adicional.Item(AV40GXV17)).gxTpr_Itemadicionalvalor, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,94);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavMudanza_adicional__itemadicionalvalor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavMudanza_adicional__itemadicionalvalor_Columnclass,(string)edtavMudanza_adicional__itemadicionalvalor_Columnheaderclass,(short)-1,(int)edtavMudanza_adicional__itemadicionalvalor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)89,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesEH3( ) ;
            GXCCtl = "vMUDANZA_" + sGXsfl_89_idx;
            if ( context.isAjaxRequest( ) )
            {
               context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV7Mudanza);
            }
            else
            {
               context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV7Mudanza);
            }
            Gridlevel_adicionalContainer.AddRow(Gridlevel_adicionalRow);
            nGXsfl_89_idx = ((subGridlevel_adicional_Islastpage==1)&&(nGXsfl_89_idx+1>subGridlevel_adicional_fnc_Recordsperpage( )) ? 1 : nGXsfl_89_idx+1);
            sGXsfl_89_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_89_idx), 4, 0), 4, "0");
            SubsflControlProps_893( ) ;
         }
         /* End function sendrow_893 */
      }

      protected void init_web_controls( )
      {
         cmbavMudanza_mudanzahoraservicio.Name = "MUDANZA_MUDANZAHORASERVICIO";
         cmbavMudanza_mudanzahoraservicio.WebTags = "";
         cmbavMudanza_mudanzahoraservicio.addItem("08", "08:00", 0);
         cmbavMudanza_mudanzahoraservicio.addItem("09", "09:00", 0);
         cmbavMudanza_mudanzahoraservicio.addItem("10", "10:00", 0);
         cmbavMudanza_mudanzahoraservicio.addItem("11", "11:00", 0);
         cmbavMudanza_mudanzahoraservicio.addItem("12", "12:00", 0);
         cmbavMudanza_mudanzahoraservicio.addItem("13", "13:00", 0);
         cmbavMudanza_mudanzahoraservicio.addItem("14", "14:00", 0);
         cmbavMudanza_mudanzahoraservicio.addItem("15", "15:00", 0);
         cmbavMudanza_mudanzahoraservicio.addItem("16", "16:00", 0);
         cmbavMudanza_mudanzahoraservicio.addItem("17", "17:00", 0);
         cmbavMudanza_mudanzahoraservicio.addItem("18", "18:00", 0);
         cmbavMudanza_mudanzahoraservicio.addItem("19", "19:00", 0);
         if ( cmbavMudanza_mudanzahoraservicio.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Mudanzahoraservicio = cmbavMudanza_mudanzahoraservicio.getValidValue(AV7Mudanza.gxTpr_Mudanzahoraservicio);
         }
         dynavMudanza_tipoinmuebleorigenid.Name = "MUDANZA_TIPOINMUEBLEORIGENID";
         dynavMudanza_tipoinmuebleorigenid.WebTags = "";
         dynavMudanza_tipoestacionamorigenid.Name = "MUDANZA_TIPOESTACIONAMORIGENID";
         dynavMudanza_tipoestacionamorigenid.WebTags = "";
         dynavMudanza_tipoinmuebledestinoid.Name = "MUDANZA_TIPOINMUEBLEDESTINOID";
         dynavMudanza_tipoinmuebledestinoid.WebTags = "";
         dynavMudanza_tipoestacionamdestinoid.Name = "MUDANZA_TIPOESTACIONAMDESTINOID";
         dynavMudanza_tipoestacionamdestinoid.WebTags = "";
         cmbavMudanza_mudanzavehiculosugerido.Name = "MUDANZA_MUDANZAVEHICULOSUGERIDO";
         cmbavMudanza_mudanzavehiculosugerido.WebTags = "";
         if ( cmbavMudanza_mudanzavehiculosugerido.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Mudanzavehiculosugerido = cmbavMudanza_mudanzavehiculosugerido.getValidValue(AV7Mudanza.gxTpr_Mudanzavehiculosugerido);
         }
         cmbavMudanza_tipoestacionamorigennombre.Name = "MUDANZA_TIPOESTACIONAMORIGENNOMBRE";
         cmbavMudanza_tipoestacionamorigennombre.WebTags = "";
         if ( cmbavMudanza_tipoestacionamorigennombre.ItemCount > 0 )
         {
            AV7Mudanza.gxTpr_Tipoestacionamorigennombre = cmbavMudanza_tipoestacionamorigennombre.getValidValue(AV7Mudanza.gxTpr_Tipoestacionamorigennombre);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl75( )
      {
         if ( Gridlevel_cargaContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Gridlevel_cargaContainer"+"DivS\" data-gxgridid=\"75\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridlevel_carga_Internalname, subGridlevel_carga_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridlevel_carga_Backcolorstyle == 0 )
            {
               subGridlevel_carga_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridlevel_carga_Class) > 0 )
               {
                  subGridlevel_carga_Linesclass = subGridlevel_carga_Class+"Title";
               }
            }
            else
            {
               subGridlevel_carga_Titlebackstyle = 1;
               if ( subGridlevel_carga_Backcolorstyle == 1 )
               {
                  subGridlevel_carga_Titlebackcolor = subGridlevel_carga_Allbackcolor;
                  if ( StringUtil.Len( subGridlevel_carga_Class) > 0 )
                  {
                     subGridlevel_carga_Linesclass = subGridlevel_carga_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridlevel_carga_Class) > 0 )
                  {
                     subGridlevel_carga_Linesclass = subGridlevel_carga_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDeletegridlinegridlevel_carga_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+edtavMudanza_carga__itemcargaid_Horizontalalignment+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Item", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Carga Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Cantidad (unidad)", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Volumen estimado (m3)", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridlevel_cargaContainer.AddObjectProperty("GridName", "Gridlevel_carga");
         }
         else
         {
            Gridlevel_cargaContainer.AddObjectProperty("GridName", "Gridlevel_carga");
            Gridlevel_cargaContainer.AddObjectProperty("Header", subGridlevel_carga_Header);
            Gridlevel_cargaContainer.AddObjectProperty("Class", "WorkWith");
            Gridlevel_cargaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridlevel_cargaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridlevel_cargaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Backcolorstyle), 1, 0, ".", "")));
            Gridlevel_cargaContainer.AddObjectProperty("CmpContext", "");
            Gridlevel_cargaContainer.AddObjectProperty("InMasterPage", "false");
            Gridlevel_cargaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_cargaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV9DeleteGridLineGridLevel_Carga)));
            Gridlevel_cargaColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavDeletegridlinegridlevel_carga_Columnclass));
            Gridlevel_cargaColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavDeletegridlinegridlevel_carga_Columnheaderclass));
            Gridlevel_cargaColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDeletegridlinegridlevel_carga_Class));
            Gridlevel_cargaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeletegridlinegridlevel_carga_Enabled), 5, 0, ".", "")));
            Gridlevel_cargaContainer.AddColumnProperties(Gridlevel_cargaColumn);
            Gridlevel_cargaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_cargaColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavMudanza_carga__itemcargaid_Columnclass));
            Gridlevel_cargaColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavMudanza_carga__itemcargaid_Columnheaderclass));
            Gridlevel_cargaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMudanza_carga__itemcargaid_Enabled), 5, 0, ".", "")));
            Gridlevel_cargaColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtavMudanza_carga__itemcargaid_Horizontalalignment));
            Gridlevel_cargaContainer.AddColumnProperties(Gridlevel_cargaColumn);
            Gridlevel_cargaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_cargaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMudanza_carga__itemcarganombre_Enabled), 5, 0, ".", "")));
            Gridlevel_cargaContainer.AddColumnProperties(Gridlevel_cargaColumn);
            Gridlevel_cargaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_cargaColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavMudanza_carga__itemcargacantidad_Columnclass));
            Gridlevel_cargaColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavMudanza_carga__itemcargacantidad_Columnheaderclass));
            Gridlevel_cargaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMudanza_carga__itemcargacantidad_Enabled), 5, 0, ".", "")));
            Gridlevel_cargaContainer.AddColumnProperties(Gridlevel_cargaColumn);
            Gridlevel_cargaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_cargaColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavMudanza_carga__itemcargavolumen_Columnclass));
            Gridlevel_cargaColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavMudanza_carga__itemcargavolumen_Columnheaderclass));
            Gridlevel_cargaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMudanza_carga__itemcargavolumen_Enabled), 5, 0, ".", "")));
            Gridlevel_cargaContainer.AddColumnProperties(Gridlevel_cargaColumn);
            Gridlevel_cargaContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Selectedindex), 4, 0, ".", "")));
            Gridlevel_cargaContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Allowselection), 1, 0, ".", "")));
            Gridlevel_cargaContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Selectioncolor), 9, 0, ".", "")));
            Gridlevel_cargaContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Allowhovering), 1, 0, ".", "")));
            Gridlevel_cargaContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Hoveringcolor), 9, 0, ".", "")));
            Gridlevel_cargaContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Allowcollapsing), 1, 0, ".", "")));
            Gridlevel_cargaContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_carga_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl89( )
      {
         if ( Gridlevel_adicionalContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Gridlevel_adicionalContainer"+"DivS\" data-gxgridid=\"89\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridlevel_adicional_Internalname, subGridlevel_adicional_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridlevel_adicional_Backcolorstyle == 0 )
            {
               subGridlevel_adicional_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridlevel_adicional_Class) > 0 )
               {
                  subGridlevel_adicional_Linesclass = subGridlevel_adicional_Class+"Title";
               }
            }
            else
            {
               subGridlevel_adicional_Titlebackstyle = 1;
               if ( subGridlevel_adicional_Backcolorstyle == 1 )
               {
                  subGridlevel_adicional_Titlebackcolor = subGridlevel_adicional_Allbackcolor;
                  if ( StringUtil.Len( subGridlevel_adicional_Class) > 0 )
                  {
                     subGridlevel_adicional_Linesclass = subGridlevel_adicional_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridlevel_adicional_Class) > 0 )
                  {
                     subGridlevel_adicional_Linesclass = subGridlevel_adicional_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDeletegridlinegridlevel_adicional_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Adicional Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Adicional Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Adicional Cantidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Adicional Valor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridlevel_adicionalContainer.AddObjectProperty("GridName", "Gridlevel_adicional");
         }
         else
         {
            Gridlevel_adicionalContainer.AddObjectProperty("GridName", "Gridlevel_adicional");
            Gridlevel_adicionalContainer.AddObjectProperty("Header", subGridlevel_adicional_Header);
            Gridlevel_adicionalContainer.AddObjectProperty("Class", "WorkWith");
            Gridlevel_adicionalContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridlevel_adicionalContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridlevel_adicionalContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Backcolorstyle), 1, 0, ".", "")));
            Gridlevel_adicionalContainer.AddObjectProperty("CmpContext", "");
            Gridlevel_adicionalContainer.AddObjectProperty("InMasterPage", "false");
            Gridlevel_adicionalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_adicionalColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV8DeleteGridLineGridLevel_Adicional)));
            Gridlevel_adicionalColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavDeletegridlinegridlevel_adicional_Columnclass));
            Gridlevel_adicionalColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavDeletegridlinegridlevel_adicional_Columnheaderclass));
            Gridlevel_adicionalColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDeletegridlinegridlevel_adicional_Class));
            Gridlevel_adicionalColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeletegridlinegridlevel_adicional_Enabled), 5, 0, ".", "")));
            Gridlevel_adicionalContainer.AddColumnProperties(Gridlevel_adicionalColumn);
            Gridlevel_adicionalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_adicionalColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavMudanza_adicional__itemadicionalid_Columnclass));
            Gridlevel_adicionalColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavMudanza_adicional__itemadicionalid_Columnheaderclass));
            Gridlevel_adicionalColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMudanza_adicional__itemadicionalid_Enabled), 5, 0, ".", "")));
            Gridlevel_adicionalContainer.AddColumnProperties(Gridlevel_adicionalColumn);
            Gridlevel_adicionalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_adicionalColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavMudanza_adicional__itemadicionalnombre_Columnclass));
            Gridlevel_adicionalColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavMudanza_adicional__itemadicionalnombre_Columnheaderclass));
            Gridlevel_adicionalColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMudanza_adicional__itemadicionalnombre_Enabled), 5, 0, ".", "")));
            Gridlevel_adicionalContainer.AddColumnProperties(Gridlevel_adicionalColumn);
            Gridlevel_adicionalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_adicionalColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavMudanza_adicional__itemadicionalcantidad_Columnclass));
            Gridlevel_adicionalColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavMudanza_adicional__itemadicionalcantidad_Columnheaderclass));
            Gridlevel_adicionalColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMudanza_adicional__itemadicionalcantidad_Enabled), 5, 0, ".", "")));
            Gridlevel_adicionalContainer.AddColumnProperties(Gridlevel_adicionalColumn);
            Gridlevel_adicionalColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_adicionalColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavMudanza_adicional__itemadicionalvalor_Columnclass));
            Gridlevel_adicionalColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavMudanza_adicional__itemadicionalvalor_Columnheaderclass));
            Gridlevel_adicionalColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavMudanza_adicional__itemadicionalvalor_Enabled), 5, 0, ".", "")));
            Gridlevel_adicionalContainer.AddColumnProperties(Gridlevel_adicionalColumn);
            Gridlevel_adicionalContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Selectedindex), 4, 0, ".", "")));
            Gridlevel_adicionalContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Allowselection), 1, 0, ".", "")));
            Gridlevel_adicionalContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Selectioncolor), 9, 0, ".", "")));
            Gridlevel_adicionalContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Allowhovering), 1, 0, ".", "")));
            Gridlevel_adicionalContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Hoveringcolor), 9, 0, ".", "")));
            Gridlevel_adicionalContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Allowcollapsing), 1, 0, ".", "")));
            Gridlevel_adicionalContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_adicional_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavMudanza_mudanzafechaservicio_Internalname = "MUDANZA_MUDANZAFECHASERVICIO";
         cmbavMudanza_mudanzahoraservicio_Internalname = "MUDANZA_MUDANZAHORASERVICIO";
         dynavMudanza_tipoinmuebleorigenid_Internalname = "MUDANZA_TIPOINMUEBLEORIGENID";
         dynavMudanza_tipoestacionamorigenid_Internalname = "MUDANZA_TIPOESTACIONAMORIGENID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         dynavMudanza_tipoinmuebledestinoid_Internalname = "MUDANZA_TIPOINMUEBLEDESTINOID";
         dynavMudanza_tipoestacionamdestinoid_Internalname = "MUDANZA_TIPOESTACIONAMDESTINOID";
         tblUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         grpUnnamedgroup3_Internalname = "UNNAMEDGROUP3";
         edtavMudanza_mudanzapeajecantidad_Internalname = "MUDANZA_MUDANZAPEAJECANTIDAD";
         cmbavMudanza_mudanzavehiculosugerido_Internalname = "MUDANZA_MUDANZAVEHICULOSUGERIDO";
         edtavMudanza_mudanzatiempomaximo_Internalname = "MUDANZA_MUDANZATIEMPOMAXIMO";
         edtavMudanza_mudanzacargavolumenestimado_Internalname = "MUDANZA_MUDANZACARGAVOLUMENESTIMADO";
         edtavMudanza_mudanzapreciofinal_Internalname = "MUDANZA_MUDANZAPRECIOFINAL";
         divTablecontent_Internalname = "TABLECONTENT";
         edtavDeletegridlinegridlevel_carga_Internalname = "vDELETEGRIDLINEGRIDLEVEL_CARGA";
         edtavMudanza_carga__itemcargaid_Internalname = "MUDANZA_CARGA__ITEMCARGAID";
         edtavMudanza_carga__itemcarganombre_Internalname = "MUDANZA_CARGA__ITEMCARGANOMBRE";
         edtavMudanza_carga__itemcargacantidad_Internalname = "MUDANZA_CARGA__ITEMCARGACANTIDAD";
         edtavMudanza_carga__itemcargavolumen_Internalname = "MUDANZA_CARGA__ITEMCARGAVOLUMEN";
         bttBtnaddgridlinegridlevel_carga_Internalname = "BTNADDGRIDLINEGRIDLEVEL_CARGA";
         divTableleaflevel_carga_Internalname = "TABLELEAFLEVEL_CARGA";
         edtavDeletegridlinegridlevel_adicional_Internalname = "vDELETEGRIDLINEGRIDLEVEL_ADICIONAL";
         edtavMudanza_adicional__itemadicionalid_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALID";
         edtavMudanza_adicional__itemadicionalnombre_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE";
         edtavMudanza_adicional__itemadicionalcantidad_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD";
         edtavMudanza_adicional__itemadicionalvalor_Internalname = "MUDANZA_ADICIONAL__ITEMADICIONALVALOR";
         bttBtnaddgridlinegridlevel_adicional_Internalname = "BTNADDGRIDLINEGRIDLEVEL_ADICIONAL";
         divTableleaflevel_adicional_Internalname = "TABLELEAFLEVEL_ADICIONAL";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         Combo_mudanza_carga__itemcargaid_Internalname = "COMBO_MUDANZA_CARGA__ITEMCARGAID";
         edtavMudanza_mudanzaid_Internalname = "MUDANZA_MUDANZAID";
         edtavMudanza_mudanzaasesor_Internalname = "MUDANZA_MUDANZAASESOR";
         edtavMudanza_mudanzafechaalta_Internalname = "MUDANZA_MUDANZAFECHAALTA";
         edtavMudanza_mudanzapeajevalor_Internalname = "MUDANZA_MUDANZAPEAJEVALOR";
         edtavMudanza_mudanzadirecciondestino_Internalname = "MUDANZA_MUDANZADIRECCIONDESTINO";
         edtavMudanza_tipoinmuebledestinonombre_Internalname = "MUDANZA_TIPOINMUEBLEDESTINONOMBRE";
         edtavMudanza_tipoinmuebledestinovalor_Internalname = "MUDANZA_TIPOINMUEBLEDESTINOVALOR";
         edtavMudanza_tipoestacionamdestinonombre_Internalname = "MUDANZA_TIPOESTACIONAMDESTINONOMBRE";
         edtavMudanza_tipoestacionamdestinovalor_Internalname = "MUDANZA_TIPOESTACIONAMDESTINOVALOR";
         edtavMudanza_mudanzadireccionorigen_Internalname = "MUDANZA_MUDANZADIRECCIONORIGEN";
         edtavMudanza_mudanzadistancia_Internalname = "MUDANZA_MUDANZADISTANCIA";
         edtavMudanza_tipoinmuebleorigennombre_Internalname = "MUDANZA_TIPOINMUEBLEORIGENNOMBRE";
         edtavMudanza_tipoinmuebleorigenvalor_Internalname = "MUDANZA_TIPOINMUEBLEORIGENVALOR";
         cmbavMudanza_tipoestacionamorigennombre_Internalname = "MUDANZA_TIPOESTACIONAMORIGENNOMBRE";
         edtavMudanza_tipoestacionamorigenvalor_Internalname = "MUDANZA_TIPOESTACIONAMORIGENVALOR";
         Gridlevel_adicional_empowerer_Internalname = "GRIDLEVEL_ADICIONAL_EMPOWERER";
         Gridlevel_carga_empowerer_Internalname = "GRIDLEVEL_CARGA_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_carga_Internalname = "GRIDLEVEL_CARGA";
         subGridlevel_adicional_Internalname = "GRIDLEVEL_ADICIONAL";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_adicional_Allowcollapsing = 0;
         subGridlevel_adicional_Allowselection = 0;
         subGridlevel_adicional_Header = "";
         subGridlevel_carga_Allowcollapsing = 0;
         subGridlevel_carga_Allowselection = 0;
         subGridlevel_carga_Header = "";
         edtavMudanza_adicional__itemadicionalvalor_Jsonclick = "";
         edtavMudanza_adicional__itemadicionalvalor_Columnheaderclass = "";
         edtavMudanza_adicional__itemadicionalvalor_Columnclass = "WWColumn";
         edtavMudanza_adicional__itemadicionalvalor_Enabled = 0;
         edtavMudanza_adicional__itemadicionalcantidad_Jsonclick = "";
         edtavMudanza_adicional__itemadicionalcantidad_Columnheaderclass = "";
         edtavMudanza_adicional__itemadicionalcantidad_Columnclass = "WWColumn";
         edtavMudanza_adicional__itemadicionalcantidad_Enabled = 1;
         edtavMudanza_adicional__itemadicionalnombre_Jsonclick = "";
         edtavMudanza_adicional__itemadicionalnombre_Columnheaderclass = "";
         edtavMudanza_adicional__itemadicionalnombre_Columnclass = "WWColumn";
         edtavMudanza_adicional__itemadicionalnombre_Enabled = 0;
         edtavMudanza_adicional__itemadicionalid_Jsonclick = "";
         edtavMudanza_adicional__itemadicionalid_Columnheaderclass = "";
         edtavMudanza_adicional__itemadicionalid_Columnclass = "WWColumn";
         edtavMudanza_adicional__itemadicionalid_Enabled = 1;
         edtavDeletegridlinegridlevel_adicional_Jsonclick = "";
         edtavDeletegridlinegridlevel_adicional_Columnclass = "WWIconActionColumn";
         edtavDeletegridlinegridlevel_adicional_Class = "Attribute";
         edtavDeletegridlinegridlevel_adicional_Enabled = 1;
         subGridlevel_adicional_Class = "WorkWith";
         subGridlevel_adicional_Backcolorstyle = 0;
         edtavMudanza_carga__itemcargavolumen_Jsonclick = "";
         edtavMudanza_carga__itemcargavolumen_Columnheaderclass = "";
         edtavMudanza_carga__itemcargavolumen_Columnclass = "WWColumn ColumnAlignCenter";
         edtavMudanza_carga__itemcargavolumen_Enabled = 0;
         edtavMudanza_carga__itemcargacantidad_Jsonclick = "";
         edtavMudanza_carga__itemcargacantidad_Columnheaderclass = "";
         edtavMudanza_carga__itemcargacantidad_Columnclass = "WWColumn ColumnAlignCenter";
         edtavMudanza_carga__itemcargacantidad_Enabled = 1;
         edtavMudanza_carga__itemcarganombre_Jsonclick = "";
         edtavMudanza_carga__itemcarganombre_Enabled = 0;
         edtavMudanza_carga__itemcargaid_Jsonclick = "";
         edtavMudanza_carga__itemcargaid_Columnheaderclass = "";
         edtavMudanza_carga__itemcargaid_Columnclass = "WWColumn";
         edtavMudanza_carga__itemcargaid_Enabled = 1;
         edtavMudanza_carga__itemcargaid_Horizontalalignment = "end";
         edtavDeletegridlinegridlevel_carga_Jsonclick = "";
         edtavDeletegridlinegridlevel_carga_Columnclass = "WWIconActionColumn";
         edtavDeletegridlinegridlevel_carga_Class = "Attribute";
         edtavDeletegridlinegridlevel_carga_Enabled = 1;
         subGridlevel_carga_Class = "WorkWith";
         subGridlevel_carga_Backcolorstyle = 0;
         dynavMudanza_tipoestacionamdestinoid_Jsonclick = "";
         dynavMudanza_tipoestacionamdestinoid.Enabled = 1;
         dynavMudanza_tipoinmuebledestinoid_Jsonclick = "";
         dynavMudanza_tipoinmuebledestinoid.Enabled = 1;
         edtavDeletegridlinegridlevel_carga_Columnheaderclass = "";
         edtavDeletegridlinegridlevel_adicional_Columnheaderclass = "";
         edtavMudanza_carga__itemcargaid_Horizontalalignment = "end";
         dynavMudanza_tipoestacionamorigenid.Enabled = 1;
         dynavMudanza_tipoinmuebleorigenid.Enabled = 1;
         dynavMudanza_tipoestacionamdestinoid.Enabled = 1;
         dynavMudanza_tipoinmuebledestinoid.Enabled = 1;
         edtavMudanza_mudanzacargavolumenestimado_Enabled = 1;
         edtavMudanza_mudanzapeajecantidad_Enabled = 1;
         cmbavMudanza_mudanzahoraservicio.Enabled = 1;
         edtavMudanza_mudanzafechaservicio_Enabled = 1;
         edtavMudanza_adicional__itemadicionalvalor_Enabled = -1;
         edtavMudanza_adicional__itemadicionalnombre_Enabled = -1;
         edtavMudanza_carga__itemcargavolumen_Enabled = -1;
         edtavMudanza_carga__itemcarganombre_Enabled = -1;
         edtavMudanza_mudanzapreciofinal_Enabled = -1;
         edtavMudanza_mudanzatiempomaximo_Enabled = -1;
         cmbavMudanza_mudanzavehiculosugerido.Enabled = -1;
         edtavMudanza_tipoestacionamorigenvalor_Jsonclick = "";
         edtavMudanza_tipoestacionamorigenvalor_Visible = 1;
         cmbavMudanza_tipoestacionamorigennombre_Jsonclick = "";
         cmbavMudanza_tipoestacionamorigennombre.Visible = 1;
         edtavMudanza_tipoinmuebleorigenvalor_Jsonclick = "";
         edtavMudanza_tipoinmuebleorigenvalor_Visible = 1;
         edtavMudanza_tipoinmuebleorigennombre_Jsonclick = "";
         edtavMudanza_tipoinmuebleorigennombre_Visible = 1;
         edtavMudanza_mudanzadistancia_Jsonclick = "";
         edtavMudanza_mudanzadistancia_Visible = 1;
         edtavMudanza_mudanzadireccionorigen_Visible = 1;
         edtavMudanza_tipoestacionamdestinovalor_Jsonclick = "";
         edtavMudanza_tipoestacionamdestinovalor_Visible = 1;
         edtavMudanza_tipoestacionamdestinonombre_Jsonclick = "";
         edtavMudanza_tipoestacionamdestinonombre_Visible = 1;
         edtavMudanza_tipoinmuebledestinovalor_Jsonclick = "";
         edtavMudanza_tipoinmuebledestinovalor_Visible = 1;
         edtavMudanza_tipoinmuebledestinonombre_Jsonclick = "";
         edtavMudanza_tipoinmuebledestinonombre_Visible = 1;
         edtavMudanza_mudanzadirecciondestino_Visible = 1;
         edtavMudanza_mudanzapeajevalor_Jsonclick = "";
         edtavMudanza_mudanzapeajevalor_Visible = 1;
         edtavMudanza_mudanzafechaalta_Jsonclick = "";
         edtavMudanza_mudanzafechaalta_Visible = 1;
         edtavMudanza_mudanzaasesor_Jsonclick = "";
         edtavMudanza_mudanzaasesor_Visible = 1;
         edtavMudanza_mudanzaid_Jsonclick = "";
         edtavMudanza_mudanzaid_Visible = 1;
         bttBtnenter_Visible = 1;
         bttBtnaddgridlinegridlevel_adicional_Visible = 1;
         bttBtnaddgridlinegridlevel_carga_Visible = 1;
         edtavMudanza_mudanzapreciofinal_Jsonclick = "";
         edtavMudanza_mudanzapreciofinal_Enabled = 0;
         edtavMudanza_mudanzacargavolumenestimado_Jsonclick = "";
         edtavMudanza_mudanzacargavolumenestimado_Enabled = 1;
         edtavMudanza_mudanzatiempomaximo_Jsonclick = "";
         edtavMudanza_mudanzatiempomaximo_Enabled = 0;
         cmbavMudanza_mudanzavehiculosugerido_Jsonclick = "";
         cmbavMudanza_mudanzavehiculosugerido.Enabled = 0;
         edtavMudanza_mudanzapeajecantidad_Jsonclick = "";
         edtavMudanza_mudanzapeajecantidad_Enabled = 1;
         dynavMudanza_tipoestacionamorigenid_Jsonclick = "";
         dynavMudanza_tipoestacionamorigenid.Enabled = 1;
         dynavMudanza_tipoinmuebleorigenid_Jsonclick = "";
         dynavMudanza_tipoinmuebleorigenid.Enabled = 1;
         cmbavMudanza_mudanzahoraservicio_Jsonclick = "";
         cmbavMudanza_mudanzahoraservicio.Enabled = 1;
         edtavMudanza_mudanzafechaservicio_Jsonclick = "";
         edtavMudanza_mudanzafechaservicio_Enabled = 1;
         Combo_mudanza_carga__itemcargaid_Emptyitem = Convert.ToBoolean( 0);
         Combo_mudanza_carga__itemcargaid_Isgriditem = Convert.ToBoolean( -1);
         Combo_mudanza_carga__itemcargaid_Titlecontrolidtoreplace = "";
         Combo_mudanza_carga__itemcargaid_Cls = "ExtendedCombo";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Solicitud Mudanza", "");
         subGridlevel_adicional_Rows = 0;
         subGridlevel_carga_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_CARGA_nEOF',type:'int'},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_ADICIONAL_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavDeletegridlinegridlevel_adicional_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnheaderclass'},{av:'edtavDeletegridlinegridlevel_carga_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnheaderclass'},{ctrl:'BTNENTER',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_CARGA',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_ADICIONAL.LOAD","{handler:'E18EH3',iparms:[{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'},{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("GRIDLEVEL_ADICIONAL.LOAD",",oparms:[{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Enabled'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Enabled'},{av:'AV8DeleteGridLineGridLevel_Adicional',fld:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',pic:'',type:'char'},{av:'edtavDeletegridlinegridlevel_adicional_Class',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Class'},{av:'edtavDeletegridlinegridlevel_adicional_Columnclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnclass'}]}");
         setEventMetadata("GRIDLEVEL_CARGA.LOAD","{handler:'E16EH2',iparms:[{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("GRIDLEVEL_CARGA.LOAD",",oparms:[{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Enabled'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Enabled'},{av:'AV9DeleteGridLineGridLevel_Carga',fld:'vDELETEGRIDLINEGRIDLEVEL_CARGA',pic:'',type:'char'},{av:'edtavDeletegridlinegridlevel_carga_Class',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Class'},{av:'edtavDeletegridlinegridlevel_carga_Columnclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnclass'}]}");
         setEventMetadata("'DOADDGRIDLINEGRIDLEVEL_ADICIONAL'","{handler:'E11EH2',iparms:[{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'},{av:'GRIDLEVEL_CARGA_nEOF',type:'int'},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'GRIDLEVEL_ADICIONAL_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOADDGRIDLINEGRIDLEVEL_ADICIONAL'",",oparms:[{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'}]}");
         setEventMetadata("'DOADDGRIDLINEGRIDLEVEL_CARGA'","{handler:'E12EH2',iparms:[{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'},{av:'GRIDLEVEL_CARGA_nEOF',type:'int'},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'GRIDLEVEL_ADICIONAL_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOADDGRIDLINEGRIDLEVEL_CARGA'",",oparms:[{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'}]}");
         setEventMetadata("ENTER","{handler:'E13EH2',iparms:[{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV14CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:'',type:'boolean'},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'},{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'AV11Messages',fld:'vMESSAGES',pic:''},{av:'GRIDLEVEL_CARGA_nEOF',type:'int'},{av:'GRIDLEVEL_ADICIONAL_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'},{av:'AV11Messages',fld:'vMESSAGES',pic:''},{av:'AV14CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:'',type:'boolean'}]}");
         setEventMetadata("VDELETEGRIDLINEGRIDLEVEL_ADICIONAL.CLICK","{handler:'E19EH2',iparms:[{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_ADICIONAL_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'},{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDLEVEL_CARGA_nEOF',type:'int'},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''}]");
         setEventMetadata("VDELETEGRIDLINEGRIDLEVEL_ADICIONAL.CLICK",",oparms:[{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'edtavDeletegridlinegridlevel_adicional_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnheaderclass'},{av:'edtavDeletegridlinegridlevel_carga_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnheaderclass'},{ctrl:'BTNENTER',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_CARGA',prop:'Visible'}]}");
         setEventMetadata("VDELETEGRIDLINEGRIDLEVEL_CARGA.CLICK","{handler:'E17EH2',iparms:[{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_CARGA_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nEOF',type:'int'},{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''}]");
         setEventMetadata("VDELETEGRIDLINEGRIDLEVEL_CARGA.CLICK",",oparms:[{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'edtavDeletegridlinegridlevel_adicional_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnheaderclass'},{av:'edtavDeletegridlinegridlevel_carga_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnheaderclass'},{ctrl:'BTNENTER',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_CARGA',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_CARGA_FIRSTPAGE","{handler:'subgridlevel_carga_firstpage',iparms:[{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_CARGA_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'}]");
         setEventMetadata("GRIDLEVEL_CARGA_FIRSTPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_adicional_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnheaderclass'},{av:'edtavDeletegridlinegridlevel_carga_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnheaderclass'},{ctrl:'BTNENTER',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_CARGA',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_CARGA_PREVPAGE","{handler:'subgridlevel_carga_previouspage',iparms:[{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_CARGA_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'}]");
         setEventMetadata("GRIDLEVEL_CARGA_PREVPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_adicional_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnheaderclass'},{av:'edtavDeletegridlinegridlevel_carga_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnheaderclass'},{ctrl:'BTNENTER',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_CARGA',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_CARGA_NEXTPAGE","{handler:'subgridlevel_carga_nextpage',iparms:[{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_CARGA_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'}]");
         setEventMetadata("GRIDLEVEL_CARGA_NEXTPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_adicional_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnheaderclass'},{av:'edtavDeletegridlinegridlevel_carga_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnheaderclass'},{ctrl:'BTNENTER',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_CARGA',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_CARGA_LASTPAGE","{handler:'subgridlevel_carga_lastpage',iparms:[{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_CARGA_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV21MudanzaCargaDeleted',fld:'vMUDANZACARGADELETED',pic:''},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'}]");
         setEventMetadata("GRIDLEVEL_CARGA_LASTPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_adicional_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnheaderclass'},{av:'edtavDeletegridlinegridlevel_carga_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnheaderclass'},{ctrl:'BTNENTER',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_CARGA',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_ADICIONAL_FIRSTPAGE","{handler:'subgridlevel_adicional_firstpage',iparms:[{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_ADICIONAL_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'}]");
         setEventMetadata("GRIDLEVEL_ADICIONAL_FIRSTPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_adicional_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnheaderclass'},{av:'edtavDeletegridlinegridlevel_carga_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnheaderclass'},{ctrl:'BTNENTER',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_CARGA',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_ADICIONAL_PREVPAGE","{handler:'subgridlevel_adicional_previouspage',iparms:[{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_ADICIONAL_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'}]");
         setEventMetadata("GRIDLEVEL_ADICIONAL_PREVPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_adicional_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnheaderclass'},{av:'edtavDeletegridlinegridlevel_carga_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnheaderclass'},{ctrl:'BTNENTER',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_CARGA',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_ADICIONAL_NEXTPAGE","{handler:'subgridlevel_adicional_nextpage',iparms:[{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_ADICIONAL_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'}]");
         setEventMetadata("GRIDLEVEL_ADICIONAL_NEXTPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_adicional_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnheaderclass'},{av:'edtavDeletegridlinegridlevel_carga_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnheaderclass'},{ctrl:'BTNENTER',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_CARGA',prop:'Visible'}]}");
         setEventMetadata("GRIDLEVEL_ADICIONAL_LASTPAGE","{handler:'subgridlevel_adicional_lastpage',iparms:[{av:'GRIDLEVEL_ADICIONAL_nFirstRecordOnPage',type:'int'},{av:'GRIDLEVEL_ADICIONAL_nEOF',type:'int'},{av:'subGridlevel_carga_Rows',ctrl:'GRIDLEVEL_CARGA',prop:'Rows'},{av:'subGridlevel_adicional_Rows',ctrl:'GRIDLEVEL_ADICIONAL',prop:'Rows'},{av:'AV19MudanzaAdicionalDeleted',fld:'vMUDANZAADICIONALDELETED',pic:''},{av:'AV16MudanzaId',fld:'vMUDANZAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV12TrnMode',fld:'vTRNMODE',pic:'',hsh:true,type:'char'},{av:'AV7Mudanza',fld:'vMUDANZA',pic:''},{av:'GRIDLEVEL_CARGA_nFirstRecordOnPage',type:'int'},{av:'nRC_GXsfl_75',ctrl:'GRIDLEVEL_CARGA',prop:'GridRC',grid:75,type:'int'},{av:'nRC_GXsfl_89',ctrl:'GRIDLEVEL_ADICIONAL',prop:'GridRC',grid:89,type:'int'}]");
         setEventMetadata("GRIDLEVEL_ADICIONAL_LASTPAGE",",oparms:[{av:'edtavDeletegridlinegridlevel_adicional_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALNOMBRE',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALCANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_ADICIONAL__ITEMADICIONALVALOR',prop:'Columnheaderclass'},{av:'edtavDeletegridlinegridlevel_carga_Columnheaderclass',ctrl:'vDELETEGRIDLINEGRIDLEVEL_CARGA',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAID',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGACANTIDAD',prop:'Columnheaderclass'},{ctrl:'MUDANZA_CARGA__ITEMCARGAVOLUMEN',prop:'Columnheaderclass'},{ctrl:'BTNENTER',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_ADICIONAL',prop:'Visible'},{ctrl:'BTNADDGRIDLINEGRIDLEVEL_CARGA',prop:'Visible'}]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv16',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv21',iparms:[]");
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
         wcpOAV12TrnMode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7Mudanza = new SdtMudanza(context);
         AV21MudanzaCargaDeleted = new GxSimpleCollection<short>();
         AV19MudanzaAdicionalDeleted = new GxSimpleCollection<short>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV22Mudanza_Carga__ItemCargaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Gridlevel_adicional_empowerer_Gridinternalname = "";
         Gridlevel_carga_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         Gridlevel_cargaContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtnaddgridlinegridlevel_carga_Jsonclick = "";
         Gridlevel_adicionalContainer = new GXWebGrid( context);
         bttBtnaddgridlinegridlevel_adicional_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucCombo_mudanza_carga__itemcargaid = new GXUserControl();
         Combo_mudanza_carga__itemcargaid_Caption = "";
         ucGridlevel_adicional_empowerer = new GXUserControl();
         ucGridlevel_carga_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9DeleteGridLineGridLevel_Carga = "";
         AV8DeleteGridLineGridLevel_Adicional = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00EH2_A735MudanzaId = new long[1] ;
         H00EH2_A743TipoInmuebleOrigenId = new short[1] ;
         H00EH2_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         H00EH3_A735MudanzaId = new long[1] ;
         H00EH3_A749TipoEstacionamDestinoId = new short[1] ;
         H00EH3_A750TipoEstacionamDestinoNombre = new string[] {""} ;
         H00EH4_A735MudanzaId = new long[1] ;
         H00EH4_A745TipoInmuebleDestinoId = new short[1] ;
         H00EH4_A746TipoInmuebleDestinoNombre = new string[] {""} ;
         H00EH5_A735MudanzaId = new long[1] ;
         H00EH5_A749TipoEstacionamDestinoId = new short[1] ;
         H00EH5_A750TipoEstacionamDestinoNombre = new string[] {""} ;
         AV60Pgmname = "";
         Gridlevel_cargaRow = new GXWebRow();
         AV17MudanzaAdicionalItem = new SdtMudanza_Adicional(context);
         AV20MudanzaCargaItem = new SdtMudanza_Carga(context);
         H00EH6_A735MudanzaId = new long[1] ;
         H00EH6_A751ItemCargaId = new short[1] ;
         AV23Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         Gridlevel_adicionalRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridlevel_carga_Linesclass = "";
         ROClassString = "";
         subGridlevel_adicional_Linesclass = "";
         GXCCtl = "";
         Gridlevel_cargaColumn = new GXWebColumn();
         Gridlevel_adicionalColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.solicitudmudanza__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudmudanza__default(),
            new Object[][] {
                new Object[] {
               H00EH2_A735MudanzaId, H00EH2_A743TipoInmuebleOrigenId, H00EH2_A755TipoInmuebleOrigenNombre
               }
               , new Object[] {
               H00EH3_A735MudanzaId, H00EH3_A749TipoEstacionamDestinoId, H00EH3_A750TipoEstacionamDestinoNombre
               }
               , new Object[] {
               H00EH4_A735MudanzaId, H00EH4_A745TipoInmuebleDestinoId, H00EH4_A746TipoInmuebleDestinoNombre
               }
               , new Object[] {
               H00EH5_A735MudanzaId, H00EH5_A749TipoEstacionamDestinoId, H00EH5_A750TipoEstacionamDestinoNombre
               }
               , new Object[] {
               H00EH6_A735MudanzaId, H00EH6_A751ItemCargaId
               }
            }
         );
         AV60Pgmname = "SolicitudMudanza";
         /* GeneXus formulas. */
         AV60Pgmname = "SolicitudMudanza";
         cmbavMudanza_mudanzavehiculosugerido.Enabled = 0;
         edtavMudanza_mudanzatiempomaximo_Enabled = 0;
         edtavMudanza_mudanzapreciofinal_Enabled = 0;
         edtavDeletegridlinegridlevel_carga_Enabled = 0;
         edtavMudanza_carga__itemcarganombre_Enabled = 0;
         edtavMudanza_carga__itemcargavolumen_Enabled = 0;
         edtavDeletegridlinegridlevel_adicional_Enabled = 0;
         edtavMudanza_adicional__itemadicionalnombre_Enabled = 0;
         edtavMudanza_adicional__itemadicionalvalor_Enabled = 0;
      }

      private short GRIDLEVEL_CARGA_nEOF ;
      private short GRIDLEVEL_ADICIONAL_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short subGridlevel_carga_Backcolorstyle ;
      private short subGridlevel_adicional_Backcolorstyle ;
      private short AV18Index ;
      private short A751ItemCargaId ;
      private short nGXWrapped ;
      private short subGridlevel_carga_Backstyle ;
      private short subGridlevel_adicional_Backstyle ;
      private short subGridlevel_carga_Titlebackstyle ;
      private short subGridlevel_carga_Allowselection ;
      private short subGridlevel_carga_Allowhovering ;
      private short subGridlevel_carga_Allowcollapsing ;
      private short subGridlevel_carga_Collapsed ;
      private short subGridlevel_adicional_Titlebackstyle ;
      private short subGridlevel_adicional_Allowselection ;
      private short subGridlevel_adicional_Allowhovering ;
      private short subGridlevel_adicional_Allowcollapsing ;
      private short subGridlevel_adicional_Collapsed ;
      private int nRC_GXsfl_75 ;
      private int nRC_GXsfl_89 ;
      private int subGridlevel_carga_Rows ;
      private int subGridlevel_adicional_Rows ;
      private int nGXsfl_75_idx=1 ;
      private int nGXsfl_89_idx=1 ;
      private int edtavMudanza_mudanzafechaservicio_Enabled ;
      private int edtavMudanza_mudanzapeajecantidad_Enabled ;
      private int edtavMudanza_mudanzatiempomaximo_Enabled ;
      private int edtavMudanza_mudanzacargavolumenestimado_Enabled ;
      private int edtavMudanza_mudanzapreciofinal_Enabled ;
      private int AV35GXV12 ;
      private int bttBtnaddgridlinegridlevel_carga_Visible ;
      private int AV40GXV17 ;
      private int bttBtnaddgridlinegridlevel_adicional_Visible ;
      private int bttBtnenter_Visible ;
      private int edtavMudanza_mudanzaid_Visible ;
      private int edtavMudanza_mudanzaasesor_Visible ;
      private int edtavMudanza_mudanzafechaalta_Visible ;
      private int edtavMudanza_mudanzapeajevalor_Visible ;
      private int edtavMudanza_mudanzadirecciondestino_Visible ;
      private int edtavMudanza_tipoinmuebledestinonombre_Visible ;
      private int edtavMudanza_tipoinmuebledestinovalor_Visible ;
      private int edtavMudanza_tipoestacionamdestinonombre_Visible ;
      private int edtavMudanza_tipoestacionamdestinovalor_Visible ;
      private int edtavMudanza_mudanzadireccionorigen_Visible ;
      private int edtavMudanza_mudanzadistancia_Visible ;
      private int edtavMudanza_tipoinmuebleorigennombre_Visible ;
      private int edtavMudanza_tipoinmuebleorigenvalor_Visible ;
      private int edtavMudanza_tipoestacionamorigenvalor_Visible ;
      private int gxdynajaxindex ;
      private int subGridlevel_carga_Islastpage ;
      private int subGridlevel_adicional_Islastpage ;
      private int edtavDeletegridlinegridlevel_carga_Enabled ;
      private int edtavMudanza_carga__itemcarganombre_Enabled ;
      private int edtavMudanza_carga__itemcargavolumen_Enabled ;
      private int edtavDeletegridlinegridlevel_adicional_Enabled ;
      private int edtavMudanza_adicional__itemadicionalnombre_Enabled ;
      private int edtavMudanza_adicional__itemadicionalvalor_Enabled ;
      private int GRIDLEVEL_CARGA_nGridOutOfScope ;
      private int GRIDLEVEL_ADICIONAL_nGridOutOfScope ;
      private int nGXsfl_75_fel_idx=1 ;
      private int nGXsfl_89_fel_idx=1 ;
      private int edtavMudanza_carga__itemcargaid_Enabled ;
      private int edtavMudanza_carga__itemcargacantidad_Enabled ;
      private int nGXsfl_75_bak_idx=1 ;
      private int nGXsfl_89_bak_idx=1 ;
      private int AV62GXV37 ;
      private int edtavMudanza_adicional__itemadicionalid_Enabled ;
      private int edtavMudanza_adicional__itemadicionalcantidad_Enabled ;
      private int idxLst ;
      private int subGridlevel_carga_Backcolor ;
      private int subGridlevel_carga_Allbackcolor ;
      private int subGridlevel_adicional_Backcolor ;
      private int subGridlevel_adicional_Allbackcolor ;
      private int subGridlevel_carga_Titlebackcolor ;
      private int subGridlevel_carga_Selectedindex ;
      private int subGridlevel_carga_Selectioncolor ;
      private int subGridlevel_carga_Hoveringcolor ;
      private int subGridlevel_adicional_Titlebackcolor ;
      private int subGridlevel_adicional_Selectedindex ;
      private int subGridlevel_adicional_Selectioncolor ;
      private int subGridlevel_adicional_Hoveringcolor ;
      private long AV16MudanzaId ;
      private long wcpOAV16MudanzaId ;
      private long GRIDLEVEL_CARGA_nFirstRecordOnPage ;
      private long GRIDLEVEL_ADICIONAL_nFirstRecordOnPage ;
      private long GRIDLEVEL_CARGA_nCurrentRecord ;
      private long GRIDLEVEL_ADICIONAL_nCurrentRecord ;
      private long GRIDLEVEL_CARGA_nRecordCount ;
      private long GRIDLEVEL_ADICIONAL_nRecordCount ;
      private string AV12TrnMode ;
      private string wcpOAV12TrnMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_75_idx="0001" ;
      private string sGXsfl_89_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Combo_mudanza_carga__itemcargaid_Cls ;
      private string Combo_mudanza_carga__itemcargaid_Titlecontrolidtoreplace ;
      private string Gridlevel_adicional_empowerer_Gridinternalname ;
      private string Gridlevel_carga_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string edtavMudanza_mudanzafechaservicio_Internalname ;
      private string TempTags ;
      private string edtavMudanza_mudanzafechaservicio_Jsonclick ;
      private string cmbavMudanza_mudanzahoraservicio_Internalname ;
      private string cmbavMudanza_mudanzahoraservicio_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableattributes_Internalname ;
      private string dynavMudanza_tipoinmuebleorigenid_Internalname ;
      private string dynavMudanza_tipoinmuebleorigenid_Jsonclick ;
      private string dynavMudanza_tipoestacionamorigenid_Internalname ;
      private string dynavMudanza_tipoestacionamorigenid_Jsonclick ;
      private string grpUnnamedgroup3_Internalname ;
      private string edtavMudanza_mudanzapeajecantidad_Internalname ;
      private string edtavMudanza_mudanzapeajecantidad_Jsonclick ;
      private string cmbavMudanza_mudanzavehiculosugerido_Internalname ;
      private string cmbavMudanza_mudanzavehiculosugerido_Jsonclick ;
      private string edtavMudanza_mudanzatiempomaximo_Internalname ;
      private string edtavMudanza_mudanzatiempomaximo_Jsonclick ;
      private string edtavMudanza_mudanzacargavolumenestimado_Internalname ;
      private string edtavMudanza_mudanzacargavolumenestimado_Jsonclick ;
      private string edtavMudanza_mudanzapreciofinal_Internalname ;
      private string edtavMudanza_mudanzapreciofinal_Jsonclick ;
      private string divTableleaflevel_carga_Internalname ;
      private string sStyleString ;
      private string subGridlevel_carga_Internalname ;
      private string bttBtnaddgridlinegridlevel_carga_Internalname ;
      private string bttBtnaddgridlinegridlevel_carga_Jsonclick ;
      private string divTableleaflevel_adicional_Internalname ;
      private string subGridlevel_adicional_Internalname ;
      private string bttBtnaddgridlinegridlevel_adicional_Internalname ;
      private string bttBtnaddgridlinegridlevel_adicional_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Combo_mudanza_carga__itemcargaid_Caption ;
      private string Combo_mudanza_carga__itemcargaid_Internalname ;
      private string edtavMudanza_mudanzaid_Internalname ;
      private string edtavMudanza_mudanzaid_Jsonclick ;
      private string edtavMudanza_mudanzaasesor_Internalname ;
      private string edtavMudanza_mudanzaasesor_Jsonclick ;
      private string edtavMudanza_mudanzafechaalta_Internalname ;
      private string edtavMudanza_mudanzafechaalta_Jsonclick ;
      private string edtavMudanza_mudanzapeajevalor_Internalname ;
      private string edtavMudanza_mudanzapeajevalor_Jsonclick ;
      private string edtavMudanza_mudanzadirecciondestino_Internalname ;
      private string edtavMudanza_tipoinmuebledestinonombre_Internalname ;
      private string edtavMudanza_tipoinmuebledestinonombre_Jsonclick ;
      private string edtavMudanza_tipoinmuebledestinovalor_Internalname ;
      private string edtavMudanza_tipoinmuebledestinovalor_Jsonclick ;
      private string edtavMudanza_tipoestacionamdestinonombre_Internalname ;
      private string edtavMudanza_tipoestacionamdestinonombre_Jsonclick ;
      private string edtavMudanza_tipoestacionamdestinovalor_Internalname ;
      private string edtavMudanza_tipoestacionamdestinovalor_Jsonclick ;
      private string edtavMudanza_mudanzadireccionorigen_Internalname ;
      private string edtavMudanza_mudanzadistancia_Internalname ;
      private string edtavMudanza_mudanzadistancia_Jsonclick ;
      private string edtavMudanza_tipoinmuebleorigennombre_Internalname ;
      private string edtavMudanza_tipoinmuebleorigennombre_Jsonclick ;
      private string edtavMudanza_tipoinmuebleorigenvalor_Internalname ;
      private string edtavMudanza_tipoinmuebleorigenvalor_Jsonclick ;
      private string cmbavMudanza_tipoestacionamorigennombre_Internalname ;
      private string cmbavMudanza_tipoestacionamorigennombre_Jsonclick ;
      private string edtavMudanza_tipoestacionamorigenvalor_Internalname ;
      private string edtavMudanza_tipoestacionamorigenvalor_Jsonclick ;
      private string Gridlevel_adicional_empowerer_Internalname ;
      private string Gridlevel_carga_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV9DeleteGridLineGridLevel_Carga ;
      private string edtavDeletegridlinegridlevel_carga_Internalname ;
      private string AV8DeleteGridLineGridLevel_Adicional ;
      private string edtavDeletegridlinegridlevel_adicional_Internalname ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string dynavMudanza_tipoinmuebledestinoid_Internalname ;
      private string dynavMudanza_tipoestacionamdestinoid_Internalname ;
      private string AV60Pgmname ;
      private string sGXsfl_75_fel_idx="0001" ;
      private string sGXsfl_89_fel_idx="0001" ;
      private string edtavMudanza_carga__itemcargaid_Internalname ;
      private string edtavMudanza_carga__itemcargaid_Horizontalalignment ;
      private string edtavDeletegridlinegridlevel_adicional_Columnheaderclass ;
      private string edtavMudanza_adicional__itemadicionalid_Columnheaderclass ;
      private string edtavMudanza_adicional__itemadicionalid_Internalname ;
      private string edtavMudanza_adicional__itemadicionalnombre_Columnheaderclass ;
      private string edtavMudanza_adicional__itemadicionalnombre_Internalname ;
      private string edtavMudanza_adicional__itemadicionalcantidad_Columnheaderclass ;
      private string edtavMudanza_adicional__itemadicionalcantidad_Internalname ;
      private string edtavMudanza_adicional__itemadicionalvalor_Columnheaderclass ;
      private string edtavMudanza_adicional__itemadicionalvalor_Internalname ;
      private string edtavDeletegridlinegridlevel_carga_Columnheaderclass ;
      private string edtavMudanza_carga__itemcargaid_Columnheaderclass ;
      private string edtavMudanza_carga__itemcargacantidad_Columnheaderclass ;
      private string edtavMudanza_carga__itemcargacantidad_Internalname ;
      private string edtavMudanza_carga__itemcargavolumen_Columnheaderclass ;
      private string edtavMudanza_carga__itemcargavolumen_Internalname ;
      private string edtavDeletegridlinegridlevel_carga_Class ;
      private string edtavDeletegridlinegridlevel_carga_Columnclass ;
      private string edtavMudanza_carga__itemcargaid_Columnclass ;
      private string edtavMudanza_carga__itemcargacantidad_Columnclass ;
      private string edtavMudanza_carga__itemcargavolumen_Columnclass ;
      private string edtavDeletegridlinegridlevel_adicional_Class ;
      private string edtavDeletegridlinegridlevel_adicional_Columnclass ;
      private string edtavMudanza_adicional__itemadicionalid_Columnclass ;
      private string edtavMudanza_adicional__itemadicionalnombre_Columnclass ;
      private string edtavMudanza_adicional__itemadicionalcantidad_Columnclass ;
      private string edtavMudanza_adicional__itemadicionalvalor_Columnclass ;
      private string tblUnnamedtable2_Internalname ;
      private string dynavMudanza_tipoinmuebledestinoid_Jsonclick ;
      private string dynavMudanza_tipoestacionamdestinoid_Jsonclick ;
      private string edtavMudanza_carga__itemcarganombre_Internalname ;
      private string subGridlevel_carga_Class ;
      private string subGridlevel_carga_Linesclass ;
      private string ROClassString ;
      private string edtavDeletegridlinegridlevel_carga_Jsonclick ;
      private string edtavMudanza_carga__itemcargaid_Jsonclick ;
      private string edtavMudanza_carga__itemcarganombre_Jsonclick ;
      private string edtavMudanza_carga__itemcargacantidad_Jsonclick ;
      private string edtavMudanza_carga__itemcargavolumen_Jsonclick ;
      private string subGridlevel_adicional_Class ;
      private string subGridlevel_adicional_Linesclass ;
      private string edtavDeletegridlinegridlevel_adicional_Jsonclick ;
      private string edtavMudanza_adicional__itemadicionalid_Jsonclick ;
      private string edtavMudanza_adicional__itemadicionalnombre_Jsonclick ;
      private string edtavMudanza_adicional__itemadicionalcantidad_Jsonclick ;
      private string edtavMudanza_adicional__itemadicionalvalor_Jsonclick ;
      private string GXCCtl ;
      private string subGridlevel_carga_Header ;
      private string subGridlevel_adicional_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14CheckRequiredFieldsResult ;
      private bool Combo_mudanza_carga__itemcargaid_Isgriditem ;
      private bool Combo_mudanza_carga__itemcargaid_Emptyitem ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_75_Refreshing=false ;
      private bool bGXsfl_89_Refreshing=false ;
      private bool returnInSub ;
      private bool AV13LoadSuccess ;
      private bool gx_BV75 ;
      private bool gx_refresh_fired ;
      private bool AV15LineDeleted ;
      private bool gx_BV89 ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Gridlevel_cargaContainer ;
      private GXWebGrid Gridlevel_adicionalContainer ;
      private GXWebRow Gridlevel_cargaRow ;
      private GXWebRow Gridlevel_adicionalRow ;
      private GXWebColumn Gridlevel_cargaColumn ;
      private GXWebColumn Gridlevel_adicionalColumn ;
      private GXUserControl ucCombo_mudanza_carga__itemcargaid ;
      private GXUserControl ucGridlevel_adicional_empowerer ;
      private GXUserControl ucGridlevel_carga_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavMudanza_mudanzahoraservicio ;
      private GXCombobox dynavMudanza_tipoinmuebleorigenid ;
      private GXCombobox dynavMudanza_tipoestacionamorigenid ;
      private GXCombobox dynavMudanza_tipoinmuebledestinoid ;
      private GXCombobox dynavMudanza_tipoestacionamdestinoid ;
      private GXCombobox cmbavMudanza_mudanzavehiculosugerido ;
      private GXCombobox cmbavMudanza_tipoestacionamorigennombre ;
      private SdtMudanza AV7Mudanza ;
      private GxSimpleCollection<short> AV21MudanzaCargaDeleted ;
      private GxSimpleCollection<short> AV19MudanzaAdicionalDeleted ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22Mudanza_Carga__ItemCargaId_Data ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private IDataStoreProvider pr_default ;
      private long[] H00EH2_A735MudanzaId ;
      private short[] H00EH2_A743TipoInmuebleOrigenId ;
      private string[] H00EH2_A755TipoInmuebleOrigenNombre ;
      private long[] H00EH3_A735MudanzaId ;
      private short[] H00EH3_A749TipoEstacionamDestinoId ;
      private string[] H00EH3_A750TipoEstacionamDestinoNombre ;
      private long[] H00EH4_A735MudanzaId ;
      private short[] H00EH4_A745TipoInmuebleDestinoId ;
      private string[] H00EH4_A746TipoInmuebleDestinoNombre ;
      private long[] H00EH5_A735MudanzaId ;
      private short[] H00EH5_A749TipoEstacionamDestinoId ;
      private string[] H00EH5_A750TipoEstacionamDestinoNombre ;
      private SdtMudanza_Adicional AV17MudanzaAdicionalItem ;
      private SdtMudanza_Carga AV20MudanzaCargaItem ;
      private long[] H00EH6_A735MudanzaId ;
      private short[] H00EH6_A751ItemCargaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV23Combo_DataItem ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class solicitudmudanza__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class solicitudmudanza__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH00EH2;
        prmH00EH2 = new Object[] {
        };
        Object[] prmH00EH3;
        prmH00EH3 = new Object[] {
        };
        Object[] prmH00EH4;
        prmH00EH4 = new Object[] {
        };
        Object[] prmH00EH5;
        prmH00EH5 = new Object[] {
        };
        Object[] prmH00EH6;
        prmH00EH6 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H00EH2", "SELECT T1.[MudanzaId], T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId]) ORDER BY T2.[ParametroMudanzaNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00EH2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00EH3", "SELECT T1.[MudanzaId], T1.[TipoEstacionamDestinoId] AS TipoEstacionamDestinoId, T2.[ParametroMudanzaNombre] AS TipoEstacionamDestinoNombre FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoEstacionamDestinoId]) ORDER BY T2.[ParametroMudanzaNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00EH3,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00EH4", "SELECT T1.[MudanzaId], T1.[TipoInmuebleDestinoId] AS TipoInmuebleDestinoId, T2.[ParametroMudanzaNombre] AS TipoInmuebleDestinoNombre FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleDestinoId]) ORDER BY T2.[ParametroMudanzaNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00EH4,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00EH5", "SELECT T1.[MudanzaId], T1.[TipoEstacionamDestinoId] AS TipoEstacionamDestinoId, T2.[ParametroMudanzaNombre] AS TipoEstacionamDestinoNombre FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoEstacionamDestinoId]) ORDER BY T2.[ParametroMudanzaNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00EH5,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00EH6", "SELECT [MudanzaId], [ItemCargaId] FROM [MudanzaCarga] ORDER BY [ItemCargaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00EH6,100, GxCacheFrequency.OFF ,false,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
     }
  }

}

}
