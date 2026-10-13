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
   public class cierresww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public cierresww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cierresww( IGxContext context )
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
         nRC_GXsfl_125 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_125"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_125_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_125_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_125_idx = GetPar( "sGXsfl_125_idx");
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
         AV17FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV20CierresUltimaFecha1 = context.localUtil.ParseDateParm( GetPar( "CierresUltimaFecha1"));
         AV25CierresUltimaFecha2 = context.localUtil.ParseDateParm( GetPar( "CierresUltimaFecha2"));
         AV30CierresUltimaFecha3 = context.localUtil.ParseDateParm( GetPar( "CierresUltimaFecha3"));
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38ColumnsSelector);
         AV73Pgmname = GetPar( "Pgmname");
         AV21CierresUltimaFecha_To1 = context.localUtil.ParseDateParm( GetPar( "CierresUltimaFecha_To1"));
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV26CierresUltimaFecha_To2 = context.localUtil.ParseDateParm( GetPar( "CierresUltimaFecha_To2"));
         AV27DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV31CierresUltimaFecha_To3 = context.localUtil.ParseDateParm( GetPar( "CierresUltimaFecha_To3"));
         AV44TFCierresId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCierresId"), "."), 18, MidpointRounding.ToEven));
         AV45TFCierresId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCierresId_To"), "."), 18, MidpointRounding.ToEven));
         AV46TFCierresUltimaFecha = context.localUtil.ParseDateParm( GetPar( "TFCierresUltimaFecha"));
         AV47TFCierresUltimaFecha_To = context.localUtil.ParseDateParm( GetPar( "TFCierresUltimaFecha_To"));
         AV51TFCierresUsuario = GetPar( "TFCierresUsuario");
         AV52TFCierresUsuario_Sel = GetPar( "TFCierresUsuario_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV33DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV32DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV60IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV61IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
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
         PAJ22( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTJ22( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cierresww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV60IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV60IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV61IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV61IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV17FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV28DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCIERRESULTIMAFECHA1", context.localUtil.Format(AV20CierresUltimaFecha1, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCIERRESULTIMAFECHA2", context.localUtil.Format(AV25CierresUltimaFecha2, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCIERRESULTIMAFECHA3", context.localUtil.Format(AV30CierresUltimaFecha3, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_125", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_125), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV57GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV62AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV62AGExportData);
         }
         GxWebStd.gx_hidden_field( context, "vCIERRESULTIMAFECHA_TO1", context.localUtil.DToC( AV21CierresUltimaFecha_To1, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vCIERRESULTIMAFECHA_TO2", context.localUtil.DToC( AV26CierresUltimaFecha_To2, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vCIERRESULTIMAFECHA_TO3", context.localUtil.DToC( AV31CierresUltimaFecha_To3, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV53DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV53DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_CIERRESULTIMAFECHAAUXDATETO", context.localUtil.DToC( AV49DDO_CierresUltimaFechaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV27DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFCIERRESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFCierresId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCIERRESID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TFCierresId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCIERRESULTIMAFECHA", context.localUtil.DToC( AV46TFCierresUltimaFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFCIERRESULTIMAFECHA_TO", context.localUtil.DToC( AV47TFCierresUltimaFecha_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFCIERRESUSUARIO", StringUtil.RTrim( AV51TFCierresUsuario));
         GxWebStd.gx_hidden_field( context, "vTFCIERRESUSUARIO_SEL", StringUtil.RTrim( AV52TFCierresUsuario_Sel));
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV33DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV32DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV60IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV60IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV61IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV61IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vCIERRESULTIMAFECHA1", context.localUtil.DToC( AV20CierresUltimaFecha1, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vCIERRESULTIMAFECHA2", context.localUtil.DToC( AV25CierresUltimaFecha2, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vCIERRESULTIMAFECHA3", context.localUtil.DToC( AV30CierresUltimaFecha3, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CIERRESULTIMAFECHAAUXDATE", context.localUtil.DToC( AV48DDO_CierresUltimaFechaAuxDate, 0, "/"));
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
            WEJ22( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTJ22( ) ;
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
         return formatLink("cierresww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CierresWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Cierres", "") ;
      }

      protected void WBJ20( )
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
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, divTableheadercontent_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(125), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(125), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(125), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(125), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_26_J22( true) ;
         }
         else
         {
            wb_table1_26_J22( false) ;
         }
         return  ;
      }

      protected void wb_table1_26_J22e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_125_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_CierresWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_50_J22( true) ;
         }
         else
         {
            wb_table2_50_J22( false) ;
         }
         return  ;
      }

      protected void wb_table2_50_J22e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_125_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_CierresWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_75_J22( true) ;
         }
         else
         {
            wb_table3_75_J22( false) ;
         }
         return  ;
      }

      protected void wb_table3_75_J22e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_125_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "", true, 0, "HLP_CierresWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_100_J22( true) ;
         }
         else
         {
            wb_table4_100_J22( false) ;
         }
         return  ;
      }

      protected void wb_table4_100_J22e( bool wbgen )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavFechacierre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFechacierre_Internalname, context.GetMessage( "Fecha de Cierre", ""), "gx-form-item AttributeDateLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'" + sGXsfl_125_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechacierre_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechacierre_Internalname, context.localUtil.Format(AV68FechaCierre, "99/99/99"), context.localUtil.Format( AV68FechaCierre, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechacierre_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavFechacierre_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CierresWW.htm");
            GxWebStd.gx_bitmap( context, edtavFechacierre_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechacierre_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_CierresWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl125( ) ;
         }
         if ( wbEnd == 125 )
         {
            wbEnd = 0;
            nRC_GXsfl_125 = (int)(nGXsfl_125_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV55GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV56GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV57GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(125), 3, 0)+","+"null"+");", context.GetMessage( "Actualizar", ""), bttBtnuseraction1_Jsonclick, 5, context.GetMessage( "Actualizar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CierresWW.htm");
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV62AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* User Defined Control */
            ucCierresultimafecha_rangepicker1.SetProperty("Start Date", AV20CierresUltimaFecha1);
            ucCierresultimafecha_rangepicker1.SetProperty("End Date", AV21CierresUltimaFecha_To1);
            ucCierresultimafecha_rangepicker1.Render(context, "wwp.daterangepicker", Cierresultimafecha_rangepicker1_Internalname, "CIERRESULTIMAFECHA_RANGEPICKER1Container");
            /* User Defined Control */
            ucCierresultimafecha_rangepicker2.SetProperty("Start Date", AV25CierresUltimaFecha2);
            ucCierresultimafecha_rangepicker2.SetProperty("End Date", AV26CierresUltimaFecha_To2);
            ucCierresultimafecha_rangepicker2.Render(context, "wwp.daterangepicker", Cierresultimafecha_rangepicker2_Internalname, "CIERRESULTIMAFECHA_RANGEPICKER2Container");
            /* User Defined Control */
            ucCierresultimafecha_rangepicker3.SetProperty("Start Date", AV30CierresUltimaFecha3);
            ucCierresultimafecha_rangepicker3.SetProperty("End Date", AV31CierresUltimaFecha_To3);
            ucCierresultimafecha_rangepicker3.Render(context, "wwp.daterangepicker", Cierresultimafecha_rangepicker3_Internalname, "CIERRESULTIMAFECHA_RANGEPICKER3Container");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_CierresWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV53DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV53DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV38ColumnsSelector);
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
               GxWebStd.gx_hidden_field( context, "W0150"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0150"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_125_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0150"+"");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_cierresultimafechaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'" + sGXsfl_125_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_cierresultimafechaauxdatetext_Internalname, AV50DDO_CierresUltimaFechaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV50DDO_CierresUltimaFechaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_cierresultimafechaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CierresWW.htm");
            /* User Defined Control */
            ucTfcierresultimafecha_rangepicker.SetProperty("Start Date", AV48DDO_CierresUltimaFechaAuxDate);
            ucTfcierresultimafecha_rangepicker.SetProperty("End Date", AV49DDO_CierresUltimaFechaAuxDateTo);
            ucTfcierresultimafecha_rangepicker.Render(context, "wwp.daterangepicker", Tfcierresultimafecha_rangepicker_Internalname, "TFCIERRESULTIMAFECHA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 125 )
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

      protected void STARTJ22( )
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
         Form.Meta.addItem("description", context.GetMessage( " Cierres", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPJ20( ) ;
      }

      protected void WSJ22( )
      {
         STARTJ22( ) ;
         EVTJ22( ) ;
      }

      protected void EVTJ22( )
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
                              E11J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E14J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E15J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CIERRESULTIMAFECHA_RANGEPICKER1.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Cierresultimafecha_rangepicker1.Daterangechanged */
                              E16J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CIERRESULTIMAFECHA_RANGEPICKER2.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Cierresultimafecha_rangepicker2.Daterangechanged */
                              E17J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CIERRESULTIMAFECHA_RANGEPICKER3.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Cierresultimafecha_rangepicker3.Daterangechanged */
                              E18J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E19J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E20J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E21J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E22J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E23J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction1' */
                              E24J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E25J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E26J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E27J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E28J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E29J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E30J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E31J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E32J22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E33J22 ();
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
                              nGXsfl_125_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_125_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_125_idx), 4, 0), 4, "0");
                              SubsflControlProps_1252( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV58GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV58GridActions), 4, 0));
                              A155CierresId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCierresId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A313CierresUltimaFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCierresUltimaFecha_Internalname), 0));
                              A314CierresUsuario = cgiGet( edtCierresUsuario_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E34J22 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E35J22 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E36J22 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E37J22 ();
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
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
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
                                       /* Set Refresh If Cierresultimafecha1 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCIERRESULTIMAFECHA1"), 0) != AV20CierresUltimaFecha1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cierresultimafecha2 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCIERRESULTIMAFECHA2"), 0) != AV25CierresUltimaFecha2 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cierresultimafecha3 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCIERRESULTIMAFECHA3"), 0) != AV30CierresUltimaFecha3 )
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
                        if ( nCmpId == 150 )
                        {
                           OldWwpaux_wc = cgiGet( "W0150");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0150", "", sEvt);
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

      protected void WEJ22( )
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

      protected void PAJ22( )
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
         SubsflControlProps_1252( ) ;
         while ( nGXsfl_125_idx <= nRC_GXsfl_125 )
         {
            sendrow_1252( ) ;
            nGXsfl_125_idx = ((subGrid_Islastpage==1)&&(nGXsfl_125_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_125_idx+1);
            sGXsfl_125_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_125_idx), 4, 0), 4, "0");
            SubsflControlProps_1252( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       string AV28DynamicFiltersSelector3 ,
                                       short AV29DynamicFiltersOperator3 ,
                                       DateTime AV20CierresUltimaFecha1 ,
                                       DateTime AV25CierresUltimaFecha2 ,
                                       DateTime AV30CierresUltimaFecha3 ,
                                       short AV43ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ,
                                       string AV73Pgmname ,
                                       DateTime AV21CierresUltimaFecha_To1 ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       DateTime AV26CierresUltimaFecha_To2 ,
                                       bool AV27DynamicFiltersEnabled3 ,
                                       DateTime AV31CierresUltimaFecha_To3 ,
                                       long AV44TFCierresId ,
                                       long AV45TFCierresId_To ,
                                       DateTime AV46TFCierresUltimaFecha ,
                                       DateTime AV47TFCierresUltimaFecha_To ,
                                       string AV51TFCierresUsuario ,
                                       string AV52TFCierresUsuario_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV33DynamicFiltersIgnoreFirst ,
                                       bool AV32DynamicFiltersRemoving ,
                                       bool AV60IsAuthorized_Update ,
                                       bool AV61IsAuthorized_Delete ,
                                       DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFJ22( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CIERRESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A155CierresId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CIERRESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A155CierresId), 18, 0, ".", "")));
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
         RFJ22( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV73Pgmname = "CierresWW";
      }

      protected void RFJ22( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 125;
         /* Execute user event: Refresh */
         E35J22 ();
         nGXsfl_125_idx = 1;
         sGXsfl_125_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_125_idx), 4, 0), 4, "0");
         SubsflControlProps_1252( ) ;
         bGXsfl_125_Refreshing = true;
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
            SubsflControlProps_1252( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV74Cierreswwds_1_filterfulltext ,
                                                 AV75Cierreswwds_2_dynamicfiltersselector1 ,
                                                 AV76Cierreswwds_3_dynamicfiltersoperator1 ,
                                                 AV77Cierreswwds_4_cierresultimafecha1 ,
                                                 AV78Cierreswwds_5_cierresultimafecha_to1 ,
                                                 AV79Cierreswwds_6_dynamicfiltersenabled2 ,
                                                 AV80Cierreswwds_7_dynamicfiltersselector2 ,
                                                 AV81Cierreswwds_8_dynamicfiltersoperator2 ,
                                                 AV82Cierreswwds_9_cierresultimafecha2 ,
                                                 AV83Cierreswwds_10_cierresultimafecha_to2 ,
                                                 AV84Cierreswwds_11_dynamicfiltersenabled3 ,
                                                 AV85Cierreswwds_12_dynamicfiltersselector3 ,
                                                 AV86Cierreswwds_13_dynamicfiltersoperator3 ,
                                                 AV87Cierreswwds_14_cierresultimafecha3 ,
                                                 AV88Cierreswwds_15_cierresultimafecha_to3 ,
                                                 AV89Cierreswwds_16_tfcierresid ,
                                                 AV90Cierreswwds_17_tfcierresid_to ,
                                                 AV91Cierreswwds_18_tfcierresultimafecha ,
                                                 AV92Cierreswwds_19_tfcierresultimafecha_to ,
                                                 AV94Cierreswwds_21_tfcierresusuario_sel ,
                                                 AV93Cierreswwds_20_tfcierresusuario ,
                                                 A155CierresId ,
                                                 A314CierresUsuario ,
                                                 A313CierresUltimaFecha ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV74Cierreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Cierreswwds_1_filterfulltext), "%", "");
            lV74Cierreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Cierreswwds_1_filterfulltext), "%", "");
            lV93Cierreswwds_20_tfcierresusuario = StringUtil.PadR( StringUtil.RTrim( AV93Cierreswwds_20_tfcierresusuario), 30, "%");
            /* Using cursor H00J22 */
            pr_default.execute(0, new Object[] {lV74Cierreswwds_1_filterfulltext, lV74Cierreswwds_1_filterfulltext, AV77Cierreswwds_4_cierresultimafecha1, AV77Cierreswwds_4_cierresultimafecha1, AV77Cierreswwds_4_cierresultimafecha1, AV77Cierreswwds_4_cierresultimafecha1, AV78Cierreswwds_5_cierresultimafecha_to1, AV82Cierreswwds_9_cierresultimafecha2, AV82Cierreswwds_9_cierresultimafecha2, AV82Cierreswwds_9_cierresultimafecha2, AV82Cierreswwds_9_cierresultimafecha2, AV83Cierreswwds_10_cierresultimafecha_to2, AV87Cierreswwds_14_cierresultimafecha3, AV87Cierreswwds_14_cierresultimafecha3, AV87Cierreswwds_14_cierresultimafecha3, AV87Cierreswwds_14_cierresultimafecha3, AV88Cierreswwds_15_cierresultimafecha_to3, AV89Cierreswwds_16_tfcierresid, AV90Cierreswwds_17_tfcierresid_to, AV91Cierreswwds_18_tfcierresultimafecha, AV92Cierreswwds_19_tfcierresultimafecha_to, lV93Cierreswwds_20_tfcierresusuario, AV94Cierreswwds_21_tfcierresusuario_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_125_idx = 1;
            sGXsfl_125_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_125_idx), 4, 0), 4, "0");
            SubsflControlProps_1252( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A314CierresUsuario = H00J22_A314CierresUsuario[0];
               A313CierresUltimaFecha = H00J22_A313CierresUltimaFecha[0];
               A155CierresId = H00J22_A155CierresId[0];
               /* Execute user event: Grid.Load */
               E36J22 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 125;
            WBJ20( ) ;
         }
         bGXsfl_125_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesJ22( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV60IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV60IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV61IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV61IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "gxhash_CIERRESID"+"_"+sGXsfl_125_idx, GetSecureSignedToken( sGXsfl_125_idx, context.localUtil.Format( (decimal)(A155CierresId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         AV74Cierreswwds_1_filterfulltext = AV17FilterFullText;
         AV75Cierreswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Cierreswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Cierreswwds_4_cierresultimafecha1 = AV20CierresUltimaFecha1;
         AV78Cierreswwds_5_cierresultimafecha_to1 = AV21CierresUltimaFecha_To1;
         AV79Cierreswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Cierreswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Cierreswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Cierreswwds_9_cierresultimafecha2 = AV25CierresUltimaFecha2;
         AV83Cierreswwds_10_cierresultimafecha_to2 = AV26CierresUltimaFecha_To2;
         AV84Cierreswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Cierreswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Cierreswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Cierreswwds_14_cierresultimafecha3 = AV30CierresUltimaFecha3;
         AV88Cierreswwds_15_cierresultimafecha_to3 = AV31CierresUltimaFecha_To3;
         AV89Cierreswwds_16_tfcierresid = AV44TFCierresId;
         AV90Cierreswwds_17_tfcierresid_to = AV45TFCierresId_To;
         AV91Cierreswwds_18_tfcierresultimafecha = AV46TFCierresUltimaFecha;
         AV92Cierreswwds_19_tfcierresultimafecha_to = AV47TFCierresUltimaFecha_To;
         AV93Cierreswwds_20_tfcierresusuario = AV51TFCierresUsuario;
         AV94Cierreswwds_21_tfcierresusuario_sel = AV52TFCierresUsuario_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV74Cierreswwds_1_filterfulltext ,
                                              AV75Cierreswwds_2_dynamicfiltersselector1 ,
                                              AV76Cierreswwds_3_dynamicfiltersoperator1 ,
                                              AV77Cierreswwds_4_cierresultimafecha1 ,
                                              AV78Cierreswwds_5_cierresultimafecha_to1 ,
                                              AV79Cierreswwds_6_dynamicfiltersenabled2 ,
                                              AV80Cierreswwds_7_dynamicfiltersselector2 ,
                                              AV81Cierreswwds_8_dynamicfiltersoperator2 ,
                                              AV82Cierreswwds_9_cierresultimafecha2 ,
                                              AV83Cierreswwds_10_cierresultimafecha_to2 ,
                                              AV84Cierreswwds_11_dynamicfiltersenabled3 ,
                                              AV85Cierreswwds_12_dynamicfiltersselector3 ,
                                              AV86Cierreswwds_13_dynamicfiltersoperator3 ,
                                              AV87Cierreswwds_14_cierresultimafecha3 ,
                                              AV88Cierreswwds_15_cierresultimafecha_to3 ,
                                              AV89Cierreswwds_16_tfcierresid ,
                                              AV90Cierreswwds_17_tfcierresid_to ,
                                              AV91Cierreswwds_18_tfcierresultimafecha ,
                                              AV92Cierreswwds_19_tfcierresultimafecha_to ,
                                              AV94Cierreswwds_21_tfcierresusuario_sel ,
                                              AV93Cierreswwds_20_tfcierresusuario ,
                                              A155CierresId ,
                                              A314CierresUsuario ,
                                              A313CierresUltimaFecha ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Cierreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Cierreswwds_1_filterfulltext), "%", "");
         lV74Cierreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Cierreswwds_1_filterfulltext), "%", "");
         lV93Cierreswwds_20_tfcierresusuario = StringUtil.PadR( StringUtil.RTrim( AV93Cierreswwds_20_tfcierresusuario), 30, "%");
         /* Using cursor H00J23 */
         pr_default.execute(1, new Object[] {lV74Cierreswwds_1_filterfulltext, lV74Cierreswwds_1_filterfulltext, AV77Cierreswwds_4_cierresultimafecha1, AV77Cierreswwds_4_cierresultimafecha1, AV77Cierreswwds_4_cierresultimafecha1, AV77Cierreswwds_4_cierresultimafecha1, AV78Cierreswwds_5_cierresultimafecha_to1, AV82Cierreswwds_9_cierresultimafecha2, AV82Cierreswwds_9_cierresultimafecha2, AV82Cierreswwds_9_cierresultimafecha2, AV82Cierreswwds_9_cierresultimafecha2, AV83Cierreswwds_10_cierresultimafecha_to2, AV87Cierreswwds_14_cierresultimafecha3, AV87Cierreswwds_14_cierresultimafecha3, AV87Cierreswwds_14_cierresultimafecha3, AV87Cierreswwds_14_cierresultimafecha3, AV88Cierreswwds_15_cierresultimafecha_to3, AV89Cierreswwds_16_tfcierresid, AV90Cierreswwds_17_tfcierresid_to, AV91Cierreswwds_18_tfcierresultimafecha, AV92Cierreswwds_19_tfcierresultimafecha_to, lV93Cierreswwds_20_tfcierresusuario, AV94Cierreswwds_21_tfcierresusuario_sel});
         GRID_nRecordCount = H00J23_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
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
         AV74Cierreswwds_1_filterfulltext = AV17FilterFullText;
         AV75Cierreswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Cierreswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Cierreswwds_4_cierresultimafecha1 = AV20CierresUltimaFecha1;
         AV78Cierreswwds_5_cierresultimafecha_to1 = AV21CierresUltimaFecha_To1;
         AV79Cierreswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Cierreswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Cierreswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Cierreswwds_9_cierresultimafecha2 = AV25CierresUltimaFecha2;
         AV83Cierreswwds_10_cierresultimafecha_to2 = AV26CierresUltimaFecha_To2;
         AV84Cierreswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Cierreswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Cierreswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Cierreswwds_14_cierresultimafecha3 = AV30CierresUltimaFecha3;
         AV88Cierreswwds_15_cierresultimafecha_to3 = AV31CierresUltimaFecha_To3;
         AV89Cierreswwds_16_tfcierresid = AV44TFCierresId;
         AV90Cierreswwds_17_tfcierresid_to = AV45TFCierresId_To;
         AV91Cierreswwds_18_tfcierresultimafecha = AV46TFCierresUltimaFecha;
         AV92Cierreswwds_19_tfcierresultimafecha_to = AV47TFCierresUltimaFecha_To;
         AV93Cierreswwds_20_tfcierresusuario = AV51TFCierresUsuario;
         AV94Cierreswwds_21_tfcierresusuario_sel = AV52TFCierresUsuario_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV74Cierreswwds_1_filterfulltext = AV17FilterFullText;
         AV75Cierreswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Cierreswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Cierreswwds_4_cierresultimafecha1 = AV20CierresUltimaFecha1;
         AV78Cierreswwds_5_cierresultimafecha_to1 = AV21CierresUltimaFecha_To1;
         AV79Cierreswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Cierreswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Cierreswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Cierreswwds_9_cierresultimafecha2 = AV25CierresUltimaFecha2;
         AV83Cierreswwds_10_cierresultimafecha_to2 = AV26CierresUltimaFecha_To2;
         AV84Cierreswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Cierreswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Cierreswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Cierreswwds_14_cierresultimafecha3 = AV30CierresUltimaFecha3;
         AV88Cierreswwds_15_cierresultimafecha_to3 = AV31CierresUltimaFecha_To3;
         AV89Cierreswwds_16_tfcierresid = AV44TFCierresId;
         AV90Cierreswwds_17_tfcierresid_to = AV45TFCierresId_To;
         AV91Cierreswwds_18_tfcierresultimafecha = AV46TFCierresUltimaFecha;
         AV92Cierreswwds_19_tfcierresultimafecha_to = AV47TFCierresUltimaFecha_To;
         AV93Cierreswwds_20_tfcierresusuario = AV51TFCierresUsuario;
         AV94Cierreswwds_21_tfcierresusuario_sel = AV52TFCierresUsuario_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV74Cierreswwds_1_filterfulltext = AV17FilterFullText;
         AV75Cierreswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Cierreswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Cierreswwds_4_cierresultimafecha1 = AV20CierresUltimaFecha1;
         AV78Cierreswwds_5_cierresultimafecha_to1 = AV21CierresUltimaFecha_To1;
         AV79Cierreswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Cierreswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Cierreswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Cierreswwds_9_cierresultimafecha2 = AV25CierresUltimaFecha2;
         AV83Cierreswwds_10_cierresultimafecha_to2 = AV26CierresUltimaFecha_To2;
         AV84Cierreswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Cierreswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Cierreswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Cierreswwds_14_cierresultimafecha3 = AV30CierresUltimaFecha3;
         AV88Cierreswwds_15_cierresultimafecha_to3 = AV31CierresUltimaFecha_To3;
         AV89Cierreswwds_16_tfcierresid = AV44TFCierresId;
         AV90Cierreswwds_17_tfcierresid_to = AV45TFCierresId_To;
         AV91Cierreswwds_18_tfcierresultimafecha = AV46TFCierresUltimaFecha;
         AV92Cierreswwds_19_tfcierresultimafecha_to = AV47TFCierresUltimaFecha_To;
         AV93Cierreswwds_20_tfcierresusuario = AV51TFCierresUsuario;
         AV94Cierreswwds_21_tfcierresusuario_sel = AV52TFCierresUsuario_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV74Cierreswwds_1_filterfulltext = AV17FilterFullText;
         AV75Cierreswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Cierreswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Cierreswwds_4_cierresultimafecha1 = AV20CierresUltimaFecha1;
         AV78Cierreswwds_5_cierresultimafecha_to1 = AV21CierresUltimaFecha_To1;
         AV79Cierreswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Cierreswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Cierreswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Cierreswwds_9_cierresultimafecha2 = AV25CierresUltimaFecha2;
         AV83Cierreswwds_10_cierresultimafecha_to2 = AV26CierresUltimaFecha_To2;
         AV84Cierreswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Cierreswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Cierreswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Cierreswwds_14_cierresultimafecha3 = AV30CierresUltimaFecha3;
         AV88Cierreswwds_15_cierresultimafecha_to3 = AV31CierresUltimaFecha_To3;
         AV89Cierreswwds_16_tfcierresid = AV44TFCierresId;
         AV90Cierreswwds_17_tfcierresid_to = AV45TFCierresId_To;
         AV91Cierreswwds_18_tfcierresultimafecha = AV46TFCierresUltimaFecha;
         AV92Cierreswwds_19_tfcierresultimafecha_to = AV47TFCierresUltimaFecha_To;
         AV93Cierreswwds_20_tfcierresusuario = AV51TFCierresUsuario;
         AV94Cierreswwds_21_tfcierresusuario_sel = AV52TFCierresUsuario_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV74Cierreswwds_1_filterfulltext = AV17FilterFullText;
         AV75Cierreswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Cierreswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Cierreswwds_4_cierresultimafecha1 = AV20CierresUltimaFecha1;
         AV78Cierreswwds_5_cierresultimafecha_to1 = AV21CierresUltimaFecha_To1;
         AV79Cierreswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Cierreswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Cierreswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Cierreswwds_9_cierresultimafecha2 = AV25CierresUltimaFecha2;
         AV83Cierreswwds_10_cierresultimafecha_to2 = AV26CierresUltimaFecha_To2;
         AV84Cierreswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Cierreswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Cierreswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Cierreswwds_14_cierresultimafecha3 = AV30CierresUltimaFecha3;
         AV88Cierreswwds_15_cierresultimafecha_to3 = AV31CierresUltimaFecha_To3;
         AV89Cierreswwds_16_tfcierresid = AV44TFCierresId;
         AV90Cierreswwds_17_tfcierresid_to = AV45TFCierresId_To;
         AV91Cierreswwds_18_tfcierresultimafecha = AV46TFCierresUltimaFecha;
         AV92Cierreswwds_19_tfcierresultimafecha_to = AV47TFCierresUltimaFecha_To;
         AV93Cierreswwds_20_tfcierresusuario = AV51TFCierresUsuario;
         AV94Cierreswwds_21_tfcierresusuario_sel = AV52TFCierresUsuario_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AV73Pgmname = "CierresWW";
         edtCierresId_Enabled = 0;
         edtCierresUltimaFecha_Enabled = 0;
         edtCierresUsuario_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPJ20( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E34J22 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV62AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV53DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV38ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_125 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_125"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV55GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV56GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV57GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV20CierresUltimaFecha1 = context.localUtil.CToD( cgiGet( "vCIERRESULTIMAFECHA1"), 0);
            AssignAttri("", false, "AV20CierresUltimaFecha1", context.localUtil.Format(AV20CierresUltimaFecha1, "99/99/99"));
            AV21CierresUltimaFecha_To1 = context.localUtil.CToD( cgiGet( "vCIERRESULTIMAFECHA_TO1"), 0);
            AssignAttri("", false, "AV21CierresUltimaFecha_To1", context.localUtil.Format(AV21CierresUltimaFecha_To1, "99/99/99"));
            AV25CierresUltimaFecha2 = context.localUtil.CToD( cgiGet( "vCIERRESULTIMAFECHA2"), 0);
            AssignAttri("", false, "AV25CierresUltimaFecha2", context.localUtil.Format(AV25CierresUltimaFecha2, "99/99/99"));
            AV26CierresUltimaFecha_To2 = context.localUtil.CToD( cgiGet( "vCIERRESULTIMAFECHA_TO2"), 0);
            AssignAttri("", false, "AV26CierresUltimaFecha_To2", context.localUtil.Format(AV26CierresUltimaFecha_To2, "99/99/99"));
            AV30CierresUltimaFecha3 = context.localUtil.CToD( cgiGet( "vCIERRESULTIMAFECHA3"), 0);
            AssignAttri("", false, "AV30CierresUltimaFecha3", context.localUtil.Format(AV30CierresUltimaFecha3, "99/99/99"));
            AV31CierresUltimaFecha_To3 = context.localUtil.CToD( cgiGet( "vCIERRESULTIMAFECHA_TO3"), 0);
            AssignAttri("", false, "AV31CierresUltimaFecha_To3", context.localUtil.Format(AV31CierresUltimaFecha_To3, "99/99/99"));
            AV48DDO_CierresUltimaFechaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CIERRESULTIMAFECHAAUXDATE"), 0);
            AV49DDO_CierresUltimaFechaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CIERRESULTIMAFECHAAUXDATETO"), 0);
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
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AV65CierresUltimaFecha_RangeText1 = cgiGet( edtavCierresultimafecha_rangetext1_Internalname);
            AssignAttri("", false, "AV65CierresUltimaFecha_RangeText1", AV65CierresUltimaFecha_RangeText1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AV66CierresUltimaFecha_RangeText2 = cgiGet( edtavCierresultimafecha_rangetext2_Internalname);
            AssignAttri("", false, "AV66CierresUltimaFecha_RangeText2", AV66CierresUltimaFecha_RangeText2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV28DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AV67CierresUltimaFecha_RangeText3 = cgiGet( edtavCierresultimafecha_rangetext3_Internalname);
            AssignAttri("", false, "AV67CierresUltimaFecha_RangeText3", AV67CierresUltimaFecha_RangeText3);
            if ( context.localUtil.VCDate( cgiGet( edtavFechacierre_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Cierre", "")}), 1, "vFECHACIERRE");
               GX_FocusControl = edtavFechacierre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV68FechaCierre = DateTime.MinValue;
               AssignAttri("", false, "AV68FechaCierre", context.localUtil.Format(AV68FechaCierre, "99/99/99"));
            }
            else
            {
               AV68FechaCierre = context.localUtil.CToD( cgiGet( edtavFechacierre_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV68FechaCierre", context.localUtil.Format(AV68FechaCierre, "99/99/99"));
            }
            AV50DDO_CierresUltimaFechaAuxDateText = cgiGet( edtavDdo_cierresultimafechaauxdatetext_Internalname);
            AssignAttri("", false, "AV50DDO_CierresUltimaFechaAuxDateText", AV50DDO_CierresUltimaFechaAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
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
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCIERRESULTIMAFECHA1"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV20CierresUltimaFecha1 ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCIERRESULTIMAFECHA2"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV25CierresUltimaFecha2 ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCIERRESULTIMAFECHA3"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV30CierresUltimaFecha3 ) )
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
         E34J22 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E34J22( )
      {
         /* Start Routine */
         returnInSub = false;
         AV71RoleName = AV72WebSession.Get(context.GetMessage( "Rol", ""));
         if ( ! ( StringUtil.StrCmp(StringUtil.Trim( AV71RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) )
         {
            CallWebObject(formatLink("solicitudesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         this.executeUsercontrolMethod("", false, "TFCIERRESULTIMAFECHA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_cierresultimafechaauxdatetext_Internalname});
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         this.executeUsercontrolMethod("", false, "CIERRESULTIMAFECHA_RANGEPICKER1Container", "Attach", "", new Object[] {(string)edtavCierresultimafecha_rangetext1_Internalname});
         AV18DynamicFiltersSelector1 = "CIERRESULTIMAFECHA";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod("", false, "CIERRESULTIMAFECHA_RANGEPICKER2Container", "Attach", "", new Object[] {(string)edtavCierresultimafecha_rangetext2_Internalname});
         AV23DynamicFiltersSelector2 = "CIERRESULTIMAFECHA";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod("", false, "CIERRESULTIMAFECHA_RANGEPICKER3Container", "Attach", "", new Object[] {(string)edtavCierresultimafecha_rangetext3_Internalname});
         AV28DynamicFiltersSelector3 = "CIERRESULTIMAFECHA";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S152 ();
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
         AV62AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV63AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV63AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV63AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV63AGExportDataItem.gxTpr_Eventkey = "Export";
         AV63AGExportDataItem.gxTpr_Isdivider = false;
         AV62AGExportData.Add(AV63AGExportDataItem, 0);
         AV63AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV63AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV63AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV63AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV63AGExportDataItem.gxTpr_Isdivider = false;
         AV62AGExportData.Add(AV63AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Cierres", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S172 ();
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
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV53DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV53DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         GXt_date2 = AV68FechaCierre;
         new updatecierres(context ).execute(  AV68FechaCierre,  context.GetMessage( "Obtener", ""), out  GXt_date2) ;
         AV68FechaCierre = GXt_date2;
         AssignAttri("", false, "AV68FechaCierre", context.localUtil.Format(AV68FechaCierre, "99/99/99"));
      }

      protected void E35J22( )
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
         S192 ();
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
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV40Session.Get("CierresWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV40Session.Get("CierresWWColumnsSelector");
            AV38ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtCierresId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCierresId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCierresId_Visible), 5, 0), !bGXsfl_125_Refreshing);
         edtCierresUltimaFecha_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCierresUltimaFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCierresUltimaFecha_Visible), 5, 0), !bGXsfl_125_Refreshing);
         edtCierresUsuario_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCierresUsuario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCierresUsuario_Visible), 5, 0), !bGXsfl_125_Refreshing);
         AV55GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV55GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV55GridCurrentPage), 10, 0));
         AV56GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV56GridPageCount", StringUtil.LTrimStr( (decimal)(AV56GridPageCount), 10, 0));
         GXt_char3 = AV57GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV73Pgmname, out  GXt_char3) ;
         AV57GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV57GridAppliedFilters", AV57GridAppliedFilters);
         AV74Cierreswwds_1_filterfulltext = AV17FilterFullText;
         AV75Cierreswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Cierreswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Cierreswwds_4_cierresultimafecha1 = AV20CierresUltimaFecha1;
         AV78Cierreswwds_5_cierresultimafecha_to1 = AV21CierresUltimaFecha_To1;
         AV79Cierreswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Cierreswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Cierreswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Cierreswwds_9_cierresultimafecha2 = AV25CierresUltimaFecha2;
         AV83Cierreswwds_10_cierresultimafecha_to2 = AV26CierresUltimaFecha_To2;
         AV84Cierreswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Cierreswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Cierreswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Cierreswwds_14_cierresultimafecha3 = AV30CierresUltimaFecha3;
         AV88Cierreswwds_15_cierresultimafecha_to3 = AV31CierresUltimaFecha_To3;
         AV89Cierreswwds_16_tfcierresid = AV44TFCierresId;
         AV90Cierreswwds_17_tfcierresid_to = AV45TFCierresId_To;
         AV91Cierreswwds_18_tfcierresultimafecha = AV46TFCierresUltimaFecha;
         AV92Cierreswwds_19_tfcierresultimafecha_to = AV47TFCierresUltimaFecha_To;
         AV93Cierreswwds_20_tfcierresusuario = AV51TFCierresUsuario;
         AV94Cierreswwds_21_tfcierresusuario_sel = AV52TFCierresUsuario_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12J22( )
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
            AV54PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV54PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13J22( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E19J22( )
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
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CierresId") == 0 )
            {
               AV44TFCierresId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFCierresId", StringUtil.LTrimStr( (decimal)(AV44TFCierresId), 18, 0));
               AV45TFCierresId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFCierresId_To", StringUtil.LTrimStr( (decimal)(AV45TFCierresId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CierresUltimaFecha") == 0 )
            {
               AV46TFCierresUltimaFecha = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV46TFCierresUltimaFecha", context.localUtil.Format(AV46TFCierresUltimaFecha, "99/99/99"));
               AV47TFCierresUltimaFecha_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV47TFCierresUltimaFecha_To", context.localUtil.Format(AV47TFCierresUltimaFecha_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CierresUsuario") == 0 )
            {
               AV51TFCierresUsuario = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV51TFCierresUsuario", AV51TFCierresUsuario);
               AV52TFCierresUsuario_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV52TFCierresUsuario_Sel", AV52TFCierresUsuario_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E36J22( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         if ( AV60IsAuthorized_Update )
         {
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV61IsAuthorized_Delete )
         {
            cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "cierresview.aspx"+UrlEncode(StringUtil.LTrimStr(A155CierresId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         edtCierresUltimaFecha_Link = formatLink("cierresview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 125;
         }
         sendrow_1252( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_125_Refreshing )
         {
            context.DoAjaxLoad(125, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0));
      }

      protected void E20J22( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV36ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV38ColumnsSelector.FromJSonString(AV36ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "CierresWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV36ColumnsSelectorXML)) ? "" : AV38ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E26J22( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E21J22( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E27J22( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E16J22( )
      {
         /* Cierresultimafecha_rangepicker1_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV20CierresUltimaFecha1", context.localUtil.Format(AV20CierresUltimaFecha1, "99/99/99"));
         AssignAttri("", false, "AV21CierresUltimaFecha_To1", context.localUtil.Format(AV21CierresUltimaFecha_To1, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E28J22( )
      {
         /* Dynamicfiltersoperator1_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CIERRESULTIMAFECHA") == 0 )
         {
            AV20CierresUltimaFecha1 = DateTime.MinValue;
            AssignAttri("", false, "AV20CierresUltimaFecha1", context.localUtil.Format(AV20CierresUltimaFecha1, "99/99/99"));
            AV21CierresUltimaFecha_To1 = DateTime.MinValue;
            AssignAttri("", false, "AV21CierresUltimaFecha_To1", context.localUtil.Format(AV21CierresUltimaFecha_To1, "99/99/99"));
            /* Execute user subroutine: 'UPDATECIERRESULTIMAFECHA1OPERATORVALUES' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E29J22( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E22J22( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E30J22( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E17J22( )
      {
         /* Cierresultimafecha_rangepicker2_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV25CierresUltimaFecha2", context.localUtil.Format(AV25CierresUltimaFecha2, "99/99/99"));
         AssignAttri("", false, "AV26CierresUltimaFecha_To2", context.localUtil.Format(AV26CierresUltimaFecha_To2, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E31J22( )
      {
         /* Dynamicfiltersoperator2_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CIERRESULTIMAFECHA") == 0 )
         {
            AV25CierresUltimaFecha2 = DateTime.MinValue;
            AssignAttri("", false, "AV25CierresUltimaFecha2", context.localUtil.Format(AV25CierresUltimaFecha2, "99/99/99"));
            AV26CierresUltimaFecha_To2 = DateTime.MinValue;
            AssignAttri("", false, "AV26CierresUltimaFecha_To2", context.localUtil.Format(AV26CierresUltimaFecha_To2, "99/99/99"));
            /* Execute user subroutine: 'UPDATECIERRESULTIMAFECHA2OPERATORVALUES' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E23J22( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E32J22( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E18J22( )
      {
         /* Cierresultimafecha_rangepicker3_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV30CierresUltimaFecha3", context.localUtil.Format(AV30CierresUltimaFecha3, "99/99/99"));
         AssignAttri("", false, "AV31CierresUltimaFecha_To3", context.localUtil.Format(AV31CierresUltimaFecha_To3, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E33J22( )
      {
         /* Dynamicfiltersoperator3_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CIERRESULTIMAFECHA") == 0 )
         {
            AV30CierresUltimaFecha3 = DateTime.MinValue;
            AssignAttri("", false, "AV30CierresUltimaFecha3", context.localUtil.Format(AV30CierresUltimaFecha3, "99/99/99"));
            AV31CierresUltimaFecha_To3 = DateTime.MinValue;
            AssignAttri("", false, "AV31CierresUltimaFecha_To3", context.localUtil.Format(AV31CierresUltimaFecha_To3, "99/99/99"));
            /* Execute user subroutine: 'UPDATECIERRESULTIMAFECHA3OPERATORVALUES' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20CierresUltimaFecha1, AV25CierresUltimaFecha2, AV30CierresUltimaFecha3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV73Pgmname, AV21CierresUltimaFecha_To1, AV22DynamicFiltersEnabled2, AV26CierresUltimaFecha_To2, AV27DynamicFiltersEnabled3, AV31CierresUltimaFecha_To3, AV44TFCierresId, AV45TFCierresId_To, AV46TFCierresUltimaFecha, AV47TFCierresUltimaFecha_To, AV51TFCierresUsuario, AV52TFCierresUsuario_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV60IsAuthorized_Update, AV61IsAuthorized_Delete, Gx_date) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E11J22( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S282 ();
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
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("CierresWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV73Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("CierresWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "CierresWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV42ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S282 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV73Pgmname+"GridState",  AV42ManageFiltersXml) ;
               AV11GridState.FromXml(AV42ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S292 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S242 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E24J22( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         GXt_date2 = (DateTime)(DateTime.MinValue);
         new updatecierres(context ).execute(  AV68FechaCierre,  context.GetMessage( "Actualizar", ""), out  GXt_date2) ;
         GX_msglist.addItem(context.GetMessage( "Fecha de cierre actualizada", ""));
      }

      protected void E37J22( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV58GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV58GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S312 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV58GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S322 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV58GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV58GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E25J22( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "cierres.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("cierres.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14J22( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S332 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S342 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E15J22( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0150",(string)"",(string)"Cierres",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0150"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S182( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S212( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "CierresId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "CierresUltimaFecha",  "",  "del Cierre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "CierresUsuario",  "",  "de Cierre",  true,  "") ;
         GXt_char3 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "CierresWWColumnsSelector", out  GXt_char3) ;
         AV37UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37UserCustomValue)) ) )
         {
            AV39ColumnsSelectorAux.FromXml(AV37UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV39ColumnsSelectorAux, ref  AV38ColumnsSelector) ;
         }
      }

      protected void S192( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean4 = AV60IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Update", out  GXt_boolean4) ;
         AV60IsAuthorized_Update = GXt_boolean4;
         AssignAttri("", false, "AV60IsAuthorized_Update", AV60IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV60IsAuthorized_Update, context));
         GXt_boolean4 = AV61IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Delete", out  GXt_boolean4) ;
         AV61IsAuthorized_Delete = GXt_boolean4;
         AssignAttri("", false, "AV61IsAuthorized_Delete", AV61IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV61IsAuthorized_Delete, context));
         GXt_boolean4 = AV64TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Insert", out  GXt_boolean4) ;
         AV64TempBoolean = GXt_boolean4;
         if ( ! ( AV64TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean4 = AV64TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean4) ;
         AV64TempBoolean = GXt_boolean4;
         if ( ! ( AV64TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Cierres",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         tblTablemergeddynamicfilterscierresultimafecha1_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfilterscierresultimafecha1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterscierresultimafecha1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CIERRESULTIMAFECHA") == 0 )
         {
            tblTablemergeddynamicfilterscierresultimafecha1_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfilterscierresultimafecha1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterscierresultimafecha1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATECIERRESULTIMAFECHA1OPERATORVALUES' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S252( )
      {
         /* 'UPDATECIERRESULTIMAFECHA1OPERATORVALUES' Routine */
         returnInSub = false;
         cellCierresultimafecha_range_cell1_Class = "Invisible";
         AssignProp("", false, cellCierresultimafecha_range_cell1_Internalname, "Class", cellCierresultimafecha_range_cell1_Class, true);
         if ( AV19DynamicFiltersOperator1 == 0 )
         {
            AV20CierresUltimaFecha1 = Gx_date;
            AssignAttri("", false, "AV20CierresUltimaFecha1", context.localUtil.Format(AV20CierresUltimaFecha1, "99/99/99"));
         }
         else if ( AV19DynamicFiltersOperator1 == 1 )
         {
            AV20CierresUltimaFecha1 = Gx_date;
            AssignAttri("", false, "AV20CierresUltimaFecha1", context.localUtil.Format(AV20CierresUltimaFecha1, "99/99/99"));
         }
         else if ( AV19DynamicFiltersOperator1 == 2 )
         {
            AV20CierresUltimaFecha1 = Gx_date;
            AssignAttri("", false, "AV20CierresUltimaFecha1", context.localUtil.Format(AV20CierresUltimaFecha1, "99/99/99"));
         }
         else if ( AV19DynamicFiltersOperator1 == 3 )
         {
            cellCierresultimafecha_range_cell1_Class = "";
            AssignProp("", false, cellCierresultimafecha_range_cell1_Internalname, "Class", cellCierresultimafecha_range_cell1_Class, true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         tblTablemergeddynamicfilterscierresultimafecha2_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfilterscierresultimafecha2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterscierresultimafecha2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CIERRESULTIMAFECHA") == 0 )
         {
            tblTablemergeddynamicfilterscierresultimafecha2_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfilterscierresultimafecha2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterscierresultimafecha2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATECIERRESULTIMAFECHA2OPERATORVALUES' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S262( )
      {
         /* 'UPDATECIERRESULTIMAFECHA2OPERATORVALUES' Routine */
         returnInSub = false;
         cellCierresultimafecha_range_cell2_Class = "Invisible";
         AssignProp("", false, cellCierresultimafecha_range_cell2_Internalname, "Class", cellCierresultimafecha_range_cell2_Class, true);
         if ( AV24DynamicFiltersOperator2 == 0 )
         {
            AV25CierresUltimaFecha2 = Gx_date;
            AssignAttri("", false, "AV25CierresUltimaFecha2", context.localUtil.Format(AV25CierresUltimaFecha2, "99/99/99"));
         }
         else if ( AV24DynamicFiltersOperator2 == 1 )
         {
            AV25CierresUltimaFecha2 = Gx_date;
            AssignAttri("", false, "AV25CierresUltimaFecha2", context.localUtil.Format(AV25CierresUltimaFecha2, "99/99/99"));
         }
         else if ( AV24DynamicFiltersOperator2 == 2 )
         {
            AV25CierresUltimaFecha2 = Gx_date;
            AssignAttri("", false, "AV25CierresUltimaFecha2", context.localUtil.Format(AV25CierresUltimaFecha2, "99/99/99"));
         }
         else if ( AV24DynamicFiltersOperator2 == 3 )
         {
            cellCierresultimafecha_range_cell2_Class = "";
            AssignProp("", false, cellCierresultimafecha_range_cell2_Internalname, "Class", cellCierresultimafecha_range_cell2_Class, true);
         }
      }

      protected void S152( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         tblTablemergeddynamicfilterscierresultimafecha3_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfilterscierresultimafecha3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterscierresultimafecha3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CIERRESULTIMAFECHA") == 0 )
         {
            tblTablemergeddynamicfilterscierresultimafecha3_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfilterscierresultimafecha3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterscierresultimafecha3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATECIERRESULTIMAFECHA3OPERATORVALUES' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S272( )
      {
         /* 'UPDATECIERRESULTIMAFECHA3OPERATORVALUES' Routine */
         returnInSub = false;
         cellCierresultimafecha_range_cell3_Class = "Invisible";
         AssignProp("", false, cellCierresultimafecha_range_cell3_Internalname, "Class", cellCierresultimafecha_range_cell3_Class, true);
         if ( AV29DynamicFiltersOperator3 == 0 )
         {
            AV30CierresUltimaFecha3 = Gx_date;
            AssignAttri("", false, "AV30CierresUltimaFecha3", context.localUtil.Format(AV30CierresUltimaFecha3, "99/99/99"));
         }
         else if ( AV29DynamicFiltersOperator3 == 1 )
         {
            AV30CierresUltimaFecha3 = Gx_date;
            AssignAttri("", false, "AV30CierresUltimaFecha3", context.localUtil.Format(AV30CierresUltimaFecha3, "99/99/99"));
         }
         else if ( AV29DynamicFiltersOperator3 == 2 )
         {
            AV30CierresUltimaFecha3 = Gx_date;
            AssignAttri("", false, "AV30CierresUltimaFecha3", context.localUtil.Format(AV30CierresUltimaFecha3, "99/99/99"));
         }
         else if ( AV29DynamicFiltersOperator3 == 3 )
         {
            cellCierresultimafecha_range_cell3_Class = "";
            AssignProp("", false, cellCierresultimafecha_range_cell3_Internalname, "Class", cellCierresultimafecha_range_cell3_Class, true);
         }
      }

      protected void S232( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         AV23DynamicFiltersSelector2 = "CIERRESULTIMAFECHA";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV25CierresUltimaFecha2 = DateTime.MinValue;
         AssignAttri("", false, "AV25CierresUltimaFecha2", context.localUtil.Format(AV25CierresUltimaFecha2, "99/99/99"));
         AV26CierresUltimaFecha_To2 = DateTime.MinValue;
         AssignAttri("", false, "AV26CierresUltimaFecha_To2", context.localUtil.Format(AV26CierresUltimaFecha_To2, "99/99/99"));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         AV28DynamicFiltersSelector3 = "CIERRESULTIMAFECHA";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AV30CierresUltimaFecha3 = DateTime.MinValue;
         AssignAttri("", false, "AV30CierresUltimaFecha3", context.localUtil.Format(AV30CierresUltimaFecha3, "99/99/99"));
         AV31CierresUltimaFecha_To3 = DateTime.MinValue;
         AssignAttri("", false, "AV31CierresUltimaFecha_To3", context.localUtil.Format(AV31CierresUltimaFecha_To3, "99/99/99"));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S122( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV41ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "CierresWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S282( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV44TFCierresId = 0;
         AssignAttri("", false, "AV44TFCierresId", StringUtil.LTrimStr( (decimal)(AV44TFCierresId), 18, 0));
         AV45TFCierresId_To = 0;
         AssignAttri("", false, "AV45TFCierresId_To", StringUtil.LTrimStr( (decimal)(AV45TFCierresId_To), 18, 0));
         AV46TFCierresUltimaFecha = DateTime.MinValue;
         AssignAttri("", false, "AV46TFCierresUltimaFecha", context.localUtil.Format(AV46TFCierresUltimaFecha, "99/99/99"));
         AV47TFCierresUltimaFecha_To = DateTime.MinValue;
         AssignAttri("", false, "AV47TFCierresUltimaFecha_To", context.localUtil.Format(AV47TFCierresUltimaFecha_To, "99/99/99"));
         AV51TFCierresUsuario = "";
         AssignAttri("", false, "AV51TFCierresUsuario", AV51TFCierresUsuario);
         AV52TFCierresUsuario_Sel = "";
         AssignAttri("", false, "AV52TFCierresUsuario_Sel", AV52TFCierresUsuario_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "CIERRESULTIMAFECHA";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20CierresUltimaFecha1 = DateTime.MinValue;
         AssignAttri("", false, "AV20CierresUltimaFecha1", context.localUtil.Format(AV20CierresUltimaFecha1, "99/99/99"));
         AV21CierresUltimaFecha_To1 = DateTime.MinValue;
         AssignAttri("", false, "AV21CierresUltimaFecha_To1", context.localUtil.Format(AV21CierresUltimaFecha_To1, "99/99/99"));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S302( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "cierresview.aspx"+UrlEncode(StringUtil.LTrimStr(A155CierresId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("cierresview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S312( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "cierres.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A155CierresId,18,0));
         CallWebObject(formatLink("cierres.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S322( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "cierres.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A155CierresId,18,0));
         CallWebObject(formatLink("cierres.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S172( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV73Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV73Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV40Session.Get(AV73Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S292 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S242 ();
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

      protected void S292( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV96GXV1 = 1;
         while ( AV96GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV96GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCIERRESID") == 0 )
            {
               AV44TFCierresId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFCierresId", StringUtil.LTrimStr( (decimal)(AV44TFCierresId), 18, 0));
               AV45TFCierresId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFCierresId_To", StringUtil.LTrimStr( (decimal)(AV45TFCierresId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCIERRESULTIMAFECHA") == 0 )
            {
               AV46TFCierresUltimaFecha = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV46TFCierresUltimaFecha", context.localUtil.Format(AV46TFCierresUltimaFecha, "99/99/99"));
               AV47TFCierresUltimaFecha_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV47TFCierresUltimaFecha_To", context.localUtil.Format(AV47TFCierresUltimaFecha_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCIERRESUSUARIO") == 0 )
            {
               AV51TFCierresUsuario = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFCierresUsuario", AV51TFCierresUsuario);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCIERRESUSUARIO_SEL") == 0 )
            {
               AV52TFCierresUsuario_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFCierresUsuario_Sel", AV52TFCierresUsuario_Sel);
            }
            AV96GXV1 = (int)(AV96GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCierresUsuario_Sel)),  AV52TFCierresUsuario_Sel, out  GXt_char3) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCierresUsuario)),  AV51TFCierresUsuario, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV44TFCierresId) ? "" : StringUtil.Str( (decimal)(AV44TFCierresId), 18, 0))+"|"+((DateTime.MinValue==AV46TFCierresUltimaFecha) ? "" : context.localUtil.DToC( AV46TFCierresUltimaFecha, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV45TFCierresId_To) ? "" : StringUtil.Str( (decimal)(AV45TFCierresId_To), 18, 0))+"|"+((DateTime.MinValue==AV47TFCierresUltimaFecha_To) ? "" : context.localUtil.DToC( AV47TFCierresUltimaFecha_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S242( )
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CIERRESULTIMAFECHA") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20CierresUltimaFecha1 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV20CierresUltimaFecha1", context.localUtil.Format(AV20CierresUltimaFecha1, "99/99/99"));
               AV21CierresUltimaFecha_To1 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV21CierresUltimaFecha_To1", context.localUtil.Format(AV21CierresUltimaFecha_To1, "99/99/99"));
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S132 ();
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
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CIERRESULTIMAFECHA") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25CierresUltimaFecha2 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "AV25CierresUltimaFecha2", context.localUtil.Format(AV25CierresUltimaFecha2, "99/99/99"));
                  AV26CierresUltimaFecha_To2 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "AV26CierresUltimaFecha_To2", context.localUtil.Format(AV26CierresUltimaFecha_To2, "99/99/99"));
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S142 ();
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
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CIERRESULTIMAFECHA") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV30CierresUltimaFecha3 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AssignAttri("", false, "AV30CierresUltimaFecha3", context.localUtil.Format(AV30CierresUltimaFecha3, "99/99/99"));
                     AV31CierresUltimaFecha_To3 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AssignAttri("", false, "AV31CierresUltimaFecha_To3", context.localUtil.Format(AV31CierresUltimaFecha_To3, "99/99/99"));
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S152 ();
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

      protected void S202( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV40Session.Get(AV73Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCIERRESID",  context.GetMessage( "Id", ""),  !((0==AV44TFCierresId)&&(0==AV45TFCierresId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFCierresId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV45TFCierresId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCIERRESULTIMAFECHA",  context.GetMessage( "del Cierre", ""),  !((DateTime.MinValue==AV46TFCierresUltimaFecha)&&(DateTime.MinValue==AV47TFCierresUltimaFecha_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV46TFCierresUltimaFecha, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV47TFCierresUltimaFecha_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCIERRESUSUARIO",  context.GetMessage( "de Cierre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCierresUsuario)),  0,  AV51TFCierresUsuario,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCierresUsuario_Sel)),  AV52TFCierresUsuario_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV73Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S222( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV33DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CIERRESULTIMAFECHA") == 0 ) && ! ( (DateTime.MinValue==AV20CierresUltimaFecha1) && (DateTime.MinValue==AV21CierresUltimaFecha_To1) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "del Cierre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV20CierresUltimaFecha1, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV21CierresUltimaFecha_To1, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CIERRESULTIMAFECHA") == 0 ) && ! ( (DateTime.MinValue==AV25CierresUltimaFecha2) && (DateTime.MinValue==AV26CierresUltimaFecha_To2) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "del Cierre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV25CierresUltimaFecha2, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV26CierresUltimaFecha_To2, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV27DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV28DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CIERRESULTIMAFECHA") == 0 ) && ! ( (DateTime.MinValue==AV30CierresUltimaFecha3) && (DateTime.MinValue==AV31CierresUltimaFecha_To3) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "del Cierre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV30CierresUltimaFecha3, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV31CierresUltimaFecha_To3, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S162( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV73Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Cierres";
         AV40Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S332( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new cierreswwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
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

      protected void S342( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("cierreswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divTableheadercontent_Visible = (((1==0)) ? 1 : 0);
         AssignProp("", false, divTableheadercontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableheadercontent_Visible), 5, 0), true);
      }

      protected void wb_table4_100_J22( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_125_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR3.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "", true, 0, "HLP_CierresWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cierresultimafecha3_cell_Internalname+"\"  class=''>") ;
            wb_table5_106_J22( true) ;
         }
         else
         {
            wb_table5_106_J22( false) ;
         }
         return  ;
      }

      protected void wb_table5_106_J22e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CierresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_100_J22e( true) ;
         }
         else
         {
            wb_table4_100_J22e( false) ;
         }
      }

      protected void wb_table5_106_J22( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfilterscierresultimafecha3_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilterscierresultimafecha3_Internalname, tblTablemergeddynamicfilterscierresultimafecha3_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellCierresultimafecha_range_cell3_Internalname+"\"  class='"+cellCierresultimafecha_range_cell3_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCierresultimafecha_rangetext3_Internalname, context.GetMessage( "Cierres Ultima Fecha_Range Text3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_125_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCierresultimafecha_rangetext3_Internalname, AV67CierresUltimaFecha_RangeText3, StringUtil.RTrim( context.localUtil.Format( AV67CierresUltimaFecha_RangeText3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCierresultimafecha_rangetext3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCierresultimafecha_rangetext3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_106_J22e( true) ;
         }
         else
         {
            wb_table5_106_J22e( false) ;
         }
      }

      protected void wb_table3_75_J22( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_125_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR2.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_CierresWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cierresultimafecha2_cell_Internalname+"\"  class=''>") ;
            wb_table6_81_J22( true) ;
         }
         else
         {
            wb_table6_81_J22( false) ;
         }
         return  ;
      }

      protected void wb_table6_81_J22e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CierresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CierresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_75_J22e( true) ;
         }
         else
         {
            wb_table3_75_J22e( false) ;
         }
      }

      protected void wb_table6_81_J22( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfilterscierresultimafecha2_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilterscierresultimafecha2_Internalname, tblTablemergeddynamicfilterscierresultimafecha2_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellCierresultimafecha_range_cell2_Internalname+"\"  class='"+cellCierresultimafecha_range_cell2_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCierresultimafecha_rangetext2_Internalname, context.GetMessage( "Cierres Ultima Fecha_Range Text2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_125_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCierresultimafecha_rangetext2_Internalname, AV66CierresUltimaFecha_RangeText2, StringUtil.RTrim( context.localUtil.Format( AV66CierresUltimaFecha_RangeText2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCierresultimafecha_rangetext2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCierresultimafecha_rangetext2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_81_J22e( true) ;
         }
         else
         {
            wb_table6_81_J22e( false) ;
         }
      }

      protected void wb_table2_50_J22( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_125_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR1.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_CierresWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cierresultimafecha1_cell_Internalname+"\"  class=''>") ;
            wb_table7_56_J22( true) ;
         }
         else
         {
            wb_table7_56_J22( false) ;
         }
         return  ;
      }

      protected void wb_table7_56_J22e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CierresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CierresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_50_J22e( true) ;
         }
         else
         {
            wb_table2_50_J22e( false) ;
         }
      }

      protected void wb_table7_56_J22( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfilterscierresultimafecha1_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilterscierresultimafecha1_Internalname, tblTablemergeddynamicfilterscierresultimafecha1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellCierresultimafecha_range_cell1_Internalname+"\"  class='"+cellCierresultimafecha_range_cell1_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCierresultimafecha_rangetext1_Internalname, context.GetMessage( "Cierres Ultima Fecha_Range Text1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_125_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCierresultimafecha_rangetext1_Internalname, AV65CierresUltimaFecha_RangeText1, StringUtil.RTrim( context.localUtil.Format( AV65CierresUltimaFecha_RangeText1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCierresultimafecha_rangetext1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCierresultimafecha_rangetext1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_56_J22e( true) ;
         }
         else
         {
            wb_table7_56_J22e( false) ;
         }
      }

      protected void wb_table1_26_J22( bool wbgen )
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
            wb_table8_31_J22( true) ;
         }
         else
         {
            wb_table8_31_J22( false) ;
         }
         return  ;
      }

      protected void wb_table8_31_J22e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_26_J22e( true) ;
         }
         else
         {
            wb_table1_26_J22e( false) ;
         }
      }

      protected void wb_table8_31_J22( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_125_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_CierresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_31_J22e( true) ;
         }
         else
         {
            wb_table8_31_J22e( false) ;
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
         PAJ22( ) ;
         WSJ22( ) ;
         WEJ22( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302124194", true, true, false);
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
         context.AddJavascriptSource("cierresww.js", "?20267302124195", false, true, false);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1252( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_125_idx;
         edtCierresId_Internalname = "CIERRESID_"+sGXsfl_125_idx;
         edtCierresUltimaFecha_Internalname = "CIERRESULTIMAFECHA_"+sGXsfl_125_idx;
         edtCierresUsuario_Internalname = "CIERRESUSUARIO_"+sGXsfl_125_idx;
      }

      protected void SubsflControlProps_fel_1252( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_125_fel_idx;
         edtCierresId_Internalname = "CIERRESID_"+sGXsfl_125_fel_idx;
         edtCierresUltimaFecha_Internalname = "CIERRESULTIMAFECHA_"+sGXsfl_125_fel_idx;
         edtCierresUsuario_Internalname = "CIERRESUSUARIO_"+sGXsfl_125_fel_idx;
      }

      protected void sendrow_1252( )
      {
         sGXsfl_125_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_125_idx), 4, 0), 4, "0");
         SubsflControlProps_1252( ) ;
         WBJ20( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_125_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_125_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_125_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_125_idx + "',125)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_125_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV58GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV58GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_125_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_125_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCierresId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCierresId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A155CierresId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A155CierresId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCierresId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCierresId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)125,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCierresUltimaFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCierresUltimaFecha_Internalname,context.localUtil.Format(A313CierresUltimaFecha, "99/99/99"),context.localUtil.Format( A313CierresUltimaFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCierresUltimaFecha_Link,(string)"",(string)"",(string)"",(string)edtCierresUltimaFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCierresUltimaFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)125,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCierresUsuario_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCierresUsuario_Internalname,StringUtil.RTrim( A314CierresUsuario),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCierresUsuario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCierresUsuario_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)125,(short)0,(short)-1,(short)-1,(bool)true,(string)"Usuario",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesJ22( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_125_idx = ((subGrid_Islastpage==1)&&(nGXsfl_125_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_125_idx+1);
            sGXsfl_125_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_125_idx), 4, 0), 4, "0");
            SubsflControlProps_1252( ) ;
         }
         /* End function sendrow_1252 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CIERRESULTIMAFECHA", context.GetMessage( "del Cierre", ""), 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterPast", ""), 0);
         cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterToday", ""), 0);
         cmbavDynamicfiltersoperator1.addItem("2", context.GetMessage( "WWP_FilterInTheFuture", ""), 0);
         cmbavDynamicfiltersoperator1.addItem("3", context.GetMessage( "WWP_FilterRange", ""), 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("CIERRESULTIMAFECHA", context.GetMessage( "del Cierre", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterPast", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterToday", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("2", context.GetMessage( "WWP_FilterInTheFuture", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("3", context.GetMessage( "WWP_FilterRange", ""), 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CIERRESULTIMAFECHA", context.GetMessage( "del Cierre", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterPast", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterToday", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("2", context.GetMessage( "WWP_FilterInTheFuture", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("3", context.GetMessage( "WWP_FilterRange", ""), 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_125_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV58GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV58GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV58GridActions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl125( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"125\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCierresId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCierresUltimaFecha_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "del Cierre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCierresUsuario_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "de Cierre", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A155CierresId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCierresId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A313CierresUltimaFecha, "99/99/99")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCierresUltimaFecha_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCierresUltimaFecha_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A314CierresUsuario)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCierresUsuario_Visible), 5, 0, ".", "")));
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
         edtavCierresultimafecha_rangetext1_Internalname = "vCIERRESULTIMAFECHA_RANGETEXT1";
         cellCierresultimafecha_range_cell1_Internalname = "CIERRESULTIMAFECHA_RANGE_CELL1";
         tblTablemergeddynamicfilterscierresultimafecha1_Internalname = "TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA1";
         cellFilter_cierresultimafecha1_cell_Internalname = "FILTER_CIERRESULTIMAFECHA1_CELL";
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
         edtavCierresultimafecha_rangetext2_Internalname = "vCIERRESULTIMAFECHA_RANGETEXT2";
         cellCierresultimafecha_range_cell2_Internalname = "CIERRESULTIMAFECHA_RANGE_CELL2";
         tblTablemergeddynamicfilterscierresultimafecha2_Internalname = "TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA2";
         cellFilter_cierresultimafecha2_cell_Internalname = "FILTER_CIERRESULTIMAFECHA2_CELL";
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
         edtavCierresultimafecha_rangetext3_Internalname = "vCIERRESULTIMAFECHA_RANGETEXT3";
         cellCierresultimafecha_range_cell3_Internalname = "CIERRESULTIMAFECHA_RANGE_CELL3";
         tblTablemergeddynamicfilterscierresultimafecha3_Internalname = "TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA3";
         cellFilter_cierresultimafecha3_cell_Internalname = "FILTER_CIERRESULTIMAFECHA3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         edtavFechacierre_Internalname = "vFECHACIERRE";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtCierresId_Internalname = "CIERRESID";
         edtCierresUltimaFecha_Internalname = "CIERRESULTIMAFECHA";
         edtCierresUsuario_Internalname = "CIERRESUSUARIO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         bttBtnuseraction1_Internalname = "BTNUSERACTION1";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Cierresultimafecha_rangepicker1_Internalname = "CIERRESULTIMAFECHA_RANGEPICKER1";
         Cierresultimafecha_rangepicker2_Internalname = "CIERRESULTIMAFECHA_RANGEPICKER2";
         Cierresultimafecha_rangepicker3_Internalname = "CIERRESULTIMAFECHA_RANGEPICKER3";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_cierresultimafechaauxdatetext_Internalname = "vDDO_CIERRESULTIMAFECHAAUXDATETEXT";
         Tfcierresultimafecha_rangepicker_Internalname = "TFCIERRESULTIMAFECHA_RANGEPICKER";
         divDdo_cierresultimafechaauxdates_Internalname = "DDO_CIERRESULTIMAFECHAAUXDATES";
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
         edtCierresUsuario_Jsonclick = "";
         edtCierresUltimaFecha_Jsonclick = "";
         edtCierresUltimaFecha_Link = "";
         edtCierresId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavCierresultimafecha_rangetext1_Jsonclick = "";
         edtavCierresultimafecha_rangetext1_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         edtavCierresultimafecha_rangetext2_Jsonclick = "";
         edtavCierresultimafecha_rangetext2_Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavCierresultimafecha_rangetext3_Jsonclick = "";
         edtavCierresultimafecha_rangetext3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cellCierresultimafecha_range_cell3_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator3.Visible = 1;
         tblTablemergeddynamicfilterscierresultimafecha3_Visible = 1;
         cellCierresultimafecha_range_cell2_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator2.Visible = 1;
         tblTablemergeddynamicfilterscierresultimafecha2_Visible = 1;
         cellCierresultimafecha_range_cell1_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator1.Visible = 1;
         tblTablemergeddynamicfilterscierresultimafecha1_Visible = 1;
         edtCierresUsuario_Visible = -1;
         edtCierresUltimaFecha_Visible = -1;
         edtCierresId_Visible = -1;
         edtCierresUsuario_Enabled = 0;
         edtCierresUltimaFecha_Enabled = 0;
         edtCierresId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_cierresultimafechaauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = context.GetMessage( "JSDynamicFilters", "");
         edtavFechacierre_Jsonclick = "";
         edtavFechacierre_Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         divTableheadercontent_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;";
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
         Ddo_grid_Format = "18.0||";
         Ddo_grid_Datalistproc = "CierresWWGetFilterData";
         Ddo_grid_Datalisttype = "||Dynamic";
         Ddo_grid_Includedatalist = "||T";
         Ddo_grid_Filterisrange = "T|P|";
         Ddo_grid_Filtertype = "Numeric|Date|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3";
         Ddo_grid_Columnids = "1:CierresId|2:CierresUltimaFecha|3:CierresUsuario";
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
         Form.Caption = context.GetMessage( " Cierres", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E19J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E36J22',iparms:[{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'A155CierresId',fld:'CIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV58GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtCierresUltimaFecha_Link',ctrl:'CIERRESULTIMAFECHA',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E20J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E26J22',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E21J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfilterscierresultimafecha2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA2',prop:'Visible'},{av:'tblTablemergeddynamicfilterscierresultimafecha3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA3',prop:'Visible'},{av:'tblTablemergeddynamicfilterscierresultimafecha1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA1',prop:'Visible'},{av:'cellCierresultimafecha_range_cell2_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL2',prop:'Class'},{av:'cellCierresultimafecha_range_cell3_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL3',prop:'Class'},{av:'cellCierresultimafecha_range_cell1_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E27J22',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'tblTablemergeddynamicfilterscierresultimafecha1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'cellCierresultimafecha_range_cell1_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL1',prop:'Class'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'}]}");
         setEventMetadata("CIERRESULTIMAFECHA_RANGEPICKER1.DATERANGECHANGED","{handler:'E16J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("CIERRESULTIMAFECHA_RANGEPICKER1.DATERANGECHANGED",",oparms:[{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK","{handler:'E28J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK",",oparms:[{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'cellCierresultimafecha_range_cell1_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E29J22',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E22J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfilterscierresultimafecha2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA2',prop:'Visible'},{av:'tblTablemergeddynamicfilterscierresultimafecha3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA3',prop:'Visible'},{av:'tblTablemergeddynamicfilterscierresultimafecha1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA1',prop:'Visible'},{av:'cellCierresultimafecha_range_cell2_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL2',prop:'Class'},{av:'cellCierresultimafecha_range_cell3_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL3',prop:'Class'},{av:'cellCierresultimafecha_range_cell1_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E30J22',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'tblTablemergeddynamicfilterscierresultimafecha2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cellCierresultimafecha_range_cell2_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL2',prop:'Class'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'}]}");
         setEventMetadata("CIERRESULTIMAFECHA_RANGEPICKER2.DATERANGECHANGED","{handler:'E17J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("CIERRESULTIMAFECHA_RANGEPICKER2.DATERANGECHANGED",",oparms:[{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK","{handler:'E31J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK",",oparms:[{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'cellCierresultimafecha_range_cell2_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL2',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E23J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfilterscierresultimafecha2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA2',prop:'Visible'},{av:'tblTablemergeddynamicfilterscierresultimafecha3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA3',prop:'Visible'},{av:'tblTablemergeddynamicfilterscierresultimafecha1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA1',prop:'Visible'},{av:'cellCierresultimafecha_range_cell2_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL2',prop:'Class'},{av:'cellCierresultimafecha_range_cell3_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL3',prop:'Class'},{av:'cellCierresultimafecha_range_cell1_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E32J22',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'tblTablemergeddynamicfilterscierresultimafecha3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'},{av:'cellCierresultimafecha_range_cell3_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL3',prop:'Class'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'}]}");
         setEventMetadata("CIERRESULTIMAFECHA_RANGEPICKER3.DATERANGECHANGED","{handler:'E18J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("CIERRESULTIMAFECHA_RANGEPICKER3.DATERANGECHANGED",",oparms:[{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK","{handler:'E33J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK",",oparms:[{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'cellCierresultimafecha_range_cell3_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL3',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11J22',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'tblTablemergeddynamicfilterscierresultimafecha1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA1',prop:'Visible'},{av:'tblTablemergeddynamicfilterscierresultimafecha2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA2',prop:'Visible'},{av:'tblTablemergeddynamicfilterscierresultimafecha3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA3',prop:'Visible'},{av:'cellCierresultimafecha_range_cell1_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL1',prop:'Class'},{av:'cellCierresultimafecha_range_cell2_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL2',prop:'Class'},{av:'cellCierresultimafecha_range_cell3_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL3',prop:'Class'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOUSERACTION1'","{handler:'E24J22',iparms:[{av:'AV68FechaCierre',fld:'vFECHACIERRE',pic:'',type:'date'}]");
         setEventMetadata("'DOUSERACTION1'",",oparms:[]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E37J22',iparms:[{av:'cmbavGridactions'},{av:'AV58GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A155CierresId',fld:'CIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV58GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E25J22',iparms:[{av:'A155CierresId',fld:'CIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14J22',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV20CierresUltimaFecha1',fld:'vCIERRESULTIMAFECHA1',pic:'',type:'date'},{av:'AV25CierresUltimaFecha2',fld:'vCIERRESULTIMAFECHA2',pic:'',type:'date'},{av:'AV30CierresUltimaFecha3',fld:'vCIERRESULTIMAFECHA3',pic:'',type:'date'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21CierresUltimaFecha_To1',fld:'vCIERRESULTIMAFECHA_TO1',pic:'',type:'date'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV26CierresUltimaFecha_To2',fld:'vCIERRESULTIMAFECHA_TO2',pic:'',type:'date'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV31CierresUltimaFecha_To3',fld:'vCIERRESULTIMAFECHA_TO3',pic:'',type:'date'},{av:'AV44TFCierresId',fld:'vTFCIERRESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCierresId_To',fld:'vTFCIERRESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFCierresUltimaFecha',fld:'vTFCIERRESULTIMAFECHA',pic:'',type:'date'},{av:'AV47TFCierresUltimaFecha_To',fld:'vTFCIERRESULTIMAFECHA_TO',pic:'',type:'date'},{av:'AV51TFCierresUsuario',fld:'vTFCIERRESUSUARIO',pic:'',type:'char'},{av:'AV52TFCierresUsuario_Sel',fld:'vTFCIERRESUSUARIO_SEL',pic:'',type:'char'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV60IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV61IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfilterscierresultimafecha1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA1',prop:'Visible'},{av:'tblTablemergeddynamicfilterscierresultimafecha2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA2',prop:'Visible'},{av:'tblTablemergeddynamicfilterscierresultimafecha3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSCIERRESULTIMAFECHA3',prop:'Visible'},{av:'cellCierresultimafecha_range_cell1_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL1',prop:'Class'},{av:'cellCierresultimafecha_range_cell2_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL2',prop:'Class'},{av:'cellCierresultimafecha_range_cell3_Class',ctrl:'CIERRESULTIMAFECHA_RANGE_CELL3',prop:'Class'},{av:'edtCierresId_Visible',ctrl:'CIERRESID',prop:'Visible'},{av:'edtCierresUltimaFecha_Visible',ctrl:'CIERRESULTIMAFECHA',prop:'Visible'},{av:'edtCierresUsuario_Visible',ctrl:'CIERRESUSUARIO',prop:'Visible'},{av:'AV55GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV56GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV57GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E15J22',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALIDV_FECHACIERRE","{handler:'Validv_Fechacierre',iparms:[]");
         setEventMetadata("VALIDV_FECHACIERRE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Cierresusuario',iparms:[]");
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
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV20CierresUltimaFecha1 = DateTime.MinValue;
         AV25CierresUltimaFecha2 = DateTime.MinValue;
         AV30CierresUltimaFecha3 = DateTime.MinValue;
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV73Pgmname = "";
         AV21CierresUltimaFecha_To1 = DateTime.MinValue;
         AV26CierresUltimaFecha_To2 = DateTime.MinValue;
         AV31CierresUltimaFecha_To3 = DateTime.MinValue;
         AV46TFCierresUltimaFecha = DateTime.MinValue;
         AV47TFCierresUltimaFecha_To = DateTime.MinValue;
         AV51TFCierresUsuario = "";
         AV52TFCierresUsuario_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV57GridAppliedFilters = "";
         AV62AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV53DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV49DDO_CierresUltimaFechaAuxDateTo = DateTime.MinValue;
         AV48DDO_CierresUltimaFechaAuxDate = DateTime.MinValue;
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
         AV68FechaCierre = DateTime.MinValue;
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         bttBtnuseraction1_Jsonclick = "";
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucCierresultimafecha_rangepicker1 = new GXUserControl();
         ucCierresultimafecha_rangepicker2 = new GXUserControl();
         ucCierresultimafecha_rangepicker3 = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV50DDO_CierresUltimaFechaAuxDateText = "";
         ucTfcierresultimafecha_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A313CierresUltimaFecha = DateTime.MinValue;
         A314CierresUsuario = "";
         lV74Cierreswwds_1_filterfulltext = "";
         lV93Cierreswwds_20_tfcierresusuario = "";
         AV74Cierreswwds_1_filterfulltext = "";
         AV75Cierreswwds_2_dynamicfiltersselector1 = "";
         AV77Cierreswwds_4_cierresultimafecha1 = DateTime.MinValue;
         AV78Cierreswwds_5_cierresultimafecha_to1 = DateTime.MinValue;
         AV80Cierreswwds_7_dynamicfiltersselector2 = "";
         AV82Cierreswwds_9_cierresultimafecha2 = DateTime.MinValue;
         AV83Cierreswwds_10_cierresultimafecha_to2 = DateTime.MinValue;
         AV85Cierreswwds_12_dynamicfiltersselector3 = "";
         AV87Cierreswwds_14_cierresultimafecha3 = DateTime.MinValue;
         AV88Cierreswwds_15_cierresultimafecha_to3 = DateTime.MinValue;
         AV91Cierreswwds_18_tfcierresultimafecha = DateTime.MinValue;
         AV92Cierreswwds_19_tfcierresultimafecha_to = DateTime.MinValue;
         AV94Cierreswwds_21_tfcierresusuario_sel = "";
         AV93Cierreswwds_20_tfcierresusuario = "";
         H00J22_A314CierresUsuario = new string[] {""} ;
         H00J22_A313CierresUltimaFecha = new DateTime[] {DateTime.MinValue} ;
         H00J22_A155CierresId = new long[1] ;
         H00J23_AGRID_nRecordCount = new long[1] ;
         AV65CierresUltimaFecha_RangeText1 = "";
         AV66CierresUltimaFecha_RangeText2 = "";
         AV67CierresUltimaFecha_RangeText3 = "";
         AV71RoleName = "";
         AV72WebSession = context.GetSession();
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV63AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV42ManageFiltersXml = "";
         GXt_date2 = DateTime.MinValue;
         AV37UserCustomValue = "";
         AV39ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV34ExcelFilename = "";
         AV35ErrorMessage = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cierresww__default(),
            new Object[][] {
                new Object[] {
               H00J22_A314CierresUsuario, H00J22_A313CierresUltimaFecha, H00J22_A155CierresId
               }
               , new Object[] {
               H00J23_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         AV73Pgmname = "CierresWW";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV73Pgmname = "CierresWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV43ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV58GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV76Cierreswwds_3_dynamicfiltersoperator1 ;
      private short AV81Cierreswwds_8_dynamicfiltersoperator2 ;
      private short AV86Cierreswwds_13_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_125 ;
      private int nGXsfl_125_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int divTableheadercontent_Visible ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFechacierre_Enabled ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtCierresId_Enabled ;
      private int edtCierresUltimaFecha_Enabled ;
      private int edtCierresUsuario_Enabled ;
      private int edtCierresId_Visible ;
      private int edtCierresUltimaFecha_Visible ;
      private int edtCierresUsuario_Visible ;
      private int AV54PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int tblTablemergeddynamicfilterscierresultimafecha1_Visible ;
      private int tblTablemergeddynamicfilterscierresultimafecha2_Visible ;
      private int tblTablemergeddynamicfilterscierresultimafecha3_Visible ;
      private int AV96GXV1 ;
      private int edtavCierresultimafecha_rangetext3_Enabled ;
      private int edtavCierresultimafecha_rangetext2_Enabled ;
      private int edtavCierresultimafecha_rangetext1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV44TFCierresId ;
      private long AV45TFCierresId_To ;
      private long AV55GridCurrentPage ;
      private long AV56GridPageCount ;
      private long A155CierresId ;
      private long GRID_nCurrentRecord ;
      private long AV89Cierreswwds_16_tfcierresid ;
      private long AV90Cierreswwds_17_tfcierresid_to ;
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
      private string sGXsfl_125_idx="0001" ;
      private string AV73Pgmname ;
      private string AV51TFCierresUsuario ;
      private string AV52TFCierresUsuario_Sel ;
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
      private string edtavFechacierre_Internalname ;
      private string edtavFechacierre_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Cierresultimafecha_rangepicker1_Internalname ;
      private string Cierresultimafecha_rangepicker2_Internalname ;
      private string Cierresultimafecha_rangepicker3_Internalname ;
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
      private string divDdo_cierresultimafechaauxdates_Internalname ;
      private string edtavDdo_cierresultimafechaauxdatetext_Internalname ;
      private string edtavDdo_cierresultimafechaauxdatetext_Jsonclick ;
      private string Tfcierresultimafecha_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtCierresId_Internalname ;
      private string edtCierresUltimaFecha_Internalname ;
      private string A314CierresUsuario ;
      private string edtCierresUsuario_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string lV93Cierreswwds_20_tfcierresusuario ;
      private string AV94Cierreswwds_21_tfcierresusuario_sel ;
      private string AV93Cierreswwds_20_tfcierresusuario ;
      private string edtavCierresultimafecha_rangetext1_Internalname ;
      private string edtavCierresultimafecha_rangetext2_Internalname ;
      private string edtavCierresultimafecha_rangetext3_Internalname ;
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
      private string edtCierresUltimaFecha_Link ;
      private string GXEncryptionTmp ;
      private string tblTablemergeddynamicfilterscierresultimafecha1_Internalname ;
      private string cellCierresultimafecha_range_cell1_Class ;
      private string cellCierresultimafecha_range_cell1_Internalname ;
      private string tblTablemergeddynamicfilterscierresultimafecha2_Internalname ;
      private string cellCierresultimafecha_range_cell2_Class ;
      private string cellCierresultimafecha_range_cell2_Internalname ;
      private string tblTablemergeddynamicfilterscierresultimafecha3_Internalname ;
      private string cellCierresultimafecha_range_cell3_Class ;
      private string cellCierresultimafecha_range_cell3_Internalname ;
      private string GXt_char3 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_cierresultimafecha3_cell_Internalname ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string edtavCierresultimafecha_rangetext3_Jsonclick ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_cierresultimafecha2_cell_Internalname ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string edtavCierresultimafecha_rangetext2_Jsonclick ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_cierresultimafecha1_cell_Internalname ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string edtavCierresultimafecha_rangetext1_Jsonclick ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_125_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtCierresId_Jsonclick ;
      private string edtCierresUltimaFecha_Jsonclick ;
      private string edtCierresUsuario_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV20CierresUltimaFecha1 ;
      private DateTime AV25CierresUltimaFecha2 ;
      private DateTime AV30CierresUltimaFecha3 ;
      private DateTime AV21CierresUltimaFecha_To1 ;
      private DateTime AV26CierresUltimaFecha_To2 ;
      private DateTime AV31CierresUltimaFecha_To3 ;
      private DateTime AV46TFCierresUltimaFecha ;
      private DateTime AV47TFCierresUltimaFecha_To ;
      private DateTime Gx_date ;
      private DateTime AV49DDO_CierresUltimaFechaAuxDateTo ;
      private DateTime AV48DDO_CierresUltimaFechaAuxDate ;
      private DateTime AV68FechaCierre ;
      private DateTime A313CierresUltimaFecha ;
      private DateTime AV77Cierreswwds_4_cierresultimafecha1 ;
      private DateTime AV78Cierreswwds_5_cierresultimafecha_to1 ;
      private DateTime AV82Cierreswwds_9_cierresultimafecha2 ;
      private DateTime AV83Cierreswwds_10_cierresultimafecha_to2 ;
      private DateTime AV87Cierreswwds_14_cierresultimafecha3 ;
      private DateTime AV88Cierreswwds_15_cierresultimafecha_to3 ;
      private DateTime AV91Cierreswwds_18_tfcierresultimafecha ;
      private DateTime AV92Cierreswwds_19_tfcierresultimafecha_to ;
      private DateTime GXt_date2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV33DynamicFiltersIgnoreFirst ;
      private bool AV32DynamicFiltersRemoving ;
      private bool AV60IsAuthorized_Update ;
      private bool AV61IsAuthorized_Delete ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_125_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV79Cierreswwds_6_dynamicfiltersenabled2 ;
      private bool AV84Cierreswwds_11_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV64TempBoolean ;
      private bool GXt_boolean4 ;
      private string AV36ColumnsSelectorXML ;
      private string AV42ManageFiltersXml ;
      private string AV37UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV57GridAppliedFilters ;
      private string AV50DDO_CierresUltimaFechaAuxDateText ;
      private string lV74Cierreswwds_1_filterfulltext ;
      private string AV74Cierreswwds_1_filterfulltext ;
      private string AV75Cierreswwds_2_dynamicfiltersselector1 ;
      private string AV80Cierreswwds_7_dynamicfiltersselector2 ;
      private string AV85Cierreswwds_12_dynamicfiltersselector3 ;
      private string AV65CierresUltimaFecha_RangeText1 ;
      private string AV66CierresUltimaFecha_RangeText2 ;
      private string AV67CierresUltimaFecha_RangeText3 ;
      private string AV71RoleName ;
      private string AV34ExcelFilename ;
      private string AV35ErrorMessage ;
      private IGxSession AV72WebSession ;
      private IGxSession AV40Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucCierresultimafecha_rangepicker1 ;
      private GXUserControl ucCierresultimafecha_rangepicker2 ;
      private GXUserControl ucCierresultimafecha_rangepicker3 ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfcierresultimafecha_rangepicker ;
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
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV41ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV62AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV53DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H00J22_A314CierresUsuario ;
      private DateTime[] H00J22_A313CierresUltimaFecha ;
      private long[] H00J22_A155CierresId ;
      private long[] H00J23_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV63AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class cierresww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00J22( IGxContext context ,
                                             string AV74Cierreswwds_1_filterfulltext ,
                                             string AV75Cierreswwds_2_dynamicfiltersselector1 ,
                                             short AV76Cierreswwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV77Cierreswwds_4_cierresultimafecha1 ,
                                             DateTime AV78Cierreswwds_5_cierresultimafecha_to1 ,
                                             bool AV79Cierreswwds_6_dynamicfiltersenabled2 ,
                                             string AV80Cierreswwds_7_dynamicfiltersselector2 ,
                                             short AV81Cierreswwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV82Cierreswwds_9_cierresultimafecha2 ,
                                             DateTime AV83Cierreswwds_10_cierresultimafecha_to2 ,
                                             bool AV84Cierreswwds_11_dynamicfiltersenabled3 ,
                                             string AV85Cierreswwds_12_dynamicfiltersselector3 ,
                                             short AV86Cierreswwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV87Cierreswwds_14_cierresultimafecha3 ,
                                             DateTime AV88Cierreswwds_15_cierresultimafecha_to3 ,
                                             long AV89Cierreswwds_16_tfcierresid ,
                                             long AV90Cierreswwds_17_tfcierresid_to ,
                                             DateTime AV91Cierreswwds_18_tfcierresultimafecha ,
                                             DateTime AV92Cierreswwds_19_tfcierresultimafecha_to ,
                                             string AV94Cierreswwds_21_tfcierresusuario_sel ,
                                             string AV93Cierreswwds_20_tfcierresusuario ,
                                             long A155CierresId ,
                                             string A314CierresUsuario ,
                                             DateTime A313CierresUltimaFecha ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[26];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CierresUsuario], [CierresUltimaFecha], [CierresId]";
         sFromString = " FROM [Cierres]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Cierreswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST([CierresId] AS decimal(18,0))) like '%' + @lV74Cierreswwds_1_filterfulltext) or ( UPPER([CierresUsuario]) like '%' + UPPER(@lV74Cierreswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV76Cierreswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV77Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV77Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV76Cierreswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV77Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV77Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV76Cierreswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV77Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV77Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV76Cierreswwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV77Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV77Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV76Cierreswwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV78Cierreswwds_5_cierresultimafecha_to1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV78Cierreswwds_5_cierresultimafecha_to1)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV79Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV81Cierreswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV82Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV82Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV79Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV81Cierreswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV82Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV82Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV79Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV81Cierreswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV82Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV82Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV79Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV81Cierreswwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV82Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV82Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV79Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV81Cierreswwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV83Cierreswwds_10_cierresultimafecha_to2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV83Cierreswwds_10_cierresultimafecha_to2)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV84Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV86Cierreswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV87Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV87Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV84Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV86Cierreswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV87Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV87Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV84Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV86Cierreswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV87Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV87Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV84Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV86Cierreswwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV87Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV87Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV84Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV86Cierreswwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV88Cierreswwds_15_cierresultimafecha_to3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV88Cierreswwds_15_cierresultimafecha_to3)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! (0==AV89Cierreswwds_16_tfcierresid) )
         {
            AddWhere(sWhereString, "([CierresId] >= @AV89Cierreswwds_16_tfcierresid)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! (0==AV90Cierreswwds_17_tfcierresid_to) )
         {
            AddWhere(sWhereString, "([CierresId] <= @AV90Cierreswwds_17_tfcierresid_to)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Cierreswwds_18_tfcierresultimafecha) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV91Cierreswwds_18_tfcierresultimafecha)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Cierreswwds_19_tfcierresultimafecha_to) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV92Cierreswwds_19_tfcierresultimafecha_to)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Cierreswwds_21_tfcierresusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Cierreswwds_20_tfcierresusuario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CierresUsuario]) like UPPER(@lV93Cierreswwds_20_tfcierresusuario))");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Cierreswwds_21_tfcierresusuario_sel)) && ! ( StringUtil.StrCmp(AV94Cierreswwds_21_tfcierresusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CierresUsuario] = @AV94Cierreswwds_21_tfcierresusuario_sel)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( StringUtil.StrCmp(AV94Cierreswwds_21_tfcierresusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([CierresUsuario] = ''))");
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY [CierresUltimaFecha]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CierresUltimaFecha] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY [CierresId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CierresId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY [CierresUsuario]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY [CierresUsuario] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [CierresId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00J23( IGxContext context ,
                                             string AV74Cierreswwds_1_filterfulltext ,
                                             string AV75Cierreswwds_2_dynamicfiltersselector1 ,
                                             short AV76Cierreswwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV77Cierreswwds_4_cierresultimafecha1 ,
                                             DateTime AV78Cierreswwds_5_cierresultimafecha_to1 ,
                                             bool AV79Cierreswwds_6_dynamicfiltersenabled2 ,
                                             string AV80Cierreswwds_7_dynamicfiltersselector2 ,
                                             short AV81Cierreswwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV82Cierreswwds_9_cierresultimafecha2 ,
                                             DateTime AV83Cierreswwds_10_cierresultimafecha_to2 ,
                                             bool AV84Cierreswwds_11_dynamicfiltersenabled3 ,
                                             string AV85Cierreswwds_12_dynamicfiltersselector3 ,
                                             short AV86Cierreswwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV87Cierreswwds_14_cierresultimafecha3 ,
                                             DateTime AV88Cierreswwds_15_cierresultimafecha_to3 ,
                                             long AV89Cierreswwds_16_tfcierresid ,
                                             long AV90Cierreswwds_17_tfcierresid_to ,
                                             DateTime AV91Cierreswwds_18_tfcierresultimafecha ,
                                             DateTime AV92Cierreswwds_19_tfcierresultimafecha_to ,
                                             string AV94Cierreswwds_21_tfcierresusuario_sel ,
                                             string AV93Cierreswwds_20_tfcierresusuario ,
                                             long A155CierresId ,
                                             string A314CierresUsuario ,
                                             DateTime A313CierresUltimaFecha ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[23];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Cierres]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Cierreswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST([CierresId] AS decimal(18,0))) like '%' + @lV74Cierreswwds_1_filterfulltext) or ( UPPER([CierresUsuario]) like '%' + UPPER(@lV74Cierreswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV76Cierreswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV77Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV77Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV76Cierreswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV77Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV77Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV76Cierreswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV77Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV77Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV76Cierreswwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV77Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV77Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV76Cierreswwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV78Cierreswwds_5_cierresultimafecha_to1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV78Cierreswwds_5_cierresultimafecha_to1)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV79Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV81Cierreswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV82Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV82Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( AV79Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV81Cierreswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV82Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV82Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV79Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV81Cierreswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV82Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV82Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV79Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV81Cierreswwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV82Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV82Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV79Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV81Cierreswwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV83Cierreswwds_10_cierresultimafecha_to2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV83Cierreswwds_10_cierresultimafecha_to2)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV84Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV86Cierreswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV87Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV87Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV84Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV86Cierreswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV87Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV87Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV84Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV86Cierreswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV87Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV87Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV84Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV86Cierreswwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV87Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV87Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV84Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV86Cierreswwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV88Cierreswwds_15_cierresultimafecha_to3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV88Cierreswwds_15_cierresultimafecha_to3)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! (0==AV89Cierreswwds_16_tfcierresid) )
         {
            AddWhere(sWhereString, "([CierresId] >= @AV89Cierreswwds_16_tfcierresid)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! (0==AV90Cierreswwds_17_tfcierresid_to) )
         {
            AddWhere(sWhereString, "([CierresId] <= @AV90Cierreswwds_17_tfcierresid_to)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Cierreswwds_18_tfcierresultimafecha) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV91Cierreswwds_18_tfcierresultimafecha)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Cierreswwds_19_tfcierresultimafecha_to) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV92Cierreswwds_19_tfcierresultimafecha_to)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Cierreswwds_21_tfcierresusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Cierreswwds_20_tfcierresusuario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CierresUsuario]) like UPPER(@lV93Cierreswwds_20_tfcierresusuario))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Cierreswwds_21_tfcierresusuario_sel)) && ! ( StringUtil.StrCmp(AV94Cierreswwds_21_tfcierresusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CierresUsuario] = @AV94Cierreswwds_21_tfcierresusuario_sel)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( StringUtil.StrCmp(AV94Cierreswwds_21_tfcierresusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([CierresUsuario] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00J22(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
               case 1 :
                     return conditional_H00J23(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
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
          Object[] prmH00J22;
          prmH00J22 = new Object[] {
          new ParDef("@lV74Cierreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Cierreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV77Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV77Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV77Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV77Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV78Cierreswwds_5_cierresultimafecha_to1",GXType.Date,8,0) ,
          new ParDef("@AV82Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV82Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV82Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV82Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV83Cierreswwds_10_cierresultimafecha_to2",GXType.Date,8,0) ,
          new ParDef("@AV87Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV87Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV87Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV87Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV88Cierreswwds_15_cierresultimafecha_to3",GXType.Date,8,0) ,
          new ParDef("@AV89Cierreswwds_16_tfcierresid",GXType.Decimal,18,0) ,
          new ParDef("@AV90Cierreswwds_17_tfcierresid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV91Cierreswwds_18_tfcierresultimafecha",GXType.Date,8,0) ,
          new ParDef("@AV92Cierreswwds_19_tfcierresultimafecha_to",GXType.Date,8,0) ,
          new ParDef("@lV93Cierreswwds_20_tfcierresusuario",GXType.Char,30,0) ,
          new ParDef("@AV94Cierreswwds_21_tfcierresusuario_sel",GXType.NChar,30,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00J23;
          prmH00J23 = new Object[] {
          new ParDef("@lV74Cierreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Cierreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV77Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV77Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV77Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV77Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV78Cierreswwds_5_cierresultimafecha_to1",GXType.Date,8,0) ,
          new ParDef("@AV82Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV82Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV82Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV82Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV83Cierreswwds_10_cierresultimafecha_to2",GXType.Date,8,0) ,
          new ParDef("@AV87Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV87Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV87Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV87Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV88Cierreswwds_15_cierresultimafecha_to3",GXType.Date,8,0) ,
          new ParDef("@AV89Cierreswwds_16_tfcierresid",GXType.Decimal,18,0) ,
          new ParDef("@AV90Cierreswwds_17_tfcierresid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV91Cierreswwds_18_tfcierresultimafecha",GXType.Date,8,0) ,
          new ParDef("@AV92Cierreswwds_19_tfcierresultimafecha_to",GXType.Date,8,0) ,
          new ParDef("@lV93Cierreswwds_20_tfcierresusuario",GXType.Char,30,0) ,
          new ParDef("@AV94Cierreswwds_21_tfcierresusuario_sel",GXType.NChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00J22", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00J22,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00J23", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00J23,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
