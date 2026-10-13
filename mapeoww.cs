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
   public class mapeoww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public mapeoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mapeoww( IGxContext context )
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV65DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV66DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV67STComerciosNombre1 = GetPar( "STComerciosNombre1");
         AV68ProveedorNombre1 = GetPar( "ProveedorNombre1");
         AV69ConexionesNombre1 = GetPar( "ConexionesNombre1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV71DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV72DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV73STComerciosNombre2 = GetPar( "STComerciosNombre2");
         AV74ProveedorNombre2 = GetPar( "ProveedorNombre2");
         AV75ConexionesNombre2 = GetPar( "ConexionesNombre2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV77DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV78DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV79STComerciosNombre3 = GetPar( "STComerciosNombre3");
         AV80ProveedorNombre3 = GetPar( "ProveedorNombre3");
         AV81ConexionesNombre3 = GetPar( "ConexionesNombre3");
         AV26ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV70DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV76DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21ColumnsSelector);
         AV84Pgmname = GetPar( "Pgmname");
         AV16FilterFullText = GetPar( "FilterFullText");
         AV27TFMapeoID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMapeoID"), "."), 18, MidpointRounding.ToEven));
         AV28TFMapeoID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFMapeoID_To"), "."), 18, MidpointRounding.ToEven));
         AV29TFProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProveedorID"), "."), 18, MidpointRounding.ToEven));
         AV30TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProveedorID_To"), "."), 18, MidpointRounding.ToEven));
         AV31TFProveedorNombre = GetPar( "TFProveedorNombre");
         AV32TFProveedorNombre_Sel = GetPar( "TFProveedorNombre_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV34TFProveedorEstado_Sels);
         AV35TFSTComerciosID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFSTComerciosID"), "."), 18, MidpointRounding.ToEven));
         AV36TFSTComerciosID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFSTComerciosID_To"), "."), 18, MidpointRounding.ToEven));
         AV37TFSTComerciosNombre = GetPar( "TFSTComerciosNombre");
         AV38TFSTComerciosNombre_Sel = GetPar( "TFSTComerciosNombre_Sel");
         AV41TFConexionesID = GetPar( "TFConexionesID");
         AV42TFConexionesID_Sel = GetPar( "TFConexionesID_Sel");
         AV43TFConexionesNombre = GetPar( "TFConexionesNombre");
         AV44TFConexionesNombre_Sel = GetPar( "TFConexionesNombre_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV83DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV82DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV54IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV55IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV56IsAuthorized_ProveedorNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_ProveedorNombre"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV65DynamicFiltersSelector1, AV66DynamicFiltersOperator1, AV67STComerciosNombre1, AV68ProveedorNombre1, AV69ConexionesNombre1, AV71DynamicFiltersSelector2, AV72DynamicFiltersOperator2, AV73STComerciosNombre2, AV74ProveedorNombre2, AV75ConexionesNombre2, AV77DynamicFiltersSelector3, AV78DynamicFiltersOperator3, AV79STComerciosNombre3, AV80ProveedorNombre3, AV81ConexionesNombre3, AV26ManageFiltersExecutionStep, AV70DynamicFiltersEnabled2, AV76DynamicFiltersEnabled3, AV21ColumnsSelector, AV84Pgmname, AV16FilterFullText, AV27TFMapeoID, AV28TFMapeoID_To, AV29TFProveedorID, AV30TFProveedorID_To, AV31TFProveedorNombre, AV32TFProveedorNombre_Sel, AV34TFProveedorEstado_Sels, AV35TFSTComerciosID, AV36TFSTComerciosID_To, AV37TFSTComerciosNombre, AV38TFSTComerciosNombre_Sel, AV41TFConexionesID, AV42TFConexionesID_Sel, AV43TFConexionesNombre, AV44TFConexionesNombre_Sel, AV11GridState, AV83DynamicFiltersIgnoreFirst, AV82DynamicFiltersRemoving, AV54IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ProveedorNombre) ;
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
         PAJF2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTJF2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("mapeoww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV84Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV84Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV54IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV54IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV55IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV55IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROVEEDORNOMBRE", AV56IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( "", AV56IsAuthorized_ProveedorNombre, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV65DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66DynamicFiltersOperator1), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSTCOMERCIOSNOMBRE1", StringUtil.RTrim( AV67STComerciosNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vPROVEEDORNOMBRE1", StringUtil.RTrim( AV68ProveedorNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vCONEXIONESNOMBRE1", StringUtil.RTrim( AV69ConexionesNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV71DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV72DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSTCOMERCIOSNOMBRE2", StringUtil.RTrim( AV73STComerciosNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vPROVEEDORNOMBRE2", StringUtil.RTrim( AV74ProveedorNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vCONEXIONESNOMBRE2", StringUtil.RTrim( AV75ConexionesNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV77DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV78DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSTCOMERCIOSNOMBRE3", StringUtil.RTrim( AV79STComerciosNombre3));
         GxWebStd.gx_hidden_field( context, "GXH_vPROVEEDORNOMBRE3", StringUtil.RTrim( AV80ProveedorNombre3));
         GxWebStd.gx_hidden_field( context, "GXH_vCONEXIONESNOMBRE3", StringUtil.RTrim( AV81ConexionesNombre3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_129", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_129), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV51GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV61AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV61AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV70DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV76DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV84Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV84Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFMAPEOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27TFMapeoID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFMAPEOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28TFMapeoID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29TFProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TFProveedorID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORNOMBRE", StringUtil.RTrim( AV31TFProveedorNombre));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORNOMBRE_SEL", StringUtil.RTrim( AV32TFProveedorNombre_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPROVEEDORESTADO_SELS", AV34TFProveedorEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPROVEEDORESTADO_SELS", AV34TFProveedorEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFSTCOMERCIOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35TFSTComerciosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSTCOMERCIOSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36TFSTComerciosID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSTCOMERCIOSNOMBRE", StringUtil.RTrim( AV37TFSTComerciosNombre));
         GxWebStd.gx_hidden_field( context, "vTFSTCOMERCIOSNOMBRE_SEL", StringUtil.RTrim( AV38TFSTComerciosNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCONEXIONESID", StringUtil.RTrim( AV41TFConexionesID));
         GxWebStd.gx_hidden_field( context, "vTFCONEXIONESID_SEL", StringUtil.RTrim( AV42TFConexionesID_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCONEXIONESNOMBRE", StringUtil.RTrim( AV43TFConexionesNombre));
         GxWebStd.gx_hidden_field( context, "vTFCONEXIONESNOMBRE_SEL", StringUtil.RTrim( AV44TFConexionesNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV83DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV82DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV54IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV54IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV55IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV55IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROVEEDORNOMBRE", AV56IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( "", AV56IsAuthorized_ProveedorNombre, context));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORESTADO_SELSJSON", AV33TFProveedorEstado_SelsJson);
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
            WEJF2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTJF2( ) ;
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
         return formatLink("mapeoww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "MapeoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Mapeo", "") ;
      }

      protected void WBJF0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_JF2( true) ;
         }
         else
         {
            wb_table1_25_JF2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_JF2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV65DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_MapeoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV65DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_JF2( true) ;
         }
         else
         {
            wb_table2_49_JF2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_JF2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV71DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_MapeoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV71DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_77_JF2( true) ;
         }
         else
         {
            wb_table3_77_JF2( false) ;
         }
         return  ;
      }

      protected void wb_table3_77_JF2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV77DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 0, "HLP_MapeoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV77DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_105_JF2( true) ;
         }
         else
         {
            wb_table4_105_JF2( false) ;
         }
         return  ;
      }

      protected void wb_table4_105_JF2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV49GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV50GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV51GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV61AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_MapeoWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
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
               GxWebStd.gx_hidden_field( context, "W0153"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0153"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_129_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0153"+"");
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

      protected void STARTJF2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Mapeo", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPJF0( ) ;
      }

      protected void WSJF2( )
      {
         STARTJF2( ) ;
         EVTJF2( ) ;
      }

      protected void EVTJF2( )
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
                              E11JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E14JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E15JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E16JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E17JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E18JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E19JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E20JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E21JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E22JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E24JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E25JF2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E26JF2 ();
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
                              AV52GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
                              A918MapeoID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMapeoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
                              cmbProveedorEstado.Name = cmbProveedorEstado_Internalname;
                              cmbProveedorEstado.CurrentValue = cgiGet( cmbProveedorEstado_Internalname);
                              A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
                              A919STComerciosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSTComerciosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n919STComerciosID = false;
                              A923STComerciosNombre = cgiGet( edtSTComerciosNombre_Internalname);
                              A552ConexionesID = cgiGet( edtConexionesID_Internalname);
                              n552ConexionesID = false;
                              A556ConexionesNombre = cgiGet( edtConexionesNombre_Internalname);
                              n556ConexionesNombre = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E27JF2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E28JF2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E29JF2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E30JF2 ();
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
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV65DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV66DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Stcomerciosnombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSTCOMERCIOSNOMBRE1"), AV67STComerciosNombre1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Proveedornombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE1"), AV68ProveedorNombre1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conexionesnombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONEXIONESNOMBRE1"), AV69ConexionesNombre1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV71DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV72DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Stcomerciosnombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSTCOMERCIOSNOMBRE2"), AV73STComerciosNombre2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Proveedornombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE2"), AV74ProveedorNombre2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conexionesnombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONEXIONESNOMBRE2"), AV75ConexionesNombre2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV77DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV78DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Stcomerciosnombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSTCOMERCIOSNOMBRE3"), AV79STComerciosNombre3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Proveedornombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE3"), AV80ProveedorNombre3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Conexionesnombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCONEXIONESNOMBRE3"), AV81ConexionesNombre3) != 0 )
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
                        if ( nCmpId == 153 )
                        {
                           OldWwpaux_wc = cgiGet( "W0153");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0153", "", sEvt);
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

      protected void WEJF2( )
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

      protected void PAJF2( )
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
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV65DynamicFiltersSelector1 ,
                                       short AV66DynamicFiltersOperator1 ,
                                       string AV67STComerciosNombre1 ,
                                       string AV68ProveedorNombre1 ,
                                       string AV69ConexionesNombre1 ,
                                       string AV71DynamicFiltersSelector2 ,
                                       short AV72DynamicFiltersOperator2 ,
                                       string AV73STComerciosNombre2 ,
                                       string AV74ProveedorNombre2 ,
                                       string AV75ConexionesNombre2 ,
                                       string AV77DynamicFiltersSelector3 ,
                                       short AV78DynamicFiltersOperator3 ,
                                       string AV79STComerciosNombre3 ,
                                       string AV80ProveedorNombre3 ,
                                       string AV81ConexionesNombre3 ,
                                       short AV26ManageFiltersExecutionStep ,
                                       bool AV70DynamicFiltersEnabled2 ,
                                       bool AV76DynamicFiltersEnabled3 ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ,
                                       string AV84Pgmname ,
                                       string AV16FilterFullText ,
                                       long AV27TFMapeoID ,
                                       long AV28TFMapeoID_To ,
                                       long AV29TFProveedorID ,
                                       long AV30TFProveedorID_To ,
                                       string AV31TFProveedorNombre ,
                                       string AV32TFProveedorNombre_Sel ,
                                       GxSimpleCollection<string> AV34TFProveedorEstado_Sels ,
                                       long AV35TFSTComerciosID ,
                                       long AV36TFSTComerciosID_To ,
                                       string AV37TFSTComerciosNombre ,
                                       string AV38TFSTComerciosNombre_Sel ,
                                       string AV41TFConexionesID ,
                                       string AV42TFConexionesID_Sel ,
                                       string AV43TFConexionesNombre ,
                                       string AV44TFConexionesNombre_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV83DynamicFiltersIgnoreFirst ,
                                       bool AV82DynamicFiltersRemoving ,
                                       bool AV54IsAuthorized_Update ,
                                       bool AV55IsAuthorized_Delete ,
                                       bool AV56IsAuthorized_ProveedorNombre )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFJF2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MAPEOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A918MapeoID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MAPEOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A918MapeoID), 18, 0, ".", "")));
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
            AV65DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV65DynamicFiltersSelector1);
            AssignAttri("", false, "AV65DynamicFiltersSelector1", AV65DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV65DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV66DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV66DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV71DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV71DynamicFiltersSelector2);
            AssignAttri("", false, "AV71DynamicFiltersSelector2", AV71DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV71DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV72DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV72DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV77DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV77DynamicFiltersSelector3);
            AssignAttri("", false, "AV77DynamicFiltersSelector3", AV77DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV77DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV78DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV78DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFJF2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV84Pgmname = "MapeoWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV85Mapeowwds_1_filterfulltext = AV16FilterFullText;
         AV86Mapeowwds_2_dynamicfiltersselector1 = AV65DynamicFiltersSelector1;
         AV87Mapeowwds_3_dynamicfiltersoperator1 = AV66DynamicFiltersOperator1;
         AV88Mapeowwds_4_stcomerciosnombre1 = AV67STComerciosNombre1;
         AV89Mapeowwds_5_proveedornombre1 = AV68ProveedorNombre1;
         AV90Mapeowwds_6_conexionesnombre1 = AV69ConexionesNombre1;
         AV91Mapeowwds_7_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV92Mapeowwds_8_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV93Mapeowwds_9_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV94Mapeowwds_10_stcomerciosnombre2 = AV73STComerciosNombre2;
         AV95Mapeowwds_11_proveedornombre2 = AV74ProveedorNombre2;
         AV96Mapeowwds_12_conexionesnombre2 = AV75ConexionesNombre2;
         AV97Mapeowwds_13_dynamicfiltersenabled3 = AV76DynamicFiltersEnabled3;
         AV98Mapeowwds_14_dynamicfiltersselector3 = AV77DynamicFiltersSelector3;
         AV99Mapeowwds_15_dynamicfiltersoperator3 = AV78DynamicFiltersOperator3;
         AV100Mapeowwds_16_stcomerciosnombre3 = AV79STComerciosNombre3;
         AV101Mapeowwds_17_proveedornombre3 = AV80ProveedorNombre3;
         AV102Mapeowwds_18_conexionesnombre3 = AV81ConexionesNombre3;
         AV103Mapeowwds_19_tfmapeoid = AV27TFMapeoID;
         AV104Mapeowwds_20_tfmapeoid_to = AV28TFMapeoID_To;
         AV105Mapeowwds_21_tfproveedorid = AV29TFProveedorID;
         AV106Mapeowwds_22_tfproveedorid_to = AV30TFProveedorID_To;
         AV107Mapeowwds_23_tfproveedornombre = AV31TFProveedorNombre;
         AV108Mapeowwds_24_tfproveedornombre_sel = AV32TFProveedorNombre_Sel;
         AV109Mapeowwds_25_tfproveedorestado_sels = AV34TFProveedorEstado_Sels;
         AV110Mapeowwds_26_tfstcomerciosid = AV35TFSTComerciosID;
         AV111Mapeowwds_27_tfstcomerciosid_to = AV36TFSTComerciosID_To;
         AV112Mapeowwds_28_tfstcomerciosnombre = AV37TFSTComerciosNombre;
         AV113Mapeowwds_29_tfstcomerciosnombre_sel = AV38TFSTComerciosNombre_Sel;
         AV114Mapeowwds_30_tfconexionesid = AV41TFConexionesID;
         AV115Mapeowwds_31_tfconexionesid_sel = AV42TFConexionesID_Sel;
         AV116Mapeowwds_32_tfconexionesnombre = AV43TFConexionesNombre;
         AV117Mapeowwds_33_tfconexionesnombre_sel = AV44TFConexionesNombre_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV109Mapeowwds_25_tfproveedorestado_sels ,
                                              AV86Mapeowwds_2_dynamicfiltersselector1 ,
                                              AV87Mapeowwds_3_dynamicfiltersoperator1 ,
                                              AV88Mapeowwds_4_stcomerciosnombre1 ,
                                              AV89Mapeowwds_5_proveedornombre1 ,
                                              AV90Mapeowwds_6_conexionesnombre1 ,
                                              AV91Mapeowwds_7_dynamicfiltersenabled2 ,
                                              AV92Mapeowwds_8_dynamicfiltersselector2 ,
                                              AV93Mapeowwds_9_dynamicfiltersoperator2 ,
                                              AV94Mapeowwds_10_stcomerciosnombre2 ,
                                              AV95Mapeowwds_11_proveedornombre2 ,
                                              AV96Mapeowwds_12_conexionesnombre2 ,
                                              AV97Mapeowwds_13_dynamicfiltersenabled3 ,
                                              AV98Mapeowwds_14_dynamicfiltersselector3 ,
                                              AV99Mapeowwds_15_dynamicfiltersoperator3 ,
                                              AV100Mapeowwds_16_stcomerciosnombre3 ,
                                              AV101Mapeowwds_17_proveedornombre3 ,
                                              AV102Mapeowwds_18_conexionesnombre3 ,
                                              AV103Mapeowwds_19_tfmapeoid ,
                                              AV104Mapeowwds_20_tfmapeoid_to ,
                                              AV105Mapeowwds_21_tfproveedorid ,
                                              AV106Mapeowwds_22_tfproveedorid_to ,
                                              AV108Mapeowwds_24_tfproveedornombre_sel ,
                                              AV107Mapeowwds_23_tfproveedornombre ,
                                              AV109Mapeowwds_25_tfproveedorestado_sels.Count ,
                                              AV110Mapeowwds_26_tfstcomerciosid ,
                                              AV111Mapeowwds_27_tfstcomerciosid_to ,
                                              AV113Mapeowwds_29_tfstcomerciosnombre_sel ,
                                              AV112Mapeowwds_28_tfstcomerciosnombre ,
                                              AV115Mapeowwds_31_tfconexionesid_sel ,
                                              AV114Mapeowwds_30_tfconexionesid ,
                                              AV117Mapeowwds_33_tfconexionesnombre_sel ,
                                              AV116Mapeowwds_32_tfconexionesnombre ,
                                              A923STComerciosNombre ,
                                              A282ProveedorNombre ,
                                              A556ConexionesNombre ,
                                              A918MapeoID ,
                                              A133ProveedorID ,
                                              A919STComerciosID ,
                                              A552ConexionesID ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV85Mapeowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV88Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV88Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV89Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_5_proveedornombre1), 80, "%");
         lV89Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_5_proveedornombre1), 80, "%");
         lV90Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_6_conexionesnombre1), 80, "%");
         lV90Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_6_conexionesnombre1), 80, "%");
         lV94Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV94Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV94Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV94Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV95Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV95Mapeowwds_11_proveedornombre2), 80, "%");
         lV95Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV95Mapeowwds_11_proveedornombre2), 80, "%");
         lV96Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV96Mapeowwds_12_conexionesnombre2), 80, "%");
         lV96Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV96Mapeowwds_12_conexionesnombre2), 80, "%");
         lV100Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV100Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV100Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV100Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV101Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV101Mapeowwds_17_proveedornombre3), 80, "%");
         lV101Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV101Mapeowwds_17_proveedornombre3), 80, "%");
         lV102Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV102Mapeowwds_18_conexionesnombre3), 80, "%");
         lV102Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV102Mapeowwds_18_conexionesnombre3), 80, "%");
         lV107Mapeowwds_23_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV107Mapeowwds_23_tfproveedornombre), 80, "%");
         lV112Mapeowwds_28_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV112Mapeowwds_28_tfstcomerciosnombre), 80, "%");
         lV114Mapeowwds_30_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV114Mapeowwds_30_tfconexionesid), 9, "%");
         lV116Mapeowwds_32_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV116Mapeowwds_32_tfconexionesnombre), 80, "%");
         /* Using cursor H00JF2 */
         pr_default.execute(0, new Object[] {lV88Mapeowwds_4_stcomerciosnombre1, lV88Mapeowwds_4_stcomerciosnombre1, lV89Mapeowwds_5_proveedornombre1, lV89Mapeowwds_5_proveedornombre1, lV90Mapeowwds_6_conexionesnombre1, lV90Mapeowwds_6_conexionesnombre1, lV94Mapeowwds_10_stcomerciosnombre2, lV94Mapeowwds_10_stcomerciosnombre2, lV95Mapeowwds_11_proveedornombre2, lV95Mapeowwds_11_proveedornombre2, lV96Mapeowwds_12_conexionesnombre2, lV96Mapeowwds_12_conexionesnombre2, lV100Mapeowwds_16_stcomerciosnombre3, lV100Mapeowwds_16_stcomerciosnombre3, lV101Mapeowwds_17_proveedornombre3, lV101Mapeowwds_17_proveedornombre3, lV102Mapeowwds_18_conexionesnombre3, lV102Mapeowwds_18_conexionesnombre3, AV103Mapeowwds_19_tfmapeoid, AV104Mapeowwds_20_tfmapeoid_to, AV105Mapeowwds_21_tfproveedorid, AV106Mapeowwds_22_tfproveedorid_to, lV107Mapeowwds_23_tfproveedornombre, AV108Mapeowwds_24_tfproveedornombre_sel, AV110Mapeowwds_26_tfstcomerciosid, AV111Mapeowwds_27_tfstcomerciosid_to, lV112Mapeowwds_28_tfstcomerciosnombre, AV113Mapeowwds_29_tfstcomerciosnombre_sel, lV114Mapeowwds_30_tfconexionesid, AV115Mapeowwds_31_tfconexionesid_sel, lV116Mapeowwds_32_tfconexionesnombre, AV117Mapeowwds_33_tfconexionesnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A556ConexionesNombre = H00JF2_A556ConexionesNombre[0];
            n556ConexionesNombre = H00JF2_n556ConexionesNombre[0];
            A552ConexionesID = H00JF2_A552ConexionesID[0];
            n552ConexionesID = H00JF2_n552ConexionesID[0];
            A923STComerciosNombre = H00JF2_A923STComerciosNombre[0];
            A919STComerciosID = H00JF2_A919STComerciosID[0];
            n919STComerciosID = H00JF2_n919STComerciosID[0];
            A344ProveedorEstado = H00JF2_A344ProveedorEstado[0];
            A282ProveedorNombre = H00JF2_A282ProveedorNombre[0];
            A133ProveedorID = H00JF2_A133ProveedorID[0];
            A918MapeoID = H00JF2_A918MapeoID[0];
            A556ConexionesNombre = H00JF2_A556ConexionesNombre[0];
            n556ConexionesNombre = H00JF2_n556ConexionesNombre[0];
            A923STComerciosNombre = H00JF2_A923STComerciosNombre[0];
            A344ProveedorEstado = H00JF2_A344ProveedorEstado[0];
            A282ProveedorNombre = H00JF2_A282ProveedorNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Mapeowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A918MapeoID), 18, 0) , StringUtil.PadR( "%" + AV85Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV85Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A919STComerciosID), 18, 0) , StringUtil.PadR( "%" + AV85Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A923STComerciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
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

      protected void RFJF2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 129;
         /* Execute user event: Refresh */
         E28JF2 ();
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
                                                 A344ProveedorEstado ,
                                                 AV109Mapeowwds_25_tfproveedorestado_sels ,
                                                 AV86Mapeowwds_2_dynamicfiltersselector1 ,
                                                 AV87Mapeowwds_3_dynamicfiltersoperator1 ,
                                                 AV88Mapeowwds_4_stcomerciosnombre1 ,
                                                 AV89Mapeowwds_5_proveedornombre1 ,
                                                 AV90Mapeowwds_6_conexionesnombre1 ,
                                                 AV91Mapeowwds_7_dynamicfiltersenabled2 ,
                                                 AV92Mapeowwds_8_dynamicfiltersselector2 ,
                                                 AV93Mapeowwds_9_dynamicfiltersoperator2 ,
                                                 AV94Mapeowwds_10_stcomerciosnombre2 ,
                                                 AV95Mapeowwds_11_proveedornombre2 ,
                                                 AV96Mapeowwds_12_conexionesnombre2 ,
                                                 AV97Mapeowwds_13_dynamicfiltersenabled3 ,
                                                 AV98Mapeowwds_14_dynamicfiltersselector3 ,
                                                 AV99Mapeowwds_15_dynamicfiltersoperator3 ,
                                                 AV100Mapeowwds_16_stcomerciosnombre3 ,
                                                 AV101Mapeowwds_17_proveedornombre3 ,
                                                 AV102Mapeowwds_18_conexionesnombre3 ,
                                                 AV103Mapeowwds_19_tfmapeoid ,
                                                 AV104Mapeowwds_20_tfmapeoid_to ,
                                                 AV105Mapeowwds_21_tfproveedorid ,
                                                 AV106Mapeowwds_22_tfproveedorid_to ,
                                                 AV108Mapeowwds_24_tfproveedornombre_sel ,
                                                 AV107Mapeowwds_23_tfproveedornombre ,
                                                 AV109Mapeowwds_25_tfproveedorestado_sels.Count ,
                                                 AV110Mapeowwds_26_tfstcomerciosid ,
                                                 AV111Mapeowwds_27_tfstcomerciosid_to ,
                                                 AV113Mapeowwds_29_tfstcomerciosnombre_sel ,
                                                 AV112Mapeowwds_28_tfstcomerciosnombre ,
                                                 AV115Mapeowwds_31_tfconexionesid_sel ,
                                                 AV114Mapeowwds_30_tfconexionesid ,
                                                 AV117Mapeowwds_33_tfconexionesnombre_sel ,
                                                 AV116Mapeowwds_32_tfconexionesnombre ,
                                                 A923STComerciosNombre ,
                                                 A282ProveedorNombre ,
                                                 A556ConexionesNombre ,
                                                 A918MapeoID ,
                                                 A133ProveedorID ,
                                                 A919STComerciosID ,
                                                 A552ConexionesID ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV85Mapeowwds_1_filterfulltext } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT,
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV88Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_4_stcomerciosnombre1), 80, "%");
            lV88Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_4_stcomerciosnombre1), 80, "%");
            lV89Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_5_proveedornombre1), 80, "%");
            lV89Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_5_proveedornombre1), 80, "%");
            lV90Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_6_conexionesnombre1), 80, "%");
            lV90Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_6_conexionesnombre1), 80, "%");
            lV94Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV94Mapeowwds_10_stcomerciosnombre2), 80, "%");
            lV94Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV94Mapeowwds_10_stcomerciosnombre2), 80, "%");
            lV95Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV95Mapeowwds_11_proveedornombre2), 80, "%");
            lV95Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV95Mapeowwds_11_proveedornombre2), 80, "%");
            lV96Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV96Mapeowwds_12_conexionesnombre2), 80, "%");
            lV96Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV96Mapeowwds_12_conexionesnombre2), 80, "%");
            lV100Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV100Mapeowwds_16_stcomerciosnombre3), 80, "%");
            lV100Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV100Mapeowwds_16_stcomerciosnombre3), 80, "%");
            lV101Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV101Mapeowwds_17_proveedornombre3), 80, "%");
            lV101Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV101Mapeowwds_17_proveedornombre3), 80, "%");
            lV102Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV102Mapeowwds_18_conexionesnombre3), 80, "%");
            lV102Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV102Mapeowwds_18_conexionesnombre3), 80, "%");
            lV107Mapeowwds_23_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV107Mapeowwds_23_tfproveedornombre), 80, "%");
            lV112Mapeowwds_28_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV112Mapeowwds_28_tfstcomerciosnombre), 80, "%");
            lV114Mapeowwds_30_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV114Mapeowwds_30_tfconexionesid), 9, "%");
            lV116Mapeowwds_32_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV116Mapeowwds_32_tfconexionesnombre), 80, "%");
            /* Using cursor H00JF3 */
            pr_default.execute(1, new Object[] {lV88Mapeowwds_4_stcomerciosnombre1, lV88Mapeowwds_4_stcomerciosnombre1, lV89Mapeowwds_5_proveedornombre1, lV89Mapeowwds_5_proveedornombre1, lV90Mapeowwds_6_conexionesnombre1, lV90Mapeowwds_6_conexionesnombre1, lV94Mapeowwds_10_stcomerciosnombre2, lV94Mapeowwds_10_stcomerciosnombre2, lV95Mapeowwds_11_proveedornombre2, lV95Mapeowwds_11_proveedornombre2, lV96Mapeowwds_12_conexionesnombre2, lV96Mapeowwds_12_conexionesnombre2, lV100Mapeowwds_16_stcomerciosnombre3, lV100Mapeowwds_16_stcomerciosnombre3, lV101Mapeowwds_17_proveedornombre3, lV101Mapeowwds_17_proveedornombre3, lV102Mapeowwds_18_conexionesnombre3, lV102Mapeowwds_18_conexionesnombre3, AV103Mapeowwds_19_tfmapeoid, AV104Mapeowwds_20_tfmapeoid_to, AV105Mapeowwds_21_tfproveedorid, AV106Mapeowwds_22_tfproveedorid_to, lV107Mapeowwds_23_tfproveedornombre, AV108Mapeowwds_24_tfproveedornombre_sel, AV110Mapeowwds_26_tfstcomerciosid, AV111Mapeowwds_27_tfstcomerciosid_to, lV112Mapeowwds_28_tfstcomerciosnombre, AV113Mapeowwds_29_tfstcomerciosnombre_sel, lV114Mapeowwds_30_tfconexionesid, AV115Mapeowwds_31_tfconexionesid_sel, lV116Mapeowwds_32_tfconexionesnombre, AV117Mapeowwds_33_tfconexionesnombre_sel});
            nGXsfl_129_idx = 1;
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
            SubsflControlProps_1292( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A556ConexionesNombre = H00JF3_A556ConexionesNombre[0];
               n556ConexionesNombre = H00JF3_n556ConexionesNombre[0];
               A552ConexionesID = H00JF3_A552ConexionesID[0];
               n552ConexionesID = H00JF3_n552ConexionesID[0];
               A923STComerciosNombre = H00JF3_A923STComerciosNombre[0];
               A919STComerciosID = H00JF3_A919STComerciosID[0];
               n919STComerciosID = H00JF3_n919STComerciosID[0];
               A344ProveedorEstado = H00JF3_A344ProveedorEstado[0];
               A282ProveedorNombre = H00JF3_A282ProveedorNombre[0];
               A133ProveedorID = H00JF3_A133ProveedorID[0];
               A918MapeoID = H00JF3_A918MapeoID[0];
               A556ConexionesNombre = H00JF3_A556ConexionesNombre[0];
               n556ConexionesNombre = H00JF3_n556ConexionesNombre[0];
               A923STComerciosNombre = H00JF3_A923STComerciosNombre[0];
               A344ProveedorEstado = H00JF3_A344ProveedorEstado[0];
               A282ProveedorNombre = H00JF3_A282ProveedorNombre[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Mapeowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A918MapeoID), 18, 0) , StringUtil.PadR( "%" + AV85Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV85Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A919STComerciosID), 18, 0) , StringUtil.PadR( "%" + AV85Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A923STComerciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV85Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
               {
                  /* Execute user event: Grid.Load */
                  E29JF2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 129;
            WBJF0( ) ;
         }
         bGXsfl_129_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesJF2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV84Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV84Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV54IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV54IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV55IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV55IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROVEEDORNOMBRE", AV56IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( "", AV56IsAuthorized_ProveedorNombre, context));
         GxWebStd.gx_hidden_field( context, "gxhash_MAPEOID"+"_"+sGXsfl_129_idx, GetSecureSignedToken( sGXsfl_129_idx, context.localUtil.Format( (decimal)(A918MapeoID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         AV85Mapeowwds_1_filterfulltext = AV16FilterFullText;
         AV86Mapeowwds_2_dynamicfiltersselector1 = AV65DynamicFiltersSelector1;
         AV87Mapeowwds_3_dynamicfiltersoperator1 = AV66DynamicFiltersOperator1;
         AV88Mapeowwds_4_stcomerciosnombre1 = AV67STComerciosNombre1;
         AV89Mapeowwds_5_proveedornombre1 = AV68ProveedorNombre1;
         AV90Mapeowwds_6_conexionesnombre1 = AV69ConexionesNombre1;
         AV91Mapeowwds_7_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV92Mapeowwds_8_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV93Mapeowwds_9_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV94Mapeowwds_10_stcomerciosnombre2 = AV73STComerciosNombre2;
         AV95Mapeowwds_11_proveedornombre2 = AV74ProveedorNombre2;
         AV96Mapeowwds_12_conexionesnombre2 = AV75ConexionesNombre2;
         AV97Mapeowwds_13_dynamicfiltersenabled3 = AV76DynamicFiltersEnabled3;
         AV98Mapeowwds_14_dynamicfiltersselector3 = AV77DynamicFiltersSelector3;
         AV99Mapeowwds_15_dynamicfiltersoperator3 = AV78DynamicFiltersOperator3;
         AV100Mapeowwds_16_stcomerciosnombre3 = AV79STComerciosNombre3;
         AV101Mapeowwds_17_proveedornombre3 = AV80ProveedorNombre3;
         AV102Mapeowwds_18_conexionesnombre3 = AV81ConexionesNombre3;
         AV103Mapeowwds_19_tfmapeoid = AV27TFMapeoID;
         AV104Mapeowwds_20_tfmapeoid_to = AV28TFMapeoID_To;
         AV105Mapeowwds_21_tfproveedorid = AV29TFProveedorID;
         AV106Mapeowwds_22_tfproveedorid_to = AV30TFProveedorID_To;
         AV107Mapeowwds_23_tfproveedornombre = AV31TFProveedorNombre;
         AV108Mapeowwds_24_tfproveedornombre_sel = AV32TFProveedorNombre_Sel;
         AV109Mapeowwds_25_tfproveedorestado_sels = AV34TFProveedorEstado_Sels;
         AV110Mapeowwds_26_tfstcomerciosid = AV35TFSTComerciosID;
         AV111Mapeowwds_27_tfstcomerciosid_to = AV36TFSTComerciosID_To;
         AV112Mapeowwds_28_tfstcomerciosnombre = AV37TFSTComerciosNombre;
         AV113Mapeowwds_29_tfstcomerciosnombre_sel = AV38TFSTComerciosNombre_Sel;
         AV114Mapeowwds_30_tfconexionesid = AV41TFConexionesID;
         AV115Mapeowwds_31_tfconexionesid_sel = AV42TFConexionesID_Sel;
         AV116Mapeowwds_32_tfconexionesnombre = AV43TFConexionesNombre;
         AV117Mapeowwds_33_tfconexionesnombre_sel = AV44TFConexionesNombre_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV65DynamicFiltersSelector1, AV66DynamicFiltersOperator1, AV67STComerciosNombre1, AV68ProveedorNombre1, AV69ConexionesNombre1, AV71DynamicFiltersSelector2, AV72DynamicFiltersOperator2, AV73STComerciosNombre2, AV74ProveedorNombre2, AV75ConexionesNombre2, AV77DynamicFiltersSelector3, AV78DynamicFiltersOperator3, AV79STComerciosNombre3, AV80ProveedorNombre3, AV81ConexionesNombre3, AV26ManageFiltersExecutionStep, AV70DynamicFiltersEnabled2, AV76DynamicFiltersEnabled3, AV21ColumnsSelector, AV84Pgmname, AV16FilterFullText, AV27TFMapeoID, AV28TFMapeoID_To, AV29TFProveedorID, AV30TFProveedorID_To, AV31TFProveedorNombre, AV32TFProveedorNombre_Sel, AV34TFProveedorEstado_Sels, AV35TFSTComerciosID, AV36TFSTComerciosID_To, AV37TFSTComerciosNombre, AV38TFSTComerciosNombre_Sel, AV41TFConexionesID, AV42TFConexionesID_Sel, AV43TFConexionesNombre, AV44TFConexionesNombre_Sel, AV11GridState, AV83DynamicFiltersIgnoreFirst, AV82DynamicFiltersRemoving, AV54IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ProveedorNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV85Mapeowwds_1_filterfulltext = AV16FilterFullText;
         AV86Mapeowwds_2_dynamicfiltersselector1 = AV65DynamicFiltersSelector1;
         AV87Mapeowwds_3_dynamicfiltersoperator1 = AV66DynamicFiltersOperator1;
         AV88Mapeowwds_4_stcomerciosnombre1 = AV67STComerciosNombre1;
         AV89Mapeowwds_5_proveedornombre1 = AV68ProveedorNombre1;
         AV90Mapeowwds_6_conexionesnombre1 = AV69ConexionesNombre1;
         AV91Mapeowwds_7_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV92Mapeowwds_8_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV93Mapeowwds_9_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV94Mapeowwds_10_stcomerciosnombre2 = AV73STComerciosNombre2;
         AV95Mapeowwds_11_proveedornombre2 = AV74ProveedorNombre2;
         AV96Mapeowwds_12_conexionesnombre2 = AV75ConexionesNombre2;
         AV97Mapeowwds_13_dynamicfiltersenabled3 = AV76DynamicFiltersEnabled3;
         AV98Mapeowwds_14_dynamicfiltersselector3 = AV77DynamicFiltersSelector3;
         AV99Mapeowwds_15_dynamicfiltersoperator3 = AV78DynamicFiltersOperator3;
         AV100Mapeowwds_16_stcomerciosnombre3 = AV79STComerciosNombre3;
         AV101Mapeowwds_17_proveedornombre3 = AV80ProveedorNombre3;
         AV102Mapeowwds_18_conexionesnombre3 = AV81ConexionesNombre3;
         AV103Mapeowwds_19_tfmapeoid = AV27TFMapeoID;
         AV104Mapeowwds_20_tfmapeoid_to = AV28TFMapeoID_To;
         AV105Mapeowwds_21_tfproveedorid = AV29TFProveedorID;
         AV106Mapeowwds_22_tfproveedorid_to = AV30TFProveedorID_To;
         AV107Mapeowwds_23_tfproveedornombre = AV31TFProveedorNombre;
         AV108Mapeowwds_24_tfproveedornombre_sel = AV32TFProveedorNombre_Sel;
         AV109Mapeowwds_25_tfproveedorestado_sels = AV34TFProveedorEstado_Sels;
         AV110Mapeowwds_26_tfstcomerciosid = AV35TFSTComerciosID;
         AV111Mapeowwds_27_tfstcomerciosid_to = AV36TFSTComerciosID_To;
         AV112Mapeowwds_28_tfstcomerciosnombre = AV37TFSTComerciosNombre;
         AV113Mapeowwds_29_tfstcomerciosnombre_sel = AV38TFSTComerciosNombre_Sel;
         AV114Mapeowwds_30_tfconexionesid = AV41TFConexionesID;
         AV115Mapeowwds_31_tfconexionesid_sel = AV42TFConexionesID_Sel;
         AV116Mapeowwds_32_tfconexionesnombre = AV43TFConexionesNombre;
         AV117Mapeowwds_33_tfconexionesnombre_sel = AV44TFConexionesNombre_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV65DynamicFiltersSelector1, AV66DynamicFiltersOperator1, AV67STComerciosNombre1, AV68ProveedorNombre1, AV69ConexionesNombre1, AV71DynamicFiltersSelector2, AV72DynamicFiltersOperator2, AV73STComerciosNombre2, AV74ProveedorNombre2, AV75ConexionesNombre2, AV77DynamicFiltersSelector3, AV78DynamicFiltersOperator3, AV79STComerciosNombre3, AV80ProveedorNombre3, AV81ConexionesNombre3, AV26ManageFiltersExecutionStep, AV70DynamicFiltersEnabled2, AV76DynamicFiltersEnabled3, AV21ColumnsSelector, AV84Pgmname, AV16FilterFullText, AV27TFMapeoID, AV28TFMapeoID_To, AV29TFProveedorID, AV30TFProveedorID_To, AV31TFProveedorNombre, AV32TFProveedorNombre_Sel, AV34TFProveedorEstado_Sels, AV35TFSTComerciosID, AV36TFSTComerciosID_To, AV37TFSTComerciosNombre, AV38TFSTComerciosNombre_Sel, AV41TFConexionesID, AV42TFConexionesID_Sel, AV43TFConexionesNombre, AV44TFConexionesNombre_Sel, AV11GridState, AV83DynamicFiltersIgnoreFirst, AV82DynamicFiltersRemoving, AV54IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ProveedorNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV85Mapeowwds_1_filterfulltext = AV16FilterFullText;
         AV86Mapeowwds_2_dynamicfiltersselector1 = AV65DynamicFiltersSelector1;
         AV87Mapeowwds_3_dynamicfiltersoperator1 = AV66DynamicFiltersOperator1;
         AV88Mapeowwds_4_stcomerciosnombre1 = AV67STComerciosNombre1;
         AV89Mapeowwds_5_proveedornombre1 = AV68ProveedorNombre1;
         AV90Mapeowwds_6_conexionesnombre1 = AV69ConexionesNombre1;
         AV91Mapeowwds_7_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV92Mapeowwds_8_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV93Mapeowwds_9_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV94Mapeowwds_10_stcomerciosnombre2 = AV73STComerciosNombre2;
         AV95Mapeowwds_11_proveedornombre2 = AV74ProveedorNombre2;
         AV96Mapeowwds_12_conexionesnombre2 = AV75ConexionesNombre2;
         AV97Mapeowwds_13_dynamicfiltersenabled3 = AV76DynamicFiltersEnabled3;
         AV98Mapeowwds_14_dynamicfiltersselector3 = AV77DynamicFiltersSelector3;
         AV99Mapeowwds_15_dynamicfiltersoperator3 = AV78DynamicFiltersOperator3;
         AV100Mapeowwds_16_stcomerciosnombre3 = AV79STComerciosNombre3;
         AV101Mapeowwds_17_proveedornombre3 = AV80ProveedorNombre3;
         AV102Mapeowwds_18_conexionesnombre3 = AV81ConexionesNombre3;
         AV103Mapeowwds_19_tfmapeoid = AV27TFMapeoID;
         AV104Mapeowwds_20_tfmapeoid_to = AV28TFMapeoID_To;
         AV105Mapeowwds_21_tfproveedorid = AV29TFProveedorID;
         AV106Mapeowwds_22_tfproveedorid_to = AV30TFProveedorID_To;
         AV107Mapeowwds_23_tfproveedornombre = AV31TFProveedorNombre;
         AV108Mapeowwds_24_tfproveedornombre_sel = AV32TFProveedorNombre_Sel;
         AV109Mapeowwds_25_tfproveedorestado_sels = AV34TFProveedorEstado_Sels;
         AV110Mapeowwds_26_tfstcomerciosid = AV35TFSTComerciosID;
         AV111Mapeowwds_27_tfstcomerciosid_to = AV36TFSTComerciosID_To;
         AV112Mapeowwds_28_tfstcomerciosnombre = AV37TFSTComerciosNombre;
         AV113Mapeowwds_29_tfstcomerciosnombre_sel = AV38TFSTComerciosNombre_Sel;
         AV114Mapeowwds_30_tfconexionesid = AV41TFConexionesID;
         AV115Mapeowwds_31_tfconexionesid_sel = AV42TFConexionesID_Sel;
         AV116Mapeowwds_32_tfconexionesnombre = AV43TFConexionesNombre;
         AV117Mapeowwds_33_tfconexionesnombre_sel = AV44TFConexionesNombre_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV65DynamicFiltersSelector1, AV66DynamicFiltersOperator1, AV67STComerciosNombre1, AV68ProveedorNombre1, AV69ConexionesNombre1, AV71DynamicFiltersSelector2, AV72DynamicFiltersOperator2, AV73STComerciosNombre2, AV74ProveedorNombre2, AV75ConexionesNombre2, AV77DynamicFiltersSelector3, AV78DynamicFiltersOperator3, AV79STComerciosNombre3, AV80ProveedorNombre3, AV81ConexionesNombre3, AV26ManageFiltersExecutionStep, AV70DynamicFiltersEnabled2, AV76DynamicFiltersEnabled3, AV21ColumnsSelector, AV84Pgmname, AV16FilterFullText, AV27TFMapeoID, AV28TFMapeoID_To, AV29TFProveedorID, AV30TFProveedorID_To, AV31TFProveedorNombre, AV32TFProveedorNombre_Sel, AV34TFProveedorEstado_Sels, AV35TFSTComerciosID, AV36TFSTComerciosID_To, AV37TFSTComerciosNombre, AV38TFSTComerciosNombre_Sel, AV41TFConexionesID, AV42TFConexionesID_Sel, AV43TFConexionesNombre, AV44TFConexionesNombre_Sel, AV11GridState, AV83DynamicFiltersIgnoreFirst, AV82DynamicFiltersRemoving, AV54IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ProveedorNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV85Mapeowwds_1_filterfulltext = AV16FilterFullText;
         AV86Mapeowwds_2_dynamicfiltersselector1 = AV65DynamicFiltersSelector1;
         AV87Mapeowwds_3_dynamicfiltersoperator1 = AV66DynamicFiltersOperator1;
         AV88Mapeowwds_4_stcomerciosnombre1 = AV67STComerciosNombre1;
         AV89Mapeowwds_5_proveedornombre1 = AV68ProveedorNombre1;
         AV90Mapeowwds_6_conexionesnombre1 = AV69ConexionesNombre1;
         AV91Mapeowwds_7_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV92Mapeowwds_8_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV93Mapeowwds_9_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV94Mapeowwds_10_stcomerciosnombre2 = AV73STComerciosNombre2;
         AV95Mapeowwds_11_proveedornombre2 = AV74ProveedorNombre2;
         AV96Mapeowwds_12_conexionesnombre2 = AV75ConexionesNombre2;
         AV97Mapeowwds_13_dynamicfiltersenabled3 = AV76DynamicFiltersEnabled3;
         AV98Mapeowwds_14_dynamicfiltersselector3 = AV77DynamicFiltersSelector3;
         AV99Mapeowwds_15_dynamicfiltersoperator3 = AV78DynamicFiltersOperator3;
         AV100Mapeowwds_16_stcomerciosnombre3 = AV79STComerciosNombre3;
         AV101Mapeowwds_17_proveedornombre3 = AV80ProveedorNombre3;
         AV102Mapeowwds_18_conexionesnombre3 = AV81ConexionesNombre3;
         AV103Mapeowwds_19_tfmapeoid = AV27TFMapeoID;
         AV104Mapeowwds_20_tfmapeoid_to = AV28TFMapeoID_To;
         AV105Mapeowwds_21_tfproveedorid = AV29TFProveedorID;
         AV106Mapeowwds_22_tfproveedorid_to = AV30TFProveedorID_To;
         AV107Mapeowwds_23_tfproveedornombre = AV31TFProveedorNombre;
         AV108Mapeowwds_24_tfproveedornombre_sel = AV32TFProveedorNombre_Sel;
         AV109Mapeowwds_25_tfproveedorestado_sels = AV34TFProveedorEstado_Sels;
         AV110Mapeowwds_26_tfstcomerciosid = AV35TFSTComerciosID;
         AV111Mapeowwds_27_tfstcomerciosid_to = AV36TFSTComerciosID_To;
         AV112Mapeowwds_28_tfstcomerciosnombre = AV37TFSTComerciosNombre;
         AV113Mapeowwds_29_tfstcomerciosnombre_sel = AV38TFSTComerciosNombre_Sel;
         AV114Mapeowwds_30_tfconexionesid = AV41TFConexionesID;
         AV115Mapeowwds_31_tfconexionesid_sel = AV42TFConexionesID_Sel;
         AV116Mapeowwds_32_tfconexionesnombre = AV43TFConexionesNombre;
         AV117Mapeowwds_33_tfconexionesnombre_sel = AV44TFConexionesNombre_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV65DynamicFiltersSelector1, AV66DynamicFiltersOperator1, AV67STComerciosNombre1, AV68ProveedorNombre1, AV69ConexionesNombre1, AV71DynamicFiltersSelector2, AV72DynamicFiltersOperator2, AV73STComerciosNombre2, AV74ProveedorNombre2, AV75ConexionesNombre2, AV77DynamicFiltersSelector3, AV78DynamicFiltersOperator3, AV79STComerciosNombre3, AV80ProveedorNombre3, AV81ConexionesNombre3, AV26ManageFiltersExecutionStep, AV70DynamicFiltersEnabled2, AV76DynamicFiltersEnabled3, AV21ColumnsSelector, AV84Pgmname, AV16FilterFullText, AV27TFMapeoID, AV28TFMapeoID_To, AV29TFProveedorID, AV30TFProveedorID_To, AV31TFProveedorNombre, AV32TFProveedorNombre_Sel, AV34TFProveedorEstado_Sels, AV35TFSTComerciosID, AV36TFSTComerciosID_To, AV37TFSTComerciosNombre, AV38TFSTComerciosNombre_Sel, AV41TFConexionesID, AV42TFConexionesID_Sel, AV43TFConexionesNombre, AV44TFConexionesNombre_Sel, AV11GridState, AV83DynamicFiltersIgnoreFirst, AV82DynamicFiltersRemoving, AV54IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ProveedorNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV85Mapeowwds_1_filterfulltext = AV16FilterFullText;
         AV86Mapeowwds_2_dynamicfiltersselector1 = AV65DynamicFiltersSelector1;
         AV87Mapeowwds_3_dynamicfiltersoperator1 = AV66DynamicFiltersOperator1;
         AV88Mapeowwds_4_stcomerciosnombre1 = AV67STComerciosNombre1;
         AV89Mapeowwds_5_proveedornombre1 = AV68ProveedorNombre1;
         AV90Mapeowwds_6_conexionesnombre1 = AV69ConexionesNombre1;
         AV91Mapeowwds_7_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV92Mapeowwds_8_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV93Mapeowwds_9_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV94Mapeowwds_10_stcomerciosnombre2 = AV73STComerciosNombre2;
         AV95Mapeowwds_11_proveedornombre2 = AV74ProveedorNombre2;
         AV96Mapeowwds_12_conexionesnombre2 = AV75ConexionesNombre2;
         AV97Mapeowwds_13_dynamicfiltersenabled3 = AV76DynamicFiltersEnabled3;
         AV98Mapeowwds_14_dynamicfiltersselector3 = AV77DynamicFiltersSelector3;
         AV99Mapeowwds_15_dynamicfiltersoperator3 = AV78DynamicFiltersOperator3;
         AV100Mapeowwds_16_stcomerciosnombre3 = AV79STComerciosNombre3;
         AV101Mapeowwds_17_proveedornombre3 = AV80ProveedorNombre3;
         AV102Mapeowwds_18_conexionesnombre3 = AV81ConexionesNombre3;
         AV103Mapeowwds_19_tfmapeoid = AV27TFMapeoID;
         AV104Mapeowwds_20_tfmapeoid_to = AV28TFMapeoID_To;
         AV105Mapeowwds_21_tfproveedorid = AV29TFProveedorID;
         AV106Mapeowwds_22_tfproveedorid_to = AV30TFProveedorID_To;
         AV107Mapeowwds_23_tfproveedornombre = AV31TFProveedorNombre;
         AV108Mapeowwds_24_tfproveedornombre_sel = AV32TFProveedorNombre_Sel;
         AV109Mapeowwds_25_tfproveedorestado_sels = AV34TFProveedorEstado_Sels;
         AV110Mapeowwds_26_tfstcomerciosid = AV35TFSTComerciosID;
         AV111Mapeowwds_27_tfstcomerciosid_to = AV36TFSTComerciosID_To;
         AV112Mapeowwds_28_tfstcomerciosnombre = AV37TFSTComerciosNombre;
         AV113Mapeowwds_29_tfstcomerciosnombre_sel = AV38TFSTComerciosNombre_Sel;
         AV114Mapeowwds_30_tfconexionesid = AV41TFConexionesID;
         AV115Mapeowwds_31_tfconexionesid_sel = AV42TFConexionesID_Sel;
         AV116Mapeowwds_32_tfconexionesnombre = AV43TFConexionesNombre;
         AV117Mapeowwds_33_tfconexionesnombre_sel = AV44TFConexionesNombre_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV65DynamicFiltersSelector1, AV66DynamicFiltersOperator1, AV67STComerciosNombre1, AV68ProveedorNombre1, AV69ConexionesNombre1, AV71DynamicFiltersSelector2, AV72DynamicFiltersOperator2, AV73STComerciosNombre2, AV74ProveedorNombre2, AV75ConexionesNombre2, AV77DynamicFiltersSelector3, AV78DynamicFiltersOperator3, AV79STComerciosNombre3, AV80ProveedorNombre3, AV81ConexionesNombre3, AV26ManageFiltersExecutionStep, AV70DynamicFiltersEnabled2, AV76DynamicFiltersEnabled3, AV21ColumnsSelector, AV84Pgmname, AV16FilterFullText, AV27TFMapeoID, AV28TFMapeoID_To, AV29TFProveedorID, AV30TFProveedorID_To, AV31TFProveedorNombre, AV32TFProveedorNombre_Sel, AV34TFProveedorEstado_Sels, AV35TFSTComerciosID, AV36TFSTComerciosID_To, AV37TFSTComerciosNombre, AV38TFSTComerciosNombre_Sel, AV41TFConexionesID, AV42TFConexionesID_Sel, AV43TFConexionesNombre, AV44TFConexionesNombre_Sel, AV11GridState, AV83DynamicFiltersIgnoreFirst, AV82DynamicFiltersRemoving, AV54IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ProveedorNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV84Pgmname = "MapeoWW";
         edtMapeoID_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         cmbProveedorEstado.Enabled = 0;
         edtSTComerciosID_Enabled = 0;
         edtSTComerciosNombre_Enabled = 0;
         edtConexionesID_Enabled = 0;
         edtConexionesNombre_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPJF0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E27JF2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV61AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV47DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV21ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_129 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_129"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV49GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV50GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV51GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV65DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV65DynamicFiltersSelector1", AV65DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV66DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV66DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
            AV67STComerciosNombre1 = cgiGet( edtavStcomerciosnombre1_Internalname);
            AssignAttri("", false, "AV67STComerciosNombre1", AV67STComerciosNombre1);
            AV68ProveedorNombre1 = cgiGet( edtavProveedornombre1_Internalname);
            AssignAttri("", false, "AV68ProveedorNombre1", AV68ProveedorNombre1);
            AV69ConexionesNombre1 = cgiGet( edtavConexionesnombre1_Internalname);
            AssignAttri("", false, "AV69ConexionesNombre1", AV69ConexionesNombre1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV71DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV71DynamicFiltersSelector2", AV71DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV72DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV72DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
            AV73STComerciosNombre2 = cgiGet( edtavStcomerciosnombre2_Internalname);
            AssignAttri("", false, "AV73STComerciosNombre2", AV73STComerciosNombre2);
            AV74ProveedorNombre2 = cgiGet( edtavProveedornombre2_Internalname);
            AssignAttri("", false, "AV74ProveedorNombre2", AV74ProveedorNombre2);
            AV75ConexionesNombre2 = cgiGet( edtavConexionesnombre2_Internalname);
            AssignAttri("", false, "AV75ConexionesNombre2", AV75ConexionesNombre2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV77DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV77DynamicFiltersSelector3", AV77DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV78DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV78DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
            AV79STComerciosNombre3 = cgiGet( edtavStcomerciosnombre3_Internalname);
            AssignAttri("", false, "AV79STComerciosNombre3", AV79STComerciosNombre3);
            AV80ProveedorNombre3 = cgiGet( edtavProveedornombre3_Internalname);
            AssignAttri("", false, "AV80ProveedorNombre3", AV80ProveedorNombre3);
            AV81ConexionesNombre3 = cgiGet( edtavConexionesnombre3_Internalname);
            AssignAttri("", false, "AV81ConexionesNombre3", AV81ConexionesNombre3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV65DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV66DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSTCOMERCIOSNOMBRE1"), AV67STComerciosNombre1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE1"), AV68ProveedorNombre1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONEXIONESNOMBRE1"), AV69ConexionesNombre1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV71DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV72DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSTCOMERCIOSNOMBRE2"), AV73STComerciosNombre2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE2"), AV74ProveedorNombre2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONEXIONESNOMBRE2"), AV75ConexionesNombre2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV77DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV78DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSTCOMERCIOSNOMBRE3"), AV79STComerciosNombre3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE3"), AV80ProveedorNombre3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCONEXIONESNOMBRE3"), AV81ConexionesNombre3) != 0 )
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
         E27JF2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E27JF2( )
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
         AV65DynamicFiltersSelector1 = "STCOMERCIOSNOMBRE";
         AssignAttri("", false, "AV65DynamicFiltersSelector1", AV65DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV71DynamicFiltersSelector2 = "STCOMERCIOSNOMBRE";
         AssignAttri("", false, "AV71DynamicFiltersSelector2", AV71DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV77DynamicFiltersSelector3 = "STCOMERCIOSNOMBRE";
         AssignAttri("", false, "AV77DynamicFiltersSelector3", AV77DynamicFiltersSelector3);
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
         AV61AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV62AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV62AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV62AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV62AGExportDataItem.gxTpr_Eventkey = "Export";
         AV62AGExportDataItem.gxTpr_Isdivider = false;
         AV61AGExportData.Add(AV62AGExportDataItem, 0);
         AV62AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV62AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV62AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV62AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV62AGExportDataItem.gxTpr_Isdivider = false;
         AV61AGExportData.Add(AV62AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV56IsAuthorized_ProveedorNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor", out  GXt_boolean1) ;
         AV56IsAuthorized_ProveedorNombre = GXt_boolean1;
         AssignAttri("", false, "AV56IsAuthorized_ProveedorNombre", AV56IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( "", AV56IsAuthorized_ProveedorNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Mapeo", "");
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
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV47DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV47DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E28JF2( )
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
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "STCOMERCIOSNOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "CONEXIONESNOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         if ( AV70DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "STCOMERCIOSNOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "CONEXIONESNOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            if ( AV76DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "STCOMERCIOSNOMBRE") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
               }
               else if ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
               }
               else if ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "CONEXIONESNOMBRE") == 0 )
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
         if ( StringUtil.StrCmp(AV23Session.Get("MapeoWWColumnsSelector"), "") != 0 )
         {
            AV19ColumnsSelectorXML = AV23Session.Get("MapeoWWColumnsSelector");
            AV21ColumnsSelector.FromXml(AV19ColumnsSelectorXML, null, "", "");
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
         edtMapeoID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMapeoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMapeoID_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProveedorID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorID_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProveedorNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         cmbProveedorEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbProveedorEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtSTComerciosID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSTComerciosID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSTComerciosID_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtSTComerciosNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSTComerciosNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSTComerciosNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtConexionesID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtConexionesID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConexionesID_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtConexionesNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtConexionesNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConexionesNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         AV49GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV49GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV49GridCurrentPage), 10, 0));
         AV50GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV50GridPageCount", StringUtil.LTrimStr( (decimal)(AV50GridPageCount), 10, 0));
         GXt_char3 = AV51GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV84Pgmname, out  GXt_char3) ;
         AV51GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV51GridAppliedFilters", AV51GridAppliedFilters);
         AV85Mapeowwds_1_filterfulltext = AV16FilterFullText;
         AV86Mapeowwds_2_dynamicfiltersselector1 = AV65DynamicFiltersSelector1;
         AV87Mapeowwds_3_dynamicfiltersoperator1 = AV66DynamicFiltersOperator1;
         AV88Mapeowwds_4_stcomerciosnombre1 = AV67STComerciosNombre1;
         AV89Mapeowwds_5_proveedornombre1 = AV68ProveedorNombre1;
         AV90Mapeowwds_6_conexionesnombre1 = AV69ConexionesNombre1;
         AV91Mapeowwds_7_dynamicfiltersenabled2 = AV70DynamicFiltersEnabled2;
         AV92Mapeowwds_8_dynamicfiltersselector2 = AV71DynamicFiltersSelector2;
         AV93Mapeowwds_9_dynamicfiltersoperator2 = AV72DynamicFiltersOperator2;
         AV94Mapeowwds_10_stcomerciosnombre2 = AV73STComerciosNombre2;
         AV95Mapeowwds_11_proveedornombre2 = AV74ProveedorNombre2;
         AV96Mapeowwds_12_conexionesnombre2 = AV75ConexionesNombre2;
         AV97Mapeowwds_13_dynamicfiltersenabled3 = AV76DynamicFiltersEnabled3;
         AV98Mapeowwds_14_dynamicfiltersselector3 = AV77DynamicFiltersSelector3;
         AV99Mapeowwds_15_dynamicfiltersoperator3 = AV78DynamicFiltersOperator3;
         AV100Mapeowwds_16_stcomerciosnombre3 = AV79STComerciosNombre3;
         AV101Mapeowwds_17_proveedornombre3 = AV80ProveedorNombre3;
         AV102Mapeowwds_18_conexionesnombre3 = AV81ConexionesNombre3;
         AV103Mapeowwds_19_tfmapeoid = AV27TFMapeoID;
         AV104Mapeowwds_20_tfmapeoid_to = AV28TFMapeoID_To;
         AV105Mapeowwds_21_tfproveedorid = AV29TFProveedorID;
         AV106Mapeowwds_22_tfproveedorid_to = AV30TFProveedorID_To;
         AV107Mapeowwds_23_tfproveedornombre = AV31TFProveedorNombre;
         AV108Mapeowwds_24_tfproveedornombre_sel = AV32TFProveedorNombre_Sel;
         AV109Mapeowwds_25_tfproveedorestado_sels = AV34TFProveedorEstado_Sels;
         AV110Mapeowwds_26_tfstcomerciosid = AV35TFSTComerciosID;
         AV111Mapeowwds_27_tfstcomerciosid_to = AV36TFSTComerciosID_To;
         AV112Mapeowwds_28_tfstcomerciosnombre = AV37TFSTComerciosNombre;
         AV113Mapeowwds_29_tfstcomerciosnombre_sel = AV38TFSTComerciosNombre_Sel;
         AV114Mapeowwds_30_tfconexionesid = AV41TFConexionesID;
         AV115Mapeowwds_31_tfconexionesid_sel = AV42TFConexionesID_Sel;
         AV116Mapeowwds_32_tfconexionesnombre = AV43TFConexionesNombre;
         AV117Mapeowwds_33_tfconexionesnombre_sel = AV44TFConexionesNombre_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12JF2( )
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
            AV48PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV48PageToGo) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13JF2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E16JF2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MapeoID") == 0 )
            {
               AV27TFMapeoID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27TFMapeoID", StringUtil.LTrimStr( (decimal)(AV27TFMapeoID), 18, 0));
               AV28TFMapeoID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV28TFMapeoID_To", StringUtil.LTrimStr( (decimal)(AV28TFMapeoID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorID") == 0 )
            {
               AV29TFProveedorID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29TFProveedorID", StringUtil.LTrimStr( (decimal)(AV29TFProveedorID), 18, 0));
               AV30TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30TFProveedorID_To", StringUtil.LTrimStr( (decimal)(AV30TFProveedorID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorNombre") == 0 )
            {
               AV31TFProveedorNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFProveedorNombre", AV31TFProveedorNombre);
               AV32TFProveedorNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFProveedorNombre_Sel", AV32TFProveedorNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorEstado") == 0 )
            {
               AV33TFProveedorEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV33TFProveedorEstado_SelsJson", AV33TFProveedorEstado_SelsJson);
               AV34TFProveedorEstado_Sels.FromJSonString(AV33TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "STComerciosID") == 0 )
            {
               AV35TFSTComerciosID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV35TFSTComerciosID", StringUtil.LTrimStr( (decimal)(AV35TFSTComerciosID), 18, 0));
               AV36TFSTComerciosID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV36TFSTComerciosID_To", StringUtil.LTrimStr( (decimal)(AV36TFSTComerciosID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "STComerciosNombre") == 0 )
            {
               AV37TFSTComerciosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFSTComerciosNombre", AV37TFSTComerciosNombre);
               AV38TFSTComerciosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFSTComerciosNombre_Sel", AV38TFSTComerciosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ConexionesID") == 0 )
            {
               AV41TFConexionesID = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFConexionesID", AV41TFConexionesID);
               AV42TFConexionesID_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFConexionesID_Sel", AV42TFConexionesID_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ConexionesNombre") == 0 )
            {
               AV43TFConexionesNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFConexionesNombre", AV43TFConexionesNombre);
               AV44TFConexionesNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFConexionesNombre_Sel", AV44TFConexionesNombre_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34TFProveedorEstado_Sels", AV34TFProveedorEstado_Sels);
      }

      private void E29JF2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV54IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV55IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            cmbavGridactions.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "Integrar ordenes Fenicios", ""), "fas fa-arrow-rotate-right", "", "", "", "", "", "", ""), 0);
            if ( AV56IsAuthorized_ProveedorNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "proveedorview.aspx"+UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtProveedorNombre_Link = formatLink("proveedorview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "mapeoview.aspx"+UrlEncode(StringUtil.LTrimStr(A918MapeoID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSTComerciosNombre_Link = formatLink("mapeoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0));
      }

      protected void E17JF2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV19ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV21ColumnsSelector.FromJSonString(AV19ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "MapeoWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV19ColumnsSelectorXML)) ? "" : AV21ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E22JF2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV70DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV70DynamicFiltersEnabled2", AV70DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV65DynamicFiltersSelector1, AV66DynamicFiltersOperator1, AV67STComerciosNombre1, AV68ProveedorNombre1, AV69ConexionesNombre1, AV71DynamicFiltersSelector2, AV72DynamicFiltersOperator2, AV73STComerciosNombre2, AV74ProveedorNombre2, AV75ConexionesNombre2, AV77DynamicFiltersSelector3, AV78DynamicFiltersOperator3, AV79STComerciosNombre3, AV80ProveedorNombre3, AV81ConexionesNombre3, AV26ManageFiltersExecutionStep, AV70DynamicFiltersEnabled2, AV76DynamicFiltersEnabled3, AV21ColumnsSelector, AV84Pgmname, AV16FilterFullText, AV27TFMapeoID, AV28TFMapeoID_To, AV29TFProveedorID, AV30TFProveedorID_To, AV31TFProveedorNombre, AV32TFProveedorNombre_Sel, AV34TFProveedorEstado_Sels, AV35TFSTComerciosID, AV36TFSTComerciosID_To, AV37TFSTComerciosNombre, AV38TFSTComerciosNombre_Sel, AV41TFConexionesID, AV42TFConexionesID_Sel, AV43TFConexionesNombre, AV44TFConexionesNombre_Sel, AV11GridState, AV83DynamicFiltersIgnoreFirst, AV82DynamicFiltersRemoving, AV54IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ProveedorNombre) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E18JF2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV82DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV82DynamicFiltersRemoving", AV82DynamicFiltersRemoving);
         AV83DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV83DynamicFiltersIgnoreFirst", AV83DynamicFiltersIgnoreFirst);
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
         AV82DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV82DynamicFiltersRemoving", AV82DynamicFiltersRemoving);
         AV83DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV83DynamicFiltersIgnoreFirst", AV83DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV65DynamicFiltersSelector1, AV66DynamicFiltersOperator1, AV67STComerciosNombre1, AV68ProveedorNombre1, AV69ConexionesNombre1, AV71DynamicFiltersSelector2, AV72DynamicFiltersOperator2, AV73STComerciosNombre2, AV74ProveedorNombre2, AV75ConexionesNombre2, AV77DynamicFiltersSelector3, AV78DynamicFiltersOperator3, AV79STComerciosNombre3, AV80ProveedorNombre3, AV81ConexionesNombre3, AV26ManageFiltersExecutionStep, AV70DynamicFiltersEnabled2, AV76DynamicFiltersEnabled3, AV21ColumnsSelector, AV84Pgmname, AV16FilterFullText, AV27TFMapeoID, AV28TFMapeoID_To, AV29TFProveedorID, AV30TFProveedorID_To, AV31TFProveedorNombre, AV32TFProveedorNombre_Sel, AV34TFProveedorEstado_Sels, AV35TFSTComerciosID, AV36TFSTComerciosID_To, AV37TFSTComerciosNombre, AV38TFSTComerciosNombre_Sel, AV41TFConexionesID, AV42TFConexionesID_Sel, AV43TFConexionesNombre, AV44TFConexionesNombre_Sel, AV11GridState, AV83DynamicFiltersIgnoreFirst, AV82DynamicFiltersRemoving, AV54IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ProveedorNombre) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV71DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV77DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV65DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E23JF2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV66DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV66DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E24JF2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV76DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV76DynamicFiltersEnabled3", AV76DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV65DynamicFiltersSelector1, AV66DynamicFiltersOperator1, AV67STComerciosNombre1, AV68ProveedorNombre1, AV69ConexionesNombre1, AV71DynamicFiltersSelector2, AV72DynamicFiltersOperator2, AV73STComerciosNombre2, AV74ProveedorNombre2, AV75ConexionesNombre2, AV77DynamicFiltersSelector3, AV78DynamicFiltersOperator3, AV79STComerciosNombre3, AV80ProveedorNombre3, AV81ConexionesNombre3, AV26ManageFiltersExecutionStep, AV70DynamicFiltersEnabled2, AV76DynamicFiltersEnabled3, AV21ColumnsSelector, AV84Pgmname, AV16FilterFullText, AV27TFMapeoID, AV28TFMapeoID_To, AV29TFProveedorID, AV30TFProveedorID_To, AV31TFProveedorNombre, AV32TFProveedorNombre_Sel, AV34TFProveedorEstado_Sels, AV35TFSTComerciosID, AV36TFSTComerciosID_To, AV37TFSTComerciosNombre, AV38TFSTComerciosNombre_Sel, AV41TFConexionesID, AV42TFConexionesID_Sel, AV43TFConexionesNombre, AV44TFConexionesNombre_Sel, AV11GridState, AV83DynamicFiltersIgnoreFirst, AV82DynamicFiltersRemoving, AV54IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ProveedorNombre) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E19JF2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV82DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV82DynamicFiltersRemoving", AV82DynamicFiltersRemoving);
         AV70DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV70DynamicFiltersEnabled2", AV70DynamicFiltersEnabled2);
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
         AV82DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV82DynamicFiltersRemoving", AV82DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV65DynamicFiltersSelector1, AV66DynamicFiltersOperator1, AV67STComerciosNombre1, AV68ProveedorNombre1, AV69ConexionesNombre1, AV71DynamicFiltersSelector2, AV72DynamicFiltersOperator2, AV73STComerciosNombre2, AV74ProveedorNombre2, AV75ConexionesNombre2, AV77DynamicFiltersSelector3, AV78DynamicFiltersOperator3, AV79STComerciosNombre3, AV80ProveedorNombre3, AV81ConexionesNombre3, AV26ManageFiltersExecutionStep, AV70DynamicFiltersEnabled2, AV76DynamicFiltersEnabled3, AV21ColumnsSelector, AV84Pgmname, AV16FilterFullText, AV27TFMapeoID, AV28TFMapeoID_To, AV29TFProveedorID, AV30TFProveedorID_To, AV31TFProveedorNombre, AV32TFProveedorNombre_Sel, AV34TFProveedorEstado_Sels, AV35TFSTComerciosID, AV36TFSTComerciosID_To, AV37TFSTComerciosNombre, AV38TFSTComerciosNombre_Sel, AV41TFConexionesID, AV42TFConexionesID_Sel, AV43TFConexionesNombre, AV44TFConexionesNombre_Sel, AV11GridState, AV83DynamicFiltersIgnoreFirst, AV82DynamicFiltersRemoving, AV54IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ProveedorNombre) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV71DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV77DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV65DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E25JF2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV72DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV72DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E20JF2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV82DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV82DynamicFiltersRemoving", AV82DynamicFiltersRemoving);
         AV76DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV76DynamicFiltersEnabled3", AV76DynamicFiltersEnabled3);
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
         AV82DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV82DynamicFiltersRemoving", AV82DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV65DynamicFiltersSelector1, AV66DynamicFiltersOperator1, AV67STComerciosNombre1, AV68ProveedorNombre1, AV69ConexionesNombre1, AV71DynamicFiltersSelector2, AV72DynamicFiltersOperator2, AV73STComerciosNombre2, AV74ProveedorNombre2, AV75ConexionesNombre2, AV77DynamicFiltersSelector3, AV78DynamicFiltersOperator3, AV79STComerciosNombre3, AV80ProveedorNombre3, AV81ConexionesNombre3, AV26ManageFiltersExecutionStep, AV70DynamicFiltersEnabled2, AV76DynamicFiltersEnabled3, AV21ColumnsSelector, AV84Pgmname, AV16FilterFullText, AV27TFMapeoID, AV28TFMapeoID_To, AV29TFProveedorID, AV30TFProveedorID_To, AV31TFProveedorNombre, AV32TFProveedorNombre_Sel, AV34TFProveedorEstado_Sels, AV35TFSTComerciosID, AV36TFSTComerciosID_To, AV37TFSTComerciosNombre, AV38TFSTComerciosNombre_Sel, AV41TFConexionesID, AV42TFConexionesID_Sel, AV43TFConexionesNombre, AV44TFConexionesNombre_Sel, AV11GridState, AV83DynamicFiltersIgnoreFirst, AV82DynamicFiltersRemoving, AV54IsAuthorized_Update, AV55IsAuthorized_Delete, AV56IsAuthorized_ProveedorNombre) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV71DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV77DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV65DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E26JF2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV78DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV78DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E11JF2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("MapeoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV84Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("MapeoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV25ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "MapeoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV25ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV84Pgmname+"GridState",  AV25ManageFiltersXml) ;
               AV11GridState.FromXml(AV25ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34TFProveedorEstado_Sels", AV34TFProveedorEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV65DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV71DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV77DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E30JF2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV52GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV52GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV52GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV52GridActions == 4 )
         {
            /* Execute user subroutine: 'DO USERACTION1' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV52GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E21JF2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "mapeo.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("mapeo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14JF2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S312 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34TFProveedorEstado_Sels", AV34TFProveedorEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV65DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV71DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV77DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E15JF2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0153",(string)"",(string)"Mapeo",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0153"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S202( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "MapeoID",  "",  "Mapeo ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "ProveedorID",  "",  "Código del Proveedor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "ProveedorNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "ProveedorEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "STComerciosID",  "",  "Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "STComerciosNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "ConexionesID",  "",  "Código de Conexión",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "ConexionesNombre",  "",  "Nombre",  true,  "") ;
         GXt_char3 = AV20UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "MapeoWWColumnsSelector", out  GXt_char3) ;
         AV20UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV20UserCustomValue)) ) )
         {
            AV22ColumnsSelectorAux.FromXml(AV20UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV22ColumnsSelectorAux, ref  AV21ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV54IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMapeo_Update", out  GXt_boolean1) ;
         AV54IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV54IsAuthorized_Update", AV54IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV54IsAuthorized_Update, context));
         GXt_boolean1 = AV55IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMapeo_Delete", out  GXt_boolean1) ;
         AV55IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV55IsAuthorized_Delete", AV55IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV55IsAuthorized_Delete, context));
         GXt_boolean1 = AV63TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMapeo_Insert", out  GXt_boolean1) ;
         AV63TempBoolean = GXt_boolean1;
         if ( ! ( AV63TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV63TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean1) ;
         AV63TempBoolean = GXt_boolean1;
         if ( ! ( AV63TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Mapeo",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavStcomerciosnombre1_Visible = 0;
         AssignProp("", false, edtavStcomerciosnombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStcomerciosnombre1_Visible), 5, 0), true);
         edtavProveedornombre1_Visible = 0;
         AssignProp("", false, edtavProveedornombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre1_Visible), 5, 0), true);
         edtavConexionesnombre1_Visible = 0;
         AssignProp("", false, edtavConexionesnombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConexionesnombre1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "STCOMERCIOSNOMBRE") == 0 )
         {
            edtavStcomerciosnombre1_Visible = 1;
            AssignProp("", false, edtavStcomerciosnombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStcomerciosnombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
         {
            edtavProveedornombre1_Visible = 1;
            AssignProp("", false, edtavProveedornombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "CONEXIONESNOMBRE") == 0 )
         {
            edtavConexionesnombre1_Visible = 1;
            AssignProp("", false, edtavConexionesnombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConexionesnombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavStcomerciosnombre2_Visible = 0;
         AssignProp("", false, edtavStcomerciosnombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStcomerciosnombre2_Visible), 5, 0), true);
         edtavProveedornombre2_Visible = 0;
         AssignProp("", false, edtavProveedornombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre2_Visible), 5, 0), true);
         edtavConexionesnombre2_Visible = 0;
         AssignProp("", false, edtavConexionesnombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConexionesnombre2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "STCOMERCIOSNOMBRE") == 0 )
         {
            edtavStcomerciosnombre2_Visible = 1;
            AssignProp("", false, edtavStcomerciosnombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStcomerciosnombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
         {
            edtavProveedornombre2_Visible = 1;
            AssignProp("", false, edtavProveedornombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "CONEXIONESNOMBRE") == 0 )
         {
            edtavConexionesnombre2_Visible = 1;
            AssignProp("", false, edtavConexionesnombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConexionesnombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavStcomerciosnombre3_Visible = 0;
         AssignProp("", false, edtavStcomerciosnombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStcomerciosnombre3_Visible), 5, 0), true);
         edtavProveedornombre3_Visible = 0;
         AssignProp("", false, edtavProveedornombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre3_Visible), 5, 0), true);
         edtavConexionesnombre3_Visible = 0;
         AssignProp("", false, edtavConexionesnombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConexionesnombre3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "STCOMERCIOSNOMBRE") == 0 )
         {
            edtavStcomerciosnombre3_Visible = 1;
            AssignProp("", false, edtavStcomerciosnombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStcomerciosnombre3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
         {
            edtavProveedornombre3_Visible = 1;
            AssignProp("", false, edtavProveedornombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "CONEXIONESNOMBRE") == 0 )
         {
            edtavConexionesnombre3_Visible = 1;
            AssignProp("", false, edtavConexionesnombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConexionesnombre3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV70DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV70DynamicFiltersEnabled2", AV70DynamicFiltersEnabled2);
         AV71DynamicFiltersSelector2 = "STCOMERCIOSNOMBRE";
         AssignAttri("", false, "AV71DynamicFiltersSelector2", AV71DynamicFiltersSelector2);
         AV72DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV72DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         AV73STComerciosNombre2 = "";
         AssignAttri("", false, "AV73STComerciosNombre2", AV73STComerciosNombre2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV76DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV76DynamicFiltersEnabled3", AV76DynamicFiltersEnabled3);
         AV77DynamicFiltersSelector3 = "STCOMERCIOSNOMBRE";
         AssignAttri("", false, "AV77DynamicFiltersSelector3", AV77DynamicFiltersSelector3);
         AV78DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV78DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         AV79STComerciosNombre3 = "";
         AssignAttri("", false, "AV79STComerciosNombre3", AV79STComerciosNombre3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV24ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "MapeoWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV27TFMapeoID = 0;
         AssignAttri("", false, "AV27TFMapeoID", StringUtil.LTrimStr( (decimal)(AV27TFMapeoID), 18, 0));
         AV28TFMapeoID_To = 0;
         AssignAttri("", false, "AV28TFMapeoID_To", StringUtil.LTrimStr( (decimal)(AV28TFMapeoID_To), 18, 0));
         AV29TFProveedorID = 0;
         AssignAttri("", false, "AV29TFProveedorID", StringUtil.LTrimStr( (decimal)(AV29TFProveedorID), 18, 0));
         AV30TFProveedorID_To = 0;
         AssignAttri("", false, "AV30TFProveedorID_To", StringUtil.LTrimStr( (decimal)(AV30TFProveedorID_To), 18, 0));
         AV31TFProveedorNombre = "";
         AssignAttri("", false, "AV31TFProveedorNombre", AV31TFProveedorNombre);
         AV32TFProveedorNombre_Sel = "";
         AssignAttri("", false, "AV32TFProveedorNombre_Sel", AV32TFProveedorNombre_Sel);
         AV34TFProveedorEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35TFSTComerciosID = 0;
         AssignAttri("", false, "AV35TFSTComerciosID", StringUtil.LTrimStr( (decimal)(AV35TFSTComerciosID), 18, 0));
         AV36TFSTComerciosID_To = 0;
         AssignAttri("", false, "AV36TFSTComerciosID_To", StringUtil.LTrimStr( (decimal)(AV36TFSTComerciosID_To), 18, 0));
         AV37TFSTComerciosNombre = "";
         AssignAttri("", false, "AV37TFSTComerciosNombre", AV37TFSTComerciosNombre);
         AV38TFSTComerciosNombre_Sel = "";
         AssignAttri("", false, "AV38TFSTComerciosNombre_Sel", AV38TFSTComerciosNombre_Sel);
         AV41TFConexionesID = "";
         AssignAttri("", false, "AV41TFConexionesID", AV41TFConexionesID);
         AV42TFConexionesID_Sel = "";
         AssignAttri("", false, "AV42TFConexionesID_Sel", AV42TFConexionesID_Sel);
         AV43TFConexionesNombre = "";
         AssignAttri("", false, "AV43TFConexionesNombre", AV43TFConexionesNombre);
         AV44TFConexionesNombre_Sel = "";
         AssignAttri("", false, "AV44TFConexionesNombre_Sel", AV44TFConexionesNombre_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV65DynamicFiltersSelector1 = "STCOMERCIOSNOMBRE";
         AssignAttri("", false, "AV65DynamicFiltersSelector1", AV65DynamicFiltersSelector1);
         AV66DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV66DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         AV67STComerciosNombre1 = "";
         AssignAttri("", false, "AV67STComerciosNombre1", AV67STComerciosNombre1);
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
         GXEncryptionTmp = "mapeoview.aspx"+UrlEncode(StringUtil.LTrimStr(A918MapeoID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("mapeoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "mapeo.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A918MapeoID,18,0));
         CallWebObject(formatLink("mapeo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "mapeo.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A918MapeoID,18,0));
         CallWebObject(formatLink("mapeo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S292( )
      {
         /* 'DO USERACTION1' Routine */
         returnInSub = false;
         GXt_char3 = "";
         new integrarordenesecommerce(context ).execute( out  GXt_char3) ;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get(AV84Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV84Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV23Session.Get(AV84Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
         AV118GXV1 = 1;
         while ( AV118GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV118GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMAPEOID") == 0 )
            {
               AV27TFMapeoID = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27TFMapeoID", StringUtil.LTrimStr( (decimal)(AV27TFMapeoID), 18, 0));
               AV28TFMapeoID_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV28TFMapeoID_To", StringUtil.LTrimStr( (decimal)(AV28TFMapeoID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV29TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29TFProveedorID", StringUtil.LTrimStr( (decimal)(AV29TFProveedorID), 18, 0));
               AV30TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30TFProveedorID_To", StringUtil.LTrimStr( (decimal)(AV30TFProveedorID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV31TFProveedorNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFProveedorNombre", AV31TFProveedorNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV32TFProveedorNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFProveedorNombre_Sel", AV32TFProveedorNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV33TFProveedorEstado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFProveedorEstado_SelsJson", AV33TFProveedorEstado_SelsJson);
               AV34TFProveedorEstado_Sels.FromJSonString(AV33TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSID") == 0 )
            {
               AV35TFSTComerciosID = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV35TFSTComerciosID", StringUtil.LTrimStr( (decimal)(AV35TFSTComerciosID), 18, 0));
               AV36TFSTComerciosID_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV36TFSTComerciosID_To", StringUtil.LTrimStr( (decimal)(AV36TFSTComerciosID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE") == 0 )
            {
               AV37TFSTComerciosNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFSTComerciosNombre", AV37TFSTComerciosNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE_SEL") == 0 )
            {
               AV38TFSTComerciosNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFSTComerciosNombre_Sel", AV38TFSTComerciosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID") == 0 )
            {
               AV41TFConexionesID = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFConexionesID", AV41TFConexionesID);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID_SEL") == 0 )
            {
               AV42TFConexionesID_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFConexionesID_Sel", AV42TFConexionesID_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE") == 0 )
            {
               AV43TFConexionesNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFConexionesNombre", AV43TFConexionesNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE_SEL") == 0 )
            {
               AV44TFConexionesNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFConexionesNombre_Sel", AV44TFConexionesNombre_Sel);
            }
            AV118GXV1 = (int)(AV118GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFProveedorNombre_Sel)),  AV32TFProveedorNombre_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV34TFProveedorEstado_Sels.Count==0),  AV33TFProveedorEstado_SelsJson, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSTComerciosNombre_Sel)),  AV38TFSTComerciosNombre_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFConexionesID_Sel)),  AV42TFConexionesID_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFConexionesNombre_Sel)),  AV44TFConexionesNombre_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char3+"|"+GXt_char5+"||"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFProveedorNombre)),  AV31TFProveedorNombre, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSTComerciosNombre)),  AV37TFSTComerciosNombre, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFConexionesID)),  AV41TFConexionesID, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFConexionesNombre)),  AV43TFConexionesNombre, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = ((0==AV27TFMapeoID) ? "" : StringUtil.Str( (decimal)(AV27TFMapeoID), 18, 0))+"|"+((0==AV29TFProveedorID) ? "" : StringUtil.Str( (decimal)(AV29TFProveedorID), 18, 0))+"|"+GXt_char8+"||"+((0==AV35TFSTComerciosID) ? "" : StringUtil.Str( (decimal)(AV35TFSTComerciosID), 18, 0))+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV28TFMapeoID_To) ? "" : StringUtil.Str( (decimal)(AV28TFMapeoID_To), 18, 0))+"|"+((0==AV30TFProveedorID_To) ? "" : StringUtil.Str( (decimal)(AV30TFProveedorID_To), 18, 0))+"|||"+((0==AV36TFSTComerciosID_To) ? "" : StringUtil.Str( (decimal)(AV36TFSTComerciosID_To), 18, 0))+"|||";
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
            AV64GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV65DynamicFiltersSelector1 = AV64GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV65DynamicFiltersSelector1", AV65DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "STCOMERCIOSNOMBRE") == 0 )
            {
               AV66DynamicFiltersOperator1 = AV64GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV66DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
               AV67STComerciosNombre1 = AV64GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV67STComerciosNombre1", AV67STComerciosNombre1);
            }
            else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
            {
               AV66DynamicFiltersOperator1 = AV64GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV66DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
               AV68ProveedorNombre1 = AV64GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV68ProveedorNombre1", AV68ProveedorNombre1);
            }
            else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "CONEXIONESNOMBRE") == 0 )
            {
               AV66DynamicFiltersOperator1 = AV64GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV66DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
               AV69ConexionesNombre1 = AV64GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV69ConexionesNombre1", AV69ConexionesNombre1);
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
               AV70DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV70DynamicFiltersEnabled2", AV70DynamicFiltersEnabled2);
               AV64GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV71DynamicFiltersSelector2 = AV64GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV71DynamicFiltersSelector2", AV71DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "STCOMERCIOSNOMBRE") == 0 )
               {
                  AV72DynamicFiltersOperator2 = AV64GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV72DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
                  AV73STComerciosNombre2 = AV64GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV73STComerciosNombre2", AV73STComerciosNombre2);
               }
               else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
               {
                  AV72DynamicFiltersOperator2 = AV64GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV72DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
                  AV74ProveedorNombre2 = AV64GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV74ProveedorNombre2", AV74ProveedorNombre2);
               }
               else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "CONEXIONESNOMBRE") == 0 )
               {
                  AV72DynamicFiltersOperator2 = AV64GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV72DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
                  AV75ConexionesNombre2 = AV64GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV75ConexionesNombre2", AV75ConexionesNombre2);
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
                  AV76DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV76DynamicFiltersEnabled3", AV76DynamicFiltersEnabled3);
                  AV64GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV77DynamicFiltersSelector3 = AV64GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV77DynamicFiltersSelector3", AV77DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "STCOMERCIOSNOMBRE") == 0 )
                  {
                     AV78DynamicFiltersOperator3 = AV64GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV78DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
                     AV79STComerciosNombre3 = AV64GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV79STComerciosNombre3", AV79STComerciosNombre3);
                  }
                  else if ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
                  {
                     AV78DynamicFiltersOperator3 = AV64GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV78DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
                     AV80ProveedorNombre3 = AV64GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV80ProveedorNombre3", AV80ProveedorNombre3);
                  }
                  else if ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "CONEXIONESNOMBRE") == 0 )
                  {
                     AV78DynamicFiltersOperator3 = AV64GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV78DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
                     AV81ConexionesNombre3 = AV64GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV81ConexionesNombre3", AV81ConexionesNombre3);
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
         if ( AV82DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV23Session.Get(AV84Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMAPEOID",  context.GetMessage( "Mapeo ID", ""),  !((0==AV27TFMapeoID)&&(0==AV28TFMapeoID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV27TFMapeoID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV28TFMapeoID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPROVEEDORID",  context.GetMessage( "Código del Proveedor", ""),  !((0==AV29TFProveedorID)&&(0==AV30TFProveedorID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV29TFProveedorID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV30TFProveedorID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROVEEDORNOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFProveedorNombre)),  0,  AV31TFProveedorNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFProveedorNombre_Sel)),  AV32TFProveedorNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPROVEEDORESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV34TFProveedorEstado_Sels.Count==0),  0,  AV34TFProveedorEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFSTCOMERCIOSID",  context.GetMessage( "Comercio", ""),  !((0==AV35TFSTComerciosID)&&(0==AV36TFSTComerciosID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV35TFSTComerciosID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV36TFSTComerciosID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFSTCOMERCIOSNOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSTComerciosNombre)),  0,  AV37TFSTComerciosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSTComerciosNombre_Sel)),  AV38TFSTComerciosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCONEXIONESID",  context.GetMessage( "Código de Conexión", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFConexionesID)),  0,  AV41TFConexionesID,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFConexionesID_Sel)),  AV42TFConexionesID_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCONEXIONESNOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFConexionesNombre)),  0,  AV43TFConexionesNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFConexionesNombre_Sel)),  AV44TFConexionesNombre_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV84Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV83DynamicFiltersIgnoreFirst )
         {
            AV64GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV64GridStateDynamicFilter.gxTpr_Selected = AV65DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "STCOMERCIOSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV67STComerciosNombre1)) )
            {
               AV64GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Nombre", "");
               AV64GridStateDynamicFilter.gxTpr_Value = AV67STComerciosNombre1;
               AV64GridStateDynamicFilter.gxTpr_Operator = AV66DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV68ProveedorNombre1)) )
            {
               AV64GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Nombre", "");
               AV64GridStateDynamicFilter.gxTpr_Value = AV68ProveedorNombre1;
               AV64GridStateDynamicFilter.gxTpr_Operator = AV66DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV65DynamicFiltersSelector1, "CONEXIONESNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ConexionesNombre1)) )
            {
               AV64GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Conexiones Nombre", "");
               AV64GridStateDynamicFilter.gxTpr_Value = AV69ConexionesNombre1;
               AV64GridStateDynamicFilter.gxTpr_Operator = AV66DynamicFiltersOperator1;
            }
            if ( AV82DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV64GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV64GridStateDynamicFilter, 0);
            }
         }
         if ( AV70DynamicFiltersEnabled2 )
         {
            AV64GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV64GridStateDynamicFilter.gxTpr_Selected = AV71DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "STCOMERCIOSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV73STComerciosNombre2)) )
            {
               AV64GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Nombre", "");
               AV64GridStateDynamicFilter.gxTpr_Value = AV73STComerciosNombre2;
               AV64GridStateDynamicFilter.gxTpr_Operator = AV72DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ProveedorNombre2)) )
            {
               AV64GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Nombre", "");
               AV64GridStateDynamicFilter.gxTpr_Value = AV74ProveedorNombre2;
               AV64GridStateDynamicFilter.gxTpr_Operator = AV72DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV71DynamicFiltersSelector2, "CONEXIONESNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ConexionesNombre2)) )
            {
               AV64GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Conexiones Nombre", "");
               AV64GridStateDynamicFilter.gxTpr_Value = AV75ConexionesNombre2;
               AV64GridStateDynamicFilter.gxTpr_Operator = AV72DynamicFiltersOperator2;
            }
            if ( AV82DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV64GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV64GridStateDynamicFilter, 0);
            }
         }
         if ( AV76DynamicFiltersEnabled3 )
         {
            AV64GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV64GridStateDynamicFilter.gxTpr_Selected = AV77DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "STCOMERCIOSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV79STComerciosNombre3)) )
            {
               AV64GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Nombre", "");
               AV64GridStateDynamicFilter.gxTpr_Value = AV79STComerciosNombre3;
               AV64GridStateDynamicFilter.gxTpr_Operator = AV78DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ProveedorNombre3)) )
            {
               AV64GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Nombre", "");
               AV64GridStateDynamicFilter.gxTpr_Value = AV80ProveedorNombre3;
               AV64GridStateDynamicFilter.gxTpr_Operator = AV78DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV77DynamicFiltersSelector3, "CONEXIONESNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV81ConexionesNombre3)) )
            {
               AV64GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Conexiones Nombre", "");
               AV64GridStateDynamicFilter.gxTpr_Value = AV81ConexionesNombre3;
               AV64GridStateDynamicFilter.gxTpr_Operator = AV78DynamicFiltersOperator3;
            }
            if ( AV82DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV64GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV64GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV84Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Mapeo";
         AV23Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S302( )
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
         new mapeowwexport(context ).execute( out  AV17ExcelFilename, out  AV18ErrorMessage) ;
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

      protected void S312( )
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
         Innewwindow1_Target = formatLink("mapeowwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_105_JF2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "", true, 0, "HLP_MapeoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_stcomerciosnombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStcomerciosnombre3_Internalname, context.GetMessage( "STComercios Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStcomerciosnombre3_Internalname, StringUtil.RTrim( AV79STComerciosNombre3), StringUtil.RTrim( context.localUtil.Format( AV79STComerciosNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStcomerciosnombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavStcomerciosnombre3_Visible, edtavStcomerciosnombre3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_proveedornombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProveedornombre3_Internalname, context.GetMessage( "Proveedor Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProveedornombre3_Internalname, StringUtil.RTrim( AV80ProveedorNombre3), StringUtil.RTrim( context.localUtil.Format( AV80ProveedorNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProveedornombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavProveedornombre3_Visible, edtavProveedornombre3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conexionesnombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConexionesnombre3_Internalname, context.GetMessage( "Conexiones Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConexionesnombre3_Internalname, StringUtil.RTrim( AV81ConexionesNombre3), StringUtil.RTrim( context.localUtil.Format( AV81ConexionesNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConexionesnombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavConexionesnombre3_Visible, edtavConexionesnombre3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MapeoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_105_JF2e( true) ;
         }
         else
         {
            wb_table4_105_JF2e( false) ;
         }
      }

      protected void wb_table3_77_JF2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", true, 0, "HLP_MapeoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_stcomerciosnombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStcomerciosnombre2_Internalname, context.GetMessage( "STComercios Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStcomerciosnombre2_Internalname, StringUtil.RTrim( AV73STComerciosNombre2), StringUtil.RTrim( context.localUtil.Format( AV73STComerciosNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStcomerciosnombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavStcomerciosnombre2_Visible, edtavStcomerciosnombre2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_proveedornombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProveedornombre2_Internalname, context.GetMessage( "Proveedor Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProveedornombre2_Internalname, StringUtil.RTrim( AV74ProveedorNombre2), StringUtil.RTrim( context.localUtil.Format( AV74ProveedorNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProveedornombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavProveedornombre2_Visible, edtavProveedornombre2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conexionesnombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConexionesnombre2_Internalname, context.GetMessage( "Conexiones Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConexionesnombre2_Internalname, StringUtil.RTrim( AV75ConexionesNombre2), StringUtil.RTrim( context.localUtil.Format( AV75ConexionesNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConexionesnombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavConexionesnombre2_Visible, edtavConexionesnombre2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MapeoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MapeoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_77_JF2e( true) ;
         }
         else
         {
            wb_table3_77_JF2e( false) ;
         }
      }

      protected void wb_table2_49_JF2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_MapeoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_stcomerciosnombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStcomerciosnombre1_Internalname, context.GetMessage( "STComercios Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStcomerciosnombre1_Internalname, StringUtil.RTrim( AV67STComerciosNombre1), StringUtil.RTrim( context.localUtil.Format( AV67STComerciosNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStcomerciosnombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavStcomerciosnombre1_Visible, edtavStcomerciosnombre1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_proveedornombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProveedornombre1_Internalname, context.GetMessage( "Proveedor Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProveedornombre1_Internalname, StringUtil.RTrim( AV68ProveedorNombre1), StringUtil.RTrim( context.localUtil.Format( AV68ProveedorNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProveedornombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavProveedornombre1_Visible, edtavProveedornombre1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_conexionesnombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConexionesnombre1_Internalname, context.GetMessage( "Conexiones Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConexionesnombre1_Internalname, StringUtil.RTrim( AV69ConexionesNombre1), StringUtil.RTrim( context.localUtil.Format( AV69ConexionesNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConexionesnombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavConexionesnombre1_Visible, edtavConexionesnombre1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MapeoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_MapeoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_JF2e( true) ;
         }
         else
         {
            wb_table2_49_JF2e( false) ;
         }
      }

      protected void wb_table1_25_JF2( bool wbgen )
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
            wb_table5_30_JF2( true) ;
         }
         else
         {
            wb_table5_30_JF2( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_JF2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_JF2e( true) ;
         }
         else
         {
            wb_table1_25_JF2e( false) ;
         }
      }

      protected void wb_table5_30_JF2( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_MapeoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_JF2e( true) ;
         }
         else
         {
            wb_table5_30_JF2e( false) ;
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
         PAJF2( ) ;
         WSJF2( ) ;
         WEJF2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320182333", true, true, false);
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
         context.AddJavascriptSource("mapeoww.js", "?20269320182334", false, true, false);
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

      protected void SubsflControlProps_1292( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_129_idx;
         edtMapeoID_Internalname = "MAPEOID_"+sGXsfl_129_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_129_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_129_idx;
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO_"+sGXsfl_129_idx;
         edtSTComerciosID_Internalname = "STCOMERCIOSID_"+sGXsfl_129_idx;
         edtSTComerciosNombre_Internalname = "STCOMERCIOSNOMBRE_"+sGXsfl_129_idx;
         edtConexionesID_Internalname = "CONEXIONESID_"+sGXsfl_129_idx;
         edtConexionesNombre_Internalname = "CONEXIONESNOMBRE_"+sGXsfl_129_idx;
      }

      protected void SubsflControlProps_fel_1292( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_129_fel_idx;
         edtMapeoID_Internalname = "MAPEOID_"+sGXsfl_129_fel_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_129_fel_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_129_fel_idx;
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO_"+sGXsfl_129_fel_idx;
         edtSTComerciosID_Internalname = "STCOMERCIOSID_"+sGXsfl_129_fel_idx;
         edtSTComerciosNombre_Internalname = "STCOMERCIOSNOMBRE_"+sGXsfl_129_fel_idx;
         edtConexionesID_Internalname = "CONEXIONESID_"+sGXsfl_129_fel_idx;
         edtConexionesNombre_Internalname = "CONEXIONESNOMBRE_"+sGXsfl_129_fel_idx;
      }

      protected void sendrow_1292( )
      {
         sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
         SubsflControlProps_1292( ) ;
         WBJF0( ) ;
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
                  AV52GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_129_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_129_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtMapeoID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMapeoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A918MapeoID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A918MapeoID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMapeoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMapeoID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtProveedorID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProveedorID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProveedorNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorNombre_Internalname,StringUtil.RTrim( A282ProveedorNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProveedorNombre_Link,(string)"",(string)"",(string)"",(string)edtProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProveedorNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbProveedorEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            GXCCtl = "PROVEEDORESTADO_" + sGXsfl_129_idx;
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
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorEstado,(string)cmbProveedorEstado_Internalname,StringUtil.RTrim( A344ProveedorEstado),(short)1,(string)cmbProveedorEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbProveedorEstado.Visible,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
            AssignProp("", false, cmbProveedorEstado_Internalname, "Values", (string)(cmbProveedorEstado.ToJavascriptSource()), !bGXsfl_129_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSTComerciosID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSTComerciosID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A919STComerciosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A919STComerciosID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSTComerciosID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSTComerciosID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSTComerciosNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSTComerciosNombre_Internalname,StringUtil.RTrim( A923STComerciosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSTComerciosNombre_Link,(string)"",(string)"",(string)"",(string)edtSTComerciosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSTComerciosNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtConexionesID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConexionesID_Internalname,StringUtil.RTrim( A552ConexionesID),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConexionesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtConexionesID_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtConexionesNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConexionesNombre_Internalname,StringUtil.RTrim( A556ConexionesNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConexionesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtConexionesNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashesJF2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("STCOMERCIOSNOMBRE", context.GetMessage( "Nombre", ""), 0);
         cmbavDynamicfiltersselector1.addItem("PROVEEDORNOMBRE", context.GetMessage( "Proveedor Nombre", ""), 0);
         cmbavDynamicfiltersselector1.addItem("CONEXIONESNOMBRE", context.GetMessage( "Conexiones Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV65DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV65DynamicFiltersSelector1);
            AssignAttri("", false, "AV65DynamicFiltersSelector1", AV65DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV66DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV66DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV66DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV66DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("STCOMERCIOSNOMBRE", context.GetMessage( "Nombre", ""), 0);
         cmbavDynamicfiltersselector2.addItem("PROVEEDORNOMBRE", context.GetMessage( "Proveedor Nombre", ""), 0);
         cmbavDynamicfiltersselector2.addItem("CONEXIONESNOMBRE", context.GetMessage( "Conexiones Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV71DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV71DynamicFiltersSelector2);
            AssignAttri("", false, "AV71DynamicFiltersSelector2", AV71DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV72DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV72DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV72DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV72DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("STCOMERCIOSNOMBRE", context.GetMessage( "Nombre", ""), 0);
         cmbavDynamicfiltersselector3.addItem("PROVEEDORNOMBRE", context.GetMessage( "Proveedor Nombre", ""), 0);
         cmbavDynamicfiltersselector3.addItem("CONEXIONESNOMBRE", context.GetMessage( "Conexiones Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV77DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV77DynamicFiltersSelector3);
            AssignAttri("", false, "AV77DynamicFiltersSelector3", AV77DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV78DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV78DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV78DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV78DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_129_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV52GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
         }
         GXCCtl = "PROVEEDORESTADO_" + sGXsfl_129_idx;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMapeoID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mapeo ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código del Proveedor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbProveedorEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSTComerciosID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comercio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSTComerciosNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtConexionesID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código de Conexión", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtConexionesNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A918MapeoID), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMapeoID_Visible), 5, 0, ".", "")));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A344ProveedorEstado)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorEstado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A919STComerciosID), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSTComerciosID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A923STComerciosNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSTComerciosNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSTComerciosNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A552ConexionesID)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A556ConexionesNombre)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtConexionesNombre_Visible), 5, 0, ".", "")));
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
         edtavStcomerciosnombre1_Internalname = "vSTCOMERCIOSNOMBRE1";
         cellFilter_stcomerciosnombre1_cell_Internalname = "FILTER_STCOMERCIOSNOMBRE1_CELL";
         edtavProveedornombre1_Internalname = "vPROVEEDORNOMBRE1";
         cellFilter_proveedornombre1_cell_Internalname = "FILTER_PROVEEDORNOMBRE1_CELL";
         edtavConexionesnombre1_Internalname = "vCONEXIONESNOMBRE1";
         cellFilter_conexionesnombre1_cell_Internalname = "FILTER_CONEXIONESNOMBRE1_CELL";
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
         edtavStcomerciosnombre2_Internalname = "vSTCOMERCIOSNOMBRE2";
         cellFilter_stcomerciosnombre2_cell_Internalname = "FILTER_STCOMERCIOSNOMBRE2_CELL";
         edtavProveedornombre2_Internalname = "vPROVEEDORNOMBRE2";
         cellFilter_proveedornombre2_cell_Internalname = "FILTER_PROVEEDORNOMBRE2_CELL";
         edtavConexionesnombre2_Internalname = "vCONEXIONESNOMBRE2";
         cellFilter_conexionesnombre2_cell_Internalname = "FILTER_CONEXIONESNOMBRE2_CELL";
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
         edtavStcomerciosnombre3_Internalname = "vSTCOMERCIOSNOMBRE3";
         cellFilter_stcomerciosnombre3_cell_Internalname = "FILTER_STCOMERCIOSNOMBRE3_CELL";
         edtavProveedornombre3_Internalname = "vPROVEEDORNOMBRE3";
         cellFilter_proveedornombre3_cell_Internalname = "FILTER_PROVEEDORNOMBRE3_CELL";
         edtavConexionesnombre3_Internalname = "vCONEXIONESNOMBRE3";
         cellFilter_conexionesnombre3_cell_Internalname = "FILTER_CONEXIONESNOMBRE3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtMapeoID_Internalname = "MAPEOID";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO";
         edtSTComerciosID_Internalname = "STCOMERCIOSID";
         edtSTComerciosNombre_Internalname = "STCOMERCIOSNOMBRE";
         edtConexionesID_Internalname = "CONEXIONESID";
         edtConexionesNombre_Internalname = "CONEXIONESNOMBRE";
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
         edtConexionesNombre_Jsonclick = "";
         edtConexionesID_Jsonclick = "";
         edtSTComerciosNombre_Jsonclick = "";
         edtSTComerciosNombre_Link = "";
         edtSTComerciosID_Jsonclick = "";
         cmbProveedorEstado_Jsonclick = "";
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Link = "";
         edtProveedorID_Jsonclick = "";
         edtMapeoID_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavConexionesnombre1_Jsonclick = "";
         edtavConexionesnombre1_Enabled = 1;
         edtavProveedornombre1_Jsonclick = "";
         edtavProveedornombre1_Enabled = 1;
         edtavStcomerciosnombre1_Jsonclick = "";
         edtavStcomerciosnombre1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavConexionesnombre2_Jsonclick = "";
         edtavConexionesnombre2_Enabled = 1;
         edtavProveedornombre2_Jsonclick = "";
         edtavProveedornombre2_Enabled = 1;
         edtavStcomerciosnombre2_Jsonclick = "";
         edtavStcomerciosnombre2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavConexionesnombre3_Jsonclick = "";
         edtavConexionesnombre3_Enabled = 1;
         edtavProveedornombre3_Jsonclick = "";
         edtavProveedornombre3_Enabled = 1;
         edtavStcomerciosnombre3_Jsonclick = "";
         edtavStcomerciosnombre3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavConexionesnombre3_Visible = 1;
         edtavProveedornombre3_Visible = 1;
         edtavStcomerciosnombre3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavConexionesnombre2_Visible = 1;
         edtavProveedornombre2_Visible = 1;
         edtavStcomerciosnombre2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavConexionesnombre1_Visible = 1;
         edtavProveedornombre1_Visible = 1;
         edtavStcomerciosnombre1_Visible = 1;
         edtConexionesNombre_Visible = -1;
         edtConexionesID_Visible = -1;
         edtSTComerciosNombre_Visible = -1;
         edtSTComerciosID_Visible = -1;
         cmbProveedorEstado.Visible = -1;
         edtProveedorNombre_Visible = -1;
         edtProveedorID_Visible = -1;
         edtMapeoID_Visible = -1;
         edtConexionesNombre_Enabled = 0;
         edtConexionesID_Enabled = 0;
         edtSTComerciosNombre_Enabled = 0;
         edtSTComerciosID_Enabled = 0;
         cmbProveedorEstado.Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtMapeoID_Enabled = 0;
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
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;";
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
         Ddo_grid_Format = "18.0|18.0|||18.0|||";
         Ddo_grid_Datalistproc = "MapeoWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||HAB:Habilitado,DES:Deshabilitado,PEN:Pendiente||||";
         Ddo_grid_Allowmultipleselection = "|||T||||";
         Ddo_grid_Datalisttype = "||Dynamic|FixedValues||Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "||T|T||T|T|T";
         Ddo_grid_Filterisrange = "T|T|||T|||";
         Ddo_grid_Filtertype = "Numeric|Numeric|Character||Numeric|Character|Character|Character";
         Ddo_grid_Includefilter = "T|T|T||T|T|T|T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8";
         Ddo_grid_Columnids = "1:MapeoID|2:ProveedorID|3:ProveedorNombre|4:ProveedorEstado|5:STComerciosID|6:STComerciosNombre|7:ConexionesID|8:ConexionesNombre";
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
         Form.Caption = context.GetMessage( " Mapeo", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMapeoID_Visible',ctrl:'MAPEOID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'cmbProveedorEstado'},{av:'edtSTComerciosID_Visible',ctrl:'STCOMERCIOSID',prop:'Visible'},{av:'edtSTComerciosNombre_Visible',ctrl:'STCOMERCIOSNOMBRE',prop:'Visible'},{av:'edtConexionesID_Visible',ctrl:'CONEXIONESID',prop:'Visible'},{av:'edtConexionesNombre_Visible',ctrl:'CONEXIONESNOMBRE',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12JF2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMapeoID_Visible',ctrl:'MAPEOID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'cmbProveedorEstado'},{av:'edtSTComerciosID_Visible',ctrl:'STCOMERCIOSID',prop:'Visible'},{av:'edtSTComerciosNombre_Visible',ctrl:'STCOMERCIOSNOMBRE',prop:'Visible'},{av:'edtConexionesID_Visible',ctrl:'CONEXIONESID',prop:'Visible'},{av:'edtConexionesNombre_Visible',ctrl:'CONEXIONESNOMBRE',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13JF2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E16JF2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFProveedorEstado_SelsJson',fld:'vTFPROVEEDORESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E29JF2',iparms:[{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A918MapeoID',fld:'MAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV52GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtProveedorNombre_Link',ctrl:'PROVEEDORNOMBRE',prop:'Link'},{av:'edtSTComerciosNombre_Link',ctrl:'STCOMERCIOSNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E17JF2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtMapeoID_Visible',ctrl:'MAPEOID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'cmbProveedorEstado'},{av:'edtSTComerciosID_Visible',ctrl:'STCOMERCIOSID',prop:'Visible'},{av:'edtSTComerciosNombre_Visible',ctrl:'STCOMERCIOSNOMBRE',prop:'Visible'},{av:'edtConexionesID_Visible',ctrl:'CONEXIONESID',prop:'Visible'},{av:'edtConexionesNombre_Visible',ctrl:'CONEXIONESNOMBRE',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E22JF2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMapeoID_Visible',ctrl:'MAPEOID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'cmbProveedorEstado'},{av:'edtSTComerciosID_Visible',ctrl:'STCOMERCIOSID',prop:'Visible'},{av:'edtSTComerciosNombre_Visible',ctrl:'STCOMERCIOSNOMBRE',prop:'Visible'},{av:'edtConexionesID_Visible',ctrl:'CONEXIONESID',prop:'Visible'},{av:'edtConexionesNombre_Visible',ctrl:'CONEXIONESNOMBRE',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E18JF2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'edtavStcomerciosnombre2_Visible',ctrl:'vSTCOMERCIOSNOMBRE2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavConexionesnombre2_Visible',ctrl:'vCONEXIONESNOMBRE2',prop:'Visible'},{av:'edtavStcomerciosnombre3_Visible',ctrl:'vSTCOMERCIOSNOMBRE3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavConexionesnombre3_Visible',ctrl:'vCONEXIONESNOMBRE3',prop:'Visible'},{av:'edtavStcomerciosnombre1_Visible',ctrl:'vSTCOMERCIOSNOMBRE1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavConexionesnombre1_Visible',ctrl:'vCONEXIONESNOMBRE1',prop:'Visible'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMapeoID_Visible',ctrl:'MAPEOID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'cmbProveedorEstado'},{av:'edtSTComerciosID_Visible',ctrl:'STCOMERCIOSID',prop:'Visible'},{av:'edtSTComerciosNombre_Visible',ctrl:'STCOMERCIOSNOMBRE',prop:'Visible'},{av:'edtConexionesID_Visible',ctrl:'CONEXIONESID',prop:'Visible'},{av:'edtConexionesNombre_Visible',ctrl:'CONEXIONESNOMBRE',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E23JF2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'edtavStcomerciosnombre1_Visible',ctrl:'vSTCOMERCIOSNOMBRE1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavConexionesnombre1_Visible',ctrl:'vCONEXIONESNOMBRE1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E24JF2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMapeoID_Visible',ctrl:'MAPEOID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'cmbProveedorEstado'},{av:'edtSTComerciosID_Visible',ctrl:'STCOMERCIOSID',prop:'Visible'},{av:'edtSTComerciosNombre_Visible',ctrl:'STCOMERCIOSNOMBRE',prop:'Visible'},{av:'edtConexionesID_Visible',ctrl:'CONEXIONESID',prop:'Visible'},{av:'edtConexionesNombre_Visible',ctrl:'CONEXIONESNOMBRE',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E19JF2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'edtavStcomerciosnombre2_Visible',ctrl:'vSTCOMERCIOSNOMBRE2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavConexionesnombre2_Visible',ctrl:'vCONEXIONESNOMBRE2',prop:'Visible'},{av:'edtavStcomerciosnombre3_Visible',ctrl:'vSTCOMERCIOSNOMBRE3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavConexionesnombre3_Visible',ctrl:'vCONEXIONESNOMBRE3',prop:'Visible'},{av:'edtavStcomerciosnombre1_Visible',ctrl:'vSTCOMERCIOSNOMBRE1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavConexionesnombre1_Visible',ctrl:'vCONEXIONESNOMBRE1',prop:'Visible'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMapeoID_Visible',ctrl:'MAPEOID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'cmbProveedorEstado'},{av:'edtSTComerciosID_Visible',ctrl:'STCOMERCIOSID',prop:'Visible'},{av:'edtSTComerciosNombre_Visible',ctrl:'STCOMERCIOSNOMBRE',prop:'Visible'},{av:'edtConexionesID_Visible',ctrl:'CONEXIONESID',prop:'Visible'},{av:'edtConexionesNombre_Visible',ctrl:'CONEXIONESNOMBRE',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E25JF2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'edtavStcomerciosnombre2_Visible',ctrl:'vSTCOMERCIOSNOMBRE2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavConexionesnombre2_Visible',ctrl:'vCONEXIONESNOMBRE2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E20JF2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'edtavStcomerciosnombre2_Visible',ctrl:'vSTCOMERCIOSNOMBRE2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavConexionesnombre2_Visible',ctrl:'vCONEXIONESNOMBRE2',prop:'Visible'},{av:'edtavStcomerciosnombre3_Visible',ctrl:'vSTCOMERCIOSNOMBRE3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavConexionesnombre3_Visible',ctrl:'vCONEXIONESNOMBRE3',prop:'Visible'},{av:'edtavStcomerciosnombre1_Visible',ctrl:'vSTCOMERCIOSNOMBRE1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavConexionesnombre1_Visible',ctrl:'vCONEXIONESNOMBRE1',prop:'Visible'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMapeoID_Visible',ctrl:'MAPEOID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'cmbProveedorEstado'},{av:'edtSTComerciosID_Visible',ctrl:'STCOMERCIOSID',prop:'Visible'},{av:'edtSTComerciosNombre_Visible',ctrl:'STCOMERCIOSNOMBRE',prop:'Visible'},{av:'edtConexionesID_Visible',ctrl:'CONEXIONESID',prop:'Visible'},{av:'edtConexionesNombre_Visible',ctrl:'CONEXIONESNOMBRE',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E26JF2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtavStcomerciosnombre3_Visible',ctrl:'vSTCOMERCIOSNOMBRE3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavConexionesnombre3_Visible',ctrl:'vCONEXIONESNOMBRE3',prop:'Visible'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11JF2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV33TFProveedorEstado_SelsJson',fld:'vTFPROVEEDORESTADO_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV33TFProveedorEstado_SelsJson',fld:'vTFPROVEEDORESTADO_SELSJSON',pic:'',type:'vchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'edtavStcomerciosnombre1_Visible',ctrl:'vSTCOMERCIOSNOMBRE1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavConexionesnombre1_Visible',ctrl:'vCONEXIONESNOMBRE1',prop:'Visible'},{av:'edtavStcomerciosnombre2_Visible',ctrl:'vSTCOMERCIOSNOMBRE2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavConexionesnombre2_Visible',ctrl:'vCONEXIONESNOMBRE2',prop:'Visible'},{av:'edtavStcomerciosnombre3_Visible',ctrl:'vSTCOMERCIOSNOMBRE3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavConexionesnombre3_Visible',ctrl:'vCONEXIONESNOMBRE3',prop:'Visible'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMapeoID_Visible',ctrl:'MAPEOID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'cmbProveedorEstado'},{av:'edtSTComerciosID_Visible',ctrl:'STCOMERCIOSID',prop:'Visible'},{av:'edtSTComerciosNombre_Visible',ctrl:'STCOMERCIOSNOMBRE',prop:'Visible'},{av:'edtConexionesID_Visible',ctrl:'CONEXIONESID',prop:'Visible'},{av:'edtConexionesNombre_Visible',ctrl:'CONEXIONESNOMBRE',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E30JF2',iparms:[{av:'cmbavGridactions'},{av:'AV52GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A918MapeoID',fld:'MAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV52GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E21JF2',iparms:[{av:'A918MapeoID',fld:'MAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14JF2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV33TFProveedorEstado_SelsJson',fld:'vTFPROVEEDORESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV65DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV66DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV67STComerciosNombre1',fld:'vSTCOMERCIOSNOMBRE1',pic:'',type:'char'},{av:'AV68ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'AV69ConexionesNombre1',fld:'vCONEXIONESNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV71DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV72DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV73STComerciosNombre2',fld:'vSTCOMERCIOSNOMBRE2',pic:'',type:'char'},{av:'AV74ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV75ConexionesNombre2',fld:'vCONEXIONESNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV77DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV78DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV79STComerciosNombre3',fld:'vSTCOMERCIOSNOMBRE3',pic:'',type:'char'},{av:'AV80ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV81ConexionesNombre3',fld:'vCONEXIONESNOMBRE3',pic:'',type:'char'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV76DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV27TFMapeoID',fld:'vTFMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV28TFMapeoID_To',fld:'vTFMAPEOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV32TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV34TFProveedorEstado_Sels',fld:'vTFPROVEEDORESTADO_SELS',pic:''},{av:'AV35TFSTComerciosID',fld:'vTFSTCOMERCIOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36TFSTComerciosID_To',fld:'vTFSTCOMERCIOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV37TFSTComerciosNombre',fld:'vTFSTCOMERCIOSNOMBRE',pic:'',type:'char'},{av:'AV38TFSTComerciosNombre_Sel',fld:'vTFSTCOMERCIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFConexionesID',fld:'vTFCONEXIONESID',pic:'',type:'char'},{av:'AV42TFConexionesID_Sel',fld:'vTFCONEXIONESID_SEL',pic:'',type:'char'},{av:'AV43TFConexionesNombre',fld:'vTFCONEXIONESNOMBRE',pic:'',type:'char'},{av:'AV44TFConexionesNombre_Sel',fld:'vTFCONEXIONESNOMBRE_SEL',pic:'',type:'char'},{av:'AV83DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV82DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV54IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV55IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV56IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV33TFProveedorEstado_SelsJson',fld:'vTFPROVEEDORESTADO_SELSJSON',pic:'',type:'vchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavStcomerciosnombre1_Visible',ctrl:'vSTCOMERCIOSNOMBRE1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavConexionesnombre1_Visible',ctrl:'vCONEXIONESNOMBRE1',prop:'Visible'},{av:'edtavStcomerciosnombre2_Visible',ctrl:'vSTCOMERCIOSNOMBRE2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavConexionesnombre2_Visible',ctrl:'vCONEXIONESNOMBRE2',prop:'Visible'},{av:'edtavStcomerciosnombre3_Visible',ctrl:'vSTCOMERCIOSNOMBRE3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavConexionesnombre3_Visible',ctrl:'vCONEXIONESNOMBRE3',prop:'Visible'},{av:'edtMapeoID_Visible',ctrl:'MAPEOID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'cmbProveedorEstado'},{av:'edtSTComerciosID_Visible',ctrl:'STCOMERCIOSID',prop:'Visible'},{av:'edtSTComerciosNombre_Visible',ctrl:'STCOMERCIOSNOMBRE',prop:'Visible'},{av:'edtConexionesID_Visible',ctrl:'CONEXIONESID',prop:'Visible'},{av:'edtConexionesNombre_Visible',ctrl:'CONEXIONESNOMBRE',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E15JF2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALID_MAPEOID","{handler:'Valid_Mapeoid',iparms:[]");
         setEventMetadata("VALID_MAPEOID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORNOMBRE","{handler:'Valid_Proveedornombre',iparms:[]");
         setEventMetadata("VALID_PROVEEDORNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORESTADO","{handler:'Valid_Proveedorestado',iparms:[]");
         setEventMetadata("VALID_PROVEEDORESTADO",",oparms:[]}");
         setEventMetadata("VALID_STCOMERCIOSID","{handler:'Valid_Stcomerciosid',iparms:[]");
         setEventMetadata("VALID_STCOMERCIOSID",",oparms:[]}");
         setEventMetadata("VALID_STCOMERCIOSNOMBRE","{handler:'Valid_Stcomerciosnombre',iparms:[]");
         setEventMetadata("VALID_STCOMERCIOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_CONEXIONESID","{handler:'Valid_Conexionesid',iparms:[]");
         setEventMetadata("VALID_CONEXIONESID",",oparms:[]}");
         setEventMetadata("VALID_CONEXIONESNOMBRE","{handler:'Valid_Conexionesnombre',iparms:[]");
         setEventMetadata("VALID_CONEXIONESNOMBRE",",oparms:[]}");
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
         AV65DynamicFiltersSelector1 = "";
         AV67STComerciosNombre1 = "";
         AV68ProveedorNombre1 = "";
         AV69ConexionesNombre1 = "";
         AV71DynamicFiltersSelector2 = "";
         AV73STComerciosNombre2 = "";
         AV74ProveedorNombre2 = "";
         AV75ConexionesNombre2 = "";
         AV77DynamicFiltersSelector3 = "";
         AV79STComerciosNombre3 = "";
         AV80ProveedorNombre3 = "";
         AV81ConexionesNombre3 = "";
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV84Pgmname = "";
         AV16FilterFullText = "";
         AV31TFProveedorNombre = "";
         AV32TFProveedorNombre_Sel = "";
         AV34TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         AV37TFSTComerciosNombre = "";
         AV38TFSTComerciosNombre_Sel = "";
         AV41TFConexionesID = "";
         AV42TFConexionesID_Sel = "";
         AV43TFConexionesNombre = "";
         AV44TFConexionesNombre_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV51GridAppliedFilters = "";
         AV61AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV47DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV33TFProveedorEstado_SelsJson = "";
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
         A282ProveedorNombre = "";
         A344ProveedorEstado = "";
         A923STComerciosNombre = "";
         A552ConexionesID = "";
         A556ConexionesNombre = "";
         AV85Mapeowwds_1_filterfulltext = "";
         AV86Mapeowwds_2_dynamicfiltersselector1 = "";
         AV88Mapeowwds_4_stcomerciosnombre1 = "";
         AV89Mapeowwds_5_proveedornombre1 = "";
         AV90Mapeowwds_6_conexionesnombre1 = "";
         AV92Mapeowwds_8_dynamicfiltersselector2 = "";
         AV94Mapeowwds_10_stcomerciosnombre2 = "";
         AV95Mapeowwds_11_proveedornombre2 = "";
         AV96Mapeowwds_12_conexionesnombre2 = "";
         AV98Mapeowwds_14_dynamicfiltersselector3 = "";
         AV100Mapeowwds_16_stcomerciosnombre3 = "";
         AV101Mapeowwds_17_proveedornombre3 = "";
         AV102Mapeowwds_18_conexionesnombre3 = "";
         AV107Mapeowwds_23_tfproveedornombre = "";
         AV108Mapeowwds_24_tfproveedornombre_sel = "";
         AV109Mapeowwds_25_tfproveedorestado_sels = new GxSimpleCollection<string>();
         AV112Mapeowwds_28_tfstcomerciosnombre = "";
         AV113Mapeowwds_29_tfstcomerciosnombre_sel = "";
         AV114Mapeowwds_30_tfconexionesid = "";
         AV115Mapeowwds_31_tfconexionesid_sel = "";
         AV116Mapeowwds_32_tfconexionesnombre = "";
         AV117Mapeowwds_33_tfconexionesnombre_sel = "";
         lV85Mapeowwds_1_filterfulltext = "";
         lV88Mapeowwds_4_stcomerciosnombre1 = "";
         lV89Mapeowwds_5_proveedornombre1 = "";
         lV90Mapeowwds_6_conexionesnombre1 = "";
         lV94Mapeowwds_10_stcomerciosnombre2 = "";
         lV95Mapeowwds_11_proveedornombre2 = "";
         lV96Mapeowwds_12_conexionesnombre2 = "";
         lV100Mapeowwds_16_stcomerciosnombre3 = "";
         lV101Mapeowwds_17_proveedornombre3 = "";
         lV102Mapeowwds_18_conexionesnombre3 = "";
         lV107Mapeowwds_23_tfproveedornombre = "";
         lV112Mapeowwds_28_tfstcomerciosnombre = "";
         lV114Mapeowwds_30_tfconexionesid = "";
         lV116Mapeowwds_32_tfconexionesnombre = "";
         H00JF2_A556ConexionesNombre = new string[] {""} ;
         H00JF2_n556ConexionesNombre = new bool[] {false} ;
         H00JF2_A552ConexionesID = new string[] {""} ;
         H00JF2_n552ConexionesID = new bool[] {false} ;
         H00JF2_A923STComerciosNombre = new string[] {""} ;
         H00JF2_A919STComerciosID = new long[1] ;
         H00JF2_n919STComerciosID = new bool[] {false} ;
         H00JF2_A344ProveedorEstado = new string[] {""} ;
         H00JF2_A282ProveedorNombre = new string[] {""} ;
         H00JF2_A133ProveedorID = new long[1] ;
         H00JF2_A918MapeoID = new long[1] ;
         H00JF3_A556ConexionesNombre = new string[] {""} ;
         H00JF3_n556ConexionesNombre = new bool[] {false} ;
         H00JF3_A552ConexionesID = new string[] {""} ;
         H00JF3_n552ConexionesID = new bool[] {false} ;
         H00JF3_A923STComerciosNombre = new string[] {""} ;
         H00JF3_A919STComerciosID = new long[1] ;
         H00JF3_n919STComerciosID = new bool[] {false} ;
         H00JF3_A344ProveedorEstado = new string[] {""} ;
         H00JF3_A282ProveedorNombre = new string[] {""} ;
         H00JF3_A133ProveedorID = new long[1] ;
         H00JF3_A918MapeoID = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV62AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         GXt_char3 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV64GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV17ExcelFilename = "";
         AV18ErrorMessage = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mapeoww__default(),
            new Object[][] {
                new Object[] {
               H00JF2_A556ConexionesNombre, H00JF2_n556ConexionesNombre, H00JF2_A552ConexionesID, H00JF2_n552ConexionesID, H00JF2_A923STComerciosNombre, H00JF2_A919STComerciosID, H00JF2_n919STComerciosID, H00JF2_A344ProveedorEstado, H00JF2_A282ProveedorNombre, H00JF2_A133ProveedorID,
               H00JF2_A918MapeoID
               }
               , new Object[] {
               H00JF3_A556ConexionesNombre, H00JF3_n556ConexionesNombre, H00JF3_A552ConexionesID, H00JF3_n552ConexionesID, H00JF3_A923STComerciosNombre, H00JF3_A919STComerciosID, H00JF3_n919STComerciosID, H00JF3_A344ProveedorEstado, H00JF3_A282ProveedorNombre, H00JF3_A133ProveedorID,
               H00JF3_A918MapeoID
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV84Pgmname = "MapeoWW";
         /* GeneXus formulas. */
         AV84Pgmname = "MapeoWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV66DynamicFiltersOperator1 ;
      private short AV72DynamicFiltersOperator2 ;
      private short AV78DynamicFiltersOperator3 ;
      private short AV26ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV52GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV87Mapeowwds_3_dynamicfiltersoperator1 ;
      private short AV93Mapeowwds_9_dynamicfiltersoperator2 ;
      private short AV99Mapeowwds_15_dynamicfiltersoperator3 ;
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
      private int AV109Mapeowwds_25_tfproveedorestado_sels_Count ;
      private int edtMapeoID_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtSTComerciosID_Enabled ;
      private int edtSTComerciosNombre_Enabled ;
      private int edtConexionesID_Enabled ;
      private int edtConexionesNombre_Enabled ;
      private int edtMapeoID_Visible ;
      private int edtProveedorID_Visible ;
      private int edtProveedorNombre_Visible ;
      private int edtSTComerciosID_Visible ;
      private int edtSTComerciosNombre_Visible ;
      private int edtConexionesID_Visible ;
      private int edtConexionesNombre_Visible ;
      private int AV48PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavStcomerciosnombre1_Visible ;
      private int edtavProveedornombre1_Visible ;
      private int edtavConexionesnombre1_Visible ;
      private int edtavStcomerciosnombre2_Visible ;
      private int edtavProveedornombre2_Visible ;
      private int edtavConexionesnombre2_Visible ;
      private int edtavStcomerciosnombre3_Visible ;
      private int edtavProveedornombre3_Visible ;
      private int edtavConexionesnombre3_Visible ;
      private int AV118GXV1 ;
      private int edtavStcomerciosnombre3_Enabled ;
      private int edtavProveedornombre3_Enabled ;
      private int edtavConexionesnombre3_Enabled ;
      private int edtavStcomerciosnombre2_Enabled ;
      private int edtavProveedornombre2_Enabled ;
      private int edtavConexionesnombre2_Enabled ;
      private int edtavStcomerciosnombre1_Enabled ;
      private int edtavProveedornombre1_Enabled ;
      private int edtavConexionesnombre1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV27TFMapeoID ;
      private long AV28TFMapeoID_To ;
      private long AV29TFProveedorID ;
      private long AV30TFProveedorID_To ;
      private long AV35TFSTComerciosID ;
      private long AV36TFSTComerciosID_To ;
      private long AV49GridCurrentPage ;
      private long AV50GridPageCount ;
      private long A918MapeoID ;
      private long A133ProveedorID ;
      private long A919STComerciosID ;
      private long GRID_nCurrentRecord ;
      private long AV103Mapeowwds_19_tfmapeoid ;
      private long AV104Mapeowwds_20_tfmapeoid_to ;
      private long AV105Mapeowwds_21_tfproveedorid ;
      private long AV106Mapeowwds_22_tfproveedorid_to ;
      private long AV110Mapeowwds_26_tfstcomerciosid ;
      private long AV111Mapeowwds_27_tfstcomerciosid_to ;
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
      private string AV67STComerciosNombre1 ;
      private string AV68ProveedorNombre1 ;
      private string AV69ConexionesNombre1 ;
      private string AV73STComerciosNombre2 ;
      private string AV74ProveedorNombre2 ;
      private string AV75ConexionesNombre2 ;
      private string AV79STComerciosNombre3 ;
      private string AV80ProveedorNombre3 ;
      private string AV81ConexionesNombre3 ;
      private string AV84Pgmname ;
      private string AV31TFProveedorNombre ;
      private string AV32TFProveedorNombre_Sel ;
      private string AV37TFSTComerciosNombre ;
      private string AV38TFSTComerciosNombre_Sel ;
      private string AV41TFConexionesID ;
      private string AV42TFConexionesID_Sel ;
      private string AV43TFConexionesNombre ;
      private string AV44TFConexionesNombre_Sel ;
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
      private string edtMapeoID_Internalname ;
      private string edtProveedorID_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Internalname ;
      private string cmbProveedorEstado_Internalname ;
      private string A344ProveedorEstado ;
      private string edtSTComerciosID_Internalname ;
      private string A923STComerciosNombre ;
      private string edtSTComerciosNombre_Internalname ;
      private string A552ConexionesID ;
      private string edtConexionesID_Internalname ;
      private string A556ConexionesNombre ;
      private string edtConexionesNombre_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string AV88Mapeowwds_4_stcomerciosnombre1 ;
      private string AV89Mapeowwds_5_proveedornombre1 ;
      private string AV90Mapeowwds_6_conexionesnombre1 ;
      private string AV94Mapeowwds_10_stcomerciosnombre2 ;
      private string AV95Mapeowwds_11_proveedornombre2 ;
      private string AV96Mapeowwds_12_conexionesnombre2 ;
      private string AV100Mapeowwds_16_stcomerciosnombre3 ;
      private string AV101Mapeowwds_17_proveedornombre3 ;
      private string AV102Mapeowwds_18_conexionesnombre3 ;
      private string AV107Mapeowwds_23_tfproveedornombre ;
      private string AV108Mapeowwds_24_tfproveedornombre_sel ;
      private string AV112Mapeowwds_28_tfstcomerciosnombre ;
      private string AV113Mapeowwds_29_tfstcomerciosnombre_sel ;
      private string AV114Mapeowwds_30_tfconexionesid ;
      private string AV115Mapeowwds_31_tfconexionesid_sel ;
      private string AV116Mapeowwds_32_tfconexionesnombre ;
      private string AV117Mapeowwds_33_tfconexionesnombre_sel ;
      private string lV88Mapeowwds_4_stcomerciosnombre1 ;
      private string lV89Mapeowwds_5_proveedornombre1 ;
      private string lV90Mapeowwds_6_conexionesnombre1 ;
      private string lV94Mapeowwds_10_stcomerciosnombre2 ;
      private string lV95Mapeowwds_11_proveedornombre2 ;
      private string lV96Mapeowwds_12_conexionesnombre2 ;
      private string lV100Mapeowwds_16_stcomerciosnombre3 ;
      private string lV101Mapeowwds_17_proveedornombre3 ;
      private string lV102Mapeowwds_18_conexionesnombre3 ;
      private string lV107Mapeowwds_23_tfproveedornombre ;
      private string lV112Mapeowwds_28_tfstcomerciosnombre ;
      private string lV114Mapeowwds_30_tfconexionesid ;
      private string lV116Mapeowwds_32_tfconexionesnombre ;
      private string edtavStcomerciosnombre1_Internalname ;
      private string edtavProveedornombre1_Internalname ;
      private string edtavConexionesnombre1_Internalname ;
      private string edtavStcomerciosnombre2_Internalname ;
      private string edtavProveedornombre2_Internalname ;
      private string edtavConexionesnombre2_Internalname ;
      private string edtavStcomerciosnombre3_Internalname ;
      private string edtavProveedornombre3_Internalname ;
      private string edtavConexionesnombre3_Internalname ;
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
      private string edtProveedorNombre_Link ;
      private string GXEncryptionTmp ;
      private string edtSTComerciosNombre_Link ;
      private string GXt_char3 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_stcomerciosnombre3_cell_Internalname ;
      private string edtavStcomerciosnombre3_Jsonclick ;
      private string cellFilter_proveedornombre3_cell_Internalname ;
      private string edtavProveedornombre3_Jsonclick ;
      private string cellFilter_conexionesnombre3_cell_Internalname ;
      private string edtavConexionesnombre3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_stcomerciosnombre2_cell_Internalname ;
      private string edtavStcomerciosnombre2_Jsonclick ;
      private string cellFilter_proveedornombre2_cell_Internalname ;
      private string edtavProveedornombre2_Jsonclick ;
      private string cellFilter_conexionesnombre2_cell_Internalname ;
      private string edtavConexionesnombre2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_stcomerciosnombre1_cell_Internalname ;
      private string edtavStcomerciosnombre1_Jsonclick ;
      private string cellFilter_proveedornombre1_cell_Internalname ;
      private string edtavProveedornombre1_Jsonclick ;
      private string cellFilter_conexionesnombre1_cell_Internalname ;
      private string edtavConexionesnombre1_Jsonclick ;
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
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtMapeoID_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedorNombre_Jsonclick ;
      private string cmbProveedorEstado_Jsonclick ;
      private string edtSTComerciosID_Jsonclick ;
      private string edtSTComerciosNombre_Jsonclick ;
      private string edtConexionesID_Jsonclick ;
      private string edtConexionesNombre_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV70DynamicFiltersEnabled2 ;
      private bool AV76DynamicFiltersEnabled3 ;
      private bool AV83DynamicFiltersIgnoreFirst ;
      private bool AV82DynamicFiltersRemoving ;
      private bool AV54IsAuthorized_Update ;
      private bool AV55IsAuthorized_Delete ;
      private bool AV56IsAuthorized_ProveedorNombre ;
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
      private bool n919STComerciosID ;
      private bool n552ConexionesID ;
      private bool n556ConexionesNombre ;
      private bool AV91Mapeowwds_7_dynamicfiltersenabled2 ;
      private bool AV97Mapeowwds_13_dynamicfiltersenabled3 ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV63TempBoolean ;
      private bool GXt_boolean1 ;
      private string AV33TFProveedorEstado_SelsJson ;
      private string AV19ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV20UserCustomValue ;
      private string AV65DynamicFiltersSelector1 ;
      private string AV71DynamicFiltersSelector2 ;
      private string AV77DynamicFiltersSelector3 ;
      private string AV16FilterFullText ;
      private string AV51GridAppliedFilters ;
      private string AV85Mapeowwds_1_filterfulltext ;
      private string AV86Mapeowwds_2_dynamicfiltersselector1 ;
      private string AV92Mapeowwds_8_dynamicfiltersselector2 ;
      private string AV98Mapeowwds_14_dynamicfiltersselector3 ;
      private string lV85Mapeowwds_1_filterfulltext ;
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
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbProveedorEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ;
      private GxSimpleCollection<string> AV34TFProveedorEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV61AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV47DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV109Mapeowwds_25_tfproveedorestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H00JF2_A556ConexionesNombre ;
      private bool[] H00JF2_n556ConexionesNombre ;
      private string[] H00JF2_A552ConexionesID ;
      private bool[] H00JF2_n552ConexionesID ;
      private string[] H00JF2_A923STComerciosNombre ;
      private long[] H00JF2_A919STComerciosID ;
      private bool[] H00JF2_n919STComerciosID ;
      private string[] H00JF2_A344ProveedorEstado ;
      private string[] H00JF2_A282ProveedorNombre ;
      private long[] H00JF2_A133ProveedorID ;
      private long[] H00JF2_A918MapeoID ;
      private string[] H00JF3_A556ConexionesNombre ;
      private bool[] H00JF3_n556ConexionesNombre ;
      private string[] H00JF3_A552ConexionesID ;
      private bool[] H00JF3_n552ConexionesID ;
      private string[] H00JF3_A923STComerciosNombre ;
      private long[] H00JF3_A919STComerciosID ;
      private bool[] H00JF3_n919STComerciosID ;
      private string[] H00JF3_A344ProveedorEstado ;
      private string[] H00JF3_A282ProveedorNombre ;
      private long[] H00JF3_A133ProveedorID ;
      private long[] H00JF3_A918MapeoID ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV62AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV22ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV64GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class mapeoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00JF2( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV109Mapeowwds_25_tfproveedorestado_sels ,
                                             string AV86Mapeowwds_2_dynamicfiltersselector1 ,
                                             short AV87Mapeowwds_3_dynamicfiltersoperator1 ,
                                             string AV88Mapeowwds_4_stcomerciosnombre1 ,
                                             string AV89Mapeowwds_5_proveedornombre1 ,
                                             string AV90Mapeowwds_6_conexionesnombre1 ,
                                             bool AV91Mapeowwds_7_dynamicfiltersenabled2 ,
                                             string AV92Mapeowwds_8_dynamicfiltersselector2 ,
                                             short AV93Mapeowwds_9_dynamicfiltersoperator2 ,
                                             string AV94Mapeowwds_10_stcomerciosnombre2 ,
                                             string AV95Mapeowwds_11_proveedornombre2 ,
                                             string AV96Mapeowwds_12_conexionesnombre2 ,
                                             bool AV97Mapeowwds_13_dynamicfiltersenabled3 ,
                                             string AV98Mapeowwds_14_dynamicfiltersselector3 ,
                                             short AV99Mapeowwds_15_dynamicfiltersoperator3 ,
                                             string AV100Mapeowwds_16_stcomerciosnombre3 ,
                                             string AV101Mapeowwds_17_proveedornombre3 ,
                                             string AV102Mapeowwds_18_conexionesnombre3 ,
                                             long AV103Mapeowwds_19_tfmapeoid ,
                                             long AV104Mapeowwds_20_tfmapeoid_to ,
                                             long AV105Mapeowwds_21_tfproveedorid ,
                                             long AV106Mapeowwds_22_tfproveedorid_to ,
                                             string AV108Mapeowwds_24_tfproveedornombre_sel ,
                                             string AV107Mapeowwds_23_tfproveedornombre ,
                                             int AV109Mapeowwds_25_tfproveedorestado_sels_Count ,
                                             long AV110Mapeowwds_26_tfstcomerciosid ,
                                             long AV111Mapeowwds_27_tfstcomerciosid_to ,
                                             string AV113Mapeowwds_29_tfstcomerciosnombre_sel ,
                                             string AV112Mapeowwds_28_tfstcomerciosnombre ,
                                             string AV115Mapeowwds_31_tfconexionesid_sel ,
                                             string AV114Mapeowwds_30_tfconexionesid ,
                                             string AV117Mapeowwds_33_tfconexionesnombre_sel ,
                                             string AV116Mapeowwds_32_tfconexionesnombre ,
                                             string A923STComerciosNombre ,
                                             string A282ProveedorNombre ,
                                             string A556ConexionesNombre ,
                                             long A918MapeoID ,
                                             long A133ProveedorID ,
                                             long A919STComerciosID ,
                                             string A552ConexionesID ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV85Mapeowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[32];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T2.[ConexionesNombre], T1.[ConexionesID], T3.[ProveedorNombre] AS STComerciosNombre, T1.[STComerciosID] AS STComerciosID, T4.[ProveedorEstado], T4.[ProveedorNombre], T1.[ProveedorID], T1.[MapeoID] FROM ((([ListaMapeo] T1 LEFT JOIN [Conexiones] T2 ON T2.[ConexionesID] = T1.[ConexionesID]) LEFT JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[STComerciosID]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = T1.[ProveedorID])";
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV88Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV88Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV89Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV89Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV90Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV90Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV94Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV94Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV95Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV95Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV96Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV96Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV100Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV100Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV101Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV101Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV102Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV102Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! (0==AV103Mapeowwds_19_tfmapeoid) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] >= @AV103Mapeowwds_19_tfmapeoid)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! (0==AV104Mapeowwds_20_tfmapeoid_to) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] <= @AV104Mapeowwds_20_tfmapeoid_to)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! (0==AV105Mapeowwds_21_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV105Mapeowwds_21_tfproveedorid)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! (0==AV106Mapeowwds_22_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV106Mapeowwds_22_tfproveedorid_to)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Mapeowwds_24_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Mapeowwds_23_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV107Mapeowwds_23_tfproveedornombre))");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Mapeowwds_24_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV108Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ProveedorNombre] = @AV108Mapeowwds_24_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( StringUtil.StrCmp(AV108Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ProveedorNombre] = ''))");
         }
         if ( AV109Mapeowwds_25_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV109Mapeowwds_25_tfproveedorestado_sels, "T4.[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! (0==AV110Mapeowwds_26_tfstcomerciosid) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] >= @AV110Mapeowwds_26_tfstcomerciosid)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ! (0==AV111Mapeowwds_27_tfstcomerciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] <= @AV111Mapeowwds_27_tfstcomerciosid_to)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Mapeowwds_29_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Mapeowwds_28_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV112Mapeowwds_28_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Mapeowwds_29_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV113Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV113Mapeowwds_29_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( StringUtil.StrCmp(AV113Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] IS NULL or (T3.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Mapeowwds_31_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Mapeowwds_30_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ConexionesID]) like UPPER(@lV114Mapeowwds_30_tfconexionesid))");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Mapeowwds_31_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV115Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] = @AV115Mapeowwds_31_tfconexionesid_sel)");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( StringUtil.StrCmp(AV115Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] IS NULL or (T1.[ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Mapeowwds_33_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Mapeowwds_32_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV116Mapeowwds_32_tfconexionesnombre))");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Mapeowwds_33_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV117Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] = @AV117Mapeowwds_33_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( StringUtil.StrCmp(AV117Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] IS NULL or (T2.[ConexionesNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MapeoID]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MapeoID] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ProveedorNombre]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ProveedorNombre] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ProveedorEstado]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ProveedorEstado] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[STComerciosID]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[STComerciosID] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConexionesID]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConexionesID] DESC";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ConexionesNombre]";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ConexionesNombre] DESC";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H00JF3( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV109Mapeowwds_25_tfproveedorestado_sels ,
                                             string AV86Mapeowwds_2_dynamicfiltersselector1 ,
                                             short AV87Mapeowwds_3_dynamicfiltersoperator1 ,
                                             string AV88Mapeowwds_4_stcomerciosnombre1 ,
                                             string AV89Mapeowwds_5_proveedornombre1 ,
                                             string AV90Mapeowwds_6_conexionesnombre1 ,
                                             bool AV91Mapeowwds_7_dynamicfiltersenabled2 ,
                                             string AV92Mapeowwds_8_dynamicfiltersselector2 ,
                                             short AV93Mapeowwds_9_dynamicfiltersoperator2 ,
                                             string AV94Mapeowwds_10_stcomerciosnombre2 ,
                                             string AV95Mapeowwds_11_proveedornombre2 ,
                                             string AV96Mapeowwds_12_conexionesnombre2 ,
                                             bool AV97Mapeowwds_13_dynamicfiltersenabled3 ,
                                             string AV98Mapeowwds_14_dynamicfiltersselector3 ,
                                             short AV99Mapeowwds_15_dynamicfiltersoperator3 ,
                                             string AV100Mapeowwds_16_stcomerciosnombre3 ,
                                             string AV101Mapeowwds_17_proveedornombre3 ,
                                             string AV102Mapeowwds_18_conexionesnombre3 ,
                                             long AV103Mapeowwds_19_tfmapeoid ,
                                             long AV104Mapeowwds_20_tfmapeoid_to ,
                                             long AV105Mapeowwds_21_tfproveedorid ,
                                             long AV106Mapeowwds_22_tfproveedorid_to ,
                                             string AV108Mapeowwds_24_tfproveedornombre_sel ,
                                             string AV107Mapeowwds_23_tfproveedornombre ,
                                             int AV109Mapeowwds_25_tfproveedorestado_sels_Count ,
                                             long AV110Mapeowwds_26_tfstcomerciosid ,
                                             long AV111Mapeowwds_27_tfstcomerciosid_to ,
                                             string AV113Mapeowwds_29_tfstcomerciosnombre_sel ,
                                             string AV112Mapeowwds_28_tfstcomerciosnombre ,
                                             string AV115Mapeowwds_31_tfconexionesid_sel ,
                                             string AV114Mapeowwds_30_tfconexionesid ,
                                             string AV117Mapeowwds_33_tfconexionesnombre_sel ,
                                             string AV116Mapeowwds_32_tfconexionesnombre ,
                                             string A923STComerciosNombre ,
                                             string A282ProveedorNombre ,
                                             string A556ConexionesNombre ,
                                             long A918MapeoID ,
                                             long A133ProveedorID ,
                                             long A919STComerciosID ,
                                             string A552ConexionesID ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV85Mapeowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[32];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T2.[ConexionesNombre], T1.[ConexionesID], T3.[ProveedorNombre] AS STComerciosNombre, T1.[STComerciosID] AS STComerciosID, T4.[ProveedorEstado], T4.[ProveedorNombre], T1.[ProveedorID], T1.[MapeoID] FROM ((([ListaMapeo] T1 LEFT JOIN [Conexiones] T2 ON T2.[ConexionesID] = T1.[ConexionesID]) LEFT JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[STComerciosID]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = T1.[ProveedorID])";
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV88Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV88Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV89Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV89Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV90Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV90Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV94Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV94Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV95Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV95Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV96Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( AV91Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV93Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV96Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV100Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV100Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV101Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV101Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV102Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( AV97Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV99Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV102Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! (0==AV103Mapeowwds_19_tfmapeoid) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] >= @AV103Mapeowwds_19_tfmapeoid)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( ! (0==AV104Mapeowwds_20_tfmapeoid_to) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] <= @AV104Mapeowwds_20_tfmapeoid_to)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ! (0==AV105Mapeowwds_21_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV105Mapeowwds_21_tfproveedorid)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! (0==AV106Mapeowwds_22_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV106Mapeowwds_22_tfproveedorid_to)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Mapeowwds_24_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Mapeowwds_23_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV107Mapeowwds_23_tfproveedornombre))");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Mapeowwds_24_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV108Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ProveedorNombre] = @AV108Mapeowwds_24_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( StringUtil.StrCmp(AV108Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ProveedorNombre] = ''))");
         }
         if ( AV109Mapeowwds_25_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV109Mapeowwds_25_tfproveedorestado_sels, "T4.[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! (0==AV110Mapeowwds_26_tfstcomerciosid) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] >= @AV110Mapeowwds_26_tfstcomerciosid)");
         }
         else
         {
            GXv_int11[24] = 1;
         }
         if ( ! (0==AV111Mapeowwds_27_tfstcomerciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] <= @AV111Mapeowwds_27_tfstcomerciosid_to)");
         }
         else
         {
            GXv_int11[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Mapeowwds_29_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Mapeowwds_28_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV112Mapeowwds_28_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int11[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Mapeowwds_29_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV113Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV113Mapeowwds_29_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int11[27] = 1;
         }
         if ( StringUtil.StrCmp(AV113Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] IS NULL or (T3.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Mapeowwds_31_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Mapeowwds_30_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ConexionesID]) like UPPER(@lV114Mapeowwds_30_tfconexionesid))");
         }
         else
         {
            GXv_int11[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Mapeowwds_31_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV115Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] = @AV115Mapeowwds_31_tfconexionesid_sel)");
         }
         else
         {
            GXv_int11[29] = 1;
         }
         if ( StringUtil.StrCmp(AV115Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] IS NULL or (T1.[ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Mapeowwds_33_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Mapeowwds_32_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV116Mapeowwds_32_tfconexionesnombre))");
         }
         else
         {
            GXv_int11[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Mapeowwds_33_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV117Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] = @AV117Mapeowwds_33_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int11[31] = 1;
         }
         if ( StringUtil.StrCmp(AV117Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] IS NULL or (T2.[ConexionesNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MapeoID]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MapeoID] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ProveedorNombre]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ProveedorNombre] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ProveedorEstado]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ProveedorEstado] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[STComerciosID]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[STComerciosID] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConexionesID]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConexionesID] DESC";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ConexionesNombre]";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ConexionesNombre] DESC";
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
                     return conditional_H00JF2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (long)dynConstraints[37] , (long)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (short)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] );
               case 1 :
                     return conditional_H00JF3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (long)dynConstraints[37] , (long)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (short)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] );
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
          Object[] prmH00JF2;
          prmH00JF2 = new Object[] {
          new ParDef("@lV88Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV88Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV94Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV94Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV95Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV95Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV96Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV96Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV100Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV100Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV101Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV101Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV102Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV102Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@AV103Mapeowwds_19_tfmapeoid",GXType.Decimal,18,0) ,
          new ParDef("@AV104Mapeowwds_20_tfmapeoid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV105Mapeowwds_21_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV106Mapeowwds_22_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV107Mapeowwds_23_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV108Mapeowwds_24_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV110Mapeowwds_26_tfstcomerciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV111Mapeowwds_27_tfstcomerciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV112Mapeowwds_28_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV113Mapeowwds_29_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV114Mapeowwds_30_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV115Mapeowwds_31_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV116Mapeowwds_32_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV117Mapeowwds_33_tfconexionesnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmH00JF3;
          prmH00JF3 = new Object[] {
          new ParDef("@lV88Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV88Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV94Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV94Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV95Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV95Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV96Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV96Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV100Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV100Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV101Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV101Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV102Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV102Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@AV103Mapeowwds_19_tfmapeoid",GXType.Decimal,18,0) ,
          new ParDef("@AV104Mapeowwds_20_tfmapeoid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV105Mapeowwds_21_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV106Mapeowwds_22_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV107Mapeowwds_23_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV108Mapeowwds_24_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV110Mapeowwds_26_tfstcomerciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV111Mapeowwds_27_tfstcomerciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV112Mapeowwds_28_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV113Mapeowwds_29_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV114Mapeowwds_30_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV115Mapeowwds_31_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV116Mapeowwds_32_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV117Mapeowwds_33_tfconexionesnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00JF2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JF2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00JF3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JF3,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 9);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((string[]) buf[8])[0] = rslt.getString(6, 80);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((long[]) buf[10])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 9);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((string[]) buf[8])[0] = rslt.getString(6, 80);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((long[]) buf[10])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
