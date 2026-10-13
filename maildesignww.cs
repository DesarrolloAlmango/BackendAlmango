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
   public class maildesignww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public maildesignww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public maildesignww( IGxContext context )
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
         cmbavMaildesigntipo1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavMaildesigntipo2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavMaildesigntipo3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbMailDesignTipo = new GXCombobox();
         cmbMailDesignEstado = new GXCombobox();
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
         nRC_GXsfl_102 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_102"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_102_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_102_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_102_idx = GetPar( "sGXsfl_102_idx");
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
         cmbavMaildesigntipo1.FromJSonString( GetNextPar( ));
         AV19MailDesignTipo1 = GetPar( "MailDesignTipo1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavMaildesigntipo2.FromJSonString( GetNextPar( ));
         AV22MailDesignTipo2 = GetPar( "MailDesignTipo2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavMaildesigntipo3.FromJSonString( GetNextPar( ));
         AV25MailDesignTipo3 = GetPar( "MailDesignTipo3");
         AV37ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV32ColumnsSelector);
         AV57Pgmname = GetPar( "Pgmname");
         AV17FilterFullText = GetPar( "FilterFullText");
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV38TFMailDesignId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMailDesignId"), "."), 18, MidpointRounding.ToEven));
         AV39TFMailDesignId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMailDesignId_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41TFMailDesignTipo_Sels);
         AV42TFMailDesignAsunto = GetPar( "TFMailDesignAsunto");
         AV43TFMailDesignAsunto_Sel = GetPar( "TFMailDesignAsunto_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV45TFMailDesignEstado_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV27DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV26DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV52IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV53IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19MailDesignTipo1, AV21DynamicFiltersSelector2, AV22MailDesignTipo2, AV24DynamicFiltersSelector3, AV25MailDesignTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV57Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFMailDesignId, AV39TFMailDesignId_To, AV41TFMailDesignTipo_Sels, AV42TFMailDesignAsunto, AV43TFMailDesignAsunto_Sel, AV45TFMailDesignEstado_Sels, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV52IsAuthorized_Update, AV53IsAuthorized_Delete) ;
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
         PAB62( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTB62( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("maildesignww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV52IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV52IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vMAILDESIGNTIPO1", StringUtil.RTrim( AV19MailDesignTipo1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vMAILDESIGNTIPO2", StringUtil.RTrim( AV22MailDesignTipo2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vMAILDESIGNTIPO3", StringUtil.RTrim( AV25MailDesignTipo3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_102", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_102), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV50GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV54AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV54AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFMAILDESIGNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38TFMailDesignId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFMAILDESIGNID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39TFMailDesignId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMAILDESIGNTIPO_SELS", AV41TFMailDesignTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMAILDESIGNTIPO_SELS", AV41TFMailDesignTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFMAILDESIGNASUNTO", StringUtil.RTrim( AV42TFMailDesignAsunto));
         GxWebStd.gx_hidden_field( context, "vTFMAILDESIGNASUNTO_SEL", StringUtil.RTrim( AV43TFMailDesignAsunto_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMAILDESIGNESTADO_SELS", AV45TFMailDesignEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMAILDESIGNESTADO_SELS", AV45TFMailDesignEstado_Sels);
         }
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV52IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV52IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "vTFMAILDESIGNTIPO_SELSJSON", AV40TFMailDesignTipo_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFMAILDESIGNESTADO_SELSJSON", AV44TFMailDesignEstado_SelsJson);
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
            WEB62( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTB62( ) ;
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
         return formatLink("maildesignww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "MailDesignWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Mail Design", "") ;
      }

      protected void WBB60( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(102), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_MailDesignWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(102), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_MailDesignWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(102), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_MailDesignWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(102), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_MailDesignWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_B62( true) ;
         }
         else
         {
            wb_table1_25_B62( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_B62e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_MailDesignWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_MailDesignWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_MailDesignWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_B62( true) ;
         }
         else
         {
            wb_table2_49_B62( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_B62e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_MailDesignWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_MailDesignWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_MailDesignWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_68_B62( true) ;
         }
         else
         {
            wb_table3_68_B62( false) ;
         }
         return  ;
      }

      protected void wb_table3_68_B62e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_MailDesignWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 0, "HLP_MailDesignWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_MailDesignWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_87_B62( true) ;
         }
         else
         {
            wb_table4_87_B62( false) ;
         }
         return  ;
      }

      protected void wb_table4_87_B62e( bool wbgen )
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
            StartGridControl102( ) ;
         }
         if ( wbEnd == 102 )
         {
            wbEnd = 0;
            nRC_GXsfl_102 = (int)(nGXsfl_102_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV48GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV49GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV50GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV54AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_MailDesignWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV46DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV46DDO_TitleSettingsIcons);
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
               GxWebStd.gx_hidden_field( context, "W0122"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0122"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_102_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0122"+"");
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
         if ( wbEnd == 102 )
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

      protected void STARTB62( )
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
         Form.Meta.addItem("description", context.GetMessage( " Mail Design", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPB60( ) ;
      }

      protected void WSB62( )
      {
         STARTB62( ) ;
         EVTB62( ) ;
      }

      protected void EVTB62( )
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
                              E11B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E14B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E15B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E16B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E17B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E18B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E19B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E20B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E21B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E22B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E24B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E25B62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E26B62 ();
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
                              nGXsfl_102_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
                              SubsflControlProps_1022( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV51GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV51GridActions), 4, 0));
                              A148MailDesignId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMailDesignId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbMailDesignTipo.Name = cmbMailDesignTipo_Internalname;
                              cmbMailDesignTipo.CurrentValue = cgiGet( cmbMailDesignTipo_Internalname);
                              A244MailDesignTipo = cgiGet( cmbMailDesignTipo_Internalname);
                              A246MailDesignAsunto = cgiGet( edtMailDesignAsunto_Internalname);
                              cmbMailDesignEstado.Name = cmbMailDesignEstado_Internalname;
                              cmbMailDesignEstado.CurrentValue = cgiGet( cmbMailDesignEstado_Internalname);
                              A245MailDesignEstado = cgiGet( cmbMailDesignEstado_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E27B62 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E28B62 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E29B62 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E30B62 ();
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
                                       /* Set Refresh If Maildesigntipo1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMAILDESIGNTIPO1"), AV19MailDesignTipo1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Maildesigntipo2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMAILDESIGNTIPO2"), AV22MailDesignTipo2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Maildesigntipo3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMAILDESIGNTIPO3"), AV25MailDesignTipo3) != 0 )
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
                        if ( nCmpId == 122 )
                        {
                           OldWwpaux_wc = cgiGet( "W0122");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0122", "", sEvt);
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

      protected void WEB62( )
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

      protected void PAB62( )
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
         SubsflControlProps_1022( ) ;
         while ( nGXsfl_102_idx <= nRC_GXsfl_102 )
         {
            sendrow_1022( ) ;
            nGXsfl_102_idx = ((subGrid_Islastpage==1)&&(nGXsfl_102_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_102_idx+1);
            sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
            SubsflControlProps_1022( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV18DynamicFiltersSelector1 ,
                                       string AV19MailDesignTipo1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       string AV22MailDesignTipo2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       string AV25MailDesignTipo3 ,
                                       short AV37ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV32ColumnsSelector ,
                                       string AV57Pgmname ,
                                       string AV17FilterFullText ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       long AV38TFMailDesignId ,
                                       long AV39TFMailDesignId_To ,
                                       GxSimpleCollection<string> AV41TFMailDesignTipo_Sels ,
                                       string AV42TFMailDesignAsunto ,
                                       string AV43TFMailDesignAsunto_Sel ,
                                       GxSimpleCollection<string> AV45TFMailDesignEstado_Sels ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV27DynamicFiltersIgnoreFirst ,
                                       bool AV26DynamicFiltersRemoving ,
                                       bool AV52IsAuthorized_Update ,
                                       bool AV53IsAuthorized_Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFB62( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MAILDESIGNID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A148MailDesignId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MAILDESIGNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A148MailDesignId), 18, 0, ".", "")));
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
         if ( cmbavMaildesigntipo1.ItemCount > 0 )
         {
            AV19MailDesignTipo1 = cmbavMaildesigntipo1.getValidValue(AV19MailDesignTipo1);
            AssignAttri("", false, "AV19MailDesignTipo1", AV19MailDesignTipo1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMaildesigntipo1.CurrentValue = StringUtil.RTrim( AV19MailDesignTipo1);
            AssignProp("", false, cmbavMaildesigntipo1_Internalname, "Values", cmbavMaildesigntipo1.ToJavascriptSource(), true);
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
         if ( cmbavMaildesigntipo2.ItemCount > 0 )
         {
            AV22MailDesignTipo2 = cmbavMaildesigntipo2.getValidValue(AV22MailDesignTipo2);
            AssignAttri("", false, "AV22MailDesignTipo2", AV22MailDesignTipo2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMaildesigntipo2.CurrentValue = StringUtil.RTrim( AV22MailDesignTipo2);
            AssignProp("", false, cmbavMaildesigntipo2_Internalname, "Values", cmbavMaildesigntipo2.ToJavascriptSource(), true);
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
         if ( cmbavMaildesigntipo3.ItemCount > 0 )
         {
            AV25MailDesignTipo3 = cmbavMaildesigntipo3.getValidValue(AV25MailDesignTipo3);
            AssignAttri("", false, "AV25MailDesignTipo3", AV25MailDesignTipo3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMaildesigntipo3.CurrentValue = StringUtil.RTrim( AV25MailDesignTipo3);
            AssignProp("", false, cmbavMaildesigntipo3_Internalname, "Values", cmbavMaildesigntipo3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFB62( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV57Pgmname = "MailDesignWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV58Maildesignwwds_1_filterfulltext = AV17FilterFullText;
         AV59Maildesignwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV60Maildesignwwds_3_maildesigntipo1 = AV19MailDesignTipo1;
         AV61Maildesignwwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Maildesignwwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Maildesignwwds_6_maildesigntipo2 = AV22MailDesignTipo2;
         AV64Maildesignwwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV65Maildesignwwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV66Maildesignwwds_9_maildesigntipo3 = AV25MailDesignTipo3;
         AV67Maildesignwwds_10_tfmaildesignid = AV38TFMailDesignId;
         AV68Maildesignwwds_11_tfmaildesignid_to = AV39TFMailDesignId_To;
         AV69Maildesignwwds_12_tfmaildesigntipo_sels = AV41TFMailDesignTipo_Sels;
         AV70Maildesignwwds_13_tfmaildesignasunto = AV42TFMailDesignAsunto;
         AV71Maildesignwwds_14_tfmaildesignasunto_sel = AV43TFMailDesignAsunto_Sel;
         AV72Maildesignwwds_15_tfmaildesignestado_sels = AV45TFMailDesignEstado_Sels;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A244MailDesignTipo ,
                                              AV69Maildesignwwds_12_tfmaildesigntipo_sels ,
                                              A245MailDesignEstado ,
                                              AV72Maildesignwwds_15_tfmaildesignestado_sels ,
                                              AV59Maildesignwwds_2_dynamicfiltersselector1 ,
                                              AV60Maildesignwwds_3_maildesigntipo1 ,
                                              AV61Maildesignwwds_4_dynamicfiltersenabled2 ,
                                              AV62Maildesignwwds_5_dynamicfiltersselector2 ,
                                              AV63Maildesignwwds_6_maildesigntipo2 ,
                                              AV64Maildesignwwds_7_dynamicfiltersenabled3 ,
                                              AV65Maildesignwwds_8_dynamicfiltersselector3 ,
                                              AV66Maildesignwwds_9_maildesigntipo3 ,
                                              AV67Maildesignwwds_10_tfmaildesignid ,
                                              AV68Maildesignwwds_11_tfmaildesignid_to ,
                                              AV69Maildesignwwds_12_tfmaildesigntipo_sels.Count ,
                                              AV71Maildesignwwds_14_tfmaildesignasunto_sel ,
                                              AV70Maildesignwwds_13_tfmaildesignasunto ,
                                              AV72Maildesignwwds_15_tfmaildesignestado_sels.Count ,
                                              A148MailDesignId ,
                                              A246MailDesignAsunto ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV58Maildesignwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV70Maildesignwwds_13_tfmaildesignasunto = StringUtil.PadR( StringUtil.RTrim( AV70Maildesignwwds_13_tfmaildesignasunto), 80, "%");
         /* Using cursor H00B62 */
         pr_default.execute(0, new Object[] {AV60Maildesignwwds_3_maildesigntipo1, AV63Maildesignwwds_6_maildesigntipo2, AV66Maildesignwwds_9_maildesigntipo3, AV67Maildesignwwds_10_tfmaildesignid, AV68Maildesignwwds_11_tfmaildesignid_to, lV70Maildesignwwds_13_tfmaildesignasunto, AV71Maildesignwwds_14_tfmaildesignasunto_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A245MailDesignEstado = H00B62_A245MailDesignEstado[0];
            A246MailDesignAsunto = H00B62_A246MailDesignAsunto[0];
            A244MailDesignTipo = H00B62_A244MailDesignTipo[0];
            A148MailDesignId = H00B62_A148MailDesignId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Maildesignwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A148MailDesignId), 18, 0) , StringUtil.PadR( "%" + AV58Maildesignwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "publicidad", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "recuperar usuario y contraseña", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "R") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "notificación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "N") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "O") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A246MailDesignAsunto) , StringUtil.PadR( "%" + StringUtil.Upper( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A245MailDesignEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A245MailDesignEstado, "DES") == 0 ) ) ) )
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

      protected void RFB62( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 102;
         /* Execute user event: Refresh */
         E28B62 ();
         nGXsfl_102_idx = 1;
         sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
         SubsflControlProps_1022( ) ;
         bGXsfl_102_Refreshing = true;
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
            SubsflControlProps_1022( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A244MailDesignTipo ,
                                                 AV69Maildesignwwds_12_tfmaildesigntipo_sels ,
                                                 A245MailDesignEstado ,
                                                 AV72Maildesignwwds_15_tfmaildesignestado_sels ,
                                                 AV59Maildesignwwds_2_dynamicfiltersselector1 ,
                                                 AV60Maildesignwwds_3_maildesigntipo1 ,
                                                 AV61Maildesignwwds_4_dynamicfiltersenabled2 ,
                                                 AV62Maildesignwwds_5_dynamicfiltersselector2 ,
                                                 AV63Maildesignwwds_6_maildesigntipo2 ,
                                                 AV64Maildesignwwds_7_dynamicfiltersenabled3 ,
                                                 AV65Maildesignwwds_8_dynamicfiltersselector3 ,
                                                 AV66Maildesignwwds_9_maildesigntipo3 ,
                                                 AV67Maildesignwwds_10_tfmaildesignid ,
                                                 AV68Maildesignwwds_11_tfmaildesignid_to ,
                                                 AV69Maildesignwwds_12_tfmaildesigntipo_sels.Count ,
                                                 AV71Maildesignwwds_14_tfmaildesignasunto_sel ,
                                                 AV70Maildesignwwds_13_tfmaildesignasunto ,
                                                 AV72Maildesignwwds_15_tfmaildesignestado_sels.Count ,
                                                 A148MailDesignId ,
                                                 A246MailDesignAsunto ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV58Maildesignwwds_1_filterfulltext } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV70Maildesignwwds_13_tfmaildesignasunto = StringUtil.PadR( StringUtil.RTrim( AV70Maildesignwwds_13_tfmaildesignasunto), 80, "%");
            /* Using cursor H00B63 */
            pr_default.execute(1, new Object[] {AV60Maildesignwwds_3_maildesigntipo1, AV63Maildesignwwds_6_maildesigntipo2, AV66Maildesignwwds_9_maildesigntipo3, AV67Maildesignwwds_10_tfmaildesignid, AV68Maildesignwwds_11_tfmaildesignid_to, lV70Maildesignwwds_13_tfmaildesignasunto, AV71Maildesignwwds_14_tfmaildesignasunto_sel});
            nGXsfl_102_idx = 1;
            sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
            SubsflControlProps_1022( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A245MailDesignEstado = H00B63_A245MailDesignEstado[0];
               A246MailDesignAsunto = H00B63_A246MailDesignAsunto[0];
               A244MailDesignTipo = H00B63_A244MailDesignTipo[0];
               A148MailDesignId = H00B63_A148MailDesignId[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Maildesignwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A148MailDesignId), 18, 0) , StringUtil.PadR( "%" + AV58Maildesignwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "publicidad", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "recuperar usuario y contraseña", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "R") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "notificación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "N") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "O") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A246MailDesignAsunto) , StringUtil.PadR( "%" + StringUtil.Upper( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A245MailDesignEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A245MailDesignEstado, "DES") == 0 ) ) ) )
               {
                  /* Execute user event: Grid.Load */
                  E29B62 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 102;
            WBB60( ) ;
         }
         bGXsfl_102_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesB62( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV52IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV52IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_MAILDESIGNID"+"_"+sGXsfl_102_idx, GetSecureSignedToken( sGXsfl_102_idx, context.localUtil.Format( (decimal)(A148MailDesignId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         AV58Maildesignwwds_1_filterfulltext = AV17FilterFullText;
         AV59Maildesignwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV60Maildesignwwds_3_maildesigntipo1 = AV19MailDesignTipo1;
         AV61Maildesignwwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Maildesignwwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Maildesignwwds_6_maildesigntipo2 = AV22MailDesignTipo2;
         AV64Maildesignwwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV65Maildesignwwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV66Maildesignwwds_9_maildesigntipo3 = AV25MailDesignTipo3;
         AV67Maildesignwwds_10_tfmaildesignid = AV38TFMailDesignId;
         AV68Maildesignwwds_11_tfmaildesignid_to = AV39TFMailDesignId_To;
         AV69Maildesignwwds_12_tfmaildesigntipo_sels = AV41TFMailDesignTipo_Sels;
         AV70Maildesignwwds_13_tfmaildesignasunto = AV42TFMailDesignAsunto;
         AV71Maildesignwwds_14_tfmaildesignasunto_sel = AV43TFMailDesignAsunto_Sel;
         AV72Maildesignwwds_15_tfmaildesignestado_sels = AV45TFMailDesignEstado_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19MailDesignTipo1, AV21DynamicFiltersSelector2, AV22MailDesignTipo2, AV24DynamicFiltersSelector3, AV25MailDesignTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV57Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFMailDesignId, AV39TFMailDesignId_To, AV41TFMailDesignTipo_Sels, AV42TFMailDesignAsunto, AV43TFMailDesignAsunto_Sel, AV45TFMailDesignEstado_Sels, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV52IsAuthorized_Update, AV53IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV58Maildesignwwds_1_filterfulltext = AV17FilterFullText;
         AV59Maildesignwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV60Maildesignwwds_3_maildesigntipo1 = AV19MailDesignTipo1;
         AV61Maildesignwwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Maildesignwwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Maildesignwwds_6_maildesigntipo2 = AV22MailDesignTipo2;
         AV64Maildesignwwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV65Maildesignwwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV66Maildesignwwds_9_maildesigntipo3 = AV25MailDesignTipo3;
         AV67Maildesignwwds_10_tfmaildesignid = AV38TFMailDesignId;
         AV68Maildesignwwds_11_tfmaildesignid_to = AV39TFMailDesignId_To;
         AV69Maildesignwwds_12_tfmaildesigntipo_sels = AV41TFMailDesignTipo_Sels;
         AV70Maildesignwwds_13_tfmaildesignasunto = AV42TFMailDesignAsunto;
         AV71Maildesignwwds_14_tfmaildesignasunto_sel = AV43TFMailDesignAsunto_Sel;
         AV72Maildesignwwds_15_tfmaildesignestado_sels = AV45TFMailDesignEstado_Sels;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19MailDesignTipo1, AV21DynamicFiltersSelector2, AV22MailDesignTipo2, AV24DynamicFiltersSelector3, AV25MailDesignTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV57Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFMailDesignId, AV39TFMailDesignId_To, AV41TFMailDesignTipo_Sels, AV42TFMailDesignAsunto, AV43TFMailDesignAsunto_Sel, AV45TFMailDesignEstado_Sels, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV52IsAuthorized_Update, AV53IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV58Maildesignwwds_1_filterfulltext = AV17FilterFullText;
         AV59Maildesignwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV60Maildesignwwds_3_maildesigntipo1 = AV19MailDesignTipo1;
         AV61Maildesignwwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Maildesignwwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Maildesignwwds_6_maildesigntipo2 = AV22MailDesignTipo2;
         AV64Maildesignwwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV65Maildesignwwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV66Maildesignwwds_9_maildesigntipo3 = AV25MailDesignTipo3;
         AV67Maildesignwwds_10_tfmaildesignid = AV38TFMailDesignId;
         AV68Maildesignwwds_11_tfmaildesignid_to = AV39TFMailDesignId_To;
         AV69Maildesignwwds_12_tfmaildesigntipo_sels = AV41TFMailDesignTipo_Sels;
         AV70Maildesignwwds_13_tfmaildesignasunto = AV42TFMailDesignAsunto;
         AV71Maildesignwwds_14_tfmaildesignasunto_sel = AV43TFMailDesignAsunto_Sel;
         AV72Maildesignwwds_15_tfmaildesignestado_sels = AV45TFMailDesignEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19MailDesignTipo1, AV21DynamicFiltersSelector2, AV22MailDesignTipo2, AV24DynamicFiltersSelector3, AV25MailDesignTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV57Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFMailDesignId, AV39TFMailDesignId_To, AV41TFMailDesignTipo_Sels, AV42TFMailDesignAsunto, AV43TFMailDesignAsunto_Sel, AV45TFMailDesignEstado_Sels, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV52IsAuthorized_Update, AV53IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV58Maildesignwwds_1_filterfulltext = AV17FilterFullText;
         AV59Maildesignwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV60Maildesignwwds_3_maildesigntipo1 = AV19MailDesignTipo1;
         AV61Maildesignwwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Maildesignwwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Maildesignwwds_6_maildesigntipo2 = AV22MailDesignTipo2;
         AV64Maildesignwwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV65Maildesignwwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV66Maildesignwwds_9_maildesigntipo3 = AV25MailDesignTipo3;
         AV67Maildesignwwds_10_tfmaildesignid = AV38TFMailDesignId;
         AV68Maildesignwwds_11_tfmaildesignid_to = AV39TFMailDesignId_To;
         AV69Maildesignwwds_12_tfmaildesigntipo_sels = AV41TFMailDesignTipo_Sels;
         AV70Maildesignwwds_13_tfmaildesignasunto = AV42TFMailDesignAsunto;
         AV71Maildesignwwds_14_tfmaildesignasunto_sel = AV43TFMailDesignAsunto_Sel;
         AV72Maildesignwwds_15_tfmaildesignestado_sels = AV45TFMailDesignEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19MailDesignTipo1, AV21DynamicFiltersSelector2, AV22MailDesignTipo2, AV24DynamicFiltersSelector3, AV25MailDesignTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV57Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFMailDesignId, AV39TFMailDesignId_To, AV41TFMailDesignTipo_Sels, AV42TFMailDesignAsunto, AV43TFMailDesignAsunto_Sel, AV45TFMailDesignEstado_Sels, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV52IsAuthorized_Update, AV53IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV58Maildesignwwds_1_filterfulltext = AV17FilterFullText;
         AV59Maildesignwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV60Maildesignwwds_3_maildesigntipo1 = AV19MailDesignTipo1;
         AV61Maildesignwwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Maildesignwwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Maildesignwwds_6_maildesigntipo2 = AV22MailDesignTipo2;
         AV64Maildesignwwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV65Maildesignwwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV66Maildesignwwds_9_maildesigntipo3 = AV25MailDesignTipo3;
         AV67Maildesignwwds_10_tfmaildesignid = AV38TFMailDesignId;
         AV68Maildesignwwds_11_tfmaildesignid_to = AV39TFMailDesignId_To;
         AV69Maildesignwwds_12_tfmaildesigntipo_sels = AV41TFMailDesignTipo_Sels;
         AV70Maildesignwwds_13_tfmaildesignasunto = AV42TFMailDesignAsunto;
         AV71Maildesignwwds_14_tfmaildesignasunto_sel = AV43TFMailDesignAsunto_Sel;
         AV72Maildesignwwds_15_tfmaildesignestado_sels = AV45TFMailDesignEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19MailDesignTipo1, AV21DynamicFiltersSelector2, AV22MailDesignTipo2, AV24DynamicFiltersSelector3, AV25MailDesignTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV57Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFMailDesignId, AV39TFMailDesignId_To, AV41TFMailDesignTipo_Sels, AV42TFMailDesignAsunto, AV43TFMailDesignAsunto_Sel, AV45TFMailDesignEstado_Sels, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV52IsAuthorized_Update, AV53IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV57Pgmname = "MailDesignWW";
         edtMailDesignId_Enabled = 0;
         cmbMailDesignTipo.Enabled = 0;
         edtMailDesignAsunto_Enabled = 0;
         cmbMailDesignEstado.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPB60( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E27B62 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV35ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV54AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV46DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV32ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_102 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_102"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV48GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV49GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV50GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV18DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            cmbavMaildesigntipo1.Name = cmbavMaildesigntipo1_Internalname;
            cmbavMaildesigntipo1.CurrentValue = cgiGet( cmbavMaildesigntipo1_Internalname);
            AV19MailDesignTipo1 = cgiGet( cmbavMaildesigntipo1_Internalname);
            AssignAttri("", false, "AV19MailDesignTipo1", AV19MailDesignTipo1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavMaildesigntipo2.Name = cmbavMaildesigntipo2_Internalname;
            cmbavMaildesigntipo2.CurrentValue = cgiGet( cmbavMaildesigntipo2_Internalname);
            AV22MailDesignTipo2 = cgiGet( cmbavMaildesigntipo2_Internalname);
            AssignAttri("", false, "AV22MailDesignTipo2", AV22MailDesignTipo2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavMaildesigntipo3.Name = cmbavMaildesigntipo3_Internalname;
            cmbavMaildesigntipo3.CurrentValue = cgiGet( cmbavMaildesigntipo3_Internalname);
            AV25MailDesignTipo3 = cgiGet( cmbavMaildesigntipo3_Internalname);
            AssignAttri("", false, "AV25MailDesignTipo3", AV25MailDesignTipo3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMAILDESIGNTIPO1"), AV19MailDesignTipo1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMAILDESIGNTIPO2"), AV22MailDesignTipo2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMAILDESIGNTIPO3"), AV25MailDesignTipo3) != 0 )
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
         E27B62 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E27B62( )
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
         AV19MailDesignTipo1 = "";
         AssignAttri("", false, "AV19MailDesignTipo1", AV19MailDesignTipo1);
         AV18DynamicFiltersSelector1 = "MAILDESIGNTIPO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22MailDesignTipo2 = "";
         AssignAttri("", false, "AV22MailDesignTipo2", AV22MailDesignTipo2);
         AV21DynamicFiltersSelector2 = "MAILDESIGNTIPO";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25MailDesignTipo3 = "";
         AssignAttri("", false, "AV25MailDesignTipo3", AV25MailDesignTipo3);
         AV24DynamicFiltersSelector3 = "MAILDESIGNTIPO";
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
         AV54AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV55AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV55AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV55AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV55AGExportDataItem.gxTpr_Eventkey = "Export";
         AV55AGExportDataItem.gxTpr_Isdivider = false;
         AV54AGExportData.Add(AV55AGExportDataItem, 0);
         AV55AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV55AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV55AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV55AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV55AGExportDataItem.gxTpr_Isdivider = false;
         AV54AGExportData.Add(AV55AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Mail Design", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV46DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV46DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E28B62( )
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
         if ( StringUtil.StrCmp(AV34Session.Get("MailDesignWWColumnsSelector"), "") != 0 )
         {
            AV30ColumnsSelectorXML = AV34Session.Get("MailDesignWWColumnsSelector");
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
         edtMailDesignId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMailDesignId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMailDesignId_Visible), 5, 0), !bGXsfl_102_Refreshing);
         cmbMailDesignTipo.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbMailDesignTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbMailDesignTipo.Visible), 5, 0), !bGXsfl_102_Refreshing);
         edtMailDesignAsunto_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMailDesignAsunto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMailDesignAsunto_Visible), 5, 0), !bGXsfl_102_Refreshing);
         cmbMailDesignEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV32ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbMailDesignEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbMailDesignEstado.Visible), 5, 0), !bGXsfl_102_Refreshing);
         AV48GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV48GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV48GridCurrentPage), 10, 0));
         AV49GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV49GridPageCount", StringUtil.LTrimStr( (decimal)(AV49GridPageCount), 10, 0));
         GXt_char2 = AV50GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV57Pgmname, out  GXt_char2) ;
         AV50GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV50GridAppliedFilters", AV50GridAppliedFilters);
         AV58Maildesignwwds_1_filterfulltext = AV17FilterFullText;
         AV59Maildesignwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV60Maildesignwwds_3_maildesigntipo1 = AV19MailDesignTipo1;
         AV61Maildesignwwds_4_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Maildesignwwds_5_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Maildesignwwds_6_maildesigntipo2 = AV22MailDesignTipo2;
         AV64Maildesignwwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV65Maildesignwwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV66Maildesignwwds_9_maildesigntipo3 = AV25MailDesignTipo3;
         AV67Maildesignwwds_10_tfmaildesignid = AV38TFMailDesignId;
         AV68Maildesignwwds_11_tfmaildesignid_to = AV39TFMailDesignId_To;
         AV69Maildesignwwds_12_tfmaildesigntipo_sels = AV41TFMailDesignTipo_Sels;
         AV70Maildesignwwds_13_tfmaildesignasunto = AV42TFMailDesignAsunto;
         AV71Maildesignwwds_14_tfmaildesignasunto_sel = AV43TFMailDesignAsunto_Sel;
         AV72Maildesignwwds_15_tfmaildesignestado_sels = AV45TFMailDesignEstado_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12B62( )
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
            AV47PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV47PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13B62( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E16B62( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MailDesignId") == 0 )
            {
               AV38TFMailDesignId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV38TFMailDesignId", StringUtil.LTrimStr( (decimal)(AV38TFMailDesignId), 18, 0));
               AV39TFMailDesignId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39TFMailDesignId_To", StringUtil.LTrimStr( (decimal)(AV39TFMailDesignId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MailDesignTipo") == 0 )
            {
               AV40TFMailDesignTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFMailDesignTipo_SelsJson", AV40TFMailDesignTipo_SelsJson);
               AV41TFMailDesignTipo_Sels.FromJSonString(AV40TFMailDesignTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MailDesignAsunto") == 0 )
            {
               AV42TFMailDesignAsunto = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFMailDesignAsunto", AV42TFMailDesignAsunto);
               AV43TFMailDesignAsunto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFMailDesignAsunto_Sel", AV43TFMailDesignAsunto_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MailDesignEstado") == 0 )
            {
               AV44TFMailDesignEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFMailDesignEstado_SelsJson", AV44TFMailDesignEstado_SelsJson);
               AV45TFMailDesignEstado_Sels.FromJSonString(AV44TFMailDesignEstado_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41TFMailDesignTipo_Sels", AV41TFMailDesignTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45TFMailDesignEstado_Sels", AV45TFMailDesignEstado_Sels);
      }

      private void E29B62( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV52IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV53IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 102;
            }
            sendrow_1022( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_102_Refreshing )
         {
            context.DoAjaxLoad(102, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0));
      }

      protected void E17B62( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV30ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV32ColumnsSelector.FromJSonString(AV30ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "MailDesignWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV30ColumnsSelectorXML)) ? "" : AV32ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E22B62( )
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

      protected void E18B62( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19MailDesignTipo1, AV21DynamicFiltersSelector2, AV22MailDesignTipo2, AV24DynamicFiltersSelector3, AV25MailDesignTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV57Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFMailDesignId, AV39TFMailDesignId_To, AV41TFMailDesignTipo_Sels, AV42TFMailDesignAsunto, AV43TFMailDesignAsunto_Sel, AV45TFMailDesignEstado_Sels, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV52IsAuthorized_Update, AV53IsAuthorized_Delete) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavMaildesigntipo2.CurrentValue = StringUtil.RTrim( AV22MailDesignTipo2);
         AssignProp("", false, cmbavMaildesigntipo2_Internalname, "Values", cmbavMaildesigntipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavMaildesigntipo3.CurrentValue = StringUtil.RTrim( AV25MailDesignTipo3);
         AssignProp("", false, cmbavMaildesigntipo3_Internalname, "Values", cmbavMaildesigntipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavMaildesigntipo1.CurrentValue = StringUtil.RTrim( AV19MailDesignTipo1);
         AssignProp("", false, cmbavMaildesigntipo1_Internalname, "Values", cmbavMaildesigntipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E23B62( )
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

      protected void E24B62( )
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

      protected void E19B62( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19MailDesignTipo1, AV21DynamicFiltersSelector2, AV22MailDesignTipo2, AV24DynamicFiltersSelector3, AV25MailDesignTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV57Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFMailDesignId, AV39TFMailDesignId_To, AV41TFMailDesignTipo_Sels, AV42TFMailDesignAsunto, AV43TFMailDesignAsunto_Sel, AV45TFMailDesignEstado_Sels, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV52IsAuthorized_Update, AV53IsAuthorized_Delete) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavMaildesigntipo2.CurrentValue = StringUtil.RTrim( AV22MailDesignTipo2);
         AssignProp("", false, cmbavMaildesigntipo2_Internalname, "Values", cmbavMaildesigntipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavMaildesigntipo3.CurrentValue = StringUtil.RTrim( AV25MailDesignTipo3);
         AssignProp("", false, cmbavMaildesigntipo3_Internalname, "Values", cmbavMaildesigntipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavMaildesigntipo1.CurrentValue = StringUtil.RTrim( AV19MailDesignTipo1);
         AssignProp("", false, cmbavMaildesigntipo1_Internalname, "Values", cmbavMaildesigntipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E25B62( )
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

      protected void E20B62( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19MailDesignTipo1, AV21DynamicFiltersSelector2, AV22MailDesignTipo2, AV24DynamicFiltersSelector3, AV25MailDesignTipo3, AV37ManageFiltersExecutionStep, AV32ColumnsSelector, AV57Pgmname, AV17FilterFullText, AV20DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV38TFMailDesignId, AV39TFMailDesignId_To, AV41TFMailDesignTipo_Sels, AV42TFMailDesignAsunto, AV43TFMailDesignAsunto_Sel, AV45TFMailDesignEstado_Sels, AV11GridState, AV27DynamicFiltersIgnoreFirst, AV26DynamicFiltersRemoving, AV52IsAuthorized_Update, AV53IsAuthorized_Delete) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavMaildesigntipo2.CurrentValue = StringUtil.RTrim( AV22MailDesignTipo2);
         AssignProp("", false, cmbavMaildesigntipo2_Internalname, "Values", cmbavMaildesigntipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavMaildesigntipo3.CurrentValue = StringUtil.RTrim( AV25MailDesignTipo3);
         AssignProp("", false, cmbavMaildesigntipo3_Internalname, "Values", cmbavMaildesigntipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavMaildesigntipo1.CurrentValue = StringUtil.RTrim( AV19MailDesignTipo1);
         AssignProp("", false, cmbavMaildesigntipo1_Internalname, "Values", cmbavMaildesigntipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E26B62( )
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

      protected void E11B62( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("MailDesignWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV57Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("MailDesignWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV36ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "MailDesignWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV57Pgmname+"GridState",  AV36ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41TFMailDesignTipo_Sels", AV41TFMailDesignTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45TFMailDesignEstado_Sels", AV45TFMailDesignEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavMaildesigntipo1.CurrentValue = StringUtil.RTrim( AV19MailDesignTipo1);
         AssignProp("", false, cmbavMaildesigntipo1_Internalname, "Values", cmbavMaildesigntipo1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavMaildesigntipo2.CurrentValue = StringUtil.RTrim( AV22MailDesignTipo2);
         AssignProp("", false, cmbavMaildesigntipo2_Internalname, "Values", cmbavMaildesigntipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavMaildesigntipo3.CurrentValue = StringUtil.RTrim( AV25MailDesignTipo3);
         AssignProp("", false, cmbavMaildesigntipo3_Internalname, "Values", cmbavMaildesigntipo3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E30B62( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV51GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV51GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV51GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV51GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV51GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E21B62( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "maildesign.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("maildesign.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14B62( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45TFMailDesignEstado_Sels", AV45TFMailDesignEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41TFMailDesignTipo_Sels", AV41TFMailDesignTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavMaildesigntipo1.CurrentValue = StringUtil.RTrim( AV19MailDesignTipo1);
         AssignProp("", false, cmbavMaildesigntipo1_Internalname, "Values", cmbavMaildesigntipo1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavMaildesigntipo2.CurrentValue = StringUtil.RTrim( AV22MailDesignTipo2);
         AssignProp("", false, cmbavMaildesigntipo2_Internalname, "Values", cmbavMaildesigntipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavMaildesigntipo3.CurrentValue = StringUtil.RTrim( AV25MailDesignTipo3);
         AssignProp("", false, cmbavMaildesigntipo3_Internalname, "Values", cmbavMaildesigntipo3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ColumnsSelector", AV32ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E15B62( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0122",(string)"",(string)"MailDesign",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0122"+"");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "MailDesignId",  "",  "Identificador",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "MailDesignTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "MailDesignAsunto",  "",  "Asunto",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV32ColumnsSelector,  "MailDesignEstado",  "",  "Estado",  true,  "") ;
         GXt_char2 = AV31UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "MailDesignWWColumnsSelector", out  GXt_char2) ;
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
         GXt_boolean3 = AV52IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailDesign_Update", out  GXt_boolean3) ;
         AV52IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV52IsAuthorized_Update", AV52IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV52IsAuthorized_Update, context));
         GXt_boolean3 = AV53IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailDesign_Delete", out  GXt_boolean3) ;
         AV53IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV53IsAuthorized_Delete", AV53IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV53IsAuthorized_Delete, context));
         GXt_boolean3 = AV56TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailDesign_Insert", out  GXt_boolean3) ;
         AV56TempBoolean = GXt_boolean3;
         if ( ! ( AV56TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean3 = AV56TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean3) ;
         AV56TempBoolean = GXt_boolean3;
         if ( ! ( AV56TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "MailDesign",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         cmbavMaildesigntipo1.Visible = 0;
         AssignProp("", false, cmbavMaildesigntipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMaildesigntipo1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MAILDESIGNTIPO") == 0 )
         {
            cmbavMaildesigntipo1.Visible = 1;
            AssignProp("", false, cmbavMaildesigntipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMaildesigntipo1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavMaildesigntipo2.Visible = 0;
         AssignProp("", false, cmbavMaildesigntipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMaildesigntipo2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "MAILDESIGNTIPO") == 0 )
         {
            cmbavMaildesigntipo2.Visible = 1;
            AssignProp("", false, cmbavMaildesigntipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMaildesigntipo2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavMaildesigntipo3.Visible = 0;
         AssignProp("", false, cmbavMaildesigntipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMaildesigntipo3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "MAILDESIGNTIPO") == 0 )
         {
            cmbavMaildesigntipo3.Visible = 1;
            AssignProp("", false, cmbavMaildesigntipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMaildesigntipo3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "MAILDESIGNTIPO";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV22MailDesignTipo2 = "";
         AssignAttri("", false, "AV22MailDesignTipo2", AV22MailDesignTipo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "MAILDESIGNTIPO";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25MailDesignTipo3 = "";
         AssignAttri("", false, "AV25MailDesignTipo3", AV25MailDesignTipo3);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "MailDesignWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV35ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV38TFMailDesignId = 0;
         AssignAttri("", false, "AV38TFMailDesignId", StringUtil.LTrimStr( (decimal)(AV38TFMailDesignId), 18, 0));
         AV39TFMailDesignId_To = 0;
         AssignAttri("", false, "AV39TFMailDesignId_To", StringUtil.LTrimStr( (decimal)(AV39TFMailDesignId_To), 18, 0));
         AV41TFMailDesignTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42TFMailDesignAsunto = "";
         AssignAttri("", false, "AV42TFMailDesignAsunto", AV42TFMailDesignAsunto);
         AV43TFMailDesignAsunto_Sel = "";
         AssignAttri("", false, "AV43TFMailDesignAsunto_Sel", AV43TFMailDesignAsunto_Sel);
         AV45TFMailDesignEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "MAILDESIGNTIPO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19MailDesignTipo1 = "";
         AssignAttri("", false, "AV19MailDesignTipo1", AV19MailDesignTipo1);
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
         GXEncryptionTmp = "maildesign.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A148MailDesignId,18,0));
         CallWebObject(formatLink("maildesign.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "maildesign.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A148MailDesignId,18,0));
         CallWebObject(formatLink("maildesign.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "maildesign.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A148MailDesignId,18,0));
         CallWebObject(formatLink("maildesign.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get(AV57Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV57Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV34Session.Get(AV57Pgmname+"GridState"), null, "", "");
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
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV73GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNID") == 0 )
            {
               AV38TFMailDesignId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV38TFMailDesignId", StringUtil.LTrimStr( (decimal)(AV38TFMailDesignId), 18, 0));
               AV39TFMailDesignId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39TFMailDesignId_To", StringUtil.LTrimStr( (decimal)(AV39TFMailDesignId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNTIPO_SEL") == 0 )
            {
               AV40TFMailDesignTipo_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFMailDesignTipo_SelsJson", AV40TFMailDesignTipo_SelsJson);
               AV41TFMailDesignTipo_Sels.FromJSonString(AV40TFMailDesignTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNASUNTO") == 0 )
            {
               AV42TFMailDesignAsunto = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFMailDesignAsunto", AV42TFMailDesignAsunto);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNASUNTO_SEL") == 0 )
            {
               AV43TFMailDesignAsunto_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFMailDesignAsunto_Sel", AV43TFMailDesignAsunto_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNESTADO_SEL") == 0 )
            {
               AV44TFMailDesignEstado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFMailDesignEstado_SelsJson", AV44TFMailDesignEstado_SelsJson);
               AV45TFMailDesignEstado_Sels.FromJSonString(AV44TFMailDesignEstado_SelsJson, null);
            }
            AV73GXV1 = (int)(AV73GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV41TFMailDesignTipo_Sels.Count==0),  AV40TFMailDesignTipo_SelsJson, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFMailDesignAsunto_Sel)),  AV43TFMailDesignAsunto_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV45TFMailDesignEstado_Sels.Count==0),  AV44TFMailDesignEstado_SelsJson, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMailDesignAsunto)),  AV42TFMailDesignAsunto, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = ((0==AV38TFMailDesignId) ? "" : StringUtil.Str( (decimal)(AV38TFMailDesignId), 18, 0))+"||"+GXt_char6+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV39TFMailDesignId_To) ? "" : StringUtil.Str( (decimal)(AV39TFMailDesignId_To), 18, 0))+"|||";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MAILDESIGNTIPO") == 0 )
            {
               AV19MailDesignTipo1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19MailDesignTipo1", AV19MailDesignTipo1);
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
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "MAILDESIGNTIPO") == 0 )
               {
                  AV22MailDesignTipo2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV22MailDesignTipo2", AV22MailDesignTipo2);
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
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "MAILDESIGNTIPO") == 0 )
                  {
                     AV25MailDesignTipo3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV25MailDesignTipo3", AV25MailDesignTipo3);
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
         AV11GridState.FromXml(AV34Session.Get(AV57Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMAILDESIGNID",  context.GetMessage( "Identificador", ""),  !((0==AV38TFMailDesignId)&&(0==AV39TFMailDesignId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV38TFMailDesignId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV39TFMailDesignId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMAILDESIGNTIPO_SEL",  context.GetMessage( "Tipo", ""),  !(AV41TFMailDesignTipo_Sels.Count==0),  0,  AV41TFMailDesignTipo_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMAILDESIGNASUNTO",  context.GetMessage( "Asunto", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMailDesignAsunto)),  0,  AV42TFMailDesignAsunto,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFMailDesignAsunto_Sel)),  AV43TFMailDesignAsunto_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMAILDESIGNESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV45TFMailDesignEstado_Sels.Count==0),  0,  AV45TFMailDesignEstado_Sels.ToJSonString(false),  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV57Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MAILDESIGNTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19MailDesignTipo1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Tipo", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV19MailDesignTipo1;
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
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "MAILDESIGNTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22MailDesignTipo2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Tipo", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV22MailDesignTipo2;
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
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "MAILDESIGNTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25MailDesignTipo3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Tipo", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV25MailDesignTipo3;
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
         AV9TrnContext.gxTpr_Callerobject = AV57Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "MailDesign";
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
         new maildesignwwexport(context ).execute( out  AV28ExcelFilename, out  AV29ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("maildesignwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_87_B62( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_3_Internalname, tblUnnamedtabledynamicfilters_3_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_maildesigntipo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMaildesigntipo3_Internalname, context.GetMessage( "Mail Design Tipo3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMaildesigntipo3, cmbavMaildesigntipo3_Internalname, StringUtil.RTrim( AV25MailDesignTipo3), 1, cmbavMaildesigntipo3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavMaildesigntipo3.Visible, cmbavMaildesigntipo3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_MailDesignWW.htm");
            cmbavMaildesigntipo3.CurrentValue = StringUtil.RTrim( AV25MailDesignTipo3);
            AssignProp("", false, cmbavMaildesigntipo3_Internalname, "Values", (string)(cmbavMaildesigntipo3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MailDesignWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_87_B62e( true) ;
         }
         else
         {
            wb_table4_87_B62e( false) ;
         }
      }

      protected void wb_table3_68_B62( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_2_Internalname, tblUnnamedtabledynamicfilters_2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_maildesigntipo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMaildesigntipo2_Internalname, context.GetMessage( "Mail Design Tipo2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMaildesigntipo2, cmbavMaildesigntipo2_Internalname, StringUtil.RTrim( AV22MailDesignTipo2), 1, cmbavMaildesigntipo2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavMaildesigntipo2.Visible, cmbavMaildesigntipo2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_MailDesignWW.htm");
            cmbavMaildesigntipo2.CurrentValue = StringUtil.RTrim( AV22MailDesignTipo2);
            AssignProp("", false, cmbavMaildesigntipo2_Internalname, "Values", (string)(cmbavMaildesigntipo2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MailDesignWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MailDesignWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_68_B62e( true) ;
         }
         else
         {
            wb_table3_68_B62e( false) ;
         }
      }

      protected void wb_table2_49_B62( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_1_Internalname, tblUnnamedtabledynamicfilters_1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_maildesigntipo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMaildesigntipo1_Internalname, context.GetMessage( "Mail Design Tipo1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMaildesigntipo1, cmbavMaildesigntipo1_Internalname, StringUtil.RTrim( AV19MailDesignTipo1), 1, cmbavMaildesigntipo1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavMaildesigntipo1.Visible, cmbavMaildesigntipo1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_MailDesignWW.htm");
            cmbavMaildesigntipo1.CurrentValue = StringUtil.RTrim( AV19MailDesignTipo1);
            AssignProp("", false, cmbavMaildesigntipo1_Internalname, "Values", (string)(cmbavMaildesigntipo1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MailDesignWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MailDesignWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_B62e( true) ;
         }
         else
         {
            wb_table2_49_B62e( false) ;
         }
      }

      protected void wb_table1_25_B62( bool wbgen )
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
            wb_table5_30_B62( true) ;
         }
         else
         {
            wb_table5_30_B62( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_B62e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_B62e( true) ;
         }
         else
         {
            wb_table1_25_B62e( false) ;
         }
      }

      protected void wb_table5_30_B62( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_102_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_MailDesignWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_B62e( true) ;
         }
         else
         {
            wb_table5_30_B62e( false) ;
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
         PAB62( ) ;
         WSB62( ) ;
         WEB62( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021222572", true, true, false);
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
         context.AddJavascriptSource("maildesignww.js", "?202673021222572", false, true, false);
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

      protected void SubsflControlProps_1022( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_102_idx;
         edtMailDesignId_Internalname = "MAILDESIGNID_"+sGXsfl_102_idx;
         cmbMailDesignTipo_Internalname = "MAILDESIGNTIPO_"+sGXsfl_102_idx;
         edtMailDesignAsunto_Internalname = "MAILDESIGNASUNTO_"+sGXsfl_102_idx;
         cmbMailDesignEstado_Internalname = "MAILDESIGNESTADO_"+sGXsfl_102_idx;
      }

      protected void SubsflControlProps_fel_1022( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_102_fel_idx;
         edtMailDesignId_Internalname = "MAILDESIGNID_"+sGXsfl_102_fel_idx;
         cmbMailDesignTipo_Internalname = "MAILDESIGNTIPO_"+sGXsfl_102_fel_idx;
         edtMailDesignAsunto_Internalname = "MAILDESIGNASUNTO_"+sGXsfl_102_fel_idx;
         cmbMailDesignEstado_Internalname = "MAILDESIGNESTADO_"+sGXsfl_102_fel_idx;
      }

      protected void sendrow_1022( )
      {
         sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
         SubsflControlProps_1022( ) ;
         WBB60( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_102_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_102_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_102_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_102_idx + "',102)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_102_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV51GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV51GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_102_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_102_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtMailDesignId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMailDesignId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A148MailDesignId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A148MailDesignId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMailDesignId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMailDesignId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)102,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbMailDesignTipo.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbMailDesignTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MAILDESIGNTIPO_" + sGXsfl_102_idx;
               cmbMailDesignTipo.Name = GXCCtl;
               cmbMailDesignTipo.WebTags = "";
               cmbMailDesignTipo.addItem("A", context.GetMessage( "Publicidad", ""), 0);
               cmbMailDesignTipo.addItem("R", context.GetMessage( "Recuperar Usuario y Contraseña", ""), 0);
               cmbMailDesignTipo.addItem("N", context.GetMessage( "Notificación", ""), 0);
               cmbMailDesignTipo.addItem("O", context.GetMessage( "Otros", ""), 0);
               if ( cmbMailDesignTipo.ItemCount > 0 )
               {
                  A244MailDesignTipo = cmbMailDesignTipo.getValidValue(A244MailDesignTipo);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMailDesignTipo,(string)cmbMailDesignTipo_Internalname,StringUtil.RTrim( A244MailDesignTipo),(short)1,(string)cmbMailDesignTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbMailDesignTipo.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMailDesignTipo.CurrentValue = StringUtil.RTrim( A244MailDesignTipo);
            AssignProp("", false, cmbMailDesignTipo_Internalname, "Values", (string)(cmbMailDesignTipo.ToJavascriptSource()), !bGXsfl_102_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMailDesignAsunto_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMailDesignAsunto_Internalname,StringUtil.RTrim( A246MailDesignAsunto),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMailDesignAsunto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMailDesignAsunto_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)102,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbMailDesignEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbMailDesignEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MAILDESIGNESTADO_" + sGXsfl_102_idx;
               cmbMailDesignEstado.Name = GXCCtl;
               cmbMailDesignEstado.WebTags = "";
               cmbMailDesignEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbMailDesignEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               if ( cmbMailDesignEstado.ItemCount > 0 )
               {
                  A245MailDesignEstado = cmbMailDesignEstado.getValidValue(A245MailDesignEstado);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMailDesignEstado,(string)cmbMailDesignEstado_Internalname,StringUtil.RTrim( A245MailDesignEstado),(short)1,(string)cmbMailDesignEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbMailDesignEstado.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbMailDesignEstado.CurrentValue = StringUtil.RTrim( A245MailDesignEstado);
            AssignProp("", false, cmbMailDesignEstado_Internalname, "Values", (string)(cmbMailDesignEstado.ToJavascriptSource()), !bGXsfl_102_Refreshing);
            send_integrity_lvl_hashesB62( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_102_idx = ((subGrid_Islastpage==1)&&(nGXsfl_102_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_102_idx+1);
            sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
            SubsflControlProps_1022( ) ;
         }
         /* End function sendrow_1022 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("MAILDESIGNTIPO", context.GetMessage( "Tipo", ""), 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavMaildesigntipo1.Name = "vMAILDESIGNTIPO1";
         cmbavMaildesigntipo1.WebTags = "";
         cmbavMaildesigntipo1.addItem("", context.GetMessage( "WWP_AllInCombo", ""), 0);
         cmbavMaildesigntipo1.addItem("A", context.GetMessage( "Publicidad", ""), 0);
         cmbavMaildesigntipo1.addItem("R", context.GetMessage( "Recuperar Usuario y Contraseña", ""), 0);
         cmbavMaildesigntipo1.addItem("N", context.GetMessage( "Notificación", ""), 0);
         cmbavMaildesigntipo1.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbavMaildesigntipo1.ItemCount > 0 )
         {
            AV19MailDesignTipo1 = cmbavMaildesigntipo1.getValidValue(AV19MailDesignTipo1);
            AssignAttri("", false, "AV19MailDesignTipo1", AV19MailDesignTipo1);
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("MAILDESIGNTIPO", context.GetMessage( "Tipo", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         cmbavMaildesigntipo2.Name = "vMAILDESIGNTIPO2";
         cmbavMaildesigntipo2.WebTags = "";
         cmbavMaildesigntipo2.addItem("", context.GetMessage( "WWP_AllInCombo", ""), 0);
         cmbavMaildesigntipo2.addItem("A", context.GetMessage( "Publicidad", ""), 0);
         cmbavMaildesigntipo2.addItem("R", context.GetMessage( "Recuperar Usuario y Contraseña", ""), 0);
         cmbavMaildesigntipo2.addItem("N", context.GetMessage( "Notificación", ""), 0);
         cmbavMaildesigntipo2.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbavMaildesigntipo2.ItemCount > 0 )
         {
            AV22MailDesignTipo2 = cmbavMaildesigntipo2.getValidValue(AV22MailDesignTipo2);
            AssignAttri("", false, "AV22MailDesignTipo2", AV22MailDesignTipo2);
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("MAILDESIGNTIPO", context.GetMessage( "Tipo", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         cmbavMaildesigntipo3.Name = "vMAILDESIGNTIPO3";
         cmbavMaildesigntipo3.WebTags = "";
         cmbavMaildesigntipo3.addItem("", context.GetMessage( "WWP_AllInCombo", ""), 0);
         cmbavMaildesigntipo3.addItem("A", context.GetMessage( "Publicidad", ""), 0);
         cmbavMaildesigntipo3.addItem("R", context.GetMessage( "Recuperar Usuario y Contraseña", ""), 0);
         cmbavMaildesigntipo3.addItem("N", context.GetMessage( "Notificación", ""), 0);
         cmbavMaildesigntipo3.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbavMaildesigntipo3.ItemCount > 0 )
         {
            AV25MailDesignTipo3 = cmbavMaildesigntipo3.getValidValue(AV25MailDesignTipo3);
            AssignAttri("", false, "AV25MailDesignTipo3", AV25MailDesignTipo3);
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_102_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV51GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV51GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV51GridActions), 4, 0));
         }
         GXCCtl = "MAILDESIGNTIPO_" + sGXsfl_102_idx;
         cmbMailDesignTipo.Name = GXCCtl;
         cmbMailDesignTipo.WebTags = "";
         cmbMailDesignTipo.addItem("A", context.GetMessage( "Publicidad", ""), 0);
         cmbMailDesignTipo.addItem("R", context.GetMessage( "Recuperar Usuario y Contraseña", ""), 0);
         cmbMailDesignTipo.addItem("N", context.GetMessage( "Notificación", ""), 0);
         cmbMailDesignTipo.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbMailDesignTipo.ItemCount > 0 )
         {
            A244MailDesignTipo = cmbMailDesignTipo.getValidValue(A244MailDesignTipo);
         }
         GXCCtl = "MAILDESIGNESTADO_" + sGXsfl_102_idx;
         cmbMailDesignEstado.Name = GXCCtl;
         cmbMailDesignEstado.WebTags = "";
         cmbMailDesignEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMailDesignEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbMailDesignEstado.ItemCount > 0 )
         {
            A245MailDesignEstado = cmbMailDesignEstado.getValidValue(A245MailDesignEstado);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl102( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"102\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMailDesignId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbMailDesignTipo.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMailDesignAsunto_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Asunto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbMailDesignEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A148MailDesignId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMailDesignId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A244MailDesignTipo)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMailDesignTipo.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A246MailDesignAsunto)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMailDesignAsunto_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A245MailDesignEstado)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMailDesignEstado.Visible), 5, 0, ".", "")));
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
         cmbavMaildesigntipo1_Internalname = "vMAILDESIGNTIPO1";
         cellFilter_maildesigntipo1_cell_Internalname = "FILTER_MAILDESIGNTIPO1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblUnnamedtabledynamicfilters_1_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavMaildesigntipo2_Internalname = "vMAILDESIGNTIPO2";
         cellFilter_maildesigntipo2_cell_Internalname = "FILTER_MAILDESIGNTIPO2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblUnnamedtabledynamicfilters_2_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavMaildesigntipo3_Internalname = "vMAILDESIGNTIPO3";
         cellFilter_maildesigntipo3_cell_Internalname = "FILTER_MAILDESIGNTIPO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblUnnamedtabledynamicfilters_3_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtMailDesignId_Internalname = "MAILDESIGNID";
         cmbMailDesignTipo_Internalname = "MAILDESIGNTIPO";
         edtMailDesignAsunto_Internalname = "MAILDESIGNASUNTO";
         cmbMailDesignEstado_Internalname = "MAILDESIGNESTADO";
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
         cmbMailDesignEstado_Jsonclick = "";
         edtMailDesignAsunto_Jsonclick = "";
         cmbMailDesignTipo_Jsonclick = "";
         edtMailDesignId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         cmbavMaildesigntipo1_Jsonclick = "";
         cmbavMaildesigntipo1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         cmbavMaildesigntipo2_Jsonclick = "";
         cmbavMaildesigntipo2.Enabled = 1;
         cmbavMaildesigntipo3_Jsonclick = "";
         cmbavMaildesigntipo3.Enabled = 1;
         cmbavMaildesigntipo3.Visible = 1;
         cmbavMaildesigntipo2.Visible = 1;
         cmbavMaildesigntipo1.Visible = 1;
         cmbMailDesignEstado.Visible = -1;
         edtMailDesignAsunto_Visible = -1;
         cmbMailDesignTipo.Visible = -1;
         edtMailDesignId_Visible = -1;
         cmbMailDesignEstado.Enabled = 0;
         edtMailDesignAsunto_Enabled = 0;
         cmbMailDesignTipo.Enabled = 0;
         edtMailDesignId_Enabled = 0;
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
         Grid_empowerer_Fixedcolumns = "L;;;;";
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
         Ddo_grid_Format = "18.0|||";
         Ddo_grid_Datalistproc = "MailDesignWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|A:Publicidad,R:Recuperar Usuario y Contraseña,N:Notificación,O:Otros||HAB:Habilitado,DES:Deshabilitado";
         Ddo_grid_Allowmultipleselection = "|T||T";
         Ddo_grid_Datalisttype = "|FixedValues|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "|T|T|T";
         Ddo_grid_Filterisrange = "T|||";
         Ddo_grid_Filtertype = "Numeric||Character|";
         Ddo_grid_Includefilter = "T||T|";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4";
         Ddo_grid_Columnids = "1:MailDesignId|2:MailDesignTipo|3:MailDesignAsunto|4:MailDesignEstado";
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
         Form.Caption = context.GetMessage( " Mail Design", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMailDesignId_Visible',ctrl:'MAILDESIGNID',prop:'Visible'},{av:'cmbMailDesignTipo'},{av:'edtMailDesignAsunto_Visible',ctrl:'MAILDESIGNASUNTO',prop:'Visible'},{av:'cmbMailDesignEstado'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12B62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMailDesignId_Visible',ctrl:'MAILDESIGNID',prop:'Visible'},{av:'cmbMailDesignTipo'},{av:'edtMailDesignAsunto_Visible',ctrl:'MAILDESIGNASUNTO',prop:'Visible'},{av:'cmbMailDesignEstado'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13B62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E16B62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV40TFMailDesignTipo_SelsJson',fld:'vTFMAILDESIGNTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV44TFMailDesignEstado_SelsJson',fld:'vTFMAILDESIGNESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E29B62',iparms:[{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV51GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E17B62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'edtMailDesignId_Visible',ctrl:'MAILDESIGNID',prop:'Visible'},{av:'cmbMailDesignTipo'},{av:'edtMailDesignAsunto_Visible',ctrl:'MAILDESIGNASUNTO',prop:'Visible'},{av:'cmbMailDesignEstado'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E22B62',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E18B62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMailDesignId_Visible',ctrl:'MAILDESIGNID',prop:'Visible'},{av:'cmbMailDesignTipo'},{av:'edtMailDesignAsunto_Visible',ctrl:'MAILDESIGNASUNTO',prop:'Visible'},{av:'cmbMailDesignEstado'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E23B62',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavMaildesigntipo1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E24B62',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E19B62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMailDesignId_Visible',ctrl:'MAILDESIGNID',prop:'Visible'},{av:'cmbMailDesignTipo'},{av:'edtMailDesignAsunto_Visible',ctrl:'MAILDESIGNASUNTO',prop:'Visible'},{av:'cmbMailDesignEstado'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E25B62',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavMaildesigntipo2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E20B62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMailDesignId_Visible',ctrl:'MAILDESIGNID',prop:'Visible'},{av:'cmbMailDesignTipo'},{av:'edtMailDesignAsunto_Visible',ctrl:'MAILDESIGNASUNTO',prop:'Visible'},{av:'cmbMailDesignEstado'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E26B62',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavMaildesigntipo3'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11B62',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV40TFMailDesignTipo_SelsJson',fld:'vTFMAILDESIGNTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV44TFMailDesignEstado_SelsJson',fld:'vTFMAILDESIGNESTADO_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV44TFMailDesignEstado_SelsJson',fld:'vTFMAILDESIGNESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV40TFMailDesignTipo_SelsJson',fld:'vTFMAILDESIGNTIPO_SELSJSON',pic:'',type:'vchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMailDesignId_Visible',ctrl:'MAILDESIGNID',prop:'Visible'},{av:'cmbMailDesignTipo'},{av:'edtMailDesignAsunto_Visible',ctrl:'MAILDESIGNASUNTO',prop:'Visible'},{av:'cmbMailDesignEstado'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E30B62',iparms:[{av:'cmbavGridactions'},{av:'AV51GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A148MailDesignId',fld:'MAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV51GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E21B62',iparms:[{av:'A148MailDesignId',fld:'MAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14B62',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV40TFMailDesignTipo_SelsJson',fld:'vTFMAILDESIGNTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'AV44TFMailDesignEstado_SelsJson',fld:'vTFMAILDESIGNESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo1'},{av:'AV19MailDesignTipo1',fld:'vMAILDESIGNTIPO1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo2'},{av:'AV22MailDesignTipo2',fld:'vMAILDESIGNTIPO2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV24DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavMaildesigntipo3'},{av:'AV25MailDesignTipo3',fld:'vMAILDESIGNTIPO3',pic:'',type:'char'},{av:'AV37ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV57Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38TFMailDesignId',fld:'vTFMAILDESIGNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFMailDesignId_To',fld:'vTFMAILDESIGNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFMailDesignTipo_Sels',fld:'vTFMAILDESIGNTIPO_SELS',pic:''},{av:'AV42TFMailDesignAsunto',fld:'vTFMAILDESIGNASUNTO',pic:'',type:'char'},{av:'AV43TFMailDesignAsunto_Sel',fld:'vTFMAILDESIGNASUNTO_SEL',pic:'',type:'char'},{av:'AV45TFMailDesignEstado_Sels',fld:'vTFMAILDESIGNESTADO_SELS',pic:''},{av:'AV27DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV26DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV52IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV44TFMailDesignEstado_SelsJson',fld:'vTFMAILDESIGNESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV40TFMailDesignTipo_SelsJson',fld:'vTFMAILDESIGNTIPO_SELSJSON',pic:'',type:'vchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtMailDesignId_Visible',ctrl:'MAILDESIGNID',prop:'Visible'},{av:'cmbMailDesignTipo'},{av:'edtMailDesignAsunto_Visible',ctrl:'MAILDESIGNASUNTO',prop:'Visible'},{av:'cmbMailDesignEstado'},{av:'AV48GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV49GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV35ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E15B62',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALID_MAILDESIGNID","{handler:'Valid_Maildesignid',iparms:[]");
         setEventMetadata("VALID_MAILDESIGNID",",oparms:[]}");
         setEventMetadata("VALID_MAILDESIGNTIPO","{handler:'Valid_Maildesigntipo',iparms:[]");
         setEventMetadata("VALID_MAILDESIGNTIPO",",oparms:[]}");
         setEventMetadata("VALID_MAILDESIGNASUNTO","{handler:'Valid_Maildesignasunto',iparms:[]");
         setEventMetadata("VALID_MAILDESIGNASUNTO",",oparms:[]}");
         setEventMetadata("VALID_MAILDESIGNESTADO","{handler:'Valid_Maildesignestado',iparms:[]");
         setEventMetadata("VALID_MAILDESIGNESTADO",",oparms:[]}");
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
         AV18DynamicFiltersSelector1 = "";
         AV19MailDesignTipo1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV22MailDesignTipo2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV25MailDesignTipo3 = "";
         AV32ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV57Pgmname = "";
         AV17FilterFullText = "";
         AV41TFMailDesignTipo_Sels = new GxSimpleCollection<string>();
         AV42TFMailDesignAsunto = "";
         AV43TFMailDesignAsunto_Sel = "";
         AV45TFMailDesignEstado_Sels = new GxSimpleCollection<string>();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV35ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV50GridAppliedFilters = "";
         AV54AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV40TFMailDesignTipo_SelsJson = "";
         AV44TFMailDesignEstado_SelsJson = "";
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
         A244MailDesignTipo = "";
         A246MailDesignAsunto = "";
         A245MailDesignEstado = "";
         AV58Maildesignwwds_1_filterfulltext = "";
         AV59Maildesignwwds_2_dynamicfiltersselector1 = "";
         AV60Maildesignwwds_3_maildesigntipo1 = "";
         AV62Maildesignwwds_5_dynamicfiltersselector2 = "";
         AV63Maildesignwwds_6_maildesigntipo2 = "";
         AV65Maildesignwwds_8_dynamicfiltersselector3 = "";
         AV66Maildesignwwds_9_maildesigntipo3 = "";
         AV69Maildesignwwds_12_tfmaildesigntipo_sels = new GxSimpleCollection<string>();
         AV70Maildesignwwds_13_tfmaildesignasunto = "";
         AV71Maildesignwwds_14_tfmaildesignasunto_sel = "";
         AV72Maildesignwwds_15_tfmaildesignestado_sels = new GxSimpleCollection<string>();
         lV70Maildesignwwds_13_tfmaildesignasunto = "";
         H00B62_A245MailDesignEstado = new string[] {""} ;
         H00B62_A246MailDesignAsunto = new string[] {""} ;
         H00B62_A244MailDesignTipo = new string[] {""} ;
         H00B62_A148MailDesignId = new long[1] ;
         H00B63_A245MailDesignEstado = new string[] {""} ;
         H00B63_A246MailDesignAsunto = new string[] {""} ;
         H00B63_A244MailDesignTipo = new string[] {""} ;
         H00B63_A148MailDesignId = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV55AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.maildesignww__default(),
            new Object[][] {
                new Object[] {
               H00B62_A245MailDesignEstado, H00B62_A246MailDesignAsunto, H00B62_A244MailDesignTipo, H00B62_A148MailDesignId
               }
               , new Object[] {
               H00B63_A245MailDesignEstado, H00B63_A246MailDesignAsunto, H00B63_A244MailDesignTipo, H00B63_A148MailDesignId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV57Pgmname = "MailDesignWW";
         /* GeneXus formulas. */
         AV57Pgmname = "MailDesignWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV37ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV51GridActions ;
      private short nCmpId ;
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
      private int nRC_GXsfl_102 ;
      private int nGXsfl_102_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int AV69Maildesignwwds_12_tfmaildesigntipo_sels_Count ;
      private int AV72Maildesignwwds_15_tfmaildesignestado_sels_Count ;
      private int edtMailDesignId_Enabled ;
      private int edtMailDesignAsunto_Enabled ;
      private int edtMailDesignId_Visible ;
      private int edtMailDesignAsunto_Visible ;
      private int AV47PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int AV73GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV38TFMailDesignId ;
      private long AV39TFMailDesignId_To ;
      private long AV48GridCurrentPage ;
      private long AV49GridPageCount ;
      private long A148MailDesignId ;
      private long GRID_nCurrentRecord ;
      private long AV67Maildesignwwds_10_tfmaildesignid ;
      private long AV68Maildesignwwds_11_tfmaildesignid_to ;
      private long GRID_nRecordCount ;
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
      private string sGXsfl_102_idx="0001" ;
      private string AV19MailDesignTipo1 ;
      private string AV22MailDesignTipo2 ;
      private string AV25MailDesignTipo3 ;
      private string AV57Pgmname ;
      private string AV42TFMailDesignAsunto ;
      private string AV43TFMailDesignAsunto_Sel ;
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
      private string edtMailDesignId_Internalname ;
      private string cmbMailDesignTipo_Internalname ;
      private string A244MailDesignTipo ;
      private string A246MailDesignAsunto ;
      private string edtMailDesignAsunto_Internalname ;
      private string cmbMailDesignEstado_Internalname ;
      private string A245MailDesignEstado ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavMaildesigntipo1_Internalname ;
      private string cmbavMaildesigntipo2_Internalname ;
      private string cmbavMaildesigntipo3_Internalname ;
      private string AV60Maildesignwwds_3_maildesigntipo1 ;
      private string AV63Maildesignwwds_6_maildesigntipo2 ;
      private string AV66Maildesignwwds_9_maildesigntipo3 ;
      private string AV70Maildesignwwds_13_tfmaildesignasunto ;
      private string AV71Maildesignwwds_14_tfmaildesignasunto_sel ;
      private string lV70Maildesignwwds_13_tfmaildesignasunto ;
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
      private string GXt_char6 ;
      private string tblUnnamedtabledynamicfilters_3_Internalname ;
      private string cellFilter_maildesigntipo3_cell_Internalname ;
      private string cmbavMaildesigntipo3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblUnnamedtabledynamicfilters_2_Internalname ;
      private string cellFilter_maildesigntipo2_cell_Internalname ;
      private string cmbavMaildesigntipo2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblUnnamedtabledynamicfilters_1_Internalname ;
      private string cellFilter_maildesigntipo1_cell_Internalname ;
      private string cmbavMaildesigntipo1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_102_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtMailDesignId_Jsonclick ;
      private string cmbMailDesignTipo_Jsonclick ;
      private string edtMailDesignAsunto_Jsonclick ;
      private string cmbMailDesignEstado_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV27DynamicFiltersIgnoreFirst ;
      private bool AV26DynamicFiltersRemoving ;
      private bool AV52IsAuthorized_Update ;
      private bool AV53IsAuthorized_Delete ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_102_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV61Maildesignwwds_4_dynamicfiltersenabled2 ;
      private bool AV64Maildesignwwds_7_dynamicfiltersenabled3 ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV56TempBoolean ;
      private bool GXt_boolean3 ;
      private string AV40TFMailDesignTipo_SelsJson ;
      private string AV44TFMailDesignEstado_SelsJson ;
      private string AV30ColumnsSelectorXML ;
      private string AV36ManageFiltersXml ;
      private string AV31UserCustomValue ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV17FilterFullText ;
      private string AV50GridAppliedFilters ;
      private string AV58Maildesignwwds_1_filterfulltext ;
      private string AV59Maildesignwwds_2_dynamicfiltersselector1 ;
      private string AV62Maildesignwwds_5_dynamicfiltersselector2 ;
      private string AV65Maildesignwwds_8_dynamicfiltersselector3 ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
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
      private GXCombobox cmbavMaildesigntipo1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavMaildesigntipo2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavMaildesigntipo3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbMailDesignTipo ;
      private GXCombobox cmbMailDesignEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV32ColumnsSelector ;
      private GxSimpleCollection<string> AV41TFMailDesignTipo_Sels ;
      private GxSimpleCollection<string> AV45TFMailDesignEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV35ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV54AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV46DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV69Maildesignwwds_12_tfmaildesigntipo_sels ;
      private GxSimpleCollection<string> AV72Maildesignwwds_15_tfmaildesignestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H00B62_A245MailDesignEstado ;
      private string[] H00B62_A246MailDesignAsunto ;
      private string[] H00B62_A244MailDesignTipo ;
      private long[] H00B62_A148MailDesignId ;
      private string[] H00B63_A245MailDesignEstado ;
      private string[] H00B63_A246MailDesignAsunto ;
      private string[] H00B63_A244MailDesignTipo ;
      private long[] H00B63_A148MailDesignId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV55AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV33ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class maildesignww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00B62( IGxContext context ,
                                             string A244MailDesignTipo ,
                                             GxSimpleCollection<string> AV69Maildesignwwds_12_tfmaildesigntipo_sels ,
                                             string A245MailDesignEstado ,
                                             GxSimpleCollection<string> AV72Maildesignwwds_15_tfmaildesignestado_sels ,
                                             string AV59Maildesignwwds_2_dynamicfiltersselector1 ,
                                             string AV60Maildesignwwds_3_maildesigntipo1 ,
                                             bool AV61Maildesignwwds_4_dynamicfiltersenabled2 ,
                                             string AV62Maildesignwwds_5_dynamicfiltersselector2 ,
                                             string AV63Maildesignwwds_6_maildesigntipo2 ,
                                             bool AV64Maildesignwwds_7_dynamicfiltersenabled3 ,
                                             string AV65Maildesignwwds_8_dynamicfiltersselector3 ,
                                             string AV66Maildesignwwds_9_maildesigntipo3 ,
                                             long AV67Maildesignwwds_10_tfmaildesignid ,
                                             long AV68Maildesignwwds_11_tfmaildesignid_to ,
                                             int AV69Maildesignwwds_12_tfmaildesigntipo_sels_Count ,
                                             string AV71Maildesignwwds_14_tfmaildesignasunto_sel ,
                                             string AV70Maildesignwwds_13_tfmaildesignasunto ,
                                             int AV72Maildesignwwds_15_tfmaildesignestado_sels_Count ,
                                             long A148MailDesignId ,
                                             string A246MailDesignAsunto ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV58Maildesignwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[7];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [MailDesignEstado], [MailDesignAsunto], [MailDesignTipo], [MailDesignId] FROM [MailDesign]";
         if ( ( StringUtil.StrCmp(AV59Maildesignwwds_2_dynamicfiltersselector1, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Maildesignwwds_3_maildesigntipo1)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV60Maildesignwwds_3_maildesigntipo1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( AV61Maildesignwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Maildesignwwds_5_dynamicfiltersselector2, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Maildesignwwds_6_maildesigntipo2)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV63Maildesignwwds_6_maildesigntipo2)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( AV64Maildesignwwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Maildesignwwds_8_dynamicfiltersselector3, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Maildesignwwds_9_maildesigntipo3)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV66Maildesignwwds_9_maildesigntipo3)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV67Maildesignwwds_10_tfmaildesignid) )
         {
            AddWhere(sWhereString, "([MailDesignId] >= @AV67Maildesignwwds_10_tfmaildesignid)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV68Maildesignwwds_11_tfmaildesignid_to) )
         {
            AddWhere(sWhereString, "([MailDesignId] <= @AV68Maildesignwwds_11_tfmaildesignid_to)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV69Maildesignwwds_12_tfmaildesigntipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Maildesignwwds_12_tfmaildesigntipo_sels, "[MailDesignTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Maildesignwwds_14_tfmaildesignasunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Maildesignwwds_13_tfmaildesignasunto)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailDesignAsunto]) like UPPER(@lV70Maildesignwwds_13_tfmaildesignasunto))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Maildesignwwds_14_tfmaildesignasunto_sel)) && ! ( StringUtil.StrCmp(AV71Maildesignwwds_14_tfmaildesignasunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailDesignAsunto] = @AV71Maildesignwwds_14_tfmaildesignasunto_sel)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV71Maildesignwwds_14_tfmaildesignasunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailDesignAsunto] = ''))");
         }
         if ( AV72Maildesignwwds_15_tfmaildesignestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Maildesignwwds_15_tfmaildesignestado_sels, "[MailDesignEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignTipo]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignAsunto]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignAsunto] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignEstado]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignEstado] DESC";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H00B63( IGxContext context ,
                                             string A244MailDesignTipo ,
                                             GxSimpleCollection<string> AV69Maildesignwwds_12_tfmaildesigntipo_sels ,
                                             string A245MailDesignEstado ,
                                             GxSimpleCollection<string> AV72Maildesignwwds_15_tfmaildesignestado_sels ,
                                             string AV59Maildesignwwds_2_dynamicfiltersselector1 ,
                                             string AV60Maildesignwwds_3_maildesigntipo1 ,
                                             bool AV61Maildesignwwds_4_dynamicfiltersenabled2 ,
                                             string AV62Maildesignwwds_5_dynamicfiltersselector2 ,
                                             string AV63Maildesignwwds_6_maildesigntipo2 ,
                                             bool AV64Maildesignwwds_7_dynamicfiltersenabled3 ,
                                             string AV65Maildesignwwds_8_dynamicfiltersselector3 ,
                                             string AV66Maildesignwwds_9_maildesigntipo3 ,
                                             long AV67Maildesignwwds_10_tfmaildesignid ,
                                             long AV68Maildesignwwds_11_tfmaildesignid_to ,
                                             int AV69Maildesignwwds_12_tfmaildesigntipo_sels_Count ,
                                             string AV71Maildesignwwds_14_tfmaildesignasunto_sel ,
                                             string AV70Maildesignwwds_13_tfmaildesignasunto ,
                                             int AV72Maildesignwwds_15_tfmaildesignestado_sels_Count ,
                                             long A148MailDesignId ,
                                             string A246MailDesignAsunto ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV58Maildesignwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[7];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT [MailDesignEstado], [MailDesignAsunto], [MailDesignTipo], [MailDesignId] FROM [MailDesign]";
         if ( ( StringUtil.StrCmp(AV59Maildesignwwds_2_dynamicfiltersselector1, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Maildesignwwds_3_maildesigntipo1)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV60Maildesignwwds_3_maildesigntipo1)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( AV61Maildesignwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Maildesignwwds_5_dynamicfiltersselector2, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Maildesignwwds_6_maildesigntipo2)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV63Maildesignwwds_6_maildesigntipo2)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( AV64Maildesignwwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Maildesignwwds_8_dynamicfiltersselector3, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Maildesignwwds_9_maildesigntipo3)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV66Maildesignwwds_9_maildesigntipo3)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! (0==AV67Maildesignwwds_10_tfmaildesignid) )
         {
            AddWhere(sWhereString, "([MailDesignId] >= @AV67Maildesignwwds_10_tfmaildesignid)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! (0==AV68Maildesignwwds_11_tfmaildesignid_to) )
         {
            AddWhere(sWhereString, "([MailDesignId] <= @AV68Maildesignwwds_11_tfmaildesignid_to)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( AV69Maildesignwwds_12_tfmaildesigntipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Maildesignwwds_12_tfmaildesigntipo_sels, "[MailDesignTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Maildesignwwds_14_tfmaildesignasunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Maildesignwwds_13_tfmaildesignasunto)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailDesignAsunto]) like UPPER(@lV70Maildesignwwds_13_tfmaildesignasunto))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Maildesignwwds_14_tfmaildesignasunto_sel)) && ! ( StringUtil.StrCmp(AV71Maildesignwwds_14_tfmaildesignasunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailDesignAsunto] = @AV71Maildesignwwds_14_tfmaildesignasunto_sel)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV71Maildesignwwds_14_tfmaildesignasunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailDesignAsunto] = ''))");
         }
         if ( AV72Maildesignwwds_15_tfmaildesignestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Maildesignwwds_15_tfmaildesignestado_sels, "[MailDesignEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignTipo]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignAsunto]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignAsunto] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignEstado]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignEstado] DESC";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00B62(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_H00B63(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmH00B62;
          prmH00B62 = new Object[] {
          new ParDef("@AV60Maildesignwwds_3_maildesigntipo1",GXType.NChar,1,0) ,
          new ParDef("@AV63Maildesignwwds_6_maildesigntipo2",GXType.NChar,1,0) ,
          new ParDef("@AV66Maildesignwwds_9_maildesigntipo3",GXType.NChar,1,0) ,
          new ParDef("@AV67Maildesignwwds_10_tfmaildesignid",GXType.Decimal,18,0) ,
          new ParDef("@AV68Maildesignwwds_11_tfmaildesignid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV70Maildesignwwds_13_tfmaildesignasunto",GXType.Char,80,0) ,
          new ParDef("@AV71Maildesignwwds_14_tfmaildesignasunto_sel",GXType.NChar,80,0)
          };
          Object[] prmH00B63;
          prmH00B63 = new Object[] {
          new ParDef("@AV60Maildesignwwds_3_maildesigntipo1",GXType.NChar,1,0) ,
          new ParDef("@AV63Maildesignwwds_6_maildesigntipo2",GXType.NChar,1,0) ,
          new ParDef("@AV66Maildesignwwds_9_maildesigntipo3",GXType.NChar,1,0) ,
          new ParDef("@AV67Maildesignwwds_10_tfmaildesignid",GXType.Decimal,18,0) ,
          new ParDef("@AV68Maildesignwwds_11_tfmaildesignid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV70Maildesignwwds_13_tfmaildesignasunto",GXType.Char,80,0) ,
          new ParDef("@AV71Maildesignwwds_14_tfmaildesignasunto_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00B62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B62,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00B63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B63,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
