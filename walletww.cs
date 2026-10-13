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
   public class walletww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public walletww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public walletww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGridactions = new GXCombobox();
         cmbTipoCuentaConcepto = new GXCombobox();
         cmbWalletTipoEntidad = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_43 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV44TFWalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFWalletId"), "."), 18, MidpointRounding.ToEven));
         AV45TFWalletId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFWalletId_To"), "."), 18, MidpointRounding.ToEven));
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38ColumnsSelector);
         AV93Pgmname = GetPar( "Pgmname");
         AV17FilterFullText = GetPar( "FilterFullText");
         AV54TFWalletCodRefencia = GetPar( "TFWalletCodRefencia");
         AV55TFWalletCodRefencia_Sel = GetPar( "TFWalletCodRefencia_Sel");
         AV79TFWalletNombre = GetPar( "TFWalletNombre");
         AV80TFWalletNombre_Sel = GetPar( "TFWalletNombre_Sel");
         AV81TFMonedaISOSimbolo = GetPar( "TFMonedaISOSimbolo");
         AV82TFMonedaISOSimbolo_Sel = GetPar( "TFMonedaISOSimbolo_Sel");
         AV62TFWalletSaldo = NumberUtil.Val( GetPar( "TFWalletSaldo"), ".");
         AV63TFWalletSaldo_To = NumberUtil.Val( GetPar( "TFWalletSaldo_To"), ".");
         AV73IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV85IsAuthorized_Acreditar = StringUtil.StrToBool( GetPar( "IsAuthorized_Acreditar"));
         AV86IsAuthorized_Debitar = StringUtil.StrToBool( GetPar( "IsAuthorized_Debitar"));
         AV88IsAuthorized_PagoSaldo = StringUtil.StrToBool( GetPar( "IsAuthorized_PagoSaldo"));
         AV89IsAuthorized_CobroSaldo = StringUtil.StrToBool( GetPar( "IsAuthorized_CobroSaldo"));
         AV90OperacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "OperacionesId"), "."), 18, MidpointRounding.ToEven));
         AV91WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV44TFWalletId, AV45TFWalletId_To, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV93Pgmname, AV17FilterFullText, AV54TFWalletCodRefencia, AV55TFWalletCodRefencia_Sel, AV79TFWalletNombre, AV80TFWalletNombre_Sel, AV81TFMonedaISOSimbolo, AV82TFMonedaISOSimbolo_Sel, AV62TFWalletSaldo, AV63TFWalletSaldo_To, AV73IsAuthorized_Update, AV85IsAuthorized_Acreditar, AV86IsAuthorized_Debitar, AV88IsAuthorized_PagoSaldo, AV89IsAuthorized_CobroSaldo, AV90OperacionesId, AV91WalletId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
         PAAP2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTAP2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("walletww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV93Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV93Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV73IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV73IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ACREDITAR", AV85IsAuthorized_Acreditar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ACREDITAR", GetSecureSignedToken( "", AV85IsAuthorized_Acreditar, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DEBITAR", AV86IsAuthorized_Debitar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DEBITAR", GetSecureSignedToken( "", AV86IsAuthorized_Debitar, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PAGOSALDO", AV88IsAuthorized_PagoSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PAGOSALDO", GetSecureSignedToken( "", AV88IsAuthorized_PagoSaldo, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_COBROSALDO", AV89IsAuthorized_CobroSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COBROSALDO", GetSecureSignedToken( "", AV89IsAuthorized_CobroSaldo, context));
         GxWebStd.gx_hidden_field( context, "vOPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV90OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV70GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV75AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV75AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV66DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV66DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV93Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV93Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFWalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWALLETID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TFWalletId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWALLETCODREFENCIA", StringUtil.RTrim( AV54TFWalletCodRefencia));
         GxWebStd.gx_hidden_field( context, "vTFWALLETCODREFENCIA_SEL", StringUtil.RTrim( AV55TFWalletCodRefencia_Sel));
         GxWebStd.gx_hidden_field( context, "vTFWALLETNOMBRE", StringUtil.RTrim( AV79TFWalletNombre));
         GxWebStd.gx_hidden_field( context, "vTFWALLETNOMBRE_SEL", StringUtil.RTrim( AV80TFWalletNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFMONEDAISOSIMBOLO", StringUtil.RTrim( AV81TFMonedaISOSimbolo));
         GxWebStd.gx_hidden_field( context, "vTFMONEDAISOSIMBOLO_SEL", StringUtil.RTrim( AV82TFMonedaISOSimbolo_Sel));
         GxWebStd.gx_hidden_field( context, "vTFWALLETSALDO", StringUtil.LTrim( StringUtil.NToC( AV62TFWalletSaldo, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWALLETSALDO_TO", StringUtil.LTrim( StringUtil.NToC( AV63TFWalletSaldo_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV73IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV73IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ACREDITAR", AV85IsAuthorized_Acreditar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ACREDITAR", GetSecureSignedToken( "", AV85IsAuthorized_Acreditar, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DEBITAR", AV86IsAuthorized_Debitar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DEBITAR", GetSecureSignedToken( "", AV86IsAuthorized_Debitar, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PAGOSALDO", AV88IsAuthorized_PagoSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PAGOSALDO", GetSecureSignedToken( "", AV88IsAuthorized_PagoSaldo, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_COBROSALDO", AV89IsAuthorized_CobroSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COBROSALDO", GetSecureSignedToken( "", AV89IsAuthorized_CobroSaldo, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vOPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV90OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WALLETTOTALDEBITO", StringUtil.LTrim( StringUtil.NToC( A646WalletTotalDebito, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WALLETTOTALCREDITO", StringUtil.LTrim( StringUtil.NToC( A647WalletTotalCredito, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
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
            WEAP2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTAP2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("walletww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WalletWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Saldos y Cuentas", "") ;
      }

      protected void WBAP0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WalletWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WalletWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WalletWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnliquidaciones_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "Ir a Liquidaciones", ""), bttBtnliquidaciones_Jsonclick, 5, context.GetMessage( "Ir a Liquidaciones", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOLIQUIDACIONES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WalletWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_AP2( true) ;
         }
         else
         {
            wb_table1_25_AP2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_AP2e( bool wbgen )
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl43( ) ;
         }
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            nRC_GXsfl_43 = (int)(nGXsfl_43_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV68GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV69GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV70GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV75AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV66DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV66DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV38ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTAP2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Saldos y Cuentas", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPAP0( ) ;
      }

      protected void WSAP2( )
      {
         STARTAP2( ) ;
         EVTAP2( ) ;
      }

      protected void EVTAP2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E11AP2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12AP2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13AP2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E14AP2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E15AP2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E16AP2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E17AP2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLIQUIDACIONES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLiquidaciones' */
                              E18AP2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
                              SubsflControlProps_432( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV71GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV71GridActions), 4, 0));
                              A637WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWalletId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A483TipoCuentaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoCuentaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbTipoCuentaConcepto.Name = cmbTipoCuentaConcepto_Internalname;
                              cmbTipoCuentaConcepto.CurrentValue = cgiGet( cmbTipoCuentaConcepto_Internalname);
                              A636TipoCuentaConcepto = cgiGet( cmbTipoCuentaConcepto_Internalname);
                              A484TipoCuentaNombre = cgiGet( edtTipoCuentaNombre_Internalname);
                              cmbWalletTipoEntidad.Name = cmbWalletTipoEntidad_Internalname;
                              cmbWalletTipoEntidad.CurrentValue = cgiGet( cmbWalletTipoEntidad_Internalname);
                              A638WalletTipoEntidad = cgiGet( cmbWalletTipoEntidad_Internalname);
                              A639WalletCodRefencia = cgiGet( edtWalletCodRefencia_Internalname);
                              A715WalletNombre = cgiGet( edtWalletNombre_Internalname);
                              A118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMonedaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n118MonedaId = false;
                              A119MonedaISOSimbolo = cgiGet( edtMonedaISOSimbolo_Internalname);
                              A648WalletSaldo = context.localUtil.CToN( cgiGet( edtWalletSaldo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavOperacionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOperacionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOPERACIONID");
                                 GX_FocusControl = edtavOperacionid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV92OperacionId = 0;
                                 AssignAttri("", false, edtavOperacionid_Internalname, StringUtil.LTrimStr( (decimal)(AV92OperacionId), 18, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV92OperacionId), "ZZZZZZZZZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV92OperacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavOperacionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavOperacionid_Internalname, StringUtil.LTrimStr( (decimal)(AV92OperacionId), 18, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV92OperacionId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                    E19AP2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E20AP2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E21AP2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E22AP2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
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

      protected void WEAP2( )
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

      protected void PAAP2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_432( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            sendrow_432( ) ;
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       long AV44TFWalletId ,
                                       long AV45TFWalletId_To ,
                                       short AV43ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ,
                                       string AV93Pgmname ,
                                       string AV17FilterFullText ,
                                       string AV54TFWalletCodRefencia ,
                                       string AV55TFWalletCodRefencia_Sel ,
                                       string AV79TFWalletNombre ,
                                       string AV80TFWalletNombre_Sel ,
                                       string AV81TFMonedaISOSimbolo ,
                                       string AV82TFMonedaISOSimbolo_Sel ,
                                       decimal AV62TFWalletSaldo ,
                                       decimal AV63TFWalletSaldo_To ,
                                       bool AV73IsAuthorized_Update ,
                                       bool AV85IsAuthorized_Acreditar ,
                                       bool AV86IsAuthorized_Debitar ,
                                       bool AV88IsAuthorized_PagoSaldo ,
                                       bool AV89IsAuthorized_CobroSaldo ,
                                       long AV90OperacionesId ,
                                       long AV91WalletId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFAP2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETNOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A715WalletNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "WALLETNOMBRE", StringUtil.RTrim( A715WalletNombre));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV92OperacionId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vOPERACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV92OperacionId), 18, 0, ".", "")));
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
         RFAP2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV93Pgmname = "WalletWW";
         edtavOperacionid_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV94Walletwwds_1_filterfulltext = AV17FilterFullText;
         AV95Walletwwds_2_tfwalletid = AV44TFWalletId;
         AV96Walletwwds_3_tfwalletid_to = AV45TFWalletId_To;
         AV97Walletwwds_4_tfwalletcodrefencia = AV54TFWalletCodRefencia;
         AV98Walletwwds_5_tfwalletcodrefencia_sel = AV55TFWalletCodRefencia_Sel;
         AV99Walletwwds_6_tfwalletnombre = AV79TFWalletNombre;
         AV100Walletwwds_7_tfwalletnombre_sel = AV80TFWalletNombre_Sel;
         AV101Walletwwds_8_tfmonedaisosimbolo = AV81TFMonedaISOSimbolo;
         AV102Walletwwds_9_tfmonedaisosimbolo_sel = AV82TFMonedaISOSimbolo_Sel;
         AV103Walletwwds_10_tfwalletsaldo = AV62TFWalletSaldo;
         AV104Walletwwds_11_tfwalletsaldo_to = AV63TFWalletSaldo_To;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV95Walletwwds_2_tfwalletid ,
                                              AV96Walletwwds_3_tfwalletid_to ,
                                              AV98Walletwwds_5_tfwalletcodrefencia_sel ,
                                              AV97Walletwwds_4_tfwalletcodrefencia ,
                                              AV102Walletwwds_9_tfmonedaisosimbolo_sel ,
                                              AV101Walletwwds_8_tfmonedaisosimbolo ,
                                              A637WalletId ,
                                              A639WalletCodRefencia ,
                                              A119MonedaISOSimbolo ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV94Walletwwds_1_filterfulltext ,
                                              A715WalletNombre ,
                                              A648WalletSaldo ,
                                              AV100Walletwwds_7_tfwalletnombre_sel ,
                                              AV99Walletwwds_6_tfwalletnombre ,
                                              AV103Walletwwds_10_tfwalletsaldo ,
                                              AV104Walletwwds_11_tfwalletsaldo_to } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV97Walletwwds_4_tfwalletcodrefencia = StringUtil.PadR( StringUtil.RTrim( AV97Walletwwds_4_tfwalletcodrefencia), 25, "%");
         lV101Walletwwds_8_tfmonedaisosimbolo = StringUtil.PadR( StringUtil.RTrim( AV101Walletwwds_8_tfmonedaisosimbolo), 3, "%");
         /* Using cursor H00AP2 */
         pr_default.execute(0, new Object[] {AV95Walletwwds_2_tfwalletid, AV96Walletwwds_3_tfwalletid_to, lV97Walletwwds_4_tfwalletcodrefencia, AV98Walletwwds_5_tfwalletcodrefencia_sel, lV101Walletwwds_8_tfmonedaisosimbolo, AV102Walletwwds_9_tfmonedaisosimbolo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A119MonedaISOSimbolo = H00AP2_A119MonedaISOSimbolo[0];
            A118MonedaId = H00AP2_A118MonedaId[0];
            n118MonedaId = H00AP2_n118MonedaId[0];
            A484TipoCuentaNombre = H00AP2_A484TipoCuentaNombre[0];
            A636TipoCuentaConcepto = H00AP2_A636TipoCuentaConcepto[0];
            A483TipoCuentaId = H00AP2_A483TipoCuentaId[0];
            A639WalletCodRefencia = H00AP2_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = H00AP2_A638WalletTipoEntidad[0];
            A637WalletId = H00AP2_A637WalletId[0];
            A119MonedaISOSimbolo = H00AP2_A119MonedaISOSimbolo[0];
            A484TipoCuentaNombre = H00AP2_A484TipoCuentaNombre[0];
            A636TipoCuentaConcepto = H00AP2_A636TipoCuentaConcepto[0];
            GXt_decimal1 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal1) ;
            A646WalletTotalDebito = GXt_decimal1;
            AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
            GXt_decimal1 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal1) ;
            A647WalletTotalCredito = GXt_decimal1;
            AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            if ( (Convert.ToDecimal(0)==AV103Walletwwds_10_tfwalletsaldo) || ( ( A648WalletSaldo >= AV103Walletwwds_10_tfwalletsaldo ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV104Walletwwds_11_tfwalletsaldo_to) || ( ( A648WalletSaldo <= AV104Walletwwds_11_tfwalletsaldo_to ) ) )
               {
                  GXt_char2 = A715WalletNombre;
                  new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char2) ;
                  A715WalletNombre = GXt_char2;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Walletwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV94Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV94Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV94Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV94Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV94Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Walletwwds_7_tfwalletnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Walletwwds_6_tfwalletnombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV99Walletwwds_6_tfwalletnombre) , 254 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Walletwwds_7_tfwalletnombre_sel)) && ! ( StringUtil.StrCmp(AV100Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV100Walletwwds_7_tfwalletnombre_sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV100Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
                           {
                              GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                           }
                        }
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RFAP2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E20AP2 ();
         nGXsfl_43_idx = 1;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         bGXsfl_43_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_432( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV95Walletwwds_2_tfwalletid ,
                                                 AV96Walletwwds_3_tfwalletid_to ,
                                                 AV98Walletwwds_5_tfwalletcodrefencia_sel ,
                                                 AV97Walletwwds_4_tfwalletcodrefencia ,
                                                 AV102Walletwwds_9_tfmonedaisosimbolo_sel ,
                                                 AV101Walletwwds_8_tfmonedaisosimbolo ,
                                                 A637WalletId ,
                                                 A639WalletCodRefencia ,
                                                 A119MonedaISOSimbolo ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV94Walletwwds_1_filterfulltext ,
                                                 A715WalletNombre ,
                                                 A648WalletSaldo ,
                                                 AV100Walletwwds_7_tfwalletnombre_sel ,
                                                 AV99Walletwwds_6_tfwalletnombre ,
                                                 AV103Walletwwds_10_tfwalletsaldo ,
                                                 AV104Walletwwds_11_tfwalletsaldo_to } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                                 }
            });
            lV97Walletwwds_4_tfwalletcodrefencia = StringUtil.PadR( StringUtil.RTrim( AV97Walletwwds_4_tfwalletcodrefencia), 25, "%");
            lV101Walletwwds_8_tfmonedaisosimbolo = StringUtil.PadR( StringUtil.RTrim( AV101Walletwwds_8_tfmonedaisosimbolo), 3, "%");
            /* Using cursor H00AP3 */
            pr_default.execute(1, new Object[] {AV95Walletwwds_2_tfwalletid, AV96Walletwwds_3_tfwalletid_to, lV97Walletwwds_4_tfwalletcodrefencia, AV98Walletwwds_5_tfwalletcodrefencia_sel, lV101Walletwwds_8_tfmonedaisosimbolo, AV102Walletwwds_9_tfmonedaisosimbolo_sel});
            nGXsfl_43_idx = 1;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A119MonedaISOSimbolo = H00AP3_A119MonedaISOSimbolo[0];
               A118MonedaId = H00AP3_A118MonedaId[0];
               n118MonedaId = H00AP3_n118MonedaId[0];
               A484TipoCuentaNombre = H00AP3_A484TipoCuentaNombre[0];
               A636TipoCuentaConcepto = H00AP3_A636TipoCuentaConcepto[0];
               A483TipoCuentaId = H00AP3_A483TipoCuentaId[0];
               A639WalletCodRefencia = H00AP3_A639WalletCodRefencia[0];
               A638WalletTipoEntidad = H00AP3_A638WalletTipoEntidad[0];
               A637WalletId = H00AP3_A637WalletId[0];
               A119MonedaISOSimbolo = H00AP3_A119MonedaISOSimbolo[0];
               A484TipoCuentaNombre = H00AP3_A484TipoCuentaNombre[0];
               A636TipoCuentaConcepto = H00AP3_A636TipoCuentaConcepto[0];
               GXt_decimal1 = A646WalletTotalDebito;
               new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal1) ;
               A646WalletTotalDebito = GXt_decimal1;
               AssignAttri("", false, "A646WalletTotalDebito", StringUtil.LTrimStr( A646WalletTotalDebito, 18, 2));
               GXt_decimal1 = A647WalletTotalCredito;
               new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal1) ;
               A647WalletTotalCredito = GXt_decimal1;
               AssignAttri("", false, "A647WalletTotalCredito", StringUtil.LTrimStr( A647WalletTotalCredito, 18, 2));
               A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
               if ( (Convert.ToDecimal(0)==AV103Walletwwds_10_tfwalletsaldo) || ( ( A648WalletSaldo >= AV103Walletwwds_10_tfwalletsaldo ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV104Walletwwds_11_tfwalletsaldo_to) || ( ( A648WalletSaldo <= AV104Walletwwds_11_tfwalletsaldo_to ) ) )
                  {
                     GXt_char2 = A715WalletNombre;
                     new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char2) ;
                     A715WalletNombre = GXt_char2;
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Walletwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV94Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV94Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV94Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV94Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV94Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
                     {
                        if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Walletwwds_7_tfwalletnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Walletwwds_6_tfwalletnombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV99Walletwwds_6_tfwalletnombre) , 254 , "%"),  ' ' ) ) )
                        {
                           if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Walletwwds_7_tfwalletnombre_sel)) && ! ( StringUtil.StrCmp(AV100Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV100Walletwwds_7_tfwalletnombre_sel) == 0 ) ) )
                           {
                              if ( ( StringUtil.StrCmp(AV100Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
                              {
                                 /* Execute user event: Grid.Load */
                                 E21AP2 ();
                              }
                           }
                        }
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 43;
            WBAP0( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesAP2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV93Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV93Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV73IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV73IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ACREDITAR", AV85IsAuthorized_Acreditar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ACREDITAR", GetSecureSignedToken( "", AV85IsAuthorized_Acreditar, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DEBITAR", AV86IsAuthorized_Debitar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DEBITAR", GetSecureSignedToken( "", AV86IsAuthorized_Debitar, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PAGOSALDO", AV88IsAuthorized_PagoSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PAGOSALDO", GetSecureSignedToken( "", AV88IsAuthorized_PagoSaldo, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_COBROSALDO", AV89IsAuthorized_CobroSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COBROSALDO", GetSecureSignedToken( "", AV89IsAuthorized_CobroSaldo, context));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WALLETNOMBRE"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, StringUtil.RTrim( context.localUtil.Format( A715WalletNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "vOPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV90OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV91WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV92OperacionId), "ZZZZZZZZZZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(subGridclient_rec_count_fnc()) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV94Walletwwds_1_filterfulltext = AV17FilterFullText;
         AV95Walletwwds_2_tfwalletid = AV44TFWalletId;
         AV96Walletwwds_3_tfwalletid_to = AV45TFWalletId_To;
         AV97Walletwwds_4_tfwalletcodrefencia = AV54TFWalletCodRefencia;
         AV98Walletwwds_5_tfwalletcodrefencia_sel = AV55TFWalletCodRefencia_Sel;
         AV99Walletwwds_6_tfwalletnombre = AV79TFWalletNombre;
         AV100Walletwwds_7_tfwalletnombre_sel = AV80TFWalletNombre_Sel;
         AV101Walletwwds_8_tfmonedaisosimbolo = AV81TFMonedaISOSimbolo;
         AV102Walletwwds_9_tfmonedaisosimbolo_sel = AV82TFMonedaISOSimbolo_Sel;
         AV103Walletwwds_10_tfwalletsaldo = AV62TFWalletSaldo;
         AV104Walletwwds_11_tfwalletsaldo_to = AV63TFWalletSaldo_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV44TFWalletId, AV45TFWalletId_To, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV93Pgmname, AV17FilterFullText, AV54TFWalletCodRefencia, AV55TFWalletCodRefencia_Sel, AV79TFWalletNombre, AV80TFWalletNombre_Sel, AV81TFMonedaISOSimbolo, AV82TFMonedaISOSimbolo_Sel, AV62TFWalletSaldo, AV63TFWalletSaldo_To, AV73IsAuthorized_Update, AV85IsAuthorized_Acreditar, AV86IsAuthorized_Debitar, AV88IsAuthorized_PagoSaldo, AV89IsAuthorized_CobroSaldo, AV90OperacionesId, AV91WalletId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV94Walletwwds_1_filterfulltext = AV17FilterFullText;
         AV95Walletwwds_2_tfwalletid = AV44TFWalletId;
         AV96Walletwwds_3_tfwalletid_to = AV45TFWalletId_To;
         AV97Walletwwds_4_tfwalletcodrefencia = AV54TFWalletCodRefencia;
         AV98Walletwwds_5_tfwalletcodrefencia_sel = AV55TFWalletCodRefencia_Sel;
         AV99Walletwwds_6_tfwalletnombre = AV79TFWalletNombre;
         AV100Walletwwds_7_tfwalletnombre_sel = AV80TFWalletNombre_Sel;
         AV101Walletwwds_8_tfmonedaisosimbolo = AV81TFMonedaISOSimbolo;
         AV102Walletwwds_9_tfmonedaisosimbolo_sel = AV82TFMonedaISOSimbolo_Sel;
         AV103Walletwwds_10_tfwalletsaldo = AV62TFWalletSaldo;
         AV104Walletwwds_11_tfwalletsaldo_to = AV63TFWalletSaldo_To;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV44TFWalletId, AV45TFWalletId_To, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV93Pgmname, AV17FilterFullText, AV54TFWalletCodRefencia, AV55TFWalletCodRefencia_Sel, AV79TFWalletNombre, AV80TFWalletNombre_Sel, AV81TFMonedaISOSimbolo, AV82TFMonedaISOSimbolo_Sel, AV62TFWalletSaldo, AV63TFWalletSaldo_To, AV73IsAuthorized_Update, AV85IsAuthorized_Acreditar, AV86IsAuthorized_Debitar, AV88IsAuthorized_PagoSaldo, AV89IsAuthorized_CobroSaldo, AV90OperacionesId, AV91WalletId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV94Walletwwds_1_filterfulltext = AV17FilterFullText;
         AV95Walletwwds_2_tfwalletid = AV44TFWalletId;
         AV96Walletwwds_3_tfwalletid_to = AV45TFWalletId_To;
         AV97Walletwwds_4_tfwalletcodrefencia = AV54TFWalletCodRefencia;
         AV98Walletwwds_5_tfwalletcodrefencia_sel = AV55TFWalletCodRefencia_Sel;
         AV99Walletwwds_6_tfwalletnombre = AV79TFWalletNombre;
         AV100Walletwwds_7_tfwalletnombre_sel = AV80TFWalletNombre_Sel;
         AV101Walletwwds_8_tfmonedaisosimbolo = AV81TFMonedaISOSimbolo;
         AV102Walletwwds_9_tfmonedaisosimbolo_sel = AV82TFMonedaISOSimbolo_Sel;
         AV103Walletwwds_10_tfwalletsaldo = AV62TFWalletSaldo;
         AV104Walletwwds_11_tfwalletsaldo_to = AV63TFWalletSaldo_To;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV44TFWalletId, AV45TFWalletId_To, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV93Pgmname, AV17FilterFullText, AV54TFWalletCodRefencia, AV55TFWalletCodRefencia_Sel, AV79TFWalletNombre, AV80TFWalletNombre_Sel, AV81TFMonedaISOSimbolo, AV82TFMonedaISOSimbolo_Sel, AV62TFWalletSaldo, AV63TFWalletSaldo_To, AV73IsAuthorized_Update, AV85IsAuthorized_Acreditar, AV86IsAuthorized_Debitar, AV88IsAuthorized_PagoSaldo, AV89IsAuthorized_CobroSaldo, AV90OperacionesId, AV91WalletId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV94Walletwwds_1_filterfulltext = AV17FilterFullText;
         AV95Walletwwds_2_tfwalletid = AV44TFWalletId;
         AV96Walletwwds_3_tfwalletid_to = AV45TFWalletId_To;
         AV97Walletwwds_4_tfwalletcodrefencia = AV54TFWalletCodRefencia;
         AV98Walletwwds_5_tfwalletcodrefencia_sel = AV55TFWalletCodRefencia_Sel;
         AV99Walletwwds_6_tfwalletnombre = AV79TFWalletNombre;
         AV100Walletwwds_7_tfwalletnombre_sel = AV80TFWalletNombre_Sel;
         AV101Walletwwds_8_tfmonedaisosimbolo = AV81TFMonedaISOSimbolo;
         AV102Walletwwds_9_tfmonedaisosimbolo_sel = AV82TFMonedaISOSimbolo_Sel;
         AV103Walletwwds_10_tfwalletsaldo = AV62TFWalletSaldo;
         AV104Walletwwds_11_tfwalletsaldo_to = AV63TFWalletSaldo_To;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV44TFWalletId, AV45TFWalletId_To, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV93Pgmname, AV17FilterFullText, AV54TFWalletCodRefencia, AV55TFWalletCodRefencia_Sel, AV79TFWalletNombre, AV80TFWalletNombre_Sel, AV81TFMonedaISOSimbolo, AV82TFMonedaISOSimbolo_Sel, AV62TFWalletSaldo, AV63TFWalletSaldo_To, AV73IsAuthorized_Update, AV85IsAuthorized_Acreditar, AV86IsAuthorized_Debitar, AV88IsAuthorized_PagoSaldo, AV89IsAuthorized_CobroSaldo, AV90OperacionesId, AV91WalletId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV94Walletwwds_1_filterfulltext = AV17FilterFullText;
         AV95Walletwwds_2_tfwalletid = AV44TFWalletId;
         AV96Walletwwds_3_tfwalletid_to = AV45TFWalletId_To;
         AV97Walletwwds_4_tfwalletcodrefencia = AV54TFWalletCodRefencia;
         AV98Walletwwds_5_tfwalletcodrefencia_sel = AV55TFWalletCodRefencia_Sel;
         AV99Walletwwds_6_tfwalletnombre = AV79TFWalletNombre;
         AV100Walletwwds_7_tfwalletnombre_sel = AV80TFWalletNombre_Sel;
         AV101Walletwwds_8_tfmonedaisosimbolo = AV81TFMonedaISOSimbolo;
         AV102Walletwwds_9_tfmonedaisosimbolo_sel = AV82TFMonedaISOSimbolo_Sel;
         AV103Walletwwds_10_tfwalletsaldo = AV62TFWalletSaldo;
         AV104Walletwwds_11_tfwalletsaldo_to = AV63TFWalletSaldo_To;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV44TFWalletId, AV45TFWalletId_To, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV93Pgmname, AV17FilterFullText, AV54TFWalletCodRefencia, AV55TFWalletCodRefencia_Sel, AV79TFWalletNombre, AV80TFWalletNombre_Sel, AV81TFMonedaISOSimbolo, AV82TFMonedaISOSimbolo_Sel, AV62TFWalletSaldo, AV63TFWalletSaldo_To, AV73IsAuthorized_Update, AV85IsAuthorized_Acreditar, AV86IsAuthorized_Debitar, AV88IsAuthorized_PagoSaldo, AV89IsAuthorized_CobroSaldo, AV90OperacionesId, AV91WalletId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV93Pgmname = "WalletWW";
         edtavOperacionid_Enabled = 0;
         edtWalletId_Enabled = 0;
         edtTipoCuentaId_Enabled = 0;
         cmbTipoCuentaConcepto.Enabled = 0;
         edtTipoCuentaNombre_Enabled = 0;
         cmbWalletTipoEntidad.Enabled = 0;
         edtWalletCodRefencia_Enabled = 0;
         edtWalletNombre_Enabled = 0;
         edtMonedaId_Enabled = 0;
         edtMonedaISOSimbolo_Enabled = 0;
         edtWalletSaldo_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAP0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19AP2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV75AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV66DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV38ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV68GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV69GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV70GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
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
         E19AP2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19AP2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV75AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV76AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV76AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV76AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV76AGExportDataItem.gxTpr_Eventkey = "Export";
         AV76AGExportDataItem.gxTpr_Isdivider = false;
         AV75AGExportData.Add(AV76AGExportDataItem, 0);
         AV76AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV76AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV76AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV76AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV76AGExportDataItem.gxTpr_Isdivider = false;
         AV75AGExportData.Add(AV76AGExportDataItem, 0);
         AV75AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV76AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV76AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV76AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV76AGExportDataItem.gxTpr_Eventkey = "Export";
         AV76AGExportDataItem.gxTpr_Isdivider = false;
         AV75AGExportData.Add(AV76AGExportDataItem, 0);
         AV76AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV76AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV76AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV76AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV76AGExportDataItem.gxTpr_Isdivider = false;
         AV75AGExportData.Add(AV76AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Saldos y Cuentas", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = AV66DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3) ;
         AV66DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E20AP2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV43ManageFiltersExecutionStep == 1 )
         {
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV43ManageFiltersExecutionStep == 2 )
         {
            AV43ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV40Session.Get("WalletWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV40Session.Get("WalletWWColumnsSelector");
            AV38ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtWalletId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWalletId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWalletId_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtWalletCodRefencia_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWalletCodRefencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWalletCodRefencia_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtWalletNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWalletNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWalletNombre_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtMonedaISOSimbolo_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMonedaISOSimbolo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMonedaISOSimbolo_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtWalletSaldo_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWalletSaldo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWalletSaldo_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtavOperacionid_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavOperacionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOperacionid_Visible), 5, 0), !bGXsfl_43_Refreshing);
         AV68GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV68GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV68GridCurrentPage), 10, 0));
         AV69GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV69GridPageCount", StringUtil.LTrimStr( (decimal)(AV69GridPageCount), 10, 0));
         GXt_char2 = AV70GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV93Pgmname, out  GXt_char2) ;
         AV70GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV70GridAppliedFilters", AV70GridAppliedFilters);
         edtWalletSaldo_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtWalletSaldo_Internalname, "Columnheaderclass", edtWalletSaldo_Columnheaderclass, !bGXsfl_43_Refreshing);
         AV94Walletwwds_1_filterfulltext = AV17FilterFullText;
         AV95Walletwwds_2_tfwalletid = AV44TFWalletId;
         AV96Walletwwds_3_tfwalletid_to = AV45TFWalletId_To;
         AV97Walletwwds_4_tfwalletcodrefencia = AV54TFWalletCodRefencia;
         AV98Walletwwds_5_tfwalletcodrefencia_sel = AV55TFWalletCodRefencia_Sel;
         AV99Walletwwds_6_tfwalletnombre = AV79TFWalletNombre;
         AV100Walletwwds_7_tfwalletnombre_sel = AV80TFWalletNombre_Sel;
         AV101Walletwwds_8_tfmonedaisosimbolo = AV81TFMonedaISOSimbolo;
         AV102Walletwwds_9_tfmonedaisosimbolo_sel = AV82TFMonedaISOSimbolo_Sel;
         AV103Walletwwds_10_tfwalletsaldo = AV62TFWalletSaldo;
         AV104Walletwwds_11_tfwalletsaldo_to = AV63TFWalletSaldo_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12AP2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV67PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV67PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13AP2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15AP2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WalletId") == 0 )
            {
               AV44TFWalletId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFWalletId", StringUtil.LTrimStr( (decimal)(AV44TFWalletId), 18, 0));
               AV45TFWalletId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFWalletId_To", StringUtil.LTrimStr( (decimal)(AV45TFWalletId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WalletCodRefencia") == 0 )
            {
               AV54TFWalletCodRefencia = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFWalletCodRefencia", AV54TFWalletCodRefencia);
               AV55TFWalletCodRefencia_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFWalletCodRefencia_Sel", AV55TFWalletCodRefencia_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WalletNombre") == 0 )
            {
               AV79TFWalletNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV79TFWalletNombre", AV79TFWalletNombre);
               AV80TFWalletNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV80TFWalletNombre_Sel", AV80TFWalletNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MonedaISOSimbolo") == 0 )
            {
               AV81TFMonedaISOSimbolo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV81TFMonedaISOSimbolo", AV81TFMonedaISOSimbolo);
               AV82TFMonedaISOSimbolo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV82TFMonedaISOSimbolo_Sel", AV82TFMonedaISOSimbolo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WalletSaldo") == 0 )
            {
               AV62TFWalletSaldo = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV62TFWalletSaldo", StringUtil.LTrimStr( AV62TFWalletSaldo, 18, 2));
               AV63TFWalletSaldo_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV63TFWalletSaldo_To", StringUtil.LTrimStr( AV63TFWalletSaldo_To, 18, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E21AP2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV73IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV85IsAuthorized_Acreditar )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "Acreditar", ""), "fas fa-square-plus", "", "", "", "", "", "", ""), 0);
            }
            if ( AV86IsAuthorized_Debitar )
            {
               cmbavGridactions.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "Debitar", ""), "fas fa-square-minus", "", "", "", "", "", "", ""), 0);
            }
            if ( AV88IsAuthorized_PagoSaldo )
            {
               cmbavGridactions.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "Pago de Liquidación", ""), "fas fa-coins", "", "", "", "", "", "", ""), 0);
            }
            if ( AV89IsAuthorized_CobroSaldo )
            {
               cmbavGridactions.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "Cobro de Liquidación", ""), "far fa-money-bill-1", "", "", "", "", "", "", ""), 0);
            }
            if ( ( A648WalletSaldo < Convert.ToDecimal( 0 )) )
            {
               edtWalletSaldo_Columnclass = "WWColumn WWColumnDanger WWColumnDangerSingleCell";
            }
            else if ( ( A648WalletSaldo == Convert.ToDecimal( 0 )) )
            {
               edtWalletSaldo_Columnclass = "WWColumn WWColumnSuccess WWColumnSuccessSingleCell";
            }
            else
            {
               edtWalletSaldo_Columnclass = "WWColumn";
            }
            GXt_int4 = AV92OperacionId;
            new owalletoperacionultima(context ).execute(  A637WalletId, out  GXt_int4) ;
            AV92OperacionId = GXt_int4;
            AssignAttri("", false, edtavOperacionid_Internalname, StringUtil.LTrimStr( (decimal)(AV92OperacionId), 18, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vOPERACIONID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(AV92OperacionId), "ZZZZZZZZZZZZZZZZZ9"), context));
            if ( ( A648WalletSaldo == Convert.ToDecimal( 0 )) || ( AV92OperacionId == 0 ) )
            {
               cmbavGridactions.removeItem(StringUtil.Str( (decimal)(5), 1, 0));
               cmbavGridactions.removeItem(StringUtil.Str( (decimal)(6), 1, 0));
            }
            else if ( ( A648WalletSaldo < Convert.ToDecimal( 0 )) )
            {
               cmbavGridactions.removeItem(StringUtil.Str( (decimal)(5), 1, 0));
            }
            else if ( ( A648WalletSaldo > Convert.ToDecimal( 0 )) )
            {
               cmbavGridactions.removeItem(StringUtil.Str( (decimal)(6), 1, 0));
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 43;
            }
            sendrow_432( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_43_Refreshing )
         {
            context.DoAjaxLoad(43, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV71GridActions), 4, 0));
      }

      protected void E16AP2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV36ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV38ColumnsSelector.FromJSonString(AV36ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "WalletWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV36ColumnsSelectorXML)) ? "" : AV38ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E11AP2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WalletWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV93Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WalletWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WalletWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV42ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV93Pgmname+"GridState",  AV42ManageFiltersXml) ;
               AV11GridState.FromXml(AV42ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E22AP2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV71GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV71GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV71GridActions == 3 )
         {
            /* Execute user subroutine: 'DO ACREDITAR' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV71GridActions == 4 )
         {
            /* Execute user subroutine: 'DO DEBITAR' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV71GridActions == 5 )
         {
            /* Execute user subroutine: 'DO PAGOSALDO' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV71GridActions == 6 )
         {
            /* Execute user subroutine: 'DO COBROSALDO' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV71GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV71GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV71GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E17AP2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wallet.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("wallet.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14AP2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E18AP2( )
      {
         /* 'DoLiquidaciones' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wpliquidacioncentro.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "WalletId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "WalletCodRefencia",  "",  "Código de Refencia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "WalletNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "MonedaISOSimbolo",  "",  "Moneda",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "WalletSaldo",  "",  "Saldo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "&OperacionId",  "",  "Liquidación",  true,  "") ;
         GXt_char2 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "WalletWWColumnsSelector", out  GXt_char2) ;
         AV37UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37UserCustomValue)) ) )
         {
            AV39ColumnsSelectorAux.FromXml(AV37UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV39ColumnsSelectorAux, ref  AV38ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean5 = AV73IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet_Update", out  GXt_boolean5) ;
         AV73IsAuthorized_Update = GXt_boolean5;
         AssignAttri("", false, "AV73IsAuthorized_Update", AV73IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV73IsAuthorized_Update, context));
         GXt_boolean5 = AV85IsAuthorized_Acreditar;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "OperacionWP", out  GXt_boolean5) ;
         AV85IsAuthorized_Acreditar = GXt_boolean5;
         AssignAttri("", false, "AV85IsAuthorized_Acreditar", AV85IsAuthorized_Acreditar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ACREDITAR", GetSecureSignedToken( "", AV85IsAuthorized_Acreditar, context));
         GXt_boolean5 = AV86IsAuthorized_Debitar;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "OperacionWP", out  GXt_boolean5) ;
         AV86IsAuthorized_Debitar = GXt_boolean5;
         AssignAttri("", false, "AV86IsAuthorized_Debitar", AV86IsAuthorized_Debitar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DEBITAR", GetSecureSignedToken( "", AV86IsAuthorized_Debitar, context));
         GXt_boolean5 = AV88IsAuthorized_PagoSaldo;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "OperacionWP", out  GXt_boolean5) ;
         AV88IsAuthorized_PagoSaldo = GXt_boolean5;
         AssignAttri("", false, "AV88IsAuthorized_PagoSaldo", AV88IsAuthorized_PagoSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PAGOSALDO", GetSecureSignedToken( "", AV88IsAuthorized_PagoSaldo, context));
         GXt_boolean5 = AV89IsAuthorized_CobroSaldo;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "OperacionWP", out  GXt_boolean5) ;
         AV89IsAuthorized_CobroSaldo = GXt_boolean5;
         AssignAttri("", false, "AV89IsAuthorized_CobroSaldo", AV89IsAuthorized_CobroSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COBROSALDO", GetSecureSignedToken( "", AV89IsAuthorized_CobroSaldo, context));
         GXt_boolean5 = AV77TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet_Insert", out  GXt_boolean5) ;
         AV77TempBoolean = GXt_boolean5;
         if ( ! ( AV77TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6 = AV41ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WalletWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV44TFWalletId = 0;
         AssignAttri("", false, "AV44TFWalletId", StringUtil.LTrimStr( (decimal)(AV44TFWalletId), 18, 0));
         AV45TFWalletId_To = 0;
         AssignAttri("", false, "AV45TFWalletId_To", StringUtil.LTrimStr( (decimal)(AV45TFWalletId_To), 18, 0));
         AV54TFWalletCodRefencia = "";
         AssignAttri("", false, "AV54TFWalletCodRefencia", AV54TFWalletCodRefencia);
         AV55TFWalletCodRefencia_Sel = "";
         AssignAttri("", false, "AV55TFWalletCodRefencia_Sel", AV55TFWalletCodRefencia_Sel);
         AV79TFWalletNombre = "";
         AssignAttri("", false, "AV79TFWalletNombre", AV79TFWalletNombre);
         AV80TFWalletNombre_Sel = "";
         AssignAttri("", false, "AV80TFWalletNombre_Sel", AV80TFWalletNombre_Sel);
         AV81TFMonedaISOSimbolo = "";
         AssignAttri("", false, "AV81TFMonedaISOSimbolo", AV81TFMonedaISOSimbolo);
         AV82TFMonedaISOSimbolo_Sel = "";
         AssignAttri("", false, "AV82TFMonedaISOSimbolo_Sel", AV82TFMonedaISOSimbolo_Sel);
         AV62TFWalletSaldo = 0;
         AssignAttri("", false, "AV62TFWalletSaldo", StringUtil.LTrimStr( AV62TFWalletSaldo, 18, 2));
         AV63TFWalletSaldo_To = 0;
         AssignAttri("", false, "AV63TFWalletSaldo_To", StringUtil.LTrimStr( AV63TFWalletSaldo_To, 18, 2));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S202( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "walletview.aspx"+UrlEncode(StringUtil.LTrimStr(A637WalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("walletview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wallet.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A637WalletId,18,0));
         CallWebObject(formatLink("wallet.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO ACREDITAR' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("NCR")) + "," + UrlEncode(StringUtil.LTrimStr(A637WalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(A715WalletNombre)) + "," + UrlEncode(StringUtil.LTrimStr(AV90OperacionesId,18,0));
         CallWebObject(formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S232( )
      {
         /* 'DO DEBITAR' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("NDE")) + "," + UrlEncode(StringUtil.LTrimStr(A637WalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(A715WalletNombre)) + "," + UrlEncode(StringUtil.LTrimStr(AV90OperacionesId,18,0));
         CallWebObject(formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S242( )
      {
         /* 'DO PAGOSALDO' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("POL")) + "," + UrlEncode(StringUtil.LTrimStr(AV91WalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(A715WalletNombre)) + "," + UrlEncode(StringUtil.LTrimStr(AV92OperacionId,18,0));
         CallWebObject(formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S252( )
      {
         /* 'DO COBROSALDO' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("COL")) + "," + UrlEncode(StringUtil.LTrimStr(AV91WalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(A715WalletNombre)) + "," + UrlEncode(StringUtil.LTrimStr(AV92OperacionId,18,0));
         CallWebObject(formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV93Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV93Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV40Session.Get(AV93Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV105GXV1 = 1;
         while ( AV105GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV105GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWALLETID") == 0 )
            {
               AV44TFWalletId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFWalletId", StringUtil.LTrimStr( (decimal)(AV44TFWalletId), 18, 0));
               AV45TFWalletId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFWalletId_To", StringUtil.LTrimStr( (decimal)(AV45TFWalletId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWALLETCODREFENCIA") == 0 )
            {
               AV54TFWalletCodRefencia = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFWalletCodRefencia", AV54TFWalletCodRefencia);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWALLETCODREFENCIA_SEL") == 0 )
            {
               AV55TFWalletCodRefencia_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFWalletCodRefencia_Sel", AV55TFWalletCodRefencia_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWALLETNOMBRE") == 0 )
            {
               AV79TFWalletNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV79TFWalletNombre", AV79TFWalletNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWALLETNOMBRE_SEL") == 0 )
            {
               AV80TFWalletNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV80TFWalletNombre_Sel", AV80TFWalletNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO") == 0 )
            {
               AV81TFMonedaISOSimbolo = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV81TFMonedaISOSimbolo", AV81TFMonedaISOSimbolo);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO_SEL") == 0 )
            {
               AV82TFMonedaISOSimbolo_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV82TFMonedaISOSimbolo_Sel", AV82TFMonedaISOSimbolo_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWALLETSALDO") == 0 )
            {
               AV62TFWalletSaldo = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV62TFWalletSaldo", StringUtil.LTrimStr( AV62TFWalletSaldo, 18, 2));
               AV63TFWalletSaldo_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV63TFWalletSaldo_To", StringUtil.LTrimStr( AV63TFWalletSaldo_To, 18, 2));
            }
            AV105GXV1 = (int)(AV105GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFWalletCodRefencia_Sel)),  AV55TFWalletCodRefencia_Sel, out  GXt_char2) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV80TFWalletNombre_Sel)),  AV80TFWalletNombre_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV82TFMonedaISOSimbolo_Sel)),  AV82TFMonedaISOSimbolo_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char7+"|"+GXt_char8+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFWalletCodRefencia)),  AV54TFWalletCodRefencia, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV79TFWalletNombre)),  AV79TFWalletNombre, out  GXt_char7) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV81TFMonedaISOSimbolo)),  AV81TFMonedaISOSimbolo, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((0==AV44TFWalletId) ? "" : StringUtil.Str( (decimal)(AV44TFWalletId), 18, 0))+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char2+"|"+((Convert.ToDecimal(0)==AV62TFWalletSaldo) ? "" : StringUtil.Str( AV62TFWalletSaldo, 18, 2))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV45TFWalletId_To) ? "" : StringUtil.Str( (decimal)(AV45TFWalletId_To), 18, 0))+"||||"+((Convert.ToDecimal(0)==AV63TFWalletSaldo_To) ? "" : StringUtil.Str( AV63TFWalletSaldo_To, 18, 2))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV40Session.Get(AV93Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFWALLETID",  context.GetMessage( "Id", ""),  !((0==AV44TFWalletId)&&(0==AV45TFWalletId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFWalletId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV45TFWalletId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFWALLETCODREFENCIA",  context.GetMessage( "Código de Refencia", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFWalletCodRefencia)),  0,  AV54TFWalletCodRefencia,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFWalletCodRefencia_Sel)),  AV55TFWalletCodRefencia_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFWALLETNOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV79TFWalletNombre)),  0,  AV79TFWalletNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV80TFWalletNombre_Sel)),  AV80TFWalletNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMONEDAISOSIMBOLO",  context.GetMessage( "Moneda", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV81TFMonedaISOSimbolo)),  0,  AV81TFMonedaISOSimbolo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV82TFMonedaISOSimbolo_Sel)),  AV82TFMonedaISOSimbolo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFWALLETSALDO",  context.GetMessage( "Saldo", ""),  !((Convert.ToDecimal(0)==AV62TFWalletSaldo)&&(Convert.ToDecimal(0)==AV63TFWalletSaldo_To)),  0,  StringUtil.Trim( StringUtil.Str( AV62TFWalletSaldo, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV63TFWalletSaldo_To, 18, 2))) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV93Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV93Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Wallet";
         AV40Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S262( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new walletwwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
         if ( StringUtil.StrCmp(AV34ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV34ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV35ErrorMessage);
         }
      }

      protected void S272( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("walletwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_AP2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV41ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_30_AP2( true) ;
         }
         else
         {
            wb_table2_30_AP2( false) ;
         }
         return  ;
      }

      protected void wb_table2_30_AP2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_AP2e( true) ;
         }
         else
         {
            wb_table1_25_AP2e( false) ;
         }
      }

      protected void wb_table2_30_AP2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WalletWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_30_AP2e( true) ;
         }
         else
         {
            wb_table2_30_AP2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PAAP2( ) ;
         WSAP2( ) ;
         WEAP2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269282144368", true, true, false);
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
         context.AddJavascriptSource("walletww.js", "?20269282144369", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_432( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_43_idx;
         edtWalletId_Internalname = "WALLETID_"+sGXsfl_43_idx;
         edtTipoCuentaId_Internalname = "TIPOCUENTAID_"+sGXsfl_43_idx;
         cmbTipoCuentaConcepto_Internalname = "TIPOCUENTACONCEPTO_"+sGXsfl_43_idx;
         edtTipoCuentaNombre_Internalname = "TIPOCUENTANOMBRE_"+sGXsfl_43_idx;
         cmbWalletTipoEntidad_Internalname = "WALLETTIPOENTIDAD_"+sGXsfl_43_idx;
         edtWalletCodRefencia_Internalname = "WALLETCODREFENCIA_"+sGXsfl_43_idx;
         edtWalletNombre_Internalname = "WALLETNOMBRE_"+sGXsfl_43_idx;
         edtMonedaId_Internalname = "MONEDAID_"+sGXsfl_43_idx;
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO_"+sGXsfl_43_idx;
         edtWalletSaldo_Internalname = "WALLETSALDO_"+sGXsfl_43_idx;
         edtavOperacionid_Internalname = "vOPERACIONID_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_43_fel_idx;
         edtWalletId_Internalname = "WALLETID_"+sGXsfl_43_fel_idx;
         edtTipoCuentaId_Internalname = "TIPOCUENTAID_"+sGXsfl_43_fel_idx;
         cmbTipoCuentaConcepto_Internalname = "TIPOCUENTACONCEPTO_"+sGXsfl_43_fel_idx;
         edtTipoCuentaNombre_Internalname = "TIPOCUENTANOMBRE_"+sGXsfl_43_fel_idx;
         cmbWalletTipoEntidad_Internalname = "WALLETTIPOENTIDAD_"+sGXsfl_43_fel_idx;
         edtWalletCodRefencia_Internalname = "WALLETCODREFENCIA_"+sGXsfl_43_fel_idx;
         edtWalletNombre_Internalname = "WALLETNOMBRE_"+sGXsfl_43_fel_idx;
         edtMonedaId_Internalname = "MONEDAID_"+sGXsfl_43_fel_idx;
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO_"+sGXsfl_43_fel_idx;
         edtWalletSaldo_Internalname = "WALLETSALDO_"+sGXsfl_43_fel_idx;
         edtavOperacionid_Internalname = "vOPERACIONID_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         WBAP0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_43_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_43_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_43_idx + "',43)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_43_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV71GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV71GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV71GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV71GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_43_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV71GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWalletId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWalletId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoCuentaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A483TipoCuentaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A483TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoCuentaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            GXCCtl = "TIPOCUENTACONCEPTO_" + sGXsfl_43_idx;
            cmbTipoCuentaConcepto.Name = GXCCtl;
            cmbTipoCuentaConcepto.WebTags = "";
            cmbTipoCuentaConcepto.addItem("SAL", context.GetMessage( "Saldo por Cuentas", ""), 0);
            cmbTipoCuentaConcepto.addItem("COS", context.GetMessage( "Usada En Centro Costo", ""), 0);
            cmbTipoCuentaConcepto.addItem("OTR", context.GetMessage( "Otros", ""), 0);
            if ( cmbTipoCuentaConcepto.ItemCount > 0 )
            {
               A636TipoCuentaConcepto = cmbTipoCuentaConcepto.getValidValue(A636TipoCuentaConcepto);
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTipoCuentaConcepto,(string)cmbTipoCuentaConcepto_Internalname,StringUtil.RTrim( A636TipoCuentaConcepto),(short)1,(string)cmbTipoCuentaConcepto_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTipoCuentaConcepto.CurrentValue = StringUtil.RTrim( A636TipoCuentaConcepto);
            AssignProp("", false, cmbTipoCuentaConcepto_Internalname, "Values", (string)(cmbTipoCuentaConcepto.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoCuentaNombre_Internalname,StringUtil.RTrim( A484TipoCuentaNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoCuentaNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"NombreLargo",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbWalletTipoEntidad.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WALLETTIPOENTIDAD_" + sGXsfl_43_idx;
               cmbWalletTipoEntidad.Name = GXCCtl;
               cmbWalletTipoEntidad.WebTags = "";
               cmbWalletTipoEntidad.addItem("CLI", context.GetMessage( "Clientes", ""), 0);
               cmbWalletTipoEntidad.addItem("COM", context.GetMessage( "Comercios", ""), 0);
               cmbWalletTipoEntidad.addItem("PRO", context.GetMessage( "Profesionales", ""), 0);
               cmbWalletTipoEntidad.addItem("EMP", context.GetMessage( "Empleados", ""), 0);
               cmbWalletTipoEntidad.addItem("OTR", context.GetMessage( "Otros", ""), 0);
               if ( cmbWalletTipoEntidad.ItemCount > 0 )
               {
                  A638WalletTipoEntidad = cmbWalletTipoEntidad.getValidValue(A638WalletTipoEntidad);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWalletTipoEntidad,(string)cmbWalletTipoEntidad_Internalname,StringUtil.RTrim( A638WalletTipoEntidad),(short)1,(string)cmbWalletTipoEntidad_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWalletTipoEntidad.CurrentValue = StringUtil.RTrim( A638WalletTipoEntidad);
            AssignProp("", false, cmbWalletTipoEntidad_Internalname, "Values", (string)(cmbWalletTipoEntidad.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWalletCodRefencia_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletCodRefencia_Internalname,StringUtil.RTrim( A639WalletCodRefencia),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletCodRefencia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWalletCodRefencia_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWalletNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletNombre_Internalname,StringUtil.RTrim( A715WalletNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWalletNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonedaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A118MonedaId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonedaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMonedaISOSimbolo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonedaISOSimbolo_Internalname,StringUtil.RTrim( A119MonedaISOSimbolo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonedaISOSimbolo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMonedaISOSimbolo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"MonISO",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWalletSaldo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWalletSaldo_Internalname,StringUtil.LTrim( StringUtil.NToC( A648WalletSaldo, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A648WalletSaldo, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWalletSaldo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtWalletSaldo_Columnclass,(string)edtWalletSaldo_Columnheaderclass,(int)edtWalletSaldo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtavOperacionid_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavOperacionid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV92OperacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavOperacionid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV92OperacionId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV92OperacionId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",context.GetMessage( "Ultima Liquidación Realizada", ""),(string)edtavOperacionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavOperacionid_Visible,(int)edtavOperacionid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesAP2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_43_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV71GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV71GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV71GridActions), 4, 0));
         }
         GXCCtl = "TIPOCUENTACONCEPTO_" + sGXsfl_43_idx;
         cmbTipoCuentaConcepto.Name = GXCCtl;
         cmbTipoCuentaConcepto.WebTags = "";
         cmbTipoCuentaConcepto.addItem("SAL", context.GetMessage( "Saldo por Cuentas", ""), 0);
         cmbTipoCuentaConcepto.addItem("COS", context.GetMessage( "Usada En Centro Costo", ""), 0);
         cmbTipoCuentaConcepto.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         if ( cmbTipoCuentaConcepto.ItemCount > 0 )
         {
            A636TipoCuentaConcepto = cmbTipoCuentaConcepto.getValidValue(A636TipoCuentaConcepto);
         }
         GXCCtl = "WALLETTIPOENTIDAD_" + sGXsfl_43_idx;
         cmbWalletTipoEntidad.Name = GXCCtl;
         cmbWalletTipoEntidad.WebTags = "";
         cmbWalletTipoEntidad.addItem("CLI", context.GetMessage( "Clientes", ""), 0);
         cmbWalletTipoEntidad.addItem("COM", context.GetMessage( "Comercios", ""), 0);
         cmbWalletTipoEntidad.addItem("PRO", context.GetMessage( "Profesionales", ""), 0);
         cmbWalletTipoEntidad.addItem("EMP", context.GetMessage( "Empleados", ""), 0);
         cmbWalletTipoEntidad.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         if ( cmbWalletTipoEntidad.ItemCount > 0 )
         {
            A638WalletTipoEntidad = cmbWalletTipoEntidad.getValidValue(A638WalletTipoEntidad);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl43( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"43\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWalletId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWalletCodRefencia_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código de Refencia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWalletNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMonedaISOSimbolo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Moneda", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWalletSaldo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Saldo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavOperacionid_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Liquidación", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A637WalletId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A483TipoCuentaId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A636TipoCuentaConcepto)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A484TipoCuentaNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A638WalletTipoEntidad)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A639WalletCodRefencia)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletCodRefencia_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A715WalletNombre)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A119MonedaISOSimbolo)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaISOSimbolo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A648WalletSaldo, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtWalletSaldo_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtWalletSaldo_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWalletSaldo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV92OperacionId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOperacionid_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOperacionid_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnliquidaciones_Internalname = "BTNLIQUIDACIONES";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtWalletId_Internalname = "WALLETID";
         edtTipoCuentaId_Internalname = "TIPOCUENTAID";
         cmbTipoCuentaConcepto_Internalname = "TIPOCUENTACONCEPTO";
         edtTipoCuentaNombre_Internalname = "TIPOCUENTANOMBRE";
         cmbWalletTipoEntidad_Internalname = "WALLETTIPOENTIDAD";
         edtWalletCodRefencia_Internalname = "WALLETCODREFENCIA";
         edtWalletNombre_Internalname = "WALLETNOMBRE";
         edtMonedaId_Internalname = "MONEDAID";
         edtMonedaISOSimbolo_Internalname = "MONEDAISOSIMBOLO";
         edtWalletSaldo_Internalname = "WALLETSALDO";
         edtavOperacionid_Internalname = "vOPERACIONID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavOperacionid_Jsonclick = "";
         edtavOperacionid_Enabled = 1;
         edtWalletSaldo_Jsonclick = "";
         edtWalletSaldo_Columnclass = "WWColumn";
         edtMonedaISOSimbolo_Jsonclick = "";
         edtMonedaId_Jsonclick = "";
         edtWalletNombre_Jsonclick = "";
         edtWalletCodRefencia_Jsonclick = "";
         cmbWalletTipoEntidad_Jsonclick = "";
         edtTipoCuentaNombre_Jsonclick = "";
         cmbTipoCuentaConcepto_Jsonclick = "";
         edtTipoCuentaId_Jsonclick = "";
         edtWalletId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtWalletSaldo_Columnheaderclass = "";
         edtavOperacionid_Visible = -1;
         edtWalletSaldo_Visible = -1;
         edtMonedaISOSimbolo_Visible = -1;
         edtWalletNombre_Visible = -1;
         edtWalletCodRefencia_Visible = -1;
         edtWalletId_Visible = -1;
         edtWalletSaldo_Enabled = 0;
         edtMonedaISOSimbolo_Enabled = 0;
         edtMonedaId_Enabled = 0;
         edtWalletNombre_Enabled = 0;
         edtWalletCodRefencia_Enabled = 0;
         cmbWalletTipoEntidad.Enabled = 0;
         edtTipoCuentaNombre_Enabled = 0;
         cmbTipoCuentaConcepto.Enabled = 0;
         edtTipoCuentaId_Enabled = 0;
         edtWalletId_Enabled = 0;
         subGrid_Sortable = 0;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "18.0||||-18.2|";
         Ddo_grid_Datalistproc = "WalletWWGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic||";
         Ddo_grid_Includedatalist = "|T|T|T||";
         Ddo_grid_Filterisrange = "T||||T|";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Numeric|";
         Ddo_grid_Includefilter = "T|T|T|T|T|";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T||T||";
         Ddo_grid_Columnssortvalues = "1|2||3||";
         Ddo_grid_Columnids = "1:WalletId|6:WalletCodRefencia|7:WalletNombre|9:MonedaISOSimbolo|10:WalletSaldo|11:OperacionId";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " Saldos y Cuentas", "");
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV44TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV93Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV55TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV79TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV80TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV81TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV82TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV62TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV63TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV90OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV91WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtWalletId_Visible',ctrl:'WALLETID',prop:'Visible'},{av:'edtWalletCodRefencia_Visible',ctrl:'WALLETCODREFENCIA',prop:'Visible'},{av:'edtWalletNombre_Visible',ctrl:'WALLETNOMBRE',prop:'Visible'},{av:'edtMonedaISOSimbolo_Visible',ctrl:'MONEDAISOSIMBOLO',prop:'Visible'},{av:'edtWalletSaldo_Visible',ctrl:'WALLETSALDO',prop:'Visible'},{av:'edtavOperacionid_Visible',ctrl:'vOPERACIONID',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'edtWalletSaldo_Columnheaderclass',ctrl:'WALLETSALDO',prop:'Columnheaderclass'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12AP2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV44TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV93Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV55TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV79TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV80TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV81TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV82TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV62TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV63TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV90OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV91WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtWalletId_Visible',ctrl:'WALLETID',prop:'Visible'},{av:'edtWalletCodRefencia_Visible',ctrl:'WALLETCODREFENCIA',prop:'Visible'},{av:'edtWalletNombre_Visible',ctrl:'WALLETNOMBRE',prop:'Visible'},{av:'edtMonedaISOSimbolo_Visible',ctrl:'MONEDAISOSIMBOLO',prop:'Visible'},{av:'edtWalletSaldo_Visible',ctrl:'WALLETSALDO',prop:'Visible'},{av:'edtavOperacionid_Visible',ctrl:'vOPERACIONID',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'edtWalletSaldo_Columnheaderclass',ctrl:'WALLETSALDO',prop:'Columnheaderclass'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13AP2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV44TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV93Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV55TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV79TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV80TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV81TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV82TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV62TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV63TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV90OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV91WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E15AP2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV44TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV93Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV55TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV79TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV80TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV81TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV82TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV62TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV63TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV90OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV91WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV44TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV55TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV79TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV80TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV81TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV82TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV62TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV63TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E21AP2',iparms:[{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'A648WalletSaldo',fld:'WALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A637WalletId',fld:'WALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV71GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtWalletSaldo_Columnclass',ctrl:'WALLETSALDO',prop:'Columnclass'},{av:'AV92OperacionId',fld:'vOPERACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E16AP2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV44TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV93Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV55TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV79TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV80TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV81TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV82TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV62TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV63TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV90OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV91WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'edtWalletId_Visible',ctrl:'WALLETID',prop:'Visible'},{av:'edtWalletCodRefencia_Visible',ctrl:'WALLETCODREFENCIA',prop:'Visible'},{av:'edtWalletNombre_Visible',ctrl:'WALLETNOMBRE',prop:'Visible'},{av:'edtMonedaISOSimbolo_Visible',ctrl:'MONEDAISOSIMBOLO',prop:'Visible'},{av:'edtWalletSaldo_Visible',ctrl:'WALLETSALDO',prop:'Visible'},{av:'edtavOperacionid_Visible',ctrl:'vOPERACIONID',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'edtWalletSaldo_Columnheaderclass',ctrl:'WALLETSALDO',prop:'Columnheaderclass'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11AP2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV44TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV93Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV55TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV79TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV80TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV81TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV82TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV62TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV63TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV90OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV91WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV55TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV79TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV80TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV81TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV82TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV62TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV63TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtWalletId_Visible',ctrl:'WALLETID',prop:'Visible'},{av:'edtWalletCodRefencia_Visible',ctrl:'WALLETCODREFENCIA',prop:'Visible'},{av:'edtWalletNombre_Visible',ctrl:'WALLETNOMBRE',prop:'Visible'},{av:'edtMonedaISOSimbolo_Visible',ctrl:'MONEDAISOSIMBOLO',prop:'Visible'},{av:'edtWalletSaldo_Visible',ctrl:'WALLETSALDO',prop:'Visible'},{av:'edtavOperacionid_Visible',ctrl:'vOPERACIONID',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'edtWalletSaldo_Columnheaderclass',ctrl:'WALLETSALDO',prop:'Columnheaderclass'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E22AP2',iparms:[{av:'cmbavGridactions'},{av:'AV71GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A637WalletId',fld:'WALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A715WalletNombre',fld:'WALLETNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV90OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV91WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV92OperacionId',fld:'vOPERACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV71GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E17AP2',iparms:[{av:'A637WalletId',fld:'WALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14AP2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV93Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV55TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV80TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV82TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV44TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV79TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV81TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV62TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV63TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV90OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV91WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV44TFWalletId',fld:'vTFWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFWalletId_To',fld:'vTFWALLETID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV93Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV54TFWalletCodRefencia',fld:'vTFWALLETCODREFENCIA',pic:'',type:'char'},{av:'AV55TFWalletCodRefencia_Sel',fld:'vTFWALLETCODREFENCIA_SEL',pic:'',type:'char'},{av:'AV79TFWalletNombre',fld:'vTFWALLETNOMBRE',pic:'',type:'char'},{av:'AV80TFWalletNombre_Sel',fld:'vTFWALLETNOMBRE_SEL',pic:'',type:'char'},{av:'AV81TFMonedaISOSimbolo',fld:'vTFMONEDAISOSIMBOLO',pic:'',type:'char'},{av:'AV82TFMonedaISOSimbolo_Sel',fld:'vTFMONEDAISOSIMBOLO_SEL',pic:'',type:'char'},{av:'AV62TFWalletSaldo',fld:'vTFWALLETSALDO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV63TFWalletSaldo_To',fld:'vTFWALLETSALDO_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV73IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV85IsAuthorized_Acreditar',fld:'vISAUTHORIZED_ACREDITAR',pic:'',hsh:true,type:'boolean'},{av:'AV86IsAuthorized_Debitar',fld:'vISAUTHORIZED_DEBITAR',pic:'',hsh:true,type:'boolean'},{av:'AV88IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV89IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV90OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV91WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'edtWalletId_Visible',ctrl:'WALLETID',prop:'Visible'},{av:'edtWalletCodRefencia_Visible',ctrl:'WALLETCODREFENCIA',prop:'Visible'},{av:'edtWalletNombre_Visible',ctrl:'WALLETNOMBRE',prop:'Visible'},{av:'edtMonedaISOSimbolo_Visible',ctrl:'MONEDAISOSIMBOLO',prop:'Visible'},{av:'edtWalletSaldo_Visible',ctrl:'WALLETSALDO',prop:'Visible'},{av:'edtavOperacionid_Visible',ctrl:'vOPERACIONID',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'edtWalletSaldo_Columnheaderclass',ctrl:'WALLETSALDO',prop:'Columnheaderclass'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOLIQUIDACIONES'","{handler:'E18AP2',iparms:[]");
         setEventMetadata("'DOLIQUIDACIONES'",",oparms:[]}");
         setEventMetadata("VALID_WALLETID","{handler:'Valid_Walletid',iparms:[]");
         setEventMetadata("VALID_WALLETID",",oparms:[]}");
         setEventMetadata("VALID_TIPOCUENTAID","{handler:'Valid_Tipocuentaid',iparms:[]");
         setEventMetadata("VALID_TIPOCUENTAID",",oparms:[]}");
         setEventMetadata("VALID_WALLETTIPOENTIDAD","{handler:'Valid_Wallettipoentidad',iparms:[]");
         setEventMetadata("VALID_WALLETTIPOENTIDAD",",oparms:[]}");
         setEventMetadata("VALID_WALLETCODREFENCIA","{handler:'Valid_Walletcodrefencia',iparms:[]");
         setEventMetadata("VALID_WALLETCODREFENCIA",",oparms:[]}");
         setEventMetadata("VALID_WALLETNOMBRE","{handler:'Valid_Walletnombre',iparms:[]");
         setEventMetadata("VALID_WALLETNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_MONEDAID","{handler:'Valid_Monedaid',iparms:[]");
         setEventMetadata("VALID_MONEDAID",",oparms:[]}");
         setEventMetadata("VALID_MONEDAISOSIMBOLO","{handler:'Valid_Monedaisosimbolo',iparms:[]");
         setEventMetadata("VALID_MONEDAISOSIMBOLO",",oparms:[]}");
         setEventMetadata("VALID_WALLETSALDO","{handler:'Valid_Walletsaldo',iparms:[]");
         setEventMetadata("VALID_WALLETSALDO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Operacionid',iparms:[]");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV44TFWalletId = 0;
         AV45TFWalletId_To = 0;
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV93Pgmname = "";
         AV17FilterFullText = "";
         AV54TFWalletCodRefencia = "";
         AV55TFWalletCodRefencia_Sel = "";
         AV79TFWalletNombre = "";
         AV80TFWalletNombre_Sel = "";
         AV81TFMonedaISOSimbolo = "";
         AV82TFMonedaISOSimbolo_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV70GridAppliedFilters = "";
         AV75AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV66DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnliquidaciones_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A636TipoCuentaConcepto = "";
         A484TipoCuentaNombre = "";
         A638WalletTipoEntidad = "";
         A639WalletCodRefencia = "";
         A715WalletNombre = "";
         A119MonedaISOSimbolo = "";
         AV94Walletwwds_1_filterfulltext = "";
         AV97Walletwwds_4_tfwalletcodrefencia = "";
         AV98Walletwwds_5_tfwalletcodrefencia_sel = "";
         AV99Walletwwds_6_tfwalletnombre = "";
         AV100Walletwwds_7_tfwalletnombre_sel = "";
         AV101Walletwwds_8_tfmonedaisosimbolo = "";
         AV102Walletwwds_9_tfmonedaisosimbolo_sel = "";
         lV97Walletwwds_4_tfwalletcodrefencia = "";
         lV101Walletwwds_8_tfmonedaisosimbolo = "";
         H00AP2_A119MonedaISOSimbolo = new string[] {""} ;
         H00AP2_A118MonedaId = new short[1] ;
         H00AP2_n118MonedaId = new bool[] {false} ;
         H00AP2_A484TipoCuentaNombre = new string[] {""} ;
         H00AP2_A636TipoCuentaConcepto = new string[] {""} ;
         H00AP2_A483TipoCuentaId = new long[1] ;
         H00AP2_A639WalletCodRefencia = new string[] {""} ;
         H00AP2_A638WalletTipoEntidad = new string[] {""} ;
         H00AP2_A637WalletId = new long[1] ;
         H00AP3_A119MonedaISOSimbolo = new string[] {""} ;
         H00AP3_A118MonedaId = new short[1] ;
         H00AP3_n118MonedaId = new bool[] {false} ;
         H00AP3_A484TipoCuentaNombre = new string[] {""} ;
         H00AP3_A636TipoCuentaConcepto = new string[] {""} ;
         H00AP3_A483TipoCuentaId = new long[1] ;
         H00AP3_A639WalletCodRefencia = new string[] {""} ;
         H00AP3_A638WalletTipoEntidad = new string[] {""} ;
         H00AP3_A637WalletId = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV76AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV42ManageFiltersXml = "";
         AV37UserCustomValue = "";
         AV39ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char2 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV34ExcelFilename = "";
         AV35ErrorMessage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.walletww__default(),
            new Object[][] {
                new Object[] {
               H00AP2_A119MonedaISOSimbolo, H00AP2_A118MonedaId, H00AP2_n118MonedaId, H00AP2_A484TipoCuentaNombre, H00AP2_A636TipoCuentaConcepto, H00AP2_A483TipoCuentaId, H00AP2_A639WalletCodRefencia, H00AP2_A638WalletTipoEntidad, H00AP2_A637WalletId
               }
               , new Object[] {
               H00AP3_A119MonedaISOSimbolo, H00AP3_A118MonedaId, H00AP3_n118MonedaId, H00AP3_A484TipoCuentaNombre, H00AP3_A636TipoCuentaConcepto, H00AP3_A483TipoCuentaId, H00AP3_A639WalletCodRefencia, H00AP3_A638WalletTipoEntidad, H00AP3_A637WalletId
               }
            }
         );
         AV93Pgmname = "WalletWW";
         /* GeneXus formulas. */
         AV93Pgmname = "WalletWW";
         edtavOperacionid_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV43ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV71GridActions ;
      private short A118MonedaId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int subGrid_Islastpage ;
      private int edtavOperacionid_Enabled ;
      private int edtWalletId_Enabled ;
      private int edtTipoCuentaId_Enabled ;
      private int edtTipoCuentaNombre_Enabled ;
      private int edtWalletCodRefencia_Enabled ;
      private int edtWalletNombre_Enabled ;
      private int edtMonedaId_Enabled ;
      private int edtMonedaISOSimbolo_Enabled ;
      private int edtWalletSaldo_Enabled ;
      private int edtWalletId_Visible ;
      private int edtWalletCodRefencia_Visible ;
      private int edtWalletNombre_Visible ;
      private int edtMonedaISOSimbolo_Visible ;
      private int edtWalletSaldo_Visible ;
      private int edtavOperacionid_Visible ;
      private int AV67PageToGo ;
      private int AV105GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV44TFWalletId ;
      private long AV45TFWalletId_To ;
      private long AV90OperacionesId ;
      private long AV91WalletId ;
      private long AV68GridCurrentPage ;
      private long AV69GridPageCount ;
      private long A637WalletId ;
      private long A483TipoCuentaId ;
      private long AV92OperacionId ;
      private long GRID_nCurrentRecord ;
      private long AV95Walletwwds_2_tfwalletid ;
      private long AV96Walletwwds_3_tfwalletid_to ;
      private long GRID_nRecordCount ;
      private long GXt_int4 ;
      private decimal AV62TFWalletSaldo ;
      private decimal AV63TFWalletSaldo_To ;
      private decimal A646WalletTotalDebito ;
      private decimal A647WalletTotalCredito ;
      private decimal A648WalletSaldo ;
      private decimal AV103Walletwwds_10_tfwalletsaldo ;
      private decimal AV104Walletwwds_11_tfwalletsaldo_to ;
      private decimal GXt_decimal1 ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_43_idx="0001" ;
      private string AV93Pgmname ;
      private string AV54TFWalletCodRefencia ;
      private string AV55TFWalletCodRefencia_Sel ;
      private string AV79TFWalletNombre ;
      private string AV80TFWalletNombre_Sel ;
      private string AV81TFMonedaISOSimbolo ;
      private string AV82TFMonedaISOSimbolo_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnliquidaciones_Internalname ;
      private string bttBtnliquidaciones_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtWalletId_Internalname ;
      private string edtTipoCuentaId_Internalname ;
      private string cmbTipoCuentaConcepto_Internalname ;
      private string A636TipoCuentaConcepto ;
      private string A484TipoCuentaNombre ;
      private string edtTipoCuentaNombre_Internalname ;
      private string cmbWalletTipoEntidad_Internalname ;
      private string A638WalletTipoEntidad ;
      private string A639WalletCodRefencia ;
      private string edtWalletCodRefencia_Internalname ;
      private string A715WalletNombre ;
      private string edtWalletNombre_Internalname ;
      private string edtMonedaId_Internalname ;
      private string A119MonedaISOSimbolo ;
      private string edtMonedaISOSimbolo_Internalname ;
      private string edtWalletSaldo_Internalname ;
      private string edtavOperacionid_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string AV97Walletwwds_4_tfwalletcodrefencia ;
      private string AV98Walletwwds_5_tfwalletcodrefencia_sel ;
      private string AV99Walletwwds_6_tfwalletnombre ;
      private string AV100Walletwwds_7_tfwalletnombre_sel ;
      private string AV101Walletwwds_8_tfmonedaisosimbolo ;
      private string AV102Walletwwds_9_tfmonedaisosimbolo_sel ;
      private string lV97Walletwwds_4_tfwalletcodrefencia ;
      private string lV101Walletwwds_8_tfmonedaisosimbolo ;
      private string edtWalletSaldo_Columnheaderclass ;
      private string edtWalletSaldo_Columnclass ;
      private string GXEncryptionTmp ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char2 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtWalletId_Jsonclick ;
      private string edtTipoCuentaId_Jsonclick ;
      private string cmbTipoCuentaConcepto_Jsonclick ;
      private string edtTipoCuentaNombre_Jsonclick ;
      private string cmbWalletTipoEntidad_Jsonclick ;
      private string edtWalletCodRefencia_Jsonclick ;
      private string edtWalletNombre_Jsonclick ;
      private string edtMonedaId_Jsonclick ;
      private string edtMonedaISOSimbolo_Jsonclick ;
      private string edtWalletSaldo_Jsonclick ;
      private string edtavOperacionid_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV73IsAuthorized_Update ;
      private bool AV85IsAuthorized_Acreditar ;
      private bool AV86IsAuthorized_Debitar ;
      private bool AV88IsAuthorized_PagoSaldo ;
      private bool AV89IsAuthorized_CobroSaldo ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n118MonedaId ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV77TempBoolean ;
      private bool GXt_boolean5 ;
      private string AV36ColumnsSelectorXML ;
      private string AV42ManageFiltersXml ;
      private string AV37UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV70GridAppliedFilters ;
      private string AV94Walletwwds_1_filterfulltext ;
      private string AV34ExcelFilename ;
      private string AV35ErrorMessage ;
      private IGxSession AV40Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbTipoCuentaConcepto ;
      private GXCombobox cmbWalletTipoEntidad ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV41ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV75AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV66DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H00AP2_A119MonedaISOSimbolo ;
      private short[] H00AP2_A118MonedaId ;
      private bool[] H00AP2_n118MonedaId ;
      private string[] H00AP2_A484TipoCuentaNombre ;
      private string[] H00AP2_A636TipoCuentaConcepto ;
      private long[] H00AP2_A483TipoCuentaId ;
      private string[] H00AP2_A639WalletCodRefencia ;
      private string[] H00AP2_A638WalletTipoEntidad ;
      private long[] H00AP2_A637WalletId ;
      private string[] H00AP3_A119MonedaISOSimbolo ;
      private short[] H00AP3_A118MonedaId ;
      private bool[] H00AP3_n118MonedaId ;
      private string[] H00AP3_A484TipoCuentaNombre ;
      private string[] H00AP3_A636TipoCuentaConcepto ;
      private long[] H00AP3_A483TipoCuentaId ;
      private string[] H00AP3_A639WalletCodRefencia ;
      private string[] H00AP3_A638WalletTipoEntidad ;
      private long[] H00AP3_A637WalletId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV76AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item6 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class walletww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00AP2( IGxContext context ,
                                             long AV95Walletwwds_2_tfwalletid ,
                                             long AV96Walletwwds_3_tfwalletid_to ,
                                             string AV98Walletwwds_5_tfwalletcodrefencia_sel ,
                                             string AV97Walletwwds_4_tfwalletcodrefencia ,
                                             string AV102Walletwwds_9_tfmonedaisosimbolo_sel ,
                                             string AV101Walletwwds_8_tfmonedaisosimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV94Walletwwds_1_filterfulltext ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV100Walletwwds_7_tfwalletnombre_sel ,
                                             string AV99Walletwwds_6_tfwalletnombre ,
                                             decimal AV103Walletwwds_10_tfwalletsaldo ,
                                             decimal AV104Walletwwds_11_tfwalletsaldo_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[6];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T2.[MonedaISOSimbolo], T1.[MonedaId], T3.[TipoCuentaNombre], T3.[TipoCuentaConcepto], T1.[TipoCuentaId], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM (([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId]) INNER JOIN [TipoCuenta] T3 ON T3.[TipoCuentaId] = T1.[TipoCuentaId])";
         if ( ! (0==AV95Walletwwds_2_tfwalletid) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV95Walletwwds_2_tfwalletid)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! (0==AV96Walletwwds_3_tfwalletid_to) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV96Walletwwds_3_tfwalletid_to)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Walletwwds_5_tfwalletcodrefencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Walletwwds_4_tfwalletcodrefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV97Walletwwds_4_tfwalletcodrefencia))");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Walletwwds_5_tfwalletcodrefencia_sel)) && ! ( StringUtil.StrCmp(AV98Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV98Walletwwds_5_tfwalletcodrefencia_sel)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( StringUtil.StrCmp(AV98Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Walletwwds_9_tfmonedaisosimbolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Walletwwds_8_tfmonedaisosimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV101Walletwwds_8_tfmonedaisosimbolo))");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Walletwwds_9_tfmonedaisosimbolo_sel)) && ! ( StringUtil.StrCmp(AV102Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV102Walletwwds_9_tfmonedaisosimbolo_sel)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV102Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] IS NULL or (T2.[MonedaISOSimbolo] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo] DESC";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H00AP3( IGxContext context ,
                                             long AV95Walletwwds_2_tfwalletid ,
                                             long AV96Walletwwds_3_tfwalletid_to ,
                                             string AV98Walletwwds_5_tfwalletcodrefencia_sel ,
                                             string AV97Walletwwds_4_tfwalletcodrefencia ,
                                             string AV102Walletwwds_9_tfmonedaisosimbolo_sel ,
                                             string AV101Walletwwds_8_tfmonedaisosimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV94Walletwwds_1_filterfulltext ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV100Walletwwds_7_tfwalletnombre_sel ,
                                             string AV99Walletwwds_6_tfwalletnombre ,
                                             decimal AV103Walletwwds_10_tfwalletsaldo ,
                                             decimal AV104Walletwwds_11_tfwalletsaldo_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[6];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T2.[MonedaISOSimbolo], T1.[MonedaId], T3.[TipoCuentaNombre], T3.[TipoCuentaConcepto], T1.[TipoCuentaId], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM (([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId]) INNER JOIN [TipoCuenta] T3 ON T3.[TipoCuentaId] = T1.[TipoCuentaId])";
         if ( ! (0==AV95Walletwwds_2_tfwalletid) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV95Walletwwds_2_tfwalletid)");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         if ( ! (0==AV96Walletwwds_3_tfwalletid_to) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV96Walletwwds_3_tfwalletid_to)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Walletwwds_5_tfwalletcodrefencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Walletwwds_4_tfwalletcodrefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV97Walletwwds_4_tfwalletcodrefencia))");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Walletwwds_5_tfwalletcodrefencia_sel)) && ! ( StringUtil.StrCmp(AV98Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV98Walletwwds_5_tfwalletcodrefencia_sel)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( StringUtil.StrCmp(AV98Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Walletwwds_9_tfmonedaisosimbolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Walletwwds_8_tfmonedaisosimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV101Walletwwds_8_tfmonedaisosimbolo))");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Walletwwds_9_tfmonedaisosimbolo_sel)) && ! ( StringUtil.StrCmp(AV102Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV102Walletwwds_9_tfmonedaisosimbolo_sel)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( StringUtil.StrCmp(AV102Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] IS NULL or (T2.[MonedaISOSimbolo] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo] DESC";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00AP2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] );
               case 1 :
                     return conditional_H00AP3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00AP2;
          prmH00AP2 = new Object[] {
          new ParDef("@AV95Walletwwds_2_tfwalletid",GXType.Decimal,18,0) ,
          new ParDef("@AV96Walletwwds_3_tfwalletid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV97Walletwwds_4_tfwalletcodrefencia",GXType.Char,25,0) ,
          new ParDef("@AV98Walletwwds_5_tfwalletcodrefencia_sel",GXType.NChar,25,0) ,
          new ParDef("@lV101Walletwwds_8_tfmonedaisosimbolo",GXType.Char,3,0) ,
          new ParDef("@AV102Walletwwds_9_tfmonedaisosimbolo_sel",GXType.NChar,3,0)
          };
          Object[] prmH00AP3;
          prmH00AP3 = new Object[] {
          new ParDef("@AV95Walletwwds_2_tfwalletid",GXType.Decimal,18,0) ,
          new ParDef("@AV96Walletwwds_3_tfwalletid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV97Walletwwds_4_tfwalletcodrefencia",GXType.Char,25,0) ,
          new ParDef("@AV98Walletwwds_5_tfwalletcodrefencia_sel",GXType.NChar,25,0) ,
          new ParDef("@lV101Walletwwds_8_tfmonedaisosimbolo",GXType.Char,3,0) ,
          new ParDef("@AV102Walletwwds_9_tfmonedaisosimbolo_sel",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00AP2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AP2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00AP3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AP3,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 120);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 25);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 120);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 25);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
