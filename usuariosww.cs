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
   public class usuariosww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public usuariosww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usuariosww( IGxContext context )
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
         cmbusuariosTipo = new GXCombobox();
         cmbusuariosEstado = new GXCombobox();
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
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
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
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV71Pgmname = GetPar( "Pgmname");
         AV17FilterFullText = GetPar( "FilterFullText");
         AV44TFusuariosId = GetPar( "TFusuariosId");
         AV45TFusuariosId_Sel = GetPar( "TFusuariosId_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV47TFusuariosTipo_Sels);
         AV48TFusuariosNombre = GetPar( "TFusuariosNombre");
         AV49TFusuariosNombre_Sel = GetPar( "TFusuariosNombre_Sel");
         AV50TFPaisID = GetPar( "TFPaisID");
         AV51TFPaisID_Sel = GetPar( "TFPaisID_Sel");
         AV52TFusuariosTelefono = GetPar( "TFusuariosTelefono");
         AV53TFusuariosTelefono_Sel = GetPar( "TFusuariosTelefono_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV55TFusuariosEstado_Sels);
         AV69TFusuariosPasw = GetPar( "TFusuariosPasw");
         AV70TFusuariosPasw_Sel = GetPar( "TFusuariosPasw_Sel");
         AV68IsAuthorized_Desencriptar = StringUtil.StrToBool( GetPar( "IsAuthorized_Desencriptar"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV43ManageFiltersExecutionStep, AV71Pgmname, AV17FilterFullText, AV44TFusuariosId, AV45TFusuariosId_Sel, AV47TFusuariosTipo_Sels, AV48TFusuariosNombre, AV49TFusuariosNombre_Sel, AV50TFPaisID, AV51TFPaisID_Sel, AV52TFusuariosTelefono, AV53TFusuariosTelefono_Sel, AV55TFusuariosEstado_Sels, AV69TFusuariosPasw, AV70TFusuariosPasw_Sel, AV68IsAuthorized_Desencriptar) ;
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
         PABW2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTBW2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usuariosww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DESENCRIPTAR", AV68IsAuthorized_Desencriptar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESENCRIPTAR", GetSecureSignedToken( "", AV68IsAuthorized_Desencriptar, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV60GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV56DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV56DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSID", StringUtil.RTrim( AV44TFusuariosId));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSID_SEL", StringUtil.RTrim( AV45TFusuariosId_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFUSUARIOSTIPO_SELS", AV47TFusuariosTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFUSUARIOSTIPO_SELS", AV47TFusuariosTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSNOMBRE", StringUtil.RTrim( AV48TFusuariosNombre));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSNOMBRE_SEL", StringUtil.RTrim( AV49TFusuariosNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPAISID", StringUtil.RTrim( AV50TFPaisID));
         GxWebStd.gx_hidden_field( context, "vTFPAISID_SEL", StringUtil.RTrim( AV51TFPaisID_Sel));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSTELEFONO", StringUtil.RTrim( AV52TFusuariosTelefono));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSTELEFONO_SEL", StringUtil.RTrim( AV53TFusuariosTelefono_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFUSUARIOSESTADO_SELS", AV55TFusuariosEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFUSUARIOSESTADO_SELS", AV55TFusuariosEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSPASW", StringUtil.RTrim( AV69TFusuariosPasw));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSPASW_SEL", StringUtil.RTrim( AV70TFusuariosPasw_Sel));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DESENCRIPTAR", AV68IsAuthorized_Desencriptar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESENCRIPTAR", GetSecureSignedToken( "", AV68IsAuthorized_Desencriptar, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSTIPO_SELSJSON", AV46TFusuariosTipo_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSESTADO_SELSJSON", AV54TFusuariosEstado_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DESENCRIPTAR_MODAL_Width", StringUtil.RTrim( Desencriptar_modal_Width));
         GxWebStd.gx_hidden_field( context, "DESENCRIPTAR_MODAL_Title", StringUtil.RTrim( Desencriptar_modal_Title));
         GxWebStd.gx_hidden_field( context, "DESENCRIPTAR_MODAL_Confirmtype", StringUtil.RTrim( Desencriptar_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DESENCRIPTAR_MODAL_Bodytype", StringUtil.RTrim( Desencriptar_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            WEBW2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTBW2( ) ;
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
         return formatLink("usuariosww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "usuariosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " usuarios", "") ;
      }

      protected void WBBW0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_usuariosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_19_BW2( true) ;
         }
         else
         {
            wb_table1_19_BW2( false) ;
         }
         return  ;
      }

      protected void wb_table1_19_BW2e( bool wbgen )
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
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV58GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV59GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV60GridAppliedFilters);
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV56DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            wb_table2_53_BW2( true) ;
         }
         else
         {
            wb_table2_53_BW2( false) ;
         }
         return  ;
      }

      protected void wb_table2_53_BW2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0060"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0060"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_37_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
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
         if ( wbEnd == 37 )
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

      protected void STARTBW2( )
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
         Form.Meta.addItem("description", context.GetMessage( " usuarios", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPBW0( ) ;
      }

      protected void WSBW2( )
      {
         STARTBW2( ) ;
         EVTBW2( ) ;
      }

      protected void EVTBW2( )
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
                              E11BW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12BW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13BW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14BW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DESENCRIPTAR_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Desencriptar_modal.Close */
                              E15BW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DESENCRIPTAR_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Desencriptar_modal.Onloadcomponent */
                              E16BW2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E17BW2 ();
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
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV61GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV61GridActions), 4, 0));
                              A145usuariosId = cgiGet( edtusuariosId_Internalname);
                              cmbusuariosTipo.Name = cmbusuariosTipo_Internalname;
                              cmbusuariosTipo.CurrentValue = cgiGet( cmbusuariosTipo_Internalname);
                              A225usuariosTipo = cgiGet( cmbusuariosTipo_Internalname);
                              A222usuariosNombre = cgiGet( edtusuariosNombre_Internalname);
                              A116PaisID = cgiGet( edtPaisID_Internalname);
                              A232usuariosTelefono = cgiGet( edtusuariosTelefono_Internalname);
                              cmbusuariosEstado.Name = cmbusuariosEstado_Internalname;
                              cmbusuariosEstado.CurrentValue = cgiGet( cmbusuariosEstado_Internalname);
                              A226usuariosEstado = cgiGet( cmbusuariosEstado_Internalname);
                              A223usuariosPasw = cgiGet( edtusuariosPasw_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18BW2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E19BW2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E20BW2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E21BW2 ();
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
                        if ( nCmpId == 60 )
                        {
                           OldWwpaux_wc = cgiGet( "W0060");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0060", "", sEvt);
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

      protected void WEBW2( )
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

      protected void PABW2( )
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
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       short AV43ManageFiltersExecutionStep ,
                                       string AV71Pgmname ,
                                       string AV17FilterFullText ,
                                       string AV44TFusuariosId ,
                                       string AV45TFusuariosId_Sel ,
                                       GxSimpleCollection<string> AV47TFusuariosTipo_Sels ,
                                       string AV48TFusuariosNombre ,
                                       string AV49TFusuariosNombre_Sel ,
                                       string AV50TFPaisID ,
                                       string AV51TFPaisID_Sel ,
                                       string AV52TFusuariosTelefono ,
                                       string AV53TFusuariosTelefono_Sel ,
                                       GxSimpleCollection<string> AV55TFusuariosEstado_Sels ,
                                       string AV69TFusuariosPasw ,
                                       string AV70TFusuariosPasw_Sel ,
                                       bool AV68IsAuthorized_Desencriptar )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFBW2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSID", StringUtil.RTrim( A145usuariosId));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSPASW", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A223usuariosPasw, "")), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSPASW", StringUtil.RTrim( A223usuariosPasw));
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
         RFBW2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV71Pgmname = "usuariosWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV72Usuarioswwds_1_filterfulltext = AV17FilterFullText;
         AV73Usuarioswwds_2_tfusuariosid = AV44TFusuariosId;
         AV74Usuarioswwds_3_tfusuariosid_sel = AV45TFusuariosId_Sel;
         AV75Usuarioswwds_4_tfusuariostipo_sels = AV47TFusuariosTipo_Sels;
         AV76Usuarioswwds_5_tfusuariosnombre = AV48TFusuariosNombre;
         AV77Usuarioswwds_6_tfusuariosnombre_sel = AV49TFusuariosNombre_Sel;
         AV78Usuarioswwds_7_tfpaisid = AV50TFPaisID;
         AV79Usuarioswwds_8_tfpaisid_sel = AV51TFPaisID_Sel;
         AV80Usuarioswwds_9_tfusuariostelefono = AV52TFusuariosTelefono;
         AV81Usuarioswwds_10_tfusuariostelefono_sel = AV53TFusuariosTelefono_Sel;
         AV82Usuarioswwds_11_tfusuariosestado_sels = AV55TFusuariosEstado_Sels;
         AV83Usuarioswwds_12_tfusuariospasw = AV69TFusuariosPasw;
         AV84Usuarioswwds_13_tfusuariospasw_sel = AV70TFusuariosPasw_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A225usuariosTipo ,
                                              AV75Usuarioswwds_4_tfusuariostipo_sels ,
                                              A226usuariosEstado ,
                                              AV82Usuarioswwds_11_tfusuariosestado_sels ,
                                              AV74Usuarioswwds_3_tfusuariosid_sel ,
                                              AV73Usuarioswwds_2_tfusuariosid ,
                                              AV75Usuarioswwds_4_tfusuariostipo_sels.Count ,
                                              AV77Usuarioswwds_6_tfusuariosnombre_sel ,
                                              AV76Usuarioswwds_5_tfusuariosnombre ,
                                              AV79Usuarioswwds_8_tfpaisid_sel ,
                                              AV78Usuarioswwds_7_tfpaisid ,
                                              AV81Usuarioswwds_10_tfusuariostelefono_sel ,
                                              AV80Usuarioswwds_9_tfusuariostelefono ,
                                              AV82Usuarioswwds_11_tfusuariosestado_sels.Count ,
                                              AV84Usuarioswwds_13_tfusuariospasw_sel ,
                                              AV83Usuarioswwds_12_tfusuariospasw ,
                                              A145usuariosId ,
                                              A222usuariosNombre ,
                                              A116PaisID ,
                                              A232usuariosTelefono ,
                                              A223usuariosPasw ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV72Usuarioswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV73Usuarioswwds_2_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV73Usuarioswwds_2_tfusuariosid), 20, "%");
         lV76Usuarioswwds_5_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV76Usuarioswwds_5_tfusuariosnombre), 80, "%");
         lV78Usuarioswwds_7_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV78Usuarioswwds_7_tfpaisid), 2, "%");
         lV80Usuarioswwds_9_tfusuariostelefono = StringUtil.PadR( StringUtil.RTrim( AV80Usuarioswwds_9_tfusuariostelefono), 20, "%");
         lV83Usuarioswwds_12_tfusuariospasw = StringUtil.PadR( StringUtil.RTrim( AV83Usuarioswwds_12_tfusuariospasw), 80, "%");
         /* Using cursor H00BW2 */
         pr_default.execute(0, new Object[] {lV73Usuarioswwds_2_tfusuariosid, AV74Usuarioswwds_3_tfusuariosid_sel, lV76Usuarioswwds_5_tfusuariosnombre, AV77Usuarioswwds_6_tfusuariosnombre_sel, lV78Usuarioswwds_7_tfpaisid, AV79Usuarioswwds_8_tfpaisid_sel, lV80Usuarioswwds_9_tfusuariostelefono, AV81Usuarioswwds_10_tfusuariostelefono_sel, lV83Usuarioswwds_12_tfusuariospasw, AV84Usuarioswwds_13_tfusuariospasw_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A223usuariosPasw = H00BW2_A223usuariosPasw[0];
            A226usuariosEstado = H00BW2_A226usuariosEstado[0];
            A232usuariosTelefono = H00BW2_A232usuariosTelefono[0];
            A116PaisID = H00BW2_A116PaisID[0];
            A222usuariosNombre = H00BW2_A222usuariosNombre[0];
            A225usuariosTipo = H00BW2_A225usuariosTipo[0];
            A145usuariosId = H00BW2_A145usuariosId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Usuarioswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrador sistema", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedor de servicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "administrador de agencia", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "G") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "agente de servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cliente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "C") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "usuario registrado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "R") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "usuario sin registrar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "U") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A116PaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A232usuariosTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A223usuariosPasw) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
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

      protected void RFBW2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E19BW2 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
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
            SubsflControlProps_372( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A225usuariosTipo ,
                                                 AV75Usuarioswwds_4_tfusuariostipo_sels ,
                                                 A226usuariosEstado ,
                                                 AV82Usuarioswwds_11_tfusuariosestado_sels ,
                                                 AV74Usuarioswwds_3_tfusuariosid_sel ,
                                                 AV73Usuarioswwds_2_tfusuariosid ,
                                                 AV75Usuarioswwds_4_tfusuariostipo_sels.Count ,
                                                 AV77Usuarioswwds_6_tfusuariosnombre_sel ,
                                                 AV76Usuarioswwds_5_tfusuariosnombre ,
                                                 AV79Usuarioswwds_8_tfpaisid_sel ,
                                                 AV78Usuarioswwds_7_tfpaisid ,
                                                 AV81Usuarioswwds_10_tfusuariostelefono_sel ,
                                                 AV80Usuarioswwds_9_tfusuariostelefono ,
                                                 AV82Usuarioswwds_11_tfusuariosestado_sels.Count ,
                                                 AV84Usuarioswwds_13_tfusuariospasw_sel ,
                                                 AV83Usuarioswwds_12_tfusuariospasw ,
                                                 A145usuariosId ,
                                                 A222usuariosNombre ,
                                                 A116PaisID ,
                                                 A232usuariosTelefono ,
                                                 A223usuariosPasw ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV72Usuarioswwds_1_filterfulltext } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV73Usuarioswwds_2_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV73Usuarioswwds_2_tfusuariosid), 20, "%");
            lV76Usuarioswwds_5_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV76Usuarioswwds_5_tfusuariosnombre), 80, "%");
            lV78Usuarioswwds_7_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV78Usuarioswwds_7_tfpaisid), 2, "%");
            lV80Usuarioswwds_9_tfusuariostelefono = StringUtil.PadR( StringUtil.RTrim( AV80Usuarioswwds_9_tfusuariostelefono), 20, "%");
            lV83Usuarioswwds_12_tfusuariospasw = StringUtil.PadR( StringUtil.RTrim( AV83Usuarioswwds_12_tfusuariospasw), 80, "%");
            /* Using cursor H00BW3 */
            pr_default.execute(1, new Object[] {lV73Usuarioswwds_2_tfusuariosid, AV74Usuarioswwds_3_tfusuariosid_sel, lV76Usuarioswwds_5_tfusuariosnombre, AV77Usuarioswwds_6_tfusuariosnombre_sel, lV78Usuarioswwds_7_tfpaisid, AV79Usuarioswwds_8_tfpaisid_sel, lV80Usuarioswwds_9_tfusuariostelefono, AV81Usuarioswwds_10_tfusuariostelefono_sel, lV83Usuarioswwds_12_tfusuariospasw, AV84Usuarioswwds_13_tfusuariospasw_sel});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A223usuariosPasw = H00BW3_A223usuariosPasw[0];
               A226usuariosEstado = H00BW3_A226usuariosEstado[0];
               A232usuariosTelefono = H00BW3_A232usuariosTelefono[0];
               A116PaisID = H00BW3_A116PaisID[0];
               A222usuariosNombre = H00BW3_A222usuariosNombre[0];
               A225usuariosTipo = H00BW3_A225usuariosTipo[0];
               A145usuariosId = H00BW3_A145usuariosId[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Usuarioswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "administrador sistema", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedor de servicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A225usuariosTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "administrador de agencia", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "G") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "agente de servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cliente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A225usuariosTipo, "C") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "usuario registrado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "R") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "usuario sin registrar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "U") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A116PaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A232usuariosTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A223usuariosPasw) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E20BW2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WBBW0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBW2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DESENCRIPTAR", AV68IsAuthorized_Desencriptar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESENCRIPTAR", GetSecureSignedToken( "", AV68IsAuthorized_Desencriptar, context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSPASW"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A223usuariosPasw, "")), context));
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
         AV72Usuarioswwds_1_filterfulltext = AV17FilterFullText;
         AV73Usuarioswwds_2_tfusuariosid = AV44TFusuariosId;
         AV74Usuarioswwds_3_tfusuariosid_sel = AV45TFusuariosId_Sel;
         AV75Usuarioswwds_4_tfusuariostipo_sels = AV47TFusuariosTipo_Sels;
         AV76Usuarioswwds_5_tfusuariosnombre = AV48TFusuariosNombre;
         AV77Usuarioswwds_6_tfusuariosnombre_sel = AV49TFusuariosNombre_Sel;
         AV78Usuarioswwds_7_tfpaisid = AV50TFPaisID;
         AV79Usuarioswwds_8_tfpaisid_sel = AV51TFPaisID_Sel;
         AV80Usuarioswwds_9_tfusuariostelefono = AV52TFusuariosTelefono;
         AV81Usuarioswwds_10_tfusuariostelefono_sel = AV53TFusuariosTelefono_Sel;
         AV82Usuarioswwds_11_tfusuariosestado_sels = AV55TFusuariosEstado_Sels;
         AV83Usuarioswwds_12_tfusuariospasw = AV69TFusuariosPasw;
         AV84Usuarioswwds_13_tfusuariospasw_sel = AV70TFusuariosPasw_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV43ManageFiltersExecutionStep, AV71Pgmname, AV17FilterFullText, AV44TFusuariosId, AV45TFusuariosId_Sel, AV47TFusuariosTipo_Sels, AV48TFusuariosNombre, AV49TFusuariosNombre_Sel, AV50TFPaisID, AV51TFPaisID_Sel, AV52TFusuariosTelefono, AV53TFusuariosTelefono_Sel, AV55TFusuariosEstado_Sels, AV69TFusuariosPasw, AV70TFusuariosPasw_Sel, AV68IsAuthorized_Desencriptar) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV72Usuarioswwds_1_filterfulltext = AV17FilterFullText;
         AV73Usuarioswwds_2_tfusuariosid = AV44TFusuariosId;
         AV74Usuarioswwds_3_tfusuariosid_sel = AV45TFusuariosId_Sel;
         AV75Usuarioswwds_4_tfusuariostipo_sels = AV47TFusuariosTipo_Sels;
         AV76Usuarioswwds_5_tfusuariosnombre = AV48TFusuariosNombre;
         AV77Usuarioswwds_6_tfusuariosnombre_sel = AV49TFusuariosNombre_Sel;
         AV78Usuarioswwds_7_tfpaisid = AV50TFPaisID;
         AV79Usuarioswwds_8_tfpaisid_sel = AV51TFPaisID_Sel;
         AV80Usuarioswwds_9_tfusuariostelefono = AV52TFusuariosTelefono;
         AV81Usuarioswwds_10_tfusuariostelefono_sel = AV53TFusuariosTelefono_Sel;
         AV82Usuarioswwds_11_tfusuariosestado_sels = AV55TFusuariosEstado_Sels;
         AV83Usuarioswwds_12_tfusuariospasw = AV69TFusuariosPasw;
         AV84Usuarioswwds_13_tfusuariospasw_sel = AV70TFusuariosPasw_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV43ManageFiltersExecutionStep, AV71Pgmname, AV17FilterFullText, AV44TFusuariosId, AV45TFusuariosId_Sel, AV47TFusuariosTipo_Sels, AV48TFusuariosNombre, AV49TFusuariosNombre_Sel, AV50TFPaisID, AV51TFPaisID_Sel, AV52TFusuariosTelefono, AV53TFusuariosTelefono_Sel, AV55TFusuariosEstado_Sels, AV69TFusuariosPasw, AV70TFusuariosPasw_Sel, AV68IsAuthorized_Desencriptar) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV72Usuarioswwds_1_filterfulltext = AV17FilterFullText;
         AV73Usuarioswwds_2_tfusuariosid = AV44TFusuariosId;
         AV74Usuarioswwds_3_tfusuariosid_sel = AV45TFusuariosId_Sel;
         AV75Usuarioswwds_4_tfusuariostipo_sels = AV47TFusuariosTipo_Sels;
         AV76Usuarioswwds_5_tfusuariosnombre = AV48TFusuariosNombre;
         AV77Usuarioswwds_6_tfusuariosnombre_sel = AV49TFusuariosNombre_Sel;
         AV78Usuarioswwds_7_tfpaisid = AV50TFPaisID;
         AV79Usuarioswwds_8_tfpaisid_sel = AV51TFPaisID_Sel;
         AV80Usuarioswwds_9_tfusuariostelefono = AV52TFusuariosTelefono;
         AV81Usuarioswwds_10_tfusuariostelefono_sel = AV53TFusuariosTelefono_Sel;
         AV82Usuarioswwds_11_tfusuariosestado_sels = AV55TFusuariosEstado_Sels;
         AV83Usuarioswwds_12_tfusuariospasw = AV69TFusuariosPasw;
         AV84Usuarioswwds_13_tfusuariospasw_sel = AV70TFusuariosPasw_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV43ManageFiltersExecutionStep, AV71Pgmname, AV17FilterFullText, AV44TFusuariosId, AV45TFusuariosId_Sel, AV47TFusuariosTipo_Sels, AV48TFusuariosNombre, AV49TFusuariosNombre_Sel, AV50TFPaisID, AV51TFPaisID_Sel, AV52TFusuariosTelefono, AV53TFusuariosTelefono_Sel, AV55TFusuariosEstado_Sels, AV69TFusuariosPasw, AV70TFusuariosPasw_Sel, AV68IsAuthorized_Desencriptar) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV72Usuarioswwds_1_filterfulltext = AV17FilterFullText;
         AV73Usuarioswwds_2_tfusuariosid = AV44TFusuariosId;
         AV74Usuarioswwds_3_tfusuariosid_sel = AV45TFusuariosId_Sel;
         AV75Usuarioswwds_4_tfusuariostipo_sels = AV47TFusuariosTipo_Sels;
         AV76Usuarioswwds_5_tfusuariosnombre = AV48TFusuariosNombre;
         AV77Usuarioswwds_6_tfusuariosnombre_sel = AV49TFusuariosNombre_Sel;
         AV78Usuarioswwds_7_tfpaisid = AV50TFPaisID;
         AV79Usuarioswwds_8_tfpaisid_sel = AV51TFPaisID_Sel;
         AV80Usuarioswwds_9_tfusuariostelefono = AV52TFusuariosTelefono;
         AV81Usuarioswwds_10_tfusuariostelefono_sel = AV53TFusuariosTelefono_Sel;
         AV82Usuarioswwds_11_tfusuariosestado_sels = AV55TFusuariosEstado_Sels;
         AV83Usuarioswwds_12_tfusuariospasw = AV69TFusuariosPasw;
         AV84Usuarioswwds_13_tfusuariospasw_sel = AV70TFusuariosPasw_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV43ManageFiltersExecutionStep, AV71Pgmname, AV17FilterFullText, AV44TFusuariosId, AV45TFusuariosId_Sel, AV47TFusuariosTipo_Sels, AV48TFusuariosNombre, AV49TFusuariosNombre_Sel, AV50TFPaisID, AV51TFPaisID_Sel, AV52TFusuariosTelefono, AV53TFusuariosTelefono_Sel, AV55TFusuariosEstado_Sels, AV69TFusuariosPasw, AV70TFusuariosPasw_Sel, AV68IsAuthorized_Desencriptar) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV72Usuarioswwds_1_filterfulltext = AV17FilterFullText;
         AV73Usuarioswwds_2_tfusuariosid = AV44TFusuariosId;
         AV74Usuarioswwds_3_tfusuariosid_sel = AV45TFusuariosId_Sel;
         AV75Usuarioswwds_4_tfusuariostipo_sels = AV47TFusuariosTipo_Sels;
         AV76Usuarioswwds_5_tfusuariosnombre = AV48TFusuariosNombre;
         AV77Usuarioswwds_6_tfusuariosnombre_sel = AV49TFusuariosNombre_Sel;
         AV78Usuarioswwds_7_tfpaisid = AV50TFPaisID;
         AV79Usuarioswwds_8_tfpaisid_sel = AV51TFPaisID_Sel;
         AV80Usuarioswwds_9_tfusuariostelefono = AV52TFusuariosTelefono;
         AV81Usuarioswwds_10_tfusuariostelefono_sel = AV53TFusuariosTelefono_Sel;
         AV82Usuarioswwds_11_tfusuariosestado_sels = AV55TFusuariosEstado_Sels;
         AV83Usuarioswwds_12_tfusuariospasw = AV69TFusuariosPasw;
         AV84Usuarioswwds_13_tfusuariospasw_sel = AV70TFusuariosPasw_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV43ManageFiltersExecutionStep, AV71Pgmname, AV17FilterFullText, AV44TFusuariosId, AV45TFusuariosId_Sel, AV47TFusuariosTipo_Sels, AV48TFusuariosNombre, AV49TFusuariosNombre_Sel, AV50TFPaisID, AV51TFPaisID_Sel, AV52TFusuariosTelefono, AV53TFusuariosTelefono_Sel, AV55TFusuariosEstado_Sels, AV69TFusuariosPasw, AV70TFusuariosPasw_Sel, AV68IsAuthorized_Desencriptar) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV71Pgmname = "usuariosWW";
         edtusuariosId_Enabled = 0;
         cmbusuariosTipo.Enabled = 0;
         edtusuariosNombre_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtusuariosTelefono_Enabled = 0;
         cmbusuariosEstado.Enabled = 0;
         edtusuariosPasw_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBW0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18BW2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV56DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV58GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV59GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV60GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Desencriptar_modal_Width = cgiGet( "DESENCRIPTAR_MODAL_Width");
            Desencriptar_modal_Title = cgiGet( "DESENCRIPTAR_MODAL_Title");
            Desencriptar_modal_Confirmtype = cgiGet( "DESENCRIPTAR_MODAL_Confirmtype");
            Desencriptar_modal_Bodytype = cgiGet( "DESENCRIPTAR_MODAL_Bodytype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         E18BW2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18BW2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
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
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " usuarios", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV56DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV56DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E19BW2( )
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
         AV58GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV58GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV58GridCurrentPage), 10, 0));
         AV59GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV59GridPageCount", StringUtil.LTrimStr( (decimal)(AV59GridPageCount), 10, 0));
         GXt_char2 = AV60GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV71Pgmname, out  GXt_char2) ;
         AV60GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV60GridAppliedFilters", AV60GridAppliedFilters);
         cmbavGridactions_Columnheaderclass = "WWActionGroupColumn";
         AssignProp("", false, cmbavGridactions_Internalname, "Columnheaderclass", cmbavGridactions_Columnheaderclass, !bGXsfl_37_Refreshing);
         edtusuariosId_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtusuariosId_Internalname, "Columnheaderclass", edtusuariosId_Columnheaderclass, !bGXsfl_37_Refreshing);
         cmbusuariosTipo_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbusuariosTipo_Internalname, "Columnheaderclass", cmbusuariosTipo_Columnheaderclass, !bGXsfl_37_Refreshing);
         edtusuariosNombre_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtusuariosNombre_Internalname, "Columnheaderclass", edtusuariosNombre_Columnheaderclass, !bGXsfl_37_Refreshing);
         edtPaisID_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtPaisID_Internalname, "Columnheaderclass", edtPaisID_Columnheaderclass, !bGXsfl_37_Refreshing);
         edtusuariosTelefono_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtusuariosTelefono_Internalname, "Columnheaderclass", edtusuariosTelefono_Columnheaderclass, !bGXsfl_37_Refreshing);
         cmbusuariosEstado_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbusuariosEstado_Internalname, "Columnheaderclass", cmbusuariosEstado_Columnheaderclass, !bGXsfl_37_Refreshing);
         edtusuariosPasw_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtusuariosPasw_Internalname, "Columnheaderclass", edtusuariosPasw_Columnheaderclass, !bGXsfl_37_Refreshing);
         AV72Usuarioswwds_1_filterfulltext = AV17FilterFullText;
         AV73Usuarioswwds_2_tfusuariosid = AV44TFusuariosId;
         AV74Usuarioswwds_3_tfusuariosid_sel = AV45TFusuariosId_Sel;
         AV75Usuarioswwds_4_tfusuariostipo_sels = AV47TFusuariosTipo_Sels;
         AV76Usuarioswwds_5_tfusuariosnombre = AV48TFusuariosNombre;
         AV77Usuarioswwds_6_tfusuariosnombre_sel = AV49TFusuariosNombre_Sel;
         AV78Usuarioswwds_7_tfpaisid = AV50TFPaisID;
         AV79Usuarioswwds_8_tfpaisid_sel = AV51TFPaisID_Sel;
         AV80Usuarioswwds_9_tfusuariostelefono = AV52TFusuariosTelefono;
         AV81Usuarioswwds_10_tfusuariostelefono_sel = AV53TFusuariosTelefono_Sel;
         AV82Usuarioswwds_11_tfusuariosestado_sels = AV55TFusuariosEstado_Sels;
         AV83Usuarioswwds_12_tfusuariospasw = AV69TFusuariosPasw;
         AV84Usuarioswwds_13_tfusuariospasw_sel = AV70TFusuariosPasw_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12BW2( )
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
            AV57PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV57PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13BW2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14BW2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "usuariosId") == 0 )
            {
               AV44TFusuariosId = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFusuariosId", AV44TFusuariosId);
               AV45TFusuariosId_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFusuariosId_Sel", AV45TFusuariosId_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "usuariosTipo") == 0 )
            {
               AV46TFusuariosTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFusuariosTipo_SelsJson", AV46TFusuariosTipo_SelsJson);
               AV47TFusuariosTipo_Sels.FromJSonString(AV46TFusuariosTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "usuariosNombre") == 0 )
            {
               AV48TFusuariosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFusuariosNombre", AV48TFusuariosNombre);
               AV49TFusuariosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFusuariosNombre_Sel", AV49TFusuariosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PaisID") == 0 )
            {
               AV50TFPaisID = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFPaisID", AV50TFPaisID);
               AV51TFPaisID_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFPaisID_Sel", AV51TFPaisID_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "usuariosTelefono") == 0 )
            {
               AV52TFusuariosTelefono = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV52TFusuariosTelefono", AV52TFusuariosTelefono);
               AV53TFusuariosTelefono_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV53TFusuariosTelefono_Sel", AV53TFusuariosTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "usuariosEstado") == 0 )
            {
               AV54TFusuariosEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV54TFusuariosEstado_SelsJson", AV54TFusuariosEstado_SelsJson);
               AV55TFusuariosEstado_Sels.FromJSonString(AV54TFusuariosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "usuariosPasw") == 0 )
            {
               AV69TFusuariosPasw = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV69TFusuariosPasw", AV69TFusuariosPasw);
               AV70TFusuariosPasw_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV70TFusuariosPasw_Sel", AV70TFusuariosPasw_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55TFusuariosEstado_Sels", AV55TFusuariosEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFusuariosTipo_Sels", AV47TFusuariosTipo_Sels);
      }

      private void E20BW2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV68IsAuthorized_Desencriptar )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Ver Pass", ""), "fas fa-unlock-keyhole", "", "", "", "", "", "", ""), 0);
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "usuariosview.aspx"+UrlEncode(StringUtil.RTrim(A145usuariosId)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtusuariosId_Link = formatLink("usuariosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            if ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 )
            {
               cmbavGridactions_Columnclass = "WWActionGroupColumn WWColumnDanger WWColumnDangerFirstColumn";
               edtusuariosId_Columnclass = "WWColumn WWColumnDanger";
               cmbusuariosTipo_Columnclass = "WWColumn WWColumnDanger";
               edtusuariosNombre_Columnclass = "WWColumn WWColumnDanger";
               edtPaisID_Columnclass = "WWColumn WWColumnDanger";
               edtusuariosTelefono_Columnclass = "WWColumn WWColumnDanger";
               cmbusuariosEstado_Columnclass = "WWColumn WWColumnDanger";
               edtusuariosPasw_Columnclass = "WWColumn WWColumnDanger";
            }
            else if ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 )
            {
               cmbavGridactions_Columnclass = "WWActionGroupColumn WWColumnWarning WWColumnWarningFirstColumn";
               edtusuariosId_Columnclass = "WWColumn WWColumnWarning";
               cmbusuariosTipo_Columnclass = "WWColumn WWColumnWarning";
               edtusuariosNombre_Columnclass = "WWColumn WWColumnWarning";
               edtPaisID_Columnclass = "WWColumn WWColumnWarning";
               edtusuariosTelefono_Columnclass = "WWColumn WWColumnWarning";
               cmbusuariosEstado_Columnclass = "WWColumn WWColumnWarning";
               edtusuariosPasw_Columnclass = "WWColumn WWColumnWarning";
            }
            else
            {
               cmbavGridactions_Columnclass = "WWActionGroupColumn";
               edtusuariosId_Columnclass = "WWColumn";
               cmbusuariosTipo_Columnclass = "WWColumn";
               edtusuariosNombre_Columnclass = "WWColumn";
               edtPaisID_Columnclass = "WWColumn";
               edtusuariosTelefono_Columnclass = "WWColumn";
               cmbusuariosEstado_Columnclass = "WWColumn";
               edtusuariosPasw_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 37;
            }
            sendrow_372( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            context.DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV61GridActions), 4, 0));
      }

      protected void E11BW2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S172 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("usuariosWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV71Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("usuariosWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "usuariosWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV42ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV71Pgmname+"GridState",  AV42ManageFiltersXml) ;
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
               S182 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47TFusuariosTipo_Sels", AV47TFusuariosTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55TFusuariosEstado_Sels", AV55TFusuariosEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E21BW2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV61GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV61GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DESENCRIPTAR' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV61GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV61GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV61GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E16BW2( )
      {
         /* Desencriptar_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "DesencriptarPass")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "desencriptarpass", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "DesencriptarPass";
            WebComp_Wwpaux_wc_Component = "DesencriptarPass";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0060",(string)"",(string)A223usuariosPasw});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E15BW2( )
      {
         /* Desencriptar_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E17BW2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "usuarios.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("usuarios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV68IsAuthorized_Desencriptar;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WebComponent1", out  GXt_boolean3) ;
         AV68IsAuthorized_Desencriptar = GXt_boolean3;
         AssignAttri("", false, "AV68IsAuthorized_Desencriptar", AV68IsAuthorized_Desencriptar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESENCRIPTAR", GetSecureSignedToken( "", AV68IsAuthorized_Desencriptar, context));
         GXt_boolean3 = AV66TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios_Insert", out  GXt_boolean3) ;
         AV66TempBoolean = GXt_boolean3;
         if ( ! ( AV66TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV41ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "usuariosWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV44TFusuariosId = "";
         AssignAttri("", false, "AV44TFusuariosId", AV44TFusuariosId);
         AV45TFusuariosId_Sel = "";
         AssignAttri("", false, "AV45TFusuariosId_Sel", AV45TFusuariosId_Sel);
         AV47TFusuariosTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV48TFusuariosNombre = "";
         AssignAttri("", false, "AV48TFusuariosNombre", AV48TFusuariosNombre);
         AV49TFusuariosNombre_Sel = "";
         AssignAttri("", false, "AV49TFusuariosNombre_Sel", AV49TFusuariosNombre_Sel);
         AV50TFPaisID = "";
         AssignAttri("", false, "AV50TFPaisID", AV50TFPaisID);
         AV51TFPaisID_Sel = "";
         AssignAttri("", false, "AV51TFPaisID_Sel", AV51TFPaisID_Sel);
         AV52TFusuariosTelefono = "";
         AssignAttri("", false, "AV52TFusuariosTelefono", AV52TFusuariosTelefono);
         AV53TFusuariosTelefono_Sel = "";
         AssignAttri("", false, "AV53TFusuariosTelefono_Sel", AV53TFusuariosTelefono_Sel);
         AV55TFusuariosEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV69TFusuariosPasw = "";
         AssignAttri("", false, "AV69TFusuariosPasw", AV69TFusuariosPasw);
         AV70TFusuariosPasw_Sel = "";
         AssignAttri("", false, "AV70TFusuariosPasw_Sel", AV70TFusuariosPasw_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S192( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "usuariosview.aspx"+UrlEncode(StringUtil.RTrim(A145usuariosId)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("usuariosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S202( )
      {
         /* 'DO DESENCRIPTAR' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "DESENCRIPTAR_MODALContainer", "Confirm", "", new Object[] {});
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV71Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV71Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV40Session.Get(AV71Pgmname+"GridState"), null, "", "");
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
         S182 ();
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

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV85GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID") == 0 )
            {
               AV44TFusuariosId = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFusuariosId", AV44TFusuariosId);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID_SEL") == 0 )
            {
               AV45TFusuariosId_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFusuariosId_Sel", AV45TFusuariosId_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIOSTIPO_SEL") == 0 )
            {
               AV46TFusuariosTipo_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFusuariosTipo_SelsJson", AV46TFusuariosTipo_SelsJson);
               AV47TFusuariosTipo_Sels.FromJSonString(AV46TFusuariosTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE") == 0 )
            {
               AV48TFusuariosNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFusuariosNombre", AV48TFusuariosNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE_SEL") == 0 )
            {
               AV49TFusuariosNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFusuariosNombre_Sel", AV49TFusuariosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV50TFPaisID = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFPaisID", AV50TFPaisID);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV51TFPaisID_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFPaisID_Sel", AV51TFPaisID_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIOSTELEFONO") == 0 )
            {
               AV52TFusuariosTelefono = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFusuariosTelefono", AV52TFusuariosTelefono);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIOSTELEFONO_SEL") == 0 )
            {
               AV53TFusuariosTelefono_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFusuariosTelefono_Sel", AV53TFusuariosTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIOSESTADO_SEL") == 0 )
            {
               AV54TFusuariosEstado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFusuariosEstado_SelsJson", AV54TFusuariosEstado_SelsJson);
               AV55TFusuariosEstado_Sels.FromJSonString(AV54TFusuariosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIOSPASW") == 0 )
            {
               AV69TFusuariosPasw = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69TFusuariosPasw", AV69TFusuariosPasw);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFUSUARIOSPASW_SEL") == 0 )
            {
               AV70TFusuariosPasw_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV70TFusuariosPasw_Sel", AV70TFusuariosPasw_Sel);
            }
            AV85GXV1 = (int)(AV85GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFusuariosId_Sel)),  AV45TFusuariosId_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV47TFusuariosTipo_Sels.Count==0),  AV46TFusuariosTipo_SelsJson, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFusuariosNombre_Sel)),  AV49TFusuariosNombre_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFPaisID_Sel)),  AV51TFPaisID_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFusuariosTelefono_Sel)),  AV53TFusuariosTelefono_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV55TFusuariosEstado_Sels.Count==0),  AV54TFusuariosEstado_SelsJson, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV70TFusuariosPasw_Sel)),  AV70TFusuariosPasw_Sel, out  GXt_char10) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFusuariosId)),  AV44TFusuariosId, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFusuariosNombre)),  AV48TFusuariosNombre, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFPaisID)),  AV50TFPaisID, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFusuariosTelefono)),  AV52TFusuariosTelefono, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV69TFusuariosPasw)),  AV69TFusuariosPasw, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = GXt_char10+"||"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"||"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV40Session.Get(AV71Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFUSUARIOSID",  context.GetMessage( "Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFusuariosId)),  0,  AV44TFusuariosId,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFusuariosId_Sel)),  AV45TFusuariosId_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFUSUARIOSTIPO_SEL",  context.GetMessage( "Tipo", ""),  !(AV47TFusuariosTipo_Sels.Count==0),  0,  AV47TFusuariosTipo_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFUSUARIOSNOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFusuariosNombre)),  0,  AV48TFusuariosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFusuariosNombre_Sel)),  AV49TFusuariosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPAISID",  context.GetMessage( "Pais", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFPaisID)),  0,  AV50TFPaisID,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFPaisID_Sel)),  AV51TFPaisID_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFUSUARIOSTELEFONO",  context.GetMessage( "Telefono", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFusuariosTelefono)),  0,  AV52TFusuariosTelefono,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFusuariosTelefono_Sel)),  AV53TFusuariosTelefono_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFUSUARIOSESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV55TFusuariosEstado_Sels.Count==0),  0,  AV55TFusuariosEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFUSUARIOSPASW",  context.GetMessage( "Paswword", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV69TFusuariosPasw)),  0,  AV69TFusuariosPasw,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV70TFusuariosPasw_Sel)),  AV70TFusuariosPasw_Sel,  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV71Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV71Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "usuarios";
         AV40Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table2_53_BW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledesencriptar_modal_Internalname, tblTabledesencriptar_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDesencriptar_modal.SetProperty("Width", Desencriptar_modal_Width);
            ucDesencriptar_modal.SetProperty("Title", Desencriptar_modal_Title);
            ucDesencriptar_modal.SetProperty("ConfirmType", Desencriptar_modal_Confirmtype);
            ucDesencriptar_modal.SetProperty("BodyType", Desencriptar_modal_Bodytype);
            ucDesencriptar_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Desencriptar_modal_Internalname, "DESENCRIPTAR_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DESENCRIPTAR_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_53_BW2e( true) ;
         }
         else
         {
            wb_table2_53_BW2e( false) ;
         }
      }

      protected void wb_table1_19_BW2( bool wbgen )
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
            wb_table3_24_BW2( true) ;
         }
         else
         {
            wb_table3_24_BW2( false) ;
         }
         return  ;
      }

      protected void wb_table3_24_BW2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_19_BW2e( true) ;
         }
         else
         {
            wb_table1_19_BW2e( false) ;
         }
      }

      protected void wb_table3_24_BW2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_usuariosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_24_BW2e( true) ;
         }
         else
         {
            wb_table3_24_BW2e( false) ;
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
         PABW2( ) ;
         WSBW2( ) ;
         WEBW2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320164346", true, true, false);
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
         context.AddJavascriptSource("usuariosww.js", "?20269320164346", false, true, false);
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
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_37_idx;
         edtusuariosId_Internalname = "USUARIOSID_"+sGXsfl_37_idx;
         cmbusuariosTipo_Internalname = "USUARIOSTIPO_"+sGXsfl_37_idx;
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_37_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_37_idx;
         edtusuariosTelefono_Internalname = "USUARIOSTELEFONO_"+sGXsfl_37_idx;
         cmbusuariosEstado_Internalname = "USUARIOSESTADO_"+sGXsfl_37_idx;
         edtusuariosPasw_Internalname = "USUARIOSPASW_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_37_fel_idx;
         edtusuariosId_Internalname = "USUARIOSID_"+sGXsfl_37_fel_idx;
         cmbusuariosTipo_Internalname = "USUARIOSTIPO_"+sGXsfl_37_fel_idx;
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_37_fel_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_37_fel_idx;
         edtusuariosTelefono_Internalname = "USUARIOSTELEFONO_"+sGXsfl_37_fel_idx;
         cmbusuariosEstado_Internalname = "USUARIOSESTADO_"+sGXsfl_37_fel_idx;
         edtusuariosPasw_Internalname = "USUARIOSPASW_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WBBW0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_37_idx + "',37)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_37_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV61GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV61GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV61GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV61GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_37_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)cmbavGridactions_Columnclass,(string)cmbavGridactions_Columnheaderclass,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV61GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosId_Internalname,StringUtil.RTrim( A145usuariosId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtusuariosId_Link,(string)"",(string)"",(string)"",(string)edtusuariosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtusuariosId_Columnclass,(string)edtusuariosId_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"NickName",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbusuariosTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIOSTIPO_" + sGXsfl_37_idx;
               cmbusuariosTipo.Name = GXCCtl;
               cmbusuariosTipo.WebTags = "";
               cmbusuariosTipo.addItem("A", context.GetMessage( "Administrador Sistema", ""), 0);
               cmbusuariosTipo.addItem("P", context.GetMessage( "Proveedor de Servicio", ""), 0);
               cmbusuariosTipo.addItem("G", context.GetMessage( "Administrador de Agencia", ""), 0);
               cmbusuariosTipo.addItem("S", context.GetMessage( "Agente de Servicios", ""), 0);
               cmbusuariosTipo.addItem("C", context.GetMessage( "Cliente", ""), 0);
               cmbusuariosTipo.addItem("R", context.GetMessage( "Usuario Registrado", ""), 0);
               cmbusuariosTipo.addItem("U", context.GetMessage( "Usuario Sin Registrar", ""), 0);
               if ( cmbusuariosTipo.ItemCount > 0 )
               {
                  A225usuariosTipo = cmbusuariosTipo.getValidValue(A225usuariosTipo);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbusuariosTipo,(string)cmbusuariosTipo_Internalname,StringUtil.RTrim( A225usuariosTipo),(short)1,(string)cmbusuariosTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbusuariosTipo_Columnclass,(string)cmbusuariosTipo_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbusuariosTipo.CurrentValue = StringUtil.RTrim( A225usuariosTipo);
            AssignProp("", false, cmbusuariosTipo_Internalname, "Values", (string)(cmbusuariosTipo.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosNombre_Internalname,StringUtil.RTrim( A222usuariosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtusuariosNombre_Columnclass,(string)edtusuariosNombre_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisID_Internalname,StringUtil.RTrim( A116PaisID),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtPaisID_Columnclass,(string)edtPaisID_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A232usuariosTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosTelefono_Internalname,StringUtil.RTrim( A232usuariosTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtusuariosTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtusuariosTelefono_Columnclass,(string)edtusuariosTelefono_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbusuariosEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIOSESTADO_" + sGXsfl_37_idx;
               cmbusuariosEstado.Name = GXCCtl;
               cmbusuariosEstado.WebTags = "";
               cmbusuariosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbusuariosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbusuariosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbusuariosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbusuariosEstado.ItemCount > 0 )
               {
                  A226usuariosEstado = cmbusuariosEstado.getValidValue(A226usuariosEstado);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbusuariosEstado,(string)cmbusuariosEstado_Internalname,StringUtil.RTrim( A226usuariosEstado),(short)1,(string)cmbusuariosEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbusuariosEstado_Columnclass,(string)cmbusuariosEstado_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbusuariosEstado.CurrentValue = StringUtil.RTrim( A226usuariosEstado);
            AssignProp("", false, cmbusuariosEstado_Internalname, "Values", (string)(cmbusuariosEstado.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosPasw_Internalname,StringUtil.RTrim( A223usuariosPasw),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosPasw_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtusuariosPasw_Columnclass,(string)edtusuariosPasw_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Pasword",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesBW2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_37_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV61GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV61GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV61GridActions), 4, 0));
         }
         GXCCtl = "USUARIOSTIPO_" + sGXsfl_37_idx;
         cmbusuariosTipo.Name = GXCCtl;
         cmbusuariosTipo.WebTags = "";
         cmbusuariosTipo.addItem("A", context.GetMessage( "Administrador Sistema", ""), 0);
         cmbusuariosTipo.addItem("P", context.GetMessage( "Proveedor de Servicio", ""), 0);
         cmbusuariosTipo.addItem("G", context.GetMessage( "Administrador de Agencia", ""), 0);
         cmbusuariosTipo.addItem("S", context.GetMessage( "Agente de Servicios", ""), 0);
         cmbusuariosTipo.addItem("C", context.GetMessage( "Cliente", ""), 0);
         cmbusuariosTipo.addItem("R", context.GetMessage( "Usuario Registrado", ""), 0);
         cmbusuariosTipo.addItem("U", context.GetMessage( "Usuario Sin Registrar", ""), 0);
         if ( cmbusuariosTipo.ItemCount > 0 )
         {
            A225usuariosTipo = cmbusuariosTipo.getValidValue(A225usuariosTipo);
         }
         GXCCtl = "USUARIOSESTADO_" + sGXsfl_37_idx;
         cmbusuariosEstado.Name = GXCCtl;
         cmbusuariosEstado.WebTags = "";
         cmbusuariosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbusuariosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbusuariosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbusuariosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbusuariosEstado.ItemCount > 0 )
         {
            A226usuariosEstado = cmbusuariosEstado.getValidValue(A226usuariosEstado);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Pais", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Telefono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Paswword", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavGridactions_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavGridactions_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A145usuariosId)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtusuariosId_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtusuariosId_Columnheaderclass));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtusuariosId_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A225usuariosTipo)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbusuariosTipo_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbusuariosTipo_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A222usuariosNombre)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtusuariosNombre_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtusuariosNombre_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A116PaisID)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtPaisID_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtPaisID_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A232usuariosTelefono)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtusuariosTelefono_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtusuariosTelefono_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A226usuariosEstado)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbusuariosEstado_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbusuariosEstado_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A223usuariosPasw)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtusuariosPasw_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtusuariosPasw_Columnheaderclass));
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
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtusuariosId_Internalname = "USUARIOSID";
         cmbusuariosTipo_Internalname = "USUARIOSTIPO";
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE";
         edtPaisID_Internalname = "PAISID";
         edtusuariosTelefono_Internalname = "USUARIOSTELEFONO";
         cmbusuariosEstado_Internalname = "USUARIOSESTADO";
         edtusuariosPasw_Internalname = "USUARIOSPASW";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Desencriptar_modal_Internalname = "DESENCRIPTAR_MODAL";
         tblTabledesencriptar_modal_Internalname = "TABLEDESENCRIPTAR_MODAL";
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
         edtusuariosPasw_Jsonclick = "";
         edtusuariosPasw_Columnclass = "WWColumn";
         cmbusuariosEstado_Jsonclick = "";
         cmbusuariosEstado_Columnclass = "WWColumn";
         edtusuariosTelefono_Jsonclick = "";
         edtusuariosTelefono_Columnclass = "WWColumn";
         edtPaisID_Jsonclick = "";
         edtPaisID_Columnclass = "WWColumn";
         edtusuariosNombre_Jsonclick = "";
         edtusuariosNombre_Columnclass = "WWColumn";
         cmbusuariosTipo_Jsonclick = "";
         cmbusuariosTipo_Columnclass = "WWColumn";
         edtusuariosId_Jsonclick = "";
         edtusuariosId_Columnclass = "WWColumn";
         edtusuariosId_Link = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions_Columnclass = "WWActionGroupColumn";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtusuariosPasw_Columnheaderclass = "";
         cmbusuariosEstado_Columnheaderclass = "";
         edtusuariosTelefono_Columnheaderclass = "";
         edtPaisID_Columnheaderclass = "";
         edtusuariosNombre_Columnheaderclass = "";
         cmbusuariosTipo_Columnheaderclass = "";
         edtusuariosId_Columnheaderclass = "";
         cmbavGridactions_Columnheaderclass = "";
         edtusuariosPasw_Enabled = 0;
         cmbusuariosEstado.Enabled = 0;
         edtusuariosTelefono_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtusuariosNombre_Enabled = 0;
         cmbusuariosTipo.Enabled = 0;
         edtusuariosId_Enabled = 0;
         subGrid_Sortable = 0;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Desencriptar_modal_Bodytype = "WebComponent";
         Desencriptar_modal_Confirmtype = "";
         Desencriptar_modal_Title = context.GetMessage( "Contraseña", "");
         Desencriptar_modal_Width = "400";
         Ddo_grid_Datalistproc = "usuariosWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|A:Administrador Sistema,P:Proveedor de Servicio,G:Administrador de Agencia,S:Agente de Servicios,C:Cliente,R:Usuario Registrado,U:Usuario Sin Registrar||||HAB:Habilitado,DES:Deshabilitado,PEN:Pendiente|";
         Ddo_grid_Allowmultipleselection = "|T||||T|";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues|Dynamic|Dynamic|Dynamic|FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character||Character|Character|Character||Character";
         Ddo_grid_Includefilter = "T||T|T|T||T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7";
         Ddo_grid_Columnids = "1:usuariosId|2:usuariosTipo|3:usuariosNombre|4:PaisID|5:usuariosTelefono|6:usuariosEstado|7:usuariosPasw";
         Ddo_grid_Gridinternalname = "";
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
         Form.Caption = context.GetMessage( " usuarios", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV45TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV47TFusuariosTipo_Sels',fld:'vTFUSUARIOSTIPO_SELS',pic:''},{av:'AV48TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV51TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV52TFusuariosTelefono',fld:'vTFUSUARIOSTELEFONO',pic:'',type:'char'},{av:'AV53TFusuariosTelefono_Sel',fld:'vTFUSUARIOSTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV69TFusuariosPasw',fld:'vTFUSUARIOSPASW',pic:'',type:'char'},{av:'AV70TFusuariosPasw_Sel',fld:'vTFUSUARIOSPASW_SEL',pic:'',type:'char'},{av:'AV68IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV58GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV59GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'cmbusuariosTipo'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtPaisID_Columnheaderclass',ctrl:'PAISID',prop:'Columnheaderclass'},{av:'edtusuariosTelefono_Columnheaderclass',ctrl:'USUARIOSTELEFONO',prop:'Columnheaderclass'},{av:'cmbusuariosEstado'},{av:'edtusuariosPasw_Columnheaderclass',ctrl:'USUARIOSPASW',prop:'Columnheaderclass'},{av:'AV68IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12BW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV45TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV47TFusuariosTipo_Sels',fld:'vTFUSUARIOSTIPO_SELS',pic:''},{av:'AV48TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV51TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV52TFusuariosTelefono',fld:'vTFUSUARIOSTELEFONO',pic:'',type:'char'},{av:'AV53TFusuariosTelefono_Sel',fld:'vTFUSUARIOSTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV69TFusuariosPasw',fld:'vTFUSUARIOSPASW',pic:'',type:'char'},{av:'AV70TFusuariosPasw_Sel',fld:'vTFUSUARIOSPASW_SEL',pic:'',type:'char'},{av:'AV68IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV58GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV59GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'cmbusuariosTipo'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtPaisID_Columnheaderclass',ctrl:'PAISID',prop:'Columnheaderclass'},{av:'edtusuariosTelefono_Columnheaderclass',ctrl:'USUARIOSTELEFONO',prop:'Columnheaderclass'},{av:'cmbusuariosEstado'},{av:'edtusuariosPasw_Columnheaderclass',ctrl:'USUARIOSPASW',prop:'Columnheaderclass'},{av:'AV68IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13BW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV45TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV47TFusuariosTipo_Sels',fld:'vTFUSUARIOSTIPO_SELS',pic:''},{av:'AV48TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV51TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV52TFusuariosTelefono',fld:'vTFUSUARIOSTELEFONO',pic:'',type:'char'},{av:'AV53TFusuariosTelefono_Sel',fld:'vTFUSUARIOSTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV69TFusuariosPasw',fld:'vTFUSUARIOSPASW',pic:'',type:'char'},{av:'AV70TFusuariosPasw_Sel',fld:'vTFUSUARIOSPASW_SEL',pic:'',type:'char'},{av:'AV68IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E14BW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV45TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV47TFusuariosTipo_Sels',fld:'vTFUSUARIOSTIPO_SELS',pic:''},{av:'AV48TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV51TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV52TFusuariosTelefono',fld:'vTFUSUARIOSTELEFONO',pic:'',type:'char'},{av:'AV53TFusuariosTelefono_Sel',fld:'vTFUSUARIOSTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV69TFusuariosPasw',fld:'vTFUSUARIOSPASW',pic:'',type:'char'},{av:'AV70TFusuariosPasw_Sel',fld:'vTFUSUARIOSPASW_SEL',pic:'',type:'char'},{av:'AV68IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV69TFusuariosPasw',fld:'vTFUSUARIOSPASW',pic:'',type:'char'},{av:'AV70TFusuariosPasw_Sel',fld:'vTFUSUARIOSPASW_SEL',pic:'',type:'char'},{av:'AV54TFusuariosEstado_SelsJson',fld:'vTFUSUARIOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV55TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV52TFusuariosTelefono',fld:'vTFUSUARIOSTELEFONO',pic:'',type:'char'},{av:'AV53TFusuariosTelefono_Sel',fld:'vTFUSUARIOSTELEFONO_SEL',pic:'',type:'char'},{av:'AV50TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV51TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV48TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV46TFusuariosTipo_SelsJson',fld:'vTFUSUARIOSTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV47TFusuariosTipo_Sels',fld:'vTFUSUARIOSTIPO_SELS',pic:''},{av:'AV44TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV45TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E20BW2',iparms:[{av:'AV68IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'A145usuariosId',fld:'USUARIOSID',pic:'',hsh:true,type:'char'},{av:'cmbusuariosEstado'},{av:'A226usuariosEstado',fld:'USUARIOSESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV61GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtusuariosId_Link',ctrl:'USUARIOSID',prop:'Link'},{av:'edtusuariosId_Columnclass',ctrl:'USUARIOSID',prop:'Columnclass'},{av:'cmbusuariosTipo'},{av:'edtusuariosNombre_Columnclass',ctrl:'USUARIOSNOMBRE',prop:'Columnclass'},{av:'edtPaisID_Columnclass',ctrl:'PAISID',prop:'Columnclass'},{av:'edtusuariosTelefono_Columnclass',ctrl:'USUARIOSTELEFONO',prop:'Columnclass'},{av:'cmbusuariosEstado'},{av:'edtusuariosPasw_Columnclass',ctrl:'USUARIOSPASW',prop:'Columnclass'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11BW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV45TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV47TFusuariosTipo_Sels',fld:'vTFUSUARIOSTIPO_SELS',pic:''},{av:'AV48TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV51TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV52TFusuariosTelefono',fld:'vTFUSUARIOSTELEFONO',pic:'',type:'char'},{av:'AV53TFusuariosTelefono_Sel',fld:'vTFUSUARIOSTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV69TFusuariosPasw',fld:'vTFUSUARIOSPASW',pic:'',type:'char'},{av:'AV70TFusuariosPasw_Sel',fld:'vTFUSUARIOSPASW_SEL',pic:'',type:'char'},{av:'AV68IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV46TFusuariosTipo_SelsJson',fld:'vTFUSUARIOSTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV54TFusuariosEstado_SelsJson',fld:'vTFUSUARIOSESTADO_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV45TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV47TFusuariosTipo_Sels',fld:'vTFUSUARIOSTIPO_SELS',pic:''},{av:'AV48TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV51TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV52TFusuariosTelefono',fld:'vTFUSUARIOSTELEFONO',pic:'',type:'char'},{av:'AV53TFusuariosTelefono_Sel',fld:'vTFUSUARIOSTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV69TFusuariosPasw',fld:'vTFUSUARIOSPASW',pic:'',type:'char'},{av:'AV70TFusuariosPasw_Sel',fld:'vTFUSUARIOSPASW_SEL',pic:'',type:'char'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV54TFusuariosEstado_SelsJson',fld:'vTFUSUARIOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV46TFusuariosTipo_SelsJson',fld:'vTFUSUARIOSTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV58GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV59GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'cmbusuariosTipo'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtPaisID_Columnheaderclass',ctrl:'PAISID',prop:'Columnheaderclass'},{av:'edtusuariosTelefono_Columnheaderclass',ctrl:'USUARIOSTELEFONO',prop:'Columnheaderclass'},{av:'cmbusuariosEstado'},{av:'edtusuariosPasw_Columnheaderclass',ctrl:'USUARIOSPASW',prop:'Columnheaderclass'},{av:'AV68IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E21BW2',iparms:[{av:'cmbavGridactions'},{av:'AV61GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A145usuariosId',fld:'USUARIOSID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV61GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("DESENCRIPTAR_MODAL.ONLOADCOMPONENT","{handler:'E16BW2',iparms:[{av:'A223usuariosPasw',fld:'USUARIOSPASW',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("DESENCRIPTAR_MODAL.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("DESENCRIPTAR_MODAL.CLOSE","{handler:'E15BW2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV45TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV47TFusuariosTipo_Sels',fld:'vTFUSUARIOSTIPO_SELS',pic:''},{av:'AV48TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV49TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFPaisID',fld:'vTFPAISID',pic:'',type:'char'},{av:'AV51TFPaisID_Sel',fld:'vTFPAISID_SEL',pic:'',type:'char'},{av:'AV52TFusuariosTelefono',fld:'vTFUSUARIOSTELEFONO',pic:'',type:'char'},{av:'AV53TFusuariosTelefono_Sel',fld:'vTFUSUARIOSTELEFONO_SEL',pic:'',type:'char'},{av:'AV55TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV69TFusuariosPasw',fld:'vTFUSUARIOSPASW',pic:'',type:'char'},{av:'AV70TFusuariosPasw_Sel',fld:'vTFUSUARIOSPASW_SEL',pic:'',type:'char'},{av:'AV68IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DESENCRIPTAR_MODAL.CLOSE",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV58GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV59GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'cmbusuariosTipo'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtPaisID_Columnheaderclass',ctrl:'PAISID',prop:'Columnheaderclass'},{av:'edtusuariosTelefono_Columnheaderclass',ctrl:'USUARIOSTELEFONO',prop:'Columnheaderclass'},{av:'cmbusuariosEstado'},{av:'edtusuariosPasw_Columnheaderclass',ctrl:'USUARIOSPASW',prop:'Columnheaderclass'},{av:'AV68IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E17BW2',iparms:[{av:'A145usuariosId',fld:'USUARIOSID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSTIPO","{handler:'Valid_Usuariostipo',iparms:[]");
         setEventMetadata("VALID_USUARIOSTIPO",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSNOMBRE","{handler:'Valid_Usuariosnombre',iparms:[]");
         setEventMetadata("VALID_USUARIOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[]");
         setEventMetadata("VALID_PAISID",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSTELEFONO","{handler:'Valid_Usuariostelefono',iparms:[]");
         setEventMetadata("VALID_USUARIOSTELEFONO",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSESTADO","{handler:'Valid_Usuariosestado',iparms:[]");
         setEventMetadata("VALID_USUARIOSESTADO",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSPASW","{handler:'Valid_Usuariospasw',iparms:[]");
         setEventMetadata("VALID_USUARIOSPASW",",oparms:[]}");
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
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV71Pgmname = "";
         AV17FilterFullText = "";
         AV44TFusuariosId = "";
         AV45TFusuariosId_Sel = "";
         AV47TFusuariosTipo_Sels = new GxSimpleCollection<string>();
         AV48TFusuariosNombre = "";
         AV49TFusuariosNombre_Sel = "";
         AV50TFPaisID = "";
         AV51TFPaisID_Sel = "";
         AV52TFusuariosTelefono = "";
         AV53TFusuariosTelefono_Sel = "";
         AV55TFusuariosEstado_Sels = new GxSimpleCollection<string>();
         AV69TFusuariosPasw = "";
         AV70TFusuariosPasw_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV60GridAppliedFilters = "";
         AV56DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV46TFusuariosTipo_SelsJson = "";
         AV54TFusuariosEstado_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A145usuariosId = "";
         A225usuariosTipo = "";
         A222usuariosNombre = "";
         A116PaisID = "";
         A232usuariosTelefono = "";
         A226usuariosEstado = "";
         A223usuariosPasw = "";
         AV72Usuarioswwds_1_filterfulltext = "";
         AV73Usuarioswwds_2_tfusuariosid = "";
         AV74Usuarioswwds_3_tfusuariosid_sel = "";
         AV75Usuarioswwds_4_tfusuariostipo_sels = new GxSimpleCollection<string>();
         AV76Usuarioswwds_5_tfusuariosnombre = "";
         AV77Usuarioswwds_6_tfusuariosnombre_sel = "";
         AV78Usuarioswwds_7_tfpaisid = "";
         AV79Usuarioswwds_8_tfpaisid_sel = "";
         AV80Usuarioswwds_9_tfusuariostelefono = "";
         AV81Usuarioswwds_10_tfusuariostelefono_sel = "";
         AV82Usuarioswwds_11_tfusuariosestado_sels = new GxSimpleCollection<string>();
         AV83Usuarioswwds_12_tfusuariospasw = "";
         AV84Usuarioswwds_13_tfusuariospasw_sel = "";
         lV72Usuarioswwds_1_filterfulltext = "";
         lV73Usuarioswwds_2_tfusuariosid = "";
         lV76Usuarioswwds_5_tfusuariosnombre = "";
         lV78Usuarioswwds_7_tfpaisid = "";
         lV80Usuarioswwds_9_tfusuariostelefono = "";
         lV83Usuarioswwds_12_tfusuariospasw = "";
         H00BW2_A223usuariosPasw = new string[] {""} ;
         H00BW2_A226usuariosEstado = new string[] {""} ;
         H00BW2_A232usuariosTelefono = new string[] {""} ;
         H00BW2_A116PaisID = new string[] {""} ;
         H00BW2_A222usuariosNombre = new string[] {""} ;
         H00BW2_A225usuariosTipo = new string[] {""} ;
         H00BW2_A145usuariosId = new string[] {""} ;
         H00BW3_A223usuariosPasw = new string[] {""} ;
         H00BW3_A226usuariosEstado = new string[] {""} ;
         H00BW3_A232usuariosTelefono = new string[] {""} ;
         H00BW3_A116PaisID = new string[] {""} ;
         H00BW3_A222usuariosNombre = new string[] {""} ;
         H00BW3_A225usuariosTipo = new string[] {""} ;
         H00BW3_A145usuariosId = new string[] {""} ;
         AV8HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV42ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char5 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         ucDesencriptar_modal = new GXUserControl();
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuariosww__default(),
            new Object[][] {
                new Object[] {
               H00BW2_A223usuariosPasw, H00BW2_A226usuariosEstado, H00BW2_A232usuariosTelefono, H00BW2_A116PaisID, H00BW2_A222usuariosNombre, H00BW2_A225usuariosTipo, H00BW2_A145usuariosId
               }
               , new Object[] {
               H00BW3_A223usuariosPasw, H00BW3_A226usuariosEstado, H00BW3_A232usuariosTelefono, H00BW3_A116PaisID, H00BW3_A222usuariosNombre, H00BW3_A225usuariosTipo, H00BW3_A145usuariosId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV71Pgmname = "usuariosWW";
         /* GeneXus formulas. */
         AV71Pgmname = "usuariosWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV43ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV61GridActions ;
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
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int subGrid_Islastpage ;
      private int AV75Usuarioswwds_4_tfusuariostipo_sels_Count ;
      private int AV82Usuarioswwds_11_tfusuariosestado_sels_Count ;
      private int edtusuariosId_Enabled ;
      private int edtusuariosNombre_Enabled ;
      private int edtPaisID_Enabled ;
      private int edtusuariosTelefono_Enabled ;
      private int edtusuariosPasw_Enabled ;
      private int AV57PageToGo ;
      private int AV85GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV58GridCurrentPage ;
      private long AV59GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV71Pgmname ;
      private string AV44TFusuariosId ;
      private string AV45TFusuariosId_Sel ;
      private string AV48TFusuariosNombre ;
      private string AV49TFusuariosNombre_Sel ;
      private string AV50TFPaisID ;
      private string AV51TFPaisID_Sel ;
      private string AV52TFusuariosTelefono ;
      private string AV53TFusuariosTelefono_Sel ;
      private string AV69TFusuariosPasw ;
      private string AV70TFusuariosPasw_Sel ;
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
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Desencriptar_modal_Width ;
      private string Desencriptar_modal_Title ;
      private string Desencriptar_modal_Confirmtype ;
      private string Desencriptar_modal_Bodytype ;
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
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string A145usuariosId ;
      private string edtusuariosId_Internalname ;
      private string cmbusuariosTipo_Internalname ;
      private string A225usuariosTipo ;
      private string A222usuariosNombre ;
      private string edtusuariosNombre_Internalname ;
      private string A116PaisID ;
      private string edtPaisID_Internalname ;
      private string A232usuariosTelefono ;
      private string edtusuariosTelefono_Internalname ;
      private string cmbusuariosEstado_Internalname ;
      private string A226usuariosEstado ;
      private string A223usuariosPasw ;
      private string edtusuariosPasw_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string AV73Usuarioswwds_2_tfusuariosid ;
      private string AV74Usuarioswwds_3_tfusuariosid_sel ;
      private string AV76Usuarioswwds_5_tfusuariosnombre ;
      private string AV77Usuarioswwds_6_tfusuariosnombre_sel ;
      private string AV78Usuarioswwds_7_tfpaisid ;
      private string AV79Usuarioswwds_8_tfpaisid_sel ;
      private string AV80Usuarioswwds_9_tfusuariostelefono ;
      private string AV81Usuarioswwds_10_tfusuariostelefono_sel ;
      private string AV83Usuarioswwds_12_tfusuariospasw ;
      private string AV84Usuarioswwds_13_tfusuariospasw_sel ;
      private string lV73Usuarioswwds_2_tfusuariosid ;
      private string lV76Usuarioswwds_5_tfusuariosnombre ;
      private string lV78Usuarioswwds_7_tfpaisid ;
      private string lV80Usuarioswwds_9_tfusuariostelefono ;
      private string lV83Usuarioswwds_12_tfusuariospasw ;
      private string cmbavGridactions_Columnheaderclass ;
      private string edtusuariosId_Columnheaderclass ;
      private string cmbusuariosTipo_Columnheaderclass ;
      private string edtusuariosNombre_Columnheaderclass ;
      private string edtPaisID_Columnheaderclass ;
      private string edtusuariosTelefono_Columnheaderclass ;
      private string cmbusuariosEstado_Columnheaderclass ;
      private string edtusuariosPasw_Columnheaderclass ;
      private string edtusuariosId_Link ;
      private string GXEncryptionTmp ;
      private string cmbavGridactions_Columnclass ;
      private string edtusuariosId_Columnclass ;
      private string cmbusuariosTipo_Columnclass ;
      private string edtusuariosNombre_Columnclass ;
      private string edtPaisID_Columnclass ;
      private string edtusuariosTelefono_Columnclass ;
      private string cmbusuariosEstado_Columnclass ;
      private string edtusuariosPasw_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char5 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string tblTabledesencriptar_modal_Internalname ;
      private string Desencriptar_modal_Internalname ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtusuariosId_Jsonclick ;
      private string cmbusuariosTipo_Jsonclick ;
      private string edtusuariosNombre_Jsonclick ;
      private string edtPaisID_Jsonclick ;
      private string gxphoneLink ;
      private string edtusuariosTelefono_Jsonclick ;
      private string cmbusuariosEstado_Jsonclick ;
      private string edtusuariosPasw_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV68IsAuthorized_Desencriptar ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV66TempBoolean ;
      private bool GXt_boolean3 ;
      private string AV46TFusuariosTipo_SelsJson ;
      private string AV54TFusuariosEstado_SelsJson ;
      private string AV42ManageFiltersXml ;
      private string AV17FilterFullText ;
      private string AV60GridAppliedFilters ;
      private string AV72Usuarioswwds_1_filterfulltext ;
      private string lV72Usuarioswwds_1_filterfulltext ;
      private IGxSession AV40Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDesencriptar_modal ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbusuariosTipo ;
      private GXCombobox cmbusuariosEstado ;
      private GxSimpleCollection<string> AV47TFusuariosTipo_Sels ;
      private GxSimpleCollection<string> AV55TFusuariosEstado_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV41ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV56DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GxSimpleCollection<string> AV75Usuarioswwds_4_tfusuariostipo_sels ;
      private GxSimpleCollection<string> AV82Usuarioswwds_11_tfusuariosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H00BW2_A223usuariosPasw ;
      private string[] H00BW2_A226usuariosEstado ;
      private string[] H00BW2_A232usuariosTelefono ;
      private string[] H00BW2_A116PaisID ;
      private string[] H00BW2_A222usuariosNombre ;
      private string[] H00BW2_A225usuariosTipo ;
      private string[] H00BW2_A145usuariosId ;
      private string[] H00BW3_A223usuariosPasw ;
      private string[] H00BW3_A226usuariosEstado ;
      private string[] H00BW3_A232usuariosTelefono ;
      private string[] H00BW3_A116PaisID ;
      private string[] H00BW3_A222usuariosNombre ;
      private string[] H00BW3_A225usuariosTipo ;
      private string[] H00BW3_A145usuariosId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class usuariosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00BW2( IGxContext context ,
                                             string A225usuariosTipo ,
                                             GxSimpleCollection<string> AV75Usuarioswwds_4_tfusuariostipo_sels ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV82Usuarioswwds_11_tfusuariosestado_sels ,
                                             string AV74Usuarioswwds_3_tfusuariosid_sel ,
                                             string AV73Usuarioswwds_2_tfusuariosid ,
                                             int AV75Usuarioswwds_4_tfusuariostipo_sels_Count ,
                                             string AV77Usuarioswwds_6_tfusuariosnombre_sel ,
                                             string AV76Usuarioswwds_5_tfusuariosnombre ,
                                             string AV79Usuarioswwds_8_tfpaisid_sel ,
                                             string AV78Usuarioswwds_7_tfpaisid ,
                                             string AV81Usuarioswwds_10_tfusuariostelefono_sel ,
                                             string AV80Usuarioswwds_9_tfusuariostelefono ,
                                             int AV82Usuarioswwds_11_tfusuariosestado_sels_Count ,
                                             string AV84Usuarioswwds_13_tfusuariospasw_sel ,
                                             string AV83Usuarioswwds_12_tfusuariospasw ,
                                             string A145usuariosId ,
                                             string A222usuariosNombre ,
                                             string A116PaisID ,
                                             string A232usuariosTelefono ,
                                             string A223usuariosPasw ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV72Usuarioswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[10];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT [usuariosPasw], [usuariosEstado], [usuariosTelefono], [PaisID], [usuariosNombre], [usuariosTipo], [usuariosId] FROM [usuarios]";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Usuarioswwds_3_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_2_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosId]) like UPPER(@lV73Usuarioswwds_2_tfusuariosid))");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Usuarioswwds_3_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV74Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosId] = @AV74Usuarioswwds_3_tfusuariosid_sel)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( StringUtil.StrCmp(AV74Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosId] = ''))");
         }
         if ( AV75Usuarioswwds_4_tfusuariostipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Usuarioswwds_4_tfusuariostipo_sels, "[usuariosTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Usuarioswwds_6_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_5_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosNombre]) like UPPER(@lV76Usuarioswwds_5_tfusuariosnombre))");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Usuarioswwds_6_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV77Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosNombre] = @AV77Usuarioswwds_6_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( StringUtil.StrCmp(AV77Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Usuarioswwds_8_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Usuarioswwds_7_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV78Usuarioswwds_7_tfpaisid))");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Usuarioswwds_8_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV79Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV79Usuarioswwds_8_tfpaisid_sel)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( StringUtil.StrCmp(AV79Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Usuarioswwds_10_tfusuariostelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Usuarioswwds_9_tfusuariostelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosTelefono]) like UPPER(@lV80Usuarioswwds_9_tfusuariostelefono))");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Usuarioswwds_10_tfusuariostelefono_sel)) && ! ( StringUtil.StrCmp(AV81Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosTelefono] = @AV81Usuarioswwds_10_tfusuariostelefono_sel)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( StringUtil.StrCmp(AV81Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosTelefono] = ''))");
         }
         if ( AV82Usuarioswwds_11_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Usuarioswwds_11_tfusuariosestado_sels, "[usuariosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Usuarioswwds_13_tfusuariospasw_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Usuarioswwds_12_tfusuariospasw)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosPasw]) like UPPER(@lV83Usuarioswwds_12_tfusuariospasw))");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Usuarioswwds_13_tfusuariospasw_sel)) && ! ( StringUtil.StrCmp(AV84Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosPasw] = @AV84Usuarioswwds_13_tfusuariospasw_sel)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( StringUtil.StrCmp(AV84Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosPasw] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosTipo]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaisID]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaisID] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosTelefono]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosEstado]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosPasw]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosPasw] DESC";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_H00BW3( IGxContext context ,
                                             string A225usuariosTipo ,
                                             GxSimpleCollection<string> AV75Usuarioswwds_4_tfusuariostipo_sels ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV82Usuarioswwds_11_tfusuariosestado_sels ,
                                             string AV74Usuarioswwds_3_tfusuariosid_sel ,
                                             string AV73Usuarioswwds_2_tfusuariosid ,
                                             int AV75Usuarioswwds_4_tfusuariostipo_sels_Count ,
                                             string AV77Usuarioswwds_6_tfusuariosnombre_sel ,
                                             string AV76Usuarioswwds_5_tfusuariosnombre ,
                                             string AV79Usuarioswwds_8_tfpaisid_sel ,
                                             string AV78Usuarioswwds_7_tfpaisid ,
                                             string AV81Usuarioswwds_10_tfusuariostelefono_sel ,
                                             string AV80Usuarioswwds_9_tfusuariostelefono ,
                                             int AV82Usuarioswwds_11_tfusuariosestado_sels_Count ,
                                             string AV84Usuarioswwds_13_tfusuariospasw_sel ,
                                             string AV83Usuarioswwds_12_tfusuariospasw ,
                                             string A145usuariosId ,
                                             string A222usuariosNombre ,
                                             string A116PaisID ,
                                             string A232usuariosTelefono ,
                                             string A223usuariosPasw ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV72Usuarioswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[10];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT [usuariosPasw], [usuariosEstado], [usuariosTelefono], [PaisID], [usuariosNombre], [usuariosTipo], [usuariosId] FROM [usuarios]";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Usuarioswwds_3_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_2_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosId]) like UPPER(@lV73Usuarioswwds_2_tfusuariosid))");
         }
         else
         {
            GXv_int13[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Usuarioswwds_3_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV74Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosId] = @AV74Usuarioswwds_3_tfusuariosid_sel)");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         if ( StringUtil.StrCmp(AV74Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosId] = ''))");
         }
         if ( AV75Usuarioswwds_4_tfusuariostipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Usuarioswwds_4_tfusuariostipo_sels, "[usuariosTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Usuarioswwds_6_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_5_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosNombre]) like UPPER(@lV76Usuarioswwds_5_tfusuariosnombre))");
         }
         else
         {
            GXv_int13[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Usuarioswwds_6_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV77Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosNombre] = @AV77Usuarioswwds_6_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         if ( StringUtil.StrCmp(AV77Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Usuarioswwds_8_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Usuarioswwds_7_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV78Usuarioswwds_7_tfpaisid))");
         }
         else
         {
            GXv_int13[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Usuarioswwds_8_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV79Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV79Usuarioswwds_8_tfpaisid_sel)");
         }
         else
         {
            GXv_int13[5] = 1;
         }
         if ( StringUtil.StrCmp(AV79Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Usuarioswwds_10_tfusuariostelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Usuarioswwds_9_tfusuariostelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosTelefono]) like UPPER(@lV80Usuarioswwds_9_tfusuariostelefono))");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Usuarioswwds_10_tfusuariostelefono_sel)) && ! ( StringUtil.StrCmp(AV81Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosTelefono] = @AV81Usuarioswwds_10_tfusuariostelefono_sel)");
         }
         else
         {
            GXv_int13[7] = 1;
         }
         if ( StringUtil.StrCmp(AV81Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosTelefono] = ''))");
         }
         if ( AV82Usuarioswwds_11_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Usuarioswwds_11_tfusuariosestado_sels, "[usuariosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Usuarioswwds_13_tfusuariospasw_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Usuarioswwds_12_tfusuariospasw)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosPasw]) like UPPER(@lV83Usuarioswwds_12_tfusuariospasw))");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Usuarioswwds_13_tfusuariospasw_sel)) && ! ( StringUtil.StrCmp(AV84Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosPasw] = @AV84Usuarioswwds_13_tfusuariospasw_sel)");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( StringUtil.StrCmp(AV84Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosPasw] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosTipo]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaisID]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaisID] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosTelefono]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosEstado]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [usuariosPasw]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [usuariosPasw] DESC";
         }
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00BW2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] );
               case 1 :
                     return conditional_H00BW3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] );
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
          Object[] prmH00BW2;
          prmH00BW2 = new Object[] {
          new ParDef("@lV73Usuarioswwds_2_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV74Usuarioswwds_3_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV76Usuarioswwds_5_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV77Usuarioswwds_6_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV78Usuarioswwds_7_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV79Usuarioswwds_8_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV80Usuarioswwds_9_tfusuariostelefono",GXType.Char,20,0) ,
          new ParDef("@AV81Usuarioswwds_10_tfusuariostelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV83Usuarioswwds_12_tfusuariospasw",GXType.Char,80,0) ,
          new ParDef("@AV84Usuarioswwds_13_tfusuariospasw_sel",GXType.NChar,80,0)
          };
          Object[] prmH00BW3;
          prmH00BW3 = new Object[] {
          new ParDef("@lV73Usuarioswwds_2_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV74Usuarioswwds_3_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV76Usuarioswwds_5_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV77Usuarioswwds_6_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV78Usuarioswwds_7_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV79Usuarioswwds_8_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV80Usuarioswwds_9_tfusuariostelefono",GXType.Char,20,0) ,
          new ParDef("@AV81Usuarioswwds_10_tfusuariostelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV83Usuarioswwds_12_tfusuariospasw",GXType.Char,80,0) ,
          new ParDef("@AV84Usuarioswwds_13_tfusuariospasw_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BW2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BW2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BW3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BW3,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 2);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 2);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                return;
       }
    }

 }

}
