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
   public class inventarioww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public inventarioww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public inventarioww( IGxContext context )
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
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbMedidasEstado = new GXCombobox();
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
         nRC_GXsfl_129 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_129"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_129_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_129_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_129_idx = GetPar( "sGXsfl_129_idx");
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
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV20RubrosCosto1 = NumberUtil.Val( GetPar( "RubrosCosto1"), ".");
         AV21RubrosNombre1 = GetPar( "RubrosNombre1");
         AV82TextosTipo1 = GetPar( "TextosTipo1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV25RubrosCosto2 = NumberUtil.Val( GetPar( "RubrosCosto2"), ".");
         AV26RubrosNombre2 = GetPar( "RubrosNombre2");
         AV83TextosTipo2 = GetPar( "TextosTipo2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV30RubrosCosto3 = NumberUtil.Val( GetPar( "RubrosCosto3"), ".");
         AV31RubrosNombre3 = GetPar( "RubrosNombre3");
         AV84TextosTipo3 = GetPar( "TextosTipo3");
         AV44ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV27DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV39ColumnsSelector);
         AV95Pgmname = GetPar( "Pgmname");
         AV17FilterFullText = GetPar( "FilterFullText");
         AV45TFRubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "TFRubrosId"), "."), 18, MidpointRounding.ToEven));
         AV46TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFRubrosId_To"), "."), 18, MidpointRounding.ToEven));
         AV47TFRubrosNombre = GetPar( "TFRubrosNombre");
         AV48TFRubrosNombre_Sel = GetPar( "TFRubrosNombre_Sel");
         AV51TFMedidasNombre = GetPar( "TFMedidasNombre");
         AV52TFMedidasNombre_Sel = GetPar( "TFMedidasNombre_Sel");
         AV53TFTextosId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFTextosId"), "."), 18, MidpointRounding.ToEven));
         AV54TFTextosId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFTextosId_To"), "."), 18, MidpointRounding.ToEven));
         AV55TFTextosTitulo = GetPar( "TFTextosTitulo");
         AV56TFTextosTitulo_Sel = GetPar( "TFTextosTitulo_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV58TFMedidasEstado_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV67GridCollapsedRecords);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV33DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV32DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV74IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV75IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV79IsAuthorized_RubrosNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_RubrosNombre"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV66GridCollapsedRecordsChildren);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20RubrosCosto1, AV21RubrosNombre1, AV82TextosTipo1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25RubrosCosto2, AV26RubrosNombre2, AV83TextosTipo2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30RubrosCosto3, AV31RubrosNombre3, AV84TextosTipo3, AV44ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV39ColumnsSelector, AV95Pgmname, AV17FilterFullText, AV45TFRubrosId, AV46TFRubrosId_To, AV47TFRubrosNombre, AV48TFRubrosNombre_Sel, AV51TFMedidasNombre, AV52TFMedidasNombre_Sel, AV53TFTextosId, AV54TFTextosId_To, AV55TFTextosTitulo, AV56TFTextosTitulo_Sel, AV58TFMedidasEstado_Sels, AV67GridCollapsedRecords, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV74IsAuthorized_Update, AV75IsAuthorized_Delete, AV79IsAuthorized_RubrosNombre, AV66GridCollapsedRecordsChildren) ;
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
         PA1U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1U2( ) ;
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
         context.AddJavascriptSource("DVelop/DVGroupBy/DVGroupByRender.js", "", false, true, false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("inventarioww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV95Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV95Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV74IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV74IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV75IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV75IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RUBROSNOMBRE", AV79IsAuthorized_RubrosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RUBROSNOMBRE", GetSecureSignedToken( "", AV79IsAuthorized_RubrosNombre, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRUBROSCOSTO1", StringUtil.LTrim( StringUtil.NToC( AV20RubrosCosto1, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRUBROSNOMBRE1", StringUtil.RTrim( AV21RubrosNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vTEXTOSTIPO1", StringUtil.RTrim( AV82TextosTipo1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRUBROSCOSTO2", StringUtil.LTrim( StringUtil.NToC( AV25RubrosCosto2, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRUBROSNOMBRE2", StringUtil.RTrim( AV26RubrosNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vTEXTOSTIPO2", StringUtil.RTrim( AV83TextosTipo2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV28DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRUBROSCOSTO3", StringUtil.LTrim( StringUtil.NToC( AV30RubrosCosto3, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRUBROSNOMBRE3", StringUtil.RTrim( AV31RubrosNombre3));
         GxWebStd.gx_hidden_field( context, "GXH_vTEXTOSTIPO3", StringUtil.RTrim( AV84TextosTipo3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_129", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_129), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV42ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV42ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV63GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV76AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV76AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV59DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV59DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV39ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV39ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV27DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV95Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV95Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TFRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFRUBROSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46TFRubrosId_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFRUBROSNOMBRE", StringUtil.RTrim( AV47TFRubrosNombre));
         GxWebStd.gx_hidden_field( context, "vTFRUBROSNOMBRE_SEL", StringUtil.RTrim( AV48TFRubrosNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFMEDIDASNOMBRE", StringUtil.RTrim( AV51TFMedidasNombre));
         GxWebStd.gx_hidden_field( context, "vTFMEDIDASNOMBRE_SEL", StringUtil.RTrim( AV52TFMedidasNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTEXTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53TFTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFTEXTOSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54TFTextosId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFTEXTOSTITULO", StringUtil.RTrim( AV55TFTextosTitulo));
         GxWebStd.gx_hidden_field( context, "vTFTEXTOSTITULO_SEL", StringUtil.RTrim( AV56TFTextosTitulo_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMEDIDASESTADO_SELS", AV58TFMedidasEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMEDIDASESTADO_SELS", AV58TFMedidasEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCOLLAPSEDRECORDS", AV67GridCollapsedRecords);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCOLLAPSEDRECORDS", AV67GridCollapsedRecords);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV33DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV32DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV74IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV74IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV75IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV75IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RUBROSNOMBRE", AV79IsAuthorized_RubrosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RUBROSNOMBRE", GetSecureSignedToken( "", AV79IsAuthorized_RubrosNombre, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCOLLAPSEDRECORDSCHILDREN", AV66GridCollapsedRecordsChildren);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCOLLAPSEDRECORDSCHILDREN", AV66GridCollapsedRecordsChildren);
         }
         GxWebStd.gx_hidden_field( context, "vTFMEDIDASESTADO_SELSJSON", AV57TFMedidasEstado_SelsJson);
         GxWebStd.gx_hidden_field( context, "vGROUPRUBROSNOMBRE", StringUtil.RTrim( AV65GroupRubrosNombre));
         GxWebStd.gx_boolean_hidden_field( context, "vADDCHILDREN", AV71AddChildren);
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
         GxWebStd.gx_hidden_field( context, "GRID_GROUP_Gridinternalname", StringUtil.RTrim( Grid_group_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_GROUP_Columnindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid_group_Columnindex), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hasrowgroups", StringUtil.BoolToStr( Grid_empowerer_Hasrowgroups));
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
            WE1U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1U2( ) ;
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
         return formatLink("inventarioww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "InventarioWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Inventario", "") ;
      }

      protected void WB1U0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_1U2( true) ;
         }
         else
         {
            wb_table1_25_1U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_1U2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_InventarioWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_1U2( true) ;
         }
         else
         {
            wb_table2_49_1U2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_1U2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_InventarioWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_77_1U2( true) ;
         }
         else
         {
            wb_table3_77_1U2( false) ;
         }
         return  ;
      }

      protected void wb_table3_77_1U2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 0, "HLP_InventarioWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_105_1U2( true) ;
         }
         else
         {
            wb_table4_105_1U2( false) ;
         }
         return  ;
      }

      protected void wb_table4_105_1U2e( bool wbgen )
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
            StartGridControl129( ) ;
         }
         if ( wbEnd == 129 )
         {
            wbEnd = 0;
            nRC_GXsfl_129 = (int)(nGXsfl_129_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV61GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV62GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV63GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV76AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_InventarioWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV59DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV59DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV39ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_group.SetProperty("ColumnIndex", Grid_group_Columnindex);
            ucGrid_group.Render(context, "dvelop.dvgroupby", Grid_group_Internalname, "GRID_GROUPContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("HasRowGroups", Grid_empowerer_Hasrowgroups);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0156"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0156"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_129_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0156"+"");
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
         if ( wbEnd == 129 )
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

      protected void START1U2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Inventario", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1U0( ) ;
      }

      protected void WS1U2( )
      {
         START1U2( ) ;
         EVT1U2( ) ;
      }

      protected void EVT1U2( )
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
                              E111U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E121U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E131U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E141U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E151U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E161U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E171U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E181U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E191U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E201U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E211U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E221U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E231U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E241U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E251U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E261U2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VEXPAND.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VEXPAND.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_129_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
                              SubsflControlProps_1292( ) ;
                              AV72Expand = cgiGet( edtavExpand_Internalname);
                              AssignAttri("", false, edtavExpand_Internalname, AV72Expand);
                              AV34Grid_GroupCaption = cgiGet( edtavGrid_groupcaption_Internalname);
                              AssignAttri("", false, edtavGrid_groupcaption_Internalname, AV34Grid_GroupCaption);
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV73GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV73GridActions), 4, 0));
                              A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A168RubrosImagen = cgiGet( edtRubrosImagen_Internalname);
                              AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_129_Refreshing);
                              AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
                              A122RubrosNombre = cgiGet( edtRubrosNombre_Internalname);
                              A137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMedidasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A138MedidasNombre = cgiGet( edtMedidasNombre_Internalname);
                              A150TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTextosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n150TextosId = false;
                              A259TextosTitulo = cgiGet( edtTextosTitulo_Internalname);
                              cmbMedidasEstado.Name = cmbMedidasEstado_Internalname;
                              cmbMedidasEstado.CurrentValue = cgiGet( cmbMedidasEstado_Internalname);
                              A139MedidasEstado = cgiGet( cmbMedidasEstado_Internalname);
                              n139MedidasEstado = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E271U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E281U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E291U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E301U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VEXPAND.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E311U2 ();
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
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Rubroscosto1 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vRUBROSCOSTO1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV20RubrosCosto1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Rubrosnombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRUBROSNOMBRE1"), AV21RubrosNombre1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Textostipo1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTEXTOSTIPO1"), AV82TextosTipo1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Rubroscosto2 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vRUBROSCOSTO2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV25RubrosCosto2 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Rubrosnombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRUBROSNOMBRE2"), AV26RubrosNombre2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Textostipo2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTEXTOSTIPO2"), AV83TextosTipo2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV28DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV29DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Rubroscosto3 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vRUBROSCOSTO3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV30RubrosCosto3 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Rubrosnombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vRUBROSNOMBRE3"), AV31RubrosNombre3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Textostipo3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTEXTOSTIPO3"), AV84TextosTipo3) != 0 )
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
                        if ( nCmpId == 156 )
                        {
                           OldWwpaux_wc = cgiGet( "W0156");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0156", "", sEvt);
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

      protected void WE1U2( )
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

      protected void PA1U2( )
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
         SubsflControlProps_1292( ) ;
         while ( nGXsfl_129_idx <= nRC_GXsfl_129 )
         {
            sendrow_1292( ) ;
            nGXsfl_129_idx = ((subGrid_Islastpage==1)&&(nGXsfl_129_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_129_idx+1);
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
            SubsflControlProps_1292( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       decimal AV20RubrosCosto1 ,
                                       string AV21RubrosNombre1 ,
                                       string AV82TextosTipo1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       decimal AV25RubrosCosto2 ,
                                       string AV26RubrosNombre2 ,
                                       string AV83TextosTipo2 ,
                                       string AV28DynamicFiltersSelector3 ,
                                       short AV29DynamicFiltersOperator3 ,
                                       decimal AV30RubrosCosto3 ,
                                       string AV31RubrosNombre3 ,
                                       string AV84TextosTipo3 ,
                                       short AV44ManageFiltersExecutionStep ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       bool AV27DynamicFiltersEnabled3 ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ,
                                       string AV95Pgmname ,
                                       string AV17FilterFullText ,
                                       short AV45TFRubrosId ,
                                       short AV46TFRubrosId_To ,
                                       string AV47TFRubrosNombre ,
                                       string AV48TFRubrosNombre_Sel ,
                                       string AV51TFMedidasNombre ,
                                       string AV52TFMedidasNombre_Sel ,
                                       long AV53TFTextosId ,
                                       long AV54TFTextosId_To ,
                                       string AV55TFTextosTitulo ,
                                       string AV56TFTextosTitulo_Sel ,
                                       GxSimpleCollection<string> AV58TFMedidasEstado_Sels ,
                                       GxSimpleCollection<string> AV67GridCollapsedRecords ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV33DynamicFiltersIgnoreFirst ,
                                       bool AV32DynamicFiltersRemoving ,
                                       bool AV74IsAuthorized_Update ,
                                       bool AV75IsAuthorized_Delete ,
                                       bool AV79IsAuthorized_RubrosNombre ,
                                       GxSimpleCollection<string> AV66GridCollapsedRecordsChildren )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1U2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RUBROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_MEDIDASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", "")));
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
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV95Pgmname = "InventarioWW";
         edtavExpand_Enabled = 0;
         edtavGrid_groupcaption_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV96Inventariowwds_1_filterfulltext = AV17FilterFullText;
         AV97Inventariowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV98Inventariowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV99Inventariowwds_4_rubroscosto1 = AV20RubrosCosto1;
         AV100Inventariowwds_5_rubrosnombre1 = AV21RubrosNombre1;
         AV101Inventariowwds_6_textostipo1 = AV82TextosTipo1;
         AV102Inventariowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV103Inventariowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV104Inventariowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV105Inventariowwds_10_rubroscosto2 = AV25RubrosCosto2;
         AV106Inventariowwds_11_rubrosnombre2 = AV26RubrosNombre2;
         AV107Inventariowwds_12_textostipo2 = AV83TextosTipo2;
         AV108Inventariowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV109Inventariowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV110Inventariowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV111Inventariowwds_16_rubroscosto3 = AV30RubrosCosto3;
         AV112Inventariowwds_17_rubrosnombre3 = AV31RubrosNombre3;
         AV113Inventariowwds_18_textostipo3 = AV84TextosTipo3;
         AV114Inventariowwds_19_tfrubrosid = AV45TFRubrosId;
         AV115Inventariowwds_20_tfrubrosid_to = AV46TFRubrosId_To;
         AV116Inventariowwds_21_tfrubrosnombre = AV47TFRubrosNombre;
         AV117Inventariowwds_22_tfrubrosnombre_sel = AV48TFRubrosNombre_Sel;
         AV118Inventariowwds_23_tfmedidasnombre = AV51TFMedidasNombre;
         AV119Inventariowwds_24_tfmedidasnombre_sel = AV52TFMedidasNombre_Sel;
         AV120Inventariowwds_25_tftextosid = AV53TFTextosId;
         AV121Inventariowwds_26_tftextosid_to = AV54TFTextosId_To;
         AV122Inventariowwds_27_tftextostitulo = AV55TFTextosTitulo;
         AV123Inventariowwds_28_tftextostitulo_sel = AV56TFTextosTitulo_Sel;
         AV124Inventariowwds_29_tfmedidasestado_sels = AV58TFMedidasEstado_Sels;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV124Inventariowwds_29_tfmedidasestado_sels ,
                                              AV97Inventariowwds_2_dynamicfiltersselector1 ,
                                              AV98Inventariowwds_3_dynamicfiltersoperator1 ,
                                              AV99Inventariowwds_4_rubroscosto1 ,
                                              AV100Inventariowwds_5_rubrosnombre1 ,
                                              AV101Inventariowwds_6_textostipo1 ,
                                              AV102Inventariowwds_7_dynamicfiltersenabled2 ,
                                              AV103Inventariowwds_8_dynamicfiltersselector2 ,
                                              AV104Inventariowwds_9_dynamicfiltersoperator2 ,
                                              AV105Inventariowwds_10_rubroscosto2 ,
                                              AV106Inventariowwds_11_rubrosnombre2 ,
                                              AV107Inventariowwds_12_textostipo2 ,
                                              AV108Inventariowwds_13_dynamicfiltersenabled3 ,
                                              AV109Inventariowwds_14_dynamicfiltersselector3 ,
                                              AV110Inventariowwds_15_dynamicfiltersoperator3 ,
                                              AV111Inventariowwds_16_rubroscosto3 ,
                                              AV112Inventariowwds_17_rubrosnombre3 ,
                                              AV113Inventariowwds_18_textostipo3 ,
                                              AV114Inventariowwds_19_tfrubrosid ,
                                              AV115Inventariowwds_20_tfrubrosid_to ,
                                              AV117Inventariowwds_22_tfrubrosnombre_sel ,
                                              AV116Inventariowwds_21_tfrubrosnombre ,
                                              AV119Inventariowwds_24_tfmedidasnombre_sel ,
                                              AV118Inventariowwds_23_tfmedidasnombre ,
                                              AV120Inventariowwds_25_tftextosid ,
                                              AV121Inventariowwds_26_tftextosid_to ,
                                              AV123Inventariowwds_28_tftextostitulo_sel ,
                                              AV122Inventariowwds_27_tftextostitulo ,
                                              AV124Inventariowwds_29_tfmedidasestado_sels.Count ,
                                              A215RubrosCosto ,
                                              A122RubrosNombre ,
                                              A258TextosTipo ,
                                              A121RubrosId ,
                                              A138MedidasNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV96Inventariowwds_1_filterfulltext ,
                                              AV66GridCollapsedRecordsChildren.Count ,
                                              A137MedidasID ,
                                              AV66GridCollapsedRecordsChildren } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV100Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1), 100, "%");
         lV100Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1), 100, "%");
         lV101Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV101Inventariowwds_6_textostipo1), 20, "%");
         lV101Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV101Inventariowwds_6_textostipo1), 20, "%");
         lV106Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2), 100, "%");
         lV106Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2), 100, "%");
         lV107Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV107Inventariowwds_12_textostipo2), 20, "%");
         lV107Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV107Inventariowwds_12_textostipo2), 20, "%");
         lV112Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3), 100, "%");
         lV112Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3), 100, "%");
         lV113Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV113Inventariowwds_18_textostipo3), 20, "%");
         lV113Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV113Inventariowwds_18_textostipo3), 20, "%");
         lV116Inventariowwds_21_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV116Inventariowwds_21_tfrubrosnombre), 100, "%");
         lV118Inventariowwds_23_tfmedidasnombre = StringUtil.PadR( StringUtil.RTrim( AV118Inventariowwds_23_tfmedidasnombre), 50, "%");
         lV122Inventariowwds_27_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV122Inventariowwds_27_tftextostitulo), 80, "%");
         /* Using cursor H001U2 */
         pr_default.execute(0, new Object[] {AV99Inventariowwds_4_rubroscosto1, AV99Inventariowwds_4_rubroscosto1, AV99Inventariowwds_4_rubroscosto1, lV100Inventariowwds_5_rubrosnombre1, lV100Inventariowwds_5_rubrosnombre1, lV101Inventariowwds_6_textostipo1, lV101Inventariowwds_6_textostipo1, AV105Inventariowwds_10_rubroscosto2, AV105Inventariowwds_10_rubroscosto2, AV105Inventariowwds_10_rubroscosto2, lV106Inventariowwds_11_rubrosnombre2, lV106Inventariowwds_11_rubrosnombre2, lV107Inventariowwds_12_textostipo2, lV107Inventariowwds_12_textostipo2, AV111Inventariowwds_16_rubroscosto3, AV111Inventariowwds_16_rubroscosto3, AV111Inventariowwds_16_rubroscosto3, lV112Inventariowwds_17_rubrosnombre3, lV112Inventariowwds_17_rubrosnombre3, lV113Inventariowwds_18_textostipo3, lV113Inventariowwds_18_textostipo3, AV114Inventariowwds_19_tfrubrosid, AV115Inventariowwds_20_tfrubrosid_to, lV116Inventariowwds_21_tfrubrosnombre, AV117Inventariowwds_22_tfrubrosnombre_sel, lV118Inventariowwds_23_tfmedidasnombre, AV119Inventariowwds_24_tfmedidasnombre_sel, AV120Inventariowwds_25_tftextosid, AV121Inventariowwds_26_tftextosid_to, lV122Inventariowwds_27_tftextostitulo, AV123Inventariowwds_28_tftextostitulo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A258TextosTipo = H001U2_A258TextosTipo[0];
            A215RubrosCosto = H001U2_A215RubrosCosto[0];
            A139MedidasEstado = H001U2_A139MedidasEstado[0];
            n139MedidasEstado = H001U2_n139MedidasEstado[0];
            A259TextosTitulo = H001U2_A259TextosTitulo[0];
            A150TextosId = H001U2_A150TextosId[0];
            n150TextosId = H001U2_n150TextosId[0];
            A138MedidasNombre = H001U2_A138MedidasNombre[0];
            A137MedidasID = H001U2_A137MedidasID[0];
            A122RubrosNombre = H001U2_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = H001U2_A40001RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_129_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A121RubrosId = H001U2_A121RubrosId[0];
            A168RubrosImagen = H001U2_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_129_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A258TextosTipo = H001U2_A258TextosTipo[0];
            A259TextosTitulo = H001U2_A259TextosTitulo[0];
            A122RubrosNombre = H001U2_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = H001U2_A40001RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_129_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A168RubrosImagen = H001U2_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_129_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Inventariowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV96Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV96Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "bloqueado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "BLO") == 0 ) ) ) )
            {
               if ( ( AV66GridCollapsedRecordsChildren.Count <= 0 ) || ( ! new GeneXus.Programs.wwpbaseobjects.wwp_itemincollection(context).executeUdp(  StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0))+";"+StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)),  AV66GridCollapsedRecordsChildren) ) )
               {
                  GRID_nRecordCount = (long)(GRID_nRecordCount+1);
               }
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF1U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 129;
         /* Execute user event: Refresh */
         E281U2 ();
         nGXsfl_129_idx = 1;
         sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
         SubsflControlProps_1292( ) ;
         bGXsfl_129_Refreshing = true;
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
            SubsflControlProps_1292( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A139MedidasEstado ,
                                                 AV124Inventariowwds_29_tfmedidasestado_sels ,
                                                 AV97Inventariowwds_2_dynamicfiltersselector1 ,
                                                 AV98Inventariowwds_3_dynamicfiltersoperator1 ,
                                                 AV99Inventariowwds_4_rubroscosto1 ,
                                                 AV100Inventariowwds_5_rubrosnombre1 ,
                                                 AV101Inventariowwds_6_textostipo1 ,
                                                 AV102Inventariowwds_7_dynamicfiltersenabled2 ,
                                                 AV103Inventariowwds_8_dynamicfiltersselector2 ,
                                                 AV104Inventariowwds_9_dynamicfiltersoperator2 ,
                                                 AV105Inventariowwds_10_rubroscosto2 ,
                                                 AV106Inventariowwds_11_rubrosnombre2 ,
                                                 AV107Inventariowwds_12_textostipo2 ,
                                                 AV108Inventariowwds_13_dynamicfiltersenabled3 ,
                                                 AV109Inventariowwds_14_dynamicfiltersselector3 ,
                                                 AV110Inventariowwds_15_dynamicfiltersoperator3 ,
                                                 AV111Inventariowwds_16_rubroscosto3 ,
                                                 AV112Inventariowwds_17_rubrosnombre3 ,
                                                 AV113Inventariowwds_18_textostipo3 ,
                                                 AV114Inventariowwds_19_tfrubrosid ,
                                                 AV115Inventariowwds_20_tfrubrosid_to ,
                                                 AV117Inventariowwds_22_tfrubrosnombre_sel ,
                                                 AV116Inventariowwds_21_tfrubrosnombre ,
                                                 AV119Inventariowwds_24_tfmedidasnombre_sel ,
                                                 AV118Inventariowwds_23_tfmedidasnombre ,
                                                 AV120Inventariowwds_25_tftextosid ,
                                                 AV121Inventariowwds_26_tftextosid_to ,
                                                 AV123Inventariowwds_28_tftextostitulo_sel ,
                                                 AV122Inventariowwds_27_tftextostitulo ,
                                                 AV124Inventariowwds_29_tfmedidasestado_sels.Count ,
                                                 A215RubrosCosto ,
                                                 A122RubrosNombre ,
                                                 A258TextosTipo ,
                                                 A121RubrosId ,
                                                 A138MedidasNombre ,
                                                 A150TextosId ,
                                                 A259TextosTitulo ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV96Inventariowwds_1_filterfulltext ,
                                                 AV66GridCollapsedRecordsChildren.Count ,
                                                 A137MedidasID ,
                                                 AV66GridCollapsedRecordsChildren } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.LONG
                                                 }
            });
            lV100Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1), 100, "%");
            lV100Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1), 100, "%");
            lV101Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV101Inventariowwds_6_textostipo1), 20, "%");
            lV101Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV101Inventariowwds_6_textostipo1), 20, "%");
            lV106Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2), 100, "%");
            lV106Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2), 100, "%");
            lV107Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV107Inventariowwds_12_textostipo2), 20, "%");
            lV107Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV107Inventariowwds_12_textostipo2), 20, "%");
            lV112Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3), 100, "%");
            lV112Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3), 100, "%");
            lV113Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV113Inventariowwds_18_textostipo3), 20, "%");
            lV113Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV113Inventariowwds_18_textostipo3), 20, "%");
            lV116Inventariowwds_21_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV116Inventariowwds_21_tfrubrosnombre), 100, "%");
            lV118Inventariowwds_23_tfmedidasnombre = StringUtil.PadR( StringUtil.RTrim( AV118Inventariowwds_23_tfmedidasnombre), 50, "%");
            lV122Inventariowwds_27_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV122Inventariowwds_27_tftextostitulo), 80, "%");
            /* Using cursor H001U3 */
            pr_default.execute(1, new Object[] {AV99Inventariowwds_4_rubroscosto1, AV99Inventariowwds_4_rubroscosto1, AV99Inventariowwds_4_rubroscosto1, lV100Inventariowwds_5_rubrosnombre1, lV100Inventariowwds_5_rubrosnombre1, lV101Inventariowwds_6_textostipo1, lV101Inventariowwds_6_textostipo1, AV105Inventariowwds_10_rubroscosto2, AV105Inventariowwds_10_rubroscosto2, AV105Inventariowwds_10_rubroscosto2, lV106Inventariowwds_11_rubrosnombre2, lV106Inventariowwds_11_rubrosnombre2, lV107Inventariowwds_12_textostipo2, lV107Inventariowwds_12_textostipo2, AV111Inventariowwds_16_rubroscosto3, AV111Inventariowwds_16_rubroscosto3, AV111Inventariowwds_16_rubroscosto3, lV112Inventariowwds_17_rubrosnombre3, lV112Inventariowwds_17_rubrosnombre3, lV113Inventariowwds_18_textostipo3, lV113Inventariowwds_18_textostipo3, AV114Inventariowwds_19_tfrubrosid, AV115Inventariowwds_20_tfrubrosid_to, lV116Inventariowwds_21_tfrubrosnombre, AV117Inventariowwds_22_tfrubrosnombre_sel, lV118Inventariowwds_23_tfmedidasnombre, AV119Inventariowwds_24_tfmedidasnombre_sel, AV120Inventariowwds_25_tftextosid, AV121Inventariowwds_26_tftextosid_to, lV122Inventariowwds_27_tftextostitulo, AV123Inventariowwds_28_tftextostitulo_sel});
            nGXsfl_129_idx = 1;
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
            SubsflControlProps_1292( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A258TextosTipo = H001U3_A258TextosTipo[0];
               A215RubrosCosto = H001U3_A215RubrosCosto[0];
               A139MedidasEstado = H001U3_A139MedidasEstado[0];
               n139MedidasEstado = H001U3_n139MedidasEstado[0];
               A259TextosTitulo = H001U3_A259TextosTitulo[0];
               A150TextosId = H001U3_A150TextosId[0];
               n150TextosId = H001U3_n150TextosId[0];
               A138MedidasNombre = H001U3_A138MedidasNombre[0];
               A137MedidasID = H001U3_A137MedidasID[0];
               A122RubrosNombre = H001U3_A122RubrosNombre[0];
               A40001RubrosImagen_GXI = H001U3_A40001RubrosImagen_GXI[0];
               AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_129_Refreshing);
               AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
               A121RubrosId = H001U3_A121RubrosId[0];
               A168RubrosImagen = H001U3_A168RubrosImagen[0];
               AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_129_Refreshing);
               AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
               A258TextosTipo = H001U3_A258TextosTipo[0];
               A259TextosTitulo = H001U3_A259TextosTitulo[0];
               A122RubrosNombre = H001U3_A122RubrosNombre[0];
               A40001RubrosImagen_GXI = H001U3_A40001RubrosImagen_GXI[0];
               AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_129_Refreshing);
               AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
               A168RubrosImagen = H001U3_A168RubrosImagen[0];
               AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_129_Refreshing);
               AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Inventariowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV96Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV96Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "bloqueado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "BLO") == 0 ) ) ) )
               {
                  if ( ( AV66GridCollapsedRecordsChildren.Count <= 0 ) || ( ! new GeneXus.Programs.wwpbaseobjects.wwp_itemincollection(context).executeUdp(  StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0))+";"+StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)),  AV66GridCollapsedRecordsChildren) ) )
                  {
                     /* Execute user event: Grid.Load */
                     E291U2 ();
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 129;
            WB1U0( ) ;
         }
         bGXsfl_129_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1U2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV95Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV95Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV74IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV74IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV75IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV75IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_RUBROSNOMBRE", AV79IsAuthorized_RubrosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RUBROSNOMBRE", GetSecureSignedToken( "", AV79IsAuthorized_RubrosNombre, context));
         GxWebStd.gx_hidden_field( context, "gxhash_RUBROSID"+"_"+sGXsfl_129_idx, GetSecureSignedToken( sGXsfl_129_idx, context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MEDIDASID"+"_"+sGXsfl_129_idx, GetSecureSignedToken( sGXsfl_129_idx, context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         AV96Inventariowwds_1_filterfulltext = AV17FilterFullText;
         AV97Inventariowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV98Inventariowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV99Inventariowwds_4_rubroscosto1 = AV20RubrosCosto1;
         AV100Inventariowwds_5_rubrosnombre1 = AV21RubrosNombre1;
         AV101Inventariowwds_6_textostipo1 = AV82TextosTipo1;
         AV102Inventariowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV103Inventariowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV104Inventariowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV105Inventariowwds_10_rubroscosto2 = AV25RubrosCosto2;
         AV106Inventariowwds_11_rubrosnombre2 = AV26RubrosNombre2;
         AV107Inventariowwds_12_textostipo2 = AV83TextosTipo2;
         AV108Inventariowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV109Inventariowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV110Inventariowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV111Inventariowwds_16_rubroscosto3 = AV30RubrosCosto3;
         AV112Inventariowwds_17_rubrosnombre3 = AV31RubrosNombre3;
         AV113Inventariowwds_18_textostipo3 = AV84TextosTipo3;
         AV114Inventariowwds_19_tfrubrosid = AV45TFRubrosId;
         AV115Inventariowwds_20_tfrubrosid_to = AV46TFRubrosId_To;
         AV116Inventariowwds_21_tfrubrosnombre = AV47TFRubrosNombre;
         AV117Inventariowwds_22_tfrubrosnombre_sel = AV48TFRubrosNombre_Sel;
         AV118Inventariowwds_23_tfmedidasnombre = AV51TFMedidasNombre;
         AV119Inventariowwds_24_tfmedidasnombre_sel = AV52TFMedidasNombre_Sel;
         AV120Inventariowwds_25_tftextosid = AV53TFTextosId;
         AV121Inventariowwds_26_tftextosid_to = AV54TFTextosId_To;
         AV122Inventariowwds_27_tftextostitulo = AV55TFTextosTitulo;
         AV123Inventariowwds_28_tftextostitulo_sel = AV56TFTextosTitulo_Sel;
         AV124Inventariowwds_29_tfmedidasestado_sels = AV58TFMedidasEstado_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20RubrosCosto1, AV21RubrosNombre1, AV82TextosTipo1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25RubrosCosto2, AV26RubrosNombre2, AV83TextosTipo2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30RubrosCosto3, AV31RubrosNombre3, AV84TextosTipo3, AV44ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV39ColumnsSelector, AV95Pgmname, AV17FilterFullText, AV45TFRubrosId, AV46TFRubrosId_To, AV47TFRubrosNombre, AV48TFRubrosNombre_Sel, AV51TFMedidasNombre, AV52TFMedidasNombre_Sel, AV53TFTextosId, AV54TFTextosId_To, AV55TFTextosTitulo, AV56TFTextosTitulo_Sel, AV58TFMedidasEstado_Sels, AV67GridCollapsedRecords, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV74IsAuthorized_Update, AV75IsAuthorized_Delete, AV79IsAuthorized_RubrosNombre, AV66GridCollapsedRecordsChildren) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV96Inventariowwds_1_filterfulltext = AV17FilterFullText;
         AV97Inventariowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV98Inventariowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV99Inventariowwds_4_rubroscosto1 = AV20RubrosCosto1;
         AV100Inventariowwds_5_rubrosnombre1 = AV21RubrosNombre1;
         AV101Inventariowwds_6_textostipo1 = AV82TextosTipo1;
         AV102Inventariowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV103Inventariowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV104Inventariowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV105Inventariowwds_10_rubroscosto2 = AV25RubrosCosto2;
         AV106Inventariowwds_11_rubrosnombre2 = AV26RubrosNombre2;
         AV107Inventariowwds_12_textostipo2 = AV83TextosTipo2;
         AV108Inventariowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV109Inventariowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV110Inventariowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV111Inventariowwds_16_rubroscosto3 = AV30RubrosCosto3;
         AV112Inventariowwds_17_rubrosnombre3 = AV31RubrosNombre3;
         AV113Inventariowwds_18_textostipo3 = AV84TextosTipo3;
         AV114Inventariowwds_19_tfrubrosid = AV45TFRubrosId;
         AV115Inventariowwds_20_tfrubrosid_to = AV46TFRubrosId_To;
         AV116Inventariowwds_21_tfrubrosnombre = AV47TFRubrosNombre;
         AV117Inventariowwds_22_tfrubrosnombre_sel = AV48TFRubrosNombre_Sel;
         AV118Inventariowwds_23_tfmedidasnombre = AV51TFMedidasNombre;
         AV119Inventariowwds_24_tfmedidasnombre_sel = AV52TFMedidasNombre_Sel;
         AV120Inventariowwds_25_tftextosid = AV53TFTextosId;
         AV121Inventariowwds_26_tftextosid_to = AV54TFTextosId_To;
         AV122Inventariowwds_27_tftextostitulo = AV55TFTextosTitulo;
         AV123Inventariowwds_28_tftextostitulo_sel = AV56TFTextosTitulo_Sel;
         AV124Inventariowwds_29_tfmedidasestado_sels = AV58TFMedidasEstado_Sels;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20RubrosCosto1, AV21RubrosNombre1, AV82TextosTipo1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25RubrosCosto2, AV26RubrosNombre2, AV83TextosTipo2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30RubrosCosto3, AV31RubrosNombre3, AV84TextosTipo3, AV44ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV39ColumnsSelector, AV95Pgmname, AV17FilterFullText, AV45TFRubrosId, AV46TFRubrosId_To, AV47TFRubrosNombre, AV48TFRubrosNombre_Sel, AV51TFMedidasNombre, AV52TFMedidasNombre_Sel, AV53TFTextosId, AV54TFTextosId_To, AV55TFTextosTitulo, AV56TFTextosTitulo_Sel, AV58TFMedidasEstado_Sels, AV67GridCollapsedRecords, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV74IsAuthorized_Update, AV75IsAuthorized_Delete, AV79IsAuthorized_RubrosNombre, AV66GridCollapsedRecordsChildren) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV96Inventariowwds_1_filterfulltext = AV17FilterFullText;
         AV97Inventariowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV98Inventariowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV99Inventariowwds_4_rubroscosto1 = AV20RubrosCosto1;
         AV100Inventariowwds_5_rubrosnombre1 = AV21RubrosNombre1;
         AV101Inventariowwds_6_textostipo1 = AV82TextosTipo1;
         AV102Inventariowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV103Inventariowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV104Inventariowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV105Inventariowwds_10_rubroscosto2 = AV25RubrosCosto2;
         AV106Inventariowwds_11_rubrosnombre2 = AV26RubrosNombre2;
         AV107Inventariowwds_12_textostipo2 = AV83TextosTipo2;
         AV108Inventariowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV109Inventariowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV110Inventariowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV111Inventariowwds_16_rubroscosto3 = AV30RubrosCosto3;
         AV112Inventariowwds_17_rubrosnombre3 = AV31RubrosNombre3;
         AV113Inventariowwds_18_textostipo3 = AV84TextosTipo3;
         AV114Inventariowwds_19_tfrubrosid = AV45TFRubrosId;
         AV115Inventariowwds_20_tfrubrosid_to = AV46TFRubrosId_To;
         AV116Inventariowwds_21_tfrubrosnombre = AV47TFRubrosNombre;
         AV117Inventariowwds_22_tfrubrosnombre_sel = AV48TFRubrosNombre_Sel;
         AV118Inventariowwds_23_tfmedidasnombre = AV51TFMedidasNombre;
         AV119Inventariowwds_24_tfmedidasnombre_sel = AV52TFMedidasNombre_Sel;
         AV120Inventariowwds_25_tftextosid = AV53TFTextosId;
         AV121Inventariowwds_26_tftextosid_to = AV54TFTextosId_To;
         AV122Inventariowwds_27_tftextostitulo = AV55TFTextosTitulo;
         AV123Inventariowwds_28_tftextostitulo_sel = AV56TFTextosTitulo_Sel;
         AV124Inventariowwds_29_tfmedidasestado_sels = AV58TFMedidasEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20RubrosCosto1, AV21RubrosNombre1, AV82TextosTipo1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25RubrosCosto2, AV26RubrosNombre2, AV83TextosTipo2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30RubrosCosto3, AV31RubrosNombre3, AV84TextosTipo3, AV44ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV39ColumnsSelector, AV95Pgmname, AV17FilterFullText, AV45TFRubrosId, AV46TFRubrosId_To, AV47TFRubrosNombre, AV48TFRubrosNombre_Sel, AV51TFMedidasNombre, AV52TFMedidasNombre_Sel, AV53TFTextosId, AV54TFTextosId_To, AV55TFTextosTitulo, AV56TFTextosTitulo_Sel, AV58TFMedidasEstado_Sels, AV67GridCollapsedRecords, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV74IsAuthorized_Update, AV75IsAuthorized_Delete, AV79IsAuthorized_RubrosNombre, AV66GridCollapsedRecordsChildren) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV96Inventariowwds_1_filterfulltext = AV17FilterFullText;
         AV97Inventariowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV98Inventariowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV99Inventariowwds_4_rubroscosto1 = AV20RubrosCosto1;
         AV100Inventariowwds_5_rubrosnombre1 = AV21RubrosNombre1;
         AV101Inventariowwds_6_textostipo1 = AV82TextosTipo1;
         AV102Inventariowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV103Inventariowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV104Inventariowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV105Inventariowwds_10_rubroscosto2 = AV25RubrosCosto2;
         AV106Inventariowwds_11_rubrosnombre2 = AV26RubrosNombre2;
         AV107Inventariowwds_12_textostipo2 = AV83TextosTipo2;
         AV108Inventariowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV109Inventariowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV110Inventariowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV111Inventariowwds_16_rubroscosto3 = AV30RubrosCosto3;
         AV112Inventariowwds_17_rubrosnombre3 = AV31RubrosNombre3;
         AV113Inventariowwds_18_textostipo3 = AV84TextosTipo3;
         AV114Inventariowwds_19_tfrubrosid = AV45TFRubrosId;
         AV115Inventariowwds_20_tfrubrosid_to = AV46TFRubrosId_To;
         AV116Inventariowwds_21_tfrubrosnombre = AV47TFRubrosNombre;
         AV117Inventariowwds_22_tfrubrosnombre_sel = AV48TFRubrosNombre_Sel;
         AV118Inventariowwds_23_tfmedidasnombre = AV51TFMedidasNombre;
         AV119Inventariowwds_24_tfmedidasnombre_sel = AV52TFMedidasNombre_Sel;
         AV120Inventariowwds_25_tftextosid = AV53TFTextosId;
         AV121Inventariowwds_26_tftextosid_to = AV54TFTextosId_To;
         AV122Inventariowwds_27_tftextostitulo = AV55TFTextosTitulo;
         AV123Inventariowwds_28_tftextostitulo_sel = AV56TFTextosTitulo_Sel;
         AV124Inventariowwds_29_tfmedidasestado_sels = AV58TFMedidasEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20RubrosCosto1, AV21RubrosNombre1, AV82TextosTipo1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25RubrosCosto2, AV26RubrosNombre2, AV83TextosTipo2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30RubrosCosto3, AV31RubrosNombre3, AV84TextosTipo3, AV44ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV39ColumnsSelector, AV95Pgmname, AV17FilterFullText, AV45TFRubrosId, AV46TFRubrosId_To, AV47TFRubrosNombre, AV48TFRubrosNombre_Sel, AV51TFMedidasNombre, AV52TFMedidasNombre_Sel, AV53TFTextosId, AV54TFTextosId_To, AV55TFTextosTitulo, AV56TFTextosTitulo_Sel, AV58TFMedidasEstado_Sels, AV67GridCollapsedRecords, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV74IsAuthorized_Update, AV75IsAuthorized_Delete, AV79IsAuthorized_RubrosNombre, AV66GridCollapsedRecordsChildren) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV96Inventariowwds_1_filterfulltext = AV17FilterFullText;
         AV97Inventariowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV98Inventariowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV99Inventariowwds_4_rubroscosto1 = AV20RubrosCosto1;
         AV100Inventariowwds_5_rubrosnombre1 = AV21RubrosNombre1;
         AV101Inventariowwds_6_textostipo1 = AV82TextosTipo1;
         AV102Inventariowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV103Inventariowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV104Inventariowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV105Inventariowwds_10_rubroscosto2 = AV25RubrosCosto2;
         AV106Inventariowwds_11_rubrosnombre2 = AV26RubrosNombre2;
         AV107Inventariowwds_12_textostipo2 = AV83TextosTipo2;
         AV108Inventariowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV109Inventariowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV110Inventariowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV111Inventariowwds_16_rubroscosto3 = AV30RubrosCosto3;
         AV112Inventariowwds_17_rubrosnombre3 = AV31RubrosNombre3;
         AV113Inventariowwds_18_textostipo3 = AV84TextosTipo3;
         AV114Inventariowwds_19_tfrubrosid = AV45TFRubrosId;
         AV115Inventariowwds_20_tfrubrosid_to = AV46TFRubrosId_To;
         AV116Inventariowwds_21_tfrubrosnombre = AV47TFRubrosNombre;
         AV117Inventariowwds_22_tfrubrosnombre_sel = AV48TFRubrosNombre_Sel;
         AV118Inventariowwds_23_tfmedidasnombre = AV51TFMedidasNombre;
         AV119Inventariowwds_24_tfmedidasnombre_sel = AV52TFMedidasNombre_Sel;
         AV120Inventariowwds_25_tftextosid = AV53TFTextosId;
         AV121Inventariowwds_26_tftextosid_to = AV54TFTextosId_To;
         AV122Inventariowwds_27_tftextostitulo = AV55TFTextosTitulo;
         AV123Inventariowwds_28_tftextostitulo_sel = AV56TFTextosTitulo_Sel;
         AV124Inventariowwds_29_tfmedidasestado_sels = AV58TFMedidasEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20RubrosCosto1, AV21RubrosNombre1, AV82TextosTipo1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25RubrosCosto2, AV26RubrosNombre2, AV83TextosTipo2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30RubrosCosto3, AV31RubrosNombre3, AV84TextosTipo3, AV44ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV39ColumnsSelector, AV95Pgmname, AV17FilterFullText, AV45TFRubrosId, AV46TFRubrosId_To, AV47TFRubrosNombre, AV48TFRubrosNombre_Sel, AV51TFMedidasNombre, AV52TFMedidasNombre_Sel, AV53TFTextosId, AV54TFTextosId_To, AV55TFTextosTitulo, AV56TFTextosTitulo_Sel, AV58TFMedidasEstado_Sels, AV67GridCollapsedRecords, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV74IsAuthorized_Update, AV75IsAuthorized_Delete, AV79IsAuthorized_RubrosNombre, AV66GridCollapsedRecordsChildren) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV95Pgmname = "InventarioWW";
         edtavExpand_Enabled = 0;
         edtavGrid_groupcaption_Enabled = 0;
         edtRubrosId_Enabled = 0;
         edtRubrosImagen_Enabled = 0;
         edtRubrosNombre_Enabled = 0;
         edtMedidasID_Enabled = 0;
         edtMedidasNombre_Enabled = 0;
         edtTextosId_Enabled = 0;
         edtTextosTitulo_Enabled = 0;
         cmbMedidasEstado.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E271U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV42ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV76AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV59DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV39ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_129 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_129"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV61GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV62GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV63GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Grid_group_Gridinternalname = cgiGet( "GRID_GROUP_Gridinternalname");
            Grid_group_Columnindex = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_GROUP_Columnindex"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Hasrowgroups = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hasrowgroups"));
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
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRubroscosto1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavRubroscosto1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRUBROSCOSTO1");
               GX_FocusControl = edtavRubroscosto1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20RubrosCosto1 = 0;
               AssignAttri("", false, "AV20RubrosCosto1", StringUtil.LTrimStr( AV20RubrosCosto1, 18, 2));
            }
            else
            {
               AV20RubrosCosto1 = context.localUtil.CToN( cgiGet( edtavRubroscosto1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV20RubrosCosto1", StringUtil.LTrimStr( AV20RubrosCosto1, 18, 2));
            }
            AV21RubrosNombre1 = cgiGet( edtavRubrosnombre1_Internalname);
            AssignAttri("", false, "AV21RubrosNombre1", AV21RubrosNombre1);
            AV82TextosTipo1 = cgiGet( edtavTextostipo1_Internalname);
            AssignAttri("", false, "AV82TextosTipo1", AV82TextosTipo1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRubroscosto2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavRubroscosto2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRUBROSCOSTO2");
               GX_FocusControl = edtavRubroscosto2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25RubrosCosto2 = 0;
               AssignAttri("", false, "AV25RubrosCosto2", StringUtil.LTrimStr( AV25RubrosCosto2, 18, 2));
            }
            else
            {
               AV25RubrosCosto2 = context.localUtil.CToN( cgiGet( edtavRubroscosto2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV25RubrosCosto2", StringUtil.LTrimStr( AV25RubrosCosto2, 18, 2));
            }
            AV26RubrosNombre2 = cgiGet( edtavRubrosnombre2_Internalname);
            AssignAttri("", false, "AV26RubrosNombre2", AV26RubrosNombre2);
            AV83TextosTipo2 = cgiGet( edtavTextostipo2_Internalname);
            AssignAttri("", false, "AV83TextosTipo2", AV83TextosTipo2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV28DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRubroscosto3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavRubroscosto3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRUBROSCOSTO3");
               GX_FocusControl = edtavRubroscosto3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30RubrosCosto3 = 0;
               AssignAttri("", false, "AV30RubrosCosto3", StringUtil.LTrimStr( AV30RubrosCosto3, 18, 2));
            }
            else
            {
               AV30RubrosCosto3 = context.localUtil.CToN( cgiGet( edtavRubroscosto3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV30RubrosCosto3", StringUtil.LTrimStr( AV30RubrosCosto3, 18, 2));
            }
            AV31RubrosNombre3 = cgiGet( edtavRubrosnombre3_Internalname);
            AssignAttri("", false, "AV31RubrosNombre3", AV31RubrosNombre3);
            AV84TextosTipo3 = cgiGet( edtavTextostipo3_Internalname);
            AssignAttri("", false, "AV84TextosTipo3", AV84TextosTipo3);
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vRUBROSCOSTO1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV20RubrosCosto1 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRUBROSNOMBRE1"), AV21RubrosNombre1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTEXTOSTIPO1"), AV82TextosTipo1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vRUBROSCOSTO2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV25RubrosCosto2 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRUBROSNOMBRE2"), AV26RubrosNombre2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTEXTOSTIPO2"), AV83TextosTipo2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV28DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV29DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vRUBROSCOSTO3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV30RubrosCosto3 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vRUBROSNOMBRE3"), AV31RubrosNombre3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTEXTOSTIPO3"), AV84TextosTipo3) != 0 )
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
         E271U2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E271U2( )
      {
         /* Start Routine */
         returnInSub = false;
         Grid_group_Gridinternalname = subGrid_Internalname;
         ucGrid_group.SendProperty(context, "", false, Grid_group_Internalname, "GridInternalName", Grid_group_Gridinternalname);
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
         AV18DynamicFiltersSelector1 = "RUBROSCOSTO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector2 = "RUBROSCOSTO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28DynamicFiltersSelector3 = "RUBROSCOSTO";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
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
         AV76AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV77AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV77AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV77AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV77AGExportDataItem.gxTpr_Eventkey = "Export";
         AV77AGExportDataItem.gxTpr_Isdivider = false;
         AV76AGExportData.Add(AV77AGExportDataItem, 0);
         AV77AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV77AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV77AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV77AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV77AGExportDataItem.gxTpr_Isdivider = false;
         AV76AGExportData.Add(AV77AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         AV76AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV77AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV77AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV77AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV77AGExportDataItem.gxTpr_Eventkey = "Export";
         AV77AGExportDataItem.gxTpr_Isdivider = false;
         AV76AGExportData.Add(AV77AGExportDataItem, 0);
         AV77AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV77AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV77AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV77AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV77AGExportDataItem.gxTpr_Isdivider = false;
         AV76AGExportData.Add(AV77AGExportDataItem, 0);
         GXt_boolean1 = AV79IsAuthorized_RubrosNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubros", out  GXt_boolean1) ;
         AV79IsAuthorized_RubrosNombre = GXt_boolean1;
         AssignAttri("", false, "AV79IsAuthorized_RubrosNombre", AV79IsAuthorized_RubrosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_RUBROSNOMBRE", GetSecureSignedToken( "", AV79IsAuthorized_RubrosNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Inventario", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV59DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV59DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E281U2( )
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
         if ( AV44ManageFiltersExecutionStep == 1 )
         {
            AV44ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV44ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV44ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV44ManageFiltersExecutionStep == 2 )
         {
            AV44ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV44ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV44ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RUBROSCOSTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TEXTOSTIPO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RUBROSCOSTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TEXTOSTIPO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            if ( AV27DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "RUBROSCOSTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "TEXTOSTIPO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV41Session.Get("InventarioWWColumnsSelector"), "") != 0 )
         {
            AV37ColumnsSelectorXML = AV41Session.Get("InventarioWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV37ColumnsSelectorXML, null, "", "");
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
         edtRubrosId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtRubrosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRubrosId_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtRubrosImagen_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtRubrosImagen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRubrosImagen_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtRubrosNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtRubrosNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRubrosNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtMedidasNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMedidasNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMedidasNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtTextosId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtTextosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTextosId_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtTextosTitulo_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtTextosTitulo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTextosTitulo_Visible), 5, 0), !bGXsfl_129_Refreshing);
         cmbMedidasEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbMedidasEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbMedidasEstado.Visible), 5, 0), !bGXsfl_129_Refreshing);
         AV61GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV61GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV61GridCurrentPage), 10, 0));
         AV62GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV62GridPageCount", StringUtil.LTrimStr( (decimal)(AV62GridPageCount), 10, 0));
         GXt_char3 = AV63GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV95Pgmname, out  GXt_char3) ;
         AV63GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV63GridAppliedFilters", AV63GridAppliedFilters);
         AV34Grid_GroupCaption = "";
         AssignAttri("", false, edtavGrid_groupcaption_Internalname, AV34Grid_GroupCaption);
         AV96Inventariowwds_1_filterfulltext = AV17FilterFullText;
         AV97Inventariowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV98Inventariowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV99Inventariowwds_4_rubroscosto1 = AV20RubrosCosto1;
         AV100Inventariowwds_5_rubrosnombre1 = AV21RubrosNombre1;
         AV101Inventariowwds_6_textostipo1 = AV82TextosTipo1;
         AV102Inventariowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV103Inventariowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV104Inventariowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV105Inventariowwds_10_rubroscosto2 = AV25RubrosCosto2;
         AV106Inventariowwds_11_rubrosnombre2 = AV26RubrosNombre2;
         AV107Inventariowwds_12_textostipo2 = AV83TextosTipo2;
         AV108Inventariowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV109Inventariowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV110Inventariowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV111Inventariowwds_16_rubroscosto3 = AV30RubrosCosto3;
         AV112Inventariowwds_17_rubrosnombre3 = AV31RubrosNombre3;
         AV113Inventariowwds_18_textostipo3 = AV84TextosTipo3;
         AV114Inventariowwds_19_tfrubrosid = AV45TFRubrosId;
         AV115Inventariowwds_20_tfrubrosid_to = AV46TFRubrosId_To;
         AV116Inventariowwds_21_tfrubrosnombre = AV47TFRubrosNombre;
         AV117Inventariowwds_22_tfrubrosnombre_sel = AV48TFRubrosNombre_Sel;
         AV118Inventariowwds_23_tfmedidasnombre = AV51TFMedidasNombre;
         AV119Inventariowwds_24_tfmedidasnombre_sel = AV52TFMedidasNombre_Sel;
         AV120Inventariowwds_25_tftextosid = AV53TFTextosId;
         AV121Inventariowwds_26_tftextosid_to = AV54TFTextosId_To;
         AV122Inventariowwds_27_tftextostitulo = AV55TFTextosTitulo;
         AV123Inventariowwds_28_tftextostitulo_sel = AV56TFTextosTitulo_Sel;
         AV124Inventariowwds_29_tfmedidasestado_sels = AV58TFMedidasEstado_Sels;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridCollapsedRecords", AV67GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridCollapsedRecordsChildren", AV66GridCollapsedRecordsChildren);
      }

      protected void E121U2( )
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
            AV60PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV60PageToGo) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridCollapsedRecords", AV67GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridCollapsedRecordsChildren", AV66GridCollapsedRecordsChildren);
      }

      protected void E131U2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E161U2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubrosId") == 0 )
            {
               AV45TFRubrosId = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFRubrosId", StringUtil.LTrimStr( (decimal)(AV45TFRubrosId), 4, 0));
               AV46TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFRubrosId_To", StringUtil.LTrimStr( (decimal)(AV46TFRubrosId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RubrosNombre") == 0 )
            {
               AV47TFRubrosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV47TFRubrosNombre", AV47TFRubrosNombre);
               AV48TFRubrosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV48TFRubrosNombre_Sel", AV48TFRubrosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedidasNombre") == 0 )
            {
               AV51TFMedidasNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV51TFMedidasNombre", AV51TFMedidasNombre);
               AV52TFMedidasNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV52TFMedidasNombre_Sel", AV52TFMedidasNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TextosId") == 0 )
            {
               AV53TFTextosId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV53TFTextosId", StringUtil.LTrimStr( (decimal)(AV53TFTextosId), 18, 0));
               AV54TFTextosId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV54TFTextosId_To", StringUtil.LTrimStr( (decimal)(AV54TFTextosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TextosTitulo") == 0 )
            {
               AV55TFTextosTitulo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV55TFTextosTitulo", AV55TFTextosTitulo);
               AV56TFTextosTitulo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV56TFTextosTitulo_Sel", AV56TFTextosTitulo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MedidasEstado") == 0 )
            {
               AV57TFMedidasEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV57TFMedidasEstado_SelsJson", AV57TFMedidasEstado_SelsJson);
               AV58TFMedidasEstado_Sels.FromJSonString(AV57TFMedidasEstado_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58TFMedidasEstado_Sels", AV58TFMedidasEstado_Sels);
      }

      private void E291U2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV34Grid_GroupCaption = A122RubrosNombre;
            AssignAttri("", false, edtavGrid_groupcaption_Internalname, AV34Grid_GroupCaption);
            AV34Grid_GroupCaption = StringUtil.Format( "%1: %2", "", (String.IsNullOrEmpty(StringUtil.RTrim( A122RubrosNombre)) ? context.GetMessage( "WWP_FilterEmpty", "") : AV34Grid_GroupCaption), "", "", "", "", "", "", "");
            AssignAttri("", false, edtavGrid_groupcaption_Internalname, AV34Grid_GroupCaption);
            AV68Index = AV67GridCollapsedRecords.IndexOf(StringUtil.Trim( A122RubrosNombre));
            AV72Expand = ((AV68Index>0) ? "<i class=\"fas fa-angle-right\"></i>" : "<i class=\"fas fa-angle-down\"></i>");
            AssignAttri("", false, edtavExpand_Internalname, AV72Expand);
            edtavExpand_Columnclass = ((AV68Index>0) ? "WWPExpand" : "WWPCollapse");
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV74IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV75IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            if ( AV79IsAuthorized_RubrosNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "rubrosview.aspx"+UrlEncode(StringUtil.LTrimStr(A121RubrosId,4,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtRubrosNombre_Link = formatLink("rubrosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( AV66GridCollapsedRecordsChildren.Count == 0 )
            {
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 129;
            }
            sendrow_1292( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_129_Refreshing )
         {
            context.DoAjaxLoad(129, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0));
      }

      protected void E171U2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV37ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV39ColumnsSelector.FromJSonString(AV37ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "InventarioWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV37ColumnsSelectorXML)) ? "" : AV39ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridCollapsedRecords", AV67GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridCollapsedRecordsChildren", AV66GridCollapsedRecordsChildren);
      }

      protected void E221U2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20RubrosCosto1, AV21RubrosNombre1, AV82TextosTipo1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25RubrosCosto2, AV26RubrosNombre2, AV83TextosTipo2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30RubrosCosto3, AV31RubrosNombre3, AV84TextosTipo3, AV44ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV39ColumnsSelector, AV95Pgmname, AV17FilterFullText, AV45TFRubrosId, AV46TFRubrosId_To, AV47TFRubrosNombre, AV48TFRubrosNombre_Sel, AV51TFMedidasNombre, AV52TFMedidasNombre_Sel, AV53TFTextosId, AV54TFTextosId_To, AV55TFTextosTitulo, AV56TFTextosTitulo_Sel, AV58TFMedidasEstado_Sels, AV67GridCollapsedRecords, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV74IsAuthorized_Update, AV75IsAuthorized_Delete, AV79IsAuthorized_RubrosNombre, AV66GridCollapsedRecordsChildren) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridCollapsedRecords", AV67GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridCollapsedRecordsChildren", AV66GridCollapsedRecordsChildren);
      }

      protected void E181U2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
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
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20RubrosCosto1, AV21RubrosNombre1, AV82TextosTipo1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25RubrosCosto2, AV26RubrosNombre2, AV83TextosTipo2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30RubrosCosto3, AV31RubrosNombre3, AV84TextosTipo3, AV44ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV39ColumnsSelector, AV95Pgmname, AV17FilterFullText, AV45TFRubrosId, AV46TFRubrosId_To, AV47TFRubrosNombre, AV48TFRubrosNombre_Sel, AV51TFMedidasNombre, AV52TFMedidasNombre_Sel, AV53TFTextosId, AV54TFTextosId_To, AV55TFTextosTitulo, AV56TFTextosTitulo_Sel, AV58TFMedidasEstado_Sels, AV67GridCollapsedRecords, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV74IsAuthorized_Update, AV75IsAuthorized_Delete, AV79IsAuthorized_RubrosNombre, AV66GridCollapsedRecordsChildren) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridCollapsedRecords", AV67GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridCollapsedRecordsChildren", AV66GridCollapsedRecordsChildren);
      }

      protected void E231U2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E241U2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20RubrosCosto1, AV21RubrosNombre1, AV82TextosTipo1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25RubrosCosto2, AV26RubrosNombre2, AV83TextosTipo2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30RubrosCosto3, AV31RubrosNombre3, AV84TextosTipo3, AV44ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV39ColumnsSelector, AV95Pgmname, AV17FilterFullText, AV45TFRubrosId, AV46TFRubrosId_To, AV47TFRubrosNombre, AV48TFRubrosNombre_Sel, AV51TFMedidasNombre, AV52TFMedidasNombre_Sel, AV53TFTextosId, AV54TFTextosId_To, AV55TFTextosTitulo, AV56TFTextosTitulo_Sel, AV58TFMedidasEstado_Sels, AV67GridCollapsedRecords, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV74IsAuthorized_Update, AV75IsAuthorized_Delete, AV79IsAuthorized_RubrosNombre, AV66GridCollapsedRecordsChildren) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridCollapsedRecords", AV67GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridCollapsedRecordsChildren", AV66GridCollapsedRecordsChildren);
      }

      protected void E191U2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
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
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20RubrosCosto1, AV21RubrosNombre1, AV82TextosTipo1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25RubrosCosto2, AV26RubrosNombre2, AV83TextosTipo2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30RubrosCosto3, AV31RubrosNombre3, AV84TextosTipo3, AV44ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV39ColumnsSelector, AV95Pgmname, AV17FilterFullText, AV45TFRubrosId, AV46TFRubrosId_To, AV47TFRubrosNombre, AV48TFRubrosNombre_Sel, AV51TFMedidasNombre, AV52TFMedidasNombre_Sel, AV53TFTextosId, AV54TFTextosId_To, AV55TFTextosTitulo, AV56TFTextosTitulo_Sel, AV58TFMedidasEstado_Sels, AV67GridCollapsedRecords, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV74IsAuthorized_Update, AV75IsAuthorized_Delete, AV79IsAuthorized_RubrosNombre, AV66GridCollapsedRecordsChildren) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridCollapsedRecords", AV67GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridCollapsedRecordsChildren", AV66GridCollapsedRecordsChildren);
      }

      protected void E251U2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E201U2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
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
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20RubrosCosto1, AV21RubrosNombre1, AV82TextosTipo1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25RubrosCosto2, AV26RubrosNombre2, AV83TextosTipo2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30RubrosCosto3, AV31RubrosNombre3, AV84TextosTipo3, AV44ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV39ColumnsSelector, AV95Pgmname, AV17FilterFullText, AV45TFRubrosId, AV46TFRubrosId_To, AV47TFRubrosNombre, AV48TFRubrosNombre_Sel, AV51TFMedidasNombre, AV52TFMedidasNombre_Sel, AV53TFTextosId, AV54TFTextosId_To, AV55TFTextosTitulo, AV56TFTextosTitulo_Sel, AV58TFMedidasEstado_Sels, AV67GridCollapsedRecords, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV74IsAuthorized_Update, AV75IsAuthorized_Delete, AV79IsAuthorized_RubrosNombre, AV66GridCollapsedRecordsChildren) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridCollapsedRecords", AV67GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridCollapsedRecordsChildren", AV66GridCollapsedRecordsChildren);
      }

      protected void E261U2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E111U2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("InventarioWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV95Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV44ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV44ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV44ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("InventarioWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV44ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV44ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV44ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV43ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "InventarioWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV43ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV95Pgmname+"GridState",  AV43ManageFiltersXml) ;
               AV11GridState.FromXml(AV43ManageFiltersXml, null, "", "");
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
               AV67GridCollapsedRecords.FromJSonString(AV11GridState.gxTpr_Collapsedrecords, null);
               if ( AV67GridCollapsedRecords.Count > 0 )
               {
                  AV71AddChildren = true;
                  AssignAttri("", false, "AV71AddChildren", AV71AddChildren);
                  AV125GXV1 = 1;
                  while ( AV125GXV1 <= AV67GridCollapsedRecords.Count )
                  {
                     AV65GroupRubrosNombre = AV67GridCollapsedRecords.GetString(AV125GXV1);
                     AssignAttri("", false, "AV65GroupRubrosNombre", AV65GroupRubrosNombre);
                     /* Execute user subroutine: 'ADDREMOVECHILDREN' */
                     S312 ();
                     if ( returnInSub )
                     {
                        returnInSub = true;
                        if (true) return;
                     }
                     AV125GXV1 = (int)(AV125GXV1+1);
                  }
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridCollapsedRecords", AV67GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58TFMedidasEstado_Sels", AV58TFMedidasEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridCollapsedRecordsChildren", AV66GridCollapsedRecordsChildren);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
      }

      protected void E301U2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV73GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV73GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV73GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV73GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV73GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E211U2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "inventario.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("inventario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E141U2( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridCollapsedRecords", AV67GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58TFMedidasEstado_Sels", AV58TFMedidasEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridCollapsedRecordsChildren", AV66GridCollapsedRecordsChildren);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
      }

      protected void E151U2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0156",(string)"",(string)"Inventario",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0156"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E311U2( )
      {
         /* Expand_Click Routine */
         returnInSub = false;
         AV65GroupRubrosNombre = A122RubrosNombre;
         AssignAttri("", false, "AV65GroupRubrosNombre", AV65GroupRubrosNombre);
         AV68Index = AV67GridCollapsedRecords.IndexOf(StringUtil.Trim( A122RubrosNombre));
         if ( AV68Index > 0 )
         {
            AV67GridCollapsedRecords.RemoveItem((int)(AV68Index));
         }
         else
         {
            AV67GridCollapsedRecords.Add(StringUtil.Trim( A122RubrosNombre), 0);
         }
         AV71AddChildren = (0==AV68Index);
         AssignAttri("", false, "AV71AddChildren", AV71AddChildren);
         /* Execute user subroutine: 'ADDREMOVECHILDREN' */
         S312 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridCollapsedRecords", AV67GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66GridCollapsedRecordsChildren", AV66GridCollapsedRecordsChildren);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42ManageFiltersData", AV42ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
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
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "RubrosId",  "",  "Rubro",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "RubrosImagen",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "RubrosNombre",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MedidasNombre",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "TextosId",  "",  "#",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "TextosTitulo",  "",  "Terminos y Condiciones",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MedidasEstado",  "",  "",  true,  "") ;
         GXt_char3 = AV38UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "InventarioWWColumnsSelector", out  GXt_char3) ;
         AV38UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38UserCustomValue)) ) )
         {
            AV40ColumnsSelectorAux.FromXml(AV38UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV40ColumnsSelectorAux, ref  AV39ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV74IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario_Update", out  GXt_boolean1) ;
         AV74IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV74IsAuthorized_Update", AV74IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV74IsAuthorized_Update, context));
         GXt_boolean1 = AV75IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario_Delete", out  GXt_boolean1) ;
         AV75IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV75IsAuthorized_Delete", AV75IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV75IsAuthorized_Delete, context));
         GXt_boolean1 = AV78TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario_Insert", out  GXt_boolean1) ;
         AV78TempBoolean = GXt_boolean1;
         if ( ! ( AV78TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV78TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean1) ;
         AV78TempBoolean = GXt_boolean1;
         if ( ! ( AV78TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Inventario",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavRubroscosto1_Visible = 0;
         AssignProp("", false, edtavRubroscosto1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubroscosto1_Visible), 5, 0), true);
         edtavRubrosnombre1_Visible = 0;
         AssignProp("", false, edtavRubrosnombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubrosnombre1_Visible), 5, 0), true);
         edtavTextostipo1_Visible = 0;
         AssignProp("", false, edtavTextostipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTextostipo1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RUBROSCOSTO") == 0 )
         {
            edtavRubroscosto1_Visible = 1;
            AssignProp("", false, edtavRubroscosto1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubroscosto1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 )
         {
            edtavRubrosnombre1_Visible = 1;
            AssignProp("", false, edtavRubrosnombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubrosnombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TEXTOSTIPO") == 0 )
         {
            edtavTextostipo1_Visible = 1;
            AssignProp("", false, edtavTextostipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTextostipo1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavRubroscosto2_Visible = 0;
         AssignProp("", false, edtavRubroscosto2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubroscosto2_Visible), 5, 0), true);
         edtavRubrosnombre2_Visible = 0;
         AssignProp("", false, edtavRubrosnombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubrosnombre2_Visible), 5, 0), true);
         edtavTextostipo2_Visible = 0;
         AssignProp("", false, edtavTextostipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTextostipo2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RUBROSCOSTO") == 0 )
         {
            edtavRubroscosto2_Visible = 1;
            AssignProp("", false, edtavRubroscosto2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubroscosto2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 )
         {
            edtavRubrosnombre2_Visible = 1;
            AssignProp("", false, edtavRubrosnombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubrosnombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TEXTOSTIPO") == 0 )
         {
            edtavTextostipo2_Visible = 1;
            AssignProp("", false, edtavTextostipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTextostipo2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavRubroscosto3_Visible = 0;
         AssignProp("", false, edtavRubroscosto3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubroscosto3_Visible), 5, 0), true);
         edtavRubrosnombre3_Visible = 0;
         AssignProp("", false, edtavRubrosnombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubrosnombre3_Visible), 5, 0), true);
         edtavTextostipo3_Visible = 0;
         AssignProp("", false, edtavTextostipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTextostipo3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "RUBROSCOSTO") == 0 )
         {
            edtavRubroscosto3_Visible = 1;
            AssignProp("", false, edtavRubroscosto3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubroscosto3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 )
         {
            edtavRubrosnombre3_Visible = 1;
            AssignProp("", false, edtavRubrosnombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRubrosnombre3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "TEXTOSTIPO") == 0 )
         {
            edtavTextostipo3_Visible = 1;
            AssignProp("", false, edtavTextostipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTextostipo3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         AV23DynamicFiltersSelector2 = "RUBROSCOSTO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV25RubrosCosto2 = 0;
         AssignAttri("", false, "AV25RubrosCosto2", StringUtil.LTrimStr( AV25RubrosCosto2, 18, 2));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         AV28DynamicFiltersSelector3 = "RUBROSCOSTO";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AV30RubrosCosto3 = 0;
         AssignAttri("", false, "AV30RubrosCosto3", StringUtil.LTrimStr( AV30RubrosCosto3, 18, 2));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV42ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "InventarioWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV42ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV45TFRubrosId = 0;
         AssignAttri("", false, "AV45TFRubrosId", StringUtil.LTrimStr( (decimal)(AV45TFRubrosId), 4, 0));
         AV46TFRubrosId_To = 0;
         AssignAttri("", false, "AV46TFRubrosId_To", StringUtil.LTrimStr( (decimal)(AV46TFRubrosId_To), 4, 0));
         AV47TFRubrosNombre = "";
         AssignAttri("", false, "AV47TFRubrosNombre", AV47TFRubrosNombre);
         AV48TFRubrosNombre_Sel = "";
         AssignAttri("", false, "AV48TFRubrosNombre_Sel", AV48TFRubrosNombre_Sel);
         AV51TFMedidasNombre = "";
         AssignAttri("", false, "AV51TFMedidasNombre", AV51TFMedidasNombre);
         AV52TFMedidasNombre_Sel = "";
         AssignAttri("", false, "AV52TFMedidasNombre_Sel", AV52TFMedidasNombre_Sel);
         AV53TFTextosId = 0;
         AssignAttri("", false, "AV53TFTextosId", StringUtil.LTrimStr( (decimal)(AV53TFTextosId), 18, 0));
         AV54TFTextosId_To = 0;
         AssignAttri("", false, "AV54TFTextosId_To", StringUtil.LTrimStr( (decimal)(AV54TFTextosId_To), 18, 0));
         AV55TFTextosTitulo = "";
         AssignAttri("", false, "AV55TFTextosTitulo", AV55TFTextosTitulo);
         AV56TFTextosTitulo_Sel = "";
         AssignAttri("", false, "AV56TFTextosTitulo_Sel", AV56TFTextosTitulo_Sel);
         AV58TFMedidasEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "RUBROSCOSTO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20RubrosCosto1 = 0;
         AssignAttri("", false, "AV20RubrosCosto1", StringUtil.LTrimStr( AV20RubrosCosto1, 18, 2));
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
         AV67GridCollapsedRecords = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV66GridCollapsedRecordsChildren = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
      }

      protected void S262( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "inventario.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A121RubrosId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(A137MedidasID,18,0));
         CallWebObject(formatLink("inventario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "inventario.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A121RubrosId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(A137MedidasID,18,0));
         CallWebObject(formatLink("inventario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "inventario.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A121RubrosId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(A137MedidasID,18,0));
         CallWebObject(formatLink("inventario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41Session.Get(AV95Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV95Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV41Session.Get(AV95Pgmname+"GridState"), null, "", "");
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
         AV67GridCollapsedRecords.FromJSonString(AV11GridState.gxTpr_Collapsedrecords, null);
         if ( AV67GridCollapsedRecords.Count > 0 )
         {
            AV71AddChildren = true;
            AssignAttri("", false, "AV71AddChildren", AV71AddChildren);
            AV126GXV2 = 1;
            while ( AV126GXV2 <= AV67GridCollapsedRecords.Count )
            {
               AV65GroupRubrosNombre = AV67GridCollapsedRecords.GetString(AV126GXV2);
               AssignAttri("", false, "AV65GroupRubrosNombre", AV65GroupRubrosNombre);
               /* Execute user subroutine: 'ADDREMOVECHILDREN' */
               S312 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               AV126GXV2 = (int)(AV126GXV2+1);
            }
         }
      }

      protected void S252( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV127GXV3 = 1;
         while ( AV127GXV3 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV127GXV3));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV45TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFRubrosId", StringUtil.LTrimStr( (decimal)(AV45TFRubrosId), 4, 0));
               AV46TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFRubrosId_To", StringUtil.LTrimStr( (decimal)(AV46TFRubrosId_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV47TFRubrosNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFRubrosNombre", AV47TFRubrosNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV48TFRubrosNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFRubrosNombre_Sel", AV48TFRubrosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE") == 0 )
            {
               AV51TFMedidasNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFMedidasNombre", AV51TFMedidasNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE_SEL") == 0 )
            {
               AV52TFMedidasNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFMedidasNombre_Sel", AV52TFMedidasNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV53TFTextosId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV53TFTextosId", StringUtil.LTrimStr( (decimal)(AV53TFTextosId), 18, 0));
               AV54TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV54TFTextosId_To", StringUtil.LTrimStr( (decimal)(AV54TFTextosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV55TFTextosTitulo = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFTextosTitulo", AV55TFTextosTitulo);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV56TFTextosTitulo_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFTextosTitulo_Sel", AV56TFTextosTitulo_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMEDIDASESTADO_SEL") == 0 )
            {
               AV57TFMedidasEstado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV57TFMedidasEstado_SelsJson", AV57TFMedidasEstado_SelsJson);
               AV58TFMedidasEstado_Sels.FromJSonString(AV57TFMedidasEstado_SelsJson, null);
            }
            AV127GXV3 = (int)(AV127GXV3+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFRubrosNombre_Sel)),  AV48TFRubrosNombre_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFMedidasNombre_Sel)),  AV52TFMedidasNombre_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFTextosTitulo_Sel)),  AV56TFTextosTitulo_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV58TFMedidasEstado_Sels.Count==0),  AV57TFMedidasEstado_SelsJson, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char3+"|"+GXt_char5+"||"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFRubrosNombre)),  AV47TFRubrosNombre, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFMedidasNombre)),  AV51TFMedidasNombre, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFTextosTitulo)),  AV55TFTextosTitulo, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = ((0==AV45TFRubrosId) ? "" : StringUtil.Str( (decimal)(AV45TFRubrosId), 4, 0))+"||"+GXt_char7+"|"+GXt_char6+"|"+((0==AV53TFTextosId) ? "" : StringUtil.Str( (decimal)(AV53TFTextosId), 18, 0))+"|"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV46TFRubrosId_To) ? "" : StringUtil.Str( (decimal)(AV46TFRubrosId_To), 4, 0))+"||||"+((0==AV54TFTextosId_To) ? "" : StringUtil.Str( (decimal)(AV54TFTextosId_To), 18, 0))+"||";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RUBROSCOSTO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20RubrosCosto1 = NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, ".");
               AssignAttri("", false, "AV20RubrosCosto1", StringUtil.LTrimStr( AV20RubrosCosto1, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV21RubrosNombre1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21RubrosNombre1", AV21RubrosNombre1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TEXTOSTIPO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV82TextosTipo1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV82TextosTipo1", AV82TextosTipo1);
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
               AV22DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RUBROSCOSTO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25RubrosCosto2 = NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, ".");
                  AssignAttri("", false, "AV25RubrosCosto2", StringUtil.LTrimStr( AV25RubrosCosto2, 18, 2));
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV26RubrosNombre2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26RubrosNombre2", AV26RubrosNombre2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TEXTOSTIPO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV83TextosTipo2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV83TextosTipo2", AV83TextosTipo2);
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
                  AV27DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "RUBROSCOSTO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV30RubrosCosto3 = NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, ".");
                     AssignAttri("", false, "AV30RubrosCosto3", StringUtil.LTrimStr( AV30RubrosCosto3, 18, 2));
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV31RubrosNombre3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31RubrosNombre3", AV31RubrosNombre3);
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "TEXTOSTIPO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV84TextosTipo3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV84TextosTipo3", AV84TextosTipo3);
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
         if ( AV32DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV41Session.Get(AV95Pgmname+"GridState"), null, "", "");
         AV69OldGridState.FromXml(AV11GridState.ToXml(false, true, "", ""), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFRUBROSID",  context.GetMessage( "Rubro", ""),  !((0==AV45TFRubrosId)&&(0==AV46TFRubrosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV45TFRubrosId), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV46TFRubrosId_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRUBROSNOMBRE",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFRubrosNombre)),  0,  AV47TFRubrosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFRubrosNombre_Sel)),  AV48TFRubrosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMEDIDASNOMBRE",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFMedidasNombre)),  0,  AV51TFMedidasNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFMedidasNombre_Sel)),  AV52TFMedidasNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTEXTOSID",  "#",  !((0==AV53TFTextosId)&&(0==AV54TFTextosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV53TFTextosId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV54TFTextosId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTEXTOSTITULO",  context.GetMessage( "Terminos y Condiciones", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFTextosTitulo)),  0,  AV55TFTextosTitulo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFTextosTitulo_Sel)),  AV56TFTextosTitulo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMEDIDASESTADO_SEL",  "",  !(AV58TFMedidasEstado_Sels.Count==0),  0,  AV58TFMedidasEstado_Sels.ToJSonString(false),  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         if ( new GeneXus.Programs.wwpbaseobjects.wwp_resetcollapsedrecords(context).executeUdp(  AV69OldGridState,  AV11GridState) )
         {
            AV67GridCollapsedRecords = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV66GridCollapsedRecordsChildren = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         }
         AV11GridState.gxTpr_Collapsedrecords = AV67GridCollapsedRecords.ToJSonString(false);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV95Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV33DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RUBROSCOSTO") == 0 ) && ! (Convert.ToDecimal(0)==AV20RubrosCosto1) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Costo Base", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( AV20RubrosCosto1, 18, 2);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21RubrosNombre1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Rubro", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV21RubrosNombre1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TEXTOSTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV82TextosTipo1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Tipo", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV82TextosTipo1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RUBROSCOSTO") == 0 ) && ! (Convert.ToDecimal(0)==AV25RubrosCosto2) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Costo Base", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( AV25RubrosCosto2, 18, 2);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26RubrosNombre2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Rubro", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV26RubrosNombre2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TEXTOSTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV83TextosTipo2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Tipo", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV83TextosTipo2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV27DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV28DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "RUBROSCOSTO") == 0 ) && ! (Convert.ToDecimal(0)==AV30RubrosCosto3) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Costo Base", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( AV30RubrosCosto3, 18, 2);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31RubrosNombre3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Rubro", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV31RubrosNombre3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "TEXTOSTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TextosTipo3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Tipo", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV84TextosTipo3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
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
         AV9TrnContext.gxTpr_Callerobject = AV95Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Inventario";
         AV41Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         new inventariowwexport(context ).execute( out  AV35ExcelFilename, out  AV36ErrorMessage) ;
         if ( StringUtil.StrCmp(AV35ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV35ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV36ErrorMessage);
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
         Innewwindow1_Target = formatLink("inventariowwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void S312( )
      {
         /* 'ADDREMOVECHILDREN' Routine */
         returnInSub = false;
         AV70DiscardFirst = true;
         AV96Inventariowwds_1_filterfulltext = AV17FilterFullText;
         AV97Inventariowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV98Inventariowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV99Inventariowwds_4_rubroscosto1 = AV20RubrosCosto1;
         AV100Inventariowwds_5_rubrosnombre1 = AV21RubrosNombre1;
         AV101Inventariowwds_6_textostipo1 = AV82TextosTipo1;
         AV102Inventariowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV103Inventariowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV104Inventariowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV105Inventariowwds_10_rubroscosto2 = AV25RubrosCosto2;
         AV106Inventariowwds_11_rubrosnombre2 = AV26RubrosNombre2;
         AV107Inventariowwds_12_textostipo2 = AV83TextosTipo2;
         AV108Inventariowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV109Inventariowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV110Inventariowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV111Inventariowwds_16_rubroscosto3 = AV30RubrosCosto3;
         AV112Inventariowwds_17_rubrosnombre3 = AV31RubrosNombre3;
         AV113Inventariowwds_18_textostipo3 = AV84TextosTipo3;
         AV114Inventariowwds_19_tfrubrosid = AV45TFRubrosId;
         AV115Inventariowwds_20_tfrubrosid_to = AV46TFRubrosId_To;
         AV116Inventariowwds_21_tfrubrosnombre = AV47TFRubrosNombre;
         AV117Inventariowwds_22_tfrubrosnombre_sel = AV48TFRubrosNombre_Sel;
         AV118Inventariowwds_23_tfmedidasnombre = AV51TFMedidasNombre;
         AV119Inventariowwds_24_tfmedidasnombre_sel = AV52TFMedidasNombre_Sel;
         AV120Inventariowwds_25_tftextosid = AV53TFTextosId;
         AV121Inventariowwds_26_tftextosid_to = AV54TFTextosId_To;
         AV122Inventariowwds_27_tftextostitulo = AV55TFTextosTitulo;
         AV123Inventariowwds_28_tftextostitulo_sel = AV56TFTextosTitulo_Sel;
         AV124Inventariowwds_29_tfmedidasestado_sels = AV58TFMedidasEstado_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV124Inventariowwds_29_tfmedidasestado_sels ,
                                              AV97Inventariowwds_2_dynamicfiltersselector1 ,
                                              AV98Inventariowwds_3_dynamicfiltersoperator1 ,
                                              AV99Inventariowwds_4_rubroscosto1 ,
                                              AV100Inventariowwds_5_rubrosnombre1 ,
                                              AV101Inventariowwds_6_textostipo1 ,
                                              AV102Inventariowwds_7_dynamicfiltersenabled2 ,
                                              AV103Inventariowwds_8_dynamicfiltersselector2 ,
                                              AV104Inventariowwds_9_dynamicfiltersoperator2 ,
                                              AV105Inventariowwds_10_rubroscosto2 ,
                                              AV106Inventariowwds_11_rubrosnombre2 ,
                                              AV107Inventariowwds_12_textostipo2 ,
                                              AV108Inventariowwds_13_dynamicfiltersenabled3 ,
                                              AV109Inventariowwds_14_dynamicfiltersselector3 ,
                                              AV110Inventariowwds_15_dynamicfiltersoperator3 ,
                                              AV111Inventariowwds_16_rubroscosto3 ,
                                              AV112Inventariowwds_17_rubrosnombre3 ,
                                              AV113Inventariowwds_18_textostipo3 ,
                                              AV114Inventariowwds_19_tfrubrosid ,
                                              AV115Inventariowwds_20_tfrubrosid_to ,
                                              AV117Inventariowwds_22_tfrubrosnombre_sel ,
                                              AV116Inventariowwds_21_tfrubrosnombre ,
                                              AV119Inventariowwds_24_tfmedidasnombre_sel ,
                                              AV118Inventariowwds_23_tfmedidasnombre ,
                                              AV120Inventariowwds_25_tftextosid ,
                                              AV121Inventariowwds_26_tftextosid_to ,
                                              AV123Inventariowwds_28_tftextostitulo_sel ,
                                              AV122Inventariowwds_27_tftextostitulo ,
                                              AV124Inventariowwds_29_tfmedidasestado_sels.Count ,
                                              A215RubrosCosto ,
                                              A122RubrosNombre ,
                                              A258TextosTipo ,
                                              A121RubrosId ,
                                              A138MedidasNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV96Inventariowwds_1_filterfulltext ,
                                              AV65GroupRubrosNombre } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV100Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1), 100, "%");
         lV100Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1), 100, "%");
         lV101Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV101Inventariowwds_6_textostipo1), 20, "%");
         lV101Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV101Inventariowwds_6_textostipo1), 20, "%");
         lV106Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2), 100, "%");
         lV106Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2), 100, "%");
         lV107Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV107Inventariowwds_12_textostipo2), 20, "%");
         lV107Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV107Inventariowwds_12_textostipo2), 20, "%");
         lV112Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3), 100, "%");
         lV112Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3), 100, "%");
         lV113Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV113Inventariowwds_18_textostipo3), 20, "%");
         lV113Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV113Inventariowwds_18_textostipo3), 20, "%");
         lV116Inventariowwds_21_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV116Inventariowwds_21_tfrubrosnombre), 100, "%");
         lV118Inventariowwds_23_tfmedidasnombre = StringUtil.PadR( StringUtil.RTrim( AV118Inventariowwds_23_tfmedidasnombre), 50, "%");
         lV122Inventariowwds_27_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV122Inventariowwds_27_tftextostitulo), 80, "%");
         /* Using cursor H001U4 */
         pr_default.execute(2, new Object[] {AV65GroupRubrosNombre, AV99Inventariowwds_4_rubroscosto1, AV99Inventariowwds_4_rubroscosto1, AV99Inventariowwds_4_rubroscosto1, lV100Inventariowwds_5_rubrosnombre1, lV100Inventariowwds_5_rubrosnombre1, lV101Inventariowwds_6_textostipo1, lV101Inventariowwds_6_textostipo1, AV105Inventariowwds_10_rubroscosto2, AV105Inventariowwds_10_rubroscosto2, AV105Inventariowwds_10_rubroscosto2, lV106Inventariowwds_11_rubrosnombre2, lV106Inventariowwds_11_rubrosnombre2, lV107Inventariowwds_12_textostipo2, lV107Inventariowwds_12_textostipo2, AV111Inventariowwds_16_rubroscosto3, AV111Inventariowwds_16_rubroscosto3, AV111Inventariowwds_16_rubroscosto3, lV112Inventariowwds_17_rubrosnombre3, lV112Inventariowwds_17_rubrosnombre3, lV113Inventariowwds_18_textostipo3, lV113Inventariowwds_18_textostipo3, AV114Inventariowwds_19_tfrubrosid, AV115Inventariowwds_20_tfrubrosid_to, lV116Inventariowwds_21_tfrubrosnombre, AV117Inventariowwds_22_tfrubrosnombre_sel, lV118Inventariowwds_23_tfmedidasnombre, AV119Inventariowwds_24_tfmedidasnombre_sel, AV120Inventariowwds_25_tftextosid, AV121Inventariowwds_26_tftextosid_to, lV122Inventariowwds_27_tftextostitulo, AV123Inventariowwds_28_tftextostitulo_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A258TextosTipo = H001U4_A258TextosTipo[0];
            A259TextosTitulo = H001U4_A259TextosTitulo[0];
            A150TextosId = H001U4_A150TextosId[0];
            n150TextosId = H001U4_n150TextosId[0];
            A138MedidasNombre = H001U4_A138MedidasNombre[0];
            A122RubrosNombre = H001U4_A122RubrosNombre[0];
            A121RubrosId = H001U4_A121RubrosId[0];
            A215RubrosCosto = H001U4_A215RubrosCosto[0];
            A139MedidasEstado = H001U4_A139MedidasEstado[0];
            n139MedidasEstado = H001U4_n139MedidasEstado[0];
            A137MedidasID = H001U4_A137MedidasID[0];
            A258TextosTipo = H001U4_A258TextosTipo[0];
            A259TextosTitulo = H001U4_A259TextosTitulo[0];
            A122RubrosNombre = H001U4_A122RubrosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Inventariowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV96Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV96Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "bloqueado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "BLO") == 0 ) ) ) )
            {
               AV64RecordKey = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0)) + ";" + StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
               AV68Index = AV66GridCollapsedRecordsChildren.IndexOf(AV64RecordKey);
               if ( AV71AddChildren && ( AV68Index == 0 ) )
               {
                  if ( ! AV70DiscardFirst )
                  {
                     AV66GridCollapsedRecordsChildren.Add(AV64RecordKey, 0);
                  }
                  else
                  {
                     AV70DiscardFirst = false;
                  }
               }
               else
               {
                  if ( ( ! AV71AddChildren ) && ( AV68Index > 0 ) )
                  {
                     AV66GridCollapsedRecordsChildren.RemoveItem((int)(AV68Index));
                  }
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void wb_table4_105_1U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters3_Internalname, tblTablemergeddynamicfilters3_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator3_Internalname, context.GetMessage( "Dynamic Filters Operator3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "", true, 0, "HLP_InventarioWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_rubroscosto3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRubroscosto3_Internalname, context.GetMessage( "Rubros Costo3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRubroscosto3_Internalname, StringUtil.LTrim( StringUtil.NToC( AV30RubrosCosto3, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavRubroscosto3_Enabled!=0) ? context.localUtil.Format( AV30RubrosCosto3, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV30RubrosCosto3, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRubroscosto3_Jsonclick, 0, "Attribute", "", "", "", "", edtavRubroscosto3_Visible, edtavRubroscosto3_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_rubrosnombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRubrosnombre3_Internalname, context.GetMessage( "Rubros Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRubrosnombre3_Internalname, StringUtil.RTrim( AV31RubrosNombre3), StringUtil.RTrim( context.localUtil.Format( AV31RubrosNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRubrosnombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavRubrosnombre3_Visible, edtavRubrosnombre3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_textostipo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTextostipo3_Internalname, context.GetMessage( "Textos Tipo3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTextostipo3_Internalname, StringUtil.RTrim( AV84TextosTipo3), StringUtil.RTrim( context.localUtil.Format( AV84TextosTipo3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTextostipo3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTextostipo3_Visible, edtavTextostipo3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_InventarioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_105_1U2e( true) ;
         }
         else
         {
            wb_table4_105_1U2e( false) ;
         }
      }

      protected void wb_table3_77_1U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters2_Internalname, tblTablemergeddynamicfilters2_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator2_Internalname, context.GetMessage( "Dynamic Filters Operator2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", true, 0, "HLP_InventarioWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_rubroscosto2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRubroscosto2_Internalname, context.GetMessage( "Rubros Costo2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRubroscosto2_Internalname, StringUtil.LTrim( StringUtil.NToC( AV25RubrosCosto2, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavRubroscosto2_Enabled!=0) ? context.localUtil.Format( AV25RubrosCosto2, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV25RubrosCosto2, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRubroscosto2_Jsonclick, 0, "Attribute", "", "", "", "", edtavRubroscosto2_Visible, edtavRubroscosto2_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_rubrosnombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRubrosnombre2_Internalname, context.GetMessage( "Rubros Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRubrosnombre2_Internalname, StringUtil.RTrim( AV26RubrosNombre2), StringUtil.RTrim( context.localUtil.Format( AV26RubrosNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRubrosnombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavRubrosnombre2_Visible, edtavRubrosnombre2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_textostipo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTextostipo2_Internalname, context.GetMessage( "Textos Tipo2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTextostipo2_Internalname, StringUtil.RTrim( AV83TextosTipo2), StringUtil.RTrim( context.localUtil.Format( AV83TextosTipo2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTextostipo2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTextostipo2_Visible, edtavTextostipo2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_InventarioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_InventarioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_77_1U2e( true) ;
         }
         else
         {
            wb_table3_77_1U2e( false) ;
         }
      }

      protected void wb_table2_49_1U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters1_Internalname, tblTablemergeddynamicfilters1_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator1_Internalname, context.GetMessage( "Dynamic Filters Operator1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_InventarioWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_rubroscosto1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRubroscosto1_Internalname, context.GetMessage( "Rubros Costo1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRubroscosto1_Internalname, StringUtil.LTrim( StringUtil.NToC( AV20RubrosCosto1, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavRubroscosto1_Enabled!=0) ? context.localUtil.Format( AV20RubrosCosto1, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV20RubrosCosto1, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRubroscosto1_Jsonclick, 0, "Attribute", "", "", "", "", edtavRubroscosto1_Visible, edtavRubroscosto1_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_rubrosnombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRubrosnombre1_Internalname, context.GetMessage( "Rubros Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRubrosnombre1_Internalname, StringUtil.RTrim( AV21RubrosNombre1), StringUtil.RTrim( context.localUtil.Format( AV21RubrosNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRubrosnombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavRubrosnombre1_Visible, edtavRubrosnombre1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_textostipo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTextostipo1_Internalname, context.GetMessage( "Textos Tipo1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTextostipo1_Internalname, StringUtil.RTrim( AV82TextosTipo1), StringUtil.RTrim( context.localUtil.Format( AV82TextosTipo1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTextostipo1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTextostipo1_Visible, edtavTextostipo1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_InventarioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_InventarioWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_1U2e( true) ;
         }
         else
         {
            wb_table2_49_1U2e( false) ;
         }
      }

      protected void wb_table1_25_1U2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV42ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_30_1U2( true) ;
         }
         else
         {
            wb_table5_30_1U2( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_1U2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_1U2e( true) ;
         }
         else
         {
            wb_table1_25_1U2e( false) ;
         }
      }

      protected void wb_table5_30_1U2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_InventarioWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_1U2e( true) ;
         }
         else
         {
            wb_table5_30_1U2e( false) ;
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
         PA1U2( ) ;
         WS1U2( ) ;
         WE1U2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320125581", true, true, false);
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
         context.AddJavascriptSource("inventarioww.js", "?20269320125582", false, true, false);
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
         context.AddJavascriptSource("DVelop/DVGroupBy/DVGroupByRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1292( )
      {
         edtavExpand_Internalname = "vEXPAND_"+sGXsfl_129_idx;
         edtavGrid_groupcaption_Internalname = "vGRID_GROUPCAPTION_"+sGXsfl_129_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_129_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_129_idx;
         edtRubrosImagen_Internalname = "RUBROSIMAGEN_"+sGXsfl_129_idx;
         edtRubrosNombre_Internalname = "RUBROSNOMBRE_"+sGXsfl_129_idx;
         edtMedidasID_Internalname = "MEDIDASID_"+sGXsfl_129_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_129_idx;
         edtTextosId_Internalname = "TEXTOSID_"+sGXsfl_129_idx;
         edtTextosTitulo_Internalname = "TEXTOSTITULO_"+sGXsfl_129_idx;
         cmbMedidasEstado_Internalname = "MEDIDASESTADO_"+sGXsfl_129_idx;
      }

      protected void SubsflControlProps_fel_1292( )
      {
         edtavExpand_Internalname = "vEXPAND_"+sGXsfl_129_fel_idx;
         edtavGrid_groupcaption_Internalname = "vGRID_GROUPCAPTION_"+sGXsfl_129_fel_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_129_fel_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_129_fel_idx;
         edtRubrosImagen_Internalname = "RUBROSIMAGEN_"+sGXsfl_129_fel_idx;
         edtRubrosNombre_Internalname = "RUBROSNOMBRE_"+sGXsfl_129_fel_idx;
         edtMedidasID_Internalname = "MEDIDASID_"+sGXsfl_129_fel_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_129_fel_idx;
         edtTextosId_Internalname = "TEXTOSID_"+sGXsfl_129_fel_idx;
         edtTextosTitulo_Internalname = "TEXTOSTITULO_"+sGXsfl_129_fel_idx;
         cmbMedidasEstado_Internalname = "MEDIDASESTADO_"+sGXsfl_129_fel_idx;
      }

      protected void sendrow_1292( )
      {
         sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
         SubsflControlProps_1292( ) ;
         WB1U0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_129_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_129_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_129_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExpand_Internalname,StringUtil.RTrim( AV72Expand),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ","'"+""+"'"+",false,"+"'"+"EVEXPAND.CLICK."+sGXsfl_129_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExpand_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavExpand_Columnclass,(string)"",(short)0,(int)edtavExpand_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGrid_groupcaption_Internalname,(string)AV34Grid_GroupCaption,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGrid_groupcaption_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavGrid_groupcaption_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'" + sGXsfl_129_idx + "',129)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_129_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV73GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV73GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_129_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_129_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtRubrosId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtRubrosId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtRubrosImagen_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A168RubrosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001RubrosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtRubrosImagen_Visible,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A168RubrosImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtRubrosNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosNombre_Internalname,StringUtil.RTrim( A122RubrosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtRubrosNombre_Link,(string)"",(string)"",(string)"",(string)edtRubrosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtRubrosNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMedidasNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasNombre_Internalname,StringUtil.RTrim( A138MedidasNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidasNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMedidasNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtTextosId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTextosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A150TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A150TextosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTextosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtTextosId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtTextosTitulo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTextosTitulo_Internalname,StringUtil.RTrim( A259TextosTitulo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTextosTitulo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtTextosTitulo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbMedidasEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbMedidasEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MEDIDASESTADO_" + sGXsfl_129_idx;
               cmbMedidasEstado.Name = GXCCtl;
               cmbMedidasEstado.WebTags = "";
               cmbMedidasEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbMedidasEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbMedidasEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbMedidasEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbMedidasEstado.ItemCount > 0 )
               {
                  A139MedidasEstado = cmbMedidasEstado.getValidValue(A139MedidasEstado);
                  n139MedidasEstado = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMedidasEstado,(string)cmbMedidasEstado_Internalname,StringUtil.RTrim( A139MedidasEstado),(short)1,(string)cmbMedidasEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbMedidasEstado.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMedidasEstado.CurrentValue = StringUtil.RTrim( A139MedidasEstado);
            AssignProp("", false, cmbMedidasEstado_Internalname, "Values", (string)(cmbMedidasEstado.ToJavascriptSource()), !bGXsfl_129_Refreshing);
            send_integrity_lvl_hashes1U2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_129_idx = ((subGrid_Islastpage==1)&&(nGXsfl_129_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_129_idx+1);
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
            SubsflControlProps_1292( ) ;
         }
         /* End function sendrow_1292 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("RUBROSCOSTO", context.GetMessage( "Costo Base", ""), 0);
         cmbavDynamicfiltersselector1.addItem("RUBROSNOMBRE", context.GetMessage( "Rubro", ""), 0);
         cmbavDynamicfiltersselector1.addItem("TEXTOSTIPO", context.GetMessage( "Tipo", ""), 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("RUBROSCOSTO", context.GetMessage( "Costo Base", ""), 0);
         cmbavDynamicfiltersselector2.addItem("RUBROSNOMBRE", context.GetMessage( "Rubro", ""), 0);
         cmbavDynamicfiltersselector2.addItem("TEXTOSTIPO", context.GetMessage( "Tipo", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("RUBROSCOSTO", context.GetMessage( "Costo Base", ""), 0);
         cmbavDynamicfiltersselector3.addItem("RUBROSNOMBRE", context.GetMessage( "Rubro", ""), 0);
         cmbavDynamicfiltersselector3.addItem("TEXTOSTIPO", context.GetMessage( "Tipo", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_129_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV73GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV73GridActions), 4, 0));
         }
         GXCCtl = "MEDIDASESTADO_" + sGXsfl_129_idx;
         cmbMedidasEstado.Name = GXCCtl;
         cmbMedidasEstado.WebTags = "";
         cmbMedidasEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMedidasEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbMedidasEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbMedidasEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbMedidasEstado.ItemCount > 0 )
         {
            A139MedidasEstado = cmbMedidasEstado.getValidValue(A139MedidasEstado);
            n139MedidasEstado = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl129( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"129\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtRubrosId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rubro", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtRubrosImagen_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtRubrosNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMedidasNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtTextosId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "#") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtTextosTitulo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Terminos y Condiciones", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbMedidasEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV72Expand)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavExpand_Columnclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExpand_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV34Grid_GroupCaption));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGrid_groupcaption_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV73GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A168RubrosImagen));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A122RubrosNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtRubrosNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A138MedidasNombre)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A150TextosId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTextosId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A259TextosTitulo)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTextosTitulo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A139MedidasEstado)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMedidasEstado.Visible), 5, 0, ".", "")));
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
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavRubroscosto1_Internalname = "vRUBROSCOSTO1";
         cellFilter_rubroscosto1_cell_Internalname = "FILTER_RUBROSCOSTO1_CELL";
         edtavRubrosnombre1_Internalname = "vRUBROSNOMBRE1";
         cellFilter_rubrosnombre1_cell_Internalname = "FILTER_RUBROSNOMBRE1_CELL";
         edtavTextostipo1_Internalname = "vTEXTOSTIPO1";
         cellFilter_textostipo1_cell_Internalname = "FILTER_TEXTOSTIPO1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavRubroscosto2_Internalname = "vRUBROSCOSTO2";
         cellFilter_rubroscosto2_cell_Internalname = "FILTER_RUBROSCOSTO2_CELL";
         edtavRubrosnombre2_Internalname = "vRUBROSNOMBRE2";
         cellFilter_rubrosnombre2_cell_Internalname = "FILTER_RUBROSNOMBRE2_CELL";
         edtavTextostipo2_Internalname = "vTEXTOSTIPO2";
         cellFilter_textostipo2_cell_Internalname = "FILTER_TEXTOSTIPO2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavRubroscosto3_Internalname = "vRUBROSCOSTO3";
         cellFilter_rubroscosto3_cell_Internalname = "FILTER_RUBROSCOSTO3_CELL";
         edtavRubrosnombre3_Internalname = "vRUBROSNOMBRE3";
         cellFilter_rubrosnombre3_cell_Internalname = "FILTER_RUBROSNOMBRE3_CELL";
         edtavTextostipo3_Internalname = "vTEXTOSTIPO3";
         cellFilter_textostipo3_cell_Internalname = "FILTER_TEXTOSTIPO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         edtavExpand_Internalname = "vEXPAND";
         edtavGrid_groupcaption_Internalname = "vGRID_GROUPCAPTION";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtRubrosId_Internalname = "RUBROSID";
         edtRubrosImagen_Internalname = "RUBROSIMAGEN";
         edtRubrosNombre_Internalname = "RUBROSNOMBRE";
         edtMedidasID_Internalname = "MEDIDASID";
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE";
         edtTextosId_Internalname = "TEXTOSID";
         edtTextosTitulo_Internalname = "TEXTOSTITULO";
         cmbMedidasEstado_Internalname = "MEDIDASESTADO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_group_Internalname = "GRID_GROUP";
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
         cmbMedidasEstado_Jsonclick = "";
         edtTextosTitulo_Jsonclick = "";
         edtTextosId_Jsonclick = "";
         edtMedidasNombre_Jsonclick = "";
         edtMedidasID_Jsonclick = "";
         edtRubrosNombre_Jsonclick = "";
         edtRubrosNombre_Link = "";
         edtRubrosId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         edtavGrid_groupcaption_Jsonclick = "";
         edtavGrid_groupcaption_Enabled = 1;
         edtavExpand_Jsonclick = "";
         edtavExpand_Columnclass = "WWIconActionColumn";
         edtavExpand_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavTextostipo1_Jsonclick = "";
         edtavTextostipo1_Enabled = 1;
         edtavRubrosnombre1_Jsonclick = "";
         edtavRubrosnombre1_Enabled = 1;
         edtavRubroscosto1_Jsonclick = "";
         edtavRubroscosto1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavTextostipo2_Jsonclick = "";
         edtavTextostipo2_Enabled = 1;
         edtavRubrosnombre2_Jsonclick = "";
         edtavRubrosnombre2_Enabled = 1;
         edtavRubroscosto2_Jsonclick = "";
         edtavRubroscosto2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavTextostipo3_Jsonclick = "";
         edtavTextostipo3_Enabled = 1;
         edtavRubrosnombre3_Jsonclick = "";
         edtavRubrosnombre3_Enabled = 1;
         edtavRubroscosto3_Jsonclick = "";
         edtavRubroscosto3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavTextostipo3_Visible = 1;
         edtavRubrosnombre3_Visible = 1;
         edtavRubroscosto3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavTextostipo2_Visible = 1;
         edtavRubrosnombre2_Visible = 1;
         edtavRubroscosto2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavTextostipo1_Visible = 1;
         edtavRubrosnombre1_Visible = 1;
         edtavRubroscosto1_Visible = 1;
         cmbMedidasEstado.Visible = -1;
         edtTextosTitulo_Visible = -1;
         edtTextosId_Visible = -1;
         edtMedidasNombre_Visible = -1;
         edtRubrosNombre_Visible = -1;
         edtRubrosImagen_Visible = -1;
         edtRubrosId_Visible = -1;
         cmbMedidasEstado.Enabled = 0;
         edtTextosTitulo_Enabled = 0;
         edtTextosId_Enabled = 0;
         edtMedidasNombre_Enabled = 0;
         edtMedidasID_Enabled = 0;
         edtRubrosNombre_Enabled = 0;
         edtRubrosImagen_Enabled = 0;
         edtRubrosId_Enabled = 0;
         subGrid_Sortable = 0;
         lblJsdynamicfilters_Caption = context.GetMessage( "JSDynamicFilters", "");
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = ";;L;;;;;;;;";
         Grid_empowerer_Hasrowgroups = Convert.ToBoolean( -1);
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Grid_group_Columnindex = 1;
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
         Ddo_grid_Format = "4.0||||18.0||";
         Ddo_grid_Datalistproc = "InventarioWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||HAB:Habilitado,DES:Deshabilitado,PEN:Pendiente,BLO:Bloqueado";
         Ddo_grid_Allowmultipleselection = "||||||T";
         Ddo_grid_Datalisttype = "||Dynamic|Dynamic||Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "||T|T||T|T";
         Ddo_grid_Filterisrange = "T||||T||";
         Ddo_grid_Filtertype = "Numeric||Character|Character|Numeric|Character|";
         Ddo_grid_Includefilter = "T||T|T|T|T|";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T||T|T|T|T|T";
         Ddo_grid_Columnssortvalues = "2||3|4|5|6|7";
         Ddo_grid_Columnids = "3:RubrosId|4:RubrosImagen|5:RubrosNombre|7:MedidasNombre|8:TextosId|9:TextosTitulo|10:MedidasEstado";
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
         Form.Caption = context.GetMessage( " Inventario", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRubrosId_Visible',ctrl:'RUBROSID',prop:'Visible'},{av:'edtRubrosImagen_Visible',ctrl:'RUBROSIMAGEN',prop:'Visible'},{av:'edtRubrosNombre_Visible',ctrl:'RUBROSNOMBRE',prop:'Visible'},{av:'edtMedidasNombre_Visible',ctrl:'MEDIDASNOMBRE',prop:'Visible'},{av:'edtTextosId_Visible',ctrl:'TEXTOSID',prop:'Visible'},{av:'edtTextosTitulo_Visible',ctrl:'TEXTOSTITULO',prop:'Visible'},{av:'cmbMedidasEstado'},{av:'AV61GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV63GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV42ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E121U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRubrosId_Visible',ctrl:'RUBROSID',prop:'Visible'},{av:'edtRubrosImagen_Visible',ctrl:'RUBROSIMAGEN',prop:'Visible'},{av:'edtRubrosNombre_Visible',ctrl:'RUBROSNOMBRE',prop:'Visible'},{av:'edtMedidasNombre_Visible',ctrl:'MEDIDASNOMBRE',prop:'Visible'},{av:'edtTextosId_Visible',ctrl:'TEXTOSID',prop:'Visible'},{av:'edtTextosTitulo_Visible',ctrl:'TEXTOSTITULO',prop:'Visible'},{av:'cmbMedidasEstado'},{av:'AV61GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV63GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV42ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E131U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E161U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV57TFMedidasEstado_SelsJson',fld:'vTFMEDIDASESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E291U2',iparms:[{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV72Expand',fld:'vEXPAND',pic:'',type:'char'},{av:'edtavExpand_Columnclass',ctrl:'vEXPAND',prop:'Columnclass'},{av:'cmbavGridactions'},{av:'AV73GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtRubrosNombre_Link',ctrl:'RUBROSNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E171U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtRubrosId_Visible',ctrl:'RUBROSID',prop:'Visible'},{av:'edtRubrosImagen_Visible',ctrl:'RUBROSIMAGEN',prop:'Visible'},{av:'edtRubrosNombre_Visible',ctrl:'RUBROSNOMBRE',prop:'Visible'},{av:'edtMedidasNombre_Visible',ctrl:'MEDIDASNOMBRE',prop:'Visible'},{av:'edtTextosId_Visible',ctrl:'TEXTOSID',prop:'Visible'},{av:'edtTextosTitulo_Visible',ctrl:'TEXTOSTITULO',prop:'Visible'},{av:'cmbMedidasEstado'},{av:'AV61GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV63GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV42ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E221U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRubrosId_Visible',ctrl:'RUBROSID',prop:'Visible'},{av:'edtRubrosImagen_Visible',ctrl:'RUBROSIMAGEN',prop:'Visible'},{av:'edtRubrosNombre_Visible',ctrl:'RUBROSNOMBRE',prop:'Visible'},{av:'edtMedidasNombre_Visible',ctrl:'MEDIDASNOMBRE',prop:'Visible'},{av:'edtTextosId_Visible',ctrl:'TEXTOSID',prop:'Visible'},{av:'edtTextosTitulo_Visible',ctrl:'TEXTOSTITULO',prop:'Visible'},{av:'cmbMedidasEstado'},{av:'AV61GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV63GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV42ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E181U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'edtavRubroscosto2_Visible',ctrl:'vRUBROSCOSTO2',prop:'Visible'},{av:'edtavRubrosnombre2_Visible',ctrl:'vRUBROSNOMBRE2',prop:'Visible'},{av:'edtavTextostipo2_Visible',ctrl:'vTEXTOSTIPO2',prop:'Visible'},{av:'edtavRubroscosto3_Visible',ctrl:'vRUBROSCOSTO3',prop:'Visible'},{av:'edtavRubrosnombre3_Visible',ctrl:'vRUBROSNOMBRE3',prop:'Visible'},{av:'edtavTextostipo3_Visible',ctrl:'vTEXTOSTIPO3',prop:'Visible'},{av:'edtavRubroscosto1_Visible',ctrl:'vRUBROSCOSTO1',prop:'Visible'},{av:'edtavRubrosnombre1_Visible',ctrl:'vRUBROSNOMBRE1',prop:'Visible'},{av:'edtavTextostipo1_Visible',ctrl:'vTEXTOSTIPO1',prop:'Visible'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRubrosId_Visible',ctrl:'RUBROSID',prop:'Visible'},{av:'edtRubrosImagen_Visible',ctrl:'RUBROSIMAGEN',prop:'Visible'},{av:'edtRubrosNombre_Visible',ctrl:'RUBROSNOMBRE',prop:'Visible'},{av:'edtMedidasNombre_Visible',ctrl:'MEDIDASNOMBRE',prop:'Visible'},{av:'edtTextosId_Visible',ctrl:'TEXTOSID',prop:'Visible'},{av:'edtTextosTitulo_Visible',ctrl:'TEXTOSTITULO',prop:'Visible'},{av:'cmbMedidasEstado'},{av:'AV61GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV63GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV42ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E231U2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'edtavRubroscosto1_Visible',ctrl:'vRUBROSCOSTO1',prop:'Visible'},{av:'edtavRubrosnombre1_Visible',ctrl:'vRUBROSNOMBRE1',prop:'Visible'},{av:'edtavTextostipo1_Visible',ctrl:'vTEXTOSTIPO1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E241U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRubrosId_Visible',ctrl:'RUBROSID',prop:'Visible'},{av:'edtRubrosImagen_Visible',ctrl:'RUBROSIMAGEN',prop:'Visible'},{av:'edtRubrosNombre_Visible',ctrl:'RUBROSNOMBRE',prop:'Visible'},{av:'edtMedidasNombre_Visible',ctrl:'MEDIDASNOMBRE',prop:'Visible'},{av:'edtTextosId_Visible',ctrl:'TEXTOSID',prop:'Visible'},{av:'edtTextosTitulo_Visible',ctrl:'TEXTOSTITULO',prop:'Visible'},{av:'cmbMedidasEstado'},{av:'AV61GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV63GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV42ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E191U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'edtavRubroscosto2_Visible',ctrl:'vRUBROSCOSTO2',prop:'Visible'},{av:'edtavRubrosnombre2_Visible',ctrl:'vRUBROSNOMBRE2',prop:'Visible'},{av:'edtavTextostipo2_Visible',ctrl:'vTEXTOSTIPO2',prop:'Visible'},{av:'edtavRubroscosto3_Visible',ctrl:'vRUBROSCOSTO3',prop:'Visible'},{av:'edtavRubrosnombre3_Visible',ctrl:'vRUBROSNOMBRE3',prop:'Visible'},{av:'edtavTextostipo3_Visible',ctrl:'vTEXTOSTIPO3',prop:'Visible'},{av:'edtavRubroscosto1_Visible',ctrl:'vRUBROSCOSTO1',prop:'Visible'},{av:'edtavRubrosnombre1_Visible',ctrl:'vRUBROSNOMBRE1',prop:'Visible'},{av:'edtavTextostipo1_Visible',ctrl:'vTEXTOSTIPO1',prop:'Visible'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRubrosId_Visible',ctrl:'RUBROSID',prop:'Visible'},{av:'edtRubrosImagen_Visible',ctrl:'RUBROSIMAGEN',prop:'Visible'},{av:'edtRubrosNombre_Visible',ctrl:'RUBROSNOMBRE',prop:'Visible'},{av:'edtMedidasNombre_Visible',ctrl:'MEDIDASNOMBRE',prop:'Visible'},{av:'edtTextosId_Visible',ctrl:'TEXTOSID',prop:'Visible'},{av:'edtTextosTitulo_Visible',ctrl:'TEXTOSTITULO',prop:'Visible'},{av:'cmbMedidasEstado'},{av:'AV61GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV63GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV42ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E251U2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'edtavRubroscosto2_Visible',ctrl:'vRUBROSCOSTO2',prop:'Visible'},{av:'edtavRubrosnombre2_Visible',ctrl:'vRUBROSNOMBRE2',prop:'Visible'},{av:'edtavTextostipo2_Visible',ctrl:'vTEXTOSTIPO2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E201U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'edtavRubroscosto2_Visible',ctrl:'vRUBROSCOSTO2',prop:'Visible'},{av:'edtavRubrosnombre2_Visible',ctrl:'vRUBROSNOMBRE2',prop:'Visible'},{av:'edtavTextostipo2_Visible',ctrl:'vTEXTOSTIPO2',prop:'Visible'},{av:'edtavRubroscosto3_Visible',ctrl:'vRUBROSCOSTO3',prop:'Visible'},{av:'edtavRubrosnombre3_Visible',ctrl:'vRUBROSNOMBRE3',prop:'Visible'},{av:'edtavTextostipo3_Visible',ctrl:'vTEXTOSTIPO3',prop:'Visible'},{av:'edtavRubroscosto1_Visible',ctrl:'vRUBROSCOSTO1',prop:'Visible'},{av:'edtavRubrosnombre1_Visible',ctrl:'vRUBROSNOMBRE1',prop:'Visible'},{av:'edtavTextostipo1_Visible',ctrl:'vTEXTOSTIPO1',prop:'Visible'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRubrosId_Visible',ctrl:'RUBROSID',prop:'Visible'},{av:'edtRubrosImagen_Visible',ctrl:'RUBROSIMAGEN',prop:'Visible'},{av:'edtRubrosNombre_Visible',ctrl:'RUBROSNOMBRE',prop:'Visible'},{av:'edtMedidasNombre_Visible',ctrl:'MEDIDASNOMBRE',prop:'Visible'},{av:'edtTextosId_Visible',ctrl:'TEXTOSID',prop:'Visible'},{av:'edtTextosTitulo_Visible',ctrl:'TEXTOSTITULO',prop:'Visible'},{av:'cmbMedidasEstado'},{av:'AV61GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV63GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV42ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E261U2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtavRubroscosto3_Visible',ctrl:'vRUBROSCOSTO3',prop:'Visible'},{av:'edtavRubrosnombre3_Visible',ctrl:'vRUBROSNOMBRE3',prop:'Visible'},{av:'edtavTextostipo3_Visible',ctrl:'vTEXTOSTIPO3',prop:'Visible'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E111U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV57TFMedidasEstado_SelsJson',fld:'vTFMEDIDASESTADO_SELSJSON',pic:'',type:'vchar'},{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'AV65GroupRubrosNombre',fld:'vGROUPRUBROSNOMBRE',pic:'',type:'char'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV71AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV71AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'},{av:'AV65GroupRubrosNombre',fld:'vGROUPRUBROSNOMBRE',pic:'',type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV57TFMedidasEstado_SelsJson',fld:'vTFMEDIDASESTADO_SELSJSON',pic:'',type:'vchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'edtavRubroscosto1_Visible',ctrl:'vRUBROSCOSTO1',prop:'Visible'},{av:'edtavRubrosnombre1_Visible',ctrl:'vRUBROSNOMBRE1',prop:'Visible'},{av:'edtavTextostipo1_Visible',ctrl:'vTEXTOSTIPO1',prop:'Visible'},{av:'edtavRubroscosto2_Visible',ctrl:'vRUBROSCOSTO2',prop:'Visible'},{av:'edtavRubrosnombre2_Visible',ctrl:'vRUBROSNOMBRE2',prop:'Visible'},{av:'edtavTextostipo2_Visible',ctrl:'vTEXTOSTIPO2',prop:'Visible'},{av:'edtavRubroscosto3_Visible',ctrl:'vRUBROSCOSTO3',prop:'Visible'},{av:'edtavRubrosnombre3_Visible',ctrl:'vRUBROSNOMBRE3',prop:'Visible'},{av:'edtavTextostipo3_Visible',ctrl:'vTEXTOSTIPO3',prop:'Visible'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRubrosId_Visible',ctrl:'RUBROSID',prop:'Visible'},{av:'edtRubrosImagen_Visible',ctrl:'RUBROSIMAGEN',prop:'Visible'},{av:'edtRubrosNombre_Visible',ctrl:'RUBROSNOMBRE',prop:'Visible'},{av:'edtMedidasNombre_Visible',ctrl:'MEDIDASNOMBRE',prop:'Visible'},{av:'edtTextosId_Visible',ctrl:'TEXTOSID',prop:'Visible'},{av:'edtTextosTitulo_Visible',ctrl:'TEXTOSTITULO',prop:'Visible'},{av:'cmbMedidasEstado'},{av:'AV61GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV63GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV42ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E301U2',iparms:[{av:'cmbavGridactions'},{av:'AV73GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV73GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E211U2',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E141U2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV57TFMedidasEstado_SelsJson',fld:'vTFMEDIDASESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'AV65GroupRubrosNombre',fld:'vGROUPRUBROSNOMBRE',pic:'',type:'char'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV71AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV71AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'},{av:'AV65GroupRubrosNombre',fld:'vGROUPRUBROSNOMBRE',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV57TFMedidasEstado_SelsJson',fld:'vTFMEDIDASESTADO_SELSJSON',pic:'',type:'vchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavRubroscosto1_Visible',ctrl:'vRUBROSCOSTO1',prop:'Visible'},{av:'edtavRubrosnombre1_Visible',ctrl:'vRUBROSNOMBRE1',prop:'Visible'},{av:'edtavTextostipo1_Visible',ctrl:'vTEXTOSTIPO1',prop:'Visible'},{av:'edtavRubroscosto2_Visible',ctrl:'vRUBROSCOSTO2',prop:'Visible'},{av:'edtavRubrosnombre2_Visible',ctrl:'vRUBROSNOMBRE2',prop:'Visible'},{av:'edtavTextostipo2_Visible',ctrl:'vTEXTOSTIPO2',prop:'Visible'},{av:'edtavRubroscosto3_Visible',ctrl:'vRUBROSCOSTO3',prop:'Visible'},{av:'edtavRubrosnombre3_Visible',ctrl:'vRUBROSNOMBRE3',prop:'Visible'},{av:'edtavTextostipo3_Visible',ctrl:'vTEXTOSTIPO3',prop:'Visible'},{av:'edtRubrosId_Visible',ctrl:'RUBROSID',prop:'Visible'},{av:'edtRubrosImagen_Visible',ctrl:'RUBROSIMAGEN',prop:'Visible'},{av:'edtRubrosNombre_Visible',ctrl:'RUBROSNOMBRE',prop:'Visible'},{av:'edtMedidasNombre_Visible',ctrl:'MEDIDASNOMBRE',prop:'Visible'},{av:'edtTextosId_Visible',ctrl:'TEXTOSID',prop:'Visible'},{av:'edtTextosTitulo_Visible',ctrl:'TEXTOSTITULO',prop:'Visible'},{av:'cmbMedidasEstado'},{av:'AV61GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV63GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV42ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E151U2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VEXPAND.CLICK","{handler:'E311U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RubrosCosto1',fld:'vRUBROSCOSTO1',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV21RubrosNombre1',fld:'vRUBROSNOMBRE1',pic:'',type:'char'},{av:'AV82TextosTipo1',fld:'vTEXTOSTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25RubrosCosto2',fld:'vRUBROSCOSTO2',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26RubrosNombre2',fld:'vRUBROSNOMBRE2',pic:'',type:'char'},{av:'AV83TextosTipo2',fld:'vTEXTOSTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30RubrosCosto3',fld:'vRUBROSCOSTO3',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31RubrosNombre3',fld:'vRUBROSNOMBRE3',pic:'',type:'char'},{av:'AV84TextosTipo3',fld:'vTEXTOSTIPO3',pic:'',type:'char'},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV95Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV45TFRubrosId',fld:'vTFRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV46TFRubrosId_To',fld:'vTFRUBROSID_TO',pic:'ZZZ9',type:'int'},{av:'AV47TFRubrosNombre',fld:'vTFRUBROSNOMBRE',pic:'',type:'char'},{av:'AV48TFRubrosNombre_Sel',fld:'vTFRUBROSNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFMedidasNombre',fld:'vTFMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV52TFMedidasNombre_Sel',fld:'vTFMEDIDASNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFTextosId',fld:'vTFTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFTextosId_To',fld:'vTFTEXTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55TFTextosTitulo',fld:'vTFTEXTOSTITULO',pic:'',type:'char'},{av:'AV56TFTextosTitulo_Sel',fld:'vTFTEXTOSTITULO_SEL',pic:'',type:'char'},{av:'AV58TFMedidasEstado_Sels',fld:'vTFMEDIDASESTADO_SELS',pic:''},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV79IsAuthorized_RubrosNombre',fld:'vISAUTHORIZED_RUBROSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'AV65GroupRubrosNombre',fld:'vGROUPRUBROSNOMBRE',pic:'',type:'char'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV71AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'}]");
         setEventMetadata("VEXPAND.CLICK",",oparms:[{av:'AV65GroupRubrosNombre',fld:'vGROUPRUBROSNOMBRE',pic:'',type:'char'},{av:'AV67GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV71AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'},{av:'AV66GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV44ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtRubrosId_Visible',ctrl:'RUBROSID',prop:'Visible'},{av:'edtRubrosImagen_Visible',ctrl:'RUBROSIMAGEN',prop:'Visible'},{av:'edtRubrosNombre_Visible',ctrl:'RUBROSNOMBRE',prop:'Visible'},{av:'edtMedidasNombre_Visible',ctrl:'MEDIDASNOMBRE',prop:'Visible'},{av:'edtTextosId_Visible',ctrl:'TEXTOSID',prop:'Visible'},{av:'edtTextosTitulo_Visible',ctrl:'TEXTOSTITULO',prop:'Visible'},{av:'cmbMedidasEstado'},{av:'AV61GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV63GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV34Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV74IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV75IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV42ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[]");
         setEventMetadata("VALID_RUBROSID",",oparms:[]}");
         setEventMetadata("VALID_RUBROSNOMBRE","{handler:'Valid_Rubrosnombre',iparms:[]");
         setEventMetadata("VALID_RUBROSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASNOMBRE","{handler:'Valid_Medidasnombre',iparms:[]");
         setEventMetadata("VALID_MEDIDASNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_TEXTOSID","{handler:'Valid_Textosid',iparms:[]");
         setEventMetadata("VALID_TEXTOSID",",oparms:[]}");
         setEventMetadata("VALID_TEXTOSTITULO","{handler:'Valid_Textostitulo',iparms:[]");
         setEventMetadata("VALID_TEXTOSTITULO",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASESTADO","{handler:'Valid_Medidasestado',iparms:[]");
         setEventMetadata("VALID_MEDIDASESTADO",",oparms:[]}");
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
         AV21RubrosNombre1 = "";
         AV82TextosTipo1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV26RubrosNombre2 = "";
         AV83TextosTipo2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV31RubrosNombre3 = "";
         AV84TextosTipo3 = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV95Pgmname = "";
         AV17FilterFullText = "";
         AV47TFRubrosNombre = "";
         AV48TFRubrosNombre_Sel = "";
         AV51TFMedidasNombre = "";
         AV52TFMedidasNombre_Sel = "";
         AV55TFTextosTitulo = "";
         AV56TFTextosTitulo_Sel = "";
         AV58TFMedidasEstado_Sels = new GxSimpleCollection<string>();
         AV67GridCollapsedRecords = new GxSimpleCollection<string>();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV66GridCollapsedRecordsChildren = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV42ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV63GridAppliedFilters = "";
         AV76AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV59DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV57TFMedidasEstado_SelsJson = "";
         AV65GroupRubrosNombre = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_group_Gridinternalname = "";
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
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_group = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV72Expand = "";
         AV34Grid_GroupCaption = "";
         A168RubrosImagen = "";
         A40001RubrosImagen_GXI = "";
         A122RubrosNombre = "";
         A138MedidasNombre = "";
         A259TextosTitulo = "";
         A139MedidasEstado = "";
         AV96Inventariowwds_1_filterfulltext = "";
         AV97Inventariowwds_2_dynamicfiltersselector1 = "";
         AV100Inventariowwds_5_rubrosnombre1 = "";
         AV101Inventariowwds_6_textostipo1 = "";
         AV103Inventariowwds_8_dynamicfiltersselector2 = "";
         AV106Inventariowwds_11_rubrosnombre2 = "";
         AV107Inventariowwds_12_textostipo2 = "";
         AV109Inventariowwds_14_dynamicfiltersselector3 = "";
         AV112Inventariowwds_17_rubrosnombre3 = "";
         AV113Inventariowwds_18_textostipo3 = "";
         AV116Inventariowwds_21_tfrubrosnombre = "";
         AV117Inventariowwds_22_tfrubrosnombre_sel = "";
         AV118Inventariowwds_23_tfmedidasnombre = "";
         AV119Inventariowwds_24_tfmedidasnombre_sel = "";
         AV122Inventariowwds_27_tftextostitulo = "";
         AV123Inventariowwds_28_tftextostitulo_sel = "";
         AV124Inventariowwds_29_tfmedidasestado_sels = new GxSimpleCollection<string>();
         lV100Inventariowwds_5_rubrosnombre1 = "";
         lV101Inventariowwds_6_textostipo1 = "";
         lV106Inventariowwds_11_rubrosnombre2 = "";
         lV107Inventariowwds_12_textostipo2 = "";
         lV112Inventariowwds_17_rubrosnombre3 = "";
         lV113Inventariowwds_18_textostipo3 = "";
         lV116Inventariowwds_21_tfrubrosnombre = "";
         lV118Inventariowwds_23_tfmedidasnombre = "";
         lV122Inventariowwds_27_tftextostitulo = "";
         A258TextosTipo = "";
         H001U2_A258TextosTipo = new string[] {""} ;
         H001U2_A215RubrosCosto = new decimal[1] ;
         H001U2_A139MedidasEstado = new string[] {""} ;
         H001U2_n139MedidasEstado = new bool[] {false} ;
         H001U2_A259TextosTitulo = new string[] {""} ;
         H001U2_A150TextosId = new long[1] ;
         H001U2_n150TextosId = new bool[] {false} ;
         H001U2_A138MedidasNombre = new string[] {""} ;
         H001U2_A137MedidasID = new long[1] ;
         H001U2_A122RubrosNombre = new string[] {""} ;
         H001U2_A40001RubrosImagen_GXI = new string[] {""} ;
         H001U2_A121RubrosId = new short[1] ;
         H001U2_A168RubrosImagen = new string[] {""} ;
         H001U3_A258TextosTipo = new string[] {""} ;
         H001U3_A215RubrosCosto = new decimal[1] ;
         H001U3_A139MedidasEstado = new string[] {""} ;
         H001U3_n139MedidasEstado = new bool[] {false} ;
         H001U3_A259TextosTitulo = new string[] {""} ;
         H001U3_A150TextosId = new long[1] ;
         H001U3_n150TextosId = new bool[] {false} ;
         H001U3_A138MedidasNombre = new string[] {""} ;
         H001U3_A137MedidasID = new long[1] ;
         H001U3_A122RubrosNombre = new string[] {""} ;
         H001U3_A40001RubrosImagen_GXI = new string[] {""} ;
         H001U3_A121RubrosId = new short[1] ;
         H001U3_A168RubrosImagen = new string[] {""} ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV77AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV41Session = context.GetSession();
         AV37ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV43ManageFiltersXml = "";
         AV38UserCustomValue = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV69OldGridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV35ExcelFilename = "";
         AV36ErrorMessage = "";
         H001U4_A258TextosTipo = new string[] {""} ;
         H001U4_A259TextosTitulo = new string[] {""} ;
         H001U4_A150TextosId = new long[1] ;
         H001U4_n150TextosId = new bool[] {false} ;
         H001U4_A138MedidasNombre = new string[] {""} ;
         H001U4_A122RubrosNombre = new string[] {""} ;
         H001U4_A121RubrosId = new short[1] ;
         H001U4_A215RubrosCosto = new decimal[1] ;
         H001U4_A139MedidasEstado = new string[] {""} ;
         H001U4_n139MedidasEstado = new bool[] {false} ;
         H001U4_A137MedidasID = new long[1] ;
         AV64RecordKey = "";
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
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.inventarioww__default(),
            new Object[][] {
                new Object[] {
               H001U2_A258TextosTipo, H001U2_A215RubrosCosto, H001U2_A139MedidasEstado, H001U2_n139MedidasEstado, H001U2_A259TextosTitulo, H001U2_A150TextosId, H001U2_n150TextosId, H001U2_A138MedidasNombre, H001U2_A137MedidasID, H001U2_A122RubrosNombre,
               H001U2_A40001RubrosImagen_GXI, H001U2_A121RubrosId, H001U2_A168RubrosImagen
               }
               , new Object[] {
               H001U3_A258TextosTipo, H001U3_A215RubrosCosto, H001U3_A139MedidasEstado, H001U3_n139MedidasEstado, H001U3_A259TextosTitulo, H001U3_A150TextosId, H001U3_n150TextosId, H001U3_A138MedidasNombre, H001U3_A137MedidasID, H001U3_A122RubrosNombre,
               H001U3_A40001RubrosImagen_GXI, H001U3_A121RubrosId, H001U3_A168RubrosImagen
               }
               , new Object[] {
               H001U4_A258TextosTipo, H001U4_A259TextosTitulo, H001U4_A150TextosId, H001U4_n150TextosId, H001U4_A138MedidasNombre, H001U4_A122RubrosNombre, H001U4_A121RubrosId, H001U4_A215RubrosCosto, H001U4_A139MedidasEstado, H001U4_n139MedidasEstado,
               H001U4_A137MedidasID
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV95Pgmname = "InventarioWW";
         /* GeneXus formulas. */
         AV95Pgmname = "InventarioWW";
         edtavExpand_Enabled = 0;
         edtavGrid_groupcaption_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV44ManageFiltersExecutionStep ;
      private short AV45TFRubrosId ;
      private short AV46TFRubrosId_To ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV73GridActions ;
      private short A121RubrosId ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV98Inventariowwds_3_dynamicfiltersoperator1 ;
      private short AV104Inventariowwds_9_dynamicfiltersoperator2 ;
      private short AV110Inventariowwds_15_dynamicfiltersoperator3 ;
      private short AV114Inventariowwds_19_tfrubrosid ;
      private short AV115Inventariowwds_20_tfrubrosid_to ;
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
      private int nRC_GXsfl_129 ;
      private int nGXsfl_129_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int Grid_group_Columnindex ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int edtavExpand_Enabled ;
      private int edtavGrid_groupcaption_Enabled ;
      private int AV124Inventariowwds_29_tfmedidasestado_sels_Count ;
      private int AV66GridCollapsedRecordsChildren_Count ;
      private int edtRubrosId_Enabled ;
      private int edtRubrosImagen_Enabled ;
      private int edtRubrosNombre_Enabled ;
      private int edtMedidasID_Enabled ;
      private int edtMedidasNombre_Enabled ;
      private int edtTextosId_Enabled ;
      private int edtTextosTitulo_Enabled ;
      private int edtRubrosId_Visible ;
      private int edtRubrosImagen_Visible ;
      private int edtRubrosNombre_Visible ;
      private int edtMedidasNombre_Visible ;
      private int edtTextosId_Visible ;
      private int edtTextosTitulo_Visible ;
      private int AV60PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int AV125GXV1 ;
      private int edtavRubroscosto1_Visible ;
      private int edtavRubrosnombre1_Visible ;
      private int edtavTextostipo1_Visible ;
      private int edtavRubroscosto2_Visible ;
      private int edtavRubrosnombre2_Visible ;
      private int edtavTextostipo2_Visible ;
      private int edtavRubroscosto3_Visible ;
      private int edtavRubrosnombre3_Visible ;
      private int edtavTextostipo3_Visible ;
      private int AV126GXV2 ;
      private int AV127GXV3 ;
      private int edtavRubroscosto3_Enabled ;
      private int edtavRubrosnombre3_Enabled ;
      private int edtavTextostipo3_Enabled ;
      private int edtavRubroscosto2_Enabled ;
      private int edtavRubrosnombre2_Enabled ;
      private int edtavTextostipo2_Enabled ;
      private int edtavRubroscosto1_Enabled ;
      private int edtavRubrosnombre1_Enabled ;
      private int edtavTextostipo1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV53TFTextosId ;
      private long AV54TFTextosId_To ;
      private long AV61GridCurrentPage ;
      private long AV62GridPageCount ;
      private long A137MedidasID ;
      private long A150TextosId ;
      private long GRID_nCurrentRecord ;
      private long AV120Inventariowwds_25_tftextosid ;
      private long AV121Inventariowwds_26_tftextosid_to ;
      private long GRID_nRecordCount ;
      private long AV68Index ;
      private decimal AV20RubrosCosto1 ;
      private decimal AV25RubrosCosto2 ;
      private decimal AV30RubrosCosto3 ;
      private decimal AV99Inventariowwds_4_rubroscosto1 ;
      private decimal AV105Inventariowwds_10_rubroscosto2 ;
      private decimal AV111Inventariowwds_16_rubroscosto3 ;
      private decimal A215RubrosCosto ;
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
      private string sGXsfl_129_idx="0001" ;
      private string AV21RubrosNombre1 ;
      private string AV82TextosTipo1 ;
      private string AV26RubrosNombre2 ;
      private string AV83TextosTipo2 ;
      private string AV31RubrosNombre3 ;
      private string AV84TextosTipo3 ;
      private string AV95Pgmname ;
      private string AV47TFRubrosNombre ;
      private string AV48TFRubrosNombre_Sel ;
      private string AV51TFMedidasNombre ;
      private string AV52TFMedidasNombre_Sel ;
      private string AV55TFTextosTitulo ;
      private string AV56TFTextosTitulo_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV65GroupRubrosNombre ;
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
      private string Grid_group_Gridinternalname ;
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
      private string Grid_group_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV72Expand ;
      private string edtavExpand_Internalname ;
      private string edtavGrid_groupcaption_Internalname ;
      private string cmbavGridactions_Internalname ;
      private string edtRubrosId_Internalname ;
      private string edtRubrosImagen_Internalname ;
      private string A122RubrosNombre ;
      private string edtRubrosNombre_Internalname ;
      private string edtMedidasID_Internalname ;
      private string A138MedidasNombre ;
      private string edtMedidasNombre_Internalname ;
      private string edtTextosId_Internalname ;
      private string A259TextosTitulo ;
      private string edtTextosTitulo_Internalname ;
      private string cmbMedidasEstado_Internalname ;
      private string A139MedidasEstado ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string AV100Inventariowwds_5_rubrosnombre1 ;
      private string AV101Inventariowwds_6_textostipo1 ;
      private string AV106Inventariowwds_11_rubrosnombre2 ;
      private string AV107Inventariowwds_12_textostipo2 ;
      private string AV112Inventariowwds_17_rubrosnombre3 ;
      private string AV113Inventariowwds_18_textostipo3 ;
      private string AV116Inventariowwds_21_tfrubrosnombre ;
      private string AV117Inventariowwds_22_tfrubrosnombre_sel ;
      private string AV118Inventariowwds_23_tfmedidasnombre ;
      private string AV119Inventariowwds_24_tfmedidasnombre_sel ;
      private string AV122Inventariowwds_27_tftextostitulo ;
      private string AV123Inventariowwds_28_tftextostitulo_sel ;
      private string lV100Inventariowwds_5_rubrosnombre1 ;
      private string lV101Inventariowwds_6_textostipo1 ;
      private string lV106Inventariowwds_11_rubrosnombre2 ;
      private string lV107Inventariowwds_12_textostipo2 ;
      private string lV112Inventariowwds_17_rubrosnombre3 ;
      private string lV113Inventariowwds_18_textostipo3 ;
      private string lV116Inventariowwds_21_tfrubrosnombre ;
      private string lV118Inventariowwds_23_tfmedidasnombre ;
      private string lV122Inventariowwds_27_tftextostitulo ;
      private string A258TextosTipo ;
      private string edtavRubroscosto1_Internalname ;
      private string edtavRubrosnombre1_Internalname ;
      private string edtavTextostipo1_Internalname ;
      private string edtavRubroscosto2_Internalname ;
      private string edtavRubrosnombre2_Internalname ;
      private string edtavTextostipo2_Internalname ;
      private string edtavRubroscosto3_Internalname ;
      private string edtavRubrosnombre3_Internalname ;
      private string edtavTextostipo3_Internalname ;
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
      private string edtavExpand_Columnclass ;
      private string edtRubrosNombre_Link ;
      private string GXEncryptionTmp ;
      private string GXt_char3 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_rubroscosto3_cell_Internalname ;
      private string edtavRubroscosto3_Jsonclick ;
      private string cellFilter_rubrosnombre3_cell_Internalname ;
      private string edtavRubrosnombre3_Jsonclick ;
      private string cellFilter_textostipo3_cell_Internalname ;
      private string edtavTextostipo3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_rubroscosto2_cell_Internalname ;
      private string edtavRubroscosto2_Jsonclick ;
      private string cellFilter_rubrosnombre2_cell_Internalname ;
      private string edtavRubrosnombre2_Jsonclick ;
      private string cellFilter_textostipo2_cell_Internalname ;
      private string edtavTextostipo2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_rubroscosto1_cell_Internalname ;
      private string edtavRubroscosto1_Jsonclick ;
      private string cellFilter_rubrosnombre1_cell_Internalname ;
      private string edtavRubrosnombre1_Jsonclick ;
      private string cellFilter_textostipo1_cell_Internalname ;
      private string edtavTextostipo1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_129_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavExpand_Jsonclick ;
      private string edtavGrid_groupcaption_Jsonclick ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string edtRubrosId_Jsonclick ;
      private string edtRubrosNombre_Jsonclick ;
      private string edtMedidasID_Jsonclick ;
      private string edtMedidasNombre_Jsonclick ;
      private string edtTextosId_Jsonclick ;
      private string edtTextosTitulo_Jsonclick ;
      private string cmbMedidasEstado_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV33DynamicFiltersIgnoreFirst ;
      private bool AV32DynamicFiltersRemoving ;
      private bool AV74IsAuthorized_Update ;
      private bool AV75IsAuthorized_Delete ;
      private bool AV79IsAuthorized_RubrosNombre ;
      private bool AV71AddChildren ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool Grid_empowerer_Hasrowgroups ;
      private bool wbLoad ;
      private bool bGXsfl_129_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n150TextosId ;
      private bool n139MedidasEstado ;
      private bool AV102Inventariowwds_7_dynamicfiltersenabled2 ;
      private bool AV108Inventariowwds_13_dynamicfiltersenabled3 ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV78TempBoolean ;
      private bool GXt_boolean1 ;
      private bool AV70DiscardFirst ;
      private bool A168RubrosImagen_IsBlob ;
      private string AV57TFMedidasEstado_SelsJson ;
      private string AV37ColumnsSelectorXML ;
      private string AV43ManageFiltersXml ;
      private string AV38UserCustomValue ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV17FilterFullText ;
      private string AV63GridAppliedFilters ;
      private string AV34Grid_GroupCaption ;
      private string A40001RubrosImagen_GXI ;
      private string AV96Inventariowwds_1_filterfulltext ;
      private string AV97Inventariowwds_2_dynamicfiltersselector1 ;
      private string AV103Inventariowwds_8_dynamicfiltersselector2 ;
      private string AV109Inventariowwds_14_dynamicfiltersselector3 ;
      private string AV35ExcelFilename ;
      private string AV36ErrorMessage ;
      private string AV64RecordKey ;
      private string A168RubrosImagen ;
      private IGxSession AV41Session ;
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
      private GXUserControl ucGrid_group ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbMedidasEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GxSimpleCollection<string> AV58TFMedidasEstado_Sels ;
      private GxSimpleCollection<string> AV67GridCollapsedRecords ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GxSimpleCollection<string> AV66GridCollapsedRecordsChildren ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV42ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV76AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV59DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV124Inventariowwds_29_tfmedidasestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H001U2_A258TextosTipo ;
      private decimal[] H001U2_A215RubrosCosto ;
      private string[] H001U2_A139MedidasEstado ;
      private bool[] H001U2_n139MedidasEstado ;
      private string[] H001U2_A259TextosTitulo ;
      private long[] H001U2_A150TextosId ;
      private bool[] H001U2_n150TextosId ;
      private string[] H001U2_A138MedidasNombre ;
      private long[] H001U2_A137MedidasID ;
      private string[] H001U2_A122RubrosNombre ;
      private string[] H001U2_A40001RubrosImagen_GXI ;
      private short[] H001U2_A121RubrosId ;
      private string[] H001U2_A168RubrosImagen ;
      private string[] H001U3_A258TextosTipo ;
      private decimal[] H001U3_A215RubrosCosto ;
      private string[] H001U3_A139MedidasEstado ;
      private bool[] H001U3_n139MedidasEstado ;
      private string[] H001U3_A259TextosTitulo ;
      private long[] H001U3_A150TextosId ;
      private bool[] H001U3_n150TextosId ;
      private string[] H001U3_A138MedidasNombre ;
      private long[] H001U3_A137MedidasID ;
      private string[] H001U3_A122RubrosNombre ;
      private string[] H001U3_A40001RubrosImagen_GXI ;
      private short[] H001U3_A121RubrosId ;
      private string[] H001U3_A168RubrosImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV77AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV69OldGridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private string[] H001U4_A258TextosTipo ;
      private string[] H001U4_A259TextosTitulo ;
      private long[] H001U4_A150TextosId ;
      private bool[] H001U4_n150TextosId ;
      private string[] H001U4_A138MedidasNombre ;
      private string[] H001U4_A122RubrosNombre ;
      private short[] H001U4_A121RubrosId ;
      private decimal[] H001U4_A215RubrosCosto ;
      private string[] H001U4_A139MedidasEstado ;
      private bool[] H001U4_n139MedidasEstado ;
      private long[] H001U4_A137MedidasID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class inventarioww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001U2( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV124Inventariowwds_29_tfmedidasestado_sels ,
                                             string AV97Inventariowwds_2_dynamicfiltersselector1 ,
                                             short AV98Inventariowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV99Inventariowwds_4_rubroscosto1 ,
                                             string AV100Inventariowwds_5_rubrosnombre1 ,
                                             string AV101Inventariowwds_6_textostipo1 ,
                                             bool AV102Inventariowwds_7_dynamicfiltersenabled2 ,
                                             string AV103Inventariowwds_8_dynamicfiltersselector2 ,
                                             short AV104Inventariowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV105Inventariowwds_10_rubroscosto2 ,
                                             string AV106Inventariowwds_11_rubrosnombre2 ,
                                             string AV107Inventariowwds_12_textostipo2 ,
                                             bool AV108Inventariowwds_13_dynamicfiltersenabled3 ,
                                             string AV109Inventariowwds_14_dynamicfiltersselector3 ,
                                             short AV110Inventariowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV111Inventariowwds_16_rubroscosto3 ,
                                             string AV112Inventariowwds_17_rubrosnombre3 ,
                                             string AV113Inventariowwds_18_textostipo3 ,
                                             short AV114Inventariowwds_19_tfrubrosid ,
                                             short AV115Inventariowwds_20_tfrubrosid_to ,
                                             string AV117Inventariowwds_22_tfrubrosnombre_sel ,
                                             string AV116Inventariowwds_21_tfrubrosnombre ,
                                             string AV119Inventariowwds_24_tfmedidasnombre_sel ,
                                             string AV118Inventariowwds_23_tfmedidasnombre ,
                                             long AV120Inventariowwds_25_tftextosid ,
                                             long AV121Inventariowwds_26_tftextosid_to ,
                                             string AV123Inventariowwds_28_tftextostitulo_sel ,
                                             string AV122Inventariowwds_27_tftextostitulo ,
                                             int AV124Inventariowwds_29_tfmedidasestado_sels_Count ,
                                             decimal A215RubrosCosto ,
                                             string A122RubrosNombre ,
                                             string A258TextosTipo ,
                                             short A121RubrosId ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV96Inventariowwds_1_filterfulltext ,
                                             int AV66GridCollapsedRecordsChildren_Count ,
                                             long A137MedidasID ,
                                             GxSimpleCollection<string> AV66GridCollapsedRecordsChildren )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[31];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T2.[TextosTipo], T1.[RubrosCosto], T1.[MedidasEstado], T2.[TextosTitulo], T1.[TextosId], T1.[MedidasNombre], T1.[MedidasID], T3.[RubrosNombre], T3.[RubrosImagen_GXI], T1.[RubrosId], T3.[RubrosImagen] FROM (([RubrosMedidas] T1 LEFT JOIN [Textos] T2 ON T2.[TextosId] = T1.[TextosId]) INNER JOIN [Rubros] T3 ON T3.[RubrosId] = T1.[RubrosId])";
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV99Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV99Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV99Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV99Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV99Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV99Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV100Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV100Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV101Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV101Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV105Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV105Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV105Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV105Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV105Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV105Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV106Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV106Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV107Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV107Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV111Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV111Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV111Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV111Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV111Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV111Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV112Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV112Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV113Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV113Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! (0==AV114Inventariowwds_19_tfrubrosid) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV114Inventariowwds_19_tfrubrosid)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! (0==AV115Inventariowwds_20_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV115Inventariowwds_20_tfrubrosid_to)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Inventariowwds_22_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Inventariowwds_21_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV116Inventariowwds_21_tfrubrosnombre))");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Inventariowwds_22_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV117Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[RubrosNombre] = @AV117Inventariowwds_22_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( StringUtil.StrCmp(AV117Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[RubrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Inventariowwds_24_tfmedidasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Inventariowwds_23_tfmedidasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV118Inventariowwds_23_tfmedidasnombre))");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Inventariowwds_24_tfmedidasnombre_sel)) && ! ( StringUtil.StrCmp(AV119Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV119Inventariowwds_24_tfmedidasnombre_sel)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( StringUtil.StrCmp(AV119Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( ! (0==AV120Inventariowwds_25_tftextosid) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV120Inventariowwds_25_tftextosid)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ! (0==AV121Inventariowwds_26_tftextosid_to) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV121Inventariowwds_26_tftextosid_to)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Inventariowwds_28_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Inventariowwds_27_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTitulo]) like UPPER(@lV122Inventariowwds_27_tftextostitulo))");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Inventariowwds_28_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV123Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] = @AV123Inventariowwds_28_tftextostitulo_sel)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( StringUtil.StrCmp(AV123Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] IS NULL or (T2.[TextosTitulo] = ''))");
         }
         if ( AV124Inventariowwds_29_tfmedidasestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV124Inventariowwds_29_tfmedidasestado_sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV14OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[RubrosCosto]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[RubrosId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[RubrosId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[MedidasNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[MedidasNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[TextosId]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[TextosId] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T2.[TextosTitulo]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T2.[TextosTitulo] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[MedidasEstado]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[MedidasEstado] DESC";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H001U3( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV124Inventariowwds_29_tfmedidasestado_sels ,
                                             string AV97Inventariowwds_2_dynamicfiltersselector1 ,
                                             short AV98Inventariowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV99Inventariowwds_4_rubroscosto1 ,
                                             string AV100Inventariowwds_5_rubrosnombre1 ,
                                             string AV101Inventariowwds_6_textostipo1 ,
                                             bool AV102Inventariowwds_7_dynamicfiltersenabled2 ,
                                             string AV103Inventariowwds_8_dynamicfiltersselector2 ,
                                             short AV104Inventariowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV105Inventariowwds_10_rubroscosto2 ,
                                             string AV106Inventariowwds_11_rubrosnombre2 ,
                                             string AV107Inventariowwds_12_textostipo2 ,
                                             bool AV108Inventariowwds_13_dynamicfiltersenabled3 ,
                                             string AV109Inventariowwds_14_dynamicfiltersselector3 ,
                                             short AV110Inventariowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV111Inventariowwds_16_rubroscosto3 ,
                                             string AV112Inventariowwds_17_rubrosnombre3 ,
                                             string AV113Inventariowwds_18_textostipo3 ,
                                             short AV114Inventariowwds_19_tfrubrosid ,
                                             short AV115Inventariowwds_20_tfrubrosid_to ,
                                             string AV117Inventariowwds_22_tfrubrosnombre_sel ,
                                             string AV116Inventariowwds_21_tfrubrosnombre ,
                                             string AV119Inventariowwds_24_tfmedidasnombre_sel ,
                                             string AV118Inventariowwds_23_tfmedidasnombre ,
                                             long AV120Inventariowwds_25_tftextosid ,
                                             long AV121Inventariowwds_26_tftextosid_to ,
                                             string AV123Inventariowwds_28_tftextostitulo_sel ,
                                             string AV122Inventariowwds_27_tftextostitulo ,
                                             int AV124Inventariowwds_29_tfmedidasestado_sels_Count ,
                                             decimal A215RubrosCosto ,
                                             string A122RubrosNombre ,
                                             string A258TextosTipo ,
                                             short A121RubrosId ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV96Inventariowwds_1_filterfulltext ,
                                             int AV66GridCollapsedRecordsChildren_Count ,
                                             long A137MedidasID ,
                                             GxSimpleCollection<string> AV66GridCollapsedRecordsChildren )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[31];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T2.[TextosTipo], T1.[RubrosCosto], T1.[MedidasEstado], T2.[TextosTitulo], T1.[TextosId], T1.[MedidasNombre], T1.[MedidasID], T3.[RubrosNombre], T3.[RubrosImagen_GXI], T1.[RubrosId], T3.[RubrosImagen] FROM (([RubrosMedidas] T1 LEFT JOIN [Textos] T2 ON T2.[TextosId] = T1.[TextosId]) INNER JOIN [Rubros] T3 ON T3.[RubrosId] = T1.[RubrosId])";
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV99Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV99Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int10[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV99Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV99Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV99Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV99Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV100Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV100Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV101Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV101Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV105Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV105Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV105Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV105Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV105Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV105Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV106Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV106Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV107Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV107Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV111Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV111Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV111Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV111Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV111Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV111Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV112Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV112Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV113Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV113Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( ! (0==AV114Inventariowwds_19_tfrubrosid) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV114Inventariowwds_19_tfrubrosid)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ! (0==AV115Inventariowwds_20_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV115Inventariowwds_20_tfrubrosid_to)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Inventariowwds_22_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Inventariowwds_21_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV116Inventariowwds_21_tfrubrosnombre))");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Inventariowwds_22_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV117Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[RubrosNombre] = @AV117Inventariowwds_22_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( StringUtil.StrCmp(AV117Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[RubrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Inventariowwds_24_tfmedidasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Inventariowwds_23_tfmedidasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV118Inventariowwds_23_tfmedidasnombre))");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Inventariowwds_24_tfmedidasnombre_sel)) && ! ( StringUtil.StrCmp(AV119Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV119Inventariowwds_24_tfmedidasnombre_sel)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( StringUtil.StrCmp(AV119Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( ! (0==AV120Inventariowwds_25_tftextosid) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV120Inventariowwds_25_tftextosid)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( ! (0==AV121Inventariowwds_26_tftextosid_to) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV121Inventariowwds_26_tftextosid_to)");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Inventariowwds_28_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Inventariowwds_27_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTitulo]) like UPPER(@lV122Inventariowwds_27_tftextostitulo))");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Inventariowwds_28_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV123Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] = @AV123Inventariowwds_28_tftextostitulo_sel)");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( StringUtil.StrCmp(AV123Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] IS NULL or (T2.[TextosTitulo] = ''))");
         }
         if ( AV124Inventariowwds_29_tfmedidasestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV124Inventariowwds_29_tfmedidasestado_sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV14OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[RubrosCosto]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[RubrosId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[RubrosId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[MedidasNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[MedidasNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[TextosId]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[TextosId] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T2.[TextosTitulo]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T2.[TextosTitulo] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[MedidasEstado]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[MedidasEstado] DESC";
         }
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_H001U4( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV124Inventariowwds_29_tfmedidasestado_sels ,
                                             string AV97Inventariowwds_2_dynamicfiltersselector1 ,
                                             short AV98Inventariowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV99Inventariowwds_4_rubroscosto1 ,
                                             string AV100Inventariowwds_5_rubrosnombre1 ,
                                             string AV101Inventariowwds_6_textostipo1 ,
                                             bool AV102Inventariowwds_7_dynamicfiltersenabled2 ,
                                             string AV103Inventariowwds_8_dynamicfiltersselector2 ,
                                             short AV104Inventariowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV105Inventariowwds_10_rubroscosto2 ,
                                             string AV106Inventariowwds_11_rubrosnombre2 ,
                                             string AV107Inventariowwds_12_textostipo2 ,
                                             bool AV108Inventariowwds_13_dynamicfiltersenabled3 ,
                                             string AV109Inventariowwds_14_dynamicfiltersselector3 ,
                                             short AV110Inventariowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV111Inventariowwds_16_rubroscosto3 ,
                                             string AV112Inventariowwds_17_rubrosnombre3 ,
                                             string AV113Inventariowwds_18_textostipo3 ,
                                             short AV114Inventariowwds_19_tfrubrosid ,
                                             short AV115Inventariowwds_20_tfrubrosid_to ,
                                             string AV117Inventariowwds_22_tfrubrosnombre_sel ,
                                             string AV116Inventariowwds_21_tfrubrosnombre ,
                                             string AV119Inventariowwds_24_tfmedidasnombre_sel ,
                                             string AV118Inventariowwds_23_tfmedidasnombre ,
                                             long AV120Inventariowwds_25_tftextosid ,
                                             long AV121Inventariowwds_26_tftextosid_to ,
                                             string AV123Inventariowwds_28_tftextostitulo_sel ,
                                             string AV122Inventariowwds_27_tftextostitulo ,
                                             int AV124Inventariowwds_29_tfmedidasestado_sels_Count ,
                                             decimal A215RubrosCosto ,
                                             string A122RubrosNombre ,
                                             string A258TextosTipo ,
                                             short A121RubrosId ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string AV96Inventariowwds_1_filterfulltext ,
                                             string AV65GroupRubrosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[32];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T2.[TextosTipo], T2.[TextosTitulo], T1.[TextosId], T1.[MedidasNombre], T3.[RubrosNombre], T1.[RubrosId], T1.[RubrosCosto], T1.[MedidasEstado], T1.[MedidasID] FROM (([RubrosMedidas] T1 LEFT JOIN [Textos] T2 ON T2.[TextosId] = T1.[TextosId]) INNER JOIN [Rubros] T3 ON T3.[RubrosId] = T1.[RubrosId])";
         AddWhere(sWhereString, "(T3.[RubrosNombre] = @AV65GroupRubrosNombre)");
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV99Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV99Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV99Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV99Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV99Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV99Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV100Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV100Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV101Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV98Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV101Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV105Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV105Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV105Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV105Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV105Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV105Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV106Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV106Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV107Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( AV102Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV104Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV107Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV111Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV111Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV111Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV111Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV111Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV111Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV112Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV112Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV113Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( AV108Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV110Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV113Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( ! (0==AV114Inventariowwds_19_tfrubrosid) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV114Inventariowwds_19_tfrubrosid)");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( ! (0==AV115Inventariowwds_20_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV115Inventariowwds_20_tfrubrosid_to)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Inventariowwds_22_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Inventariowwds_21_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV116Inventariowwds_21_tfrubrosnombre))");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Inventariowwds_22_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV117Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[RubrosNombre] = @AV117Inventariowwds_22_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( StringUtil.StrCmp(AV117Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[RubrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Inventariowwds_24_tfmedidasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Inventariowwds_23_tfmedidasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV118Inventariowwds_23_tfmedidasnombre))");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Inventariowwds_24_tfmedidasnombre_sel)) && ! ( StringUtil.StrCmp(AV119Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV119Inventariowwds_24_tfmedidasnombre_sel)");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( StringUtil.StrCmp(AV119Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( ! (0==AV120Inventariowwds_25_tftextosid) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV120Inventariowwds_25_tftextosid)");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( ! (0==AV121Inventariowwds_26_tftextosid_to) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV121Inventariowwds_26_tftextosid_to)");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Inventariowwds_28_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Inventariowwds_27_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTitulo]) like UPPER(@lV122Inventariowwds_27_tftextostitulo))");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Inventariowwds_28_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV123Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] = @AV123Inventariowwds_28_tftextostitulo_sel)");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( StringUtil.StrCmp(AV123Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] IS NULL or (T2.[TextosTitulo] = ''))");
         }
         if ( AV124Inventariowwds_29_tfmedidasestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV124Inventariowwds_29_tfmedidasestado_sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T1.[MedidasID]";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001U2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (decimal)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] , (string)dynConstraints[39] , (int)dynConstraints[40] , (long)dynConstraints[41] , (GxSimpleCollection<string>)dynConstraints[42] );
               case 1 :
                     return conditional_H001U3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (decimal)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] , (string)dynConstraints[39] , (int)dynConstraints[40] , (long)dynConstraints[41] , (GxSimpleCollection<string>)dynConstraints[42] );
               case 2 :
                     return conditional_H001U4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (decimal)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH001U2;
          prmH001U2 = new Object[] {
          new ParDef("@AV99Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV99Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV99Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@lV100Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV100Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV101Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV101Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@AV105Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV105Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV105Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@lV106Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV106Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV107Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV107Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@AV111Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV111Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV111Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@lV112Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV112Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV113Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV113Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV114Inventariowwds_19_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV115Inventariowwds_20_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV116Inventariowwds_21_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV117Inventariowwds_22_tfrubrosnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV118Inventariowwds_23_tfmedidasnombre",GXType.Char,50,0) ,
          new ParDef("@AV119Inventariowwds_24_tfmedidasnombre_sel",GXType.NChar,50,0) ,
          new ParDef("@AV120Inventariowwds_25_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV121Inventariowwds_26_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV122Inventariowwds_27_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV123Inventariowwds_28_tftextostitulo_sel",GXType.NChar,80,0)
          };
          Object[] prmH001U3;
          prmH001U3 = new Object[] {
          new ParDef("@AV99Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV99Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV99Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@lV100Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV100Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV101Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV101Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@AV105Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV105Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV105Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@lV106Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV106Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV107Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV107Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@AV111Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV111Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV111Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@lV112Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV112Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV113Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV113Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV114Inventariowwds_19_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV115Inventariowwds_20_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV116Inventariowwds_21_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV117Inventariowwds_22_tfrubrosnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV118Inventariowwds_23_tfmedidasnombre",GXType.Char,50,0) ,
          new ParDef("@AV119Inventariowwds_24_tfmedidasnombre_sel",GXType.NChar,50,0) ,
          new ParDef("@AV120Inventariowwds_25_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV121Inventariowwds_26_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV122Inventariowwds_27_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV123Inventariowwds_28_tftextostitulo_sel",GXType.NChar,80,0)
          };
          Object[] prmH001U4;
          prmH001U4 = new Object[] {
          new ParDef("@AV65GroupRubrosNombre",GXType.NChar,100,0) ,
          new ParDef("@AV99Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV99Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV99Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@lV100Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV100Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV101Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV101Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@AV105Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV105Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV105Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@lV106Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV106Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV107Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV107Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@AV111Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV111Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV111Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@lV112Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV112Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV113Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV113Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV114Inventariowwds_19_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV115Inventariowwds_20_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV116Inventariowwds_21_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV117Inventariowwds_22_tfrubrosnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV118Inventariowwds_23_tfmedidasnombre",GXType.Char,50,0) ,
          new ParDef("@AV119Inventariowwds_24_tfmedidasnombre_sel",GXType.NChar,50,0) ,
          new ParDef("@AV120Inventariowwds_25_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV121Inventariowwds_26_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV122Inventariowwds_27_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV123Inventariowwds_28_tftextostitulo_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001U2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001U3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001U4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001U4,11, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 80);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 50);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 100);
                ((string[]) buf[10])[0] = rslt.getMultimediaUri(9);
                ((short[]) buf[11])[0] = rslt.getShort(10);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(9));
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 80);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 50);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 100);
                ((string[]) buf[10])[0] = rslt.getMultimediaUri(9);
                ((short[]) buf[11])[0] = rslt.getShort(10);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(9));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}
