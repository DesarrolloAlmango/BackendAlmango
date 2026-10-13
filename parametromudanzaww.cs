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
   public class parametromudanzaww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public parametromudanzaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametromudanzaww( IGxContext context )
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavParametromudanzatipo1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavParametromudanzatipo2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavParametromudanzatipo3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbParametroMudanzaTipo = new GXCombobox();
         cmbParametroMudanzaUnidad = new GXCombobox();
         chkParametroMudanzaActivo = new GXCheckbox();
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
         nRC_GXsfl_184 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_184"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_184_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_184_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_184_idx = GetPar( "sGXsfl_184_idx");
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
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavParametromudanzatipo1.FromJSonString( GetNextPar( ));
         AV19ParametroMudanzaTipo1 = GetPar( "ParametroMudanzaTipo1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavParametromudanzatipo2.FromJSonString( GetNextPar( ));
         AV22ParametroMudanzaTipo2 = GetPar( "ParametroMudanzaTipo2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavParametromudanzatipo3.FromJSonString( GetNextPar( ));
         AV25ParametroMudanzaTipo3 = GetPar( "ParametroMudanzaTipo3");
         AV37ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV32ColumnsSelector);
         AV83Pgmname = GetPar( "Pgmname");
         AV17FilterFullText = GetPar( "FilterFullText");
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV38TFParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( GetPar( "TFParametroMudanzaId"), "."), 18, MidpointRounding.ToEven));
         AV39TFParametroMudanzaId_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFParametroMudanzaId_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41TFParametroMudanzaTipo_Sels);
         AV72TFParametroMudanzaTitulo = GetPar( "TFParametroMudanzaTitulo");
         AV73TFParametroMudanzaTitulo_Sel = GetPar( "TFParametroMudanzaTitulo_Sel");
         AV42TFParametroMudanzaNombre = GetPar( "TFParametroMudanzaNombre");
         AV43TFParametroMudanzaNombre_Sel = GetPar( "TFParametroMudanzaNombre_Sel");
         AV62TFParametroMudanzaDescripcion = GetPar( "TFParametroMudanzaDescripcion");
         AV63TFParametroMudanzaDescripcion_Sel = GetPar( "TFParametroMudanzaDescripcion_Sel");
         AV44TFParametroMudanzaValor = NumberUtil.Val( GetPar( "TFParametroMudanzaValor"), ".");
         AV45TFParametroMudanzaValor_To = NumberUtil.Val( GetPar( "TFParametroMudanzaValor_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV47TFParametroMudanzaUnidad_Sels);
         AV64TFParametroMudanzaPisoElev = (short)(Math.Round(NumberUtil.Val( GetPar( "TFParametroMudanzaPisoElev"), "."), 18, MidpointRounding.ToEven));
         AV65TFParametroMudanzaPisoElev_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFParametroMudanzaPisoElev_To"), "."), 18, MidpointRounding.ToEven));
         AV74TFParametroMudanzaActivo_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFParametroMudanzaActivo_Sel"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV27DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV26DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV55IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV56IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19ParametroMudanzaTipo1, AV21DynamicFiltersSelector2, AV22ParametroMudanzaTipo2, AV24DynamicFiltersSelector3, AV25ParametroMudanzaTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV83Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFParametroMudanzaId, AV39TFParametroMudanzaId_To, AV41TFParametroMudanzaTipo_Sels, AV72TFParametroMudanzaTitulo, AV73TFParametroMudanzaTitulo_Sel, AV42TFParametroMudanzaNombre, AV43TFParametroMudanzaNombre_Sel, AV62TFParametroMudanzaDescripcion, AV63TFParametroMudanzaDescripcion_Sel, AV44TFParametroMudanzaValor, AV45TFParametroMudanzaValor_To, AV47TFParametroMudanzaUnidad_Sels, AV64TFParametroMudanzaPisoElev, AV65TFParametroMudanzaPisoElev_To, AV74TFParametroMudanzaActivo_Sel, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV55IsAuthorized_Update, AV56IsAuthorized_Delete) ;
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
         PAFS2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTFS2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parametromudanzaww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV83Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV83Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vPARAMETROMUDANZATIPO1", AV19ParametroMudanzaTipo1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vPARAMETROMUDANZATIPO2", AV22ParametroMudanzaTipo2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vPARAMETROMUDANZATIPO3", AV25ParametroMudanzaTipo3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_184", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_184), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV52GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV57AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV57AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV48DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV48DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV32ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV32ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV83Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV83Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38TFParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZAID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39TFParametroMudanzaId_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPARAMETROMUDANZATIPO_SELS", AV41TFParametroMudanzaTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPARAMETROMUDANZATIPO_SELS", AV41TFParametroMudanzaTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZATITULO", AV72TFParametroMudanzaTitulo);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZATITULO_SEL", AV73TFParametroMudanzaTitulo_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZANOMBRE", AV42TFParametroMudanzaNombre);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZANOMBRE_SEL", AV43TFParametroMudanzaNombre_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZADESCRIPCION", AV62TFParametroMudanzaDescripcion);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZADESCRIPCION_SEL", AV63TFParametroMudanzaDescripcion_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZAVALOR", StringUtil.LTrim( StringUtil.NToC( AV44TFParametroMudanzaValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZAVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV45TFParametroMudanzaValor_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPARAMETROMUDANZAUNIDAD_SELS", AV47TFParametroMudanzaUnidad_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPARAMETROMUDANZAUNIDAD_SELS", AV47TFParametroMudanzaUnidad_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZAPISOELEV", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64TFParametroMudanzaPisoElev), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZAPISOELEV_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65TFParametroMudanzaPisoElev_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZAACTIVO_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV74TFParametroMudanzaActivo_Sel), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV27DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV26DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZATIPO_SELSJSON", AV40TFParametroMudanzaTipo_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROMUDANZAUNIDAD_SELSJSON", AV46TFParametroMudanzaUnidad_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
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
            WEFS2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTFS2( ) ;
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
         return formatLink("parametromudanzaww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ParametroMudanzaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Parametro Mudanza", "") ;
      }

      protected void WBFS0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellPaddingBottom", "start", "top", "", "", "div");
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(184), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(184), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(184), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(184), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_FS2( true) ;
         }
         else
         {
            wb_table1_25_FS2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_FS2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellAdvancedFiltersHidden", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedfilterscontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_184_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_ParametroMudanzaWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_FS2( true) ;
         }
         else
         {
            wb_table2_49_FS2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_FS2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_184_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_ParametroMudanzaWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_68_FS2( true) ;
         }
         else
         {
            wb_table3_68_FS2( false) ;
         }
         return  ;
      }

      protected void wb_table3_68_FS2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_184_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 0, "HLP_ParametroMudanzaWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_87_FS2( true) ;
         }
         else
         {
            wb_table4_87_FS2( false) ;
         }
         return  ;
      }

      protected void wb_table4_87_FS2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, context.GetMessage( "Embalaje/Elevación", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_ParametroMudanzaWW.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPrecioembmetro3_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPrecioembmetro3_Internalname, context.GetMessage( "$ Embajale x m3", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_184_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPrecioembmetro3_Internalname, StringUtil.LTrim( StringUtil.NToC( AV60PrecioEmbMetro3, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavPrecioembmetro3_Enabled!=0) ? context.localUtil.Format( AV60PrecioEmbMetro3, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV60PrecioEmbMetro3, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPrecioembmetro3_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPrecioembmetro3_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPrecioelevpiso_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPrecioelevpiso_Internalname, context.GetMessage( "$ Elevación x piso", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_184_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPrecioelevpiso_Internalname, StringUtil.LTrim( StringUtil.NToC( AV61PrecioElevPiso, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavPrecioelevpiso_Enabled!=0) ? context.localUtil.Format( AV61PrecioElevPiso, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV61PrecioElevPiso, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPrecioelevpiso_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPrecioelevpiso_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
            ClassString = "ButtonColorFilled";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(184), 3, 0)+","+"null"+");", context.GetMessage( "Aplicar", ""), bttBtnuseraction1_Jsonclick, 5, context.GetMessage( "Aplicar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, " ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup5_Internalname, context.GetMessage( "Precio Base Veh.", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_ParametroMudanzaWW.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPreciochico_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPreciochico_Internalname, context.GetMessage( "$/hora CHICO", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_184_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPreciochico_Internalname, StringUtil.LTrim( StringUtil.NToC( AV66PrecioChico, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavPreciochico_Enabled!=0) ? context.localUtil.Format( AV66PrecioChico, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV66PrecioChico, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPreciochico_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPreciochico_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPreciomediano_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPreciomediano_Internalname, context.GetMessage( "$/hora MEDIANO", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'" + sGXsfl_184_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPreciomediano_Internalname, StringUtil.LTrim( StringUtil.NToC( AV67PrecioMediano, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavPreciomediano_Enabled!=0) ? context.localUtil.Format( AV67PrecioMediano, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV67PrecioMediano, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,132);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPreciomediano_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPreciomediano_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPreciogrande_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPreciogrande_Internalname, context.GetMessage( "$/hora GRANDE", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'" + sGXsfl_184_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPreciogrande_Internalname, StringUtil.LTrim( StringUtil.NToC( AV68PrecioGrande, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavPreciogrande_Enabled!=0) ? context.localUtil.Format( AV68PrecioGrande, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV68PrecioGrande, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,137);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPreciogrande_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPreciogrande_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
            ClassString = "ButtonColorFilled";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction2_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(184), 3, 0)+","+"null"+");", context.GetMessage( "Aplicar", ""), bttBtnuseraction2_Jsonclick, 5, context.GetMessage( "Aplicar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION2\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, " ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup7_Internalname, context.GetMessage( "Precio Peón", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_ParametroMudanzaWW.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPreciopeon_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPreciopeon_Internalname, context.GetMessage( "$/hora Peón", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'" + sGXsfl_184_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPreciopeon_Internalname, StringUtil.LTrim( StringUtil.NToC( AV69PrecioPeon, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavPreciopeon_Enabled!=0) ? context.localUtil.Format( AV69PrecioPeon, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV69PrecioPeon, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPreciopeon_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavPreciopeon_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
            ClassString = "ButtonColorFilled";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction3_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(184), 3, 0)+","+"null"+");", context.GetMessage( "Aplicar", ""), bttBtnuseraction3_Jsonclick, 5, context.GetMessage( "Aplicar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION3\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup9_Internalname, context.GetMessage( "Tiempo x KM", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_ParametroMudanzaWW.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTiempokm_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTiempokm_Internalname, context.GetMessage( "1.33 (default)", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'" + sGXsfl_184_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTiempokm_Internalname, StringUtil.LTrim( StringUtil.NToC( AV70TiempoKm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavTiempokm_Enabled!=0) ? context.localUtil.Format( AV70TiempoKm, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV70TiempoKm, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTiempokm_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTiempokm_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
            ClassString = "ButtonColorFilled";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction4_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(184), 3, 0)+","+"null"+");", context.GetMessage( "Aplicar", ""), bttBtnuseraction4_Jsonclick, 5, context.GetMessage( "Aplicar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION4\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup11_Internalname, context.GetMessage( "Tiempo x M3", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_ParametroMudanzaWW.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTiempoxm3_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTiempoxm3_Internalname, context.GetMessage( "min/m3", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'" + sGXsfl_184_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTiempoxm3_Internalname, StringUtil.LTrim( StringUtil.NToC( AV71TiempoxM3, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavTiempoxm3_Enabled!=0) ? context.localUtil.Format( AV71TiempoxM3, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV71TiempoxM3, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTiempoxm3_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTiempoxm3_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
            ClassString = "ButtonColorFilled";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction5_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(184), 3, 0)+","+"null"+");", context.GetMessage( "Aplicar", ""), bttBtnuseraction5_Jsonclick, 5, context.GetMessage( "Aplicar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION5\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl184( ) ;
         }
         if ( wbEnd == 184 )
         {
            wbEnd = 0;
            nRC_GXsfl_184 = (int)(nGXsfl_184_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV50GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV51GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV52GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV57AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ParametroMudanzaWW.htm");
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
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV48DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV48DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV32ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0210"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0210"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_184_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0210"+"");
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
         if ( wbEnd == 184 )
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

      protected void STARTFS2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Parametro Mudanza", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPFS0( ) ;
      }

      protected void WSFS2( )
      {
         STARTFS2( ) ;
         EVTFS2( ) ;
      }

      protected void EVTFS2( )
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
                              E11FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E14FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E15FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E16FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E17FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E18FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E19FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E20FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION5'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction5' */
                              E21FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION4'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction4' */
                              E22FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction3' */
                              E23FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction2' */
                              E24FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction1' */
                              E25FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E26FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E27FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E28FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E29FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E30FS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E31FS2 ();
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
                              nGXsfl_184_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_184_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_184_idx), 4, 0), 4, "0");
                              SubsflControlProps_1842( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV53GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV53GridActions), 4, 0));
                              A730ParametroMudanzaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtParametroMudanzaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbParametroMudanzaTipo.Name = cmbParametroMudanzaTipo_Internalname;
                              cmbParametroMudanzaTipo.CurrentValue = cgiGet( cmbParametroMudanzaTipo_Internalname);
                              A731ParametroMudanzaTipo = cgiGet( cmbParametroMudanzaTipo_Internalname);
                              A869ParametroMudanzaTitulo = cgiGet( edtParametroMudanzaTitulo_Internalname);
                              A732ParametroMudanzaNombre = cgiGet( edtParametroMudanzaNombre_Internalname);
                              A812ParametroMudanzaDescripcion = cgiGet( edtParametroMudanzaDescripcion_Internalname);
                              A733ParametroMudanzaValor = context.localUtil.CToN( cgiGet( edtParametroMudanzaValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbParametroMudanzaUnidad.Name = cmbParametroMudanzaUnidad_Internalname;
                              cmbParametroMudanzaUnidad.CurrentValue = cgiGet( cmbParametroMudanzaUnidad_Internalname);
                              A734ParametroMudanzaUnidad = cgiGet( cmbParametroMudanzaUnidad_Internalname);
                              A818ParametroMudanzaPisoElev = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtParametroMudanzaPisoElev_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A870ParametroMudanzaImagen = cgiGet( edtParametroMudanzaImagen_Internalname);
                              AssignProp("", false, edtParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), !bGXsfl_184_Refreshing);
                              AssignProp("", false, edtParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
                              A877ParametroMudanzaActivo = StringUtil.StrToBool( cgiGet( chkParametroMudanzaActivo_Internalname));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E32FS2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E33FS2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E34FS2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E35FS2 ();
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
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Parametromudanzatipo1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPARAMETROMUDANZATIPO1"), AV19ParametroMudanzaTipo1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Parametromudanzatipo2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPARAMETROMUDANZATIPO2"), AV22ParametroMudanzaTipo2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Parametromudanzatipo3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPARAMETROMUDANZATIPO3"), AV25ParametroMudanzaTipo3) != 0 )
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 210 )
                        {
                           OldWwpaux_wc = cgiGet( "W0210");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0210", "", sEvt);
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

      protected void WEFS2( )
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

      protected void PAFS2( )
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
         SubsflControlProps_1842( ) ;
         while ( nGXsfl_184_idx <= nRC_GXsfl_184 )
         {
            sendrow_1842( ) ;
            nGXsfl_184_idx = ((subGrid_Islastpage==1)&&(nGXsfl_184_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_184_idx+1);
            sGXsfl_184_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_184_idx), 4, 0), 4, "0");
            SubsflControlProps_1842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV18DynamicFiltersSelector1 ,
                                       string AV19ParametroMudanzaTipo1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       string AV22ParametroMudanzaTipo2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       string AV25ParametroMudanzaTipo3 ,
                                       short AV37ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV32ColumnsSelector ,
                                       string AV83Pgmname ,
                                       string AV17FilterFullText ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       short AV38TFParametroMudanzaId ,
                                       short AV39TFParametroMudanzaId_To ,
                                       GxSimpleCollection<string> AV41TFParametroMudanzaTipo_Sels ,
                                       string AV72TFParametroMudanzaTitulo ,
                                       string AV73TFParametroMudanzaTitulo_Sel ,
                                       string AV42TFParametroMudanzaNombre ,
                                       string AV43TFParametroMudanzaNombre_Sel ,
                                       string AV62TFParametroMudanzaDescripcion ,
                                       string AV63TFParametroMudanzaDescripcion_Sel ,
                                       decimal AV44TFParametroMudanzaValor ,
                                       decimal AV45TFParametroMudanzaValor_To ,
                                       GxSimpleCollection<string> AV47TFParametroMudanzaUnidad_Sels ,
                                       short AV64TFParametroMudanzaPisoElev ,
                                       short AV65TFParametroMudanzaPisoElev_To ,
                                       short AV74TFParametroMudanzaActivo_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving ,
                                       bool AV55IsAuthorized_Update ,
                                       bool AV56IsAuthorized_Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFFS2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PARAMETROMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PARAMETROMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A730ParametroMudanzaId), 4, 0, ".", "")));
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
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavParametromudanzatipo1.ItemCount > 0 )
         {
            AV19ParametroMudanzaTipo1 = cmbavParametromudanzatipo1.getValidValue(AV19ParametroMudanzaTipo1);
            AssignAttri("", false, "AV19ParametroMudanzaTipo1", AV19ParametroMudanzaTipo1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavParametromudanzatipo1.CurrentValue = StringUtil.RTrim( AV19ParametroMudanzaTipo1);
            AssignProp("", false, cmbavParametromudanzatipo1_Internalname, "Values", cmbavParametromudanzatipo1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavParametromudanzatipo2.ItemCount > 0 )
         {
            AV22ParametroMudanzaTipo2 = cmbavParametromudanzatipo2.getValidValue(AV22ParametroMudanzaTipo2);
            AssignAttri("", false, "AV22ParametroMudanzaTipo2", AV22ParametroMudanzaTipo2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavParametromudanzatipo2.CurrentValue = StringUtil.RTrim( AV22ParametroMudanzaTipo2);
            AssignProp("", false, cmbavParametromudanzatipo2_Internalname, "Values", cmbavParametromudanzatipo2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavParametromudanzatipo3.ItemCount > 0 )
         {
            AV25ParametroMudanzaTipo3 = cmbavParametromudanzatipo3.getValidValue(AV25ParametroMudanzaTipo3);
            AssignAttri("", false, "AV25ParametroMudanzaTipo3", AV25ParametroMudanzaTipo3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavParametromudanzatipo3.CurrentValue = StringUtil.RTrim( AV25ParametroMudanzaTipo3);
            AssignProp("", false, cmbavParametromudanzatipo3_Internalname, "Values", cmbavParametromudanzatipo3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFFS2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV83Pgmname = "ParametroMudanzaWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV84Parametromudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV85Parametromudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV86Parametromudanzawwds_3_parametromudanzatipo1 = AV19ParametroMudanzaTipo1;
         AV87Parametromudanzawwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV88Parametromudanzawwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV89Parametromudanzawwds_6_parametromudanzatipo2 = AV22ParametroMudanzaTipo2;
         AV90Parametromudanzawwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV91Parametromudanzawwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV92Parametromudanzawwds_9_parametromudanzatipo3 = AV25ParametroMudanzaTipo3;
         AV93Parametromudanzawwds_10_tfparametromudanzaid = AV38TFParametroMudanzaId;
         AV94Parametromudanzawwds_11_tfparametromudanzaid_to = AV39TFParametroMudanzaId_To;
         AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV41TFParametroMudanzaTipo_Sels;
         AV96Parametromudanzawwds_13_tfparametromudanzatitulo = AV72TFParametroMudanzaTitulo;
         AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV73TFParametroMudanzaTitulo_Sel;
         AV98Parametromudanzawwds_15_tfparametromudanzanombre = AV42TFParametroMudanzaNombre;
         AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV43TFParametroMudanzaNombre_Sel;
         AV100Parametromudanzawwds_17_tfparametromudanzadescripcion = AV62TFParametroMudanzaDescripcion;
         AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV63TFParametroMudanzaDescripcion_Sel;
         AV102Parametromudanzawwds_19_tfparametromudanzavalor = AV44TFParametroMudanzaValor;
         AV103Parametromudanzawwds_20_tfparametromudanzavalor_to = AV45TFParametroMudanzaValor_To;
         AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV47TFParametroMudanzaUnidad_Sels;
         AV105Parametromudanzawwds_22_tfparametromudanzapisoelev = AV64TFParametroMudanzaPisoElev;
         AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV65TFParametroMudanzaPisoElev_To;
         AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV74TFParametroMudanzaActivo_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A731ParametroMudanzaTipo ,
                                              AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                              A734ParametroMudanzaUnidad ,
                                              AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                              AV85Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                              AV86Parametromudanzawwds_3_parametromudanzatipo1 ,
                                              AV87Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                              AV88Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                              AV89Parametromudanzawwds_6_parametromudanzatipo2 ,
                                              AV90Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                              AV91Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                              AV92Parametromudanzawwds_9_parametromudanzatipo3 ,
                                              AV93Parametromudanzawwds_10_tfparametromudanzaid ,
                                              AV94Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                              AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels.Count ,
                                              AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                              AV96Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                              AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                              AV98Parametromudanzawwds_15_tfparametromudanzanombre ,
                                              AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                              AV100Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                              AV102Parametromudanzawwds_19_tfparametromudanzavalor ,
                                              AV103Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                              AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels.Count ,
                                              AV105Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                              AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                              AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                              A730ParametroMudanzaId ,
                                              A869ParametroMudanzaTitulo ,
                                              A732ParametroMudanzaNombre ,
                                              A812ParametroMudanzaDescripcion ,
                                              A733ParametroMudanzaValor ,
                                              A818ParametroMudanzaPisoElev ,
                                              A877ParametroMudanzaActivo ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV84Parametromudanzawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV96Parametromudanzawwds_13_tfparametromudanzatitulo = StringUtil.Concat( StringUtil.RTrim( AV96Parametromudanzawwds_13_tfparametromudanzatitulo), "%", "");
         lV98Parametromudanzawwds_15_tfparametromudanzanombre = StringUtil.Concat( StringUtil.RTrim( AV98Parametromudanzawwds_15_tfparametromudanzanombre), "%", "");
         lV100Parametromudanzawwds_17_tfparametromudanzadescripcion = StringUtil.Concat( StringUtil.RTrim( AV100Parametromudanzawwds_17_tfparametromudanzadescripcion), "%", "");
         /* Using cursor H00FS2 */
         pr_default.execute(0, new Object[] {AV86Parametromudanzawwds_3_parametromudanzatipo1, AV89Parametromudanzawwds_6_parametromudanzatipo2, AV92Parametromudanzawwds_9_parametromudanzatipo3, AV93Parametromudanzawwds_10_tfparametromudanzaid, AV94Parametromudanzawwds_11_tfparametromudanzaid_to, lV96Parametromudanzawwds_13_tfparametromudanzatitulo, AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel, lV98Parametromudanzawwds_15_tfparametromudanzanombre, AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel, lV100Parametromudanzawwds_17_tfparametromudanzadescripcion, AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, AV102Parametromudanzawwds_19_tfparametromudanzavalor, AV103Parametromudanzawwds_20_tfparametromudanzavalor_to, AV105Parametromudanzawwds_22_tfparametromudanzapisoelev, AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A877ParametroMudanzaActivo = H00FS2_A877ParametroMudanzaActivo[0];
            A40000ParametroMudanzaImagen_GXI = H00FS2_A40000ParametroMudanzaImagen_GXI[0];
            AssignProp("", false, edtParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), !bGXsfl_184_Refreshing);
            AssignProp("", false, edtParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
            A818ParametroMudanzaPisoElev = H00FS2_A818ParametroMudanzaPisoElev[0];
            A734ParametroMudanzaUnidad = H00FS2_A734ParametroMudanzaUnidad[0];
            A733ParametroMudanzaValor = H00FS2_A733ParametroMudanzaValor[0];
            A812ParametroMudanzaDescripcion = H00FS2_A812ParametroMudanzaDescripcion[0];
            A732ParametroMudanzaNombre = H00FS2_A732ParametroMudanzaNombre[0];
            A869ParametroMudanzaTitulo = H00FS2_A869ParametroMudanzaTitulo[0];
            A731ParametroMudanzaTipo = H00FS2_A731ParametroMudanzaTipo[0];
            A730ParametroMudanzaId = H00FS2_A730ParametroMudanzaId[0];
            A870ParametroMudanzaImagen = H00FS2_A870ParametroMudanzaImagen[0];
            AssignProp("", false, edtParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), !bGXsfl_184_Refreshing);
            AssignProp("", false, edtParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Parametromudanzawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A730ParametroMudanzaId), 4, 0) , StringUtil.PadR( "%" + AV84Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble casa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleCasa") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo estacionamiento", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoEstacionamiento") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo vehiculo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoVehiculo") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "electro hogar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaHogar") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "item adicional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemAdicional") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "peaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Peaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble apto", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleApto") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "mobiliario", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaMobiliario") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "exterior y jardín", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaExterior") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "decoración", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaDecoracion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaOtros") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "escalera", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Escalera") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ascensor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Ascensor") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "esca+asce", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "EscaAsce") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio embalaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioEmbalaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio elevacion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioElevacion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio base", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioBase") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox km", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxKm") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxM3") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A869ParametroMudanzaTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A732ParametroMudanzaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A812ParametroMudanzaDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A733ParametroMudanzaValor, 18, 2) , StringUtil.PadR( "%" + AV84Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "m3") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pesos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "$") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "unidades", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "u") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "minutos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mi") == 0 ) ) || ( StringUtil.Like( "%" , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "%") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "min/m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mm") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A818ParametroMudanzaPisoElev), 4, 0) , StringUtil.PadR( "%" + AV84Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RFFS2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 184;
         /* Execute user event: Refresh */
         E33FS2 ();
         nGXsfl_184_idx = 1;
         sGXsfl_184_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_184_idx), 4, 0), 4, "0");
         SubsflControlProps_1842( ) ;
         bGXsfl_184_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
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
            SubsflControlProps_1842( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A731ParametroMudanzaTipo ,
                                                 AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                                 A734ParametroMudanzaUnidad ,
                                                 AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                                 AV85Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                                 AV86Parametromudanzawwds_3_parametromudanzatipo1 ,
                                                 AV87Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                                 AV88Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                                 AV89Parametromudanzawwds_6_parametromudanzatipo2 ,
                                                 AV90Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                                 AV91Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                                 AV92Parametromudanzawwds_9_parametromudanzatipo3 ,
                                                 AV93Parametromudanzawwds_10_tfparametromudanzaid ,
                                                 AV94Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                                 AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels.Count ,
                                                 AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                                 AV96Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                                 AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                                 AV98Parametromudanzawwds_15_tfparametromudanzanombre ,
                                                 AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                                 AV100Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                                 AV102Parametromudanzawwds_19_tfparametromudanzavalor ,
                                                 AV103Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                                 AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels.Count ,
                                                 AV105Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                                 AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                                 AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                                 A730ParametroMudanzaId ,
                                                 A869ParametroMudanzaTitulo ,
                                                 A732ParametroMudanzaNombre ,
                                                 A812ParametroMudanzaDescripcion ,
                                                 A733ParametroMudanzaValor ,
                                                 A818ParametroMudanzaPisoElev ,
                                                 A877ParametroMudanzaActivo ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV84Parametromudanzawwds_1_filterfulltext } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV96Parametromudanzawwds_13_tfparametromudanzatitulo = StringUtil.Concat( StringUtil.RTrim( AV96Parametromudanzawwds_13_tfparametromudanzatitulo), "%", "");
            lV98Parametromudanzawwds_15_tfparametromudanzanombre = StringUtil.Concat( StringUtil.RTrim( AV98Parametromudanzawwds_15_tfparametromudanzanombre), "%", "");
            lV100Parametromudanzawwds_17_tfparametromudanzadescripcion = StringUtil.Concat( StringUtil.RTrim( AV100Parametromudanzawwds_17_tfparametromudanzadescripcion), "%", "");
            /* Using cursor H00FS3 */
            pr_default.execute(1, new Object[] {AV86Parametromudanzawwds_3_parametromudanzatipo1, AV89Parametromudanzawwds_6_parametromudanzatipo2, AV92Parametromudanzawwds_9_parametromudanzatipo3, AV93Parametromudanzawwds_10_tfparametromudanzaid, AV94Parametromudanzawwds_11_tfparametromudanzaid_to, lV96Parametromudanzawwds_13_tfparametromudanzatitulo, AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel, lV98Parametromudanzawwds_15_tfparametromudanzanombre, AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel, lV100Parametromudanzawwds_17_tfparametromudanzadescripcion, AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, AV102Parametromudanzawwds_19_tfparametromudanzavalor, AV103Parametromudanzawwds_20_tfparametromudanzavalor_to, AV105Parametromudanzawwds_22_tfparametromudanzapisoelev, AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to});
            nGXsfl_184_idx = 1;
            sGXsfl_184_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_184_idx), 4, 0), 4, "0");
            SubsflControlProps_1842( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A877ParametroMudanzaActivo = H00FS3_A877ParametroMudanzaActivo[0];
               A40000ParametroMudanzaImagen_GXI = H00FS3_A40000ParametroMudanzaImagen_GXI[0];
               AssignProp("", false, edtParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), !bGXsfl_184_Refreshing);
               AssignProp("", false, edtParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
               A818ParametroMudanzaPisoElev = H00FS3_A818ParametroMudanzaPisoElev[0];
               A734ParametroMudanzaUnidad = H00FS3_A734ParametroMudanzaUnidad[0];
               A733ParametroMudanzaValor = H00FS3_A733ParametroMudanzaValor[0];
               A812ParametroMudanzaDescripcion = H00FS3_A812ParametroMudanzaDescripcion[0];
               A732ParametroMudanzaNombre = H00FS3_A732ParametroMudanzaNombre[0];
               A869ParametroMudanzaTitulo = H00FS3_A869ParametroMudanzaTitulo[0];
               A731ParametroMudanzaTipo = H00FS3_A731ParametroMudanzaTipo[0];
               A730ParametroMudanzaId = H00FS3_A730ParametroMudanzaId[0];
               A870ParametroMudanzaImagen = H00FS3_A870ParametroMudanzaImagen[0];
               AssignProp("", false, edtParametroMudanzaImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.convertURL( context.PathToRelativeUrl( A870ParametroMudanzaImagen))), !bGXsfl_184_Refreshing);
               AssignProp("", false, edtParametroMudanzaImagen_Internalname, "SrcSet", context.GetImageSrcSet( A870ParametroMudanzaImagen), true);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Parametromudanzawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A730ParametroMudanzaId), 4, 0) , StringUtil.PadR( "%" + AV84Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "tipo inmueble casa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleCasa") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "tipo estacionamiento", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoEstacionamiento") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "tipo vehiculo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoVehiculo") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "electro hogar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaHogar") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "item adicional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemAdicional") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "peaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Peaje") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "tipo inmueble apto", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleApto") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "mobiliario", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaMobiliario") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "exterior y jardín", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaExterior") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "decoración", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaDecoracion") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaOtros") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "escalera", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Escalera") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ascensor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Ascensor") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "esca+asce", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "EscaAsce") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "precio embalaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioEmbalaje") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "precio elevacion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioElevacion") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "precio base", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioBase") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "tiempox km", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxKm") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "tiempox m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxM3") == 0 ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A869ParametroMudanzaTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A732ParametroMudanzaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A812ParametroMudanzaDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A733ParametroMudanzaValor, 18, 2) , StringUtil.PadR( "%" + AV84Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "m3") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pesos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "$") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "unidades", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "u") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "minutos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mi") == 0 ) ) || ( StringUtil.Like( "%" , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "%") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "min/m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV84Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mm") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A818ParametroMudanzaPisoElev), 4, 0) , StringUtil.PadR( "%" + AV84Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E34FS2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 184;
            WBFS0( ) ;
         }
         bGXsfl_184_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesFS2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV83Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV83Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PARAMETROMUDANZAID"+"_"+sGXsfl_184_idx, GetSecureSignedToken( sGXsfl_184_idx, context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9"), context));
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
         AV84Parametromudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV85Parametromudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV86Parametromudanzawwds_3_parametromudanzatipo1 = AV19ParametroMudanzaTipo1;
         AV87Parametromudanzawwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV88Parametromudanzawwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV89Parametromudanzawwds_6_parametromudanzatipo2 = AV22ParametroMudanzaTipo2;
         AV90Parametromudanzawwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV91Parametromudanzawwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV92Parametromudanzawwds_9_parametromudanzatipo3 = AV25ParametroMudanzaTipo3;
         AV93Parametromudanzawwds_10_tfparametromudanzaid = AV38TFParametroMudanzaId;
         AV94Parametromudanzawwds_11_tfparametromudanzaid_to = AV39TFParametroMudanzaId_To;
         AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV41TFParametroMudanzaTipo_Sels;
         AV96Parametromudanzawwds_13_tfparametromudanzatitulo = AV72TFParametroMudanzaTitulo;
         AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV73TFParametroMudanzaTitulo_Sel;
         AV98Parametromudanzawwds_15_tfparametromudanzanombre = AV42TFParametroMudanzaNombre;
         AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV43TFParametroMudanzaNombre_Sel;
         AV100Parametromudanzawwds_17_tfparametromudanzadescripcion = AV62TFParametroMudanzaDescripcion;
         AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV63TFParametroMudanzaDescripcion_Sel;
         AV102Parametromudanzawwds_19_tfparametromudanzavalor = AV44TFParametroMudanzaValor;
         AV103Parametromudanzawwds_20_tfparametromudanzavalor_to = AV45TFParametroMudanzaValor_To;
         AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV47TFParametroMudanzaUnidad_Sels;
         AV105Parametromudanzawwds_22_tfparametromudanzapisoelev = AV64TFParametroMudanzaPisoElev;
         AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV65TFParametroMudanzaPisoElev_To;
         AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV74TFParametroMudanzaActivo_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19ParametroMudanzaTipo1, AV21DynamicFiltersSelector2, AV22ParametroMudanzaTipo2, AV24DynamicFiltersSelector3, AV25ParametroMudanzaTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV83Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFParametroMudanzaId, AV39TFParametroMudanzaId_To, AV41TFParametroMudanzaTipo_Sels, AV72TFParametroMudanzaTitulo, AV73TFParametroMudanzaTitulo_Sel, AV42TFParametroMudanzaNombre, AV43TFParametroMudanzaNombre_Sel, AV62TFParametroMudanzaDescripcion, AV63TFParametroMudanzaDescripcion_Sel, AV44TFParametroMudanzaValor, AV45TFParametroMudanzaValor_To, AV47TFParametroMudanzaUnidad_Sels, AV64TFParametroMudanzaPisoElev, AV65TFParametroMudanzaPisoElev_To, AV74TFParametroMudanzaActivo_Sel, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV55IsAuthorized_Update, AV56IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV84Parametromudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV85Parametromudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV86Parametromudanzawwds_3_parametromudanzatipo1 = AV19ParametroMudanzaTipo1;
         AV87Parametromudanzawwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV88Parametromudanzawwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV89Parametromudanzawwds_6_parametromudanzatipo2 = AV22ParametroMudanzaTipo2;
         AV90Parametromudanzawwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV91Parametromudanzawwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV92Parametromudanzawwds_9_parametromudanzatipo3 = AV25ParametroMudanzaTipo3;
         AV93Parametromudanzawwds_10_tfparametromudanzaid = AV38TFParametroMudanzaId;
         AV94Parametromudanzawwds_11_tfparametromudanzaid_to = AV39TFParametroMudanzaId_To;
         AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV41TFParametroMudanzaTipo_Sels;
         AV96Parametromudanzawwds_13_tfparametromudanzatitulo = AV72TFParametroMudanzaTitulo;
         AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV73TFParametroMudanzaTitulo_Sel;
         AV98Parametromudanzawwds_15_tfparametromudanzanombre = AV42TFParametroMudanzaNombre;
         AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV43TFParametroMudanzaNombre_Sel;
         AV100Parametromudanzawwds_17_tfparametromudanzadescripcion = AV62TFParametroMudanzaDescripcion;
         AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV63TFParametroMudanzaDescripcion_Sel;
         AV102Parametromudanzawwds_19_tfparametromudanzavalor = AV44TFParametroMudanzaValor;
         AV103Parametromudanzawwds_20_tfparametromudanzavalor_to = AV45TFParametroMudanzaValor_To;
         AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV47TFParametroMudanzaUnidad_Sels;
         AV105Parametromudanzawwds_22_tfparametromudanzapisoelev = AV64TFParametroMudanzaPisoElev;
         AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV65TFParametroMudanzaPisoElev_To;
         AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV74TFParametroMudanzaActivo_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19ParametroMudanzaTipo1, AV21DynamicFiltersSelector2, AV22ParametroMudanzaTipo2, AV24DynamicFiltersSelector3, AV25ParametroMudanzaTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV83Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFParametroMudanzaId, AV39TFParametroMudanzaId_To, AV41TFParametroMudanzaTipo_Sels, AV72TFParametroMudanzaTitulo, AV73TFParametroMudanzaTitulo_Sel, AV42TFParametroMudanzaNombre, AV43TFParametroMudanzaNombre_Sel, AV62TFParametroMudanzaDescripcion, AV63TFParametroMudanzaDescripcion_Sel, AV44TFParametroMudanzaValor, AV45TFParametroMudanzaValor_To, AV47TFParametroMudanzaUnidad_Sels, AV64TFParametroMudanzaPisoElev, AV65TFParametroMudanzaPisoElev_To, AV74TFParametroMudanzaActivo_Sel, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV55IsAuthorized_Update, AV56IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV84Parametromudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV85Parametromudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV86Parametromudanzawwds_3_parametromudanzatipo1 = AV19ParametroMudanzaTipo1;
         AV87Parametromudanzawwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV88Parametromudanzawwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV89Parametromudanzawwds_6_parametromudanzatipo2 = AV22ParametroMudanzaTipo2;
         AV90Parametromudanzawwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV91Parametromudanzawwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV92Parametromudanzawwds_9_parametromudanzatipo3 = AV25ParametroMudanzaTipo3;
         AV93Parametromudanzawwds_10_tfparametromudanzaid = AV38TFParametroMudanzaId;
         AV94Parametromudanzawwds_11_tfparametromudanzaid_to = AV39TFParametroMudanzaId_To;
         AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV41TFParametroMudanzaTipo_Sels;
         AV96Parametromudanzawwds_13_tfparametromudanzatitulo = AV72TFParametroMudanzaTitulo;
         AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV73TFParametroMudanzaTitulo_Sel;
         AV98Parametromudanzawwds_15_tfparametromudanzanombre = AV42TFParametroMudanzaNombre;
         AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV43TFParametroMudanzaNombre_Sel;
         AV100Parametromudanzawwds_17_tfparametromudanzadescripcion = AV62TFParametroMudanzaDescripcion;
         AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV63TFParametroMudanzaDescripcion_Sel;
         AV102Parametromudanzawwds_19_tfparametromudanzavalor = AV44TFParametroMudanzaValor;
         AV103Parametromudanzawwds_20_tfparametromudanzavalor_to = AV45TFParametroMudanzaValor_To;
         AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV47TFParametroMudanzaUnidad_Sels;
         AV105Parametromudanzawwds_22_tfparametromudanzapisoelev = AV64TFParametroMudanzaPisoElev;
         AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV65TFParametroMudanzaPisoElev_To;
         AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV74TFParametroMudanzaActivo_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19ParametroMudanzaTipo1, AV21DynamicFiltersSelector2, AV22ParametroMudanzaTipo2, AV24DynamicFiltersSelector3, AV25ParametroMudanzaTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV83Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFParametroMudanzaId, AV39TFParametroMudanzaId_To, AV41TFParametroMudanzaTipo_Sels, AV72TFParametroMudanzaTitulo, AV73TFParametroMudanzaTitulo_Sel, AV42TFParametroMudanzaNombre, AV43TFParametroMudanzaNombre_Sel, AV62TFParametroMudanzaDescripcion, AV63TFParametroMudanzaDescripcion_Sel, AV44TFParametroMudanzaValor, AV45TFParametroMudanzaValor_To, AV47TFParametroMudanzaUnidad_Sels, AV64TFParametroMudanzaPisoElev, AV65TFParametroMudanzaPisoElev_To, AV74TFParametroMudanzaActivo_Sel, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV55IsAuthorized_Update, AV56IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV84Parametromudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV85Parametromudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV86Parametromudanzawwds_3_parametromudanzatipo1 = AV19ParametroMudanzaTipo1;
         AV87Parametromudanzawwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV88Parametromudanzawwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV89Parametromudanzawwds_6_parametromudanzatipo2 = AV22ParametroMudanzaTipo2;
         AV90Parametromudanzawwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV91Parametromudanzawwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV92Parametromudanzawwds_9_parametromudanzatipo3 = AV25ParametroMudanzaTipo3;
         AV93Parametromudanzawwds_10_tfparametromudanzaid = AV38TFParametroMudanzaId;
         AV94Parametromudanzawwds_11_tfparametromudanzaid_to = AV39TFParametroMudanzaId_To;
         AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV41TFParametroMudanzaTipo_Sels;
         AV96Parametromudanzawwds_13_tfparametromudanzatitulo = AV72TFParametroMudanzaTitulo;
         AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV73TFParametroMudanzaTitulo_Sel;
         AV98Parametromudanzawwds_15_tfparametromudanzanombre = AV42TFParametroMudanzaNombre;
         AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV43TFParametroMudanzaNombre_Sel;
         AV100Parametromudanzawwds_17_tfparametromudanzadescripcion = AV62TFParametroMudanzaDescripcion;
         AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV63TFParametroMudanzaDescripcion_Sel;
         AV102Parametromudanzawwds_19_tfparametromudanzavalor = AV44TFParametroMudanzaValor;
         AV103Parametromudanzawwds_20_tfparametromudanzavalor_to = AV45TFParametroMudanzaValor_To;
         AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV47TFParametroMudanzaUnidad_Sels;
         AV105Parametromudanzawwds_22_tfparametromudanzapisoelev = AV64TFParametroMudanzaPisoElev;
         AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV65TFParametroMudanzaPisoElev_To;
         AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV74TFParametroMudanzaActivo_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19ParametroMudanzaTipo1, AV21DynamicFiltersSelector2, AV22ParametroMudanzaTipo2, AV24DynamicFiltersSelector3, AV25ParametroMudanzaTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV83Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFParametroMudanzaId, AV39TFParametroMudanzaId_To, AV41TFParametroMudanzaTipo_Sels, AV72TFParametroMudanzaTitulo, AV73TFParametroMudanzaTitulo_Sel, AV42TFParametroMudanzaNombre, AV43TFParametroMudanzaNombre_Sel, AV62TFParametroMudanzaDescripcion, AV63TFParametroMudanzaDescripcion_Sel, AV44TFParametroMudanzaValor, AV45TFParametroMudanzaValor_To, AV47TFParametroMudanzaUnidad_Sels, AV64TFParametroMudanzaPisoElev, AV65TFParametroMudanzaPisoElev_To, AV74TFParametroMudanzaActivo_Sel, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV55IsAuthorized_Update, AV56IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV84Parametromudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV85Parametromudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV86Parametromudanzawwds_3_parametromudanzatipo1 = AV19ParametroMudanzaTipo1;
         AV87Parametromudanzawwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV88Parametromudanzawwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV89Parametromudanzawwds_6_parametromudanzatipo2 = AV22ParametroMudanzaTipo2;
         AV90Parametromudanzawwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV91Parametromudanzawwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV92Parametromudanzawwds_9_parametromudanzatipo3 = AV25ParametroMudanzaTipo3;
         AV93Parametromudanzawwds_10_tfparametromudanzaid = AV38TFParametroMudanzaId;
         AV94Parametromudanzawwds_11_tfparametromudanzaid_to = AV39TFParametroMudanzaId_To;
         AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV41TFParametroMudanzaTipo_Sels;
         AV96Parametromudanzawwds_13_tfparametromudanzatitulo = AV72TFParametroMudanzaTitulo;
         AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV73TFParametroMudanzaTitulo_Sel;
         AV98Parametromudanzawwds_15_tfparametromudanzanombre = AV42TFParametroMudanzaNombre;
         AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV43TFParametroMudanzaNombre_Sel;
         AV100Parametromudanzawwds_17_tfparametromudanzadescripcion = AV62TFParametroMudanzaDescripcion;
         AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV63TFParametroMudanzaDescripcion_Sel;
         AV102Parametromudanzawwds_19_tfparametromudanzavalor = AV44TFParametroMudanzaValor;
         AV103Parametromudanzawwds_20_tfparametromudanzavalor_to = AV45TFParametroMudanzaValor_To;
         AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV47TFParametroMudanzaUnidad_Sels;
         AV105Parametromudanzawwds_22_tfparametromudanzapisoelev = AV64TFParametroMudanzaPisoElev;
         AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV65TFParametroMudanzaPisoElev_To;
         AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV74TFParametroMudanzaActivo_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19ParametroMudanzaTipo1, AV21DynamicFiltersSelector2, AV22ParametroMudanzaTipo2, AV24DynamicFiltersSelector3, AV25ParametroMudanzaTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV83Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFParametroMudanzaId, AV39TFParametroMudanzaId_To, AV41TFParametroMudanzaTipo_Sels, AV72TFParametroMudanzaTitulo, AV73TFParametroMudanzaTitulo_Sel, AV42TFParametroMudanzaNombre, AV43TFParametroMudanzaNombre_Sel, AV62TFParametroMudanzaDescripcion, AV63TFParametroMudanzaDescripcion_Sel, AV44TFParametroMudanzaValor, AV45TFParametroMudanzaValor_To, AV47TFParametroMudanzaUnidad_Sels, AV64TFParametroMudanzaPisoElev, AV65TFParametroMudanzaPisoElev_To, AV74TFParametroMudanzaActivo_Sel, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV55IsAuthorized_Update, AV56IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV83Pgmname = "ParametroMudanzaWW";
         edtParametroMudanzaId_Enabled = 0;
         cmbParametroMudanzaTipo.Enabled = 0;
         edtParametroMudanzaTitulo_Enabled = 0;
         edtParametroMudanzaNombre_Enabled = 0;
         edtParametroMudanzaDescripcion_Enabled = 0;
         edtParametroMudanzaValor_Enabled = 0;
         cmbParametroMudanzaUnidad.Enabled = 0;
         edtParametroMudanzaPisoElev_Enabled = 0;
         edtParametroMudanzaImagen_Enabled = 0;
         chkParametroMudanzaActivo.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPFS0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E32FS2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV35ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV57AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV48DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV32ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_184 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_184"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV50GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV51GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV52GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( "DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
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
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
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
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV18DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            cmbavParametromudanzatipo1.Name = cmbavParametromudanzatipo1_Internalname;
            cmbavParametromudanzatipo1.CurrentValue = cgiGet( cmbavParametromudanzatipo1_Internalname);
            AV19ParametroMudanzaTipo1 = cgiGet( cmbavParametromudanzatipo1_Internalname);
            AssignAttri("", false, "AV19ParametroMudanzaTipo1", AV19ParametroMudanzaTipo1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavParametromudanzatipo2.Name = cmbavParametromudanzatipo2_Internalname;
            cmbavParametromudanzatipo2.CurrentValue = cgiGet( cmbavParametromudanzatipo2_Internalname);
            AV22ParametroMudanzaTipo2 = cgiGet( cmbavParametromudanzatipo2_Internalname);
            AssignAttri("", false, "AV22ParametroMudanzaTipo2", AV22ParametroMudanzaTipo2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavParametromudanzatipo3.Name = cmbavParametromudanzatipo3_Internalname;
            cmbavParametromudanzatipo3.CurrentValue = cgiGet( cmbavParametromudanzatipo3_Internalname);
            AV25ParametroMudanzaTipo3 = cgiGet( cmbavParametromudanzatipo3_Internalname);
            AssignAttri("", false, "AV25ParametroMudanzaTipo3", AV25ParametroMudanzaTipo3);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPrecioembmetro3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPrecioembmetro3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRECIOEMBMETRO3");
               GX_FocusControl = edtavPrecioembmetro3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV60PrecioEmbMetro3 = 0;
               AssignAttri("", false, "AV60PrecioEmbMetro3", StringUtil.LTrimStr( AV60PrecioEmbMetro3, 18, 2));
            }
            else
            {
               AV60PrecioEmbMetro3 = context.localUtil.CToN( cgiGet( edtavPrecioembmetro3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV60PrecioEmbMetro3", StringUtil.LTrimStr( AV60PrecioEmbMetro3, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPrecioelevpiso_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPrecioelevpiso_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRECIOELEVPISO");
               GX_FocusControl = edtavPrecioelevpiso_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV61PrecioElevPiso = 0;
               AssignAttri("", false, "AV61PrecioElevPiso", StringUtil.LTrimStr( AV61PrecioElevPiso, 18, 2));
            }
            else
            {
               AV61PrecioElevPiso = context.localUtil.CToN( cgiGet( edtavPrecioelevpiso_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV61PrecioElevPiso", StringUtil.LTrimStr( AV61PrecioElevPiso, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPreciochico_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPreciochico_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRECIOCHICO");
               GX_FocusControl = edtavPreciochico_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV66PrecioChico = 0;
               AssignAttri("", false, "AV66PrecioChico", StringUtil.LTrimStr( AV66PrecioChico, 18, 2));
            }
            else
            {
               AV66PrecioChico = context.localUtil.CToN( cgiGet( edtavPreciochico_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV66PrecioChico", StringUtil.LTrimStr( AV66PrecioChico, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPreciomediano_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPreciomediano_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRECIOMEDIANO");
               GX_FocusControl = edtavPreciomediano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV67PrecioMediano = 0;
               AssignAttri("", false, "AV67PrecioMediano", StringUtil.LTrimStr( AV67PrecioMediano, 18, 2));
            }
            else
            {
               AV67PrecioMediano = context.localUtil.CToN( cgiGet( edtavPreciomediano_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV67PrecioMediano", StringUtil.LTrimStr( AV67PrecioMediano, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPreciogrande_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPreciogrande_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRECIOGRANDE");
               GX_FocusControl = edtavPreciogrande_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV68PrecioGrande = 0;
               AssignAttri("", false, "AV68PrecioGrande", StringUtil.LTrimStr( AV68PrecioGrande, 18, 2));
            }
            else
            {
               AV68PrecioGrande = context.localUtil.CToN( cgiGet( edtavPreciogrande_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV68PrecioGrande", StringUtil.LTrimStr( AV68PrecioGrande, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPreciopeon_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPreciopeon_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRECIOPEON");
               GX_FocusControl = edtavPreciopeon_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV69PrecioPeon = 0;
               AssignAttri("", false, "AV69PrecioPeon", StringUtil.LTrimStr( AV69PrecioPeon, 18, 2));
            }
            else
            {
               AV69PrecioPeon = context.localUtil.CToN( cgiGet( edtavPreciopeon_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV69PrecioPeon", StringUtil.LTrimStr( AV69PrecioPeon, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTiempokm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTiempokm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIEMPOKM");
               GX_FocusControl = edtavTiempokm_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV70TiempoKm = 0;
               AssignAttri("", false, "AV70TiempoKm", StringUtil.LTrimStr( AV70TiempoKm, 18, 2));
            }
            else
            {
               AV70TiempoKm = context.localUtil.CToN( cgiGet( edtavTiempokm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV70TiempoKm", StringUtil.LTrimStr( AV70TiempoKm, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTiempoxm3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTiempoxm3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTIEMPOXM3");
               GX_FocusControl = edtavTiempoxm3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV71TiempoxM3 = 0;
               AssignAttri("", false, "AV71TiempoxM3", StringUtil.LTrimStr( AV71TiempoxM3, 18, 2));
            }
            else
            {
               AV71TiempoxM3 = context.localUtil.CToN( cgiGet( edtavTiempoxm3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV71TiempoxM3", StringUtil.LTrimStr( AV71TiempoxM3, 18, 2));
            }
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPARAMETROMUDANZATIPO1"), AV19ParametroMudanzaTipo1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPARAMETROMUDANZATIPO2"), AV22ParametroMudanzaTipo2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPARAMETROMUDANZATIPO3"), AV25ParametroMudanzaTipo3) != 0 )
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
         E32FS2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E32FS2( )
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
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV19ParametroMudanzaTipo1 = "";
         AssignAttri("", false, "AV19ParametroMudanzaTipo1", AV19ParametroMudanzaTipo1);
         AV18DynamicFiltersSelector1 = "PARAMETROMUDANZATIPO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22ParametroMudanzaTipo2 = "";
         AssignAttri("", false, "AV22ParametroMudanzaTipo2", AV22ParametroMudanzaTipo2);
         AV21DynamicFiltersSelector2 = "PARAMETROMUDANZATIPO";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25ParametroMudanzaTipo3 = "";
         AssignAttri("", false, "AV25ParametroMudanzaTipo3", AV25ParametroMudanzaTipo3);
         AV24DynamicFiltersSelector3 = "PARAMETROMUDANZATIPO";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV57AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV58AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV58AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV58AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV58AGExportDataItem.gxTpr_Eventkey = "Export";
         AV58AGExportDataItem.gxTpr_Isdivider = false;
         AV57AGExportData.Add(AV58AGExportDataItem, 0);
         AV58AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV58AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV58AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV58AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV58AGExportDataItem.gxTpr_Isdivider = false;
         AV57AGExportData.Add(AV58AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Parametro Mudanza", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
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
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV48DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV48DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         /* Using cursor H00FS4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A732ParametroMudanzaNombre = H00FS4_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = H00FS4_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = H00FS4_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "PrecioElevPiso", "")) == 0 )
            {
               AV61PrecioElevPiso = A733ParametroMudanzaValor;
               AssignAttri("", false, "AV61PrecioElevPiso", StringUtil.LTrimStr( AV61PrecioElevPiso, 18, 2));
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor H00FS5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A732ParametroMudanzaNombre = H00FS5_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = H00FS5_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = H00FS5_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "PrecioEmbMetro3", "")) == 0 )
            {
               AV60PrecioEmbMetro3 = A733ParametroMudanzaValor;
               AssignAttri("", false, "AV60PrecioEmbMetro3", StringUtil.LTrimStr( AV60PrecioEmbMetro3, 18, 2));
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor H00FS6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A732ParametroMudanzaNombre = H00FS6_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = H00FS6_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = H00FS6_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "CHICO", "")) == 0 )
            {
               AV66PrecioChico = A733ParametroMudanzaValor;
               AssignAttri("", false, "AV66PrecioChico", StringUtil.LTrimStr( AV66PrecioChico, 18, 2));
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Using cursor H00FS7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A732ParametroMudanzaNombre = H00FS7_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = H00FS7_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = H00FS7_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "MEDIANO", "")) == 0 )
            {
               AV67PrecioMediano = A733ParametroMudanzaValor;
               AssignAttri("", false, "AV67PrecioMediano", StringUtil.LTrimStr( AV67PrecioMediano, 18, 2));
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Using cursor H00FS8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A732ParametroMudanzaNombre = H00FS8_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = H00FS8_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = H00FS8_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "GRANDE", "")) == 0 )
            {
               AV68PrecioGrande = A733ParametroMudanzaValor;
               AssignAttri("", false, "AV68PrecioGrande", StringUtil.LTrimStr( AV68PrecioGrande, 18, 2));
            }
            pr_default.readNext(6);
         }
         pr_default.close(6);
         /* Using cursor H00FS9 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            A732ParametroMudanzaNombre = H00FS9_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = H00FS9_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = H00FS9_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "Peones adicionales", "")) == 0 )
            {
               AV69PrecioPeon = A733ParametroMudanzaValor;
               AssignAttri("", false, "AV69PrecioPeon", StringUtil.LTrimStr( AV69PrecioPeon, 18, 2));
            }
            pr_default.readNext(7);
         }
         pr_default.close(7);
         /* Using cursor H00FS10 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            A732ParametroMudanzaNombre = H00FS10_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = H00FS10_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = H00FS10_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "TiempoxKm", "")) == 0 )
            {
               AV70TiempoKm = A733ParametroMudanzaValor;
               AssignAttri("", false, "AV70TiempoKm", StringUtil.LTrimStr( AV70TiempoKm, 18, 2));
            }
            pr_default.readNext(8);
         }
         pr_default.close(8);
         /* Using cursor H00FS11 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            A732ParametroMudanzaNombre = H00FS11_A732ParametroMudanzaNombre[0];
            A731ParametroMudanzaTipo = H00FS11_A731ParametroMudanzaTipo[0];
            A733ParametroMudanzaValor = H00FS11_A733ParametroMudanzaValor[0];
            if ( StringUtil.StrCmp(A732ParametroMudanzaNombre, context.GetMessage( "TiempoxM3", "")) == 0 )
            {
               AV71TiempoxM3 = A733ParametroMudanzaValor;
               AssignAttri("", false, "AV71TiempoxM3", StringUtil.LTrimStr( AV71TiempoxM3, 18, 2));
            }
            pr_default.readNext(9);
         }
         pr_default.close(9);
      }

      protected void E33FS2( )
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
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV37ManageFiltersExecutionStep == 1 )
         {
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV37ManageFiltersExecutionStep == 2 )
         {
            AV37ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV34Session.Get("ParametroMudanzaWWColumnsSelector"), "") != 0 )
         {
            AV30ColumnsSelectorXML = AV34Session.Get("ParametroMudanzaWWColumnsSelector");
            AV32ColumnsSelector.FromXml(AV30ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtParametroMudanzaId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroMudanzaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaId_Visible), 5, 0), !bGXsfl_184_Refreshing);
         cmbParametroMudanzaTipo.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbParametroMudanzaTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbParametroMudanzaTipo.Visible), 5, 0), !bGXsfl_184_Refreshing);
         edtParametroMudanzaTitulo_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroMudanzaTitulo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaTitulo_Visible), 5, 0), !bGXsfl_184_Refreshing);
         edtParametroMudanzaNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroMudanzaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaNombre_Visible), 5, 0), !bGXsfl_184_Refreshing);
         edtParametroMudanzaDescripcion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroMudanzaDescripcion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaDescripcion_Visible), 5, 0), !bGXsfl_184_Refreshing);
         edtParametroMudanzaValor_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroMudanzaValor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaValor_Visible), 5, 0), !bGXsfl_184_Refreshing);
         cmbParametroMudanzaUnidad.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbParametroMudanzaUnidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbParametroMudanzaUnidad.Visible), 5, 0), !bGXsfl_184_Refreshing);
         edtParametroMudanzaPisoElev_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroMudanzaPisoElev_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaPisoElev_Visible), 5, 0), !bGXsfl_184_Refreshing);
         edtParametroMudanzaImagen_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroMudanzaImagen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroMudanzaImagen_Visible), 5, 0), !bGXsfl_184_Refreshing);
         chkParametroMudanzaActivo.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkParametroMudanzaActivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkParametroMudanzaActivo.Visible), 5, 0), !bGXsfl_184_Refreshing);
         AV50GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV50GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV50GridCurrentPage), 10, 0));
         AV51GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV51GridPageCount", StringUtil.LTrimStr( (decimal)(AV51GridPageCount), 10, 0));
         GXt_char2 = AV52GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV83Pgmname, out  GXt_char2) ;
         AV52GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV52GridAppliedFilters", AV52GridAppliedFilters);
         AV84Parametromudanzawwds_1_filterfulltext = AV17FilterFullText;
         AV85Parametromudanzawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV86Parametromudanzawwds_3_parametromudanzatipo1 = AV19ParametroMudanzaTipo1;
         AV87Parametromudanzawwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV88Parametromudanzawwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV89Parametromudanzawwds_6_parametromudanzatipo2 = AV22ParametroMudanzaTipo2;
         AV90Parametromudanzawwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV91Parametromudanzawwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV92Parametromudanzawwds_9_parametromudanzatipo3 = AV25ParametroMudanzaTipo3;
         AV93Parametromudanzawwds_10_tfparametromudanzaid = AV38TFParametroMudanzaId;
         AV94Parametromudanzawwds_11_tfparametromudanzaid_to = AV39TFParametroMudanzaId_To;
         AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV41TFParametroMudanzaTipo_Sels;
         AV96Parametromudanzawwds_13_tfparametromudanzatitulo = AV72TFParametroMudanzaTitulo;
         AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV73TFParametroMudanzaTitulo_Sel;
         AV98Parametromudanzawwds_15_tfparametromudanzanombre = AV42TFParametroMudanzaNombre;
         AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV43TFParametroMudanzaNombre_Sel;
         AV100Parametromudanzawwds_17_tfparametromudanzadescripcion = AV62TFParametroMudanzaDescripcion;
         AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV63TFParametroMudanzaDescripcion_Sel;
         AV102Parametromudanzawwds_19_tfparametromudanzavalor = AV44TFParametroMudanzaValor;
         AV103Parametromudanzawwds_20_tfparametromudanzavalor_to = AV45TFParametroMudanzaValor_To;
         AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV47TFParametroMudanzaUnidad_Sels;
         AV105Parametromudanzawwds_22_tfparametromudanzapisoelev = AV64TFParametroMudanzaPisoElev;
         AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV65TFParametroMudanzaPisoElev_To;
         AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV74TFParametroMudanzaActivo_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12FS2( )
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
            AV49PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV49PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13FS2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E16FS2( )
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
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroMudanzaId") == 0 )
            {
               AV38TFParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV38TFParametroMudanzaId", StringUtil.LTrimStr( (decimal)(AV38TFParametroMudanzaId), 4, 0));
               AV39TFParametroMudanzaId_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39TFParametroMudanzaId_To", StringUtil.LTrimStr( (decimal)(AV39TFParametroMudanzaId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroMudanzaTipo") == 0 )
            {
               AV40TFParametroMudanzaTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFParametroMudanzaTipo_SelsJson", AV40TFParametroMudanzaTipo_SelsJson);
               AV41TFParametroMudanzaTipo_Sels.FromJSonString(AV40TFParametroMudanzaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroMudanzaTitulo") == 0 )
            {
               AV72TFParametroMudanzaTitulo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV72TFParametroMudanzaTitulo", AV72TFParametroMudanzaTitulo);
               AV73TFParametroMudanzaTitulo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV73TFParametroMudanzaTitulo_Sel", AV73TFParametroMudanzaTitulo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroMudanzaNombre") == 0 )
            {
               AV42TFParametroMudanzaNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFParametroMudanzaNombre", AV42TFParametroMudanzaNombre);
               AV43TFParametroMudanzaNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFParametroMudanzaNombre_Sel", AV43TFParametroMudanzaNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroMudanzaDescripcion") == 0 )
            {
               AV62TFParametroMudanzaDescripcion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV62TFParametroMudanzaDescripcion", AV62TFParametroMudanzaDescripcion);
               AV63TFParametroMudanzaDescripcion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV63TFParametroMudanzaDescripcion_Sel", AV63TFParametroMudanzaDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroMudanzaValor") == 0 )
            {
               AV44TFParametroMudanzaValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV44TFParametroMudanzaValor", StringUtil.LTrimStr( AV44TFParametroMudanzaValor, 18, 2));
               AV45TFParametroMudanzaValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV45TFParametroMudanzaValor_To", StringUtil.LTrimStr( AV45TFParametroMudanzaValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroMudanzaUnidad") == 0 )
            {
               AV46TFParametroMudanzaUnidad_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFParametroMudanzaUnidad_SelsJson", AV46TFParametroMudanzaUnidad_SelsJson);
               AV47TFParametroMudanzaUnidad_Sels.FromJSonString(AV46TFParametroMudanzaUnidad_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroMudanzaPisoElev") == 0 )
            {
               AV64TFParametroMudanzaPisoElev = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV64TFParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(AV64TFParametroMudanzaPisoElev), 4, 0));
               AV65TFParametroMudanzaPisoElev_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV65TFParametroMudanzaPisoElev_To", StringUtil.LTrimStr( (decimal)(AV65TFParametroMudanzaPisoElev_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroMudanzaActivo") == 0 )
            {
               AV74TFParametroMudanzaActivo_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV74TFParametroMudanzaActivo_Sel", StringUtil.Str( (decimal)(AV74TFParametroMudanzaActivo_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFParametroMudanzaUnidad_Sels", AV47TFParametroMudanzaUnidad_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41TFParametroMudanzaTipo_Sels", AV41TFParametroMudanzaTipo_Sels);
      }

      private void E34FS2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV55IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV56IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 184;
            }
            sendrow_1842( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_184_Refreshing )
         {
            context.DoAjaxLoad(184, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV53GridActions), 4, 0));
      }

      protected void E17FS2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV30ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV32ColumnsSelector.FromJSonString(AV30ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "ParametroMudanzaWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV30ColumnsSelectorXML)) ? "" : AV32ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E27FS2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E18FS2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV27DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV27DynamicFiltersIgnoreFirst", AV27DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV27DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV27DynamicFiltersIgnoreFirst", AV27DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19ParametroMudanzaTipo1, AV21DynamicFiltersSelector2, AV22ParametroMudanzaTipo2, AV24DynamicFiltersSelector3, AV25ParametroMudanzaTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV83Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFParametroMudanzaId, AV39TFParametroMudanzaId_To, AV41TFParametroMudanzaTipo_Sels, AV72TFParametroMudanzaTitulo, AV73TFParametroMudanzaTitulo_Sel, AV42TFParametroMudanzaNombre, AV43TFParametroMudanzaNombre_Sel, AV62TFParametroMudanzaDescripcion, AV63TFParametroMudanzaDescripcion_Sel, AV44TFParametroMudanzaValor, AV45TFParametroMudanzaValor_To, AV47TFParametroMudanzaUnidad_Sels, AV64TFParametroMudanzaPisoElev, AV65TFParametroMudanzaPisoElev_To, AV74TFParametroMudanzaActivo_Sel, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV55IsAuthorized_Update, AV56IsAuthorized_Delete) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavParametromudanzatipo2.CurrentValue = StringUtil.RTrim( AV22ParametroMudanzaTipo2);
         AssignProp("", false, cmbavParametromudanzatipo2_Internalname, "Values", cmbavParametromudanzatipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavParametromudanzatipo3.CurrentValue = StringUtil.RTrim( AV25ParametroMudanzaTipo3);
         AssignProp("", false, cmbavParametromudanzatipo3_Internalname, "Values", cmbavParametromudanzatipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavParametromudanzatipo1.CurrentValue = StringUtil.RTrim( AV19ParametroMudanzaTipo1);
         AssignProp("", false, cmbavParametromudanzatipo1_Internalname, "Values", cmbavParametromudanzatipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E28FS2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E29FS2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E19FS2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19ParametroMudanzaTipo1, AV21DynamicFiltersSelector2, AV22ParametroMudanzaTipo2, AV24DynamicFiltersSelector3, AV25ParametroMudanzaTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV83Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFParametroMudanzaId, AV39TFParametroMudanzaId_To, AV41TFParametroMudanzaTipo_Sels, AV72TFParametroMudanzaTitulo, AV73TFParametroMudanzaTitulo_Sel, AV42TFParametroMudanzaNombre, AV43TFParametroMudanzaNombre_Sel, AV62TFParametroMudanzaDescripcion, AV63TFParametroMudanzaDescripcion_Sel, AV44TFParametroMudanzaValor, AV45TFParametroMudanzaValor_To, AV47TFParametroMudanzaUnidad_Sels, AV64TFParametroMudanzaPisoElev, AV65TFParametroMudanzaPisoElev_To, AV74TFParametroMudanzaActivo_Sel, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV55IsAuthorized_Update, AV56IsAuthorized_Delete) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavParametromudanzatipo2.CurrentValue = StringUtil.RTrim( AV22ParametroMudanzaTipo2);
         AssignProp("", false, cmbavParametromudanzatipo2_Internalname, "Values", cmbavParametromudanzatipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavParametromudanzatipo3.CurrentValue = StringUtil.RTrim( AV25ParametroMudanzaTipo3);
         AssignProp("", false, cmbavParametromudanzatipo3_Internalname, "Values", cmbavParametromudanzatipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavParametromudanzatipo1.CurrentValue = StringUtil.RTrim( AV19ParametroMudanzaTipo1);
         AssignProp("", false, cmbavParametromudanzatipo1_Internalname, "Values", cmbavParametromudanzatipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E30FS2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E20FS2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV26DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV26DynamicFiltersRemoving", AV26DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19ParametroMudanzaTipo1, AV21DynamicFiltersSelector2, AV22ParametroMudanzaTipo2, AV24DynamicFiltersSelector3, AV25ParametroMudanzaTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV83Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFParametroMudanzaId, AV39TFParametroMudanzaId_To, AV41TFParametroMudanzaTipo_Sels, AV72TFParametroMudanzaTitulo, AV73TFParametroMudanzaTitulo_Sel, AV42TFParametroMudanzaNombre, AV43TFParametroMudanzaNombre_Sel, AV62TFParametroMudanzaDescripcion, AV63TFParametroMudanzaDescripcion_Sel, AV44TFParametroMudanzaValor, AV45TFParametroMudanzaValor_To, AV47TFParametroMudanzaUnidad_Sels, AV64TFParametroMudanzaPisoElev, AV65TFParametroMudanzaPisoElev_To, AV74TFParametroMudanzaActivo_Sel, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV55IsAuthorized_Update, AV56IsAuthorized_Delete) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavParametromudanzatipo2.CurrentValue = StringUtil.RTrim( AV22ParametroMudanzaTipo2);
         AssignProp("", false, cmbavParametromudanzatipo2_Internalname, "Values", cmbavParametromudanzatipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavParametromudanzatipo3.CurrentValue = StringUtil.RTrim( AV25ParametroMudanzaTipo3);
         AssignProp("", false, cmbavParametromudanzatipo3_Internalname, "Values", cmbavParametromudanzatipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavParametromudanzatipo1.CurrentValue = StringUtil.RTrim( AV19ParametroMudanzaTipo1);
         AssignProp("", false, cmbavParametromudanzatipo1_Internalname, "Values", cmbavParametromudanzatipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E31FS2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E11FS2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S242 ();
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
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("ParametroMudanzaWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV83Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("ParametroMudanzaWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV36ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ParametroMudanzaWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV36ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S242 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV83Pgmname+"GridState",  AV36ManageFiltersXml) ;
               AV11GridState.FromXml(AV36ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S252 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S232 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41TFParametroMudanzaTipo_Sels", AV41TFParametroMudanzaTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFParametroMudanzaUnidad_Sels", AV47TFParametroMudanzaUnidad_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavParametromudanzatipo1.CurrentValue = StringUtil.RTrim( AV19ParametroMudanzaTipo1);
         AssignProp("", false, cmbavParametromudanzatipo1_Internalname, "Values", cmbavParametromudanzatipo1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavParametromudanzatipo2.CurrentValue = StringUtil.RTrim( AV22ParametroMudanzaTipo2);
         AssignProp("", false, cmbavParametromudanzatipo2_Internalname, "Values", cmbavParametromudanzatipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavParametromudanzatipo3.CurrentValue = StringUtil.RTrim( AV25ParametroMudanzaTipo3);
         AssignProp("", false, cmbavParametromudanzatipo3_Internalname, "Values", cmbavParametromudanzatipo3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E35FS2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV53GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV53GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV53GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV53GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV53GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV53GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E21FS2( )
      {
         /* 'DoUserAction5' Routine */
         returnInSub = false;
         new actualizartiempoxm3(context ).execute(  AV71TiempoxM3) ;
         GX_msglist.addItem(context.GetMessage( "Valores actualizados", ""));
      }

      protected void E22FS2( )
      {
         /* 'DoUserAction4' Routine */
         returnInSub = false;
         new actualizartiempoxkm(context ).execute(  AV70TiempoKm) ;
         GX_msglist.addItem(context.GetMessage( "Valores actualizados", ""));
      }

      protected void E23FS2( )
      {
         /* 'DoUserAction3' Routine */
         returnInSub = false;
         new actualizarpreciopeon(context ).execute(  AV69PrecioPeon) ;
         GX_msglist.addItem(context.GetMessage( "Valores actualizados", ""));
      }

      protected void E24FS2( )
      {
         /* 'DoUserAction2' Routine */
         returnInSub = false;
         new actualizarpreciobase(context ).execute(  AV66PrecioChico,  AV67PrecioMediano,  AV68PrecioGrande) ;
         GX_msglist.addItem(context.GetMessage( "Valores actualizados", ""));
      }

      protected void E25FS2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         new actualizarprecioembelev(context ).execute(  AV60PrecioEmbMetro3,  AV61PrecioElevPiso) ;
         GX_msglist.addItem(context.GetMessage( "Valores actualizados", ""));
      }

      protected void E26FS2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "parametromudanza.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("parametromudanza.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14FS2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFParametroMudanzaUnidad_Sels", AV47TFParametroMudanzaUnidad_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41TFParametroMudanzaTipo_Sels", AV41TFParametroMudanzaTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavParametromudanzatipo1.CurrentValue = StringUtil.RTrim( AV19ParametroMudanzaTipo1);
         AssignProp("", false, cmbavParametromudanzatipo1_Internalname, "Values", cmbavParametromudanzatipo1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavParametromudanzatipo2.CurrentValue = StringUtil.RTrim( AV22ParametroMudanzaTipo2);
         AssignProp("", false, cmbavParametromudanzatipo2_Internalname, "Values", cmbavParametromudanzatipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavParametromudanzatipo3.CurrentValue = StringUtil.RTrim( AV25ParametroMudanzaTipo3);
         AssignProp("", false, cmbavParametromudanzatipo3_Internalname, "Values", cmbavParametromudanzatipo3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E15FS2( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0210",(string)"",(string)"ParametroMudanza",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0210"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S202( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV32ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "ParametroMudanzaId",  "",  "Mudanza Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "ParametroMudanzaTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "ParametroMudanzaTitulo",  "",  "Título",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "ParametroMudanzaNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "ParametroMudanzaDescripcion",  "",  "Información",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "ParametroMudanzaValor",  "",  "Valor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "ParametroMudanzaUnidad",  "",  "Unidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "ParametroMudanzaPisoElev",  "",  "Piso (elevación)",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "ParametroMudanzaImagen",  "",  "Mudanza Imagen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "ParametroMudanzaActivo",  "",  "Mudanza Activo",  true,  "") ;
         GXt_char2 = AV31UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ParametroMudanzaWWColumnsSelector", out  GXt_char2) ;
         AV31UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV31UserCustomValue)) ) )
         {
            AV33ColumnsSelectorAux.FromXml(AV31UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV33ColumnsSelectorAux, ref  AV32ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV55IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza_Update", out  GXt_boolean3) ;
         AV55IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV55IsAuthorized_Update", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GXt_boolean3 = AV56IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza_Delete", out  GXt_boolean3) ;
         AV56IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV56IsAuthorized_Delete", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         GXt_boolean3 = AV59TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza_Insert", out  GXt_boolean3) ;
         AV59TempBoolean = GXt_boolean3;
         if ( ! ( AV59TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean3 = AV59TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean3) ;
         AV59TempBoolean = GXt_boolean3;
         if ( ! ( AV59TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "ParametroMudanza",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         cmbavParametromudanzatipo1.Visible = 0;
         AssignProp("", false, cmbavParametromudanzatipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavParametromudanzatipo1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PARAMETROMUDANZATIPO") == 0 )
         {
            cmbavParametromudanzatipo1.Visible = 1;
            AssignProp("", false, cmbavParametromudanzatipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavParametromudanzatipo1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavParametromudanzatipo2.Visible = 0;
         AssignProp("", false, cmbavParametromudanzatipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavParametromudanzatipo2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "PARAMETROMUDANZATIPO") == 0 )
         {
            cmbavParametromudanzatipo2.Visible = 1;
            AssignProp("", false, cmbavParametromudanzatipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavParametromudanzatipo2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavParametromudanzatipo3.Visible = 0;
         AssignProp("", false, cmbavParametromudanzatipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavParametromudanzatipo3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PARAMETROMUDANZATIPO") == 0 )
         {
            cmbavParametromudanzatipo3.Visible = 1;
            AssignProp("", false, cmbavParametromudanzatipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavParametromudanzatipo3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "PARAMETROMUDANZATIPO";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV22ParametroMudanzaTipo2 = "";
         AssignAttri("", false, "AV22ParametroMudanzaTipo2", AV22ParametroMudanzaTipo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "PARAMETROMUDANZATIPO";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25ParametroMudanzaTipo3 = "";
         AssignAttri("", false, "AV25ParametroMudanzaTipo3", AV25ParametroMudanzaTipo3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV35ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ParametroMudanzaWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV35ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV38TFParametroMudanzaId = 0;
         AssignAttri("", false, "AV38TFParametroMudanzaId", StringUtil.LTrimStr( (decimal)(AV38TFParametroMudanzaId), 4, 0));
         AV39TFParametroMudanzaId_To = 0;
         AssignAttri("", false, "AV39TFParametroMudanzaId_To", StringUtil.LTrimStr( (decimal)(AV39TFParametroMudanzaId_To), 4, 0));
         AV41TFParametroMudanzaTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV72TFParametroMudanzaTitulo = "";
         AssignAttri("", false, "AV72TFParametroMudanzaTitulo", AV72TFParametroMudanzaTitulo);
         AV73TFParametroMudanzaTitulo_Sel = "";
         AssignAttri("", false, "AV73TFParametroMudanzaTitulo_Sel", AV73TFParametroMudanzaTitulo_Sel);
         AV42TFParametroMudanzaNombre = "";
         AssignAttri("", false, "AV42TFParametroMudanzaNombre", AV42TFParametroMudanzaNombre);
         AV43TFParametroMudanzaNombre_Sel = "";
         AssignAttri("", false, "AV43TFParametroMudanzaNombre_Sel", AV43TFParametroMudanzaNombre_Sel);
         AV62TFParametroMudanzaDescripcion = "";
         AssignAttri("", false, "AV62TFParametroMudanzaDescripcion", AV62TFParametroMudanzaDescripcion);
         AV63TFParametroMudanzaDescripcion_Sel = "";
         AssignAttri("", false, "AV63TFParametroMudanzaDescripcion_Sel", AV63TFParametroMudanzaDescripcion_Sel);
         AV44TFParametroMudanzaValor = 0;
         AssignAttri("", false, "AV44TFParametroMudanzaValor", StringUtil.LTrimStr( AV44TFParametroMudanzaValor, 18, 2));
         AV45TFParametroMudanzaValor_To = 0;
         AssignAttri("", false, "AV45TFParametroMudanzaValor_To", StringUtil.LTrimStr( AV45TFParametroMudanzaValor_To, 18, 2));
         AV47TFParametroMudanzaUnidad_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV64TFParametroMudanzaPisoElev = 0;
         AssignAttri("", false, "AV64TFParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(AV64TFParametroMudanzaPisoElev), 4, 0));
         AV65TFParametroMudanzaPisoElev_To = 0;
         AssignAttri("", false, "AV65TFParametroMudanzaPisoElev_To", StringUtil.LTrimStr( (decimal)(AV65TFParametroMudanzaPisoElev_To), 4, 0));
         AV74TFParametroMudanzaActivo_Sel = 0;
         AssignAttri("", false, "AV74TFParametroMudanzaActivo_Sel", StringUtil.Str( (decimal)(AV74TFParametroMudanzaActivo_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "PARAMETROMUDANZATIPO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19ParametroMudanzaTipo1 = "";
         AssignAttri("", false, "AV19ParametroMudanzaTipo1", AV19ParametroMudanzaTipo1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S262( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "parametromudanzaview.aspx"+UrlEncode(StringUtil.LTrimStr(A730ParametroMudanzaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("parametromudanzaview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "parametromudanza.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A730ParametroMudanzaId,4,0));
         CallWebObject(formatLink("parametromudanza.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "parametromudanza.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A730ParametroMudanzaId,4,0));
         CallWebObject(formatLink("parametromudanza.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get(AV83Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV83Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV34Session.Get(AV83Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
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

      protected void S252( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV108GXV1 = 1;
         while ( AV108GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV108GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAID") == 0 )
            {
               AV38TFParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV38TFParametroMudanzaId", StringUtil.LTrimStr( (decimal)(AV38TFParametroMudanzaId), 4, 0));
               AV39TFParametroMudanzaId_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39TFParametroMudanzaId_To", StringUtil.LTrimStr( (decimal)(AV39TFParametroMudanzaId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATIPO_SEL") == 0 )
            {
               AV40TFParametroMudanzaTipo_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFParametroMudanzaTipo_SelsJson", AV40TFParametroMudanzaTipo_SelsJson);
               AV41TFParametroMudanzaTipo_Sels.FromJSonString(AV40TFParametroMudanzaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATITULO") == 0 )
            {
               AV72TFParametroMudanzaTitulo = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV72TFParametroMudanzaTitulo", AV72TFParametroMudanzaTitulo);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATITULO_SEL") == 0 )
            {
               AV73TFParametroMudanzaTitulo_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV73TFParametroMudanzaTitulo_Sel", AV73TFParametroMudanzaTitulo_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZANOMBRE") == 0 )
            {
               AV42TFParametroMudanzaNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFParametroMudanzaNombre", AV42TFParametroMudanzaNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZANOMBRE_SEL") == 0 )
            {
               AV43TFParametroMudanzaNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFParametroMudanzaNombre_Sel", AV43TFParametroMudanzaNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZADESCRIPCION") == 0 )
            {
               AV62TFParametroMudanzaDescripcion = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV62TFParametroMudanzaDescripcion", AV62TFParametroMudanzaDescripcion);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZADESCRIPCION_SEL") == 0 )
            {
               AV63TFParametroMudanzaDescripcion_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV63TFParametroMudanzaDescripcion_Sel", AV63TFParametroMudanzaDescripcion_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAVALOR") == 0 )
            {
               AV44TFParametroMudanzaValor = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV44TFParametroMudanzaValor", StringUtil.LTrimStr( AV44TFParametroMudanzaValor, 18, 2));
               AV45TFParametroMudanzaValor_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV45TFParametroMudanzaValor_To", StringUtil.LTrimStr( AV45TFParametroMudanzaValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAUNIDAD_SEL") == 0 )
            {
               AV46TFParametroMudanzaUnidad_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFParametroMudanzaUnidad_SelsJson", AV46TFParametroMudanzaUnidad_SelsJson);
               AV47TFParametroMudanzaUnidad_Sels.FromJSonString(AV46TFParametroMudanzaUnidad_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAPISOELEV") == 0 )
            {
               AV64TFParametroMudanzaPisoElev = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV64TFParametroMudanzaPisoElev", StringUtil.LTrimStr( (decimal)(AV64TFParametroMudanzaPisoElev), 4, 0));
               AV65TFParametroMudanzaPisoElev_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV65TFParametroMudanzaPisoElev_To", StringUtil.LTrimStr( (decimal)(AV65TFParametroMudanzaPisoElev_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAACTIVO_SEL") == 0 )
            {
               AV74TFParametroMudanzaActivo_Sel = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV74TFParametroMudanzaActivo_Sel", StringUtil.Str( (decimal)(AV74TFParametroMudanzaActivo_Sel), 1, 0));
            }
            AV108GXV1 = (int)(AV108GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV41TFParametroMudanzaTipo_Sels.Count==0),  AV40TFParametroMudanzaTipo_SelsJson, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV73TFParametroMudanzaTitulo_Sel)),  AV73TFParametroMudanzaTitulo_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFParametroMudanzaNombre_Sel)),  AV43TFParametroMudanzaNombre_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV63TFParametroMudanzaDescripcion_Sel)),  AV63TFParametroMudanzaDescripcion_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV47TFParametroMudanzaUnidad_Sels.Count==0),  AV46TFParametroMudanzaUnidad_SelsJson, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"||"+GXt_char8+"|||"+((0==AV74TFParametroMudanzaActivo_Sel) ? "" : StringUtil.Str( (decimal)(AV74TFParametroMudanzaActivo_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV72TFParametroMudanzaTitulo)),  AV72TFParametroMudanzaTitulo, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFParametroMudanzaNombre)),  AV42TFParametroMudanzaNombre, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV62TFParametroMudanzaDescripcion)),  AV62TFParametroMudanzaDescripcion, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = ((0==AV38TFParametroMudanzaId) ? "" : StringUtil.Str( (decimal)(AV38TFParametroMudanzaId), 4, 0))+"||"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+((Convert.ToDecimal(0)==AV44TFParametroMudanzaValor) ? "" : StringUtil.Str( AV44TFParametroMudanzaValor, 18, 2))+"||"+((0==AV64TFParametroMudanzaPisoElev) ? "" : StringUtil.Str( (decimal)(AV64TFParametroMudanzaPisoElev), 4, 0))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV39TFParametroMudanzaId_To) ? "" : StringUtil.Str( (decimal)(AV39TFParametroMudanzaId_To), 4, 0))+"|||||"+((Convert.ToDecimal(0)==AV45TFParametroMudanzaValor_To) ? "" : StringUtil.Str( AV45TFParametroMudanzaValor_To, 18, 2))+"||"+((0==AV65TFParametroMudanzaPisoElev_To) ? "" : StringUtil.Str( (decimal)(AV65TFParametroMudanzaPisoElev_To), 4, 0))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S232( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PARAMETROMUDANZATIPO") == 0 )
            {
               AV19ParametroMudanzaTipo1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19ParametroMudanzaTipo1", AV19ParametroMudanzaTipo1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "PARAMETROMUDANZATIPO") == 0 )
               {
                  AV22ParametroMudanzaTipo2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV22ParametroMudanzaTipo2", AV22ParametroMudanzaTipo2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV23DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PARAMETROMUDANZATIPO") == 0 )
                  {
                     AV25ParametroMudanzaTipo3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV25ParametroMudanzaTipo3", AV25ParametroMudanzaTipo3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S142 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV26DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV34Session.Get(AV83Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPARAMETROMUDANZAID",  context.GetMessage( "Mudanza Id", ""),  !((0==AV38TFParametroMudanzaId)&&(0==AV39TFParametroMudanzaId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV38TFParametroMudanzaId), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV39TFParametroMudanzaId_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPARAMETROMUDANZATIPO_SEL",  context.GetMessage( "Tipo", ""),  !(AV41TFParametroMudanzaTipo_Sels.Count==0),  0,  AV41TFParametroMudanzaTipo_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPARAMETROMUDANZATITULO",  context.GetMessage( "Título", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV72TFParametroMudanzaTitulo)),  0,  AV72TFParametroMudanzaTitulo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV73TFParametroMudanzaTitulo_Sel)),  AV73TFParametroMudanzaTitulo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPARAMETROMUDANZANOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFParametroMudanzaNombre)),  0,  AV42TFParametroMudanzaNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFParametroMudanzaNombre_Sel)),  AV43TFParametroMudanzaNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPARAMETROMUDANZADESCRIPCION",  context.GetMessage( "Información", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV62TFParametroMudanzaDescripcion)),  0,  AV62TFParametroMudanzaDescripcion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV63TFParametroMudanzaDescripcion_Sel)),  AV63TFParametroMudanzaDescripcion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPARAMETROMUDANZAVALOR",  context.GetMessage( "Valor", ""),  !((Convert.ToDecimal(0)==AV44TFParametroMudanzaValor)&&(Convert.ToDecimal(0)==AV45TFParametroMudanzaValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV44TFParametroMudanzaValor, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV45TFParametroMudanzaValor_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPARAMETROMUDANZAUNIDAD_SEL",  context.GetMessage( "Unidad", ""),  !(AV47TFParametroMudanzaUnidad_Sels.Count==0),  0,  AV47TFParametroMudanzaUnidad_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPARAMETROMUDANZAPISOELEV",  context.GetMessage( "Piso (elevación)", ""),  !((0==AV64TFParametroMudanzaPisoElev)&&(0==AV65TFParametroMudanzaPisoElev_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV64TFParametroMudanzaPisoElev), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV65TFParametroMudanzaPisoElev_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPARAMETROMUDANZAACTIVO_SEL",  context.GetMessage( "Mudanza Activo", ""),  !(0==AV74TFParametroMudanzaActivo_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV74TFParametroMudanzaActivo_Sel), 1, 0)),  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV83Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV27DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PARAMETROMUDANZATIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ParametroMudanzaTipo1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Mudanza Tipo", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV19ParametroMudanzaTipo1;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV21DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "PARAMETROMUDANZATIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ParametroMudanzaTipo2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Mudanza Tipo", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV22ParametroMudanzaTipo2;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV23DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV24DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PARAMETROMUDANZATIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ParametroMudanzaTipo3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Mudanza Tipo", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV25ParametroMudanzaTipo3;
            }
            if ( AV26DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV83Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "ParametroMudanza";
         AV34Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S292( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new parametromudanzawwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
         if ( StringUtil.StrCmp(AV28ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV28ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV29ErrorMessage);
         }
      }

      protected void S302( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("parametromudanzawwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_87_FS2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_3_Internalname, tblUnnamedtabledynamicfilters_3_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_parametromudanzatipo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavParametromudanzatipo3_Internalname, context.GetMessage( "Parametro Mudanza Tipo3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_184_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavParametromudanzatipo3, cmbavParametromudanzatipo3_Internalname, StringUtil.RTrim( AV25ParametroMudanzaTipo3), 1, cmbavParametromudanzatipo3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavParametromudanzatipo3.Visible, cmbavParametromudanzatipo3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_ParametroMudanzaWW.htm");
            cmbavParametromudanzatipo3.CurrentValue = StringUtil.RTrim( AV25ParametroMudanzaTipo3);
            AssignProp("", false, cmbavParametromudanzatipo3_Internalname, "Values", (string)(cmbavParametromudanzatipo3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ParametroMudanzaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_87_FS2e( true) ;
         }
         else
         {
            wb_table4_87_FS2e( false) ;
         }
      }

      protected void wb_table3_68_FS2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_2_Internalname, tblUnnamedtabledynamicfilters_2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_parametromudanzatipo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavParametromudanzatipo2_Internalname, context.GetMessage( "Parametro Mudanza Tipo2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_184_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavParametromudanzatipo2, cmbavParametromudanzatipo2_Internalname, StringUtil.RTrim( AV22ParametroMudanzaTipo2), 1, cmbavParametromudanzatipo2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavParametromudanzatipo2.Visible, cmbavParametromudanzatipo2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_ParametroMudanzaWW.htm");
            cmbavParametromudanzatipo2.CurrentValue = StringUtil.RTrim( AV22ParametroMudanzaTipo2);
            AssignProp("", false, cmbavParametromudanzatipo2_Internalname, "Values", (string)(cmbavParametromudanzatipo2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ParametroMudanzaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ParametroMudanzaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_68_FS2e( true) ;
         }
         else
         {
            wb_table3_68_FS2e( false) ;
         }
      }

      protected void wb_table2_49_FS2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_1_Internalname, tblUnnamedtabledynamicfilters_1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_parametromudanzatipo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavParametromudanzatipo1_Internalname, context.GetMessage( "Parametro Mudanza Tipo1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_184_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavParametromudanzatipo1, cmbavParametromudanzatipo1_Internalname, StringUtil.RTrim( AV19ParametroMudanzaTipo1), 1, cmbavParametromudanzatipo1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavParametromudanzatipo1.Visible, cmbavParametromudanzatipo1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_ParametroMudanzaWW.htm");
            cmbavParametromudanzatipo1.CurrentValue = StringUtil.RTrim( AV19ParametroMudanzaTipo1);
            AssignProp("", false, cmbavParametromudanzatipo1_Internalname, "Values", (string)(cmbavParametromudanzatipo1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ParametroMudanzaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ParametroMudanzaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_FS2e( true) ;
         }
         else
         {
            wb_table2_49_FS2e( false) ;
         }
      }

      protected void wb_table1_25_FS2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV35ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_30_FS2( true) ;
         }
         else
         {
            wb_table5_30_FS2( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_FS2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_FS2e( true) ;
         }
         else
         {
            wb_table1_25_FS2e( false) ;
         }
      }

      protected void wb_table5_30_FS2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_184_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ParametroMudanzaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_FS2e( true) ;
         }
         else
         {
            wb_table5_30_FS2e( false) ;
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
         PAFS2( ) ;
         WSFS2( ) ;
         WEFS2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021234963", true, true, false);
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
         context.AddJavascriptSource("parametromudanzaww.js", "?202673021234964", false, true, false);
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

      protected void SubsflControlProps_1842( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_184_idx;
         edtParametroMudanzaId_Internalname = "PARAMETROMUDANZAID_"+sGXsfl_184_idx;
         cmbParametroMudanzaTipo_Internalname = "PARAMETROMUDANZATIPO_"+sGXsfl_184_idx;
         edtParametroMudanzaTitulo_Internalname = "PARAMETROMUDANZATITULO_"+sGXsfl_184_idx;
         edtParametroMudanzaNombre_Internalname = "PARAMETROMUDANZANOMBRE_"+sGXsfl_184_idx;
         edtParametroMudanzaDescripcion_Internalname = "PARAMETROMUDANZADESCRIPCION_"+sGXsfl_184_idx;
         edtParametroMudanzaValor_Internalname = "PARAMETROMUDANZAVALOR_"+sGXsfl_184_idx;
         cmbParametroMudanzaUnidad_Internalname = "PARAMETROMUDANZAUNIDAD_"+sGXsfl_184_idx;
         edtParametroMudanzaPisoElev_Internalname = "PARAMETROMUDANZAPISOELEV_"+sGXsfl_184_idx;
         edtParametroMudanzaImagen_Internalname = "PARAMETROMUDANZAIMAGEN_"+sGXsfl_184_idx;
         chkParametroMudanzaActivo_Internalname = "PARAMETROMUDANZAACTIVO_"+sGXsfl_184_idx;
      }

      protected void SubsflControlProps_fel_1842( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_184_fel_idx;
         edtParametroMudanzaId_Internalname = "PARAMETROMUDANZAID_"+sGXsfl_184_fel_idx;
         cmbParametroMudanzaTipo_Internalname = "PARAMETROMUDANZATIPO_"+sGXsfl_184_fel_idx;
         edtParametroMudanzaTitulo_Internalname = "PARAMETROMUDANZATITULO_"+sGXsfl_184_fel_idx;
         edtParametroMudanzaNombre_Internalname = "PARAMETROMUDANZANOMBRE_"+sGXsfl_184_fel_idx;
         edtParametroMudanzaDescripcion_Internalname = "PARAMETROMUDANZADESCRIPCION_"+sGXsfl_184_fel_idx;
         edtParametroMudanzaValor_Internalname = "PARAMETROMUDANZAVALOR_"+sGXsfl_184_fel_idx;
         cmbParametroMudanzaUnidad_Internalname = "PARAMETROMUDANZAUNIDAD_"+sGXsfl_184_fel_idx;
         edtParametroMudanzaPisoElev_Internalname = "PARAMETROMUDANZAPISOELEV_"+sGXsfl_184_fel_idx;
         edtParametroMudanzaImagen_Internalname = "PARAMETROMUDANZAIMAGEN_"+sGXsfl_184_fel_idx;
         chkParametroMudanzaActivo_Internalname = "PARAMETROMUDANZAACTIVO_"+sGXsfl_184_fel_idx;
      }

      protected void sendrow_1842( )
      {
         sGXsfl_184_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_184_idx), 4, 0), 4, "0");
         SubsflControlProps_1842( ) ;
         WBFS0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_184_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_184_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_184_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 185,'',false,'" + sGXsfl_184_idx + "',184)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_184_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV53GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV53GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV53GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV53GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_184_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,185);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV53GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_184_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtParametroMudanzaId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroMudanzaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A730ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroMudanzaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtParametroMudanzaId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)184,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbParametroMudanzaTipo.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbParametroMudanzaTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PARAMETROMUDANZATIPO_" + sGXsfl_184_idx;
               cmbParametroMudanzaTipo.Name = GXCCtl;
               cmbParametroMudanzaTipo.WebTags = "";
               cmbParametroMudanzaTipo.addItem("TipoInmuebleCasa", context.GetMessage( "Tipo Inmueble Casa", ""), 0);
               cmbParametroMudanzaTipo.addItem("TipoEstacionamiento", context.GetMessage( "Tipo Estacionamiento", ""), 0);
               cmbParametroMudanzaTipo.addItem("TipoVehiculo", context.GetMessage( "Tipo Vehiculo", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemCargaHogar", context.GetMessage( "Electro Hogar", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemAdicional", context.GetMessage( "Item Adicional", ""), 0);
               cmbParametroMudanzaTipo.addItem("Peaje", context.GetMessage( "Peaje", ""), 0);
               cmbParametroMudanzaTipo.addItem("TipoInmuebleApto", context.GetMessage( "Tipo Inmueble Apto", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemCargaMobiliario", context.GetMessage( "Mobiliario", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemCargaExterior", context.GetMessage( "Exterior y Jardín", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemCargaDecoracion", context.GetMessage( "Decoración", ""), 0);
               cmbParametroMudanzaTipo.addItem("ItemCargaOtros", context.GetMessage( "Otros", ""), 0);
               cmbParametroMudanzaTipo.addItem("Escalera", context.GetMessage( "Escalera", ""), 0);
               cmbParametroMudanzaTipo.addItem("Ascensor", context.GetMessage( "Ascensor", ""), 0);
               cmbParametroMudanzaTipo.addItem("EscaAsce", context.GetMessage( "Esca+Asce", ""), 0);
               cmbParametroMudanzaTipo.addItem("PrecioEmbalaje", context.GetMessage( "Precio Embalaje", ""), 0);
               cmbParametroMudanzaTipo.addItem("PrecioElevacion", context.GetMessage( "Precio Elevacion", ""), 0);
               cmbParametroMudanzaTipo.addItem("PrecioBase", context.GetMessage( "Precio Base", ""), 0);
               cmbParametroMudanzaTipo.addItem("TiempoxKm", context.GetMessage( "Tiempox Km", ""), 0);
               cmbParametroMudanzaTipo.addItem("TiempoxM3", context.GetMessage( "Tiempox M3", ""), 0);
               if ( cmbParametroMudanzaTipo.ItemCount > 0 )
               {
                  A731ParametroMudanzaTipo = cmbParametroMudanzaTipo.getValidValue(A731ParametroMudanzaTipo);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbParametroMudanzaTipo,(string)cmbParametroMudanzaTipo_Internalname,StringUtil.RTrim( A731ParametroMudanzaTipo),(short)1,(string)cmbParametroMudanzaTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",cmbParametroMudanzaTipo.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbParametroMudanzaTipo.CurrentValue = StringUtil.RTrim( A731ParametroMudanzaTipo);
            AssignProp("", false, cmbParametroMudanzaTipo_Internalname, "Values", (string)(cmbParametroMudanzaTipo.ToJavascriptSource()), !bGXsfl_184_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtParametroMudanzaTitulo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroMudanzaTitulo_Internalname,(string)A869ParametroMudanzaTitulo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroMudanzaTitulo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtParametroMudanzaTitulo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)184,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtParametroMudanzaNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroMudanzaNombre_Internalname,(string)A732ParametroMudanzaNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroMudanzaNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtParametroMudanzaNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)184,(short)0,(short)-1,(short)-1,(bool)true,(string)"ParametroNombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtParametroMudanzaDescripcion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroMudanzaDescripcion_Internalname,(string)A812ParametroMudanzaDescripcion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroMudanzaDescripcion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtParametroMudanzaDescripcion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)184,(short)0,(short)-1,(short)-1,(bool)true,(string)"ParametroNombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtParametroMudanzaValor_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroMudanzaValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A733ParametroMudanzaValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A733ParametroMudanzaValor, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroMudanzaValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtParametroMudanzaValor_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)184,(short)0,(short)-1,(short)0,(bool)true,(string)"ParametroValor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbParametroMudanzaUnidad.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbParametroMudanzaUnidad.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PARAMETROMUDANZAUNIDAD_" + sGXsfl_184_idx;
               cmbParametroMudanzaUnidad.Name = GXCCtl;
               cmbParametroMudanzaUnidad.WebTags = "";
               cmbParametroMudanzaUnidad.addItem("m3", context.GetMessage( "m3", ""), 0);
               cmbParametroMudanzaUnidad.addItem("$", context.GetMessage( "Pesos", ""), 0);
               cmbParametroMudanzaUnidad.addItem("u", context.GetMessage( "Unidades", ""), 0);
               cmbParametroMudanzaUnidad.addItem("mi", context.GetMessage( "Minutos", ""), 0);
               cmbParametroMudanzaUnidad.addItem("%", "%", 0);
               cmbParametroMudanzaUnidad.addItem("mm", context.GetMessage( "Min/m3", ""), 0);
               if ( cmbParametroMudanzaUnidad.ItemCount > 0 )
               {
                  A734ParametroMudanzaUnidad = cmbParametroMudanzaUnidad.getValidValue(A734ParametroMudanzaUnidad);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbParametroMudanzaUnidad,(string)cmbParametroMudanzaUnidad_Internalname,StringUtil.RTrim( A734ParametroMudanzaUnidad),(short)1,(string)cmbParametroMudanzaUnidad_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbParametroMudanzaUnidad.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbParametroMudanzaUnidad.CurrentValue = StringUtil.RTrim( A734ParametroMudanzaUnidad);
            AssignProp("", false, cmbParametroMudanzaUnidad_Internalname, "Values", (string)(cmbParametroMudanzaUnidad.ToJavascriptSource()), !bGXsfl_184_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtParametroMudanzaPisoElev_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroMudanzaPisoElev_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A818ParametroMudanzaPisoElev), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A818ParametroMudanzaPisoElev), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroMudanzaPisoElev_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtParametroMudanzaPisoElev_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)184,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtParametroMudanzaImagen_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A870ParametroMudanzaImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ParametroMudanzaImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : context.PathToRelativeUrl( A870ParametroMudanzaImagen));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroMudanzaImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtParametroMudanzaImagen_Visible,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A870ParametroMudanzaImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkParametroMudanzaActivo.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "PARAMETROMUDANZAACTIVO_" + sGXsfl_184_idx;
            chkParametroMudanzaActivo.Name = GXCCtl;
            chkParametroMudanzaActivo.WebTags = "";
            chkParametroMudanzaActivo.Caption = "";
            AssignProp("", false, chkParametroMudanzaActivo_Internalname, "TitleCaption", chkParametroMudanzaActivo.Caption, !bGXsfl_184_Refreshing);
            chkParametroMudanzaActivo.CheckedValue = "false";
            A877ParametroMudanzaActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A877ParametroMudanzaActivo));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkParametroMudanzaActivo_Internalname,StringUtil.BoolToStr( A877ParametroMudanzaActivo),(string)"",(string)"",chkParametroMudanzaActivo.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            send_integrity_lvl_hashesFS2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_184_idx = ((subGrid_Islastpage==1)&&(nGXsfl_184_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_184_idx+1);
            sGXsfl_184_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_184_idx), 4, 0), 4, "0");
            SubsflControlProps_1842( ) ;
         }
         /* End function sendrow_1842 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("PARAMETROMUDANZATIPO", context.GetMessage( "Mudanza Tipo", ""), 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavParametromudanzatipo1.Name = "vPARAMETROMUDANZATIPO1";
         cmbavParametromudanzatipo1.WebTags = "";
         cmbavParametromudanzatipo1.addItem("", context.GetMessage( "WWP_AllInCombo", ""), 0);
         cmbavParametromudanzatipo1.addItem("TipoInmuebleCasa", context.GetMessage( "Tipo Inmueble Casa", ""), 0);
         cmbavParametromudanzatipo1.addItem("TipoEstacionamiento", context.GetMessage( "Tipo Estacionamiento", ""), 0);
         cmbavParametromudanzatipo1.addItem("TipoVehiculo", context.GetMessage( "Tipo Vehiculo", ""), 0);
         cmbavParametromudanzatipo1.addItem("ItemCargaHogar", context.GetMessage( "Electro Hogar", ""), 0);
         cmbavParametromudanzatipo1.addItem("ItemAdicional", context.GetMessage( "Item Adicional", ""), 0);
         cmbavParametromudanzatipo1.addItem("Peaje", context.GetMessage( "Peaje", ""), 0);
         cmbavParametromudanzatipo1.addItem("TipoInmuebleApto", context.GetMessage( "Tipo Inmueble Apto", ""), 0);
         cmbavParametromudanzatipo1.addItem("ItemCargaMobiliario", context.GetMessage( "Mobiliario", ""), 0);
         cmbavParametromudanzatipo1.addItem("ItemCargaExterior", context.GetMessage( "Exterior y Jardín", ""), 0);
         cmbavParametromudanzatipo1.addItem("ItemCargaDecoracion", context.GetMessage( "Decoración", ""), 0);
         cmbavParametromudanzatipo1.addItem("ItemCargaOtros", context.GetMessage( "Otros", ""), 0);
         cmbavParametromudanzatipo1.addItem("Escalera", context.GetMessage( "Escalera", ""), 0);
         cmbavParametromudanzatipo1.addItem("Ascensor", context.GetMessage( "Ascensor", ""), 0);
         cmbavParametromudanzatipo1.addItem("EscaAsce", context.GetMessage( "Esca+Asce", ""), 0);
         cmbavParametromudanzatipo1.addItem("PrecioEmbalaje", context.GetMessage( "Precio Embalaje", ""), 0);
         cmbavParametromudanzatipo1.addItem("PrecioElevacion", context.GetMessage( "Precio Elevacion", ""), 0);
         cmbavParametromudanzatipo1.addItem("PrecioBase", context.GetMessage( "Precio Base", ""), 0);
         cmbavParametromudanzatipo1.addItem("TiempoxKm", context.GetMessage( "Tiempox Km", ""), 0);
         cmbavParametromudanzatipo1.addItem("TiempoxM3", context.GetMessage( "Tiempox M3", ""), 0);
         if ( cmbavParametromudanzatipo1.ItemCount > 0 )
         {
            AV19ParametroMudanzaTipo1 = cmbavParametromudanzatipo1.getValidValue(AV19ParametroMudanzaTipo1);
            AssignAttri("", false, "AV19ParametroMudanzaTipo1", AV19ParametroMudanzaTipo1);
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("PARAMETROMUDANZATIPO", context.GetMessage( "Mudanza Tipo", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         cmbavParametromudanzatipo2.Name = "vPARAMETROMUDANZATIPO2";
         cmbavParametromudanzatipo2.WebTags = "";
         cmbavParametromudanzatipo2.addItem("", context.GetMessage( "WWP_AllInCombo", ""), 0);
         cmbavParametromudanzatipo2.addItem("TipoInmuebleCasa", context.GetMessage( "Tipo Inmueble Casa", ""), 0);
         cmbavParametromudanzatipo2.addItem("TipoEstacionamiento", context.GetMessage( "Tipo Estacionamiento", ""), 0);
         cmbavParametromudanzatipo2.addItem("TipoVehiculo", context.GetMessage( "Tipo Vehiculo", ""), 0);
         cmbavParametromudanzatipo2.addItem("ItemCargaHogar", context.GetMessage( "Electro Hogar", ""), 0);
         cmbavParametromudanzatipo2.addItem("ItemAdicional", context.GetMessage( "Item Adicional", ""), 0);
         cmbavParametromudanzatipo2.addItem("Peaje", context.GetMessage( "Peaje", ""), 0);
         cmbavParametromudanzatipo2.addItem("TipoInmuebleApto", context.GetMessage( "Tipo Inmueble Apto", ""), 0);
         cmbavParametromudanzatipo2.addItem("ItemCargaMobiliario", context.GetMessage( "Mobiliario", ""), 0);
         cmbavParametromudanzatipo2.addItem("ItemCargaExterior", context.GetMessage( "Exterior y Jardín", ""), 0);
         cmbavParametromudanzatipo2.addItem("ItemCargaDecoracion", context.GetMessage( "Decoración", ""), 0);
         cmbavParametromudanzatipo2.addItem("ItemCargaOtros", context.GetMessage( "Otros", ""), 0);
         cmbavParametromudanzatipo2.addItem("Escalera", context.GetMessage( "Escalera", ""), 0);
         cmbavParametromudanzatipo2.addItem("Ascensor", context.GetMessage( "Ascensor", ""), 0);
         cmbavParametromudanzatipo2.addItem("EscaAsce", context.GetMessage( "Esca+Asce", ""), 0);
         cmbavParametromudanzatipo2.addItem("PrecioEmbalaje", context.GetMessage( "Precio Embalaje", ""), 0);
         cmbavParametromudanzatipo2.addItem("PrecioElevacion", context.GetMessage( "Precio Elevacion", ""), 0);
         cmbavParametromudanzatipo2.addItem("PrecioBase", context.GetMessage( "Precio Base", ""), 0);
         cmbavParametromudanzatipo2.addItem("TiempoxKm", context.GetMessage( "Tiempox Km", ""), 0);
         cmbavParametromudanzatipo2.addItem("TiempoxM3", context.GetMessage( "Tiempox M3", ""), 0);
         if ( cmbavParametromudanzatipo2.ItemCount > 0 )
         {
            AV22ParametroMudanzaTipo2 = cmbavParametromudanzatipo2.getValidValue(AV22ParametroMudanzaTipo2);
            AssignAttri("", false, "AV22ParametroMudanzaTipo2", AV22ParametroMudanzaTipo2);
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("PARAMETROMUDANZATIPO", context.GetMessage( "Mudanza Tipo", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         cmbavParametromudanzatipo3.Name = "vPARAMETROMUDANZATIPO3";
         cmbavParametromudanzatipo3.WebTags = "";
         cmbavParametromudanzatipo3.addItem("", context.GetMessage( "WWP_AllInCombo", ""), 0);
         cmbavParametromudanzatipo3.addItem("TipoInmuebleCasa", context.GetMessage( "Tipo Inmueble Casa", ""), 0);
         cmbavParametromudanzatipo3.addItem("TipoEstacionamiento", context.GetMessage( "Tipo Estacionamiento", ""), 0);
         cmbavParametromudanzatipo3.addItem("TipoVehiculo", context.GetMessage( "Tipo Vehiculo", ""), 0);
         cmbavParametromudanzatipo3.addItem("ItemCargaHogar", context.GetMessage( "Electro Hogar", ""), 0);
         cmbavParametromudanzatipo3.addItem("ItemAdicional", context.GetMessage( "Item Adicional", ""), 0);
         cmbavParametromudanzatipo3.addItem("Peaje", context.GetMessage( "Peaje", ""), 0);
         cmbavParametromudanzatipo3.addItem("TipoInmuebleApto", context.GetMessage( "Tipo Inmueble Apto", ""), 0);
         cmbavParametromudanzatipo3.addItem("ItemCargaMobiliario", context.GetMessage( "Mobiliario", ""), 0);
         cmbavParametromudanzatipo3.addItem("ItemCargaExterior", context.GetMessage( "Exterior y Jardín", ""), 0);
         cmbavParametromudanzatipo3.addItem("ItemCargaDecoracion", context.GetMessage( "Decoración", ""), 0);
         cmbavParametromudanzatipo3.addItem("ItemCargaOtros", context.GetMessage( "Otros", ""), 0);
         cmbavParametromudanzatipo3.addItem("Escalera", context.GetMessage( "Escalera", ""), 0);
         cmbavParametromudanzatipo3.addItem("Ascensor", context.GetMessage( "Ascensor", ""), 0);
         cmbavParametromudanzatipo3.addItem("EscaAsce", context.GetMessage( "Esca+Asce", ""), 0);
         cmbavParametromudanzatipo3.addItem("PrecioEmbalaje", context.GetMessage( "Precio Embalaje", ""), 0);
         cmbavParametromudanzatipo3.addItem("PrecioElevacion", context.GetMessage( "Precio Elevacion", ""), 0);
         cmbavParametromudanzatipo3.addItem("PrecioBase", context.GetMessage( "Precio Base", ""), 0);
         cmbavParametromudanzatipo3.addItem("TiempoxKm", context.GetMessage( "Tiempox Km", ""), 0);
         cmbavParametromudanzatipo3.addItem("TiempoxM3", context.GetMessage( "Tiempox M3", ""), 0);
         if ( cmbavParametromudanzatipo3.ItemCount > 0 )
         {
            AV25ParametroMudanzaTipo3 = cmbavParametromudanzatipo3.getValidValue(AV25ParametroMudanzaTipo3);
            AssignAttri("", false, "AV25ParametroMudanzaTipo3", AV25ParametroMudanzaTipo3);
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_184_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV53GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV53GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV53GridActions), 4, 0));
         }
         GXCCtl = "PARAMETROMUDANZATIPO_" + sGXsfl_184_idx;
         cmbParametroMudanzaTipo.Name = GXCCtl;
         cmbParametroMudanzaTipo.WebTags = "";
         cmbParametroMudanzaTipo.addItem("TipoInmuebleCasa", context.GetMessage( "Tipo Inmueble Casa", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoEstacionamiento", context.GetMessage( "Tipo Estacionamiento", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoVehiculo", context.GetMessage( "Tipo Vehiculo", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaHogar", context.GetMessage( "Electro Hogar", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemAdicional", context.GetMessage( "Item Adicional", ""), 0);
         cmbParametroMudanzaTipo.addItem("Peaje", context.GetMessage( "Peaje", ""), 0);
         cmbParametroMudanzaTipo.addItem("TipoInmuebleApto", context.GetMessage( "Tipo Inmueble Apto", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaMobiliario", context.GetMessage( "Mobiliario", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaExterior", context.GetMessage( "Exterior y Jardín", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaDecoracion", context.GetMessage( "Decoración", ""), 0);
         cmbParametroMudanzaTipo.addItem("ItemCargaOtros", context.GetMessage( "Otros", ""), 0);
         cmbParametroMudanzaTipo.addItem("Escalera", context.GetMessage( "Escalera", ""), 0);
         cmbParametroMudanzaTipo.addItem("Ascensor", context.GetMessage( "Ascensor", ""), 0);
         cmbParametroMudanzaTipo.addItem("EscaAsce", context.GetMessage( "Esca+Asce", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioEmbalaje", context.GetMessage( "Precio Embalaje", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioElevacion", context.GetMessage( "Precio Elevacion", ""), 0);
         cmbParametroMudanzaTipo.addItem("PrecioBase", context.GetMessage( "Precio Base", ""), 0);
         cmbParametroMudanzaTipo.addItem("TiempoxKm", context.GetMessage( "Tiempox Km", ""), 0);
         cmbParametroMudanzaTipo.addItem("TiempoxM3", context.GetMessage( "Tiempox M3", ""), 0);
         if ( cmbParametroMudanzaTipo.ItemCount > 0 )
         {
            A731ParametroMudanzaTipo = cmbParametroMudanzaTipo.getValidValue(A731ParametroMudanzaTipo);
         }
         GXCCtl = "PARAMETROMUDANZAUNIDAD_" + sGXsfl_184_idx;
         cmbParametroMudanzaUnidad.Name = GXCCtl;
         cmbParametroMudanzaUnidad.WebTags = "";
         cmbParametroMudanzaUnidad.addItem("m3", context.GetMessage( "m3", ""), 0);
         cmbParametroMudanzaUnidad.addItem("$", context.GetMessage( "Pesos", ""), 0);
         cmbParametroMudanzaUnidad.addItem("u", context.GetMessage( "Unidades", ""), 0);
         cmbParametroMudanzaUnidad.addItem("mi", context.GetMessage( "Minutos", ""), 0);
         cmbParametroMudanzaUnidad.addItem("%", "%", 0);
         cmbParametroMudanzaUnidad.addItem("mm", context.GetMessage( "Min/m3", ""), 0);
         if ( cmbParametroMudanzaUnidad.ItemCount > 0 )
         {
            A734ParametroMudanzaUnidad = cmbParametroMudanzaUnidad.getValidValue(A734ParametroMudanzaUnidad);
         }
         GXCCtl = "PARAMETROMUDANZAACTIVO_" + sGXsfl_184_idx;
         chkParametroMudanzaActivo.Name = GXCCtl;
         chkParametroMudanzaActivo.WebTags = "";
         chkParametroMudanzaActivo.Caption = "";
         AssignProp("", false, chkParametroMudanzaActivo_Internalname, "TitleCaption", chkParametroMudanzaActivo.Caption, !bGXsfl_184_Refreshing);
         chkParametroMudanzaActivo.CheckedValue = "false";
         A877ParametroMudanzaActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A877ParametroMudanzaActivo));
         /* End function init_web_controls */
      }

      protected void StartGridControl184( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"184\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroMudanzaId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mudanza Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbParametroMudanzaTipo.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroMudanzaTitulo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Título", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroMudanzaNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroMudanzaDescripcion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Información", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroMudanzaValor_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Valor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbParametroMudanzaUnidad.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Unidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroMudanzaPisoElev_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Piso (elevación)", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroMudanzaImagen_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mudanza Imagen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkParametroMudanzaActivo.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mudanza Activo", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A730ParametroMudanzaId), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroMudanzaId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A731ParametroMudanzaTipo));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbParametroMudanzaTipo.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A869ParametroMudanzaTitulo));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroMudanzaTitulo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A732ParametroMudanzaNombre));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroMudanzaNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A812ParametroMudanzaDescripcion));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroMudanzaDescripcion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A733ParametroMudanzaValor, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroMudanzaValor_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A734ParametroMudanzaUnidad)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbParametroMudanzaUnidad.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A818ParametroMudanzaPisoElev), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroMudanzaPisoElev_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A870ParametroMudanzaImagen));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroMudanzaImagen_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A877ParametroMudanzaActivo)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkParametroMudanzaActivo.Visible), 5, 0, ".", "")));
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
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavParametromudanzatipo1_Internalname = "vPARAMETROMUDANZATIPO1";
         cellFilter_parametromudanzatipo1_cell_Internalname = "FILTER_PARAMETROMUDANZATIPO1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblUnnamedtabledynamicfilters_1_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavParametromudanzatipo2_Internalname = "vPARAMETROMUDANZATIPO2";
         cellFilter_parametromudanzatipo2_cell_Internalname = "FILTER_PARAMETROMUDANZATIPO2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblUnnamedtabledynamicfilters_2_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavParametromudanzatipo3_Internalname = "vPARAMETROMUDANZATIPO3";
         cellFilter_parametromudanzatipo3_cell_Internalname = "FILTER_PARAMETROMUDANZATIPO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblUnnamedtabledynamicfilters_3_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         edtavPrecioembmetro3_Internalname = "vPRECIOEMBMETRO3";
         edtavPrecioelevpiso_Internalname = "vPRECIOELEVPISO";
         bttBtnuseraction1_Internalname = "BTNUSERACTION1";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         grpUnnamedgroup3_Internalname = "UNNAMEDGROUP3";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavPreciochico_Internalname = "vPRECIOCHICO";
         edtavPreciomediano_Internalname = "vPRECIOMEDIANO";
         edtavPreciogrande_Internalname = "vPRECIOGRANDE";
         bttBtnuseraction2_Internalname = "BTNUSERACTION2";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         grpUnnamedgroup5_Internalname = "UNNAMEDGROUP5";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtavPreciopeon_Internalname = "vPRECIOPEON";
         bttBtnuseraction3_Internalname = "BTNUSERACTION3";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         grpUnnamedgroup7_Internalname = "UNNAMEDGROUP7";
         edtavTiempokm_Internalname = "vTIEMPOKM";
         bttBtnuseraction4_Internalname = "BTNUSERACTION4";
         divUnnamedtable8_Internalname = "UNNAMEDTABLE8";
         grpUnnamedgroup9_Internalname = "UNNAMEDGROUP9";
         edtavTiempoxm3_Internalname = "vTIEMPOXM3";
         bttBtnuseraction5_Internalname = "BTNUSERACTION5";
         divUnnamedtable10_Internalname = "UNNAMEDTABLE10";
         grpUnnamedgroup11_Internalname = "UNNAMEDGROUP11";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtParametroMudanzaId_Internalname = "PARAMETROMUDANZAID";
         cmbParametroMudanzaTipo_Internalname = "PARAMETROMUDANZATIPO";
         edtParametroMudanzaTitulo_Internalname = "PARAMETROMUDANZATITULO";
         edtParametroMudanzaNombre_Internalname = "PARAMETROMUDANZANOMBRE";
         edtParametroMudanzaDescripcion_Internalname = "PARAMETROMUDANZADESCRIPCION";
         edtParametroMudanzaValor_Internalname = "PARAMETROMUDANZAVALOR";
         cmbParametroMudanzaUnidad_Internalname = "PARAMETROMUDANZAUNIDAD";
         edtParametroMudanzaPisoElev_Internalname = "PARAMETROMUDANZAPISOELEV";
         edtParametroMudanzaImagen_Internalname = "PARAMETROMUDANZAIMAGEN";
         chkParametroMudanzaActivo_Internalname = "PARAMETROMUDANZAACTIVO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
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
         chkParametroMudanzaActivo.Caption = "";
         edtParametroMudanzaPisoElev_Jsonclick = "";
         cmbParametroMudanzaUnidad_Jsonclick = "";
         edtParametroMudanzaValor_Jsonclick = "";
         edtParametroMudanzaDescripcion_Jsonclick = "";
         edtParametroMudanzaNombre_Jsonclick = "";
         edtParametroMudanzaTitulo_Jsonclick = "";
         cmbParametroMudanzaTipo_Jsonclick = "";
         edtParametroMudanzaId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         cmbavParametromudanzatipo1_Jsonclick = "";
         cmbavParametromudanzatipo1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         cmbavParametromudanzatipo2_Jsonclick = "";
         cmbavParametromudanzatipo2.Enabled = 1;
         cmbavParametromudanzatipo3_Jsonclick = "";
         cmbavParametromudanzatipo3.Enabled = 1;
         cmbavParametromudanzatipo3.Visible = 1;
         cmbavParametromudanzatipo2.Visible = 1;
         cmbavParametromudanzatipo1.Visible = 1;
         chkParametroMudanzaActivo.Visible = -1;
         edtParametroMudanzaImagen_Visible = -1;
         edtParametroMudanzaPisoElev_Visible = -1;
         cmbParametroMudanzaUnidad.Visible = -1;
         edtParametroMudanzaValor_Visible = -1;
         edtParametroMudanzaDescripcion_Visible = -1;
         edtParametroMudanzaNombre_Visible = -1;
         edtParametroMudanzaTitulo_Visible = -1;
         cmbParametroMudanzaTipo.Visible = -1;
         edtParametroMudanzaId_Visible = -1;
         chkParametroMudanzaActivo.Enabled = 0;
         edtParametroMudanzaImagen_Enabled = 0;
         edtParametroMudanzaPisoElev_Enabled = 0;
         cmbParametroMudanzaUnidad.Enabled = 0;
         edtParametroMudanzaValor_Enabled = 0;
         edtParametroMudanzaDescripcion_Enabled = 0;
         edtParametroMudanzaNombre_Enabled = 0;
         edtParametroMudanzaTitulo_Enabled = 0;
         cmbParametroMudanzaTipo.Enabled = 0;
         edtParametroMudanzaId_Enabled = 0;
         subGrid_Sortable = 0;
         lblJsdynamicfilters_Caption = context.GetMessage( "JSDynamicFilters", "");
         edtavTiempoxm3_Jsonclick = "";
         edtavTiempoxm3_Enabled = 1;
         edtavTiempokm_Jsonclick = "";
         edtavTiempokm_Enabled = 1;
         edtavPreciopeon_Jsonclick = "";
         edtavPreciopeon_Enabled = 1;
         edtavPreciogrande_Jsonclick = "";
         edtavPreciogrande_Enabled = 1;
         edtavPreciomediano_Jsonclick = "";
         edtavPreciomediano_Enabled = 1;
         edtavPreciochico_Jsonclick = "";
         edtavPreciochico_Enabled = 1;
         edtavPrecioelevpiso_Jsonclick = "";
         edtavPrecioelevpiso_Enabled = 1;
         edtavPrecioembmetro3_Jsonclick = "";
         edtavPrecioembmetro3_Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;";
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
         Ddo_grid_Format = "4.0|||||8.2||4.0||";
         Ddo_grid_Datalistproc = "ParametroMudanzaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|TipoInmuebleCasa:Tipo Inmueble Casa,TipoEstacionamiento:Tipo Estacionamiento,TipoVehiculo:Tipo Vehiculo,ItemCargaHogar:Electro Hogar,ItemAdicional:Item Adicional,Peaje:Peaje,TipoInmuebleApto:Tipo Inmueble Apto,ItemCargaMobiliario:Mobiliario,ItemCargaExterior:Exterior y Jardín,ItemCargaDecoracion:Decoración,ItemCargaOtros:Otros,Escalera:Escalera,Ascensor:Ascensor,EscaAsce:Esca+Asce,PrecioEmbalaje:Precio Embalaje,PrecioElevacion:Precio Elevacion,PrecioBase:Precio Base,TiempoxKm:Tiempox Km,TiempoxM3:Tiempox M3|||||m3:m3,$:Pesos,u:Unidades,mi:Minutos,%:%,mm:Min/m3|||1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Allowmultipleselection = "|T|||||T|||";
         Ddo_grid_Datalisttype = "|FixedValues|Dynamic|Dynamic|Dynamic||FixedValues|||FixedValues";
         Ddo_grid_Includedatalist = "|T|T|T|T||T|||T";
         Ddo_grid_Filterisrange = "T|||||T||T||";
         Ddo_grid_Filtertype = "Numeric||Character|Character|Character|Numeric||Numeric||";
         Ddo_grid_Includefilter = "T||T|T|T|T||T||";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T|T|T||T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8||9";
         Ddo_grid_Columnids = "1:ParametroMudanzaId|2:ParametroMudanzaTipo|3:ParametroMudanzaTitulo|4:ParametroMudanzaNombre|5:ParametroMudanzaDescripcion|6:ParametroMudanzaValor|7:ParametroMudanzaUnidad|8:ParametroMudanzaPisoElev|9:ParametroMudanzaImagen|10:ParametroMudanzaActivo";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
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
         Form.Caption = context.GetMessage( " Parametro Mudanza", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroMudanzaId_Visible',ctrl:'PARAMETROMUDANZAID',prop:'Visible'},{av:'cmbParametroMudanzaTipo'},{av:'edtParametroMudanzaTitulo_Visible',ctrl:'PARAMETROMUDANZATITULO',prop:'Visible'},{av:'edtParametroMudanzaNombre_Visible',ctrl:'PARAMETROMUDANZANOMBRE',prop:'Visible'},{av:'edtParametroMudanzaDescripcion_Visible',ctrl:'PARAMETROMUDANZADESCRIPCION',prop:'Visible'},{av:'edtParametroMudanzaValor_Visible',ctrl:'PARAMETROMUDANZAVALOR',prop:'Visible'},{av:'cmbParametroMudanzaUnidad'},{av:'edtParametroMudanzaPisoElev_Visible',ctrl:'PARAMETROMUDANZAPISOELEV',prop:'Visible'},{av:'edtParametroMudanzaImagen_Visible',ctrl:'PARAMETROMUDANZAIMAGEN',prop:'Visible'},{av:'chkParametroMudanzaActivo.Visible',ctrl:'PARAMETROMUDANZAACTIVO',prop:'Visible'},{av:'AV50GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV52GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12FS2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroMudanzaId_Visible',ctrl:'PARAMETROMUDANZAID',prop:'Visible'},{av:'cmbParametroMudanzaTipo'},{av:'edtParametroMudanzaTitulo_Visible',ctrl:'PARAMETROMUDANZATITULO',prop:'Visible'},{av:'edtParametroMudanzaNombre_Visible',ctrl:'PARAMETROMUDANZANOMBRE',prop:'Visible'},{av:'edtParametroMudanzaDescripcion_Visible',ctrl:'PARAMETROMUDANZADESCRIPCION',prop:'Visible'},{av:'edtParametroMudanzaValor_Visible',ctrl:'PARAMETROMUDANZAVALOR',prop:'Visible'},{av:'cmbParametroMudanzaUnidad'},{av:'edtParametroMudanzaPisoElev_Visible',ctrl:'PARAMETROMUDANZAPISOELEV',prop:'Visible'},{av:'edtParametroMudanzaImagen_Visible',ctrl:'PARAMETROMUDANZAIMAGEN',prop:'Visible'},{av:'chkParametroMudanzaActivo.Visible',ctrl:'PARAMETROMUDANZAACTIVO',prop:'Visible'},{av:'AV50GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV52GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13FS2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E16FS2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV46TFParametroMudanzaUnidad_SelsJson',fld:'vTFPARAMETROMUDANZAUNIDAD_SELSJSON',pic:'',type:'vchar'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV40TFParametroMudanzaTipo_SelsJson',fld:'vTFPARAMETROMUDANZATIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E34FS2',iparms:[{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV53GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E17FS2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'edtParametroMudanzaId_Visible',ctrl:'PARAMETROMUDANZAID',prop:'Visible'},{av:'cmbParametroMudanzaTipo'},{av:'edtParametroMudanzaTitulo_Visible',ctrl:'PARAMETROMUDANZATITULO',prop:'Visible'},{av:'edtParametroMudanzaNombre_Visible',ctrl:'PARAMETROMUDANZANOMBRE',prop:'Visible'},{av:'edtParametroMudanzaDescripcion_Visible',ctrl:'PARAMETROMUDANZADESCRIPCION',prop:'Visible'},{av:'edtParametroMudanzaValor_Visible',ctrl:'PARAMETROMUDANZAVALOR',prop:'Visible'},{av:'cmbParametroMudanzaUnidad'},{av:'edtParametroMudanzaPisoElev_Visible',ctrl:'PARAMETROMUDANZAPISOELEV',prop:'Visible'},{av:'edtParametroMudanzaImagen_Visible',ctrl:'PARAMETROMUDANZAIMAGEN',prop:'Visible'},{av:'chkParametroMudanzaActivo.Visible',ctrl:'PARAMETROMUDANZAACTIVO',prop:'Visible'},{av:'AV50GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV52GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E27FS2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E18FS2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroMudanzaId_Visible',ctrl:'PARAMETROMUDANZAID',prop:'Visible'},{av:'cmbParametroMudanzaTipo'},{av:'edtParametroMudanzaTitulo_Visible',ctrl:'PARAMETROMUDANZATITULO',prop:'Visible'},{av:'edtParametroMudanzaNombre_Visible',ctrl:'PARAMETROMUDANZANOMBRE',prop:'Visible'},{av:'edtParametroMudanzaDescripcion_Visible',ctrl:'PARAMETROMUDANZADESCRIPCION',prop:'Visible'},{av:'edtParametroMudanzaValor_Visible',ctrl:'PARAMETROMUDANZAVALOR',prop:'Visible'},{av:'cmbParametroMudanzaUnidad'},{av:'edtParametroMudanzaPisoElev_Visible',ctrl:'PARAMETROMUDANZAPISOELEV',prop:'Visible'},{av:'edtParametroMudanzaImagen_Visible',ctrl:'PARAMETROMUDANZAIMAGEN',prop:'Visible'},{av:'chkParametroMudanzaActivo.Visible',ctrl:'PARAMETROMUDANZAACTIVO',prop:'Visible'},{av:'AV50GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV52GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E28FS2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavParametromudanzatipo1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E29FS2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E19FS2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroMudanzaId_Visible',ctrl:'PARAMETROMUDANZAID',prop:'Visible'},{av:'cmbParametroMudanzaTipo'},{av:'edtParametroMudanzaTitulo_Visible',ctrl:'PARAMETROMUDANZATITULO',prop:'Visible'},{av:'edtParametroMudanzaNombre_Visible',ctrl:'PARAMETROMUDANZANOMBRE',prop:'Visible'},{av:'edtParametroMudanzaDescripcion_Visible',ctrl:'PARAMETROMUDANZADESCRIPCION',prop:'Visible'},{av:'edtParametroMudanzaValor_Visible',ctrl:'PARAMETROMUDANZAVALOR',prop:'Visible'},{av:'cmbParametroMudanzaUnidad'},{av:'edtParametroMudanzaPisoElev_Visible',ctrl:'PARAMETROMUDANZAPISOELEV',prop:'Visible'},{av:'edtParametroMudanzaImagen_Visible',ctrl:'PARAMETROMUDANZAIMAGEN',prop:'Visible'},{av:'chkParametroMudanzaActivo.Visible',ctrl:'PARAMETROMUDANZAACTIVO',prop:'Visible'},{av:'AV50GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV52GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E30FS2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavParametromudanzatipo2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E20FS2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroMudanzaId_Visible',ctrl:'PARAMETROMUDANZAID',prop:'Visible'},{av:'cmbParametroMudanzaTipo'},{av:'edtParametroMudanzaTitulo_Visible',ctrl:'PARAMETROMUDANZATITULO',prop:'Visible'},{av:'edtParametroMudanzaNombre_Visible',ctrl:'PARAMETROMUDANZANOMBRE',prop:'Visible'},{av:'edtParametroMudanzaDescripcion_Visible',ctrl:'PARAMETROMUDANZADESCRIPCION',prop:'Visible'},{av:'edtParametroMudanzaValor_Visible',ctrl:'PARAMETROMUDANZAVALOR',prop:'Visible'},{av:'cmbParametroMudanzaUnidad'},{av:'edtParametroMudanzaPisoElev_Visible',ctrl:'PARAMETROMUDANZAPISOELEV',prop:'Visible'},{av:'edtParametroMudanzaImagen_Visible',ctrl:'PARAMETROMUDANZAIMAGEN',prop:'Visible'},{av:'chkParametroMudanzaActivo.Visible',ctrl:'PARAMETROMUDANZAACTIVO',prop:'Visible'},{av:'AV50GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV52GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E31FS2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavParametromudanzatipo3'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11FS2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV40TFParametroMudanzaTipo_SelsJson',fld:'vTFPARAMETROMUDANZATIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV46TFParametroMudanzaUnidad_SelsJson',fld:'vTFPARAMETROMUDANZAUNIDAD_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV46TFParametroMudanzaUnidad_SelsJson',fld:'vTFPARAMETROMUDANZAUNIDAD_SELSJSON',pic:'',type:'vchar'},{av:'AV40TFParametroMudanzaTipo_SelsJson',fld:'vTFPARAMETROMUDANZATIPO_SELSJSON',pic:'',type:'vchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroMudanzaId_Visible',ctrl:'PARAMETROMUDANZAID',prop:'Visible'},{av:'cmbParametroMudanzaTipo'},{av:'edtParametroMudanzaTitulo_Visible',ctrl:'PARAMETROMUDANZATITULO',prop:'Visible'},{av:'edtParametroMudanzaNombre_Visible',ctrl:'PARAMETROMUDANZANOMBRE',prop:'Visible'},{av:'edtParametroMudanzaDescripcion_Visible',ctrl:'PARAMETROMUDANZADESCRIPCION',prop:'Visible'},{av:'edtParametroMudanzaValor_Visible',ctrl:'PARAMETROMUDANZAVALOR',prop:'Visible'},{av:'cmbParametroMudanzaUnidad'},{av:'edtParametroMudanzaPisoElev_Visible',ctrl:'PARAMETROMUDANZAPISOELEV',prop:'Visible'},{av:'edtParametroMudanzaImagen_Visible',ctrl:'PARAMETROMUDANZAIMAGEN',prop:'Visible'},{av:'chkParametroMudanzaActivo.Visible',ctrl:'PARAMETROMUDANZAACTIVO',prop:'Visible'},{av:'AV50GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV52GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E35FS2',iparms:[{av:'cmbavGridactions'},{av:'AV53GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A730ParametroMudanzaId',fld:'PARAMETROMUDANZAID',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV53GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOUSERACTION5'","{handler:'E21FS2',iparms:[{av:'AV71TiempoxM3',fld:'vTIEMPOXM3',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("'DOUSERACTION5'",",oparms:[]}");
         setEventMetadata("'DOUSERACTION4'","{handler:'E22FS2',iparms:[{av:'AV70TiempoKm',fld:'vTIEMPOKM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("'DOUSERACTION4'",",oparms:[]}");
         setEventMetadata("'DOUSERACTION3'","{handler:'E23FS2',iparms:[{av:'AV69PrecioPeon',fld:'vPRECIOPEON',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("'DOUSERACTION3'",",oparms:[]}");
         setEventMetadata("'DOUSERACTION2'","{handler:'E24FS2',iparms:[{av:'AV66PrecioChico',fld:'vPRECIOCHICO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV67PrecioMediano',fld:'vPRECIOMEDIANO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV68PrecioGrande',fld:'vPRECIOGRANDE',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("'DOUSERACTION2'",",oparms:[]}");
         setEventMetadata("'DOUSERACTION1'","{handler:'E25FS2',iparms:[{av:'AV60PrecioEmbMetro3',fld:'vPRECIOEMBMETRO3',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV61PrecioElevPiso',fld:'vPRECIOELEVPISO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("'DOUSERACTION1'",",oparms:[]}");
         setEventMetadata("'DOINSERT'","{handler:'E26FS2',iparms:[{av:'A730ParametroMudanzaId',fld:'PARAMETROMUDANZAID',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14FS2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV40TFParametroMudanzaTipo_SelsJson',fld:'vTFPARAMETROMUDANZATIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV46TFParametroMudanzaUnidad_SelsJson',fld:'vTFPARAMETROMUDANZAUNIDAD_SELSJSON',pic:'',type:'vchar'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo1'},{av:'AV19ParametroMudanzaTipo1',fld:'vPARAMETROMUDANZATIPO1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo2'},{av:'AV22ParametroMudanzaTipo2',fld:'vPARAMETROMUDANZATIPO2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavParametromudanzatipo3'},{av:'AV25ParametroMudanzaTipo3',fld:'vPARAMETROMUDANZATIPO3',pic:'',type:'svchar'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV83Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFParametroMudanzaId',fld:'vTFPARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV39TFParametroMudanzaId_To',fld:'vTFPARAMETROMUDANZAID_TO',pic:'ZZZ9',type:'int'},{av:'AV41TFParametroMudanzaTipo_Sels',fld:'vTFPARAMETROMUDANZATIPO_SELS',pic:''},{av:'AV72TFParametroMudanzaTitulo',fld:'vTFPARAMETROMUDANZATITULO',pic:'',type:'svchar'},{av:'AV73TFParametroMudanzaTitulo_Sel',fld:'vTFPARAMETROMUDANZATITULO_SEL',pic:'',type:'svchar'},{av:'AV42TFParametroMudanzaNombre',fld:'vTFPARAMETROMUDANZANOMBRE',pic:'',type:'svchar'},{av:'AV43TFParametroMudanzaNombre_Sel',fld:'vTFPARAMETROMUDANZANOMBRE_SEL',pic:'',type:'svchar'},{av:'AV62TFParametroMudanzaDescripcion',fld:'vTFPARAMETROMUDANZADESCRIPCION',pic:'',type:'svchar'},{av:'AV63TFParametroMudanzaDescripcion_Sel',fld:'vTFPARAMETROMUDANZADESCRIPCION_SEL',pic:'',type:'svchar'},{av:'AV44TFParametroMudanzaValor',fld:'vTFPARAMETROMUDANZAVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV45TFParametroMudanzaValor_To',fld:'vTFPARAMETROMUDANZAVALOR_TO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV47TFParametroMudanzaUnidad_Sels',fld:'vTFPARAMETROMUDANZAUNIDAD_SELS',pic:''},{av:'AV64TFParametroMudanzaPisoElev',fld:'vTFPARAMETROMUDANZAPISOELEV',pic:'ZZZ9',type:'int'},{av:'AV65TFParametroMudanzaPisoElev_To',fld:'vTFPARAMETROMUDANZAPISOELEV_TO',pic:'ZZZ9',type:'int'},{av:'AV74TFParametroMudanzaActivo_Sel',fld:'vTFPARAMETROMUDANZAACTIVO_SEL',pic:'9',type:'int'},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV55IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV46TFParametroMudanzaUnidad_SelsJson',fld:'vTFPARAMETROMUDANZAUNIDAD_SELSJSON',pic:'',type:'vchar'},{av:'AV40TFParametroMudanzaTipo_SelsJson',fld:'vTFPARAMETROMUDANZATIPO_SELSJSON',pic:'',type:'vchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtParametroMudanzaId_Visible',ctrl:'PARAMETROMUDANZAID',prop:'Visible'},{av:'cmbParametroMudanzaTipo'},{av:'edtParametroMudanzaTitulo_Visible',ctrl:'PARAMETROMUDANZATITULO',prop:'Visible'},{av:'edtParametroMudanzaNombre_Visible',ctrl:'PARAMETROMUDANZANOMBRE',prop:'Visible'},{av:'edtParametroMudanzaDescripcion_Visible',ctrl:'PARAMETROMUDANZADESCRIPCION',prop:'Visible'},{av:'edtParametroMudanzaValor_Visible',ctrl:'PARAMETROMUDANZAVALOR',prop:'Visible'},{av:'cmbParametroMudanzaUnidad'},{av:'edtParametroMudanzaPisoElev_Visible',ctrl:'PARAMETROMUDANZAPISOELEV',prop:'Visible'},{av:'edtParametroMudanzaImagen_Visible',ctrl:'PARAMETROMUDANZAIMAGEN',prop:'Visible'},{av:'chkParametroMudanzaActivo.Visible',ctrl:'PARAMETROMUDANZAACTIVO',prop:'Visible'},{av:'AV50GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV52GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E15FS2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALIDV_PARAMETROMUDANZATIPO1","{handler:'Validv_Parametromudanzatipo1',iparms:[]");
         setEventMetadata("VALIDV_PARAMETROMUDANZATIPO1",",oparms:[]}");
         setEventMetadata("VALIDV_PARAMETROMUDANZATIPO2","{handler:'Validv_Parametromudanzatipo2',iparms:[]");
         setEventMetadata("VALIDV_PARAMETROMUDANZATIPO2",",oparms:[]}");
         setEventMetadata("VALIDV_PARAMETROMUDANZATIPO3","{handler:'Validv_Parametromudanzatipo3',iparms:[]");
         setEventMetadata("VALIDV_PARAMETROMUDANZATIPO3",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROMUDANZAID","{handler:'Valid_Parametromudanzaid',iparms:[]");
         setEventMetadata("VALID_PARAMETROMUDANZAID",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROMUDANZATIPO","{handler:'Valid_Parametromudanzatipo',iparms:[]");
         setEventMetadata("VALID_PARAMETROMUDANZATIPO",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROMUDANZATITULO","{handler:'Valid_Parametromudanzatitulo',iparms:[]");
         setEventMetadata("VALID_PARAMETROMUDANZATITULO",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROMUDANZANOMBRE","{handler:'Valid_Parametromudanzanombre',iparms:[]");
         setEventMetadata("VALID_PARAMETROMUDANZANOMBRE",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROMUDANZADESCRIPCION","{handler:'Valid_Parametromudanzadescripcion',iparms:[]");
         setEventMetadata("VALID_PARAMETROMUDANZADESCRIPCION",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROMUDANZAVALOR","{handler:'Valid_Parametromudanzavalor',iparms:[]");
         setEventMetadata("VALID_PARAMETROMUDANZAVALOR",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROMUDANZAUNIDAD","{handler:'Valid_Parametromudanzaunidad',iparms:[]");
         setEventMetadata("VALID_PARAMETROMUDANZAUNIDAD",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROMUDANZAPISOELEV","{handler:'Valid_Parametromudanzapisoelev',iparms:[]");
         setEventMetadata("VALID_PARAMETROMUDANZAPISOELEV",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Parametromudanzaactivo',iparms:[]");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV18DynamicFiltersSelector1 = "";
         AV19ParametroMudanzaTipo1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV22ParametroMudanzaTipo2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV25ParametroMudanzaTipo3 = "";
         AV32ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV83Pgmname = "";
         AV17FilterFullText = "";
         AV41TFParametroMudanzaTipo_Sels = new GxSimpleCollection<string>();
         AV72TFParametroMudanzaTitulo = "";
         AV73TFParametroMudanzaTitulo_Sel = "";
         AV42TFParametroMudanzaNombre = "";
         AV43TFParametroMudanzaNombre_Sel = "";
         AV62TFParametroMudanzaDescripcion = "";
         AV63TFParametroMudanzaDescripcion_Sel = "";
         AV47TFParametroMudanzaUnidad_Sels = new GxSimpleCollection<string>();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV35ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV52GridAppliedFilters = "";
         AV57AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV48DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV40TFParametroMudanzaTipo_SelsJson = "";
         AV46TFParametroMudanzaUnidad_SelsJson = "";
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
         bttBtnsubscriptions_Jsonclick = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         bttBtnuseraction1_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         bttBtnuseraction2_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         bttBtnuseraction3_Jsonclick = "";
         bttBtnuseraction4_Jsonclick = "";
         bttBtnuseraction5_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A731ParametroMudanzaTipo = "";
         A869ParametroMudanzaTitulo = "";
         A732ParametroMudanzaNombre = "";
         A812ParametroMudanzaDescripcion = "";
         A734ParametroMudanzaUnidad = "";
         A870ParametroMudanzaImagen = "";
         A40000ParametroMudanzaImagen_GXI = "";
         AV84Parametromudanzawwds_1_filterfulltext = "";
         AV85Parametromudanzawwds_2_dynamicfiltersselector1 = "";
         AV86Parametromudanzawwds_3_parametromudanzatipo1 = "";
         AV88Parametromudanzawwds_5_dynamicfiltersselector2 = "";
         AV89Parametromudanzawwds_6_parametromudanzatipo2 = "";
         AV91Parametromudanzawwds_8_dynamicfiltersselector3 = "";
         AV92Parametromudanzawwds_9_parametromudanzatipo3 = "";
         AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels = new GxSimpleCollection<string>();
         AV96Parametromudanzawwds_13_tfparametromudanzatitulo = "";
         AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel = "";
         AV98Parametromudanzawwds_15_tfparametromudanzanombre = "";
         AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel = "";
         AV100Parametromudanzawwds_17_tfparametromudanzadescripcion = "";
         AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = "";
         AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels = new GxSimpleCollection<string>();
         lV84Parametromudanzawwds_1_filterfulltext = "";
         lV96Parametromudanzawwds_13_tfparametromudanzatitulo = "";
         lV98Parametromudanzawwds_15_tfparametromudanzanombre = "";
         lV100Parametromudanzawwds_17_tfparametromudanzadescripcion = "";
         H00FS2_A877ParametroMudanzaActivo = new bool[] {false} ;
         H00FS2_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         H00FS2_A818ParametroMudanzaPisoElev = new short[1] ;
         H00FS2_A734ParametroMudanzaUnidad = new string[] {""} ;
         H00FS2_A733ParametroMudanzaValor = new decimal[1] ;
         H00FS2_A812ParametroMudanzaDescripcion = new string[] {""} ;
         H00FS2_A732ParametroMudanzaNombre = new string[] {""} ;
         H00FS2_A869ParametroMudanzaTitulo = new string[] {""} ;
         H00FS2_A731ParametroMudanzaTipo = new string[] {""} ;
         H00FS2_A730ParametroMudanzaId = new short[1] ;
         H00FS2_A870ParametroMudanzaImagen = new string[] {""} ;
         H00FS3_A877ParametroMudanzaActivo = new bool[] {false} ;
         H00FS3_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         H00FS3_A818ParametroMudanzaPisoElev = new short[1] ;
         H00FS3_A734ParametroMudanzaUnidad = new string[] {""} ;
         H00FS3_A733ParametroMudanzaValor = new decimal[1] ;
         H00FS3_A812ParametroMudanzaDescripcion = new string[] {""} ;
         H00FS3_A732ParametroMudanzaNombre = new string[] {""} ;
         H00FS3_A869ParametroMudanzaTitulo = new string[] {""} ;
         H00FS3_A731ParametroMudanzaTipo = new string[] {""} ;
         H00FS3_A730ParametroMudanzaId = new short[1] ;
         H00FS3_A870ParametroMudanzaImagen = new string[] {""} ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV58AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         H00FS4_A730ParametroMudanzaId = new short[1] ;
         H00FS4_A732ParametroMudanzaNombre = new string[] {""} ;
         H00FS4_A731ParametroMudanzaTipo = new string[] {""} ;
         H00FS4_A733ParametroMudanzaValor = new decimal[1] ;
         H00FS5_A730ParametroMudanzaId = new short[1] ;
         H00FS5_A732ParametroMudanzaNombre = new string[] {""} ;
         H00FS5_A731ParametroMudanzaTipo = new string[] {""} ;
         H00FS5_A733ParametroMudanzaValor = new decimal[1] ;
         H00FS6_A730ParametroMudanzaId = new short[1] ;
         H00FS6_A732ParametroMudanzaNombre = new string[] {""} ;
         H00FS6_A731ParametroMudanzaTipo = new string[] {""} ;
         H00FS6_A733ParametroMudanzaValor = new decimal[1] ;
         H00FS7_A730ParametroMudanzaId = new short[1] ;
         H00FS7_A732ParametroMudanzaNombre = new string[] {""} ;
         H00FS7_A731ParametroMudanzaTipo = new string[] {""} ;
         H00FS7_A733ParametroMudanzaValor = new decimal[1] ;
         H00FS8_A730ParametroMudanzaId = new short[1] ;
         H00FS8_A732ParametroMudanzaNombre = new string[] {""} ;
         H00FS8_A731ParametroMudanzaTipo = new string[] {""} ;
         H00FS8_A733ParametroMudanzaValor = new decimal[1] ;
         H00FS9_A730ParametroMudanzaId = new short[1] ;
         H00FS9_A732ParametroMudanzaNombre = new string[] {""} ;
         H00FS9_A731ParametroMudanzaTipo = new string[] {""} ;
         H00FS9_A733ParametroMudanzaValor = new decimal[1] ;
         H00FS10_A730ParametroMudanzaId = new short[1] ;
         H00FS10_A732ParametroMudanzaNombre = new string[] {""} ;
         H00FS10_A731ParametroMudanzaTipo = new string[] {""} ;
         H00FS10_A733ParametroMudanzaValor = new decimal[1] ;
         H00FS11_A730ParametroMudanzaId = new short[1] ;
         H00FS11_A732ParametroMudanzaNombre = new string[] {""} ;
         H00FS11_A731ParametroMudanzaTipo = new string[] {""} ;
         H00FS11_A733ParametroMudanzaValor = new decimal[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV30ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV36ManageFiltersXml = "";
         AV31UserCustomValue = "";
         AV33ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char5 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV28ExcelFilename = "";
         AV29ErrorMessage = "";
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametromudanzaww__default(),
            new Object[][] {
                new Object[] {
               H00FS2_A877ParametroMudanzaActivo, H00FS2_A40000ParametroMudanzaImagen_GXI, H00FS2_A818ParametroMudanzaPisoElev, H00FS2_A734ParametroMudanzaUnidad, H00FS2_A733ParametroMudanzaValor, H00FS2_A812ParametroMudanzaDescripcion, H00FS2_A732ParametroMudanzaNombre, H00FS2_A869ParametroMudanzaTitulo, H00FS2_A731ParametroMudanzaTipo, H00FS2_A730ParametroMudanzaId,
               H00FS2_A870ParametroMudanzaImagen
               }
               , new Object[] {
               H00FS3_A877ParametroMudanzaActivo, H00FS3_A40000ParametroMudanzaImagen_GXI, H00FS3_A818ParametroMudanzaPisoElev, H00FS3_A734ParametroMudanzaUnidad, H00FS3_A733ParametroMudanzaValor, H00FS3_A812ParametroMudanzaDescripcion, H00FS3_A732ParametroMudanzaNombre, H00FS3_A869ParametroMudanzaTitulo, H00FS3_A731ParametroMudanzaTipo, H00FS3_A730ParametroMudanzaId,
               H00FS3_A870ParametroMudanzaImagen
               }
               , new Object[] {
               H00FS4_A730ParametroMudanzaId, H00FS4_A732ParametroMudanzaNombre, H00FS4_A731ParametroMudanzaTipo, H00FS4_A733ParametroMudanzaValor
               }
               , new Object[] {
               H00FS5_A730ParametroMudanzaId, H00FS5_A732ParametroMudanzaNombre, H00FS5_A731ParametroMudanzaTipo, H00FS5_A733ParametroMudanzaValor
               }
               , new Object[] {
               H00FS6_A730ParametroMudanzaId, H00FS6_A732ParametroMudanzaNombre, H00FS6_A731ParametroMudanzaTipo, H00FS6_A733ParametroMudanzaValor
               }
               , new Object[] {
               H00FS7_A730ParametroMudanzaId, H00FS7_A732ParametroMudanzaNombre, H00FS7_A731ParametroMudanzaTipo, H00FS7_A733ParametroMudanzaValor
               }
               , new Object[] {
               H00FS8_A730ParametroMudanzaId, H00FS8_A732ParametroMudanzaNombre, H00FS8_A731ParametroMudanzaTipo, H00FS8_A733ParametroMudanzaValor
               }
               , new Object[] {
               H00FS9_A730ParametroMudanzaId, H00FS9_A732ParametroMudanzaNombre, H00FS9_A731ParametroMudanzaTipo, H00FS9_A733ParametroMudanzaValor
               }
               , new Object[] {
               H00FS10_A730ParametroMudanzaId, H00FS10_A732ParametroMudanzaNombre, H00FS10_A731ParametroMudanzaTipo, H00FS10_A733ParametroMudanzaValor
               }
               , new Object[] {
               H00FS11_A730ParametroMudanzaId, H00FS11_A732ParametroMudanzaNombre, H00FS11_A731ParametroMudanzaTipo, H00FS11_A733ParametroMudanzaValor
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV83Pgmname = "ParametroMudanzaWW";
         /* GeneXus formulas. */
         AV83Pgmname = "ParametroMudanzaWW";
      }

      private short GRID_nEOF ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
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
      private short AV14OrderedBy ;
      private short AV37ManageFiltersExecutionStep ;
      private short AV38TFParametroMudanzaId ;
      private short AV39TFParametroMudanzaId_To ;
      private short AV64TFParametroMudanzaPisoElev ;
      private short AV65TFParametroMudanzaPisoElev_To ;
      private short AV74TFParametroMudanzaActivo_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV53GridActions ;
      private short A730ParametroMudanzaId ;
      private short A818ParametroMudanzaPisoElev ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV93Parametromudanzawwds_10_tfparametromudanzaid ;
      private short AV94Parametromudanzawwds_11_tfparametromudanzaid_to ;
      private short AV105Parametromudanzawwds_22_tfparametromudanzapisoelev ;
      private short AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to ;
      private short AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel ;
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
      private int nRC_GXsfl_184 ;
      private int nGXsfl_184_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavPrecioembmetro3_Enabled ;
      private int edtavPrecioelevpiso_Enabled ;
      private int edtavPreciochico_Enabled ;
      private int edtavPreciomediano_Enabled ;
      private int edtavPreciogrande_Enabled ;
      private int edtavPreciopeon_Enabled ;
      private int edtavTiempokm_Enabled ;
      private int edtavTiempoxm3_Enabled ;
      private int subGrid_Islastpage ;
      private int AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count ;
      private int AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count ;
      private int edtParametroMudanzaId_Enabled ;
      private int edtParametroMudanzaTitulo_Enabled ;
      private int edtParametroMudanzaNombre_Enabled ;
      private int edtParametroMudanzaDescripcion_Enabled ;
      private int edtParametroMudanzaValor_Enabled ;
      private int edtParametroMudanzaPisoElev_Enabled ;
      private int edtParametroMudanzaImagen_Enabled ;
      private int edtParametroMudanzaId_Visible ;
      private int edtParametroMudanzaTitulo_Visible ;
      private int edtParametroMudanzaNombre_Visible ;
      private int edtParametroMudanzaDescripcion_Visible ;
      private int edtParametroMudanzaValor_Visible ;
      private int edtParametroMudanzaPisoElev_Visible ;
      private int edtParametroMudanzaImagen_Visible ;
      private int AV49PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int AV108GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV50GridCurrentPage ;
      private long AV51GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV44TFParametroMudanzaValor ;
      private decimal AV45TFParametroMudanzaValor_To ;
      private decimal AV60PrecioEmbMetro3 ;
      private decimal AV61PrecioElevPiso ;
      private decimal AV66PrecioChico ;
      private decimal AV67PrecioMediano ;
      private decimal AV68PrecioGrande ;
      private decimal AV69PrecioPeon ;
      private decimal AV70TiempoKm ;
      private decimal AV71TiempoxM3 ;
      private decimal A733ParametroMudanzaValor ;
      private decimal AV102Parametromudanzawwds_19_tfparametromudanzavalor ;
      private decimal AV103Parametromudanzawwds_20_tfparametromudanzavalor_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_184_idx="0001" ;
      private string AV83Pgmname ;
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
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_subscriptions_Titlecontrolidtoreplace ;
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
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
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
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divAdvancedfilterscontainer_Internalname ;
      private string divTabledynamicfilters_Internalname ;
      private string divTabledynamicfiltersrow1_Internalname ;
      private string lblDynamicfiltersprefix1_Internalname ;
      private string lblDynamicfiltersprefix1_Jsonclick ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersselector1_Jsonclick ;
      private string lblDynamicfiltersmiddle1_Internalname ;
      private string lblDynamicfiltersmiddle1_Jsonclick ;
      private string divTabledynamicfiltersrow2_Internalname ;
      private string lblDynamicfiltersprefix2_Internalname ;
      private string lblDynamicfiltersprefix2_Jsonclick ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersselector2_Jsonclick ;
      private string lblDynamicfiltersmiddle2_Internalname ;
      private string lblDynamicfiltersmiddle2_Jsonclick ;
      private string divTabledynamicfiltersrow3_Internalname ;
      private string lblDynamicfiltersprefix3_Internalname ;
      private string lblDynamicfiltersprefix3_Jsonclick ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersselector3_Jsonclick ;
      private string lblDynamicfiltersmiddle3_Internalname ;
      private string lblDynamicfiltersmiddle3_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string grpUnnamedgroup3_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string edtavPrecioembmetro3_Internalname ;
      private string edtavPrecioembmetro3_Jsonclick ;
      private string edtavPrecioelevpiso_Internalname ;
      private string edtavPrecioelevpiso_Jsonclick ;
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string grpUnnamedgroup5_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string edtavPreciochico_Internalname ;
      private string edtavPreciochico_Jsonclick ;
      private string edtavPreciomediano_Internalname ;
      private string edtavPreciomediano_Jsonclick ;
      private string edtavPreciogrande_Internalname ;
      private string edtavPreciogrande_Jsonclick ;
      private string bttBtnuseraction2_Internalname ;
      private string bttBtnuseraction2_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string grpUnnamedgroup7_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string edtavPreciopeon_Internalname ;
      private string edtavPreciopeon_Jsonclick ;
      private string bttBtnuseraction3_Internalname ;
      private string bttBtnuseraction3_Jsonclick ;
      private string grpUnnamedgroup9_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string edtavTiempokm_Internalname ;
      private string edtavTiempokm_Jsonclick ;
      private string bttBtnuseraction4_Internalname ;
      private string bttBtnuseraction4_Jsonclick ;
      private string grpUnnamedgroup11_Internalname ;
      private string divUnnamedtable10_Internalname ;
      private string edtavTiempoxm3_Internalname ;
      private string edtavTiempoxm3_Jsonclick ;
      private string bttBtnuseraction5_Internalname ;
      private string bttBtnuseraction5_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtParametroMudanzaId_Internalname ;
      private string cmbParametroMudanzaTipo_Internalname ;
      private string edtParametroMudanzaTitulo_Internalname ;
      private string edtParametroMudanzaNombre_Internalname ;
      private string edtParametroMudanzaDescripcion_Internalname ;
      private string edtParametroMudanzaValor_Internalname ;
      private string cmbParametroMudanzaUnidad_Internalname ;
      private string A734ParametroMudanzaUnidad ;
      private string edtParametroMudanzaPisoElev_Internalname ;
      private string edtParametroMudanzaImagen_Internalname ;
      private string chkParametroMudanzaActivo_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavParametromudanzatipo1_Internalname ;
      private string cmbavParametromudanzatipo2_Internalname ;
      private string cmbavParametromudanzatipo3_Internalname ;
      private string imgAdddynamicfilters1_Jsonclick ;
      private string imgAdddynamicfilters1_Internalname ;
      private string imgRemovedynamicfilters1_Jsonclick ;
      private string imgRemovedynamicfilters1_Internalname ;
      private string imgAdddynamicfilters2_Jsonclick ;
      private string imgAdddynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters2_Jsonclick ;
      private string imgRemovedynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters3_Jsonclick ;
      private string imgRemovedynamicfilters3_Internalname ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string GXt_char5 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string tblUnnamedtabledynamicfilters_3_Internalname ;
      private string cellFilter_parametromudanzatipo3_cell_Internalname ;
      private string cmbavParametromudanzatipo3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblUnnamedtabledynamicfilters_2_Internalname ;
      private string cellFilter_parametromudanzatipo2_cell_Internalname ;
      private string cmbavParametromudanzatipo2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblUnnamedtabledynamicfilters_1_Internalname ;
      private string cellFilter_parametromudanzatipo1_cell_Internalname ;
      private string cmbavParametromudanzatipo1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_184_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtParametroMudanzaId_Jsonclick ;
      private string cmbParametroMudanzaTipo_Jsonclick ;
      private string edtParametroMudanzaTitulo_Jsonclick ;
      private string edtParametroMudanzaNombre_Jsonclick ;
      private string edtParametroMudanzaDescripcion_Jsonclick ;
      private string edtParametroMudanzaValor_Jsonclick ;
      private string cmbParametroMudanzaUnidad_Jsonclick ;
      private string edtParametroMudanzaPisoElev_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV27DynamicFiltersIgnoreFirst ;
      private bool AV26DynamicFiltersRemoving ;
      private bool AV55IsAuthorized_Update ;
      private bool AV56IsAuthorized_Delete ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_184_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A877ParametroMudanzaActivo ;
      private bool AV87Parametromudanzawwds_4_dynamicfiltersenabled2 ;
      private bool AV90Parametromudanzawwds_7_dynamicfiltersenabled3 ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV59TempBoolean ;
      private bool GXt_boolean3 ;
      private bool A870ParametroMudanzaImagen_IsBlob ;
      private string AV40TFParametroMudanzaTipo_SelsJson ;
      private string AV46TFParametroMudanzaUnidad_SelsJson ;
      private string AV30ColumnsSelectorXML ;
      private string AV36ManageFiltersXml ;
      private string AV31UserCustomValue ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV19ParametroMudanzaTipo1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV22ParametroMudanzaTipo2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV25ParametroMudanzaTipo3 ;
      private string AV17FilterFullText ;
      private string AV72TFParametroMudanzaTitulo ;
      private string AV73TFParametroMudanzaTitulo_Sel ;
      private string AV42TFParametroMudanzaNombre ;
      private string AV43TFParametroMudanzaNombre_Sel ;
      private string AV62TFParametroMudanzaDescripcion ;
      private string AV63TFParametroMudanzaDescripcion_Sel ;
      private string AV52GridAppliedFilters ;
      private string A731ParametroMudanzaTipo ;
      private string A869ParametroMudanzaTitulo ;
      private string A732ParametroMudanzaNombre ;
      private string A812ParametroMudanzaDescripcion ;
      private string A40000ParametroMudanzaImagen_GXI ;
      private string AV84Parametromudanzawwds_1_filterfulltext ;
      private string AV85Parametromudanzawwds_2_dynamicfiltersselector1 ;
      private string AV86Parametromudanzawwds_3_parametromudanzatipo1 ;
      private string AV88Parametromudanzawwds_5_dynamicfiltersselector2 ;
      private string AV89Parametromudanzawwds_6_parametromudanzatipo2 ;
      private string AV91Parametromudanzawwds_8_dynamicfiltersselector3 ;
      private string AV92Parametromudanzawwds_9_parametromudanzatipo3 ;
      private string AV96Parametromudanzawwds_13_tfparametromudanzatitulo ;
      private string AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel ;
      private string AV98Parametromudanzawwds_15_tfparametromudanzanombre ;
      private string AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel ;
      private string AV100Parametromudanzawwds_17_tfparametromudanzadescripcion ;
      private string AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ;
      private string lV84Parametromudanzawwds_1_filterfulltext ;
      private string lV96Parametromudanzawwds_13_tfparametromudanzatitulo ;
      private string lV98Parametromudanzawwds_15_tfparametromudanzanombre ;
      private string lV100Parametromudanzawwds_17_tfparametromudanzadescripcion ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private string A870ParametroMudanzaImagen ;
      private IGxSession AV34Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavParametromudanzatipo1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavParametromudanzatipo2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavParametromudanzatipo3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbParametroMudanzaTipo ;
      private GXCombobox cmbParametroMudanzaUnidad ;
      private GXCheckbox chkParametroMudanzaActivo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV32ColumnsSelector ;
      private GxSimpleCollection<string> AV41TFParametroMudanzaTipo_Sels ;
      private GxSimpleCollection<string> AV47TFParametroMudanzaUnidad_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV35ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV57AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV48DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels ;
      private GxSimpleCollection<string> AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels ;
      private IDataStoreProvider pr_default ;
      private bool[] H00FS2_A877ParametroMudanzaActivo ;
      private string[] H00FS2_A40000ParametroMudanzaImagen_GXI ;
      private short[] H00FS2_A818ParametroMudanzaPisoElev ;
      private string[] H00FS2_A734ParametroMudanzaUnidad ;
      private decimal[] H00FS2_A733ParametroMudanzaValor ;
      private string[] H00FS2_A812ParametroMudanzaDescripcion ;
      private string[] H00FS2_A732ParametroMudanzaNombre ;
      private string[] H00FS2_A869ParametroMudanzaTitulo ;
      private string[] H00FS2_A731ParametroMudanzaTipo ;
      private short[] H00FS2_A730ParametroMudanzaId ;
      private string[] H00FS2_A870ParametroMudanzaImagen ;
      private bool[] H00FS3_A877ParametroMudanzaActivo ;
      private string[] H00FS3_A40000ParametroMudanzaImagen_GXI ;
      private short[] H00FS3_A818ParametroMudanzaPisoElev ;
      private string[] H00FS3_A734ParametroMudanzaUnidad ;
      private decimal[] H00FS3_A733ParametroMudanzaValor ;
      private string[] H00FS3_A812ParametroMudanzaDescripcion ;
      private string[] H00FS3_A732ParametroMudanzaNombre ;
      private string[] H00FS3_A869ParametroMudanzaTitulo ;
      private string[] H00FS3_A731ParametroMudanzaTipo ;
      private short[] H00FS3_A730ParametroMudanzaId ;
      private string[] H00FS3_A870ParametroMudanzaImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV58AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private short[] H00FS4_A730ParametroMudanzaId ;
      private string[] H00FS4_A732ParametroMudanzaNombre ;
      private string[] H00FS4_A731ParametroMudanzaTipo ;
      private decimal[] H00FS4_A733ParametroMudanzaValor ;
      private short[] H00FS5_A730ParametroMudanzaId ;
      private string[] H00FS5_A732ParametroMudanzaNombre ;
      private string[] H00FS5_A731ParametroMudanzaTipo ;
      private decimal[] H00FS5_A733ParametroMudanzaValor ;
      private short[] H00FS6_A730ParametroMudanzaId ;
      private string[] H00FS6_A732ParametroMudanzaNombre ;
      private string[] H00FS6_A731ParametroMudanzaTipo ;
      private decimal[] H00FS6_A733ParametroMudanzaValor ;
      private short[] H00FS7_A730ParametroMudanzaId ;
      private string[] H00FS7_A732ParametroMudanzaNombre ;
      private string[] H00FS7_A731ParametroMudanzaTipo ;
      private decimal[] H00FS7_A733ParametroMudanzaValor ;
      private short[] H00FS8_A730ParametroMudanzaId ;
      private string[] H00FS8_A732ParametroMudanzaNombre ;
      private string[] H00FS8_A731ParametroMudanzaTipo ;
      private decimal[] H00FS8_A733ParametroMudanzaValor ;
      private short[] H00FS9_A730ParametroMudanzaId ;
      private string[] H00FS9_A732ParametroMudanzaNombre ;
      private string[] H00FS9_A731ParametroMudanzaTipo ;
      private decimal[] H00FS9_A733ParametroMudanzaValor ;
      private short[] H00FS10_A730ParametroMudanzaId ;
      private string[] H00FS10_A732ParametroMudanzaNombre ;
      private string[] H00FS10_A731ParametroMudanzaTipo ;
      private decimal[] H00FS10_A733ParametroMudanzaValor ;
      private short[] H00FS11_A730ParametroMudanzaId ;
      private string[] H00FS11_A732ParametroMudanzaNombre ;
      private string[] H00FS11_A731ParametroMudanzaTipo ;
      private decimal[] H00FS11_A733ParametroMudanzaValor ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV33ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class parametromudanzaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00FS2( IGxContext context ,
                                             string A731ParametroMudanzaTipo ,
                                             GxSimpleCollection<string> AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                             string A734ParametroMudanzaUnidad ,
                                             GxSimpleCollection<string> AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                             string AV85Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                             string AV86Parametromudanzawwds_3_parametromudanzatipo1 ,
                                             bool AV87Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                             string AV88Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                             string AV89Parametromudanzawwds_6_parametromudanzatipo2 ,
                                             bool AV90Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                             string AV91Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                             string AV92Parametromudanzawwds_9_parametromudanzatipo3 ,
                                             short AV93Parametromudanzawwds_10_tfparametromudanzaid ,
                                             short AV94Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                             int AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count ,
                                             string AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                             string AV96Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                             string AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                             string AV98Parametromudanzawwds_15_tfparametromudanzanombre ,
                                             string AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                             string AV100Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                             decimal AV102Parametromudanzawwds_19_tfparametromudanzavalor ,
                                             decimal AV103Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                             int AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count ,
                                             short AV105Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                             short AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                             short AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                             short A730ParametroMudanzaId ,
                                             string A869ParametroMudanzaTitulo ,
                                             string A732ParametroMudanzaNombre ,
                                             string A812ParametroMudanzaDescripcion ,
                                             decimal A733ParametroMudanzaValor ,
                                             short A818ParametroMudanzaPisoElev ,
                                             bool A877ParametroMudanzaActivo ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV84Parametromudanzawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[15];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT [ParametroMudanzaActivo], [ParametroMudanzaImagen_GXI], [ParametroMudanzaPisoElev], [ParametroMudanzaUnidad], [ParametroMudanzaValor], [ParametroMudanzaDescripcion], [ParametroMudanzaNombre], [ParametroMudanzaTitulo], [ParametroMudanzaTipo], [ParametroMudanzaId], [ParametroMudanzaImagen] FROM [ParametroMudanza]";
         if ( ( StringUtil.StrCmp(AV85Parametromudanzawwds_2_dynamicfiltersselector1, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Parametromudanzawwds_3_parametromudanzatipo1)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV86Parametromudanzawwds_3_parametromudanzatipo1)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( AV87Parametromudanzawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Parametromudanzawwds_5_dynamicfiltersselector2, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Parametromudanzawwds_6_parametromudanzatipo2)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV89Parametromudanzawwds_6_parametromudanzatipo2)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( AV90Parametromudanzawwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Parametromudanzawwds_8_dynamicfiltersselector3, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Parametromudanzawwds_9_parametromudanzatipo3)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV92Parametromudanzawwds_9_parametromudanzatipo3)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! (0==AV93Parametromudanzawwds_10_tfparametromudanzaid) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] >= @AV93Parametromudanzawwds_10_tfparametromudanzaid)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! (0==AV94Parametromudanzawwds_11_tfparametromudanzaid_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] <= @AV94Parametromudanzawwds_11_tfparametromudanzaid_to)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels, "[ParametroMudanzaTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Parametromudanzawwds_13_tfparametromudanzatitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaTitulo]) like UPPER(@lV96Parametromudanzawwds_13_tfparametromudanzatitulo))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ! ( StringUtil.StrCmp(AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTitulo] = @AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaTitulo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Parametromudanzawwds_15_tfparametromudanzanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaNombre]) like UPPER(@lV98Parametromudanzawwds_15_tfparametromudanzanombre))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ! ( StringUtil.StrCmp(AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaNombre] = @AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Parametromudanzawwds_17_tfparametromudanzadescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaDescripcion]) like UPPER(@lV100Parametromudanzawwds_17_tfparametromudanzadescripcion))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ! ( StringUtil.StrCmp(AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaDescripcion] = @AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaDescripcion] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV102Parametromudanzawwds_19_tfparametromudanzavalor) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] >= @AV102Parametromudanzawwds_19_tfparametromudanzavalor)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV103Parametromudanzawwds_20_tfparametromudanzavalor_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] <= @AV103Parametromudanzawwds_20_tfparametromudanzavalor_to)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels, "[ParametroMudanzaUnidad] IN (", ")")+")");
         }
         if ( ! (0==AV105Parametromudanzawwds_22_tfparametromudanzapisoelev) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] >= @AV105Parametromudanzawwds_22_tfparametromudanzapisoelev)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! (0==AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] <= @AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 1 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 1)");
         }
         if ( AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 2 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTipo]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTitulo]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTitulo] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaDescripcion]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaDescripcion] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaValor]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaValor] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaUnidad]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaUnidad] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaPisoElev]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaPisoElev] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaActivo]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaActivo] DESC";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H00FS3( IGxContext context ,
                                             string A731ParametroMudanzaTipo ,
                                             GxSimpleCollection<string> AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                             string A734ParametroMudanzaUnidad ,
                                             GxSimpleCollection<string> AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                             string AV85Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                             string AV86Parametromudanzawwds_3_parametromudanzatipo1 ,
                                             bool AV87Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                             string AV88Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                             string AV89Parametromudanzawwds_6_parametromudanzatipo2 ,
                                             bool AV90Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                             string AV91Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                             string AV92Parametromudanzawwds_9_parametromudanzatipo3 ,
                                             short AV93Parametromudanzawwds_10_tfparametromudanzaid ,
                                             short AV94Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                             int AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count ,
                                             string AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                             string AV96Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                             string AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                             string AV98Parametromudanzawwds_15_tfparametromudanzanombre ,
                                             string AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                             string AV100Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                             decimal AV102Parametromudanzawwds_19_tfparametromudanzavalor ,
                                             decimal AV103Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                             int AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count ,
                                             short AV105Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                             short AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                             short AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                             short A730ParametroMudanzaId ,
                                             string A869ParametroMudanzaTitulo ,
                                             string A732ParametroMudanzaNombre ,
                                             string A812ParametroMudanzaDescripcion ,
                                             decimal A733ParametroMudanzaValor ,
                                             short A818ParametroMudanzaPisoElev ,
                                             bool A877ParametroMudanzaActivo ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV84Parametromudanzawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[15];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT [ParametroMudanzaActivo], [ParametroMudanzaImagen_GXI], [ParametroMudanzaPisoElev], [ParametroMudanzaUnidad], [ParametroMudanzaValor], [ParametroMudanzaDescripcion], [ParametroMudanzaNombre], [ParametroMudanzaTitulo], [ParametroMudanzaTipo], [ParametroMudanzaId], [ParametroMudanzaImagen] FROM [ParametroMudanza]";
         if ( ( StringUtil.StrCmp(AV85Parametromudanzawwds_2_dynamicfiltersselector1, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Parametromudanzawwds_3_parametromudanzatipo1)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV86Parametromudanzawwds_3_parametromudanzatipo1)");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         if ( AV87Parametromudanzawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Parametromudanzawwds_5_dynamicfiltersselector2, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Parametromudanzawwds_6_parametromudanzatipo2)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV89Parametromudanzawwds_6_parametromudanzatipo2)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( AV90Parametromudanzawwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Parametromudanzawwds_8_dynamicfiltersselector3, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Parametromudanzawwds_9_parametromudanzatipo3)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV92Parametromudanzawwds_9_parametromudanzatipo3)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! (0==AV93Parametromudanzawwds_10_tfparametromudanzaid) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] >= @AV93Parametromudanzawwds_10_tfparametromudanzaid)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! (0==AV94Parametromudanzawwds_11_tfparametromudanzaid_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] <= @AV94Parametromudanzawwds_11_tfparametromudanzaid_to)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95Parametromudanzawwds_12_tfparametromudanzatipo_sels, "[ParametroMudanzaTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Parametromudanzawwds_13_tfparametromudanzatitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaTitulo]) like UPPER(@lV96Parametromudanzawwds_13_tfparametromudanzatitulo))");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ! ( StringUtil.StrCmp(AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTitulo] = @AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( StringUtil.StrCmp(AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaTitulo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Parametromudanzawwds_15_tfparametromudanzanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaNombre]) like UPPER(@lV98Parametromudanzawwds_15_tfparametromudanzanombre))");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ! ( StringUtil.StrCmp(AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaNombre] = @AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( StringUtil.StrCmp(AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Parametromudanzawwds_17_tfparametromudanzadescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaDescripcion]) like UPPER(@lV100Parametromudanzawwds_17_tfparametromudanzadescripcion))");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ! ( StringUtil.StrCmp(AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaDescripcion] = @AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( StringUtil.StrCmp(AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaDescripcion] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV102Parametromudanzawwds_19_tfparametromudanzavalor) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] >= @AV102Parametromudanzawwds_19_tfparametromudanzavalor)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV103Parametromudanzawwds_20_tfparametromudanzavalor_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] <= @AV103Parametromudanzawwds_20_tfparametromudanzavalor_to)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV104Parametromudanzawwds_21_tfparametromudanzaunidad_sels, "[ParametroMudanzaUnidad] IN (", ")")+")");
         }
         if ( ! (0==AV105Parametromudanzawwds_22_tfparametromudanzapisoelev) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] >= @AV105Parametromudanzawwds_22_tfparametromudanzapisoelev)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! (0==AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] <= @AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 1 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 1)");
         }
         if ( AV107Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 2 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTipo]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTitulo]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTitulo] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaDescripcion]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaDescripcion] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaValor]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaValor] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaUnidad]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaUnidad] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaPisoElev]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaPisoElev] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaActivo]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaActivo] DESC";
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
                     return conditional_H00FS2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (string)dynConstraints[36] );
               case 1 :
                     return conditional_H00FS3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (string)dynConstraints[36] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00FS4;
          prmH00FS4 = new Object[] {
          };
          Object[] prmH00FS5;
          prmH00FS5 = new Object[] {
          };
          Object[] prmH00FS6;
          prmH00FS6 = new Object[] {
          };
          Object[] prmH00FS7;
          prmH00FS7 = new Object[] {
          };
          Object[] prmH00FS8;
          prmH00FS8 = new Object[] {
          };
          Object[] prmH00FS9;
          prmH00FS9 = new Object[] {
          };
          Object[] prmH00FS10;
          prmH00FS10 = new Object[] {
          };
          Object[] prmH00FS11;
          prmH00FS11 = new Object[] {
          };
          Object[] prmH00FS2;
          prmH00FS2 = new Object[] {
          new ParDef("@AV86Parametromudanzawwds_3_parametromudanzatipo1",GXType.NVarChar,20,0) ,
          new ParDef("@AV89Parametromudanzawwds_6_parametromudanzatipo2",GXType.NVarChar,20,0) ,
          new ParDef("@AV92Parametromudanzawwds_9_parametromudanzatipo3",GXType.NVarChar,20,0) ,
          new ParDef("@AV93Parametromudanzawwds_10_tfparametromudanzaid",GXType.Int16,4,0) ,
          new ParDef("@AV94Parametromudanzawwds_11_tfparametromudanzaid_to",GXType.Int16,4,0) ,
          new ParDef("@lV96Parametromudanzawwds_13_tfparametromudanzatitulo",GXType.VarChar,80,0) ,
          new ParDef("@AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel",GXType.NVarChar,80,0) ,
          new ParDef("@lV98Parametromudanzawwds_15_tfparametromudanzanombre",GXType.VarChar,100,0) ,
          new ParDef("@AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV100Parametromudanzawwds_17_tfparametromudanzadescripcion",GXType.VarChar,100,0) ,
          new ParDef("@AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV102Parametromudanzawwds_19_tfparametromudanzavalor",GXType.Decimal,18,2) ,
          new ParDef("@AV103Parametromudanzawwds_20_tfparametromudanzavalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV105Parametromudanzawwds_22_tfparametromudanzapisoelev",GXType.Int16,4,0) ,
          new ParDef("@AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to",GXType.Int16,4,0)
          };
          Object[] prmH00FS3;
          prmH00FS3 = new Object[] {
          new ParDef("@AV86Parametromudanzawwds_3_parametromudanzatipo1",GXType.NVarChar,20,0) ,
          new ParDef("@AV89Parametromudanzawwds_6_parametromudanzatipo2",GXType.NVarChar,20,0) ,
          new ParDef("@AV92Parametromudanzawwds_9_parametromudanzatipo3",GXType.NVarChar,20,0) ,
          new ParDef("@AV93Parametromudanzawwds_10_tfparametromudanzaid",GXType.Int16,4,0) ,
          new ParDef("@AV94Parametromudanzawwds_11_tfparametromudanzaid_to",GXType.Int16,4,0) ,
          new ParDef("@lV96Parametromudanzawwds_13_tfparametromudanzatitulo",GXType.VarChar,80,0) ,
          new ParDef("@AV97Parametromudanzawwds_14_tfparametromudanzatitulo_sel",GXType.NVarChar,80,0) ,
          new ParDef("@lV98Parametromudanzawwds_15_tfparametromudanzanombre",GXType.VarChar,100,0) ,
          new ParDef("@AV99Parametromudanzawwds_16_tfparametromudanzanombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV100Parametromudanzawwds_17_tfparametromudanzadescripcion",GXType.VarChar,100,0) ,
          new ParDef("@AV101Parametromudanzawwds_18_tfparametromudanzadescripcion_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV102Parametromudanzawwds_19_tfparametromudanzavalor",GXType.Decimal,18,2) ,
          new ParDef("@AV103Parametromudanzawwds_20_tfparametromudanzavalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV105Parametromudanzawwds_22_tfparametromudanzapisoelev",GXType.Int16,4,0) ,
          new ParDef("@AV106Parametromudanzawwds_23_tfparametromudanzapisoelev_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00FS2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FS2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00FS3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FS3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00FS4", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'PrecioElevacion' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FS4,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00FS5", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'PrecioEmbalaje' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FS5,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00FS6", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'PrecioBase' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FS6,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00FS7", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'PrecioBase' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FS7,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00FS8", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'PrecioBase' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FS8,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00FS9", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'ItemAdicional' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FS9,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00FS10", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'TiempoxKm' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FS10,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00FS11", "SELECT [ParametroMudanzaId], [ParametroMudanzaNombre], [ParametroMudanzaTipo], [ParametroMudanzaValor] FROM [ParametroMudanza] WHERE [ParametroMudanzaTipo] = 'TiempoxM3' ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FS11,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(2));
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(2));
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
       }
    }

 }

}
