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
   public class proveedorww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public proveedorww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public proveedorww( IGxContext context )
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
         cmbProveedorPagoDefault = new GXCombobox();
         cmbProveedorEstado = new GXCombobox();
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
         nRC_GXsfl_48 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_48"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_48_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_48_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_48_idx = GetPar( "sGXsfl_48_idx");
         AV34HacerLoad = (short)(Math.Round(NumberUtil.Val( GetPar( "HacerLoad"), "."), 18, MidpointRounding.ToEven));
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
         AV46ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV39ColumnsSelector);
         AV105Pgmname = GetPar( "Pgmname");
         AV42GridConditionalFormattingFilter = (short)(Math.Round(NumberUtil.Val( GetPar( "GridConditionalFormattingFilter"), "."), 18, MidpointRounding.ToEven));
         AV17FilterFullText = GetPar( "FilterFullText");
         AV47TFProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProveedorID"), "."), 18, MidpointRounding.ToEven));
         AV48TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProveedorID_To"), "."), 18, MidpointRounding.ToEven));
         AV49TFProveedorNombre = GetPar( "TFProveedorNombre");
         AV50TFProveedorNombre_Sel = GetPar( "TFProveedorNombre_Sel");
         AV51TFProveedorDocIdentidad = GetPar( "TFProveedorDocIdentidad");
         AV52TFProveedorDocIdentidad_Sel = GetPar( "TFProveedorDocIdentidad_Sel");
         AV53TFProveedorTelefono = GetPar( "TFProveedorTelefono");
         AV54TFProveedorTelefono_Sel = GetPar( "TFProveedorTelefono_Sel");
         AV55TFProveedorDireccion = GetPar( "TFProveedorDireccion");
         AV56TFProveedorDireccion_Sel = GetPar( "TFProveedorDireccion_Sel");
         AV57TFProveedorEmail = GetPar( "TFProveedorEmail");
         AV58TFProveedorEmail_Sel = GetPar( "TFProveedorEmail_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV88TFProveedorPagoDefault_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV60TFProveedorEstado_Sels);
         AV34HacerLoad = (short)(Math.Round(NumberUtil.Val( GetPar( "HacerLoad"), "."), 18, MidpointRounding.ToEven));
         AV76SecRoleName = GetPar( "SecRoleName");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6WWPContext);
         AV90IsAuthorized_Estadisticas = StringUtil.StrToBool( GetPar( "IsAuthorized_Estadisticas"));
         AV92IsAuthorized_DesaINV = StringUtil.StrToBool( GetPar( "IsAuthorized_DesaINV"));
         AV104IsAuthorized_ReplicarRubros = StringUtil.StrToBool( GetPar( "IsAuthorized_ReplicarRubros"));
         AV99IsAuthorized_ReplicarPrecios2 = StringUtil.StrToBool( GetPar( "IsAuthorized_ReplicarPrecios2"));
         AV68IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV69IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV46ManageFiltersExecutionStep, AV39ColumnsSelector, AV105Pgmname, AV42GridConditionalFormattingFilter, AV17FilterFullText, AV47TFProveedorID, AV48TFProveedorID_To, AV49TFProveedorNombre, AV50TFProveedorNombre_Sel, AV51TFProveedorDocIdentidad, AV52TFProveedorDocIdentidad_Sel, AV53TFProveedorTelefono, AV54TFProveedorTelefono_Sel, AV55TFProveedorDireccion, AV56TFProveedorDireccion_Sel, AV57TFProveedorEmail, AV58TFProveedorEmail_Sel, AV88TFProveedorPagoDefault_Sels, AV60TFProveedorEstado_Sels, AV34HacerLoad, AV76SecRoleName, AV6WWPContext, AV90IsAuthorized_Estadisticas, AV92IsAuthorized_DesaINV, AV104IsAuthorized_ReplicarRubros, AV99IsAuthorized_ReplicarPrecios2, AV68IsAuthorized_Update, AV69IsAuthorized_Delete) ;
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
         PA4R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4R2( ) ;
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("proveedorww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV105Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV105Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECROLENAME", AV76SecRoleName);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV76SecRoleName, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADISTICAS", AV90IsAuthorized_Estadisticas);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADISTICAS", GetSecureSignedToken( "", AV90IsAuthorized_Estadisticas, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DESAINV", AV92IsAuthorized_DesaINV);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESAINV", GetSecureSignedToken( "", AV92IsAuthorized_DesaINV, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_REPLICARRUBROS", AV104IsAuthorized_ReplicarRubros);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REPLICARRUBROS", GetSecureSignedToken( "", AV104IsAuthorized_ReplicarRubros, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_REPLICARPRECIOS2", AV99IsAuthorized_ReplicarPrecios2);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REPLICARPRECIOS2", GetSecureSignedToken( "", AV99IsAuthorized_ReplicarPrecios2, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV68IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV68IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV69IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV69IsAuthorized_Delete, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_48", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_48), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV44ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV44ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV65GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV70AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV70AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV61DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV61DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV39ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV39ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV105Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV105Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vGRIDCONDITIONALFORMATTINGFILTER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42GridConditionalFormattingFilter), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFProveedorID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORNOMBRE", StringUtil.RTrim( AV49TFProveedorNombre));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORNOMBRE_SEL", StringUtil.RTrim( AV50TFProveedorNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORDOCIDENTIDAD", StringUtil.RTrim( AV51TFProveedorDocIdentidad));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORDOCIDENTIDAD_SEL", StringUtil.RTrim( AV52TFProveedorDocIdentidad_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORTELEFONO", StringUtil.RTrim( AV53TFProveedorTelefono));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORTELEFONO_SEL", StringUtil.RTrim( AV54TFProveedorTelefono_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORDIRECCION", AV55TFProveedorDireccion);
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORDIRECCION_SEL", AV56TFProveedorDireccion_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDOREMAIL", AV57TFProveedorEmail);
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDOREMAIL_SEL", AV58TFProveedorEmail_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPROVEEDORPAGODEFAULT_SELS", AV88TFProveedorPagoDefault_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPROVEEDORPAGODEFAULT_SELS", AV88TFProveedorPagoDefault_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPROVEEDORESTADO_SELS", AV60TFProveedorEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPROVEEDORESTADO_SELS", AV60TFProveedorEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vSECROLENAME", AV76SecRoleName);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV76SecRoleName, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADISTICAS", AV90IsAuthorized_Estadisticas);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADISTICAS", GetSecureSignedToken( "", AV90IsAuthorized_Estadisticas, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DESAINV", AV92IsAuthorized_DesaINV);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESAINV", GetSecureSignedToken( "", AV92IsAuthorized_DesaINV, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_REPLICARRUBROS", AV104IsAuthorized_ReplicarRubros);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REPLICARRUBROS", GetSecureSignedToken( "", AV104IsAuthorized_ReplicarRubros, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_REPLICARPRECIOS2", AV99IsAuthorized_ReplicarPrecios2);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REPLICARPRECIOS2", GetSecureSignedToken( "", AV99IsAuthorized_ReplicarPrecios2, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV68IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV68IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV69IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV69IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORPAGODEFAULT_SELSJSON", AV87TFProveedorPagoDefault_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORESTADO_SELSJSON", AV59TFProveedorEstado_SelsJson);
         GxWebStd.gx_boolean_hidden_field( context, "vEXITOSO", AV100Exitoso);
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
         GxWebStd.gx_hidden_field( context, "NEWWINDOW_Target", StringUtil.RTrim( Newwindow_Target));
         GxWebStd.gx_hidden_field( context, "NEWWINDOW2_Width", StringUtil.RTrim( Newwindow2_Width));
         GxWebStd.gx_hidden_field( context, "NEWWINDOW2_Height", StringUtil.RTrim( Newwindow2_Height));
         GxWebStd.gx_hidden_field( context, "NEWWINDOW2_Target", StringUtil.RTrim( Newwindow2_Target));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixedfilters", StringUtil.RTrim( Ddo_grid_Fixedfilters));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedfixedfilter));
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
         GxWebStd.gx_hidden_field( context, "REPLICARRUBROS_MODAL_Width", StringUtil.RTrim( Replicarrubros_modal_Width));
         GxWebStd.gx_hidden_field( context, "REPLICARRUBROS_MODAL_Title", StringUtil.RTrim( Replicarrubros_modal_Title));
         GxWebStd.gx_hidden_field( context, "REPLICARRUBROS_MODAL_Confirmtype", StringUtil.RTrim( Replicarrubros_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "REPLICARRUBROS_MODAL_Bodytype", StringUtil.RTrim( Replicarrubros_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "REPLICARPRECIOS2_MODAL_Width", StringUtil.RTrim( Replicarprecios2_modal_Width));
         GxWebStd.gx_hidden_field( context, "REPLICARPRECIOS2_MODAL_Title", StringUtil.RTrim( Replicarprecios2_modal_Title));
         GxWebStd.gx_hidden_field( context, "REPLICARPRECIOS2_MODAL_Confirmtype", StringUtil.RTrim( Replicarprecios2_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "REPLICARPRECIOS2_MODAL_Bodytype", StringUtil.RTrim( Replicarprecios2_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
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
            WE4R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4R2( ) ;
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
         return formatLink("proveedorww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ProveedorWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Comercios", "") ;
      }

      protected void WB4R0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(48), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(48), 2, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(48), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(48), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_4R2( true) ;
         }
         else
         {
            wb_table1_25_4R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_4R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, divUnnamedtable1_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "ButtonColorFilled";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnmudanza_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(48), 2, 0)+","+"null"+");", context.GetMessage( "Nueva Mudanza", ""), bttBtnmudanza_Jsonclick, 5, context.GetMessage( "Nueva Mudanza", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOMUDANZA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProveedorWW.htm");
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
            StartGridControl48( ) ;
         }
         if ( wbEnd == 48 )
         {
            wbEnd = 0;
            nRC_GXsfl_48 = (int)(nGXsfl_48_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV63GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV64GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV65GridAppliedFilters);
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
            /* User Defined Control */
            ucNewwindow.Render(context, "innewwindow", Newwindow_Internalname, "NEWWINDOWContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucNewwindow2.Render(context, "innewwindow", Newwindow2_Internalname, "NEWWINDOW2Container");
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV70AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
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
            ucDdo_grid.SetProperty("FixedFilters", Ddo_grid_Fixedfilters);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV61DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV61DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV39ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table2_78_4R2( true) ;
         }
         else
         {
            wb_table2_78_4R2( false) ;
         }
         return  ;
      }

      protected void wb_table2_78_4R2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_83_4R2( true) ;
         }
         else
         {
            wb_table3_83_4R2( false) ;
         }
         return  ;
      }

      protected void wb_table3_83_4R2e( bool wbgen )
      {
         if ( wbgen )
         {
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
               GxWebStd.gx_hidden_field( context, "W0090"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0090"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_48_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0090"+"");
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
         if ( wbEnd == 48 )
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

      protected void START4R2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Comercios", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4R0( ) ;
      }

      protected void WS4R2( )
      {
         START4R2( ) ;
         EVT4R2( ) ;
      }

      protected void EVT4R2( )
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
                              E114R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E124R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E134R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E144R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E154R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E164R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E174R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REPLICARRUBROS_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Replicarrubros_modal.Close */
                              E184R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REPLICARRUBROS_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Replicarrubros_modal.Onloadcomponent */
                              E194R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REPLICARPRECIOS2_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Replicarprecios2_modal.Close */
                              E204R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REPLICARPRECIOS2_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Replicarprecios2_modal.Onloadcomponent */
                              E214R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMUDANZA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoMudanza' */
                              E224R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E234R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.FINALIZARREPLICARPRECIOS") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E244R2 ();
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
                              nGXsfl_48_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
                              SubsflControlProps_482( ) ;
                              AV43GridBadge = cgiGet( edtavGridbadge_Internalname);
                              AssignAttri("", false, edtavGridbadge_Internalname, AV43GridBadge);
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV66GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV66GridActions), 4, 0));
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
                              A432ProveedorImagen = cgiGet( edtProveedorImagen_Internalname);
                              n432ProveedorImagen = false;
                              AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_48_Refreshing);
                              AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
                              A338ProveedorDocIdentidad = cgiGet( edtProveedorDocIdentidad_Internalname);
                              A430ProveedorTelefono = cgiGet( edtProveedorTelefono_Internalname);
                              n430ProveedorTelefono = false;
                              A431ProveedorDireccion = cgiGet( edtProveedorDireccion_Internalname);
                              n431ProveedorDireccion = false;
                              A433ProveedorEmail = cgiGet( edtProveedorEmail_Internalname);
                              n433ProveedorEmail = false;
                              cmbProveedorPagoDefault.Name = cmbProveedorPagoDefault_Internalname;
                              cmbProveedorPagoDefault.CurrentValue = cgiGet( cmbProveedorPagoDefault_Internalname);
                              A440ProveedorPagoDefault = cgiGet( cmbProveedorPagoDefault_Internalname);
                              cmbProveedorEstado.Name = cmbProveedorEstado_Internalname;
                              cmbProveedorEstado.CurrentValue = cgiGet( cmbProveedorEstado_Internalname);
                              A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavHacerload_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavHacerload_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vHACERLOAD");
                                 GX_FocusControl = edtavHacerload_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV34HacerLoad = 0;
                                 AssignAttri("", false, edtavHacerload_Internalname, StringUtil.Str( (decimal)(AV34HacerLoad), 1, 0));
                              }
                              else
                              {
                                 AV34HacerLoad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavHacerload_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavHacerload_Internalname, StringUtil.Str( (decimal)(AV34HacerLoad), 1, 0));
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
                                    E254R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E264R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E274R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E284R2 ();
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 90 )
                        {
                           OldWwpaux_wc = cgiGet( "W0090");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0090", "", sEvt);
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

      protected void WE4R2( )
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

      protected void PA4R2( )
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
         SubsflControlProps_482( ) ;
         while ( nGXsfl_48_idx <= nRC_GXsfl_48 )
         {
            sendrow_482( ) ;
            nGXsfl_48_idx = ((subGrid_Islastpage==1)&&(nGXsfl_48_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_482( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       short AV46ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ,
                                       string AV105Pgmname ,
                                       short AV42GridConditionalFormattingFilter ,
                                       string AV17FilterFullText ,
                                       long AV47TFProveedorID ,
                                       long AV48TFProveedorID_To ,
                                       string AV49TFProveedorNombre ,
                                       string AV50TFProveedorNombre_Sel ,
                                       string AV51TFProveedorDocIdentidad ,
                                       string AV52TFProveedorDocIdentidad_Sel ,
                                       string AV53TFProveedorTelefono ,
                                       string AV54TFProveedorTelefono_Sel ,
                                       string AV55TFProveedorDireccion ,
                                       string AV56TFProveedorDireccion_Sel ,
                                       string AV57TFProveedorEmail ,
                                       string AV58TFProveedorEmail_Sel ,
                                       GxSimpleCollection<string> AV88TFProveedorPagoDefault_Sels ,
                                       GxSimpleCollection<string> AV60TFProveedorEstado_Sels ,
                                       short AV34HacerLoad ,
                                       string AV76SecRoleName ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ,
                                       bool AV90IsAuthorized_Estadisticas ,
                                       bool AV92IsAuthorized_DesaINV ,
                                       bool AV104IsAuthorized_ReplicarRubros ,
                                       bool AV99IsAuthorized_ReplicarPrecios2 ,
                                       bool AV68IsAuthorized_Update ,
                                       bool AV69IsAuthorized_Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4R2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", "")));
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
         RF4R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV105Pgmname = "ProveedorWW";
         edtavGridbadge_Enabled = 0;
         edtavHacerload_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV106Proveedorwwds_1_gridconditionalformattingfilter = AV42GridConditionalFormattingFilter;
         AV107Proveedorwwds_2_filterfulltext = AV17FilterFullText;
         AV108Proveedorwwds_3_tfproveedorid = AV47TFProveedorID;
         AV109Proveedorwwds_4_tfproveedorid_to = AV48TFProveedorID_To;
         AV110Proveedorwwds_5_tfproveedornombre = AV49TFProveedorNombre;
         AV111Proveedorwwds_6_tfproveedornombre_sel = AV50TFProveedorNombre_Sel;
         AV112Proveedorwwds_7_tfproveedordocidentidad = AV51TFProveedorDocIdentidad;
         AV113Proveedorwwds_8_tfproveedordocidentidad_sel = AV52TFProveedorDocIdentidad_Sel;
         AV114Proveedorwwds_9_tfproveedortelefono = AV53TFProveedorTelefono;
         AV115Proveedorwwds_10_tfproveedortelefono_sel = AV54TFProveedorTelefono_Sel;
         AV116Proveedorwwds_11_tfproveedordireccion = AV55TFProveedorDireccion;
         AV117Proveedorwwds_12_tfproveedordireccion_sel = AV56TFProveedorDireccion_Sel;
         AV118Proveedorwwds_13_tfproveedoremail = AV57TFProveedorEmail;
         AV119Proveedorwwds_14_tfproveedoremail_sel = AV58TFProveedorEmail_Sel;
         AV120Proveedorwwds_15_tfproveedorpagodefault_sels = AV88TFProveedorPagoDefault_Sels;
         AV121Proveedorwwds_16_tfproveedorestado_sels = AV60TFProveedorEstado_Sels;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A440ProveedorPagoDefault ,
                                              AV120Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                              A344ProveedorEstado ,
                                              AV121Proveedorwwds_16_tfproveedorestado_sels ,
                                              AV106Proveedorwwds_1_gridconditionalformattingfilter ,
                                              AV108Proveedorwwds_3_tfproveedorid ,
                                              AV109Proveedorwwds_4_tfproveedorid_to ,
                                              AV111Proveedorwwds_6_tfproveedornombre_sel ,
                                              AV110Proveedorwwds_5_tfproveedornombre ,
                                              AV113Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                              AV112Proveedorwwds_7_tfproveedordocidentidad ,
                                              AV115Proveedorwwds_10_tfproveedortelefono_sel ,
                                              AV114Proveedorwwds_9_tfproveedortelefono ,
                                              AV117Proveedorwwds_12_tfproveedordireccion_sel ,
                                              AV116Proveedorwwds_11_tfproveedordireccion ,
                                              AV119Proveedorwwds_14_tfproveedoremail_sel ,
                                              AV118Proveedorwwds_13_tfproveedoremail ,
                                              AV120Proveedorwwds_15_tfproveedorpagodefault_sels.Count ,
                                              AV121Proveedorwwds_16_tfproveedorestado_sels.Count ,
                                              AV102VerTodProv ,
                                              AV34HacerLoad ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV107Proveedorwwds_2_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV110Proveedorwwds_5_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV110Proveedorwwds_5_tfproveedornombre), 80, "%");
         lV112Proveedorwwds_7_tfproveedordocidentidad = StringUtil.PadR( StringUtil.RTrim( AV112Proveedorwwds_7_tfproveedordocidentidad), 25, "%");
         lV114Proveedorwwds_9_tfproveedortelefono = StringUtil.PadR( StringUtil.RTrim( AV114Proveedorwwds_9_tfproveedortelefono), 20, "%");
         lV116Proveedorwwds_11_tfproveedordireccion = StringUtil.Concat( StringUtil.RTrim( AV116Proveedorwwds_11_tfproveedordireccion), "%", "");
         lV118Proveedorwwds_13_tfproveedoremail = StringUtil.Concat( StringUtil.RTrim( AV118Proveedorwwds_13_tfproveedoremail), "%", "");
         /* Using cursor H004R2 */
         pr_default.execute(0, new Object[] {AV34HacerLoad, AV108Proveedorwwds_3_tfproveedorid, AV109Proveedorwwds_4_tfproveedorid_to, lV110Proveedorwwds_5_tfproveedornombre, AV111Proveedorwwds_6_tfproveedornombre_sel, lV112Proveedorwwds_7_tfproveedordocidentidad, AV113Proveedorwwds_8_tfproveedordocidentidad_sel, lV114Proveedorwwds_9_tfproveedortelefono, AV115Proveedorwwds_10_tfproveedortelefono_sel, lV116Proveedorwwds_11_tfproveedordireccion, AV117Proveedorwwds_12_tfproveedordireccion_sel, lV118Proveedorwwds_13_tfproveedoremail, AV119Proveedorwwds_14_tfproveedoremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A344ProveedorEstado = H004R2_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = H004R2_A440ProveedorPagoDefault[0];
            A433ProveedorEmail = H004R2_A433ProveedorEmail[0];
            n433ProveedorEmail = H004R2_n433ProveedorEmail[0];
            A431ProveedorDireccion = H004R2_A431ProveedorDireccion[0];
            n431ProveedorDireccion = H004R2_n431ProveedorDireccion[0];
            A430ProveedorTelefono = H004R2_A430ProveedorTelefono[0];
            n430ProveedorTelefono = H004R2_n430ProveedorTelefono[0];
            A338ProveedorDocIdentidad = H004R2_A338ProveedorDocIdentidad[0];
            A40000ProveedorImagen_GXI = H004R2_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = H004R2_n40000ProveedorImagen_GXI[0];
            AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_48_Refreshing);
            AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A282ProveedorNombre = H004R2_A282ProveedorNombre[0];
            A133ProveedorID = H004R2_A133ProveedorID[0];
            A432ProveedorImagen = H004R2_A432ProveedorImagen[0];
            n432ProveedorImagen = H004R2_n432ProveedorImagen[0];
            AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_48_Refreshing);
            AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Proveedorwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV107Proveedorwwds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) )
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

      protected void RF4R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 48;
         /* Execute user event: Refresh */
         E264R2 ();
         nGXsfl_48_idx = 1;
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_482( ) ;
         bGXsfl_48_Refreshing = true;
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
            SubsflControlProps_482( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A440ProveedorPagoDefault ,
                                                 AV120Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                                 A344ProveedorEstado ,
                                                 AV121Proveedorwwds_16_tfproveedorestado_sels ,
                                                 AV106Proveedorwwds_1_gridconditionalformattingfilter ,
                                                 AV108Proveedorwwds_3_tfproveedorid ,
                                                 AV109Proveedorwwds_4_tfproveedorid_to ,
                                                 AV111Proveedorwwds_6_tfproveedornombre_sel ,
                                                 AV110Proveedorwwds_5_tfproveedornombre ,
                                                 AV113Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                                 AV112Proveedorwwds_7_tfproveedordocidentidad ,
                                                 AV115Proveedorwwds_10_tfproveedortelefono_sel ,
                                                 AV114Proveedorwwds_9_tfproveedortelefono ,
                                                 AV117Proveedorwwds_12_tfproveedordireccion_sel ,
                                                 AV116Proveedorwwds_11_tfproveedordireccion ,
                                                 AV119Proveedorwwds_14_tfproveedoremail_sel ,
                                                 AV118Proveedorwwds_13_tfproveedoremail ,
                                                 AV120Proveedorwwds_15_tfproveedorpagodefault_sels.Count ,
                                                 AV121Proveedorwwds_16_tfproveedorestado_sels.Count ,
                                                 AV102VerTodProv ,
                                                 AV34HacerLoad ,
                                                 A133ProveedorID ,
                                                 A282ProveedorNombre ,
                                                 A338ProveedorDocIdentidad ,
                                                 A430ProveedorTelefono ,
                                                 A431ProveedorDireccion ,
                                                 A433ProveedorEmail ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV107Proveedorwwds_2_filterfulltext } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV110Proveedorwwds_5_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV110Proveedorwwds_5_tfproveedornombre), 80, "%");
            lV112Proveedorwwds_7_tfproveedordocidentidad = StringUtil.PadR( StringUtil.RTrim( AV112Proveedorwwds_7_tfproveedordocidentidad), 25, "%");
            lV114Proveedorwwds_9_tfproveedortelefono = StringUtil.PadR( StringUtil.RTrim( AV114Proveedorwwds_9_tfproveedortelefono), 20, "%");
            lV116Proveedorwwds_11_tfproveedordireccion = StringUtil.Concat( StringUtil.RTrim( AV116Proveedorwwds_11_tfproveedordireccion), "%", "");
            lV118Proveedorwwds_13_tfproveedoremail = StringUtil.Concat( StringUtil.RTrim( AV118Proveedorwwds_13_tfproveedoremail), "%", "");
            /* Using cursor H004R3 */
            pr_default.execute(1, new Object[] {AV34HacerLoad, AV108Proveedorwwds_3_tfproveedorid, AV109Proveedorwwds_4_tfproveedorid_to, lV110Proveedorwwds_5_tfproveedornombre, AV111Proveedorwwds_6_tfproveedornombre_sel, lV112Proveedorwwds_7_tfproveedordocidentidad, AV113Proveedorwwds_8_tfproveedordocidentidad_sel, lV114Proveedorwwds_9_tfproveedortelefono, AV115Proveedorwwds_10_tfproveedortelefono_sel, lV116Proveedorwwds_11_tfproveedordireccion, AV117Proveedorwwds_12_tfproveedordireccion_sel, lV118Proveedorwwds_13_tfproveedoremail, AV119Proveedorwwds_14_tfproveedoremail_sel});
            nGXsfl_48_idx = 1;
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_482( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A344ProveedorEstado = H004R3_A344ProveedorEstado[0];
               A440ProveedorPagoDefault = H004R3_A440ProveedorPagoDefault[0];
               A433ProveedorEmail = H004R3_A433ProveedorEmail[0];
               n433ProveedorEmail = H004R3_n433ProveedorEmail[0];
               A431ProveedorDireccion = H004R3_A431ProveedorDireccion[0];
               n431ProveedorDireccion = H004R3_n431ProveedorDireccion[0];
               A430ProveedorTelefono = H004R3_A430ProveedorTelefono[0];
               n430ProveedorTelefono = H004R3_n430ProveedorTelefono[0];
               A338ProveedorDocIdentidad = H004R3_A338ProveedorDocIdentidad[0];
               A40000ProveedorImagen_GXI = H004R3_A40000ProveedorImagen_GXI[0];
               n40000ProveedorImagen_GXI = H004R3_n40000ProveedorImagen_GXI[0];
               AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_48_Refreshing);
               AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
               A282ProveedorNombre = H004R3_A282ProveedorNombre[0];
               A133ProveedorID = H004R3_A133ProveedorID[0];
               A432ProveedorImagen = H004R3_A432ProveedorImagen[0];
               n432ProveedorImagen = H004R3_n432ProveedorImagen[0];
               AssignProp("", false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_48_Refreshing);
               AssignProp("", false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Proveedorwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV107Proveedorwwds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV107Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E274R2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 48;
            WB4R0( ) ;
         }
         bGXsfl_48_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4R2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV105Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV105Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECROLENAME", AV76SecRoleName);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV76SecRoleName, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADISTICAS", AV90IsAuthorized_Estadisticas);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADISTICAS", GetSecureSignedToken( "", AV90IsAuthorized_Estadisticas, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DESAINV", AV92IsAuthorized_DesaINV);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESAINV", GetSecureSignedToken( "", AV92IsAuthorized_DesaINV, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_REPLICARRUBROS", AV104IsAuthorized_ReplicarRubros);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REPLICARRUBROS", GetSecureSignedToken( "", AV104IsAuthorized_ReplicarRubros, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_REPLICARPRECIOS2", AV99IsAuthorized_ReplicarPrecios2);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REPLICARPRECIOS2", GetSecureSignedToken( "", AV99IsAuthorized_ReplicarPrecios2, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV68IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV68IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV69IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV69IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROVEEDORID"+"_"+sGXsfl_48_idx, GetSecureSignedToken( sGXsfl_48_idx, context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         AV106Proveedorwwds_1_gridconditionalformattingfilter = AV42GridConditionalFormattingFilter;
         AV107Proveedorwwds_2_filterfulltext = AV17FilterFullText;
         AV108Proveedorwwds_3_tfproveedorid = AV47TFProveedorID;
         AV109Proveedorwwds_4_tfproveedorid_to = AV48TFProveedorID_To;
         AV110Proveedorwwds_5_tfproveedornombre = AV49TFProveedorNombre;
         AV111Proveedorwwds_6_tfproveedornombre_sel = AV50TFProveedorNombre_Sel;
         AV112Proveedorwwds_7_tfproveedordocidentidad = AV51TFProveedorDocIdentidad;
         AV113Proveedorwwds_8_tfproveedordocidentidad_sel = AV52TFProveedorDocIdentidad_Sel;
         AV114Proveedorwwds_9_tfproveedortelefono = AV53TFProveedorTelefono;
         AV115Proveedorwwds_10_tfproveedortelefono_sel = AV54TFProveedorTelefono_Sel;
         AV116Proveedorwwds_11_tfproveedordireccion = AV55TFProveedorDireccion;
         AV117Proveedorwwds_12_tfproveedordireccion_sel = AV56TFProveedorDireccion_Sel;
         AV118Proveedorwwds_13_tfproveedoremail = AV57TFProveedorEmail;
         AV119Proveedorwwds_14_tfproveedoremail_sel = AV58TFProveedorEmail_Sel;
         AV120Proveedorwwds_15_tfproveedorpagodefault_sels = AV88TFProveedorPagoDefault_Sels;
         AV121Proveedorwwds_16_tfproveedorestado_sels = AV60TFProveedorEstado_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV46ManageFiltersExecutionStep, AV39ColumnsSelector, AV105Pgmname, AV42GridConditionalFormattingFilter, AV17FilterFullText, AV47TFProveedorID, AV48TFProveedorID_To, AV49TFProveedorNombre, AV50TFProveedorNombre_Sel, AV51TFProveedorDocIdentidad, AV52TFProveedorDocIdentidad_Sel, AV53TFProveedorTelefono, AV54TFProveedorTelefono_Sel, AV55TFProveedorDireccion, AV56TFProveedorDireccion_Sel, AV57TFProveedorEmail, AV58TFProveedorEmail_Sel, AV88TFProveedorPagoDefault_Sels, AV60TFProveedorEstado_Sels, AV34HacerLoad, AV76SecRoleName, AV6WWPContext, AV90IsAuthorized_Estadisticas, AV92IsAuthorized_DesaINV, AV104IsAuthorized_ReplicarRubros, AV99IsAuthorized_ReplicarPrecios2, AV68IsAuthorized_Update, AV69IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV106Proveedorwwds_1_gridconditionalformattingfilter = AV42GridConditionalFormattingFilter;
         AV107Proveedorwwds_2_filterfulltext = AV17FilterFullText;
         AV108Proveedorwwds_3_tfproveedorid = AV47TFProveedorID;
         AV109Proveedorwwds_4_tfproveedorid_to = AV48TFProveedorID_To;
         AV110Proveedorwwds_5_tfproveedornombre = AV49TFProveedorNombre;
         AV111Proveedorwwds_6_tfproveedornombre_sel = AV50TFProveedorNombre_Sel;
         AV112Proveedorwwds_7_tfproveedordocidentidad = AV51TFProveedorDocIdentidad;
         AV113Proveedorwwds_8_tfproveedordocidentidad_sel = AV52TFProveedorDocIdentidad_Sel;
         AV114Proveedorwwds_9_tfproveedortelefono = AV53TFProveedorTelefono;
         AV115Proveedorwwds_10_tfproveedortelefono_sel = AV54TFProveedorTelefono_Sel;
         AV116Proveedorwwds_11_tfproveedordireccion = AV55TFProveedorDireccion;
         AV117Proveedorwwds_12_tfproveedordireccion_sel = AV56TFProveedorDireccion_Sel;
         AV118Proveedorwwds_13_tfproveedoremail = AV57TFProveedorEmail;
         AV119Proveedorwwds_14_tfproveedoremail_sel = AV58TFProveedorEmail_Sel;
         AV120Proveedorwwds_15_tfproveedorpagodefault_sels = AV88TFProveedorPagoDefault_Sels;
         AV121Proveedorwwds_16_tfproveedorestado_sels = AV60TFProveedorEstado_Sels;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV46ManageFiltersExecutionStep, AV39ColumnsSelector, AV105Pgmname, AV42GridConditionalFormattingFilter, AV17FilterFullText, AV47TFProveedorID, AV48TFProveedorID_To, AV49TFProveedorNombre, AV50TFProveedorNombre_Sel, AV51TFProveedorDocIdentidad, AV52TFProveedorDocIdentidad_Sel, AV53TFProveedorTelefono, AV54TFProveedorTelefono_Sel, AV55TFProveedorDireccion, AV56TFProveedorDireccion_Sel, AV57TFProveedorEmail, AV58TFProveedorEmail_Sel, AV88TFProveedorPagoDefault_Sels, AV60TFProveedorEstado_Sels, AV34HacerLoad, AV76SecRoleName, AV6WWPContext, AV90IsAuthorized_Estadisticas, AV92IsAuthorized_DesaINV, AV104IsAuthorized_ReplicarRubros, AV99IsAuthorized_ReplicarPrecios2, AV68IsAuthorized_Update, AV69IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV106Proveedorwwds_1_gridconditionalformattingfilter = AV42GridConditionalFormattingFilter;
         AV107Proveedorwwds_2_filterfulltext = AV17FilterFullText;
         AV108Proveedorwwds_3_tfproveedorid = AV47TFProveedorID;
         AV109Proveedorwwds_4_tfproveedorid_to = AV48TFProveedorID_To;
         AV110Proveedorwwds_5_tfproveedornombre = AV49TFProveedorNombre;
         AV111Proveedorwwds_6_tfproveedornombre_sel = AV50TFProveedorNombre_Sel;
         AV112Proveedorwwds_7_tfproveedordocidentidad = AV51TFProveedorDocIdentidad;
         AV113Proveedorwwds_8_tfproveedordocidentidad_sel = AV52TFProveedorDocIdentidad_Sel;
         AV114Proveedorwwds_9_tfproveedortelefono = AV53TFProveedorTelefono;
         AV115Proveedorwwds_10_tfproveedortelefono_sel = AV54TFProveedorTelefono_Sel;
         AV116Proveedorwwds_11_tfproveedordireccion = AV55TFProveedorDireccion;
         AV117Proveedorwwds_12_tfproveedordireccion_sel = AV56TFProveedorDireccion_Sel;
         AV118Proveedorwwds_13_tfproveedoremail = AV57TFProveedorEmail;
         AV119Proveedorwwds_14_tfproveedoremail_sel = AV58TFProveedorEmail_Sel;
         AV120Proveedorwwds_15_tfproveedorpagodefault_sels = AV88TFProveedorPagoDefault_Sels;
         AV121Proveedorwwds_16_tfproveedorestado_sels = AV60TFProveedorEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV46ManageFiltersExecutionStep, AV39ColumnsSelector, AV105Pgmname, AV42GridConditionalFormattingFilter, AV17FilterFullText, AV47TFProveedorID, AV48TFProveedorID_To, AV49TFProveedorNombre, AV50TFProveedorNombre_Sel, AV51TFProveedorDocIdentidad, AV52TFProveedorDocIdentidad_Sel, AV53TFProveedorTelefono, AV54TFProveedorTelefono_Sel, AV55TFProveedorDireccion, AV56TFProveedorDireccion_Sel, AV57TFProveedorEmail, AV58TFProveedorEmail_Sel, AV88TFProveedorPagoDefault_Sels, AV60TFProveedorEstado_Sels, AV34HacerLoad, AV76SecRoleName, AV6WWPContext, AV90IsAuthorized_Estadisticas, AV92IsAuthorized_DesaINV, AV104IsAuthorized_ReplicarRubros, AV99IsAuthorized_ReplicarPrecios2, AV68IsAuthorized_Update, AV69IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV106Proveedorwwds_1_gridconditionalformattingfilter = AV42GridConditionalFormattingFilter;
         AV107Proveedorwwds_2_filterfulltext = AV17FilterFullText;
         AV108Proveedorwwds_3_tfproveedorid = AV47TFProveedorID;
         AV109Proveedorwwds_4_tfproveedorid_to = AV48TFProveedorID_To;
         AV110Proveedorwwds_5_tfproveedornombre = AV49TFProveedorNombre;
         AV111Proveedorwwds_6_tfproveedornombre_sel = AV50TFProveedorNombre_Sel;
         AV112Proveedorwwds_7_tfproveedordocidentidad = AV51TFProveedorDocIdentidad;
         AV113Proveedorwwds_8_tfproveedordocidentidad_sel = AV52TFProveedorDocIdentidad_Sel;
         AV114Proveedorwwds_9_tfproveedortelefono = AV53TFProveedorTelefono;
         AV115Proveedorwwds_10_tfproveedortelefono_sel = AV54TFProveedorTelefono_Sel;
         AV116Proveedorwwds_11_tfproveedordireccion = AV55TFProveedorDireccion;
         AV117Proveedorwwds_12_tfproveedordireccion_sel = AV56TFProveedorDireccion_Sel;
         AV118Proveedorwwds_13_tfproveedoremail = AV57TFProveedorEmail;
         AV119Proveedorwwds_14_tfproveedoremail_sel = AV58TFProveedorEmail_Sel;
         AV120Proveedorwwds_15_tfproveedorpagodefault_sels = AV88TFProveedorPagoDefault_Sels;
         AV121Proveedorwwds_16_tfproveedorestado_sels = AV60TFProveedorEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV46ManageFiltersExecutionStep, AV39ColumnsSelector, AV105Pgmname, AV42GridConditionalFormattingFilter, AV17FilterFullText, AV47TFProveedorID, AV48TFProveedorID_To, AV49TFProveedorNombre, AV50TFProveedorNombre_Sel, AV51TFProveedorDocIdentidad, AV52TFProveedorDocIdentidad_Sel, AV53TFProveedorTelefono, AV54TFProveedorTelefono_Sel, AV55TFProveedorDireccion, AV56TFProveedorDireccion_Sel, AV57TFProveedorEmail, AV58TFProveedorEmail_Sel, AV88TFProveedorPagoDefault_Sels, AV60TFProveedorEstado_Sels, AV34HacerLoad, AV76SecRoleName, AV6WWPContext, AV90IsAuthorized_Estadisticas, AV92IsAuthorized_DesaINV, AV104IsAuthorized_ReplicarRubros, AV99IsAuthorized_ReplicarPrecios2, AV68IsAuthorized_Update, AV69IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV106Proveedorwwds_1_gridconditionalformattingfilter = AV42GridConditionalFormattingFilter;
         AV107Proveedorwwds_2_filterfulltext = AV17FilterFullText;
         AV108Proveedorwwds_3_tfproveedorid = AV47TFProveedorID;
         AV109Proveedorwwds_4_tfproveedorid_to = AV48TFProveedorID_To;
         AV110Proveedorwwds_5_tfproveedornombre = AV49TFProveedorNombre;
         AV111Proveedorwwds_6_tfproveedornombre_sel = AV50TFProveedorNombre_Sel;
         AV112Proveedorwwds_7_tfproveedordocidentidad = AV51TFProveedorDocIdentidad;
         AV113Proveedorwwds_8_tfproveedordocidentidad_sel = AV52TFProveedorDocIdentidad_Sel;
         AV114Proveedorwwds_9_tfproveedortelefono = AV53TFProveedorTelefono;
         AV115Proveedorwwds_10_tfproveedortelefono_sel = AV54TFProveedorTelefono_Sel;
         AV116Proveedorwwds_11_tfproveedordireccion = AV55TFProveedorDireccion;
         AV117Proveedorwwds_12_tfproveedordireccion_sel = AV56TFProveedorDireccion_Sel;
         AV118Proveedorwwds_13_tfproveedoremail = AV57TFProveedorEmail;
         AV119Proveedorwwds_14_tfproveedoremail_sel = AV58TFProveedorEmail_Sel;
         AV120Proveedorwwds_15_tfproveedorpagodefault_sels = AV88TFProveedorPagoDefault_Sels;
         AV121Proveedorwwds_16_tfproveedorestado_sels = AV60TFProveedorEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV46ManageFiltersExecutionStep, AV39ColumnsSelector, AV105Pgmname, AV42GridConditionalFormattingFilter, AV17FilterFullText, AV47TFProveedorID, AV48TFProveedorID_To, AV49TFProveedorNombre, AV50TFProveedorNombre_Sel, AV51TFProveedorDocIdentidad, AV52TFProveedorDocIdentidad_Sel, AV53TFProveedorTelefono, AV54TFProveedorTelefono_Sel, AV55TFProveedorDireccion, AV56TFProveedorDireccion_Sel, AV57TFProveedorEmail, AV58TFProveedorEmail_Sel, AV88TFProveedorPagoDefault_Sels, AV60TFProveedorEstado_Sels, AV34HacerLoad, AV76SecRoleName, AV6WWPContext, AV90IsAuthorized_Estadisticas, AV92IsAuthorized_DesaINV, AV104IsAuthorized_ReplicarRubros, AV99IsAuthorized_ReplicarPrecios2, AV68IsAuthorized_Update, AV69IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV105Pgmname = "ProveedorWW";
         edtavGridbadge_Enabled = 0;
         edtavHacerload_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProveedorImagen_Enabled = 0;
         edtProveedorDocIdentidad_Enabled = 0;
         edtProveedorTelefono_Enabled = 0;
         edtProveedorDireccion_Enabled = 0;
         edtProveedorEmail_Enabled = 0;
         cmbProveedorPagoDefault.Enabled = 0;
         cmbProveedorEstado.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E254R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV44ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV70AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV61DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV39ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_48 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_48"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV63GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV64GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV65GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Newwindow_Target = cgiGet( "NEWWINDOW_Target");
            Newwindow2_Width = cgiGet( "NEWWINDOW2_Width");
            Newwindow2_Height = cgiGet( "NEWWINDOW2_Height");
            Newwindow2_Target = cgiGet( "NEWWINDOW2_Target");
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
            Ddo_grid_Fixedfilters = cgiGet( "DDO_GRID_Fixedfilters");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Ddo_grid_Selectedfixedfilter = cgiGet( "DDO_GRID_Selectedfixedfilter");
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
            Replicarrubros_modal_Width = cgiGet( "REPLICARRUBROS_MODAL_Width");
            Replicarrubros_modal_Title = cgiGet( "REPLICARRUBROS_MODAL_Title");
            Replicarrubros_modal_Confirmtype = cgiGet( "REPLICARRUBROS_MODAL_Confirmtype");
            Replicarrubros_modal_Bodytype = cgiGet( "REPLICARRUBROS_MODAL_Bodytype");
            Replicarprecios2_modal_Width = cgiGet( "REPLICARPRECIOS2_MODAL_Width");
            Replicarprecios2_modal_Title = cgiGet( "REPLICARPRECIOS2_MODAL_Title");
            Replicarprecios2_modal_Confirmtype = cgiGet( "REPLICARPRECIOS2_MODAL_Confirmtype");
            Replicarprecios2_modal_Bodytype = cgiGet( "REPLICARPRECIOS2_MODAL_Bodytype");
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
            Ddo_grid_Selectedcolumnfixedfilter = cgiGet( "DDO_GRID_Selectedcolumnfixedfilter");
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
         E254R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E254R2( )
      {
         /* Start Routine */
         returnInSub = false;
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
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV70AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV71AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV71AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV71AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV71AGExportDataItem.gxTpr_Eventkey = "Export";
         AV71AGExportDataItem.gxTpr_Isdivider = false;
         AV70AGExportData.Add(AV71AGExportDataItem, 0);
         AV71AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV71AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV71AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV71AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV71AGExportDataItem.gxTpr_Isdivider = false;
         AV70AGExportData.Add(AV71AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Comercios", "");
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
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV61DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV61DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'OBTENGO ROL' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV34HacerLoad = 0;
         AssignAttri("", false, edtavHacerload_Internalname, StringUtil.Str( (decimal)(AV34HacerLoad), 1, 0));
         new oparametros(context ).execute(  context.GetMessage( "LIKSOLICITUDES", ""), out  AV84ParametrosValor, out  AV86ParametrosNumerico, out  AV85ParametrosEstado) ;
      }

      protected void E264R2( )
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
         S172 ();
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
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV41Session.Get("ProveedorWWColumnsSelector"), "") != 0 )
         {
            AV37ColumnsSelectorXML = AV41Session.Get("ProveedorWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV37ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtProveedorID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorID_Visible), 5, 0), !bGXsfl_48_Refreshing);
         edtProveedorNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Visible), 5, 0), !bGXsfl_48_Refreshing);
         edtProveedorImagen_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorImagen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorImagen_Visible), 5, 0), !bGXsfl_48_Refreshing);
         edtProveedorDocIdentidad_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorDocIdentidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorDocIdentidad_Visible), 5, 0), !bGXsfl_48_Refreshing);
         edtProveedorTelefono_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorTelefono_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorTelefono_Visible), 5, 0), !bGXsfl_48_Refreshing);
         edtProveedorDireccion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorDireccion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorDireccion_Visible), 5, 0), !bGXsfl_48_Refreshing);
         edtProveedorEmail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorEmail_Visible), 5, 0), !bGXsfl_48_Refreshing);
         cmbProveedorPagoDefault.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbProveedorPagoDefault_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbProveedorPagoDefault.Visible), 5, 0), !bGXsfl_48_Refreshing);
         cmbProveedorEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbProveedorEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Visible), 5, 0), !bGXsfl_48_Refreshing);
         edtavHacerload_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavHacerload_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavHacerload_Visible), 5, 0), !bGXsfl_48_Refreshing);
         AV63GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV63GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV63GridCurrentPage), 10, 0));
         AV64GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV64GridPageCount", StringUtil.LTrimStr( (decimal)(AV64GridPageCount), 10, 0));
         GXt_char2 = AV65GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV105Pgmname, out  GXt_char2) ;
         AV65GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV65GridAppliedFilters", AV65GridAppliedFilters);
         cmbProveedorEstado_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbProveedorEstado_Internalname, "Columnheaderclass", cmbProveedorEstado_Columnheaderclass, !bGXsfl_48_Refreshing);
         AV106Proveedorwwds_1_gridconditionalformattingfilter = AV42GridConditionalFormattingFilter;
         AV107Proveedorwwds_2_filterfulltext = AV17FilterFullText;
         AV108Proveedorwwds_3_tfproveedorid = AV47TFProveedorID;
         AV109Proveedorwwds_4_tfproveedorid_to = AV48TFProveedorID_To;
         AV110Proveedorwwds_5_tfproveedornombre = AV49TFProveedorNombre;
         AV111Proveedorwwds_6_tfproveedornombre_sel = AV50TFProveedorNombre_Sel;
         AV112Proveedorwwds_7_tfproveedordocidentidad = AV51TFProveedorDocIdentidad;
         AV113Proveedorwwds_8_tfproveedordocidentidad_sel = AV52TFProveedorDocIdentidad_Sel;
         AV114Proveedorwwds_9_tfproveedortelefono = AV53TFProveedorTelefono;
         AV115Proveedorwwds_10_tfproveedortelefono_sel = AV54TFProveedorTelefono_Sel;
         AV116Proveedorwwds_11_tfproveedordireccion = AV55TFProveedorDireccion;
         AV117Proveedorwwds_12_tfproveedordireccion_sel = AV56TFProveedorDireccion_Sel;
         AV118Proveedorwwds_13_tfproveedoremail = AV57TFProveedorEmail;
         AV119Proveedorwwds_14_tfproveedoremail_sel = AV58TFProveedorEmail_Sel;
         AV120Proveedorwwds_15_tfproveedorpagodefault_sels = AV88TFProveedorPagoDefault_Sels;
         AV121Proveedorwwds_16_tfproveedorestado_sels = AV60TFProveedorEstado_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E124R2( )
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
            AV62PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV62PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E134R2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E164R2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TagColumn") == 0 )
            {
               AV42GridConditionalFormattingFilter = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedcolumnfixedfilter, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42GridConditionalFormattingFilter", StringUtil.LTrimStr( (decimal)(AV42GridConditionalFormattingFilter), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorID") == 0 )
            {
               AV47TFProveedorID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFProveedorID", StringUtil.LTrimStr( (decimal)(AV47TFProveedorID), 18, 0));
               AV48TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFProveedorID_To", StringUtil.LTrimStr( (decimal)(AV48TFProveedorID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorNombre") == 0 )
            {
               AV49TFProveedorNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV49TFProveedorNombre", AV49TFProveedorNombre);
               AV50TFProveedorNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV50TFProveedorNombre_Sel", AV50TFProveedorNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorDocIdentidad") == 0 )
            {
               AV51TFProveedorDocIdentidad = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV51TFProveedorDocIdentidad", AV51TFProveedorDocIdentidad);
               AV52TFProveedorDocIdentidad_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV52TFProveedorDocIdentidad_Sel", AV52TFProveedorDocIdentidad_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorTelefono") == 0 )
            {
               AV53TFProveedorTelefono = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV53TFProveedorTelefono", AV53TFProveedorTelefono);
               AV54TFProveedorTelefono_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV54TFProveedorTelefono_Sel", AV54TFProveedorTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorDireccion") == 0 )
            {
               AV55TFProveedorDireccion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV55TFProveedorDireccion", AV55TFProveedorDireccion);
               AV56TFProveedorDireccion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV56TFProveedorDireccion_Sel", AV56TFProveedorDireccion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorEmail") == 0 )
            {
               AV57TFProveedorEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV57TFProveedorEmail", AV57TFProveedorEmail);
               AV58TFProveedorEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV58TFProveedorEmail_Sel", AV58TFProveedorEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorPagoDefault") == 0 )
            {
               AV87TFProveedorPagoDefault_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV87TFProveedorPagoDefault_SelsJson", AV87TFProveedorPagoDefault_SelsJson);
               AV88TFProveedorPagoDefault_Sels.FromJSonString(AV87TFProveedorPagoDefault_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorEstado") == 0 )
            {
               AV59TFProveedorEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV59TFProveedorEstado_SelsJson", AV59TFProveedorEstado_SelsJson);
               AV60TFProveedorEstado_Sels.FromJSonString(AV59TFProveedorEstado_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60TFProveedorEstado_Sels", AV60TFProveedorEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV88TFProveedorPagoDefault_Sels", AV88TFProveedorPagoDefault_Sels);
      }

      private void E274R2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV34HacerLoad = (short)(Math.Round(NumberUtil.Val( AV78proveedorProperty.Get(StringUtil.Str( (decimal)(A133ProveedorID), 18, 0)), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, edtavHacerload_Internalname, StringUtil.Str( (decimal)(AV34HacerLoad), 1, 0));
            if ( ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV76SecRoleName)), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV76SecRoleName)), context.GetMessage( "ADM GENERAL", "")) == 0 ) ) )
            {
               AV34HacerLoad = 1;
               AssignAttri("", false, edtavHacerload_Internalname, StringUtil.Str( (decimal)(AV34HacerLoad), 1, 0));
               AV78proveedorProperty.Set(StringUtil.Str( (decimal)(A133ProveedorID), 18, 0), StringUtil.Str( (decimal)(AV34HacerLoad), 1, 0));
            }
            else
            {
               if ( AV34HacerLoad == 0 )
               {
                  new olisagruserprovid(context ).execute(  AV6WWPContext.gxTpr_Userid,  A133ProveedorID,  "ADM", out  AV89Existe, out  AV79AgrProveedorEstado) ;
                  if ( StringUtil.StrCmp(AV79AgrProveedorEstado, "VIN") == 0 )
                  {
                     AV34HacerLoad = 1;
                     AssignAttri("", false, edtavHacerload_Internalname, StringUtil.Str( (decimal)(AV34HacerLoad), 1, 0));
                  }
                  else
                  {
                     AV34HacerLoad = 2;
                     AssignAttri("", false, edtavHacerload_Internalname, StringUtil.Str( (decimal)(AV34HacerLoad), 1, 0));
                  }
                  AV78proveedorProperty.Set(StringUtil.Str( (decimal)(A133ProveedorID), 18, 0), StringUtil.Str( (decimal)(AV34HacerLoad), 1, 0));
               }
            }
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            if ( 1 == 0 )
            {
               cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Alta de Solicitudes", ""), "fa fa-tasks", "", "", "", "", "", "", ""), 0);
            }
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Formulario de Instalaciones", ""), "fa fa-tasks", "", "", "", "", "", "", ""), 0);
            if ( AV90IsAuthorized_Estadisticas )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "Estadísticas", ""), "fas fa-chart-pie", "", "", "", "", "", "", ""), 0);
            }
            cmbavGridactions.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "Alta Postulación/Subasta", ""), "fa fa-tasks", "", "", "", "", "", "", ""), 0);
            if ( AV92IsAuthorized_DesaINV )
            {
               cmbavGridactions.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "Desactivar Rubros", ""), "fas fa-trash-can-arrow-up", "", "", "", "", "", "", ""), 0);
            }
            if ( AV104IsAuthorized_ReplicarRubros )
            {
               cmbavGridactions.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "Replicar Rubros en ...", ""), "fa fa-clone", "", "", "", "", "", "", ""), 0);
            }
            cmbavGridactions.addItem("7", StringUtil.Format( "%1;%2", context.GetMessage( "Replicar precios en...", ""), "fa-copy far", "", "", "", "", "", "", ""), 0);
            cmbavGridactions.addItem("8", StringUtil.Format( "%1;%2", context.GetMessage( "Nueva Mudanza", ""), "fas fa-box-open", "", "", "", "", "", "", ""), 0);
            cmbavGridactions.addItem("9", StringUtil.Format( "%1;%2", context.GetMessage( "Freezar Precios", ""), "fas fa-plane-lock", "", "", "", "", "", "", ""), 0);
            cmbavGridactions.addItem("10", StringUtil.Format( "%1;%2", context.GetMessage( "Eliminar Freezado", ""), "fas fa-unlock", "", "", "", "", "", "", ""), 0);
            if ( AV99IsAuthorized_ReplicarPrecios2 )
            {
               cmbavGridactions.addItem("11", StringUtil.Format( "%1;%2", context.GetMessage( "Replicar precios en...", ""), "fa-copy far", "", "", "", "", "", "", ""), 0);
            }
            cmbavGridactions.addItem("12", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV68IsAuthorized_Update )
            {
               cmbavGridactions.addItem("13", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV69IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("14", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "proveedorview.aspx"+UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtProveedorNombre_Link = formatLink("proveedorview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            if ( AV34HacerLoad == 1 )
            {
               AV43GridBadge = StringUtil.Format( "<i class='fa fa-check-circle FontColorIconSuccess	 BootstrapTooltipTop' title='%1'></i>", context.GetMessage( "Asignado", ""), "", "", "", "", "", "", "", "");
               AssignAttri("", false, edtavGridbadge_Internalname, AV43GridBadge);
            }
            else
            {
               AV43GridBadge = "";
               AssignAttri("", false, edtavGridbadge_Internalname, AV43GridBadge);
            }
            if ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 )
            {
               cmbProveedorEstado_Columnclass = "WWColumn WWColumnDanger WWColumnDangerSingleCell";
            }
            else if ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 )
            {
               cmbProveedorEstado_Columnclass = "WWColumn WWColumnWarning WWColumnWarningSingleCell";
            }
            else
            {
               cmbProveedorEstado_Columnclass = "WWColumn";
            }
            if ( AV34HacerLoad != 1 )
            {
               cmbavGridactions.removeItem(StringUtil.Str( (decimal)(3), 1, 0));
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 48;
            }
            sendrow_482( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_48_Refreshing )
         {
            context.DoAjaxLoad(48, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0));
      }

      protected void E174R2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV37ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV39ColumnsSelector.FromJSonString(AV37ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "ProveedorWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV37ColumnsSelectorXML)) ? "" : AV39ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E114R2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S202 ();
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
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("ProveedorWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV105Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV46ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV46ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV46ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("ProveedorWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV46ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV46ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV46ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV45ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ProveedorWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV45ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S202 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV105Pgmname+"GridState",  AV45ManageFiltersXml) ;
               AV11GridState.FromXml(AV45ManageFiltersXml, null, "", "");
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
               S212 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV88TFProveedorPagoDefault_Sels", AV88TFProveedorPagoDefault_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60TFProveedorEstado_Sels", AV60TFProveedorEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E284R2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV66GridActions == 1 )
         {
            /* Execute user subroutine: 'DO ALSASOLICITUDES' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 2 )
         {
            /* Execute user subroutine: 'DO SOLICITUDONEPAGE' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 3 )
         {
            /* Execute user subroutine: 'DO ESTADISTICAS' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 4 )
         {
            /* Execute user subroutine: 'DO ALTAPOSTULACIONES' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 5 )
         {
            /* Execute user subroutine: 'DO DESAINV' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 6 )
         {
            /* Execute user subroutine: 'DO REPLICARRUBROS' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 7 )
         {
            /* Execute user subroutine: 'DO REPLICARPRECIOS' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 8 )
         {
            /* Execute user subroutine: 'DO NUEVAMUDANZA' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 9 )
         {
            /* Execute user subroutine: 'DO FREEZAR' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 10 )
         {
            /* Execute user subroutine: 'DO ELIMINARFREEZAR' */
            S312 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 11 )
         {
            /* Execute user subroutine: 'DO REPLICARPRECIOS2' */
            S322 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 12 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S332 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 13 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S342 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 14 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S352 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV66GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV66GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E194R2( )
      {
         /* Replicarrubros_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "ReplicarRubrosWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "replicarrubroswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "ReplicarRubrosWC";
            WebComp_Wwpaux_wc_Component = "ReplicarRubrosWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0090",(string)"",(long)A133ProveedorID});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0090"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E184R2( )
      {
         /* Replicarrubros_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E214R2( )
      {
         /* Replicarprecios2_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "ReplicarPreciosWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "replicarprecioswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "ReplicarPreciosWC";
            WebComp_Wwpaux_wc_Component = "ReplicarPreciosWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0090",(string)"",(long)A133ProveedorID});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0090"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E204R2( )
      {
         /* Replicarprecios2_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E224R2( )
      {
         /* 'DoMudanza' Routine */
         returnInSub = false;
         AV97SecUserId = AV6WWPContext.gxTpr_Userid;
         GXt_int3 = AV95ProveedorId;
         new obtenermudanzaproveedorid(context ).execute( out  GXt_int3) ;
         AV95ProveedorId = GXt_int3;
         AV96WebSession.Set(context.GetMessage( "SecUserId", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV97SecUserId), 10, 0)));
         AV96WebSession.Set(context.GetMessage( "ProveedorNombre", ""), context.GetMessage( "ALMANGO MUDANZAS", ""));
         AV96WebSession.Set(context.GetMessage( "ProveedorId", ""), StringUtil.Str( (decimal)(AV95ProveedorId), 18, 0));
         CallWebObject(formatLink("mudanza.aspx", new object[] {UrlEncode(StringUtil.RTrim(context.GetMessage( "INS", ""))),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.LTrimStr(AV95ProveedorId,18,0)),UrlEncode(StringUtil.LTrimStr(AV97SecUserId,10,0))}, new string[] {"Mode","MudanzaId","ProveedorId","SecUserId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void E234R2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "proveedor.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("proveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E144R2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S362 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S372 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60TFProveedorEstado_Sels", AV60TFProveedorEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV88TFProveedorPagoDefault_Sels", AV88TFProveedorPagoDefault_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ColumnsSelector", AV39ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E154R2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0090",(string)"",(string)"Proveedor",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0090"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S192( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorID",  "",  "Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorImagen",  "",  "Imagen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorDocIdentidad",  "",  "Doc. Identidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorTelefono",  "",  "Teléfono",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorDireccion",  "",  "Dirección",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorPagoDefault",  "",  "Pago",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "&HacerLoad",  "",  "",  false,  "") ;
         GXt_char2 = AV38UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ProveedorWWColumnsSelector", out  GXt_char2) ;
         AV38UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38UserCustomValue)) ) )
         {
            AV40ColumnsSelectorAux.FromXml(AV38UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV40ColumnsSelectorAux, ref  AV39ColumnsSelector) ;
         }
      }

      protected void S172( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean4 = AV90IsAuthorized_Estadisticas;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "EstadisticasCOM", out  GXt_boolean4) ;
         AV90IsAuthorized_Estadisticas = GXt_boolean4;
         AssignAttri("", false, "AV90IsAuthorized_Estadisticas", AV90IsAuthorized_Estadisticas);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADISTICAS", GetSecureSignedToken( "", AV90IsAuthorized_Estadisticas, context));
         GXt_boolean4 = AV92IsAuthorized_DesaINV;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercioProductos", out  GXt_boolean4) ;
         AV92IsAuthorized_DesaINV = GXt_boolean4;
         AssignAttri("", false, "AV92IsAuthorized_DesaINV", AV92IsAuthorized_DesaINV);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESAINV", GetSecureSignedToken( "", AV92IsAuthorized_DesaINV, context));
         GXt_boolean4 = AV104IsAuthorized_ReplicarRubros;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyobjectname(context ).execute(  "ReplicarRubrosWC", out  GXt_boolean4) ;
         AV104IsAuthorized_ReplicarRubros = GXt_boolean4;
         AssignAttri("", false, "AV104IsAuthorized_ReplicarRubros", AV104IsAuthorized_ReplicarRubros);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REPLICARRUBROS", GetSecureSignedToken( "", AV104IsAuthorized_ReplicarRubros, context));
         GXt_boolean4 = AV99IsAuthorized_ReplicarPrecios2;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "ReplicarPreciosWC", out  GXt_boolean4) ;
         AV99IsAuthorized_ReplicarPrecios2 = GXt_boolean4;
         AssignAttri("", false, "AV99IsAuthorized_ReplicarPrecios2", AV99IsAuthorized_ReplicarPrecios2);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REPLICARPRECIOS2", GetSecureSignedToken( "", AV99IsAuthorized_ReplicarPrecios2, context));
         GXt_boolean4 = AV68IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Update", out  GXt_boolean4) ;
         AV68IsAuthorized_Update = GXt_boolean4;
         AssignAttri("", false, "AV68IsAuthorized_Update", AV68IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV68IsAuthorized_Update, context));
         GXt_boolean4 = AV69IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Delete", out  GXt_boolean4) ;
         AV69IsAuthorized_Delete = GXt_boolean4;
         AssignAttri("", false, "AV69IsAuthorized_Delete", AV69IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV69IsAuthorized_Delete, context));
         GXt_boolean4 = AV72TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Insert", out  GXt_boolean4) ;
         AV72TempBoolean = GXt_boolean4;
         if ( ! ( AV72TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean4 = AV72TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean4) ;
         AV72TempBoolean = GXt_boolean4;
         if ( ! ( AV72TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Proveedor",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S152( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV44ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ProveedorWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV44ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S202( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV47TFProveedorID = 0;
         AssignAttri("", false, "AV47TFProveedorID", StringUtil.LTrimStr( (decimal)(AV47TFProveedorID), 18, 0));
         AV48TFProveedorID_To = 0;
         AssignAttri("", false, "AV48TFProveedorID_To", StringUtil.LTrimStr( (decimal)(AV48TFProveedorID_To), 18, 0));
         AV49TFProveedorNombre = "";
         AssignAttri("", false, "AV49TFProveedorNombre", AV49TFProveedorNombre);
         AV50TFProveedorNombre_Sel = "";
         AssignAttri("", false, "AV50TFProveedorNombre_Sel", AV50TFProveedorNombre_Sel);
         AV51TFProveedorDocIdentidad = "";
         AssignAttri("", false, "AV51TFProveedorDocIdentidad", AV51TFProveedorDocIdentidad);
         AV52TFProveedorDocIdentidad_Sel = "";
         AssignAttri("", false, "AV52TFProveedorDocIdentidad_Sel", AV52TFProveedorDocIdentidad_Sel);
         AV53TFProveedorTelefono = "";
         AssignAttri("", false, "AV53TFProveedorTelefono", AV53TFProveedorTelefono);
         AV54TFProveedorTelefono_Sel = "";
         AssignAttri("", false, "AV54TFProveedorTelefono_Sel", AV54TFProveedorTelefono_Sel);
         AV55TFProveedorDireccion = "";
         AssignAttri("", false, "AV55TFProveedorDireccion", AV55TFProveedorDireccion);
         AV56TFProveedorDireccion_Sel = "";
         AssignAttri("", false, "AV56TFProveedorDireccion_Sel", AV56TFProveedorDireccion_Sel);
         AV57TFProveedorEmail = "";
         AssignAttri("", false, "AV57TFProveedorEmail", AV57TFProveedorEmail);
         AV58TFProveedorEmail_Sel = "";
         AssignAttri("", false, "AV58TFProveedorEmail_Sel", AV58TFProveedorEmail_Sel);
         AV88TFProveedorPagoDefault_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV60TFProveedorEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedfixedfilter = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV42GridConditionalFormattingFilter = 0;
         AssignAttri("", false, "AV42GridConditionalFormattingFilter", StringUtil.LTrimStr( (decimal)(AV42GridConditionalFormattingFilter), 4, 0));
      }

      protected void S222( )
      {
         /* 'DO ALSASOLICITUDES' Routine */
         returnInSub = false;
         AV81UsrId = AV6WWPContext.gxTpr_Userid;
         AV80Link = context.GetMessage( "https://sis.almango.com.uy/SolicitudServicio.aspx?", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 10, 0)) + "," + StringUtil.Trim( StringUtil.Str( (decimal)(AV81UsrId), 10, 0));
         Innewwindow1_Target = AV80Link;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void S232( )
      {
         /* 'DO SOLICITUDONEPAGE' Routine */
         returnInSub = false;
         AV81UsrId = AV6WWPContext.gxTpr_Userid;
         AV80Link = context.GetMessage( "https://services.almango.com.uy/servicios/", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV81UsrId), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0)) + context.GetMessage( "/B", "");
         Innewwindow1_Target = AV80Link;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void S242( )
      {
         /* 'DO ESTADISTICAS' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "comercios.dashboardcom.aspx"+UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
         context.PopUp(formatLink("comercios.dashboardcom.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void S252( )
      {
         /* 'DO ALTAPOSTULACIONES' Routine */
         returnInSub = false;
         AV81UsrId = AV6WWPContext.gxTpr_Userid;
         AV80Link = context.GetMessage( "https://services.almango.com.uy/postulacion/", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV81UsrId), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0));
         Newwindow2_Target = AV80Link;
         ucNewwindow2.SendProperty(context, "", false, Newwindow2_Internalname, "Target", Newwindow2_Target);
         Newwindow2_Height = "600";
         ucNewwindow2.SendProperty(context, "", false, Newwindow2_Internalname, "Height", Newwindow2_Height);
         Newwindow2_Width = "800";
         ucNewwindow2.SendProperty(context, "", false, Newwindow2_Internalname, "Width", Newwindow2_Width);
         this.executeUsercontrolMethod("", false, "NEWWINDOW2Container", "OpenWindow", "", new Object[] {});
      }

      protected void S262( )
      {
         /* 'DO DESAINV' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "comercioproductos.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
         CallWebObject(formatLink("comercioproductos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO REPLICARRUBROS' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "REPLICARRUBROS_MODALContainer", "Confirm", "", new Object[] {});
      }

      protected void S282( )
      {
         /* 'DO REPLICARPRECIOS' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "REPLICARPRECIOS2_MODALContainer", "Confirm", "", new Object[] {});
      }

      protected void S292( )
      {
         /* 'DO NUEVAMUDANZA' Routine */
         returnInSub = false;
         AV97SecUserId = AV6WWPContext.gxTpr_Userid;
         AV95ProveedorId = A133ProveedorID;
         AV101LinkMudanza = context.GetMessage( "https://mudanza.almango.com.uy/", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV97SecUserId), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV95ProveedorId), 18, 0));
         Newwindow_Target = StringUtil.Trim( AV101LinkMudanza);
         ucNewwindow.SendProperty(context, "", false, Newwindow_Internalname, "Target", Newwindow_Target);
         this.executeUsercontrolMethod("", false, "NEWWINDOWContainer", "OpenWindow", "", new Object[] {});
      }

      protected void S302( )
      {
         /* 'DO FREEZAR' Routine */
         returnInSub = false;
         GXt_int3 = AV103Cantidad;
         new proveedorfreezarprecios(context ).execute(  A133ProveedorID,  true, out  GXt_int3) ;
         AV103Cantidad = GXt_int3;
         GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Freezado",  context.GetMessage( "Proceso completado.", ""),  "success",  "",  "true",  ""));
      }

      protected void S312( )
      {
         /* 'DO ELIMINARFREEZAR' Routine */
         returnInSub = false;
         GXt_int3 = AV103Cantidad;
         new proveedorfreezarprecios(context ).execute(  A133ProveedorID,  false, out  GXt_int3) ;
         AV103Cantidad = GXt_int3;
         GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Eliminar Freezado",  context.GetMessage( "Proceso completado.", ""),  "success",  "",  "true",  ""));
      }

      protected void S322( )
      {
         /* 'DO REPLICARPRECIOS2' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "REPLICARPRECIOS2_MODALContainer", "Confirm", "", new Object[] {});
      }

      protected void S332( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "proveedorview.aspx"+UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("proveedorview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S342( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "proveedor.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
         CallWebObject(formatLink("proveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S352( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "proveedor.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
         CallWebObject(formatLink("proveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41Session.Get(AV105Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV105Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV41Session.Get(AV105Pgmname+"GridState"), null, "", "");
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
         S212 ();
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

      protected void S212( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV122GXV1 = 1;
         while ( AV122GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV122GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV47TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFProveedorID", StringUtil.LTrimStr( (decimal)(AV47TFProveedorID), 18, 0));
               AV48TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFProveedorID_To", StringUtil.LTrimStr( (decimal)(AV48TFProveedorID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV49TFProveedorNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFProveedorNombre", AV49TFProveedorNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV50TFProveedorNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFProveedorNombre_Sel", AV50TFProveedorNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDOCIDENTIDAD") == 0 )
            {
               AV51TFProveedorDocIdentidad = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFProveedorDocIdentidad", AV51TFProveedorDocIdentidad);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDOCIDENTIDAD_SEL") == 0 )
            {
               AV52TFProveedorDocIdentidad_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFProveedorDocIdentidad_Sel", AV52TFProveedorDocIdentidad_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO") == 0 )
            {
               AV53TFProveedorTelefono = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFProveedorTelefono", AV53TFProveedorTelefono);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO_SEL") == 0 )
            {
               AV54TFProveedorTelefono_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFProveedorTelefono_Sel", AV54TFProveedorTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION") == 0 )
            {
               AV55TFProveedorDireccion = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFProveedorDireccion", AV55TFProveedorDireccion);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION_SEL") == 0 )
            {
               AV56TFProveedorDireccion_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFProveedorDireccion_Sel", AV56TFProveedorDireccion_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL") == 0 )
            {
               AV57TFProveedorEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV57TFProveedorEmail", AV57TFProveedorEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL_SEL") == 0 )
            {
               AV58TFProveedorEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV58TFProveedorEmail_Sel", AV58TFProveedorEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORPAGODEFAULT_SEL") == 0 )
            {
               AV87TFProveedorPagoDefault_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV87TFProveedorPagoDefault_SelsJson", AV87TFProveedorPagoDefault_SelsJson);
               AV88TFProveedorPagoDefault_Sels.FromJSonString(AV87TFProveedorPagoDefault_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV59TFProveedorEstado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFProveedorEstado_SelsJson", AV59TFProveedorEstado_SelsJson);
               AV60TFProveedorEstado_Sels.FromJSonString(AV59TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "GRIDCFFILTER") == 0 )
            {
               AV42GridConditionalFormattingFilter = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42GridConditionalFormattingFilter", StringUtil.LTrimStr( (decimal)(AV42GridConditionalFormattingFilter), 4, 0));
            }
            AV122GXV1 = (int)(AV122GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProveedorNombre_Sel)),  AV50TFProveedorNombre_Sel, out  GXt_char2) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProveedorDocIdentidad_Sel)),  AV52TFProveedorDocIdentidad_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProveedorTelefono_Sel)),  AV54TFProveedorTelefono_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFProveedorDireccion_Sel)),  AV56TFProveedorDireccion_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV58TFProveedorEmail_Sel)),  AV58TFProveedorEmail_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV88TFProveedorPagoDefault_Sels.Count==0),  AV87TFProveedorPagoDefault_SelsJson, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV60TFProveedorEstado_Sels.Count==0),  AV59TFProveedorEstado_SelsJson, out  GXt_char11) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char2+"||"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProveedorNombre)),  AV49TFProveedorNombre, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProveedorDocIdentidad)),  AV51TFProveedorDocIdentidad, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProveedorTelefono)),  AV53TFProveedorTelefono, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProveedorDireccion)),  AV55TFProveedorDireccion, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV57TFProveedorEmail)),  AV57TFProveedorEmail, out  GXt_char7) ;
         Ddo_grid_Filteredtext_set = "|"+((0==AV47TFProveedorID) ? "" : StringUtil.Str( (decimal)(AV47TFProveedorID), 18, 0))+"|"+GXt_char11+"||"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((0==AV48TFProveedorID_To) ? "" : StringUtil.Str( (decimal)(AV48TFProveedorID_To), 18, 0))+"|||||||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         Ddo_grid_Selectedfixedfilter = ((AV42GridConditionalFormattingFilter!=1) ? "" : "1")+"||||||||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV41Session.Get(AV105Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPROVEEDORID",  context.GetMessage( "Comercio", ""),  !((0==AV47TFProveedorID)&&(0==AV48TFProveedorID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFProveedorID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFProveedorID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROVEEDORNOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProveedorNombre)),  0,  AV49TFProveedorNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProveedorNombre_Sel)),  AV50TFProveedorNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROVEEDORDOCIDENTIDAD",  context.GetMessage( "Doc. Identidad", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProveedorDocIdentidad)),  0,  AV51TFProveedorDocIdentidad,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProveedorDocIdentidad_Sel)),  AV52TFProveedorDocIdentidad_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROVEEDORTELEFONO",  context.GetMessage( "Teléfono", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProveedorTelefono)),  0,  AV53TFProveedorTelefono,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProveedorTelefono_Sel)),  AV54TFProveedorTelefono_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROVEEDORDIRECCION",  context.GetMessage( "Dirección", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProveedorDireccion)),  0,  AV55TFProveedorDireccion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFProveedorDireccion_Sel)),  AV56TFProveedorDireccion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROVEEDOREMAIL",  context.GetMessage( "Email", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV57TFProveedorEmail)),  0,  AV57TFProveedorEmail,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV58TFProveedorEmail_Sel)),  AV58TFProveedorEmail_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPROVEEDORPAGODEFAULT_SEL",  context.GetMessage( "Pago", ""),  !(AV88TFProveedorPagoDefault_Sels.Count==0),  0,  AV88TFProveedorPagoDefault_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPROVEEDORESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV60TFProveedorEstado_Sels.Count==0),  0,  AV60TFProveedorEstado_Sels.ToJSonString(false),  "") ;
         if ( ! (0==AV42GridConditionalFormattingFilter) )
         {
            if ( AV42GridConditionalFormattingFilter == 1 )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "GRIDCFFILTER",  context.GetMessage( "Permiso Concedido", ""),  true,  0,  StringUtil.Str( (decimal)(AV42GridConditionalFormattingFilter), 4, 0),  "") ;
            }
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV105Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV105Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Proveedor";
         AV41Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S362( )
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
         new proveedorwwexport(context ).execute( out  AV35ExcelFilename, out  AV36ErrorMessage) ;
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

      protected void S372( )
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
         Innewwindow1_Target = formatLink("proveedorwwexportreport.aspx") ;
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
         divUnnamedtable1_Visible = (((1==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable1_Visible), 5, 0), true);
      }

      protected void E244R2( )
      {
         /* General\GlobalEvents_Finalizarreplicarprecios Routine */
         returnInSub = false;
         if ( AV100Exitoso )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Atención",  context.GetMessage( "Replicación exitosa.", ""),  "success",  "",  "true",  ""));
            this.executeUsercontrolMethod("", false, "REPLICARPRECIOS2_MODALContainer", "CloseConfirmPanel", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Atención",  context.GetMessage( "Replicación fallida.", ""),  "error",  "",  "true",  ""));
            this.executeUsercontrolMethod("", false, "REPLICARPRECIOS2_MODALContainer", "CloseConfirmPanel", "", new Object[] {});
         }
      }

      protected void S382( )
      {
         /* 'DO ALTAPOSTULACION' Routine */
         returnInSub = false;
         AV81UsrId = AV6WWPContext.gxTpr_Userid;
         AV80Link = context.GetMessage( "https://services.almango.com.uy/postulacion/", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV81UsrId), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0));
         Newwindow2_Target = AV80Link;
         ucNewwindow2.SendProperty(context, "", false, Newwindow2_Internalname, "Target", Newwindow2_Target);
         Newwindow2_Height = "600";
         ucNewwindow2.SendProperty(context, "", false, Newwindow2_Internalname, "Height", Newwindow2_Height);
         Newwindow2_Width = "800";
         ucNewwindow2.SendProperty(context, "", false, Newwindow2_Internalname, "Width", Newwindow2_Width);
         this.executeUsercontrolMethod("", false, "NEWWINDOW2Container", "OpenWindow", "", new Object[] {});
      }

      protected void S162( )
      {
         /* 'OBTENGO ROL' Routine */
         returnInSub = false;
         AV102VerTodProv = false;
         AssignAttri("", false, "AV102VerTodProv", AV102VerTodProv);
         AV75Roles = AV6WWPContext.gxTpr_Roles;
         AV123GXV2 = 1;
         while ( AV123GXV2 <= AV75Roles.gxTpr_Roles.Count )
         {
            AV77RolesItem = ((SdtSDTRoles_Id)AV75Roles.gxTpr_Roles.Item(AV123GXV2));
            AV76SecRoleName = AV77RolesItem.gxTpr_Secrolename;
            AssignAttri("", false, "AV76SecRoleName", AV76SecRoleName);
            GxWebStd.gx_hidden_field( context, "gxhash_vSECROLENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV76SecRoleName, "")), context));
            if ( ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV76SecRoleName)), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV76SecRoleName)), context.GetMessage( "ADM GENERAL", "")) == 0 ) ) )
            {
               AV102VerTodProv = true;
               AssignAttri("", false, "AV102VerTodProv", AV102VerTodProv);
            }
            AV123GXV2 = (int)(AV123GXV2+1);
         }
      }

      protected void wb_table3_83_4R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablereplicarprecios2_modal_Internalname, tblTablereplicarprecios2_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucReplicarprecios2_modal.SetProperty("Width", Replicarprecios2_modal_Width);
            ucReplicarprecios2_modal.SetProperty("Title", Replicarprecios2_modal_Title);
            ucReplicarprecios2_modal.SetProperty("ConfirmType", Replicarprecios2_modal_Confirmtype);
            ucReplicarprecios2_modal.SetProperty("BodyType", Replicarprecios2_modal_Bodytype);
            ucReplicarprecios2_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Replicarprecios2_modal_Internalname, "REPLICARPRECIOS2_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"REPLICARPRECIOS2_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_83_4R2e( true) ;
         }
         else
         {
            wb_table3_83_4R2e( false) ;
         }
      }

      protected void wb_table2_78_4R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablereplicarrubros_modal_Internalname, tblTablereplicarrubros_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucReplicarrubros_modal.SetProperty("Width", Replicarrubros_modal_Width);
            ucReplicarrubros_modal.SetProperty("Title", Replicarrubros_modal_Title);
            ucReplicarrubros_modal.SetProperty("ConfirmType", Replicarrubros_modal_Confirmtype);
            ucReplicarrubros_modal.SetProperty("BodyType", Replicarrubros_modal_Bodytype);
            ucReplicarrubros_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Replicarrubros_modal_Internalname, "REPLICARRUBROS_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"REPLICARRUBROS_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_78_4R2e( true) ;
         }
         else
         {
            wb_table2_78_4R2e( false) ;
         }
      }

      protected void wb_table1_25_4R2( bool wbgen )
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
            wb_table4_30_4R2( true) ;
         }
         else
         {
            wb_table4_30_4R2( false) ;
         }
         return  ;
      }

      protected void wb_table4_30_4R2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_4R2e( true) ;
         }
         else
         {
            wb_table1_25_4R2e( false) ;
         }
      }

      protected void wb_table4_30_4R2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_48_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ProveedorWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_30_4R2e( true) ;
         }
         else
         {
            wb_table4_30_4R2e( false) ;
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
         PA4R2( ) ;
         WS4R2( ) ;
         WE4R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269282143288", true, true, false);
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
         context.AddJavascriptSource("proveedorww.js", "?20269282143289", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_482( )
      {
         edtavGridbadge_Internalname = "vGRIDBADGE_"+sGXsfl_48_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_48_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_48_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_48_idx;
         edtProveedorImagen_Internalname = "PROVEEDORIMAGEN_"+sGXsfl_48_idx;
         edtProveedorDocIdentidad_Internalname = "PROVEEDORDOCIDENTIDAD_"+sGXsfl_48_idx;
         edtProveedorTelefono_Internalname = "PROVEEDORTELEFONO_"+sGXsfl_48_idx;
         edtProveedorDireccion_Internalname = "PROVEEDORDIRECCION_"+sGXsfl_48_idx;
         edtProveedorEmail_Internalname = "PROVEEDOREMAIL_"+sGXsfl_48_idx;
         cmbProveedorPagoDefault_Internalname = "PROVEEDORPAGODEFAULT_"+sGXsfl_48_idx;
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO_"+sGXsfl_48_idx;
         edtavHacerload_Internalname = "vHACERLOAD_"+sGXsfl_48_idx;
      }

      protected void SubsflControlProps_fel_482( )
      {
         edtavGridbadge_Internalname = "vGRIDBADGE_"+sGXsfl_48_fel_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_48_fel_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_48_fel_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_48_fel_idx;
         edtProveedorImagen_Internalname = "PROVEEDORIMAGEN_"+sGXsfl_48_fel_idx;
         edtProveedorDocIdentidad_Internalname = "PROVEEDORDOCIDENTIDAD_"+sGXsfl_48_fel_idx;
         edtProveedorTelefono_Internalname = "PROVEEDORTELEFONO_"+sGXsfl_48_fel_idx;
         edtProveedorDireccion_Internalname = "PROVEEDORDIRECCION_"+sGXsfl_48_fel_idx;
         edtProveedorEmail_Internalname = "PROVEEDOREMAIL_"+sGXsfl_48_fel_idx;
         cmbProveedorPagoDefault_Internalname = "PROVEEDORPAGODEFAULT_"+sGXsfl_48_fel_idx;
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO_"+sGXsfl_48_fel_idx;
         edtavHacerload_Internalname = "vHACERLOAD_"+sGXsfl_48_fel_idx;
      }

      protected void sendrow_482( )
      {
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_482( ) ;
         WB4R0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_48_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_48_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_48_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_48_idx + "',48)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGridbadge_Internalname,(string)AV43GridBadge,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGridbadge_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TagColumn",(string)"",(short)-1,(int)edtavGridbadge_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)1,(short)48,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_48_idx + "',48)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_48_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV66GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV66GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_48_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_48_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtProveedorID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProveedorID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProveedorNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorNombre_Internalname,StringUtil.RTrim( A282ProveedorNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProveedorNombre_Link,(string)"",(string)"",(string)"",(string)edtProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProveedorNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtProveedorImagen_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A432ProveedorImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtProveedorImagen_Visible,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A432ProveedorImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProveedorDocIdentidad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorDocIdentidad_Internalname,StringUtil.RTrim( A338ProveedorDocIdentidad),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorDocIdentidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProveedorDocIdentidad_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProveedorTelefono_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A430ProveedorTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorTelefono_Internalname,StringUtil.RTrim( A430ProveedorTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProveedorTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProveedorTelefono_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProveedorDireccion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorDireccion_Internalname,(string)A431ProveedorDireccion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A431ProveedorDireccion),(string)"_blank",(string)"",(string)"",(string)edtProveedorDireccion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProveedorDireccion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProveedorEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorEmail_Internalname,(string)A433ProveedorEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A433ProveedorEmail,(string)"",(string)"",(string)"",(string)edtProveedorEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProveedorEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbProveedorPagoDefault.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbProveedorPagoDefault.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROVEEDORPAGODEFAULT_" + sGXsfl_48_idx;
               cmbProveedorPagoDefault.Name = GXCCtl;
               cmbProveedorPagoDefault.WebTags = "";
               cmbProveedorPagoDefault.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
               cmbProveedorPagoDefault.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
               cmbProveedorPagoDefault.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
               if ( cmbProveedorPagoDefault.ItemCount > 0 )
               {
                  A440ProveedorPagoDefault = cmbProveedorPagoDefault.getValidValue(A440ProveedorPagoDefault);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorPagoDefault,(string)cmbProveedorPagoDefault_Internalname,StringUtil.RTrim( A440ProveedorPagoDefault),(short)1,(string)cmbProveedorPagoDefault_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbProveedorPagoDefault.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProveedorPagoDefault.CurrentValue = StringUtil.RTrim( A440ProveedorPagoDefault);
            AssignProp("", false, cmbProveedorPagoDefault_Internalname, "Values", (string)(cmbProveedorPagoDefault.ToJavascriptSource()), !bGXsfl_48_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbProveedorEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbProveedorEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROVEEDORESTADO_" + sGXsfl_48_idx;
               cmbProveedorEstado.Name = GXCCtl;
               cmbProveedorEstado.WebTags = "";
               cmbProveedorEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbProveedorEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbProveedorEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbProveedorEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbProveedorEstado.ItemCount > 0 )
               {
                  A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorEstado,(string)cmbProveedorEstado_Internalname,StringUtil.RTrim( A344ProveedorEstado),(short)1,(string)cmbProveedorEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbProveedorEstado.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbProveedorEstado_Columnclass,(string)cmbProveedorEstado_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
            AssignProp("", false, cmbProveedorEstado_Internalname, "Values", (string)(cmbProveedorEstado.ToJavascriptSource()), !bGXsfl_48_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtavHacerload_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_48_idx + "',48)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavHacerload_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34HacerLoad), 1, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavHacerload_Enabled!=0) ? context.localUtil.Format( (decimal)(AV34HacerLoad), "9") : context.localUtil.Format( (decimal)(AV34HacerLoad), "9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,60);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavHacerload_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavHacerload_Visible,(int)edtavHacerload_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes4R2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_48_idx = ((subGrid_Islastpage==1)&&(nGXsfl_48_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_482( ) ;
         }
         /* End function sendrow_482 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_48_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV66GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV66GridActions), 4, 0));
         }
         GXCCtl = "PROVEEDORPAGODEFAULT_" + sGXsfl_48_idx;
         cmbProveedorPagoDefault.Name = GXCCtl;
         cmbProveedorPagoDefault.WebTags = "";
         cmbProveedorPagoDefault.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbProveedorPagoDefault.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbProveedorPagoDefault.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbProveedorPagoDefault.ItemCount > 0 )
         {
            A440ProveedorPagoDefault = cmbProveedorPagoDefault.getValidValue(A440ProveedorPagoDefault);
         }
         GXCCtl = "PROVEEDORESTADO_" + sGXsfl_48_idx;
         cmbProveedorEstado.Name = GXCCtl;
         cmbProveedorEstado.WebTags = "";
         cmbProveedorEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbProveedorEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbProveedorEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbProveedorEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl48( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"48\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comercio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorImagen_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Imagen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorDocIdentidad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Doc. Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorTelefono_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorDireccion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Dirección", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbProveedorPagoDefault.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Pago", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbProveedorEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavHacerload_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV43GridBadge));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGridbadge_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A282ProveedorNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtProveedorNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A432ProveedorImagen));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorImagen_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A338ProveedorDocIdentidad)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorDocIdentidad_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A430ProveedorTelefono)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorTelefono_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A431ProveedorDireccion));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorDireccion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A433ProveedorEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A440ProveedorPagoDefault)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorPagoDefault.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A344ProveedorEstado)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbProveedorEstado_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbProveedorEstado_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorEstado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34HacerLoad), 1, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavHacerload_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavHacerload_Visible), 5, 0, ".", "")));
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
         bttBtnmudanza_Internalname = "BTNMUDANZA";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTableheader_Internalname = "TABLEHEADER";
         edtavGridbadge_Internalname = "vGRIDBADGE";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtProveedorImagen_Internalname = "PROVEEDORIMAGEN";
         edtProveedorDocIdentidad_Internalname = "PROVEEDORDOCIDENTIDAD";
         edtProveedorTelefono_Internalname = "PROVEEDORTELEFONO";
         edtProveedorDireccion_Internalname = "PROVEEDORDIRECCION";
         edtProveedorEmail_Internalname = "PROVEEDOREMAIL";
         cmbProveedorPagoDefault_Internalname = "PROVEEDORPAGODEFAULT";
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO";
         edtavHacerload_Internalname = "vHACERLOAD";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         Newwindow_Internalname = "NEWWINDOW";
         Newwindow2_Internalname = "NEWWINDOW2";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Replicarrubros_modal_Internalname = "REPLICARRUBROS_MODAL";
         tblTablereplicarrubros_modal_Internalname = "TABLEREPLICARRUBROS_MODAL";
         Replicarprecios2_modal_Internalname = "REPLICARPRECIOS2_MODAL";
         tblTablereplicarprecios2_modal_Internalname = "TABLEREPLICARPRECIOS2_MODAL";
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
         edtavHacerload_Jsonclick = "";
         edtavHacerload_Enabled = 1;
         cmbProveedorEstado_Jsonclick = "";
         cmbProveedorEstado_Columnclass = "WWColumn";
         cmbProveedorPagoDefault_Jsonclick = "";
         edtProveedorEmail_Jsonclick = "";
         edtProveedorDireccion_Jsonclick = "";
         edtProveedorTelefono_Jsonclick = "";
         edtProveedorDocIdentidad_Jsonclick = "";
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Link = "";
         edtProveedorID_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         edtavGridbadge_Jsonclick = "";
         edtavGridbadge_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         cmbProveedorEstado_Columnheaderclass = "";
         edtavHacerload_Visible = -1;
         cmbProveedorEstado.Visible = -1;
         cmbProveedorPagoDefault.Visible = -1;
         edtProveedorEmail_Visible = -1;
         edtProveedorDireccion_Visible = -1;
         edtProveedorTelefono_Visible = -1;
         edtProveedorDocIdentidad_Visible = -1;
         edtProveedorImagen_Visible = -1;
         edtProveedorNombre_Visible = -1;
         edtProveedorID_Visible = -1;
         cmbProveedorEstado.Enabled = 0;
         cmbProveedorPagoDefault.Enabled = 0;
         edtProveedorEmail_Enabled = 0;
         edtProveedorDireccion_Enabled = 0;
         edtProveedorTelefono_Enabled = 0;
         edtProveedorDocIdentidad_Enabled = 0;
         edtProveedorImagen_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Enabled = 0;
         subGrid_Sortable = 0;
         divUnnamedtable1_Visible = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = ";L;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Replicarprecios2_modal_Bodytype = "WebComponent";
         Replicarprecios2_modal_Confirmtype = "";
         Replicarprecios2_modal_Title = context.GetMessage( "Comercios", "");
         Replicarprecios2_modal_Width = "400";
         Replicarrubros_modal_Bodytype = "WebComponent";
         Replicarrubros_modal_Confirmtype = "";
         Replicarrubros_modal_Title = context.GetMessage( "Replicar Rubros comercios", "");
         Replicarrubros_modal_Width = "400";
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
         Ddo_grid_Format = "|18.0|||||||||";
         Ddo_grid_Fixedfilters = "1:Permiso Concedido:fa fa-check-circle FontColorIconSuccess ConditionalFormattingFilterIcon||||||||||";
         Ddo_grid_Datalistproc = "ProveedorWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||||F:Cobro Directo,T:Cobro Prepago Comercio,O:Cobro Prepago Almango|HAB:Habilitado,DES:Deshabilitado,PEN:Pendiente|";
         Ddo_grid_Allowmultipleselection = "||||||||T|T|";
         Ddo_grid_Datalisttype = "||Dynamic||Dynamic|Dynamic|Dynamic|Dynamic|FixedValues|FixedValues|";
         Ddo_grid_Includedatalist = "||T||T|T|T|T|T|T|";
         Ddo_grid_Filterisrange = "|T|||||||||";
         Ddo_grid_Filtertype = "|Numeric|Character||Character|Character|Character|Character|||";
         Ddo_grid_Includefilter = "|T|T||T|T|T|T|||";
         Ddo_grid_Fixable = "|T|T|T|T|T|T|T|T|T|T";
         Ddo_grid_Includesortasc = "|T|T||T|T|T|T|T|T|";
         Ddo_grid_Columnssortvalues = "|2|1||3|4|5|6|7|8|";
         Ddo_grid_Columnids = "0:TagColumn|2:ProveedorID|3:ProveedorNombre|4:ProveedorImagen|5:ProveedorDocIdentidad|6:ProveedorTelefono|7:ProveedorDireccion|8:ProveedorEmail|9:ProveedorPagoDefault|10:ProveedorEstado|11:HacerLoad";
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
         Newwindow2_Target = "";
         Newwindow2_Height = "50";
         Newwindow2_Width = "50";
         Newwindow_Target = "";
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
         Form.Caption = context.GetMessage( "Comercios", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV105Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtProveedorImagen_Visible',ctrl:'PROVEEDORIMAGEN',prop:'Visible'},{av:'edtProveedorDocIdentidad_Visible',ctrl:'PROVEEDORDOCIDENTIDAD',prop:'Visible'},{av:'edtProveedorTelefono_Visible',ctrl:'PROVEEDORTELEFONO',prop:'Visible'},{av:'edtProveedorDireccion_Visible',ctrl:'PROVEEDORDIRECCION',prop:'Visible'},{av:'edtProveedorEmail_Visible',ctrl:'PROVEEDOREMAIL',prop:'Visible'},{av:'cmbProveedorPagoDefault'},{av:'cmbProveedorEstado'},{av:'edtavHacerload_Visible',ctrl:'vHACERLOAD',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E124R2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV105Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtProveedorImagen_Visible',ctrl:'PROVEEDORIMAGEN',prop:'Visible'},{av:'edtProveedorDocIdentidad_Visible',ctrl:'PROVEEDORDOCIDENTIDAD',prop:'Visible'},{av:'edtProveedorTelefono_Visible',ctrl:'PROVEEDORTELEFONO',prop:'Visible'},{av:'edtProveedorDireccion_Visible',ctrl:'PROVEEDORDIRECCION',prop:'Visible'},{av:'edtProveedorEmail_Visible',ctrl:'PROVEEDOREMAIL',prop:'Visible'},{av:'cmbProveedorPagoDefault'},{av:'cmbProveedorEstado'},{av:'edtavHacerload_Visible',ctrl:'vHACERLOAD',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E134R2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV105Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E164R2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV105Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumnfixedfilter',ctrl:'DDO_GRID',prop:'SelectedColumnFixedFilter'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV59TFProveedorEstado_SelsJson',fld:'vTFPROVEEDORESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV87TFProveedorPagoDefault_SelsJson',fld:'vTFPROVEEDORPAGODEFAULT_SELSJSON',pic:'',type:'vchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E274R2',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'cmbProveedorEstado'},{av:'A344ProveedorEstado',fld:'PROVEEDORESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'cmbavGridactions'},{av:'AV66GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtProveedorNombre_Link',ctrl:'PROVEEDORNOMBRE',prop:'Link'},{av:'AV43GridBadge',fld:'vGRIDBADGE',pic:'',type:'svchar'},{av:'cmbProveedorEstado'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E174R2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV105Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtProveedorImagen_Visible',ctrl:'PROVEEDORIMAGEN',prop:'Visible'},{av:'edtProveedorDocIdentidad_Visible',ctrl:'PROVEEDORDOCIDENTIDAD',prop:'Visible'},{av:'edtProveedorTelefono_Visible',ctrl:'PROVEEDORTELEFONO',prop:'Visible'},{av:'edtProveedorDireccion_Visible',ctrl:'PROVEEDORDIRECCION',prop:'Visible'},{av:'edtProveedorEmail_Visible',ctrl:'PROVEEDOREMAIL',prop:'Visible'},{av:'cmbProveedorPagoDefault'},{av:'cmbProveedorEstado'},{av:'edtavHacerload_Visible',ctrl:'vHACERLOAD',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E114R2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV105Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV87TFProveedorPagoDefault_SelsJson',fld:'vTFPROVEEDORPAGODEFAULT_SELSJSON',pic:'',type:'vchar'},{av:'AV59TFProveedorEstado_SelsJson',fld:'vTFPROVEEDORESTADO_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'Ddo_grid_Selectedfixedfilter',ctrl:'DDO_GRID',prop:'SelectedFixedFilter'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV59TFProveedorEstado_SelsJson',fld:'vTFPROVEEDORESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV87TFProveedorPagoDefault_SelsJson',fld:'vTFPROVEEDORPAGODEFAULT_SELSJSON',pic:'',type:'vchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtProveedorImagen_Visible',ctrl:'PROVEEDORIMAGEN',prop:'Visible'},{av:'edtProveedorDocIdentidad_Visible',ctrl:'PROVEEDORDOCIDENTIDAD',prop:'Visible'},{av:'edtProveedorTelefono_Visible',ctrl:'PROVEEDORTELEFONO',prop:'Visible'},{av:'edtProveedorDireccion_Visible',ctrl:'PROVEEDORDIRECCION',prop:'Visible'},{av:'edtProveedorEmail_Visible',ctrl:'PROVEEDOREMAIL',prop:'Visible'},{av:'cmbProveedorPagoDefault'},{av:'cmbProveedorEstado'},{av:'edtavHacerload_Visible',ctrl:'vHACERLOAD',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E284R2',iparms:[{av:'cmbavGridactions'},{av:'AV66GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV105Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV66GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'Newwindow2_Target',ctrl:'NEWWINDOW2',prop:'Target'},{av:'Newwindow2_Height',ctrl:'NEWWINDOW2',prop:'Height'},{av:'Newwindow2_Width',ctrl:'NEWWINDOW2',prop:'Width'},{av:'Newwindow_Target',ctrl:'NEWWINDOW',prop:'Target'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtProveedorImagen_Visible',ctrl:'PROVEEDORIMAGEN',prop:'Visible'},{av:'edtProveedorDocIdentidad_Visible',ctrl:'PROVEEDORDOCIDENTIDAD',prop:'Visible'},{av:'edtProveedorTelefono_Visible',ctrl:'PROVEEDORTELEFONO',prop:'Visible'},{av:'edtProveedorDireccion_Visible',ctrl:'PROVEEDORDIRECCION',prop:'Visible'},{av:'edtProveedorEmail_Visible',ctrl:'PROVEEDOREMAIL',prop:'Visible'},{av:'cmbProveedorPagoDefault'},{av:'cmbProveedorEstado'},{av:'edtavHacerload_Visible',ctrl:'vHACERLOAD',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("REPLICARRUBROS_MODAL.ONLOADCOMPONENT","{handler:'E194R2',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REPLICARRUBROS_MODAL.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("REPLICARRUBROS_MODAL.CLOSE","{handler:'E184R2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV105Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REPLICARRUBROS_MODAL.CLOSE",",oparms:[{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtProveedorImagen_Visible',ctrl:'PROVEEDORIMAGEN',prop:'Visible'},{av:'edtProveedorDocIdentidad_Visible',ctrl:'PROVEEDORDOCIDENTIDAD',prop:'Visible'},{av:'edtProveedorTelefono_Visible',ctrl:'PROVEEDORTELEFONO',prop:'Visible'},{av:'edtProveedorDireccion_Visible',ctrl:'PROVEEDORDIRECCION',prop:'Visible'},{av:'edtProveedorEmail_Visible',ctrl:'PROVEEDOREMAIL',prop:'Visible'},{av:'cmbProveedorPagoDefault'},{av:'cmbProveedorEstado'},{av:'edtavHacerload_Visible',ctrl:'vHACERLOAD',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("REPLICARPRECIOS2_MODAL.ONLOADCOMPONENT","{handler:'E214R2',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REPLICARPRECIOS2_MODAL.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("REPLICARPRECIOS2_MODAL.CLOSE","{handler:'E204R2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV105Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REPLICARPRECIOS2_MODAL.CLOSE",",oparms:[{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtProveedorImagen_Visible',ctrl:'PROVEEDORIMAGEN',prop:'Visible'},{av:'edtProveedorDocIdentidad_Visible',ctrl:'PROVEEDORDOCIDENTIDAD',prop:'Visible'},{av:'edtProveedorTelefono_Visible',ctrl:'PROVEEDORTELEFONO',prop:'Visible'},{av:'edtProveedorDireccion_Visible',ctrl:'PROVEEDORDIRECCION',prop:'Visible'},{av:'edtProveedorEmail_Visible',ctrl:'PROVEEDOREMAIL',prop:'Visible'},{av:'cmbProveedorPagoDefault'},{av:'cmbProveedorEstado'},{av:'edtavHacerload_Visible',ctrl:'vHACERLOAD',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOMUDANZA'","{handler:'E224R2',iparms:[{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOMUDANZA'",",oparms:[]}");
         setEventMetadata("'DOINSERT'","{handler:'E234R2',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E144R2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV105Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV87TFProveedorPagoDefault_SelsJson',fld:'vTFPROVEEDORPAGODEFAULT_SELSJSON',pic:'',type:'vchar'},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV59TFProveedorEstado_SelsJson',fld:'vTFPROVEEDORESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV46ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV39ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV105Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV42GridConditionalFormattingFilter',fld:'vGRIDCONDITIONALFORMATTINGFILTER',pic:'ZZZ9',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV49TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProveedorDocIdentidad',fld:'vTFPROVEEDORDOCIDENTIDAD',pic:'',type:'char'},{av:'AV52TFProveedorDocIdentidad_Sel',fld:'vTFPROVEEDORDOCIDENTIDAD_SEL',pic:'',type:'char'},{av:'AV53TFProveedorTelefono',fld:'vTFPROVEEDORTELEFONO',pic:'',type:'char'},{av:'AV54TFProveedorTelefono_Sel',fld:'vTFPROVEEDORTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFProveedorDireccion',fld:'vTFPROVEEDORDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProveedorDireccion_Sel',fld:'vTFPROVEEDORDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV57TFProveedorEmail',fld:'vTFPROVEEDOREMAIL',pic:'',type:'svchar'},{av:'AV58TFProveedorEmail_Sel',fld:'vTFPROVEEDOREMAIL_SEL',pic:'',type:'svchar'},{av:'AV88TFProveedorPagoDefault_Sels',fld:'vTFPROVEEDORPAGODEFAULT_SELS',pic:''},{av:'AV60TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV34HacerLoad',fld:'vHACERLOAD',pic:'9',type:'int'},{av:'AV76SecRoleName',fld:'vSECROLENAME',pic:'',hsh:true,type:'svchar'},{av:'AV6WWPContext',fld:'vWWPCONTEXT',pic:'',hsh:true},{av:'AV90IsAuthorized_Estadisticas',fld:'vISAUTHORIZED_ESTADISTICAS',pic:'',hsh:true,type:'boolean'},{av:'AV92IsAuthorized_DesaINV',fld:'vISAUTHORIZED_DESAINV',pic:'',hsh:true,type:'boolean'},{av:'AV104IsAuthorized_ReplicarRubros',fld:'vISAUTHORIZED_REPLICARRUBROS',pic:'',hsh:true,type:'boolean'},{av:'AV99IsAuthorized_ReplicarPrecios2',fld:'vISAUTHORIZED_REPLICARPRECIOS2',pic:'',hsh:true,type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV59TFProveedorEstado_SelsJson',fld:'vTFPROVEEDORESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV87TFProveedorPagoDefault_SelsJson',fld:'vTFPROVEEDORPAGODEFAULT_SELSJSON',pic:'',type:'vchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Selectedfixedfilter',ctrl:'DDO_GRID',prop:'SelectedFixedFilter'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtProveedorImagen_Visible',ctrl:'PROVEEDORIMAGEN',prop:'Visible'},{av:'edtProveedorDocIdentidad_Visible',ctrl:'PROVEEDORDOCIDENTIDAD',prop:'Visible'},{av:'edtProveedorTelefono_Visible',ctrl:'PROVEEDORTELEFONO',prop:'Visible'},{av:'edtProveedorDireccion_Visible',ctrl:'PROVEEDORDIRECCION',prop:'Visible'},{av:'edtProveedorEmail_Visible',ctrl:'PROVEEDOREMAIL',prop:'Visible'},{av:'cmbProveedorPagoDefault'},{av:'cmbProveedorEstado'},{av:'edtavHacerload_Visible',ctrl:'vHACERLOAD',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E154R2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("GLOBALEVENTS.FINALIZARREPLICARPRECIOS","{handler:'E244R2',iparms:[{av:'AV100Exitoso',fld:'vEXITOSO',pic:'',type:'boolean'}]");
         setEventMetadata("GLOBALEVENTS.FINALIZARREPLICARPRECIOS",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORNOMBRE","{handler:'Valid_Proveedornombre',iparms:[]");
         setEventMetadata("VALID_PROVEEDORNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORDOCIDENTIDAD","{handler:'Valid_Proveedordocidentidad',iparms:[]");
         setEventMetadata("VALID_PROVEEDORDOCIDENTIDAD",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORTELEFONO","{handler:'Valid_Proveedortelefono',iparms:[]");
         setEventMetadata("VALID_PROVEEDORTELEFONO",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORDIRECCION","{handler:'Valid_Proveedordireccion',iparms:[]");
         setEventMetadata("VALID_PROVEEDORDIRECCION",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDOREMAIL","{handler:'Valid_Proveedoremail',iparms:[]");
         setEventMetadata("VALID_PROVEEDOREMAIL",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORPAGODEFAULT","{handler:'Valid_Proveedorpagodefault',iparms:[]");
         setEventMetadata("VALID_PROVEEDORPAGODEFAULT",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORESTADO","{handler:'Valid_Proveedorestado',iparms:[]");
         setEventMetadata("VALID_PROVEEDORESTADO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Hacerload',iparms:[]");
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
         Ddo_grid_Selectedcolumnfixedfilter = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV105Pgmname = "";
         AV17FilterFullText = "";
         AV49TFProveedorNombre = "";
         AV50TFProveedorNombre_Sel = "";
         AV51TFProveedorDocIdentidad = "";
         AV52TFProveedorDocIdentidad_Sel = "";
         AV53TFProveedorTelefono = "";
         AV54TFProveedorTelefono_Sel = "";
         AV55TFProveedorDireccion = "";
         AV56TFProveedorDireccion_Sel = "";
         AV57TFProveedorEmail = "";
         AV58TFProveedorEmail_Sel = "";
         AV88TFProveedorPagoDefault_Sels = new GxSimpleCollection<string>();
         AV60TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         AV76SecRoleName = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV44ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV65GridAppliedFilters = "";
         AV70AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV61DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV87TFProveedorPagoDefault_SelsJson = "";
         AV59TFProveedorEstado_SelsJson = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_grid_Selectedfixedfilter = "";
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
         bttBtnmudanza_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucNewwindow = new GXUserControl();
         ucNewwindow2 = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
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
         AV43GridBadge = "";
         A282ProveedorNombre = "";
         A432ProveedorImagen = "";
         A40000ProveedorImagen_GXI = "";
         A338ProveedorDocIdentidad = "";
         A430ProveedorTelefono = "";
         A431ProveedorDireccion = "";
         A433ProveedorEmail = "";
         A440ProveedorPagoDefault = "";
         A344ProveedorEstado = "";
         AV107Proveedorwwds_2_filterfulltext = "";
         AV110Proveedorwwds_5_tfproveedornombre = "";
         AV111Proveedorwwds_6_tfproveedornombre_sel = "";
         AV112Proveedorwwds_7_tfproveedordocidentidad = "";
         AV113Proveedorwwds_8_tfproveedordocidentidad_sel = "";
         AV114Proveedorwwds_9_tfproveedortelefono = "";
         AV115Proveedorwwds_10_tfproveedortelefono_sel = "";
         AV116Proveedorwwds_11_tfproveedordireccion = "";
         AV117Proveedorwwds_12_tfproveedordireccion_sel = "";
         AV118Proveedorwwds_13_tfproveedoremail = "";
         AV119Proveedorwwds_14_tfproveedoremail_sel = "";
         AV120Proveedorwwds_15_tfproveedorpagodefault_sels = new GxSimpleCollection<string>();
         AV121Proveedorwwds_16_tfproveedorestado_sels = new GxSimpleCollection<string>();
         lV110Proveedorwwds_5_tfproveedornombre = "";
         lV112Proveedorwwds_7_tfproveedordocidentidad = "";
         lV114Proveedorwwds_9_tfproveedortelefono = "";
         lV116Proveedorwwds_11_tfproveedordireccion = "";
         lV118Proveedorwwds_13_tfproveedoremail = "";
         H004R2_A344ProveedorEstado = new string[] {""} ;
         H004R2_A440ProveedorPagoDefault = new string[] {""} ;
         H004R2_A433ProveedorEmail = new string[] {""} ;
         H004R2_n433ProveedorEmail = new bool[] {false} ;
         H004R2_A431ProveedorDireccion = new string[] {""} ;
         H004R2_n431ProveedorDireccion = new bool[] {false} ;
         H004R2_A430ProveedorTelefono = new string[] {""} ;
         H004R2_n430ProveedorTelefono = new bool[] {false} ;
         H004R2_A338ProveedorDocIdentidad = new string[] {""} ;
         H004R2_A40000ProveedorImagen_GXI = new string[] {""} ;
         H004R2_n40000ProveedorImagen_GXI = new bool[] {false} ;
         H004R2_A282ProveedorNombre = new string[] {""} ;
         H004R2_A133ProveedorID = new long[1] ;
         H004R2_A432ProveedorImagen = new string[] {""} ;
         H004R2_n432ProveedorImagen = new bool[] {false} ;
         H004R3_A344ProveedorEstado = new string[] {""} ;
         H004R3_A440ProveedorPagoDefault = new string[] {""} ;
         H004R3_A433ProveedorEmail = new string[] {""} ;
         H004R3_n433ProveedorEmail = new bool[] {false} ;
         H004R3_A431ProveedorDireccion = new string[] {""} ;
         H004R3_n431ProveedorDireccion = new bool[] {false} ;
         H004R3_A430ProveedorTelefono = new string[] {""} ;
         H004R3_n430ProveedorTelefono = new bool[] {false} ;
         H004R3_A338ProveedorDocIdentidad = new string[] {""} ;
         H004R3_A40000ProveedorImagen_GXI = new string[] {""} ;
         H004R3_n40000ProveedorImagen_GXI = new bool[] {false} ;
         H004R3_A282ProveedorNombre = new string[] {""} ;
         H004R3_A133ProveedorID = new long[1] ;
         H004R3_A432ProveedorImagen = new string[] {""} ;
         H004R3_n432ProveedorImagen = new bool[] {false} ;
         AV71AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV84ParametrosValor = "";
         AV85ParametrosEstado = "";
         AV41Session = context.GetSession();
         AV37ColumnsSelectorXML = "";
         AV78proveedorProperty = new GXProperties();
         AV79AgrProveedorEstado = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV45ManageFiltersXml = "";
         AV96WebSession = context.GetSession();
         AV38UserCustomValue = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV80Link = "";
         AV101LinkMudanza = "";
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char6 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV35ExcelFilename = "";
         AV36ErrorMessage = "";
         AV75Roles = new SdtSDTRoles(context);
         AV77RolesItem = new SdtSDTRoles_Id(context);
         ucReplicarprecios2_modal = new GXUserControl();
         ucReplicarrubros_modal = new GXUserControl();
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sImgUrl = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedorww__default(),
            new Object[][] {
                new Object[] {
               H004R2_A344ProveedorEstado, H004R2_A440ProveedorPagoDefault, H004R2_A433ProveedorEmail, H004R2_n433ProveedorEmail, H004R2_A431ProveedorDireccion, H004R2_n431ProveedorDireccion, H004R2_A430ProveedorTelefono, H004R2_n430ProveedorTelefono, H004R2_A338ProveedorDocIdentidad, H004R2_A40000ProveedorImagen_GXI,
               H004R2_n40000ProveedorImagen_GXI, H004R2_A282ProveedorNombre, H004R2_A133ProveedorID, H004R2_A432ProveedorImagen, H004R2_n432ProveedorImagen
               }
               , new Object[] {
               H004R3_A344ProveedorEstado, H004R3_A440ProveedorPagoDefault, H004R3_A433ProveedorEmail, H004R3_n433ProveedorEmail, H004R3_A431ProveedorDireccion, H004R3_n431ProveedorDireccion, H004R3_A430ProveedorTelefono, H004R3_n430ProveedorTelefono, H004R3_A338ProveedorDocIdentidad, H004R3_A40000ProveedorImagen_GXI,
               H004R3_n40000ProveedorImagen_GXI, H004R3_A282ProveedorNombre, H004R3_A133ProveedorID, H004R3_A432ProveedorImagen, H004R3_n432ProveedorImagen
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV105Pgmname = "ProveedorWW";
         /* GeneXus formulas. */
         AV105Pgmname = "ProveedorWW";
         edtavGridbadge_Enabled = 0;
         edtavHacerload_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV34HacerLoad ;
      private short AV14OrderedBy ;
      private short AV46ManageFiltersExecutionStep ;
      private short AV42GridConditionalFormattingFilter ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV66GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV106Proveedorwwds_1_gridconditionalformattingfilter ;
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
      private int nRC_GXsfl_48 ;
      private int nGXsfl_48_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int divUnnamedtable1_Visible ;
      private int subGrid_Islastpage ;
      private int edtavGridbadge_Enabled ;
      private int edtavHacerload_Enabled ;
      private int AV120Proveedorwwds_15_tfproveedorpagodefault_sels_Count ;
      private int AV121Proveedorwwds_16_tfproveedorestado_sels_Count ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtProveedorImagen_Enabled ;
      private int edtProveedorDocIdentidad_Enabled ;
      private int edtProveedorTelefono_Enabled ;
      private int edtProveedorDireccion_Enabled ;
      private int edtProveedorEmail_Enabled ;
      private int AV86ParametrosNumerico ;
      private int edtProveedorID_Visible ;
      private int edtProveedorNombre_Visible ;
      private int edtProveedorImagen_Visible ;
      private int edtProveedorDocIdentidad_Visible ;
      private int edtProveedorTelefono_Visible ;
      private int edtProveedorDireccion_Visible ;
      private int edtProveedorEmail_Visible ;
      private int edtavHacerload_Visible ;
      private int AV62PageToGo ;
      private int AV122GXV1 ;
      private int AV123GXV2 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV47TFProveedorID ;
      private long AV48TFProveedorID_To ;
      private long AV63GridCurrentPage ;
      private long AV64GridPageCount ;
      private long A133ProveedorID ;
      private long GRID_nCurrentRecord ;
      private long AV108Proveedorwwds_3_tfproveedorid ;
      private long AV109Proveedorwwds_4_tfproveedorid_to ;
      private long GRID_nRecordCount ;
      private long AV97SecUserId ;
      private long AV95ProveedorId ;
      private long AV81UsrId ;
      private long AV103Cantidad ;
      private long GXt_int3 ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumnfixedfilter ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_48_idx="0001" ;
      private string AV105Pgmname ;
      private string AV49TFProveedorNombre ;
      private string AV50TFProveedorNombre_Sel ;
      private string AV51TFProveedorDocIdentidad ;
      private string AV52TFProveedorDocIdentidad_Sel ;
      private string AV53TFProveedorTelefono ;
      private string AV54TFProveedorTelefono_Sel ;
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
      private string Newwindow_Target ;
      private string Newwindow2_Width ;
      private string Newwindow2_Height ;
      private string Newwindow2_Target ;
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
      private string Ddo_grid_Fixedfilters ;
      private string Ddo_grid_Format ;
      private string Ddo_grid_Selectedfixedfilter ;
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
      private string Replicarrubros_modal_Width ;
      private string Replicarrubros_modal_Title ;
      private string Replicarrubros_modal_Confirmtype ;
      private string Replicarrubros_modal_Bodytype ;
      private string Replicarprecios2_modal_Width ;
      private string Replicarprecios2_modal_Title ;
      private string Replicarprecios2_modal_Confirmtype ;
      private string Replicarprecios2_modal_Bodytype ;
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
      private string divUnnamedtable1_Internalname ;
      private string bttBtnmudanza_Internalname ;
      private string bttBtnmudanza_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string Newwindow_Internalname ;
      private string Newwindow2_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
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
      private string edtavGridbadge_Internalname ;
      private string cmbavGridactions_Internalname ;
      private string edtProveedorID_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Internalname ;
      private string edtProveedorImagen_Internalname ;
      private string A338ProveedorDocIdentidad ;
      private string edtProveedorDocIdentidad_Internalname ;
      private string A430ProveedorTelefono ;
      private string edtProveedorTelefono_Internalname ;
      private string edtProveedorDireccion_Internalname ;
      private string edtProveedorEmail_Internalname ;
      private string cmbProveedorPagoDefault_Internalname ;
      private string A440ProveedorPagoDefault ;
      private string cmbProveedorEstado_Internalname ;
      private string A344ProveedorEstado ;
      private string edtavHacerload_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string AV110Proveedorwwds_5_tfproveedornombre ;
      private string AV111Proveedorwwds_6_tfproveedornombre_sel ;
      private string AV112Proveedorwwds_7_tfproveedordocidentidad ;
      private string AV113Proveedorwwds_8_tfproveedordocidentidad_sel ;
      private string AV114Proveedorwwds_9_tfproveedortelefono ;
      private string AV115Proveedorwwds_10_tfproveedortelefono_sel ;
      private string lV110Proveedorwwds_5_tfproveedornombre ;
      private string lV112Proveedorwwds_7_tfproveedordocidentidad ;
      private string lV114Proveedorwwds_9_tfproveedortelefono ;
      private string AV85ParametrosEstado ;
      private string cmbProveedorEstado_Columnheaderclass ;
      private string AV79AgrProveedorEstado ;
      private string edtProveedorNombre_Link ;
      private string GXEncryptionTmp ;
      private string cmbProveedorEstado_Columnclass ;
      private string AV80Link ;
      private string GXt_char2 ;
      private string GXt_char6 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string tblTablereplicarprecios2_modal_Internalname ;
      private string Replicarprecios2_modal_Internalname ;
      private string tblTablereplicarrubros_modal_Internalname ;
      private string Replicarrubros_modal_Internalname ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_48_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavGridbadge_Jsonclick ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedorNombre_Jsonclick ;
      private string sImgUrl ;
      private string edtProveedorDocIdentidad_Jsonclick ;
      private string gxphoneLink ;
      private string edtProveedorTelefono_Jsonclick ;
      private string edtProveedorDireccion_Jsonclick ;
      private string edtProveedorEmail_Jsonclick ;
      private string cmbProveedorPagoDefault_Jsonclick ;
      private string cmbProveedorEstado_Jsonclick ;
      private string edtavHacerload_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV90IsAuthorized_Estadisticas ;
      private bool AV92IsAuthorized_DesaINV ;
      private bool AV104IsAuthorized_ReplicarRubros ;
      private bool AV99IsAuthorized_ReplicarPrecios2 ;
      private bool AV68IsAuthorized_Update ;
      private bool AV69IsAuthorized_Delete ;
      private bool AV100Exitoso ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_48_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n432ProveedorImagen ;
      private bool n430ProveedorTelefono ;
      private bool n431ProveedorDireccion ;
      private bool n433ProveedorEmail ;
      private bool AV102VerTodProv ;
      private bool n40000ProveedorImagen_GXI ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV89Existe ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV72TempBoolean ;
      private bool GXt_boolean4 ;
      private bool A432ProveedorImagen_IsBlob ;
      private string AV87TFProveedorPagoDefault_SelsJson ;
      private string AV59TFProveedorEstado_SelsJson ;
      private string AV37ColumnsSelectorXML ;
      private string AV45ManageFiltersXml ;
      private string AV38UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV55TFProveedorDireccion ;
      private string AV56TFProveedorDireccion_Sel ;
      private string AV57TFProveedorEmail ;
      private string AV58TFProveedorEmail_Sel ;
      private string AV76SecRoleName ;
      private string AV65GridAppliedFilters ;
      private string AV43GridBadge ;
      private string A40000ProveedorImagen_GXI ;
      private string A431ProveedorDireccion ;
      private string A433ProveedorEmail ;
      private string AV107Proveedorwwds_2_filterfulltext ;
      private string AV116Proveedorwwds_11_tfproveedordireccion ;
      private string AV117Proveedorwwds_12_tfproveedordireccion_sel ;
      private string AV118Proveedorwwds_13_tfproveedoremail ;
      private string AV119Proveedorwwds_14_tfproveedoremail_sel ;
      private string lV116Proveedorwwds_11_tfproveedordireccion ;
      private string lV118Proveedorwwds_13_tfproveedoremail ;
      private string AV84ParametrosValor ;
      private string AV101LinkMudanza ;
      private string AV35ExcelFilename ;
      private string AV36ErrorMessage ;
      private string A432ProveedorImagen ;
      private IGxSession AV41Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXProperties AV78proveedorProperty ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucNewwindow ;
      private GXUserControl ucNewwindow2 ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucReplicarprecios2_modal ;
      private GXUserControl ucReplicarrubros_modal ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxSession AV96WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbProveedorPagoDefault ;
      private GXCombobox cmbProveedorEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GxSimpleCollection<string> AV88TFProveedorPagoDefault_Sels ;
      private GxSimpleCollection<string> AV60TFProveedorEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV44ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV70AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV61DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GxSimpleCollection<string> AV120Proveedorwwds_15_tfproveedorpagodefault_sels ;
      private GxSimpleCollection<string> AV121Proveedorwwds_16_tfproveedorestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H004R2_A344ProveedorEstado ;
      private string[] H004R2_A440ProveedorPagoDefault ;
      private string[] H004R2_A433ProveedorEmail ;
      private bool[] H004R2_n433ProveedorEmail ;
      private string[] H004R2_A431ProveedorDireccion ;
      private bool[] H004R2_n431ProveedorDireccion ;
      private string[] H004R2_A430ProveedorTelefono ;
      private bool[] H004R2_n430ProveedorTelefono ;
      private string[] H004R2_A338ProveedorDocIdentidad ;
      private string[] H004R2_A40000ProveedorImagen_GXI ;
      private bool[] H004R2_n40000ProveedorImagen_GXI ;
      private string[] H004R2_A282ProveedorNombre ;
      private long[] H004R2_A133ProveedorID ;
      private string[] H004R2_A432ProveedorImagen ;
      private bool[] H004R2_n432ProveedorImagen ;
      private string[] H004R3_A344ProveedorEstado ;
      private string[] H004R3_A440ProveedorPagoDefault ;
      private string[] H004R3_A433ProveedorEmail ;
      private bool[] H004R3_n433ProveedorEmail ;
      private string[] H004R3_A431ProveedorDireccion ;
      private bool[] H004R3_n431ProveedorDireccion ;
      private string[] H004R3_A430ProveedorTelefono ;
      private bool[] H004R3_n430ProveedorTelefono ;
      private string[] H004R3_A338ProveedorDocIdentidad ;
      private string[] H004R3_A40000ProveedorImagen_GXI ;
      private bool[] H004R3_n40000ProveedorImagen_GXI ;
      private string[] H004R3_A282ProveedorNombre ;
      private long[] H004R3_A133ProveedorID ;
      private string[] H004R3_A432ProveedorImagen ;
      private bool[] H004R3_n432ProveedorImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV71AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private SdtSDTRoles AV75Roles ;
      private SdtSDTRoles_Id AV77RolesItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class proveedorww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004R2( IGxContext context ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV120Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV121Proveedorwwds_16_tfproveedorestado_sels ,
                                             short AV106Proveedorwwds_1_gridconditionalformattingfilter ,
                                             long AV108Proveedorwwds_3_tfproveedorid ,
                                             long AV109Proveedorwwds_4_tfproveedorid_to ,
                                             string AV111Proveedorwwds_6_tfproveedornombre_sel ,
                                             string AV110Proveedorwwds_5_tfproveedornombre ,
                                             string AV113Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                             string AV112Proveedorwwds_7_tfproveedordocidentidad ,
                                             string AV115Proveedorwwds_10_tfproveedortelefono_sel ,
                                             string AV114Proveedorwwds_9_tfproveedortelefono ,
                                             string AV117Proveedorwwds_12_tfproveedordireccion_sel ,
                                             string AV116Proveedorwwds_11_tfproveedordireccion ,
                                             string AV119Proveedorwwds_14_tfproveedoremail_sel ,
                                             string AV118Proveedorwwds_13_tfproveedoremail ,
                                             int AV120Proveedorwwds_15_tfproveedorpagodefault_sels_Count ,
                                             int AV121Proveedorwwds_16_tfproveedorestado_sels_Count ,
                                             bool AV102VerTodProv ,
                                             short AV34HacerLoad ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV107Proveedorwwds_2_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[13];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT [ProveedorEstado], [ProveedorPagoDefault], [ProveedorEmail], [ProveedorDireccion], [ProveedorTelefono], [ProveedorDocIdentidad], [ProveedorImagen_GXI], [ProveedorNombre], [ProveedorID], [ProveedorImagen] FROM [Proveedor]";
         if ( AV106Proveedorwwds_1_gridconditionalformattingfilter == 1 )
         {
            AddWhere(sWhereString, "(@AV34HacerLoad = 1)");
         }
         else
         {
            GXv_int12[0] = 1;
         }
         if ( ! (0==AV108Proveedorwwds_3_tfproveedorid) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV108Proveedorwwds_3_tfproveedorid)");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( ! (0==AV109Proveedorwwds_4_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV109Proveedorwwds_4_tfproveedorid_to)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Proveedorwwds_6_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Proveedorwwds_5_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV110Proveedorwwds_5_tfproveedornombre))");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Proveedorwwds_6_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV111Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV111Proveedorwwds_6_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( StringUtil.StrCmp(AV111Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Proveedorwwds_8_tfproveedordocidentidad_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Proveedorwwds_7_tfproveedordocidentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDocIdentidad]) like UPPER(@lV112Proveedorwwds_7_tfproveedordocidentidad))");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Proveedorwwds_8_tfproveedordocidentidad_sel)) && ! ( StringUtil.StrCmp(AV113Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDocIdentidad] = @AV113Proveedorwwds_8_tfproveedordocidentidad_sel)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( StringUtil.StrCmp(AV113Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Proveedorwwds_10_tfproveedortelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Proveedorwwds_9_tfproveedortelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV114Proveedorwwds_9_tfproveedortelefono))");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Proveedorwwds_10_tfproveedortelefono_sel)) && ! ( StringUtil.StrCmp(AV115Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV115Proveedorwwds_10_tfproveedortelefono_sel)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( StringUtil.StrCmp(AV115Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Proveedorwwds_12_tfproveedordireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Proveedorwwds_11_tfproveedordireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV116Proveedorwwds_11_tfproveedordireccion))");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Proveedorwwds_12_tfproveedordireccion_sel)) && ! ( StringUtil.StrCmp(AV117Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV117Proveedorwwds_12_tfproveedordireccion_sel)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( StringUtil.StrCmp(AV117Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Proveedorwwds_14_tfproveedoremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Proveedorwwds_13_tfproveedoremail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV118Proveedorwwds_13_tfproveedoremail))");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Proveedorwwds_14_tfproveedoremail_sel)) && ! ( StringUtil.StrCmp(AV119Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV119Proveedorwwds_14_tfproveedoremail_sel)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( StringUtil.StrCmp(AV119Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV120Proveedorwwds_15_tfproveedorpagodefault_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV120Proveedorwwds_15_tfproveedorpagodefault_sels, "[ProveedorPagoDefault] IN (", ")")+")");
         }
         if ( AV121Proveedorwwds_16_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV121Proveedorwwds_16_tfproveedorestado_sels, "[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! AV102VerTodProv )
         {
            AddWhere(sWhereString, "([ProveedorEstado] = 'HAB')");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorNombre]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorID]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorID] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorDocIdentidad]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorDocIdentidad] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorTelefono]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorDireccion]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorEmail]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorEmail] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorPagoDefault]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorPagoDefault] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorEstado]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorEstado] DESC";
         }
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_H004R3( IGxContext context ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV120Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV121Proveedorwwds_16_tfproveedorestado_sels ,
                                             short AV106Proveedorwwds_1_gridconditionalformattingfilter ,
                                             long AV108Proveedorwwds_3_tfproveedorid ,
                                             long AV109Proveedorwwds_4_tfproveedorid_to ,
                                             string AV111Proveedorwwds_6_tfproveedornombre_sel ,
                                             string AV110Proveedorwwds_5_tfproveedornombre ,
                                             string AV113Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                             string AV112Proveedorwwds_7_tfproveedordocidentidad ,
                                             string AV115Proveedorwwds_10_tfproveedortelefono_sel ,
                                             string AV114Proveedorwwds_9_tfproveedortelefono ,
                                             string AV117Proveedorwwds_12_tfproveedordireccion_sel ,
                                             string AV116Proveedorwwds_11_tfproveedordireccion ,
                                             string AV119Proveedorwwds_14_tfproveedoremail_sel ,
                                             string AV118Proveedorwwds_13_tfproveedoremail ,
                                             int AV120Proveedorwwds_15_tfproveedorpagodefault_sels_Count ,
                                             int AV121Proveedorwwds_16_tfproveedorestado_sels_Count ,
                                             bool AV102VerTodProv ,
                                             short AV34HacerLoad ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV107Proveedorwwds_2_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[13];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT [ProveedorEstado], [ProveedorPagoDefault], [ProveedorEmail], [ProveedorDireccion], [ProveedorTelefono], [ProveedorDocIdentidad], [ProveedorImagen_GXI], [ProveedorNombre], [ProveedorID], [ProveedorImagen] FROM [Proveedor]";
         if ( AV106Proveedorwwds_1_gridconditionalformattingfilter == 1 )
         {
            AddWhere(sWhereString, "(@AV34HacerLoad = 1)");
         }
         else
         {
            GXv_int14[0] = 1;
         }
         if ( ! (0==AV108Proveedorwwds_3_tfproveedorid) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV108Proveedorwwds_3_tfproveedorid)");
         }
         else
         {
            GXv_int14[1] = 1;
         }
         if ( ! (0==AV109Proveedorwwds_4_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV109Proveedorwwds_4_tfproveedorid_to)");
         }
         else
         {
            GXv_int14[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Proveedorwwds_6_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Proveedorwwds_5_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV110Proveedorwwds_5_tfproveedornombre))");
         }
         else
         {
            GXv_int14[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Proveedorwwds_6_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV111Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV111Proveedorwwds_6_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int14[4] = 1;
         }
         if ( StringUtil.StrCmp(AV111Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Proveedorwwds_8_tfproveedordocidentidad_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Proveedorwwds_7_tfproveedordocidentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDocIdentidad]) like UPPER(@lV112Proveedorwwds_7_tfproveedordocidentidad))");
         }
         else
         {
            GXv_int14[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Proveedorwwds_8_tfproveedordocidentidad_sel)) && ! ( StringUtil.StrCmp(AV113Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDocIdentidad] = @AV113Proveedorwwds_8_tfproveedordocidentidad_sel)");
         }
         else
         {
            GXv_int14[6] = 1;
         }
         if ( StringUtil.StrCmp(AV113Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Proveedorwwds_10_tfproveedortelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Proveedorwwds_9_tfproveedortelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV114Proveedorwwds_9_tfproveedortelefono))");
         }
         else
         {
            GXv_int14[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Proveedorwwds_10_tfproveedortelefono_sel)) && ! ( StringUtil.StrCmp(AV115Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV115Proveedorwwds_10_tfproveedortelefono_sel)");
         }
         else
         {
            GXv_int14[8] = 1;
         }
         if ( StringUtil.StrCmp(AV115Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Proveedorwwds_12_tfproveedordireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Proveedorwwds_11_tfproveedordireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV116Proveedorwwds_11_tfproveedordireccion))");
         }
         else
         {
            GXv_int14[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Proveedorwwds_12_tfproveedordireccion_sel)) && ! ( StringUtil.StrCmp(AV117Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV117Proveedorwwds_12_tfproveedordireccion_sel)");
         }
         else
         {
            GXv_int14[10] = 1;
         }
         if ( StringUtil.StrCmp(AV117Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Proveedorwwds_14_tfproveedoremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Proveedorwwds_13_tfproveedoremail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV118Proveedorwwds_13_tfproveedoremail))");
         }
         else
         {
            GXv_int14[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Proveedorwwds_14_tfproveedoremail_sel)) && ! ( StringUtil.StrCmp(AV119Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV119Proveedorwwds_14_tfproveedoremail_sel)");
         }
         else
         {
            GXv_int14[12] = 1;
         }
         if ( StringUtil.StrCmp(AV119Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV120Proveedorwwds_15_tfproveedorpagodefault_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV120Proveedorwwds_15_tfproveedorpagodefault_sels, "[ProveedorPagoDefault] IN (", ")")+")");
         }
         if ( AV121Proveedorwwds_16_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV121Proveedorwwds_16_tfproveedorestado_sels, "[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! AV102VerTodProv )
         {
            AddWhere(sWhereString, "([ProveedorEstado] = 'HAB')");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorNombre]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorID]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorID] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorDocIdentidad]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorDocIdentidad] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorTelefono]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorDireccion]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorEmail]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorEmail] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorPagoDefault]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorPagoDefault] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorEstado]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorEstado] DESC";
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
                     return conditional_H004R2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (bool)dynConstraints[19] , (short)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] );
               case 1 :
                     return conditional_H004R3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (bool)dynConstraints[19] , (short)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] );
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
          Object[] prmH004R2;
          prmH004R2 = new Object[] {
          new ParDef("@AV34HacerLoad",GXType.Int16,1,0) ,
          new ParDef("@AV108Proveedorwwds_3_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV109Proveedorwwds_4_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV110Proveedorwwds_5_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV111Proveedorwwds_6_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV112Proveedorwwds_7_tfproveedordocidentidad",GXType.Char,25,0) ,
          new ParDef("@AV113Proveedorwwds_8_tfproveedordocidentidad_sel",GXType.NChar,25,0) ,
          new ParDef("@lV114Proveedorwwds_9_tfproveedortelefono",GXType.Char,20,0) ,
          new ParDef("@AV115Proveedorwwds_10_tfproveedortelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV116Proveedorwwds_11_tfproveedordireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV117Proveedorwwds_12_tfproveedordireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV118Proveedorwwds_13_tfproveedoremail",GXType.VarChar,100,0) ,
          new ParDef("@AV119Proveedorwwds_14_tfproveedoremail_sel",GXType.NVarChar,100,0)
          };
          Object[] prmH004R3;
          prmH004R3 = new Object[] {
          new ParDef("@AV34HacerLoad",GXType.Int16,1,0) ,
          new ParDef("@AV108Proveedorwwds_3_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV109Proveedorwwds_4_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV110Proveedorwwds_5_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV111Proveedorwwds_6_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV112Proveedorwwds_7_tfproveedordocidentidad",GXType.Char,25,0) ,
          new ParDef("@AV113Proveedorwwds_8_tfproveedordocidentidad_sel",GXType.NChar,25,0) ,
          new ParDef("@lV114Proveedorwwds_9_tfproveedortelefono",GXType.Char,20,0) ,
          new ParDef("@AV115Proveedorwwds_10_tfproveedortelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV116Proveedorwwds_11_tfproveedordireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV117Proveedorwwds_12_tfproveedordireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV118Proveedorwwds_13_tfproveedoremail",GXType.VarChar,100,0) ,
          new ParDef("@AV119Proveedorwwds_14_tfproveedoremail_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R3,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 25);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 80);
                ((long[]) buf[12])[0] = rslt.getLong(9);
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(7));
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 25);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 80);
                ((long[]) buf[12])[0] = rslt.getLong(9);
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(7));
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
