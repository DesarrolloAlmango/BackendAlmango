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
   public class incidenciaww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public incidenciaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public incidenciaww( IGxContext context )
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
         cmbavIncidenciaorigen1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavIncidenciaorigen2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavIncidenciaorigen3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbIncidenciaOrigen = new GXCombobox();
         cmbIncidenciaEstado = new GXCombobox();
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
         nRC_GXsfl_120 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_120"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_120_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_120_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_120_idx = GetPar( "sGXsfl_120_idx");
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
         cmbavIncidenciaorigen1.FromJSonString( GetNextPar( ));
         AV20IncidenciaOrigen1 = GetPar( "IncidenciaOrigen1");
         AV21MotivoNombre1 = GetPar( "MotivoNombre1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         cmbavIncidenciaorigen2.FromJSonString( GetNextPar( ));
         AV25IncidenciaOrigen2 = GetPar( "IncidenciaOrigen2");
         AV26MotivoNombre2 = GetPar( "MotivoNombre2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         cmbavIncidenciaorigen3.FromJSonString( GetNextPar( ));
         AV30IncidenciaOrigen3 = GetPar( "IncidenciaOrigen3");
         AV31MotivoNombre3 = GetPar( "MotivoNombre3");
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38ColumnsSelector);
         AV79Pgmname = GetPar( "Pgmname");
         AV17FilterFullText = GetPar( "FilterFullText");
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV27DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV44TFIncidenciaId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFIncidenciaId"), "."), 18, MidpointRounding.ToEven));
         AV45TFIncidenciaId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFIncidenciaId_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV47TFIncidenciaOrigen_Sels);
         AV48TFIncidenciaCodRef = GetPar( "TFIncidenciaCodRef");
         AV49TFIncidenciaCodRef_Sel = GetPar( "TFIncidenciaCodRef_Sel");
         AV50TFMotivoNombre = GetPar( "TFMotivoNombre");
         AV51TFMotivoNombre_Sel = GetPar( "TFMotivoNombre_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV53TFIncidenciaEstado_Sels);
         AV54TFIncidenciaUsrAlta = GetPar( "TFIncidenciaUsrAlta");
         AV55TFIncidenciaUsrAlta_Sel = GetPar( "TFIncidenciaUsrAlta_Sel");
         AV56TFIncidenciaFechaAlta = context.localUtil.ParseDateParm( GetPar( "TFIncidenciaFechaAlta"));
         AV57TFIncidenciaFechaAlta_To = context.localUtil.ParseDateParm( GetPar( "TFIncidenciaFechaAlta_To"));
         AV61TFIncidenciaUsrActualizacion = GetPar( "TFIncidenciaUsrActualizacion");
         AV62TFIncidenciaUsrActualizacion_Sel = GetPar( "TFIncidenciaUsrActualizacion_Sel");
         AV63TFIncidenciaFechaActualizacion = context.localUtil.ParseDateParm( GetPar( "TFIncidenciaFechaActualizacion"));
         AV64TFIncidenciaFechaActualizacion_To = context.localUtil.ParseDateParm( GetPar( "TFIncidenciaFechaActualizacion_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV33DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV32DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IncidenciaOrigen1, AV21MotivoNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25IncidenciaOrigen2, AV26MotivoNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30IncidenciaOrigen3, AV31MotivoNombre3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV79Pgmname, AV17FilterFullText, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV44TFIncidenciaId, AV45TFIncidenciaId_To, AV47TFIncidenciaOrigen_Sels, AV48TFIncidenciaCodRef, AV49TFIncidenciaCodRef_Sel, AV50TFMotivoNombre, AV51TFMotivoNombre_Sel, AV53TFIncidenciaEstado_Sels, AV54TFIncidenciaUsrAlta, AV55TFIncidenciaUsrAlta_Sel, AV56TFIncidenciaFechaAlta, AV57TFIncidenciaFechaAlta_To, AV61TFIncidenciaUsrActualizacion, AV62TFIncidenciaUsrActualizacion_Sel, AV63TFIncidenciaFechaActualizacion, AV64TFIncidenciaFechaActualizacion_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
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
         PA842( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START842( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("incidenciaww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV79Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV79Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vINCIDENCIAORIGEN1", StringUtil.RTrim( AV20IncidenciaOrigen1));
         GxWebStd.gx_hidden_field( context, "GXH_vMOTIVONOMBRE1", StringUtil.RTrim( AV21MotivoNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vINCIDENCIAORIGEN2", StringUtil.RTrim( AV25IncidenciaOrigen2));
         GxWebStd.gx_hidden_field( context, "GXH_vMOTIVONOMBRE2", StringUtil.RTrim( AV26MotivoNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV28DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vINCIDENCIAORIGEN3", StringUtil.RTrim( AV30IncidenciaOrigen3));
         GxWebStd.gx_hidden_field( context, "GXH_vMOTIVONOMBRE3", StringUtil.RTrim( AV31MotivoNombre3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_120", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_120), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV72GridAppliedFilters);
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV68DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV68DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_INCIDENCIAFECHAALTAAUXDATETO", context.localUtil.DToC( AV59DDO_IncidenciaFechaAltaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_INCIDENCIAFECHAACTUALIZACIONAUXDATETO", context.localUtil.DToC( AV66DDO_IncidenciaFechaActualizacionAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV79Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV79Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV27DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFIncidenciaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TFIncidenciaId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFINCIDENCIAORIGEN_SELS", AV47TFIncidenciaOrigen_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFINCIDENCIAORIGEN_SELS", AV47TFIncidenciaOrigen_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIACODREF", AV48TFIncidenciaCodRef);
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIACODREF_SEL", AV49TFIncidenciaCodRef_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMOTIVONOMBRE", StringUtil.RTrim( AV50TFMotivoNombre));
         GxWebStd.gx_hidden_field( context, "vTFMOTIVONOMBRE_SEL", StringUtil.RTrim( AV51TFMotivoNombre_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFINCIDENCIAESTADO_SELS", AV53TFIncidenciaEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFINCIDENCIAESTADO_SELS", AV53TFIncidenciaEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAUSRALTA", StringUtil.RTrim( AV54TFIncidenciaUsrAlta));
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAUSRALTA_SEL", StringUtil.RTrim( AV55TFIncidenciaUsrAlta_Sel));
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAFECHAALTA", context.localUtil.DToC( AV56TFIncidenciaFechaAlta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAFECHAALTA_TO", context.localUtil.DToC( AV57TFIncidenciaFechaAlta_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAUSRACTUALIZACION", StringUtil.RTrim( AV61TFIncidenciaUsrActualizacion));
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAUSRACTUALIZACION_SEL", StringUtil.RTrim( AV62TFIncidenciaUsrActualizacion_Sel));
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAFECHAACTUALIZACION", context.localUtil.DToC( AV63TFIncidenciaFechaActualizacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAFECHAACTUALIZACION_TO", context.localUtil.DToC( AV64TFIncidenciaFechaActualizacion_To, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAORIGEN_SELSJSON", AV46TFIncidenciaOrigen_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFINCIDENCIAESTADO_SELSJSON", AV52TFIncidenciaEstado_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vDDO_INCIDENCIAFECHAALTAAUXDATE", context.localUtil.DToC( AV58DDO_IncidenciaFechaAltaAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_INCIDENCIAFECHAACTUALIZACIONAUXDATE", context.localUtil.DToC( AV65DDO_IncidenciaFechaActualizacionAuxDate, 0, "/"));
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
            WE842( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT842( ) ;
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
         return formatLink("incidenciaww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "IncidenciaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Incidencia", "") ;
      }

      protected void WB840( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_842( true) ;
         }
         else
         {
            wb_table1_25_842( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_842e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_IncidenciaWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_842( true) ;
         }
         else
         {
            wb_table2_49_842( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_842e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "", true, 0, "HLP_IncidenciaWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_74_842( true) ;
         }
         else
         {
            wb_table3_74_842( false) ;
         }
         return  ;
      }

      protected void wb_table3_74_842e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_IncidenciaWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_99_842( true) ;
         }
         else
         {
            wb_table4_99_842( false) ;
         }
         return  ;
      }

      protected void wb_table4_99_842e( bool wbgen )
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
            StartGridControl120( ) ;
         }
         if ( wbEnd == 120 )
         {
            wbEnd = 0;
            nRC_GXsfl_120 = (int)(nGXsfl_120_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV70GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV71GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV72GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_IncidenciaWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV68DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV68DDO_TitleSettingsIcons);
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
               GxWebStd.gx_hidden_field( context, "W0146"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0146"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_120_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0146"+"");
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
            GxWebStd.gx_div_start( context, divDdo_incidenciafechaaltaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_incidenciafechaaltaauxdatetext_Internalname, AV60DDO_IncidenciaFechaAltaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV60DDO_IncidenciaFechaAltaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_incidenciafechaaltaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_IncidenciaWW.htm");
            /* User Defined Control */
            ucTfincidenciafechaalta_rangepicker.SetProperty("Start Date", AV58DDO_IncidenciaFechaAltaAuxDate);
            ucTfincidenciafechaalta_rangepicker.SetProperty("End Date", AV59DDO_IncidenciaFechaAltaAuxDateTo);
            ucTfincidenciafechaalta_rangepicker.Render(context, "wwp.daterangepicker", Tfincidenciafechaalta_rangepicker_Internalname, "TFINCIDENCIAFECHAALTA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_incidenciafechaactualizacionauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_incidenciafechaactualizacionauxdatetext_Internalname, AV67DDO_IncidenciaFechaActualizacionAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV67DDO_IncidenciaFechaActualizacionAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_incidenciafechaactualizacionauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_IncidenciaWW.htm");
            /* User Defined Control */
            ucTfincidenciafechaactualizacion_rangepicker.SetProperty("Start Date", AV65DDO_IncidenciaFechaActualizacionAuxDate);
            ucTfincidenciafechaactualizacion_rangepicker.SetProperty("End Date", AV66DDO_IncidenciaFechaActualizacionAuxDateTo);
            ucTfincidenciafechaactualizacion_rangepicker.Render(context, "wwp.daterangepicker", Tfincidenciafechaactualizacion_rangepicker_Internalname, "TFINCIDENCIAFECHAACTUALIZACION_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 120 )
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

      protected void START842( )
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
         Form.Meta.addItem("description", context.GetMessage( " Incidencia", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP840( ) ;
      }

      protected void WS842( )
      {
         START842( ) ;
         EVT842( ) ;
      }

      protected void EVT842( )
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
                              E11842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E14842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E15842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E16842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E17842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E18842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E19842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E20842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E21842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E22842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E24842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E25842 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E26842 ();
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
                              nGXsfl_120_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
                              SubsflControlProps_1202( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV73GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV73GridActions), 4, 0));
                              A603IncidenciaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtIncidenciaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbIncidenciaOrigen.Name = cmbIncidenciaOrigen_Internalname;
                              cmbIncidenciaOrigen.CurrentValue = cgiGet( cmbIncidenciaOrigen_Internalname);
                              A611IncidenciaOrigen = cgiGet( cmbIncidenciaOrigen_Internalname);
                              A606IncidenciaCodRef = cgiGet( edtIncidenciaCodRef_Internalname);
                              A604MotivoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMotivoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A616MotivoNombre = cgiGet( edtMotivoNombre_Internalname);
                              cmbIncidenciaEstado.Name = cmbIncidenciaEstado_Internalname;
                              cmbIncidenciaEstado.CurrentValue = cgiGet( cmbIncidenciaEstado_Internalname);
                              A608IncidenciaEstado = cgiGet( cmbIncidenciaEstado_Internalname);
                              A615IncidenciaUsrAlta = cgiGet( edtIncidenciaUsrAlta_Internalname);
                              A610IncidenciaFechaAlta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtIncidenciaFechaAlta_Internalname), 0));
                              A614IncidenciaUsrActualizacion = cgiGet( edtIncidenciaUsrActualizacion_Internalname);
                              A609IncidenciaFechaActualizacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtIncidenciaFechaActualizacion_Internalname), 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E27842 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E28842 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E29842 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E30842 ();
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
                                       /* Set Refresh If Incidenciaorigen1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vINCIDENCIAORIGEN1"), AV20IncidenciaOrigen1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Motivonombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMOTIVONOMBRE1"), AV21MotivoNombre1) != 0 )
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
                                       /* Set Refresh If Incidenciaorigen2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vINCIDENCIAORIGEN2"), AV25IncidenciaOrigen2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Motivonombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMOTIVONOMBRE2"), AV26MotivoNombre2) != 0 )
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
                                       /* Set Refresh If Incidenciaorigen3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vINCIDENCIAORIGEN3"), AV30IncidenciaOrigen3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Motivonombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vMOTIVONOMBRE3"), AV31MotivoNombre3) != 0 )
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
                        if ( nCmpId == 146 )
                        {
                           OldWwpaux_wc = cgiGet( "W0146");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0146", "", sEvt);
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

      protected void WE842( )
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

      protected void PA842( )
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
         SubsflControlProps_1202( ) ;
         while ( nGXsfl_120_idx <= nRC_GXsfl_120 )
         {
            sendrow_1202( ) ;
            nGXsfl_120_idx = ((subGrid_Islastpage==1)&&(nGXsfl_120_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_120_idx+1);
            sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
            SubsflControlProps_1202( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV20IncidenciaOrigen1 ,
                                       string AV21MotivoNombre1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       string AV25IncidenciaOrigen2 ,
                                       string AV26MotivoNombre2 ,
                                       string AV28DynamicFiltersSelector3 ,
                                       short AV29DynamicFiltersOperator3 ,
                                       string AV30IncidenciaOrigen3 ,
                                       string AV31MotivoNombre3 ,
                                       short AV43ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ,
                                       string AV79Pgmname ,
                                       string AV17FilterFullText ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       bool AV27DynamicFiltersEnabled3 ,
                                       long AV44TFIncidenciaId ,
                                       long AV45TFIncidenciaId_To ,
                                       GxSimpleCollection<string> AV47TFIncidenciaOrigen_Sels ,
                                       string AV48TFIncidenciaCodRef ,
                                       string AV49TFIncidenciaCodRef_Sel ,
                                       string AV50TFMotivoNombre ,
                                       string AV51TFMotivoNombre_Sel ,
                                       GxSimpleCollection<string> AV53TFIncidenciaEstado_Sels ,
                                       string AV54TFIncidenciaUsrAlta ,
                                       string AV55TFIncidenciaUsrAlta_Sel ,
                                       DateTime AV56TFIncidenciaFechaAlta ,
                                       DateTime AV57TFIncidenciaFechaAlta_To ,
                                       string AV61TFIncidenciaUsrActualizacion ,
                                       string AV62TFIncidenciaUsrActualizacion_Sel ,
                                       DateTime AV63TFIncidenciaFechaActualizacion ,
                                       DateTime AV64TFIncidenciaFechaActualizacion_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV33DynamicFiltersIgnoreFirst ,
                                       bool AV32DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF842( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A603IncidenciaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "INCIDENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A603IncidenciaId), 18, 0, ".", "")));
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
         if ( cmbavIncidenciaorigen1.ItemCount > 0 )
         {
            AV20IncidenciaOrigen1 = cmbavIncidenciaorigen1.getValidValue(AV20IncidenciaOrigen1);
            AssignAttri("", false, "AV20IncidenciaOrigen1", AV20IncidenciaOrigen1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavIncidenciaorigen1.CurrentValue = StringUtil.RTrim( AV20IncidenciaOrigen1);
            AssignProp("", false, cmbavIncidenciaorigen1_Internalname, "Values", cmbavIncidenciaorigen1.ToJavascriptSource(), true);
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
         if ( cmbavIncidenciaorigen2.ItemCount > 0 )
         {
            AV25IncidenciaOrigen2 = cmbavIncidenciaorigen2.getValidValue(AV25IncidenciaOrigen2);
            AssignAttri("", false, "AV25IncidenciaOrigen2", AV25IncidenciaOrigen2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavIncidenciaorigen2.CurrentValue = StringUtil.RTrim( AV25IncidenciaOrigen2);
            AssignProp("", false, cmbavIncidenciaorigen2_Internalname, "Values", cmbavIncidenciaorigen2.ToJavascriptSource(), true);
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
         if ( cmbavIncidenciaorigen3.ItemCount > 0 )
         {
            AV30IncidenciaOrigen3 = cmbavIncidenciaorigen3.getValidValue(AV30IncidenciaOrigen3);
            AssignAttri("", false, "AV30IncidenciaOrigen3", AV30IncidenciaOrigen3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavIncidenciaorigen3.CurrentValue = StringUtil.RTrim( AV30IncidenciaOrigen3);
            AssignProp("", false, cmbavIncidenciaorigen3_Internalname, "Values", cmbavIncidenciaorigen3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF842( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV79Pgmname = "IncidenciaWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV80Incidenciawwds_1_filterfulltext = AV17FilterFullText;
         AV81Incidenciawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV82Incidenciawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV83Incidenciawwds_4_incidenciaorigen1 = AV20IncidenciaOrigen1;
         AV84Incidenciawwds_5_motivonombre1 = AV21MotivoNombre1;
         AV85Incidenciawwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Incidenciawwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Incidenciawwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Incidenciawwds_9_incidenciaorigen2 = AV25IncidenciaOrigen2;
         AV89Incidenciawwds_10_motivonombre2 = AV26MotivoNombre2;
         AV90Incidenciawwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV91Incidenciawwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV92Incidenciawwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV93Incidenciawwds_14_incidenciaorigen3 = AV30IncidenciaOrigen3;
         AV94Incidenciawwds_15_motivonombre3 = AV31MotivoNombre3;
         AV95Incidenciawwds_16_tfincidenciaid = AV44TFIncidenciaId;
         AV96Incidenciawwds_17_tfincidenciaid_to = AV45TFIncidenciaId_To;
         AV97Incidenciawwds_18_tfincidenciaorigen_sels = AV47TFIncidenciaOrigen_Sels;
         AV98Incidenciawwds_19_tfincidenciacodref = AV48TFIncidenciaCodRef;
         AV99Incidenciawwds_20_tfincidenciacodref_sel = AV49TFIncidenciaCodRef_Sel;
         AV100Incidenciawwds_21_tfmotivonombre = AV50TFMotivoNombre;
         AV101Incidenciawwds_22_tfmotivonombre_sel = AV51TFMotivoNombre_Sel;
         AV102Incidenciawwds_23_tfincidenciaestado_sels = AV53TFIncidenciaEstado_Sels;
         AV103Incidenciawwds_24_tfincidenciausralta = AV54TFIncidenciaUsrAlta;
         AV104Incidenciawwds_25_tfincidenciausralta_sel = AV55TFIncidenciaUsrAlta_Sel;
         AV105Incidenciawwds_26_tfincidenciafechaalta = AV56TFIncidenciaFechaAlta;
         AV106Incidenciawwds_27_tfincidenciafechaalta_to = AV57TFIncidenciaFechaAlta_To;
         AV107Incidenciawwds_28_tfincidenciausractualizacion = AV61TFIncidenciaUsrActualizacion;
         AV108Incidenciawwds_29_tfincidenciausractualizacion_sel = AV62TFIncidenciaUsrActualizacion_Sel;
         AV109Incidenciawwds_30_tfincidenciafechaactualizacion = AV63TFIncidenciaFechaActualizacion;
         AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV64TFIncidenciaFechaActualizacion_To;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A611IncidenciaOrigen ,
                                              AV97Incidenciawwds_18_tfincidenciaorigen_sels ,
                                              A608IncidenciaEstado ,
                                              AV102Incidenciawwds_23_tfincidenciaestado_sels ,
                                              AV81Incidenciawwds_2_dynamicfiltersselector1 ,
                                              AV83Incidenciawwds_4_incidenciaorigen1 ,
                                              AV82Incidenciawwds_3_dynamicfiltersoperator1 ,
                                              AV84Incidenciawwds_5_motivonombre1 ,
                                              AV85Incidenciawwds_6_dynamicfiltersenabled2 ,
                                              AV86Incidenciawwds_7_dynamicfiltersselector2 ,
                                              AV88Incidenciawwds_9_incidenciaorigen2 ,
                                              AV87Incidenciawwds_8_dynamicfiltersoperator2 ,
                                              AV89Incidenciawwds_10_motivonombre2 ,
                                              AV90Incidenciawwds_11_dynamicfiltersenabled3 ,
                                              AV91Incidenciawwds_12_dynamicfiltersselector3 ,
                                              AV93Incidenciawwds_14_incidenciaorigen3 ,
                                              AV92Incidenciawwds_13_dynamicfiltersoperator3 ,
                                              AV94Incidenciawwds_15_motivonombre3 ,
                                              AV95Incidenciawwds_16_tfincidenciaid ,
                                              AV96Incidenciawwds_17_tfincidenciaid_to ,
                                              AV97Incidenciawwds_18_tfincidenciaorigen_sels.Count ,
                                              AV99Incidenciawwds_20_tfincidenciacodref_sel ,
                                              AV98Incidenciawwds_19_tfincidenciacodref ,
                                              AV101Incidenciawwds_22_tfmotivonombre_sel ,
                                              AV100Incidenciawwds_21_tfmotivonombre ,
                                              AV102Incidenciawwds_23_tfincidenciaestado_sels.Count ,
                                              AV104Incidenciawwds_25_tfincidenciausralta_sel ,
                                              AV103Incidenciawwds_24_tfincidenciausralta ,
                                              AV105Incidenciawwds_26_tfincidenciafechaalta ,
                                              AV106Incidenciawwds_27_tfincidenciafechaalta_to ,
                                              AV108Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                              AV107Incidenciawwds_28_tfincidenciausractualizacion ,
                                              AV109Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                              AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                              A616MotivoNombre ,
                                              A603IncidenciaId ,
                                              A606IncidenciaCodRef ,
                                              A615IncidenciaUsrAlta ,
                                              A610IncidenciaFechaAlta ,
                                              A614IncidenciaUsrActualizacion ,
                                              A609IncidenciaFechaActualizacion ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV80Incidenciawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV84Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV84Incidenciawwds_5_motivonombre1), 80, "%");
         lV84Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV84Incidenciawwds_5_motivonombre1), 80, "%");
         lV89Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV89Incidenciawwds_10_motivonombre2), 80, "%");
         lV89Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV89Incidenciawwds_10_motivonombre2), 80, "%");
         lV94Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV94Incidenciawwds_15_motivonombre3), 80, "%");
         lV94Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV94Incidenciawwds_15_motivonombre3), 80, "%");
         lV98Incidenciawwds_19_tfincidenciacodref = StringUtil.Concat( StringUtil.RTrim( AV98Incidenciawwds_19_tfincidenciacodref), "%", "");
         lV100Incidenciawwds_21_tfmotivonombre = StringUtil.PadR( StringUtil.RTrim( AV100Incidenciawwds_21_tfmotivonombre), 80, "%");
         lV103Incidenciawwds_24_tfincidenciausralta = StringUtil.PadR( StringUtil.RTrim( AV103Incidenciawwds_24_tfincidenciausralta), 20, "%");
         lV107Incidenciawwds_28_tfincidenciausractualizacion = StringUtil.PadR( StringUtil.RTrim( AV107Incidenciawwds_28_tfincidenciausractualizacion), 20, "%");
         /* Using cursor H00842 */
         pr_default.execute(0, new Object[] {AV83Incidenciawwds_4_incidenciaorigen1, lV84Incidenciawwds_5_motivonombre1, lV84Incidenciawwds_5_motivonombre1, AV88Incidenciawwds_9_incidenciaorigen2, lV89Incidenciawwds_10_motivonombre2, lV89Incidenciawwds_10_motivonombre2, AV93Incidenciawwds_14_incidenciaorigen3, lV94Incidenciawwds_15_motivonombre3, lV94Incidenciawwds_15_motivonombre3, AV95Incidenciawwds_16_tfincidenciaid, AV96Incidenciawwds_17_tfincidenciaid_to, lV98Incidenciawwds_19_tfincidenciacodref, AV99Incidenciawwds_20_tfincidenciacodref_sel, lV100Incidenciawwds_21_tfmotivonombre, AV101Incidenciawwds_22_tfmotivonombre_sel, lV103Incidenciawwds_24_tfincidenciausralta, AV104Incidenciawwds_25_tfincidenciausralta_sel, AV105Incidenciawwds_26_tfincidenciafechaalta, AV106Incidenciawwds_27_tfincidenciafechaalta_to, lV107Incidenciawwds_28_tfincidenciausractualizacion, AV108Incidenciawwds_29_tfincidenciausractualizacion_sel, AV109Incidenciawwds_30_tfincidenciafechaactualizacion, AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A609IncidenciaFechaActualizacion = H00842_A609IncidenciaFechaActualizacion[0];
            A614IncidenciaUsrActualizacion = H00842_A614IncidenciaUsrActualizacion[0];
            A610IncidenciaFechaAlta = H00842_A610IncidenciaFechaAlta[0];
            A615IncidenciaUsrAlta = H00842_A615IncidenciaUsrAlta[0];
            A608IncidenciaEstado = H00842_A608IncidenciaEstado[0];
            A616MotivoNombre = H00842_A616MotivoNombre[0];
            A604MotivoId = H00842_A604MotivoId[0];
            A606IncidenciaCodRef = H00842_A606IncidenciaCodRef[0];
            A611IncidenciaOrigen = H00842_A611IncidenciaOrigen[0];
            A603IncidenciaId = H00842_A603IncidenciaId[0];
            A616MotivoNombre = H00842_A616MotivoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Incidenciawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A603IncidenciaId), 18, 0) , StringUtil.PadR( "%" + AV80Incidenciawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "solicitudes", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A611IncidenciaOrigen, "SOL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedores", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesionales", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRF") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A606IncidenciaCodRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A616MotivoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A608IncidenciaEstado, "ANU") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A615IncidenciaUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A614IncidenciaUsrActualizacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
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

      protected void RF842( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 120;
         /* Execute user event: Refresh */
         E28842 ();
         nGXsfl_120_idx = 1;
         sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
         SubsflControlProps_1202( ) ;
         bGXsfl_120_Refreshing = true;
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
            SubsflControlProps_1202( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A611IncidenciaOrigen ,
                                                 AV97Incidenciawwds_18_tfincidenciaorigen_sels ,
                                                 A608IncidenciaEstado ,
                                                 AV102Incidenciawwds_23_tfincidenciaestado_sels ,
                                                 AV81Incidenciawwds_2_dynamicfiltersselector1 ,
                                                 AV83Incidenciawwds_4_incidenciaorigen1 ,
                                                 AV82Incidenciawwds_3_dynamicfiltersoperator1 ,
                                                 AV84Incidenciawwds_5_motivonombre1 ,
                                                 AV85Incidenciawwds_6_dynamicfiltersenabled2 ,
                                                 AV86Incidenciawwds_7_dynamicfiltersselector2 ,
                                                 AV88Incidenciawwds_9_incidenciaorigen2 ,
                                                 AV87Incidenciawwds_8_dynamicfiltersoperator2 ,
                                                 AV89Incidenciawwds_10_motivonombre2 ,
                                                 AV90Incidenciawwds_11_dynamicfiltersenabled3 ,
                                                 AV91Incidenciawwds_12_dynamicfiltersselector3 ,
                                                 AV93Incidenciawwds_14_incidenciaorigen3 ,
                                                 AV92Incidenciawwds_13_dynamicfiltersoperator3 ,
                                                 AV94Incidenciawwds_15_motivonombre3 ,
                                                 AV95Incidenciawwds_16_tfincidenciaid ,
                                                 AV96Incidenciawwds_17_tfincidenciaid_to ,
                                                 AV97Incidenciawwds_18_tfincidenciaorigen_sels.Count ,
                                                 AV99Incidenciawwds_20_tfincidenciacodref_sel ,
                                                 AV98Incidenciawwds_19_tfincidenciacodref ,
                                                 AV101Incidenciawwds_22_tfmotivonombre_sel ,
                                                 AV100Incidenciawwds_21_tfmotivonombre ,
                                                 AV102Incidenciawwds_23_tfincidenciaestado_sels.Count ,
                                                 AV104Incidenciawwds_25_tfincidenciausralta_sel ,
                                                 AV103Incidenciawwds_24_tfincidenciausralta ,
                                                 AV105Incidenciawwds_26_tfincidenciafechaalta ,
                                                 AV106Incidenciawwds_27_tfincidenciafechaalta_to ,
                                                 AV108Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                                 AV107Incidenciawwds_28_tfincidenciausractualizacion ,
                                                 AV109Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                                 AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                                 A616MotivoNombre ,
                                                 A603IncidenciaId ,
                                                 A606IncidenciaCodRef ,
                                                 A615IncidenciaUsrAlta ,
                                                 A610IncidenciaFechaAlta ,
                                                 A614IncidenciaUsrActualizacion ,
                                                 A609IncidenciaFechaActualizacion ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV80Incidenciawwds_1_filterfulltext } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV84Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV84Incidenciawwds_5_motivonombre1), 80, "%");
            lV84Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV84Incidenciawwds_5_motivonombre1), 80, "%");
            lV89Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV89Incidenciawwds_10_motivonombre2), 80, "%");
            lV89Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV89Incidenciawwds_10_motivonombre2), 80, "%");
            lV94Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV94Incidenciawwds_15_motivonombre3), 80, "%");
            lV94Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV94Incidenciawwds_15_motivonombre3), 80, "%");
            lV98Incidenciawwds_19_tfincidenciacodref = StringUtil.Concat( StringUtil.RTrim( AV98Incidenciawwds_19_tfincidenciacodref), "%", "");
            lV100Incidenciawwds_21_tfmotivonombre = StringUtil.PadR( StringUtil.RTrim( AV100Incidenciawwds_21_tfmotivonombre), 80, "%");
            lV103Incidenciawwds_24_tfincidenciausralta = StringUtil.PadR( StringUtil.RTrim( AV103Incidenciawwds_24_tfincidenciausralta), 20, "%");
            lV107Incidenciawwds_28_tfincidenciausractualizacion = StringUtil.PadR( StringUtil.RTrim( AV107Incidenciawwds_28_tfincidenciausractualizacion), 20, "%");
            /* Using cursor H00843 */
            pr_default.execute(1, new Object[] {AV83Incidenciawwds_4_incidenciaorigen1, lV84Incidenciawwds_5_motivonombre1, lV84Incidenciawwds_5_motivonombre1, AV88Incidenciawwds_9_incidenciaorigen2, lV89Incidenciawwds_10_motivonombre2, lV89Incidenciawwds_10_motivonombre2, AV93Incidenciawwds_14_incidenciaorigen3, lV94Incidenciawwds_15_motivonombre3, lV94Incidenciawwds_15_motivonombre3, AV95Incidenciawwds_16_tfincidenciaid, AV96Incidenciawwds_17_tfincidenciaid_to, lV98Incidenciawwds_19_tfincidenciacodref, AV99Incidenciawwds_20_tfincidenciacodref_sel, lV100Incidenciawwds_21_tfmotivonombre, AV101Incidenciawwds_22_tfmotivonombre_sel, lV103Incidenciawwds_24_tfincidenciausralta, AV104Incidenciawwds_25_tfincidenciausralta_sel, AV105Incidenciawwds_26_tfincidenciafechaalta, AV106Incidenciawwds_27_tfincidenciafechaalta_to, lV107Incidenciawwds_28_tfincidenciausractualizacion, AV108Incidenciawwds_29_tfincidenciausractualizacion_sel, AV109Incidenciawwds_30_tfincidenciafechaactualizacion, AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to});
            nGXsfl_120_idx = 1;
            sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
            SubsflControlProps_1202( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A609IncidenciaFechaActualizacion = H00843_A609IncidenciaFechaActualizacion[0];
               A614IncidenciaUsrActualizacion = H00843_A614IncidenciaUsrActualizacion[0];
               A610IncidenciaFechaAlta = H00843_A610IncidenciaFechaAlta[0];
               A615IncidenciaUsrAlta = H00843_A615IncidenciaUsrAlta[0];
               A608IncidenciaEstado = H00843_A608IncidenciaEstado[0];
               A616MotivoNombre = H00843_A616MotivoNombre[0];
               A604MotivoId = H00843_A604MotivoId[0];
               A606IncidenciaCodRef = H00843_A606IncidenciaCodRef[0];
               A611IncidenciaOrigen = H00843_A611IncidenciaOrigen[0];
               A603IncidenciaId = H00843_A603IncidenciaId[0];
               A616MotivoNombre = H00843_A616MotivoNombre[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Incidenciawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A603IncidenciaId), 18, 0) , StringUtil.PadR( "%" + AV80Incidenciawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "solicitudes", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A611IncidenciaOrigen, "SOL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedores", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRV") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "profesionales", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRF") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A606IncidenciaCodRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A616MotivoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PRO") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A608IncidenciaEstado, "ANU") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A615IncidenciaUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A614IncidenciaUsrActualizacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV80Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E29842 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 120;
            WB840( ) ;
         }
         bGXsfl_120_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes842( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV79Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV79Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INCIDENCIAID"+"_"+sGXsfl_120_idx, GetSecureSignedToken( sGXsfl_120_idx, context.localUtil.Format( (decimal)(A603IncidenciaId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         AV80Incidenciawwds_1_filterfulltext = AV17FilterFullText;
         AV81Incidenciawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV82Incidenciawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV83Incidenciawwds_4_incidenciaorigen1 = AV20IncidenciaOrigen1;
         AV84Incidenciawwds_5_motivonombre1 = AV21MotivoNombre1;
         AV85Incidenciawwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Incidenciawwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Incidenciawwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Incidenciawwds_9_incidenciaorigen2 = AV25IncidenciaOrigen2;
         AV89Incidenciawwds_10_motivonombre2 = AV26MotivoNombre2;
         AV90Incidenciawwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV91Incidenciawwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV92Incidenciawwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV93Incidenciawwds_14_incidenciaorigen3 = AV30IncidenciaOrigen3;
         AV94Incidenciawwds_15_motivonombre3 = AV31MotivoNombre3;
         AV95Incidenciawwds_16_tfincidenciaid = AV44TFIncidenciaId;
         AV96Incidenciawwds_17_tfincidenciaid_to = AV45TFIncidenciaId_To;
         AV97Incidenciawwds_18_tfincidenciaorigen_sels = AV47TFIncidenciaOrigen_Sels;
         AV98Incidenciawwds_19_tfincidenciacodref = AV48TFIncidenciaCodRef;
         AV99Incidenciawwds_20_tfincidenciacodref_sel = AV49TFIncidenciaCodRef_Sel;
         AV100Incidenciawwds_21_tfmotivonombre = AV50TFMotivoNombre;
         AV101Incidenciawwds_22_tfmotivonombre_sel = AV51TFMotivoNombre_Sel;
         AV102Incidenciawwds_23_tfincidenciaestado_sels = AV53TFIncidenciaEstado_Sels;
         AV103Incidenciawwds_24_tfincidenciausralta = AV54TFIncidenciaUsrAlta;
         AV104Incidenciawwds_25_tfincidenciausralta_sel = AV55TFIncidenciaUsrAlta_Sel;
         AV105Incidenciawwds_26_tfincidenciafechaalta = AV56TFIncidenciaFechaAlta;
         AV106Incidenciawwds_27_tfincidenciafechaalta_to = AV57TFIncidenciaFechaAlta_To;
         AV107Incidenciawwds_28_tfincidenciausractualizacion = AV61TFIncidenciaUsrActualizacion;
         AV108Incidenciawwds_29_tfincidenciausractualizacion_sel = AV62TFIncidenciaUsrActualizacion_Sel;
         AV109Incidenciawwds_30_tfincidenciafechaactualizacion = AV63TFIncidenciaFechaActualizacion;
         AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV64TFIncidenciaFechaActualizacion_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IncidenciaOrigen1, AV21MotivoNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25IncidenciaOrigen2, AV26MotivoNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30IncidenciaOrigen3, AV31MotivoNombre3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV79Pgmname, AV17FilterFullText, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV44TFIncidenciaId, AV45TFIncidenciaId_To, AV47TFIncidenciaOrigen_Sels, AV48TFIncidenciaCodRef, AV49TFIncidenciaCodRef_Sel, AV50TFMotivoNombre, AV51TFMotivoNombre_Sel, AV53TFIncidenciaEstado_Sels, AV54TFIncidenciaUsrAlta, AV55TFIncidenciaUsrAlta_Sel, AV56TFIncidenciaFechaAlta, AV57TFIncidenciaFechaAlta_To, AV61TFIncidenciaUsrActualizacion, AV62TFIncidenciaUsrActualizacion_Sel, AV63TFIncidenciaFechaActualizacion, AV64TFIncidenciaFechaActualizacion_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV80Incidenciawwds_1_filterfulltext = AV17FilterFullText;
         AV81Incidenciawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV82Incidenciawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV83Incidenciawwds_4_incidenciaorigen1 = AV20IncidenciaOrigen1;
         AV84Incidenciawwds_5_motivonombre1 = AV21MotivoNombre1;
         AV85Incidenciawwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Incidenciawwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Incidenciawwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Incidenciawwds_9_incidenciaorigen2 = AV25IncidenciaOrigen2;
         AV89Incidenciawwds_10_motivonombre2 = AV26MotivoNombre2;
         AV90Incidenciawwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV91Incidenciawwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV92Incidenciawwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV93Incidenciawwds_14_incidenciaorigen3 = AV30IncidenciaOrigen3;
         AV94Incidenciawwds_15_motivonombre3 = AV31MotivoNombre3;
         AV95Incidenciawwds_16_tfincidenciaid = AV44TFIncidenciaId;
         AV96Incidenciawwds_17_tfincidenciaid_to = AV45TFIncidenciaId_To;
         AV97Incidenciawwds_18_tfincidenciaorigen_sels = AV47TFIncidenciaOrigen_Sels;
         AV98Incidenciawwds_19_tfincidenciacodref = AV48TFIncidenciaCodRef;
         AV99Incidenciawwds_20_tfincidenciacodref_sel = AV49TFIncidenciaCodRef_Sel;
         AV100Incidenciawwds_21_tfmotivonombre = AV50TFMotivoNombre;
         AV101Incidenciawwds_22_tfmotivonombre_sel = AV51TFMotivoNombre_Sel;
         AV102Incidenciawwds_23_tfincidenciaestado_sels = AV53TFIncidenciaEstado_Sels;
         AV103Incidenciawwds_24_tfincidenciausralta = AV54TFIncidenciaUsrAlta;
         AV104Incidenciawwds_25_tfincidenciausralta_sel = AV55TFIncidenciaUsrAlta_Sel;
         AV105Incidenciawwds_26_tfincidenciafechaalta = AV56TFIncidenciaFechaAlta;
         AV106Incidenciawwds_27_tfincidenciafechaalta_to = AV57TFIncidenciaFechaAlta_To;
         AV107Incidenciawwds_28_tfincidenciausractualizacion = AV61TFIncidenciaUsrActualizacion;
         AV108Incidenciawwds_29_tfincidenciausractualizacion_sel = AV62TFIncidenciaUsrActualizacion_Sel;
         AV109Incidenciawwds_30_tfincidenciafechaactualizacion = AV63TFIncidenciaFechaActualizacion;
         AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV64TFIncidenciaFechaActualizacion_To;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IncidenciaOrigen1, AV21MotivoNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25IncidenciaOrigen2, AV26MotivoNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30IncidenciaOrigen3, AV31MotivoNombre3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV79Pgmname, AV17FilterFullText, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV44TFIncidenciaId, AV45TFIncidenciaId_To, AV47TFIncidenciaOrigen_Sels, AV48TFIncidenciaCodRef, AV49TFIncidenciaCodRef_Sel, AV50TFMotivoNombre, AV51TFMotivoNombre_Sel, AV53TFIncidenciaEstado_Sels, AV54TFIncidenciaUsrAlta, AV55TFIncidenciaUsrAlta_Sel, AV56TFIncidenciaFechaAlta, AV57TFIncidenciaFechaAlta_To, AV61TFIncidenciaUsrActualizacion, AV62TFIncidenciaUsrActualizacion_Sel, AV63TFIncidenciaFechaActualizacion, AV64TFIncidenciaFechaActualizacion_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV80Incidenciawwds_1_filterfulltext = AV17FilterFullText;
         AV81Incidenciawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV82Incidenciawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV83Incidenciawwds_4_incidenciaorigen1 = AV20IncidenciaOrigen1;
         AV84Incidenciawwds_5_motivonombre1 = AV21MotivoNombre1;
         AV85Incidenciawwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Incidenciawwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Incidenciawwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Incidenciawwds_9_incidenciaorigen2 = AV25IncidenciaOrigen2;
         AV89Incidenciawwds_10_motivonombre2 = AV26MotivoNombre2;
         AV90Incidenciawwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV91Incidenciawwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV92Incidenciawwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV93Incidenciawwds_14_incidenciaorigen3 = AV30IncidenciaOrigen3;
         AV94Incidenciawwds_15_motivonombre3 = AV31MotivoNombre3;
         AV95Incidenciawwds_16_tfincidenciaid = AV44TFIncidenciaId;
         AV96Incidenciawwds_17_tfincidenciaid_to = AV45TFIncidenciaId_To;
         AV97Incidenciawwds_18_tfincidenciaorigen_sels = AV47TFIncidenciaOrigen_Sels;
         AV98Incidenciawwds_19_tfincidenciacodref = AV48TFIncidenciaCodRef;
         AV99Incidenciawwds_20_tfincidenciacodref_sel = AV49TFIncidenciaCodRef_Sel;
         AV100Incidenciawwds_21_tfmotivonombre = AV50TFMotivoNombre;
         AV101Incidenciawwds_22_tfmotivonombre_sel = AV51TFMotivoNombre_Sel;
         AV102Incidenciawwds_23_tfincidenciaestado_sels = AV53TFIncidenciaEstado_Sels;
         AV103Incidenciawwds_24_tfincidenciausralta = AV54TFIncidenciaUsrAlta;
         AV104Incidenciawwds_25_tfincidenciausralta_sel = AV55TFIncidenciaUsrAlta_Sel;
         AV105Incidenciawwds_26_tfincidenciafechaalta = AV56TFIncidenciaFechaAlta;
         AV106Incidenciawwds_27_tfincidenciafechaalta_to = AV57TFIncidenciaFechaAlta_To;
         AV107Incidenciawwds_28_tfincidenciausractualizacion = AV61TFIncidenciaUsrActualizacion;
         AV108Incidenciawwds_29_tfincidenciausractualizacion_sel = AV62TFIncidenciaUsrActualizacion_Sel;
         AV109Incidenciawwds_30_tfincidenciafechaactualizacion = AV63TFIncidenciaFechaActualizacion;
         AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV64TFIncidenciaFechaActualizacion_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IncidenciaOrigen1, AV21MotivoNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25IncidenciaOrigen2, AV26MotivoNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30IncidenciaOrigen3, AV31MotivoNombre3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV79Pgmname, AV17FilterFullText, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV44TFIncidenciaId, AV45TFIncidenciaId_To, AV47TFIncidenciaOrigen_Sels, AV48TFIncidenciaCodRef, AV49TFIncidenciaCodRef_Sel, AV50TFMotivoNombre, AV51TFMotivoNombre_Sel, AV53TFIncidenciaEstado_Sels, AV54TFIncidenciaUsrAlta, AV55TFIncidenciaUsrAlta_Sel, AV56TFIncidenciaFechaAlta, AV57TFIncidenciaFechaAlta_To, AV61TFIncidenciaUsrActualizacion, AV62TFIncidenciaUsrActualizacion_Sel, AV63TFIncidenciaFechaActualizacion, AV64TFIncidenciaFechaActualizacion_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV80Incidenciawwds_1_filterfulltext = AV17FilterFullText;
         AV81Incidenciawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV82Incidenciawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV83Incidenciawwds_4_incidenciaorigen1 = AV20IncidenciaOrigen1;
         AV84Incidenciawwds_5_motivonombre1 = AV21MotivoNombre1;
         AV85Incidenciawwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Incidenciawwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Incidenciawwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Incidenciawwds_9_incidenciaorigen2 = AV25IncidenciaOrigen2;
         AV89Incidenciawwds_10_motivonombre2 = AV26MotivoNombre2;
         AV90Incidenciawwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV91Incidenciawwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV92Incidenciawwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV93Incidenciawwds_14_incidenciaorigen3 = AV30IncidenciaOrigen3;
         AV94Incidenciawwds_15_motivonombre3 = AV31MotivoNombre3;
         AV95Incidenciawwds_16_tfincidenciaid = AV44TFIncidenciaId;
         AV96Incidenciawwds_17_tfincidenciaid_to = AV45TFIncidenciaId_To;
         AV97Incidenciawwds_18_tfincidenciaorigen_sels = AV47TFIncidenciaOrigen_Sels;
         AV98Incidenciawwds_19_tfincidenciacodref = AV48TFIncidenciaCodRef;
         AV99Incidenciawwds_20_tfincidenciacodref_sel = AV49TFIncidenciaCodRef_Sel;
         AV100Incidenciawwds_21_tfmotivonombre = AV50TFMotivoNombre;
         AV101Incidenciawwds_22_tfmotivonombre_sel = AV51TFMotivoNombre_Sel;
         AV102Incidenciawwds_23_tfincidenciaestado_sels = AV53TFIncidenciaEstado_Sels;
         AV103Incidenciawwds_24_tfincidenciausralta = AV54TFIncidenciaUsrAlta;
         AV104Incidenciawwds_25_tfincidenciausralta_sel = AV55TFIncidenciaUsrAlta_Sel;
         AV105Incidenciawwds_26_tfincidenciafechaalta = AV56TFIncidenciaFechaAlta;
         AV106Incidenciawwds_27_tfincidenciafechaalta_to = AV57TFIncidenciaFechaAlta_To;
         AV107Incidenciawwds_28_tfincidenciausractualizacion = AV61TFIncidenciaUsrActualizacion;
         AV108Incidenciawwds_29_tfincidenciausractualizacion_sel = AV62TFIncidenciaUsrActualizacion_Sel;
         AV109Incidenciawwds_30_tfincidenciafechaactualizacion = AV63TFIncidenciaFechaActualizacion;
         AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV64TFIncidenciaFechaActualizacion_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IncidenciaOrigen1, AV21MotivoNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25IncidenciaOrigen2, AV26MotivoNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30IncidenciaOrigen3, AV31MotivoNombre3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV79Pgmname, AV17FilterFullText, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV44TFIncidenciaId, AV45TFIncidenciaId_To, AV47TFIncidenciaOrigen_Sels, AV48TFIncidenciaCodRef, AV49TFIncidenciaCodRef_Sel, AV50TFMotivoNombre, AV51TFMotivoNombre_Sel, AV53TFIncidenciaEstado_Sels, AV54TFIncidenciaUsrAlta, AV55TFIncidenciaUsrAlta_Sel, AV56TFIncidenciaFechaAlta, AV57TFIncidenciaFechaAlta_To, AV61TFIncidenciaUsrActualizacion, AV62TFIncidenciaUsrActualizacion_Sel, AV63TFIncidenciaFechaActualizacion, AV64TFIncidenciaFechaActualizacion_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV80Incidenciawwds_1_filterfulltext = AV17FilterFullText;
         AV81Incidenciawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV82Incidenciawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV83Incidenciawwds_4_incidenciaorigen1 = AV20IncidenciaOrigen1;
         AV84Incidenciawwds_5_motivonombre1 = AV21MotivoNombre1;
         AV85Incidenciawwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Incidenciawwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Incidenciawwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Incidenciawwds_9_incidenciaorigen2 = AV25IncidenciaOrigen2;
         AV89Incidenciawwds_10_motivonombre2 = AV26MotivoNombre2;
         AV90Incidenciawwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV91Incidenciawwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV92Incidenciawwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV93Incidenciawwds_14_incidenciaorigen3 = AV30IncidenciaOrigen3;
         AV94Incidenciawwds_15_motivonombre3 = AV31MotivoNombre3;
         AV95Incidenciawwds_16_tfincidenciaid = AV44TFIncidenciaId;
         AV96Incidenciawwds_17_tfincidenciaid_to = AV45TFIncidenciaId_To;
         AV97Incidenciawwds_18_tfincidenciaorigen_sels = AV47TFIncidenciaOrigen_Sels;
         AV98Incidenciawwds_19_tfincidenciacodref = AV48TFIncidenciaCodRef;
         AV99Incidenciawwds_20_tfincidenciacodref_sel = AV49TFIncidenciaCodRef_Sel;
         AV100Incidenciawwds_21_tfmotivonombre = AV50TFMotivoNombre;
         AV101Incidenciawwds_22_tfmotivonombre_sel = AV51TFMotivoNombre_Sel;
         AV102Incidenciawwds_23_tfincidenciaestado_sels = AV53TFIncidenciaEstado_Sels;
         AV103Incidenciawwds_24_tfincidenciausralta = AV54TFIncidenciaUsrAlta;
         AV104Incidenciawwds_25_tfincidenciausralta_sel = AV55TFIncidenciaUsrAlta_Sel;
         AV105Incidenciawwds_26_tfincidenciafechaalta = AV56TFIncidenciaFechaAlta;
         AV106Incidenciawwds_27_tfincidenciafechaalta_to = AV57TFIncidenciaFechaAlta_To;
         AV107Incidenciawwds_28_tfincidenciausractualizacion = AV61TFIncidenciaUsrActualizacion;
         AV108Incidenciawwds_29_tfincidenciausractualizacion_sel = AV62TFIncidenciaUsrActualizacion_Sel;
         AV109Incidenciawwds_30_tfincidenciafechaactualizacion = AV63TFIncidenciaFechaActualizacion;
         AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV64TFIncidenciaFechaActualizacion_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IncidenciaOrigen1, AV21MotivoNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25IncidenciaOrigen2, AV26MotivoNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30IncidenciaOrigen3, AV31MotivoNombre3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV79Pgmname, AV17FilterFullText, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV44TFIncidenciaId, AV45TFIncidenciaId_To, AV47TFIncidenciaOrigen_Sels, AV48TFIncidenciaCodRef, AV49TFIncidenciaCodRef_Sel, AV50TFMotivoNombre, AV51TFMotivoNombre_Sel, AV53TFIncidenciaEstado_Sels, AV54TFIncidenciaUsrAlta, AV55TFIncidenciaUsrAlta_Sel, AV56TFIncidenciaFechaAlta, AV57TFIncidenciaFechaAlta_To, AV61TFIncidenciaUsrActualizacion, AV62TFIncidenciaUsrActualizacion_Sel, AV63TFIncidenciaFechaActualizacion, AV64TFIncidenciaFechaActualizacion_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV79Pgmname = "IncidenciaWW";
         edtIncidenciaId_Enabled = 0;
         cmbIncidenciaOrigen.Enabled = 0;
         edtIncidenciaCodRef_Enabled = 0;
         edtMotivoId_Enabled = 0;
         edtMotivoNombre_Enabled = 0;
         cmbIncidenciaEstado.Enabled = 0;
         edtIncidenciaUsrAlta_Enabled = 0;
         edtIncidenciaFechaAlta_Enabled = 0;
         edtIncidenciaUsrActualizacion_Enabled = 0;
         edtIncidenciaFechaActualizacion_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP840( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E27842 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV76AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV68DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV38ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_120 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_120"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV70GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV71GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV72GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV58DDO_IncidenciaFechaAltaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_INCIDENCIAFECHAALTAAUXDATE"), 0);
            AV59DDO_IncidenciaFechaAltaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_INCIDENCIAFECHAALTAAUXDATETO"), 0);
            AV65DDO_IncidenciaFechaActualizacionAuxDate = context.localUtil.CToD( cgiGet( "vDDO_INCIDENCIAFECHAACTUALIZACIONAUXDATE"), 0);
            AV66DDO_IncidenciaFechaActualizacionAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_INCIDENCIAFECHAACTUALIZACIONAUXDATETO"), 0);
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
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            cmbavIncidenciaorigen1.Name = cmbavIncidenciaorigen1_Internalname;
            cmbavIncidenciaorigen1.CurrentValue = cgiGet( cmbavIncidenciaorigen1_Internalname);
            AV20IncidenciaOrigen1 = cgiGet( cmbavIncidenciaorigen1_Internalname);
            AssignAttri("", false, "AV20IncidenciaOrigen1", AV20IncidenciaOrigen1);
            AV21MotivoNombre1 = cgiGet( edtavMotivonombre1_Internalname);
            AssignAttri("", false, "AV21MotivoNombre1", AV21MotivoNombre1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            cmbavIncidenciaorigen2.Name = cmbavIncidenciaorigen2_Internalname;
            cmbavIncidenciaorigen2.CurrentValue = cgiGet( cmbavIncidenciaorigen2_Internalname);
            AV25IncidenciaOrigen2 = cgiGet( cmbavIncidenciaorigen2_Internalname);
            AssignAttri("", false, "AV25IncidenciaOrigen2", AV25IncidenciaOrigen2);
            AV26MotivoNombre2 = cgiGet( edtavMotivonombre2_Internalname);
            AssignAttri("", false, "AV26MotivoNombre2", AV26MotivoNombre2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV28DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            cmbavIncidenciaorigen3.Name = cmbavIncidenciaorigen3_Internalname;
            cmbavIncidenciaorigen3.CurrentValue = cgiGet( cmbavIncidenciaorigen3_Internalname);
            AV30IncidenciaOrigen3 = cgiGet( cmbavIncidenciaorigen3_Internalname);
            AssignAttri("", false, "AV30IncidenciaOrigen3", AV30IncidenciaOrigen3);
            AV31MotivoNombre3 = cgiGet( edtavMotivonombre3_Internalname);
            AssignAttri("", false, "AV31MotivoNombre3", AV31MotivoNombre3);
            AV60DDO_IncidenciaFechaAltaAuxDateText = cgiGet( edtavDdo_incidenciafechaaltaauxdatetext_Internalname);
            AssignAttri("", false, "AV60DDO_IncidenciaFechaAltaAuxDateText", AV60DDO_IncidenciaFechaAltaAuxDateText);
            AV67DDO_IncidenciaFechaActualizacionAuxDateText = cgiGet( edtavDdo_incidenciafechaactualizacionauxdatetext_Internalname);
            AssignAttri("", false, "AV67DDO_IncidenciaFechaActualizacionAuxDateText", AV67DDO_IncidenciaFechaActualizacionAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vINCIDENCIAORIGEN1"), AV20IncidenciaOrigen1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMOTIVONOMBRE1"), AV21MotivoNombre1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vINCIDENCIAORIGEN2"), AV25IncidenciaOrigen2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMOTIVONOMBRE2"), AV26MotivoNombre2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vINCIDENCIAORIGEN3"), AV30IncidenciaOrigen3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vMOTIVONOMBRE3"), AV31MotivoNombre3) != 0 )
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
         E27842 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E27842( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFINCIDENCIAFECHAACTUALIZACION_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_incidenciafechaactualizacionauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFINCIDENCIAFECHAALTA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_incidenciafechaaltaauxdatetext_Internalname});
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
         AV20IncidenciaOrigen1 = "";
         AssignAttri("", false, "AV20IncidenciaOrigen1", AV20IncidenciaOrigen1);
         AV18DynamicFiltersSelector1 = "INCIDENCIAORIGEN";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25IncidenciaOrigen2 = "";
         AssignAttri("", false, "AV25IncidenciaOrigen2", AV25IncidenciaOrigen2);
         AV23DynamicFiltersSelector2 = "INCIDENCIAORIGEN";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30IncidenciaOrigen3 = "";
         AssignAttri("", false, "AV30IncidenciaOrigen3", AV30IncidenciaOrigen3);
         AV28DynamicFiltersSelector3 = "INCIDENCIAORIGEN";
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
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Incidencia", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV68DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV68DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E28842( )
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
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV40Session.Get("IncidenciaWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV40Session.Get("IncidenciaWWColumnsSelector");
            AV38ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
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
         edtIncidenciaId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtIncidenciaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIncidenciaId_Visible), 5, 0), !bGXsfl_120_Refreshing);
         cmbIncidenciaOrigen.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbIncidenciaOrigen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbIncidenciaOrigen.Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtIncidenciaCodRef_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtIncidenciaCodRef_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIncidenciaCodRef_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtMotivoNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMotivoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMotivoNombre_Visible), 5, 0), !bGXsfl_120_Refreshing);
         cmbIncidenciaEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbIncidenciaEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbIncidenciaEstado.Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtIncidenciaUsrAlta_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtIncidenciaUsrAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIncidenciaUsrAlta_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtIncidenciaFechaAlta_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtIncidenciaFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIncidenciaFechaAlta_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtIncidenciaUsrActualizacion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtIncidenciaUsrActualizacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIncidenciaUsrActualizacion_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtIncidenciaFechaActualizacion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtIncidenciaFechaActualizacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIncidenciaFechaActualizacion_Visible), 5, 0), !bGXsfl_120_Refreshing);
         AV70GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV70GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV70GridCurrentPage), 10, 0));
         AV71GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV71GridPageCount", StringUtil.LTrimStr( (decimal)(AV71GridPageCount), 10, 0));
         GXt_char2 = AV72GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV79Pgmname, out  GXt_char2) ;
         AV72GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV72GridAppliedFilters", AV72GridAppliedFilters);
         AV80Incidenciawwds_1_filterfulltext = AV17FilterFullText;
         AV81Incidenciawwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV82Incidenciawwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV83Incidenciawwds_4_incidenciaorigen1 = AV20IncidenciaOrigen1;
         AV84Incidenciawwds_5_motivonombre1 = AV21MotivoNombre1;
         AV85Incidenciawwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV86Incidenciawwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV87Incidenciawwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV88Incidenciawwds_9_incidenciaorigen2 = AV25IncidenciaOrigen2;
         AV89Incidenciawwds_10_motivonombre2 = AV26MotivoNombre2;
         AV90Incidenciawwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV91Incidenciawwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV92Incidenciawwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV93Incidenciawwds_14_incidenciaorigen3 = AV30IncidenciaOrigen3;
         AV94Incidenciawwds_15_motivonombre3 = AV31MotivoNombre3;
         AV95Incidenciawwds_16_tfincidenciaid = AV44TFIncidenciaId;
         AV96Incidenciawwds_17_tfincidenciaid_to = AV45TFIncidenciaId_To;
         AV97Incidenciawwds_18_tfincidenciaorigen_sels = AV47TFIncidenciaOrigen_Sels;
         AV98Incidenciawwds_19_tfincidenciacodref = AV48TFIncidenciaCodRef;
         AV99Incidenciawwds_20_tfincidenciacodref_sel = AV49TFIncidenciaCodRef_Sel;
         AV100Incidenciawwds_21_tfmotivonombre = AV50TFMotivoNombre;
         AV101Incidenciawwds_22_tfmotivonombre_sel = AV51TFMotivoNombre_Sel;
         AV102Incidenciawwds_23_tfincidenciaestado_sels = AV53TFIncidenciaEstado_Sels;
         AV103Incidenciawwds_24_tfincidenciausralta = AV54TFIncidenciaUsrAlta;
         AV104Incidenciawwds_25_tfincidenciausralta_sel = AV55TFIncidenciaUsrAlta_Sel;
         AV105Incidenciawwds_26_tfincidenciafechaalta = AV56TFIncidenciaFechaAlta;
         AV106Incidenciawwds_27_tfincidenciafechaalta_to = AV57TFIncidenciaFechaAlta_To;
         AV107Incidenciawwds_28_tfincidenciausractualizacion = AV61TFIncidenciaUsrActualizacion;
         AV108Incidenciawwds_29_tfincidenciausractualizacion_sel = AV62TFIncidenciaUsrActualizacion_Sel;
         AV109Incidenciawwds_30_tfincidenciafechaactualizacion = AV63TFIncidenciaFechaActualizacion;
         AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV64TFIncidenciaFechaActualizacion_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12842( )
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
            AV69PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV69PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13842( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E16842( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "IncidenciaId") == 0 )
            {
               AV44TFIncidenciaId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFIncidenciaId", StringUtil.LTrimStr( (decimal)(AV44TFIncidenciaId), 18, 0));
               AV45TFIncidenciaId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFIncidenciaId_To", StringUtil.LTrimStr( (decimal)(AV45TFIncidenciaId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "IncidenciaOrigen") == 0 )
            {
               AV46TFIncidenciaOrigen_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFIncidenciaOrigen_SelsJson", AV46TFIncidenciaOrigen_SelsJson);
               AV47TFIncidenciaOrigen_Sels.FromJSonString(AV46TFIncidenciaOrigen_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "IncidenciaCodRef") == 0 )
            {
               AV48TFIncidenciaCodRef = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFIncidenciaCodRef", AV48TFIncidenciaCodRef);
               AV49TFIncidenciaCodRef_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFIncidenciaCodRef_Sel", AV49TFIncidenciaCodRef_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MotivoNombre") == 0 )
            {
               AV50TFMotivoNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFMotivoNombre", AV50TFMotivoNombre);
               AV51TFMotivoNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFMotivoNombre_Sel", AV51TFMotivoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "IncidenciaEstado") == 0 )
            {
               AV52TFIncidenciaEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV52TFIncidenciaEstado_SelsJson", AV52TFIncidenciaEstado_SelsJson);
               AV53TFIncidenciaEstado_Sels.FromJSonString(AV52TFIncidenciaEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "IncidenciaUsrAlta") == 0 )
            {
               AV54TFIncidenciaUsrAlta = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFIncidenciaUsrAlta", AV54TFIncidenciaUsrAlta);
               AV55TFIncidenciaUsrAlta_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFIncidenciaUsrAlta_Sel", AV55TFIncidenciaUsrAlta_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "IncidenciaFechaAlta") == 0 )
            {
               AV56TFIncidenciaFechaAlta = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV56TFIncidenciaFechaAlta", context.localUtil.Format(AV56TFIncidenciaFechaAlta, "99/99/99"));
               AV57TFIncidenciaFechaAlta_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV57TFIncidenciaFechaAlta_To", context.localUtil.Format(AV57TFIncidenciaFechaAlta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "IncidenciaUsrActualizacion") == 0 )
            {
               AV61TFIncidenciaUsrActualizacion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV61TFIncidenciaUsrActualizacion", AV61TFIncidenciaUsrActualizacion);
               AV62TFIncidenciaUsrActualizacion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV62TFIncidenciaUsrActualizacion_Sel", AV62TFIncidenciaUsrActualizacion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "IncidenciaFechaActualizacion") == 0 )
            {
               AV63TFIncidenciaFechaActualizacion = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV63TFIncidenciaFechaActualizacion", context.localUtil.Format(AV63TFIncidenciaFechaActualizacion, "99/99/99"));
               AV64TFIncidenciaFechaActualizacion_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV64TFIncidenciaFechaActualizacion_To", context.localUtil.Format(AV64TFIncidenciaFechaActualizacion_To, "99/99/99"));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53TFIncidenciaEstado_Sels", AV53TFIncidenciaEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFIncidenciaOrigen_Sels", AV47TFIncidenciaOrigen_Sels);
      }

      private void E29842( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 120;
            }
            sendrow_1202( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_120_Refreshing )
         {
            context.DoAjaxLoad(120, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0));
      }

      protected void E17842( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV36ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV38ColumnsSelector.FromJSonString(AV36ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "IncidenciaWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV36ColumnsSelectorXML)) ? "" : AV38ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E22842( )
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

      protected void E18842( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IncidenciaOrigen1, AV21MotivoNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25IncidenciaOrigen2, AV26MotivoNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30IncidenciaOrigen3, AV31MotivoNombre3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV79Pgmname, AV17FilterFullText, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV44TFIncidenciaId, AV45TFIncidenciaId_To, AV47TFIncidenciaOrigen_Sels, AV48TFIncidenciaCodRef, AV49TFIncidenciaCodRef_Sel, AV50TFMotivoNombre, AV51TFMotivoNombre_Sel, AV53TFIncidenciaEstado_Sels, AV54TFIncidenciaUsrAlta, AV55TFIncidenciaUsrAlta_Sel, AV56TFIncidenciaFechaAlta, AV57TFIncidenciaFechaAlta_To, AV61TFIncidenciaUsrActualizacion, AV62TFIncidenciaUsrActualizacion_Sel, AV63TFIncidenciaFechaActualizacion, AV64TFIncidenciaFechaActualizacion_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavIncidenciaorigen2.CurrentValue = StringUtil.RTrim( AV25IncidenciaOrigen2);
         AssignProp("", false, cmbavIncidenciaorigen2_Internalname, "Values", cmbavIncidenciaorigen2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavIncidenciaorigen3.CurrentValue = StringUtil.RTrim( AV30IncidenciaOrigen3);
         AssignProp("", false, cmbavIncidenciaorigen3_Internalname, "Values", cmbavIncidenciaorigen3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavIncidenciaorigen1.CurrentValue = StringUtil.RTrim( AV20IncidenciaOrigen1);
         AssignProp("", false, cmbavIncidenciaorigen1_Internalname, "Values", cmbavIncidenciaorigen1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E23842( )
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

      protected void E24842( )
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

      protected void E19842( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IncidenciaOrigen1, AV21MotivoNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25IncidenciaOrigen2, AV26MotivoNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30IncidenciaOrigen3, AV31MotivoNombre3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV79Pgmname, AV17FilterFullText, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV44TFIncidenciaId, AV45TFIncidenciaId_To, AV47TFIncidenciaOrigen_Sels, AV48TFIncidenciaCodRef, AV49TFIncidenciaCodRef_Sel, AV50TFMotivoNombre, AV51TFMotivoNombre_Sel, AV53TFIncidenciaEstado_Sels, AV54TFIncidenciaUsrAlta, AV55TFIncidenciaUsrAlta_Sel, AV56TFIncidenciaFechaAlta, AV57TFIncidenciaFechaAlta_To, AV61TFIncidenciaUsrActualizacion, AV62TFIncidenciaUsrActualizacion_Sel, AV63TFIncidenciaFechaActualizacion, AV64TFIncidenciaFechaActualizacion_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavIncidenciaorigen2.CurrentValue = StringUtil.RTrim( AV25IncidenciaOrigen2);
         AssignProp("", false, cmbavIncidenciaorigen2_Internalname, "Values", cmbavIncidenciaorigen2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavIncidenciaorigen3.CurrentValue = StringUtil.RTrim( AV30IncidenciaOrigen3);
         AssignProp("", false, cmbavIncidenciaorigen3_Internalname, "Values", cmbavIncidenciaorigen3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavIncidenciaorigen1.CurrentValue = StringUtil.RTrim( AV20IncidenciaOrigen1);
         AssignProp("", false, cmbavIncidenciaorigen1_Internalname, "Values", cmbavIncidenciaorigen1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E25842( )
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

      protected void E20842( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IncidenciaOrigen1, AV21MotivoNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25IncidenciaOrigen2, AV26MotivoNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30IncidenciaOrigen3, AV31MotivoNombre3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV79Pgmname, AV17FilterFullText, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV44TFIncidenciaId, AV45TFIncidenciaId_To, AV47TFIncidenciaOrigen_Sels, AV48TFIncidenciaCodRef, AV49TFIncidenciaCodRef_Sel, AV50TFMotivoNombre, AV51TFMotivoNombre_Sel, AV53TFIncidenciaEstado_Sels, AV54TFIncidenciaUsrAlta, AV55TFIncidenciaUsrAlta_Sel, AV56TFIncidenciaFechaAlta, AV57TFIncidenciaFechaAlta_To, AV61TFIncidenciaUsrActualizacion, AV62TFIncidenciaUsrActualizacion_Sel, AV63TFIncidenciaFechaActualizacion, AV64TFIncidenciaFechaActualizacion_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavIncidenciaorigen2.CurrentValue = StringUtil.RTrim( AV25IncidenciaOrigen2);
         AssignProp("", false, cmbavIncidenciaorigen2_Internalname, "Values", cmbavIncidenciaorigen2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavIncidenciaorigen3.CurrentValue = StringUtil.RTrim( AV30IncidenciaOrigen3);
         AssignProp("", false, cmbavIncidenciaorigen3_Internalname, "Values", cmbavIncidenciaorigen3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavIncidenciaorigen1.CurrentValue = StringUtil.RTrim( AV20IncidenciaOrigen1);
         AssignProp("", false, cmbavIncidenciaorigen1_Internalname, "Values", cmbavIncidenciaorigen1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E26842( )
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

      protected void E11842( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("IncidenciaWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV79Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("IncidenciaWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "IncidenciaWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV42ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV79Pgmname+"GridState",  AV42ManageFiltersXml) ;
               AV11GridState.FromXml(AV42ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFIncidenciaOrigen_Sels", AV47TFIncidenciaOrigen_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53TFIncidenciaEstado_Sels", AV53TFIncidenciaEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavIncidenciaorigen1.CurrentValue = StringUtil.RTrim( AV20IncidenciaOrigen1);
         AssignProp("", false, cmbavIncidenciaorigen1_Internalname, "Values", cmbavIncidenciaorigen1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavIncidenciaorigen2.CurrentValue = StringUtil.RTrim( AV25IncidenciaOrigen2);
         AssignProp("", false, cmbavIncidenciaorigen2_Internalname, "Values", cmbavIncidenciaorigen2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavIncidenciaorigen3.CurrentValue = StringUtil.RTrim( AV30IncidenciaOrigen3);
         AssignProp("", false, cmbavIncidenciaorigen3_Internalname, "Values", cmbavIncidenciaorigen3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E30842( )
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
         AV73GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV73GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E21842( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "incidencia.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("incidencia.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14842( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53TFIncidenciaEstado_Sels", AV53TFIncidenciaEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFIncidenciaOrigen_Sels", AV47TFIncidenciaOrigen_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavIncidenciaorigen1.CurrentValue = StringUtil.RTrim( AV20IncidenciaOrigen1);
         AssignProp("", false, cmbavIncidenciaorigen1_Internalname, "Values", cmbavIncidenciaorigen1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavIncidenciaorigen2.CurrentValue = StringUtil.RTrim( AV25IncidenciaOrigen2);
         AssignProp("", false, cmbavIncidenciaorigen2_Internalname, "Values", cmbavIncidenciaorigen2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavIncidenciaorigen3.CurrentValue = StringUtil.RTrim( AV30IncidenciaOrigen3);
         AssignProp("", false, cmbavIncidenciaorigen3_Internalname, "Values", cmbavIncidenciaorigen3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E15842( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0146",(string)"",(string)"Incidencia",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0146"+"");
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
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "IncidenciaId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "IncidenciaOrigen",  "",  "Origen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "IncidenciaCodRef",  "",  "Referencia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "MotivoNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "IncidenciaEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "IncidenciaUsrAlta",  "",  "Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "IncidenciaFechaAlta",  "",  "Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "IncidenciaUsrActualizacion",  "",  "Actualiza",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "IncidenciaFechaActualizacion",  "",  "Actualiza",  true,  "") ;
         GXt_char2 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "IncidenciaWWColumnsSelector", out  GXt_char2) ;
         AV37UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37UserCustomValue)) ) )
         {
            AV39ColumnsSelectorAux.FromXml(AV37UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV39ColumnsSelectorAux, ref  AV38ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV78TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWIncidencia_Insert", out  GXt_boolean3) ;
         AV78TempBoolean = GXt_boolean3;
         if ( ! ( AV78TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean3 = AV78TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean3) ;
         AV78TempBoolean = GXt_boolean3;
         if ( ! ( AV78TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Incidencia",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         cmbavIncidenciaorigen1.Visible = 0;
         AssignProp("", false, cmbavIncidenciaorigen1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavIncidenciaorigen1.Visible), 5, 0), true);
         edtavMotivonombre1_Visible = 0;
         AssignProp("", false, edtavMotivonombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivonombre1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "INCIDENCIAORIGEN") == 0 )
         {
            cmbavIncidenciaorigen1.Visible = 1;
            AssignProp("", false, cmbavIncidenciaorigen1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavIncidenciaorigen1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MOTIVONOMBRE") == 0 )
         {
            edtavMotivonombre1_Visible = 1;
            AssignProp("", false, edtavMotivonombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivonombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavIncidenciaorigen2.Visible = 0;
         AssignProp("", false, cmbavIncidenciaorigen2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavIncidenciaorigen2.Visible), 5, 0), true);
         edtavMotivonombre2_Visible = 0;
         AssignProp("", false, edtavMotivonombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivonombre2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "INCIDENCIAORIGEN") == 0 )
         {
            cmbavIncidenciaorigen2.Visible = 1;
            AssignProp("", false, cmbavIncidenciaorigen2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavIncidenciaorigen2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "MOTIVONOMBRE") == 0 )
         {
            edtavMotivonombre2_Visible = 1;
            AssignProp("", false, edtavMotivonombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivonombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavIncidenciaorigen3.Visible = 0;
         AssignProp("", false, cmbavIncidenciaorigen3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavIncidenciaorigen3.Visible), 5, 0), true);
         edtavMotivonombre3_Visible = 0;
         AssignProp("", false, edtavMotivonombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivonombre3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "INCIDENCIAORIGEN") == 0 )
         {
            cmbavIncidenciaorigen3.Visible = 1;
            AssignProp("", false, cmbavIncidenciaorigen3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavIncidenciaorigen3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "MOTIVONOMBRE") == 0 )
         {
            edtavMotivonombre3_Visible = 1;
            AssignProp("", false, edtavMotivonombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavMotivonombre3_Visible), 5, 0), true);
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
         AV23DynamicFiltersSelector2 = "INCIDENCIAORIGEN";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV25IncidenciaOrigen2 = "";
         AssignAttri("", false, "AV25IncidenciaOrigen2", AV25IncidenciaOrigen2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         AV28DynamicFiltersSelector3 = "INCIDENCIAORIGEN";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         AV30IncidenciaOrigen3 = "";
         AssignAttri("", false, "AV30IncidenciaOrigen3", AV30IncidenciaOrigen3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV41ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "IncidenciaWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV44TFIncidenciaId = 0;
         AssignAttri("", false, "AV44TFIncidenciaId", StringUtil.LTrimStr( (decimal)(AV44TFIncidenciaId), 18, 0));
         AV45TFIncidenciaId_To = 0;
         AssignAttri("", false, "AV45TFIncidenciaId_To", StringUtil.LTrimStr( (decimal)(AV45TFIncidenciaId_To), 18, 0));
         AV47TFIncidenciaOrigen_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV48TFIncidenciaCodRef = "";
         AssignAttri("", false, "AV48TFIncidenciaCodRef", AV48TFIncidenciaCodRef);
         AV49TFIncidenciaCodRef_Sel = "";
         AssignAttri("", false, "AV49TFIncidenciaCodRef_Sel", AV49TFIncidenciaCodRef_Sel);
         AV50TFMotivoNombre = "";
         AssignAttri("", false, "AV50TFMotivoNombre", AV50TFMotivoNombre);
         AV51TFMotivoNombre_Sel = "";
         AssignAttri("", false, "AV51TFMotivoNombre_Sel", AV51TFMotivoNombre_Sel);
         AV53TFIncidenciaEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV54TFIncidenciaUsrAlta = "";
         AssignAttri("", false, "AV54TFIncidenciaUsrAlta", AV54TFIncidenciaUsrAlta);
         AV55TFIncidenciaUsrAlta_Sel = "";
         AssignAttri("", false, "AV55TFIncidenciaUsrAlta_Sel", AV55TFIncidenciaUsrAlta_Sel);
         AV56TFIncidenciaFechaAlta = DateTime.MinValue;
         AssignAttri("", false, "AV56TFIncidenciaFechaAlta", context.localUtil.Format(AV56TFIncidenciaFechaAlta, "99/99/99"));
         AV57TFIncidenciaFechaAlta_To = DateTime.MinValue;
         AssignAttri("", false, "AV57TFIncidenciaFechaAlta_To", context.localUtil.Format(AV57TFIncidenciaFechaAlta_To, "99/99/99"));
         AV61TFIncidenciaUsrActualizacion = "";
         AssignAttri("", false, "AV61TFIncidenciaUsrActualizacion", AV61TFIncidenciaUsrActualizacion);
         AV62TFIncidenciaUsrActualizacion_Sel = "";
         AssignAttri("", false, "AV62TFIncidenciaUsrActualizacion_Sel", AV62TFIncidenciaUsrActualizacion_Sel);
         AV63TFIncidenciaFechaActualizacion = DateTime.MinValue;
         AssignAttri("", false, "AV63TFIncidenciaFechaActualizacion", context.localUtil.Format(AV63TFIncidenciaFechaActualizacion, "99/99/99"));
         AV64TFIncidenciaFechaActualizacion_To = DateTime.MinValue;
         AssignAttri("", false, "AV64TFIncidenciaFechaActualizacion_To", context.localUtil.Format(AV64TFIncidenciaFechaActualizacion_To, "99/99/99"));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "INCIDENCIAORIGEN";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV20IncidenciaOrigen1 = "";
         AssignAttri("", false, "AV20IncidenciaOrigen1", AV20IncidenciaOrigen1);
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
         GXEncryptionTmp = "incidenciaview.aspx"+UrlEncode(StringUtil.LTrimStr(A603IncidenciaId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("incidenciaview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV79Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV79Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV40Session.Get(AV79Pgmname+"GridState"), null, "", "");
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
         AV111GXV1 = 1;
         while ( AV111GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV111GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAID") == 0 )
            {
               AV44TFIncidenciaId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFIncidenciaId", StringUtil.LTrimStr( (decimal)(AV44TFIncidenciaId), 18, 0));
               AV45TFIncidenciaId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFIncidenciaId_To", StringUtil.LTrimStr( (decimal)(AV45TFIncidenciaId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAORIGEN_SEL") == 0 )
            {
               AV46TFIncidenciaOrigen_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFIncidenciaOrigen_SelsJson", AV46TFIncidenciaOrigen_SelsJson);
               AV47TFIncidenciaOrigen_Sels.FromJSonString(AV46TFIncidenciaOrigen_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINCIDENCIACODREF") == 0 )
            {
               AV48TFIncidenciaCodRef = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFIncidenciaCodRef", AV48TFIncidenciaCodRef);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINCIDENCIACODREF_SEL") == 0 )
            {
               AV49TFIncidenciaCodRef_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFIncidenciaCodRef_Sel", AV49TFIncidenciaCodRef_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE") == 0 )
            {
               AV50TFMotivoNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFMotivoNombre", AV50TFMotivoNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE_SEL") == 0 )
            {
               AV51TFMotivoNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFMotivoNombre_Sel", AV51TFMotivoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAESTADO_SEL") == 0 )
            {
               AV52TFIncidenciaEstado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFIncidenciaEstado_SelsJson", AV52TFIncidenciaEstado_SelsJson);
               AV53TFIncidenciaEstado_Sels.FromJSonString(AV52TFIncidenciaEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRALTA") == 0 )
            {
               AV54TFIncidenciaUsrAlta = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFIncidenciaUsrAlta", AV54TFIncidenciaUsrAlta);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRALTA_SEL") == 0 )
            {
               AV55TFIncidenciaUsrAlta_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFIncidenciaUsrAlta_Sel", AV55TFIncidenciaUsrAlta_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAFECHAALTA") == 0 )
            {
               AV56TFIncidenciaFechaAlta = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV56TFIncidenciaFechaAlta", context.localUtil.Format(AV56TFIncidenciaFechaAlta, "99/99/99"));
               AV57TFIncidenciaFechaAlta_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV57TFIncidenciaFechaAlta_To", context.localUtil.Format(AV57TFIncidenciaFechaAlta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRACTUALIZACION") == 0 )
            {
               AV61TFIncidenciaUsrActualizacion = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV61TFIncidenciaUsrActualizacion", AV61TFIncidenciaUsrActualizacion);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRACTUALIZACION_SEL") == 0 )
            {
               AV62TFIncidenciaUsrActualizacion_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV62TFIncidenciaUsrActualizacion_Sel", AV62TFIncidenciaUsrActualizacion_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAFECHAACTUALIZACION") == 0 )
            {
               AV63TFIncidenciaFechaActualizacion = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV63TFIncidenciaFechaActualizacion", context.localUtil.Format(AV63TFIncidenciaFechaActualizacion, "99/99/99"));
               AV64TFIncidenciaFechaActualizacion_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV64TFIncidenciaFechaActualizacion_To", context.localUtil.Format(AV64TFIncidenciaFechaActualizacion_To, "99/99/99"));
            }
            AV111GXV1 = (int)(AV111GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV47TFIncidenciaOrigen_Sels.Count==0),  AV46TFIncidenciaOrigen_SelsJson, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFIncidenciaCodRef_Sel)),  AV49TFIncidenciaCodRef_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFMotivoNombre_Sel)),  AV51TFMotivoNombre_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV53TFIncidenciaEstado_Sels.Count==0),  AV52TFIncidenciaEstado_SelsJson, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFIncidenciaUsrAlta_Sel)),  AV55TFIncidenciaUsrAlta_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV62TFIncidenciaUsrActualizacion_Sel)),  AV62TFIncidenciaUsrActualizacion_Sel, out  GXt_char9) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"||"+GXt_char9+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFIncidenciaCodRef)),  AV48TFIncidenciaCodRef, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMotivoNombre)),  AV50TFMotivoNombre, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFIncidenciaUsrAlta)),  AV54TFIncidenciaUsrAlta, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV61TFIncidenciaUsrActualizacion)),  AV61TFIncidenciaUsrActualizacion, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = ((0==AV44TFIncidenciaId) ? "" : StringUtil.Str( (decimal)(AV44TFIncidenciaId), 18, 0))+"||"+GXt_char9+"|"+GXt_char8+"||"+GXt_char7+"|"+((DateTime.MinValue==AV56TFIncidenciaFechaAlta) ? "" : context.localUtil.DToC( AV56TFIncidenciaFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+GXt_char6+"|"+((DateTime.MinValue==AV63TFIncidenciaFechaActualizacion) ? "" : context.localUtil.DToC( AV63TFIncidenciaFechaActualizacion, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV45TFIncidenciaId_To) ? "" : StringUtil.Str( (decimal)(AV45TFIncidenciaId_To), 18, 0))+"||||||"+((DateTime.MinValue==AV57TFIncidenciaFechaAlta_To) ? "" : context.localUtil.DToC( AV57TFIncidenciaFechaAlta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||"+((DateTime.MinValue==AV64TFIncidenciaFechaActualizacion_To) ? "" : context.localUtil.DToC( AV64TFIncidenciaFechaActualizacion_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
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
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "INCIDENCIAORIGEN") == 0 )
            {
               AV20IncidenciaOrigen1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20IncidenciaOrigen1", AV20IncidenciaOrigen1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MOTIVONOMBRE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV21MotivoNombre1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21MotivoNombre1", AV21MotivoNombre1);
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
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "INCIDENCIAORIGEN") == 0 )
               {
                  AV25IncidenciaOrigen2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV25IncidenciaOrigen2", AV25IncidenciaOrigen2);
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "MOTIVONOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV26MotivoNombre2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26MotivoNombre2", AV26MotivoNombre2);
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
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "INCIDENCIAORIGEN") == 0 )
                  {
                     AV30IncidenciaOrigen3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV30IncidenciaOrigen3", AV30IncidenciaOrigen3);
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "MOTIVONOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV31MotivoNombre3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31MotivoNombre3", AV31MotivoNombre3);
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
         AV11GridState.FromXml(AV40Session.Get(AV79Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFINCIDENCIAID",  context.GetMessage( "Id", ""),  !((0==AV44TFIncidenciaId)&&(0==AV45TFIncidenciaId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFIncidenciaId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV45TFIncidenciaId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFINCIDENCIAORIGEN_SEL",  context.GetMessage( "Origen", ""),  !(AV47TFIncidenciaOrigen_Sels.Count==0),  0,  AV47TFIncidenciaOrigen_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFINCIDENCIACODREF",  context.GetMessage( "Referencia", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFIncidenciaCodRef)),  0,  AV48TFIncidenciaCodRef,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFIncidenciaCodRef_Sel)),  AV49TFIncidenciaCodRef_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMOTIVONOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMotivoNombre)),  0,  AV50TFMotivoNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFMotivoNombre_Sel)),  AV51TFMotivoNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFINCIDENCIAESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV53TFIncidenciaEstado_Sels.Count==0),  0,  AV53TFIncidenciaEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFINCIDENCIAUSRALTA",  context.GetMessage( "Alta", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFIncidenciaUsrAlta)),  0,  AV54TFIncidenciaUsrAlta,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFIncidenciaUsrAlta_Sel)),  AV55TFIncidenciaUsrAlta_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFINCIDENCIAFECHAALTA",  context.GetMessage( "Alta", ""),  !((DateTime.MinValue==AV56TFIncidenciaFechaAlta)&&(DateTime.MinValue==AV57TFIncidenciaFechaAlta_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV56TFIncidenciaFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV57TFIncidenciaFechaAlta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFINCIDENCIAUSRACTUALIZACION",  context.GetMessage( "Actualiza", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV61TFIncidenciaUsrActualizacion)),  0,  AV61TFIncidenciaUsrActualizacion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV62TFIncidenciaUsrActualizacion_Sel)),  AV62TFIncidenciaUsrActualizacion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFINCIDENCIAFECHAACTUALIZACION",  context.GetMessage( "Actualiza", ""),  !((DateTime.MinValue==AV63TFIncidenciaFechaActualizacion)&&(DateTime.MinValue==AV64TFIncidenciaFechaActualizacion_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV63TFIncidenciaFechaActualizacion, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV64TFIncidenciaFechaActualizacion_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV79Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "INCIDENCIAORIGEN") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20IncidenciaOrigen1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Origen", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV20IncidenciaOrigen1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MOTIVONOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21MotivoNombre1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Motivo Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV21MotivoNombre1;
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
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "INCIDENCIAORIGEN") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25IncidenciaOrigen2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Origen", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV25IncidenciaOrigen2;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "MOTIVONOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26MotivoNombre2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Motivo Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV26MotivoNombre2;
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
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "INCIDENCIAORIGEN") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV30IncidenciaOrigen3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Origen", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV30IncidenciaOrigen3;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "MOTIVONOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31MotivoNombre3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Motivo Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV31MotivoNombre3;
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
         AV9TrnContext.gxTpr_Callerobject = AV79Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Incidencia";
         AV40Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S272( )
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
         new incidenciawwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
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

      protected void S282( )
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
         Innewwindow1_Target = formatLink("incidenciawwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_99_842( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "", true, 0, "HLP_IncidenciaWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_incidenciaorigen3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavIncidenciaorigen3_Internalname, context.GetMessage( "Incidencia Origen3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavIncidenciaorigen3, cmbavIncidenciaorigen3_Internalname, StringUtil.RTrim( AV30IncidenciaOrigen3), 1, cmbavIncidenciaorigen3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavIncidenciaorigen3.Visible, cmbavIncidenciaorigen3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "", true, 0, "HLP_IncidenciaWW.htm");
            cmbavIncidenciaorigen3.CurrentValue = StringUtil.RTrim( AV30IncidenciaOrigen3);
            AssignProp("", false, cmbavIncidenciaorigen3_Internalname, "Values", (string)(cmbavIncidenciaorigen3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_motivonombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMotivonombre3_Internalname, context.GetMessage( "Motivo Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMotivonombre3_Internalname, StringUtil.RTrim( AV31MotivoNombre3), StringUtil.RTrim( context.localUtil.Format( AV31MotivoNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMotivonombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavMotivonombre3_Visible, edtavMotivonombre3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_IncidenciaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_99_842e( true) ;
         }
         else
         {
            wb_table4_99_842e( false) ;
         }
      }

      protected void wb_table3_74_842( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, 0, "HLP_IncidenciaWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_incidenciaorigen2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavIncidenciaorigen2_Internalname, context.GetMessage( "Incidencia Origen2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavIncidenciaorigen2, cmbavIncidenciaorigen2_Internalname, StringUtil.RTrim( AV25IncidenciaOrigen2), 1, cmbavIncidenciaorigen2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavIncidenciaorigen2.Visible, cmbavIncidenciaorigen2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", true, 0, "HLP_IncidenciaWW.htm");
            cmbavIncidenciaorigen2.CurrentValue = StringUtil.RTrim( AV25IncidenciaOrigen2);
            AssignProp("", false, cmbavIncidenciaorigen2_Internalname, "Values", (string)(cmbavIncidenciaorigen2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_motivonombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMotivonombre2_Internalname, context.GetMessage( "Motivo Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMotivonombre2_Internalname, StringUtil.RTrim( AV26MotivoNombre2), StringUtil.RTrim( context.localUtil.Format( AV26MotivoNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMotivonombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavMotivonombre2_Visible, edtavMotivonombre2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_IncidenciaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_IncidenciaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_74_842e( true) ;
         }
         else
         {
            wb_table3_74_842e( false) ;
         }
      }

      protected void wb_table2_49_842( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_IncidenciaWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_incidenciaorigen1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavIncidenciaorigen1_Internalname, context.GetMessage( "Incidencia Origen1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavIncidenciaorigen1, cmbavIncidenciaorigen1_Internalname, StringUtil.RTrim( AV20IncidenciaOrigen1), 1, cmbavIncidenciaorigen1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavIncidenciaorigen1.Visible, cmbavIncidenciaorigen1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 0, "HLP_IncidenciaWW.htm");
            cmbavIncidenciaorigen1.CurrentValue = StringUtil.RTrim( AV20IncidenciaOrigen1);
            AssignProp("", false, cmbavIncidenciaorigen1_Internalname, "Values", (string)(cmbavIncidenciaorigen1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_motivonombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMotivonombre1_Internalname, context.GetMessage( "Motivo Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMotivonombre1_Internalname, StringUtil.RTrim( AV21MotivoNombre1), StringUtil.RTrim( context.localUtil.Format( AV21MotivoNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMotivonombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavMotivonombre1_Visible, edtavMotivonombre1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_IncidenciaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_IncidenciaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_842e( true) ;
         }
         else
         {
            wb_table2_49_842e( false) ;
         }
      }

      protected void wb_table1_25_842( bool wbgen )
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
            wb_table5_30_842( true) ;
         }
         else
         {
            wb_table5_30_842( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_842e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_842e( true) ;
         }
         else
         {
            wb_table1_25_842e( false) ;
         }
      }

      protected void wb_table5_30_842( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_IncidenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_842e( true) ;
         }
         else
         {
            wb_table5_30_842e( false) ;
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
         PA842( ) ;
         WS842( ) ;
         WE842( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302122373", true, true, false);
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
         context.AddJavascriptSource("incidenciaww.js", "?20267302122374", false, true, false);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1202( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_120_idx;
         edtIncidenciaId_Internalname = "INCIDENCIAID_"+sGXsfl_120_idx;
         cmbIncidenciaOrigen_Internalname = "INCIDENCIAORIGEN_"+sGXsfl_120_idx;
         edtIncidenciaCodRef_Internalname = "INCIDENCIACODREF_"+sGXsfl_120_idx;
         edtMotivoId_Internalname = "MOTIVOID_"+sGXsfl_120_idx;
         edtMotivoNombre_Internalname = "MOTIVONOMBRE_"+sGXsfl_120_idx;
         cmbIncidenciaEstado_Internalname = "INCIDENCIAESTADO_"+sGXsfl_120_idx;
         edtIncidenciaUsrAlta_Internalname = "INCIDENCIAUSRALTA_"+sGXsfl_120_idx;
         edtIncidenciaFechaAlta_Internalname = "INCIDENCIAFECHAALTA_"+sGXsfl_120_idx;
         edtIncidenciaUsrActualizacion_Internalname = "INCIDENCIAUSRACTUALIZACION_"+sGXsfl_120_idx;
         edtIncidenciaFechaActualizacion_Internalname = "INCIDENCIAFECHAACTUALIZACION_"+sGXsfl_120_idx;
      }

      protected void SubsflControlProps_fel_1202( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_120_fel_idx;
         edtIncidenciaId_Internalname = "INCIDENCIAID_"+sGXsfl_120_fel_idx;
         cmbIncidenciaOrigen_Internalname = "INCIDENCIAORIGEN_"+sGXsfl_120_fel_idx;
         edtIncidenciaCodRef_Internalname = "INCIDENCIACODREF_"+sGXsfl_120_fel_idx;
         edtMotivoId_Internalname = "MOTIVOID_"+sGXsfl_120_fel_idx;
         edtMotivoNombre_Internalname = "MOTIVONOMBRE_"+sGXsfl_120_fel_idx;
         cmbIncidenciaEstado_Internalname = "INCIDENCIAESTADO_"+sGXsfl_120_fel_idx;
         edtIncidenciaUsrAlta_Internalname = "INCIDENCIAUSRALTA_"+sGXsfl_120_fel_idx;
         edtIncidenciaFechaAlta_Internalname = "INCIDENCIAFECHAALTA_"+sGXsfl_120_fel_idx;
         edtIncidenciaUsrActualizacion_Internalname = "INCIDENCIAUSRACTUALIZACION_"+sGXsfl_120_fel_idx;
         edtIncidenciaFechaActualizacion_Internalname = "INCIDENCIAFECHAACTUALIZACION_"+sGXsfl_120_fel_idx;
      }

      protected void sendrow_1202( )
      {
         sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
         SubsflControlProps_1202( ) ;
         WB840( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_120_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_120_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_120_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_120_idx + "',120)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_120_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV73GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV73GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_120_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_120_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtIncidenciaId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A603IncidenciaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A603IncidenciaId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtIncidenciaId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbIncidenciaOrigen.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbIncidenciaOrigen.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "INCIDENCIAORIGEN_" + sGXsfl_120_idx;
               cmbIncidenciaOrigen.Name = GXCCtl;
               cmbIncidenciaOrigen.WebTags = "";
               cmbIncidenciaOrigen.addItem("SOL", context.GetMessage( "Solicitudes", ""), 0);
               cmbIncidenciaOrigen.addItem("PRV", context.GetMessage( "Proveedores", ""), 0);
               cmbIncidenciaOrigen.addItem("PRF", context.GetMessage( "Profesionales", ""), 0);
               if ( cmbIncidenciaOrigen.ItemCount > 0 )
               {
                  A611IncidenciaOrigen = cmbIncidenciaOrigen.getValidValue(A611IncidenciaOrigen);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbIncidenciaOrigen,(string)cmbIncidenciaOrigen_Internalname,StringUtil.RTrim( A611IncidenciaOrigen),(short)1,(string)cmbIncidenciaOrigen_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbIncidenciaOrigen.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbIncidenciaOrigen.CurrentValue = StringUtil.RTrim( A611IncidenciaOrigen);
            AssignProp("", false, cmbIncidenciaOrigen_Internalname, "Values", (string)(cmbIncidenciaOrigen.ToJavascriptSource()), !bGXsfl_120_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtIncidenciaCodRef_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaCodRef_Internalname,(string)A606IncidenciaCodRef,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaCodRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtIncidenciaCodRef_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A604MotivoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A604MotivoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMotivoNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMotivoNombre_Internalname,StringUtil.RTrim( A616MotivoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMotivoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMotivoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbIncidenciaEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbIncidenciaEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "INCIDENCIAESTADO_" + sGXsfl_120_idx;
               cmbIncidenciaEstado.Name = GXCCtl;
               cmbIncidenciaEstado.WebTags = "";
               cmbIncidenciaEstado.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
               cmbIncidenciaEstado.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
               cmbIncidenciaEstado.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
               if ( cmbIncidenciaEstado.ItemCount > 0 )
               {
                  A608IncidenciaEstado = cmbIncidenciaEstado.getValidValue(A608IncidenciaEstado);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbIncidenciaEstado,(string)cmbIncidenciaEstado_Internalname,StringUtil.RTrim( A608IncidenciaEstado),(short)1,(string)cmbIncidenciaEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbIncidenciaEstado.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbIncidenciaEstado.CurrentValue = StringUtil.RTrim( A608IncidenciaEstado);
            AssignProp("", false, cmbIncidenciaEstado_Internalname, "Values", (string)(cmbIncidenciaEstado.ToJavascriptSource()), !bGXsfl_120_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtIncidenciaUsrAlta_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaUsrAlta_Internalname,StringUtil.RTrim( A615IncidenciaUsrAlta),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaUsrAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtIncidenciaUsrAlta_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"NickName",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtIncidenciaFechaAlta_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaFechaAlta_Internalname,context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99"),context.localUtil.Format( A610IncidenciaFechaAlta, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtIncidenciaFechaAlta_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtIncidenciaUsrActualizacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaUsrActualizacion_Internalname,StringUtil.RTrim( A614IncidenciaUsrActualizacion),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaUsrActualizacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtIncidenciaUsrActualizacion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"NickName",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtIncidenciaFechaActualizacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIncidenciaFechaActualizacion_Internalname,context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99"),context.localUtil.Format( A609IncidenciaFechaActualizacion, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIncidenciaFechaActualizacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtIncidenciaFechaActualizacion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes842( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_120_idx = ((subGrid_Islastpage==1)&&(nGXsfl_120_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_120_idx+1);
            sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
            SubsflControlProps_1202( ) ;
         }
         /* End function sendrow_1202 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("INCIDENCIAORIGEN", context.GetMessage( "Origen", ""), 0);
         cmbavDynamicfiltersselector1.addItem("MOTIVONOMBRE", context.GetMessage( "Motivo Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         cmbavIncidenciaorigen1.Name = "vINCIDENCIAORIGEN1";
         cmbavIncidenciaorigen1.WebTags = "";
         cmbavIncidenciaorigen1.addItem("", context.GetMessage( "WWP_AllInCombo", ""), 0);
         cmbavIncidenciaorigen1.addItem("SOL", context.GetMessage( "Solicitudes", ""), 0);
         cmbavIncidenciaorigen1.addItem("PRV", context.GetMessage( "Proveedores", ""), 0);
         cmbavIncidenciaorigen1.addItem("PRF", context.GetMessage( "Profesionales", ""), 0);
         if ( cmbavIncidenciaorigen1.ItemCount > 0 )
         {
            AV20IncidenciaOrigen1 = cmbavIncidenciaorigen1.getValidValue(AV20IncidenciaOrigen1);
            AssignAttri("", false, "AV20IncidenciaOrigen1", AV20IncidenciaOrigen1);
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("INCIDENCIAORIGEN", context.GetMessage( "Origen", ""), 0);
         cmbavDynamicfiltersselector2.addItem("MOTIVONOMBRE", context.GetMessage( "Motivo Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavIncidenciaorigen2.Name = "vINCIDENCIAORIGEN2";
         cmbavIncidenciaorigen2.WebTags = "";
         cmbavIncidenciaorigen2.addItem("", context.GetMessage( "WWP_AllInCombo", ""), 0);
         cmbavIncidenciaorigen2.addItem("SOL", context.GetMessage( "Solicitudes", ""), 0);
         cmbavIncidenciaorigen2.addItem("PRV", context.GetMessage( "Proveedores", ""), 0);
         cmbavIncidenciaorigen2.addItem("PRF", context.GetMessage( "Profesionales", ""), 0);
         if ( cmbavIncidenciaorigen2.ItemCount > 0 )
         {
            AV25IncidenciaOrigen2 = cmbavIncidenciaorigen2.getValidValue(AV25IncidenciaOrigen2);
            AssignAttri("", false, "AV25IncidenciaOrigen2", AV25IncidenciaOrigen2);
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("INCIDENCIAORIGEN", context.GetMessage( "Origen", ""), 0);
         cmbavDynamicfiltersselector3.addItem("MOTIVONOMBRE", context.GetMessage( "Motivo Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         cmbavIncidenciaorigen3.Name = "vINCIDENCIAORIGEN3";
         cmbavIncidenciaorigen3.WebTags = "";
         cmbavIncidenciaorigen3.addItem("", context.GetMessage( "WWP_AllInCombo", ""), 0);
         cmbavIncidenciaorigen3.addItem("SOL", context.GetMessage( "Solicitudes", ""), 0);
         cmbavIncidenciaorigen3.addItem("PRV", context.GetMessage( "Proveedores", ""), 0);
         cmbavIncidenciaorigen3.addItem("PRF", context.GetMessage( "Profesionales", ""), 0);
         if ( cmbavIncidenciaorigen3.ItemCount > 0 )
         {
            AV30IncidenciaOrigen3 = cmbavIncidenciaorigen3.getValidValue(AV30IncidenciaOrigen3);
            AssignAttri("", false, "AV30IncidenciaOrigen3", AV30IncidenciaOrigen3);
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_120_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV73GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV73GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV73GridActions), 4, 0));
         }
         GXCCtl = "INCIDENCIAORIGEN_" + sGXsfl_120_idx;
         cmbIncidenciaOrigen.Name = GXCCtl;
         cmbIncidenciaOrigen.WebTags = "";
         cmbIncidenciaOrigen.addItem("SOL", context.GetMessage( "Solicitudes", ""), 0);
         cmbIncidenciaOrigen.addItem("PRV", context.GetMessage( "Proveedores", ""), 0);
         cmbIncidenciaOrigen.addItem("PRF", context.GetMessage( "Profesionales", ""), 0);
         if ( cmbIncidenciaOrigen.ItemCount > 0 )
         {
            A611IncidenciaOrigen = cmbIncidenciaOrigen.getValidValue(A611IncidenciaOrigen);
         }
         GXCCtl = "INCIDENCIAESTADO_" + sGXsfl_120_idx;
         cmbIncidenciaEstado.Name = GXCCtl;
         cmbIncidenciaEstado.WebTags = "";
         cmbIncidenciaEstado.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbIncidenciaEstado.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbIncidenciaEstado.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbIncidenciaEstado.ItemCount > 0 )
         {
            A608IncidenciaEstado = cmbIncidenciaEstado.getValidValue(A608IncidenciaEstado);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl120( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"120\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtIncidenciaId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbIncidenciaOrigen.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Origen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtIncidenciaCodRef_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Referencia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMotivoNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbIncidenciaEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtIncidenciaUsrAlta_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtIncidenciaFechaAlta_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtIncidenciaUsrActualizacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Actualiza", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtIncidenciaFechaActualizacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Actualiza", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV73GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A603IncidenciaId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A611IncidenciaOrigen)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbIncidenciaOrigen.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A606IncidenciaCodRef));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaCodRef_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A604MotivoId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A616MotivoNombre)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMotivoNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A608IncidenciaEstado)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbIncidenciaEstado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A615IncidenciaUsrAlta)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaUsrAlta_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A610IncidenciaFechaAlta, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaFechaAlta_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A614IncidenciaUsrActualizacion)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaUsrActualizacion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A609IncidenciaFechaActualizacion, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIncidenciaFechaActualizacion_Visible), 5, 0, ".", "")));
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
         cmbavIncidenciaorigen1_Internalname = "vINCIDENCIAORIGEN1";
         cellFilter_incidenciaorigen1_cell_Internalname = "FILTER_INCIDENCIAORIGEN1_CELL";
         edtavMotivonombre1_Internalname = "vMOTIVONOMBRE1";
         cellFilter_motivonombre1_cell_Internalname = "FILTER_MOTIVONOMBRE1_CELL";
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
         cmbavIncidenciaorigen2_Internalname = "vINCIDENCIAORIGEN2";
         cellFilter_incidenciaorigen2_cell_Internalname = "FILTER_INCIDENCIAORIGEN2_CELL";
         edtavMotivonombre2_Internalname = "vMOTIVONOMBRE2";
         cellFilter_motivonombre2_cell_Internalname = "FILTER_MOTIVONOMBRE2_CELL";
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
         cmbavIncidenciaorigen3_Internalname = "vINCIDENCIAORIGEN3";
         cellFilter_incidenciaorigen3_cell_Internalname = "FILTER_INCIDENCIAORIGEN3_CELL";
         edtavMotivonombre3_Internalname = "vMOTIVONOMBRE3";
         cellFilter_motivonombre3_cell_Internalname = "FILTER_MOTIVONOMBRE3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtIncidenciaId_Internalname = "INCIDENCIAID";
         cmbIncidenciaOrigen_Internalname = "INCIDENCIAORIGEN";
         edtIncidenciaCodRef_Internalname = "INCIDENCIACODREF";
         edtMotivoId_Internalname = "MOTIVOID";
         edtMotivoNombre_Internalname = "MOTIVONOMBRE";
         cmbIncidenciaEstado_Internalname = "INCIDENCIAESTADO";
         edtIncidenciaUsrAlta_Internalname = "INCIDENCIAUSRALTA";
         edtIncidenciaFechaAlta_Internalname = "INCIDENCIAFECHAALTA";
         edtIncidenciaUsrActualizacion_Internalname = "INCIDENCIAUSRACTUALIZACION";
         edtIncidenciaFechaActualizacion_Internalname = "INCIDENCIAFECHAACTUALIZACION";
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
         edtavDdo_incidenciafechaaltaauxdatetext_Internalname = "vDDO_INCIDENCIAFECHAALTAAUXDATETEXT";
         Tfincidenciafechaalta_rangepicker_Internalname = "TFINCIDENCIAFECHAALTA_RANGEPICKER";
         divDdo_incidenciafechaaltaauxdates_Internalname = "DDO_INCIDENCIAFECHAALTAAUXDATES";
         edtavDdo_incidenciafechaactualizacionauxdatetext_Internalname = "vDDO_INCIDENCIAFECHAACTUALIZACIONAUXDATETEXT";
         Tfincidenciafechaactualizacion_rangepicker_Internalname = "TFINCIDENCIAFECHAACTUALIZACION_RANGEPICKER";
         divDdo_incidenciafechaactualizacionauxdates_Internalname = "DDO_INCIDENCIAFECHAACTUALIZACIONAUXDATES";
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
         edtIncidenciaFechaActualizacion_Jsonclick = "";
         edtIncidenciaUsrActualizacion_Jsonclick = "";
         edtIncidenciaFechaAlta_Jsonclick = "";
         edtIncidenciaUsrAlta_Jsonclick = "";
         cmbIncidenciaEstado_Jsonclick = "";
         edtMotivoNombre_Jsonclick = "";
         edtMotivoId_Jsonclick = "";
         edtIncidenciaCodRef_Jsonclick = "";
         cmbIncidenciaOrigen_Jsonclick = "";
         edtIncidenciaId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavMotivonombre1_Jsonclick = "";
         edtavMotivonombre1_Enabled = 1;
         cmbavIncidenciaorigen1_Jsonclick = "";
         cmbavIncidenciaorigen1.Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavMotivonombre2_Jsonclick = "";
         edtavMotivonombre2_Enabled = 1;
         cmbavIncidenciaorigen2_Jsonclick = "";
         cmbavIncidenciaorigen2.Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavMotivonombre3_Jsonclick = "";
         edtavMotivonombre3_Enabled = 1;
         cmbavIncidenciaorigen3_Jsonclick = "";
         cmbavIncidenciaorigen3.Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavMotivonombre3_Visible = 1;
         cmbavIncidenciaorigen3.Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavMotivonombre2_Visible = 1;
         cmbavIncidenciaorigen2.Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavMotivonombre1_Visible = 1;
         cmbavIncidenciaorigen1.Visible = 1;
         edtIncidenciaFechaActualizacion_Visible = -1;
         edtIncidenciaUsrActualizacion_Visible = -1;
         edtIncidenciaFechaAlta_Visible = -1;
         edtIncidenciaUsrAlta_Visible = -1;
         cmbIncidenciaEstado.Visible = -1;
         edtMotivoNombre_Visible = -1;
         edtIncidenciaCodRef_Visible = -1;
         cmbIncidenciaOrigen.Visible = -1;
         edtIncidenciaId_Visible = -1;
         edtIncidenciaFechaActualizacion_Enabled = 0;
         edtIncidenciaUsrActualizacion_Enabled = 0;
         edtIncidenciaFechaAlta_Enabled = 0;
         edtIncidenciaUsrAlta_Enabled = 0;
         cmbIncidenciaEstado.Enabled = 0;
         edtMotivoNombre_Enabled = 0;
         edtMotivoId_Enabled = 0;
         edtIncidenciaCodRef_Enabled = 0;
         cmbIncidenciaOrigen.Enabled = 0;
         edtIncidenciaId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_incidenciafechaactualizacionauxdatetext_Jsonclick = "";
         edtavDdo_incidenciafechaaltaauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = context.GetMessage( "JSDynamicFilters", "");
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
         Ddo_grid_Format = "18.0||||||||";
         Ddo_grid_Datalistproc = "IncidenciaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|SOL:Solicitudes,PRV:Proveedores,PRF:Profesionales|||PRO:Procesado,PND:Pendiente,ANU:Anulado||||";
         Ddo_grid_Allowmultipleselection = "|T|||T||||";
         Ddo_grid_Datalisttype = "|FixedValues|Dynamic|Dynamic|FixedValues|Dynamic||Dynamic|";
         Ddo_grid_Includedatalist = "|T|T|T|T|T||T|";
         Ddo_grid_Filterisrange = "T||||||P||P";
         Ddo_grid_Filtertype = "Numeric||Character|Character||Character|Date|Character|Date";
         Ddo_grid_Includefilter = "T||T|T||T|T|T|T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9";
         Ddo_grid_Columnids = "1:IncidenciaId|2:IncidenciaOrigen|3:IncidenciaCodRef|5:MotivoNombre|6:IncidenciaEstado|7:IncidenciaUsrAlta|8:IncidenciaFechaAlta|9:IncidenciaUsrActualizacion|10:IncidenciaFechaActualizacion";
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
         Form.Caption = context.GetMessage( " Incidencia", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtIncidenciaId_Visible',ctrl:'INCIDENCIAID',prop:'Visible'},{av:'cmbIncidenciaOrigen'},{av:'edtIncidenciaCodRef_Visible',ctrl:'INCIDENCIACODREF',prop:'Visible'},{av:'edtMotivoNombre_Visible',ctrl:'MOTIVONOMBRE',prop:'Visible'},{av:'cmbIncidenciaEstado'},{av:'edtIncidenciaUsrAlta_Visible',ctrl:'INCIDENCIAUSRALTA',prop:'Visible'},{av:'edtIncidenciaFechaAlta_Visible',ctrl:'INCIDENCIAFECHAALTA',prop:'Visible'},{av:'edtIncidenciaUsrActualizacion_Visible',ctrl:'INCIDENCIAUSRACTUALIZACION',prop:'Visible'},{av:'edtIncidenciaFechaActualizacion_Visible',ctrl:'INCIDENCIAFECHAACTUALIZACION',prop:'Visible'},{av:'AV70GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12842',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtIncidenciaId_Visible',ctrl:'INCIDENCIAID',prop:'Visible'},{av:'cmbIncidenciaOrigen'},{av:'edtIncidenciaCodRef_Visible',ctrl:'INCIDENCIACODREF',prop:'Visible'},{av:'edtMotivoNombre_Visible',ctrl:'MOTIVONOMBRE',prop:'Visible'},{av:'cmbIncidenciaEstado'},{av:'edtIncidenciaUsrAlta_Visible',ctrl:'INCIDENCIAUSRALTA',prop:'Visible'},{av:'edtIncidenciaFechaAlta_Visible',ctrl:'INCIDENCIAFECHAALTA',prop:'Visible'},{av:'edtIncidenciaUsrActualizacion_Visible',ctrl:'INCIDENCIAUSRACTUALIZACION',prop:'Visible'},{av:'edtIncidenciaFechaActualizacion_Visible',ctrl:'INCIDENCIAFECHAACTUALIZACION',prop:'Visible'},{av:'AV70GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13842',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E16842',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV52TFIncidenciaEstado_SelsJson',fld:'vTFINCIDENCIAESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV46TFIncidenciaOrigen_SelsJson',fld:'vTFINCIDENCIAORIGEN_SELSJSON',pic:'',type:'vchar'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E29842',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV73GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E17842',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'edtIncidenciaId_Visible',ctrl:'INCIDENCIAID',prop:'Visible'},{av:'cmbIncidenciaOrigen'},{av:'edtIncidenciaCodRef_Visible',ctrl:'INCIDENCIACODREF',prop:'Visible'},{av:'edtMotivoNombre_Visible',ctrl:'MOTIVONOMBRE',prop:'Visible'},{av:'cmbIncidenciaEstado'},{av:'edtIncidenciaUsrAlta_Visible',ctrl:'INCIDENCIAUSRALTA',prop:'Visible'},{av:'edtIncidenciaFechaAlta_Visible',ctrl:'INCIDENCIAFECHAALTA',prop:'Visible'},{av:'edtIncidenciaUsrActualizacion_Visible',ctrl:'INCIDENCIAUSRACTUALIZACION',prop:'Visible'},{av:'edtIncidenciaFechaActualizacion_Visible',ctrl:'INCIDENCIAFECHAACTUALIZACION',prop:'Visible'},{av:'AV70GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E22842',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E18842',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cmbavDynamicfiltersoperator3'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'edtavMotivonombre2_Visible',ctrl:'vMOTIVONOMBRE2',prop:'Visible'},{av:'edtavMotivonombre3_Visible',ctrl:'vMOTIVONOMBRE3',prop:'Visible'},{av:'edtavMotivonombre1_Visible',ctrl:'vMOTIVONOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtIncidenciaId_Visible',ctrl:'INCIDENCIAID',prop:'Visible'},{av:'cmbIncidenciaOrigen'},{av:'edtIncidenciaCodRef_Visible',ctrl:'INCIDENCIACODREF',prop:'Visible'},{av:'edtMotivoNombre_Visible',ctrl:'MOTIVONOMBRE',prop:'Visible'},{av:'cmbIncidenciaEstado'},{av:'edtIncidenciaUsrAlta_Visible',ctrl:'INCIDENCIAUSRALTA',prop:'Visible'},{av:'edtIncidenciaFechaAlta_Visible',ctrl:'INCIDENCIAFECHAALTA',prop:'Visible'},{av:'edtIncidenciaUsrActualizacion_Visible',ctrl:'INCIDENCIAUSRACTUALIZACION',prop:'Visible'},{av:'edtIncidenciaFechaActualizacion_Visible',ctrl:'INCIDENCIAFECHAACTUALIZACION',prop:'Visible'},{av:'AV70GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E23842',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavIncidenciaorigen1'},{av:'edtavMotivonombre1_Visible',ctrl:'vMOTIVONOMBRE1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E24842',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E19842',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cmbavDynamicfiltersoperator3'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'edtavMotivonombre2_Visible',ctrl:'vMOTIVONOMBRE2',prop:'Visible'},{av:'edtavMotivonombre3_Visible',ctrl:'vMOTIVONOMBRE3',prop:'Visible'},{av:'edtavMotivonombre1_Visible',ctrl:'vMOTIVONOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtIncidenciaId_Visible',ctrl:'INCIDENCIAID',prop:'Visible'},{av:'cmbIncidenciaOrigen'},{av:'edtIncidenciaCodRef_Visible',ctrl:'INCIDENCIACODREF',prop:'Visible'},{av:'edtMotivoNombre_Visible',ctrl:'MOTIVONOMBRE',prop:'Visible'},{av:'cmbIncidenciaEstado'},{av:'edtIncidenciaUsrAlta_Visible',ctrl:'INCIDENCIAUSRALTA',prop:'Visible'},{av:'edtIncidenciaFechaAlta_Visible',ctrl:'INCIDENCIAFECHAALTA',prop:'Visible'},{av:'edtIncidenciaUsrActualizacion_Visible',ctrl:'INCIDENCIAUSRACTUALIZACION',prop:'Visible'},{av:'edtIncidenciaFechaActualizacion_Visible',ctrl:'INCIDENCIAFECHAACTUALIZACION',prop:'Visible'},{av:'AV70GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E25842',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavIncidenciaorigen2'},{av:'edtavMotivonombre2_Visible',ctrl:'vMOTIVONOMBRE2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E20842',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cmbavDynamicfiltersoperator3'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'edtavMotivonombre2_Visible',ctrl:'vMOTIVONOMBRE2',prop:'Visible'},{av:'edtavMotivonombre3_Visible',ctrl:'vMOTIVONOMBRE3',prop:'Visible'},{av:'edtavMotivonombre1_Visible',ctrl:'vMOTIVONOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtIncidenciaId_Visible',ctrl:'INCIDENCIAID',prop:'Visible'},{av:'cmbIncidenciaOrigen'},{av:'edtIncidenciaCodRef_Visible',ctrl:'INCIDENCIACODREF',prop:'Visible'},{av:'edtMotivoNombre_Visible',ctrl:'MOTIVONOMBRE',prop:'Visible'},{av:'cmbIncidenciaEstado'},{av:'edtIncidenciaUsrAlta_Visible',ctrl:'INCIDENCIAUSRALTA',prop:'Visible'},{av:'edtIncidenciaFechaAlta_Visible',ctrl:'INCIDENCIAFECHAALTA',prop:'Visible'},{av:'edtIncidenciaUsrActualizacion_Visible',ctrl:'INCIDENCIAUSRACTUALIZACION',prop:'Visible'},{av:'edtIncidenciaFechaActualizacion_Visible',ctrl:'INCIDENCIAFECHAACTUALIZACION',prop:'Visible'},{av:'AV70GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E26842',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavIncidenciaorigen3'},{av:'edtavMotivonombre3_Visible',ctrl:'vMOTIVONOMBRE3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11842',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV46TFIncidenciaOrigen_SelsJson',fld:'vTFINCIDENCIAORIGEN_SELSJSON',pic:'',type:'vchar'},{av:'AV52TFIncidenciaEstado_SelsJson',fld:'vTFINCIDENCIAESTADO_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV52TFIncidenciaEstado_SelsJson',fld:'vTFINCIDENCIAESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV46TFIncidenciaOrigen_SelsJson',fld:'vTFINCIDENCIAORIGEN_SELSJSON',pic:'',type:'vchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'edtavMotivonombre1_Visible',ctrl:'vMOTIVONOMBRE1',prop:'Visible'},{av:'edtavMotivonombre2_Visible',ctrl:'vMOTIVONOMBRE2',prop:'Visible'},{av:'edtavMotivonombre3_Visible',ctrl:'vMOTIVONOMBRE3',prop:'Visible'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtIncidenciaId_Visible',ctrl:'INCIDENCIAID',prop:'Visible'},{av:'cmbIncidenciaOrigen'},{av:'edtIncidenciaCodRef_Visible',ctrl:'INCIDENCIACODREF',prop:'Visible'},{av:'edtMotivoNombre_Visible',ctrl:'MOTIVONOMBRE',prop:'Visible'},{av:'cmbIncidenciaEstado'},{av:'edtIncidenciaUsrAlta_Visible',ctrl:'INCIDENCIAUSRALTA',prop:'Visible'},{av:'edtIncidenciaFechaAlta_Visible',ctrl:'INCIDENCIAFECHAALTA',prop:'Visible'},{av:'edtIncidenciaUsrActualizacion_Visible',ctrl:'INCIDENCIAUSRACTUALIZACION',prop:'Visible'},{av:'edtIncidenciaFechaActualizacion_Visible',ctrl:'INCIDENCIAFECHAACTUALIZACION',prop:'Visible'},{av:'AV70GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E30842',iparms:[{av:'cmbavGridactions'},{av:'AV73GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A603IncidenciaId',fld:'INCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV73GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E21842',iparms:[{av:'A603IncidenciaId',fld:'INCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14842',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV46TFIncidenciaOrigen_SelsJson',fld:'vTFINCIDENCIAORIGEN_SELSJSON',pic:'',type:'vchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV52TFIncidenciaEstado_SelsJson',fld:'vTFINCIDENCIAESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen1'},{av:'AV20IncidenciaOrigen1',fld:'vINCIDENCIAORIGEN1',pic:'',type:'char'},{av:'AV21MotivoNombre1',fld:'vMOTIVONOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen2'},{av:'AV25IncidenciaOrigen2',fld:'vINCIDENCIAORIGEN2',pic:'',type:'char'},{av:'AV26MotivoNombre2',fld:'vMOTIVONOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'cmbavIncidenciaorigen3'},{av:'AV30IncidenciaOrigen3',fld:'vINCIDENCIAORIGEN3',pic:'',type:'char'},{av:'AV31MotivoNombre3',fld:'vMOTIVONOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV79Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV44TFIncidenciaId',fld:'vTFINCIDENCIAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFIncidenciaId_To',fld:'vTFINCIDENCIAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFIncidenciaOrigen_Sels',fld:'vTFINCIDENCIAORIGEN_SELS',pic:''},{av:'AV48TFIncidenciaCodRef',fld:'vTFINCIDENCIACODREF',pic:'',type:'svchar'},{av:'AV49TFIncidenciaCodRef_Sel',fld:'vTFINCIDENCIACODREF_SEL',pic:'',type:'svchar'},{av:'AV50TFMotivoNombre',fld:'vTFMOTIVONOMBRE',pic:'',type:'char'},{av:'AV51TFMotivoNombre_Sel',fld:'vTFMOTIVONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFIncidenciaEstado_Sels',fld:'vTFINCIDENCIAESTADO_SELS',pic:''},{av:'AV54TFIncidenciaUsrAlta',fld:'vTFINCIDENCIAUSRALTA',pic:'',type:'char'},{av:'AV55TFIncidenciaUsrAlta_Sel',fld:'vTFINCIDENCIAUSRALTA_SEL',pic:'',type:'char'},{av:'AV56TFIncidenciaFechaAlta',fld:'vTFINCIDENCIAFECHAALTA',pic:'',type:'date'},{av:'AV57TFIncidenciaFechaAlta_To',fld:'vTFINCIDENCIAFECHAALTA_TO',pic:'',type:'date'},{av:'AV61TFIncidenciaUsrActualizacion',fld:'vTFINCIDENCIAUSRACTUALIZACION',pic:'',type:'char'},{av:'AV62TFIncidenciaUsrActualizacion_Sel',fld:'vTFINCIDENCIAUSRACTUALIZACION_SEL',pic:'',type:'char'},{av:'AV63TFIncidenciaFechaActualizacion',fld:'vTFINCIDENCIAFECHAACTUALIZACION',pic:'',type:'date'},{av:'AV64TFIncidenciaFechaActualizacion_To',fld:'vTFINCIDENCIAFECHAACTUALIZACION_TO',pic:'',type:'date'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV52TFIncidenciaEstado_SelsJson',fld:'vTFINCIDENCIAESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV46TFIncidenciaOrigen_SelsJson',fld:'vTFINCIDENCIAORIGEN_SELSJSON',pic:'',type:'vchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavMotivonombre1_Visible',ctrl:'vMOTIVONOMBRE1',prop:'Visible'},{av:'edtavMotivonombre2_Visible',ctrl:'vMOTIVONOMBRE2',prop:'Visible'},{av:'edtavMotivonombre3_Visible',ctrl:'vMOTIVONOMBRE3',prop:'Visible'},{av:'edtIncidenciaId_Visible',ctrl:'INCIDENCIAID',prop:'Visible'},{av:'cmbIncidenciaOrigen'},{av:'edtIncidenciaCodRef_Visible',ctrl:'INCIDENCIACODREF',prop:'Visible'},{av:'edtMotivoNombre_Visible',ctrl:'MOTIVONOMBRE',prop:'Visible'},{av:'cmbIncidenciaEstado'},{av:'edtIncidenciaUsrAlta_Visible',ctrl:'INCIDENCIAUSRALTA',prop:'Visible'},{av:'edtIncidenciaFechaAlta_Visible',ctrl:'INCIDENCIAFECHAALTA',prop:'Visible'},{av:'edtIncidenciaUsrActualizacion_Visible',ctrl:'INCIDENCIAUSRACTUALIZACION',prop:'Visible'},{av:'edtIncidenciaFechaActualizacion_Visible',ctrl:'INCIDENCIAFECHAACTUALIZACION',prop:'Visible'},{av:'AV70GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV71GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E15842',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALIDV_INCIDENCIAORIGEN1","{handler:'Validv_Incidenciaorigen1',iparms:[]");
         setEventMetadata("VALIDV_INCIDENCIAORIGEN1",",oparms:[]}");
         setEventMetadata("VALIDV_INCIDENCIAORIGEN2","{handler:'Validv_Incidenciaorigen2',iparms:[]");
         setEventMetadata("VALIDV_INCIDENCIAORIGEN2",",oparms:[]}");
         setEventMetadata("VALIDV_INCIDENCIAORIGEN3","{handler:'Validv_Incidenciaorigen3',iparms:[]");
         setEventMetadata("VALIDV_INCIDENCIAORIGEN3",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAID","{handler:'Valid_Incidenciaid',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAID",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAORIGEN","{handler:'Valid_Incidenciaorigen',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAORIGEN",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIACODREF","{handler:'Valid_Incidenciacodref',iparms:[]");
         setEventMetadata("VALID_INCIDENCIACODREF",",oparms:[]}");
         setEventMetadata("VALID_MOTIVOID","{handler:'Valid_Motivoid',iparms:[]");
         setEventMetadata("VALID_MOTIVOID",",oparms:[]}");
         setEventMetadata("VALID_MOTIVONOMBRE","{handler:'Valid_Motivonombre',iparms:[]");
         setEventMetadata("VALID_MOTIVONOMBRE",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAESTADO","{handler:'Valid_Incidenciaestado',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAESTADO",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAUSRALTA","{handler:'Valid_Incidenciausralta',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAUSRALTA",",oparms:[]}");
         setEventMetadata("VALID_INCIDENCIAUSRACTUALIZACION","{handler:'Valid_Incidenciausractualizacion',iparms:[]");
         setEventMetadata("VALID_INCIDENCIAUSRACTUALIZACION",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Incidenciafechaactualizacion',iparms:[]");
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
         AV20IncidenciaOrigen1 = "";
         AV21MotivoNombre1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25IncidenciaOrigen2 = "";
         AV26MotivoNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30IncidenciaOrigen3 = "";
         AV31MotivoNombre3 = "";
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV79Pgmname = "";
         AV17FilterFullText = "";
         AV47TFIncidenciaOrigen_Sels = new GxSimpleCollection<string>();
         AV48TFIncidenciaCodRef = "";
         AV49TFIncidenciaCodRef_Sel = "";
         AV50TFMotivoNombre = "";
         AV51TFMotivoNombre_Sel = "";
         AV53TFIncidenciaEstado_Sels = new GxSimpleCollection<string>();
         AV54TFIncidenciaUsrAlta = "";
         AV55TFIncidenciaUsrAlta_Sel = "";
         AV56TFIncidenciaFechaAlta = DateTime.MinValue;
         AV57TFIncidenciaFechaAlta_To = DateTime.MinValue;
         AV61TFIncidenciaUsrActualizacion = "";
         AV62TFIncidenciaUsrActualizacion_Sel = "";
         AV63TFIncidenciaFechaActualizacion = DateTime.MinValue;
         AV64TFIncidenciaFechaActualizacion_To = DateTime.MinValue;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV72GridAppliedFilters = "";
         AV76AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV68DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV59DDO_IncidenciaFechaAltaAuxDateTo = DateTime.MinValue;
         AV66DDO_IncidenciaFechaActualizacionAuxDateTo = DateTime.MinValue;
         AV46TFIncidenciaOrigen_SelsJson = "";
         AV52TFIncidenciaEstado_SelsJson = "";
         AV58DDO_IncidenciaFechaAltaAuxDate = DateTime.MinValue;
         AV65DDO_IncidenciaFechaActualizacionAuxDate = DateTime.MinValue;
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
         AV60DDO_IncidenciaFechaAltaAuxDateText = "";
         ucTfincidenciafechaalta_rangepicker = new GXUserControl();
         AV67DDO_IncidenciaFechaActualizacionAuxDateText = "";
         ucTfincidenciafechaactualizacion_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A611IncidenciaOrigen = "";
         A606IncidenciaCodRef = "";
         A616MotivoNombre = "";
         A608IncidenciaEstado = "";
         A615IncidenciaUsrAlta = "";
         A610IncidenciaFechaAlta = DateTime.MinValue;
         A614IncidenciaUsrActualizacion = "";
         A609IncidenciaFechaActualizacion = DateTime.MinValue;
         AV80Incidenciawwds_1_filterfulltext = "";
         AV81Incidenciawwds_2_dynamicfiltersselector1 = "";
         AV83Incidenciawwds_4_incidenciaorigen1 = "";
         AV84Incidenciawwds_5_motivonombre1 = "";
         AV86Incidenciawwds_7_dynamicfiltersselector2 = "";
         AV88Incidenciawwds_9_incidenciaorigen2 = "";
         AV89Incidenciawwds_10_motivonombre2 = "";
         AV91Incidenciawwds_12_dynamicfiltersselector3 = "";
         AV93Incidenciawwds_14_incidenciaorigen3 = "";
         AV94Incidenciawwds_15_motivonombre3 = "";
         AV97Incidenciawwds_18_tfincidenciaorigen_sels = new GxSimpleCollection<string>();
         AV98Incidenciawwds_19_tfincidenciacodref = "";
         AV99Incidenciawwds_20_tfincidenciacodref_sel = "";
         AV100Incidenciawwds_21_tfmotivonombre = "";
         AV101Incidenciawwds_22_tfmotivonombre_sel = "";
         AV102Incidenciawwds_23_tfincidenciaestado_sels = new GxSimpleCollection<string>();
         AV103Incidenciawwds_24_tfincidenciausralta = "";
         AV104Incidenciawwds_25_tfincidenciausralta_sel = "";
         AV105Incidenciawwds_26_tfincidenciafechaalta = DateTime.MinValue;
         AV106Incidenciawwds_27_tfincidenciafechaalta_to = DateTime.MinValue;
         AV107Incidenciawwds_28_tfincidenciausractualizacion = "";
         AV108Incidenciawwds_29_tfincidenciausractualizacion_sel = "";
         AV109Incidenciawwds_30_tfincidenciafechaactualizacion = DateTime.MinValue;
         AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to = DateTime.MinValue;
         lV80Incidenciawwds_1_filterfulltext = "";
         lV84Incidenciawwds_5_motivonombre1 = "";
         lV89Incidenciawwds_10_motivonombre2 = "";
         lV94Incidenciawwds_15_motivonombre3 = "";
         lV98Incidenciawwds_19_tfincidenciacodref = "";
         lV100Incidenciawwds_21_tfmotivonombre = "";
         lV103Incidenciawwds_24_tfincidenciausralta = "";
         lV107Incidenciawwds_28_tfincidenciausractualizacion = "";
         H00842_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         H00842_A614IncidenciaUsrActualizacion = new string[] {""} ;
         H00842_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00842_A615IncidenciaUsrAlta = new string[] {""} ;
         H00842_A608IncidenciaEstado = new string[] {""} ;
         H00842_A616MotivoNombre = new string[] {""} ;
         H00842_A604MotivoId = new long[1] ;
         H00842_A606IncidenciaCodRef = new string[] {""} ;
         H00842_A611IncidenciaOrigen = new string[] {""} ;
         H00842_A603IncidenciaId = new long[1] ;
         H00843_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         H00843_A614IncidenciaUsrActualizacion = new string[] {""} ;
         H00843_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00843_A615IncidenciaUsrAlta = new string[] {""} ;
         H00843_A608IncidenciaEstado = new string[] {""} ;
         H00843_A616MotivoNombre = new string[] {""} ;
         H00843_A604MotivoId = new long[1] ;
         H00843_A606IncidenciaCodRef = new string[] {""} ;
         H00843_A611IncidenciaOrigen = new string[] {""} ;
         H00843_A603IncidenciaId = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV77AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV42ManageFiltersXml = "";
         AV37UserCustomValue = "";
         AV39ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char5 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.incidenciaww__default(),
            new Object[][] {
                new Object[] {
               H00842_A609IncidenciaFechaActualizacion, H00842_A614IncidenciaUsrActualizacion, H00842_A610IncidenciaFechaAlta, H00842_A615IncidenciaUsrAlta, H00842_A608IncidenciaEstado, H00842_A616MotivoNombre, H00842_A604MotivoId, H00842_A606IncidenciaCodRef, H00842_A611IncidenciaOrigen, H00842_A603IncidenciaId
               }
               , new Object[] {
               H00843_A609IncidenciaFechaActualizacion, H00843_A614IncidenciaUsrActualizacion, H00843_A610IncidenciaFechaAlta, H00843_A615IncidenciaUsrAlta, H00843_A608IncidenciaEstado, H00843_A616MotivoNombre, H00843_A604MotivoId, H00843_A606IncidenciaCodRef, H00843_A611IncidenciaOrigen, H00843_A603IncidenciaId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV79Pgmname = "IncidenciaWW";
         /* GeneXus formulas. */
         AV79Pgmname = "IncidenciaWW";
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
      private short AV73GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV82Incidenciawwds_3_dynamicfiltersoperator1 ;
      private short AV87Incidenciawwds_8_dynamicfiltersoperator2 ;
      private short AV92Incidenciawwds_13_dynamicfiltersoperator3 ;
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
      private int nRC_GXsfl_120 ;
      private int nGXsfl_120_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int AV97Incidenciawwds_18_tfincidenciaorigen_sels_Count ;
      private int AV102Incidenciawwds_23_tfincidenciaestado_sels_Count ;
      private int edtIncidenciaId_Enabled ;
      private int edtIncidenciaCodRef_Enabled ;
      private int edtMotivoId_Enabled ;
      private int edtMotivoNombre_Enabled ;
      private int edtIncidenciaUsrAlta_Enabled ;
      private int edtIncidenciaFechaAlta_Enabled ;
      private int edtIncidenciaUsrActualizacion_Enabled ;
      private int edtIncidenciaFechaActualizacion_Enabled ;
      private int edtIncidenciaId_Visible ;
      private int edtIncidenciaCodRef_Visible ;
      private int edtMotivoNombre_Visible ;
      private int edtIncidenciaUsrAlta_Visible ;
      private int edtIncidenciaFechaAlta_Visible ;
      private int edtIncidenciaUsrActualizacion_Visible ;
      private int edtIncidenciaFechaActualizacion_Visible ;
      private int AV69PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavMotivonombre1_Visible ;
      private int edtavMotivonombre2_Visible ;
      private int edtavMotivonombre3_Visible ;
      private int AV111GXV1 ;
      private int edtavMotivonombre3_Enabled ;
      private int edtavMotivonombre2_Enabled ;
      private int edtavMotivonombre1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV44TFIncidenciaId ;
      private long AV45TFIncidenciaId_To ;
      private long AV70GridCurrentPage ;
      private long AV71GridPageCount ;
      private long A603IncidenciaId ;
      private long A604MotivoId ;
      private long GRID_nCurrentRecord ;
      private long AV95Incidenciawwds_16_tfincidenciaid ;
      private long AV96Incidenciawwds_17_tfincidenciaid_to ;
      private long GRID_nRecordCount ;
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
      private string sGXsfl_120_idx="0001" ;
      private string AV20IncidenciaOrigen1 ;
      private string AV21MotivoNombre1 ;
      private string AV25IncidenciaOrigen2 ;
      private string AV26MotivoNombre2 ;
      private string AV30IncidenciaOrigen3 ;
      private string AV31MotivoNombre3 ;
      private string AV79Pgmname ;
      private string AV50TFMotivoNombre ;
      private string AV51TFMotivoNombre_Sel ;
      private string AV54TFIncidenciaUsrAlta ;
      private string AV55TFIncidenciaUsrAlta_Sel ;
      private string AV61TFIncidenciaUsrActualizacion ;
      private string AV62TFIncidenciaUsrActualizacion_Sel ;
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
      private string divDdo_incidenciafechaaltaauxdates_Internalname ;
      private string edtavDdo_incidenciafechaaltaauxdatetext_Internalname ;
      private string edtavDdo_incidenciafechaaltaauxdatetext_Jsonclick ;
      private string Tfincidenciafechaalta_rangepicker_Internalname ;
      private string divDdo_incidenciafechaactualizacionauxdates_Internalname ;
      private string edtavDdo_incidenciafechaactualizacionauxdatetext_Internalname ;
      private string edtavDdo_incidenciafechaactualizacionauxdatetext_Jsonclick ;
      private string Tfincidenciafechaactualizacion_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtIncidenciaId_Internalname ;
      private string cmbIncidenciaOrigen_Internalname ;
      private string A611IncidenciaOrigen ;
      private string edtIncidenciaCodRef_Internalname ;
      private string edtMotivoId_Internalname ;
      private string A616MotivoNombre ;
      private string edtMotivoNombre_Internalname ;
      private string cmbIncidenciaEstado_Internalname ;
      private string A608IncidenciaEstado ;
      private string A615IncidenciaUsrAlta ;
      private string edtIncidenciaUsrAlta_Internalname ;
      private string edtIncidenciaFechaAlta_Internalname ;
      private string A614IncidenciaUsrActualizacion ;
      private string edtIncidenciaUsrActualizacion_Internalname ;
      private string edtIncidenciaFechaActualizacion_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavIncidenciaorigen1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavIncidenciaorigen2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string cmbavIncidenciaorigen3_Internalname ;
      private string AV83Incidenciawwds_4_incidenciaorigen1 ;
      private string AV84Incidenciawwds_5_motivonombre1 ;
      private string AV88Incidenciawwds_9_incidenciaorigen2 ;
      private string AV89Incidenciawwds_10_motivonombre2 ;
      private string AV93Incidenciawwds_14_incidenciaorigen3 ;
      private string AV94Incidenciawwds_15_motivonombre3 ;
      private string AV100Incidenciawwds_21_tfmotivonombre ;
      private string AV101Incidenciawwds_22_tfmotivonombre_sel ;
      private string AV103Incidenciawwds_24_tfincidenciausralta ;
      private string AV104Incidenciawwds_25_tfincidenciausralta_sel ;
      private string AV107Incidenciawwds_28_tfincidenciausractualizacion ;
      private string AV108Incidenciawwds_29_tfincidenciausractualizacion_sel ;
      private string lV84Incidenciawwds_5_motivonombre1 ;
      private string lV89Incidenciawwds_10_motivonombre2 ;
      private string lV94Incidenciawwds_15_motivonombre3 ;
      private string lV100Incidenciawwds_21_tfmotivonombre ;
      private string lV103Incidenciawwds_24_tfincidenciausralta ;
      private string lV107Incidenciawwds_28_tfincidenciausractualizacion ;
      private string edtavMotivonombre1_Internalname ;
      private string edtavMotivonombre2_Internalname ;
      private string edtavMotivonombre3_Internalname ;
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
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_incidenciaorigen3_cell_Internalname ;
      private string cmbavIncidenciaorigen3_Jsonclick ;
      private string cellFilter_motivonombre3_cell_Internalname ;
      private string edtavMotivonombre3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_incidenciaorigen2_cell_Internalname ;
      private string cmbavIncidenciaorigen2_Jsonclick ;
      private string cellFilter_motivonombre2_cell_Internalname ;
      private string edtavMotivonombre2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_incidenciaorigen1_cell_Internalname ;
      private string cmbavIncidenciaorigen1_Jsonclick ;
      private string cellFilter_motivonombre1_cell_Internalname ;
      private string edtavMotivonombre1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_120_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtIncidenciaId_Jsonclick ;
      private string cmbIncidenciaOrigen_Jsonclick ;
      private string edtIncidenciaCodRef_Jsonclick ;
      private string edtMotivoId_Jsonclick ;
      private string edtMotivoNombre_Jsonclick ;
      private string cmbIncidenciaEstado_Jsonclick ;
      private string edtIncidenciaUsrAlta_Jsonclick ;
      private string edtIncidenciaFechaAlta_Jsonclick ;
      private string edtIncidenciaUsrActualizacion_Jsonclick ;
      private string edtIncidenciaFechaActualizacion_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV56TFIncidenciaFechaAlta ;
      private DateTime AV57TFIncidenciaFechaAlta_To ;
      private DateTime AV63TFIncidenciaFechaActualizacion ;
      private DateTime AV64TFIncidenciaFechaActualizacion_To ;
      private DateTime AV59DDO_IncidenciaFechaAltaAuxDateTo ;
      private DateTime AV66DDO_IncidenciaFechaActualizacionAuxDateTo ;
      private DateTime AV58DDO_IncidenciaFechaAltaAuxDate ;
      private DateTime AV65DDO_IncidenciaFechaActualizacionAuxDate ;
      private DateTime A610IncidenciaFechaAlta ;
      private DateTime A609IncidenciaFechaActualizacion ;
      private DateTime AV105Incidenciawwds_26_tfincidenciafechaalta ;
      private DateTime AV106Incidenciawwds_27_tfincidenciafechaalta_to ;
      private DateTime AV109Incidenciawwds_30_tfincidenciafechaactualizacion ;
      private DateTime AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV33DynamicFiltersIgnoreFirst ;
      private bool AV32DynamicFiltersRemoving ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_120_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV85Incidenciawwds_6_dynamicfiltersenabled2 ;
      private bool AV90Incidenciawwds_11_dynamicfiltersenabled3 ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV78TempBoolean ;
      private bool GXt_boolean3 ;
      private string AV46TFIncidenciaOrigen_SelsJson ;
      private string AV52TFIncidenciaEstado_SelsJson ;
      private string AV36ColumnsSelectorXML ;
      private string AV42ManageFiltersXml ;
      private string AV37UserCustomValue ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV17FilterFullText ;
      private string AV48TFIncidenciaCodRef ;
      private string AV49TFIncidenciaCodRef_Sel ;
      private string AV72GridAppliedFilters ;
      private string AV60DDO_IncidenciaFechaAltaAuxDateText ;
      private string AV67DDO_IncidenciaFechaActualizacionAuxDateText ;
      private string A606IncidenciaCodRef ;
      private string AV80Incidenciawwds_1_filterfulltext ;
      private string AV81Incidenciawwds_2_dynamicfiltersselector1 ;
      private string AV86Incidenciawwds_7_dynamicfiltersselector2 ;
      private string AV91Incidenciawwds_12_dynamicfiltersselector3 ;
      private string AV98Incidenciawwds_19_tfincidenciacodref ;
      private string AV99Incidenciawwds_20_tfincidenciacodref_sel ;
      private string lV80Incidenciawwds_1_filterfulltext ;
      private string lV98Incidenciawwds_19_tfincidenciacodref ;
      private string AV34ExcelFilename ;
      private string AV35ErrorMessage ;
      private IGxSession AV40Session ;
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
      private GXUserControl ucTfincidenciafechaalta_rangepicker ;
      private GXUserControl ucTfincidenciafechaactualizacion_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavIncidenciaorigen1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavIncidenciaorigen2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavIncidenciaorigen3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbIncidenciaOrigen ;
      private GXCombobox cmbIncidenciaEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ;
      private GxSimpleCollection<string> AV47TFIncidenciaOrigen_Sels ;
      private GxSimpleCollection<string> AV53TFIncidenciaEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV41ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV76AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV68DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV97Incidenciawwds_18_tfincidenciaorigen_sels ;
      private GxSimpleCollection<string> AV102Incidenciawwds_23_tfincidenciaestado_sels ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H00842_A609IncidenciaFechaActualizacion ;
      private string[] H00842_A614IncidenciaUsrActualizacion ;
      private DateTime[] H00842_A610IncidenciaFechaAlta ;
      private string[] H00842_A615IncidenciaUsrAlta ;
      private string[] H00842_A608IncidenciaEstado ;
      private string[] H00842_A616MotivoNombre ;
      private long[] H00842_A604MotivoId ;
      private string[] H00842_A606IncidenciaCodRef ;
      private string[] H00842_A611IncidenciaOrigen ;
      private long[] H00842_A603IncidenciaId ;
      private DateTime[] H00843_A609IncidenciaFechaActualizacion ;
      private string[] H00843_A614IncidenciaUsrActualizacion ;
      private DateTime[] H00843_A610IncidenciaFechaAlta ;
      private string[] H00843_A615IncidenciaUsrAlta ;
      private string[] H00843_A608IncidenciaEstado ;
      private string[] H00843_A616MotivoNombre ;
      private long[] H00843_A604MotivoId ;
      private string[] H00843_A606IncidenciaCodRef ;
      private string[] H00843_A611IncidenciaOrigen ;
      private long[] H00843_A603IncidenciaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV77AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class incidenciaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00842( IGxContext context ,
                                             string A611IncidenciaOrigen ,
                                             GxSimpleCollection<string> AV97Incidenciawwds_18_tfincidenciaorigen_sels ,
                                             string A608IncidenciaEstado ,
                                             GxSimpleCollection<string> AV102Incidenciawwds_23_tfincidenciaestado_sels ,
                                             string AV81Incidenciawwds_2_dynamicfiltersselector1 ,
                                             string AV83Incidenciawwds_4_incidenciaorigen1 ,
                                             short AV82Incidenciawwds_3_dynamicfiltersoperator1 ,
                                             string AV84Incidenciawwds_5_motivonombre1 ,
                                             bool AV85Incidenciawwds_6_dynamicfiltersenabled2 ,
                                             string AV86Incidenciawwds_7_dynamicfiltersselector2 ,
                                             string AV88Incidenciawwds_9_incidenciaorigen2 ,
                                             short AV87Incidenciawwds_8_dynamicfiltersoperator2 ,
                                             string AV89Incidenciawwds_10_motivonombre2 ,
                                             bool AV90Incidenciawwds_11_dynamicfiltersenabled3 ,
                                             string AV91Incidenciawwds_12_dynamicfiltersselector3 ,
                                             string AV93Incidenciawwds_14_incidenciaorigen3 ,
                                             short AV92Incidenciawwds_13_dynamicfiltersoperator3 ,
                                             string AV94Incidenciawwds_15_motivonombre3 ,
                                             long AV95Incidenciawwds_16_tfincidenciaid ,
                                             long AV96Incidenciawwds_17_tfincidenciaid_to ,
                                             int AV97Incidenciawwds_18_tfincidenciaorigen_sels_Count ,
                                             string AV99Incidenciawwds_20_tfincidenciacodref_sel ,
                                             string AV98Incidenciawwds_19_tfincidenciacodref ,
                                             string AV101Incidenciawwds_22_tfmotivonombre_sel ,
                                             string AV100Incidenciawwds_21_tfmotivonombre ,
                                             int AV102Incidenciawwds_23_tfincidenciaestado_sels_Count ,
                                             string AV104Incidenciawwds_25_tfincidenciausralta_sel ,
                                             string AV103Incidenciawwds_24_tfincidenciausralta ,
                                             DateTime AV105Incidenciawwds_26_tfincidenciafechaalta ,
                                             DateTime AV106Incidenciawwds_27_tfincidenciafechaalta_to ,
                                             string AV108Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                             string AV107Incidenciawwds_28_tfincidenciausractualizacion ,
                                             DateTime AV109Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                             DateTime AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                             string A616MotivoNombre ,
                                             long A603IncidenciaId ,
                                             string A606IncidenciaCodRef ,
                                             string A615IncidenciaUsrAlta ,
                                             DateTime A610IncidenciaFechaAlta ,
                                             string A614IncidenciaUsrActualizacion ,
                                             DateTime A609IncidenciaFechaActualizacion ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV80Incidenciawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[23];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[IncidenciaFechaActualizacion], T1.[IncidenciaUsrActualizacion], T1.[IncidenciaFechaAlta], T1.[IncidenciaUsrAlta], T1.[IncidenciaEstado], T2.[MotivoNombre], T1.[MotivoId], T1.[IncidenciaCodRef], T1.[IncidenciaOrigen], T1.[IncidenciaId] FROM ([Incidencia] T1 INNER JOIN [Motivo] T2 ON T2.[MotivoId] = T1.[MotivoId])";
         if ( ( StringUtil.StrCmp(AV81Incidenciawwds_2_dynamicfiltersselector1, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Incidenciawwds_4_incidenciaorigen1)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV83Incidenciawwds_4_incidenciaorigen1)");
         }
         else
         {
            GXv_int10[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV81Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV82Incidenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV84Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV81Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV82Incidenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV84Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( AV85Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Incidenciawwds_7_dynamicfiltersselector2, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Incidenciawwds_9_incidenciaorigen2)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV88Incidenciawwds_9_incidenciaorigen2)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( AV85Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV87Incidenciawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV89Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( AV85Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV87Incidenciawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV89Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( AV90Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Incidenciawwds_12_dynamicfiltersselector3, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Incidenciawwds_14_incidenciaorigen3)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV93Incidenciawwds_14_incidenciaorigen3)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( AV90Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV92Incidenciawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV94Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( AV90Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV92Incidenciawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV94Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! (0==AV95Incidenciawwds_16_tfincidenciaid) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] >= @AV95Incidenciawwds_16_tfincidenciaid)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! (0==AV96Incidenciawwds_17_tfincidenciaid_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] <= @AV96Incidenciawwds_17_tfincidenciaid_to)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( AV97Incidenciawwds_18_tfincidenciaorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV97Incidenciawwds_18_tfincidenciaorigen_sels, "T1.[IncidenciaOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Incidenciawwds_20_tfincidenciacodref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Incidenciawwds_19_tfincidenciacodref)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaCodRef]) like UPPER(@lV98Incidenciawwds_19_tfincidenciacodref))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Incidenciawwds_20_tfincidenciacodref_sel)) && ! ( StringUtil.StrCmp(AV99Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaCodRef] = @AV99Incidenciawwds_20_tfincidenciacodref_sel)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( StringUtil.StrCmp(AV99Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaCodRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Incidenciawwds_22_tfmotivonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Incidenciawwds_21_tfmotivonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV100Incidenciawwds_21_tfmotivonombre))");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Incidenciawwds_22_tfmotivonombre_sel)) && ! ( StringUtil.StrCmp(AV101Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MotivoNombre] = @AV101Incidenciawwds_22_tfmotivonombre_sel)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( StringUtil.StrCmp(AV101Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MotivoNombre] = ''))");
         }
         if ( AV102Incidenciawwds_23_tfincidenciaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV102Incidenciawwds_23_tfincidenciaestado_sels, "T1.[IncidenciaEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Incidenciawwds_25_tfincidenciausralta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Incidenciawwds_24_tfincidenciausralta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrAlta]) like UPPER(@lV103Incidenciawwds_24_tfincidenciausralta))");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Incidenciawwds_25_tfincidenciausralta_sel)) && ! ( StringUtil.StrCmp(AV104Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrAlta] = @AV104Incidenciawwds_25_tfincidenciausralta_sel)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( StringUtil.StrCmp(AV104Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV105Incidenciawwds_26_tfincidenciafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] >= @AV105Incidenciawwds_26_tfincidenciafechaalta)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Incidenciawwds_27_tfincidenciafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] <= @AV106Incidenciawwds_27_tfincidenciafechaalta_to)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Incidenciawwds_28_tfincidenciausractualizacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrActualizacion]) like UPPER(@lV107Incidenciawwds_28_tfincidenciausractualizacion))");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ! ( StringUtil.StrCmp(AV108Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrActualizacion] = @AV108Incidenciawwds_29_tfincidenciausractualizacion_sel)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( StringUtil.StrCmp(AV108Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrActualizacion] = ''))");
         }
         if ( ! (DateTime.MinValue==AV109Incidenciawwds_30_tfincidenciafechaactualizacion) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] >= @AV109Incidenciawwds_30_tfincidenciafechaactualizacion)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] <= @AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaOrigen]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaOrigen] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaCodRef]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaCodRef] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MotivoNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MotivoNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaEstado]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrAlta]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrActualizacion]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrActualizacion] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaActualizacion]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaActualizacion] DESC";
         }
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_H00843( IGxContext context ,
                                             string A611IncidenciaOrigen ,
                                             GxSimpleCollection<string> AV97Incidenciawwds_18_tfincidenciaorigen_sels ,
                                             string A608IncidenciaEstado ,
                                             GxSimpleCollection<string> AV102Incidenciawwds_23_tfincidenciaestado_sels ,
                                             string AV81Incidenciawwds_2_dynamicfiltersselector1 ,
                                             string AV83Incidenciawwds_4_incidenciaorigen1 ,
                                             short AV82Incidenciawwds_3_dynamicfiltersoperator1 ,
                                             string AV84Incidenciawwds_5_motivonombre1 ,
                                             bool AV85Incidenciawwds_6_dynamicfiltersenabled2 ,
                                             string AV86Incidenciawwds_7_dynamicfiltersselector2 ,
                                             string AV88Incidenciawwds_9_incidenciaorigen2 ,
                                             short AV87Incidenciawwds_8_dynamicfiltersoperator2 ,
                                             string AV89Incidenciawwds_10_motivonombre2 ,
                                             bool AV90Incidenciawwds_11_dynamicfiltersenabled3 ,
                                             string AV91Incidenciawwds_12_dynamicfiltersselector3 ,
                                             string AV93Incidenciawwds_14_incidenciaorigen3 ,
                                             short AV92Incidenciawwds_13_dynamicfiltersoperator3 ,
                                             string AV94Incidenciawwds_15_motivonombre3 ,
                                             long AV95Incidenciawwds_16_tfincidenciaid ,
                                             long AV96Incidenciawwds_17_tfincidenciaid_to ,
                                             int AV97Incidenciawwds_18_tfincidenciaorigen_sels_Count ,
                                             string AV99Incidenciawwds_20_tfincidenciacodref_sel ,
                                             string AV98Incidenciawwds_19_tfincidenciacodref ,
                                             string AV101Incidenciawwds_22_tfmotivonombre_sel ,
                                             string AV100Incidenciawwds_21_tfmotivonombre ,
                                             int AV102Incidenciawwds_23_tfincidenciaestado_sels_Count ,
                                             string AV104Incidenciawwds_25_tfincidenciausralta_sel ,
                                             string AV103Incidenciawwds_24_tfincidenciausralta ,
                                             DateTime AV105Incidenciawwds_26_tfincidenciafechaalta ,
                                             DateTime AV106Incidenciawwds_27_tfincidenciafechaalta_to ,
                                             string AV108Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                             string AV107Incidenciawwds_28_tfincidenciausractualizacion ,
                                             DateTime AV109Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                             DateTime AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                             string A616MotivoNombre ,
                                             long A603IncidenciaId ,
                                             string A606IncidenciaCodRef ,
                                             string A615IncidenciaUsrAlta ,
                                             DateTime A610IncidenciaFechaAlta ,
                                             string A614IncidenciaUsrActualizacion ,
                                             DateTime A609IncidenciaFechaActualizacion ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV80Incidenciawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[23];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.[IncidenciaFechaActualizacion], T1.[IncidenciaUsrActualizacion], T1.[IncidenciaFechaAlta], T1.[IncidenciaUsrAlta], T1.[IncidenciaEstado], T2.[MotivoNombre], T1.[MotivoId], T1.[IncidenciaCodRef], T1.[IncidenciaOrigen], T1.[IncidenciaId] FROM ([Incidencia] T1 INNER JOIN [Motivo] T2 ON T2.[MotivoId] = T1.[MotivoId])";
         if ( ( StringUtil.StrCmp(AV81Incidenciawwds_2_dynamicfiltersselector1, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Incidenciawwds_4_incidenciaorigen1)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV83Incidenciawwds_4_incidenciaorigen1)");
         }
         else
         {
            GXv_int12[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV81Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV82Incidenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV84Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV81Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV82Incidenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV84Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( AV85Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Incidenciawwds_7_dynamicfiltersselector2, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Incidenciawwds_9_incidenciaorigen2)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV88Incidenciawwds_9_incidenciaorigen2)");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( AV85Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV87Incidenciawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV89Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( AV85Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV87Incidenciawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV89Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( AV90Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Incidenciawwds_12_dynamicfiltersselector3, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Incidenciawwds_14_incidenciaorigen3)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV93Incidenciawwds_14_incidenciaorigen3)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( AV90Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV92Incidenciawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV94Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( AV90Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV92Incidenciawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV94Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( ! (0==AV95Incidenciawwds_16_tfincidenciaid) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] >= @AV95Incidenciawwds_16_tfincidenciaid)");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ! (0==AV96Incidenciawwds_17_tfincidenciaid_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] <= @AV96Incidenciawwds_17_tfincidenciaid_to)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( AV97Incidenciawwds_18_tfincidenciaorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV97Incidenciawwds_18_tfincidenciaorigen_sels, "T1.[IncidenciaOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Incidenciawwds_20_tfincidenciacodref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Incidenciawwds_19_tfincidenciacodref)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaCodRef]) like UPPER(@lV98Incidenciawwds_19_tfincidenciacodref))");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Incidenciawwds_20_tfincidenciacodref_sel)) && ! ( StringUtil.StrCmp(AV99Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaCodRef] = @AV99Incidenciawwds_20_tfincidenciacodref_sel)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( StringUtil.StrCmp(AV99Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaCodRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Incidenciawwds_22_tfmotivonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Incidenciawwds_21_tfmotivonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV100Incidenciawwds_21_tfmotivonombre))");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Incidenciawwds_22_tfmotivonombre_sel)) && ! ( StringUtil.StrCmp(AV101Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MotivoNombre] = @AV101Incidenciawwds_22_tfmotivonombre_sel)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( StringUtil.StrCmp(AV101Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MotivoNombre] = ''))");
         }
         if ( AV102Incidenciawwds_23_tfincidenciaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV102Incidenciawwds_23_tfincidenciaestado_sels, "T1.[IncidenciaEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Incidenciawwds_25_tfincidenciausralta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Incidenciawwds_24_tfincidenciausralta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrAlta]) like UPPER(@lV103Incidenciawwds_24_tfincidenciausralta))");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Incidenciawwds_25_tfincidenciausralta_sel)) && ! ( StringUtil.StrCmp(AV104Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrAlta] = @AV104Incidenciawwds_25_tfincidenciausralta_sel)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( StringUtil.StrCmp(AV104Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV105Incidenciawwds_26_tfincidenciafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] >= @AV105Incidenciawwds_26_tfincidenciafechaalta)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Incidenciawwds_27_tfincidenciafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] <= @AV106Incidenciawwds_27_tfincidenciafechaalta_to)");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Incidenciawwds_28_tfincidenciausractualizacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrActualizacion]) like UPPER(@lV107Incidenciawwds_28_tfincidenciausractualizacion))");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ! ( StringUtil.StrCmp(AV108Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrActualizacion] = @AV108Incidenciawwds_29_tfincidenciausractualizacion_sel)");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( StringUtil.StrCmp(AV108Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrActualizacion] = ''))");
         }
         if ( ! (DateTime.MinValue==AV109Incidenciawwds_30_tfincidenciafechaactualizacion) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] >= @AV109Incidenciawwds_30_tfincidenciafechaactualizacion)");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] <= @AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to)");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaOrigen]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaOrigen] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaCodRef]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaCodRef] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MotivoNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MotivoNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaEstado]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrAlta]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrActualizacion]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrActualizacion] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaActualizacion]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaActualizacion] DESC";
         }
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
                     return conditional_H00842(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (string)dynConstraints[39] , (DateTime)dynConstraints[40] , (short)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] );
               case 1 :
                     return conditional_H00843(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (string)dynConstraints[39] , (DateTime)dynConstraints[40] , (short)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] );
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
          Object[] prmH00842;
          prmH00842 = new Object[] {
          new ParDef("@AV83Incidenciawwds_4_incidenciaorigen1",GXType.NChar,3,0) ,
          new ParDef("@lV84Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@lV84Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@AV88Incidenciawwds_9_incidenciaorigen2",GXType.NChar,3,0) ,
          new ParDef("@lV89Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@lV89Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@AV93Incidenciawwds_14_incidenciaorigen3",GXType.NChar,3,0) ,
          new ParDef("@lV94Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@lV94Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@AV95Incidenciawwds_16_tfincidenciaid",GXType.Decimal,18,0) ,
          new ParDef("@AV96Incidenciawwds_17_tfincidenciaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV98Incidenciawwds_19_tfincidenciacodref",GXType.VarChar,40,0) ,
          new ParDef("@AV99Incidenciawwds_20_tfincidenciacodref_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV100Incidenciawwds_21_tfmotivonombre",GXType.Char,80,0) ,
          new ParDef("@AV101Incidenciawwds_22_tfmotivonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV103Incidenciawwds_24_tfincidenciausralta",GXType.Char,20,0) ,
          new ParDef("@AV104Incidenciawwds_25_tfincidenciausralta_sel",GXType.NChar,20,0) ,
          new ParDef("@AV105Incidenciawwds_26_tfincidenciafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV106Incidenciawwds_27_tfincidenciafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV107Incidenciawwds_28_tfincidenciausractualizacion",GXType.Char,20,0) ,
          new ParDef("@AV108Incidenciawwds_29_tfincidenciausractualizacion_sel",GXType.NChar,20,0) ,
          new ParDef("@AV109Incidenciawwds_30_tfincidenciafechaactualizacion",GXType.Date,8,0) ,
          new ParDef("@AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to",GXType.Date,8,0)
          };
          Object[] prmH00843;
          prmH00843 = new Object[] {
          new ParDef("@AV83Incidenciawwds_4_incidenciaorigen1",GXType.NChar,3,0) ,
          new ParDef("@lV84Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@lV84Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@AV88Incidenciawwds_9_incidenciaorigen2",GXType.NChar,3,0) ,
          new ParDef("@lV89Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@lV89Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@AV93Incidenciawwds_14_incidenciaorigen3",GXType.NChar,3,0) ,
          new ParDef("@lV94Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@lV94Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@AV95Incidenciawwds_16_tfincidenciaid",GXType.Decimal,18,0) ,
          new ParDef("@AV96Incidenciawwds_17_tfincidenciaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV98Incidenciawwds_19_tfincidenciacodref",GXType.VarChar,40,0) ,
          new ParDef("@AV99Incidenciawwds_20_tfincidenciacodref_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV100Incidenciawwds_21_tfmotivonombre",GXType.Char,80,0) ,
          new ParDef("@AV101Incidenciawwds_22_tfmotivonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV103Incidenciawwds_24_tfincidenciausralta",GXType.Char,20,0) ,
          new ParDef("@AV104Incidenciawwds_25_tfincidenciausralta_sel",GXType.NChar,20,0) ,
          new ParDef("@AV105Incidenciawwds_26_tfincidenciafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV106Incidenciawwds_27_tfincidenciafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV107Incidenciawwds_28_tfincidenciausractualizacion",GXType.Char,20,0) ,
          new ParDef("@AV108Incidenciawwds_29_tfincidenciausractualizacion_sel",GXType.NChar,20,0) ,
          new ParDef("@AV109Incidenciawwds_30_tfincidenciafechaactualizacion",GXType.Date,8,0) ,
          new ParDef("@AV110Incidenciawwds_31_tfincidenciafechaactualizacion_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00842", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00842,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00843", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00843,11, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
       }
    }

 }

}
