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
   public class estadosnotificacionww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public estadosnotificacionww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estadosnotificacionww( IGxContext context )
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
         chkEstadosNotificacionCliente = new GXCheckbox();
         chkEstadosNotificacionProfesional = new GXCheckbox();
         chkEstadosNotificacionOperador = new GXCheckbox();
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV16FilterFullText = GetPar( "FilterFullText");
         AV26ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21ColumnsSelector);
         AV48Pgmname = GetPar( "Pgmname");
         AV27TFEstadosTipo = GetPar( "TFEstadosTipo");
         AV28TFEstadosTipo_Sel = GetPar( "TFEstadosTipo_Sel");
         AV29TFEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "TFEstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
         AV30TFEstadosGenericosId_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFEstadosGenericosId_To"), "."), 18, MidpointRounding.ToEven));
         AV31TFEstadosGenericosNombre = GetPar( "TFEstadosGenericosNombre");
         AV32TFEstadosGenericosNombre_Sel = GetPar( "TFEstadosGenericosNombre_Sel");
         AV33TFEstadosNotificacionCliente_Sel = GetPar( "TFEstadosNotificacionCliente_Sel");
         AV34TFEstadosNotificacionProfesional_Sel = GetPar( "TFEstadosNotificacionProfesional_Sel");
         AV35TFEstadosNotificacionOperador_Sel = GetPar( "TFEstadosNotificacionOperador_Sel");
         AV43IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV44IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV48Pgmname, AV27TFEstadosTipo, AV28TFEstadosTipo_Sel, AV29TFEstadosGenericosId, AV30TFEstadosGenericosId_To, AV31TFEstadosGenericosNombre, AV32TFEstadosGenericosNombre_Sel, AV33TFEstadosNotificacionCliente_Sel, AV34TFEstadosNotificacionProfesional_Sel, AV35TFEstadosNotificacionOperador_Sel, AV43IsAuthorized_Update, AV44IsAuthorized_Delete) ;
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
         PACK2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTCK2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("estadosnotificacionww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV48Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV44IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV44IsAuthorized_Delete, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV40GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV45AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV45AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV36DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV36DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV48Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFESTADOSTIPO", StringUtil.RTrim( AV27TFEstadosTipo));
         GxWebStd.gx_hidden_field( context, "vTFESTADOSTIPO_SEL", StringUtil.RTrim( AV28TFEstadosTipo_Sel));
         GxWebStd.gx_hidden_field( context, "vTFESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29TFEstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFESTADOSGENERICOSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TFEstadosGenericosId_To), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFESTADOSGENERICOSNOMBRE", StringUtil.RTrim( AV31TFEstadosGenericosNombre));
         GxWebStd.gx_hidden_field( context, "vTFESTADOSGENERICOSNOMBRE_SEL", StringUtil.RTrim( AV32TFEstadosGenericosNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFESTADOSNOTIFICACIONCLIENTE_SEL", StringUtil.RTrim( AV33TFEstadosNotificacionCliente_Sel));
         GxWebStd.gx_hidden_field( context, "vTFESTADOSNOTIFICACIONPROFESIONAL_SEL", StringUtil.RTrim( AV34TFEstadosNotificacionProfesional_Sel));
         GxWebStd.gx_hidden_field( context, "vTFESTADOSNOTIFICACIONOPERADOR_SEL", StringUtil.RTrim( AV35TFEstadosNotificacionOperador_Sel));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV44IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV44IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
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
            WECK2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTCK2( ) ;
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
         return formatLink("estadosnotificacionww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "EstadosNotificacionWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Estados Notificacion", "") ;
      }

      protected void WBCK0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadosNotificacionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadosNotificacionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadosNotificacionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadosNotificacionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_CK2( true) ;
         }
         else
         {
            wb_table1_25_CK2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_CK2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV38GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV39GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV40GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV45AGExportData);
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
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV36DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV36DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV21ColumnsSelector);
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
               GxWebStd.gx_hidden_field( context, "W0064"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0064"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_43_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0064"+"");
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

      protected void STARTCK2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Estados Notificacion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPCK0( ) ;
      }

      protected void WSCK2( )
      {
         STARTCK2( ) ;
         EVTCK2( ) ;
      }

      protected void EVTCK2( )
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
                              E11CK2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12CK2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13CK2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E14CK2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E15CK2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E16CK2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E17CK2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18CK2 ();
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
                              AV41GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV41GridActions), 4, 0));
                              A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
                              A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A109EstadosGenericosNombre = cgiGet( edtEstadosGenericosNombre_Internalname);
                              A263EstadosNotificacionCliente = ((StringUtil.StrCmp(cgiGet( chkEstadosNotificacionCliente_Internalname), "S")==0) ? "S" : "N");
                              A264EstadosNotificacionProfesional = ((StringUtil.StrCmp(cgiGet( chkEstadosNotificacionProfesional_Internalname), "S")==0) ? "S" : "N");
                              A265EstadosNotificacionOperador = ((StringUtil.StrCmp(cgiGet( chkEstadosNotificacionOperador_Internalname), "S")==0) ? "S" : "N");
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19CK2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E20CK2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E21CK2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E22CK2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
                        if ( nCmpId == 64 )
                        {
                           OldWwpaux_wc = cgiGet( "W0064");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0064", "", sEvt);
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

      protected void WECK2( )
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

      protected void PACK2( )
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
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV16FilterFullText ,
                                       short AV26ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ,
                                       string AV48Pgmname ,
                                       string AV27TFEstadosTipo ,
                                       string AV28TFEstadosTipo_Sel ,
                                       int AV29TFEstadosGenericosId ,
                                       int AV30TFEstadosGenericosId_To ,
                                       string AV31TFEstadosGenericosNombre ,
                                       string AV32TFEstadosGenericosNombre_Sel ,
                                       string AV33TFEstadosNotificacionCliente_Sel ,
                                       string AV34TFEstadosNotificacionProfesional_Sel ,
                                       string AV35TFEstadosNotificacionOperador_Sel ,
                                       bool AV43IsAuthorized_Update ,
                                       bool AV44IsAuthorized_Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFCK2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ESTADOSTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPO", StringUtil.RTrim( A107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_ESTADOSGENERICOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", "")));
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
         RFCK2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV48Pgmname = "EstadosNotificacionWW";
      }

      protected void RFCK2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E20CK2 ();
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
            SubsflControlProps_432( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV49Estadosnotificacionwwds_1_filterfulltext ,
                                                 AV51Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                                 AV50Estadosnotificacionwwds_2_tfestadostipo ,
                                                 AV52Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                                 AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                                 AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                                 AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                                 AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                                 AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                                 AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                                 A107EstadosTipo ,
                                                 A108EstadosGenericosId ,
                                                 A109EstadosGenericosNombre ,
                                                 A263EstadosNotificacionCliente ,
                                                 A264EstadosNotificacionProfesional ,
                                                 A265EstadosNotificacionOperador ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV49Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Estadosnotificacionwwds_1_filterfulltext), "%", "");
            lV49Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Estadosnotificacionwwds_1_filterfulltext), "%", "");
            lV49Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Estadosnotificacionwwds_1_filterfulltext), "%", "");
            lV50Estadosnotificacionwwds_2_tfestadostipo = StringUtil.PadR( StringUtil.RTrim( AV50Estadosnotificacionwwds_2_tfestadostipo), 3, "%");
            lV54Estadosnotificacionwwds_6_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre), 80, "%");
            /* Using cursor H00CK2 */
            pr_default.execute(0, new Object[] {lV49Estadosnotificacionwwds_1_filterfulltext, lV49Estadosnotificacionwwds_1_filterfulltext, lV49Estadosnotificacionwwds_1_filterfulltext, lV50Estadosnotificacionwwds_2_tfestadostipo, AV51Estadosnotificacionwwds_3_tfestadostipo_sel, AV52Estadosnotificacionwwds_4_tfestadosgenericosid, AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to, lV54Estadosnotificacionwwds_6_tfestadosgenericosnombre, AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel, AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel, AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_43_idx = 1;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A265EstadosNotificacionOperador = H00CK2_A265EstadosNotificacionOperador[0];
               A264EstadosNotificacionProfesional = H00CK2_A264EstadosNotificacionProfesional[0];
               A263EstadosNotificacionCliente = H00CK2_A263EstadosNotificacionCliente[0];
               A109EstadosGenericosNombre = H00CK2_A109EstadosGenericosNombre[0];
               A108EstadosGenericosId = H00CK2_A108EstadosGenericosId[0];
               A107EstadosTipo = H00CK2_A107EstadosTipo[0];
               /* Execute user event: Grid.Load */
               E21CK2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 43;
            WBCK0( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesCK2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV48Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV44IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV44IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ESTADOSTIPO"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_ESTADOSGENERICOSID"+"_"+sGXsfl_43_idx, GetSecureSignedToken( sGXsfl_43_idx, context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9"), context));
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
         AV49Estadosnotificacionwwds_1_filterfulltext = AV16FilterFullText;
         AV50Estadosnotificacionwwds_2_tfestadostipo = AV27TFEstadosTipo;
         AV51Estadosnotificacionwwds_3_tfestadostipo_sel = AV28TFEstadosTipo_Sel;
         AV52Estadosnotificacionwwds_4_tfestadosgenericosid = AV29TFEstadosGenericosId;
         AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to = AV30TFEstadosGenericosId_To;
         AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre = AV31TFEstadosGenericosNombre;
         AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = AV32TFEstadosGenericosNombre_Sel;
         AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = AV33TFEstadosNotificacionCliente_Sel;
         AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = AV34TFEstadosNotificacionProfesional_Sel;
         AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = AV35TFEstadosNotificacionOperador_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV49Estadosnotificacionwwds_1_filterfulltext ,
                                              AV51Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                              AV50Estadosnotificacionwwds_2_tfestadostipo ,
                                              AV52Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                              AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                              AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                              AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                              AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                              AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                              AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                              A107EstadosTipo ,
                                              A108EstadosGenericosId ,
                                              A109EstadosGenericosNombre ,
                                              A263EstadosNotificacionCliente ,
                                              A264EstadosNotificacionProfesional ,
                                              A265EstadosNotificacionOperador ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV49Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV49Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV49Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV50Estadosnotificacionwwds_2_tfestadostipo = StringUtil.PadR( StringUtil.RTrim( AV50Estadosnotificacionwwds_2_tfestadostipo), 3, "%");
         lV54Estadosnotificacionwwds_6_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre), 80, "%");
         /* Using cursor H00CK3 */
         pr_default.execute(1, new Object[] {lV49Estadosnotificacionwwds_1_filterfulltext, lV49Estadosnotificacionwwds_1_filterfulltext, lV49Estadosnotificacionwwds_1_filterfulltext, lV50Estadosnotificacionwwds_2_tfestadostipo, AV51Estadosnotificacionwwds_3_tfestadostipo_sel, AV52Estadosnotificacionwwds_4_tfestadosgenericosid, AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to, lV54Estadosnotificacionwwds_6_tfestadosgenericosnombre, AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel, AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel, AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel});
         GRID_nRecordCount = H00CK3_AGRID_nRecordCount[0];
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
         AV49Estadosnotificacionwwds_1_filterfulltext = AV16FilterFullText;
         AV50Estadosnotificacionwwds_2_tfestadostipo = AV27TFEstadosTipo;
         AV51Estadosnotificacionwwds_3_tfestadostipo_sel = AV28TFEstadosTipo_Sel;
         AV52Estadosnotificacionwwds_4_tfestadosgenericosid = AV29TFEstadosGenericosId;
         AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to = AV30TFEstadosGenericosId_To;
         AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre = AV31TFEstadosGenericosNombre;
         AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = AV32TFEstadosGenericosNombre_Sel;
         AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = AV33TFEstadosNotificacionCliente_Sel;
         AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = AV34TFEstadosNotificacionProfesional_Sel;
         AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = AV35TFEstadosNotificacionOperador_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV48Pgmname, AV27TFEstadosTipo, AV28TFEstadosTipo_Sel, AV29TFEstadosGenericosId, AV30TFEstadosGenericosId_To, AV31TFEstadosGenericosNombre, AV32TFEstadosGenericosNombre_Sel, AV33TFEstadosNotificacionCliente_Sel, AV34TFEstadosNotificacionProfesional_Sel, AV35TFEstadosNotificacionOperador_Sel, AV43IsAuthorized_Update, AV44IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV49Estadosnotificacionwwds_1_filterfulltext = AV16FilterFullText;
         AV50Estadosnotificacionwwds_2_tfestadostipo = AV27TFEstadosTipo;
         AV51Estadosnotificacionwwds_3_tfestadostipo_sel = AV28TFEstadosTipo_Sel;
         AV52Estadosnotificacionwwds_4_tfestadosgenericosid = AV29TFEstadosGenericosId;
         AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to = AV30TFEstadosGenericosId_To;
         AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre = AV31TFEstadosGenericosNombre;
         AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = AV32TFEstadosGenericosNombre_Sel;
         AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = AV33TFEstadosNotificacionCliente_Sel;
         AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = AV34TFEstadosNotificacionProfesional_Sel;
         AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = AV35TFEstadosNotificacionOperador_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV48Pgmname, AV27TFEstadosTipo, AV28TFEstadosTipo_Sel, AV29TFEstadosGenericosId, AV30TFEstadosGenericosId_To, AV31TFEstadosGenericosNombre, AV32TFEstadosGenericosNombre_Sel, AV33TFEstadosNotificacionCliente_Sel, AV34TFEstadosNotificacionProfesional_Sel, AV35TFEstadosNotificacionOperador_Sel, AV43IsAuthorized_Update, AV44IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV49Estadosnotificacionwwds_1_filterfulltext = AV16FilterFullText;
         AV50Estadosnotificacionwwds_2_tfestadostipo = AV27TFEstadosTipo;
         AV51Estadosnotificacionwwds_3_tfestadostipo_sel = AV28TFEstadosTipo_Sel;
         AV52Estadosnotificacionwwds_4_tfestadosgenericosid = AV29TFEstadosGenericosId;
         AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to = AV30TFEstadosGenericosId_To;
         AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre = AV31TFEstadosGenericosNombre;
         AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = AV32TFEstadosGenericosNombre_Sel;
         AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = AV33TFEstadosNotificacionCliente_Sel;
         AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = AV34TFEstadosNotificacionProfesional_Sel;
         AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = AV35TFEstadosNotificacionOperador_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV48Pgmname, AV27TFEstadosTipo, AV28TFEstadosTipo_Sel, AV29TFEstadosGenericosId, AV30TFEstadosGenericosId_To, AV31TFEstadosGenericosNombre, AV32TFEstadosGenericosNombre_Sel, AV33TFEstadosNotificacionCliente_Sel, AV34TFEstadosNotificacionProfesional_Sel, AV35TFEstadosNotificacionOperador_Sel, AV43IsAuthorized_Update, AV44IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV49Estadosnotificacionwwds_1_filterfulltext = AV16FilterFullText;
         AV50Estadosnotificacionwwds_2_tfestadostipo = AV27TFEstadosTipo;
         AV51Estadosnotificacionwwds_3_tfestadostipo_sel = AV28TFEstadosTipo_Sel;
         AV52Estadosnotificacionwwds_4_tfestadosgenericosid = AV29TFEstadosGenericosId;
         AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to = AV30TFEstadosGenericosId_To;
         AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre = AV31TFEstadosGenericosNombre;
         AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = AV32TFEstadosGenericosNombre_Sel;
         AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = AV33TFEstadosNotificacionCliente_Sel;
         AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = AV34TFEstadosNotificacionProfesional_Sel;
         AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = AV35TFEstadosNotificacionOperador_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV48Pgmname, AV27TFEstadosTipo, AV28TFEstadosTipo_Sel, AV29TFEstadosGenericosId, AV30TFEstadosGenericosId_To, AV31TFEstadosGenericosNombre, AV32TFEstadosGenericosNombre_Sel, AV33TFEstadosNotificacionCliente_Sel, AV34TFEstadosNotificacionProfesional_Sel, AV35TFEstadosNotificacionOperador_Sel, AV43IsAuthorized_Update, AV44IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV49Estadosnotificacionwwds_1_filterfulltext = AV16FilterFullText;
         AV50Estadosnotificacionwwds_2_tfestadostipo = AV27TFEstadosTipo;
         AV51Estadosnotificacionwwds_3_tfestadostipo_sel = AV28TFEstadosTipo_Sel;
         AV52Estadosnotificacionwwds_4_tfestadosgenericosid = AV29TFEstadosGenericosId;
         AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to = AV30TFEstadosGenericosId_To;
         AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre = AV31TFEstadosGenericosNombre;
         AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = AV32TFEstadosGenericosNombre_Sel;
         AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = AV33TFEstadosNotificacionCliente_Sel;
         AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = AV34TFEstadosNotificacionProfesional_Sel;
         AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = AV35TFEstadosNotificacionOperador_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV48Pgmname, AV27TFEstadosTipo, AV28TFEstadosTipo_Sel, AV29TFEstadosGenericosId, AV30TFEstadosGenericosId_To, AV31TFEstadosGenericosNombre, AV32TFEstadosGenericosNombre_Sel, AV33TFEstadosNotificacionCliente_Sel, AV34TFEstadosNotificacionProfesional_Sel, AV35TFEstadosNotificacionOperador_Sel, AV43IsAuthorized_Update, AV44IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV48Pgmname = "EstadosNotificacionWW";
         edtEstadosTipo_Enabled = 0;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         chkEstadosNotificacionCliente.Enabled = 0;
         chkEstadosNotificacionProfesional.Enabled = 0;
         chkEstadosNotificacionOperador.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPCK0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19CK2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV45AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV36DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV21ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV38GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV39GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV40GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
         E19CK2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19CK2( )
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
         AV45AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV46AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV46AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV46AGExportDataItem.gxTpr_Eventkey = "Export";
         AV46AGExportDataItem.gxTpr_Isdivider = false;
         AV45AGExportData.Add(AV46AGExportDataItem, 0);
         AV46AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV46AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV46AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV46AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV46AGExportDataItem.gxTpr_Isdivider = false;
         AV45AGExportData.Add(AV46AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Estados Notificacion", "");
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
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV36DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV36DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E20CK2( )
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
         if ( AV26ManageFiltersExecutionStep == 1 )
         {
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV26ManageFiltersExecutionStep == 2 )
         {
            AV26ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV23Session.Get("EstadosNotificacionWWColumnsSelector"), "") != 0 )
         {
            AV19ColumnsSelectorXML = AV23Session.Get("EstadosNotificacionWWColumnsSelector");
            AV21ColumnsSelector.FromXml(AV19ColumnsSelectorXML, null, "", "");
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
         edtEstadosTipo_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEstadosTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtEstadosGenericosId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEstadosGenericosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Visible), 5, 0), !bGXsfl_43_Refreshing);
         edtEstadosGenericosNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEstadosGenericosNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosNombre_Visible), 5, 0), !bGXsfl_43_Refreshing);
         chkEstadosNotificacionCliente.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkEstadosNotificacionCliente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkEstadosNotificacionCliente.Visible), 5, 0), !bGXsfl_43_Refreshing);
         chkEstadosNotificacionProfesional.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkEstadosNotificacionProfesional_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkEstadosNotificacionProfesional.Visible), 5, 0), !bGXsfl_43_Refreshing);
         chkEstadosNotificacionOperador.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkEstadosNotificacionOperador_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkEstadosNotificacionOperador.Visible), 5, 0), !bGXsfl_43_Refreshing);
         AV38GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV38GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV38GridCurrentPage), 10, 0));
         AV39GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV39GridPageCount", StringUtil.LTrimStr( (decimal)(AV39GridPageCount), 10, 0));
         GXt_char2 = AV40GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV48Pgmname, out  GXt_char2) ;
         AV40GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV40GridAppliedFilters", AV40GridAppliedFilters);
         AV49Estadosnotificacionwwds_1_filterfulltext = AV16FilterFullText;
         AV50Estadosnotificacionwwds_2_tfestadostipo = AV27TFEstadosTipo;
         AV51Estadosnotificacionwwds_3_tfestadostipo_sel = AV28TFEstadosTipo_Sel;
         AV52Estadosnotificacionwwds_4_tfestadosgenericosid = AV29TFEstadosGenericosId;
         AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to = AV30TFEstadosGenericosId_To;
         AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre = AV31TFEstadosGenericosNombre;
         AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = AV32TFEstadosGenericosNombre_Sel;
         AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = AV33TFEstadosNotificacionCliente_Sel;
         AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = AV34TFEstadosNotificacionProfesional_Sel;
         AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = AV35TFEstadosNotificacionOperador_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12CK2( )
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
            AV37PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV37PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13CK2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E16CK2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosTipo") == 0 )
            {
               AV27TFEstadosTipo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV27TFEstadosTipo", AV27TFEstadosTipo);
               AV28TFEstadosTipo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFEstadosTipo_Sel", AV28TFEstadosTipo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosGenericosId") == 0 )
            {
               AV29TFEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29TFEstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV29TFEstadosGenericosId), 5, 0));
               AV30TFEstadosGenericosId_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30TFEstadosGenericosId_To", StringUtil.LTrimStr( (decimal)(AV30TFEstadosGenericosId_To), 5, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosGenericosNombre") == 0 )
            {
               AV31TFEstadosGenericosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFEstadosGenericosNombre", AV31TFEstadosGenericosNombre);
               AV32TFEstadosGenericosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFEstadosGenericosNombre_Sel", AV32TFEstadosGenericosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosNotificacionCliente") == 0 )
            {
               AV33TFEstadosNotificacionCliente_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV33TFEstadosNotificacionCliente_Sel", AV33TFEstadosNotificacionCliente_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosNotificacionProfesional") == 0 )
            {
               AV34TFEstadosNotificacionProfesional_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFEstadosNotificacionProfesional_Sel", AV34TFEstadosNotificacionProfesional_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosNotificacionOperador") == 0 )
            {
               AV35TFEstadosNotificacionOperador_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFEstadosNotificacionOperador_Sel", AV35TFEstadosNotificacionOperador_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E21CK2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         if ( AV43IsAuthorized_Update )
         {
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV44IsAuthorized_Delete )
         {
            cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(A107EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A108EstadosGenericosId,5,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         edtEstadosGenericosNombre_Link = formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 43;
         }
         sendrow_432( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_43_Refreshing )
         {
            context.DoAjaxLoad(43, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41GridActions), 4, 0));
      }

      protected void E17CK2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV19ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV21ColumnsSelector.FromJSonString(AV19ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "EstadosNotificacionWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV19ColumnsSelectorXML)) ? "" : AV21ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E11CK2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("EstadosNotificacionWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV48Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("EstadosNotificacionWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV25ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "EstadosNotificacionWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV25ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV48Pgmname+"GridState",  AV25ManageFiltersXml) ;
               AV11GridState.FromXml(AV25ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E22CK2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV41GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV41GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV41GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV41GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV41GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E18CK2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "estadosnotificacion.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("estadosnotificacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14CK2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E15CK2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0064",(string)"",(string)"EstadosNotificacion",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0064"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "EstadosTipo",  "",  "Tipo de Estados",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "EstadosGenericosId",  "",  "Identificador",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "EstadosGenericosNombre",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "EstadosNotificacionCliente",  "",  "Notificar al cliente el nuevo estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "EstadosNotificacionProfesional",  "",  "Notificar al profesional el nuevo estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "EstadosNotificacionOperador",  "",  "Notificar al operador el nuevo estado",  true,  "") ;
         GXt_char2 = AV20UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "EstadosNotificacionWWColumnsSelector", out  GXt_char2) ;
         AV20UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV20UserCustomValue)) ) )
         {
            AV22ColumnsSelectorAux.FromXml(AV20UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV22ColumnsSelectorAux, ref  AV21ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV43IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion_Update", out  GXt_boolean3) ;
         AV43IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV43IsAuthorized_Update", AV43IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV43IsAuthorized_Update, context));
         GXt_boolean3 = AV44IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion_Delete", out  GXt_boolean3) ;
         AV44IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV44IsAuthorized_Delete", AV44IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV44IsAuthorized_Delete, context));
         GXt_boolean3 = AV47TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion_Insert", out  GXt_boolean3) ;
         AV47TempBoolean = GXt_boolean3;
         if ( ! ( AV47TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean3 = AV47TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean3) ;
         AV47TempBoolean = GXt_boolean3;
         if ( ! ( AV47TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "EstadosNotificacion",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV24ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "EstadosNotificacionWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV27TFEstadosTipo = "";
         AssignAttri("", false, "AV27TFEstadosTipo", AV27TFEstadosTipo);
         AV28TFEstadosTipo_Sel = "";
         AssignAttri("", false, "AV28TFEstadosTipo_Sel", AV28TFEstadosTipo_Sel);
         AV29TFEstadosGenericosId = 0;
         AssignAttri("", false, "AV29TFEstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV29TFEstadosGenericosId), 5, 0));
         AV30TFEstadosGenericosId_To = 0;
         AssignAttri("", false, "AV30TFEstadosGenericosId_To", StringUtil.LTrimStr( (decimal)(AV30TFEstadosGenericosId_To), 5, 0));
         AV31TFEstadosGenericosNombre = "";
         AssignAttri("", false, "AV31TFEstadosGenericosNombre", AV31TFEstadosGenericosNombre);
         AV32TFEstadosGenericosNombre_Sel = "";
         AssignAttri("", false, "AV32TFEstadosGenericosNombre_Sel", AV32TFEstadosGenericosNombre_Sel);
         AV33TFEstadosNotificacionCliente_Sel = "";
         AssignAttri("", false, "AV33TFEstadosNotificacionCliente_Sel", AV33TFEstadosNotificacionCliente_Sel);
         AV34TFEstadosNotificacionProfesional_Sel = "";
         AssignAttri("", false, "AV34TFEstadosNotificacionProfesional_Sel", AV34TFEstadosNotificacionProfesional_Sel);
         AV35TFEstadosNotificacionOperador_Sel = "";
         AssignAttri("", false, "AV35TFEstadosNotificacionOperador_Sel", AV35TFEstadosNotificacionOperador_Sel);
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
         GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(A107EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A108EstadosGenericosId,5,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "estadosnotificacion.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A107EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A108EstadosGenericosId,5,0));
         CallWebObject(formatLink("estadosnotificacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "estadosnotificacion.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A107EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A108EstadosGenericosId,5,0));
         CallWebObject(formatLink("estadosnotificacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get(AV48Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV48Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV23Session.Get(AV48Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO") == 0 )
            {
               AV27TFEstadosTipo = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFEstadosTipo", AV27TFEstadosTipo);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO_SEL") == 0 )
            {
               AV28TFEstadosTipo_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFEstadosTipo_Sel", AV28TFEstadosTipo_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSID") == 0 )
            {
               AV29TFEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29TFEstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV29TFEstadosGenericosId), 5, 0));
               AV30TFEstadosGenericosId_To = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30TFEstadosGenericosId_To", StringUtil.LTrimStr( (decimal)(AV30TFEstadosGenericosId_To), 5, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV31TFEstadosGenericosNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFEstadosGenericosNombre", AV31TFEstadosGenericosNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV32TFEstadosGenericosNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFEstadosGenericosNombre_Sel", AV32TFEstadosGenericosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONCLIENTE_SEL") == 0 )
            {
               AV33TFEstadosNotificacionCliente_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFEstadosNotificacionCliente_Sel", AV33TFEstadosNotificacionCliente_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONPROFESIONAL_SEL") == 0 )
            {
               AV34TFEstadosNotificacionProfesional_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFEstadosNotificacionProfesional_Sel", AV34TFEstadosNotificacionProfesional_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONOPERADOR_SEL") == 0 )
            {
               AV35TFEstadosNotificacionOperador_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFEstadosNotificacionOperador_Sel", AV35TFEstadosNotificacionOperador_Sel);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFEstadosTipo_Sel)),  AV28TFEstadosTipo_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFEstadosGenericosNombre_Sel)),  AV32TFEstadosGenericosNombre_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEstadosNotificacionCliente_Sel)),  AV33TFEstadosNotificacionCliente_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEstadosNotificacionProfesional_Sel)),  AV34TFEstadosNotificacionProfesional_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFEstadosNotificacionOperador_Sel)),  AV35TFEstadosNotificacionOperador_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"||"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFEstadosTipo)),  AV27TFEstadosTipo, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFEstadosGenericosNombre)),  AV31TFEstadosGenericosNombre, out  GXt_char7) ;
         Ddo_grid_Filteredtext_set = GXt_char8+"|"+((0==AV29TFEstadosGenericosId) ? "" : StringUtil.Str( (decimal)(AV29TFEstadosGenericosId), 5, 0))+"|"+GXt_char7+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((0==AV30TFEstadosGenericosId_To) ? "" : StringUtil.Str( (decimal)(AV30TFEstadosGenericosId_To), 5, 0))+"||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV23Session.Get(AV48Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFESTADOSTIPO",  context.GetMessage( "Tipo de Estados", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFEstadosTipo)),  0,  AV27TFEstadosTipo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFEstadosTipo_Sel)),  AV28TFEstadosTipo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFESTADOSGENERICOSID",  context.GetMessage( "Identificador", ""),  !((0==AV29TFEstadosGenericosId)&&(0==AV30TFEstadosGenericosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV29TFEstadosGenericosId), 5, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV30TFEstadosGenericosId_To), 5, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFESTADOSGENERICOSNOMBRE",  context.GetMessage( "Estado", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFEstadosGenericosNombre)),  0,  AV31TFEstadosGenericosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFEstadosGenericosNombre_Sel)),  AV32TFEstadosGenericosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFESTADOSNOTIFICACIONCLIENTE_SEL",  context.GetMessage( "Notificar al cliente el nuevo estado", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEstadosNotificacionCliente_Sel)),  0,  AV33TFEstadosNotificacionCliente_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFESTADOSNOTIFICACIONPROFESIONAL_SEL",  context.GetMessage( "Notificar al profesional el nuevo estado", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEstadosNotificacionProfesional_Sel)),  0,  AV34TFEstadosNotificacionProfesional_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFESTADOSNOTIFICACIONOPERADOR_SEL",  context.GetMessage( "Notificar al operador el nuevo estado", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFEstadosNotificacionOperador_Sel)),  0,  AV35TFEstadosNotificacionOperador_Sel,  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV48Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV48Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "EstadosNotificacion";
         AV23Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S232( )
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
         new estadosnotificacionwwexport(context ).execute( out  AV17ExcelFilename, out  AV18ErrorMessage) ;
         if ( StringUtil.StrCmp(AV17ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV17ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV18ErrorMessage);
         }
      }

      protected void S242( )
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
         Innewwindow1_Target = formatLink("estadosnotificacionwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_CK2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV24ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_30_CK2( true) ;
         }
         else
         {
            wb_table2_30_CK2( false) ;
         }
         return  ;
      }

      protected void wb_table2_30_CK2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_CK2e( true) ;
         }
         else
         {
            wb_table1_25_CK2e( false) ;
         }
      }

      protected void wb_table2_30_CK2( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_EstadosNotificacionWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_30_CK2e( true) ;
         }
         else
         {
            wb_table2_30_CK2e( false) ;
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
         PACK2( ) ;
         WSCK2( ) ;
         WECK2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021225164", true, true, false);
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
         context.AddJavascriptSource("estadosnotificacionww.js", "?202673021225165", false, true, false);
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

      protected void SubsflControlProps_432( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_43_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_43_idx;
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_43_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_43_idx;
         chkEstadosNotificacionCliente_Internalname = "ESTADOSNOTIFICACIONCLIENTE_"+sGXsfl_43_idx;
         chkEstadosNotificacionProfesional_Internalname = "ESTADOSNOTIFICACIONPROFESIONAL_"+sGXsfl_43_idx;
         chkEstadosNotificacionOperador_Internalname = "ESTADOSNOTIFICACIONOPERADOR_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_43_fel_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_43_fel_idx;
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_43_fel_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_43_fel_idx;
         chkEstadosNotificacionCliente_Internalname = "ESTADOSNOTIFICACIONCLIENTE_"+sGXsfl_43_fel_idx;
         chkEstadosNotificacionProfesional_Internalname = "ESTADOSNOTIFICACIONPROFESIONAL_"+sGXsfl_43_fel_idx;
         chkEstadosNotificacionOperador_Internalname = "ESTADOSNOTIFICACIONOPERADOR_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         WBCK0( ) ;
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
                  AV41GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV41GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV41GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV41GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_43_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV41GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_43_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEstadosTipo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosTipo_Internalname,StringUtil.RTrim( A107EstadosTipo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEstadosTipo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtEstadosGenericosId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosGenericosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEstadosGenericosId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEstadosGenericosNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosNombre_Internalname,StringUtil.RTrim( A109EstadosGenericosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtEstadosGenericosNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadosGenericosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEstadosGenericosNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkEstadosNotificacionCliente.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "ESTADOSNOTIFICACIONCLIENTE_" + sGXsfl_43_idx;
            chkEstadosNotificacionCliente.Name = GXCCtl;
            chkEstadosNotificacionCliente.WebTags = "";
            chkEstadosNotificacionCliente.Caption = "";
            AssignProp("", false, chkEstadosNotificacionCliente_Internalname, "TitleCaption", chkEstadosNotificacionCliente.Caption, !bGXsfl_43_Refreshing);
            chkEstadosNotificacionCliente.CheckedValue = "N";
            A263EstadosNotificacionCliente = ((StringUtil.StrCmp(StringUtil.RTrim( A263EstadosNotificacionCliente), "S")==0) ? "S" : "N");
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkEstadosNotificacionCliente_Internalname,(string)A263EstadosNotificacionCliente,(string)"",(string)"",chkEstadosNotificacionCliente.Visible,(short)0,(string)"S",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkEstadosNotificacionProfesional.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "ESTADOSNOTIFICACIONPROFESIONAL_" + sGXsfl_43_idx;
            chkEstadosNotificacionProfesional.Name = GXCCtl;
            chkEstadosNotificacionProfesional.WebTags = "";
            chkEstadosNotificacionProfesional.Caption = "";
            AssignProp("", false, chkEstadosNotificacionProfesional_Internalname, "TitleCaption", chkEstadosNotificacionProfesional.Caption, !bGXsfl_43_Refreshing);
            chkEstadosNotificacionProfesional.CheckedValue = "N";
            A264EstadosNotificacionProfesional = ((StringUtil.StrCmp(StringUtil.RTrim( A264EstadosNotificacionProfesional), "S")==0) ? "S" : "N");
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkEstadosNotificacionProfesional_Internalname,(string)A264EstadosNotificacionProfesional,(string)"",(string)"",chkEstadosNotificacionProfesional.Visible,(short)0,(string)"S",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkEstadosNotificacionOperador.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "ESTADOSNOTIFICACIONOPERADOR_" + sGXsfl_43_idx;
            chkEstadosNotificacionOperador.Name = GXCCtl;
            chkEstadosNotificacionOperador.WebTags = "";
            chkEstadosNotificacionOperador.Caption = "";
            AssignProp("", false, chkEstadosNotificacionOperador_Internalname, "TitleCaption", chkEstadosNotificacionOperador.Caption, !bGXsfl_43_Refreshing);
            chkEstadosNotificacionOperador.CheckedValue = "N";
            A265EstadosNotificacionOperador = ((StringUtil.StrCmp(StringUtil.RTrim( A265EstadosNotificacionOperador), "S")==0) ? "S" : "N");
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkEstadosNotificacionOperador_Internalname,(string)A265EstadosNotificacionOperador,(string)"",(string)"",chkEstadosNotificacionOperador.Visible,(short)0,(string)"S",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            send_integrity_lvl_hashesCK2( ) ;
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
            AV41GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV41GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV41GridActions), 4, 0));
         }
         GXCCtl = "ESTADOSNOTIFICACIONCLIENTE_" + sGXsfl_43_idx;
         chkEstadosNotificacionCliente.Name = GXCCtl;
         chkEstadosNotificacionCliente.WebTags = "";
         chkEstadosNotificacionCliente.Caption = "";
         AssignProp("", false, chkEstadosNotificacionCliente_Internalname, "TitleCaption", chkEstadosNotificacionCliente.Caption, !bGXsfl_43_Refreshing);
         chkEstadosNotificacionCliente.CheckedValue = "N";
         A263EstadosNotificacionCliente = ((StringUtil.StrCmp(StringUtil.RTrim( A263EstadosNotificacionCliente), "S")==0) ? "S" : "N");
         GXCCtl = "ESTADOSNOTIFICACIONPROFESIONAL_" + sGXsfl_43_idx;
         chkEstadosNotificacionProfesional.Name = GXCCtl;
         chkEstadosNotificacionProfesional.WebTags = "";
         chkEstadosNotificacionProfesional.Caption = "";
         AssignProp("", false, chkEstadosNotificacionProfesional_Internalname, "TitleCaption", chkEstadosNotificacionProfesional.Caption, !bGXsfl_43_Refreshing);
         chkEstadosNotificacionProfesional.CheckedValue = "N";
         A264EstadosNotificacionProfesional = ((StringUtil.StrCmp(StringUtil.RTrim( A264EstadosNotificacionProfesional), "S")==0) ? "S" : "N");
         GXCCtl = "ESTADOSNOTIFICACIONOPERADOR_" + sGXsfl_43_idx;
         chkEstadosNotificacionOperador.Name = GXCCtl;
         chkEstadosNotificacionOperador.WebTags = "";
         chkEstadosNotificacionOperador.Caption = "";
         AssignProp("", false, chkEstadosNotificacionOperador_Internalname, "TitleCaption", chkEstadosNotificacionOperador.Caption, !bGXsfl_43_Refreshing);
         chkEstadosNotificacionOperador.CheckedValue = "N";
         A265EstadosNotificacionOperador = ((StringUtil.StrCmp(StringUtil.RTrim( A265EstadosNotificacionOperador), "S")==0) ? "S" : "N");
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEstadosTipo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo de Estados", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEstadosGenericosId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEstadosGenericosNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkEstadosNotificacionCliente.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notificar al cliente el nuevo estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkEstadosNotificacionProfesional.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notificar al profesional el nuevo estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkEstadosNotificacionOperador.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notificar al operador el nuevo estado", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EstadosTipo)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A109EstadosGenericosNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEstadosGenericosNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A263EstadosNotificacionCliente)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkEstadosNotificacionCliente.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A264EstadosNotificacionProfesional)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkEstadosNotificacionProfesional.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A265EstadosNotificacionOperador)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkEstadosNotificacionOperador.Visible), 5, 0, ".", "")));
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
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtEstadosTipo_Internalname = "ESTADOSTIPO";
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE";
         chkEstadosNotificacionCliente_Internalname = "ESTADOSNOTIFICACIONCLIENTE";
         chkEstadosNotificacionProfesional_Internalname = "ESTADOSNOTIFICACIONPROFESIONAL";
         chkEstadosNotificacionOperador_Internalname = "ESTADOSNOTIFICACIONOPERADOR";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
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
         chkEstadosNotificacionOperador.Caption = "";
         chkEstadosNotificacionProfesional.Caption = "";
         chkEstadosNotificacionCliente.Caption = "";
         edtEstadosGenericosNombre_Jsonclick = "";
         edtEstadosGenericosNombre_Link = "";
         edtEstadosGenericosId_Jsonclick = "";
         edtEstadosTipo_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         chkEstadosNotificacionOperador.Visible = -1;
         chkEstadosNotificacionProfesional.Visible = -1;
         chkEstadosNotificacionCliente.Visible = -1;
         edtEstadosGenericosNombre_Visible = -1;
         edtEstadosGenericosId_Visible = -1;
         edtEstadosTipo_Visible = -1;
         chkEstadosNotificacionOperador.Enabled = 0;
         chkEstadosNotificacionProfesional.Enabled = 0;
         chkEstadosNotificacionCliente.Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         subGrid_Sortable = 0;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;";
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
         Ddo_grid_Format = "|5.0||||";
         Ddo_grid_Datalistproc = "EstadosNotificacionWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||S:WWP_TSChecked,N:WWP_TSUnChecked|S:WWP_TSChecked,N:WWP_TSUnChecked|S:WWP_TSChecked,N:WWP_TSUnChecked";
         Ddo_grid_Datalisttype = "Dynamic||Dynamic|FixedValues|FixedValues|FixedValues";
         Ddo_grid_Includedatalist = "T||T|T|T|T";
         Ddo_grid_Filterisrange = "|T||||";
         Ddo_grid_Filtertype = "Character|Numeric|Character|||";
         Ddo_grid_Includefilter = "T|T|T|||";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|1|4|5|6";
         Ddo_grid_Columnids = "1:EstadosTipo|2:EstadosGenericosId|3:EstadosGenericosNombre|4:EstadosNotificacionCliente|5:EstadosNotificacionProfesional|6:EstadosNotificacionOperador";
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
         Form.Caption = context.GetMessage( " Estados Notificacion", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV48Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV27TFEstadosTipo',fld:'vTFESTADOSTIPO',pic:'',type:'char'},{av:'AV28TFEstadosTipo_Sel',fld:'vTFESTADOSTIPO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosId',fld:'vTFESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV30TFEstadosGenericosId_To',fld:'vTFESTADOSGENERICOSID_TO',pic:'ZZZZ9',type:'int'},{av:'AV31TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV32TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV33TFEstadosNotificacionCliente_Sel',fld:'vTFESTADOSNOTIFICACIONCLIENTE_SEL',pic:'',type:'char'},{av:'AV34TFEstadosNotificacionProfesional_Sel',fld:'vTFESTADOSNOTIFICACIONPROFESIONAL_SEL',pic:'',type:'char'},{av:'AV35TFEstadosNotificacionOperador_Sel',fld:'vTFESTADOSNOTIFICACIONOPERADOR_SEL',pic:'',type:'char'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtEstadosTipo_Visible',ctrl:'ESTADOSTIPO',prop:'Visible'},{av:'edtEstadosGenericosId_Visible',ctrl:'ESTADOSGENERICOSID',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'chkEstadosNotificacionCliente.Visible',ctrl:'ESTADOSNOTIFICACIONCLIENTE',prop:'Visible'},{av:'chkEstadosNotificacionProfesional.Visible',ctrl:'ESTADOSNOTIFICACIONPROFESIONAL',prop:'Visible'},{av:'chkEstadosNotificacionOperador.Visible',ctrl:'ESTADOSNOTIFICACIONOPERADOR',prop:'Visible'},{av:'AV38GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV39GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV40GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12CK2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV48Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV27TFEstadosTipo',fld:'vTFESTADOSTIPO',pic:'',type:'char'},{av:'AV28TFEstadosTipo_Sel',fld:'vTFESTADOSTIPO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosId',fld:'vTFESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV30TFEstadosGenericosId_To',fld:'vTFESTADOSGENERICOSID_TO',pic:'ZZZZ9',type:'int'},{av:'AV31TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV32TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV33TFEstadosNotificacionCliente_Sel',fld:'vTFESTADOSNOTIFICACIONCLIENTE_SEL',pic:'',type:'char'},{av:'AV34TFEstadosNotificacionProfesional_Sel',fld:'vTFESTADOSNOTIFICACIONPROFESIONAL_SEL',pic:'',type:'char'},{av:'AV35TFEstadosNotificacionOperador_Sel',fld:'vTFESTADOSNOTIFICACIONOPERADOR_SEL',pic:'',type:'char'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtEstadosTipo_Visible',ctrl:'ESTADOSTIPO',prop:'Visible'},{av:'edtEstadosGenericosId_Visible',ctrl:'ESTADOSGENERICOSID',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'chkEstadosNotificacionCliente.Visible',ctrl:'ESTADOSNOTIFICACIONCLIENTE',prop:'Visible'},{av:'chkEstadosNotificacionProfesional.Visible',ctrl:'ESTADOSNOTIFICACIONPROFESIONAL',prop:'Visible'},{av:'chkEstadosNotificacionOperador.Visible',ctrl:'ESTADOSNOTIFICACIONOPERADOR',prop:'Visible'},{av:'AV38GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV39GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV40GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13CK2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV48Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV27TFEstadosTipo',fld:'vTFESTADOSTIPO',pic:'',type:'char'},{av:'AV28TFEstadosTipo_Sel',fld:'vTFESTADOSTIPO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosId',fld:'vTFESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV30TFEstadosGenericosId_To',fld:'vTFESTADOSGENERICOSID_TO',pic:'ZZZZ9',type:'int'},{av:'AV31TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV32TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV33TFEstadosNotificacionCliente_Sel',fld:'vTFESTADOSNOTIFICACIONCLIENTE_SEL',pic:'',type:'char'},{av:'AV34TFEstadosNotificacionProfesional_Sel',fld:'vTFESTADOSNOTIFICACIONPROFESIONAL_SEL',pic:'',type:'char'},{av:'AV35TFEstadosNotificacionOperador_Sel',fld:'vTFESTADOSNOTIFICACIONOPERADOR_SEL',pic:'',type:'char'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E16CK2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV48Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV27TFEstadosTipo',fld:'vTFESTADOSTIPO',pic:'',type:'char'},{av:'AV28TFEstadosTipo_Sel',fld:'vTFESTADOSTIPO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosId',fld:'vTFESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV30TFEstadosGenericosId_To',fld:'vTFESTADOSGENERICOSID_TO',pic:'ZZZZ9',type:'int'},{av:'AV31TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV32TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV33TFEstadosNotificacionCliente_Sel',fld:'vTFESTADOSNOTIFICACIONCLIENTE_SEL',pic:'',type:'char'},{av:'AV34TFEstadosNotificacionProfesional_Sel',fld:'vTFESTADOSNOTIFICACIONPROFESIONAL_SEL',pic:'',type:'char'},{av:'AV35TFEstadosNotificacionOperador_Sel',fld:'vTFESTADOSNOTIFICACIONOPERADOR_SEL',pic:'',type:'char'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV35TFEstadosNotificacionOperador_Sel',fld:'vTFESTADOSNOTIFICACIONOPERADOR_SEL',pic:'',type:'char'},{av:'AV34TFEstadosNotificacionProfesional_Sel',fld:'vTFESTADOSNOTIFICACIONPROFESIONAL_SEL',pic:'',type:'char'},{av:'AV33TFEstadosNotificacionCliente_Sel',fld:'vTFESTADOSNOTIFICACIONCLIENTE_SEL',pic:'',type:'char'},{av:'AV31TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV32TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosId',fld:'vTFESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV30TFEstadosGenericosId_To',fld:'vTFESTADOSGENERICOSID_TO',pic:'ZZZZ9',type:'int'},{av:'AV27TFEstadosTipo',fld:'vTFESTADOSTIPO',pic:'',type:'char'},{av:'AV28TFEstadosTipo_Sel',fld:'vTFESTADOSTIPO_SEL',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E21CK2',iparms:[{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',hsh:true,type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV41GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtEstadosGenericosNombre_Link',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E17CK2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV48Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV27TFEstadosTipo',fld:'vTFESTADOSTIPO',pic:'',type:'char'},{av:'AV28TFEstadosTipo_Sel',fld:'vTFESTADOSTIPO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosId',fld:'vTFESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV30TFEstadosGenericosId_To',fld:'vTFESTADOSGENERICOSID_TO',pic:'ZZZZ9',type:'int'},{av:'AV31TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV32TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV33TFEstadosNotificacionCliente_Sel',fld:'vTFESTADOSNOTIFICACIONCLIENTE_SEL',pic:'',type:'char'},{av:'AV34TFEstadosNotificacionProfesional_Sel',fld:'vTFESTADOSNOTIFICACIONPROFESIONAL_SEL',pic:'',type:'char'},{av:'AV35TFEstadosNotificacionOperador_Sel',fld:'vTFESTADOSNOTIFICACIONOPERADOR_SEL',pic:'',type:'char'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'edtEstadosTipo_Visible',ctrl:'ESTADOSTIPO',prop:'Visible'},{av:'edtEstadosGenericosId_Visible',ctrl:'ESTADOSGENERICOSID',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'chkEstadosNotificacionCliente.Visible',ctrl:'ESTADOSNOTIFICACIONCLIENTE',prop:'Visible'},{av:'chkEstadosNotificacionProfesional.Visible',ctrl:'ESTADOSNOTIFICACIONPROFESIONAL',prop:'Visible'},{av:'chkEstadosNotificacionOperador.Visible',ctrl:'ESTADOSNOTIFICACIONOPERADOR',prop:'Visible'},{av:'AV38GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV39GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV40GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11CK2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV48Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV27TFEstadosTipo',fld:'vTFESTADOSTIPO',pic:'',type:'char'},{av:'AV28TFEstadosTipo_Sel',fld:'vTFESTADOSTIPO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosId',fld:'vTFESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV30TFEstadosGenericosId_To',fld:'vTFESTADOSGENERICOSID_TO',pic:'ZZZZ9',type:'int'},{av:'AV31TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV32TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV33TFEstadosNotificacionCliente_Sel',fld:'vTFESTADOSNOTIFICACIONCLIENTE_SEL',pic:'',type:'char'},{av:'AV34TFEstadosNotificacionProfesional_Sel',fld:'vTFESTADOSNOTIFICACIONPROFESIONAL_SEL',pic:'',type:'char'},{av:'AV35TFEstadosNotificacionOperador_Sel',fld:'vTFESTADOSNOTIFICACIONOPERADOR_SEL',pic:'',type:'char'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFEstadosTipo',fld:'vTFESTADOSTIPO',pic:'',type:'char'},{av:'AV28TFEstadosTipo_Sel',fld:'vTFESTADOSTIPO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosId',fld:'vTFESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV30TFEstadosGenericosId_To',fld:'vTFESTADOSGENERICOSID_TO',pic:'ZZZZ9',type:'int'},{av:'AV31TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV32TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV33TFEstadosNotificacionCliente_Sel',fld:'vTFESTADOSNOTIFICACIONCLIENTE_SEL',pic:'',type:'char'},{av:'AV34TFEstadosNotificacionProfesional_Sel',fld:'vTFESTADOSNOTIFICACIONPROFESIONAL_SEL',pic:'',type:'char'},{av:'AV35TFEstadosNotificacionOperador_Sel',fld:'vTFESTADOSNOTIFICACIONOPERADOR_SEL',pic:'',type:'char'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtEstadosTipo_Visible',ctrl:'ESTADOSTIPO',prop:'Visible'},{av:'edtEstadosGenericosId_Visible',ctrl:'ESTADOSGENERICOSID',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'chkEstadosNotificacionCliente.Visible',ctrl:'ESTADOSNOTIFICACIONCLIENTE',prop:'Visible'},{av:'chkEstadosNotificacionProfesional.Visible',ctrl:'ESTADOSNOTIFICACIONPROFESIONAL',prop:'Visible'},{av:'chkEstadosNotificacionOperador.Visible',ctrl:'ESTADOSNOTIFICACIONOPERADOR',prop:'Visible'},{av:'AV38GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV39GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV40GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E22CK2',iparms:[{av:'cmbavGridactions'},{av:'AV41GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',hsh:true,type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV41GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E18CK2',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',hsh:true,type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14CK2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV48Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV28TFEstadosTipo_Sel',fld:'vTFESTADOSTIPO_SEL',pic:'',type:'char'},{av:'AV32TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV33TFEstadosNotificacionCliente_Sel',fld:'vTFESTADOSNOTIFICACIONCLIENTE_SEL',pic:'',type:'char'},{av:'AV34TFEstadosNotificacionProfesional_Sel',fld:'vTFESTADOSNOTIFICACIONPROFESIONAL_SEL',pic:'',type:'char'},{av:'AV35TFEstadosNotificacionOperador_Sel',fld:'vTFESTADOSNOTIFICACIONOPERADOR_SEL',pic:'',type:'char'},{av:'AV27TFEstadosTipo',fld:'vTFESTADOSTIPO',pic:'',type:'char'},{av:'AV29TFEstadosGenericosId',fld:'vTFESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV31TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV30TFEstadosGenericosId_To',fld:'vTFESTADOSGENERICOSID_TO',pic:'ZZZZ9',type:'int'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV48Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV27TFEstadosTipo',fld:'vTFESTADOSTIPO',pic:'',type:'char'},{av:'AV28TFEstadosTipo_Sel',fld:'vTFESTADOSTIPO_SEL',pic:'',type:'char'},{av:'AV29TFEstadosGenericosId',fld:'vTFESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV30TFEstadosGenericosId_To',fld:'vTFESTADOSGENERICOSID_TO',pic:'ZZZZ9',type:'int'},{av:'AV31TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV32TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV33TFEstadosNotificacionCliente_Sel',fld:'vTFESTADOSNOTIFICACIONCLIENTE_SEL',pic:'',type:'char'},{av:'AV34TFEstadosNotificacionProfesional_Sel',fld:'vTFESTADOSNOTIFICACIONPROFESIONAL_SEL',pic:'',type:'char'},{av:'AV35TFEstadosNotificacionOperador_Sel',fld:'vTFESTADOSNOTIFICACIONOPERADOR_SEL',pic:'',type:'char'},{av:'AV43IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV44IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'edtEstadosTipo_Visible',ctrl:'ESTADOSTIPO',prop:'Visible'},{av:'edtEstadosGenericosId_Visible',ctrl:'ESTADOSGENERICOSID',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'chkEstadosNotificacionCliente.Visible',ctrl:'ESTADOSNOTIFICACIONCLIENTE',prop:'Visible'},{av:'chkEstadosNotificacionProfesional.Visible',ctrl:'ESTADOSNOTIFICACIONPROFESIONAL',prop:'Visible'},{av:'chkEstadosNotificacionOperador.Visible',ctrl:'ESTADOSNOTIFICACIONOPERADOR',prop:'Visible'},{av:'AV38GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV39GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV40GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E15CK2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("NULL","{handler:'Valid_Estadosnotificacionoperador',iparms:[]");
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
         AV16FilterFullText = "";
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV48Pgmname = "";
         AV27TFEstadosTipo = "";
         AV28TFEstadosTipo_Sel = "";
         AV31TFEstadosGenericosNombre = "";
         AV32TFEstadosGenericosNombre_Sel = "";
         AV33TFEstadosNotificacionCliente_Sel = "";
         AV34TFEstadosNotificacionProfesional_Sel = "";
         AV35TFEstadosNotificacionOperador_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40GridAppliedFilters = "";
         AV45AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV36DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         bttBtnsubscriptions_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
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
         A107EstadosTipo = "";
         A109EstadosGenericosNombre = "";
         A263EstadosNotificacionCliente = "";
         A264EstadosNotificacionProfesional = "";
         A265EstadosNotificacionOperador = "";
         lV49Estadosnotificacionwwds_1_filterfulltext = "";
         lV50Estadosnotificacionwwds_2_tfestadostipo = "";
         lV54Estadosnotificacionwwds_6_tfestadosgenericosnombre = "";
         AV49Estadosnotificacionwwds_1_filterfulltext = "";
         AV51Estadosnotificacionwwds_3_tfestadostipo_sel = "";
         AV50Estadosnotificacionwwds_2_tfestadostipo = "";
         AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = "";
         AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre = "";
         AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = "";
         AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = "";
         AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = "";
         H00CK2_A265EstadosNotificacionOperador = new string[] {""} ;
         H00CK2_A264EstadosNotificacionProfesional = new string[] {""} ;
         H00CK2_A263EstadosNotificacionCliente = new string[] {""} ;
         H00CK2_A109EstadosGenericosNombre = new string[] {""} ;
         H00CK2_A108EstadosGenericosId = new int[1] ;
         H00CK2_A107EstadosTipo = new string[] {""} ;
         H00CK3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV46AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23Session = context.GetSession();
         AV19ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV25ManageFiltersXml = "";
         AV20UserCustomValue = "";
         AV22ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char5 = "";
         GXt_char6 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV17ExcelFilename = "";
         AV18ErrorMessage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadosnotificacionww__default(),
            new Object[][] {
                new Object[] {
               H00CK2_A265EstadosNotificacionOperador, H00CK2_A264EstadosNotificacionProfesional, H00CK2_A263EstadosNotificacionCliente, H00CK2_A109EstadosGenericosNombre, H00CK2_A108EstadosGenericosId, H00CK2_A107EstadosTipo
               }
               , new Object[] {
               H00CK3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV48Pgmname = "EstadosNotificacionWW";
         /* GeneXus formulas. */
         AV48Pgmname = "EstadosNotificacionWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV26ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV41GridActions ;
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
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int AV29TFEstadosGenericosId ;
      private int AV30TFEstadosGenericosId_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int A108EstadosGenericosId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV52Estadosnotificacionwwds_4_tfestadosgenericosid ;
      private int AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to ;
      private int edtEstadosTipo_Enabled ;
      private int edtEstadosGenericosId_Enabled ;
      private int edtEstadosGenericosNombre_Enabled ;
      private int edtEstadosTipo_Visible ;
      private int edtEstadosGenericosId_Visible ;
      private int edtEstadosGenericosNombre_Visible ;
      private int AV37PageToGo ;
      private int AV59GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV38GridCurrentPage ;
      private long AV39GridPageCount ;
      private long GRID_nCurrentRecord ;
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
      private string sGXsfl_43_idx="0001" ;
      private string AV48Pgmname ;
      private string AV27TFEstadosTipo ;
      private string AV28TFEstadosTipo_Sel ;
      private string AV31TFEstadosGenericosNombre ;
      private string AV32TFEstadosGenericosNombre_Sel ;
      private string AV33TFEstadosNotificacionCliente_Sel ;
      private string AV34TFEstadosNotificacionProfesional_Sel ;
      private string AV35TFEstadosNotificacionOperador_Sel ;
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
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
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
      private string cmbavGridactions_Internalname ;
      private string A107EstadosTipo ;
      private string edtEstadosTipo_Internalname ;
      private string edtEstadosGenericosId_Internalname ;
      private string A109EstadosGenericosNombre ;
      private string edtEstadosGenericosNombre_Internalname ;
      private string A263EstadosNotificacionCliente ;
      private string chkEstadosNotificacionCliente_Internalname ;
      private string A264EstadosNotificacionProfesional ;
      private string chkEstadosNotificacionProfesional_Internalname ;
      private string A265EstadosNotificacionOperador ;
      private string chkEstadosNotificacionOperador_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string lV50Estadosnotificacionwwds_2_tfestadostipo ;
      private string lV54Estadosnotificacionwwds_6_tfestadosgenericosnombre ;
      private string AV51Estadosnotificacionwwds_3_tfestadostipo_sel ;
      private string AV50Estadosnotificacionwwds_2_tfestadostipo ;
      private string AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ;
      private string AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre ;
      private string AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ;
      private string AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ;
      private string AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ;
      private string edtEstadosGenericosNombre_Link ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string GXt_char5 ;
      private string GXt_char6 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
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
      private string edtEstadosTipo_Jsonclick ;
      private string edtEstadosGenericosId_Jsonclick ;
      private string edtEstadosGenericosNombre_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV43IsAuthorized_Update ;
      private bool AV44IsAuthorized_Delete ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV47TempBoolean ;
      private bool GXt_boolean3 ;
      private string AV19ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV20UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV40GridAppliedFilters ;
      private string lV49Estadosnotificacionwwds_1_filterfulltext ;
      private string AV49Estadosnotificacionwwds_1_filterfulltext ;
      private string AV17ExcelFilename ;
      private string AV18ErrorMessage ;
      private IGxSession AV23Session ;
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
      private GXCombobox cmbavGridactions ;
      private GXCheckbox chkEstadosNotificacionCliente ;
      private GXCheckbox chkEstadosNotificacionProfesional ;
      private GXCheckbox chkEstadosNotificacionOperador ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV45AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV36DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H00CK2_A265EstadosNotificacionOperador ;
      private string[] H00CK2_A264EstadosNotificacionProfesional ;
      private string[] H00CK2_A263EstadosNotificacionCliente ;
      private string[] H00CK2_A109EstadosGenericosNombre ;
      private int[] H00CK2_A108EstadosGenericosId ;
      private string[] H00CK2_A107EstadosTipo ;
      private long[] H00CK3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV46AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV22ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class estadosnotificacionww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00CK2( IGxContext context ,
                                             string AV49Estadosnotificacionwwds_1_filterfulltext ,
                                             string AV51Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                             string AV50Estadosnotificacionwwds_2_tfestadostipo ,
                                             int AV52Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                             int AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                             string AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                             string AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                             string AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                             string AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                             string AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId ,
                                             string A109EstadosGenericosNombre ,
                                             string A263EstadosNotificacionCliente ,
                                             string A264EstadosNotificacionProfesional ,
                                             string A265EstadosNotificacionOperador ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[15];
         Object[] GXv_Object10 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [EstadosNotificacionOperador], [EstadosNotificacionProfesional], [EstadosNotificacionCliente], [EstadosGenericosNombre], [EstadosGenericosId], [EstadosTipo]";
         sFromString = " FROM [EstadosGenericos]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Estadosnotificacionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([EstadosTipo]) like '%' + UPPER(@lV49Estadosnotificacionwwds_1_filterfulltext)) or ( CONVERT( char(5), CAST([EstadosGenericosId] AS decimal(5,0))) like '%' + @lV49Estadosnotificacionwwds_1_filterfulltext) or ( UPPER([EstadosGenericosNombre]) like '%' + UPPER(@lV49Estadosnotificacionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Estadosnotificacionwwds_3_tfestadostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Estadosnotificacionwwds_2_tfestadostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosTipo]) like UPPER(@lV50Estadosnotificacionwwds_2_tfestadostipo))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Estadosnotificacionwwds_3_tfestadostipo_sel)) && ! ( StringUtil.StrCmp(AV51Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosTipo] = @AV51Estadosnotificacionwwds_3_tfestadostipo_sel)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosTipo] = ''))");
         }
         if ( ! (0==AV52Estadosnotificacionwwds_4_tfestadosgenericosid) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] >= @AV52Estadosnotificacionwwds_4_tfestadosgenericosid)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! (0==AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] <= @AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosGenericosNombre]) like UPPER(@lV54Estadosnotificacionwwds_6_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosGenericosNombre] = @AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosGenericosNombre] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionCliente] = @AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionProfesional] = @AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionOperador] = @AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [EstadosGenericosNombre]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [EstadosGenericosNombre] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [EstadosTipo]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [EstadosTipo] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [EstadosGenericosId]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [EstadosGenericosId] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [EstadosNotificacionCliente]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [EstadosNotificacionCliente] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [EstadosNotificacionProfesional]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [EstadosNotificacionProfesional] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY [EstadosNotificacionOperador]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY [EstadosNotificacionOperador] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [EstadosTipo], [EstadosGenericosId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H00CK3( IGxContext context ,
                                             string AV49Estadosnotificacionwwds_1_filterfulltext ,
                                             string AV51Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                             string AV50Estadosnotificacionwwds_2_tfestadostipo ,
                                             int AV52Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                             int AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                             string AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                             string AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                             string AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                             string AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                             string AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId ,
                                             string A109EstadosGenericosNombre ,
                                             string A263EstadosNotificacionCliente ,
                                             string A264EstadosNotificacionProfesional ,
                                             string A265EstadosNotificacionOperador ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[12];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [EstadosGenericos]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Estadosnotificacionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([EstadosTipo]) like '%' + UPPER(@lV49Estadosnotificacionwwds_1_filterfulltext)) or ( CONVERT( char(5), CAST([EstadosGenericosId] AS decimal(5,0))) like '%' + @lV49Estadosnotificacionwwds_1_filterfulltext) or ( UPPER([EstadosGenericosNombre]) like '%' + UPPER(@lV49Estadosnotificacionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Estadosnotificacionwwds_3_tfestadostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Estadosnotificacionwwds_2_tfestadostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosTipo]) like UPPER(@lV50Estadosnotificacionwwds_2_tfestadostipo))");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Estadosnotificacionwwds_3_tfestadostipo_sel)) && ! ( StringUtil.StrCmp(AV51Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosTipo] = @AV51Estadosnotificacionwwds_3_tfestadostipo_sel)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosTipo] = ''))");
         }
         if ( ! (0==AV52Estadosnotificacionwwds_4_tfestadosgenericosid) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] >= @AV52Estadosnotificacionwwds_4_tfestadosgenericosid)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! (0==AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] <= @AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Estadosnotificacionwwds_6_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosGenericosNombre]) like UPPER(@lV54Estadosnotificacionwwds_6_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosGenericosNombre] = @AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( StringUtil.StrCmp(AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosGenericosNombre] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionCliente] = @AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionProfesional] = @AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionOperador] = @AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
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
                     return conditional_H00CK2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
               case 1 :
                     return conditional_H00CK3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmH00CK2;
          prmH00CK2 = new Object[] {
          new ParDef("@lV49Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV49Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV49Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV50Estadosnotificacionwwds_2_tfestadostipo",GXType.Char,3,0) ,
          new ParDef("@AV51Estadosnotificacionwwds_3_tfestadostipo_sel",GXType.NChar,3,0) ,
          new ParDef("@AV52Estadosnotificacionwwds_4_tfestadosgenericosid",GXType.Int32,5,0) ,
          new ParDef("@AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to",GXType.Int32,5,0) ,
          new ParDef("@lV54Estadosnotificacionwwds_6_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel",GXType.NChar,1,0) ,
          new ParDef("@AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel",GXType.NChar,1,0) ,
          new ParDef("@AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel",GXType.NChar,1,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00CK3;
          prmH00CK3 = new Object[] {
          new ParDef("@lV49Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV49Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV49Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV50Estadosnotificacionwwds_2_tfestadostipo",GXType.Char,3,0) ,
          new ParDef("@AV51Estadosnotificacionwwds_3_tfestadostipo_sel",GXType.NChar,3,0) ,
          new ParDef("@AV52Estadosnotificacionwwds_4_tfestadosgenericosid",GXType.Int32,5,0) ,
          new ParDef("@AV53Estadosnotificacionwwds_5_tfestadosgenericosid_to",GXType.Int32,5,0) ,
          new ParDef("@lV54Estadosnotificacionwwds_6_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV55Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV56Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel",GXType.NChar,1,0) ,
          new ParDef("@AV57Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel",GXType.NChar,1,0) ,
          new ParDef("@AV58Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00CK2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00CK2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00CK3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00CK3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
