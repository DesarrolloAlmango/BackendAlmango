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
   public class vinculartrnww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public vinculartrnww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public vinculartrnww( IGxContext context )
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
         AV17FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV20VincularTrnSolidicutd1 = (long)(Math.Round(NumberUtil.Val( GetPar( "VincularTrnSolidicutd1"), "."), 18, MidpointRounding.ToEven));
         AV21ProveedorNombre1 = GetPar( "ProveedorNombre1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV25VincularTrnSolidicutd2 = (long)(Math.Round(NumberUtil.Val( GetPar( "VincularTrnSolidicutd2"), "."), 18, MidpointRounding.ToEven));
         AV26ProveedorNombre2 = GetPar( "ProveedorNombre2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV30VincularTrnSolidicutd3 = (long)(Math.Round(NumberUtil.Val( GetPar( "VincularTrnSolidicutd3"), "."), 18, MidpointRounding.ToEven));
         AV31ProveedorNombre3 = GetPar( "ProveedorNombre3");
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV27DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38ColumnsSelector);
         AV80Pgmname = GetPar( "Pgmname");
         AV44TFVincularTrnId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFVincularTrnId"), "."), 18, MidpointRounding.ToEven));
         AV45TFVincularTrnId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFVincularTrnId_To"), "."), 18, MidpointRounding.ToEven));
         AV46TFProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProveedorID"), "."), 18, MidpointRounding.ToEven));
         AV47TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProveedorID_To"), "."), 18, MidpointRounding.ToEven));
         AV48TFProveedorNombre = GetPar( "TFProveedorNombre");
         AV49TFProveedorNombre_Sel = GetPar( "TFProveedorNombre_Sel");
         AV50TFVincularTrnSolidicutd = (long)(Math.Round(NumberUtil.Val( GetPar( "TFVincularTrnSolidicutd"), "."), 18, MidpointRounding.ToEven));
         AV51TFVincularTrnSolidicutd_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFVincularTrnSolidicutd_To"), "."), 18, MidpointRounding.ToEven));
         AV52TFVincularTrnNombreSol = GetPar( "TFVincularTrnNombreSol");
         AV53TFVincularTrnNombreSol_Sel = GetPar( "TFVincularTrnNombreSol_Sel");
         AV54TFVincularTrnTelefonoSol = GetPar( "TFVincularTrnTelefonoSol");
         AV55TFVincularTrnTelefonoSol_Sel = GetPar( "TFVincularTrnTelefonoSol_Sel");
         AV56TFDocumentacionId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFDocumentacionId"), "."), 18, MidpointRounding.ToEven));
         AV57TFDocumentacionId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFDocumentacionId_To"), "."), 18, MidpointRounding.ToEven));
         AV58TFVincularTrnComentario = GetPar( "TFVincularTrnComentario");
         AV59TFVincularTrnComentario_Sel = GetPar( "TFVincularTrnComentario_Sel");
         AV60TFVincularTrnFecha = context.localUtil.ParseDateParm( GetPar( "TFVincularTrnFecha"));
         AV61TFVincularTrnFecha_To = context.localUtil.ParseDateParm( GetPar( "TFVincularTrnFecha_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV33DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV32DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV72IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV73IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV77IsAuthorized_ProveedorNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_ProveedorNombre"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20VincularTrnSolidicutd1, AV21ProveedorNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25VincularTrnSolidicutd2, AV26ProveedorNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30VincularTrnSolidicutd3, AV31ProveedorNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV44TFVincularTrnId, AV45TFVincularTrnId_To, AV46TFProveedorID, AV47TFProveedorID_To, AV48TFProveedorNombre, AV49TFProveedorNombre_Sel, AV50TFVincularTrnSolidicutd, AV51TFVincularTrnSolidicutd_To, AV52TFVincularTrnNombreSol, AV53TFVincularTrnNombreSol_Sel, AV54TFVincularTrnTelefonoSol, AV55TFVincularTrnTelefonoSol_Sel, AV56TFDocumentacionId, AV57TFDocumentacionId_To, AV58TFVincularTrnComentario, AV59TFVincularTrnComentario_Sel, AV60TFVincularTrnFecha, AV61TFVincularTrnFecha_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV72IsAuthorized_Update, AV73IsAuthorized_Delete, AV77IsAuthorized_ProveedorNombre) ;
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
         PA472( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START472( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("vinculartrnww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV80Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV80Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV72IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV72IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV73IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV73IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROVEEDORNOMBRE", AV77IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( "", AV77IsAuthorized_ProveedorNombre, context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vVINCULARTRNSOLIDICUTD1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20VincularTrnSolidicutd1), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROVEEDORNOMBRE1", StringUtil.RTrim( AV21ProveedorNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vVINCULARTRNSOLIDICUTD2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25VincularTrnSolidicutd2), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROVEEDORNOMBRE2", StringUtil.RTrim( AV26ProveedorNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV28DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vVINCULARTRNSOLIDICUTD3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30VincularTrnSolidicutd3), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROVEEDORNOMBRE3", StringUtil.RTrim( AV31ProveedorNombre3));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV69GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV74AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV74AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV65DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV65DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_VINCULARTRNFECHAAUXDATETO", context.localUtil.DToC( AV63DDO_VincularTrnFechaAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV27DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV80Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV80Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFVincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TFVincularTrnId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46TFProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFProveedorID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORNOMBRE", StringUtil.RTrim( AV48TFProveedorNombre));
         GxWebStd.gx_hidden_field( context, "vTFPROVEEDORNOMBRE_SEL", StringUtil.RTrim( AV49TFProveedorNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNSOLIDICUTD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50TFVincularTrnSolidicutd), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNSOLIDICUTD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51TFVincularTrnSolidicutd_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNNOMBRESOL", StringUtil.RTrim( AV52TFVincularTrnNombreSol));
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNNOMBRESOL_SEL", StringUtil.RTrim( AV53TFVincularTrnNombreSol_Sel));
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNTELEFONOSOL", StringUtil.RTrim( AV54TFVincularTrnTelefonoSol));
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNTELEFONOSOL_SEL", StringUtil.RTrim( AV55TFVincularTrnTelefonoSol_Sel));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56TFDocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCUMENTACIONID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57TFDocumentacionId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNCOMENTARIO", AV58TFVincularTrnComentario);
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNCOMENTARIO_SEL", AV59TFVincularTrnComentario_Sel);
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNFECHA", context.localUtil.DToC( AV60TFVincularTrnFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFVINCULARTRNFECHA_TO", context.localUtil.DToC( AV61TFVincularTrnFecha_To, 0, "/"));
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV72IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV72IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV73IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV73IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROVEEDORNOMBRE", AV77IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( "", AV77IsAuthorized_ProveedorNombre, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vDDO_VINCULARTRNFECHAAUXDATE", context.localUtil.DToC( AV62DDO_VincularTrnFechaAuxDate, 0, "/"));
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
            WE472( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT472( ) ;
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
         return formatLink("vinculartrnww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "VincularTrnWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Vincular Trns", "") ;
      }

      protected void WB470( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_472( true) ;
         }
         else
         {
            wb_table1_25_472( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_472e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_VincularTrnWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_472( true) ;
         }
         else
         {
            wb_table2_49_472( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_472e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "", true, 0, "HLP_VincularTrnWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_74_472( true) ;
         }
         else
         {
            wb_table3_74_472( false) ;
         }
         return  ;
      }

      protected void wb_table3_74_472e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_VincularTrnWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_99_472( true) ;
         }
         else
         {
            wb_table4_99_472( false) ;
         }
         return  ;
      }

      protected void wb_table4_99_472e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV67GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV68GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV69GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV74AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_VincularTrnWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV65DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV65DDO_TitleSettingsIcons);
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
               GxWebStd.gx_hidden_field( context, "W0147"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0147"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_120_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0147"+"");
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
            GxWebStd.gx_div_start( context, divDdo_vinculartrnfechaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_vinculartrnfechaauxdatetext_Internalname, AV64DDO_VincularTrnFechaAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV64DDO_VincularTrnFechaAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_vinculartrnfechaauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_VincularTrnWW.htm");
            /* User Defined Control */
            ucTfvinculartrnfecha_rangepicker.SetProperty("Start Date", AV62DDO_VincularTrnFechaAuxDate);
            ucTfvinculartrnfecha_rangepicker.SetProperty("End Date", AV63DDO_VincularTrnFechaAuxDateTo);
            ucTfvinculartrnfecha_rangepicker.Render(context, "wwp.daterangepicker", Tfvinculartrnfecha_rangepicker_Internalname, "TFVINCULARTRNFECHA_RANGEPICKERContainer");
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

      protected void START472( )
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
         Form.Meta.addItem("description", context.GetMessage( "Vincular Trns", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP470( ) ;
      }

      protected void WS472( )
      {
         START472( ) ;
         EVT472( ) ;
      }

      protected void EVT472( )
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
                              E11472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E14472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E15472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E16472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E17472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E18472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E19472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E20472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E21472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E22472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E24472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E25472 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E26472 ();
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
                              AV70GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActions), 4, 0));
                              A491VincularTrnId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVincularTrnId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
                              A492VincularTrnSolidicutd = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVincularTrnSolidicutd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A493VincularTrnNombreSol = cgiGet( edtVincularTrnNombreSol_Internalname);
                              A494VincularTrnTelefonoSol = cgiGet( edtVincularTrnTelefonoSol_Internalname);
                              A488DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentacionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n488DocumentacionId = false;
                              A495VincularTrnImagen = cgiGet( edtVincularTrnImagen_Internalname);
                              AssignProp("", false, edtVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), !bGXsfl_120_Refreshing);
                              AssignProp("", false, edtVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
                              A497VincularTrnComentario = cgiGet( edtVincularTrnComentario_Internalname);
                              A496VincularTrnFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtVincularTrnFecha_Internalname), 0));
                              A498DocumentacionIcono = cgiGet( edtDocumentacionIcono_Internalname);
                              AssignProp("", false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40002DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_120_Refreshing);
                              AssignProp("", false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E27472 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E28472 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E29472 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E30472 ();
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
                                       /* Set Refresh If Vinculartrnsolidicutd1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vVINCULARTRNSOLIDICUTD1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV20VincularTrnSolidicutd1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Proveedornombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE1"), AV21ProveedorNombre1) != 0 )
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
                                       /* Set Refresh If Vinculartrnsolidicutd2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vVINCULARTRNSOLIDICUTD2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV25VincularTrnSolidicutd2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Proveedornombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE2"), AV26ProveedorNombre2) != 0 )
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
                                       /* Set Refresh If Vinculartrnsolidicutd3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vVINCULARTRNSOLIDICUTD3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV30VincularTrnSolidicutd3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Proveedornombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE3"), AV31ProveedorNombre3) != 0 )
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
                        if ( nCmpId == 147 )
                        {
                           OldWwpaux_wc = cgiGet( "W0147");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0147", "", sEvt);
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

      protected void WE472( )
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

      protected void PA472( )
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
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       long AV20VincularTrnSolidicutd1 ,
                                       string AV21ProveedorNombre1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       long AV25VincularTrnSolidicutd2 ,
                                       string AV26ProveedorNombre2 ,
                                       string AV28DynamicFiltersSelector3 ,
                                       short AV29DynamicFiltersOperator3 ,
                                       long AV30VincularTrnSolidicutd3 ,
                                       string AV31ProveedorNombre3 ,
                                       short AV43ManageFiltersExecutionStep ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       bool AV27DynamicFiltersEnabled3 ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ,
                                       string AV80Pgmname ,
                                       long AV44TFVincularTrnId ,
                                       long AV45TFVincularTrnId_To ,
                                       long AV46TFProveedorID ,
                                       long AV47TFProveedorID_To ,
                                       string AV48TFProveedorNombre ,
                                       string AV49TFProveedorNombre_Sel ,
                                       long AV50TFVincularTrnSolidicutd ,
                                       long AV51TFVincularTrnSolidicutd_To ,
                                       string AV52TFVincularTrnNombreSol ,
                                       string AV53TFVincularTrnNombreSol_Sel ,
                                       string AV54TFVincularTrnTelefonoSol ,
                                       string AV55TFVincularTrnTelefonoSol_Sel ,
                                       long AV56TFDocumentacionId ,
                                       long AV57TFDocumentacionId_To ,
                                       string AV58TFVincularTrnComentario ,
                                       string AV59TFVincularTrnComentario_Sel ,
                                       DateTime AV60TFVincularTrnFecha ,
                                       DateTime AV61TFVincularTrnFecha_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV33DynamicFiltersIgnoreFirst ,
                                       bool AV32DynamicFiltersRemoving ,
                                       bool AV72IsAuthorized_Update ,
                                       bool AV73IsAuthorized_Delete ,
                                       bool AV77IsAuthorized_ProveedorNombre )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF472( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_VINCULARTRNID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "VINCULARTRNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A491VincularTrnId), 18, 0, ".", "")));
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
         RF472( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV80Pgmname = "VincularTrnWW";
      }

      protected void RF472( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 120;
         /* Execute user event: Refresh */
         E28472 ();
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
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV81Vinculartrnwwds_1_filterfulltext ,
                                                 AV82Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                                 AV83Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                                 AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                                 AV85Vinculartrnwwds_5_proveedornombre1 ,
                                                 AV86Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                                 AV87Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                                 AV88Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                                 AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                                 AV90Vinculartrnwwds_10_proveedornombre2 ,
                                                 AV91Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                                 AV92Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                                 AV93Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                                 AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                                 AV95Vinculartrnwwds_15_proveedornombre3 ,
                                                 AV96Vinculartrnwwds_16_tfvinculartrnid ,
                                                 AV97Vinculartrnwwds_17_tfvinculartrnid_to ,
                                                 AV98Vinculartrnwwds_18_tfproveedorid ,
                                                 AV99Vinculartrnwwds_19_tfproveedorid_to ,
                                                 AV101Vinculartrnwwds_21_tfproveedornombre_sel ,
                                                 AV100Vinculartrnwwds_20_tfproveedornombre ,
                                                 AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                                 AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                                 AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                                 AV104Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                                 AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                                 AV106Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                                 AV108Vinculartrnwwds_28_tfdocumentacionid ,
                                                 AV109Vinculartrnwwds_29_tfdocumentacionid_to ,
                                                 AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                                 AV110Vinculartrnwwds_30_tfvinculartrncomentario ,
                                                 AV112Vinculartrnwwds_32_tfvinculartrnfecha ,
                                                 AV113Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                                 A491VincularTrnId ,
                                                 A133ProveedorID ,
                                                 A282ProveedorNombre ,
                                                 A492VincularTrnSolidicutd ,
                                                 A493VincularTrnNombreSol ,
                                                 A494VincularTrnTelefonoSol ,
                                                 A488DocumentacionId ,
                                                 A497VincularTrnComentario ,
                                                 A496VincularTrnFecha ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
            lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
            lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
            lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
            lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
            lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
            lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
            lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
            lV85Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV85Vinculartrnwwds_5_proveedornombre1), 80, "%");
            lV85Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV85Vinculartrnwwds_5_proveedornombre1), 80, "%");
            lV90Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV90Vinculartrnwwds_10_proveedornombre2), 80, "%");
            lV90Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV90Vinculartrnwwds_10_proveedornombre2), 80, "%");
            lV95Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV95Vinculartrnwwds_15_proveedornombre3), 80, "%");
            lV95Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV95Vinculartrnwwds_15_proveedornombre3), 80, "%");
            lV100Vinculartrnwwds_20_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV100Vinculartrnwwds_20_tfproveedornombre), 80, "%");
            lV104Vinculartrnwwds_24_tfvinculartrnnombresol = StringUtil.PadR( StringUtil.RTrim( AV104Vinculartrnwwds_24_tfvinculartrnnombresol), 80, "%");
            lV106Vinculartrnwwds_26_tfvinculartrntelefonosol = StringUtil.PadR( StringUtil.RTrim( AV106Vinculartrnwwds_26_tfvinculartrntelefonosol), 20, "%");
            lV110Vinculartrnwwds_30_tfvinculartrncomentario = StringUtil.Concat( StringUtil.RTrim( AV110Vinculartrnwwds_30_tfvinculartrncomentario), "%", "");
            /* Using cursor H00472 */
            pr_default.execute(0, new Object[] {lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, AV84Vinculartrnwwds_4_vinculartrnsolidicutd1, AV84Vinculartrnwwds_4_vinculartrnsolidicutd1, AV84Vinculartrnwwds_4_vinculartrnsolidicutd1, lV85Vinculartrnwwds_5_proveedornombre1, lV85Vinculartrnwwds_5_proveedornombre1, AV89Vinculartrnwwds_9_vinculartrnsolidicutd2, AV89Vinculartrnwwds_9_vinculartrnsolidicutd2, AV89Vinculartrnwwds_9_vinculartrnsolidicutd2, lV90Vinculartrnwwds_10_proveedornombre2, lV90Vinculartrnwwds_10_proveedornombre2, AV94Vinculartrnwwds_14_vinculartrnsolidicutd3, AV94Vinculartrnwwds_14_vinculartrnsolidicutd3, AV94Vinculartrnwwds_14_vinculartrnsolidicutd3, lV95Vinculartrnwwds_15_proveedornombre3, lV95Vinculartrnwwds_15_proveedornombre3, AV96Vinculartrnwwds_16_tfvinculartrnid, AV97Vinculartrnwwds_17_tfvinculartrnid_to, AV98Vinculartrnwwds_18_tfproveedorid, AV99Vinculartrnwwds_19_tfproveedorid_to, lV100Vinculartrnwwds_20_tfproveedornombre, AV101Vinculartrnwwds_21_tfproveedornombre_sel, AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd, AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to, lV104Vinculartrnwwds_24_tfvinculartrnnombresol, AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel, lV106Vinculartrnwwds_26_tfvinculartrntelefonosol, AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, AV108Vinculartrnwwds_28_tfdocumentacionid, AV109Vinculartrnwwds_29_tfdocumentacionid_to, lV110Vinculartrnwwds_30_tfvinculartrncomentario, AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel, AV112Vinculartrnwwds_32_tfvinculartrnfecha, AV113Vinculartrnwwds_33_tfvinculartrnfecha_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_120_idx = 1;
            sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
            SubsflControlProps_1202( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A40002DocumentacionIcono_GXI = H00472_A40002DocumentacionIcono_GXI[0];
               AssignProp("", false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40002DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_120_Refreshing);
               AssignProp("", false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               A496VincularTrnFecha = H00472_A496VincularTrnFecha[0];
               A497VincularTrnComentario = H00472_A497VincularTrnComentario[0];
               A40000VincularTrnImagen_GXI = H00472_A40000VincularTrnImagen_GXI[0];
               AssignProp("", false, edtVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), !bGXsfl_120_Refreshing);
               AssignProp("", false, edtVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
               A488DocumentacionId = H00472_A488DocumentacionId[0];
               n488DocumentacionId = H00472_n488DocumentacionId[0];
               A494VincularTrnTelefonoSol = H00472_A494VincularTrnTelefonoSol[0];
               A493VincularTrnNombreSol = H00472_A493VincularTrnNombreSol[0];
               A492VincularTrnSolidicutd = H00472_A492VincularTrnSolidicutd[0];
               A282ProveedorNombre = H00472_A282ProveedorNombre[0];
               A133ProveedorID = H00472_A133ProveedorID[0];
               A491VincularTrnId = H00472_A491VincularTrnId[0];
               A498DocumentacionIcono = H00472_A498DocumentacionIcono[0];
               AssignProp("", false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40002DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_120_Refreshing);
               AssignProp("", false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               A495VincularTrnImagen = H00472_A495VincularTrnImagen[0];
               AssignProp("", false, edtVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), !bGXsfl_120_Refreshing);
               AssignProp("", false, edtVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
               A488DocumentacionId = H00472_A488DocumentacionId[0];
               n488DocumentacionId = H00472_n488DocumentacionId[0];
               A282ProveedorNombre = H00472_A282ProveedorNombre[0];
               A40002DocumentacionIcono_GXI = H00472_A40002DocumentacionIcono_GXI[0];
               AssignProp("", false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40002DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_120_Refreshing);
               AssignProp("", false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               A498DocumentacionIcono = H00472_A498DocumentacionIcono[0];
               AssignProp("", false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40002DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_120_Refreshing);
               AssignProp("", false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               /* Execute user event: Grid.Load */
               E29472 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 120;
            WB470( ) ;
         }
         bGXsfl_120_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes472( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV80Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV80Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV72IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV72IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV73IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV73IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROVEEDORNOMBRE", AV77IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( "", AV77IsAuthorized_ProveedorNombre, context));
         GxWebStd.gx_hidden_field( context, "gxhash_VINCULARTRNID"+"_"+sGXsfl_120_idx, GetSecureSignedToken( sGXsfl_120_idx, context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         AV81Vinculartrnwwds_1_filterfulltext = AV17FilterFullText;
         AV82Vinculartrnwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV83Vinculartrnwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV20VincularTrnSolidicutd1;
         AV85Vinculartrnwwds_5_proveedornombre1 = AV21ProveedorNombre1;
         AV86Vinculartrnwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV87Vinculartrnwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV88Vinculartrnwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV25VincularTrnSolidicutd2;
         AV90Vinculartrnwwds_10_proveedornombre2 = AV26ProveedorNombre2;
         AV91Vinculartrnwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV92Vinculartrnwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV93Vinculartrnwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV30VincularTrnSolidicutd3;
         AV95Vinculartrnwwds_15_proveedornombre3 = AV31ProveedorNombre3;
         AV96Vinculartrnwwds_16_tfvinculartrnid = AV44TFVincularTrnId;
         AV97Vinculartrnwwds_17_tfvinculartrnid_to = AV45TFVincularTrnId_To;
         AV98Vinculartrnwwds_18_tfproveedorid = AV46TFProveedorID;
         AV99Vinculartrnwwds_19_tfproveedorid_to = AV47TFProveedorID_To;
         AV100Vinculartrnwwds_20_tfproveedornombre = AV48TFProveedorNombre;
         AV101Vinculartrnwwds_21_tfproveedornombre_sel = AV49TFProveedorNombre_Sel;
         AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV50TFVincularTrnSolidicutd;
         AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV51TFVincularTrnSolidicutd_To;
         AV104Vinculartrnwwds_24_tfvinculartrnnombresol = AV52TFVincularTrnNombreSol;
         AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV53TFVincularTrnNombreSol_Sel;
         AV106Vinculartrnwwds_26_tfvinculartrntelefonosol = AV54TFVincularTrnTelefonoSol;
         AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV55TFVincularTrnTelefonoSol_Sel;
         AV108Vinculartrnwwds_28_tfdocumentacionid = AV56TFDocumentacionId;
         AV109Vinculartrnwwds_29_tfdocumentacionid_to = AV57TFDocumentacionId_To;
         AV110Vinculartrnwwds_30_tfvinculartrncomentario = AV58TFVincularTrnComentario;
         AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV59TFVincularTrnComentario_Sel;
         AV112Vinculartrnwwds_32_tfvinculartrnfecha = AV60TFVincularTrnFecha;
         AV113Vinculartrnwwds_33_tfvinculartrnfecha_to = AV61TFVincularTrnFecha_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV81Vinculartrnwwds_1_filterfulltext ,
                                              AV82Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                              AV83Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                              AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                              AV85Vinculartrnwwds_5_proveedornombre1 ,
                                              AV86Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                              AV87Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                              AV88Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                              AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                              AV90Vinculartrnwwds_10_proveedornombre2 ,
                                              AV91Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                              AV92Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                              AV93Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                              AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                              AV95Vinculartrnwwds_15_proveedornombre3 ,
                                              AV96Vinculartrnwwds_16_tfvinculartrnid ,
                                              AV97Vinculartrnwwds_17_tfvinculartrnid_to ,
                                              AV98Vinculartrnwwds_18_tfproveedorid ,
                                              AV99Vinculartrnwwds_19_tfproveedorid_to ,
                                              AV101Vinculartrnwwds_21_tfproveedornombre_sel ,
                                              AV100Vinculartrnwwds_20_tfproveedornombre ,
                                              AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                              AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                              AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                              AV104Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                              AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                              AV106Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                              AV108Vinculartrnwwds_28_tfdocumentacionid ,
                                              AV109Vinculartrnwwds_29_tfdocumentacionid_to ,
                                              AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                              AV110Vinculartrnwwds_30_tfvinculartrncomentario ,
                                              AV112Vinculartrnwwds_32_tfvinculartrnfecha ,
                                              AV113Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                              A491VincularTrnId ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A492VincularTrnSolidicutd ,
                                              A493VincularTrnNombreSol ,
                                              A494VincularTrnTelefonoSol ,
                                              A488DocumentacionId ,
                                              A497VincularTrnComentario ,
                                              A496VincularTrnFecha ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
         lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
         lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
         lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
         lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
         lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
         lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
         lV81Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext), "%", "");
         lV85Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV85Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV85Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV85Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV90Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV90Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV90Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV90Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV95Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV95Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV95Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV95Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV100Vinculartrnwwds_20_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV100Vinculartrnwwds_20_tfproveedornombre), 80, "%");
         lV104Vinculartrnwwds_24_tfvinculartrnnombresol = StringUtil.PadR( StringUtil.RTrim( AV104Vinculartrnwwds_24_tfvinculartrnnombresol), 80, "%");
         lV106Vinculartrnwwds_26_tfvinculartrntelefonosol = StringUtil.PadR( StringUtil.RTrim( AV106Vinculartrnwwds_26_tfvinculartrntelefonosol), 20, "%");
         lV110Vinculartrnwwds_30_tfvinculartrncomentario = StringUtil.Concat( StringUtil.RTrim( AV110Vinculartrnwwds_30_tfvinculartrncomentario), "%", "");
         /* Using cursor H00473 */
         pr_default.execute(1, new Object[] {lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, lV81Vinculartrnwwds_1_filterfulltext, AV84Vinculartrnwwds_4_vinculartrnsolidicutd1, AV84Vinculartrnwwds_4_vinculartrnsolidicutd1, AV84Vinculartrnwwds_4_vinculartrnsolidicutd1, lV85Vinculartrnwwds_5_proveedornombre1, lV85Vinculartrnwwds_5_proveedornombre1, AV89Vinculartrnwwds_9_vinculartrnsolidicutd2, AV89Vinculartrnwwds_9_vinculartrnsolidicutd2, AV89Vinculartrnwwds_9_vinculartrnsolidicutd2, lV90Vinculartrnwwds_10_proveedornombre2, lV90Vinculartrnwwds_10_proveedornombre2, AV94Vinculartrnwwds_14_vinculartrnsolidicutd3, AV94Vinculartrnwwds_14_vinculartrnsolidicutd3, AV94Vinculartrnwwds_14_vinculartrnsolidicutd3, lV95Vinculartrnwwds_15_proveedornombre3, lV95Vinculartrnwwds_15_proveedornombre3, AV96Vinculartrnwwds_16_tfvinculartrnid, AV97Vinculartrnwwds_17_tfvinculartrnid_to, AV98Vinculartrnwwds_18_tfproveedorid, AV99Vinculartrnwwds_19_tfproveedorid_to, lV100Vinculartrnwwds_20_tfproveedornombre, AV101Vinculartrnwwds_21_tfproveedornombre_sel, AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd, AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to, lV104Vinculartrnwwds_24_tfvinculartrnnombresol, AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel, lV106Vinculartrnwwds_26_tfvinculartrntelefonosol, AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, AV108Vinculartrnwwds_28_tfdocumentacionid, AV109Vinculartrnwwds_29_tfdocumentacionid_to, lV110Vinculartrnwwds_30_tfvinculartrncomentario, AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel, AV112Vinculartrnwwds_32_tfvinculartrnfecha, AV113Vinculartrnwwds_33_tfvinculartrnfecha_to});
         GRID_nRecordCount = H00473_AGRID_nRecordCount[0];
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
         AV81Vinculartrnwwds_1_filterfulltext = AV17FilterFullText;
         AV82Vinculartrnwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV83Vinculartrnwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV20VincularTrnSolidicutd1;
         AV85Vinculartrnwwds_5_proveedornombre1 = AV21ProveedorNombre1;
         AV86Vinculartrnwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV87Vinculartrnwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV88Vinculartrnwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV25VincularTrnSolidicutd2;
         AV90Vinculartrnwwds_10_proveedornombre2 = AV26ProveedorNombre2;
         AV91Vinculartrnwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV92Vinculartrnwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV93Vinculartrnwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV30VincularTrnSolidicutd3;
         AV95Vinculartrnwwds_15_proveedornombre3 = AV31ProveedorNombre3;
         AV96Vinculartrnwwds_16_tfvinculartrnid = AV44TFVincularTrnId;
         AV97Vinculartrnwwds_17_tfvinculartrnid_to = AV45TFVincularTrnId_To;
         AV98Vinculartrnwwds_18_tfproveedorid = AV46TFProveedorID;
         AV99Vinculartrnwwds_19_tfproveedorid_to = AV47TFProveedorID_To;
         AV100Vinculartrnwwds_20_tfproveedornombre = AV48TFProveedorNombre;
         AV101Vinculartrnwwds_21_tfproveedornombre_sel = AV49TFProveedorNombre_Sel;
         AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV50TFVincularTrnSolidicutd;
         AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV51TFVincularTrnSolidicutd_To;
         AV104Vinculartrnwwds_24_tfvinculartrnnombresol = AV52TFVincularTrnNombreSol;
         AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV53TFVincularTrnNombreSol_Sel;
         AV106Vinculartrnwwds_26_tfvinculartrntelefonosol = AV54TFVincularTrnTelefonoSol;
         AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV55TFVincularTrnTelefonoSol_Sel;
         AV108Vinculartrnwwds_28_tfdocumentacionid = AV56TFDocumentacionId;
         AV109Vinculartrnwwds_29_tfdocumentacionid_to = AV57TFDocumentacionId_To;
         AV110Vinculartrnwwds_30_tfvinculartrncomentario = AV58TFVincularTrnComentario;
         AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV59TFVincularTrnComentario_Sel;
         AV112Vinculartrnwwds_32_tfvinculartrnfecha = AV60TFVincularTrnFecha;
         AV113Vinculartrnwwds_33_tfvinculartrnfecha_to = AV61TFVincularTrnFecha_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20VincularTrnSolidicutd1, AV21ProveedorNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25VincularTrnSolidicutd2, AV26ProveedorNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30VincularTrnSolidicutd3, AV31ProveedorNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV44TFVincularTrnId, AV45TFVincularTrnId_To, AV46TFProveedorID, AV47TFProveedorID_To, AV48TFProveedorNombre, AV49TFProveedorNombre_Sel, AV50TFVincularTrnSolidicutd, AV51TFVincularTrnSolidicutd_To, AV52TFVincularTrnNombreSol, AV53TFVincularTrnNombreSol_Sel, AV54TFVincularTrnTelefonoSol, AV55TFVincularTrnTelefonoSol_Sel, AV56TFDocumentacionId, AV57TFDocumentacionId_To, AV58TFVincularTrnComentario, AV59TFVincularTrnComentario_Sel, AV60TFVincularTrnFecha, AV61TFVincularTrnFecha_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV72IsAuthorized_Update, AV73IsAuthorized_Delete, AV77IsAuthorized_ProveedorNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV81Vinculartrnwwds_1_filterfulltext = AV17FilterFullText;
         AV82Vinculartrnwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV83Vinculartrnwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV20VincularTrnSolidicutd1;
         AV85Vinculartrnwwds_5_proveedornombre1 = AV21ProveedorNombre1;
         AV86Vinculartrnwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV87Vinculartrnwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV88Vinculartrnwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV25VincularTrnSolidicutd2;
         AV90Vinculartrnwwds_10_proveedornombre2 = AV26ProveedorNombre2;
         AV91Vinculartrnwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV92Vinculartrnwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV93Vinculartrnwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV30VincularTrnSolidicutd3;
         AV95Vinculartrnwwds_15_proveedornombre3 = AV31ProveedorNombre3;
         AV96Vinculartrnwwds_16_tfvinculartrnid = AV44TFVincularTrnId;
         AV97Vinculartrnwwds_17_tfvinculartrnid_to = AV45TFVincularTrnId_To;
         AV98Vinculartrnwwds_18_tfproveedorid = AV46TFProveedorID;
         AV99Vinculartrnwwds_19_tfproveedorid_to = AV47TFProveedorID_To;
         AV100Vinculartrnwwds_20_tfproveedornombre = AV48TFProveedorNombre;
         AV101Vinculartrnwwds_21_tfproveedornombre_sel = AV49TFProveedorNombre_Sel;
         AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV50TFVincularTrnSolidicutd;
         AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV51TFVincularTrnSolidicutd_To;
         AV104Vinculartrnwwds_24_tfvinculartrnnombresol = AV52TFVincularTrnNombreSol;
         AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV53TFVincularTrnNombreSol_Sel;
         AV106Vinculartrnwwds_26_tfvinculartrntelefonosol = AV54TFVincularTrnTelefonoSol;
         AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV55TFVincularTrnTelefonoSol_Sel;
         AV108Vinculartrnwwds_28_tfdocumentacionid = AV56TFDocumentacionId;
         AV109Vinculartrnwwds_29_tfdocumentacionid_to = AV57TFDocumentacionId_To;
         AV110Vinculartrnwwds_30_tfvinculartrncomentario = AV58TFVincularTrnComentario;
         AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV59TFVincularTrnComentario_Sel;
         AV112Vinculartrnwwds_32_tfvinculartrnfecha = AV60TFVincularTrnFecha;
         AV113Vinculartrnwwds_33_tfvinculartrnfecha_to = AV61TFVincularTrnFecha_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20VincularTrnSolidicutd1, AV21ProveedorNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25VincularTrnSolidicutd2, AV26ProveedorNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30VincularTrnSolidicutd3, AV31ProveedorNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV44TFVincularTrnId, AV45TFVincularTrnId_To, AV46TFProveedorID, AV47TFProveedorID_To, AV48TFProveedorNombre, AV49TFProveedorNombre_Sel, AV50TFVincularTrnSolidicutd, AV51TFVincularTrnSolidicutd_To, AV52TFVincularTrnNombreSol, AV53TFVincularTrnNombreSol_Sel, AV54TFVincularTrnTelefonoSol, AV55TFVincularTrnTelefonoSol_Sel, AV56TFDocumentacionId, AV57TFDocumentacionId_To, AV58TFVincularTrnComentario, AV59TFVincularTrnComentario_Sel, AV60TFVincularTrnFecha, AV61TFVincularTrnFecha_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV72IsAuthorized_Update, AV73IsAuthorized_Delete, AV77IsAuthorized_ProveedorNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV81Vinculartrnwwds_1_filterfulltext = AV17FilterFullText;
         AV82Vinculartrnwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV83Vinculartrnwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV20VincularTrnSolidicutd1;
         AV85Vinculartrnwwds_5_proveedornombre1 = AV21ProveedorNombre1;
         AV86Vinculartrnwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV87Vinculartrnwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV88Vinculartrnwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV25VincularTrnSolidicutd2;
         AV90Vinculartrnwwds_10_proveedornombre2 = AV26ProveedorNombre2;
         AV91Vinculartrnwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV92Vinculartrnwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV93Vinculartrnwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV30VincularTrnSolidicutd3;
         AV95Vinculartrnwwds_15_proveedornombre3 = AV31ProveedorNombre3;
         AV96Vinculartrnwwds_16_tfvinculartrnid = AV44TFVincularTrnId;
         AV97Vinculartrnwwds_17_tfvinculartrnid_to = AV45TFVincularTrnId_To;
         AV98Vinculartrnwwds_18_tfproveedorid = AV46TFProveedorID;
         AV99Vinculartrnwwds_19_tfproveedorid_to = AV47TFProveedorID_To;
         AV100Vinculartrnwwds_20_tfproveedornombre = AV48TFProveedorNombre;
         AV101Vinculartrnwwds_21_tfproveedornombre_sel = AV49TFProveedorNombre_Sel;
         AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV50TFVincularTrnSolidicutd;
         AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV51TFVincularTrnSolidicutd_To;
         AV104Vinculartrnwwds_24_tfvinculartrnnombresol = AV52TFVincularTrnNombreSol;
         AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV53TFVincularTrnNombreSol_Sel;
         AV106Vinculartrnwwds_26_tfvinculartrntelefonosol = AV54TFVincularTrnTelefonoSol;
         AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV55TFVincularTrnTelefonoSol_Sel;
         AV108Vinculartrnwwds_28_tfdocumentacionid = AV56TFDocumentacionId;
         AV109Vinculartrnwwds_29_tfdocumentacionid_to = AV57TFDocumentacionId_To;
         AV110Vinculartrnwwds_30_tfvinculartrncomentario = AV58TFVincularTrnComentario;
         AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV59TFVincularTrnComentario_Sel;
         AV112Vinculartrnwwds_32_tfvinculartrnfecha = AV60TFVincularTrnFecha;
         AV113Vinculartrnwwds_33_tfvinculartrnfecha_to = AV61TFVincularTrnFecha_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20VincularTrnSolidicutd1, AV21ProveedorNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25VincularTrnSolidicutd2, AV26ProveedorNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30VincularTrnSolidicutd3, AV31ProveedorNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV44TFVincularTrnId, AV45TFVincularTrnId_To, AV46TFProveedorID, AV47TFProveedorID_To, AV48TFProveedorNombre, AV49TFProveedorNombre_Sel, AV50TFVincularTrnSolidicutd, AV51TFVincularTrnSolidicutd_To, AV52TFVincularTrnNombreSol, AV53TFVincularTrnNombreSol_Sel, AV54TFVincularTrnTelefonoSol, AV55TFVincularTrnTelefonoSol_Sel, AV56TFDocumentacionId, AV57TFDocumentacionId_To, AV58TFVincularTrnComentario, AV59TFVincularTrnComentario_Sel, AV60TFVincularTrnFecha, AV61TFVincularTrnFecha_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV72IsAuthorized_Update, AV73IsAuthorized_Delete, AV77IsAuthorized_ProveedorNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV81Vinculartrnwwds_1_filterfulltext = AV17FilterFullText;
         AV82Vinculartrnwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV83Vinculartrnwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV20VincularTrnSolidicutd1;
         AV85Vinculartrnwwds_5_proveedornombre1 = AV21ProveedorNombre1;
         AV86Vinculartrnwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV87Vinculartrnwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV88Vinculartrnwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV25VincularTrnSolidicutd2;
         AV90Vinculartrnwwds_10_proveedornombre2 = AV26ProveedorNombre2;
         AV91Vinculartrnwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV92Vinculartrnwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV93Vinculartrnwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV30VincularTrnSolidicutd3;
         AV95Vinculartrnwwds_15_proveedornombre3 = AV31ProveedorNombre3;
         AV96Vinculartrnwwds_16_tfvinculartrnid = AV44TFVincularTrnId;
         AV97Vinculartrnwwds_17_tfvinculartrnid_to = AV45TFVincularTrnId_To;
         AV98Vinculartrnwwds_18_tfproveedorid = AV46TFProveedorID;
         AV99Vinculartrnwwds_19_tfproveedorid_to = AV47TFProveedorID_To;
         AV100Vinculartrnwwds_20_tfproveedornombre = AV48TFProveedorNombre;
         AV101Vinculartrnwwds_21_tfproveedornombre_sel = AV49TFProveedorNombre_Sel;
         AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV50TFVincularTrnSolidicutd;
         AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV51TFVincularTrnSolidicutd_To;
         AV104Vinculartrnwwds_24_tfvinculartrnnombresol = AV52TFVincularTrnNombreSol;
         AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV53TFVincularTrnNombreSol_Sel;
         AV106Vinculartrnwwds_26_tfvinculartrntelefonosol = AV54TFVincularTrnTelefonoSol;
         AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV55TFVincularTrnTelefonoSol_Sel;
         AV108Vinculartrnwwds_28_tfdocumentacionid = AV56TFDocumentacionId;
         AV109Vinculartrnwwds_29_tfdocumentacionid_to = AV57TFDocumentacionId_To;
         AV110Vinculartrnwwds_30_tfvinculartrncomentario = AV58TFVincularTrnComentario;
         AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV59TFVincularTrnComentario_Sel;
         AV112Vinculartrnwwds_32_tfvinculartrnfecha = AV60TFVincularTrnFecha;
         AV113Vinculartrnwwds_33_tfvinculartrnfecha_to = AV61TFVincularTrnFecha_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20VincularTrnSolidicutd1, AV21ProveedorNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25VincularTrnSolidicutd2, AV26ProveedorNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30VincularTrnSolidicutd3, AV31ProveedorNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV44TFVincularTrnId, AV45TFVincularTrnId_To, AV46TFProveedorID, AV47TFProveedorID_To, AV48TFProveedorNombre, AV49TFProveedorNombre_Sel, AV50TFVincularTrnSolidicutd, AV51TFVincularTrnSolidicutd_To, AV52TFVincularTrnNombreSol, AV53TFVincularTrnNombreSol_Sel, AV54TFVincularTrnTelefonoSol, AV55TFVincularTrnTelefonoSol_Sel, AV56TFDocumentacionId, AV57TFDocumentacionId_To, AV58TFVincularTrnComentario, AV59TFVincularTrnComentario_Sel, AV60TFVincularTrnFecha, AV61TFVincularTrnFecha_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV72IsAuthorized_Update, AV73IsAuthorized_Delete, AV77IsAuthorized_ProveedorNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV81Vinculartrnwwds_1_filterfulltext = AV17FilterFullText;
         AV82Vinculartrnwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV83Vinculartrnwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV20VincularTrnSolidicutd1;
         AV85Vinculartrnwwds_5_proveedornombre1 = AV21ProveedorNombre1;
         AV86Vinculartrnwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV87Vinculartrnwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV88Vinculartrnwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV25VincularTrnSolidicutd2;
         AV90Vinculartrnwwds_10_proveedornombre2 = AV26ProveedorNombre2;
         AV91Vinculartrnwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV92Vinculartrnwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV93Vinculartrnwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV30VincularTrnSolidicutd3;
         AV95Vinculartrnwwds_15_proveedornombre3 = AV31ProveedorNombre3;
         AV96Vinculartrnwwds_16_tfvinculartrnid = AV44TFVincularTrnId;
         AV97Vinculartrnwwds_17_tfvinculartrnid_to = AV45TFVincularTrnId_To;
         AV98Vinculartrnwwds_18_tfproveedorid = AV46TFProveedorID;
         AV99Vinculartrnwwds_19_tfproveedorid_to = AV47TFProveedorID_To;
         AV100Vinculartrnwwds_20_tfproveedornombre = AV48TFProveedorNombre;
         AV101Vinculartrnwwds_21_tfproveedornombre_sel = AV49TFProveedorNombre_Sel;
         AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV50TFVincularTrnSolidicutd;
         AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV51TFVincularTrnSolidicutd_To;
         AV104Vinculartrnwwds_24_tfvinculartrnnombresol = AV52TFVincularTrnNombreSol;
         AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV53TFVincularTrnNombreSol_Sel;
         AV106Vinculartrnwwds_26_tfvinculartrntelefonosol = AV54TFVincularTrnTelefonoSol;
         AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV55TFVincularTrnTelefonoSol_Sel;
         AV108Vinculartrnwwds_28_tfdocumentacionid = AV56TFDocumentacionId;
         AV109Vinculartrnwwds_29_tfdocumentacionid_to = AV57TFDocumentacionId_To;
         AV110Vinculartrnwwds_30_tfvinculartrncomentario = AV58TFVincularTrnComentario;
         AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV59TFVincularTrnComentario_Sel;
         AV112Vinculartrnwwds_32_tfvinculartrnfecha = AV60TFVincularTrnFecha;
         AV113Vinculartrnwwds_33_tfvinculartrnfecha_to = AV61TFVincularTrnFecha_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20VincularTrnSolidicutd1, AV21ProveedorNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25VincularTrnSolidicutd2, AV26ProveedorNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30VincularTrnSolidicutd3, AV31ProveedorNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV44TFVincularTrnId, AV45TFVincularTrnId_To, AV46TFProveedorID, AV47TFProveedorID_To, AV48TFProveedorNombre, AV49TFProveedorNombre_Sel, AV50TFVincularTrnSolidicutd, AV51TFVincularTrnSolidicutd_To, AV52TFVincularTrnNombreSol, AV53TFVincularTrnNombreSol_Sel, AV54TFVincularTrnTelefonoSol, AV55TFVincularTrnTelefonoSol_Sel, AV56TFDocumentacionId, AV57TFDocumentacionId_To, AV58TFVincularTrnComentario, AV59TFVincularTrnComentario_Sel, AV60TFVincularTrnFecha, AV61TFVincularTrnFecha_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV72IsAuthorized_Update, AV73IsAuthorized_Delete, AV77IsAuthorized_ProveedorNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV80Pgmname = "VincularTrnWW";
         edtVincularTrnId_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtVincularTrnSolidicutd_Enabled = 0;
         edtVincularTrnNombreSol_Enabled = 0;
         edtVincularTrnTelefonoSol_Enabled = 0;
         edtDocumentacionId_Enabled = 0;
         edtVincularTrnImagen_Enabled = 0;
         edtVincularTrnComentario_Enabled = 0;
         edtVincularTrnFecha_Enabled = 0;
         edtDocumentacionIcono_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP470( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E27472 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV74AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV65DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV38ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_120 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_120"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV67GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV68GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV69GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV62DDO_VincularTrnFechaAuxDate = context.localUtil.CToD( cgiGet( "vDDO_VINCULARTRNFECHAAUXDATE"), 0);
            AV63DDO_VincularTrnFechaAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_VINCULARTRNFECHAAUXDATETO"), 0);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavVinculartrnsolidicutd1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavVinculartrnsolidicutd1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVINCULARTRNSOLIDICUTD1");
               GX_FocusControl = edtavVinculartrnsolidicutd1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20VincularTrnSolidicutd1 = 0;
               AssignAttri("", false, "AV20VincularTrnSolidicutd1", StringUtil.LTrimStr( (decimal)(AV20VincularTrnSolidicutd1), 18, 0));
            }
            else
            {
               AV20VincularTrnSolidicutd1 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavVinculartrnsolidicutd1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20VincularTrnSolidicutd1", StringUtil.LTrimStr( (decimal)(AV20VincularTrnSolidicutd1), 18, 0));
            }
            AV21ProveedorNombre1 = cgiGet( edtavProveedornombre1_Internalname);
            AssignAttri("", false, "AV21ProveedorNombre1", AV21ProveedorNombre1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavVinculartrnsolidicutd2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavVinculartrnsolidicutd2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVINCULARTRNSOLIDICUTD2");
               GX_FocusControl = edtavVinculartrnsolidicutd2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25VincularTrnSolidicutd2 = 0;
               AssignAttri("", false, "AV25VincularTrnSolidicutd2", StringUtil.LTrimStr( (decimal)(AV25VincularTrnSolidicutd2), 18, 0));
            }
            else
            {
               AV25VincularTrnSolidicutd2 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavVinculartrnsolidicutd2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25VincularTrnSolidicutd2", StringUtil.LTrimStr( (decimal)(AV25VincularTrnSolidicutd2), 18, 0));
            }
            AV26ProveedorNombre2 = cgiGet( edtavProveedornombre2_Internalname);
            AssignAttri("", false, "AV26ProveedorNombre2", AV26ProveedorNombre2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV28DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavVinculartrnsolidicutd3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavVinculartrnsolidicutd3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVINCULARTRNSOLIDICUTD3");
               GX_FocusControl = edtavVinculartrnsolidicutd3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30VincularTrnSolidicutd3 = 0;
               AssignAttri("", false, "AV30VincularTrnSolidicutd3", StringUtil.LTrimStr( (decimal)(AV30VincularTrnSolidicutd3), 18, 0));
            }
            else
            {
               AV30VincularTrnSolidicutd3 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavVinculartrnsolidicutd3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30VincularTrnSolidicutd3", StringUtil.LTrimStr( (decimal)(AV30VincularTrnSolidicutd3), 18, 0));
            }
            AV31ProveedorNombre3 = cgiGet( edtavProveedornombre3_Internalname);
            AssignAttri("", false, "AV31ProveedorNombre3", AV31ProveedorNombre3);
            AV64DDO_VincularTrnFechaAuxDateText = cgiGet( edtavDdo_vinculartrnfechaauxdatetext_Internalname);
            AssignAttri("", false, "AV64DDO_VincularTrnFechaAuxDateText", AV64DDO_VincularTrnFechaAuxDateText);
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vVINCULARTRNSOLIDICUTD1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV20VincularTrnSolidicutd1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE1"), AV21ProveedorNombre1) != 0 )
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vVINCULARTRNSOLIDICUTD2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV25VincularTrnSolidicutd2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE2"), AV26ProveedorNombre2) != 0 )
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vVINCULARTRNSOLIDICUTD3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV30VincularTrnSolidicutd3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROVEEDORNOMBRE3"), AV31ProveedorNombre3) != 0 )
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
         E27472 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E27472( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFVINCULARTRNFECHA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_vinculartrnfechaauxdatetext_Internalname});
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
         AV18DynamicFiltersSelector1 = "VINCULARTRNSOLIDICUTD";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector2 = "VINCULARTRNSOLIDICUTD";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28DynamicFiltersSelector3 = "VINCULARTRNSOLIDICUTD";
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
         AV74AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV75AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV75AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV75AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV75AGExportDataItem.gxTpr_Eventkey = "Export";
         AV75AGExportDataItem.gxTpr_Isdivider = false;
         AV74AGExportData.Add(AV75AGExportDataItem, 0);
         AV75AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV75AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV75AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV75AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV75AGExportDataItem.gxTpr_Isdivider = false;
         AV74AGExportData.Add(AV75AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV77IsAuthorized_ProveedorNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor", out  GXt_boolean1) ;
         AV77IsAuthorized_ProveedorNombre = GXt_boolean1;
         AssignAttri("", false, "AV77IsAuthorized_ProveedorNombre", AV77IsAuthorized_ProveedorNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROVEEDORNOMBRE", GetSecureSignedToken( "", AV77IsAuthorized_ProveedorNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Vincular Trns", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV65DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV65DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E28472( )
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
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "VINCULARTRNSOLIDICUTD") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "VINCULARTRNSOLIDICUTD") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            if ( AV27DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "VINCULARTRNSOLIDICUTD") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
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
         if ( StringUtil.StrCmp(AV40Session.Get("VincularTrnWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV40Session.Get("VincularTrnWWColumnsSelector");
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
         edtVincularTrnId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVincularTrnId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVincularTrnId_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtProveedorID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorID_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtProveedorNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProveedorNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtVincularTrnSolidicutd_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVincularTrnSolidicutd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVincularTrnSolidicutd_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtVincularTrnNombreSol_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVincularTrnNombreSol_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVincularTrnNombreSol_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtVincularTrnTelefonoSol_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVincularTrnTelefonoSol_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVincularTrnTelefonoSol_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtDocumentacionId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocumentacionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtVincularTrnImagen_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVincularTrnImagen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVincularTrnImagen_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtVincularTrnComentario_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVincularTrnComentario_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVincularTrnComentario_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtVincularTrnFecha_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVincularTrnFecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVincularTrnFecha_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtDocumentacionIcono_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocumentacionIcono_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentacionIcono_Visible), 5, 0), !bGXsfl_120_Refreshing);
         AV67GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV67GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV67GridCurrentPage), 10, 0));
         AV68GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV68GridPageCount", StringUtil.LTrimStr( (decimal)(AV68GridPageCount), 10, 0));
         GXt_char3 = AV69GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV80Pgmname, out  GXt_char3) ;
         AV69GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV69GridAppliedFilters", AV69GridAppliedFilters);
         AV81Vinculartrnwwds_1_filterfulltext = AV17FilterFullText;
         AV82Vinculartrnwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV83Vinculartrnwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV20VincularTrnSolidicutd1;
         AV85Vinculartrnwwds_5_proveedornombre1 = AV21ProveedorNombre1;
         AV86Vinculartrnwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV87Vinculartrnwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV88Vinculartrnwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV25VincularTrnSolidicutd2;
         AV90Vinculartrnwwds_10_proveedornombre2 = AV26ProveedorNombre2;
         AV91Vinculartrnwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV92Vinculartrnwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV93Vinculartrnwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV30VincularTrnSolidicutd3;
         AV95Vinculartrnwwds_15_proveedornombre3 = AV31ProveedorNombre3;
         AV96Vinculartrnwwds_16_tfvinculartrnid = AV44TFVincularTrnId;
         AV97Vinculartrnwwds_17_tfvinculartrnid_to = AV45TFVincularTrnId_To;
         AV98Vinculartrnwwds_18_tfproveedorid = AV46TFProveedorID;
         AV99Vinculartrnwwds_19_tfproveedorid_to = AV47TFProveedorID_To;
         AV100Vinculartrnwwds_20_tfproveedornombre = AV48TFProveedorNombre;
         AV101Vinculartrnwwds_21_tfproveedornombre_sel = AV49TFProveedorNombre_Sel;
         AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV50TFVincularTrnSolidicutd;
         AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV51TFVincularTrnSolidicutd_To;
         AV104Vinculartrnwwds_24_tfvinculartrnnombresol = AV52TFVincularTrnNombreSol;
         AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV53TFVincularTrnNombreSol_Sel;
         AV106Vinculartrnwwds_26_tfvinculartrntelefonosol = AV54TFVincularTrnTelefonoSol;
         AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV55TFVincularTrnTelefonoSol_Sel;
         AV108Vinculartrnwwds_28_tfdocumentacionid = AV56TFDocumentacionId;
         AV109Vinculartrnwwds_29_tfdocumentacionid_to = AV57TFDocumentacionId_To;
         AV110Vinculartrnwwds_30_tfvinculartrncomentario = AV58TFVincularTrnComentario;
         AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV59TFVincularTrnComentario_Sel;
         AV112Vinculartrnwwds_32_tfvinculartrnfecha = AV60TFVincularTrnFecha;
         AV113Vinculartrnwwds_33_tfvinculartrnfecha_to = AV61TFVincularTrnFecha_To;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12472( )
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
            AV66PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV66PageToGo) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E13472( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E16472( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VincularTrnId") == 0 )
            {
               AV44TFVincularTrnId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFVincularTrnId", StringUtil.LTrimStr( (decimal)(AV44TFVincularTrnId), 18, 0));
               AV45TFVincularTrnId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFVincularTrnId_To", StringUtil.LTrimStr( (decimal)(AV45TFVincularTrnId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorID") == 0 )
            {
               AV46TFProveedorID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFProveedorID", StringUtil.LTrimStr( (decimal)(AV46TFProveedorID), 18, 0));
               AV47TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFProveedorID_To", StringUtil.LTrimStr( (decimal)(AV47TFProveedorID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProveedorNombre") == 0 )
            {
               AV48TFProveedorNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFProveedorNombre", AV48TFProveedorNombre);
               AV49TFProveedorNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFProveedorNombre_Sel", AV49TFProveedorNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VincularTrnSolidicutd") == 0 )
            {
               AV50TFVincularTrnSolidicutd = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFVincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(AV50TFVincularTrnSolidicutd), 18, 0));
               AV51TFVincularTrnSolidicutd_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFVincularTrnSolidicutd_To", StringUtil.LTrimStr( (decimal)(AV51TFVincularTrnSolidicutd_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VincularTrnNombreSol") == 0 )
            {
               AV52TFVincularTrnNombreSol = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV52TFVincularTrnNombreSol", AV52TFVincularTrnNombreSol);
               AV53TFVincularTrnNombreSol_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV53TFVincularTrnNombreSol_Sel", AV53TFVincularTrnNombreSol_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VincularTrnTelefonoSol") == 0 )
            {
               AV54TFVincularTrnTelefonoSol = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFVincularTrnTelefonoSol", AV54TFVincularTrnTelefonoSol);
               AV55TFVincularTrnTelefonoSol_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFVincularTrnTelefonoSol_Sel", AV55TFVincularTrnTelefonoSol_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocumentacionId") == 0 )
            {
               AV56TFDocumentacionId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV56TFDocumentacionId", StringUtil.LTrimStr( (decimal)(AV56TFDocumentacionId), 18, 0));
               AV57TFDocumentacionId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV57TFDocumentacionId_To", StringUtil.LTrimStr( (decimal)(AV57TFDocumentacionId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VincularTrnComentario") == 0 )
            {
               AV58TFVincularTrnComentario = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV58TFVincularTrnComentario", AV58TFVincularTrnComentario);
               AV59TFVincularTrnComentario_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV59TFVincularTrnComentario_Sel", AV59TFVincularTrnComentario_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VincularTrnFecha") == 0 )
            {
               AV60TFVincularTrnFecha = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV60TFVincularTrnFecha", context.localUtil.Format(AV60TFVincularTrnFecha, "99/99/99"));
               AV61TFVincularTrnFecha_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV61TFVincularTrnFecha_To", context.localUtil.Format(AV61TFVincularTrnFecha_To, "99/99/99"));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E29472( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         if ( AV72IsAuthorized_Update )
         {
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV73IsAuthorized_Delete )
         {
            cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         if ( AV77IsAuthorized_ProveedorNombre )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "proveedorview.aspx"+UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtProveedorNombre_Link = formatLink("proveedorview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "vinculartrnview.aspx"+UrlEncode(StringUtil.LTrimStr(A491VincularTrnId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         edtVincularTrnSolidicutd_Link = formatLink("vinculartrnview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 120;
         }
         sendrow_1202( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_120_Refreshing )
         {
            context.DoAjaxLoad(120, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0));
      }

      protected void E17472( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV36ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV38ColumnsSelector.FromJSonString(AV36ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "VincularTrnWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV36ColumnsSelectorXML)) ? "" : AV38ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E22472( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20VincularTrnSolidicutd1, AV21ProveedorNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25VincularTrnSolidicutd2, AV26ProveedorNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30VincularTrnSolidicutd3, AV31ProveedorNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV44TFVincularTrnId, AV45TFVincularTrnId_To, AV46TFProveedorID, AV47TFProveedorID_To, AV48TFProveedorNombre, AV49TFProveedorNombre_Sel, AV50TFVincularTrnSolidicutd, AV51TFVincularTrnSolidicutd_To, AV52TFVincularTrnNombreSol, AV53TFVincularTrnNombreSol_Sel, AV54TFVincularTrnTelefonoSol, AV55TFVincularTrnTelefonoSol_Sel, AV56TFDocumentacionId, AV57TFDocumentacionId_To, AV58TFVincularTrnComentario, AV59TFVincularTrnComentario_Sel, AV60TFVincularTrnFecha, AV61TFVincularTrnFecha_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV72IsAuthorized_Update, AV73IsAuthorized_Delete, AV77IsAuthorized_ProveedorNombre) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E18472( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20VincularTrnSolidicutd1, AV21ProveedorNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25VincularTrnSolidicutd2, AV26ProveedorNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30VincularTrnSolidicutd3, AV31ProveedorNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV44TFVincularTrnId, AV45TFVincularTrnId_To, AV46TFProveedorID, AV47TFProveedorID_To, AV48TFProveedorNombre, AV49TFProveedorNombre_Sel, AV50TFVincularTrnSolidicutd, AV51TFVincularTrnSolidicutd_To, AV52TFVincularTrnNombreSol, AV53TFVincularTrnNombreSol_Sel, AV54TFVincularTrnTelefonoSol, AV55TFVincularTrnTelefonoSol_Sel, AV56TFDocumentacionId, AV57TFDocumentacionId_To, AV58TFVincularTrnComentario, AV59TFVincularTrnComentario_Sel, AV60TFVincularTrnFecha, AV61TFVincularTrnFecha_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV72IsAuthorized_Update, AV73IsAuthorized_Delete, AV77IsAuthorized_ProveedorNombre) ;
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

      protected void E23472( )
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

      protected void E24472( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20VincularTrnSolidicutd1, AV21ProveedorNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25VincularTrnSolidicutd2, AV26ProveedorNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30VincularTrnSolidicutd3, AV31ProveedorNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV44TFVincularTrnId, AV45TFVincularTrnId_To, AV46TFProveedorID, AV47TFProveedorID_To, AV48TFProveedorNombre, AV49TFProveedorNombre_Sel, AV50TFVincularTrnSolidicutd, AV51TFVincularTrnSolidicutd_To, AV52TFVincularTrnNombreSol, AV53TFVincularTrnNombreSol_Sel, AV54TFVincularTrnTelefonoSol, AV55TFVincularTrnTelefonoSol_Sel, AV56TFDocumentacionId, AV57TFDocumentacionId_To, AV58TFVincularTrnComentario, AV59TFVincularTrnComentario_Sel, AV60TFVincularTrnFecha, AV61TFVincularTrnFecha_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV72IsAuthorized_Update, AV73IsAuthorized_Delete, AV77IsAuthorized_ProveedorNombre) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E19472( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20VincularTrnSolidicutd1, AV21ProveedorNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25VincularTrnSolidicutd2, AV26ProveedorNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30VincularTrnSolidicutd3, AV31ProveedorNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV44TFVincularTrnId, AV45TFVincularTrnId_To, AV46TFProveedorID, AV47TFProveedorID_To, AV48TFProveedorNombre, AV49TFProveedorNombre_Sel, AV50TFVincularTrnSolidicutd, AV51TFVincularTrnSolidicutd_To, AV52TFVincularTrnNombreSol, AV53TFVincularTrnNombreSol_Sel, AV54TFVincularTrnTelefonoSol, AV55TFVincularTrnTelefonoSol_Sel, AV56TFDocumentacionId, AV57TFDocumentacionId_To, AV58TFVincularTrnComentario, AV59TFVincularTrnComentario_Sel, AV60TFVincularTrnFecha, AV61TFVincularTrnFecha_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV72IsAuthorized_Update, AV73IsAuthorized_Delete, AV77IsAuthorized_ProveedorNombre) ;
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

      protected void E25472( )
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

      protected void E20472( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20VincularTrnSolidicutd1, AV21ProveedorNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25VincularTrnSolidicutd2, AV26ProveedorNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30VincularTrnSolidicutd3, AV31ProveedorNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV44TFVincularTrnId, AV45TFVincularTrnId_To, AV46TFProveedorID, AV47TFProveedorID_To, AV48TFProveedorNombre, AV49TFProveedorNombre_Sel, AV50TFVincularTrnSolidicutd, AV51TFVincularTrnSolidicutd_To, AV52TFVincularTrnNombreSol, AV53TFVincularTrnNombreSol_Sel, AV54TFVincularTrnTelefonoSol, AV55TFVincularTrnTelefonoSol_Sel, AV56TFDocumentacionId, AV57TFDocumentacionId_To, AV58TFVincularTrnComentario, AV59TFVincularTrnComentario_Sel, AV60TFVincularTrnFecha, AV61TFVincularTrnFecha_To, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV72IsAuthorized_Update, AV73IsAuthorized_Delete, AV77IsAuthorized_ProveedorNombre) ;
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

      protected void E26472( )
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

      protected void E11472( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("VincularTrnWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV80Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("VincularTrnWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "VincularTrnWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV42ManageFiltersXml = GXt_char3;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV80Pgmname+"GridState",  AV42ManageFiltersXml) ;
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

      protected void E30472( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV70GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV70GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV70GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV70GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E21472( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "vinculartrn.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("vinculartrn.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14472( )
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

      protected void E15472( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0147",(string)"",(string)"VincularTrn",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0147"+"");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "VincularTrnId",  "",  "Nro",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "ProveedorID",  "",  "Código del Proveedor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "ProveedorNombre",  "",  "Proveedor Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "VincularTrnSolidicutd",  "",  "Solicitud",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "VincularTrnNombreSol",  "",  "Nombre del Cliente",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "VincularTrnTelefonoSol",  "",  "Teléfono del Cliente",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "DocumentacionId",  "",  "Documentación",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "VincularTrnImagen",  "",  "Fotografia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "VincularTrnComentario",  "",  "Comentario",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "VincularTrnFecha",  "",  "Fecha",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "DocumentacionIcono",  "",  "Icono",  true,  "") ;
         GXt_char3 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "VincularTrnWWColumnsSelector", out  GXt_char3) ;
         AV37UserCustomValue = GXt_char3;
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
         GXt_boolean1 = AV72IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWVincularTrn_Update", out  GXt_boolean1) ;
         AV72IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV72IsAuthorized_Update", AV72IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV72IsAuthorized_Update, context));
         GXt_boolean1 = AV73IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWVincularTrn_Delete", out  GXt_boolean1) ;
         AV73IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV73IsAuthorized_Delete", AV73IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV73IsAuthorized_Delete, context));
         GXt_boolean1 = AV76TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWVincularTrn_Insert", out  GXt_boolean1) ;
         AV76TempBoolean = GXt_boolean1;
         if ( ! ( AV76TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV76TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean1) ;
         AV76TempBoolean = GXt_boolean1;
         if ( ! ( AV76TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "VincularTrn",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavVinculartrnsolidicutd1_Visible = 0;
         AssignProp("", false, edtavVinculartrnsolidicutd1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVinculartrnsolidicutd1_Visible), 5, 0), true);
         edtavProveedornombre1_Visible = 0;
         AssignProp("", false, edtavProveedornombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "VINCULARTRNSOLIDICUTD") == 0 )
         {
            edtavVinculartrnsolidicutd1_Visible = 1;
            AssignProp("", false, edtavVinculartrnsolidicutd1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVinculartrnsolidicutd1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
         {
            edtavProveedornombre1_Visible = 1;
            AssignProp("", false, edtavProveedornombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavVinculartrnsolidicutd2_Visible = 0;
         AssignProp("", false, edtavVinculartrnsolidicutd2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVinculartrnsolidicutd2_Visible), 5, 0), true);
         edtavProveedornombre2_Visible = 0;
         AssignProp("", false, edtavProveedornombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "VINCULARTRNSOLIDICUTD") == 0 )
         {
            edtavVinculartrnsolidicutd2_Visible = 1;
            AssignProp("", false, edtavVinculartrnsolidicutd2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVinculartrnsolidicutd2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
         {
            edtavProveedornombre2_Visible = 1;
            AssignProp("", false, edtavProveedornombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavVinculartrnsolidicutd3_Visible = 0;
         AssignProp("", false, edtavVinculartrnsolidicutd3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVinculartrnsolidicutd3_Visible), 5, 0), true);
         edtavProveedornombre3_Visible = 0;
         AssignProp("", false, edtavProveedornombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "VINCULARTRNSOLIDICUTD") == 0 )
         {
            edtavVinculartrnsolidicutd3_Visible = 1;
            AssignProp("", false, edtavVinculartrnsolidicutd3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVinculartrnsolidicutd3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
         {
            edtavProveedornombre3_Visible = 1;
            AssignProp("", false, edtavProveedornombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProveedornombre3_Visible), 5, 0), true);
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
         AV23DynamicFiltersSelector2 = "VINCULARTRNSOLIDICUTD";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV25VincularTrnSolidicutd2 = 0;
         AssignAttri("", false, "AV25VincularTrnSolidicutd2", StringUtil.LTrimStr( (decimal)(AV25VincularTrnSolidicutd2), 18, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         AV28DynamicFiltersSelector3 = "VINCULARTRNSOLIDICUTD";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AV30VincularTrnSolidicutd3 = 0;
         AssignAttri("", false, "AV30VincularTrnSolidicutd3", StringUtil.LTrimStr( (decimal)(AV30VincularTrnSolidicutd3), 18, 0));
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "VincularTrnWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV44TFVincularTrnId = 0;
         AssignAttri("", false, "AV44TFVincularTrnId", StringUtil.LTrimStr( (decimal)(AV44TFVincularTrnId), 18, 0));
         AV45TFVincularTrnId_To = 0;
         AssignAttri("", false, "AV45TFVincularTrnId_To", StringUtil.LTrimStr( (decimal)(AV45TFVincularTrnId_To), 18, 0));
         AV46TFProveedorID = 0;
         AssignAttri("", false, "AV46TFProveedorID", StringUtil.LTrimStr( (decimal)(AV46TFProveedorID), 18, 0));
         AV47TFProveedorID_To = 0;
         AssignAttri("", false, "AV47TFProveedorID_To", StringUtil.LTrimStr( (decimal)(AV47TFProveedorID_To), 18, 0));
         AV48TFProveedorNombre = "";
         AssignAttri("", false, "AV48TFProveedorNombre", AV48TFProveedorNombre);
         AV49TFProveedorNombre_Sel = "";
         AssignAttri("", false, "AV49TFProveedorNombre_Sel", AV49TFProveedorNombre_Sel);
         AV50TFVincularTrnSolidicutd = 0;
         AssignAttri("", false, "AV50TFVincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(AV50TFVincularTrnSolidicutd), 18, 0));
         AV51TFVincularTrnSolidicutd_To = 0;
         AssignAttri("", false, "AV51TFVincularTrnSolidicutd_To", StringUtil.LTrimStr( (decimal)(AV51TFVincularTrnSolidicutd_To), 18, 0));
         AV52TFVincularTrnNombreSol = "";
         AssignAttri("", false, "AV52TFVincularTrnNombreSol", AV52TFVincularTrnNombreSol);
         AV53TFVincularTrnNombreSol_Sel = "";
         AssignAttri("", false, "AV53TFVincularTrnNombreSol_Sel", AV53TFVincularTrnNombreSol_Sel);
         AV54TFVincularTrnTelefonoSol = "";
         AssignAttri("", false, "AV54TFVincularTrnTelefonoSol", AV54TFVincularTrnTelefonoSol);
         AV55TFVincularTrnTelefonoSol_Sel = "";
         AssignAttri("", false, "AV55TFVincularTrnTelefonoSol_Sel", AV55TFVincularTrnTelefonoSol_Sel);
         AV56TFDocumentacionId = 0;
         AssignAttri("", false, "AV56TFDocumentacionId", StringUtil.LTrimStr( (decimal)(AV56TFDocumentacionId), 18, 0));
         AV57TFDocumentacionId_To = 0;
         AssignAttri("", false, "AV57TFDocumentacionId_To", StringUtil.LTrimStr( (decimal)(AV57TFDocumentacionId_To), 18, 0));
         AV58TFVincularTrnComentario = "";
         AssignAttri("", false, "AV58TFVincularTrnComentario", AV58TFVincularTrnComentario);
         AV59TFVincularTrnComentario_Sel = "";
         AssignAttri("", false, "AV59TFVincularTrnComentario_Sel", AV59TFVincularTrnComentario_Sel);
         AV60TFVincularTrnFecha = DateTime.MinValue;
         AssignAttri("", false, "AV60TFVincularTrnFecha", context.localUtil.Format(AV60TFVincularTrnFecha, "99/99/99"));
         AV61TFVincularTrnFecha_To = DateTime.MinValue;
         AssignAttri("", false, "AV61TFVincularTrnFecha_To", context.localUtil.Format(AV61TFVincularTrnFecha_To, "99/99/99"));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "VINCULARTRNSOLIDICUTD";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20VincularTrnSolidicutd1 = 0;
         AssignAttri("", false, "AV20VincularTrnSolidicutd1", StringUtil.LTrimStr( (decimal)(AV20VincularTrnSolidicutd1), 18, 0));
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
         GXEncryptionTmp = "vinculartrnview.aspx"+UrlEncode(StringUtil.LTrimStr(A491VincularTrnId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("vinculartrnview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "vinculartrn.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A491VincularTrnId,18,0));
         CallWebObject(formatLink("vinculartrn.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "vinculartrn.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A491VincularTrnId,18,0));
         CallWebObject(formatLink("vinculartrn.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV80Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV80Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV40Session.Get(AV80Pgmname+"GridState"), null, "", "");
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
         AV114GXV1 = 1;
         while ( AV114GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV114GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNID") == 0 )
            {
               AV44TFVincularTrnId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFVincularTrnId", StringUtil.LTrimStr( (decimal)(AV44TFVincularTrnId), 18, 0));
               AV45TFVincularTrnId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFVincularTrnId_To", StringUtil.LTrimStr( (decimal)(AV45TFVincularTrnId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV46TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFProveedorID", StringUtil.LTrimStr( (decimal)(AV46TFProveedorID), 18, 0));
               AV47TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFProveedorID_To", StringUtil.LTrimStr( (decimal)(AV47TFProveedorID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV48TFProveedorNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFProveedorNombre", AV48TFProveedorNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV49TFProveedorNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFProveedorNombre_Sel", AV49TFProveedorNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNSOLIDICUTD") == 0 )
            {
               AV50TFVincularTrnSolidicutd = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV50TFVincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(AV50TFVincularTrnSolidicutd), 18, 0));
               AV51TFVincularTrnSolidicutd_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51TFVincularTrnSolidicutd_To", StringUtil.LTrimStr( (decimal)(AV51TFVincularTrnSolidicutd_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNNOMBRESOL") == 0 )
            {
               AV52TFVincularTrnNombreSol = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFVincularTrnNombreSol", AV52TFVincularTrnNombreSol);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNNOMBRESOL_SEL") == 0 )
            {
               AV53TFVincularTrnNombreSol_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFVincularTrnNombreSol_Sel", AV53TFVincularTrnNombreSol_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNTELEFONOSOL") == 0 )
            {
               AV54TFVincularTrnTelefonoSol = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFVincularTrnTelefonoSol", AV54TFVincularTrnTelefonoSol);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNTELEFONOSOL_SEL") == 0 )
            {
               AV55TFVincularTrnTelefonoSol_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFVincularTrnTelefonoSol_Sel", AV55TFVincularTrnTelefonoSol_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCUMENTACIONID") == 0 )
            {
               AV56TFDocumentacionId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV56TFDocumentacionId", StringUtil.LTrimStr( (decimal)(AV56TFDocumentacionId), 18, 0));
               AV57TFDocumentacionId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV57TFDocumentacionId_To", StringUtil.LTrimStr( (decimal)(AV57TFDocumentacionId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNCOMENTARIO") == 0 )
            {
               AV58TFVincularTrnComentario = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV58TFVincularTrnComentario", AV58TFVincularTrnComentario);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNCOMENTARIO_SEL") == 0 )
            {
               AV59TFVincularTrnComentario_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFVincularTrnComentario_Sel", AV59TFVincularTrnComentario_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNFECHA") == 0 )
            {
               AV60TFVincularTrnFecha = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV60TFVincularTrnFecha", context.localUtil.Format(AV60TFVincularTrnFecha, "99/99/99"));
               AV61TFVincularTrnFecha_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV61TFVincularTrnFecha_To", context.localUtil.Format(AV61TFVincularTrnFecha_To, "99/99/99"));
            }
            AV114GXV1 = (int)(AV114GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProveedorNombre_Sel)),  AV49TFProveedorNombre_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFVincularTrnNombreSol_Sel)),  AV53TFVincularTrnNombreSol_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFVincularTrnTelefonoSol_Sel)),  AV55TFVincularTrnTelefonoSol_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFVincularTrnComentario_Sel)),  AV59TFVincularTrnComentario_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char3+"||"+GXt_char5+"|"+GXt_char6+"|||"+GXt_char7+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProveedorNombre)),  AV48TFProveedorNombre, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFVincularTrnNombreSol)),  AV52TFVincularTrnNombreSol, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFVincularTrnTelefonoSol)),  AV54TFVincularTrnTelefonoSol, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV58TFVincularTrnComentario)),  AV58TFVincularTrnComentario, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV44TFVincularTrnId) ? "" : StringUtil.Str( (decimal)(AV44TFVincularTrnId), 18, 0))+"|"+((0==AV46TFProveedorID) ? "" : StringUtil.Str( (decimal)(AV46TFProveedorID), 18, 0))+"|"+GXt_char7+"|"+((0==AV50TFVincularTrnSolidicutd) ? "" : StringUtil.Str( (decimal)(AV50TFVincularTrnSolidicutd), 18, 0))+"|"+GXt_char6+"|"+GXt_char5+"|"+((0==AV56TFDocumentacionId) ? "" : StringUtil.Str( (decimal)(AV56TFDocumentacionId), 18, 0))+"||"+GXt_char3+"|"+((DateTime.MinValue==AV60TFVincularTrnFecha) ? "" : context.localUtil.DToC( AV60TFVincularTrnFecha, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV45TFVincularTrnId_To) ? "" : StringUtil.Str( (decimal)(AV45TFVincularTrnId_To), 18, 0))+"|"+((0==AV47TFProveedorID_To) ? "" : StringUtil.Str( (decimal)(AV47TFProveedorID_To), 18, 0))+"||"+((0==AV51TFVincularTrnSolidicutd_To) ? "" : StringUtil.Str( (decimal)(AV51TFVincularTrnSolidicutd_To), 18, 0))+"|||"+((0==AV57TFDocumentacionId_To) ? "" : StringUtil.Str( (decimal)(AV57TFDocumentacionId_To), 18, 0))+"|||"+((DateTime.MinValue==AV61TFVincularTrnFecha_To) ? "" : context.localUtil.DToC( AV61TFVincularTrnFecha_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "VINCULARTRNSOLIDICUTD") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20VincularTrnSolidicutd1 = (long)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20VincularTrnSolidicutd1", StringUtil.LTrimStr( (decimal)(AV20VincularTrnSolidicutd1), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV21ProveedorNombre1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21ProveedorNombre1", AV21ProveedorNombre1);
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
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "VINCULARTRNSOLIDICUTD") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25VincularTrnSolidicutd2 = (long)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV25VincularTrnSolidicutd2", StringUtil.LTrimStr( (decimal)(AV25VincularTrnSolidicutd2), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV26ProveedorNombre2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26ProveedorNombre2", AV26ProveedorNombre2);
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
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "VINCULARTRNSOLIDICUTD") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV30VincularTrnSolidicutd3 = (long)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV30VincularTrnSolidicutd3", StringUtil.LTrimStr( (decimal)(AV30VincularTrnSolidicutd3), 18, 0));
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV31ProveedorNombre3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31ProveedorNombre3", AV31ProveedorNombre3);
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
         AV11GridState.FromXml(AV40Session.Get(AV80Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFVINCULARTRNID",  context.GetMessage( "Nro", ""),  !((0==AV44TFVincularTrnId)&&(0==AV45TFVincularTrnId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFVincularTrnId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV45TFVincularTrnId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPROVEEDORID",  context.GetMessage( "Código del Proveedor", ""),  !((0==AV46TFProveedorID)&&(0==AV47TFProveedorID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV46TFProveedorID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFProveedorID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROVEEDORNOMBRE",  context.GetMessage( "Proveedor Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProveedorNombre)),  0,  AV48TFProveedorNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProveedorNombre_Sel)),  AV49TFProveedorNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFVINCULARTRNSOLIDICUTD",  context.GetMessage( "Solicitud", ""),  !((0==AV50TFVincularTrnSolidicutd)&&(0==AV51TFVincularTrnSolidicutd_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV50TFVincularTrnSolidicutd), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV51TFVincularTrnSolidicutd_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFVINCULARTRNNOMBRESOL",  context.GetMessage( "Nombre del Cliente", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFVincularTrnNombreSol)),  0,  AV52TFVincularTrnNombreSol,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFVincularTrnNombreSol_Sel)),  AV53TFVincularTrnNombreSol_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFVINCULARTRNTELEFONOSOL",  context.GetMessage( "Teléfono del Cliente", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFVincularTrnTelefonoSol)),  0,  AV54TFVincularTrnTelefonoSol,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFVincularTrnTelefonoSol_Sel)),  AV55TFVincularTrnTelefonoSol_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCUMENTACIONID",  context.GetMessage( "Documentación", ""),  !((0==AV56TFDocumentacionId)&&(0==AV57TFDocumentacionId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV56TFDocumentacionId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV57TFDocumentacionId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFVINCULARTRNCOMENTARIO",  context.GetMessage( "Comentario", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV58TFVincularTrnComentario)),  0,  AV58TFVincularTrnComentario,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFVincularTrnComentario_Sel)),  AV59TFVincularTrnComentario_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFVINCULARTRNFECHA",  context.GetMessage( "Fecha", ""),  !((DateTime.MinValue==AV60TFVincularTrnFecha)&&(DateTime.MinValue==AV61TFVincularTrnFecha_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV60TFVincularTrnFecha, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV61TFVincularTrnFecha_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV80Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ! (0==AV20VincularTrnSolidicutd1) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Solicitud", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV20VincularTrnSolidicutd1), 18, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ProveedorNombre1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV21ProveedorNombre1;
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
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ! (0==AV25VincularTrnSolidicutd2) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Solicitud", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV25VincularTrnSolidicutd2), 18, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ProveedorNombre2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV26ProveedorNombre2;
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
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ! (0==AV30VincularTrnSolidicutd3) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Solicitud", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV30VincularTrnSolidicutd3), 18, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ProveedorNombre3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Proveedor Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV31ProveedorNombre3;
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
         AV9TrnContext.gxTpr_Callerobject = AV80Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "VincularTrn";
         AV40Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         new vinculartrnwwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("vinculartrnwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_99_472( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "", true, 0, "HLP_VincularTrnWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_vinculartrnsolidicutd3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVinculartrnsolidicutd3_Internalname, context.GetMessage( "Vincular Trn Solidicutd3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVinculartrnsolidicutd3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30VincularTrnSolidicutd3), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavVinculartrnsolidicutd3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30VincularTrnSolidicutd3), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV30VincularTrnSolidicutd3), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVinculartrnsolidicutd3_Jsonclick, 0, "Attribute", "", "", "", "", edtavVinculartrnsolidicutd3_Visible, edtavVinculartrnsolidicutd3_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_proveedornombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProveedornombre3_Internalname, context.GetMessage( "Proveedor Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProveedornombre3_Internalname, StringUtil.RTrim( AV31ProveedorNombre3), StringUtil.RTrim( context.localUtil.Format( AV31ProveedorNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProveedornombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavProveedornombre3_Visible, edtavProveedornombre3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_VincularTrnWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_99_472e( true) ;
         }
         else
         {
            wb_table4_99_472e( false) ;
         }
      }

      protected void wb_table3_74_472( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, 0, "HLP_VincularTrnWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_vinculartrnsolidicutd2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVinculartrnsolidicutd2_Internalname, context.GetMessage( "Vincular Trn Solidicutd2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVinculartrnsolidicutd2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25VincularTrnSolidicutd2), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavVinculartrnsolidicutd2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25VincularTrnSolidicutd2), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV25VincularTrnSolidicutd2), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVinculartrnsolidicutd2_Jsonclick, 0, "Attribute", "", "", "", "", edtavVinculartrnsolidicutd2_Visible, edtavVinculartrnsolidicutd2_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_proveedornombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProveedornombre2_Internalname, context.GetMessage( "Proveedor Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProveedornombre2_Internalname, StringUtil.RTrim( AV26ProveedorNombre2), StringUtil.RTrim( context.localUtil.Format( AV26ProveedorNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProveedornombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavProveedornombre2_Visible, edtavProveedornombre2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_VincularTrnWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_VincularTrnWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_74_472e( true) ;
         }
         else
         {
            wb_table3_74_472e( false) ;
         }
      }

      protected void wb_table2_49_472( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_VincularTrnWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_vinculartrnsolidicutd1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVinculartrnsolidicutd1_Internalname, context.GetMessage( "Vincular Trn Solidicutd1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVinculartrnsolidicutd1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20VincularTrnSolidicutd1), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavVinculartrnsolidicutd1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20VincularTrnSolidicutd1), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV20VincularTrnSolidicutd1), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVinculartrnsolidicutd1_Jsonclick, 0, "Attribute", "", "", "", "", edtavVinculartrnsolidicutd1_Visible, edtavVinculartrnsolidicutd1_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_proveedornombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProveedornombre1_Internalname, context.GetMessage( "Proveedor Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProveedornombre1_Internalname, StringUtil.RTrim( AV21ProveedorNombre1), StringUtil.RTrim( context.localUtil.Format( AV21ProveedorNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProveedornombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavProveedornombre1_Visible, edtavProveedornombre1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_VincularTrnWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_VincularTrnWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_472e( true) ;
         }
         else
         {
            wb_table2_49_472e( false) ;
         }
      }

      protected void wb_table1_25_472( bool wbgen )
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
            wb_table5_30_472( true) ;
         }
         else
         {
            wb_table5_30_472( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_472e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_472e( true) ;
         }
         else
         {
            wb_table1_25_472e( false) ;
         }
      }

      protected void wb_table5_30_472( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_VincularTrnWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_472e( true) ;
         }
         else
         {
            wb_table5_30_472e( false) ;
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
         PA472( ) ;
         WS472( ) ;
         WE472( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202693201418", true, true, false);
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
         context.AddJavascriptSource("vinculartrnww.js", "?202693201418", false, true, false);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1202( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_120_idx;
         edtVincularTrnId_Internalname = "VINCULARTRNID_"+sGXsfl_120_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_120_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_120_idx;
         edtVincularTrnSolidicutd_Internalname = "VINCULARTRNSOLIDICUTD_"+sGXsfl_120_idx;
         edtVincularTrnNombreSol_Internalname = "VINCULARTRNNOMBRESOL_"+sGXsfl_120_idx;
         edtVincularTrnTelefonoSol_Internalname = "VINCULARTRNTELEFONOSOL_"+sGXsfl_120_idx;
         edtDocumentacionId_Internalname = "DOCUMENTACIONID_"+sGXsfl_120_idx;
         edtVincularTrnImagen_Internalname = "VINCULARTRNIMAGEN_"+sGXsfl_120_idx;
         edtVincularTrnComentario_Internalname = "VINCULARTRNCOMENTARIO_"+sGXsfl_120_idx;
         edtVincularTrnFecha_Internalname = "VINCULARTRNFECHA_"+sGXsfl_120_idx;
         edtDocumentacionIcono_Internalname = "DOCUMENTACIONICONO_"+sGXsfl_120_idx;
      }

      protected void SubsflControlProps_fel_1202( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_120_fel_idx;
         edtVincularTrnId_Internalname = "VINCULARTRNID_"+sGXsfl_120_fel_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_120_fel_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_120_fel_idx;
         edtVincularTrnSolidicutd_Internalname = "VINCULARTRNSOLIDICUTD_"+sGXsfl_120_fel_idx;
         edtVincularTrnNombreSol_Internalname = "VINCULARTRNNOMBRESOL_"+sGXsfl_120_fel_idx;
         edtVincularTrnTelefonoSol_Internalname = "VINCULARTRNTELEFONOSOL_"+sGXsfl_120_fel_idx;
         edtDocumentacionId_Internalname = "DOCUMENTACIONID_"+sGXsfl_120_fel_idx;
         edtVincularTrnImagen_Internalname = "VINCULARTRNIMAGEN_"+sGXsfl_120_fel_idx;
         edtVincularTrnComentario_Internalname = "VINCULARTRNCOMENTARIO_"+sGXsfl_120_fel_idx;
         edtVincularTrnFecha_Internalname = "VINCULARTRNFECHA_"+sGXsfl_120_fel_idx;
         edtDocumentacionIcono_Internalname = "DOCUMENTACIONICONO_"+sGXsfl_120_fel_idx;
      }

      protected void sendrow_1202( )
      {
         sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
         SubsflControlProps_1202( ) ;
         WB470( ) ;
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
                  AV70GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_120_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_120_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtVincularTrnId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A491VincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVincularTrnId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVincularTrnId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtProveedorID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProveedorID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProveedorNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorNombre_Internalname,StringUtil.RTrim( A282ProveedorNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProveedorNombre_Link,(string)"",(string)"",(string)"",(string)edtProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProveedorNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtVincularTrnSolidicutd_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnSolidicutd_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A492VincularTrnSolidicutd), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A492VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtVincularTrnSolidicutd_Link,(string)"",(string)"",(string)"",(string)edtVincularTrnSolidicutd_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVincularTrnSolidicutd_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtVincularTrnNombreSol_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnNombreSol_Internalname,StringUtil.RTrim( A493VincularTrnNombreSol),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVincularTrnNombreSol_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVincularTrnNombreSol_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtVincularTrnTelefonoSol_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A494VincularTrnTelefonoSol);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnTelefonoSol_Internalname,StringUtil.RTrim( A494VincularTrnTelefonoSol),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtVincularTrnTelefonoSol_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVincularTrnTelefonoSol_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtDocumentacionId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentacionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentacionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocumentacionId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtVincularTrnImagen_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A495VincularTrnImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000VincularTrnImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.PathToRelativeUrl( A495VincularTrnImagen));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtVincularTrnImagen_Visible,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A495VincularTrnImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtVincularTrnComentario_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnComentario_Internalname,(string)A497VincularTrnComentario,(string)A497VincularTrnComentario,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVincularTrnComentario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVincularTrnComentario_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)120,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtVincularTrnFecha_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVincularTrnFecha_Internalname,context.localUtil.Format(A496VincularTrnFecha, "99/99/99"),context.localUtil.Format( A496VincularTrnFecha, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVincularTrnFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVincularTrnFecha_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtDocumentacionIcono_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A498DocumentacionIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40002DocumentacionIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40002DocumentacionIcono_GXI : context.PathToRelativeUrl( A498DocumentacionIcono));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentacionIcono_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtDocumentacionIcono_Visible,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A498DocumentacionIcono_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            send_integrity_lvl_hashes472( ) ;
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
         cmbavDynamicfiltersselector1.addItem("VINCULARTRNSOLIDICUTD", context.GetMessage( "Solicitud", ""), 0);
         cmbavDynamicfiltersselector1.addItem("PROVEEDORNOMBRE", context.GetMessage( "Proveedor Nombre", ""), 0);
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
         cmbavDynamicfiltersselector2.addItem("VINCULARTRNSOLIDICUTD", context.GetMessage( "Solicitud", ""), 0);
         cmbavDynamicfiltersselector2.addItem("PROVEEDORNOMBRE", context.GetMessage( "Proveedor Nombre", ""), 0);
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
         cmbavDynamicfiltersselector3.addItem("VINCULARTRNSOLIDICUTD", context.GetMessage( "Solicitud", ""), 0);
         cmbavDynamicfiltersselector3.addItem("PROVEEDORNOMBRE", context.GetMessage( "Proveedor Nombre", ""), 0);
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
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_120_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV70GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActions), 4, 0));
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVincularTrnId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nro", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código del Proveedor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProveedorNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Proveedor Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVincularTrnSolidicutd_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitud", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVincularTrnNombreSol_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre del Cliente", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVincularTrnTelefonoSol_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono del Cliente", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocumentacionId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Documentación", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVincularTrnImagen_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fotografia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVincularTrnComentario_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comentario", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVincularTrnFecha_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocumentacionIcono_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Icono", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A491VincularTrnId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVincularTrnId_Visible), 5, 0, ".", "")));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A492VincularTrnSolidicutd), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtVincularTrnSolidicutd_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVincularTrnSolidicutd_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A493VincularTrnNombreSol)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVincularTrnNombreSol_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A494VincularTrnTelefonoSol)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVincularTrnTelefonoSol_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocumentacionId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A495VincularTrnImagen));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVincularTrnImagen_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A497VincularTrnComentario));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVincularTrnComentario_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A496VincularTrnFecha, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVincularTrnFecha_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A498DocumentacionIcono));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocumentacionIcono_Visible), 5, 0, ".", "")));
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
         edtavVinculartrnsolidicutd1_Internalname = "vVINCULARTRNSOLIDICUTD1";
         cellFilter_vinculartrnsolidicutd1_cell_Internalname = "FILTER_VINCULARTRNSOLIDICUTD1_CELL";
         edtavProveedornombre1_Internalname = "vPROVEEDORNOMBRE1";
         cellFilter_proveedornombre1_cell_Internalname = "FILTER_PROVEEDORNOMBRE1_CELL";
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
         edtavVinculartrnsolidicutd2_Internalname = "vVINCULARTRNSOLIDICUTD2";
         cellFilter_vinculartrnsolidicutd2_cell_Internalname = "FILTER_VINCULARTRNSOLIDICUTD2_CELL";
         edtavProveedornombre2_Internalname = "vPROVEEDORNOMBRE2";
         cellFilter_proveedornombre2_cell_Internalname = "FILTER_PROVEEDORNOMBRE2_CELL";
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
         edtavVinculartrnsolidicutd3_Internalname = "vVINCULARTRNSOLIDICUTD3";
         cellFilter_vinculartrnsolidicutd3_cell_Internalname = "FILTER_VINCULARTRNSOLIDICUTD3_CELL";
         edtavProveedornombre3_Internalname = "vPROVEEDORNOMBRE3";
         cellFilter_proveedornombre3_cell_Internalname = "FILTER_PROVEEDORNOMBRE3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtVincularTrnId_Internalname = "VINCULARTRNID";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtVincularTrnSolidicutd_Internalname = "VINCULARTRNSOLIDICUTD";
         edtVincularTrnNombreSol_Internalname = "VINCULARTRNNOMBRESOL";
         edtVincularTrnTelefonoSol_Internalname = "VINCULARTRNTELEFONOSOL";
         edtDocumentacionId_Internalname = "DOCUMENTACIONID";
         edtVincularTrnImagen_Internalname = "VINCULARTRNIMAGEN";
         edtVincularTrnComentario_Internalname = "VINCULARTRNCOMENTARIO";
         edtVincularTrnFecha_Internalname = "VINCULARTRNFECHA";
         edtDocumentacionIcono_Internalname = "DOCUMENTACIONICONO";
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
         edtavDdo_vinculartrnfechaauxdatetext_Internalname = "vDDO_VINCULARTRNFECHAAUXDATETEXT";
         Tfvinculartrnfecha_rangepicker_Internalname = "TFVINCULARTRNFECHA_RANGEPICKER";
         divDdo_vinculartrnfechaauxdates_Internalname = "DDO_VINCULARTRNFECHAAUXDATES";
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
         edtVincularTrnFecha_Jsonclick = "";
         edtVincularTrnComentario_Jsonclick = "";
         edtDocumentacionId_Jsonclick = "";
         edtVincularTrnTelefonoSol_Jsonclick = "";
         edtVincularTrnNombreSol_Jsonclick = "";
         edtVincularTrnSolidicutd_Jsonclick = "";
         edtVincularTrnSolidicutd_Link = "";
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Link = "";
         edtProveedorID_Jsonclick = "";
         edtVincularTrnId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavProveedornombre1_Jsonclick = "";
         edtavProveedornombre1_Enabled = 1;
         edtavVinculartrnsolidicutd1_Jsonclick = "";
         edtavVinculartrnsolidicutd1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavProveedornombre2_Jsonclick = "";
         edtavProveedornombre2_Enabled = 1;
         edtavVinculartrnsolidicutd2_Jsonclick = "";
         edtavVinculartrnsolidicutd2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavProveedornombre3_Jsonclick = "";
         edtavProveedornombre3_Enabled = 1;
         edtavVinculartrnsolidicutd3_Jsonclick = "";
         edtavVinculartrnsolidicutd3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavProveedornombre3_Visible = 1;
         edtavVinculartrnsolidicutd3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavProveedornombre2_Visible = 1;
         edtavVinculartrnsolidicutd2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavProveedornombre1_Visible = 1;
         edtavVinculartrnsolidicutd1_Visible = 1;
         edtDocumentacionIcono_Visible = -1;
         edtVincularTrnFecha_Visible = -1;
         edtVincularTrnComentario_Visible = -1;
         edtVincularTrnImagen_Visible = -1;
         edtDocumentacionId_Visible = -1;
         edtVincularTrnTelefonoSol_Visible = -1;
         edtVincularTrnNombreSol_Visible = -1;
         edtVincularTrnSolidicutd_Visible = -1;
         edtProveedorNombre_Visible = -1;
         edtProveedorID_Visible = -1;
         edtVincularTrnId_Visible = -1;
         edtDocumentacionIcono_Enabled = 0;
         edtVincularTrnFecha_Enabled = 0;
         edtVincularTrnComentario_Enabled = 0;
         edtVincularTrnImagen_Enabled = 0;
         edtDocumentacionId_Enabled = 0;
         edtVincularTrnTelefonoSol_Enabled = 0;
         edtVincularTrnNombreSol_Enabled = 0;
         edtVincularTrnSolidicutd_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtVincularTrnId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_vinculartrnfechaauxdatetext_Jsonclick = "";
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
         Ddo_grid_Format = "18.0|18.0||18.0|||18.0||||";
         Ddo_grid_Datalistproc = "VincularTrnWWGetFilterData";
         Ddo_grid_Datalisttype = "||Dynamic||Dynamic|Dynamic|||Dynamic||";
         Ddo_grid_Includedatalist = "||T||T|T|||T||";
         Ddo_grid_Filterisrange = "T|T||T|||T|||P|";
         Ddo_grid_Filtertype = "Numeric|Numeric|Character|Numeric|Character|Character|Numeric||Character|Date|";
         Ddo_grid_Includefilter = "T|T|T|T|T|T|T||T|T|";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T|T||T|T|";
         Ddo_grid_Columnssortvalues = "2|3|4|1|5|6|7||8|9|";
         Ddo_grid_Columnids = "1:VincularTrnId|2:ProveedorID|3:ProveedorNombre|4:VincularTrnSolidicutd|5:VincularTrnNombreSol|6:VincularTrnTelefonoSol|7:DocumentacionId|8:VincularTrnImagen|9:VincularTrnComentario|10:VincularTrnFecha|11:DocumentacionIcono";
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
         Form.Caption = context.GetMessage( "Vincular Trns", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVincularTrnId_Visible',ctrl:'VINCULARTRNID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtVincularTrnSolidicutd_Visible',ctrl:'VINCULARTRNSOLIDICUTD',prop:'Visible'},{av:'edtVincularTrnNombreSol_Visible',ctrl:'VINCULARTRNNOMBRESOL',prop:'Visible'},{av:'edtVincularTrnTelefonoSol_Visible',ctrl:'VINCULARTRNTELEFONOSOL',prop:'Visible'},{av:'edtDocumentacionId_Visible',ctrl:'DOCUMENTACIONID',prop:'Visible'},{av:'edtVincularTrnImagen_Visible',ctrl:'VINCULARTRNIMAGEN',prop:'Visible'},{av:'edtVincularTrnComentario_Visible',ctrl:'VINCULARTRNCOMENTARIO',prop:'Visible'},{av:'edtVincularTrnFecha_Visible',ctrl:'VINCULARTRNFECHA',prop:'Visible'},{av:'edtDocumentacionIcono_Visible',ctrl:'DOCUMENTACIONICONO',prop:'Visible'},{av:'AV67GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV68GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12472',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVincularTrnId_Visible',ctrl:'VINCULARTRNID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtVincularTrnSolidicutd_Visible',ctrl:'VINCULARTRNSOLIDICUTD',prop:'Visible'},{av:'edtVincularTrnNombreSol_Visible',ctrl:'VINCULARTRNNOMBRESOL',prop:'Visible'},{av:'edtVincularTrnTelefonoSol_Visible',ctrl:'VINCULARTRNTELEFONOSOL',prop:'Visible'},{av:'edtDocumentacionId_Visible',ctrl:'DOCUMENTACIONID',prop:'Visible'},{av:'edtVincularTrnImagen_Visible',ctrl:'VINCULARTRNIMAGEN',prop:'Visible'},{av:'edtVincularTrnComentario_Visible',ctrl:'VINCULARTRNCOMENTARIO',prop:'Visible'},{av:'edtVincularTrnFecha_Visible',ctrl:'VINCULARTRNFECHA',prop:'Visible'},{av:'edtDocumentacionIcono_Visible',ctrl:'DOCUMENTACIONICONO',prop:'Visible'},{av:'AV67GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV68GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13472',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E16472',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E29472',iparms:[{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A491VincularTrnId',fld:'VINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV70GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtProveedorNombre_Link',ctrl:'PROVEEDORNOMBRE',prop:'Link'},{av:'edtVincularTrnSolidicutd_Link',ctrl:'VINCULARTRNSOLIDICUTD',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E17472',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtVincularTrnId_Visible',ctrl:'VINCULARTRNID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtVincularTrnSolidicutd_Visible',ctrl:'VINCULARTRNSOLIDICUTD',prop:'Visible'},{av:'edtVincularTrnNombreSol_Visible',ctrl:'VINCULARTRNNOMBRESOL',prop:'Visible'},{av:'edtVincularTrnTelefonoSol_Visible',ctrl:'VINCULARTRNTELEFONOSOL',prop:'Visible'},{av:'edtDocumentacionId_Visible',ctrl:'DOCUMENTACIONID',prop:'Visible'},{av:'edtVincularTrnImagen_Visible',ctrl:'VINCULARTRNIMAGEN',prop:'Visible'},{av:'edtVincularTrnComentario_Visible',ctrl:'VINCULARTRNCOMENTARIO',prop:'Visible'},{av:'edtVincularTrnFecha_Visible',ctrl:'VINCULARTRNFECHA',prop:'Visible'},{av:'edtDocumentacionIcono_Visible',ctrl:'DOCUMENTACIONICONO',prop:'Visible'},{av:'AV67GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV68GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E22472',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVincularTrnId_Visible',ctrl:'VINCULARTRNID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtVincularTrnSolidicutd_Visible',ctrl:'VINCULARTRNSOLIDICUTD',prop:'Visible'},{av:'edtVincularTrnNombreSol_Visible',ctrl:'VINCULARTRNNOMBRESOL',prop:'Visible'},{av:'edtVincularTrnTelefonoSol_Visible',ctrl:'VINCULARTRNTELEFONOSOL',prop:'Visible'},{av:'edtDocumentacionId_Visible',ctrl:'DOCUMENTACIONID',prop:'Visible'},{av:'edtVincularTrnImagen_Visible',ctrl:'VINCULARTRNIMAGEN',prop:'Visible'},{av:'edtVincularTrnComentario_Visible',ctrl:'VINCULARTRNCOMENTARIO',prop:'Visible'},{av:'edtVincularTrnFecha_Visible',ctrl:'VINCULARTRNFECHA',prop:'Visible'},{av:'edtDocumentacionIcono_Visible',ctrl:'DOCUMENTACIONICONO',prop:'Visible'},{av:'AV67GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV68GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E18472',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'edtavVinculartrnsolidicutd2_Visible',ctrl:'vVINCULARTRNSOLIDICUTD2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavVinculartrnsolidicutd3_Visible',ctrl:'vVINCULARTRNSOLIDICUTD3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavVinculartrnsolidicutd1_Visible',ctrl:'vVINCULARTRNSOLIDICUTD1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVincularTrnId_Visible',ctrl:'VINCULARTRNID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtVincularTrnSolidicutd_Visible',ctrl:'VINCULARTRNSOLIDICUTD',prop:'Visible'},{av:'edtVincularTrnNombreSol_Visible',ctrl:'VINCULARTRNNOMBRESOL',prop:'Visible'},{av:'edtVincularTrnTelefonoSol_Visible',ctrl:'VINCULARTRNTELEFONOSOL',prop:'Visible'},{av:'edtDocumentacionId_Visible',ctrl:'DOCUMENTACIONID',prop:'Visible'},{av:'edtVincularTrnImagen_Visible',ctrl:'VINCULARTRNIMAGEN',prop:'Visible'},{av:'edtVincularTrnComentario_Visible',ctrl:'VINCULARTRNCOMENTARIO',prop:'Visible'},{av:'edtVincularTrnFecha_Visible',ctrl:'VINCULARTRNFECHA',prop:'Visible'},{av:'edtDocumentacionIcono_Visible',ctrl:'DOCUMENTACIONICONO',prop:'Visible'},{av:'AV67GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV68GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E23472',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'edtavVinculartrnsolidicutd1_Visible',ctrl:'vVINCULARTRNSOLIDICUTD1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E24472',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVincularTrnId_Visible',ctrl:'VINCULARTRNID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtVincularTrnSolidicutd_Visible',ctrl:'VINCULARTRNSOLIDICUTD',prop:'Visible'},{av:'edtVincularTrnNombreSol_Visible',ctrl:'VINCULARTRNNOMBRESOL',prop:'Visible'},{av:'edtVincularTrnTelefonoSol_Visible',ctrl:'VINCULARTRNTELEFONOSOL',prop:'Visible'},{av:'edtDocumentacionId_Visible',ctrl:'DOCUMENTACIONID',prop:'Visible'},{av:'edtVincularTrnImagen_Visible',ctrl:'VINCULARTRNIMAGEN',prop:'Visible'},{av:'edtVincularTrnComentario_Visible',ctrl:'VINCULARTRNCOMENTARIO',prop:'Visible'},{av:'edtVincularTrnFecha_Visible',ctrl:'VINCULARTRNFECHA',prop:'Visible'},{av:'edtDocumentacionIcono_Visible',ctrl:'DOCUMENTACIONICONO',prop:'Visible'},{av:'AV67GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV68GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E19472',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'edtavVinculartrnsolidicutd2_Visible',ctrl:'vVINCULARTRNSOLIDICUTD2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavVinculartrnsolidicutd3_Visible',ctrl:'vVINCULARTRNSOLIDICUTD3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavVinculartrnsolidicutd1_Visible',ctrl:'vVINCULARTRNSOLIDICUTD1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVincularTrnId_Visible',ctrl:'VINCULARTRNID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtVincularTrnSolidicutd_Visible',ctrl:'VINCULARTRNSOLIDICUTD',prop:'Visible'},{av:'edtVincularTrnNombreSol_Visible',ctrl:'VINCULARTRNNOMBRESOL',prop:'Visible'},{av:'edtVincularTrnTelefonoSol_Visible',ctrl:'VINCULARTRNTELEFONOSOL',prop:'Visible'},{av:'edtDocumentacionId_Visible',ctrl:'DOCUMENTACIONID',prop:'Visible'},{av:'edtVincularTrnImagen_Visible',ctrl:'VINCULARTRNIMAGEN',prop:'Visible'},{av:'edtVincularTrnComentario_Visible',ctrl:'VINCULARTRNCOMENTARIO',prop:'Visible'},{av:'edtVincularTrnFecha_Visible',ctrl:'VINCULARTRNFECHA',prop:'Visible'},{av:'edtDocumentacionIcono_Visible',ctrl:'DOCUMENTACIONICONO',prop:'Visible'},{av:'AV67GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV68GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E25472',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'edtavVinculartrnsolidicutd2_Visible',ctrl:'vVINCULARTRNSOLIDICUTD2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E20472',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'edtavVinculartrnsolidicutd2_Visible',ctrl:'vVINCULARTRNSOLIDICUTD2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavVinculartrnsolidicutd3_Visible',ctrl:'vVINCULARTRNSOLIDICUTD3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtavVinculartrnsolidicutd1_Visible',ctrl:'vVINCULARTRNSOLIDICUTD1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVincularTrnId_Visible',ctrl:'VINCULARTRNID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtVincularTrnSolidicutd_Visible',ctrl:'VINCULARTRNSOLIDICUTD',prop:'Visible'},{av:'edtVincularTrnNombreSol_Visible',ctrl:'VINCULARTRNNOMBRESOL',prop:'Visible'},{av:'edtVincularTrnTelefonoSol_Visible',ctrl:'VINCULARTRNTELEFONOSOL',prop:'Visible'},{av:'edtDocumentacionId_Visible',ctrl:'DOCUMENTACIONID',prop:'Visible'},{av:'edtVincularTrnImagen_Visible',ctrl:'VINCULARTRNIMAGEN',prop:'Visible'},{av:'edtVincularTrnComentario_Visible',ctrl:'VINCULARTRNCOMENTARIO',prop:'Visible'},{av:'edtVincularTrnFecha_Visible',ctrl:'VINCULARTRNFECHA',prop:'Visible'},{av:'edtDocumentacionIcono_Visible',ctrl:'DOCUMENTACIONICONO',prop:'Visible'},{av:'AV67GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV68GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E26472',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtavVinculartrnsolidicutd3_Visible',ctrl:'vVINCULARTRNSOLIDICUTD3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11472',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'edtavVinculartrnsolidicutd1_Visible',ctrl:'vVINCULARTRNSOLIDICUTD1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavVinculartrnsolidicutd2_Visible',ctrl:'vVINCULARTRNSOLIDICUTD2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavVinculartrnsolidicutd3_Visible',ctrl:'vVINCULARTRNSOLIDICUTD3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVincularTrnId_Visible',ctrl:'VINCULARTRNID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtVincularTrnSolidicutd_Visible',ctrl:'VINCULARTRNSOLIDICUTD',prop:'Visible'},{av:'edtVincularTrnNombreSol_Visible',ctrl:'VINCULARTRNNOMBRESOL',prop:'Visible'},{av:'edtVincularTrnTelefonoSol_Visible',ctrl:'VINCULARTRNTELEFONOSOL',prop:'Visible'},{av:'edtDocumentacionId_Visible',ctrl:'DOCUMENTACIONID',prop:'Visible'},{av:'edtVincularTrnImagen_Visible',ctrl:'VINCULARTRNIMAGEN',prop:'Visible'},{av:'edtVincularTrnComentario_Visible',ctrl:'VINCULARTRNCOMENTARIO',prop:'Visible'},{av:'edtVincularTrnFecha_Visible',ctrl:'VINCULARTRNFECHA',prop:'Visible'},{av:'edtDocumentacionIcono_Visible',ctrl:'DOCUMENTACIONICONO',prop:'Visible'},{av:'AV67GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV68GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E30472',iparms:[{av:'cmbavGridactions'},{av:'AV70GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A491VincularTrnId',fld:'VINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV70GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E21472',iparms:[{av:'A491VincularTrnId',fld:'VINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E14472',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20VincularTrnSolidicutd1',fld:'vVINCULARTRNSOLIDICUTD1',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21ProveedorNombre1',fld:'vPROVEEDORNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25VincularTrnSolidicutd2',fld:'vVINCULARTRNSOLIDICUTD2',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV26ProveedorNombre2',fld:'vPROVEEDORNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30VincularTrnSolidicutd3',fld:'vVINCULARTRNSOLIDICUTD3',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31ProveedorNombre3',fld:'vPROVEEDORNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFVincularTrnId',fld:'vTFVINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFVincularTrnId_To',fld:'vTFVINCULARTRNID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProveedorID',fld:'vTFPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV47TFProveedorID_To',fld:'vTFPROVEEDORID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFProveedorNombre',fld:'vTFPROVEEDORNOMBRE',pic:'',type:'char'},{av:'AV49TFProveedorNombre_Sel',fld:'vTFPROVEEDORNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFVincularTrnSolidicutd',fld:'vTFVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV51TFVincularTrnSolidicutd_To',fld:'vTFVINCULARTRNSOLIDICUTD_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52TFVincularTrnNombreSol',fld:'vTFVINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'AV53TFVincularTrnNombreSol_Sel',fld:'vTFVINCULARTRNNOMBRESOL_SEL',pic:'',type:'char'},{av:'AV54TFVincularTrnTelefonoSol',fld:'vTFVINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'AV55TFVincularTrnTelefonoSol_Sel',fld:'vTFVINCULARTRNTELEFONOSOL_SEL',pic:'',type:'char'},{av:'AV56TFDocumentacionId',fld:'vTFDOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV57TFDocumentacionId_To',fld:'vTFDOCUMENTACIONID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV58TFVincularTrnComentario',fld:'vTFVINCULARTRNCOMENTARIO',pic:'',type:'svchar'},{av:'AV59TFVincularTrnComentario_Sel',fld:'vTFVINCULARTRNCOMENTARIO_SEL',pic:'',type:'svchar'},{av:'AV60TFVincularTrnFecha',fld:'vTFVINCULARTRNFECHA',pic:'',type:'date'},{av:'AV61TFVincularTrnFecha_To',fld:'vTFVINCULARTRNFECHA_TO',pic:'',type:'date'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV72IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV73IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_ProveedorNombre',fld:'vISAUTHORIZED_PROVEEDORNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavVinculartrnsolidicutd1_Visible',ctrl:'vVINCULARTRNSOLIDICUTD1',prop:'Visible'},{av:'edtavProveedornombre1_Visible',ctrl:'vPROVEEDORNOMBRE1',prop:'Visible'},{av:'edtavVinculartrnsolidicutd2_Visible',ctrl:'vVINCULARTRNSOLIDICUTD2',prop:'Visible'},{av:'edtavProveedornombre2_Visible',ctrl:'vPROVEEDORNOMBRE2',prop:'Visible'},{av:'edtavVinculartrnsolidicutd3_Visible',ctrl:'vVINCULARTRNSOLIDICUTD3',prop:'Visible'},{av:'edtavProveedornombre3_Visible',ctrl:'vPROVEEDORNOMBRE3',prop:'Visible'},{av:'edtVincularTrnId_Visible',ctrl:'VINCULARTRNID',prop:'Visible'},{av:'edtProveedorID_Visible',ctrl:'PROVEEDORID',prop:'Visible'},{av:'edtProveedorNombre_Visible',ctrl:'PROVEEDORNOMBRE',prop:'Visible'},{av:'edtVincularTrnSolidicutd_Visible',ctrl:'VINCULARTRNSOLIDICUTD',prop:'Visible'},{av:'edtVincularTrnNombreSol_Visible',ctrl:'VINCULARTRNNOMBRESOL',prop:'Visible'},{av:'edtVincularTrnTelefonoSol_Visible',ctrl:'VINCULARTRNTELEFONOSOL',prop:'Visible'},{av:'edtDocumentacionId_Visible',ctrl:'DOCUMENTACIONID',prop:'Visible'},{av:'edtVincularTrnImagen_Visible',ctrl:'VINCULARTRNIMAGEN',prop:'Visible'},{av:'edtVincularTrnComentario_Visible',ctrl:'VINCULARTRNCOMENTARIO',prop:'Visible'},{av:'edtVincularTrnFecha_Visible',ctrl:'VINCULARTRNFECHA',prop:'Visible'},{av:'edtDocumentacionIcono_Visible',ctrl:'DOCUMENTACIONICONO',prop:'Visible'},{av:'AV67GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV68GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV69GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E15472',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_DOCUMENTACIONID","{handler:'Valid_Documentacionid',iparms:[]");
         setEventMetadata("VALID_DOCUMENTACIONID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Documentacionicono',iparms:[]");
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
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV21ProveedorNombre1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV26ProveedorNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV31ProveedorNombre3 = "";
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV80Pgmname = "";
         AV48TFProveedorNombre = "";
         AV49TFProveedorNombre_Sel = "";
         AV52TFVincularTrnNombreSol = "";
         AV53TFVincularTrnNombreSol_Sel = "";
         AV54TFVincularTrnTelefonoSol = "";
         AV55TFVincularTrnTelefonoSol_Sel = "";
         AV58TFVincularTrnComentario = "";
         AV59TFVincularTrnComentario_Sel = "";
         AV60TFVincularTrnFecha = DateTime.MinValue;
         AV61TFVincularTrnFecha_To = DateTime.MinValue;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV69GridAppliedFilters = "";
         AV74AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV65DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV63DDO_VincularTrnFechaAuxDateTo = DateTime.MinValue;
         AV62DDO_VincularTrnFechaAuxDate = DateTime.MinValue;
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
         AV64DDO_VincularTrnFechaAuxDateText = "";
         ucTfvinculartrnfecha_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A282ProveedorNombre = "";
         A493VincularTrnNombreSol = "";
         A494VincularTrnTelefonoSol = "";
         A495VincularTrnImagen = "";
         A40000VincularTrnImagen_GXI = "";
         A497VincularTrnComentario = "";
         A496VincularTrnFecha = DateTime.MinValue;
         A498DocumentacionIcono = "";
         A40002DocumentacionIcono_GXI = "";
         lV81Vinculartrnwwds_1_filterfulltext = "";
         lV85Vinculartrnwwds_5_proveedornombre1 = "";
         lV90Vinculartrnwwds_10_proveedornombre2 = "";
         lV95Vinculartrnwwds_15_proveedornombre3 = "";
         lV100Vinculartrnwwds_20_tfproveedornombre = "";
         lV104Vinculartrnwwds_24_tfvinculartrnnombresol = "";
         lV106Vinculartrnwwds_26_tfvinculartrntelefonosol = "";
         lV110Vinculartrnwwds_30_tfvinculartrncomentario = "";
         AV81Vinculartrnwwds_1_filterfulltext = "";
         AV82Vinculartrnwwds_2_dynamicfiltersselector1 = "";
         AV85Vinculartrnwwds_5_proveedornombre1 = "";
         AV87Vinculartrnwwds_7_dynamicfiltersselector2 = "";
         AV90Vinculartrnwwds_10_proveedornombre2 = "";
         AV92Vinculartrnwwds_12_dynamicfiltersselector3 = "";
         AV95Vinculartrnwwds_15_proveedornombre3 = "";
         AV101Vinculartrnwwds_21_tfproveedornombre_sel = "";
         AV100Vinculartrnwwds_20_tfproveedornombre = "";
         AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel = "";
         AV104Vinculartrnwwds_24_tfvinculartrnnombresol = "";
         AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = "";
         AV106Vinculartrnwwds_26_tfvinculartrntelefonosol = "";
         AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel = "";
         AV110Vinculartrnwwds_30_tfvinculartrncomentario = "";
         AV112Vinculartrnwwds_32_tfvinculartrnfecha = DateTime.MinValue;
         AV113Vinculartrnwwds_33_tfvinculartrnfecha_to = DateTime.MinValue;
         H00472_A40002DocumentacionIcono_GXI = new string[] {""} ;
         H00472_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         H00472_A497VincularTrnComentario = new string[] {""} ;
         H00472_A40000VincularTrnImagen_GXI = new string[] {""} ;
         H00472_A488DocumentacionId = new long[1] ;
         H00472_n488DocumentacionId = new bool[] {false} ;
         H00472_A494VincularTrnTelefonoSol = new string[] {""} ;
         H00472_A493VincularTrnNombreSol = new string[] {""} ;
         H00472_A492VincularTrnSolidicutd = new long[1] ;
         H00472_A282ProveedorNombre = new string[] {""} ;
         H00472_A133ProveedorID = new long[1] ;
         H00472_A491VincularTrnId = new long[1] ;
         H00472_A498DocumentacionIcono = new string[] {""} ;
         H00472_A495VincularTrnImagen = new string[] {""} ;
         H00473_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV75AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV42ManageFiltersXml = "";
         AV37UserCustomValue = "";
         AV39ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
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
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vinculartrnww__default(),
            new Object[][] {
                new Object[] {
               H00472_A40002DocumentacionIcono_GXI, H00472_A496VincularTrnFecha, H00472_A497VincularTrnComentario, H00472_A40000VincularTrnImagen_GXI, H00472_A488DocumentacionId, H00472_n488DocumentacionId, H00472_A494VincularTrnTelefonoSol, H00472_A493VincularTrnNombreSol, H00472_A492VincularTrnSolidicutd, H00472_A282ProveedorNombre,
               H00472_A133ProveedorID, H00472_A491VincularTrnId, H00472_A498DocumentacionIcono, H00472_A495VincularTrnImagen
               }
               , new Object[] {
               H00473_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV80Pgmname = "VincularTrnWW";
         /* GeneXus formulas. */
         AV80Pgmname = "VincularTrnWW";
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
      private short AV70GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV83Vinculartrnwwds_3_dynamicfiltersoperator1 ;
      private short AV88Vinculartrnwwds_8_dynamicfiltersoperator2 ;
      private short AV93Vinculartrnwwds_13_dynamicfiltersoperator3 ;
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
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtVincularTrnId_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtVincularTrnSolidicutd_Enabled ;
      private int edtVincularTrnNombreSol_Enabled ;
      private int edtVincularTrnTelefonoSol_Enabled ;
      private int edtDocumentacionId_Enabled ;
      private int edtVincularTrnImagen_Enabled ;
      private int edtVincularTrnComentario_Enabled ;
      private int edtVincularTrnFecha_Enabled ;
      private int edtDocumentacionIcono_Enabled ;
      private int edtVincularTrnId_Visible ;
      private int edtProveedorID_Visible ;
      private int edtProveedorNombre_Visible ;
      private int edtVincularTrnSolidicutd_Visible ;
      private int edtVincularTrnNombreSol_Visible ;
      private int edtVincularTrnTelefonoSol_Visible ;
      private int edtDocumentacionId_Visible ;
      private int edtVincularTrnImagen_Visible ;
      private int edtVincularTrnComentario_Visible ;
      private int edtVincularTrnFecha_Visible ;
      private int edtDocumentacionIcono_Visible ;
      private int AV66PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavVinculartrnsolidicutd1_Visible ;
      private int edtavProveedornombre1_Visible ;
      private int edtavVinculartrnsolidicutd2_Visible ;
      private int edtavProveedornombre2_Visible ;
      private int edtavVinculartrnsolidicutd3_Visible ;
      private int edtavProveedornombre3_Visible ;
      private int AV114GXV1 ;
      private int edtavVinculartrnsolidicutd3_Enabled ;
      private int edtavProveedornombre3_Enabled ;
      private int edtavVinculartrnsolidicutd2_Enabled ;
      private int edtavProveedornombre2_Enabled ;
      private int edtavVinculartrnsolidicutd1_Enabled ;
      private int edtavProveedornombre1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV20VincularTrnSolidicutd1 ;
      private long AV25VincularTrnSolidicutd2 ;
      private long AV30VincularTrnSolidicutd3 ;
      private long AV44TFVincularTrnId ;
      private long AV45TFVincularTrnId_To ;
      private long AV46TFProveedorID ;
      private long AV47TFProveedorID_To ;
      private long AV50TFVincularTrnSolidicutd ;
      private long AV51TFVincularTrnSolidicutd_To ;
      private long AV56TFDocumentacionId ;
      private long AV57TFDocumentacionId_To ;
      private long AV67GridCurrentPage ;
      private long AV68GridPageCount ;
      private long A491VincularTrnId ;
      private long A133ProveedorID ;
      private long A492VincularTrnSolidicutd ;
      private long A488DocumentacionId ;
      private long GRID_nCurrentRecord ;
      private long AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 ;
      private long AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 ;
      private long AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 ;
      private long AV96Vinculartrnwwds_16_tfvinculartrnid ;
      private long AV97Vinculartrnwwds_17_tfvinculartrnid_to ;
      private long AV98Vinculartrnwwds_18_tfproveedorid ;
      private long AV99Vinculartrnwwds_19_tfproveedorid_to ;
      private long AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd ;
      private long AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ;
      private long AV108Vinculartrnwwds_28_tfdocumentacionid ;
      private long AV109Vinculartrnwwds_29_tfdocumentacionid_to ;
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
      private string AV21ProveedorNombre1 ;
      private string AV26ProveedorNombre2 ;
      private string AV31ProveedorNombre3 ;
      private string AV80Pgmname ;
      private string AV48TFProveedorNombre ;
      private string AV49TFProveedorNombre_Sel ;
      private string AV52TFVincularTrnNombreSol ;
      private string AV53TFVincularTrnNombreSol_Sel ;
      private string AV54TFVincularTrnTelefonoSol ;
      private string AV55TFVincularTrnTelefonoSol_Sel ;
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
      private string divDdo_vinculartrnfechaauxdates_Internalname ;
      private string edtavDdo_vinculartrnfechaauxdatetext_Internalname ;
      private string edtavDdo_vinculartrnfechaauxdatetext_Jsonclick ;
      private string Tfvinculartrnfecha_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtVincularTrnId_Internalname ;
      private string edtProveedorID_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Internalname ;
      private string edtVincularTrnSolidicutd_Internalname ;
      private string A493VincularTrnNombreSol ;
      private string edtVincularTrnNombreSol_Internalname ;
      private string A494VincularTrnTelefonoSol ;
      private string edtVincularTrnTelefonoSol_Internalname ;
      private string edtDocumentacionId_Internalname ;
      private string edtVincularTrnImagen_Internalname ;
      private string edtVincularTrnComentario_Internalname ;
      private string edtVincularTrnFecha_Internalname ;
      private string edtDocumentacionIcono_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string lV85Vinculartrnwwds_5_proveedornombre1 ;
      private string lV90Vinculartrnwwds_10_proveedornombre2 ;
      private string lV95Vinculartrnwwds_15_proveedornombre3 ;
      private string lV100Vinculartrnwwds_20_tfproveedornombre ;
      private string lV104Vinculartrnwwds_24_tfvinculartrnnombresol ;
      private string lV106Vinculartrnwwds_26_tfvinculartrntelefonosol ;
      private string AV85Vinculartrnwwds_5_proveedornombre1 ;
      private string AV90Vinculartrnwwds_10_proveedornombre2 ;
      private string AV95Vinculartrnwwds_15_proveedornombre3 ;
      private string AV101Vinculartrnwwds_21_tfproveedornombre_sel ;
      private string AV100Vinculartrnwwds_20_tfproveedornombre ;
      private string AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel ;
      private string AV104Vinculartrnwwds_24_tfvinculartrnnombresol ;
      private string AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ;
      private string AV106Vinculartrnwwds_26_tfvinculartrntelefonosol ;
      private string edtavVinculartrnsolidicutd1_Internalname ;
      private string edtavProveedornombre1_Internalname ;
      private string edtavVinculartrnsolidicutd2_Internalname ;
      private string edtavProveedornombre2_Internalname ;
      private string edtavVinculartrnsolidicutd3_Internalname ;
      private string edtavProveedornombre3_Internalname ;
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
      private string edtVincularTrnSolidicutd_Link ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_vinculartrnsolidicutd3_cell_Internalname ;
      private string edtavVinculartrnsolidicutd3_Jsonclick ;
      private string cellFilter_proveedornombre3_cell_Internalname ;
      private string edtavProveedornombre3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_vinculartrnsolidicutd2_cell_Internalname ;
      private string edtavVinculartrnsolidicutd2_Jsonclick ;
      private string cellFilter_proveedornombre2_cell_Internalname ;
      private string edtavProveedornombre2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_vinculartrnsolidicutd1_cell_Internalname ;
      private string edtavVinculartrnsolidicutd1_Jsonclick ;
      private string cellFilter_proveedornombre1_cell_Internalname ;
      private string edtavProveedornombre1_Jsonclick ;
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
      private string edtVincularTrnId_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtVincularTrnSolidicutd_Jsonclick ;
      private string edtVincularTrnNombreSol_Jsonclick ;
      private string gxphoneLink ;
      private string edtVincularTrnTelefonoSol_Jsonclick ;
      private string edtDocumentacionId_Jsonclick ;
      private string edtVincularTrnComentario_Jsonclick ;
      private string edtVincularTrnFecha_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV60TFVincularTrnFecha ;
      private DateTime AV61TFVincularTrnFecha_To ;
      private DateTime AV63DDO_VincularTrnFechaAuxDateTo ;
      private DateTime AV62DDO_VincularTrnFechaAuxDate ;
      private DateTime A496VincularTrnFecha ;
      private DateTime AV112Vinculartrnwwds_32_tfvinculartrnfecha ;
      private DateTime AV113Vinculartrnwwds_33_tfvinculartrnfecha_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV33DynamicFiltersIgnoreFirst ;
      private bool AV32DynamicFiltersRemoving ;
      private bool AV72IsAuthorized_Update ;
      private bool AV73IsAuthorized_Delete ;
      private bool AV77IsAuthorized_ProveedorNombre ;
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
      private bool n488DocumentacionId ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV86Vinculartrnwwds_6_dynamicfiltersenabled2 ;
      private bool AV91Vinculartrnwwds_11_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV76TempBoolean ;
      private bool GXt_boolean1 ;
      private bool A495VincularTrnImagen_IsBlob ;
      private bool A498DocumentacionIcono_IsBlob ;
      private string A497VincularTrnComentario ;
      private string AV36ColumnsSelectorXML ;
      private string AV42ManageFiltersXml ;
      private string AV37UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV58TFVincularTrnComentario ;
      private string AV59TFVincularTrnComentario_Sel ;
      private string AV69GridAppliedFilters ;
      private string AV64DDO_VincularTrnFechaAuxDateText ;
      private string A40000VincularTrnImagen_GXI ;
      private string A40002DocumentacionIcono_GXI ;
      private string lV81Vinculartrnwwds_1_filterfulltext ;
      private string lV110Vinculartrnwwds_30_tfvinculartrncomentario ;
      private string AV81Vinculartrnwwds_1_filterfulltext ;
      private string AV82Vinculartrnwwds_2_dynamicfiltersselector1 ;
      private string AV87Vinculartrnwwds_7_dynamicfiltersselector2 ;
      private string AV92Vinculartrnwwds_12_dynamicfiltersselector3 ;
      private string AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel ;
      private string AV110Vinculartrnwwds_30_tfvinculartrncomentario ;
      private string AV34ExcelFilename ;
      private string AV35ErrorMessage ;
      private string A495VincularTrnImagen ;
      private string A498DocumentacionIcono ;
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
      private GXUserControl ucTfvinculartrnfecha_rangepicker ;
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
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV74AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV65DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H00472_A40002DocumentacionIcono_GXI ;
      private DateTime[] H00472_A496VincularTrnFecha ;
      private string[] H00472_A497VincularTrnComentario ;
      private string[] H00472_A40000VincularTrnImagen_GXI ;
      private long[] H00472_A488DocumentacionId ;
      private bool[] H00472_n488DocumentacionId ;
      private string[] H00472_A494VincularTrnTelefonoSol ;
      private string[] H00472_A493VincularTrnNombreSol ;
      private long[] H00472_A492VincularTrnSolidicutd ;
      private string[] H00472_A282ProveedorNombre ;
      private long[] H00472_A133ProveedorID ;
      private long[] H00472_A491VincularTrnId ;
      private string[] H00472_A498DocumentacionIcono ;
      private string[] H00472_A495VincularTrnImagen ;
      private long[] H00473_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV75AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class vinculartrnww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00472( IGxContext context ,
                                             string AV81Vinculartrnwwds_1_filterfulltext ,
                                             string AV82Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                             short AV83Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                             long AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                             string AV85Vinculartrnwwds_5_proveedornombre1 ,
                                             bool AV86Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                             string AV87Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                             short AV88Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                             long AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                             string AV90Vinculartrnwwds_10_proveedornombre2 ,
                                             bool AV91Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                             string AV92Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                             short AV93Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                             long AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                             string AV95Vinculartrnwwds_15_proveedornombre3 ,
                                             long AV96Vinculartrnwwds_16_tfvinculartrnid ,
                                             long AV97Vinculartrnwwds_17_tfvinculartrnid_to ,
                                             long AV98Vinculartrnwwds_18_tfproveedorid ,
                                             long AV99Vinculartrnwwds_19_tfproveedorid_to ,
                                             string AV101Vinculartrnwwds_21_tfproveedornombre_sel ,
                                             string AV100Vinculartrnwwds_20_tfproveedornombre ,
                                             long AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                             long AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                             string AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                             string AV104Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                             string AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                             string AV106Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                             long AV108Vinculartrnwwds_28_tfdocumentacionid ,
                                             long AV109Vinculartrnwwds_29_tfdocumentacionid_to ,
                                             string AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                             string AV110Vinculartrnwwds_30_tfvinculartrncomentario ,
                                             DateTime AV112Vinculartrnwwds_32_tfvinculartrnfecha ,
                                             DateTime AV113Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                             long A491VincularTrnId ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             long A492VincularTrnSolidicutd ,
                                             string A493VincularTrnNombreSol ,
                                             string A494VincularTrnTelefonoSol ,
                                             long A488DocumentacionId ,
                                             string A497VincularTrnComentario ,
                                             DateTime A496VincularTrnFecha ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[44];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T3.[DocumentacionIcono_GXI], T1.[VincularTrnFecha], T1.[VincularTrnComentario], T1.[VincularTrnImagen_GXI], T2.[DocumentacionId], T1.[VincularTrnTelefonoSol], T1.[VincularTrnNombreSol], T1.[VincularTrnSolidicutd], T2.[ProveedorNombre], T1.[ProveedorID], T1.[VincularTrnId], T3.[DocumentacionIcono], T1.[VincularTrnImagen]";
         sFromString = " FROM (([VincularTrn] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) LEFT JOIN [Documentacion] T3 ON T3.[DocumentacionId] = T2.[DocumentacionId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[VincularTrnId] AS decimal(18,0))) like '%' + @lV81Vinculartrnwwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[ProveedorID] AS decimal(18,0))) like '%' + @lV81Vinculartrnwwds_1_filterfulltext) or ( UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV81Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[VincularTrnSolidicutd] AS decimal(18,0))) like '%' + @lV81Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnNombreSol]) like '%' + UPPER(@lV81Vinculartrnwwds_1_filterfulltext)) or ( UPPER(T1.[VincularTrnTelefonoSol]) like '%' + UPPER(@lV81Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[DocumentacionId] AS decimal(18,0))) like '%' + @lV81Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnComentario]) like '%' + UPPER(@lV81Vinculartrnwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
            GXv_int8[5] = 1;
            GXv_int8[6] = 1;
            GXv_int8[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV83Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV84Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV84Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV83Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV84Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV84Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV83Vinculartrnwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV84Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV84Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV83Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV85Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV83Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV85Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV86Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV88Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV89Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV89Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV86Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV88Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV89Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV89Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV86Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV88Vinculartrnwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV89Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV89Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV86Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV88Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV90Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV86Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV88Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV90Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV91Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV93Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV94Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV94Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV91Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV93Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV94Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV94Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( AV91Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV93Vinculartrnwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV94Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV94Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( AV91Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV93Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV95Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( AV91Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV93Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV95Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! (0==AV96Vinculartrnwwds_16_tfvinculartrnid) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] >= @AV96Vinculartrnwwds_16_tfvinculartrnid)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! (0==AV97Vinculartrnwwds_17_tfvinculartrnid_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] <= @AV97Vinculartrnwwds_17_tfvinculartrnid_to)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! (0==AV98Vinculartrnwwds_18_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV98Vinculartrnwwds_18_tfproveedorid)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ! (0==AV99Vinculartrnwwds_19_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV99Vinculartrnwwds_19_tfproveedorid_to)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Vinculartrnwwds_21_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Vinculartrnwwds_20_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV100Vinculartrnwwds_20_tfproveedornombre))");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Vinculartrnwwds_21_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV101Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV101Vinculartrnwwds_21_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( StringUtil.StrCmp(AV101Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] >= @AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( ! (0==AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] <= @AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Vinculartrnwwds_24_tfvinculartrnnombresol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnNombreSol]) like UPPER(@lV104Vinculartrnwwds_24_tfvinculartrnnombresol))");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ! ( StringUtil.StrCmp(AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnNombreSol] = @AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel)");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( StringUtil.StrCmp(AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnNombreSol] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Vinculartrnwwds_26_tfvinculartrntelefonosol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnTelefonoSol]) like UPPER(@lV106Vinculartrnwwds_26_tfvinculartrntelefonosol))");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ! ( StringUtil.StrCmp(AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnTelefonoSol] = @AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)");
         }
         else
         {
            GXv_int8[34] = 1;
         }
         if ( StringUtil.StrCmp(AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnTelefonoSol] = ''))");
         }
         if ( ! (0==AV108Vinculartrnwwds_28_tfdocumentacionid) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] >= @AV108Vinculartrnwwds_28_tfdocumentacionid)");
         }
         else
         {
            GXv_int8[35] = 1;
         }
         if ( ! (0==AV109Vinculartrnwwds_29_tfdocumentacionid_to) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] <= @AV109Vinculartrnwwds_29_tfdocumentacionid_to)");
         }
         else
         {
            GXv_int8[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Vinculartrnwwds_30_tfvinculartrncomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnComentario]) like UPPER(@lV110Vinculartrnwwds_30_tfvinculartrncomentario))");
         }
         else
         {
            GXv_int8[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ! ( StringUtil.StrCmp(AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnComentario] = @AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel)");
         }
         else
         {
            GXv_int8[38] = 1;
         }
         if ( StringUtil.StrCmp(AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[VincularTrnComentario])=0))");
         }
         if ( ! (DateTime.MinValue==AV112Vinculartrnwwds_32_tfvinculartrnfecha) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] >= @AV112Vinculartrnwwds_32_tfvinculartrnfecha)");
         }
         else
         {
            GXv_int8[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV113Vinculartrnwwds_33_tfvinculartrnfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] <= @AV113Vinculartrnwwds_33_tfvinculartrnfecha_to)");
         }
         else
         {
            GXv_int8[40] = 1;
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[VincularTrnSolidicutd]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[VincularTrnSolidicutd] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[VincularTrnId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[VincularTrnId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProveedorID]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProveedorID] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[ProveedorNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[ProveedorNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[VincularTrnNombreSol]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[VincularTrnNombreSol] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[VincularTrnTelefonoSol]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[VincularTrnTelefonoSol] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[DocumentacionId]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[DocumentacionId] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[VincularTrnComentario]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[VincularTrnComentario] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[VincularTrnFecha]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[VincularTrnFecha] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[VincularTrnId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H00473( IGxContext context ,
                                             string AV81Vinculartrnwwds_1_filterfulltext ,
                                             string AV82Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                             short AV83Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                             long AV84Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                             string AV85Vinculartrnwwds_5_proveedornombre1 ,
                                             bool AV86Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                             string AV87Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                             short AV88Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                             long AV89Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                             string AV90Vinculartrnwwds_10_proveedornombre2 ,
                                             bool AV91Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                             string AV92Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                             short AV93Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                             long AV94Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                             string AV95Vinculartrnwwds_15_proveedornombre3 ,
                                             long AV96Vinculartrnwwds_16_tfvinculartrnid ,
                                             long AV97Vinculartrnwwds_17_tfvinculartrnid_to ,
                                             long AV98Vinculartrnwwds_18_tfproveedorid ,
                                             long AV99Vinculartrnwwds_19_tfproveedorid_to ,
                                             string AV101Vinculartrnwwds_21_tfproveedornombre_sel ,
                                             string AV100Vinculartrnwwds_20_tfproveedornombre ,
                                             long AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                             long AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                             string AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                             string AV104Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                             string AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                             string AV106Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                             long AV108Vinculartrnwwds_28_tfdocumentacionid ,
                                             long AV109Vinculartrnwwds_29_tfdocumentacionid_to ,
                                             string AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                             string AV110Vinculartrnwwds_30_tfvinculartrncomentario ,
                                             DateTime AV112Vinculartrnwwds_32_tfvinculartrnfecha ,
                                             DateTime AV113Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                             long A491VincularTrnId ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             long A492VincularTrnSolidicutd ,
                                             string A493VincularTrnNombreSol ,
                                             string A494VincularTrnTelefonoSol ,
                                             long A488DocumentacionId ,
                                             string A497VincularTrnComentario ,
                                             DateTime A496VincularTrnFecha ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[41];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([VincularTrn] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) LEFT JOIN [Documentacion] T3 ON T3.[DocumentacionId] = T2.[DocumentacionId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Vinculartrnwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[VincularTrnId] AS decimal(18,0))) like '%' + @lV81Vinculartrnwwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[ProveedorID] AS decimal(18,0))) like '%' + @lV81Vinculartrnwwds_1_filterfulltext) or ( UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV81Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[VincularTrnSolidicutd] AS decimal(18,0))) like '%' + @lV81Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnNombreSol]) like '%' + UPPER(@lV81Vinculartrnwwds_1_filterfulltext)) or ( UPPER(T1.[VincularTrnTelefonoSol]) like '%' + UPPER(@lV81Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[DocumentacionId] AS decimal(18,0))) like '%' + @lV81Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnComentario]) like '%' + UPPER(@lV81Vinculartrnwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
            GXv_int10[4] = 1;
            GXv_int10[5] = 1;
            GXv_int10[6] = 1;
            GXv_int10[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV83Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV84Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV84Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV83Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV84Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV84Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV83Vinculartrnwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV84Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV84Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV83Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV85Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV83Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV85Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( AV86Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV88Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV89Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV89Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( AV86Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV88Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV89Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV89Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV86Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV88Vinculartrnwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV89Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV89Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( AV86Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV88Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV90Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( AV86Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV87Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV88Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV90Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( AV91Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV93Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV94Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV94Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( AV91Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV93Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV94Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV94Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( AV91Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV93Vinculartrnwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV94Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV94Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( AV91Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV93Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV95Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( AV91Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV93Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV95Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( ! (0==AV96Vinculartrnwwds_16_tfvinculartrnid) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] >= @AV96Vinculartrnwwds_16_tfvinculartrnid)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( ! (0==AV97Vinculartrnwwds_17_tfvinculartrnid_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] <= @AV97Vinculartrnwwds_17_tfvinculartrnid_to)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( ! (0==AV98Vinculartrnwwds_18_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV98Vinculartrnwwds_18_tfproveedorid)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( ! (0==AV99Vinculartrnwwds_19_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV99Vinculartrnwwds_19_tfproveedorid_to)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Vinculartrnwwds_21_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Vinculartrnwwds_20_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV100Vinculartrnwwds_20_tfproveedornombre))");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Vinculartrnwwds_21_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV101Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV101Vinculartrnwwds_21_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( StringUtil.StrCmp(AV101Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] >= @AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( ! (0==AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] <= @AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to)");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Vinculartrnwwds_24_tfvinculartrnnombresol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnNombreSol]) like UPPER(@lV104Vinculartrnwwds_24_tfvinculartrnnombresol))");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ! ( StringUtil.StrCmp(AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnNombreSol] = @AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel)");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( StringUtil.StrCmp(AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnNombreSol] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Vinculartrnwwds_26_tfvinculartrntelefonosol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnTelefonoSol]) like UPPER(@lV106Vinculartrnwwds_26_tfvinculartrntelefonosol))");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ! ( StringUtil.StrCmp(AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnTelefonoSol] = @AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)");
         }
         else
         {
            GXv_int10[34] = 1;
         }
         if ( StringUtil.StrCmp(AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnTelefonoSol] = ''))");
         }
         if ( ! (0==AV108Vinculartrnwwds_28_tfdocumentacionid) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] >= @AV108Vinculartrnwwds_28_tfdocumentacionid)");
         }
         else
         {
            GXv_int10[35] = 1;
         }
         if ( ! (0==AV109Vinculartrnwwds_29_tfdocumentacionid_to) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] <= @AV109Vinculartrnwwds_29_tfdocumentacionid_to)");
         }
         else
         {
            GXv_int10[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Vinculartrnwwds_30_tfvinculartrncomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnComentario]) like UPPER(@lV110Vinculartrnwwds_30_tfvinculartrncomentario))");
         }
         else
         {
            GXv_int10[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ! ( StringUtil.StrCmp(AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnComentario] = @AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel)");
         }
         else
         {
            GXv_int10[38] = 1;
         }
         if ( StringUtil.StrCmp(AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[VincularTrnComentario])=0))");
         }
         if ( ! (DateTime.MinValue==AV112Vinculartrnwwds_32_tfvinculartrnfecha) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] >= @AV112Vinculartrnwwds_32_tfvinculartrnfecha)");
         }
         else
         {
            GXv_int10[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV113Vinculartrnwwds_33_tfvinculartrnfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] <= @AV113Vinculartrnwwds_33_tfvinculartrnfecha_to)");
         }
         else
         {
            GXv_int10[40] = 1;
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
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00472(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (short)dynConstraints[42] , (bool)dynConstraints[43] );
               case 1 :
                     return conditional_H00473(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (short)dynConstraints[42] , (bool)dynConstraints[43] );
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
          Object[] prmH00472;
          prmH00472 = new Object[] {
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV84Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV84Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV84Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@lV85Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV85Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV89Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV89Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV89Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@lV90Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV90Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV94Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV94Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV94Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@lV95Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV95Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV96Vinculartrnwwds_16_tfvinculartrnid",GXType.Decimal,18,0) ,
          new ParDef("@AV97Vinculartrnwwds_17_tfvinculartrnid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV98Vinculartrnwwds_18_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV99Vinculartrnwwds_19_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV100Vinculartrnwwds_20_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV101Vinculartrnwwds_21_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd",GXType.Decimal,18,0) ,
          new ParDef("@AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to",GXType.Decimal,18,0) ,
          new ParDef("@lV104Vinculartrnwwds_24_tfvinculartrnnombresol",GXType.Char,80,0) ,
          new ParDef("@AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel",GXType.NChar,80,0) ,
          new ParDef("@lV106Vinculartrnwwds_26_tfvinculartrntelefonosol",GXType.Char,20,0) ,
          new ParDef("@AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel",GXType.NChar,20,0) ,
          new ParDef("@AV108Vinculartrnwwds_28_tfdocumentacionid",GXType.Decimal,18,0) ,
          new ParDef("@AV109Vinculartrnwwds_29_tfdocumentacionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV110Vinculartrnwwds_30_tfvinculartrncomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV112Vinculartrnwwds_32_tfvinculartrnfecha",GXType.Date,8,0) ,
          new ParDef("@AV113Vinculartrnwwds_33_tfvinculartrnfecha_to",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00473;
          prmH00473 = new Object[] {
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV81Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV84Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV84Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV84Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@lV85Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV85Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV89Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV89Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV89Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@lV90Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV90Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV94Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV94Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV94Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@lV95Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV95Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV96Vinculartrnwwds_16_tfvinculartrnid",GXType.Decimal,18,0) ,
          new ParDef("@AV97Vinculartrnwwds_17_tfvinculartrnid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV98Vinculartrnwwds_18_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV99Vinculartrnwwds_19_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV100Vinculartrnwwds_20_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV101Vinculartrnwwds_21_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV102Vinculartrnwwds_22_tfvinculartrnsolidicutd",GXType.Decimal,18,0) ,
          new ParDef("@AV103Vinculartrnwwds_23_tfvinculartrnsolidicutd_to",GXType.Decimal,18,0) ,
          new ParDef("@lV104Vinculartrnwwds_24_tfvinculartrnnombresol",GXType.Char,80,0) ,
          new ParDef("@AV105Vinculartrnwwds_25_tfvinculartrnnombresol_sel",GXType.NChar,80,0) ,
          new ParDef("@lV106Vinculartrnwwds_26_tfvinculartrntelefonosol",GXType.Char,20,0) ,
          new ParDef("@AV107Vinculartrnwwds_27_tfvinculartrntelefonosol_sel",GXType.NChar,20,0) ,
          new ParDef("@AV108Vinculartrnwwds_28_tfdocumentacionid",GXType.Decimal,18,0) ,
          new ParDef("@AV109Vinculartrnwwds_29_tfdocumentacionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV110Vinculartrnwwds_30_tfvinculartrncomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV111Vinculartrnwwds_31_tfvinculartrncomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV112Vinculartrnwwds_32_tfvinculartrnfecha",GXType.Date,8,0) ,
          new ParDef("@AV113Vinculartrnwwds_33_tfvinculartrnfecha_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00472", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00472,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00473", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00473,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 80);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 80);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(1));
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(4));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
