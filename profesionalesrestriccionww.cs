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
   public class profesionalesrestriccionww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public profesionalesrestriccionww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionalesrestriccionww( IGxContext context )
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
         cmbListaEstado = new GXCombobox();
         cmbListaTipo = new GXCombobox();
         cmbRestriccionesEstado = new GXCombobox();
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
         AV22ListaNombre1 = GetPar( "ListaNombre1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV28ListaNombre2 = GetPar( "ListaNombre2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV30DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV34ListaNombre3 = GetPar( "ListaNombre3");
         AV20RestriccionesFechaAlta1 = context.localUtil.ParseDTimeParm( GetPar( "RestriccionesFechaAlta1"));
         AV26RestriccionesFechaAlta2 = context.localUtil.ParseDTimeParm( GetPar( "RestriccionesFechaAlta2"));
         AV32RestriccionesFechaAlta3 = context.localUtil.ParseDTimeParm( GetPar( "RestriccionesFechaAlta3"));
         AV46ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV23DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV29DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41ColumnsSelector);
         AV88Pgmname = GetPar( "Pgmname");
         AV17FilterFullText = GetPar( "FilterFullText");
         AV21RestriccionesFechaAlta_To1 = context.localUtil.ParseDTimeParm( GetPar( "RestriccionesFechaAlta_To1"));
         AV27RestriccionesFechaAlta_To2 = context.localUtil.ParseDTimeParm( GetPar( "RestriccionesFechaAlta_To2"));
         AV33RestriccionesFechaAlta_To3 = context.localUtil.ParseDTimeParm( GetPar( "RestriccionesFechaAlta_To3"));
         AV47TFProfesionalesRestriccionId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfesionalesRestriccionId"), "."), 18, MidpointRounding.ToEven));
         AV48TFProfesionalesRestriccionId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfesionalesRestriccionId_To"), "."), 18, MidpointRounding.ToEven));
         AV49TFProfesionalesId = GetPar( "TFProfesionalesId");
         AV50TFProfesionalesId_Sel = GetPar( "TFProfesionalesId_Sel");
         AV51TFProfesionalesPrimerNombre = GetPar( "TFProfesionalesPrimerNombre");
         AV52TFProfesionalesPrimerNombre_Sel = GetPar( "TFProfesionalesPrimerNombre_Sel");
         AV53TFProfesionalesApellidoPrimero = GetPar( "TFProfesionalesApellidoPrimero");
         AV54TFProfesionalesApellidoPrimero_Sel = GetPar( "TFProfesionalesApellidoPrimero_Sel");
         AV55TFListaid = (long)(Math.Round(NumberUtil.Val( GetPar( "TFListaid"), "."), 18, MidpointRounding.ToEven));
         AV56TFListaid_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFListaid_To"), "."), 18, MidpointRounding.ToEven));
         AV57TFListaNombre = GetPar( "TFListaNombre");
         AV58TFListaNombre_Sel = GetPar( "TFListaNombre_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV60TFListaEstado_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV62TFListaTipo_Sels);
         AV63TFRestriccionesFechaAlta = context.localUtil.ParseDTimeParm( GetPar( "TFRestriccionesFechaAlta"));
         AV64TFRestriccionesFechaAlta_To = context.localUtil.ParseDTimeParm( GetPar( "TFRestriccionesFechaAlta_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV69TFRestriccionesEstado_Sels);
         AV70TFRestriccionesObservacion = GetPar( "TFRestriccionesObservacion");
         AV71TFRestriccionesObservacion_Sel = GetPar( "TFRestriccionesObservacion_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV36DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV35DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV79IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV80IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV81IsAuthorized_ListaNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_ListaNombre"));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
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
         PAKW2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTKW2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profesionalesrestriccionww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV88Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV88Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV79IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV79IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV80IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV80IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_LISTANOMBRE", AV81IsAuthorized_ListaNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_LISTANOMBRE", GetSecureSignedToken( "", AV81IsAuthorized_ListaNombre, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vLISTANOMBRE1", StringUtil.RTrim( AV22ListaNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV24DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vLISTANOMBRE2", StringUtil.RTrim( AV28ListaNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV30DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vLISTANOMBRE3", StringUtil.RTrim( AV34ListaNombre3));
         GxWebStd.gx_hidden_field( context, "GXH_vRESTRICCIONESFECHAALTA1", context.localUtil.TToC( AV20RestriccionesFechaAlta1, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vRESTRICCIONESFECHAALTA2", context.localUtil.TToC( AV26RestriccionesFechaAlta2, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vRESTRICCIONESFECHAALTA3", context.localUtil.TToC( AV32RestriccionesFechaAlta3, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_129", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_129), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV44ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV44ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV74GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV75GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV76GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV82AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV82AGExportData);
         }
         GxWebStd.gx_hidden_field( context, "vRESTRICCIONESFECHAALTA_TO1", context.localUtil.TToC( AV21RestriccionesFechaAlta_To1, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vRESTRICCIONESFECHAALTA_TO2", context.localUtil.TToC( AV27RestriccionesFechaAlta_To2, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vRESTRICCIONESFECHAALTA_TO3", context.localUtil.TToC( AV33RestriccionesFechaAlta_To3, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV72DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV72DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV41ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV41ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_RESTRICCIONESFECHAALTAAUXDATETO", context.localUtil.DToC( AV66DDO_RestriccionesFechaAltaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV23DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV29DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV88Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV88Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESRESTRICCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFProfesionalesRestriccionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESRESTRICCIONID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFProfesionalesRestriccionId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESID", StringUtil.RTrim( AV49TFProfesionalesId));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESID_SEL", StringUtil.RTrim( AV50TFProfesionalesId_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESPRIMERNOMBRE", StringUtil.RTrim( AV51TFProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESPRIMERNOMBRE_SEL", StringUtil.RTrim( AV52TFProfesionalesPrimerNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOPRIMERO", StringUtil.RTrim( AV53TFProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOPRIMERO_SEL", StringUtil.RTrim( AV54TFProfesionalesApellidoPrimero_Sel));
         GxWebStd.gx_hidden_field( context, "vTFLISTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55TFListaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFLISTAID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56TFListaid_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFLISTANOMBRE", StringUtil.RTrim( AV57TFListaNombre));
         GxWebStd.gx_hidden_field( context, "vTFLISTANOMBRE_SEL", StringUtil.RTrim( AV58TFListaNombre_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFLISTAESTADO_SELS", AV60TFListaEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFLISTAESTADO_SELS", AV60TFListaEstado_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFLISTATIPO_SELS", AV62TFListaTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFLISTATIPO_SELS", AV62TFListaTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFRESTRICCIONESFECHAALTA", context.localUtil.TToC( AV63TFRestriccionesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFRESTRICCIONESFECHAALTA_TO", context.localUtil.TToC( AV64TFRestriccionesFechaAlta_To, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFRESTRICCIONESESTADO_SELS", AV69TFRestriccionesEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFRESTRICCIONESESTADO_SELS", AV69TFRestriccionesEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFRESTRICCIONESOBSERVACION", AV70TFRestriccionesObservacion);
         GxWebStd.gx_hidden_field( context, "vTFRESTRICCIONESOBSERVACION_SEL", AV71TFRestriccionesObservacion_Sel);
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV36DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV35DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV79IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV79IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV80IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV80IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_LISTANOMBRE", AV81IsAuthorized_ListaNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_LISTANOMBRE", GetSecureSignedToken( "", AV81IsAuthorized_ListaNombre, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vTFLISTAESTADO_SELSJSON", AV59TFListaEstado_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFLISTATIPO_SELSJSON", AV61TFListaTipo_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFRESTRICCIONESESTADO_SELSJSON", AV68TFRestriccionesEstado_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vRESTRICCIONESFECHAALTA1", context.localUtil.TToC( AV20RestriccionesFechaAlta1, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vRESTRICCIONESFECHAALTA2", context.localUtil.TToC( AV26RestriccionesFechaAlta2, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vRESTRICCIONESFECHAALTA3", context.localUtil.TToC( AV32RestriccionesFechaAlta3, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vDDO_RESTRICCIONESFECHAALTAAUXDATE", context.localUtil.DToC( AV65DDO_RestriccionesFechaAltaAuxDate, 0, "/"));
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
            WEKW2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTKW2( ) ;
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
         return formatLink("profesionalesrestriccionww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ProfesionalesRestriccionWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Lista Profesionales Restriccion", "") ;
      }

      protected void WBKW0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_KW2( true) ;
         }
         else
         {
            wb_table1_25_KW2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_KW2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_ProfesionalesRestriccionWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_KW2( true) ;
         }
         else
         {
            wb_table2_49_KW2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_KW2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_ProfesionalesRestriccionWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_77_KW2( true) ;
         }
         else
         {
            wb_table3_77_KW2( false) ;
         }
         return  ;
      }

      protected void wb_table3_77_KW2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV30DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 0, "HLP_ProfesionalesRestriccionWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_105_KW2( true) ;
         }
         else
         {
            wb_table4_105_KW2( false) ;
         }
         return  ;
      }

      protected void wb_table4_105_KW2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV74GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV75GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV76GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV82AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* User Defined Control */
            ucRestriccionesfechaalta_rangepicker1.SetProperty("Start Date", AV20RestriccionesFechaAlta1);
            ucRestriccionesfechaalta_rangepicker1.SetProperty("End Date", AV21RestriccionesFechaAlta_To1);
            ucRestriccionesfechaalta_rangepicker1.Render(context, "wwp.daterangepicker", Restriccionesfechaalta_rangepicker1_Internalname, "RESTRICCIONESFECHAALTA_RANGEPICKER1Container");
            /* User Defined Control */
            ucRestriccionesfechaalta_rangepicker2.SetProperty("Start Date", AV26RestriccionesFechaAlta2);
            ucRestriccionesfechaalta_rangepicker2.SetProperty("End Date", AV27RestriccionesFechaAlta_To2);
            ucRestriccionesfechaalta_rangepicker2.Render(context, "wwp.daterangepicker", Restriccionesfechaalta_rangepicker2_Internalname, "RESTRICCIONESFECHAALTA_RANGEPICKER2Container");
            /* User Defined Control */
            ucRestriccionesfechaalta_rangepicker3.SetProperty("Start Date", AV32RestriccionesFechaAlta3);
            ucRestriccionesfechaalta_rangepicker3.SetProperty("End Date", AV33RestriccionesFechaAlta_To3);
            ucRestriccionesfechaalta_rangepicker3.Render(context, "wwp.daterangepicker", Restriccionesfechaalta_rangepicker3_Internalname, "RESTRICCIONESFECHAALTA_RANGEPICKER3Container");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ProfesionalesRestriccionWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV72DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV72DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV41ColumnsSelector);
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
               GxWebStd.gx_hidden_field( context, "W0159"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0159"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_129_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0159"+"");
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
            GxWebStd.gx_div_start( context, divDdo_restriccionesfechaaltaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_restriccionesfechaaltaauxdatetext_Internalname, AV67DDO_RestriccionesFechaAltaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV67DDO_RestriccionesFechaAltaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_restriccionesfechaaltaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccionWW.htm");
            /* User Defined Control */
            ucTfrestriccionesfechaalta_rangepicker.SetProperty("Start Date", AV65DDO_RestriccionesFechaAltaAuxDate);
            ucTfrestriccionesfechaalta_rangepicker.SetProperty("End Date", AV66DDO_RestriccionesFechaAltaAuxDateTo);
            ucTfrestriccionesfechaalta_rangepicker.Render(context, "wwp.daterangepicker", Tfrestriccionesfechaalta_rangepicker_Internalname, "TFRESTRICCIONESFECHAALTA_RANGEPICKERContainer");
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

      protected void STARTKW2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Lista Profesionales Restriccion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPKW0( ) ;
      }

      protected void WSKW2( )
      {
         STARTKW2( ) ;
         EVTKW2( ) ;
      }

      protected void EVTKW2( )
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
                              E11KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E14KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E15KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "RESTRICCIONESFECHAALTA_RANGEPICKER1.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Restriccionesfechaalta_rangepicker1.Daterangechanged */
                              E16KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "RESTRICCIONESFECHAALTA_RANGEPICKER2.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Restriccionesfechaalta_rangepicker2.Daterangechanged */
                              E17KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "RESTRICCIONESFECHAALTA_RANGEPICKER3.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Restriccionesfechaalta_rangepicker3.Daterangechanged */
                              E18KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E19KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E20KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E21KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E22KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E23KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E24KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E25KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E26KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E27KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E28KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E29KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E30KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E31KW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E32KW2 ();
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
                              nGXsfl_129_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
                              SubsflControlProps_1292( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV77GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV77GridActions), 4, 0));
                              A976ProfesionalesRestriccionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesRestriccionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
                              A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
                              A590Listaid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A592ListaNombre = cgiGet( edtListaNombre_Internalname);
                              cmbListaEstado.Name = cmbListaEstado_Internalname;
                              cmbListaEstado.CurrentValue = cgiGet( cmbListaEstado_Internalname);
                              A593ListaEstado = cgiGet( cmbListaEstado_Internalname);
                              n593ListaEstado = false;
                              cmbListaTipo.Name = cmbListaTipo_Internalname;
                              cmbListaTipo.CurrentValue = cgiGet( cmbListaTipo_Internalname);
                              A591ListaTipo = cgiGet( cmbListaTipo_Internalname);
                              A973RestriccionesFechaAlta = context.localUtil.CToT( cgiGet( edtRestriccionesFechaAlta_Internalname), 0);
                              n973RestriccionesFechaAlta = false;
                              cmbRestriccionesEstado.Name = cmbRestriccionesEstado_Internalname;
                              cmbRestriccionesEstado.CurrentValue = cgiGet( cmbRestriccionesEstado_Internalname);
                              A974RestriccionesEstado = cgiGet( cmbRestriccionesEstado_Internalname);
                              n974RestriccionesEstado = false;
                              A975RestriccionesObservacion = cgiGet( edtRestriccionesObservacion_Internalname);
                              n975RestriccionesObservacion = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E33KW2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E34KW2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E35KW2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E36KW2 ();
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
                                       /* Set Refresh If Listanombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vLISTANOMBRE1"), AV22ListaNombre1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV24DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV25DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Listanombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vLISTANOMBRE2"), AV28ListaNombre2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV30DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV31DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Listanombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vLISTANOMBRE3"), AV34ListaNombre3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Restriccionesfechaalta1 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vRESTRICCIONESFECHAALTA1"), 0) != AV20RestriccionesFechaAlta1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Restriccionesfechaalta2 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vRESTRICCIONESFECHAALTA2"), 0) != AV26RestriccionesFechaAlta2 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Restriccionesfechaalta3 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vRESTRICCIONESFECHAALTA3"), 0) != AV32RestriccionesFechaAlta3 )
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
                        if ( nCmpId == 159 )
                        {
                           OldWwpaux_wc = cgiGet( "W0159");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0159", "", sEvt);
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

      protected void WEKW2( )
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

      protected void PAKW2( )
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
                                       string AV22ListaNombre1 ,
                                       string AV24DynamicFiltersSelector2 ,
                                       short AV25DynamicFiltersOperator2 ,
                                       string AV28ListaNombre2 ,
                                       string AV30DynamicFiltersSelector3 ,
                                       short AV31DynamicFiltersOperator3 ,
                                       string AV34ListaNombre3 ,
                                       DateTime AV20RestriccionesFechaAlta1 ,
                                       DateTime AV26RestriccionesFechaAlta2 ,
                                       DateTime AV32RestriccionesFechaAlta3 ,
                                       short AV46ManageFiltersExecutionStep ,
                                       bool AV23DynamicFiltersEnabled2 ,
                                       bool AV29DynamicFiltersEnabled3 ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV41ColumnsSelector ,
                                       string AV88Pgmname ,
                                       string AV17FilterFullText ,
                                       DateTime AV21RestriccionesFechaAlta_To1 ,
                                       DateTime AV27RestriccionesFechaAlta_To2 ,
                                       DateTime AV33RestriccionesFechaAlta_To3 ,
                                       long AV47TFProfesionalesRestriccionId ,
                                       long AV48TFProfesionalesRestriccionId_To ,
                                       string AV49TFProfesionalesId ,
                                       string AV50TFProfesionalesId_Sel ,
                                       string AV51TFProfesionalesPrimerNombre ,
                                       string AV52TFProfesionalesPrimerNombre_Sel ,
                                       string AV53TFProfesionalesApellidoPrimero ,
                                       string AV54TFProfesionalesApellidoPrimero_Sel ,
                                       long AV55TFListaid ,
                                       long AV56TFListaid_To ,
                                       string AV57TFListaNombre ,
                                       string AV58TFListaNombre_Sel ,
                                       GxSimpleCollection<string> AV60TFListaEstado_Sels ,
                                       GxSimpleCollection<string> AV62TFListaTipo_Sels ,
                                       DateTime AV63TFRestriccionesFechaAlta ,
                                       DateTime AV64TFRestriccionesFechaAlta_To ,
                                       GxSimpleCollection<string> AV69TFRestriccionesEstado_Sels ,
                                       string AV70TFRestriccionesObservacion ,
                                       string AV71TFRestriccionesObservacion_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV36DynamicFiltersIgnoreFirst ,
                                       bool AV35DynamicFiltersRemoving ,
                                       bool AV79IsAuthorized_Update ,
                                       bool AV80IsAuthorized_Delete ,
                                       bool AV81IsAuthorized_ListaNombre ,
                                       DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFKW2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESRESTRICCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A976ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESRESTRICCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A976ProfesionalesRestriccionId), 18, 0, ".", "")));
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
            AV24DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV24DynamicFiltersSelector2);
            AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV30DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV30DynamicFiltersSelector3);
            AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFKW2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV88Pgmname = "ProfesionalesRestriccionWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV89Profesionalesrestriccionwwds_1_filterfulltext = AV17FilterFullText;
         AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV20RestriccionesFechaAlta1;
         AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV21RestriccionesFechaAlta_To1;
         AV94Profesionalesrestriccionwwds_6_listanombre1 = AV22ListaNombre1;
         AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV26RestriccionesFechaAlta2;
         AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV27RestriccionesFechaAlta_To2;
         AV100Profesionalesrestriccionwwds_12_listanombre2 = AV28ListaNombre2;
         AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV32RestriccionesFechaAlta3;
         AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV33RestriccionesFechaAlta_To3;
         AV106Profesionalesrestriccionwwds_18_listanombre3 = AV34ListaNombre3;
         AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV47TFProfesionalesRestriccionId;
         AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV48TFProfesionalesRestriccionId_To;
         AV109Profesionalesrestriccionwwds_21_tfprofesionalesid = AV49TFProfesionalesId;
         AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV50TFProfesionalesId_Sel;
         AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV51TFProfesionalesPrimerNombre;
         AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV52TFProfesionalesPrimerNombre_Sel;
         AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV53TFProfesionalesApellidoPrimero;
         AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV54TFProfesionalesApellidoPrimero_Sel;
         AV115Profesionalesrestriccionwwds_27_tflistaid = AV55TFListaid;
         AV116Profesionalesrestriccionwwds_28_tflistaid_to = AV56TFListaid_To;
         AV117Profesionalesrestriccionwwds_29_tflistanombre = AV57TFListaNombre;
         AV118Profesionalesrestriccionwwds_30_tflistanombre_sel = AV58TFListaNombre_Sel;
         AV119Profesionalesrestriccionwwds_31_tflistaestado_sels = AV60TFListaEstado_Sels;
         AV120Profesionalesrestriccionwwds_32_tflistatipo_sels = AV62TFListaTipo_Sels;
         AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV63TFRestriccionesFechaAlta;
         AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV64TFRestriccionesFechaAlta_To;
         AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV69TFRestriccionesEstado_Sels;
         AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV70TFRestriccionesObservacion;
         AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV71TFRestriccionesObservacion_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A593ListaEstado ,
                                              AV119Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                              A591ListaTipo ,
                                              AV120Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                              A974RestriccionesEstado ,
                                              AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                              AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                              AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                              AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                              AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                              AV94Profesionalesrestriccionwwds_6_listanombre1 ,
                                              AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                              AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                              AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                              AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                              AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                              AV100Profesionalesrestriccionwwds_12_listanombre2 ,
                                              AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                              AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                              AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                              AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                              AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                              AV106Profesionalesrestriccionwwds_18_listanombre3 ,
                                              AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                              AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                              AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                              AV109Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                              AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                              AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                              AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                              AV115Profesionalesrestriccionwwds_27_tflistaid ,
                                              AV116Profesionalesrestriccionwwds_28_tflistaid_to ,
                                              AV118Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                              AV117Profesionalesrestriccionwwds_29_tflistanombre ,
                                              AV119Profesionalesrestriccionwwds_31_tflistaestado_sels.Count ,
                                              AV120Profesionalesrestriccionwwds_32_tflistatipo_sels.Count ,
                                              AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                              AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                              AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels.Count ,
                                              AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                              AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                              A973RestriccionesFechaAlta ,
                                              A592ListaNombre ,
                                              A976ProfesionalesRestriccionId ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A590Listaid ,
                                              A975RestriccionesObservacion ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV89Profesionalesrestriccionwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV94Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV94Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV94Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV94Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV100Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV100Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV100Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV100Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV106Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV106Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV106Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV106Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV109Profesionalesrestriccionwwds_21_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV109Profesionalesrestriccionwwds_21_tfprofesionalesid), 20, "%");
         lV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre), 30, "%");
         lV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV117Profesionalesrestriccionwwds_29_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV117Profesionalesrestriccionwwds_29_tflistanombre), 80, "%");
         lV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = StringUtil.Concat( StringUtil.RTrim( AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion), "%", "");
         /* Using cursor H00KW2 */
         pr_default.execute(0, new Object[] {AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, lV94Profesionalesrestriccionwwds_6_listanombre1, lV94Profesionalesrestriccionwwds_6_listanombre1, AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, lV100Profesionalesrestriccionwwds_12_listanombre2, lV100Profesionalesrestriccionwwds_12_listanombre2, AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, lV106Profesionalesrestriccionwwds_18_listanombre3, lV106Profesionalesrestriccionwwds_18_listanombre3, AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid, AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to, lV109Profesionalesrestriccionwwds_21_tfprofesionalesid, AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, lV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre, AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, lV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero, AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, AV115Profesionalesrestriccionwwds_27_tflistaid, AV116Profesionalesrestriccionwwds_28_tflistaid_to, lV117Profesionalesrestriccionwwds_29_tflistanombre, AV118Profesionalesrestriccionwwds_30_tflistanombre_sel, AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta, AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to, lV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion, AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A975RestriccionesObservacion = H00KW2_A975RestriccionesObservacion[0];
            n975RestriccionesObservacion = H00KW2_n975RestriccionesObservacion[0];
            A974RestriccionesEstado = H00KW2_A974RestriccionesEstado[0];
            n974RestriccionesEstado = H00KW2_n974RestriccionesEstado[0];
            A973RestriccionesFechaAlta = H00KW2_A973RestriccionesFechaAlta[0];
            n973RestriccionesFechaAlta = H00KW2_n973RestriccionesFechaAlta[0];
            A591ListaTipo = H00KW2_A591ListaTipo[0];
            A593ListaEstado = H00KW2_A593ListaEstado[0];
            n593ListaEstado = H00KW2_n593ListaEstado[0];
            A592ListaNombre = H00KW2_A592ListaNombre[0];
            A590Listaid = H00KW2_A590Listaid[0];
            A167ProfesionalesApellidoPrimero = H00KW2_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = H00KW2_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = H00KW2_A120ProfesionalesId[0];
            A976ProfesionalesRestriccionId = H00KW2_A976ProfesionalesRestriccionId[0];
            A591ListaTipo = H00KW2_A591ListaTipo[0];
            A593ListaEstado = H00KW2_A593ListaEstado[0];
            n593ListaEstado = H00KW2_n593ListaEstado[0];
            A592ListaNombre = H00KW2_A592ListaNombre[0];
            A167ProfesionalesApellidoPrimero = H00KW2_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = H00KW2_A166ProfesionalesPrimerNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Profesionalesrestriccionwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A976ProfesionalesRestriccionId), 18, 0) , StringUtil.PadR( "%" + AV89Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV89Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "restriccion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "RST") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A975RestriccionesObservacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
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

      protected void RFKW2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 129;
         /* Execute user event: Refresh */
         E34KW2 ();
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
                                                 A593ListaEstado ,
                                                 AV119Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                                 A591ListaTipo ,
                                                 AV120Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                                 A974RestriccionesEstado ,
                                                 AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                                 AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                                 AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                                 AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                                 AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                                 AV94Profesionalesrestriccionwwds_6_listanombre1 ,
                                                 AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                                 AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                                 AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                                 AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                                 AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                                 AV100Profesionalesrestriccionwwds_12_listanombre2 ,
                                                 AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                                 AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                                 AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                                 AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                                 AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                                 AV106Profesionalesrestriccionwwds_18_listanombre3 ,
                                                 AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                                 AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                                 AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                                 AV109Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                                 AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                                 AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                                 AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                                 AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                                 AV115Profesionalesrestriccionwwds_27_tflistaid ,
                                                 AV116Profesionalesrestriccionwwds_28_tflistaid_to ,
                                                 AV118Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                                 AV117Profesionalesrestriccionwwds_29_tflistanombre ,
                                                 AV119Profesionalesrestriccionwwds_31_tflistaestado_sels.Count ,
                                                 AV120Profesionalesrestriccionwwds_32_tflistatipo_sels.Count ,
                                                 AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                                 AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                                 AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels.Count ,
                                                 AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                                 AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                                 A973RestriccionesFechaAlta ,
                                                 A592ListaNombre ,
                                                 A976ProfesionalesRestriccionId ,
                                                 A120ProfesionalesId ,
                                                 A166ProfesionalesPrimerNombre ,
                                                 A167ProfesionalesApellidoPrimero ,
                                                 A590Listaid ,
                                                 A975RestriccionesObservacion ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV89Profesionalesrestriccionwwds_1_filterfulltext } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV94Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV94Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
            lV94Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV94Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
            lV100Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV100Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
            lV100Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV100Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
            lV106Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV106Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
            lV106Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV106Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
            lV109Profesionalesrestriccionwwds_21_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV109Profesionalesrestriccionwwds_21_tfprofesionalesid), 20, "%");
            lV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre), 30, "%");
            lV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero), 30, "%");
            lV117Profesionalesrestriccionwwds_29_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV117Profesionalesrestriccionwwds_29_tflistanombre), 80, "%");
            lV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = StringUtil.Concat( StringUtil.RTrim( AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion), "%", "");
            /* Using cursor H00KW3 */
            pr_default.execute(1, new Object[] {AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, lV94Profesionalesrestriccionwwds_6_listanombre1, lV94Profesionalesrestriccionwwds_6_listanombre1, AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, lV100Profesionalesrestriccionwwds_12_listanombre2, lV100Profesionalesrestriccionwwds_12_listanombre2, AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, lV106Profesionalesrestriccionwwds_18_listanombre3, lV106Profesionalesrestriccionwwds_18_listanombre3, AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid, AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to, lV109Profesionalesrestriccionwwds_21_tfprofesionalesid, AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, lV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre, AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, lV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero, AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, AV115Profesionalesrestriccionwwds_27_tflistaid, AV116Profesionalesrestriccionwwds_28_tflistaid_to, lV117Profesionalesrestriccionwwds_29_tflistanombre, AV118Profesionalesrestriccionwwds_30_tflistanombre_sel, AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta, AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to, lV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion, AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel});
            nGXsfl_129_idx = 1;
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
            SubsflControlProps_1292( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A975RestriccionesObservacion = H00KW3_A975RestriccionesObservacion[0];
               n975RestriccionesObservacion = H00KW3_n975RestriccionesObservacion[0];
               A974RestriccionesEstado = H00KW3_A974RestriccionesEstado[0];
               n974RestriccionesEstado = H00KW3_n974RestriccionesEstado[0];
               A973RestriccionesFechaAlta = H00KW3_A973RestriccionesFechaAlta[0];
               n973RestriccionesFechaAlta = H00KW3_n973RestriccionesFechaAlta[0];
               A591ListaTipo = H00KW3_A591ListaTipo[0];
               A593ListaEstado = H00KW3_A593ListaEstado[0];
               n593ListaEstado = H00KW3_n593ListaEstado[0];
               A592ListaNombre = H00KW3_A592ListaNombre[0];
               A590Listaid = H00KW3_A590Listaid[0];
               A167ProfesionalesApellidoPrimero = H00KW3_A167ProfesionalesApellidoPrimero[0];
               A166ProfesionalesPrimerNombre = H00KW3_A166ProfesionalesPrimerNombre[0];
               A120ProfesionalesId = H00KW3_A120ProfesionalesId[0];
               A976ProfesionalesRestriccionId = H00KW3_A976ProfesionalesRestriccionId[0];
               A591ListaTipo = H00KW3_A591ListaTipo[0];
               A593ListaEstado = H00KW3_A593ListaEstado[0];
               n593ListaEstado = H00KW3_n593ListaEstado[0];
               A592ListaNombre = H00KW3_A592ListaNombre[0];
               A167ProfesionalesApellidoPrimero = H00KW3_A167ProfesionalesApellidoPrimero[0];
               A166ProfesionalesPrimerNombre = H00KW3_A166ProfesionalesPrimerNombre[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Profesionalesrestriccionwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A976ProfesionalesRestriccionId), 18, 0) , StringUtil.PadR( "%" + AV89Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV89Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") ==
               0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "restriccion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "RST") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "HAB") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "DES") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A975RestriccionesObservacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E35KW2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 129;
            WBKW0( ) ;
         }
         bGXsfl_129_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesKW2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV88Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV88Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV79IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV79IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV80IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV80IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_LISTANOMBRE", AV81IsAuthorized_ListaNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_LISTANOMBRE", GetSecureSignedToken( "", AV81IsAuthorized_ListaNombre, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESRESTRICCIONID"+"_"+sGXsfl_129_idx, GetSecureSignedToken( sGXsfl_129_idx, context.localUtil.Format( (decimal)(A976ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         AV89Profesionalesrestriccionwwds_1_filterfulltext = AV17FilterFullText;
         AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV20RestriccionesFechaAlta1;
         AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV21RestriccionesFechaAlta_To1;
         AV94Profesionalesrestriccionwwds_6_listanombre1 = AV22ListaNombre1;
         AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV26RestriccionesFechaAlta2;
         AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV27RestriccionesFechaAlta_To2;
         AV100Profesionalesrestriccionwwds_12_listanombre2 = AV28ListaNombre2;
         AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV32RestriccionesFechaAlta3;
         AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV33RestriccionesFechaAlta_To3;
         AV106Profesionalesrestriccionwwds_18_listanombre3 = AV34ListaNombre3;
         AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV47TFProfesionalesRestriccionId;
         AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV48TFProfesionalesRestriccionId_To;
         AV109Profesionalesrestriccionwwds_21_tfprofesionalesid = AV49TFProfesionalesId;
         AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV50TFProfesionalesId_Sel;
         AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV51TFProfesionalesPrimerNombre;
         AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV52TFProfesionalesPrimerNombre_Sel;
         AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV53TFProfesionalesApellidoPrimero;
         AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV54TFProfesionalesApellidoPrimero_Sel;
         AV115Profesionalesrestriccionwwds_27_tflistaid = AV55TFListaid;
         AV116Profesionalesrestriccionwwds_28_tflistaid_to = AV56TFListaid_To;
         AV117Profesionalesrestriccionwwds_29_tflistanombre = AV57TFListaNombre;
         AV118Profesionalesrestriccionwwds_30_tflistanombre_sel = AV58TFListaNombre_Sel;
         AV119Profesionalesrestriccionwwds_31_tflistaestado_sels = AV60TFListaEstado_Sels;
         AV120Profesionalesrestriccionwwds_32_tflistatipo_sels = AV62TFListaTipo_Sels;
         AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV63TFRestriccionesFechaAlta;
         AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV64TFRestriccionesFechaAlta_To;
         AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV69TFRestriccionesEstado_Sels;
         AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV70TFRestriccionesObservacion;
         AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV71TFRestriccionesObservacion_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV89Profesionalesrestriccionwwds_1_filterfulltext = AV17FilterFullText;
         AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV20RestriccionesFechaAlta1;
         AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV21RestriccionesFechaAlta_To1;
         AV94Profesionalesrestriccionwwds_6_listanombre1 = AV22ListaNombre1;
         AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV26RestriccionesFechaAlta2;
         AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV27RestriccionesFechaAlta_To2;
         AV100Profesionalesrestriccionwwds_12_listanombre2 = AV28ListaNombre2;
         AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV32RestriccionesFechaAlta3;
         AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV33RestriccionesFechaAlta_To3;
         AV106Profesionalesrestriccionwwds_18_listanombre3 = AV34ListaNombre3;
         AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV47TFProfesionalesRestriccionId;
         AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV48TFProfesionalesRestriccionId_To;
         AV109Profesionalesrestriccionwwds_21_tfprofesionalesid = AV49TFProfesionalesId;
         AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV50TFProfesionalesId_Sel;
         AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV51TFProfesionalesPrimerNombre;
         AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV52TFProfesionalesPrimerNombre_Sel;
         AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV53TFProfesionalesApellidoPrimero;
         AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV54TFProfesionalesApellidoPrimero_Sel;
         AV115Profesionalesrestriccionwwds_27_tflistaid = AV55TFListaid;
         AV116Profesionalesrestriccionwwds_28_tflistaid_to = AV56TFListaid_To;
         AV117Profesionalesrestriccionwwds_29_tflistanombre = AV57TFListaNombre;
         AV118Profesionalesrestriccionwwds_30_tflistanombre_sel = AV58TFListaNombre_Sel;
         AV119Profesionalesrestriccionwwds_31_tflistaestado_sels = AV60TFListaEstado_Sels;
         AV120Profesionalesrestriccionwwds_32_tflistatipo_sels = AV62TFListaTipo_Sels;
         AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV63TFRestriccionesFechaAlta;
         AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV64TFRestriccionesFechaAlta_To;
         AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV69TFRestriccionesEstado_Sels;
         AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV70TFRestriccionesObservacion;
         AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV71TFRestriccionesObservacion_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV89Profesionalesrestriccionwwds_1_filterfulltext = AV17FilterFullText;
         AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV20RestriccionesFechaAlta1;
         AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV21RestriccionesFechaAlta_To1;
         AV94Profesionalesrestriccionwwds_6_listanombre1 = AV22ListaNombre1;
         AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV26RestriccionesFechaAlta2;
         AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV27RestriccionesFechaAlta_To2;
         AV100Profesionalesrestriccionwwds_12_listanombre2 = AV28ListaNombre2;
         AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV32RestriccionesFechaAlta3;
         AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV33RestriccionesFechaAlta_To3;
         AV106Profesionalesrestriccionwwds_18_listanombre3 = AV34ListaNombre3;
         AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV47TFProfesionalesRestriccionId;
         AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV48TFProfesionalesRestriccionId_To;
         AV109Profesionalesrestriccionwwds_21_tfprofesionalesid = AV49TFProfesionalesId;
         AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV50TFProfesionalesId_Sel;
         AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV51TFProfesionalesPrimerNombre;
         AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV52TFProfesionalesPrimerNombre_Sel;
         AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV53TFProfesionalesApellidoPrimero;
         AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV54TFProfesionalesApellidoPrimero_Sel;
         AV115Profesionalesrestriccionwwds_27_tflistaid = AV55TFListaid;
         AV116Profesionalesrestriccionwwds_28_tflistaid_to = AV56TFListaid_To;
         AV117Profesionalesrestriccionwwds_29_tflistanombre = AV57TFListaNombre;
         AV118Profesionalesrestriccionwwds_30_tflistanombre_sel = AV58TFListaNombre_Sel;
         AV119Profesionalesrestriccionwwds_31_tflistaestado_sels = AV60TFListaEstado_Sels;
         AV120Profesionalesrestriccionwwds_32_tflistatipo_sels = AV62TFListaTipo_Sels;
         AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV63TFRestriccionesFechaAlta;
         AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV64TFRestriccionesFechaAlta_To;
         AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV69TFRestriccionesEstado_Sels;
         AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV70TFRestriccionesObservacion;
         AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV71TFRestriccionesObservacion_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV89Profesionalesrestriccionwwds_1_filterfulltext = AV17FilterFullText;
         AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV20RestriccionesFechaAlta1;
         AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV21RestriccionesFechaAlta_To1;
         AV94Profesionalesrestriccionwwds_6_listanombre1 = AV22ListaNombre1;
         AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV26RestriccionesFechaAlta2;
         AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV27RestriccionesFechaAlta_To2;
         AV100Profesionalesrestriccionwwds_12_listanombre2 = AV28ListaNombre2;
         AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV32RestriccionesFechaAlta3;
         AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV33RestriccionesFechaAlta_To3;
         AV106Profesionalesrestriccionwwds_18_listanombre3 = AV34ListaNombre3;
         AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV47TFProfesionalesRestriccionId;
         AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV48TFProfesionalesRestriccionId_To;
         AV109Profesionalesrestriccionwwds_21_tfprofesionalesid = AV49TFProfesionalesId;
         AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV50TFProfesionalesId_Sel;
         AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV51TFProfesionalesPrimerNombre;
         AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV52TFProfesionalesPrimerNombre_Sel;
         AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV53TFProfesionalesApellidoPrimero;
         AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV54TFProfesionalesApellidoPrimero_Sel;
         AV115Profesionalesrestriccionwwds_27_tflistaid = AV55TFListaid;
         AV116Profesionalesrestriccionwwds_28_tflistaid_to = AV56TFListaid_To;
         AV117Profesionalesrestriccionwwds_29_tflistanombre = AV57TFListaNombre;
         AV118Profesionalesrestriccionwwds_30_tflistanombre_sel = AV58TFListaNombre_Sel;
         AV119Profesionalesrestriccionwwds_31_tflistaestado_sels = AV60TFListaEstado_Sels;
         AV120Profesionalesrestriccionwwds_32_tflistatipo_sels = AV62TFListaTipo_Sels;
         AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV63TFRestriccionesFechaAlta;
         AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV64TFRestriccionesFechaAlta_To;
         AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV69TFRestriccionesEstado_Sels;
         AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV70TFRestriccionesObservacion;
         AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV71TFRestriccionesObservacion_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV89Profesionalesrestriccionwwds_1_filterfulltext = AV17FilterFullText;
         AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV20RestriccionesFechaAlta1;
         AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV21RestriccionesFechaAlta_To1;
         AV94Profesionalesrestriccionwwds_6_listanombre1 = AV22ListaNombre1;
         AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV26RestriccionesFechaAlta2;
         AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV27RestriccionesFechaAlta_To2;
         AV100Profesionalesrestriccionwwds_12_listanombre2 = AV28ListaNombre2;
         AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV32RestriccionesFechaAlta3;
         AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV33RestriccionesFechaAlta_To3;
         AV106Profesionalesrestriccionwwds_18_listanombre3 = AV34ListaNombre3;
         AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV47TFProfesionalesRestriccionId;
         AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV48TFProfesionalesRestriccionId_To;
         AV109Profesionalesrestriccionwwds_21_tfprofesionalesid = AV49TFProfesionalesId;
         AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV50TFProfesionalesId_Sel;
         AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV51TFProfesionalesPrimerNombre;
         AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV52TFProfesionalesPrimerNombre_Sel;
         AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV53TFProfesionalesApellidoPrimero;
         AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV54TFProfesionalesApellidoPrimero_Sel;
         AV115Profesionalesrestriccionwwds_27_tflistaid = AV55TFListaid;
         AV116Profesionalesrestriccionwwds_28_tflistaid_to = AV56TFListaid_To;
         AV117Profesionalesrestriccionwwds_29_tflistanombre = AV57TFListaNombre;
         AV118Profesionalesrestriccionwwds_30_tflistanombre_sel = AV58TFListaNombre_Sel;
         AV119Profesionalesrestriccionwwds_31_tflistaestado_sels = AV60TFListaEstado_Sels;
         AV120Profesionalesrestriccionwwds_32_tflistatipo_sels = AV62TFListaTipo_Sels;
         AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV63TFRestriccionesFechaAlta;
         AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV64TFRestriccionesFechaAlta_To;
         AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV69TFRestriccionesEstado_Sels;
         AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV70TFRestriccionesObservacion;
         AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV71TFRestriccionesObservacion_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AV88Pgmname = "ProfesionalesRestriccionWW";
         edtProfesionalesRestriccionId_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtListaid_Enabled = 0;
         edtListaNombre_Enabled = 0;
         cmbListaEstado.Enabled = 0;
         cmbListaTipo.Enabled = 0;
         edtRestriccionesFechaAlta_Enabled = 0;
         cmbRestriccionesEstado.Enabled = 0;
         edtRestriccionesObservacion_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPKW0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E33KW2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV44ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV82AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV72DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV41ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_129 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_129"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV74GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV75GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV76GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV20RestriccionesFechaAlta1 = context.localUtil.CToT( cgiGet( "vRESTRICCIONESFECHAALTA1"), 0);
            AssignAttri("", false, "AV20RestriccionesFechaAlta1", context.localUtil.TToC( AV20RestriccionesFechaAlta1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV21RestriccionesFechaAlta_To1 = context.localUtil.CToT( cgiGet( "vRESTRICCIONESFECHAALTA_TO1"), 0);
            AssignAttri("", false, "AV21RestriccionesFechaAlta_To1", context.localUtil.TToC( AV21RestriccionesFechaAlta_To1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV26RestriccionesFechaAlta2 = context.localUtil.CToT( cgiGet( "vRESTRICCIONESFECHAALTA2"), 0);
            AssignAttri("", false, "AV26RestriccionesFechaAlta2", context.localUtil.TToC( AV26RestriccionesFechaAlta2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV27RestriccionesFechaAlta_To2 = context.localUtil.CToT( cgiGet( "vRESTRICCIONESFECHAALTA_TO2"), 0);
            AssignAttri("", false, "AV27RestriccionesFechaAlta_To2", context.localUtil.TToC( AV27RestriccionesFechaAlta_To2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV32RestriccionesFechaAlta3 = context.localUtil.CToT( cgiGet( "vRESTRICCIONESFECHAALTA3"), 0);
            AssignAttri("", false, "AV32RestriccionesFechaAlta3", context.localUtil.TToC( AV32RestriccionesFechaAlta3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV33RestriccionesFechaAlta_To3 = context.localUtil.CToT( cgiGet( "vRESTRICCIONESFECHAALTA_TO3"), 0);
            AssignAttri("", false, "AV33RestriccionesFechaAlta_To3", context.localUtil.TToC( AV33RestriccionesFechaAlta_To3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV65DDO_RestriccionesFechaAltaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_RESTRICCIONESFECHAALTAAUXDATE"), 0);
            AssignAttri("", false, "AV65DDO_RestriccionesFechaAltaAuxDate", context.localUtil.Format(AV65DDO_RestriccionesFechaAltaAuxDate, "99/99/99"));
            AV66DDO_RestriccionesFechaAltaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_RESTRICCIONESFECHAALTAAUXDATETO"), 0);
            AssignAttri("", false, "AV66DDO_RestriccionesFechaAltaAuxDateTo", context.localUtil.Format(AV66DDO_RestriccionesFechaAltaAuxDateTo, "99/99/99"));
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
            AV85RestriccionesFechaAlta_RangeText1 = cgiGet( edtavRestriccionesfechaalta_rangetext1_Internalname);
            AssignAttri("", false, "AV85RestriccionesFechaAlta_RangeText1", AV85RestriccionesFechaAlta_RangeText1);
            AV22ListaNombre1 = cgiGet( edtavListanombre1_Internalname);
            AssignAttri("", false, "AV22ListaNombre1", AV22ListaNombre1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV24DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
            AV86RestriccionesFechaAlta_RangeText2 = cgiGet( edtavRestriccionesfechaalta_rangetext2_Internalname);
            AssignAttri("", false, "AV86RestriccionesFechaAlta_RangeText2", AV86RestriccionesFechaAlta_RangeText2);
            AV28ListaNombre2 = cgiGet( edtavListanombre2_Internalname);
            AssignAttri("", false, "AV28ListaNombre2", AV28ListaNombre2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV30DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
            AV87RestriccionesFechaAlta_RangeText3 = cgiGet( edtavRestriccionesfechaalta_rangetext3_Internalname);
            AssignAttri("", false, "AV87RestriccionesFechaAlta_RangeText3", AV87RestriccionesFechaAlta_RangeText3);
            AV34ListaNombre3 = cgiGet( edtavListanombre3_Internalname);
            AssignAttri("", false, "AV34ListaNombre3", AV34ListaNombre3);
            AV67DDO_RestriccionesFechaAltaAuxDateText = cgiGet( edtavDdo_restriccionesfechaaltaauxdatetext_Internalname);
            AssignAttri("", false, "AV67DDO_RestriccionesFechaAltaAuxDateText", AV67DDO_RestriccionesFechaAltaAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vLISTANOMBRE1"), AV22ListaNombre1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV24DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV25DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vLISTANOMBRE2"), AV28ListaNombre2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV30DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV31DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vLISTANOMBRE3"), AV34ListaNombre3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vRESTRICCIONESFECHAALTA1")) != AV20RestriccionesFechaAlta1 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vRESTRICCIONESFECHAALTA2")) != AV26RestriccionesFechaAlta2 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vRESTRICCIONESFECHAALTA3")) != AV32RestriccionesFechaAlta3 )
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
         E33KW2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E33KW2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFRESTRICCIONESFECHAALTA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_restriccionesfechaaltaauxdatetext_Internalname});
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
         this.executeUsercontrolMethod("", false, "RESTRICCIONESFECHAALTA_RANGEPICKER1Container", "Attach", "", new Object[] {(string)edtavRestriccionesfechaalta_rangetext1_Internalname});
         AV18DynamicFiltersSelector1 = "RESTRICCIONESFECHAALTA";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod("", false, "RESTRICCIONESFECHAALTA_RANGEPICKER2Container", "Attach", "", new Object[] {(string)edtavRestriccionesfechaalta_rangetext2_Internalname});
         AV24DynamicFiltersSelector2 = "RESTRICCIONESFECHAALTA";
         AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod("", false, "RESTRICCIONESFECHAALTA_RANGEPICKER3Container", "Attach", "", new Object[] {(string)edtavRestriccionesfechaalta_rangetext3_Internalname});
         AV30DynamicFiltersSelector3 = "RESTRICCIONESFECHAALTA";
         AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
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
         AV82AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV83AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV83AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV83AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV83AGExportDataItem.gxTpr_Eventkey = "Export";
         AV83AGExportDataItem.gxTpr_Isdivider = false;
         AV82AGExportData.Add(AV83AGExportDataItem, 0);
         AV83AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV83AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV83AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV83AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV83AGExportDataItem.gxTpr_Isdivider = false;
         AV82AGExportData.Add(AV83AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV81IsAuthorized_ListaNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWLista", out  GXt_boolean1) ;
         AV81IsAuthorized_ListaNombre = GXt_boolean1;
         AssignAttri("", false, "AV81IsAuthorized_ListaNombre", AV81IsAuthorized_ListaNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_LISTANOMBRE", GetSecureSignedToken( "", AV81IsAuthorized_ListaNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Lista Profesionales Restriccion", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV72DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV72DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E34KW2( )
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
         if ( AV46ManageFiltersExecutionStep == 1 )
         {
            AV46ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV46ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV46ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV46ManageFiltersExecutionStep == 2 )
         {
            AV46ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV46ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV46ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESTRICCIONESFECHAALTA") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterPast", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterToday", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("2", context.GetMessage( "WWP_FilterInTheFuture", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("3", context.GetMessage( "WWP_FilterRange", ""), 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "LISTANOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         if ( AV23DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "RESTRICCIONESFECHAALTA") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterPast", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterToday", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("2", context.GetMessage( "WWP_FilterInTheFuture", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("3", context.GetMessage( "WWP_FilterRange", ""), 0);
            }
            else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "LISTANOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            if ( AV29DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESTRICCIONESFECHAALTA") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterPast", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterToday", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("2", context.GetMessage( "WWP_FilterInTheFuture", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("3", context.GetMessage( "WWP_FilterRange", ""), 0);
               }
               else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "LISTANOMBRE") == 0 )
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
         if ( StringUtil.StrCmp(AV43Session.Get("ProfesionalesRestriccionWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV43Session.Get("ProfesionalesRestriccionWWColumnsSelector");
            AV41ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
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
         edtProfesionalesRestriccionId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesRestriccionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesRestriccionId_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProfesionalesId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProfesionalesPrimerNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProfesionalesApellidoPrimero_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtListaid_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtListaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaid_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtListaNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtListaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         cmbListaEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbListaEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbListaEstado.Visible), 5, 0), !bGXsfl_129_Refreshing);
         cmbListaTipo.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbListaTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbListaTipo.Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtRestriccionesFechaAlta_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtRestriccionesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRestriccionesFechaAlta_Visible), 5, 0), !bGXsfl_129_Refreshing);
         cmbRestriccionesEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbRestriccionesEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbRestriccionesEstado.Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtRestriccionesObservacion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtRestriccionesObservacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRestriccionesObservacion_Visible), 5, 0), !bGXsfl_129_Refreshing);
         AV74GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV74GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV74GridCurrentPage), 10, 0));
         AV75GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV75GridPageCount", StringUtil.LTrimStr( (decimal)(AV75GridPageCount), 10, 0));
         GXt_char3 = AV76GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV88Pgmname, out  GXt_char3) ;
         AV76GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV76GridAppliedFilters", AV76GridAppliedFilters);
         AV89Profesionalesrestriccionwwds_1_filterfulltext = AV17FilterFullText;
         AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV20RestriccionesFechaAlta1;
         AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV21RestriccionesFechaAlta_To1;
         AV94Profesionalesrestriccionwwds_6_listanombre1 = AV22ListaNombre1;
         AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV26RestriccionesFechaAlta2;
         AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV27RestriccionesFechaAlta_To2;
         AV100Profesionalesrestriccionwwds_12_listanombre2 = AV28ListaNombre2;
         AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV32RestriccionesFechaAlta3;
         AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV33RestriccionesFechaAlta_To3;
         AV106Profesionalesrestriccionwwds_18_listanombre3 = AV34ListaNombre3;
         AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV47TFProfesionalesRestriccionId;
         AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV48TFProfesionalesRestriccionId_To;
         AV109Profesionalesrestriccionwwds_21_tfprofesionalesid = AV49TFProfesionalesId;
         AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV50TFProfesionalesId_Sel;
         AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV51TFProfesionalesPrimerNombre;
         AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV52TFProfesionalesPrimerNombre_Sel;
         AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV53TFProfesionalesApellidoPrimero;
         AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV54TFProfesionalesApellidoPrimero_Sel;
         AV115Profesionalesrestriccionwwds_27_tflistaid = AV55TFListaid;
         AV116Profesionalesrestriccionwwds_28_tflistaid_to = AV56TFListaid_To;
         AV117Profesionalesrestriccionwwds_29_tflistanombre = AV57TFListaNombre;
         AV118Profesionalesrestriccionwwds_30_tflistanombre_sel = AV58TFListaNombre_Sel;
         AV119Profesionalesrestriccionwwds_31_tflistaestado_sels = AV60TFListaEstado_Sels;
         AV120Profesionalesrestriccionwwds_32_tflistatipo_sels = AV62TFListaTipo_Sels;
         AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV63TFRestriccionesFechaAlta;
         AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV64TFRestriccionesFechaAlta_To;
         AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV69TFRestriccionesEstado_Sels;
         AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV70TFRestriccionesObservacion;
         AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV71TFRestriccionesObservacion_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12KW2( )
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
            AV73PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV73PageToGo) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13KW2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E19KW2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesRestriccionId") == 0 )
            {
               AV47TFProfesionalesRestriccionId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(AV47TFProfesionalesRestriccionId), 18, 0));
               AV48TFProfesionalesRestriccionId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFProfesionalesRestriccionId_To", StringUtil.LTrimStr( (decimal)(AV48TFProfesionalesRestriccionId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesId") == 0 )
            {
               AV49TFProfesionalesId = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV49TFProfesionalesId", AV49TFProfesionalesId);
               AV50TFProfesionalesId_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV50TFProfesionalesId_Sel", AV50TFProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesPrimerNombre") == 0 )
            {
               AV51TFProfesionalesPrimerNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV51TFProfesionalesPrimerNombre", AV51TFProfesionalesPrimerNombre);
               AV52TFProfesionalesPrimerNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV52TFProfesionalesPrimerNombre_Sel", AV52TFProfesionalesPrimerNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesApellidoPrimero") == 0 )
            {
               AV53TFProfesionalesApellidoPrimero = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV53TFProfesionalesApellidoPrimero", AV53TFProfesionalesApellidoPrimero);
               AV54TFProfesionalesApellidoPrimero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV54TFProfesionalesApellidoPrimero_Sel", AV54TFProfesionalesApellidoPrimero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Listaid") == 0 )
            {
               AV55TFListaid = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV55TFListaid", StringUtil.LTrimStr( (decimal)(AV55TFListaid), 18, 0));
               AV56TFListaid_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV56TFListaid_To", StringUtil.LTrimStr( (decimal)(AV56TFListaid_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ListaNombre") == 0 )
            {
               AV57TFListaNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV57TFListaNombre", AV57TFListaNombre);
               AV58TFListaNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV58TFListaNombre_Sel", AV58TFListaNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ListaEstado") == 0 )
            {
               AV59TFListaEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV59TFListaEstado_SelsJson", AV59TFListaEstado_SelsJson);
               AV60TFListaEstado_Sels.FromJSonString(AV59TFListaEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ListaTipo") == 0 )
            {
               AV61TFListaTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV61TFListaTipo_SelsJson", AV61TFListaTipo_SelsJson);
               AV62TFListaTipo_Sels.FromJSonString(AV61TFListaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RestriccionesFechaAlta") == 0 )
            {
               AV63TFRestriccionesFechaAlta = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV63TFRestriccionesFechaAlta", context.localUtil.TToC( AV63TFRestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV64TFRestriccionesFechaAlta_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV64TFRestriccionesFechaAlta_To", context.localUtil.TToC( AV64TFRestriccionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV64TFRestriccionesFechaAlta_To) )
               {
                  AV64TFRestriccionesFechaAlta_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV64TFRestriccionesFechaAlta_To)), (short)(DateTimeUtil.Month( AV64TFRestriccionesFechaAlta_To)), (short)(DateTimeUtil.Day( AV64TFRestriccionesFechaAlta_To)), 23, 59, 59);
                  AssignAttri("", false, "AV64TFRestriccionesFechaAlta_To", context.localUtil.TToC( AV64TFRestriccionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RestriccionesEstado") == 0 )
            {
               AV68TFRestriccionesEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV68TFRestriccionesEstado_SelsJson", AV68TFRestriccionesEstado_SelsJson);
               AV69TFRestriccionesEstado_Sels.FromJSonString(AV68TFRestriccionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "RestriccionesObservacion") == 0 )
            {
               AV70TFRestriccionesObservacion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV70TFRestriccionesObservacion", AV70TFRestriccionesObservacion);
               AV71TFRestriccionesObservacion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV71TFRestriccionesObservacion_Sel", AV71TFRestriccionesObservacion_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV69TFRestriccionesEstado_Sels", AV69TFRestriccionesEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV62TFListaTipo_Sels", AV62TFListaTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60TFListaEstado_Sels", AV60TFListaEstado_Sels);
      }

      private void E35KW2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV79IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV80IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            if ( AV81IsAuthorized_ListaNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "listaview.aspx"+UrlEncode(StringUtil.LTrimStr(A590Listaid,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtListaNombre_Link = formatLink("listaview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "profesionalesrestriccionview.aspx"+UrlEncode(StringUtil.LTrimStr(A976ProfesionalesRestriccionId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtRestriccionesFechaAlta_Link = formatLink("profesionalesrestriccionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV77GridActions), 4, 0));
      }

      protected void E20KW2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV39ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV41ColumnsSelector.FromJSonString(AV39ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "ProfesionalesRestriccionWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV39ColumnsSelectorXML)) ? "" : AV41ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E25KW2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E21KW2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV35DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV36DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV36DynamicFiltersIgnoreFirst", AV36DynamicFiltersIgnoreFirst);
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
         AV35DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV36DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV36DynamicFiltersIgnoreFirst", AV36DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E26KW2( )
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

      protected void E16KW2( )
      {
         /* Restriccionesfechaalta_rangepicker1_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV20RestriccionesFechaAlta1", context.localUtil.TToC( AV20RestriccionesFechaAlta1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "AV21RestriccionesFechaAlta_To1", context.localUtil.TToC( AV21RestriccionesFechaAlta_To1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E27KW2( )
      {
         /* Dynamicfiltersoperator1_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESTRICCIONESFECHAALTA") == 0 )
         {
            AV20RestriccionesFechaAlta1 = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV20RestriccionesFechaAlta1", context.localUtil.TToC( AV20RestriccionesFechaAlta1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV21RestriccionesFechaAlta_To1 = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV21RestriccionesFechaAlta_To1", context.localUtil.TToC( AV21RestriccionesFechaAlta_To1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            /* Execute user subroutine: 'UPDATERESTRICCIONESFECHAALTA1OPERATORVALUES' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E28KW2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E22KW2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV35DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
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
         AV35DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E29KW2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV25DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E17KW2( )
      {
         /* Restriccionesfechaalta_rangepicker2_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV26RestriccionesFechaAlta2", context.localUtil.TToC( AV26RestriccionesFechaAlta2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "AV27RestriccionesFechaAlta_To2", context.localUtil.TToC( AV27RestriccionesFechaAlta_To2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E30KW2( )
      {
         /* Dynamicfiltersoperator2_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "RESTRICCIONESFECHAALTA") == 0 )
         {
            AV26RestriccionesFechaAlta2 = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV26RestriccionesFechaAlta2", context.localUtil.TToC( AV26RestriccionesFechaAlta2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV27RestriccionesFechaAlta_To2 = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV27RestriccionesFechaAlta_To2", context.localUtil.TToC( AV27RestriccionesFechaAlta_To2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            /* Execute user subroutine: 'UPDATERESTRICCIONESFECHAALTA2OPERATORVALUES' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E23KW2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV35DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV29DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
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
         AV35DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E31KW2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV31DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E18KW2( )
      {
         /* Restriccionesfechaalta_rangepicker3_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV32RestriccionesFechaAlta3", context.localUtil.TToC( AV32RestriccionesFechaAlta3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "AV33RestriccionesFechaAlta_To3", context.localUtil.TToC( AV33RestriccionesFechaAlta_To3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E32KW2( )
      {
         /* Dynamicfiltersoperator3_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESTRICCIONESFECHAALTA") == 0 )
         {
            AV32RestriccionesFechaAlta3 = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV32RestriccionesFechaAlta3", context.localUtil.TToC( AV32RestriccionesFechaAlta3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV33RestriccionesFechaAlta_To3 = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV33RestriccionesFechaAlta_To3", context.localUtil.TToC( AV33RestriccionesFechaAlta_To3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            /* Execute user subroutine: 'UPDATERESTRICCIONESFECHAALTA3OPERATORVALUES' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV22ListaNombre1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV28ListaNombre2, AV30DynamicFiltersSelector3, AV31DynamicFiltersOperator3, AV34ListaNombre3, AV20RestriccionesFechaAlta1, AV26RestriccionesFechaAlta2, AV32RestriccionesFechaAlta3, AV46ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV29DynamicFiltersEnabled3, AV41ColumnsSelector, AV88Pgmname, AV17FilterFullText, AV21RestriccionesFechaAlta_To1, AV27RestriccionesFechaAlta_To2, AV33RestriccionesFechaAlta_To3, AV47TFProfesionalesRestriccionId, AV48TFProfesionalesRestriccionId_To, AV49TFProfesionalesId, AV50TFProfesionalesId_Sel, AV51TFProfesionalesPrimerNombre, AV52TFProfesionalesPrimerNombre_Sel, AV53TFProfesionalesApellidoPrimero, AV54TFProfesionalesApellidoPrimero_Sel, AV55TFListaid, AV56TFListaid_To, AV57TFListaNombre, AV58TFListaNombre_Sel, AV60TFListaEstado_Sels, AV62TFListaTipo_Sels, AV63TFRestriccionesFechaAlta, AV64TFRestriccionesFechaAlta_To, AV69TFRestriccionesEstado_Sels, AV70TFRestriccionesObservacion, AV71TFRestriccionesObservacion_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving, AV79IsAuthorized_Update, AV80IsAuthorized_Delete, AV81IsAuthorized_ListaNombre, Gx_date) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E11KW2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S272 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("ProfesionalesRestriccionWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV88Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV46ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV46ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV46ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("ProfesionalesRestriccionWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV46ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV46ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV46ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV45ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ProfesionalesRestriccionWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV45ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S272 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV88Pgmname+"GridState",  AV45ManageFiltersXml) ;
               AV11GridState.FromXml(AV45ManageFiltersXml, null, "", "");
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
               S282 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60TFListaEstado_Sels", AV60TFListaEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV62TFListaTipo_Sels", AV62TFListaTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV69TFRestriccionesEstado_Sels", AV69TFRestriccionesEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E36KW2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV77GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV77GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV77GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S312 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV77GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV77GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV77GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E24KW2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionalesrestriccion.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("profesionalesrestriccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14KW2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S322 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S332 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV69TFRestriccionesEstado_Sels", AV69TFRestriccionesEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV62TFListaTipo_Sels", AV62TFListaTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60TFListaEstado_Sels", AV60TFListaEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV30DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E15KW2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0159",(string)"",(string)"ProfesionalesRestriccion",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0159"+"");
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
         AV41ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "ProfesionalesRestriccionId",  "",  "Restriccion Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "ProfesionalesId",  "",  "Identidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "ProfesionalesPrimerNombre",  "",  "Primer Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "ProfesionalesApellidoPrimero",  "",  "Primer Apellido ",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "Listaid",  "",  "Listaid",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "ListaNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "ListaEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "ListaTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "RestriccionesFechaAlta",  "",  "Fecha Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "RestriccionesEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "RestriccionesObservacion",  "",  "Observacion",  true,  "") ;
         GXt_char3 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ProfesionalesRestriccionWWColumnsSelector", out  GXt_char3) ;
         AV40UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40UserCustomValue)) ) )
         {
            AV42ColumnsSelectorAux.FromXml(AV40UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV42ColumnsSelectorAux, ref  AV41ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV79IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionalesRestriccion_Update", out  GXt_boolean1) ;
         AV79IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV79IsAuthorized_Update", AV79IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV79IsAuthorized_Update, context));
         GXt_boolean1 = AV80IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionalesRestriccion_Delete", out  GXt_boolean1) ;
         AV80IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV80IsAuthorized_Delete", AV80IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV80IsAuthorized_Delete, context));
         GXt_boolean1 = AV84TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionalesRestriccion_Insert", out  GXt_boolean1) ;
         AV84TempBoolean = GXt_boolean1;
         if ( ! ( AV84TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV84TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean1) ;
         AV84TempBoolean = GXt_boolean1;
         if ( ! ( AV84TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "ProfesionalesRestriccion",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfiltersrestriccionesfechaalta1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible), 5, 0), true);
         edtavListanombre1_Visible = 0;
         AssignProp("", false, edtavListanombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavListanombre1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESTRICCIONESFECHAALTA") == 0 )
         {
            tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfiltersrestriccionesfechaalta1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATERESTRICCIONESFECHAALTA1OPERATORVALUES' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "LISTANOMBRE") == 0 )
         {
            edtavListanombre1_Visible = 1;
            AssignProp("", false, edtavListanombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavListanombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S242( )
      {
         /* 'UPDATERESTRICCIONESFECHAALTA1OPERATORVALUES' Routine */
         returnInSub = false;
         cellRestriccionesfechaalta_range_cell1_Class = "Invisible";
         AssignProp("", false, cellRestriccionesfechaalta_range_cell1_Internalname, "Class", cellRestriccionesfechaalta_range_cell1_Class, true);
         if ( AV19DynamicFiltersOperator1 == 0 )
         {
            AV20RestriccionesFechaAlta1 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri("", false, "AV20RestriccionesFechaAlta1", context.localUtil.TToC( AV20RestriccionesFechaAlta1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         else if ( AV19DynamicFiltersOperator1 == 1 )
         {
            AV20RestriccionesFechaAlta1 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri("", false, "AV20RestriccionesFechaAlta1", context.localUtil.TToC( AV20RestriccionesFechaAlta1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV21RestriccionesFechaAlta_To1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date , + ( (int)(1) )) ) ;
            AssignAttri("", false, "AV21RestriccionesFechaAlta_To1", context.localUtil.TToC( AV21RestriccionesFechaAlta_To1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         else if ( AV19DynamicFiltersOperator1 == 2 )
         {
            AV20RestriccionesFechaAlta1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (1)) ) ;
            AssignAttri("", false, "AV20RestriccionesFechaAlta1", context.localUtil.TToC( AV20RestriccionesFechaAlta1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         else if ( AV19DynamicFiltersOperator1 == 3 )
         {
            cellRestriccionesfechaalta_range_cell1_Class = "";
            AssignProp("", false, cellRestriccionesfechaalta_range_cell1_Internalname, "Class", cellRestriccionesfechaalta_range_cell1_Class, true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfiltersrestriccionesfechaalta2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible), 5, 0), true);
         edtavListanombre2_Visible = 0;
         AssignProp("", false, edtavListanombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavListanombre2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "RESTRICCIONESFECHAALTA") == 0 )
         {
            tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfiltersrestriccionesfechaalta2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATERESTRICCIONESFECHAALTA2OPERATORVALUES' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "LISTANOMBRE") == 0 )
         {
            edtavListanombre2_Visible = 1;
            AssignProp("", false, edtavListanombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavListanombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S252( )
      {
         /* 'UPDATERESTRICCIONESFECHAALTA2OPERATORVALUES' Routine */
         returnInSub = false;
         cellRestriccionesfechaalta_range_cell2_Class = "Invisible";
         AssignProp("", false, cellRestriccionesfechaalta_range_cell2_Internalname, "Class", cellRestriccionesfechaalta_range_cell2_Class, true);
         if ( AV25DynamicFiltersOperator2 == 0 )
         {
            AV26RestriccionesFechaAlta2 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri("", false, "AV26RestriccionesFechaAlta2", context.localUtil.TToC( AV26RestriccionesFechaAlta2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         else if ( AV25DynamicFiltersOperator2 == 1 )
         {
            AV26RestriccionesFechaAlta2 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri("", false, "AV26RestriccionesFechaAlta2", context.localUtil.TToC( AV26RestriccionesFechaAlta2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV27RestriccionesFechaAlta_To2 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date , + ( (int)(1) )) ) ;
            AssignAttri("", false, "AV27RestriccionesFechaAlta_To2", context.localUtil.TToC( AV27RestriccionesFechaAlta_To2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         else if ( AV25DynamicFiltersOperator2 == 2 )
         {
            AV26RestriccionesFechaAlta2 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (1)) ) ;
            AssignAttri("", false, "AV26RestriccionesFechaAlta2", context.localUtil.TToC( AV26RestriccionesFechaAlta2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         else if ( AV25DynamicFiltersOperator2 == 3 )
         {
            cellRestriccionesfechaalta_range_cell2_Class = "";
            AssignProp("", false, cellRestriccionesfechaalta_range_cell2_Internalname, "Class", cellRestriccionesfechaalta_range_cell2_Class, true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfiltersrestriccionesfechaalta3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible), 5, 0), true);
         edtavListanombre3_Visible = 0;
         AssignProp("", false, edtavListanombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavListanombre3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESTRICCIONESFECHAALTA") == 0 )
         {
            tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfiltersrestriccionesfechaalta3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATERESTRICCIONESFECHAALTA3OPERATORVALUES' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "LISTANOMBRE") == 0 )
         {
            edtavListanombre3_Visible = 1;
            AssignProp("", false, edtavListanombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavListanombre3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S262( )
      {
         /* 'UPDATERESTRICCIONESFECHAALTA3OPERATORVALUES' Routine */
         returnInSub = false;
         cellRestriccionesfechaalta_range_cell3_Class = "Invisible";
         AssignProp("", false, cellRestriccionesfechaalta_range_cell3_Internalname, "Class", cellRestriccionesfechaalta_range_cell3_Class, true);
         if ( AV31DynamicFiltersOperator3 == 0 )
         {
            AV32RestriccionesFechaAlta3 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri("", false, "AV32RestriccionesFechaAlta3", context.localUtil.TToC( AV32RestriccionesFechaAlta3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         else if ( AV31DynamicFiltersOperator3 == 1 )
         {
            AV32RestriccionesFechaAlta3 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri("", false, "AV32RestriccionesFechaAlta3", context.localUtil.TToC( AV32RestriccionesFechaAlta3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            AV33RestriccionesFechaAlta_To3 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date , + ( (int)(1) )) ) ;
            AssignAttri("", false, "AV33RestriccionesFechaAlta_To3", context.localUtil.TToC( AV33RestriccionesFechaAlta_To3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         else if ( AV31DynamicFiltersOperator3 == 2 )
         {
            AV32RestriccionesFechaAlta3 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (1)) ) ;
            AssignAttri("", false, "AV32RestriccionesFechaAlta3", context.localUtil.TToC( AV32RestriccionesFechaAlta3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         else if ( AV31DynamicFiltersOperator3 == 3 )
         {
            cellRestriccionesfechaalta_range_cell3_Class = "";
            AssignProp("", false, cellRestriccionesfechaalta_range_cell3_Internalname, "Class", cellRestriccionesfechaalta_range_cell3_Class, true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
         AV24DynamicFiltersSelector2 = "RESTRICCIONESFECHAALTA";
         AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         AV25DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AV26RestriccionesFechaAlta2 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV26RestriccionesFechaAlta2", context.localUtil.TToC( AV26RestriccionesFechaAlta2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV27RestriccionesFechaAlta_To2 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV27RestriccionesFechaAlta_To2", context.localUtil.TToC( AV27RestriccionesFechaAlta_To2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
         AV30DynamicFiltersSelector3 = "RESTRICCIONESFECHAALTA";
         AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
         AV31DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         AV32RestriccionesFechaAlta3 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV32RestriccionesFechaAlta3", context.localUtil.TToC( AV32RestriccionesFechaAlta3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV33RestriccionesFechaAlta_To3 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV33RestriccionesFechaAlta_To3", context.localUtil.TToC( AV33RestriccionesFechaAlta_To3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV44ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ProfesionalesRestriccionWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV44ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S272( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV47TFProfesionalesRestriccionId = 0;
         AssignAttri("", false, "AV47TFProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(AV47TFProfesionalesRestriccionId), 18, 0));
         AV48TFProfesionalesRestriccionId_To = 0;
         AssignAttri("", false, "AV48TFProfesionalesRestriccionId_To", StringUtil.LTrimStr( (decimal)(AV48TFProfesionalesRestriccionId_To), 18, 0));
         AV49TFProfesionalesId = "";
         AssignAttri("", false, "AV49TFProfesionalesId", AV49TFProfesionalesId);
         AV50TFProfesionalesId_Sel = "";
         AssignAttri("", false, "AV50TFProfesionalesId_Sel", AV50TFProfesionalesId_Sel);
         AV51TFProfesionalesPrimerNombre = "";
         AssignAttri("", false, "AV51TFProfesionalesPrimerNombre", AV51TFProfesionalesPrimerNombre);
         AV52TFProfesionalesPrimerNombre_Sel = "";
         AssignAttri("", false, "AV52TFProfesionalesPrimerNombre_Sel", AV52TFProfesionalesPrimerNombre_Sel);
         AV53TFProfesionalesApellidoPrimero = "";
         AssignAttri("", false, "AV53TFProfesionalesApellidoPrimero", AV53TFProfesionalesApellidoPrimero);
         AV54TFProfesionalesApellidoPrimero_Sel = "";
         AssignAttri("", false, "AV54TFProfesionalesApellidoPrimero_Sel", AV54TFProfesionalesApellidoPrimero_Sel);
         AV55TFListaid = 0;
         AssignAttri("", false, "AV55TFListaid", StringUtil.LTrimStr( (decimal)(AV55TFListaid), 18, 0));
         AV56TFListaid_To = 0;
         AssignAttri("", false, "AV56TFListaid_To", StringUtil.LTrimStr( (decimal)(AV56TFListaid_To), 18, 0));
         AV57TFListaNombre = "";
         AssignAttri("", false, "AV57TFListaNombre", AV57TFListaNombre);
         AV58TFListaNombre_Sel = "";
         AssignAttri("", false, "AV58TFListaNombre_Sel", AV58TFListaNombre_Sel);
         AV60TFListaEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV62TFListaTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV63TFRestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV63TFRestriccionesFechaAlta", context.localUtil.TToC( AV63TFRestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV64TFRestriccionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV64TFRestriccionesFechaAlta_To", context.localUtil.TToC( AV64TFRestriccionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV69TFRestriccionesEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV70TFRestriccionesObservacion = "";
         AssignAttri("", false, "AV70TFRestriccionesObservacion", AV70TFRestriccionesObservacion);
         AV71TFRestriccionesObservacion_Sel = "";
         AssignAttri("", false, "AV71TFRestriccionesObservacion_Sel", AV71TFRestriccionesObservacion_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "RESTRICCIONESFECHAALTA";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20RestriccionesFechaAlta1 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV20RestriccionesFechaAlta1", context.localUtil.TToC( AV20RestriccionesFechaAlta1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV21RestriccionesFechaAlta_To1 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV21RestriccionesFechaAlta_To1", context.localUtil.TToC( AV21RestriccionesFechaAlta_To1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
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

      protected void S292( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionalesrestriccionview.aspx"+UrlEncode(StringUtil.LTrimStr(A976ProfesionalesRestriccionId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("profesionalesrestriccionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S302( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionalesrestriccion.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A976ProfesionalesRestriccionId,18,0));
         CallWebObject(formatLink("profesionalesrestriccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S312( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionalesrestriccion.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A976ProfesionalesRestriccionId,18,0));
         CallWebObject(formatLink("profesionalesrestriccion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV43Session.Get(AV88Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV88Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV43Session.Get(AV88Pgmname+"GridState"), null, "", "");
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
         S282 ();
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

      protected void S282( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV127GXV1 = 1;
         while ( AV127GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV127GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESRESTRICCIONID") == 0 )
            {
               AV47TFProfesionalesRestriccionId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFProfesionalesRestriccionId", StringUtil.LTrimStr( (decimal)(AV47TFProfesionalesRestriccionId), 18, 0));
               AV48TFProfesionalesRestriccionId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFProfesionalesRestriccionId_To", StringUtil.LTrimStr( (decimal)(AV48TFProfesionalesRestriccionId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV49TFProfesionalesId = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFProfesionalesId", AV49TFProfesionalesId);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV50TFProfesionalesId_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFProfesionalesId_Sel", AV50TFProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV51TFProfesionalesPrimerNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFProfesionalesPrimerNombre", AV51TFProfesionalesPrimerNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV52TFProfesionalesPrimerNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFProfesionalesPrimerNombre_Sel", AV52TFProfesionalesPrimerNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV53TFProfesionalesApellidoPrimero = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFProfesionalesApellidoPrimero", AV53TFProfesionalesApellidoPrimero);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV54TFProfesionalesApellidoPrimero_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFProfesionalesApellidoPrimero_Sel", AV54TFProfesionalesApellidoPrimero_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLISTAID") == 0 )
            {
               AV55TFListaid = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV55TFListaid", StringUtil.LTrimStr( (decimal)(AV55TFListaid), 18, 0));
               AV56TFListaid_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV56TFListaid_To", StringUtil.LTrimStr( (decimal)(AV56TFListaid_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE") == 0 )
            {
               AV57TFListaNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV57TFListaNombre", AV57TFListaNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE_SEL") == 0 )
            {
               AV58TFListaNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV58TFListaNombre_Sel", AV58TFListaNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLISTAESTADO_SEL") == 0 )
            {
               AV59TFListaEstado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFListaEstado_SelsJson", AV59TFListaEstado_SelsJson);
               AV60TFListaEstado_Sels.FromJSonString(AV59TFListaEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLISTATIPO_SEL") == 0 )
            {
               AV61TFListaTipo_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV61TFListaTipo_SelsJson", AV61TFListaTipo_SelsJson);
               AV62TFListaTipo_Sels.FromJSonString(AV61TFListaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESFECHAALTA") == 0 )
            {
               AV63TFRestriccionesFechaAlta = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV63TFRestriccionesFechaAlta", context.localUtil.TToC( AV63TFRestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV64TFRestriccionesFechaAlta_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV64TFRestriccionesFechaAlta_To", context.localUtil.TToC( AV64TFRestriccionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV65DDO_RestriccionesFechaAltaAuxDate = DateTimeUtil.ResetTime(AV63TFRestriccionesFechaAlta);
               AssignAttri("", false, "AV65DDO_RestriccionesFechaAltaAuxDate", context.localUtil.Format(AV65DDO_RestriccionesFechaAltaAuxDate, "99/99/99"));
               AV66DDO_RestriccionesFechaAltaAuxDateTo = DateTimeUtil.ResetTime(AV64TFRestriccionesFechaAlta_To);
               AssignAttri("", false, "AV66DDO_RestriccionesFechaAltaAuxDateTo", context.localUtil.Format(AV66DDO_RestriccionesFechaAltaAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESESTADO_SEL") == 0 )
            {
               AV68TFRestriccionesEstado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFRestriccionesEstado_SelsJson", AV68TFRestriccionesEstado_SelsJson);
               AV69TFRestriccionesEstado_Sels.FromJSonString(AV68TFRestriccionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESOBSERVACION") == 0 )
            {
               AV70TFRestriccionesObservacion = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV70TFRestriccionesObservacion", AV70TFRestriccionesObservacion);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESOBSERVACION_SEL") == 0 )
            {
               AV71TFRestriccionesObservacion_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV71TFRestriccionesObservacion_Sel", AV71TFRestriccionesObservacion_Sel);
            }
            AV127GXV1 = (int)(AV127GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProfesionalesId_Sel)),  AV50TFProfesionalesId_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProfesionalesPrimerNombre_Sel)),  AV52TFProfesionalesPrimerNombre_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProfesionalesApellidoPrimero_Sel)),  AV54TFProfesionalesApellidoPrimero_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV58TFListaNombre_Sel)),  AV58TFListaNombre_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV60TFListaEstado_Sels.Count==0),  AV59TFListaEstado_SelsJson, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV62TFListaTipo_Sels.Count==0),  AV61TFListaTipo_SelsJson, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV69TFRestriccionesEstado_Sels.Count==0),  AV68TFRestriccionesEstado_SelsJson, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV71TFRestriccionesObservacion_Sel)),  AV71TFRestriccionesObservacion_Sel, out  GXt_char11) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"||"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"||"+GXt_char10+"|"+GXt_char11;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProfesionalesId)),  AV49TFProfesionalesId, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProfesionalesPrimerNombre)),  AV51TFProfesionalesPrimerNombre, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProfesionalesApellidoPrimero)),  AV53TFProfesionalesApellidoPrimero, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV57TFListaNombre)),  AV57TFListaNombre, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV70TFRestriccionesObservacion)),  AV70TFRestriccionesObservacion, out  GXt_char7) ;
         Ddo_grid_Filteredtext_set = ((0==AV47TFProfesionalesRestriccionId) ? "" : StringUtil.Str( (decimal)(AV47TFProfesionalesRestriccionId), 18, 0))+"|"+GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"|"+((0==AV55TFListaid) ? "" : StringUtil.Str( (decimal)(AV55TFListaid), 18, 0))+"|"+GXt_char8+"|||"+((DateTime.MinValue==AV63TFRestriccionesFechaAlta) ? "" : context.localUtil.DToC( AV65DDO_RestriccionesFechaAltaAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV48TFProfesionalesRestriccionId_To) ? "" : StringUtil.Str( (decimal)(AV48TFProfesionalesRestriccionId_To), 18, 0))+"||||"+((0==AV56TFListaid_To) ? "" : StringUtil.Str( (decimal)(AV56TFListaid_To), 18, 0))+"||||"+((DateTime.MinValue==AV64TFRestriccionesFechaAlta_To) ? "" : context.localUtil.DToC( AV66DDO_RestriccionesFechaAltaAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESTRICCIONESFECHAALTA") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20RestriccionesFechaAlta1 = context.localUtil.CToT( AV13GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV20RestriccionesFechaAlta1", context.localUtil.TToC( AV20RestriccionesFechaAlta1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV21RestriccionesFechaAlta_To1 = context.localUtil.CToT( AV13GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV21RestriccionesFechaAlta_To1", context.localUtil.TToC( AV21RestriccionesFechaAlta_To1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "LISTANOMBRE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV22ListaNombre1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV22ListaNombre1", AV22ListaNombre1);
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
               AV23DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "RESTRICCIONESFECHAALTA") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
                  AV26RestriccionesFechaAlta2 = context.localUtil.CToT( AV13GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "AV26RestriccionesFechaAlta2", context.localUtil.TToC( AV26RestriccionesFechaAlta2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
                  AV27RestriccionesFechaAlta_To2 = context.localUtil.CToT( AV13GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "AV27RestriccionesFechaAlta_To2", context.localUtil.TToC( AV27RestriccionesFechaAlta_To2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "LISTANOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
                  AV28ListaNombre2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV28ListaNombre2", AV28ListaNombre2);
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
                  AV29DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV29DynamicFiltersEnabled3", AV29DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESTRICCIONESFECHAALTA") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV32RestriccionesFechaAlta3 = context.localUtil.CToT( AV13GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AssignAttri("", false, "AV32RestriccionesFechaAlta3", context.localUtil.TToC( AV32RestriccionesFechaAlta3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
                     AV33RestriccionesFechaAlta_To3 = context.localUtil.CToT( AV13GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AssignAttri("", false, "AV33RestriccionesFechaAlta_To3", context.localUtil.TToC( AV33RestriccionesFechaAlta_To3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "LISTANOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
                     AV34ListaNombre3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV34ListaNombre3", AV34ListaNombre3);
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
         if ( AV35DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV43Session.Get(AV88Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPROFESIONALESRESTRICCIONID",  context.GetMessage( "Restriccion Id", ""),  !((0==AV47TFProfesionalesRestriccionId)&&(0==AV48TFProfesionalesRestriccionId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFProfesionalesRestriccionId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFProfesionalesRestriccionId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESID",  context.GetMessage( "Identidad", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProfesionalesId)),  0,  AV49TFProfesionalesId,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProfesionalesId_Sel)),  AV50TFProfesionalesId_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESPRIMERNOMBRE",  context.GetMessage( "Primer Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProfesionalesPrimerNombre)),  0,  AV51TFProfesionalesPrimerNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProfesionalesPrimerNombre_Sel)),  AV52TFProfesionalesPrimerNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESAPELLIDOPRIMERO",  context.GetMessage( "Primer Apellido ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProfesionalesApellidoPrimero)),  0,  AV53TFProfesionalesApellidoPrimero,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProfesionalesApellidoPrimero_Sel)),  AV54TFProfesionalesApellidoPrimero_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFLISTAID",  context.GetMessage( "Listaid", ""),  !((0==AV55TFListaid)&&(0==AV56TFListaid_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV55TFListaid), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV56TFListaid_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFLISTANOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV57TFListaNombre)),  0,  AV57TFListaNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV58TFListaNombre_Sel)),  AV58TFListaNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFLISTAESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV60TFListaEstado_Sels.Count==0),  0,  AV60TFListaEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFLISTATIPO_SEL",  context.GetMessage( "Tipo", ""),  !(AV62TFListaTipo_Sels.Count==0),  0,  AV62TFListaTipo_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFRESTRICCIONESFECHAALTA",  context.GetMessage( "Fecha Alta", ""),  !((DateTime.MinValue==AV63TFRestriccionesFechaAlta)&&(DateTime.MinValue==AV64TFRestriccionesFechaAlta_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV63TFRestriccionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV64TFRestriccionesFechaAlta_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFRESTRICCIONESESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV69TFRestriccionesEstado_Sels.Count==0),  0,  AV69TFRestriccionesEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFRESTRICCIONESOBSERVACION",  context.GetMessage( "Observacion", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV70TFRestriccionesObservacion)),  0,  AV70TFRestriccionesObservacion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV71TFRestriccionesObservacion_Sel)),  AV71TFRestriccionesObservacion_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV88Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV36DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RESTRICCIONESFECHAALTA") == 0 ) && ! ( (DateTime.MinValue==AV20RestriccionesFechaAlta1) && (DateTime.MinValue==AV21RestriccionesFechaAlta_To1) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Fecha Alta", "");
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.TToC( AV20RestriccionesFechaAlta1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.TToC( AV21RestriccionesFechaAlta_To1, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "LISTANOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ListaNombre1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Lista Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV22ListaNombre1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            if ( AV35DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV23DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV24DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "RESTRICCIONESFECHAALTA") == 0 ) && ! ( (DateTime.MinValue==AV26RestriccionesFechaAlta2) && (DateTime.MinValue==AV27RestriccionesFechaAlta_To2) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Fecha Alta", "");
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.TToC( AV26RestriccionesFechaAlta2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV25DynamicFiltersOperator2;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.TToC( AV27RestriccionesFechaAlta_To2, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "LISTANOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ListaNombre2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Lista Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV28ListaNombre2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV25DynamicFiltersOperator2;
            }
            if ( AV35DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV29DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV30DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RESTRICCIONESFECHAALTA") == 0 ) && ! ( (DateTime.MinValue==AV32RestriccionesFechaAlta3) && (DateTime.MinValue==AV33RestriccionesFechaAlta_To3) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Fecha Alta", "");
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.TToC( AV32RestriccionesFechaAlta3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV31DynamicFiltersOperator3;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.TToC( AV33RestriccionesFechaAlta_To3, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
            }
            else if ( ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "LISTANOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ListaNombre3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Lista Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV34ListaNombre3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV31DynamicFiltersOperator3;
            }
            if ( AV35DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Valueto)) )
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
         AV9TrnContext.gxTpr_Callerobject = AV88Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "ProfesionalesRestriccion";
         AV43Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S322( )
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
         new profesionalesrestriccionwwexport(context ).execute( out  AV37ExcelFilename, out  AV38ErrorMessage) ;
         if ( StringUtil.StrCmp(AV37ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV37ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV38ErrorMessage);
         }
      }

      protected void S332( )
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
         Innewwindow1_Target = formatLink("profesionalesrestriccionwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_105_KW2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR3.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "", true, 0, "HLP_ProfesionalesRestriccionWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_restriccionesfechaalta3_cell_Internalname+"\"  class=''>") ;
            wb_table5_111_KW2( true) ;
         }
         else
         {
            wb_table5_111_KW2( false) ;
         }
         return  ;
      }

      protected void wb_table5_111_KW2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_listanombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavListanombre3_Internalname, context.GetMessage( "Lista Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavListanombre3_Internalname, StringUtil.RTrim( AV34ListaNombre3), StringUtil.RTrim( context.localUtil.Format( AV34ListaNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavListanombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavListanombre3_Visible, edtavListanombre3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesRestriccionWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_105_KW2e( true) ;
         }
         else
         {
            wb_table4_105_KW2e( false) ;
         }
      }

      protected void wb_table5_111_KW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersrestriccionesfechaalta3_Internalname, tblTablemergeddynamicfiltersrestriccionesfechaalta3_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellRestriccionesfechaalta_range_cell3_Internalname+"\"  class='"+cellRestriccionesfechaalta_range_cell3_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRestriccionesfechaalta_rangetext3_Internalname, context.GetMessage( "Restricciones Fecha Alta_Range Text3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRestriccionesfechaalta_rangetext3_Internalname, AV87RestriccionesFechaAlta_RangeText3, StringUtil.RTrim( context.localUtil.Format( AV87RestriccionesFechaAlta_RangeText3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRestriccionesfechaalta_rangetext3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRestriccionesfechaalta_rangetext3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_111_KW2e( true) ;
         }
         else
         {
            wb_table5_111_KW2e( false) ;
         }
      }

      protected void wb_table3_77_KW2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR2.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", true, 0, "HLP_ProfesionalesRestriccionWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_restriccionesfechaalta2_cell_Internalname+"\"  class=''>") ;
            wb_table6_83_KW2( true) ;
         }
         else
         {
            wb_table6_83_KW2( false) ;
         }
         return  ;
      }

      protected void wb_table6_83_KW2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_listanombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavListanombre2_Internalname, context.GetMessage( "Lista Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavListanombre2_Internalname, StringUtil.RTrim( AV28ListaNombre2), StringUtil.RTrim( context.localUtil.Format( AV28ListaNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavListanombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavListanombre2_Visible, edtavListanombre2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesRestriccionWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesRestriccionWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_77_KW2e( true) ;
         }
         else
         {
            wb_table3_77_KW2e( false) ;
         }
      }

      protected void wb_table6_83_KW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersrestriccionesfechaalta2_Internalname, tblTablemergeddynamicfiltersrestriccionesfechaalta2_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellRestriccionesfechaalta_range_cell2_Internalname+"\"  class='"+cellRestriccionesfechaalta_range_cell2_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRestriccionesfechaalta_rangetext2_Internalname, context.GetMessage( "Restricciones Fecha Alta_Range Text2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRestriccionesfechaalta_rangetext2_Internalname, AV86RestriccionesFechaAlta_RangeText2, StringUtil.RTrim( context.localUtil.Format( AV86RestriccionesFechaAlta_RangeText2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRestriccionesfechaalta_rangetext2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRestriccionesfechaalta_rangetext2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_83_KW2e( true) ;
         }
         else
         {
            wb_table6_83_KW2e( false) ;
         }
      }

      protected void wb_table2_49_KW2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR1.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_ProfesionalesRestriccionWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_restriccionesfechaalta1_cell_Internalname+"\"  class=''>") ;
            wb_table7_55_KW2( true) ;
         }
         else
         {
            wb_table7_55_KW2( false) ;
         }
         return  ;
      }

      protected void wb_table7_55_KW2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_listanombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavListanombre1_Internalname, context.GetMessage( "Lista Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavListanombre1_Internalname, StringUtil.RTrim( AV22ListaNombre1), StringUtil.RTrim( context.localUtil.Format( AV22ListaNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavListanombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavListanombre1_Visible, edtavListanombre1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesRestriccionWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesRestriccionWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_KW2e( true) ;
         }
         else
         {
            wb_table2_49_KW2e( false) ;
         }
      }

      protected void wb_table7_55_KW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersrestriccionesfechaalta1_Internalname, tblTablemergeddynamicfiltersrestriccionesfechaalta1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellRestriccionesfechaalta_range_cell1_Internalname+"\"  class='"+cellRestriccionesfechaalta_range_cell1_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRestriccionesfechaalta_rangetext1_Internalname, context.GetMessage( "Restricciones Fecha Alta_Range Text1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRestriccionesfechaalta_rangetext1_Internalname, AV85RestriccionesFechaAlta_RangeText1, StringUtil.RTrim( context.localUtil.Format( AV85RestriccionesFechaAlta_RangeText1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRestriccionesfechaalta_rangetext1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRestriccionesfechaalta_rangetext1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_55_KW2e( true) ;
         }
         else
         {
            wb_table7_55_KW2e( false) ;
         }
      }

      protected void wb_table1_25_KW2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV44ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table8_30_KW2( true) ;
         }
         else
         {
            wb_table8_30_KW2( false) ;
         }
         return  ;
      }

      protected void wb_table8_30_KW2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_KW2e( true) ;
         }
         else
         {
            wb_table1_25_KW2e( false) ;
         }
      }

      protected void wb_table8_30_KW2( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ProfesionalesRestriccionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_30_KW2e( true) ;
         }
         else
         {
            wb_table8_30_KW2e( false) ;
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
         PAKW2( ) ;
         WSKW2( ) ;
         WEKW2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932019479", true, true, false);
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
         context.AddJavascriptSource("profesionalesrestriccionww.js", "?2026932019480", false, true, false);
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

      protected void SubsflControlProps_1292( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_129_idx;
         edtProfesionalesRestriccionId_Internalname = "PROFESIONALESRESTRICCIONID_"+sGXsfl_129_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_129_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_129_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_129_idx;
         edtListaid_Internalname = "LISTAID_"+sGXsfl_129_idx;
         edtListaNombre_Internalname = "LISTANOMBRE_"+sGXsfl_129_idx;
         cmbListaEstado_Internalname = "LISTAESTADO_"+sGXsfl_129_idx;
         cmbListaTipo_Internalname = "LISTATIPO_"+sGXsfl_129_idx;
         edtRestriccionesFechaAlta_Internalname = "RESTRICCIONESFECHAALTA_"+sGXsfl_129_idx;
         cmbRestriccionesEstado_Internalname = "RESTRICCIONESESTADO_"+sGXsfl_129_idx;
         edtRestriccionesObservacion_Internalname = "RESTRICCIONESOBSERVACION_"+sGXsfl_129_idx;
      }

      protected void SubsflControlProps_fel_1292( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_129_fel_idx;
         edtProfesionalesRestriccionId_Internalname = "PROFESIONALESRESTRICCIONID_"+sGXsfl_129_fel_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_129_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_129_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_129_fel_idx;
         edtListaid_Internalname = "LISTAID_"+sGXsfl_129_fel_idx;
         edtListaNombre_Internalname = "LISTANOMBRE_"+sGXsfl_129_fel_idx;
         cmbListaEstado_Internalname = "LISTAESTADO_"+sGXsfl_129_fel_idx;
         cmbListaTipo_Internalname = "LISTATIPO_"+sGXsfl_129_fel_idx;
         edtRestriccionesFechaAlta_Internalname = "RESTRICCIONESFECHAALTA_"+sGXsfl_129_fel_idx;
         cmbRestriccionesEstado_Internalname = "RESTRICCIONESESTADO_"+sGXsfl_129_fel_idx;
         edtRestriccionesObservacion_Internalname = "RESTRICCIONESOBSERVACION_"+sGXsfl_129_fel_idx;
      }

      protected void sendrow_1292( )
      {
         sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
         SubsflControlProps_1292( ) ;
         WBKW0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'" + sGXsfl_129_idx + "',129)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_129_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV77GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV77GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV77GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV77GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_129_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV77GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_129_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtProfesionalesRestriccionId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesRestriccionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A976ProfesionalesRestriccionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A976ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesRestriccionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProfesionalesRestriccionId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProfesionalesId_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesPrimerNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProfesionalesPrimerNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesApellidoPrimero_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProfesionalesApellidoPrimero_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtListaid_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A590Listaid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtListaid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtListaid_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtListaNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaNombre_Internalname,StringUtil.RTrim( A592ListaNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtListaNombre_Link,(string)"",(string)"",(string)"",(string)edtListaNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtListaNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbListaEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            GXCCtl = "LISTAESTADO_" + sGXsfl_129_idx;
            cmbListaEstado.Name = GXCCtl;
            cmbListaEstado.WebTags = "";
            cmbListaEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
            cmbListaEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
            cmbListaEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
            cmbListaEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
            if ( cmbListaEstado.ItemCount > 0 )
            {
               A593ListaEstado = cmbListaEstado.getValidValue(A593ListaEstado);
               n593ListaEstado = false;
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbListaEstado,(string)cmbListaEstado_Internalname,StringUtil.RTrim( A593ListaEstado),(short)1,(string)cmbListaEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbListaEstado.Visible,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbListaEstado.CurrentValue = StringUtil.RTrim( A593ListaEstado);
            AssignProp("", false, cmbListaEstado_Internalname, "Values", (string)(cmbListaEstado.ToJavascriptSource()), !bGXsfl_129_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbListaTipo.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            GXCCtl = "LISTATIPO_" + sGXsfl_129_idx;
            cmbListaTipo.Name = GXCCtl;
            cmbListaTipo.WebTags = "";
            cmbListaTipo.addItem("PROV", context.GetMessage( "Proveedor", ""), 0);
            cmbListaTipo.addItem("PROF", context.GetMessage( "Profesional", ""), 0);
            cmbListaTipo.addItem("ADM", context.GetMessage( "Administrativa", ""), 0);
            cmbListaTipo.addItem("RST", context.GetMessage( "Restriccion", ""), 0);
            if ( cmbListaTipo.ItemCount > 0 )
            {
               A591ListaTipo = cmbListaTipo.getValidValue(A591ListaTipo);
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbListaTipo,(string)cmbListaTipo_Internalname,StringUtil.RTrim( A591ListaTipo),(short)1,(string)cmbListaTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbListaTipo.Visible,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbListaTipo.CurrentValue = StringUtil.RTrim( A591ListaTipo);
            AssignProp("", false, cmbListaTipo_Internalname, "Values", (string)(cmbListaTipo.ToJavascriptSource()), !bGXsfl_129_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtRestriccionesFechaAlta_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRestriccionesFechaAlta_Internalname,context.localUtil.TToC( A973RestriccionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A973RestriccionesFechaAlta, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtRestriccionesFechaAlta_Link,(string)"",(string)"",(string)"",(string)edtRestriccionesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtRestriccionesFechaAlta_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbRestriccionesEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbRestriccionesEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "RESTRICCIONESESTADO_" + sGXsfl_129_idx;
               cmbRestriccionesEstado.Name = GXCCtl;
               cmbRestriccionesEstado.WebTags = "";
               cmbRestriccionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbRestriccionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbRestriccionesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbRestriccionesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbRestriccionesEstado.ItemCount > 0 )
               {
                  A974RestriccionesEstado = cmbRestriccionesEstado.getValidValue(A974RestriccionesEstado);
                  n974RestriccionesEstado = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbRestriccionesEstado,(string)cmbRestriccionesEstado_Internalname,StringUtil.RTrim( A974RestriccionesEstado),(short)1,(string)cmbRestriccionesEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbRestriccionesEstado.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbRestriccionesEstado.CurrentValue = StringUtil.RTrim( A974RestriccionesEstado);
            AssignProp("", false, cmbRestriccionesEstado_Internalname, "Values", (string)(cmbRestriccionesEstado.ToJavascriptSource()), !bGXsfl_129_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtRestriccionesObservacion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRestriccionesObservacion_Internalname,(string)A975RestriccionesObservacion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRestriccionesObservacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtRestriccionesObservacion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesKW2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("RESTRICCIONESFECHAALTA", context.GetMessage( "Fecha Alta", ""), 0);
         cmbavDynamicfiltersselector1.addItem("LISTANOMBRE", context.GetMessage( "Lista Nombre", ""), 0);
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
         cmbavDynamicfiltersselector2.addItem("RESTRICCIONESFECHAALTA", context.GetMessage( "Fecha Alta", ""), 0);
         cmbavDynamicfiltersselector2.addItem("LISTANOMBRE", context.GetMessage( "Lista Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV24DynamicFiltersSelector2);
            AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterPast", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterToday", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("2", context.GetMessage( "WWP_FilterInTheFuture", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("3", context.GetMessage( "WWP_FilterRange", ""), 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("RESTRICCIONESFECHAALTA", context.GetMessage( "Fecha Alta", ""), 0);
         cmbavDynamicfiltersselector3.addItem("LISTANOMBRE", context.GetMessage( "Lista Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV30DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV30DynamicFiltersSelector3);
            AssignAttri("", false, "AV30DynamicFiltersSelector3", AV30DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterPast", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterToday", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("2", context.GetMessage( "WWP_FilterInTheFuture", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("3", context.GetMessage( "WWP_FilterRange", ""), 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV31DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV31DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV31DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_129_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV77GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV77GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV77GridActions), 4, 0));
         }
         GXCCtl = "LISTAESTADO_" + sGXsfl_129_idx;
         cmbListaEstado.Name = GXCCtl;
         cmbListaEstado.WebTags = "";
         cmbListaEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbListaEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbListaEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbListaEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbListaEstado.ItemCount > 0 )
         {
            A593ListaEstado = cmbListaEstado.getValidValue(A593ListaEstado);
            n593ListaEstado = false;
         }
         GXCCtl = "LISTATIPO_" + sGXsfl_129_idx;
         cmbListaTipo.Name = GXCCtl;
         cmbListaTipo.WebTags = "";
         cmbListaTipo.addItem("PROV", context.GetMessage( "Proveedor", ""), 0);
         cmbListaTipo.addItem("PROF", context.GetMessage( "Profesional", ""), 0);
         cmbListaTipo.addItem("ADM", context.GetMessage( "Administrativa", ""), 0);
         cmbListaTipo.addItem("RST", context.GetMessage( "Restriccion", ""), 0);
         if ( cmbListaTipo.ItemCount > 0 )
         {
            A591ListaTipo = cmbListaTipo.getValidValue(A591ListaTipo);
         }
         GXCCtl = "RESTRICCIONESESTADO_" + sGXsfl_129_idx;
         cmbRestriccionesEstado.Name = GXCCtl;
         cmbRestriccionesEstado.WebTags = "";
         cmbRestriccionesEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbRestriccionesEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbRestriccionesEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbRestriccionesEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbRestriccionesEstado.ItemCount > 0 )
         {
            A974RestriccionesEstado = cmbRestriccionesEstado.getValidValue(A974RestriccionesEstado);
            n974RestriccionesEstado = false;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesRestriccionId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Restriccion Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesPrimerNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Primer Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesApellidoPrimero_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Primer Apellido ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtListaid_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Listaid", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtListaNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbListaEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbListaTipo.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtRestriccionesFechaAlta_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbRestriccionesEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtRestriccionesObservacion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Observacion", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV77GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A976ProfesionalesRestriccionId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesRestriccionId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A167ProfesionalesApellidoPrimero)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A590Listaid), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaid_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A592ListaNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtListaNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A593ListaEstado)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbListaEstado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A591ListaTipo)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbListaTipo.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A973RestriccionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtRestriccionesFechaAlta_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRestriccionesFechaAlta_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A974RestriccionesEstado)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbRestriccionesEstado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A975RestriccionesObservacion));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRestriccionesObservacion_Visible), 5, 0, ".", "")));
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
         edtavRestriccionesfechaalta_rangetext1_Internalname = "vRESTRICCIONESFECHAALTA_RANGETEXT1";
         cellRestriccionesfechaalta_range_cell1_Internalname = "RESTRICCIONESFECHAALTA_RANGE_CELL1";
         tblTablemergeddynamicfiltersrestriccionesfechaalta1_Internalname = "TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA1";
         cellFilter_restriccionesfechaalta1_cell_Internalname = "FILTER_RESTRICCIONESFECHAALTA1_CELL";
         edtavListanombre1_Internalname = "vLISTANOMBRE1";
         cellFilter_listanombre1_cell_Internalname = "FILTER_LISTANOMBRE1_CELL";
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
         edtavRestriccionesfechaalta_rangetext2_Internalname = "vRESTRICCIONESFECHAALTA_RANGETEXT2";
         cellRestriccionesfechaalta_range_cell2_Internalname = "RESTRICCIONESFECHAALTA_RANGE_CELL2";
         tblTablemergeddynamicfiltersrestriccionesfechaalta2_Internalname = "TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA2";
         cellFilter_restriccionesfechaalta2_cell_Internalname = "FILTER_RESTRICCIONESFECHAALTA2_CELL";
         edtavListanombre2_Internalname = "vLISTANOMBRE2";
         cellFilter_listanombre2_cell_Internalname = "FILTER_LISTANOMBRE2_CELL";
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
         edtavRestriccionesfechaalta_rangetext3_Internalname = "vRESTRICCIONESFECHAALTA_RANGETEXT3";
         cellRestriccionesfechaalta_range_cell3_Internalname = "RESTRICCIONESFECHAALTA_RANGE_CELL3";
         tblTablemergeddynamicfiltersrestriccionesfechaalta3_Internalname = "TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA3";
         cellFilter_restriccionesfechaalta3_cell_Internalname = "FILTER_RESTRICCIONESFECHAALTA3_CELL";
         edtavListanombre3_Internalname = "vLISTANOMBRE3";
         cellFilter_listanombre3_cell_Internalname = "FILTER_LISTANOMBRE3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtProfesionalesRestriccionId_Internalname = "PROFESIONALESRESTRICCIONID";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtListaid_Internalname = "LISTAID";
         edtListaNombre_Internalname = "LISTANOMBRE";
         cmbListaEstado_Internalname = "LISTAESTADO";
         cmbListaTipo_Internalname = "LISTATIPO";
         edtRestriccionesFechaAlta_Internalname = "RESTRICCIONESFECHAALTA";
         cmbRestriccionesEstado_Internalname = "RESTRICCIONESESTADO";
         edtRestriccionesObservacion_Internalname = "RESTRICCIONESOBSERVACION";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Restriccionesfechaalta_rangepicker1_Internalname = "RESTRICCIONESFECHAALTA_RANGEPICKER1";
         Restriccionesfechaalta_rangepicker2_Internalname = "RESTRICCIONESFECHAALTA_RANGEPICKER2";
         Restriccionesfechaalta_rangepicker3_Internalname = "RESTRICCIONESFECHAALTA_RANGEPICKER3";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_restriccionesfechaaltaauxdatetext_Internalname = "vDDO_RESTRICCIONESFECHAALTAAUXDATETEXT";
         Tfrestriccionesfechaalta_rangepicker_Internalname = "TFRESTRICCIONESFECHAALTA_RANGEPICKER";
         divDdo_restriccionesfechaaltaauxdates_Internalname = "DDO_RESTRICCIONESFECHAALTAAUXDATES";
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
         edtRestriccionesObservacion_Jsonclick = "";
         cmbRestriccionesEstado_Jsonclick = "";
         edtRestriccionesFechaAlta_Jsonclick = "";
         edtRestriccionesFechaAlta_Link = "";
         cmbListaTipo_Jsonclick = "";
         cmbListaEstado_Jsonclick = "";
         edtListaNombre_Jsonclick = "";
         edtListaNombre_Link = "";
         edtListaid_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesId_Jsonclick = "";
         edtProfesionalesRestriccionId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavRestriccionesfechaalta_rangetext1_Jsonclick = "";
         edtavRestriccionesfechaalta_rangetext1_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavListanombre1_Jsonclick = "";
         edtavListanombre1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         edtavRestriccionesfechaalta_rangetext2_Jsonclick = "";
         edtavRestriccionesfechaalta_rangetext2_Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavListanombre2_Jsonclick = "";
         edtavListanombre2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavRestriccionesfechaalta_rangetext3_Jsonclick = "";
         edtavRestriccionesfechaalta_rangetext3_Enabled = 1;
         edtavListanombre3_Jsonclick = "";
         edtavListanombre3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cellRestriccionesfechaalta_range_cell3_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavListanombre3_Visible = 1;
         tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible = 1;
         cellRestriccionesfechaalta_range_cell2_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavListanombre2_Visible = 1;
         tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible = 1;
         cellRestriccionesfechaalta_range_cell1_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavListanombre1_Visible = 1;
         tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible = 1;
         edtRestriccionesObservacion_Visible = -1;
         cmbRestriccionesEstado.Visible = -1;
         edtRestriccionesFechaAlta_Visible = -1;
         cmbListaTipo.Visible = -1;
         cmbListaEstado.Visible = -1;
         edtListaNombre_Visible = -1;
         edtListaid_Visible = -1;
         edtProfesionalesApellidoPrimero_Visible = -1;
         edtProfesionalesPrimerNombre_Visible = -1;
         edtProfesionalesId_Visible = -1;
         edtProfesionalesRestriccionId_Visible = -1;
         edtRestriccionesObservacion_Enabled = 0;
         cmbRestriccionesEstado.Enabled = 0;
         edtRestriccionesFechaAlta_Enabled = 0;
         cmbListaTipo.Enabled = 0;
         cmbListaEstado.Enabled = 0;
         edtListaNombre_Enabled = 0;
         edtListaid_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesRestriccionId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_restriccionesfechaaltaauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = context.GetMessage( "JSDynamicFilters", "");
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
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
         Ddo_grid_Format = "18.0||||18.0||||||";
         Ddo_grid_Datalistproc = "ProfesionalesRestriccionWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||HAB:Habilitado,DES:Deshabilitado,PEN:Pendiente|PROV:Proveedor,PROF:Profesional,ADM:Administrativa,RST:Restriccion||HAB:Habilitado,DES:Deshabilitado,PEN:Pendiente|";
         Ddo_grid_Allowmultipleselection = "||||||T|T||T|";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic||Dynamic|FixedValues|FixedValues||FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T||T|T|T||T|T";
         Ddo_grid_Filterisrange = "T||||T||||P||";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Numeric|Character|||Date||Character";
         Ddo_grid_Includefilter = "T|T|T|T|T|T|||T||T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7|8|9|1|10|11";
         Ddo_grid_Columnids = "1:ProfesionalesRestriccionId|2:ProfesionalesId|3:ProfesionalesPrimerNombre|4:ProfesionalesApellidoPrimero|5:Listaid|6:ListaNombre|7:ListaEstado|8:ListaTipo|9:RestriccionesFechaAlta|10:RestriccionesEstado|11:RestriccionesObservacion";
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
         Form.Caption = context.GetMessage( " Lista Profesionales Restriccion", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E19KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV68TFRestriccionesEstado_SelsJson',fld:'vTFRESTRICCIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV61TFListaTipo_SelsJson',fld:'vTFLISTATIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV59TFListaEstado_SelsJson',fld:'vTFLISTAESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E35KW2',iparms:[{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A590Listaid',fld:'LISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A976ProfesionalesRestriccionId',fld:'PROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV77GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtListaNombre_Link',ctrl:'LISTANOMBRE',prop:'Link'},{av:'edtRestriccionesFechaAlta_Link',ctrl:'RESTRICCIONESFECHAALTA',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E20KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E25KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E21KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA2',prop:'Visible'},{av:'edtavListanombre2_Visible',ctrl:'vLISTANOMBRE2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA3',prop:'Visible'},{av:'edtavListanombre3_Visible',ctrl:'vLISTANOMBRE3',prop:'Visible'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA1',prop:'Visible'},{av:'edtavListanombre1_Visible',ctrl:'vLISTANOMBRE1',prop:'Visible'},{av:'cellRestriccionesfechaalta_range_cell2_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL2',prop:'Class'},{av:'cellRestriccionesfechaalta_range_cell3_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL3',prop:'Class'},{av:'cellRestriccionesfechaalta_range_cell1_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL1',prop:'Class'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E26KW2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA1',prop:'Visible'},{av:'edtavListanombre1_Visible',ctrl:'vLISTANOMBRE1',prop:'Visible'},{av:'cellRestriccionesfechaalta_range_cell1_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL1',prop:'Class'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'}]}");
         setEventMetadata("RESTRICCIONESFECHAALTA_RANGEPICKER1.DATERANGECHANGED","{handler:'E16KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("RESTRICCIONESFECHAALTA_RANGEPICKER1.DATERANGECHANGED",",oparms:[{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK","{handler:'E27KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK",",oparms:[{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'cellRestriccionesfechaalta_range_cell1_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL1',prop:'Class'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E28KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E22KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA2',prop:'Visible'},{av:'edtavListanombre2_Visible',ctrl:'vLISTANOMBRE2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA3',prop:'Visible'},{av:'edtavListanombre3_Visible',ctrl:'vLISTANOMBRE3',prop:'Visible'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA1',prop:'Visible'},{av:'edtavListanombre1_Visible',ctrl:'vLISTANOMBRE1',prop:'Visible'},{av:'cellRestriccionesfechaalta_range_cell2_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL2',prop:'Class'},{av:'cellRestriccionesfechaalta_range_cell3_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL3',prop:'Class'},{av:'cellRestriccionesfechaalta_range_cell1_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL1',prop:'Class'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E29KW2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA2',prop:'Visible'},{av:'edtavListanombre2_Visible',ctrl:'vLISTANOMBRE2',prop:'Visible'},{av:'cellRestriccionesfechaalta_range_cell2_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL2',prop:'Class'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'}]}");
         setEventMetadata("RESTRICCIONESFECHAALTA_RANGEPICKER2.DATERANGECHANGED","{handler:'E17KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("RESTRICCIONESFECHAALTA_RANGEPICKER2.DATERANGECHANGED",",oparms:[{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK","{handler:'E30KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK",",oparms:[{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'cellRestriccionesfechaalta_range_cell2_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL2',prop:'Class'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E23KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA2',prop:'Visible'},{av:'edtavListanombre2_Visible',ctrl:'vLISTANOMBRE2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA3',prop:'Visible'},{av:'edtavListanombre3_Visible',ctrl:'vLISTANOMBRE3',prop:'Visible'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA1',prop:'Visible'},{av:'edtavListanombre1_Visible',ctrl:'vLISTANOMBRE1',prop:'Visible'},{av:'cellRestriccionesfechaalta_range_cell2_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL2',prop:'Class'},{av:'cellRestriccionesfechaalta_range_cell3_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL3',prop:'Class'},{av:'cellRestriccionesfechaalta_range_cell1_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL1',prop:'Class'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E31KW2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA3',prop:'Visible'},{av:'edtavListanombre3_Visible',ctrl:'vLISTANOMBRE3',prop:'Visible'},{av:'cellRestriccionesfechaalta_range_cell3_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL3',prop:'Class'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'}]}");
         setEventMetadata("RESTRICCIONESFECHAALTA_RANGEPICKER3.DATERANGECHANGED","{handler:'E18KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("RESTRICCIONESFECHAALTA_RANGEPICKER3.DATERANGECHANGED",",oparms:[{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK","{handler:'E32KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK",",oparms:[{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'cellRestriccionesfechaalta_range_cell3_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL3',prop:'Class'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11KW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV59TFListaEstado_SelsJson',fld:'vTFLISTAESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV61TFListaTipo_SelsJson',fld:'vTFLISTATIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV68TFRestriccionesEstado_SelsJson',fld:'vTFRESTRICCIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV65DDO_RestriccionesFechaAltaAuxDate',fld:'vDDO_RESTRICCIONESFECHAALTAAUXDATE',pic:'',type:'date'},{av:'AV66DDO_RestriccionesFechaAltaAuxDateTo',fld:'vDDO_RESTRICCIONESFECHAALTAAUXDATETO',pic:'',type:'date'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV68TFRestriccionesEstado_SelsJson',fld:'vTFRESTRICCIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV65DDO_RestriccionesFechaAltaAuxDate',fld:'vDDO_RESTRICCIONESFECHAALTAAUXDATE',pic:'',type:'date'},{av:'AV66DDO_RestriccionesFechaAltaAuxDateTo',fld:'vDDO_RESTRICCIONESFECHAALTAAUXDATETO',pic:'',type:'date'},{av:'AV61TFListaTipo_SelsJson',fld:'vTFLISTATIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV59TFListaEstado_SelsJson',fld:'vTFLISTAESTADO_SELSJSON',pic:'',type:'vchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA1',prop:'Visible'},{av:'edtavListanombre1_Visible',ctrl:'vLISTANOMBRE1',prop:'Visible'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA2',prop:'Visible'},{av:'edtavListanombre2_Visible',ctrl:'vLISTANOMBRE2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA3',prop:'Visible'},{av:'edtavListanombre3_Visible',ctrl:'vLISTANOMBRE3',prop:'Visible'},{av:'cellRestriccionesfechaalta_range_cell1_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL1',prop:'Class'},{av:'cellRestriccionesfechaalta_range_cell2_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL2',prop:'Class'},{av:'cellRestriccionesfechaalta_range_cell3_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL3',prop:'Class'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E36KW2',iparms:[{av:'cmbavGridactions'},{av:'AV77GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A976ProfesionalesRestriccionId',fld:'PROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV77GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E24KW2',iparms:[{av:'A976ProfesionalesRestriccionId',fld:'PROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14KW2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV59TFListaEstado_SelsJson',fld:'vTFLISTAESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV61TFListaTipo_SelsJson',fld:'vTFLISTATIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV68TFRestriccionesEstado_SelsJson',fld:'vTFRESTRICCIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV65DDO_RestriccionesFechaAltaAuxDate',fld:'vDDO_RESTRICCIONESFECHAALTAAUXDATE',pic:'',type:'date'},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV66DDO_RestriccionesFechaAltaAuxDateTo',fld:'vDDO_RESTRICCIONESFECHAALTAAUXDATETO',pic:'',type:'date'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV22ListaNombre1',fld:'vLISTANOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV24DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV25DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV28ListaNombre2',fld:'vLISTANOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV30DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV31DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV34ListaNombre3',fld:'vLISTANOMBRE3',pic:'',type:'char'},{av:'AV20RestriccionesFechaAlta1',fld:'vRESTRICCIONESFECHAALTA1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV26RestriccionesFechaAlta2',fld:'vRESTRICCIONESFECHAALTA2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32RestriccionesFechaAlta3',fld:'vRESTRICCIONESFECHAALTA3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV23DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV29DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV88Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21RestriccionesFechaAlta_To1',fld:'vRESTRICCIONESFECHAALTA_TO1',pic:'99/99/99 99:99',type:'dtime'},{av:'AV27RestriccionesFechaAlta_To2',fld:'vRESTRICCIONESFECHAALTA_TO2',pic:'99/99/99 99:99',type:'dtime'},{av:'AV33RestriccionesFechaAlta_To3',fld:'vRESTRICCIONESFECHAALTA_TO3',pic:'99/99/99 99:99',type:'dtime'},{av:'AV47TFProfesionalesRestriccionId',fld:'vTFPROFESIONALESRESTRICCIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProfesionalesRestriccionId_To',fld:'vTFPROFESIONALESRESTRICCIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV50TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFListaid',fld:'vTFLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV56TFListaid_To',fld:'vTFLISTAID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFListaNombre',fld:'vTFLISTANOMBRE',pic:'',type:'char'},{av:'AV58TFListaNombre_Sel',fld:'vTFLISTANOMBRE_SEL',pic:'',type:'char'},{av:'AV60TFListaEstado_Sels',fld:'vTFLISTAESTADO_SELS',pic:''},{av:'AV62TFListaTipo_Sels',fld:'vTFLISTATIPO_SELS',pic:''},{av:'AV63TFRestriccionesFechaAlta',fld:'vTFRESTRICCIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV64TFRestriccionesFechaAlta_To',fld:'vTFRESTRICCIONESFECHAALTA_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFRestriccionesEstado_Sels',fld:'vTFRESTRICCIONESESTADO_SELS',pic:''},{av:'AV70TFRestriccionesObservacion',fld:'vTFRESTRICCIONESOBSERVACION',pic:'',type:'svchar'},{av:'AV71TFRestriccionesObservacion_Sel',fld:'vTFRESTRICCIONESOBSERVACION_SEL',pic:'',type:'svchar'},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV79IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV80IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV81IsAuthorized_ListaNombre',fld:'vISAUTHORIZED_LISTANOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true,type:'date'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV68TFRestriccionesEstado_SelsJson',fld:'vTFRESTRICCIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV65DDO_RestriccionesFechaAltaAuxDate',fld:'vDDO_RESTRICCIONESFECHAALTAAUXDATE',pic:'',type:'date'},{av:'AV66DDO_RestriccionesFechaAltaAuxDateTo',fld:'vDDO_RESTRICCIONESFECHAALTAAUXDATETO',pic:'',type:'date'},{av:'AV61TFListaTipo_SelsJson',fld:'vTFLISTATIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV59TFListaEstado_SelsJson',fld:'vTFLISTAESTADO_SELSJSON',pic:'',type:'vchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA1',prop:'Visible'},{av:'edtavListanombre1_Visible',ctrl:'vLISTANOMBRE1',prop:'Visible'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA2',prop:'Visible'},{av:'edtavListanombre2_Visible',ctrl:'vLISTANOMBRE2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSRESTRICCIONESFECHAALTA3',prop:'Visible'},{av:'edtavListanombre3_Visible',ctrl:'vLISTANOMBRE3',prop:'Visible'},{av:'cellRestriccionesfechaalta_range_cell1_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL1',prop:'Class'},{av:'cellRestriccionesfechaalta_range_cell2_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL2',prop:'Class'},{av:'cellRestriccionesfechaalta_range_cell3_Class',ctrl:'RESTRICCIONESFECHAALTA_RANGE_CELL3',prop:'Class'},{av:'edtProfesionalesRestriccionId_Visible',ctrl:'PROFESIONALESRESTRICCIONID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtListaid_Visible',ctrl:'LISTAID',prop:'Visible'},{av:'edtListaNombre_Visible',ctrl:'LISTANOMBRE',prop:'Visible'},{av:'cmbListaEstado'},{av:'cmbListaTipo'},{av:'edtRestriccionesFechaAlta_Visible',ctrl:'RESTRICCIONESFECHAALTA',prop:'Visible'},{av:'cmbRestriccionesEstado'},{av:'edtRestriccionesObservacion_Visible',ctrl:'RESTRICCIONESOBSERVACION',prop:'Visible'},{av:'AV74GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV75GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV76GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E15KW2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALID_PROFESIONALESRESTRICCIONID","{handler:'Valid_Profesionalesrestriccionid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESRESTRICCIONID",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESPRIMERNOMBRE","{handler:'Valid_Profesionalesprimernombre',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESPRIMERNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESAPELLIDOPRIMERO","{handler:'Valid_Profesionalesapellidoprimero',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESAPELLIDOPRIMERO",",oparms:[]}");
         setEventMetadata("VALID_LISTAID","{handler:'Valid_Listaid',iparms:[]");
         setEventMetadata("VALID_LISTAID",",oparms:[]}");
         setEventMetadata("VALID_LISTANOMBRE","{handler:'Valid_Listanombre',iparms:[]");
         setEventMetadata("VALID_LISTANOMBRE",",oparms:[]}");
         setEventMetadata("VALID_LISTAESTADO","{handler:'Valid_Listaestado',iparms:[]");
         setEventMetadata("VALID_LISTAESTADO",",oparms:[]}");
         setEventMetadata("VALID_LISTATIPO","{handler:'Valid_Listatipo',iparms:[]");
         setEventMetadata("VALID_LISTATIPO",",oparms:[]}");
         setEventMetadata("VALID_RESTRICCIONESESTADO","{handler:'Valid_Restriccionesestado',iparms:[]");
         setEventMetadata("VALID_RESTRICCIONESESTADO",",oparms:[]}");
         setEventMetadata("VALID_RESTRICCIONESOBSERVACION","{handler:'Valid_Restriccionesobservacion',iparms:[]");
         setEventMetadata("VALID_RESTRICCIONESOBSERVACION",",oparms:[]}");
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
         AV22ListaNombre1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV28ListaNombre2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV34ListaNombre3 = "";
         AV20RestriccionesFechaAlta1 = (DateTime)(DateTime.MinValue);
         AV26RestriccionesFechaAlta2 = (DateTime)(DateTime.MinValue);
         AV32RestriccionesFechaAlta3 = (DateTime)(DateTime.MinValue);
         AV41ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV88Pgmname = "";
         AV17FilterFullText = "";
         AV21RestriccionesFechaAlta_To1 = (DateTime)(DateTime.MinValue);
         AV27RestriccionesFechaAlta_To2 = (DateTime)(DateTime.MinValue);
         AV33RestriccionesFechaAlta_To3 = (DateTime)(DateTime.MinValue);
         AV49TFProfesionalesId = "";
         AV50TFProfesionalesId_Sel = "";
         AV51TFProfesionalesPrimerNombre = "";
         AV52TFProfesionalesPrimerNombre_Sel = "";
         AV53TFProfesionalesApellidoPrimero = "";
         AV54TFProfesionalesApellidoPrimero_Sel = "";
         AV57TFListaNombre = "";
         AV58TFListaNombre_Sel = "";
         AV60TFListaEstado_Sels = new GxSimpleCollection<string>();
         AV62TFListaTipo_Sels = new GxSimpleCollection<string>();
         AV63TFRestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV64TFRestriccionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AV69TFRestriccionesEstado_Sels = new GxSimpleCollection<string>();
         AV70TFRestriccionesObservacion = "";
         AV71TFRestriccionesObservacion_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV44ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV76GridAppliedFilters = "";
         AV82AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV72DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV66DDO_RestriccionesFechaAltaAuxDateTo = DateTime.MinValue;
         AV59TFListaEstado_SelsJson = "";
         AV61TFListaTipo_SelsJson = "";
         AV68TFRestriccionesEstado_SelsJson = "";
         AV65DDO_RestriccionesFechaAltaAuxDate = DateTime.MinValue;
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
         ucRestriccionesfechaalta_rangepicker1 = new GXUserControl();
         ucRestriccionesfechaalta_rangepicker2 = new GXUserControl();
         ucRestriccionesfechaalta_rangepicker3 = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV67DDO_RestriccionesFechaAltaAuxDateText = "";
         ucTfrestriccionesfechaalta_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A592ListaNombre = "";
         A593ListaEstado = "";
         A591ListaTipo = "";
         A973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         A974RestriccionesEstado = "";
         A975RestriccionesObservacion = "";
         AV89Profesionalesrestriccionwwds_1_filterfulltext = "";
         AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = "";
         AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = (DateTime)(DateTime.MinValue);
         AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = (DateTime)(DateTime.MinValue);
         AV94Profesionalesrestriccionwwds_6_listanombre1 = "";
         AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = "";
         AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = (DateTime)(DateTime.MinValue);
         AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = (DateTime)(DateTime.MinValue);
         AV100Profesionalesrestriccionwwds_12_listanombre2 = "";
         AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = "";
         AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = (DateTime)(DateTime.MinValue);
         AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = (DateTime)(DateTime.MinValue);
         AV106Profesionalesrestriccionwwds_18_listanombre3 = "";
         AV109Profesionalesrestriccionwwds_21_tfprofesionalesid = "";
         AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = "";
         AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = "";
         AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = "";
         AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = "";
         AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = "";
         AV117Profesionalesrestriccionwwds_29_tflistanombre = "";
         AV118Profesionalesrestriccionwwds_30_tflistanombre_sel = "";
         AV119Profesionalesrestriccionwwds_31_tflistaestado_sels = new GxSimpleCollection<string>();
         AV120Profesionalesrestriccionwwds_32_tflistatipo_sels = new GxSimpleCollection<string>();
         AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = (DateTime)(DateTime.MinValue);
         AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = (DateTime)(DateTime.MinValue);
         AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = new GxSimpleCollection<string>();
         AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = "";
         AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = "";
         lV89Profesionalesrestriccionwwds_1_filterfulltext = "";
         lV94Profesionalesrestriccionwwds_6_listanombre1 = "";
         lV100Profesionalesrestriccionwwds_12_listanombre2 = "";
         lV106Profesionalesrestriccionwwds_18_listanombre3 = "";
         lV109Profesionalesrestriccionwwds_21_tfprofesionalesid = "";
         lV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = "";
         lV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = "";
         lV117Profesionalesrestriccionwwds_29_tflistanombre = "";
         lV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = "";
         H00KW2_A975RestriccionesObservacion = new string[] {""} ;
         H00KW2_n975RestriccionesObservacion = new bool[] {false} ;
         H00KW2_A974RestriccionesEstado = new string[] {""} ;
         H00KW2_n974RestriccionesEstado = new bool[] {false} ;
         H00KW2_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00KW2_n973RestriccionesFechaAlta = new bool[] {false} ;
         H00KW2_A591ListaTipo = new string[] {""} ;
         H00KW2_A593ListaEstado = new string[] {""} ;
         H00KW2_n593ListaEstado = new bool[] {false} ;
         H00KW2_A592ListaNombre = new string[] {""} ;
         H00KW2_A590Listaid = new long[1] ;
         H00KW2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00KW2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00KW2_A120ProfesionalesId = new string[] {""} ;
         H00KW2_A976ProfesionalesRestriccionId = new long[1] ;
         H00KW3_A975RestriccionesObservacion = new string[] {""} ;
         H00KW3_n975RestriccionesObservacion = new bool[] {false} ;
         H00KW3_A974RestriccionesEstado = new string[] {""} ;
         H00KW3_n974RestriccionesEstado = new bool[] {false} ;
         H00KW3_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00KW3_n973RestriccionesFechaAlta = new bool[] {false} ;
         H00KW3_A591ListaTipo = new string[] {""} ;
         H00KW3_A593ListaEstado = new string[] {""} ;
         H00KW3_n593ListaEstado = new bool[] {false} ;
         H00KW3_A592ListaNombre = new string[] {""} ;
         H00KW3_A590Listaid = new long[1] ;
         H00KW3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00KW3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00KW3_A120ProfesionalesId = new string[] {""} ;
         H00KW3_A976ProfesionalesRestriccionId = new long[1] ;
         AV85RestriccionesFechaAlta_RangeText1 = "";
         AV86RestriccionesFechaAlta_RangeText2 = "";
         AV87RestriccionesFechaAlta_RangeText3 = "";
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV83AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV43Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV45ManageFiltersXml = "";
         AV40UserCustomValue = "";
         AV42ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char5 = "";
         GXt_char6 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV37ExcelFilename = "";
         AV38ErrorMessage = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesrestriccionww__default(),
            new Object[][] {
                new Object[] {
               H00KW2_A975RestriccionesObservacion, H00KW2_n975RestriccionesObservacion, H00KW2_A974RestriccionesEstado, H00KW2_n974RestriccionesEstado, H00KW2_A973RestriccionesFechaAlta, H00KW2_n973RestriccionesFechaAlta, H00KW2_A591ListaTipo, H00KW2_A593ListaEstado, H00KW2_n593ListaEstado, H00KW2_A592ListaNombre,
               H00KW2_A590Listaid, H00KW2_A167ProfesionalesApellidoPrimero, H00KW2_A166ProfesionalesPrimerNombre, H00KW2_A120ProfesionalesId, H00KW2_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               H00KW3_A975RestriccionesObservacion, H00KW3_n975RestriccionesObservacion, H00KW3_A974RestriccionesEstado, H00KW3_n974RestriccionesEstado, H00KW3_A973RestriccionesFechaAlta, H00KW3_n973RestriccionesFechaAlta, H00KW3_A591ListaTipo, H00KW3_A593ListaEstado, H00KW3_n593ListaEstado, H00KW3_A592ListaNombre,
               H00KW3_A590Listaid, H00KW3_A167ProfesionalesApellidoPrimero, H00KW3_A166ProfesionalesPrimerNombre, H00KW3_A120ProfesionalesId, H00KW3_A976ProfesionalesRestriccionId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         AV88Pgmname = "ProfesionalesRestriccionWW";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV88Pgmname = "ProfesionalesRestriccionWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV46ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV77GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ;
      private short AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ;
      private short AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ;
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
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int AV119Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ;
      private int AV120Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ;
      private int AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ;
      private int edtProfesionalesRestriccionId_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtListaid_Enabled ;
      private int edtListaNombre_Enabled ;
      private int edtRestriccionesFechaAlta_Enabled ;
      private int edtRestriccionesObservacion_Enabled ;
      private int edtProfesionalesRestriccionId_Visible ;
      private int edtProfesionalesId_Visible ;
      private int edtProfesionalesPrimerNombre_Visible ;
      private int edtProfesionalesApellidoPrimero_Visible ;
      private int edtListaid_Visible ;
      private int edtListaNombre_Visible ;
      private int edtRestriccionesFechaAlta_Visible ;
      private int edtRestriccionesObservacion_Visible ;
      private int AV73PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int tblTablemergeddynamicfiltersrestriccionesfechaalta1_Visible ;
      private int edtavListanombre1_Visible ;
      private int tblTablemergeddynamicfiltersrestriccionesfechaalta2_Visible ;
      private int edtavListanombre2_Visible ;
      private int tblTablemergeddynamicfiltersrestriccionesfechaalta3_Visible ;
      private int edtavListanombre3_Visible ;
      private int AV127GXV1 ;
      private int edtavListanombre3_Enabled ;
      private int edtavRestriccionesfechaalta_rangetext3_Enabled ;
      private int edtavListanombre2_Enabled ;
      private int edtavRestriccionesfechaalta_rangetext2_Enabled ;
      private int edtavListanombre1_Enabled ;
      private int edtavRestriccionesfechaalta_rangetext1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV47TFProfesionalesRestriccionId ;
      private long AV48TFProfesionalesRestriccionId_To ;
      private long AV55TFListaid ;
      private long AV56TFListaid_To ;
      private long AV74GridCurrentPage ;
      private long AV75GridPageCount ;
      private long A976ProfesionalesRestriccionId ;
      private long A590Listaid ;
      private long GRID_nCurrentRecord ;
      private long AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ;
      private long AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ;
      private long AV115Profesionalesrestriccionwwds_27_tflistaid ;
      private long AV116Profesionalesrestriccionwwds_28_tflistaid_to ;
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
      private string sGXsfl_129_idx="0001" ;
      private string AV22ListaNombre1 ;
      private string AV28ListaNombre2 ;
      private string AV34ListaNombre3 ;
      private string AV88Pgmname ;
      private string AV49TFProfesionalesId ;
      private string AV50TFProfesionalesId_Sel ;
      private string AV51TFProfesionalesPrimerNombre ;
      private string AV52TFProfesionalesPrimerNombre_Sel ;
      private string AV53TFProfesionalesApellidoPrimero ;
      private string AV54TFProfesionalesApellidoPrimero_Sel ;
      private string AV57TFListaNombre ;
      private string AV58TFListaNombre_Sel ;
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
      private string Restriccionesfechaalta_rangepicker1_Internalname ;
      private string Restriccionesfechaalta_rangepicker2_Internalname ;
      private string Restriccionesfechaalta_rangepicker3_Internalname ;
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
      private string divDdo_restriccionesfechaaltaauxdates_Internalname ;
      private string edtavDdo_restriccionesfechaaltaauxdatetext_Internalname ;
      private string edtavDdo_restriccionesfechaaltaauxdatetext_Jsonclick ;
      private string Tfrestriccionesfechaalta_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtProfesionalesRestriccionId_Internalname ;
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Internalname ;
      private string A166ProfesionalesPrimerNombre ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string edtListaid_Internalname ;
      private string A592ListaNombre ;
      private string edtListaNombre_Internalname ;
      private string cmbListaEstado_Internalname ;
      private string A593ListaEstado ;
      private string cmbListaTipo_Internalname ;
      private string A591ListaTipo ;
      private string edtRestriccionesFechaAlta_Internalname ;
      private string cmbRestriccionesEstado_Internalname ;
      private string A974RestriccionesEstado ;
      private string edtRestriccionesObservacion_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string AV94Profesionalesrestriccionwwds_6_listanombre1 ;
      private string AV100Profesionalesrestriccionwwds_12_listanombre2 ;
      private string AV106Profesionalesrestriccionwwds_18_listanombre3 ;
      private string AV109Profesionalesrestriccionwwds_21_tfprofesionalesid ;
      private string AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ;
      private string AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ;
      private string AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ;
      private string AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ;
      private string AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ;
      private string AV117Profesionalesrestriccionwwds_29_tflistanombre ;
      private string AV118Profesionalesrestriccionwwds_30_tflistanombre_sel ;
      private string lV94Profesionalesrestriccionwwds_6_listanombre1 ;
      private string lV100Profesionalesrestriccionwwds_12_listanombre2 ;
      private string lV106Profesionalesrestriccionwwds_18_listanombre3 ;
      private string lV109Profesionalesrestriccionwwds_21_tfprofesionalesid ;
      private string lV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ;
      private string lV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ;
      private string lV117Profesionalesrestriccionwwds_29_tflistanombre ;
      private string edtavRestriccionesfechaalta_rangetext1_Internalname ;
      private string edtavListanombre1_Internalname ;
      private string edtavRestriccionesfechaalta_rangetext2_Internalname ;
      private string edtavListanombre2_Internalname ;
      private string edtavRestriccionesfechaalta_rangetext3_Internalname ;
      private string edtavListanombre3_Internalname ;
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
      private string edtListaNombre_Link ;
      private string GXEncryptionTmp ;
      private string edtRestriccionesFechaAlta_Link ;
      private string tblTablemergeddynamicfiltersrestriccionesfechaalta1_Internalname ;
      private string cellRestriccionesfechaalta_range_cell1_Class ;
      private string cellRestriccionesfechaalta_range_cell1_Internalname ;
      private string tblTablemergeddynamicfiltersrestriccionesfechaalta2_Internalname ;
      private string cellRestriccionesfechaalta_range_cell2_Class ;
      private string cellRestriccionesfechaalta_range_cell2_Internalname ;
      private string tblTablemergeddynamicfiltersrestriccionesfechaalta3_Internalname ;
      private string cellRestriccionesfechaalta_range_cell3_Class ;
      private string cellRestriccionesfechaalta_range_cell3_Internalname ;
      private string GXt_char3 ;
      private string GXt_char5 ;
      private string GXt_char6 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_restriccionesfechaalta3_cell_Internalname ;
      private string cellFilter_listanombre3_cell_Internalname ;
      private string edtavListanombre3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string edtavRestriccionesfechaalta_rangetext3_Jsonclick ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_restriccionesfechaalta2_cell_Internalname ;
      private string cellFilter_listanombre2_cell_Internalname ;
      private string edtavListanombre2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string edtavRestriccionesfechaalta_rangetext2_Jsonclick ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_restriccionesfechaalta1_cell_Internalname ;
      private string cellFilter_listanombre1_cell_Internalname ;
      private string edtavListanombre1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string edtavRestriccionesfechaalta_rangetext1_Jsonclick ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_129_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtProfesionalesRestriccionId_Jsonclick ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtListaid_Jsonclick ;
      private string edtListaNombre_Jsonclick ;
      private string cmbListaEstado_Jsonclick ;
      private string cmbListaTipo_Jsonclick ;
      private string edtRestriccionesFechaAlta_Jsonclick ;
      private string cmbRestriccionesEstado_Jsonclick ;
      private string edtRestriccionesObservacion_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV20RestriccionesFechaAlta1 ;
      private DateTime AV26RestriccionesFechaAlta2 ;
      private DateTime AV32RestriccionesFechaAlta3 ;
      private DateTime AV21RestriccionesFechaAlta_To1 ;
      private DateTime AV27RestriccionesFechaAlta_To2 ;
      private DateTime AV33RestriccionesFechaAlta_To3 ;
      private DateTime AV63TFRestriccionesFechaAlta ;
      private DateTime AV64TFRestriccionesFechaAlta_To ;
      private DateTime A973RestriccionesFechaAlta ;
      private DateTime AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ;
      private DateTime AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ;
      private DateTime AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ;
      private DateTime AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ;
      private DateTime AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ;
      private DateTime AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ;
      private DateTime AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ;
      private DateTime AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ;
      private DateTime Gx_date ;
      private DateTime AV66DDO_RestriccionesFechaAltaAuxDateTo ;
      private DateTime AV65DDO_RestriccionesFechaAltaAuxDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV36DynamicFiltersIgnoreFirst ;
      private bool AV35DynamicFiltersRemoving ;
      private bool AV79IsAuthorized_Update ;
      private bool AV80IsAuthorized_Delete ;
      private bool AV81IsAuthorized_ListaNombre ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_129_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n593ListaEstado ;
      private bool n973RestriccionesFechaAlta ;
      private bool n974RestriccionesEstado ;
      private bool n975RestriccionesObservacion ;
      private bool AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ;
      private bool AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV84TempBoolean ;
      private bool GXt_boolean1 ;
      private string AV59TFListaEstado_SelsJson ;
      private string AV61TFListaTipo_SelsJson ;
      private string AV68TFRestriccionesEstado_SelsJson ;
      private string AV39ColumnsSelectorXML ;
      private string AV45ManageFiltersXml ;
      private string AV40UserCustomValue ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV17FilterFullText ;
      private string AV70TFRestriccionesObservacion ;
      private string AV71TFRestriccionesObservacion_Sel ;
      private string AV76GridAppliedFilters ;
      private string AV67DDO_RestriccionesFechaAltaAuxDateText ;
      private string A975RestriccionesObservacion ;
      private string AV89Profesionalesrestriccionwwds_1_filterfulltext ;
      private string AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ;
      private string AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ;
      private string AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ;
      private string AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ;
      private string AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ;
      private string lV89Profesionalesrestriccionwwds_1_filterfulltext ;
      private string lV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ;
      private string AV85RestriccionesFechaAlta_RangeText1 ;
      private string AV86RestriccionesFechaAlta_RangeText2 ;
      private string AV87RestriccionesFechaAlta_RangeText3 ;
      private string AV37ExcelFilename ;
      private string AV38ErrorMessage ;
      private IGxSession AV43Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucRestriccionesfechaalta_rangepicker1 ;
      private GXUserControl ucRestriccionesfechaalta_rangepicker2 ;
      private GXUserControl ucRestriccionesfechaalta_rangepicker3 ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfrestriccionesfechaalta_rangepicker ;
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
      private GXCombobox cmbListaEstado ;
      private GXCombobox cmbListaTipo ;
      private GXCombobox cmbRestriccionesEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV41ColumnsSelector ;
      private GxSimpleCollection<string> AV60TFListaEstado_Sels ;
      private GxSimpleCollection<string> AV62TFListaTipo_Sels ;
      private GxSimpleCollection<string> AV69TFRestriccionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV44ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV82AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV72DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV119Profesionalesrestriccionwwds_31_tflistaestado_sels ;
      private GxSimpleCollection<string> AV120Profesionalesrestriccionwwds_32_tflistatipo_sels ;
      private GxSimpleCollection<string> AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H00KW2_A975RestriccionesObservacion ;
      private bool[] H00KW2_n975RestriccionesObservacion ;
      private string[] H00KW2_A974RestriccionesEstado ;
      private bool[] H00KW2_n974RestriccionesEstado ;
      private DateTime[] H00KW2_A973RestriccionesFechaAlta ;
      private bool[] H00KW2_n973RestriccionesFechaAlta ;
      private string[] H00KW2_A591ListaTipo ;
      private string[] H00KW2_A593ListaEstado ;
      private bool[] H00KW2_n593ListaEstado ;
      private string[] H00KW2_A592ListaNombre ;
      private long[] H00KW2_A590Listaid ;
      private string[] H00KW2_A167ProfesionalesApellidoPrimero ;
      private string[] H00KW2_A166ProfesionalesPrimerNombre ;
      private string[] H00KW2_A120ProfesionalesId ;
      private long[] H00KW2_A976ProfesionalesRestriccionId ;
      private string[] H00KW3_A975RestriccionesObservacion ;
      private bool[] H00KW3_n975RestriccionesObservacion ;
      private string[] H00KW3_A974RestriccionesEstado ;
      private bool[] H00KW3_n974RestriccionesEstado ;
      private DateTime[] H00KW3_A973RestriccionesFechaAlta ;
      private bool[] H00KW3_n973RestriccionesFechaAlta ;
      private string[] H00KW3_A591ListaTipo ;
      private string[] H00KW3_A593ListaEstado ;
      private bool[] H00KW3_n593ListaEstado ;
      private string[] H00KW3_A592ListaNombre ;
      private long[] H00KW3_A590Listaid ;
      private string[] H00KW3_A167ProfesionalesApellidoPrimero ;
      private string[] H00KW3_A166ProfesionalesPrimerNombre ;
      private string[] H00KW3_A120ProfesionalesId ;
      private long[] H00KW3_A976ProfesionalesRestriccionId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV83AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV42ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class profesionalesrestriccionww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00KW2( IGxContext context ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV119Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV120Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                             string A974RestriccionesEstado ,
                                             GxSimpleCollection<string> AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                             string AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                             short AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                             DateTime AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                             string AV94Profesionalesrestriccionwwds_6_listanombre1 ,
                                             bool AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                             string AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                             short AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                             DateTime AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                             string AV100Profesionalesrestriccionwwds_12_listanombre2 ,
                                             bool AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                             string AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                             short AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                             DateTime AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                             string AV106Profesionalesrestriccionwwds_18_listanombre3 ,
                                             long AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                             long AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                             string AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                             string AV109Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                             string AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                             string AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                             string AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                             long AV115Profesionalesrestriccionwwds_27_tflistaid ,
                                             long AV116Profesionalesrestriccionwwds_28_tflistaid_to ,
                                             string AV118Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                             string AV117Profesionalesrestriccionwwds_29_tflistanombre ,
                                             int AV119Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ,
                                             int AV120Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ,
                                             DateTime AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                             DateTime AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                             int AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ,
                                             string AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                             string AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                             DateTime A973RestriccionesFechaAlta ,
                                             string A592ListaNombre ,
                                             long A976ProfesionalesRestriccionId ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             long A590Listaid ,
                                             string A975RestriccionesObservacion ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV89Profesionalesrestriccionwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[34];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.[RestriccionesObservacion], T1.[RestriccionesEstado], T1.[RestriccionesFechaAlta], T2.[ListaTipo], T2.[ListaEstado], T2.[ListaNombre], T1.[Listaid], T3.[ProfesionalesApellidoPrimero], T3.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesRestriccionId] FROM (([ProfesionalesRestriccion] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int12[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV94Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV94Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV100Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV100Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV106Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV106Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( ! (0==AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] >= @AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid)");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( ! (0==AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] <= @AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to)");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionalesrestriccionwwds_21_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV109Profesionalesrestriccionwwds_21_tfprofesionalesid))");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesPrimerNombre]) like UPPER(@lV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesPrimerNombre] = @AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( StringUtil.StrCmp(AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesApellidoPrimero]) like UPPER(@lV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesApellidoPrimero] = @AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( StringUtil.StrCmp(AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( ! (0==AV115Profesionalesrestriccionwwds_27_tflistaid) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] >= @AV115Profesionalesrestriccionwwds_27_tflistaid)");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( ! (0==AV116Profesionalesrestriccionwwds_28_tflistaid_to) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] <= @AV116Profesionalesrestriccionwwds_28_tflistaid_to)");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Profesionalesrestriccionwwds_29_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV117Profesionalesrestriccionwwds_29_tflistanombre))");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV118Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ListaNombre] = @AV118Profesionalesrestriccionwwds_30_tflistanombre_sel)");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( StringUtil.StrCmp(AV118Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ListaNombre] = ''))");
         }
         if ( AV119Profesionalesrestriccionwwds_31_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV119Profesionalesrestriccionwwds_31_tflistaestado_sels, "T2.[ListaEstado] IN (", ")")+")");
         }
         if ( AV120Profesionalesrestriccionwwds_32_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV120Profesionalesrestriccionwwds_32_tflistatipo_sels, "T2.[ListaTipo] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta)");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to)");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels, "T1.[RestriccionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[RestriccionesObservacion]) like UPPER(@lV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion))");
         }
         else
         {
            GXv_int12[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ! ( StringUtil.StrCmp(AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] = @AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)");
         }
         else
         {
            GXv_int12[33] = 1;
         }
         if ( StringUtil.StrCmp(AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] IS NULL or (T1.[RestriccionesObservacion] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesRestriccionId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesRestriccionId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesId]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesId] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[Listaid]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[Listaid] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaNombre]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaEstado]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaTipo]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesEstado]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesObservacion]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesObservacion] DESC";
         }
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_H00KW3( IGxContext context ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV119Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV120Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                             string A974RestriccionesEstado ,
                                             GxSimpleCollection<string> AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                             string AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                             short AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                             DateTime AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                             string AV94Profesionalesrestriccionwwds_6_listanombre1 ,
                                             bool AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                             string AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                             short AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                             DateTime AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                             string AV100Profesionalesrestriccionwwds_12_listanombre2 ,
                                             bool AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                             string AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                             short AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                             DateTime AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                             string AV106Profesionalesrestriccionwwds_18_listanombre3 ,
                                             long AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                             long AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                             string AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                             string AV109Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                             string AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                             string AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                             string AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                             long AV115Profesionalesrestriccionwwds_27_tflistaid ,
                                             long AV116Profesionalesrestriccionwwds_28_tflistaid_to ,
                                             string AV118Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                             string AV117Profesionalesrestriccionwwds_29_tflistanombre ,
                                             int AV119Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ,
                                             int AV120Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ,
                                             DateTime AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                             DateTime AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                             int AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ,
                                             string AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                             string AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                             DateTime A973RestriccionesFechaAlta ,
                                             string A592ListaNombre ,
                                             long A976ProfesionalesRestriccionId ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             long A590Listaid ,
                                             string A975RestriccionesObservacion ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV89Profesionalesrestriccionwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[34];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT T1.[RestriccionesObservacion], T1.[RestriccionesEstado], T1.[RestriccionesFechaAlta], T2.[ListaTipo], T2.[ListaEstado], T2.[ListaNombre], T1.[Listaid], T3.[ProfesionalesApellidoPrimero], T3.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesRestriccionId] FROM (([ProfesionalesRestriccion] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int14[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int14[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int14[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int14[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV94Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int14[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV91Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV94Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int14[5] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int14[6] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int14[7] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int14[8] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int14[9] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV100Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int14[10] = 1;
         }
         if ( AV95Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV97Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV100Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int14[11] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int14[12] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int14[13] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int14[14] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int14[15] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV106Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int14[16] = 1;
         }
         if ( AV101Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV103Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV106Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int14[17] = 1;
         }
         if ( ! (0==AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] >= @AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid)");
         }
         else
         {
            GXv_int14[18] = 1;
         }
         if ( ! (0==AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] <= @AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to)");
         }
         else
         {
            GXv_int14[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionalesrestriccionwwds_21_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV109Profesionalesrestriccionwwds_21_tfprofesionalesid))");
         }
         else
         {
            GXv_int14[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int14[21] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesPrimerNombre]) like UPPER(@lV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int14[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesPrimerNombre] = @AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int14[23] = 1;
         }
         if ( StringUtil.StrCmp(AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesApellidoPrimero]) like UPPER(@lV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int14[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesApellidoPrimero] = @AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int14[25] = 1;
         }
         if ( StringUtil.StrCmp(AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( ! (0==AV115Profesionalesrestriccionwwds_27_tflistaid) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] >= @AV115Profesionalesrestriccionwwds_27_tflistaid)");
         }
         else
         {
            GXv_int14[26] = 1;
         }
         if ( ! (0==AV116Profesionalesrestriccionwwds_28_tflistaid_to) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] <= @AV116Profesionalesrestriccionwwds_28_tflistaid_to)");
         }
         else
         {
            GXv_int14[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Profesionalesrestriccionwwds_29_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV117Profesionalesrestriccionwwds_29_tflistanombre))");
         }
         else
         {
            GXv_int14[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV118Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ListaNombre] = @AV118Profesionalesrestriccionwwds_30_tflistanombre_sel)");
         }
         else
         {
            GXv_int14[29] = 1;
         }
         if ( StringUtil.StrCmp(AV118Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ListaNombre] = ''))");
         }
         if ( AV119Profesionalesrestriccionwwds_31_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV119Profesionalesrestriccionwwds_31_tflistaestado_sels, "T2.[ListaEstado] IN (", ")")+")");
         }
         if ( AV120Profesionalesrestriccionwwds_32_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV120Profesionalesrestriccionwwds_32_tflistatipo_sels, "T2.[ListaTipo] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta)");
         }
         else
         {
            GXv_int14[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to)");
         }
         else
         {
            GXv_int14[31] = 1;
         }
         if ( AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV123Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels, "T1.[RestriccionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[RestriccionesObservacion]) like UPPER(@lV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion))");
         }
         else
         {
            GXv_int14[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ! ( StringUtil.StrCmp(AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] = @AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)");
         }
         else
         {
            GXv_int14[33] = 1;
         }
         if ( StringUtil.StrCmp(AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] IS NULL or (T1.[RestriccionesObservacion] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesRestriccionId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesRestriccionId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesId]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesId] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[Listaid]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[Listaid] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaNombre]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaEstado]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaTipo]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesEstado]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesObservacion]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesObservacion] DESC";
         }
         GXv_Object15[0] = scmdbuf;
         GXv_Object15[1] = GXv_int14;
         return GXv_Object15 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00KW2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (DateTime)dynConstraints[42] , (string)dynConstraints[43] , (long)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (long)dynConstraints[48] , (string)dynConstraints[49] , (short)dynConstraints[50] , (bool)dynConstraints[51] , (string)dynConstraints[52] );
               case 1 :
                     return conditional_H00KW3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (DateTime)dynConstraints[42] , (string)dynConstraints[43] , (long)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (long)dynConstraints[48] , (string)dynConstraints[49] , (short)dynConstraints[50] , (bool)dynConstraints[51] , (string)dynConstraints[52] );
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
          Object[] prmH00KW2;
          prmH00KW2 = new Object[] {
          new ParDef("@AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@lV94Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV94Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@lV100Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV100Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@lV106Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV106Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid",GXType.Decimal,18,0) ,
          new ParDef("@AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Profesionalesrestriccionwwds_21_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@AV115Profesionalesrestriccionwwds_27_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV116Profesionalesrestriccionwwds_28_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV117Profesionalesrestriccionwwds_29_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV118Profesionalesrestriccionwwds_30_tflistanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@lV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion",GXType.VarChar,120,0) ,
          new ParDef("@AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel",GXType.NVarChar,120,0)
          };
          Object[] prmH00KW3;
          prmH00KW3 = new Object[] {
          new ParDef("@AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV92Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@AV93Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@lV94Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV94Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV98Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@AV99Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@lV100Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV100Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@AV105Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@lV106Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV106Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV107Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid",GXType.Decimal,18,0) ,
          new ParDef("@AV108Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Profesionalesrestriccionwwds_21_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV110Profesionalesrestriccionwwds_22_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV111Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV112Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV113Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV114Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@AV115Profesionalesrestriccionwwds_27_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV116Profesionalesrestriccionwwds_28_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV117Profesionalesrestriccionwwds_29_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV118Profesionalesrestriccionwwds_30_tflistanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV121Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV122Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@lV124Profesionalesrestriccionwwds_36_tfrestriccionesobservacion",GXType.VarChar,120,0) ,
          new ParDef("@AV125Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel",GXType.NVarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00KW2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KW2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00KW3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KW3,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 4);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 80);
                ((long[]) buf[10])[0] = rslt.getLong(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 30);
                ((string[]) buf[12])[0] = rslt.getString(9, 30);
                ((string[]) buf[13])[0] = rslt.getString(10, 20);
                ((long[]) buf[14])[0] = rslt.getLong(11);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 4);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 80);
                ((long[]) buf[10])[0] = rslt.getLong(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 30);
                ((string[]) buf[12])[0] = rslt.getString(9, 30);
                ((string[]) buf[13])[0] = rslt.getString(10, 20);
                ((long[]) buf[14])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
