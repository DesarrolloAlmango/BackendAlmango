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
   public class profcomisionesww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public profcomisionesww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profcomisionesww( IGxContext context )
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
         AV20ProfComisionesAutoEnun1 = (short)(Math.Round(NumberUtil.Val( GetPar( "ProfComisionesAutoEnun1"), "."), 18, MidpointRounding.ToEven));
         AV21ProfesionalesPrimerNombre1 = GetPar( "ProfesionalesPrimerNombre1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV25ProfComisionesAutoEnun2 = (short)(Math.Round(NumberUtil.Val( GetPar( "ProfComisionesAutoEnun2"), "."), 18, MidpointRounding.ToEven));
         AV26ProfesionalesPrimerNombre2 = GetPar( "ProfesionalesPrimerNombre2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV30ProfComisionesAutoEnun3 = (short)(Math.Round(NumberUtil.Val( GetPar( "ProfComisionesAutoEnun3"), "."), 18, MidpointRounding.ToEven));
         AV31ProfesionalesPrimerNombre3 = GetPar( "ProfesionalesPrimerNombre3");
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV27DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38ColumnsSelector);
         AV73Pgmname = GetPar( "Pgmname");
         AV44TFProfComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfComisionesID"), "."), 18, MidpointRounding.ToEven));
         AV45TFProfComisionesID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfComisionesID_To"), "."), 18, MidpointRounding.ToEven));
         AV46TFProfesionalesId = GetPar( "TFProfesionalesId");
         AV47TFProfesionalesId_Sel = GetPar( "TFProfesionalesId_Sel");
         AV48TFProfesionalesPrimerNombre = GetPar( "TFProfesionalesPrimerNombre");
         AV49TFProfesionalesPrimerNombre_Sel = GetPar( "TFProfesionalesPrimerNombre_Sel");
         AV50TFProfesionalesSegundoNombre = GetPar( "TFProfesionalesSegundoNombre");
         AV51TFProfesionalesSegundoNombre_Sel = GetPar( "TFProfesionalesSegundoNombre_Sel");
         AV52TFProfesionalesApellidoPrimero = GetPar( "TFProfesionalesApellidoPrimero");
         AV53TFProfesionalesApellidoPrimero_Sel = GetPar( "TFProfesionalesApellidoPrimero_Sel");
         AV54TFProfesionalesApellidoSegundo = GetPar( "TFProfesionalesApellidoSegundo");
         AV55TFProfesionalesApellidoSegundo_Sel = GetPar( "TFProfesionalesApellidoSegundo_Sel");
         AV56TFProfesionalesTelefono = GetPar( "TFProfesionalesTelefono");
         AV57TFProfesionalesTelefono_Sel = GetPar( "TFProfesionalesTelefono_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV33DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV32DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV65IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV66IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV70IsAuthorized_ProfesionalesPrimerNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_ProfesionalesPrimerNombre"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ProfComisionesAutoEnun1, AV21ProfesionalesPrimerNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ProfComisionesAutoEnun2, AV26ProfesionalesPrimerNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30ProfComisionesAutoEnun3, AV31ProfesionalesPrimerNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV73Pgmname, AV44TFProfComisionesID, AV45TFProfComisionesID_To, AV46TFProfesionalesId, AV47TFProfesionalesId_Sel, AV48TFProfesionalesPrimerNombre, AV49TFProfesionalesPrimerNombre_Sel, AV50TFProfesionalesSegundoNombre, AV51TFProfesionalesSegundoNombre_Sel, AV52TFProfesionalesApellidoPrimero, AV53TFProfesionalesApellidoPrimero_Sel, AV54TFProfesionalesApellidoSegundo, AV55TFProfesionalesApellidoSegundo_Sel, AV56TFProfesionalesTelefono, AV57TFProfesionalesTelefono_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV65IsAuthorized_Update, AV66IsAuthorized_Delete, AV70IsAuthorized_ProfesionalesPrimerNombre) ;
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
         PA3O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3O2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profcomisionesww.aspx") +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV65IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV65IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV66IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV66IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", AV70IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( "", AV70IsAuthorized_ProfesionalesPrimerNombre, context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vPROFCOMISIONESAUTOENUN1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ProfComisionesAutoEnun1), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROFESIONALESPRIMERNOMBRE1", StringUtil.RTrim( AV21ProfesionalesPrimerNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROFCOMISIONESAUTOENUN2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ProfComisionesAutoEnun2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROFESIONALESPRIMERNOMBRE2", StringUtil.RTrim( AV26ProfesionalesPrimerNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV28DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROFCOMISIONESAUTOENUN3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30ProfComisionesAutoEnun3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROFESIONALESPRIMERNOMBRE3", StringUtil.RTrim( AV31ProfesionalesPrimerNombre3));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV62GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV67AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV67AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV58DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV58DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV27DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPROFCOMISIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROFCOMISIONESID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TFProfComisionesID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESID", StringUtil.RTrim( AV46TFProfesionalesId));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESID_SEL", StringUtil.RTrim( AV47TFProfesionalesId_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESPRIMERNOMBRE", StringUtil.RTrim( AV48TFProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESPRIMERNOMBRE_SEL", StringUtil.RTrim( AV49TFProfesionalesPrimerNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESSEGUNDONOMBRE", StringUtil.RTrim( AV50TFProfesionalesSegundoNombre));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESSEGUNDONOMBRE_SEL", StringUtil.RTrim( AV51TFProfesionalesSegundoNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOPRIMERO", StringUtil.RTrim( AV52TFProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOPRIMERO_SEL", StringUtil.RTrim( AV53TFProfesionalesApellidoPrimero_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOSEGUNDO", StringUtil.RTrim( AV54TFProfesionalesApellidoSegundo));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOSEGUNDO_SEL", StringUtil.RTrim( AV55TFProfesionalesApellidoSegundo_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESTELEFONO", StringUtil.RTrim( AV56TFProfesionalesTelefono));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESTELEFONO_SEL", StringUtil.RTrim( AV57TFProfesionalesTelefono_Sel));
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV65IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV65IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV66IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV66IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", AV70IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( "", AV70IsAuthorized_ProfesionalesPrimerNombre, context));
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
            WE3O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3O2( ) ;
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
         return formatLink("profcomisionesww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ProfComisionesWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Comisiones para Profesionales", "") ;
      }

      protected void WB3O0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_3O2( true) ;
         }
         else
         {
            wb_table1_25_3O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_3O2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_ProfComisionesWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_3O2( true) ;
         }
         else
         {
            wb_table2_49_3O2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_3O2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "", true, 0, "HLP_ProfComisionesWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_74_3O2( true) ;
         }
         else
         {
            wb_table3_74_3O2( false) ;
         }
         return  ;
      }

      protected void wb_table3_74_3O2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_ProfComisionesWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_99_3O2( true) ;
         }
         else
         {
            wb_table4_99_3O2( false) ;
         }
         return  ;
      }

      protected void wb_table4_99_3O2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV60GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV61GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV62GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV67AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ProfComisionesWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV58DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV58DDO_TitleSettingsIcons);
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
               GxWebStd.gx_hidden_field( context, "W0144"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0144"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_120_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0144"+"");
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

      protected void START3O2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Comisiones para Profesionales", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3O0( ) ;
      }

      protected void WS3O2( )
      {
         START3O2( ) ;
         EVT3O2( ) ;
      }

      protected void EVT3O2( )
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
                              E113O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E123O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E133O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E143O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E153O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E163O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E173O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E183O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E193O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E203O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E213O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E223O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E233O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E243O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E253O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E263O2 ();
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
                              AV63GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV63GridActions), 4, 0));
                              A450ProfComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
                              A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
                              A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
                              A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
                              A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
                              A451ProfComisionesAutoEnun = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesAutoEnun_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E273O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E283O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E293O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E303O2 ();
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
                                       /* Set Refresh If Profcomisionesautoenun1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vPROFCOMISIONESAUTOENUN1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV20ProfComisionesAutoEnun1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Profesionalesprimernombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE1"), AV21ProfesionalesPrimerNombre1) != 0 )
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
                                       /* Set Refresh If Profcomisionesautoenun2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vPROFCOMISIONESAUTOENUN2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV25ProfComisionesAutoEnun2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Profesionalesprimernombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE2"), AV26ProfesionalesPrimerNombre2) != 0 )
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
                                       /* Set Refresh If Profcomisionesautoenun3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vPROFCOMISIONESAUTOENUN3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV30ProfComisionesAutoEnun3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Profesionalesprimernombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE3"), AV31ProfesionalesPrimerNombre3) != 0 )
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
                        if ( nCmpId == 144 )
                        {
                           OldWwpaux_wc = cgiGet( "W0144");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0144", "", sEvt);
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

      protected void WE3O2( )
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

      protected void PA3O2( )
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
                                       short AV20ProfComisionesAutoEnun1 ,
                                       string AV21ProfesionalesPrimerNombre1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       short AV25ProfComisionesAutoEnun2 ,
                                       string AV26ProfesionalesPrimerNombre2 ,
                                       string AV28DynamicFiltersSelector3 ,
                                       short AV29DynamicFiltersOperator3 ,
                                       short AV30ProfComisionesAutoEnun3 ,
                                       string AV31ProfesionalesPrimerNombre3 ,
                                       short AV43ManageFiltersExecutionStep ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       bool AV27DynamicFiltersEnabled3 ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ,
                                       string AV73Pgmname ,
                                       long AV44TFProfComisionesID ,
                                       long AV45TFProfComisionesID_To ,
                                       string AV46TFProfesionalesId ,
                                       string AV47TFProfesionalesId_Sel ,
                                       string AV48TFProfesionalesPrimerNombre ,
                                       string AV49TFProfesionalesPrimerNombre_Sel ,
                                       string AV50TFProfesionalesSegundoNombre ,
                                       string AV51TFProfesionalesSegundoNombre_Sel ,
                                       string AV52TFProfesionalesApellidoPrimero ,
                                       string AV53TFProfesionalesApellidoPrimero_Sel ,
                                       string AV54TFProfesionalesApellidoSegundo ,
                                       string AV55TFProfesionalesApellidoSegundo_Sel ,
                                       string AV56TFProfesionalesTelefono ,
                                       string AV57TFProfesionalesTelefono_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV33DynamicFiltersIgnoreFirst ,
                                       bool AV32DynamicFiltersRemoving ,
                                       bool AV65IsAuthorized_Update ,
                                       bool AV66IsAuthorized_Delete ,
                                       bool AV70IsAuthorized_ProfesionalesPrimerNombre )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3O2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFCOMISIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A450ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROFCOMISIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A450ProfComisionesID), 18, 0, ".", "")));
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
         RF3O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV73Pgmname = "ProfComisionesWW";
      }

      protected void RF3O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 120;
         /* Execute user event: Refresh */
         E283O2 ();
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
                                                 AV74Profcomisioneswwds_1_filterfulltext ,
                                                 AV75Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                                 AV76Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                                 AV77Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                                 AV78Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                                 AV79Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                                 AV80Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                                 AV81Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                                 AV82Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                                 AV83Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                                 AV84Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                                 AV85Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                                 AV86Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                                 AV87Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                                 AV88Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                                 AV89Profcomisioneswwds_16_tfprofcomisionesid ,
                                                 AV90Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                                 AV92Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                                 AV91Profcomisioneswwds_18_tfprofesionalesid ,
                                                 AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                                 AV93Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                                 AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                                 AV95Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                                 AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                                 AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                                 AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                                 AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                                 AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                                 AV101Profcomisioneswwds_28_tfprofesionalestelefono ,
                                                 A450ProfComisionesID ,
                                                 A120ProfesionalesId ,
                                                 A166ProfesionalesPrimerNombre ,
                                                 A191ProfesionalesSegundoNombre ,
                                                 A167ProfesionalesApellidoPrimero ,
                                                 A192ProfesionalesApellidoSegundo ,
                                                 A170ProfesionalesTelefono ,
                                                 A451ProfComisionesAutoEnun ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
            lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
            lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
            lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
            lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
            lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
            lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
            lV78Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
            lV78Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
            lV83Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
            lV83Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
            lV88Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
            lV88Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
            lV91Profcomisioneswwds_18_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV91Profcomisioneswwds_18_tfprofesionalesid), 20, "%");
            lV93Profcomisioneswwds_20_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV93Profcomisioneswwds_20_tfprofesionalesprimernombre), 30, "%");
            lV95Profcomisioneswwds_22_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV95Profcomisioneswwds_22_tfprofesionalessegundonombre), 30, "%");
            lV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero), 30, "%");
            lV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo), 30, "%");
            lV101Profcomisioneswwds_28_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV101Profcomisioneswwds_28_tfprofesionalestelefono), 20, "%");
            /* Using cursor H003O2 */
            pr_default.execute(0, new Object[] {lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, AV77Profcomisioneswwds_4_profcomisionesautoenun1, AV77Profcomisioneswwds_4_profcomisionesautoenun1, AV77Profcomisioneswwds_4_profcomisionesautoenun1, lV78Profcomisioneswwds_5_profesionalesprimernombre1, lV78Profcomisioneswwds_5_profesionalesprimernombre1, AV82Profcomisioneswwds_9_profcomisionesautoenun2, AV82Profcomisioneswwds_9_profcomisionesautoenun2, AV82Profcomisioneswwds_9_profcomisionesautoenun2, lV83Profcomisioneswwds_10_profesionalesprimernombre2, lV83Profcomisioneswwds_10_profesionalesprimernombre2, AV87Profcomisioneswwds_14_profcomisionesautoenun3, AV87Profcomisioneswwds_14_profcomisionesautoenun3, AV87Profcomisioneswwds_14_profcomisionesautoenun3, lV88Profcomisioneswwds_15_profesionalesprimernombre3, lV88Profcomisioneswwds_15_profesionalesprimernombre3, AV89Profcomisioneswwds_16_tfprofcomisionesid, AV90Profcomisioneswwds_17_tfprofcomisionesid_to, lV91Profcomisioneswwds_18_tfprofesionalesid, AV92Profcomisioneswwds_19_tfprofesionalesid_sel, lV93Profcomisioneswwds_20_tfprofesionalesprimernombre, AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, lV95Profcomisioneswwds_22_tfprofesionalessegundonombre, AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, lV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero, AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, lV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo, AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, lV101Profcomisioneswwds_28_tfprofesionalestelefono, AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_120_idx = 1;
            sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
            SubsflControlProps_1202( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A451ProfComisionesAutoEnun = H003O2_A451ProfComisionesAutoEnun[0];
               A170ProfesionalesTelefono = H003O2_A170ProfesionalesTelefono[0];
               A192ProfesionalesApellidoSegundo = H003O2_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H003O2_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H003O2_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H003O2_A166ProfesionalesPrimerNombre[0];
               A120ProfesionalesId = H003O2_A120ProfesionalesId[0];
               A450ProfComisionesID = H003O2_A450ProfComisionesID[0];
               A170ProfesionalesTelefono = H003O2_A170ProfesionalesTelefono[0];
               A192ProfesionalesApellidoSegundo = H003O2_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H003O2_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H003O2_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H003O2_A166ProfesionalesPrimerNombre[0];
               /* Execute user event: Grid.Load */
               E293O2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 120;
            WB3O0( ) ;
         }
         bGXsfl_120_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3O2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV65IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV65IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV66IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV66IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", AV70IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( "", AV70IsAuthorized_ProfesionalesPrimerNombre, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFCOMISIONESID"+"_"+sGXsfl_120_idx, GetSecureSignedToken( sGXsfl_120_idx, context.localUtil.Format( (decimal)(A450ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         AV74Profcomisioneswwds_1_filterfulltext = AV17FilterFullText;
         AV75Profcomisioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Profcomisioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Profcomisioneswwds_4_profcomisionesautoenun1 = AV20ProfComisionesAutoEnun1;
         AV78Profcomisioneswwds_5_profesionalesprimernombre1 = AV21ProfesionalesPrimerNombre1;
         AV79Profcomisioneswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Profcomisioneswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Profcomisioneswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Profcomisioneswwds_9_profcomisionesautoenun2 = AV25ProfComisionesAutoEnun2;
         AV83Profcomisioneswwds_10_profesionalesprimernombre2 = AV26ProfesionalesPrimerNombre2;
         AV84Profcomisioneswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Profcomisioneswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Profcomisioneswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Profcomisioneswwds_14_profcomisionesautoenun3 = AV30ProfComisionesAutoEnun3;
         AV88Profcomisioneswwds_15_profesionalesprimernombre3 = AV31ProfesionalesPrimerNombre3;
         AV89Profcomisioneswwds_16_tfprofcomisionesid = AV44TFProfComisionesID;
         AV90Profcomisioneswwds_17_tfprofcomisionesid_to = AV45TFProfComisionesID_To;
         AV91Profcomisioneswwds_18_tfprofesionalesid = AV46TFProfesionalesId;
         AV92Profcomisioneswwds_19_tfprofesionalesid_sel = AV47TFProfesionalesId_Sel;
         AV93Profcomisioneswwds_20_tfprofesionalesprimernombre = AV48TFProfesionalesPrimerNombre;
         AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV49TFProfesionalesPrimerNombre_Sel;
         AV95Profcomisioneswwds_22_tfprofesionalessegundonombre = AV50TFProfesionalesSegundoNombre;
         AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV51TFProfesionalesSegundoNombre_Sel;
         AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV52TFProfesionalesApellidoPrimero;
         AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV53TFProfesionalesApellidoPrimero_Sel;
         AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV54TFProfesionalesApellidoSegundo;
         AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV55TFProfesionalesApellidoSegundo_Sel;
         AV101Profcomisioneswwds_28_tfprofesionalestelefono = AV56TFProfesionalesTelefono;
         AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV57TFProfesionalesTelefono_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV74Profcomisioneswwds_1_filterfulltext ,
                                              AV75Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                              AV76Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV77Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                              AV78Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                              AV79Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                              AV80Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                              AV81Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                              AV82Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                              AV83Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                              AV84Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                              AV85Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                              AV86Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                              AV87Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                              AV88Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                              AV89Profcomisioneswwds_16_tfprofcomisionesid ,
                                              AV90Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                              AV92Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                              AV91Profcomisioneswwds_18_tfprofesionalesid ,
                                              AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                              AV93Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                              AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                              AV95Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                              AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                              AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                              AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                              AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                              AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                              AV101Profcomisioneswwds_28_tfprofesionalestelefono ,
                                              A450ProfComisionesID ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A451ProfComisionesAutoEnun ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
         lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
         lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
         lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
         lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
         lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
         lV74Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext), "%", "");
         lV78Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV78Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV83Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV83Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV88Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV88Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV91Profcomisioneswwds_18_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV91Profcomisioneswwds_18_tfprofesionalesid), 20, "%");
         lV93Profcomisioneswwds_20_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV93Profcomisioneswwds_20_tfprofesionalesprimernombre), 30, "%");
         lV95Profcomisioneswwds_22_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV95Profcomisioneswwds_22_tfprofesionalessegundonombre), 30, "%");
         lV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero), 30, "%");
         lV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo), 30, "%");
         lV101Profcomisioneswwds_28_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV101Profcomisioneswwds_28_tfprofesionalestelefono), 20, "%");
         /* Using cursor H003O3 */
         pr_default.execute(1, new Object[] {lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, lV74Profcomisioneswwds_1_filterfulltext, AV77Profcomisioneswwds_4_profcomisionesautoenun1, AV77Profcomisioneswwds_4_profcomisionesautoenun1, AV77Profcomisioneswwds_4_profcomisionesautoenun1, lV78Profcomisioneswwds_5_profesionalesprimernombre1, lV78Profcomisioneswwds_5_profesionalesprimernombre1, AV82Profcomisioneswwds_9_profcomisionesautoenun2, AV82Profcomisioneswwds_9_profcomisionesautoenun2, AV82Profcomisioneswwds_9_profcomisionesautoenun2, lV83Profcomisioneswwds_10_profesionalesprimernombre2, lV83Profcomisioneswwds_10_profesionalesprimernombre2, AV87Profcomisioneswwds_14_profcomisionesautoenun3, AV87Profcomisioneswwds_14_profcomisionesautoenun3, AV87Profcomisioneswwds_14_profcomisionesautoenun3, lV88Profcomisioneswwds_15_profesionalesprimernombre3, lV88Profcomisioneswwds_15_profesionalesprimernombre3, AV89Profcomisioneswwds_16_tfprofcomisionesid, AV90Profcomisioneswwds_17_tfprofcomisionesid_to, lV91Profcomisioneswwds_18_tfprofesionalesid, AV92Profcomisioneswwds_19_tfprofesionalesid_sel, lV93Profcomisioneswwds_20_tfprofesionalesprimernombre, AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, lV95Profcomisioneswwds_22_tfprofesionalessegundonombre, AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, lV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero, AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, lV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo, AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, lV101Profcomisioneswwds_28_tfprofesionalestelefono, AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel});
         GRID_nRecordCount = H003O3_AGRID_nRecordCount[0];
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
         AV74Profcomisioneswwds_1_filterfulltext = AV17FilterFullText;
         AV75Profcomisioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Profcomisioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Profcomisioneswwds_4_profcomisionesautoenun1 = AV20ProfComisionesAutoEnun1;
         AV78Profcomisioneswwds_5_profesionalesprimernombre1 = AV21ProfesionalesPrimerNombre1;
         AV79Profcomisioneswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Profcomisioneswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Profcomisioneswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Profcomisioneswwds_9_profcomisionesautoenun2 = AV25ProfComisionesAutoEnun2;
         AV83Profcomisioneswwds_10_profesionalesprimernombre2 = AV26ProfesionalesPrimerNombre2;
         AV84Profcomisioneswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Profcomisioneswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Profcomisioneswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Profcomisioneswwds_14_profcomisionesautoenun3 = AV30ProfComisionesAutoEnun3;
         AV88Profcomisioneswwds_15_profesionalesprimernombre3 = AV31ProfesionalesPrimerNombre3;
         AV89Profcomisioneswwds_16_tfprofcomisionesid = AV44TFProfComisionesID;
         AV90Profcomisioneswwds_17_tfprofcomisionesid_to = AV45TFProfComisionesID_To;
         AV91Profcomisioneswwds_18_tfprofesionalesid = AV46TFProfesionalesId;
         AV92Profcomisioneswwds_19_tfprofesionalesid_sel = AV47TFProfesionalesId_Sel;
         AV93Profcomisioneswwds_20_tfprofesionalesprimernombre = AV48TFProfesionalesPrimerNombre;
         AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV49TFProfesionalesPrimerNombre_Sel;
         AV95Profcomisioneswwds_22_tfprofesionalessegundonombre = AV50TFProfesionalesSegundoNombre;
         AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV51TFProfesionalesSegundoNombre_Sel;
         AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV52TFProfesionalesApellidoPrimero;
         AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV53TFProfesionalesApellidoPrimero_Sel;
         AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV54TFProfesionalesApellidoSegundo;
         AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV55TFProfesionalesApellidoSegundo_Sel;
         AV101Profcomisioneswwds_28_tfprofesionalestelefono = AV56TFProfesionalesTelefono;
         AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV57TFProfesionalesTelefono_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ProfComisionesAutoEnun1, AV21ProfesionalesPrimerNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ProfComisionesAutoEnun2, AV26ProfesionalesPrimerNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30ProfComisionesAutoEnun3, AV31ProfesionalesPrimerNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV73Pgmname, AV44TFProfComisionesID, AV45TFProfComisionesID_To, AV46TFProfesionalesId, AV47TFProfesionalesId_Sel, AV48TFProfesionalesPrimerNombre, AV49TFProfesionalesPrimerNombre_Sel, AV50TFProfesionalesSegundoNombre, AV51TFProfesionalesSegundoNombre_Sel, AV52TFProfesionalesApellidoPrimero, AV53TFProfesionalesApellidoPrimero_Sel, AV54TFProfesionalesApellidoSegundo, AV55TFProfesionalesApellidoSegundo_Sel, AV56TFProfesionalesTelefono, AV57TFProfesionalesTelefono_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV65IsAuthorized_Update, AV66IsAuthorized_Delete, AV70IsAuthorized_ProfesionalesPrimerNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV74Profcomisioneswwds_1_filterfulltext = AV17FilterFullText;
         AV75Profcomisioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Profcomisioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Profcomisioneswwds_4_profcomisionesautoenun1 = AV20ProfComisionesAutoEnun1;
         AV78Profcomisioneswwds_5_profesionalesprimernombre1 = AV21ProfesionalesPrimerNombre1;
         AV79Profcomisioneswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Profcomisioneswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Profcomisioneswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Profcomisioneswwds_9_profcomisionesautoenun2 = AV25ProfComisionesAutoEnun2;
         AV83Profcomisioneswwds_10_profesionalesprimernombre2 = AV26ProfesionalesPrimerNombre2;
         AV84Profcomisioneswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Profcomisioneswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Profcomisioneswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Profcomisioneswwds_14_profcomisionesautoenun3 = AV30ProfComisionesAutoEnun3;
         AV88Profcomisioneswwds_15_profesionalesprimernombre3 = AV31ProfesionalesPrimerNombre3;
         AV89Profcomisioneswwds_16_tfprofcomisionesid = AV44TFProfComisionesID;
         AV90Profcomisioneswwds_17_tfprofcomisionesid_to = AV45TFProfComisionesID_To;
         AV91Profcomisioneswwds_18_tfprofesionalesid = AV46TFProfesionalesId;
         AV92Profcomisioneswwds_19_tfprofesionalesid_sel = AV47TFProfesionalesId_Sel;
         AV93Profcomisioneswwds_20_tfprofesionalesprimernombre = AV48TFProfesionalesPrimerNombre;
         AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV49TFProfesionalesPrimerNombre_Sel;
         AV95Profcomisioneswwds_22_tfprofesionalessegundonombre = AV50TFProfesionalesSegundoNombre;
         AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV51TFProfesionalesSegundoNombre_Sel;
         AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV52TFProfesionalesApellidoPrimero;
         AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV53TFProfesionalesApellidoPrimero_Sel;
         AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV54TFProfesionalesApellidoSegundo;
         AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV55TFProfesionalesApellidoSegundo_Sel;
         AV101Profcomisioneswwds_28_tfprofesionalestelefono = AV56TFProfesionalesTelefono;
         AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV57TFProfesionalesTelefono_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ProfComisionesAutoEnun1, AV21ProfesionalesPrimerNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ProfComisionesAutoEnun2, AV26ProfesionalesPrimerNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30ProfComisionesAutoEnun3, AV31ProfesionalesPrimerNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV73Pgmname, AV44TFProfComisionesID, AV45TFProfComisionesID_To, AV46TFProfesionalesId, AV47TFProfesionalesId_Sel, AV48TFProfesionalesPrimerNombre, AV49TFProfesionalesPrimerNombre_Sel, AV50TFProfesionalesSegundoNombre, AV51TFProfesionalesSegundoNombre_Sel, AV52TFProfesionalesApellidoPrimero, AV53TFProfesionalesApellidoPrimero_Sel, AV54TFProfesionalesApellidoSegundo, AV55TFProfesionalesApellidoSegundo_Sel, AV56TFProfesionalesTelefono, AV57TFProfesionalesTelefono_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV65IsAuthorized_Update, AV66IsAuthorized_Delete, AV70IsAuthorized_ProfesionalesPrimerNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV74Profcomisioneswwds_1_filterfulltext = AV17FilterFullText;
         AV75Profcomisioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Profcomisioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Profcomisioneswwds_4_profcomisionesautoenun1 = AV20ProfComisionesAutoEnun1;
         AV78Profcomisioneswwds_5_profesionalesprimernombre1 = AV21ProfesionalesPrimerNombre1;
         AV79Profcomisioneswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Profcomisioneswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Profcomisioneswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Profcomisioneswwds_9_profcomisionesautoenun2 = AV25ProfComisionesAutoEnun2;
         AV83Profcomisioneswwds_10_profesionalesprimernombre2 = AV26ProfesionalesPrimerNombre2;
         AV84Profcomisioneswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Profcomisioneswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Profcomisioneswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Profcomisioneswwds_14_profcomisionesautoenun3 = AV30ProfComisionesAutoEnun3;
         AV88Profcomisioneswwds_15_profesionalesprimernombre3 = AV31ProfesionalesPrimerNombre3;
         AV89Profcomisioneswwds_16_tfprofcomisionesid = AV44TFProfComisionesID;
         AV90Profcomisioneswwds_17_tfprofcomisionesid_to = AV45TFProfComisionesID_To;
         AV91Profcomisioneswwds_18_tfprofesionalesid = AV46TFProfesionalesId;
         AV92Profcomisioneswwds_19_tfprofesionalesid_sel = AV47TFProfesionalesId_Sel;
         AV93Profcomisioneswwds_20_tfprofesionalesprimernombre = AV48TFProfesionalesPrimerNombre;
         AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV49TFProfesionalesPrimerNombre_Sel;
         AV95Profcomisioneswwds_22_tfprofesionalessegundonombre = AV50TFProfesionalesSegundoNombre;
         AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV51TFProfesionalesSegundoNombre_Sel;
         AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV52TFProfesionalesApellidoPrimero;
         AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV53TFProfesionalesApellidoPrimero_Sel;
         AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV54TFProfesionalesApellidoSegundo;
         AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV55TFProfesionalesApellidoSegundo_Sel;
         AV101Profcomisioneswwds_28_tfprofesionalestelefono = AV56TFProfesionalesTelefono;
         AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV57TFProfesionalesTelefono_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ProfComisionesAutoEnun1, AV21ProfesionalesPrimerNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ProfComisionesAutoEnun2, AV26ProfesionalesPrimerNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30ProfComisionesAutoEnun3, AV31ProfesionalesPrimerNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV73Pgmname, AV44TFProfComisionesID, AV45TFProfComisionesID_To, AV46TFProfesionalesId, AV47TFProfesionalesId_Sel, AV48TFProfesionalesPrimerNombre, AV49TFProfesionalesPrimerNombre_Sel, AV50TFProfesionalesSegundoNombre, AV51TFProfesionalesSegundoNombre_Sel, AV52TFProfesionalesApellidoPrimero, AV53TFProfesionalesApellidoPrimero_Sel, AV54TFProfesionalesApellidoSegundo, AV55TFProfesionalesApellidoSegundo_Sel, AV56TFProfesionalesTelefono, AV57TFProfesionalesTelefono_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV65IsAuthorized_Update, AV66IsAuthorized_Delete, AV70IsAuthorized_ProfesionalesPrimerNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV74Profcomisioneswwds_1_filterfulltext = AV17FilterFullText;
         AV75Profcomisioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Profcomisioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Profcomisioneswwds_4_profcomisionesautoenun1 = AV20ProfComisionesAutoEnun1;
         AV78Profcomisioneswwds_5_profesionalesprimernombre1 = AV21ProfesionalesPrimerNombre1;
         AV79Profcomisioneswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Profcomisioneswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Profcomisioneswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Profcomisioneswwds_9_profcomisionesautoenun2 = AV25ProfComisionesAutoEnun2;
         AV83Profcomisioneswwds_10_profesionalesprimernombre2 = AV26ProfesionalesPrimerNombre2;
         AV84Profcomisioneswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Profcomisioneswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Profcomisioneswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Profcomisioneswwds_14_profcomisionesautoenun3 = AV30ProfComisionesAutoEnun3;
         AV88Profcomisioneswwds_15_profesionalesprimernombre3 = AV31ProfesionalesPrimerNombre3;
         AV89Profcomisioneswwds_16_tfprofcomisionesid = AV44TFProfComisionesID;
         AV90Profcomisioneswwds_17_tfprofcomisionesid_to = AV45TFProfComisionesID_To;
         AV91Profcomisioneswwds_18_tfprofesionalesid = AV46TFProfesionalesId;
         AV92Profcomisioneswwds_19_tfprofesionalesid_sel = AV47TFProfesionalesId_Sel;
         AV93Profcomisioneswwds_20_tfprofesionalesprimernombre = AV48TFProfesionalesPrimerNombre;
         AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV49TFProfesionalesPrimerNombre_Sel;
         AV95Profcomisioneswwds_22_tfprofesionalessegundonombre = AV50TFProfesionalesSegundoNombre;
         AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV51TFProfesionalesSegundoNombre_Sel;
         AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV52TFProfesionalesApellidoPrimero;
         AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV53TFProfesionalesApellidoPrimero_Sel;
         AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV54TFProfesionalesApellidoSegundo;
         AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV55TFProfesionalesApellidoSegundo_Sel;
         AV101Profcomisioneswwds_28_tfprofesionalestelefono = AV56TFProfesionalesTelefono;
         AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV57TFProfesionalesTelefono_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ProfComisionesAutoEnun1, AV21ProfesionalesPrimerNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ProfComisionesAutoEnun2, AV26ProfesionalesPrimerNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30ProfComisionesAutoEnun3, AV31ProfesionalesPrimerNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV73Pgmname, AV44TFProfComisionesID, AV45TFProfComisionesID_To, AV46TFProfesionalesId, AV47TFProfesionalesId_Sel, AV48TFProfesionalesPrimerNombre, AV49TFProfesionalesPrimerNombre_Sel, AV50TFProfesionalesSegundoNombre, AV51TFProfesionalesSegundoNombre_Sel, AV52TFProfesionalesApellidoPrimero, AV53TFProfesionalesApellidoPrimero_Sel, AV54TFProfesionalesApellidoSegundo, AV55TFProfesionalesApellidoSegundo_Sel, AV56TFProfesionalesTelefono, AV57TFProfesionalesTelefono_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV65IsAuthorized_Update, AV66IsAuthorized_Delete, AV70IsAuthorized_ProfesionalesPrimerNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV74Profcomisioneswwds_1_filterfulltext = AV17FilterFullText;
         AV75Profcomisioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Profcomisioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Profcomisioneswwds_4_profcomisionesautoenun1 = AV20ProfComisionesAutoEnun1;
         AV78Profcomisioneswwds_5_profesionalesprimernombre1 = AV21ProfesionalesPrimerNombre1;
         AV79Profcomisioneswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Profcomisioneswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Profcomisioneswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Profcomisioneswwds_9_profcomisionesautoenun2 = AV25ProfComisionesAutoEnun2;
         AV83Profcomisioneswwds_10_profesionalesprimernombre2 = AV26ProfesionalesPrimerNombre2;
         AV84Profcomisioneswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Profcomisioneswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Profcomisioneswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Profcomisioneswwds_14_profcomisionesautoenun3 = AV30ProfComisionesAutoEnun3;
         AV88Profcomisioneswwds_15_profesionalesprimernombre3 = AV31ProfesionalesPrimerNombre3;
         AV89Profcomisioneswwds_16_tfprofcomisionesid = AV44TFProfComisionesID;
         AV90Profcomisioneswwds_17_tfprofcomisionesid_to = AV45TFProfComisionesID_To;
         AV91Profcomisioneswwds_18_tfprofesionalesid = AV46TFProfesionalesId;
         AV92Profcomisioneswwds_19_tfprofesionalesid_sel = AV47TFProfesionalesId_Sel;
         AV93Profcomisioneswwds_20_tfprofesionalesprimernombre = AV48TFProfesionalesPrimerNombre;
         AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV49TFProfesionalesPrimerNombre_Sel;
         AV95Profcomisioneswwds_22_tfprofesionalessegundonombre = AV50TFProfesionalesSegundoNombre;
         AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV51TFProfesionalesSegundoNombre_Sel;
         AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV52TFProfesionalesApellidoPrimero;
         AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV53TFProfesionalesApellidoPrimero_Sel;
         AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV54TFProfesionalesApellidoSegundo;
         AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV55TFProfesionalesApellidoSegundo_Sel;
         AV101Profcomisioneswwds_28_tfprofesionalestelefono = AV56TFProfesionalesTelefono;
         AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV57TFProfesionalesTelefono_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ProfComisionesAutoEnun1, AV21ProfesionalesPrimerNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ProfComisionesAutoEnun2, AV26ProfesionalesPrimerNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30ProfComisionesAutoEnun3, AV31ProfesionalesPrimerNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV73Pgmname, AV44TFProfComisionesID, AV45TFProfComisionesID_To, AV46TFProfesionalesId, AV47TFProfesionalesId_Sel, AV48TFProfesionalesPrimerNombre, AV49TFProfesionalesPrimerNombre_Sel, AV50TFProfesionalesSegundoNombre, AV51TFProfesionalesSegundoNombre_Sel, AV52TFProfesionalesApellidoPrimero, AV53TFProfesionalesApellidoPrimero_Sel, AV54TFProfesionalesApellidoSegundo, AV55TFProfesionalesApellidoSegundo_Sel, AV56TFProfesionalesTelefono, AV57TFProfesionalesTelefono_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV65IsAuthorized_Update, AV66IsAuthorized_Delete, AV70IsAuthorized_ProfesionalesPrimerNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV73Pgmname = "ProfComisionesWW";
         edtProfComisionesID_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtProfComisionesAutoEnun_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E273O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV67AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV58DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV38ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_120 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_120"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV60GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV61GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV62GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProfcomisionesautoenun1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProfcomisionesautoenun1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROFCOMISIONESAUTOENUN1");
               GX_FocusControl = edtavProfcomisionesautoenun1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20ProfComisionesAutoEnun1 = 0;
               AssignAttri("", false, "AV20ProfComisionesAutoEnun1", StringUtil.LTrimStr( (decimal)(AV20ProfComisionesAutoEnun1), 4, 0));
            }
            else
            {
               AV20ProfComisionesAutoEnun1 = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavProfcomisionesautoenun1_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ProfComisionesAutoEnun1", StringUtil.LTrimStr( (decimal)(AV20ProfComisionesAutoEnun1), 4, 0));
            }
            AV21ProfesionalesPrimerNombre1 = cgiGet( edtavProfesionalesprimernombre1_Internalname);
            AssignAttri("", false, "AV21ProfesionalesPrimerNombre1", AV21ProfesionalesPrimerNombre1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProfcomisionesautoenun2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProfcomisionesautoenun2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROFCOMISIONESAUTOENUN2");
               GX_FocusControl = edtavProfcomisionesautoenun2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25ProfComisionesAutoEnun2 = 0;
               AssignAttri("", false, "AV25ProfComisionesAutoEnun2", StringUtil.LTrimStr( (decimal)(AV25ProfComisionesAutoEnun2), 4, 0));
            }
            else
            {
               AV25ProfComisionesAutoEnun2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavProfcomisionesautoenun2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25ProfComisionesAutoEnun2", StringUtil.LTrimStr( (decimal)(AV25ProfComisionesAutoEnun2), 4, 0));
            }
            AV26ProfesionalesPrimerNombre2 = cgiGet( edtavProfesionalesprimernombre2_Internalname);
            AssignAttri("", false, "AV26ProfesionalesPrimerNombre2", AV26ProfesionalesPrimerNombre2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV28DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProfcomisionesautoenun3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProfcomisionesautoenun3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROFCOMISIONESAUTOENUN3");
               GX_FocusControl = edtavProfcomisionesautoenun3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30ProfComisionesAutoEnun3 = 0;
               AssignAttri("", false, "AV30ProfComisionesAutoEnun3", StringUtil.LTrimStr( (decimal)(AV30ProfComisionesAutoEnun3), 4, 0));
            }
            else
            {
               AV30ProfComisionesAutoEnun3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavProfcomisionesautoenun3_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30ProfComisionesAutoEnun3", StringUtil.LTrimStr( (decimal)(AV30ProfComisionesAutoEnun3), 4, 0));
            }
            AV31ProfesionalesPrimerNombre3 = cgiGet( edtavProfesionalesprimernombre3_Internalname);
            AssignAttri("", false, "AV31ProfesionalesPrimerNombre3", AV31ProfesionalesPrimerNombre3);
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vPROFCOMISIONESAUTOENUN1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV20ProfComisionesAutoEnun1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE1"), AV21ProfesionalesPrimerNombre1) != 0 )
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vPROFCOMISIONESAUTOENUN2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV25ProfComisionesAutoEnun2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE2"), AV26ProfesionalesPrimerNombre2) != 0 )
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vPROFCOMISIONESAUTOENUN3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV30ProfComisionesAutoEnun3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE3"), AV31ProfesionalesPrimerNombre3) != 0 )
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
         E273O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E273O2( )
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
         AV18DynamicFiltersSelector1 = "PROFCOMISIONESAUTOENUN";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector2 = "PROFCOMISIONESAUTOENUN";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28DynamicFiltersSelector3 = "PROFCOMISIONESAUTOENUN";
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
         AV67AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV68AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV68AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV68AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV68AGExportDataItem.gxTpr_Eventkey = "Export";
         AV68AGExportDataItem.gxTpr_Isdivider = false;
         AV67AGExportData.Add(AV68AGExportDataItem, 0);
         AV68AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV68AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV68AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV68AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV68AGExportDataItem.gxTpr_Isdivider = false;
         AV67AGExportData.Add(AV68AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV70IsAuthorized_ProfesionalesPrimerNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
         AV70IsAuthorized_ProfesionalesPrimerNombre = GXt_boolean1;
         AssignAttri("", false, "AV70IsAuthorized_ProfesionalesPrimerNombre", AV70IsAuthorized_ProfesionalesPrimerNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE", GetSecureSignedToken( "", AV70IsAuthorized_ProfesionalesPrimerNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Comisiones para Profesionales", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV58DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV58DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E283O2( )
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
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFCOMISIONESAUTOENUN") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROFCOMISIONESAUTOENUN") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            if ( AV27DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFCOMISIONESAUTOENUN") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
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
         if ( StringUtil.StrCmp(AV40Session.Get("ProfComisionesWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV40Session.Get("ProfComisionesWWColumnsSelector");
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
         edtProfComisionesID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfComisionesID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfComisionesID_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtProfesionalesId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtProfesionalesPrimerNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtProfesionalesSegundoNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesSegundoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesSegundoNombre_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtProfesionalesApellidoPrimero_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtProfesionalesApellidoSegundo_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesApellidoSegundo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoSegundo_Visible), 5, 0), !bGXsfl_120_Refreshing);
         edtProfesionalesTelefono_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesTelefono_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesTelefono_Visible), 5, 0), !bGXsfl_120_Refreshing);
         AV60GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV60GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV60GridCurrentPage), 10, 0));
         AV61GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV61GridPageCount", StringUtil.LTrimStr( (decimal)(AV61GridPageCount), 10, 0));
         GXt_char3 = AV62GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV73Pgmname, out  GXt_char3) ;
         AV62GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV62GridAppliedFilters", AV62GridAppliedFilters);
         AV74Profcomisioneswwds_1_filterfulltext = AV17FilterFullText;
         AV75Profcomisioneswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Profcomisioneswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Profcomisioneswwds_4_profcomisionesautoenun1 = AV20ProfComisionesAutoEnun1;
         AV78Profcomisioneswwds_5_profesionalesprimernombre1 = AV21ProfesionalesPrimerNombre1;
         AV79Profcomisioneswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV80Profcomisioneswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV81Profcomisioneswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV82Profcomisioneswwds_9_profcomisionesautoenun2 = AV25ProfComisionesAutoEnun2;
         AV83Profcomisioneswwds_10_profesionalesprimernombre2 = AV26ProfesionalesPrimerNombre2;
         AV84Profcomisioneswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV85Profcomisioneswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV86Profcomisioneswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV87Profcomisioneswwds_14_profcomisionesautoenun3 = AV30ProfComisionesAutoEnun3;
         AV88Profcomisioneswwds_15_profesionalesprimernombre3 = AV31ProfesionalesPrimerNombre3;
         AV89Profcomisioneswwds_16_tfprofcomisionesid = AV44TFProfComisionesID;
         AV90Profcomisioneswwds_17_tfprofcomisionesid_to = AV45TFProfComisionesID_To;
         AV91Profcomisioneswwds_18_tfprofesionalesid = AV46TFProfesionalesId;
         AV92Profcomisioneswwds_19_tfprofesionalesid_sel = AV47TFProfesionalesId_Sel;
         AV93Profcomisioneswwds_20_tfprofesionalesprimernombre = AV48TFProfesionalesPrimerNombre;
         AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV49TFProfesionalesPrimerNombre_Sel;
         AV95Profcomisioneswwds_22_tfprofesionalessegundonombre = AV50TFProfesionalesSegundoNombre;
         AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV51TFProfesionalesSegundoNombre_Sel;
         AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV52TFProfesionalesApellidoPrimero;
         AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV53TFProfesionalesApellidoPrimero_Sel;
         AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV54TFProfesionalesApellidoSegundo;
         AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV55TFProfesionalesApellidoSegundo_Sel;
         AV101Profcomisioneswwds_28_tfprofesionalestelefono = AV56TFProfesionalesTelefono;
         AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV57TFProfesionalesTelefono_Sel;
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

      protected void E123O2( )
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
            AV59PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV59PageToGo) ;
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

      protected void E133O2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E163O2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfComisionesID") == 0 )
            {
               AV44TFProfComisionesID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFProfComisionesID", StringUtil.LTrimStr( (decimal)(AV44TFProfComisionesID), 18, 0));
               AV45TFProfComisionesID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFProfComisionesID_To", StringUtil.LTrimStr( (decimal)(AV45TFProfComisionesID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesId") == 0 )
            {
               AV46TFProfesionalesId = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV46TFProfesionalesId", AV46TFProfesionalesId);
               AV47TFProfesionalesId_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV47TFProfesionalesId_Sel", AV47TFProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesPrimerNombre") == 0 )
            {
               AV48TFProfesionalesPrimerNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFProfesionalesPrimerNombre", AV48TFProfesionalesPrimerNombre);
               AV49TFProfesionalesPrimerNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFProfesionalesPrimerNombre_Sel", AV49TFProfesionalesPrimerNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesSegundoNombre") == 0 )
            {
               AV50TFProfesionalesSegundoNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFProfesionalesSegundoNombre", AV50TFProfesionalesSegundoNombre);
               AV51TFProfesionalesSegundoNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFProfesionalesSegundoNombre_Sel", AV51TFProfesionalesSegundoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesApellidoPrimero") == 0 )
            {
               AV52TFProfesionalesApellidoPrimero = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV52TFProfesionalesApellidoPrimero", AV52TFProfesionalesApellidoPrimero);
               AV53TFProfesionalesApellidoPrimero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV53TFProfesionalesApellidoPrimero_Sel", AV53TFProfesionalesApellidoPrimero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesApellidoSegundo") == 0 )
            {
               AV54TFProfesionalesApellidoSegundo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFProfesionalesApellidoSegundo", AV54TFProfesionalesApellidoSegundo);
               AV55TFProfesionalesApellidoSegundo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFProfesionalesApellidoSegundo_Sel", AV55TFProfesionalesApellidoSegundo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesTelefono") == 0 )
            {
               AV56TFProfesionalesTelefono = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV56TFProfesionalesTelefono", AV56TFProfesionalesTelefono);
               AV57TFProfesionalesTelefono_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV57TFProfesionalesTelefono_Sel", AV57TFProfesionalesTelefono_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E293O2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         if ( AV65IsAuthorized_Update )
         {
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV66IsAuthorized_Delete )
         {
            cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         if ( AV70IsAuthorized_ProfesionalesPrimerNombre )
         {
            edtProfesionalesPrimerNombre_Link = formatLink("profesionalesview.aspx", new object[] {UrlEncode(StringUtil.RTrim(A120ProfesionalesId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ProfesionalesId","TabCode"}) ;
         }
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV63GridActions), 4, 0));
      }

      protected void E173O2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV36ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV38ColumnsSelector.FromJSonString(AV36ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "ProfComisionesWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV36ColumnsSelectorXML)) ? "" : AV38ColumnsSelector.ToXml(false, true, "", ""))) ;
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

      protected void E223O2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ProfComisionesAutoEnun1, AV21ProfesionalesPrimerNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ProfComisionesAutoEnun2, AV26ProfesionalesPrimerNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30ProfComisionesAutoEnun3, AV31ProfesionalesPrimerNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV73Pgmname, AV44TFProfComisionesID, AV45TFProfComisionesID_To, AV46TFProfesionalesId, AV47TFProfesionalesId_Sel, AV48TFProfesionalesPrimerNombre, AV49TFProfesionalesPrimerNombre_Sel, AV50TFProfesionalesSegundoNombre, AV51TFProfesionalesSegundoNombre_Sel, AV52TFProfesionalesApellidoPrimero, AV53TFProfesionalesApellidoPrimero_Sel, AV54TFProfesionalesApellidoSegundo, AV55TFProfesionalesApellidoSegundo_Sel, AV56TFProfesionalesTelefono, AV57TFProfesionalesTelefono_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV65IsAuthorized_Update, AV66IsAuthorized_Delete, AV70IsAuthorized_ProfesionalesPrimerNombre) ;
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

      protected void E183O2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ProfComisionesAutoEnun1, AV21ProfesionalesPrimerNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ProfComisionesAutoEnun2, AV26ProfesionalesPrimerNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30ProfComisionesAutoEnun3, AV31ProfesionalesPrimerNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV73Pgmname, AV44TFProfComisionesID, AV45TFProfComisionesID_To, AV46TFProfesionalesId, AV47TFProfesionalesId_Sel, AV48TFProfesionalesPrimerNombre, AV49TFProfesionalesPrimerNombre_Sel, AV50TFProfesionalesSegundoNombre, AV51TFProfesionalesSegundoNombre_Sel, AV52TFProfesionalesApellidoPrimero, AV53TFProfesionalesApellidoPrimero_Sel, AV54TFProfesionalesApellidoSegundo, AV55TFProfesionalesApellidoSegundo_Sel, AV56TFProfesionalesTelefono, AV57TFProfesionalesTelefono_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV65IsAuthorized_Update, AV66IsAuthorized_Delete, AV70IsAuthorized_ProfesionalesPrimerNombre) ;
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

      protected void E233O2( )
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

      protected void E243O2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ProfComisionesAutoEnun1, AV21ProfesionalesPrimerNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ProfComisionesAutoEnun2, AV26ProfesionalesPrimerNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30ProfComisionesAutoEnun3, AV31ProfesionalesPrimerNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV73Pgmname, AV44TFProfComisionesID, AV45TFProfComisionesID_To, AV46TFProfesionalesId, AV47TFProfesionalesId_Sel, AV48TFProfesionalesPrimerNombre, AV49TFProfesionalesPrimerNombre_Sel, AV50TFProfesionalesSegundoNombre, AV51TFProfesionalesSegundoNombre_Sel, AV52TFProfesionalesApellidoPrimero, AV53TFProfesionalesApellidoPrimero_Sel, AV54TFProfesionalesApellidoSegundo, AV55TFProfesionalesApellidoSegundo_Sel, AV56TFProfesionalesTelefono, AV57TFProfesionalesTelefono_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV65IsAuthorized_Update, AV66IsAuthorized_Delete, AV70IsAuthorized_ProfesionalesPrimerNombre) ;
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

      protected void E193O2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ProfComisionesAutoEnun1, AV21ProfesionalesPrimerNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ProfComisionesAutoEnun2, AV26ProfesionalesPrimerNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30ProfComisionesAutoEnun3, AV31ProfesionalesPrimerNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV73Pgmname, AV44TFProfComisionesID, AV45TFProfComisionesID_To, AV46TFProfesionalesId, AV47TFProfesionalesId_Sel, AV48TFProfesionalesPrimerNombre, AV49TFProfesionalesPrimerNombre_Sel, AV50TFProfesionalesSegundoNombre, AV51TFProfesionalesSegundoNombre_Sel, AV52TFProfesionalesApellidoPrimero, AV53TFProfesionalesApellidoPrimero_Sel, AV54TFProfesionalesApellidoSegundo, AV55TFProfesionalesApellidoSegundo_Sel, AV56TFProfesionalesTelefono, AV57TFProfesionalesTelefono_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV65IsAuthorized_Update, AV66IsAuthorized_Delete, AV70IsAuthorized_ProfesionalesPrimerNombre) ;
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

      protected void E253O2( )
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

      protected void E203O2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20ProfComisionesAutoEnun1, AV21ProfesionalesPrimerNombre1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25ProfComisionesAutoEnun2, AV26ProfesionalesPrimerNombre2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30ProfComisionesAutoEnun3, AV31ProfesionalesPrimerNombre3, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV73Pgmname, AV44TFProfComisionesID, AV45TFProfComisionesID_To, AV46TFProfesionalesId, AV47TFProfesionalesId_Sel, AV48TFProfesionalesPrimerNombre, AV49TFProfesionalesPrimerNombre_Sel, AV50TFProfesionalesSegundoNombre, AV51TFProfesionalesSegundoNombre_Sel, AV52TFProfesionalesApellidoPrimero, AV53TFProfesionalesApellidoPrimero_Sel, AV54TFProfesionalesApellidoSegundo, AV55TFProfesionalesApellidoSegundo_Sel, AV56TFProfesionalesTelefono, AV57TFProfesionalesTelefono_Sel, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV65IsAuthorized_Update, AV66IsAuthorized_Delete, AV70IsAuthorized_ProfesionalesPrimerNombre) ;
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

      protected void E263O2( )
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

      protected void E113O2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("ProfComisionesWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV73Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("ProfComisionesWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ProfComisionesWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV73Pgmname+"GridState",  AV42ManageFiltersXml) ;
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

      protected void E303O2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV63GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV63GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV63GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV63GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV63GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV63GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E213O2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profcomisiones.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("profcomisiones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E143O2( )
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

      protected void E153O2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0144",(string)"",(string)"ProfComisiones",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0144"+"");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "ProfComisionesID",  "",  "Comisiones ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "ProfesionalesId",  "",  "Identidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "ProfesionalesPrimerNombre",  "",  "Primer Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "ProfesionalesSegundoNombre",  "",  "Segundo Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "ProfesionalesApellidoPrimero",  "",  "Primero Apellido ",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "ProfesionalesApellidoSegundo",  "",  "Segundo Apellido ",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "ProfesionalesTelefono",  "",  "Teléfono",  true,  "") ;
         GXt_char3 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ProfComisionesWWColumnsSelector", out  GXt_char3) ;
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
         GXt_boolean1 = AV65IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfComisiones_Update", out  GXt_boolean1) ;
         AV65IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV65IsAuthorized_Update", AV65IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV65IsAuthorized_Update, context));
         GXt_boolean1 = AV66IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfComisiones_Delete", out  GXt_boolean1) ;
         AV66IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV66IsAuthorized_Delete", AV66IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV66IsAuthorized_Delete, context));
         GXt_boolean1 = AV69TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfComisiones_Insert", out  GXt_boolean1) ;
         AV69TempBoolean = GXt_boolean1;
         if ( ! ( AV69TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV69TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean1) ;
         AV69TempBoolean = GXt_boolean1;
         if ( ! ( AV69TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "ProfComisiones",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavProfcomisionesautoenun1_Visible = 0;
         AssignProp("", false, edtavProfcomisionesautoenun1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfcomisionesautoenun1_Visible), 5, 0), true);
         edtavProfesionalesprimernombre1_Visible = 0;
         AssignProp("", false, edtavProfesionalesprimernombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesionalesprimernombre1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFCOMISIONESAUTOENUN") == 0 )
         {
            edtavProfcomisionesautoenun1_Visible = 1;
            AssignProp("", false, edtavProfcomisionesautoenun1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfcomisionesautoenun1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 )
         {
            edtavProfesionalesprimernombre1_Visible = 1;
            AssignProp("", false, edtavProfesionalesprimernombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesionalesprimernombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavProfcomisionesautoenun2_Visible = 0;
         AssignProp("", false, edtavProfcomisionesautoenun2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfcomisionesautoenun2_Visible), 5, 0), true);
         edtavProfesionalesprimernombre2_Visible = 0;
         AssignProp("", false, edtavProfesionalesprimernombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesionalesprimernombre2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROFCOMISIONESAUTOENUN") == 0 )
         {
            edtavProfcomisionesautoenun2_Visible = 1;
            AssignProp("", false, edtavProfcomisionesautoenun2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfcomisionesautoenun2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
         {
            edtavProfesionalesprimernombre2_Visible = 1;
            AssignProp("", false, edtavProfesionalesprimernombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesionalesprimernombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavProfcomisionesautoenun3_Visible = 0;
         AssignProp("", false, edtavProfcomisionesautoenun3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfcomisionesautoenun3_Visible), 5, 0), true);
         edtavProfesionalesprimernombre3_Visible = 0;
         AssignProp("", false, edtavProfesionalesprimernombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesionalesprimernombre3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFCOMISIONESAUTOENUN") == 0 )
         {
            edtavProfcomisionesautoenun3_Visible = 1;
            AssignProp("", false, edtavProfcomisionesautoenun3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfcomisionesautoenun3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
         {
            edtavProfesionalesprimernombre3_Visible = 1;
            AssignProp("", false, edtavProfesionalesprimernombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesionalesprimernombre3_Visible), 5, 0), true);
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
         AV23DynamicFiltersSelector2 = "PROFCOMISIONESAUTOENUN";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV25ProfComisionesAutoEnun2 = 0;
         AssignAttri("", false, "AV25ProfComisionesAutoEnun2", StringUtil.LTrimStr( (decimal)(AV25ProfComisionesAutoEnun2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         AV28DynamicFiltersSelector3 = "PROFCOMISIONESAUTOENUN";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AV30ProfComisionesAutoEnun3 = 0;
         AssignAttri("", false, "AV30ProfComisionesAutoEnun3", StringUtil.LTrimStr( (decimal)(AV30ProfComisionesAutoEnun3), 4, 0));
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ProfComisionesWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV44TFProfComisionesID = 0;
         AssignAttri("", false, "AV44TFProfComisionesID", StringUtil.LTrimStr( (decimal)(AV44TFProfComisionesID), 18, 0));
         AV45TFProfComisionesID_To = 0;
         AssignAttri("", false, "AV45TFProfComisionesID_To", StringUtil.LTrimStr( (decimal)(AV45TFProfComisionesID_To), 18, 0));
         AV46TFProfesionalesId = "";
         AssignAttri("", false, "AV46TFProfesionalesId", AV46TFProfesionalesId);
         AV47TFProfesionalesId_Sel = "";
         AssignAttri("", false, "AV47TFProfesionalesId_Sel", AV47TFProfesionalesId_Sel);
         AV48TFProfesionalesPrimerNombre = "";
         AssignAttri("", false, "AV48TFProfesionalesPrimerNombre", AV48TFProfesionalesPrimerNombre);
         AV49TFProfesionalesPrimerNombre_Sel = "";
         AssignAttri("", false, "AV49TFProfesionalesPrimerNombre_Sel", AV49TFProfesionalesPrimerNombre_Sel);
         AV50TFProfesionalesSegundoNombre = "";
         AssignAttri("", false, "AV50TFProfesionalesSegundoNombre", AV50TFProfesionalesSegundoNombre);
         AV51TFProfesionalesSegundoNombre_Sel = "";
         AssignAttri("", false, "AV51TFProfesionalesSegundoNombre_Sel", AV51TFProfesionalesSegundoNombre_Sel);
         AV52TFProfesionalesApellidoPrimero = "";
         AssignAttri("", false, "AV52TFProfesionalesApellidoPrimero", AV52TFProfesionalesApellidoPrimero);
         AV53TFProfesionalesApellidoPrimero_Sel = "";
         AssignAttri("", false, "AV53TFProfesionalesApellidoPrimero_Sel", AV53TFProfesionalesApellidoPrimero_Sel);
         AV54TFProfesionalesApellidoSegundo = "";
         AssignAttri("", false, "AV54TFProfesionalesApellidoSegundo", AV54TFProfesionalesApellidoSegundo);
         AV55TFProfesionalesApellidoSegundo_Sel = "";
         AssignAttri("", false, "AV55TFProfesionalesApellidoSegundo_Sel", AV55TFProfesionalesApellidoSegundo_Sel);
         AV56TFProfesionalesTelefono = "";
         AssignAttri("", false, "AV56TFProfesionalesTelefono", AV56TFProfesionalesTelefono);
         AV57TFProfesionalesTelefono_Sel = "";
         AssignAttri("", false, "AV57TFProfesionalesTelefono_Sel", AV57TFProfesionalesTelefono_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "PROFCOMISIONESAUTOENUN";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20ProfComisionesAutoEnun1 = 0;
         AssignAttri("", false, "AV20ProfComisionesAutoEnun1", StringUtil.LTrimStr( (decimal)(AV20ProfComisionesAutoEnun1), 4, 0));
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
         GXEncryptionTmp = "profcomisionesview.aspx"+UrlEncode(StringUtil.LTrimStr(A450ProfComisionesID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("profcomisionesview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profcomisiones.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A450ProfComisionesID,18,0));
         CallWebObject(formatLink("profcomisiones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profcomisiones.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A450ProfComisionesID,18,0));
         CallWebObject(formatLink("profcomisiones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
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
         AV103GXV1 = 1;
         while ( AV103GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV103GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESID") == 0 )
            {
               AV44TFProfComisionesID = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFProfComisionesID", StringUtil.LTrimStr( (decimal)(AV44TFProfComisionesID), 18, 0));
               AV45TFProfComisionesID_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFProfComisionesID_To", StringUtil.LTrimStr( (decimal)(AV45TFProfComisionesID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV46TFProfesionalesId = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFProfesionalesId", AV46TFProfesionalesId);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV47TFProfesionalesId_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFProfesionalesId_Sel", AV47TFProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV48TFProfesionalesPrimerNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFProfesionalesPrimerNombre", AV48TFProfesionalesPrimerNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV49TFProfesionalesPrimerNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFProfesionalesPrimerNombre_Sel", AV49TFProfesionalesPrimerNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV50TFProfesionalesSegundoNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFProfesionalesSegundoNombre", AV50TFProfesionalesSegundoNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV51TFProfesionalesSegundoNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFProfesionalesSegundoNombre_Sel", AV51TFProfesionalesSegundoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV52TFProfesionalesApellidoPrimero = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFProfesionalesApellidoPrimero", AV52TFProfesionalesApellidoPrimero);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV53TFProfesionalesApellidoPrimero_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFProfesionalesApellidoPrimero_Sel", AV53TFProfesionalesApellidoPrimero_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV54TFProfesionalesApellidoSegundo = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFProfesionalesApellidoSegundo", AV54TFProfesionalesApellidoSegundo);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV55TFProfesionalesApellidoSegundo_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFProfesionalesApellidoSegundo_Sel", AV55TFProfesionalesApellidoSegundo_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV56TFProfesionalesTelefono = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFProfesionalesTelefono", AV56TFProfesionalesTelefono);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV57TFProfesionalesTelefono_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV57TFProfesionalesTelefono_Sel", AV57TFProfesionalesTelefono_Sel);
            }
            AV103GXV1 = (int)(AV103GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFProfesionalesId_Sel)),  AV47TFProfesionalesId_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProfesionalesPrimerNombre_Sel)),  AV49TFProfesionalesPrimerNombre_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProfesionalesSegundoNombre_Sel)),  AV51TFProfesionalesSegundoNombre_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProfesionalesApellidoPrimero_Sel)),  AV53TFProfesionalesApellidoPrimero_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProfesionalesApellidoSegundo_Sel)),  AV55TFProfesionalesApellidoSegundo_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV57TFProfesionalesTelefono_Sel)),  AV57TFProfesionalesTelefono_Sel, out  GXt_char9) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFProfesionalesId)),  AV46TFProfesionalesId, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProfesionalesPrimerNombre)),  AV48TFProfesionalesPrimerNombre, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProfesionalesSegundoNombre)),  AV50TFProfesionalesSegundoNombre, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProfesionalesApellidoPrimero)),  AV52TFProfesionalesApellidoPrimero, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProfesionalesApellidoSegundo)),  AV54TFProfesionalesApellidoSegundo, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFProfesionalesTelefono)),  AV56TFProfesionalesTelefono, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV44TFProfComisionesID) ? "" : StringUtil.Str( (decimal)(AV44TFProfComisionesID), 18, 0))+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV45TFProfComisionesID_To) ? "" : StringUtil.Str( (decimal)(AV45TFProfComisionesID_To), 18, 0))+"||||||";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFCOMISIONESAUTOENUN") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20ProfComisionesAutoEnun1 = (short)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ProfComisionesAutoEnun1", StringUtil.LTrimStr( (decimal)(AV20ProfComisionesAutoEnun1), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV21ProfesionalesPrimerNombre1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21ProfesionalesPrimerNombre1", AV21ProfesionalesPrimerNombre1);
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
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROFCOMISIONESAUTOENUN") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25ProfComisionesAutoEnun2 = (short)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV25ProfComisionesAutoEnun2", StringUtil.LTrimStr( (decimal)(AV25ProfComisionesAutoEnun2), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV26ProfesionalesPrimerNombre2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26ProfesionalesPrimerNombre2", AV26ProfesionalesPrimerNombre2);
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
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFCOMISIONESAUTOENUN") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV30ProfComisionesAutoEnun3 = (short)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV30ProfComisionesAutoEnun3", StringUtil.LTrimStr( (decimal)(AV30ProfComisionesAutoEnun3), 4, 0));
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV31ProfesionalesPrimerNombre3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31ProfesionalesPrimerNombre3", AV31ProfesionalesPrimerNombre3);
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
         AV11GridState.FromXml(AV40Session.Get(AV73Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFPROFCOMISIONESID",  context.GetMessage( "Comisiones ID", ""),  !((0==AV44TFProfComisionesID)&&(0==AV45TFProfComisionesID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFProfComisionesID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV45TFProfComisionesID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESID",  context.GetMessage( "Identidad", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFProfesionalesId)),  0,  AV46TFProfesionalesId,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFProfesionalesId_Sel)),  AV47TFProfesionalesId_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESPRIMERNOMBRE",  context.GetMessage( "Primer Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProfesionalesPrimerNombre)),  0,  AV48TFProfesionalesPrimerNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProfesionalesPrimerNombre_Sel)),  AV49TFProfesionalesPrimerNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESSEGUNDONOMBRE",  context.GetMessage( "Segundo Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProfesionalesSegundoNombre)),  0,  AV50TFProfesionalesSegundoNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProfesionalesSegundoNombre_Sel)),  AV51TFProfesionalesSegundoNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESAPELLIDOPRIMERO",  context.GetMessage( "Primero Apellido ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProfesionalesApellidoPrimero)),  0,  AV52TFProfesionalesApellidoPrimero,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProfesionalesApellidoPrimero_Sel)),  AV53TFProfesionalesApellidoPrimero_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESAPELLIDOSEGUNDO",  context.GetMessage( "Segundo Apellido ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProfesionalesApellidoSegundo)),  0,  AV54TFProfesionalesApellidoSegundo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProfesionalesApellidoSegundo_Sel)),  AV55TFProfesionalesApellidoSegundo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESTELEFONO",  context.GetMessage( "Teléfono", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFProfesionalesTelefono)),  0,  AV56TFProfesionalesTelefono,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV57TFProfesionalesTelefono_Sel)),  AV57TFProfesionalesTelefono_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV73Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ! (0==AV20ProfComisionesAutoEnun1) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Auto Enun", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV20ProfComisionesAutoEnun1), 4, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ProfesionalesPrimerNombre1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Primer Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV21ProfesionalesPrimerNombre1;
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
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ! (0==AV25ProfComisionesAutoEnun2) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Auto Enun", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV25ProfComisionesAutoEnun2), 4, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ProfesionalesPrimerNombre2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Primer Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV26ProfesionalesPrimerNombre2;
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
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ! (0==AV30ProfComisionesAutoEnun3) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Auto Enun", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV30ProfComisionesAutoEnun3), 4, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ProfesionalesPrimerNombre3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Primer Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV31ProfesionalesPrimerNombre3;
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
         AV9TrnContext.gxTpr_Callerobject = AV73Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "ProfComisiones";
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
         new profcomisioneswwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
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
         Innewwindow1_Target = formatLink("profcomisioneswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_99_3O2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "", true, 0, "HLP_ProfComisionesWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profcomisionesautoenun3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProfcomisionesautoenun3_Internalname, context.GetMessage( "Prof Comisiones Auto Enun3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProfcomisionesautoenun3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30ProfComisionesAutoEnun3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavProfcomisionesautoenun3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30ProfComisionesAutoEnun3), "ZZZ9") : context.localUtil.Format( (decimal)(AV30ProfComisionesAutoEnun3), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProfcomisionesautoenun3_Jsonclick, 0, "Attribute", "", "", "", "", edtavProfcomisionesautoenun3_Visible, edtavProfcomisionesautoenun3_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profesionalesprimernombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProfesionalesprimernombre3_Internalname, context.GetMessage( "Profesionales Primer Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProfesionalesprimernombre3_Internalname, StringUtil.RTrim( AV31ProfesionalesPrimerNombre3), StringUtil.RTrim( context.localUtil.Format( AV31ProfesionalesPrimerNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProfesionalesprimernombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavProfesionalesprimernombre3_Visible, edtavProfesionalesprimernombre3_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfComisionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_99_3O2e( true) ;
         }
         else
         {
            wb_table4_99_3O2e( false) ;
         }
      }

      protected void wb_table3_74_3O2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, 0, "HLP_ProfComisionesWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profcomisionesautoenun2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProfcomisionesautoenun2_Internalname, context.GetMessage( "Prof Comisiones Auto Enun2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProfcomisionesautoenun2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ProfComisionesAutoEnun2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavProfcomisionesautoenun2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25ProfComisionesAutoEnun2), "ZZZ9") : context.localUtil.Format( (decimal)(AV25ProfComisionesAutoEnun2), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProfcomisionesautoenun2_Jsonclick, 0, "Attribute", "", "", "", "", edtavProfcomisionesautoenun2_Visible, edtavProfcomisionesautoenun2_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profesionalesprimernombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProfesionalesprimernombre2_Internalname, context.GetMessage( "Profesionales Primer Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProfesionalesprimernombre2_Internalname, StringUtil.RTrim( AV26ProfesionalesPrimerNombre2), StringUtil.RTrim( context.localUtil.Format( AV26ProfesionalesPrimerNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProfesionalesprimernombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavProfesionalesprimernombre2_Visible, edtavProfesionalesprimernombre2_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfComisionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfComisionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_74_3O2e( true) ;
         }
         else
         {
            wb_table3_74_3O2e( false) ;
         }
      }

      protected void wb_table2_49_3O2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_ProfComisionesWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profcomisionesautoenun1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProfcomisionesautoenun1_Internalname, context.GetMessage( "Prof Comisiones Auto Enun1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProfcomisionesautoenun1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ProfComisionesAutoEnun1), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavProfcomisionesautoenun1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ProfComisionesAutoEnun1), "ZZZ9") : context.localUtil.Format( (decimal)(AV20ProfComisionesAutoEnun1), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProfcomisionesautoenun1_Jsonclick, 0, "Attribute", "", "", "", "", edtavProfcomisionesautoenun1_Visible, edtavProfcomisionesautoenun1_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profesionalesprimernombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProfesionalesprimernombre1_Internalname, context.GetMessage( "Profesionales Primer Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProfesionalesprimernombre1_Internalname, StringUtil.RTrim( AV21ProfesionalesPrimerNombre1), StringUtil.RTrim( context.localUtil.Format( AV21ProfesionalesPrimerNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProfesionalesprimernombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavProfesionalesprimernombre1_Visible, edtavProfesionalesprimernombre1_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfComisionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfComisionesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_3O2e( true) ;
         }
         else
         {
            wb_table2_49_3O2e( false) ;
         }
      }

      protected void wb_table1_25_3O2( bool wbgen )
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
            wb_table5_30_3O2( true) ;
         }
         else
         {
            wb_table5_30_3O2( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_3O2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_3O2e( true) ;
         }
         else
         {
            wb_table1_25_3O2e( false) ;
         }
      }

      protected void wb_table5_30_3O2( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ProfComisionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_3O2e( true) ;
         }
         else
         {
            wb_table5_30_3O2e( false) ;
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
         PA3O2( ) ;
         WS3O2( ) ;
         WE3O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021191758", true, true, false);
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
         context.AddJavascriptSource("profcomisionesww.js", "?202673021191759", false, true, false);
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

      protected void SubsflControlProps_1202( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_120_idx;
         edtProfComisionesID_Internalname = "PROFCOMISIONESID_"+sGXsfl_120_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_120_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_120_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_120_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_120_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_120_idx;
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO_"+sGXsfl_120_idx;
         edtProfComisionesAutoEnun_Internalname = "PROFCOMISIONESAUTOENUN_"+sGXsfl_120_idx;
      }

      protected void SubsflControlProps_fel_1202( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_120_fel_idx;
         edtProfComisionesID_Internalname = "PROFCOMISIONESID_"+sGXsfl_120_fel_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_120_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_120_fel_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_120_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_120_fel_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_120_fel_idx;
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO_"+sGXsfl_120_fel_idx;
         edtProfComisionesAutoEnun_Internalname = "PROFCOMISIONESAUTOENUN_"+sGXsfl_120_fel_idx;
      }

      protected void sendrow_1202( )
      {
         sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
         SubsflControlProps_1202( ) ;
         WB3O0( ) ;
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
                  AV63GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV63GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV63GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV63GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_120_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV63GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_120_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtProfComisionesID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A450ProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A450ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProfComisionesID_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProfesionalesId_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesPrimerNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProfesionalesPrimerNombre_Link,(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProfesionalesPrimerNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesSegundoNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesSegundoNombre_Internalname,StringUtil.RTrim( A191ProfesionalesSegundoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesSegundoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProfesionalesSegundoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesApellidoPrimero_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProfesionalesApellidoPrimero_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesApellidoSegundo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoSegundo_Internalname,StringUtil.RTrim( A192ProfesionalesApellidoSegundo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoSegundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProfesionalesApellidoSegundo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesTelefono_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesTelefono_Internalname,StringUtil.RTrim( A170ProfesionalesTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProfesionalesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProfesionalesTelefono_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesAutoEnun_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A451ProfComisionesAutoEnun), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A451ProfComisionesAutoEnun), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesAutoEnun_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes3O2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("PROFCOMISIONESAUTOENUN", context.GetMessage( "Auto Enun", ""), 0);
         cmbavDynamicfiltersselector1.addItem("PROFESIONALESPRIMERNOMBRE", context.GetMessage( "Primer Nombre", ""), 0);
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
         cmbavDynamicfiltersselector2.addItem("PROFCOMISIONESAUTOENUN", context.GetMessage( "Auto Enun", ""), 0);
         cmbavDynamicfiltersselector2.addItem("PROFESIONALESPRIMERNOMBRE", context.GetMessage( "Primer Nombre", ""), 0);
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
         cmbavDynamicfiltersselector3.addItem("PROFCOMISIONESAUTOENUN", context.GetMessage( "Auto Enun", ""), 0);
         cmbavDynamicfiltersselector3.addItem("PROFESIONALESPRIMERNOMBRE", context.GetMessage( "Primer Nombre", ""), 0);
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
            AV63GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV63GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV63GridActions), 4, 0));
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfComisionesID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisiones ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesPrimerNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Primer Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesSegundoNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Segundo Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesApellidoPrimero_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Primero Apellido ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesApellidoSegundo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Segundo Apellido ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesTelefono_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV63GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A450ProfComisionesID), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtProfesionalesPrimerNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A191ProfesionalesSegundoNombre)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesSegundoNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A167ProfesionalesApellidoPrimero)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A192ProfesionalesApellidoSegundo)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoSegundo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A170ProfesionalesTelefono)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesTelefono_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A451ProfComisionesAutoEnun), 4, 0, ".", ""))));
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
         edtavProfcomisionesautoenun1_Internalname = "vPROFCOMISIONESAUTOENUN1";
         cellFilter_profcomisionesautoenun1_cell_Internalname = "FILTER_PROFCOMISIONESAUTOENUN1_CELL";
         edtavProfesionalesprimernombre1_Internalname = "vPROFESIONALESPRIMERNOMBRE1";
         cellFilter_profesionalesprimernombre1_cell_Internalname = "FILTER_PROFESIONALESPRIMERNOMBRE1_CELL";
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
         edtavProfcomisionesautoenun2_Internalname = "vPROFCOMISIONESAUTOENUN2";
         cellFilter_profcomisionesautoenun2_cell_Internalname = "FILTER_PROFCOMISIONESAUTOENUN2_CELL";
         edtavProfesionalesprimernombre2_Internalname = "vPROFESIONALESPRIMERNOMBRE2";
         cellFilter_profesionalesprimernombre2_cell_Internalname = "FILTER_PROFESIONALESPRIMERNOMBRE2_CELL";
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
         edtavProfcomisionesautoenun3_Internalname = "vPROFCOMISIONESAUTOENUN3";
         cellFilter_profcomisionesautoenun3_cell_Internalname = "FILTER_PROFCOMISIONESAUTOENUN3_CELL";
         edtavProfesionalesprimernombre3_Internalname = "vPROFESIONALESPRIMERNOMBRE3";
         cellFilter_profesionalesprimernombre3_cell_Internalname = "FILTER_PROFESIONALESPRIMERNOMBRE3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtProfComisionesID_Internalname = "PROFCOMISIONESID";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO";
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO";
         edtProfComisionesAutoEnun_Internalname = "PROFCOMISIONESAUTOENUN";
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
         edtProfComisionesAutoEnun_Jsonclick = "";
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Link = "";
         edtProfesionalesId_Jsonclick = "";
         edtProfComisionesID_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavProfesionalesprimernombre1_Jsonclick = "";
         edtavProfesionalesprimernombre1_Enabled = 1;
         edtavProfcomisionesautoenun1_Jsonclick = "";
         edtavProfcomisionesautoenun1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavProfesionalesprimernombre2_Jsonclick = "";
         edtavProfesionalesprimernombre2_Enabled = 1;
         edtavProfcomisionesautoenun2_Jsonclick = "";
         edtavProfcomisionesautoenun2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavProfesionalesprimernombre3_Jsonclick = "";
         edtavProfesionalesprimernombre3_Enabled = 1;
         edtavProfcomisionesautoenun3_Jsonclick = "";
         edtavProfcomisionesautoenun3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavProfesionalesprimernombre3_Visible = 1;
         edtavProfcomisionesautoenun3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavProfesionalesprimernombre2_Visible = 1;
         edtavProfcomisionesautoenun2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavProfesionalesprimernombre1_Visible = 1;
         edtavProfcomisionesautoenun1_Visible = 1;
         edtProfesionalesTelefono_Visible = -1;
         edtProfesionalesApellidoSegundo_Visible = -1;
         edtProfesionalesApellidoPrimero_Visible = -1;
         edtProfesionalesSegundoNombre_Visible = -1;
         edtProfesionalesPrimerNombre_Visible = -1;
         edtProfesionalesId_Visible = -1;
         edtProfComisionesID_Visible = -1;
         edtProfComisionesAutoEnun_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtProfComisionesID_Enabled = 0;
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
         Ddo_grid_Format = "18.0||||||";
         Ddo_grid_Datalistproc = "ProfComisionesWWGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T|T|T|T";
         Ddo_grid_Filterisrange = "T||||||";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7|8";
         Ddo_grid_Columnids = "1:ProfComisionesID|2:ProfesionalesId|3:ProfesionalesPrimerNombre|4:ProfesionalesSegundoNombre|5:ProfesionalesApellidoPrimero|6:ProfesionalesApellidoSegundo|7:ProfesionalesTelefono";
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
         Form.Caption = context.GetMessage( "Comisiones para Profesionales", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfComisionesID_Visible',ctrl:'PROFCOMISIONESID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'AV60GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E123O2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfComisionesID_Visible',ctrl:'PROFCOMISIONESID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'AV60GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E133O2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E163O2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E293O2',iparms:[{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV63GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtProfesionalesPrimerNombre_Link',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E173O2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtProfComisionesID_Visible',ctrl:'PROFCOMISIONESID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'AV60GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E223O2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfComisionesID_Visible',ctrl:'PROFCOMISIONESID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'AV60GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E183O2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'edtavProfcomisionesautoenun2_Visible',ctrl:'vPROFCOMISIONESAUTOENUN2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'},{av:'edtavProfcomisionesautoenun3_Visible',ctrl:'vPROFCOMISIONESAUTOENUN3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'},{av:'edtavProfcomisionesautoenun1_Visible',ctrl:'vPROFCOMISIONESAUTOENUN1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfComisionesID_Visible',ctrl:'PROFCOMISIONESID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'AV60GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E233O2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'edtavProfcomisionesautoenun1_Visible',ctrl:'vPROFCOMISIONESAUTOENUN1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E243O2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfComisionesID_Visible',ctrl:'PROFCOMISIONESID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'AV60GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E193O2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'edtavProfcomisionesautoenun2_Visible',ctrl:'vPROFCOMISIONESAUTOENUN2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'},{av:'edtavProfcomisionesautoenun3_Visible',ctrl:'vPROFCOMISIONESAUTOENUN3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'},{av:'edtavProfcomisionesautoenun1_Visible',ctrl:'vPROFCOMISIONESAUTOENUN1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfComisionesID_Visible',ctrl:'PROFCOMISIONESID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'AV60GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E253O2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'edtavProfcomisionesautoenun2_Visible',ctrl:'vPROFCOMISIONESAUTOENUN2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E203O2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'edtavProfcomisionesautoenun2_Visible',ctrl:'vPROFCOMISIONESAUTOENUN2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'},{av:'edtavProfcomisionesautoenun3_Visible',ctrl:'vPROFCOMISIONESAUTOENUN3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'},{av:'edtavProfcomisionesautoenun1_Visible',ctrl:'vPROFCOMISIONESAUTOENUN1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfComisionesID_Visible',ctrl:'PROFCOMISIONESID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'AV60GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E263O2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtavProfcomisionesautoenun3_Visible',ctrl:'vPROFCOMISIONESAUTOENUN3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E113O2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'edtavProfcomisionesautoenun1_Visible',ctrl:'vPROFCOMISIONESAUTOENUN1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'},{av:'edtavProfcomisionesautoenun2_Visible',ctrl:'vPROFCOMISIONESAUTOENUN2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'},{av:'edtavProfcomisionesautoenun3_Visible',ctrl:'vPROFCOMISIONESAUTOENUN3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfComisionesID_Visible',ctrl:'PROFCOMISIONESID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'AV60GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E303O2',iparms:[{av:'cmbavGridactions'},{av:'AV63GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A450ProfComisionesID',fld:'PROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV63GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E213O2',iparms:[{av:'A450ProfComisionesID',fld:'PROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E143O2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20ProfComisionesAutoEnun1',fld:'vPROFCOMISIONESAUTOENUN1',pic:'ZZZ9',type:'int'},{av:'AV21ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV25ProfComisionesAutoEnun2',fld:'vPROFCOMISIONESAUTOENUN2',pic:'ZZZ9',type:'int'},{av:'AV26ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV30ProfComisionesAutoEnun3',fld:'vPROFCOMISIONESAUTOENUN3',pic:'ZZZ9',type:'int'},{av:'AV31ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV73Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV44TFProfComisionesID',fld:'vTFPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFProfComisionesID_To',fld:'vTFPROFCOMISIONESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV46TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV47TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV49TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV51TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV53TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV55TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV56TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV57TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV65IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV66IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV70IsAuthorized_ProfesionalesPrimerNombre',fld:'vISAUTHORIZED_PROFESIONALESPRIMERNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavProfcomisionesautoenun1_Visible',ctrl:'vPROFCOMISIONESAUTOENUN1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'},{av:'edtavProfcomisionesautoenun2_Visible',ctrl:'vPROFCOMISIONESAUTOENUN2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'},{av:'edtavProfcomisionesautoenun3_Visible',ctrl:'vPROFCOMISIONESAUTOENUN3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'},{av:'edtProfComisionesID_Visible',ctrl:'PROFCOMISIONESID',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'AV60GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV62GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E153O2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Profcomisionesautoenun',iparms:[]");
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
         AV21ProfesionalesPrimerNombre1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV26ProfesionalesPrimerNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV31ProfesionalesPrimerNombre3 = "";
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV73Pgmname = "";
         AV46TFProfesionalesId = "";
         AV47TFProfesionalesId_Sel = "";
         AV48TFProfesionalesPrimerNombre = "";
         AV49TFProfesionalesPrimerNombre_Sel = "";
         AV50TFProfesionalesSegundoNombre = "";
         AV51TFProfesionalesSegundoNombre_Sel = "";
         AV52TFProfesionalesApellidoPrimero = "";
         AV53TFProfesionalesApellidoPrimero_Sel = "";
         AV54TFProfesionalesApellidoSegundo = "";
         AV55TFProfesionalesApellidoSegundo_Sel = "";
         AV56TFProfesionalesTelefono = "";
         AV57TFProfesionalesTelefono_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV62GridAppliedFilters = "";
         AV67AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV58DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         lV74Profcomisioneswwds_1_filterfulltext = "";
         lV78Profcomisioneswwds_5_profesionalesprimernombre1 = "";
         lV83Profcomisioneswwds_10_profesionalesprimernombre2 = "";
         lV88Profcomisioneswwds_15_profesionalesprimernombre3 = "";
         lV91Profcomisioneswwds_18_tfprofesionalesid = "";
         lV93Profcomisioneswwds_20_tfprofesionalesprimernombre = "";
         lV95Profcomisioneswwds_22_tfprofesionalessegundonombre = "";
         lV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero = "";
         lV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo = "";
         lV101Profcomisioneswwds_28_tfprofesionalestelefono = "";
         AV74Profcomisioneswwds_1_filterfulltext = "";
         AV75Profcomisioneswwds_2_dynamicfiltersselector1 = "";
         AV78Profcomisioneswwds_5_profesionalesprimernombre1 = "";
         AV80Profcomisioneswwds_7_dynamicfiltersselector2 = "";
         AV83Profcomisioneswwds_10_profesionalesprimernombre2 = "";
         AV85Profcomisioneswwds_12_dynamicfiltersselector3 = "";
         AV88Profcomisioneswwds_15_profesionalesprimernombre3 = "";
         AV92Profcomisioneswwds_19_tfprofesionalesid_sel = "";
         AV91Profcomisioneswwds_18_tfprofesionalesid = "";
         AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = "";
         AV93Profcomisioneswwds_20_tfprofesionalesprimernombre = "";
         AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = "";
         AV95Profcomisioneswwds_22_tfprofesionalessegundonombre = "";
         AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = "";
         AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero = "";
         AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = "";
         AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo = "";
         AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel = "";
         AV101Profcomisioneswwds_28_tfprofesionalestelefono = "";
         H003O2_A451ProfComisionesAutoEnun = new short[1] ;
         H003O2_A170ProfesionalesTelefono = new string[] {""} ;
         H003O2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H003O2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H003O2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H003O2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H003O2_A120ProfesionalesId = new string[] {""} ;
         H003O2_A450ProfComisionesID = new long[1] ;
         H003O3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV68AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         GXt_char9 = "";
         GXt_char8 = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profcomisionesww__default(),
            new Object[][] {
                new Object[] {
               H003O2_A451ProfComisionesAutoEnun, H003O2_A170ProfesionalesTelefono, H003O2_A192ProfesionalesApellidoSegundo, H003O2_A167ProfesionalesApellidoPrimero, H003O2_A191ProfesionalesSegundoNombre, H003O2_A166ProfesionalesPrimerNombre, H003O2_A120ProfesionalesId, H003O2_A450ProfComisionesID
               }
               , new Object[] {
               H003O3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV73Pgmname = "ProfComisionesWW";
         /* GeneXus formulas. */
         AV73Pgmname = "ProfComisionesWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV20ProfComisionesAutoEnun1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV25ProfComisionesAutoEnun2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV30ProfComisionesAutoEnun3 ;
      private short AV43ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV63GridActions ;
      private short A451ProfComisionesAutoEnun ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV76Profcomisioneswwds_3_dynamicfiltersoperator1 ;
      private short AV77Profcomisioneswwds_4_profcomisionesautoenun1 ;
      private short AV81Profcomisioneswwds_8_dynamicfiltersoperator2 ;
      private short AV82Profcomisioneswwds_9_profcomisionesautoenun2 ;
      private short AV86Profcomisioneswwds_13_dynamicfiltersoperator3 ;
      private short AV87Profcomisioneswwds_14_profcomisionesautoenun3 ;
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
      private int edtProfComisionesID_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int edtProfComisionesAutoEnun_Enabled ;
      private int edtProfComisionesID_Visible ;
      private int edtProfesionalesId_Visible ;
      private int edtProfesionalesPrimerNombre_Visible ;
      private int edtProfesionalesSegundoNombre_Visible ;
      private int edtProfesionalesApellidoPrimero_Visible ;
      private int edtProfesionalesApellidoSegundo_Visible ;
      private int edtProfesionalesTelefono_Visible ;
      private int AV59PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavProfcomisionesautoenun1_Visible ;
      private int edtavProfesionalesprimernombre1_Visible ;
      private int edtavProfcomisionesautoenun2_Visible ;
      private int edtavProfesionalesprimernombre2_Visible ;
      private int edtavProfcomisionesautoenun3_Visible ;
      private int edtavProfesionalesprimernombre3_Visible ;
      private int AV103GXV1 ;
      private int edtavProfcomisionesautoenun3_Enabled ;
      private int edtavProfesionalesprimernombre3_Enabled ;
      private int edtavProfcomisionesautoenun2_Enabled ;
      private int edtavProfesionalesprimernombre2_Enabled ;
      private int edtavProfcomisionesautoenun1_Enabled ;
      private int edtavProfesionalesprimernombre1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV44TFProfComisionesID ;
      private long AV45TFProfComisionesID_To ;
      private long AV60GridCurrentPage ;
      private long AV61GridPageCount ;
      private long A450ProfComisionesID ;
      private long GRID_nCurrentRecord ;
      private long AV89Profcomisioneswwds_16_tfprofcomisionesid ;
      private long AV90Profcomisioneswwds_17_tfprofcomisionesid_to ;
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
      private string AV21ProfesionalesPrimerNombre1 ;
      private string AV26ProfesionalesPrimerNombre2 ;
      private string AV31ProfesionalesPrimerNombre3 ;
      private string AV73Pgmname ;
      private string AV46TFProfesionalesId ;
      private string AV47TFProfesionalesId_Sel ;
      private string AV48TFProfesionalesPrimerNombre ;
      private string AV49TFProfesionalesPrimerNombre_Sel ;
      private string AV50TFProfesionalesSegundoNombre ;
      private string AV51TFProfesionalesSegundoNombre_Sel ;
      private string AV52TFProfesionalesApellidoPrimero ;
      private string AV53TFProfesionalesApellidoPrimero_Sel ;
      private string AV54TFProfesionalesApellidoSegundo ;
      private string AV55TFProfesionalesApellidoSegundo_Sel ;
      private string AV56TFProfesionalesTelefono ;
      private string AV57TFProfesionalesTelefono_Sel ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtProfComisionesID_Internalname ;
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Internalname ;
      private string A166ProfesionalesPrimerNombre ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string A191ProfesionalesSegundoNombre ;
      private string edtProfesionalesSegundoNombre_Internalname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string A192ProfesionalesApellidoSegundo ;
      private string edtProfesionalesApellidoSegundo_Internalname ;
      private string A170ProfesionalesTelefono ;
      private string edtProfesionalesTelefono_Internalname ;
      private string edtProfComisionesAutoEnun_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string lV78Profcomisioneswwds_5_profesionalesprimernombre1 ;
      private string lV83Profcomisioneswwds_10_profesionalesprimernombre2 ;
      private string lV88Profcomisioneswwds_15_profesionalesprimernombre3 ;
      private string lV91Profcomisioneswwds_18_tfprofesionalesid ;
      private string lV93Profcomisioneswwds_20_tfprofesionalesprimernombre ;
      private string lV95Profcomisioneswwds_22_tfprofesionalessegundonombre ;
      private string lV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero ;
      private string lV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo ;
      private string lV101Profcomisioneswwds_28_tfprofesionalestelefono ;
      private string AV78Profcomisioneswwds_5_profesionalesprimernombre1 ;
      private string AV83Profcomisioneswwds_10_profesionalesprimernombre2 ;
      private string AV88Profcomisioneswwds_15_profesionalesprimernombre3 ;
      private string AV92Profcomisioneswwds_19_tfprofesionalesid_sel ;
      private string AV91Profcomisioneswwds_18_tfprofesionalesid ;
      private string AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ;
      private string AV93Profcomisioneswwds_20_tfprofesionalesprimernombre ;
      private string AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ;
      private string AV95Profcomisioneswwds_22_tfprofesionalessegundonombre ;
      private string AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ;
      private string AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero ;
      private string AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ;
      private string AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo ;
      private string AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel ;
      private string AV101Profcomisioneswwds_28_tfprofesionalestelefono ;
      private string edtavProfcomisionesautoenun1_Internalname ;
      private string edtavProfesionalesprimernombre1_Internalname ;
      private string edtavProfcomisionesautoenun2_Internalname ;
      private string edtavProfesionalesprimernombre2_Internalname ;
      private string edtavProfcomisionesautoenun3_Internalname ;
      private string edtavProfesionalesprimernombre3_Internalname ;
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
      private string edtProfesionalesPrimerNombre_Link ;
      private string GXEncryptionTmp ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_profcomisionesautoenun3_cell_Internalname ;
      private string edtavProfcomisionesautoenun3_Jsonclick ;
      private string cellFilter_profesionalesprimernombre3_cell_Internalname ;
      private string edtavProfesionalesprimernombre3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_profcomisionesautoenun2_cell_Internalname ;
      private string edtavProfcomisionesautoenun2_Jsonclick ;
      private string cellFilter_profesionalesprimernombre2_cell_Internalname ;
      private string edtavProfesionalesprimernombre2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_profcomisionesautoenun1_cell_Internalname ;
      private string edtavProfcomisionesautoenun1_Jsonclick ;
      private string cellFilter_profesionalesprimernombre1_cell_Internalname ;
      private string edtavProfesionalesprimernombre1_Jsonclick ;
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
      private string edtProfComisionesID_Jsonclick ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string gxphoneLink ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string edtProfComisionesAutoEnun_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV33DynamicFiltersIgnoreFirst ;
      private bool AV32DynamicFiltersRemoving ;
      private bool AV65IsAuthorized_Update ;
      private bool AV66IsAuthorized_Delete ;
      private bool AV70IsAuthorized_ProfesionalesPrimerNombre ;
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
      private bool gxdyncontrolsrefreshing ;
      private bool AV79Profcomisioneswwds_6_dynamicfiltersenabled2 ;
      private bool AV84Profcomisioneswwds_11_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV69TempBoolean ;
      private bool GXt_boolean1 ;
      private string AV36ColumnsSelectorXML ;
      private string AV42ManageFiltersXml ;
      private string AV37UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV62GridAppliedFilters ;
      private string lV74Profcomisioneswwds_1_filterfulltext ;
      private string AV74Profcomisioneswwds_1_filterfulltext ;
      private string AV75Profcomisioneswwds_2_dynamicfiltersselector1 ;
      private string AV80Profcomisioneswwds_7_dynamicfiltersselector2 ;
      private string AV85Profcomisioneswwds_12_dynamicfiltersselector3 ;
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
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV67AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV58DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private short[] H003O2_A451ProfComisionesAutoEnun ;
      private string[] H003O2_A170ProfesionalesTelefono ;
      private string[] H003O2_A192ProfesionalesApellidoSegundo ;
      private string[] H003O2_A167ProfesionalesApellidoPrimero ;
      private string[] H003O2_A191ProfesionalesSegundoNombre ;
      private string[] H003O2_A166ProfesionalesPrimerNombre ;
      private string[] H003O2_A120ProfesionalesId ;
      private long[] H003O2_A450ProfComisionesID ;
      private long[] H003O3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV68AGExportDataItem ;
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

   public class profcomisionesww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003O2( IGxContext context ,
                                             string AV74Profcomisioneswwds_1_filterfulltext ,
                                             string AV75Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV76Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                             short AV77Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                             string AV78Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                             bool AV79Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                             string AV80Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                             short AV81Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                             short AV82Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                             string AV83Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                             bool AV84Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                             string AV85Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                             short AV86Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                             short AV87Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                             string AV88Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                             long AV89Profcomisioneswwds_16_tfprofcomisionesid ,
                                             long AV90Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                             string AV92Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                             string AV91Profcomisioneswwds_18_tfprofesionalesid ,
                                             string AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                             string AV93Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                             string AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                             string AV95Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                             string AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                             string AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                             string AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                             string AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                             string AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                             string AV101Profcomisioneswwds_28_tfprofesionalestelefono ,
                                             long A450ProfComisionesID ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             short A451ProfComisionesAutoEnun ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[39];
         Object[] GXv_Object11 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[ProfComisionesAutoEnun], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfComisionesID]";
         sFromString = " FROM ([ProfComisiones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProfComisionesID] AS decimal(18,0))) like '%' + @lV74Profcomisioneswwds_1_filterfulltext) or ( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesTelefono]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)))");
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
         }
         if ( ( StringUtil.StrCmp(AV75Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV77Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV77Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV77Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV77Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV77Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV77Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV78Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV78Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( AV79Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV81Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV82Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV82Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( AV79Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV81Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV82Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV82Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( AV79Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV81Profcomisioneswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV82Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV82Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV79Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV81Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV83Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( AV79Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV81Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV83Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( AV84Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV86Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV87Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV87Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( AV84Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV86Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV87Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV87Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( AV84Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV86Profcomisioneswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV87Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV87Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( AV84Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV86Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV88Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( AV84Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV86Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV88Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ! (0==AV89Profcomisioneswwds_16_tfprofcomisionesid) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] >= @AV89Profcomisioneswwds_16_tfprofcomisionesid)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( ! (0==AV90Profcomisioneswwds_17_tfprofcomisionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] <= @AV90Profcomisioneswwds_17_tfprofcomisionesid_to)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_19_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profcomisioneswwds_18_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV91Profcomisioneswwds_18_tfprofesionalesid))");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_19_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV92Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV92Profcomisioneswwds_19_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( StringUtil.StrCmp(AV92Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profcomisioneswwds_20_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV93Profcomisioneswwds_20_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profcomisioneswwds_22_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV95Profcomisioneswwds_22_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profcomisioneswwds_28_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV101Profcomisioneswwds_28_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int10[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int10[35] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( AV14OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[ProfComisionesAutoEnun]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProfComisionesID]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProfComisionesID] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesId]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesId] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[ProfesionalesSegundoNombre]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[ProfesionalesTelefono]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[ProfesionalesTelefono] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[ProfComisionesID]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_H003O3( IGxContext context ,
                                             string AV74Profcomisioneswwds_1_filterfulltext ,
                                             string AV75Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV76Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                             short AV77Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                             string AV78Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                             bool AV79Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                             string AV80Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                             short AV81Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                             short AV82Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                             string AV83Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                             bool AV84Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                             string AV85Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                             short AV86Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                             short AV87Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                             string AV88Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                             long AV89Profcomisioneswwds_16_tfprofcomisionesid ,
                                             long AV90Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                             string AV92Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                             string AV91Profcomisioneswwds_18_tfprofesionalesid ,
                                             string AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                             string AV93Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                             string AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                             string AV95Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                             string AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                             string AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                             string AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                             string AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                             string AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                             string AV101Profcomisioneswwds_28_tfprofesionalestelefono ,
                                             long A450ProfComisionesID ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             short A451ProfComisionesAutoEnun ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[36];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([ProfComisiones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Profcomisioneswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProfComisionesID] AS decimal(18,0))) like '%' + @lV74Profcomisioneswwds_1_filterfulltext) or ( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesTelefono]) like '%' + UPPER(@lV74Profcomisioneswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int12[0] = 1;
            GXv_int12[1] = 1;
            GXv_int12[2] = 1;
            GXv_int12[3] = 1;
            GXv_int12[4] = 1;
            GXv_int12[5] = 1;
            GXv_int12[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV77Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV77Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV77Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV77Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV77Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV77Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV78Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV78Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( AV79Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV81Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV82Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV82Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( AV79Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV81Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV82Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV82Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( AV79Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV81Profcomisioneswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV82Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV82Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( AV79Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV81Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV83Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( AV79Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV81Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV83Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( AV84Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV86Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV87Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV87Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( AV84Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV86Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV87Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV87Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( AV84Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV86Profcomisioneswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV87Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV87Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( AV84Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV86Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV88Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( AV84Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV86Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV88Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( ! (0==AV89Profcomisioneswwds_16_tfprofcomisionesid) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] >= @AV89Profcomisioneswwds_16_tfprofcomisionesid)");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( ! (0==AV90Profcomisioneswwds_17_tfprofcomisionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] <= @AV90Profcomisioneswwds_17_tfprofcomisionesid_to)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_19_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profcomisioneswwds_18_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV91Profcomisioneswwds_18_tfprofesionalesid))");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_19_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV92Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV92Profcomisioneswwds_19_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( StringUtil.StrCmp(AV92Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profcomisioneswwds_20_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV93Profcomisioneswwds_20_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profcomisioneswwds_22_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV95Profcomisioneswwds_22_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int12[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int12[33] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profcomisioneswwds_28_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV101Profcomisioneswwds_28_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int12[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int12[35] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         scmdbuf += sWhereString;
         if ( AV14OrderedBy == 1 )
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
         else if ( true )
         {
            scmdbuf += "";
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
                     return conditional_H003O2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (short)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] );
               case 1 :
                     return conditional_H003O3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (short)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] );
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
          Object[] prmH003O2;
          prmH003O2 = new Object[] {
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV77Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@lV78Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV78Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV82Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV82Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV82Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@lV83Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV83Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV87Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV87Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV87Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@lV88Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV88Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@AV89Profcomisioneswwds_16_tfprofcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV90Profcomisioneswwds_17_tfprofcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV91Profcomisioneswwds_18_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV92Profcomisioneswwds_19_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV93Profcomisioneswwds_20_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV95Profcomisioneswwds_22_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profcomisioneswwds_28_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003O3;
          prmH003O3 = new Object[] {
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV74Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV77Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@lV78Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV78Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV82Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV82Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV82Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@lV83Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV83Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV87Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV87Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV87Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@lV88Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV88Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@AV89Profcomisioneswwds_16_tfprofcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV90Profcomisioneswwds_17_tfprofcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV91Profcomisioneswwds_18_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV92Profcomisioneswwds_19_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV93Profcomisioneswwds_20_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV94Profcomisioneswwds_21_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV95Profcomisioneswwds_22_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV96Profcomisioneswwds_23_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV97Profcomisioneswwds_24_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV98Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profcomisioneswwds_26_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV100Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profcomisioneswwds_28_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV102Profcomisioneswwds_29_tfprofesionalestelefono_sel",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003O2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003O3,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
