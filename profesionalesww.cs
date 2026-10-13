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
   public class profesionalesww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public profesionalesww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionalesww( IGxContext context )
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
         chkavProfesionalesesrut1 = new GXCheckbox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         chkavProfesionalesesrut2 = new GXCheckbox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         chkavProfesionalesesrut3 = new GXCheckbox();
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
         AV17FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV78ProfesionalesEsRUT1 = StringUtil.StrToBool( GetPar( "ProfesionalesEsRUT1"));
         AV79BancoNombre1 = GetPar( "BancoNombre1");
         AV20ProfesionalesPrimerNombre1 = GetPar( "ProfesionalesPrimerNombre1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV80ProfesionalesEsRUT2 = StringUtil.StrToBool( GetPar( "ProfesionalesEsRUT2"));
         AV81BancoNombre2 = GetPar( "BancoNombre2");
         AV24ProfesionalesPrimerNombre2 = GetPar( "ProfesionalesPrimerNombre2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV82ProfesionalesEsRUT3 = StringUtil.StrToBool( GetPar( "ProfesionalesEsRUT3"));
         AV83BancoNombre3 = GetPar( "BancoNombre3");
         AV28ProfesionalesPrimerNombre3 = GetPar( "ProfesionalesPrimerNombre3");
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV35ColumnsSelector);
         AV84Pgmname = GetPar( "Pgmname");
         AV41TFProfesionalesId = GetPar( "TFProfesionalesId");
         AV42TFProfesionalesId_Sel = GetPar( "TFProfesionalesId_Sel");
         AV43TFProfesionalesPrimerNombre = GetPar( "TFProfesionalesPrimerNombre");
         AV44TFProfesionalesPrimerNombre_Sel = GetPar( "TFProfesionalesPrimerNombre_Sel");
         AV45TFProfesionalesSegundoNombre = GetPar( "TFProfesionalesSegundoNombre");
         AV46TFProfesionalesSegundoNombre_Sel = GetPar( "TFProfesionalesSegundoNombre_Sel");
         AV47TFProfesionalesApellidoPrimero = GetPar( "TFProfesionalesApellidoPrimero");
         AV48TFProfesionalesApellidoPrimero_Sel = GetPar( "TFProfesionalesApellidoPrimero_Sel");
         AV49TFProfesionalesApellidoSegundo = GetPar( "TFProfesionalesApellidoSegundo");
         AV50TFProfesionalesApellidoSegundo_Sel = GetPar( "TFProfesionalesApellidoSegundo_Sel");
         AV51TFProfesionalesTelefono = GetPar( "TFProfesionalesTelefono");
         AV52TFProfesionalesTelefono_Sel = GetPar( "TFProfesionalesTelefono_Sel");
         AV53TFProfesionalesEmail = GetPar( "TFProfesionalesEmail");
         AV54TFProfesionalesEmail_Sel = GetPar( "TFProfesionalesEmail_Sel");
         AV55TFProfesionalesDireccion = GetPar( "TFProfesionalesDireccion");
         AV56TFProfesionalesDireccion_Sel = GetPar( "TFProfesionalesDireccion_Sel");
         AV75TFEstadosGenericosNombre = GetPar( "TFEstadosGenericosNombre");
         AV76TFEstadosGenericosNombre_Sel = GetPar( "TFEstadosGenericosNombre_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV30DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV29DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV68IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV69IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV77IsAuthorized_EstadosGenericosNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_EstadosGenericosNombre"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV78ProfesionalesEsRUT1, AV79BancoNombre1, AV20ProfesionalesPrimerNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV80ProfesionalesEsRUT2, AV81BancoNombre2, AV24ProfesionalesPrimerNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV82ProfesionalesEsRUT3, AV83BancoNombre3, AV28ProfesionalesPrimerNombre3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV35ColumnsSelector, AV84Pgmname, AV41TFProfesionalesId, AV42TFProfesionalesId_Sel, AV43TFProfesionalesPrimerNombre, AV44TFProfesionalesPrimerNombre_Sel, AV45TFProfesionalesSegundoNombre, AV46TFProfesionalesSegundoNombre_Sel, AV47TFProfesionalesApellidoPrimero, AV48TFProfesionalesApellidoPrimero_Sel, AV49TFProfesionalesApellidoSegundo, AV50TFProfesionalesApellidoSegundo_Sel, AV51TFProfesionalesTelefono, AV52TFProfesionalesTelefono_Sel, AV53TFProfesionalesEmail, AV54TFProfesionalesEmail_Sel, AV55TFProfesionalesDireccion, AV56TFProfesionalesDireccion_Sel, AV75TFEstadosGenericosNombre, AV76TFEstadosGenericosNombre_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV68IsAuthorized_Update, AV69IsAuthorized_Delete, AV77IsAuthorized_EstadosGenericosNombre) ;
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
         PA6C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6C2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profesionalesww.aspx") +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV68IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV68IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV69IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV69IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", AV77IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( "", AV77IsAuthorized_EstadosGenericosNombre, context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vPROFESIONALESESRUT1", StringUtil.BoolToStr( AV78ProfesionalesEsRUT1));
         GxWebStd.gx_hidden_field( context, "GXH_vBANCONOMBRE1", StringUtil.RTrim( AV79BancoNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vPROFESIONALESPRIMERNOMBRE1", StringUtil.RTrim( AV20ProfesionalesPrimerNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROFESIONALESESRUT2", StringUtil.BoolToStr( AV80ProfesionalesEsRUT2));
         GxWebStd.gx_hidden_field( context, "GXH_vBANCONOMBRE2", StringUtil.RTrim( AV81BancoNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vPROFESIONALESPRIMERNOMBRE2", StringUtil.RTrim( AV24ProfesionalesPrimerNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPROFESIONALESESRUT3", StringUtil.BoolToStr( AV82ProfesionalesEsRUT3));
         GxWebStd.gx_hidden_field( context, "GXH_vBANCONOMBRE3", StringUtil.RTrim( AV83BancoNombre3));
         GxWebStd.gx_hidden_field( context, "GXH_vPROFESIONALESPRIMERNOMBRE3", StringUtil.RTrim( AV28ProfesionalesPrimerNombre3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_129", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_129), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV84Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV84Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESID", StringUtil.RTrim( AV41TFProfesionalesId));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESID_SEL", StringUtil.RTrim( AV42TFProfesionalesId_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESPRIMERNOMBRE", StringUtil.RTrim( AV43TFProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESPRIMERNOMBRE_SEL", StringUtil.RTrim( AV44TFProfesionalesPrimerNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESSEGUNDONOMBRE", StringUtil.RTrim( AV45TFProfesionalesSegundoNombre));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESSEGUNDONOMBRE_SEL", StringUtil.RTrim( AV46TFProfesionalesSegundoNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOPRIMERO", StringUtil.RTrim( AV47TFProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOPRIMERO_SEL", StringUtil.RTrim( AV48TFProfesionalesApellidoPrimero_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOSEGUNDO", StringUtil.RTrim( AV49TFProfesionalesApellidoSegundo));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESAPELLIDOSEGUNDO_SEL", StringUtil.RTrim( AV50TFProfesionalesApellidoSegundo_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESTELEFONO", StringUtil.RTrim( AV51TFProfesionalesTelefono));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESTELEFONO_SEL", StringUtil.RTrim( AV52TFProfesionalesTelefono_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESEMAIL", AV53TFProfesionalesEmail);
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESEMAIL_SEL", AV54TFProfesionalesEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESDIRECCION", AV55TFProfesionalesDireccion);
         GxWebStd.gx_hidden_field( context, "vTFPROFESIONALESDIRECCION_SEL", AV56TFProfesionalesDireccion_Sel);
         GxWebStd.gx_hidden_field( context, "vTFESTADOSGENERICOSNOMBRE", StringUtil.RTrim( AV75TFEstadosGenericosNombre));
         GxWebStd.gx_hidden_field( context, "vTFESTADOSGENERICOSNOMBRE_SEL", StringUtil.RTrim( AV76TFEstadosGenericosNombre_Sel));
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV68IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV68IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV69IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV69IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", AV77IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( "", AV77IsAuthorized_EstadosGenericosNombre, context));
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPO", StringUtil.RTrim( A107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
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
            WE6C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6C2( ) ;
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
         return formatLink("profesionalesww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ProfesionalesWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Profesionales", "") ;
      }

      protected void WB6C0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(129), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_6C2( true) ;
         }
         else
         {
            wb_table1_25_6C2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_6C2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_ProfesionalesWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_6C2( true) ;
         }
         else
         {
            wb_table2_49_6C2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_6C2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_ProfesionalesWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_77_6C2( true) ;
         }
         else
         {
            wb_table3_77_6C2( false) ;
         }
         return  ;
      }

      protected void wb_table3_77_6C2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_129_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 0, "HLP_ProfesionalesWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_105_6C2( true) ;
         }
         else
         {
            wb_table4_105_6C2( false) ;
         }
         return  ;
      }

      protected void wb_table4_105_6C2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV63GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV64GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV65GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV70AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ProfesionalesWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV35ColumnsSelector);
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
               GxWebStd.gx_hidden_field( context, "W0154"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0154"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_129_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0154"+"");
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

      protected void START6C2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Profesionales", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6C0( ) ;
      }

      protected void WS6C2( )
      {
         START6C2( ) ;
         EVT6C2( ) ;
      }

      protected void EVT6C2( )
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
                              E116C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E126C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E136C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E146C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E156C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E166C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E176C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E186C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E196C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E206C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E216C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E226C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E236C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E246C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E256C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E266C2 ();
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
                              AV66GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV66GridActions), 4, 0));
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
                              A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
                              A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
                              A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
                              A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
                              A193ProfesionalesEmail = cgiGet( edtProfesionalesEmail_Internalname);
                              n193ProfesionalesEmail = false;
                              A198ProfesionalesDireccion = cgiGet( edtProfesionalesDireccion_Internalname);
                              A109EstadosGenericosNombre = cgiGet( edtEstadosGenericosNombre_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E276C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E286C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E296C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E306C2 ();
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
                                       /* Set Refresh If Profesionalesesrut1 Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vPROFESIONALESESRUT1")) != AV78ProfesionalesEsRUT1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Banconombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vBANCONOMBRE1"), AV79BancoNombre1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Profesionalesprimernombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE1"), AV20ProfesionalesPrimerNombre1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Profesionalesesrut2 Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vPROFESIONALESESRUT2")) != AV80ProfesionalesEsRUT2 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Banconombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vBANCONOMBRE2"), AV81BancoNombre2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Profesionalesprimernombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE2"), AV24ProfesionalesPrimerNombre2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Profesionalesesrut3 Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vPROFESIONALESESRUT3")) != AV82ProfesionalesEsRUT3 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Banconombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vBANCONOMBRE3"), AV83BancoNombre3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Profesionalesprimernombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE3"), AV28ProfesionalesPrimerNombre3) != 0 )
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
                        if ( nCmpId == 154 )
                        {
                           OldWwpaux_wc = cgiGet( "W0154");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0154", "", sEvt);
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

      protected void WE6C2( )
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

      protected void PA6C2( )
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
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       bool AV78ProfesionalesEsRUT1 ,
                                       string AV79BancoNombre1 ,
                                       string AV20ProfesionalesPrimerNombre1 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       bool AV80ProfesionalesEsRUT2 ,
                                       string AV81BancoNombre2 ,
                                       string AV24ProfesionalesPrimerNombre2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       bool AV82ProfesionalesEsRUT3 ,
                                       string AV83BancoNombre3 ,
                                       string AV28ProfesionalesPrimerNombre3 ,
                                       short AV40ManageFiltersExecutionStep ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ,
                                       string AV84Pgmname ,
                                       string AV41TFProfesionalesId ,
                                       string AV42TFProfesionalesId_Sel ,
                                       string AV43TFProfesionalesPrimerNombre ,
                                       string AV44TFProfesionalesPrimerNombre_Sel ,
                                       string AV45TFProfesionalesSegundoNombre ,
                                       string AV46TFProfesionalesSegundoNombre_Sel ,
                                       string AV47TFProfesionalesApellidoPrimero ,
                                       string AV48TFProfesionalesApellidoPrimero_Sel ,
                                       string AV49TFProfesionalesApellidoSegundo ,
                                       string AV50TFProfesionalesApellidoSegundo_Sel ,
                                       string AV51TFProfesionalesTelefono ,
                                       string AV52TFProfesionalesTelefono_Sel ,
                                       string AV53TFProfesionalesEmail ,
                                       string AV54TFProfesionalesEmail_Sel ,
                                       string AV55TFProfesionalesDireccion ,
                                       string AV56TFProfesionalesDireccion_Sel ,
                                       string AV75TFEstadosGenericosNombre ,
                                       string AV76TFEstadosGenericosNombre_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving ,
                                       bool AV68IsAuthorized_Update ,
                                       bool AV69IsAuthorized_Delete ,
                                       bool AV77IsAuthorized_EstadosGenericosNombre )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF6C2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID", StringUtil.RTrim( A120ProfesionalesId));
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
         AV78ProfesionalesEsRUT1 = StringUtil.StrToBool( StringUtil.BoolToStr( AV78ProfesionalesEsRUT1));
         AssignAttri("", false, "AV78ProfesionalesEsRUT1", AV78ProfesionalesEsRUT1);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         AV80ProfesionalesEsRUT2 = StringUtil.StrToBool( StringUtil.BoolToStr( AV80ProfesionalesEsRUT2));
         AssignAttri("", false, "AV80ProfesionalesEsRUT2", AV80ProfesionalesEsRUT2);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
         AV82ProfesionalesEsRUT3 = StringUtil.StrToBool( StringUtil.BoolToStr( AV82ProfesionalesEsRUT3));
         AssignAttri("", false, "AV82ProfesionalesEsRUT3", AV82ProfesionalesEsRUT3);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV84Pgmname = "ProfesionalesWW";
      }

      protected void RF6C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 129;
         /* Execute user event: Refresh */
         E286C2 ();
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
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV85Profesionaleswwds_1_filterfulltext ,
                                                 AV86Profesionaleswwds_2_dynamicfiltersselector1 ,
                                                 AV88Profesionaleswwds_4_profesionalesesrut1 ,
                                                 AV87Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                                 AV89Profesionaleswwds_5_banconombre1 ,
                                                 AV90Profesionaleswwds_6_profesionalesprimernombre1 ,
                                                 AV91Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                                 AV92Profesionaleswwds_8_dynamicfiltersselector2 ,
                                                 AV94Profesionaleswwds_10_profesionalesesrut2 ,
                                                 AV93Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                                 AV95Profesionaleswwds_11_banconombre2 ,
                                                 AV96Profesionaleswwds_12_profesionalesprimernombre2 ,
                                                 AV97Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                                 AV98Profesionaleswwds_14_dynamicfiltersselector3 ,
                                                 AV100Profesionaleswwds_16_profesionalesesrut3 ,
                                                 AV99Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                                 AV101Profesionaleswwds_17_banconombre3 ,
                                                 AV102Profesionaleswwds_18_profesionalesprimernombre3 ,
                                                 AV104Profesionaleswwds_20_tfprofesionalesid_sel ,
                                                 AV103Profesionaleswwds_19_tfprofesionalesid ,
                                                 AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                                 AV105Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                                 AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                                 AV107Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                                 AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                                 AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                                 AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                                 AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                                 AV114Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                                 AV113Profesionaleswwds_29_tfprofesionalestelefono ,
                                                 AV116Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                                 AV115Profesionaleswwds_31_tfprofesionalesemail ,
                                                 AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                                 AV117Profesionaleswwds_33_tfprofesionalesdireccion ,
                                                 AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                                 AV119Profesionaleswwds_35_tfestadosgenericosnombre ,
                                                 A120ProfesionalesId ,
                                                 A166ProfesionalesPrimerNombre ,
                                                 A191ProfesionalesSegundoNombre ,
                                                 A167ProfesionalesApellidoPrimero ,
                                                 A192ProfesionalesApellidoSegundo ,
                                                 A170ProfesionalesTelefono ,
                                                 A676ProfesionalesEsRUT ,
                                                 A674BancoNombre ,
                                                 A193ProfesionalesEmail ,
                                                 A198ProfesionalesDireccion ,
                                                 A109EstadosGenericosNombre ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
            lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
            lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
            lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
            lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
            lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
            lV89Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV89Profesionaleswwds_5_banconombre1), 80, "%");
            lV89Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV89Profesionaleswwds_5_banconombre1), 80, "%");
            lV90Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV90Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
            lV90Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV90Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
            lV95Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_11_banconombre2), 80, "%");
            lV95Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_11_banconombre2), 80, "%");
            lV96Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV96Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
            lV96Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV96Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
            lV101Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_17_banconombre3), 80, "%");
            lV101Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_17_banconombre3), 80, "%");
            lV102Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV102Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
            lV102Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV102Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
            lV103Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_19_tfprofesionalesid), 20, "%");
            lV105Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV105Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
            lV107Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV107Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
            lV109Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
            lV111Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
            lV113Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV113Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
            lV115Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV115Profesionaleswwds_31_tfprofesionalesemail), "%", "");
            lV117Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV117Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
            lV119Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV119Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
            /* Using cursor H006C2 */
            pr_default.execute(0, new Object[] {lV85Profesionaleswwds_1_filterfulltext, lV85Profesionaleswwds_1_filterfulltext, lV85Profesionaleswwds_1_filterfulltext, lV85Profesionaleswwds_1_filterfulltext, lV85Profesionaleswwds_1_filterfulltext, lV85Profesionaleswwds_1_filterfulltext, AV88Profesionaleswwds_4_profesionalesesrut1, lV89Profesionaleswwds_5_banconombre1, lV89Profesionaleswwds_5_banconombre1, lV90Profesionaleswwds_6_profesionalesprimernombre1, lV90Profesionaleswwds_6_profesionalesprimernombre1, AV94Profesionaleswwds_10_profesionalesesrut2, lV95Profesionaleswwds_11_banconombre2, lV95Profesionaleswwds_11_banconombre2, lV96Profesionaleswwds_12_profesionalesprimernombre2, lV96Profesionaleswwds_12_profesionalesprimernombre2, AV100Profesionaleswwds_16_profesionalesesrut3, lV101Profesionaleswwds_17_banconombre3, lV101Profesionaleswwds_17_banconombre3, lV102Profesionaleswwds_18_profesionalesprimernombre3, lV102Profesionaleswwds_18_profesionalesprimernombre3, lV103Profesionaleswwds_19_tfprofesionalesid, AV104Profesionaleswwds_20_tfprofesionalesid_sel, lV105Profesionaleswwds_21_tfprofesionalesprimernombre, AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV107Profesionaleswwds_23_tfprofesionalessegundonombre, AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV109Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV111Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV113Profesionaleswwds_29_tfprofesionalestelefono, AV114Profesionaleswwds_30_tfprofesionalestelefono_sel, lV115Profesionaleswwds_31_tfprofesionalesemail, AV116Profesionaleswwds_32_tfprofesionalesemail_sel, lV117Profesionaleswwds_33_tfprofesionalesdireccion, AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV119Profesionaleswwds_35_tfestadosgenericosnombre, AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_129_idx = 1;
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
            SubsflControlProps_1292( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A673BancoId = H006C2_A673BancoId[0];
               n673BancoId = H006C2_n673BancoId[0];
               A674BancoNombre = H006C2_A674BancoNombre[0];
               A676ProfesionalesEsRUT = H006C2_A676ProfesionalesEsRUT[0];
               n676ProfesionalesEsRUT = H006C2_n676ProfesionalesEsRUT[0];
               A108EstadosGenericosId = H006C2_A108EstadosGenericosId[0];
               A107EstadosTipo = H006C2_A107EstadosTipo[0];
               A109EstadosGenericosNombre = H006C2_A109EstadosGenericosNombre[0];
               A198ProfesionalesDireccion = H006C2_A198ProfesionalesDireccion[0];
               A193ProfesionalesEmail = H006C2_A193ProfesionalesEmail[0];
               n193ProfesionalesEmail = H006C2_n193ProfesionalesEmail[0];
               A170ProfesionalesTelefono = H006C2_A170ProfesionalesTelefono[0];
               A192ProfesionalesApellidoSegundo = H006C2_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H006C2_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H006C2_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H006C2_A166ProfesionalesPrimerNombre[0];
               A120ProfesionalesId = H006C2_A120ProfesionalesId[0];
               A674BancoNombre = H006C2_A674BancoNombre[0];
               A109EstadosGenericosNombre = H006C2_A109EstadosGenericosNombre[0];
               /* Execute user event: Grid.Load */
               E296C2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 129;
            WB6C0( ) ;
         }
         bGXsfl_129_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6C2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV84Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV84Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV68IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV68IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV69IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV69IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", AV77IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( "", AV77IsAuthorized_EstadosGenericosNombre, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROFESIONALESID"+"_"+sGXsfl_129_idx, GetSecureSignedToken( sGXsfl_129_idx, StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
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
         AV85Profesionaleswwds_1_filterfulltext = AV17FilterFullText;
         AV86Profesionaleswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV87Profesionaleswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV88Profesionaleswwds_4_profesionalesesrut1 = AV78ProfesionalesEsRUT1;
         AV89Profesionaleswwds_5_banconombre1 = AV79BancoNombre1;
         AV90Profesionaleswwds_6_profesionalesprimernombre1 = AV20ProfesionalesPrimerNombre1;
         AV91Profesionaleswwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV92Profesionaleswwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV93Profesionaleswwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV94Profesionaleswwds_10_profesionalesesrut2 = AV80ProfesionalesEsRUT2;
         AV95Profesionaleswwds_11_banconombre2 = AV81BancoNombre2;
         AV96Profesionaleswwds_12_profesionalesprimernombre2 = AV24ProfesionalesPrimerNombre2;
         AV97Profesionaleswwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV98Profesionaleswwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV99Profesionaleswwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV100Profesionaleswwds_16_profesionalesesrut3 = AV82ProfesionalesEsRUT3;
         AV101Profesionaleswwds_17_banconombre3 = AV83BancoNombre3;
         AV102Profesionaleswwds_18_profesionalesprimernombre3 = AV28ProfesionalesPrimerNombre3;
         AV103Profesionaleswwds_19_tfprofesionalesid = AV41TFProfesionalesId;
         AV104Profesionaleswwds_20_tfprofesionalesid_sel = AV42TFProfesionalesId_Sel;
         AV105Profesionaleswwds_21_tfprofesionalesprimernombre = AV43TFProfesionalesPrimerNombre;
         AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV44TFProfesionalesPrimerNombre_Sel;
         AV107Profesionaleswwds_23_tfprofesionalessegundonombre = AV45TFProfesionalesSegundoNombre;
         AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV46TFProfesionalesSegundoNombre_Sel;
         AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV47TFProfesionalesApellidoPrimero;
         AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV48TFProfesionalesApellidoPrimero_Sel;
         AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV49TFProfesionalesApellidoSegundo;
         AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV50TFProfesionalesApellidoSegundo_Sel;
         AV113Profesionaleswwds_29_tfprofesionalestelefono = AV51TFProfesionalesTelefono;
         AV114Profesionaleswwds_30_tfprofesionalestelefono_sel = AV52TFProfesionalesTelefono_Sel;
         AV115Profesionaleswwds_31_tfprofesionalesemail = AV53TFProfesionalesEmail;
         AV116Profesionaleswwds_32_tfprofesionalesemail_sel = AV54TFProfesionalesEmail_Sel;
         AV117Profesionaleswwds_33_tfprofesionalesdireccion = AV55TFProfesionalesDireccion;
         AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV56TFProfesionalesDireccion_Sel;
         AV119Profesionaleswwds_35_tfestadosgenericosnombre = AV75TFEstadosGenericosNombre;
         AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV76TFEstadosGenericosNombre_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV85Profesionaleswwds_1_filterfulltext ,
                                              AV86Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV88Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV87Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV89Profesionaleswwds_5_banconombre1 ,
                                              AV90Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV91Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV92Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV94Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV93Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV95Profesionaleswwds_11_banconombre2 ,
                                              AV96Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV97Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV98Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV100Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV99Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV101Profesionaleswwds_17_banconombre3 ,
                                              AV102Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV104Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV103Profesionaleswwds_19_tfprofesionalesid ,
                                              AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV105Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV107Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV114Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV113Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV116Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV115Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV117Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV119Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
         lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
         lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
         lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
         lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
         lV85Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext), "%", "");
         lV89Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV89Profesionaleswwds_5_banconombre1), 80, "%");
         lV89Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV89Profesionaleswwds_5_banconombre1), 80, "%");
         lV90Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV90Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV90Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV90Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV95Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_11_banconombre2), 80, "%");
         lV95Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_11_banconombre2), 80, "%");
         lV96Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV96Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV96Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV96Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV101Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_17_banconombre3), 80, "%");
         lV101Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_17_banconombre3), 80, "%");
         lV102Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV102Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV102Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV102Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV103Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV105Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV105Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV107Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV107Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV109Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV111Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV113Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV113Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV115Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV115Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV117Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV117Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV119Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV119Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor H006C3 */
         pr_default.execute(1, new Object[] {lV85Profesionaleswwds_1_filterfulltext, lV85Profesionaleswwds_1_filterfulltext, lV85Profesionaleswwds_1_filterfulltext, lV85Profesionaleswwds_1_filterfulltext, lV85Profesionaleswwds_1_filterfulltext, lV85Profesionaleswwds_1_filterfulltext, AV88Profesionaleswwds_4_profesionalesesrut1, lV89Profesionaleswwds_5_banconombre1, lV89Profesionaleswwds_5_banconombre1, lV90Profesionaleswwds_6_profesionalesprimernombre1, lV90Profesionaleswwds_6_profesionalesprimernombre1, AV94Profesionaleswwds_10_profesionalesesrut2, lV95Profesionaleswwds_11_banconombre2, lV95Profesionaleswwds_11_banconombre2, lV96Profesionaleswwds_12_profesionalesprimernombre2, lV96Profesionaleswwds_12_profesionalesprimernombre2, AV100Profesionaleswwds_16_profesionalesesrut3, lV101Profesionaleswwds_17_banconombre3, lV101Profesionaleswwds_17_banconombre3, lV102Profesionaleswwds_18_profesionalesprimernombre3, lV102Profesionaleswwds_18_profesionalesprimernombre3, lV103Profesionaleswwds_19_tfprofesionalesid, AV104Profesionaleswwds_20_tfprofesionalesid_sel, lV105Profesionaleswwds_21_tfprofesionalesprimernombre, AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV107Profesionaleswwds_23_tfprofesionalessegundonombre, AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV109Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV111Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV113Profesionaleswwds_29_tfprofesionalestelefono, AV114Profesionaleswwds_30_tfprofesionalestelefono_sel, lV115Profesionaleswwds_31_tfprofesionalesemail, AV116Profesionaleswwds_32_tfprofesionalesemail_sel, lV117Profesionaleswwds_33_tfprofesionalesdireccion, AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV119Profesionaleswwds_35_tfestadosgenericosnombre, AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel});
         GRID_nRecordCount = H006C3_AGRID_nRecordCount[0];
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
         AV85Profesionaleswwds_1_filterfulltext = AV17FilterFullText;
         AV86Profesionaleswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV87Profesionaleswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV88Profesionaleswwds_4_profesionalesesrut1 = AV78ProfesionalesEsRUT1;
         AV89Profesionaleswwds_5_banconombre1 = AV79BancoNombre1;
         AV90Profesionaleswwds_6_profesionalesprimernombre1 = AV20ProfesionalesPrimerNombre1;
         AV91Profesionaleswwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV92Profesionaleswwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV93Profesionaleswwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV94Profesionaleswwds_10_profesionalesesrut2 = AV80ProfesionalesEsRUT2;
         AV95Profesionaleswwds_11_banconombre2 = AV81BancoNombre2;
         AV96Profesionaleswwds_12_profesionalesprimernombre2 = AV24ProfesionalesPrimerNombre2;
         AV97Profesionaleswwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV98Profesionaleswwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV99Profesionaleswwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV100Profesionaleswwds_16_profesionalesesrut3 = AV82ProfesionalesEsRUT3;
         AV101Profesionaleswwds_17_banconombre3 = AV83BancoNombre3;
         AV102Profesionaleswwds_18_profesionalesprimernombre3 = AV28ProfesionalesPrimerNombre3;
         AV103Profesionaleswwds_19_tfprofesionalesid = AV41TFProfesionalesId;
         AV104Profesionaleswwds_20_tfprofesionalesid_sel = AV42TFProfesionalesId_Sel;
         AV105Profesionaleswwds_21_tfprofesionalesprimernombre = AV43TFProfesionalesPrimerNombre;
         AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV44TFProfesionalesPrimerNombre_Sel;
         AV107Profesionaleswwds_23_tfprofesionalessegundonombre = AV45TFProfesionalesSegundoNombre;
         AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV46TFProfesionalesSegundoNombre_Sel;
         AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV47TFProfesionalesApellidoPrimero;
         AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV48TFProfesionalesApellidoPrimero_Sel;
         AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV49TFProfesionalesApellidoSegundo;
         AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV50TFProfesionalesApellidoSegundo_Sel;
         AV113Profesionaleswwds_29_tfprofesionalestelefono = AV51TFProfesionalesTelefono;
         AV114Profesionaleswwds_30_tfprofesionalestelefono_sel = AV52TFProfesionalesTelefono_Sel;
         AV115Profesionaleswwds_31_tfprofesionalesemail = AV53TFProfesionalesEmail;
         AV116Profesionaleswwds_32_tfprofesionalesemail_sel = AV54TFProfesionalesEmail_Sel;
         AV117Profesionaleswwds_33_tfprofesionalesdireccion = AV55TFProfesionalesDireccion;
         AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV56TFProfesionalesDireccion_Sel;
         AV119Profesionaleswwds_35_tfestadosgenericosnombre = AV75TFEstadosGenericosNombre;
         AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV76TFEstadosGenericosNombre_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV78ProfesionalesEsRUT1, AV79BancoNombre1, AV20ProfesionalesPrimerNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV80ProfesionalesEsRUT2, AV81BancoNombre2, AV24ProfesionalesPrimerNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV82ProfesionalesEsRUT3, AV83BancoNombre3, AV28ProfesionalesPrimerNombre3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV35ColumnsSelector, AV84Pgmname, AV41TFProfesionalesId, AV42TFProfesionalesId_Sel, AV43TFProfesionalesPrimerNombre, AV44TFProfesionalesPrimerNombre_Sel, AV45TFProfesionalesSegundoNombre, AV46TFProfesionalesSegundoNombre_Sel, AV47TFProfesionalesApellidoPrimero, AV48TFProfesionalesApellidoPrimero_Sel, AV49TFProfesionalesApellidoSegundo, AV50TFProfesionalesApellidoSegundo_Sel, AV51TFProfesionalesTelefono, AV52TFProfesionalesTelefono_Sel, AV53TFProfesionalesEmail, AV54TFProfesionalesEmail_Sel, AV55TFProfesionalesDireccion, AV56TFProfesionalesDireccion_Sel, AV75TFEstadosGenericosNombre, AV76TFEstadosGenericosNombre_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV68IsAuthorized_Update, AV69IsAuthorized_Delete, AV77IsAuthorized_EstadosGenericosNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV85Profesionaleswwds_1_filterfulltext = AV17FilterFullText;
         AV86Profesionaleswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV87Profesionaleswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV88Profesionaleswwds_4_profesionalesesrut1 = AV78ProfesionalesEsRUT1;
         AV89Profesionaleswwds_5_banconombre1 = AV79BancoNombre1;
         AV90Profesionaleswwds_6_profesionalesprimernombre1 = AV20ProfesionalesPrimerNombre1;
         AV91Profesionaleswwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV92Profesionaleswwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV93Profesionaleswwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV94Profesionaleswwds_10_profesionalesesrut2 = AV80ProfesionalesEsRUT2;
         AV95Profesionaleswwds_11_banconombre2 = AV81BancoNombre2;
         AV96Profesionaleswwds_12_profesionalesprimernombre2 = AV24ProfesionalesPrimerNombre2;
         AV97Profesionaleswwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV98Profesionaleswwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV99Profesionaleswwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV100Profesionaleswwds_16_profesionalesesrut3 = AV82ProfesionalesEsRUT3;
         AV101Profesionaleswwds_17_banconombre3 = AV83BancoNombre3;
         AV102Profesionaleswwds_18_profesionalesprimernombre3 = AV28ProfesionalesPrimerNombre3;
         AV103Profesionaleswwds_19_tfprofesionalesid = AV41TFProfesionalesId;
         AV104Profesionaleswwds_20_tfprofesionalesid_sel = AV42TFProfesionalesId_Sel;
         AV105Profesionaleswwds_21_tfprofesionalesprimernombre = AV43TFProfesionalesPrimerNombre;
         AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV44TFProfesionalesPrimerNombre_Sel;
         AV107Profesionaleswwds_23_tfprofesionalessegundonombre = AV45TFProfesionalesSegundoNombre;
         AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV46TFProfesionalesSegundoNombre_Sel;
         AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV47TFProfesionalesApellidoPrimero;
         AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV48TFProfesionalesApellidoPrimero_Sel;
         AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV49TFProfesionalesApellidoSegundo;
         AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV50TFProfesionalesApellidoSegundo_Sel;
         AV113Profesionaleswwds_29_tfprofesionalestelefono = AV51TFProfesionalesTelefono;
         AV114Profesionaleswwds_30_tfprofesionalestelefono_sel = AV52TFProfesionalesTelefono_Sel;
         AV115Profesionaleswwds_31_tfprofesionalesemail = AV53TFProfesionalesEmail;
         AV116Profesionaleswwds_32_tfprofesionalesemail_sel = AV54TFProfesionalesEmail_Sel;
         AV117Profesionaleswwds_33_tfprofesionalesdireccion = AV55TFProfesionalesDireccion;
         AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV56TFProfesionalesDireccion_Sel;
         AV119Profesionaleswwds_35_tfestadosgenericosnombre = AV75TFEstadosGenericosNombre;
         AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV76TFEstadosGenericosNombre_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV78ProfesionalesEsRUT1, AV79BancoNombre1, AV20ProfesionalesPrimerNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV80ProfesionalesEsRUT2, AV81BancoNombre2, AV24ProfesionalesPrimerNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV82ProfesionalesEsRUT3, AV83BancoNombre3, AV28ProfesionalesPrimerNombre3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV35ColumnsSelector, AV84Pgmname, AV41TFProfesionalesId, AV42TFProfesionalesId_Sel, AV43TFProfesionalesPrimerNombre, AV44TFProfesionalesPrimerNombre_Sel, AV45TFProfesionalesSegundoNombre, AV46TFProfesionalesSegundoNombre_Sel, AV47TFProfesionalesApellidoPrimero, AV48TFProfesionalesApellidoPrimero_Sel, AV49TFProfesionalesApellidoSegundo, AV50TFProfesionalesApellidoSegundo_Sel, AV51TFProfesionalesTelefono, AV52TFProfesionalesTelefono_Sel, AV53TFProfesionalesEmail, AV54TFProfesionalesEmail_Sel, AV55TFProfesionalesDireccion, AV56TFProfesionalesDireccion_Sel, AV75TFEstadosGenericosNombre, AV76TFEstadosGenericosNombre_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV68IsAuthorized_Update, AV69IsAuthorized_Delete, AV77IsAuthorized_EstadosGenericosNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV85Profesionaleswwds_1_filterfulltext = AV17FilterFullText;
         AV86Profesionaleswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV87Profesionaleswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV88Profesionaleswwds_4_profesionalesesrut1 = AV78ProfesionalesEsRUT1;
         AV89Profesionaleswwds_5_banconombre1 = AV79BancoNombre1;
         AV90Profesionaleswwds_6_profesionalesprimernombre1 = AV20ProfesionalesPrimerNombre1;
         AV91Profesionaleswwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV92Profesionaleswwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV93Profesionaleswwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV94Profesionaleswwds_10_profesionalesesrut2 = AV80ProfesionalesEsRUT2;
         AV95Profesionaleswwds_11_banconombre2 = AV81BancoNombre2;
         AV96Profesionaleswwds_12_profesionalesprimernombre2 = AV24ProfesionalesPrimerNombre2;
         AV97Profesionaleswwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV98Profesionaleswwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV99Profesionaleswwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV100Profesionaleswwds_16_profesionalesesrut3 = AV82ProfesionalesEsRUT3;
         AV101Profesionaleswwds_17_banconombre3 = AV83BancoNombre3;
         AV102Profesionaleswwds_18_profesionalesprimernombre3 = AV28ProfesionalesPrimerNombre3;
         AV103Profesionaleswwds_19_tfprofesionalesid = AV41TFProfesionalesId;
         AV104Profesionaleswwds_20_tfprofesionalesid_sel = AV42TFProfesionalesId_Sel;
         AV105Profesionaleswwds_21_tfprofesionalesprimernombre = AV43TFProfesionalesPrimerNombre;
         AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV44TFProfesionalesPrimerNombre_Sel;
         AV107Profesionaleswwds_23_tfprofesionalessegundonombre = AV45TFProfesionalesSegundoNombre;
         AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV46TFProfesionalesSegundoNombre_Sel;
         AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV47TFProfesionalesApellidoPrimero;
         AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV48TFProfesionalesApellidoPrimero_Sel;
         AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV49TFProfesionalesApellidoSegundo;
         AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV50TFProfesionalesApellidoSegundo_Sel;
         AV113Profesionaleswwds_29_tfprofesionalestelefono = AV51TFProfesionalesTelefono;
         AV114Profesionaleswwds_30_tfprofesionalestelefono_sel = AV52TFProfesionalesTelefono_Sel;
         AV115Profesionaleswwds_31_tfprofesionalesemail = AV53TFProfesionalesEmail;
         AV116Profesionaleswwds_32_tfprofesionalesemail_sel = AV54TFProfesionalesEmail_Sel;
         AV117Profesionaleswwds_33_tfprofesionalesdireccion = AV55TFProfesionalesDireccion;
         AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV56TFProfesionalesDireccion_Sel;
         AV119Profesionaleswwds_35_tfestadosgenericosnombre = AV75TFEstadosGenericosNombre;
         AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV76TFEstadosGenericosNombre_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV78ProfesionalesEsRUT1, AV79BancoNombre1, AV20ProfesionalesPrimerNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV80ProfesionalesEsRUT2, AV81BancoNombre2, AV24ProfesionalesPrimerNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV82ProfesionalesEsRUT3, AV83BancoNombre3, AV28ProfesionalesPrimerNombre3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV35ColumnsSelector, AV84Pgmname, AV41TFProfesionalesId, AV42TFProfesionalesId_Sel, AV43TFProfesionalesPrimerNombre, AV44TFProfesionalesPrimerNombre_Sel, AV45TFProfesionalesSegundoNombre, AV46TFProfesionalesSegundoNombre_Sel, AV47TFProfesionalesApellidoPrimero, AV48TFProfesionalesApellidoPrimero_Sel, AV49TFProfesionalesApellidoSegundo, AV50TFProfesionalesApellidoSegundo_Sel, AV51TFProfesionalesTelefono, AV52TFProfesionalesTelefono_Sel, AV53TFProfesionalesEmail, AV54TFProfesionalesEmail_Sel, AV55TFProfesionalesDireccion, AV56TFProfesionalesDireccion_Sel, AV75TFEstadosGenericosNombre, AV76TFEstadosGenericosNombre_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV68IsAuthorized_Update, AV69IsAuthorized_Delete, AV77IsAuthorized_EstadosGenericosNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV85Profesionaleswwds_1_filterfulltext = AV17FilterFullText;
         AV86Profesionaleswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV87Profesionaleswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV88Profesionaleswwds_4_profesionalesesrut1 = AV78ProfesionalesEsRUT1;
         AV89Profesionaleswwds_5_banconombre1 = AV79BancoNombre1;
         AV90Profesionaleswwds_6_profesionalesprimernombre1 = AV20ProfesionalesPrimerNombre1;
         AV91Profesionaleswwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV92Profesionaleswwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV93Profesionaleswwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV94Profesionaleswwds_10_profesionalesesrut2 = AV80ProfesionalesEsRUT2;
         AV95Profesionaleswwds_11_banconombre2 = AV81BancoNombre2;
         AV96Profesionaleswwds_12_profesionalesprimernombre2 = AV24ProfesionalesPrimerNombre2;
         AV97Profesionaleswwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV98Profesionaleswwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV99Profesionaleswwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV100Profesionaleswwds_16_profesionalesesrut3 = AV82ProfesionalesEsRUT3;
         AV101Profesionaleswwds_17_banconombre3 = AV83BancoNombre3;
         AV102Profesionaleswwds_18_profesionalesprimernombre3 = AV28ProfesionalesPrimerNombre3;
         AV103Profesionaleswwds_19_tfprofesionalesid = AV41TFProfesionalesId;
         AV104Profesionaleswwds_20_tfprofesionalesid_sel = AV42TFProfesionalesId_Sel;
         AV105Profesionaleswwds_21_tfprofesionalesprimernombre = AV43TFProfesionalesPrimerNombre;
         AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV44TFProfesionalesPrimerNombre_Sel;
         AV107Profesionaleswwds_23_tfprofesionalessegundonombre = AV45TFProfesionalesSegundoNombre;
         AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV46TFProfesionalesSegundoNombre_Sel;
         AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV47TFProfesionalesApellidoPrimero;
         AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV48TFProfesionalesApellidoPrimero_Sel;
         AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV49TFProfesionalesApellidoSegundo;
         AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV50TFProfesionalesApellidoSegundo_Sel;
         AV113Profesionaleswwds_29_tfprofesionalestelefono = AV51TFProfesionalesTelefono;
         AV114Profesionaleswwds_30_tfprofesionalestelefono_sel = AV52TFProfesionalesTelefono_Sel;
         AV115Profesionaleswwds_31_tfprofesionalesemail = AV53TFProfesionalesEmail;
         AV116Profesionaleswwds_32_tfprofesionalesemail_sel = AV54TFProfesionalesEmail_Sel;
         AV117Profesionaleswwds_33_tfprofesionalesdireccion = AV55TFProfesionalesDireccion;
         AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV56TFProfesionalesDireccion_Sel;
         AV119Profesionaleswwds_35_tfestadosgenericosnombre = AV75TFEstadosGenericosNombre;
         AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV76TFEstadosGenericosNombre_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV78ProfesionalesEsRUT1, AV79BancoNombre1, AV20ProfesionalesPrimerNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV80ProfesionalesEsRUT2, AV81BancoNombre2, AV24ProfesionalesPrimerNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV82ProfesionalesEsRUT3, AV83BancoNombre3, AV28ProfesionalesPrimerNombre3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV35ColumnsSelector, AV84Pgmname, AV41TFProfesionalesId, AV42TFProfesionalesId_Sel, AV43TFProfesionalesPrimerNombre, AV44TFProfesionalesPrimerNombre_Sel, AV45TFProfesionalesSegundoNombre, AV46TFProfesionalesSegundoNombre_Sel, AV47TFProfesionalesApellidoPrimero, AV48TFProfesionalesApellidoPrimero_Sel, AV49TFProfesionalesApellidoSegundo, AV50TFProfesionalesApellidoSegundo_Sel, AV51TFProfesionalesTelefono, AV52TFProfesionalesTelefono_Sel, AV53TFProfesionalesEmail, AV54TFProfesionalesEmail_Sel, AV55TFProfesionalesDireccion, AV56TFProfesionalesDireccion_Sel, AV75TFEstadosGenericosNombre, AV76TFEstadosGenericosNombre_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV68IsAuthorized_Update, AV69IsAuthorized_Delete, AV77IsAuthorized_EstadosGenericosNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV85Profesionaleswwds_1_filterfulltext = AV17FilterFullText;
         AV86Profesionaleswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV87Profesionaleswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV88Profesionaleswwds_4_profesionalesesrut1 = AV78ProfesionalesEsRUT1;
         AV89Profesionaleswwds_5_banconombre1 = AV79BancoNombre1;
         AV90Profesionaleswwds_6_profesionalesprimernombre1 = AV20ProfesionalesPrimerNombre1;
         AV91Profesionaleswwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV92Profesionaleswwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV93Profesionaleswwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV94Profesionaleswwds_10_profesionalesesrut2 = AV80ProfesionalesEsRUT2;
         AV95Profesionaleswwds_11_banconombre2 = AV81BancoNombre2;
         AV96Profesionaleswwds_12_profesionalesprimernombre2 = AV24ProfesionalesPrimerNombre2;
         AV97Profesionaleswwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV98Profesionaleswwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV99Profesionaleswwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV100Profesionaleswwds_16_profesionalesesrut3 = AV82ProfesionalesEsRUT3;
         AV101Profesionaleswwds_17_banconombre3 = AV83BancoNombre3;
         AV102Profesionaleswwds_18_profesionalesprimernombre3 = AV28ProfesionalesPrimerNombre3;
         AV103Profesionaleswwds_19_tfprofesionalesid = AV41TFProfesionalesId;
         AV104Profesionaleswwds_20_tfprofesionalesid_sel = AV42TFProfesionalesId_Sel;
         AV105Profesionaleswwds_21_tfprofesionalesprimernombre = AV43TFProfesionalesPrimerNombre;
         AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV44TFProfesionalesPrimerNombre_Sel;
         AV107Profesionaleswwds_23_tfprofesionalessegundonombre = AV45TFProfesionalesSegundoNombre;
         AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV46TFProfesionalesSegundoNombre_Sel;
         AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV47TFProfesionalesApellidoPrimero;
         AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV48TFProfesionalesApellidoPrimero_Sel;
         AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV49TFProfesionalesApellidoSegundo;
         AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV50TFProfesionalesApellidoSegundo_Sel;
         AV113Profesionaleswwds_29_tfprofesionalestelefono = AV51TFProfesionalesTelefono;
         AV114Profesionaleswwds_30_tfprofesionalestelefono_sel = AV52TFProfesionalesTelefono_Sel;
         AV115Profesionaleswwds_31_tfprofesionalesemail = AV53TFProfesionalesEmail;
         AV116Profesionaleswwds_32_tfprofesionalesemail_sel = AV54TFProfesionalesEmail_Sel;
         AV117Profesionaleswwds_33_tfprofesionalesdireccion = AV55TFProfesionalesDireccion;
         AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV56TFProfesionalesDireccion_Sel;
         AV119Profesionaleswwds_35_tfestadosgenericosnombre = AV75TFEstadosGenericosNombre;
         AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV76TFEstadosGenericosNombre_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV78ProfesionalesEsRUT1, AV79BancoNombre1, AV20ProfesionalesPrimerNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV80ProfesionalesEsRUT2, AV81BancoNombre2, AV24ProfesionalesPrimerNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV82ProfesionalesEsRUT3, AV83BancoNombre3, AV28ProfesionalesPrimerNombre3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV35ColumnsSelector, AV84Pgmname, AV41TFProfesionalesId, AV42TFProfesionalesId_Sel, AV43TFProfesionalesPrimerNombre, AV44TFProfesionalesPrimerNombre_Sel, AV45TFProfesionalesSegundoNombre, AV46TFProfesionalesSegundoNombre_Sel, AV47TFProfesionalesApellidoPrimero, AV48TFProfesionalesApellidoPrimero_Sel, AV49TFProfesionalesApellidoSegundo, AV50TFProfesionalesApellidoSegundo_Sel, AV51TFProfesionalesTelefono, AV52TFProfesionalesTelefono_Sel, AV53TFProfesionalesEmail, AV54TFProfesionalesEmail_Sel, AV55TFProfesionalesDireccion, AV56TFProfesionalesDireccion_Sel, AV75TFEstadosGenericosNombre, AV76TFEstadosGenericosNombre_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV68IsAuthorized_Update, AV69IsAuthorized_Delete, AV77IsAuthorized_EstadosGenericosNombre) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV84Pgmname = "ProfesionalesWW";
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesEmail_Enabled = 0;
         edtProfesionalesDireccion_Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E276C2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV70AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV61DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV35ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_129 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_129"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
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
            AV78ProfesionalesEsRUT1 = StringUtil.StrToBool( cgiGet( chkavProfesionalesesrut1_Internalname));
            AssignAttri("", false, "AV78ProfesionalesEsRUT1", AV78ProfesionalesEsRUT1);
            AV79BancoNombre1 = cgiGet( edtavBanconombre1_Internalname);
            AssignAttri("", false, "AV79BancoNombre1", AV79BancoNombre1);
            AV20ProfesionalesPrimerNombre1 = cgiGet( edtavProfesionalesprimernombre1_Internalname);
            AssignAttri("", false, "AV20ProfesionalesPrimerNombre1", AV20ProfesionalesPrimerNombre1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV22DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AV80ProfesionalesEsRUT2 = StringUtil.StrToBool( cgiGet( chkavProfesionalesesrut2_Internalname));
            AssignAttri("", false, "AV80ProfesionalesEsRUT2", AV80ProfesionalesEsRUT2);
            AV81BancoNombre2 = cgiGet( edtavBanconombre2_Internalname);
            AssignAttri("", false, "AV81BancoNombre2", AV81BancoNombre2);
            AV24ProfesionalesPrimerNombre2 = cgiGet( edtavProfesionalesprimernombre2_Internalname);
            AssignAttri("", false, "AV24ProfesionalesPrimerNombre2", AV24ProfesionalesPrimerNombre2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV82ProfesionalesEsRUT3 = StringUtil.StrToBool( cgiGet( chkavProfesionalesesrut3_Internalname));
            AssignAttri("", false, "AV82ProfesionalesEsRUT3", AV82ProfesionalesEsRUT3);
            AV83BancoNombre3 = cgiGet( edtavBanconombre3_Internalname);
            AssignAttri("", false, "AV83BancoNombre3", AV83BancoNombre3);
            AV28ProfesionalesPrimerNombre3 = cgiGet( edtavProfesionalesprimernombre3_Internalname);
            AssignAttri("", false, "AV28ProfesionalesPrimerNombre3", AV28ProfesionalesPrimerNombre3);
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
            if ( StringUtil.StrToBool( cgiGet( "GXH_vPROFESIONALESESRUT1")) != AV78ProfesionalesEsRUT1 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vBANCONOMBRE1"), AV79BancoNombre1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE1"), AV20ProfesionalesPrimerNombre1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vPROFESIONALESESRUT2")) != AV80ProfesionalesEsRUT2 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vBANCONOMBRE2"), AV81BancoNombre2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE2"), AV24ProfesionalesPrimerNombre2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vPROFESIONALESESRUT3")) != AV82ProfesionalesEsRUT3 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vBANCONOMBRE3"), AV83BancoNombre3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPROFESIONALESPRIMERNOMBRE3"), AV28ProfesionalesPrimerNombre3) != 0 )
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
         E276C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E276C2( )
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
         AV18DynamicFiltersSelector1 = "PROFESIONALESESRUT";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersSelector2 = "PROFESIONALESESRUT";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "PROFESIONALESESRUT";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
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
         GXt_boolean1 = AV77IsAuthorized_EstadosGenericosNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion", out  GXt_boolean1) ;
         AV77IsAuthorized_EstadosGenericosNombre = GXt_boolean1;
         AssignAttri("", false, "AV77IsAuthorized_EstadosGenericosNombre", AV77IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( "", AV77IsAuthorized_EstadosGenericosNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Profesionales", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV61DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV61DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E286C2( )
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
         if ( AV40ManageFiltersExecutionStep == 1 )
         {
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV40ManageFiltersExecutionStep == 2 )
         {
            AV40ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "BANCONOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "BANCONOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            if ( AV25DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "BANCONOMBRE") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
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
         if ( StringUtil.StrCmp(AV37Session.Get("ProfesionalesWWColumnsSelector"), "") != 0 )
         {
            AV33ColumnsSelectorXML = AV37Session.Get("ProfesionalesWWColumnsSelector");
            AV35ColumnsSelector.FromXml(AV33ColumnsSelectorXML, null, "", "");
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
         edtProfesionalesId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProfesionalesPrimerNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProfesionalesSegundoNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesSegundoNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesSegundoNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProfesionalesApellidoPrimero_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProfesionalesApellidoSegundo_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesApellidoSegundo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoSegundo_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProfesionalesTelefono_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesTelefono_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesTelefono_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProfesionalesEmail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesEmail_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtProfesionalesDireccion_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProfesionalesDireccion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesDireccion_Visible), 5, 0), !bGXsfl_129_Refreshing);
         edtEstadosGenericosNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEstadosGenericosNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosNombre_Visible), 5, 0), !bGXsfl_129_Refreshing);
         AV63GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV63GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV63GridCurrentPage), 10, 0));
         AV64GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV64GridPageCount", StringUtil.LTrimStr( (decimal)(AV64GridPageCount), 10, 0));
         GXt_char3 = AV65GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV84Pgmname, out  GXt_char3) ;
         AV65GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV65GridAppliedFilters", AV65GridAppliedFilters);
         cmbavGridactions_Columnheaderclass = "WWActionGroupColumn";
         AssignProp("", false, cmbavGridactions_Internalname, "Columnheaderclass", cmbavGridactions_Columnheaderclass, !bGXsfl_129_Refreshing);
         edtProfesionalesId_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtProfesionalesId_Internalname, "Columnheaderclass", edtProfesionalesId_Columnheaderclass, !bGXsfl_129_Refreshing);
         edtProfesionalesPrimerNombre_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Columnheaderclass", edtProfesionalesPrimerNombre_Columnheaderclass, !bGXsfl_129_Refreshing);
         edtProfesionalesSegundoNombre_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtProfesionalesSegundoNombre_Internalname, "Columnheaderclass", edtProfesionalesSegundoNombre_Columnheaderclass, !bGXsfl_129_Refreshing);
         edtProfesionalesApellidoPrimero_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Columnheaderclass", edtProfesionalesApellidoPrimero_Columnheaderclass, !bGXsfl_129_Refreshing);
         edtProfesionalesApellidoSegundo_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtProfesionalesApellidoSegundo_Internalname, "Columnheaderclass", edtProfesionalesApellidoSegundo_Columnheaderclass, !bGXsfl_129_Refreshing);
         edtProfesionalesTelefono_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtProfesionalesTelefono_Internalname, "Columnheaderclass", edtProfesionalesTelefono_Columnheaderclass, !bGXsfl_129_Refreshing);
         edtProfesionalesEmail_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtProfesionalesEmail_Internalname, "Columnheaderclass", edtProfesionalesEmail_Columnheaderclass, !bGXsfl_129_Refreshing);
         edtProfesionalesDireccion_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtProfesionalesDireccion_Internalname, "Columnheaderclass", edtProfesionalesDireccion_Columnheaderclass, !bGXsfl_129_Refreshing);
         edtEstadosGenericosNombre_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtEstadosGenericosNombre_Internalname, "Columnheaderclass", edtEstadosGenericosNombre_Columnheaderclass, !bGXsfl_129_Refreshing);
         AV85Profesionaleswwds_1_filterfulltext = AV17FilterFullText;
         AV86Profesionaleswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV87Profesionaleswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV88Profesionaleswwds_4_profesionalesesrut1 = AV78ProfesionalesEsRUT1;
         AV89Profesionaleswwds_5_banconombre1 = AV79BancoNombre1;
         AV90Profesionaleswwds_6_profesionalesprimernombre1 = AV20ProfesionalesPrimerNombre1;
         AV91Profesionaleswwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV92Profesionaleswwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV93Profesionaleswwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV94Profesionaleswwds_10_profesionalesesrut2 = AV80ProfesionalesEsRUT2;
         AV95Profesionaleswwds_11_banconombre2 = AV81BancoNombre2;
         AV96Profesionaleswwds_12_profesionalesprimernombre2 = AV24ProfesionalesPrimerNombre2;
         AV97Profesionaleswwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV98Profesionaleswwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV99Profesionaleswwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV100Profesionaleswwds_16_profesionalesesrut3 = AV82ProfesionalesEsRUT3;
         AV101Profesionaleswwds_17_banconombre3 = AV83BancoNombre3;
         AV102Profesionaleswwds_18_profesionalesprimernombre3 = AV28ProfesionalesPrimerNombre3;
         AV103Profesionaleswwds_19_tfprofesionalesid = AV41TFProfesionalesId;
         AV104Profesionaleswwds_20_tfprofesionalesid_sel = AV42TFProfesionalesId_Sel;
         AV105Profesionaleswwds_21_tfprofesionalesprimernombre = AV43TFProfesionalesPrimerNombre;
         AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV44TFProfesionalesPrimerNombre_Sel;
         AV107Profesionaleswwds_23_tfprofesionalessegundonombre = AV45TFProfesionalesSegundoNombre;
         AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV46TFProfesionalesSegundoNombre_Sel;
         AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV47TFProfesionalesApellidoPrimero;
         AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV48TFProfesionalesApellidoPrimero_Sel;
         AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV49TFProfesionalesApellidoSegundo;
         AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV50TFProfesionalesApellidoSegundo_Sel;
         AV113Profesionaleswwds_29_tfprofesionalestelefono = AV51TFProfesionalesTelefono;
         AV114Profesionaleswwds_30_tfprofesionalestelefono_sel = AV52TFProfesionalesTelefono_Sel;
         AV115Profesionaleswwds_31_tfprofesionalesemail = AV53TFProfesionalesEmail;
         AV116Profesionaleswwds_32_tfprofesionalesemail_sel = AV54TFProfesionalesEmail_Sel;
         AV117Profesionaleswwds_33_tfprofesionalesdireccion = AV55TFProfesionalesDireccion;
         AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV56TFProfesionalesDireccion_Sel;
         AV119Profesionaleswwds_35_tfestadosgenericosnombre = AV75TFEstadosGenericosNombre;
         AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV76TFEstadosGenericosNombre_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E126C2( )
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
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E136C2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E166C2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesId") == 0 )
            {
               AV41TFProfesionalesId = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFProfesionalesId", AV41TFProfesionalesId);
               AV42TFProfesionalesId_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFProfesionalesId_Sel", AV42TFProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesPrimerNombre") == 0 )
            {
               AV43TFProfesionalesPrimerNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFProfesionalesPrimerNombre", AV43TFProfesionalesPrimerNombre);
               AV44TFProfesionalesPrimerNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFProfesionalesPrimerNombre_Sel", AV44TFProfesionalesPrimerNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesSegundoNombre") == 0 )
            {
               AV45TFProfesionalesSegundoNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV45TFProfesionalesSegundoNombre", AV45TFProfesionalesSegundoNombre);
               AV46TFProfesionalesSegundoNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFProfesionalesSegundoNombre_Sel", AV46TFProfesionalesSegundoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesApellidoPrimero") == 0 )
            {
               AV47TFProfesionalesApellidoPrimero = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV47TFProfesionalesApellidoPrimero", AV47TFProfesionalesApellidoPrimero);
               AV48TFProfesionalesApellidoPrimero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV48TFProfesionalesApellidoPrimero_Sel", AV48TFProfesionalesApellidoPrimero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesApellidoSegundo") == 0 )
            {
               AV49TFProfesionalesApellidoSegundo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV49TFProfesionalesApellidoSegundo", AV49TFProfesionalesApellidoSegundo);
               AV50TFProfesionalesApellidoSegundo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV50TFProfesionalesApellidoSegundo_Sel", AV50TFProfesionalesApellidoSegundo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesTelefono") == 0 )
            {
               AV51TFProfesionalesTelefono = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV51TFProfesionalesTelefono", AV51TFProfesionalesTelefono);
               AV52TFProfesionalesTelefono_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV52TFProfesionalesTelefono_Sel", AV52TFProfesionalesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesEmail") == 0 )
            {
               AV53TFProfesionalesEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV53TFProfesionalesEmail", AV53TFProfesionalesEmail);
               AV54TFProfesionalesEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV54TFProfesionalesEmail_Sel", AV54TFProfesionalesEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesDireccion") == 0 )
            {
               AV55TFProfesionalesDireccion = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV55TFProfesionalesDireccion", AV55TFProfesionalesDireccion);
               AV56TFProfesionalesDireccion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV56TFProfesionalesDireccion_Sel", AV56TFProfesionalesDireccion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosGenericosNombre") == 0 )
            {
               AV75TFEstadosGenericosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV75TFEstadosGenericosNombre", AV75TFEstadosGenericosNombre);
               AV76TFEstadosGenericosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV76TFEstadosGenericosNombre_Sel", AV76TFEstadosGenericosNombre_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E296C2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         if ( AV68IsAuthorized_Update )
         {
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV69IsAuthorized_Delete )
         {
            cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         if ( AV77IsAuthorized_EstadosGenericosNombre )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(A107EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A108EstadosGenericosId,5,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtEstadosGenericosNombre_Link = formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( A108EstadosGenericosId == 2 )
         {
            cmbavGridactions_Columnclass = "WWActionGroupColumn WWColumnDanger WWColumnDangerFirstColumn";
            edtProfesionalesId_Columnclass = "WWColumn WWColumnDanger";
            edtProfesionalesPrimerNombre_Columnclass = "WWColumn WWColumnDanger hidden-xs";
            edtProfesionalesSegundoNombre_Columnclass = "WWColumn WWColumnDanger";
            edtProfesionalesApellidoPrimero_Columnclass = "WWColumn WWColumnDanger";
            edtProfesionalesApellidoSegundo_Columnclass = "WWColumn WWColumnDanger";
            edtProfesionalesTelefono_Columnclass = "WWColumn WWColumnDanger";
            edtProfesionalesEmail_Columnclass = "WWColumn WWColumnDanger";
            edtProfesionalesDireccion_Columnclass = "WWColumn WWColumnDanger";
            edtEstadosGenericosNombre_Columnclass = "WWColumn WWColumnDanger";
         }
         else if ( A108EstadosGenericosId == 3 )
         {
            cmbavGridactions_Columnclass = "WWActionGroupColumn WWColumnWarning WWColumnWarningFirstColumn";
            edtProfesionalesId_Columnclass = "WWColumn WWColumnWarning";
            edtProfesionalesPrimerNombre_Columnclass = "WWColumn WWColumnWarning hidden-xs";
            edtProfesionalesSegundoNombre_Columnclass = "WWColumn WWColumnWarning";
            edtProfesionalesApellidoPrimero_Columnclass = "WWColumn WWColumnWarning";
            edtProfesionalesApellidoSegundo_Columnclass = "WWColumn WWColumnWarning";
            edtProfesionalesTelefono_Columnclass = "WWColumn WWColumnWarning";
            edtProfesionalesEmail_Columnclass = "WWColumn WWColumnWarning";
            edtProfesionalesDireccion_Columnclass = "WWColumn WWColumnWarning";
            edtEstadosGenericosNombre_Columnclass = "WWColumn WWColumnWarning";
         }
         else
         {
            cmbavGridactions_Columnclass = "WWActionGroupColumn";
            edtProfesionalesId_Columnclass = "WWColumn";
            edtProfesionalesPrimerNombre_Columnclass = "WWColumn hidden-xs";
            edtProfesionalesSegundoNombre_Columnclass = "WWColumn";
            edtProfesionalesApellidoPrimero_Columnclass = "WWColumn";
            edtProfesionalesApellidoSegundo_Columnclass = "WWColumn";
            edtProfesionalesTelefono_Columnclass = "WWColumn";
            edtProfesionalesEmail_Columnclass = "WWColumn";
            edtProfesionalesDireccion_Columnclass = "WWColumn";
            edtEstadosGenericosNombre_Columnclass = "WWColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 129;
         }
         sendrow_1292( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_129_Refreshing )
         {
            context.DoAjaxLoad(129, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0));
      }

      protected void E176C2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV33ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV35ColumnsSelector.FromJSonString(AV33ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "ProfesionalesWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV33ColumnsSelectorXML)) ? "" : AV35ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E226C2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E186C2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV78ProfesionalesEsRUT1, AV79BancoNombre1, AV20ProfesionalesPrimerNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV80ProfesionalesEsRUT2, AV81BancoNombre2, AV24ProfesionalesPrimerNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV82ProfesionalesEsRUT3, AV83BancoNombre3, AV28ProfesionalesPrimerNombre3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV35ColumnsSelector, AV84Pgmname, AV41TFProfesionalesId, AV42TFProfesionalesId_Sel, AV43TFProfesionalesPrimerNombre, AV44TFProfesionalesPrimerNombre_Sel, AV45TFProfesionalesSegundoNombre, AV46TFProfesionalesSegundoNombre_Sel, AV47TFProfesionalesApellidoPrimero, AV48TFProfesionalesApellidoPrimero_Sel, AV49TFProfesionalesApellidoSegundo, AV50TFProfesionalesApellidoSegundo_Sel, AV51TFProfesionalesTelefono, AV52TFProfesionalesTelefono_Sel, AV53TFProfesionalesEmail, AV54TFProfesionalesEmail_Sel, AV55TFProfesionalesDireccion, AV56TFProfesionalesDireccion_Sel, AV75TFEstadosGenericosNombre, AV76TFEstadosGenericosNombre_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV68IsAuthorized_Update, AV69IsAuthorized_Delete, AV77IsAuthorized_EstadosGenericosNombre) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E236C2( )
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

      protected void E246C2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E196C2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV78ProfesionalesEsRUT1, AV79BancoNombre1, AV20ProfesionalesPrimerNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV80ProfesionalesEsRUT2, AV81BancoNombre2, AV24ProfesionalesPrimerNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV82ProfesionalesEsRUT3, AV83BancoNombre3, AV28ProfesionalesPrimerNombre3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV35ColumnsSelector, AV84Pgmname, AV41TFProfesionalesId, AV42TFProfesionalesId_Sel, AV43TFProfesionalesPrimerNombre, AV44TFProfesionalesPrimerNombre_Sel, AV45TFProfesionalesSegundoNombre, AV46TFProfesionalesSegundoNombre_Sel, AV47TFProfesionalesApellidoPrimero, AV48TFProfesionalesApellidoPrimero_Sel, AV49TFProfesionalesApellidoSegundo, AV50TFProfesionalesApellidoSegundo_Sel, AV51TFProfesionalesTelefono, AV52TFProfesionalesTelefono_Sel, AV53TFProfesionalesEmail, AV54TFProfesionalesEmail_Sel, AV55TFProfesionalesDireccion, AV56TFProfesionalesDireccion_Sel, AV75TFEstadosGenericosNombre, AV76TFEstadosGenericosNombre_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV68IsAuthorized_Update, AV69IsAuthorized_Delete, AV77IsAuthorized_EstadosGenericosNombre) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E256C2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E206C2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV78ProfesionalesEsRUT1, AV79BancoNombre1, AV20ProfesionalesPrimerNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV80ProfesionalesEsRUT2, AV81BancoNombre2, AV24ProfesionalesPrimerNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV82ProfesionalesEsRUT3, AV83BancoNombre3, AV28ProfesionalesPrimerNombre3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV35ColumnsSelector, AV84Pgmname, AV41TFProfesionalesId, AV42TFProfesionalesId_Sel, AV43TFProfesionalesPrimerNombre, AV44TFProfesionalesPrimerNombre_Sel, AV45TFProfesionalesSegundoNombre, AV46TFProfesionalesSegundoNombre_Sel, AV47TFProfesionalesApellidoPrimero, AV48TFProfesionalesApellidoPrimero_Sel, AV49TFProfesionalesApellidoSegundo, AV50TFProfesionalesApellidoSegundo_Sel, AV51TFProfesionalesTelefono, AV52TFProfesionalesTelefono_Sel, AV53TFProfesionalesEmail, AV54TFProfesionalesEmail_Sel, AV55TFProfesionalesDireccion, AV56TFProfesionalesDireccion_Sel, AV75TFEstadosGenericosNombre, AV76TFEstadosGenericosNombre_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV68IsAuthorized_Update, AV69IsAuthorized_Delete, AV77IsAuthorized_EstadosGenericosNombre) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E266C2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E116C2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("ProfesionalesWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV84Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("ProfesionalesWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ProfesionalesWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV39ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV84Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV11GridState.FromXml(AV39ManageFiltersXml, null, "", "");
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E306C2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV66GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV66GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
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
      }

      protected void E216C2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E146C2( )
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E156C2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0154",(string)"",(string)"Profesionales",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0154"+"");
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
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "ProfesionalesId",  "",  "Identidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "ProfesionalesPrimerNombre",  "",  "Primer Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "ProfesionalesSegundoNombre",  "",  "Segundo Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "ProfesionalesApellidoPrimero",  "",  "Primer Apellido ",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "ProfesionalesApellidoSegundo",  "",  "Segundo Apellido ",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "ProfesionalesTelefono",  "",  "Teléfono",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "ProfesionalesEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "ProfesionalesDireccion",  "",  "Dirección",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "EstadosGenericosNombre",  "",  "Estado",  true,  "") ;
         GXt_char3 = AV34UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ProfesionalesWWColumnsSelector", out  GXt_char3) ;
         AV34UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34UserCustomValue)) ) )
         {
            AV36ColumnsSelectorAux.FromXml(AV34UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV36ColumnsSelectorAux, ref  AV35ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV68IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Update", out  GXt_boolean1) ;
         AV68IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV68IsAuthorized_Update", AV68IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV68IsAuthorized_Update, context));
         GXt_boolean1 = AV69IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Delete", out  GXt_boolean1) ;
         AV69IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV69IsAuthorized_Delete", AV69IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV69IsAuthorized_Delete, context));
         GXt_boolean1 = AV72TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Insert", out  GXt_boolean1) ;
         AV72TempBoolean = GXt_boolean1;
         if ( ! ( AV72TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV72TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean1) ;
         AV72TempBoolean = GXt_boolean1;
         if ( ! ( AV72TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Profesionales",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         chkavProfesionalesesrut1.Visible = 0;
         AssignProp("", false, chkavProfesionalesesrut1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavProfesionalesesrut1.Visible), 5, 0), true);
         edtavBanconombre1_Visible = 0;
         AssignProp("", false, edtavBanconombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBanconombre1_Visible), 5, 0), true);
         edtavProfesionalesprimernombre1_Visible = 0;
         AssignProp("", false, edtavProfesionalesprimernombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesionalesprimernombre1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFESIONALESESRUT") == 0 )
         {
            chkavProfesionalesesrut1.Visible = 1;
            AssignProp("", false, chkavProfesionalesesrut1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavProfesionalesesrut1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "BANCONOMBRE") == 0 )
         {
            edtavBanconombre1_Visible = 1;
            AssignProp("", false, edtavBanconombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBanconombre1_Visible), 5, 0), true);
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
         chkavProfesionalesesrut2.Visible = 0;
         AssignProp("", false, chkavProfesionalesesrut2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavProfesionalesesrut2.Visible), 5, 0), true);
         edtavBanconombre2_Visible = 0;
         AssignProp("", false, edtavBanconombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBanconombre2_Visible), 5, 0), true);
         edtavProfesionalesprimernombre2_Visible = 0;
         AssignProp("", false, edtavProfesionalesprimernombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesionalesprimernombre2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROFESIONALESESRUT") == 0 )
         {
            chkavProfesionalesesrut2.Visible = 1;
            AssignProp("", false, chkavProfesionalesesrut2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavProfesionalesesrut2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "BANCONOMBRE") == 0 )
         {
            edtavBanconombre2_Visible = 1;
            AssignProp("", false, edtavBanconombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBanconombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
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
         chkavProfesionalesesrut3.Visible = 0;
         AssignProp("", false, chkavProfesionalesesrut3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavProfesionalesesrut3.Visible), 5, 0), true);
         edtavBanconombre3_Visible = 0;
         AssignProp("", false, edtavBanconombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBanconombre3_Visible), 5, 0), true);
         edtavProfesionalesprimernombre3_Visible = 0;
         AssignProp("", false, edtavProfesionalesprimernombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProfesionalesprimernombre3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PROFESIONALESESRUT") == 0 )
         {
            chkavProfesionalesesrut3.Visible = 1;
            AssignProp("", false, chkavProfesionalesesrut3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavProfesionalesesrut3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "BANCONOMBRE") == 0 )
         {
            edtavBanconombre3_Visible = 1;
            AssignProp("", false, edtavBanconombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBanconombre3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
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
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         AV22DynamicFiltersSelector2 = "PROFESIONALESESRUT";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV80ProfesionalesEsRUT2 = false;
         AssignAttri("", false, "AV80ProfesionalesEsRUT2", AV80ProfesionalesEsRUT2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "PROFESIONALESESRUT";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV82ProfesionalesEsRUT3 = false;
         AssignAttri("", false, "AV82ProfesionalesEsRUT3", AV82ProfesionalesEsRUT3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ProfesionalesWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV41TFProfesionalesId = "";
         AssignAttri("", false, "AV41TFProfesionalesId", AV41TFProfesionalesId);
         AV42TFProfesionalesId_Sel = "";
         AssignAttri("", false, "AV42TFProfesionalesId_Sel", AV42TFProfesionalesId_Sel);
         AV43TFProfesionalesPrimerNombre = "";
         AssignAttri("", false, "AV43TFProfesionalesPrimerNombre", AV43TFProfesionalesPrimerNombre);
         AV44TFProfesionalesPrimerNombre_Sel = "";
         AssignAttri("", false, "AV44TFProfesionalesPrimerNombre_Sel", AV44TFProfesionalesPrimerNombre_Sel);
         AV45TFProfesionalesSegundoNombre = "";
         AssignAttri("", false, "AV45TFProfesionalesSegundoNombre", AV45TFProfesionalesSegundoNombre);
         AV46TFProfesionalesSegundoNombre_Sel = "";
         AssignAttri("", false, "AV46TFProfesionalesSegundoNombre_Sel", AV46TFProfesionalesSegundoNombre_Sel);
         AV47TFProfesionalesApellidoPrimero = "";
         AssignAttri("", false, "AV47TFProfesionalesApellidoPrimero", AV47TFProfesionalesApellidoPrimero);
         AV48TFProfesionalesApellidoPrimero_Sel = "";
         AssignAttri("", false, "AV48TFProfesionalesApellidoPrimero_Sel", AV48TFProfesionalesApellidoPrimero_Sel);
         AV49TFProfesionalesApellidoSegundo = "";
         AssignAttri("", false, "AV49TFProfesionalesApellidoSegundo", AV49TFProfesionalesApellidoSegundo);
         AV50TFProfesionalesApellidoSegundo_Sel = "";
         AssignAttri("", false, "AV50TFProfesionalesApellidoSegundo_Sel", AV50TFProfesionalesApellidoSegundo_Sel);
         AV51TFProfesionalesTelefono = "";
         AssignAttri("", false, "AV51TFProfesionalesTelefono", AV51TFProfesionalesTelefono);
         AV52TFProfesionalesTelefono_Sel = "";
         AssignAttri("", false, "AV52TFProfesionalesTelefono_Sel", AV52TFProfesionalesTelefono_Sel);
         AV53TFProfesionalesEmail = "";
         AssignAttri("", false, "AV53TFProfesionalesEmail", AV53TFProfesionalesEmail);
         AV54TFProfesionalesEmail_Sel = "";
         AssignAttri("", false, "AV54TFProfesionalesEmail_Sel", AV54TFProfesionalesEmail_Sel);
         AV55TFProfesionalesDireccion = "";
         AssignAttri("", false, "AV55TFProfesionalesDireccion", AV55TFProfesionalesDireccion);
         AV56TFProfesionalesDireccion_Sel = "";
         AssignAttri("", false, "AV56TFProfesionalesDireccion_Sel", AV56TFProfesionalesDireccion_Sel);
         AV75TFEstadosGenericosNombre = "";
         AssignAttri("", false, "AV75TFEstadosGenericosNombre", AV75TFEstadosGenericosNombre);
         AV76TFEstadosGenericosNombre_Sel = "";
         AssignAttri("", false, "AV76TFEstadosGenericosNombre_Sel", AV76TFEstadosGenericosNombre_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV18DynamicFiltersSelector1 = "PROFESIONALESESRUT";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV78ProfesionalesEsRUT1 = false;
         AssignAttri("", false, "AV78ProfesionalesEsRUT1", AV78ProfesionalesEsRUT1);
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
         CallWebObject(formatLink("profesionalesview.aspx", new object[] {UrlEncode(StringUtil.RTrim(A120ProfesionalesId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ProfesionalesId","TabCode"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
         CallWebObject(formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
         CallWebObject(formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get(AV84Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV84Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV37Session.Get(AV84Pgmname+"GridState"), null, "", "");
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
         AV121GXV1 = 1;
         while ( AV121GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV121GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV41TFProfesionalesId = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFProfesionalesId", AV41TFProfesionalesId);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV42TFProfesionalesId_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFProfesionalesId_Sel", AV42TFProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV43TFProfesionalesPrimerNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFProfesionalesPrimerNombre", AV43TFProfesionalesPrimerNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV44TFProfesionalesPrimerNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFProfesionalesPrimerNombre_Sel", AV44TFProfesionalesPrimerNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV45TFProfesionalesSegundoNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFProfesionalesSegundoNombre", AV45TFProfesionalesSegundoNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV46TFProfesionalesSegundoNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFProfesionalesSegundoNombre_Sel", AV46TFProfesionalesSegundoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV47TFProfesionalesApellidoPrimero = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFProfesionalesApellidoPrimero", AV47TFProfesionalesApellidoPrimero);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV48TFProfesionalesApellidoPrimero_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFProfesionalesApellidoPrimero_Sel", AV48TFProfesionalesApellidoPrimero_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV49TFProfesionalesApellidoSegundo = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFProfesionalesApellidoSegundo", AV49TFProfesionalesApellidoSegundo);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV50TFProfesionalesApellidoSegundo_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFProfesionalesApellidoSegundo_Sel", AV50TFProfesionalesApellidoSegundo_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV51TFProfesionalesTelefono = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFProfesionalesTelefono", AV51TFProfesionalesTelefono);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV52TFProfesionalesTelefono_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFProfesionalesTelefono_Sel", AV52TFProfesionalesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL") == 0 )
            {
               AV53TFProfesionalesEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFProfesionalesEmail", AV53TFProfesionalesEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL_SEL") == 0 )
            {
               AV54TFProfesionalesEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFProfesionalesEmail_Sel", AV54TFProfesionalesEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESDIRECCION") == 0 )
            {
               AV55TFProfesionalesDireccion = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFProfesionalesDireccion", AV55TFProfesionalesDireccion);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESDIRECCION_SEL") == 0 )
            {
               AV56TFProfesionalesDireccion_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFProfesionalesDireccion_Sel", AV56TFProfesionalesDireccion_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV75TFEstadosGenericosNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV75TFEstadosGenericosNombre", AV75TFEstadosGenericosNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV76TFEstadosGenericosNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV76TFEstadosGenericosNombre_Sel", AV76TFEstadosGenericosNombre_Sel);
            }
            AV121GXV1 = (int)(AV121GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProfesionalesId_Sel)),  AV42TFProfesionalesId_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFProfesionalesPrimerNombre_Sel)),  AV44TFProfesionalesPrimerNombre_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFProfesionalesSegundoNombre_Sel)),  AV46TFProfesionalesSegundoNombre_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProfesionalesApellidoPrimero_Sel)),  AV48TFProfesionalesApellidoPrimero_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProfesionalesApellidoSegundo_Sel)),  AV50TFProfesionalesApellidoSegundo_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProfesionalesTelefono_Sel)),  AV52TFProfesionalesTelefono_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProfesionalesEmail_Sel)),  AV54TFProfesionalesEmail_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFProfesionalesDireccion_Sel)),  AV56TFProfesionalesDireccion_Sel, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV76TFEstadosGenericosNombre_Sel)),  AV76TFEstadosGenericosNombre_Sel, out  GXt_char12) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|"+GXt_char12;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProfesionalesId)),  AV41TFProfesionalesId, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProfesionalesPrimerNombre)),  AV43TFProfesionalesPrimerNombre, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProfesionalesSegundoNombre)),  AV45TFProfesionalesSegundoNombre, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFProfesionalesApellidoPrimero)),  AV47TFProfesionalesApellidoPrimero, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProfesionalesApellidoSegundo)),  AV49TFProfesionalesApellidoSegundo, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProfesionalesTelefono)),  AV51TFProfesionalesTelefono, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProfesionalesEmail)),  AV53TFProfesionalesEmail, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProfesionalesDireccion)),  AV55TFProfesionalesDireccion, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFEstadosGenericosNombre)),  AV75TFEstadosGenericosNombre, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char12+"|"+GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFESIONALESESRUT") == 0 )
            {
               AV78ProfesionalesEsRUT1 = BooleanUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value);
               AssignAttri("", false, "AV78ProfesionalesEsRUT1", AV78ProfesionalesEsRUT1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "BANCONOMBRE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV79BancoNombre1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV79BancoNombre1", AV79BancoNombre1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20ProfesionalesPrimerNombre1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20ProfesionalesPrimerNombre1", AV20ProfesionalesPrimerNombre1);
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
               AV21DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROFESIONALESESRUT") == 0 )
               {
                  AV80ProfesionalesEsRUT2 = BooleanUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value);
                  AssignAttri("", false, "AV80ProfesionalesEsRUT2", AV80ProfesionalesEsRUT2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "BANCONOMBRE") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV81BancoNombre2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV81BancoNombre2", AV81BancoNombre2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24ProfesionalesPrimerNombre2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24ProfesionalesPrimerNombre2", AV24ProfesionalesPrimerNombre2);
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
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PROFESIONALESESRUT") == 0 )
                  {
                     AV82ProfesionalesEsRUT3 = BooleanUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value);
                     AssignAttri("", false, "AV82ProfesionalesEsRUT3", AV82ProfesionalesEsRUT3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "BANCONOMBRE") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV83BancoNombre3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV83BancoNombre3", AV83BancoNombre3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28ProfesionalesPrimerNombre3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28ProfesionalesPrimerNombre3", AV28ProfesionalesPrimerNombre3);
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
         if ( AV29DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV37Session.Get(AV84Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESID",  context.GetMessage( "Identidad", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProfesionalesId)),  0,  AV41TFProfesionalesId,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProfesionalesId_Sel)),  AV42TFProfesionalesId_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESPRIMERNOMBRE",  context.GetMessage( "Primer Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProfesionalesPrimerNombre)),  0,  AV43TFProfesionalesPrimerNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFProfesionalesPrimerNombre_Sel)),  AV44TFProfesionalesPrimerNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESSEGUNDONOMBRE",  context.GetMessage( "Segundo Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProfesionalesSegundoNombre)),  0,  AV45TFProfesionalesSegundoNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFProfesionalesSegundoNombre_Sel)),  AV46TFProfesionalesSegundoNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESAPELLIDOPRIMERO",  context.GetMessage( "Primer Apellido ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFProfesionalesApellidoPrimero)),  0,  AV47TFProfesionalesApellidoPrimero,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProfesionalesApellidoPrimero_Sel)),  AV48TFProfesionalesApellidoPrimero_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESAPELLIDOSEGUNDO",  context.GetMessage( "Segundo Apellido ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProfesionalesApellidoSegundo)),  0,  AV49TFProfesionalesApellidoSegundo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProfesionalesApellidoSegundo_Sel)),  AV50TFProfesionalesApellidoSegundo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESTELEFONO",  context.GetMessage( "Teléfono", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProfesionalesTelefono)),  0,  AV51TFProfesionalesTelefono,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProfesionalesTelefono_Sel)),  AV52TFProfesionalesTelefono_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESEMAIL",  context.GetMessage( "Email", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProfesionalesEmail)),  0,  AV53TFProfesionalesEmail,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProfesionalesEmail_Sel)),  AV54TFProfesionalesEmail_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROFESIONALESDIRECCION",  context.GetMessage( "Dirección", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProfesionalesDireccion)),  0,  AV55TFProfesionalesDireccion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFProfesionalesDireccion_Sel)),  AV56TFProfesionalesDireccion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFESTADOSGENERICOSNOMBRE",  context.GetMessage( "Estado", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFEstadosGenericosNombre)),  0,  AV75TFEstadosGenericosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV76TFEstadosGenericosNombre_Sel)),  AV76TFEstadosGenericosNombre_Sel,  "") ;
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
         if ( ! AV30DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFESIONALESESRUT") == 0 ) && ! (false==AV78ProfesionalesEsRUT1) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "El Documento es RUT", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.BoolToStr( AV78ProfesionalesEsRUT1);
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "BANCONOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV79BancoNombre1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Nombre del Banco", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV79BancoNombre1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ProfesionalesPrimerNombre1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Primer Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV20ProfesionalesPrimerNombre1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROFESIONALESESRUT") == 0 ) && ! (false==AV80ProfesionalesEsRUT2) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "El Documento es RUT", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.BoolToStr( AV80ProfesionalesEsRUT2);
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "BANCONOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV81BancoNombre2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Nombre del Banco", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV81BancoNombre2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV23DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ProfesionalesPrimerNombre2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Primer Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV24ProfesionalesPrimerNombre2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV23DynamicFiltersOperator2;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV25DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV26DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PROFESIONALESESRUT") == 0 ) && ! (false==AV82ProfesionalesEsRUT3) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "El Documento es RUT", "");
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.BoolToStr( AV82ProfesionalesEsRUT3);
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "BANCONOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV83BancoNombre3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Nombre del Banco", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV83BancoNombre3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV27DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ProfesionalesPrimerNombre3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Primer Nombre", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV28ProfesionalesPrimerNombre3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV27DynamicFiltersOperator3;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
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
         AV9TrnContext.gxTpr_Callerobject = AV84Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Profesionales";
         AV37Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         new profesionaleswwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
         if ( StringUtil.StrCmp(AV31ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV31ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV32ErrorMessage);
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
         Innewwindow1_Target = formatLink("profesionaleswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_105_6C2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "", true, 0, "HLP_ProfesionalesWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profesionalesesrut3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavProfesionalesesrut3_Internalname, context.GetMessage( "Profesionales Es RUT3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_129_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavProfesionalesesrut3_Internalname, StringUtil.BoolToStr( AV82ProfesionalesEsRUT3), "", context.GetMessage( "Profesionales Es RUT3", ""), chkavProfesionalesesrut3.Visible, chkavProfesionalesesrut3.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(112, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,112);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_banconombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBanconombre3_Internalname, context.GetMessage( "Banco Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBanconombre3_Internalname, StringUtil.RTrim( AV83BancoNombre3), StringUtil.RTrim( context.localUtil.Format( AV83BancoNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBanconombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavBanconombre3_Visible, edtavBanconombre3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profesionalesprimernombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProfesionalesprimernombre3_Internalname, context.GetMessage( "Profesionales Primer Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProfesionalesprimernombre3_Internalname, StringUtil.RTrim( AV28ProfesionalesPrimerNombre3), StringUtil.RTrim( context.localUtil.Format( AV28ProfesionalesPrimerNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProfesionalesprimernombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavProfesionalesprimernombre3_Visible, edtavProfesionalesprimernombre3_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_105_6C2e( true) ;
         }
         else
         {
            wb_table4_105_6C2e( false) ;
         }
      }

      protected void wb_table3_77_6C2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", true, 0, "HLP_ProfesionalesWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profesionalesesrut2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavProfesionalesesrut2_Internalname, context.GetMessage( "Profesionales Es RUT2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_129_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavProfesionalesesrut2_Internalname, StringUtil.BoolToStr( AV80ProfesionalesEsRUT2), "", context.GetMessage( "Profesionales Es RUT2", ""), chkavProfesionalesesrut2.Visible, chkavProfesionalesesrut2.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(84, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,84);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_banconombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBanconombre2_Internalname, context.GetMessage( "Banco Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBanconombre2_Internalname, StringUtil.RTrim( AV81BancoNombre2), StringUtil.RTrim( context.localUtil.Format( AV81BancoNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBanconombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavBanconombre2_Visible, edtavBanconombre2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profesionalesprimernombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProfesionalesprimernombre2_Internalname, context.GetMessage( "Profesionales Primer Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProfesionalesprimernombre2_Internalname, StringUtil.RTrim( AV24ProfesionalesPrimerNombre2), StringUtil.RTrim( context.localUtil.Format( AV24ProfesionalesPrimerNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProfesionalesprimernombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavProfesionalesprimernombre2_Visible, edtavProfesionalesprimernombre2_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_77_6C2e( true) ;
         }
         else
         {
            wb_table3_77_6C2e( false) ;
         }
      }

      protected void wb_table2_49_6C2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_ProfesionalesWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profesionalesesrut1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavProfesionalesesrut1_Internalname, context.GetMessage( "Profesionales Es RUT1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_129_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavProfesionalesesrut1_Internalname, StringUtil.BoolToStr( AV78ProfesionalesEsRUT1), "", context.GetMessage( "Profesionales Es RUT1", ""), chkavProfesionalesesrut1.Visible, chkavProfesionalesesrut1.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_banconombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBanconombre1_Internalname, context.GetMessage( "Banco Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBanconombre1_Internalname, StringUtil.RTrim( AV79BancoNombre1), StringUtil.RTrim( context.localUtil.Format( AV79BancoNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBanconombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavBanconombre1_Visible, edtavBanconombre1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_profesionalesprimernombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProfesionalesprimernombre1_Internalname, context.GetMessage( "Profesionales Primer Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_129_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProfesionalesprimernombre1_Internalname, StringUtil.RTrim( AV20ProfesionalesPrimerNombre1), StringUtil.RTrim( context.localUtil.Format( AV20ProfesionalesPrimerNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProfesionalesprimernombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavProfesionalesprimernombre1_Visible, edtavProfesionalesprimernombre1_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_6C2e( true) ;
         }
         else
         {
            wb_table2_49_6C2e( false) ;
         }
      }

      protected void wb_table1_25_6C2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV38ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_30_6C2( true) ;
         }
         else
         {
            wb_table5_30_6C2( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_6C2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_6C2e( true) ;
         }
         else
         {
            wb_table1_25_6C2e( false) ;
         }
      }

      protected void wb_table5_30_6C2( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ProfesionalesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_6C2e( true) ;
         }
         else
         {
            wb_table5_30_6C2e( false) ;
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
         PA6C2( ) ;
         WS6C2( ) ;
         WE6C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320152412", true, true, false);
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
         context.AddJavascriptSource("profesionalesww.js", "?20269320152413", false, true, false);
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
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_129_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_129_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_129_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_129_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_129_idx;
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO_"+sGXsfl_129_idx;
         edtProfesionalesEmail_Internalname = "PROFESIONALESEMAIL_"+sGXsfl_129_idx;
         edtProfesionalesDireccion_Internalname = "PROFESIONALESDIRECCION_"+sGXsfl_129_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_129_idx;
      }

      protected void SubsflControlProps_fel_1292( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_129_fel_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_129_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE_"+sGXsfl_129_fel_idx;
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_129_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_129_fel_idx;
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_129_fel_idx;
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO_"+sGXsfl_129_fel_idx;
         edtProfesionalesEmail_Internalname = "PROFESIONALESEMAIL_"+sGXsfl_129_fel_idx;
         edtProfesionalesDireccion_Internalname = "PROFESIONALESDIRECCION_"+sGXsfl_129_fel_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_129_fel_idx;
      }

      protected void sendrow_1292( )
      {
         sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
         SubsflControlProps_1292( ) ;
         WB6C0( ) ;
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
                  AV66GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV66GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_129_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)cmbavGridactions_Columnclass,(string)cmbavGridactions_Columnheaderclass,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_129_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesId_Columnclass,(string)edtProfesionalesId_Columnheaderclass,(int)edtProfesionalesId_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesPrimerNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesPrimerNombre_Columnclass,(string)edtProfesionalesPrimerNombre_Columnheaderclass,(int)edtProfesionalesPrimerNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesSegundoNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesSegundoNombre_Internalname,StringUtil.RTrim( A191ProfesionalesSegundoNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesSegundoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesSegundoNombre_Columnclass,(string)edtProfesionalesSegundoNombre_Columnheaderclass,(int)edtProfesionalesSegundoNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesApellidoPrimero_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesApellidoPrimero_Columnclass,(string)edtProfesionalesApellidoPrimero_Columnheaderclass,(int)edtProfesionalesApellidoPrimero_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesApellidoSegundo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoSegundo_Internalname,StringUtil.RTrim( A192ProfesionalesApellidoSegundo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoSegundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesApellidoSegundo_Columnclass,(string)edtProfesionalesApellidoSegundo_Columnheaderclass,(int)edtProfesionalesApellidoSegundo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesTelefono_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesTelefono_Internalname,StringUtil.RTrim( A170ProfesionalesTelefono),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProfesionalesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesTelefono_Columnclass,(string)edtProfesionalesTelefono_Columnheaderclass,(int)edtProfesionalesTelefono_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesEmail_Internalname,(string)A193ProfesionalesEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A193ProfesionalesEmail,(string)"",(string)"",context.GetMessage( "email@correo.com", ""),(string)edtProfesionalesEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesEmail_Columnclass,(string)edtProfesionalesEmail_Columnheaderclass,(int)edtProfesionalesEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProfesionalesDireccion_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesDireccion_Internalname,(string)A198ProfesionalesDireccion,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A198ProfesionalesDireccion),(string)"_blank",(string)"",(string)"",(string)edtProfesionalesDireccion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtProfesionalesDireccion_Columnclass,(string)edtProfesionalesDireccion_Columnheaderclass,(int)edtProfesionalesDireccion_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEstadosGenericosNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosNombre_Internalname,StringUtil.RTrim( A109EstadosGenericosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtEstadosGenericosNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadosGenericosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtEstadosGenericosNombre_Columnclass,(string)edtEstadosGenericosNombre_Columnheaderclass,(int)edtEstadosGenericosNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes6C2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("PROFESIONALESESRUT", context.GetMessage( "El Documento es RUT", ""), 0);
         cmbavDynamicfiltersselector1.addItem("BANCONOMBRE", context.GetMessage( "Nombre del Banco", ""), 0);
         cmbavDynamicfiltersselector1.addItem("PROFESIONALESPRIMERNOMBRE", context.GetMessage( "Primer Nombre", ""), 0);
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
         chkavProfesionalesesrut1.Name = "vPROFESIONALESESRUT1";
         chkavProfesionalesesrut1.WebTags = "";
         chkavProfesionalesesrut1.Caption = context.GetMessage( "Profesionales Es RUT1", "");
         AssignProp("", false, chkavProfesionalesesrut1_Internalname, "TitleCaption", chkavProfesionalesesrut1.Caption, true);
         chkavProfesionalesesrut1.CheckedValue = "false";
         AV78ProfesionalesEsRUT1 = StringUtil.StrToBool( StringUtil.BoolToStr( AV78ProfesionalesEsRUT1));
         AssignAttri("", false, "AV78ProfesionalesEsRUT1", AV78ProfesionalesEsRUT1);
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("PROFESIONALESESRUT", context.GetMessage( "El Documento es RUT", ""), 0);
         cmbavDynamicfiltersselector2.addItem("BANCONOMBRE", context.GetMessage( "Nombre del Banco", ""), 0);
         cmbavDynamicfiltersselector2.addItem("PROFESIONALESPRIMERNOMBRE", context.GetMessage( "Primer Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         chkavProfesionalesesrut2.Name = "vPROFESIONALESESRUT2";
         chkavProfesionalesesrut2.WebTags = "";
         chkavProfesionalesesrut2.Caption = context.GetMessage( "Profesionales Es RUT2", "");
         AssignProp("", false, chkavProfesionalesesrut2_Internalname, "TitleCaption", chkavProfesionalesesrut2.Caption, true);
         chkavProfesionalesesrut2.CheckedValue = "false";
         AV80ProfesionalesEsRUT2 = StringUtil.StrToBool( StringUtil.BoolToStr( AV80ProfesionalesEsRUT2));
         AssignAttri("", false, "AV80ProfesionalesEsRUT2", AV80ProfesionalesEsRUT2);
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("PROFESIONALESESRUT", context.GetMessage( "El Documento es RUT", ""), 0);
         cmbavDynamicfiltersselector3.addItem("BANCONOMBRE", context.GetMessage( "Nombre del Banco", ""), 0);
         cmbavDynamicfiltersselector3.addItem("PROFESIONALESPRIMERNOMBRE", context.GetMessage( "Primer Nombre", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         chkavProfesionalesesrut3.Name = "vPROFESIONALESESRUT3";
         chkavProfesionalesesrut3.WebTags = "";
         chkavProfesionalesesrut3.Caption = context.GetMessage( "Profesionales Es RUT3", "");
         AssignProp("", false, chkavProfesionalesesrut3_Internalname, "TitleCaption", chkavProfesionalesesrut3.Caption, true);
         chkavProfesionalesesrut3.CheckedValue = "false";
         AV82ProfesionalesEsRUT3 = StringUtil.StrToBool( StringUtil.BoolToStr( AV82ProfesionalesEsRUT3));
         AssignAttri("", false, "AV82ProfesionalesEsRUT3", AV82ProfesionalesEsRUT3);
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_129_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV66GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV66GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV66GridActions), 4, 0));
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
            context.SendWebValue( context.GetMessage( "Primer Apellido ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesApellidoSegundo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Segundo Apellido ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesTelefono_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProfesionalesDireccion_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Dirección", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEstadosGenericosNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavGridactions_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavGridactions_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesId_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesId_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesPrimerNombre_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesPrimerNombre_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesPrimerNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A191ProfesionalesSegundoNombre)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesSegundoNombre_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesSegundoNombre_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesSegundoNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A167ProfesionalesApellidoPrimero)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesApellidoPrimero_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesApellidoPrimero_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoPrimero_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A192ProfesionalesApellidoSegundo)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesApellidoSegundo_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesApellidoSegundo_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesApellidoSegundo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A170ProfesionalesTelefono)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesTelefono_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesTelefono_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesTelefono_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A193ProfesionalesEmail));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesEmail_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesEmail_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A198ProfesionalesDireccion));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtProfesionalesDireccion_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtProfesionalesDireccion_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesDireccion_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A109EstadosGenericosNombre)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtEstadosGenericosNombre_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtEstadosGenericosNombre_Columnheaderclass));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEstadosGenericosNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Visible), 5, 0, ".", "")));
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
         chkavProfesionalesesrut1_Internalname = "vPROFESIONALESESRUT1";
         cellFilter_profesionalesesrut1_cell_Internalname = "FILTER_PROFESIONALESESRUT1_CELL";
         edtavBanconombre1_Internalname = "vBANCONOMBRE1";
         cellFilter_banconombre1_cell_Internalname = "FILTER_BANCONOMBRE1_CELL";
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
         chkavProfesionalesesrut2_Internalname = "vPROFESIONALESESRUT2";
         cellFilter_profesionalesesrut2_cell_Internalname = "FILTER_PROFESIONALESESRUT2_CELL";
         edtavBanconombre2_Internalname = "vBANCONOMBRE2";
         cellFilter_banconombre2_cell_Internalname = "FILTER_BANCONOMBRE2_CELL";
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
         chkavProfesionalesesrut3_Internalname = "vPROFESIONALESESRUT3";
         cellFilter_profesionalesesrut3_cell_Internalname = "FILTER_PROFESIONALESESRUT3_CELL";
         edtavBanconombre3_Internalname = "vBANCONOMBRE3";
         cellFilter_banconombre3_cell_Internalname = "FILTER_BANCONOMBRE3_CELL";
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
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO";
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO";
         edtProfesionalesEmail_Internalname = "PROFESIONALESEMAIL";
         edtProfesionalesDireccion_Internalname = "PROFESIONALESDIRECCION";
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE";
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
         chkavProfesionalesesrut3.Caption = context.GetMessage( "Profesionales Es RUT3", "");
         chkavProfesionalesesrut2.Caption = context.GetMessage( "Profesionales Es RUT2", "");
         chkavProfesionalesesrut1.Caption = context.GetMessage( "Profesionales Es RUT1", "");
         edtEstadosGenericosNombre_Jsonclick = "";
         edtEstadosGenericosNombre_Columnclass = "WWColumn";
         edtEstadosGenericosNombre_Link = "";
         edtProfesionalesDireccion_Jsonclick = "";
         edtProfesionalesDireccion_Columnclass = "WWColumn";
         edtProfesionalesEmail_Jsonclick = "";
         edtProfesionalesEmail_Columnclass = "WWColumn";
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesTelefono_Columnclass = "WWColumn";
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Columnclass = "WWColumn";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Columnclass = "WWColumn";
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesSegundoNombre_Columnclass = "WWColumn";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Columnclass = "WWColumn hidden-xs";
         edtProfesionalesId_Jsonclick = "";
         edtProfesionalesId_Columnclass = "WWColumn";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions_Columnclass = "WWActionGroupColumn";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavProfesionalesprimernombre1_Jsonclick = "";
         edtavProfesionalesprimernombre1_Enabled = 1;
         edtavBanconombre1_Jsonclick = "";
         edtavBanconombre1_Enabled = 1;
         chkavProfesionalesesrut1.Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavProfesionalesprimernombre2_Jsonclick = "";
         edtavProfesionalesprimernombre2_Enabled = 1;
         edtavBanconombre2_Jsonclick = "";
         edtavBanconombre2_Enabled = 1;
         chkavProfesionalesesrut2.Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavProfesionalesprimernombre3_Jsonclick = "";
         edtavProfesionalesprimernombre3_Enabled = 1;
         edtavBanconombre3_Jsonclick = "";
         edtavBanconombre3_Enabled = 1;
         chkavProfesionalesesrut3.Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavProfesionalesprimernombre3_Visible = 1;
         edtavBanconombre3_Visible = 1;
         chkavProfesionalesesrut3.Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavProfesionalesprimernombre2_Visible = 1;
         edtavBanconombre2_Visible = 1;
         chkavProfesionalesesrut2.Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavProfesionalesprimernombre1_Visible = 1;
         edtavBanconombre1_Visible = 1;
         chkavProfesionalesesrut1.Visible = 1;
         edtEstadosGenericosNombre_Columnheaderclass = "";
         edtProfesionalesDireccion_Columnheaderclass = "";
         edtProfesionalesEmail_Columnheaderclass = "";
         edtProfesionalesTelefono_Columnheaderclass = "";
         edtProfesionalesApellidoSegundo_Columnheaderclass = "";
         edtProfesionalesApellidoPrimero_Columnheaderclass = "";
         edtProfesionalesSegundoNombre_Columnheaderclass = "";
         edtProfesionalesPrimerNombre_Columnheaderclass = "";
         edtProfesionalesId_Columnheaderclass = "";
         cmbavGridactions_Columnheaderclass = "";
         edtEstadosGenericosNombre_Visible = -1;
         edtProfesionalesDireccion_Visible = -1;
         edtProfesionalesEmail_Visible = -1;
         edtProfesionalesTelefono_Visible = -1;
         edtProfesionalesApellidoSegundo_Visible = -1;
         edtProfesionalesApellidoPrimero_Visible = -1;
         edtProfesionalesSegundoNombre_Visible = -1;
         edtProfesionalesPrimerNombre_Visible = -1;
         edtProfesionalesId_Visible = -1;
         edtEstadosGenericosNombre_Enabled = 0;
         edtProfesionalesDireccion_Enabled = 0;
         edtProfesionalesEmail_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
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
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;";
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
         Ddo_grid_Datalistproc = "ProfesionalesWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "3|2|4|5|6|7|8|9|10";
         Ddo_grid_Columnids = "1:ProfesionalesId|2:ProfesionalesPrimerNombre|3:ProfesionalesSegundoNombre|4:ProfesionalesApellidoPrimero|5:ProfesionalesApellidoSegundo|6:ProfesionalesTelefono|7:ProfesionalesEmail|8:ProfesionalesDireccion|9:EstadosGenericosNombre";
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
         Form.Caption = context.GetMessage( " Profesionales", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'edtProfesionalesEmail_Visible',ctrl:'PROFESIONALESEMAIL',prop:'Visible'},{av:'edtProfesionalesDireccion_Visible',ctrl:'PROFESIONALESDIRECCION',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtProfesionalesId_Columnheaderclass',ctrl:'PROFESIONALESID',prop:'Columnheaderclass'},{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtProfesionalesTelefono_Columnheaderclass',ctrl:'PROFESIONALESTELEFONO',prop:'Columnheaderclass'},{av:'edtProfesionalesEmail_Columnheaderclass',ctrl:'PROFESIONALESEMAIL',prop:'Columnheaderclass'},{av:'edtProfesionalesDireccion_Columnheaderclass',ctrl:'PROFESIONALESDIRECCION',prop:'Columnheaderclass'},{av:'edtEstadosGenericosNombre_Columnheaderclass',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Columnheaderclass'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E126C2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'edtProfesionalesEmail_Visible',ctrl:'PROFESIONALESEMAIL',prop:'Visible'},{av:'edtProfesionalesDireccion_Visible',ctrl:'PROFESIONALESDIRECCION',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtProfesionalesId_Columnheaderclass',ctrl:'PROFESIONALESID',prop:'Columnheaderclass'},{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtProfesionalesTelefono_Columnheaderclass',ctrl:'PROFESIONALESTELEFONO',prop:'Columnheaderclass'},{av:'edtProfesionalesEmail_Columnheaderclass',ctrl:'PROFESIONALESEMAIL',prop:'Columnheaderclass'},{av:'edtProfesionalesDireccion_Columnheaderclass',ctrl:'PROFESIONALESDIRECCION',prop:'Columnheaderclass'},{av:'edtEstadosGenericosNombre_Columnheaderclass',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Columnheaderclass'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E136C2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E166C2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E296C2',iparms:[{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV66GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtEstadosGenericosNombre_Link',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Link'},{av:'edtProfesionalesId_Columnclass',ctrl:'PROFESIONALESID',prop:'Columnclass'},{av:'edtProfesionalesPrimerNombre_Columnclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnclass'},{av:'edtProfesionalesSegundoNombre_Columnclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnclass'},{av:'edtProfesionalesApellidoPrimero_Columnclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnclass'},{av:'edtProfesionalesApellidoSegundo_Columnclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnclass'},{av:'edtProfesionalesTelefono_Columnclass',ctrl:'PROFESIONALESTELEFONO',prop:'Columnclass'},{av:'edtProfesionalesEmail_Columnclass',ctrl:'PROFESIONALESEMAIL',prop:'Columnclass'},{av:'edtProfesionalesDireccion_Columnclass',ctrl:'PROFESIONALESDIRECCION',prop:'Columnclass'},{av:'edtEstadosGenericosNombre_Columnclass',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Columnclass'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E176C2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'edtProfesionalesEmail_Visible',ctrl:'PROFESIONALESEMAIL',prop:'Visible'},{av:'edtProfesionalesDireccion_Visible',ctrl:'PROFESIONALESDIRECCION',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtProfesionalesId_Columnheaderclass',ctrl:'PROFESIONALESID',prop:'Columnheaderclass'},{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtProfesionalesTelefono_Columnheaderclass',ctrl:'PROFESIONALESTELEFONO',prop:'Columnheaderclass'},{av:'edtProfesionalesEmail_Columnheaderclass',ctrl:'PROFESIONALESEMAIL',prop:'Columnheaderclass'},{av:'edtProfesionalesDireccion_Columnheaderclass',ctrl:'PROFESIONALESDIRECCION',prop:'Columnheaderclass'},{av:'edtEstadosGenericosNombre_Columnheaderclass',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Columnheaderclass'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E226C2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E186C2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cmbavDynamicfiltersoperator3'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'chkavProfesionalesesrut2.Visible',ctrl:'vPROFESIONALESESRUT2',prop:'Visible'},{av:'edtavBanconombre2_Visible',ctrl:'vBANCONOMBRE2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'},{av:'chkavProfesionalesesrut3.Visible',ctrl:'vPROFESIONALESESRUT3',prop:'Visible'},{av:'edtavBanconombre3_Visible',ctrl:'vBANCONOMBRE3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'},{av:'chkavProfesionalesesrut1.Visible',ctrl:'vPROFESIONALESESRUT1',prop:'Visible'},{av:'edtavBanconombre1_Visible',ctrl:'vBANCONOMBRE1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'edtProfesionalesEmail_Visible',ctrl:'PROFESIONALESEMAIL',prop:'Visible'},{av:'edtProfesionalesDireccion_Visible',ctrl:'PROFESIONALESDIRECCION',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtProfesionalesId_Columnheaderclass',ctrl:'PROFESIONALESID',prop:'Columnheaderclass'},{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtProfesionalesTelefono_Columnheaderclass',ctrl:'PROFESIONALESTELEFONO',prop:'Columnheaderclass'},{av:'edtProfesionalesEmail_Columnheaderclass',ctrl:'PROFESIONALESEMAIL',prop:'Columnheaderclass'},{av:'edtProfesionalesDireccion_Columnheaderclass',ctrl:'PROFESIONALESDIRECCION',prop:'Columnheaderclass'},{av:'edtEstadosGenericosNombre_Columnheaderclass',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Columnheaderclass'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E236C2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'chkavProfesionalesesrut1.Visible',ctrl:'vPROFESIONALESESRUT1',prop:'Visible'},{av:'edtavBanconombre1_Visible',ctrl:'vBANCONOMBRE1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E246C2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E196C2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cmbavDynamicfiltersoperator3'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'chkavProfesionalesesrut2.Visible',ctrl:'vPROFESIONALESESRUT2',prop:'Visible'},{av:'edtavBanconombre2_Visible',ctrl:'vBANCONOMBRE2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'},{av:'chkavProfesionalesesrut3.Visible',ctrl:'vPROFESIONALESESRUT3',prop:'Visible'},{av:'edtavBanconombre3_Visible',ctrl:'vBANCONOMBRE3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'},{av:'chkavProfesionalesesrut1.Visible',ctrl:'vPROFESIONALESESRUT1',prop:'Visible'},{av:'edtavBanconombre1_Visible',ctrl:'vBANCONOMBRE1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'edtProfesionalesEmail_Visible',ctrl:'PROFESIONALESEMAIL',prop:'Visible'},{av:'edtProfesionalesDireccion_Visible',ctrl:'PROFESIONALESDIRECCION',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtProfesionalesId_Columnheaderclass',ctrl:'PROFESIONALESID',prop:'Columnheaderclass'},{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtProfesionalesTelefono_Columnheaderclass',ctrl:'PROFESIONALESTELEFONO',prop:'Columnheaderclass'},{av:'edtProfesionalesEmail_Columnheaderclass',ctrl:'PROFESIONALESEMAIL',prop:'Columnheaderclass'},{av:'edtProfesionalesDireccion_Columnheaderclass',ctrl:'PROFESIONALESDIRECCION',prop:'Columnheaderclass'},{av:'edtEstadosGenericosNombre_Columnheaderclass',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Columnheaderclass'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E256C2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'chkavProfesionalesesrut2.Visible',ctrl:'vPROFESIONALESESRUT2',prop:'Visible'},{av:'edtavBanconombre2_Visible',ctrl:'vBANCONOMBRE2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E206C2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cmbavDynamicfiltersoperator3'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'chkavProfesionalesesrut2.Visible',ctrl:'vPROFESIONALESESRUT2',prop:'Visible'},{av:'edtavBanconombre2_Visible',ctrl:'vBANCONOMBRE2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'},{av:'chkavProfesionalesesrut3.Visible',ctrl:'vPROFESIONALESESRUT3',prop:'Visible'},{av:'edtavBanconombre3_Visible',ctrl:'vBANCONOMBRE3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'},{av:'chkavProfesionalesesrut1.Visible',ctrl:'vPROFESIONALESESRUT1',prop:'Visible'},{av:'edtavBanconombre1_Visible',ctrl:'vBANCONOMBRE1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'edtProfesionalesEmail_Visible',ctrl:'PROFESIONALESEMAIL',prop:'Visible'},{av:'edtProfesionalesDireccion_Visible',ctrl:'PROFESIONALESDIRECCION',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtProfesionalesId_Columnheaderclass',ctrl:'PROFESIONALESID',prop:'Columnheaderclass'},{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtProfesionalesTelefono_Columnheaderclass',ctrl:'PROFESIONALESTELEFONO',prop:'Columnheaderclass'},{av:'edtProfesionalesEmail_Columnheaderclass',ctrl:'PROFESIONALESEMAIL',prop:'Columnheaderclass'},{av:'edtProfesionalesDireccion_Columnheaderclass',ctrl:'PROFESIONALESDIRECCION',prop:'Columnheaderclass'},{av:'edtEstadosGenericosNombre_Columnheaderclass',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Columnheaderclass'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E266C2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'chkavProfesionalesesrut3.Visible',ctrl:'vPROFESIONALESESRUT3',prop:'Visible'},{av:'edtavBanconombre3_Visible',ctrl:'vBANCONOMBRE3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E116C2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'chkavProfesionalesesrut1.Visible',ctrl:'vPROFESIONALESESRUT1',prop:'Visible'},{av:'edtavBanconombre1_Visible',ctrl:'vBANCONOMBRE1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'},{av:'chkavProfesionalesesrut2.Visible',ctrl:'vPROFESIONALESESRUT2',prop:'Visible'},{av:'edtavBanconombre2_Visible',ctrl:'vBANCONOMBRE2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'},{av:'chkavProfesionalesesrut3.Visible',ctrl:'vPROFESIONALESESRUT3',prop:'Visible'},{av:'edtavBanconombre3_Visible',ctrl:'vBANCONOMBRE3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'edtProfesionalesEmail_Visible',ctrl:'PROFESIONALESEMAIL',prop:'Visible'},{av:'edtProfesionalesDireccion_Visible',ctrl:'PROFESIONALESDIRECCION',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtProfesionalesId_Columnheaderclass',ctrl:'PROFESIONALESID',prop:'Columnheaderclass'},{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtProfesionalesTelefono_Columnheaderclass',ctrl:'PROFESIONALESTELEFONO',prop:'Columnheaderclass'},{av:'edtProfesionalesEmail_Columnheaderclass',ctrl:'PROFESIONALESEMAIL',prop:'Columnheaderclass'},{av:'edtProfesionalesDireccion_Columnheaderclass',ctrl:'PROFESIONALESDIRECCION',prop:'Columnheaderclass'},{av:'edtEstadosGenericosNombre_Columnheaderclass',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Columnheaderclass'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E306C2',iparms:[{av:'cmbavGridactions'},{av:'AV66GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV66GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E216C2',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E146C2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV78ProfesionalesEsRUT1',fld:'vPROFESIONALESESRUT1',pic:'',type:'boolean'},{av:'AV79BancoNombre1',fld:'vBANCONOMBRE1',pic:'',type:'char'},{av:'AV20ProfesionalesPrimerNombre1',fld:'vPROFESIONALESPRIMERNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV80ProfesionalesEsRUT2',fld:'vPROFESIONALESESRUT2',pic:'',type:'boolean'},{av:'AV81BancoNombre2',fld:'vBANCONOMBRE2',pic:'',type:'char'},{av:'AV24ProfesionalesPrimerNombre2',fld:'vPROFESIONALESPRIMERNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV82ProfesionalesEsRUT3',fld:'vPROFESIONALESESRUT3',pic:'',type:'boolean'},{av:'AV83BancoNombre3',fld:'vBANCONOMBRE3',pic:'',type:'char'},{av:'AV28ProfesionalesPrimerNombre3',fld:'vPROFESIONALESPRIMERNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV84Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV41TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV42TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV43TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV44TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV45TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV46TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV48TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV49TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV50TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV51TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV52TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV53TFProfesionalesEmail',fld:'vTFPROFESIONALESEMAIL',pic:'',type:'svchar'},{av:'AV54TFProfesionalesEmail_Sel',fld:'vTFPROFESIONALESEMAIL_SEL',pic:'',type:'svchar'},{av:'AV55TFProfesionalesDireccion',fld:'vTFPROFESIONALESDIRECCION',pic:'',type:'svchar'},{av:'AV56TFProfesionalesDireccion_Sel',fld:'vTFPROFESIONALESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV75TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV76TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV68IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV69IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV77IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'chkavProfesionalesesrut1.Visible',ctrl:'vPROFESIONALESESRUT1',prop:'Visible'},{av:'edtavBanconombre1_Visible',ctrl:'vBANCONOMBRE1',prop:'Visible'},{av:'edtavProfesionalesprimernombre1_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE1',prop:'Visible'},{av:'chkavProfesionalesesrut2.Visible',ctrl:'vPROFESIONALESESRUT2',prop:'Visible'},{av:'edtavBanconombre2_Visible',ctrl:'vBANCONOMBRE2',prop:'Visible'},{av:'edtavProfesionalesprimernombre2_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE2',prop:'Visible'},{av:'chkavProfesionalesesrut3.Visible',ctrl:'vPROFESIONALESESRUT3',prop:'Visible'},{av:'edtavBanconombre3_Visible',ctrl:'vBANCONOMBRE3',prop:'Visible'},{av:'edtavProfesionalesprimernombre3_Visible',ctrl:'vPROFESIONALESPRIMERNOMBRE3',prop:'Visible'},{av:'edtProfesionalesId_Visible',ctrl:'PROFESIONALESID',prop:'Visible'},{av:'edtProfesionalesPrimerNombre_Visible',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Visible'},{av:'edtProfesionalesSegundoNombre_Visible',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Visible'},{av:'edtProfesionalesApellidoPrimero_Visible',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Visible'},{av:'edtProfesionalesApellidoSegundo_Visible',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Visible'},{av:'edtProfesionalesTelefono_Visible',ctrl:'PROFESIONALESTELEFONO',prop:'Visible'},{av:'edtProfesionalesEmail_Visible',ctrl:'PROFESIONALESEMAIL',prop:'Visible'},{av:'edtProfesionalesDireccion_Visible',ctrl:'PROFESIONALESDIRECCION',prop:'Visible'},{av:'edtEstadosGenericosNombre_Visible',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Visible'},{av:'AV63GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV64GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV65GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtProfesionalesId_Columnheaderclass',ctrl:'PROFESIONALESID',prop:'Columnheaderclass'},{av:'edtProfesionalesPrimerNombre_Columnheaderclass',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesSegundoNombre_Columnheaderclass',ctrl:'PROFESIONALESSEGUNDONOMBRE',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoPrimero_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOPRIMERO',prop:'Columnheaderclass'},{av:'edtProfesionalesApellidoSegundo_Columnheaderclass',ctrl:'PROFESIONALESAPELLIDOSEGUNDO',prop:'Columnheaderclass'},{av:'edtProfesionalesTelefono_Columnheaderclass',ctrl:'PROFESIONALESTELEFONO',prop:'Columnheaderclass'},{av:'edtProfesionalesEmail_Columnheaderclass',ctrl:'PROFESIONALESEMAIL',prop:'Columnheaderclass'},{av:'edtProfesionalesDireccion_Columnheaderclass',ctrl:'PROFESIONALESDIRECCION',prop:'Columnheaderclass'},{av:'edtEstadosGenericosNombre_Columnheaderclass',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Columnheaderclass'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E156C2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("NULL","{handler:'Valid_Estadosgenericosnombre',iparms:[]");
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
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV79BancoNombre1 = "";
         AV20ProfesionalesPrimerNombre1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV81BancoNombre2 = "";
         AV24ProfesionalesPrimerNombre2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV83BancoNombre3 = "";
         AV28ProfesionalesPrimerNombre3 = "";
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV84Pgmname = "";
         AV41TFProfesionalesId = "";
         AV42TFProfesionalesId_Sel = "";
         AV43TFProfesionalesPrimerNombre = "";
         AV44TFProfesionalesPrimerNombre_Sel = "";
         AV45TFProfesionalesSegundoNombre = "";
         AV46TFProfesionalesSegundoNombre_Sel = "";
         AV47TFProfesionalesApellidoPrimero = "";
         AV48TFProfesionalesApellidoPrimero_Sel = "";
         AV49TFProfesionalesApellidoSegundo = "";
         AV50TFProfesionalesApellidoSegundo_Sel = "";
         AV51TFProfesionalesTelefono = "";
         AV52TFProfesionalesTelefono_Sel = "";
         AV53TFProfesionalesEmail = "";
         AV54TFProfesionalesEmail_Sel = "";
         AV55TFProfesionalesDireccion = "";
         AV56TFProfesionalesDireccion_Sel = "";
         AV75TFEstadosGenericosNombre = "";
         AV76TFEstadosGenericosNombre_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV65GridAppliedFilters = "";
         AV70AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV61DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         A107EstadosTipo = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
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
         A193ProfesionalesEmail = "";
         A198ProfesionalesDireccion = "";
         A109EstadosGenericosNombre = "";
         lV85Profesionaleswwds_1_filterfulltext = "";
         lV89Profesionaleswwds_5_banconombre1 = "";
         lV90Profesionaleswwds_6_profesionalesprimernombre1 = "";
         lV95Profesionaleswwds_11_banconombre2 = "";
         lV96Profesionaleswwds_12_profesionalesprimernombre2 = "";
         lV101Profesionaleswwds_17_banconombre3 = "";
         lV102Profesionaleswwds_18_profesionalesprimernombre3 = "";
         lV103Profesionaleswwds_19_tfprofesionalesid = "";
         lV105Profesionaleswwds_21_tfprofesionalesprimernombre = "";
         lV107Profesionaleswwds_23_tfprofesionalessegundonombre = "";
         lV109Profesionaleswwds_25_tfprofesionalesapellidoprimero = "";
         lV111Profesionaleswwds_27_tfprofesionalesapellidosegundo = "";
         lV113Profesionaleswwds_29_tfprofesionalestelefono = "";
         lV115Profesionaleswwds_31_tfprofesionalesemail = "";
         lV117Profesionaleswwds_33_tfprofesionalesdireccion = "";
         lV119Profesionaleswwds_35_tfestadosgenericosnombre = "";
         AV85Profesionaleswwds_1_filterfulltext = "";
         AV86Profesionaleswwds_2_dynamicfiltersselector1 = "";
         AV89Profesionaleswwds_5_banconombre1 = "";
         AV90Profesionaleswwds_6_profesionalesprimernombre1 = "";
         AV92Profesionaleswwds_8_dynamicfiltersselector2 = "";
         AV95Profesionaleswwds_11_banconombre2 = "";
         AV96Profesionaleswwds_12_profesionalesprimernombre2 = "";
         AV98Profesionaleswwds_14_dynamicfiltersselector3 = "";
         AV101Profesionaleswwds_17_banconombre3 = "";
         AV102Profesionaleswwds_18_profesionalesprimernombre3 = "";
         AV104Profesionaleswwds_20_tfprofesionalesid_sel = "";
         AV103Profesionaleswwds_19_tfprofesionalesid = "";
         AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel = "";
         AV105Profesionaleswwds_21_tfprofesionalesprimernombre = "";
         AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel = "";
         AV107Profesionaleswwds_23_tfprofesionalessegundonombre = "";
         AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = "";
         AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero = "";
         AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = "";
         AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo = "";
         AV114Profesionaleswwds_30_tfprofesionalestelefono_sel = "";
         AV113Profesionaleswwds_29_tfprofesionalestelefono = "";
         AV116Profesionaleswwds_32_tfprofesionalesemail_sel = "";
         AV115Profesionaleswwds_31_tfprofesionalesemail = "";
         AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel = "";
         AV117Profesionaleswwds_33_tfprofesionalesdireccion = "";
         AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel = "";
         AV119Profesionaleswwds_35_tfestadosgenericosnombre = "";
         A674BancoNombre = "";
         H006C2_A673BancoId = new long[1] ;
         H006C2_n673BancoId = new bool[] {false} ;
         H006C2_A674BancoNombre = new string[] {""} ;
         H006C2_A676ProfesionalesEsRUT = new bool[] {false} ;
         H006C2_n676ProfesionalesEsRUT = new bool[] {false} ;
         H006C2_A108EstadosGenericosId = new int[1] ;
         H006C2_A107EstadosTipo = new string[] {""} ;
         H006C2_A109EstadosGenericosNombre = new string[] {""} ;
         H006C2_A198ProfesionalesDireccion = new string[] {""} ;
         H006C2_A193ProfesionalesEmail = new string[] {""} ;
         H006C2_n193ProfesionalesEmail = new bool[] {false} ;
         H006C2_A170ProfesionalesTelefono = new string[] {""} ;
         H006C2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H006C2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H006C2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H006C2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H006C2_A120ProfesionalesId = new string[] {""} ;
         H006C3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV71AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV33ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV39ManageFiltersXml = "";
         AV34UserCustomValue = "";
         AV36ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char12 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV31ExcelFilename = "";
         AV32ErrorMessage = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesww__default(),
            new Object[][] {
                new Object[] {
               H006C2_A673BancoId, H006C2_n673BancoId, H006C2_A674BancoNombre, H006C2_A676ProfesionalesEsRUT, H006C2_n676ProfesionalesEsRUT, H006C2_A108EstadosGenericosId, H006C2_A107EstadosTipo, H006C2_A109EstadosGenericosNombre, H006C2_A198ProfesionalesDireccion, H006C2_A193ProfesionalesEmail,
               H006C2_n193ProfesionalesEmail, H006C2_A170ProfesionalesTelefono, H006C2_A192ProfesionalesApellidoSegundo, H006C2_A167ProfesionalesApellidoPrimero, H006C2_A191ProfesionalesSegundoNombre, H006C2_A166ProfesionalesPrimerNombre, H006C2_A120ProfesionalesId
               }
               , new Object[] {
               H006C3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV84Pgmname = "ProfesionalesWW";
         /* GeneXus formulas. */
         AV84Pgmname = "ProfesionalesWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV40ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV66GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV87Profesionaleswwds_3_dynamicfiltersoperator1 ;
      private short AV93Profesionaleswwds_9_dynamicfiltersoperator2 ;
      private short AV99Profesionaleswwds_15_dynamicfiltersoperator3 ;
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
      private int A108EstadosGenericosId ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int edtProfesionalesEmail_Enabled ;
      private int edtProfesionalesDireccion_Enabled ;
      private int edtEstadosGenericosNombre_Enabled ;
      private int edtProfesionalesId_Visible ;
      private int edtProfesionalesPrimerNombre_Visible ;
      private int edtProfesionalesSegundoNombre_Visible ;
      private int edtProfesionalesApellidoPrimero_Visible ;
      private int edtProfesionalesApellidoSegundo_Visible ;
      private int edtProfesionalesTelefono_Visible ;
      private int edtProfesionalesEmail_Visible ;
      private int edtProfesionalesDireccion_Visible ;
      private int edtEstadosGenericosNombre_Visible ;
      private int AV62PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavBanconombre1_Visible ;
      private int edtavProfesionalesprimernombre1_Visible ;
      private int edtavBanconombre2_Visible ;
      private int edtavProfesionalesprimernombre2_Visible ;
      private int edtavBanconombre3_Visible ;
      private int edtavProfesionalesprimernombre3_Visible ;
      private int AV121GXV1 ;
      private int edtavBanconombre3_Enabled ;
      private int edtavProfesionalesprimernombre3_Enabled ;
      private int edtavBanconombre2_Enabled ;
      private int edtavProfesionalesprimernombre2_Enabled ;
      private int edtavBanconombre1_Enabled ;
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
      private long AV63GridCurrentPage ;
      private long AV64GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long A673BancoId ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_129_idx="0001" ;
      private string AV79BancoNombre1 ;
      private string AV20ProfesionalesPrimerNombre1 ;
      private string AV81BancoNombre2 ;
      private string AV24ProfesionalesPrimerNombre2 ;
      private string AV83BancoNombre3 ;
      private string AV28ProfesionalesPrimerNombre3 ;
      private string AV84Pgmname ;
      private string AV41TFProfesionalesId ;
      private string AV42TFProfesionalesId_Sel ;
      private string AV43TFProfesionalesPrimerNombre ;
      private string AV44TFProfesionalesPrimerNombre_Sel ;
      private string AV45TFProfesionalesSegundoNombre ;
      private string AV46TFProfesionalesSegundoNombre_Sel ;
      private string AV47TFProfesionalesApellidoPrimero ;
      private string AV48TFProfesionalesApellidoPrimero_Sel ;
      private string AV49TFProfesionalesApellidoSegundo ;
      private string AV50TFProfesionalesApellidoSegundo_Sel ;
      private string AV51TFProfesionalesTelefono ;
      private string AV52TFProfesionalesTelefono_Sel ;
      private string AV75TFEstadosGenericosNombre ;
      private string AV76TFEstadosGenericosNombre_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A107EstadosTipo ;
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
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
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
      private string edtProfesionalesEmail_Internalname ;
      private string edtProfesionalesDireccion_Internalname ;
      private string A109EstadosGenericosNombre ;
      private string edtEstadosGenericosNombre_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string lV89Profesionaleswwds_5_banconombre1 ;
      private string lV90Profesionaleswwds_6_profesionalesprimernombre1 ;
      private string lV95Profesionaleswwds_11_banconombre2 ;
      private string lV96Profesionaleswwds_12_profesionalesprimernombre2 ;
      private string lV101Profesionaleswwds_17_banconombre3 ;
      private string lV102Profesionaleswwds_18_profesionalesprimernombre3 ;
      private string lV103Profesionaleswwds_19_tfprofesionalesid ;
      private string lV105Profesionaleswwds_21_tfprofesionalesprimernombre ;
      private string lV107Profesionaleswwds_23_tfprofesionalessegundonombre ;
      private string lV109Profesionaleswwds_25_tfprofesionalesapellidoprimero ;
      private string lV111Profesionaleswwds_27_tfprofesionalesapellidosegundo ;
      private string lV113Profesionaleswwds_29_tfprofesionalestelefono ;
      private string lV119Profesionaleswwds_35_tfestadosgenericosnombre ;
      private string AV89Profesionaleswwds_5_banconombre1 ;
      private string AV90Profesionaleswwds_6_profesionalesprimernombre1 ;
      private string AV95Profesionaleswwds_11_banconombre2 ;
      private string AV96Profesionaleswwds_12_profesionalesprimernombre2 ;
      private string AV101Profesionaleswwds_17_banconombre3 ;
      private string AV102Profesionaleswwds_18_profesionalesprimernombre3 ;
      private string AV104Profesionaleswwds_20_tfprofesionalesid_sel ;
      private string AV103Profesionaleswwds_19_tfprofesionalesid ;
      private string AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel ;
      private string AV105Profesionaleswwds_21_tfprofesionalesprimernombre ;
      private string AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel ;
      private string AV107Profesionaleswwds_23_tfprofesionalessegundonombre ;
      private string AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ;
      private string AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero ;
      private string AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ;
      private string AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo ;
      private string AV114Profesionaleswwds_30_tfprofesionalestelefono_sel ;
      private string AV113Profesionaleswwds_29_tfprofesionalestelefono ;
      private string AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel ;
      private string AV119Profesionaleswwds_35_tfestadosgenericosnombre ;
      private string A674BancoNombre ;
      private string chkavProfesionalesesrut1_Internalname ;
      private string edtavBanconombre1_Internalname ;
      private string edtavProfesionalesprimernombre1_Internalname ;
      private string chkavProfesionalesesrut2_Internalname ;
      private string edtavBanconombre2_Internalname ;
      private string edtavProfesionalesprimernombre2_Internalname ;
      private string chkavProfesionalesesrut3_Internalname ;
      private string edtavBanconombre3_Internalname ;
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
      private string cmbavGridactions_Columnheaderclass ;
      private string edtProfesionalesId_Columnheaderclass ;
      private string edtProfesionalesPrimerNombre_Columnheaderclass ;
      private string edtProfesionalesSegundoNombre_Columnheaderclass ;
      private string edtProfesionalesApellidoPrimero_Columnheaderclass ;
      private string edtProfesionalesApellidoSegundo_Columnheaderclass ;
      private string edtProfesionalesTelefono_Columnheaderclass ;
      private string edtProfesionalesEmail_Columnheaderclass ;
      private string edtProfesionalesDireccion_Columnheaderclass ;
      private string edtEstadosGenericosNombre_Columnheaderclass ;
      private string edtEstadosGenericosNombre_Link ;
      private string GXEncryptionTmp ;
      private string cmbavGridactions_Columnclass ;
      private string edtProfesionalesId_Columnclass ;
      private string edtProfesionalesPrimerNombre_Columnclass ;
      private string edtProfesionalesSegundoNombre_Columnclass ;
      private string edtProfesionalesApellidoPrimero_Columnclass ;
      private string edtProfesionalesApellidoSegundo_Columnclass ;
      private string edtProfesionalesTelefono_Columnclass ;
      private string edtProfesionalesEmail_Columnclass ;
      private string edtProfesionalesDireccion_Columnclass ;
      private string edtEstadosGenericosNombre_Columnclass ;
      private string GXt_char12 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_profesionalesesrut3_cell_Internalname ;
      private string cellFilter_banconombre3_cell_Internalname ;
      private string edtavBanconombre3_Jsonclick ;
      private string cellFilter_profesionalesprimernombre3_cell_Internalname ;
      private string edtavProfesionalesprimernombre3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_profesionalesesrut2_cell_Internalname ;
      private string cellFilter_banconombre2_cell_Internalname ;
      private string edtavBanconombre2_Jsonclick ;
      private string cellFilter_profesionalesprimernombre2_cell_Internalname ;
      private string edtavProfesionalesprimernombre2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_profesionalesesrut1_cell_Internalname ;
      private string cellFilter_banconombre1_cell_Internalname ;
      private string edtavBanconombre1_Jsonclick ;
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
      private string sGXsfl_129_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string gxphoneLink ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string edtProfesionalesEmail_Jsonclick ;
      private string edtProfesionalesDireccion_Jsonclick ;
      private string edtEstadosGenericosNombre_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV78ProfesionalesEsRUT1 ;
      private bool AV80ProfesionalesEsRUT2 ;
      private bool AV82ProfesionalesEsRUT3 ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV30DynamicFiltersIgnoreFirst ;
      private bool AV29DynamicFiltersRemoving ;
      private bool AV68IsAuthorized_Update ;
      private bool AV69IsAuthorized_Delete ;
      private bool AV77IsAuthorized_EstadosGenericosNombre ;
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
      private bool n193ProfesionalesEmail ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV88Profesionaleswwds_4_profesionalesesrut1 ;
      private bool AV91Profesionaleswwds_7_dynamicfiltersenabled2 ;
      private bool AV94Profesionaleswwds_10_profesionalesesrut2 ;
      private bool AV97Profesionaleswwds_13_dynamicfiltersenabled3 ;
      private bool AV100Profesionaleswwds_16_profesionalesesrut3 ;
      private bool A676ProfesionalesEsRUT ;
      private bool n673BancoId ;
      private bool n676ProfesionalesEsRUT ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV72TempBoolean ;
      private bool GXt_boolean1 ;
      private string AV33ColumnsSelectorXML ;
      private string AV39ManageFiltersXml ;
      private string AV34UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV53TFProfesionalesEmail ;
      private string AV54TFProfesionalesEmail_Sel ;
      private string AV55TFProfesionalesDireccion ;
      private string AV56TFProfesionalesDireccion_Sel ;
      private string AV65GridAppliedFilters ;
      private string A193ProfesionalesEmail ;
      private string A198ProfesionalesDireccion ;
      private string lV85Profesionaleswwds_1_filterfulltext ;
      private string lV115Profesionaleswwds_31_tfprofesionalesemail ;
      private string lV117Profesionaleswwds_33_tfprofesionalesdireccion ;
      private string AV85Profesionaleswwds_1_filterfulltext ;
      private string AV86Profesionaleswwds_2_dynamicfiltersselector1 ;
      private string AV92Profesionaleswwds_8_dynamicfiltersselector2 ;
      private string AV98Profesionaleswwds_14_dynamicfiltersselector3 ;
      private string AV116Profesionaleswwds_32_tfprofesionalesemail_sel ;
      private string AV115Profesionaleswwds_31_tfprofesionalesemail ;
      private string AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel ;
      private string AV117Profesionaleswwds_33_tfprofesionalesdireccion ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private IGxSession AV37Session ;
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
      private GXCheckbox chkavProfesionalesesrut1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCheckbox chkavProfesionalesesrut2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCheckbox chkavProfesionalesesrut3 ;
      private GXCombobox cmbavGridactions ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV70AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV61DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private long[] H006C2_A673BancoId ;
      private bool[] H006C2_n673BancoId ;
      private string[] H006C2_A674BancoNombre ;
      private bool[] H006C2_A676ProfesionalesEsRUT ;
      private bool[] H006C2_n676ProfesionalesEsRUT ;
      private int[] H006C2_A108EstadosGenericosId ;
      private string[] H006C2_A107EstadosTipo ;
      private string[] H006C2_A109EstadosGenericosNombre ;
      private string[] H006C2_A198ProfesionalesDireccion ;
      private string[] H006C2_A193ProfesionalesEmail ;
      private bool[] H006C2_n193ProfesionalesEmail ;
      private string[] H006C2_A170ProfesionalesTelefono ;
      private string[] H006C2_A192ProfesionalesApellidoSegundo ;
      private string[] H006C2_A167ProfesionalesApellidoPrimero ;
      private string[] H006C2_A191ProfesionalesSegundoNombre ;
      private string[] H006C2_A166ProfesionalesPrimerNombre ;
      private string[] H006C2_A120ProfesionalesId ;
      private long[] H006C3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV71AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class profesionalesww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H006C2( IGxContext context ,
                                             string AV85Profesionaleswwds_1_filterfulltext ,
                                             string AV86Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV88Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV87Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV89Profesionaleswwds_5_banconombre1 ,
                                             string AV90Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV91Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV92Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV94Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV93Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV95Profesionaleswwds_11_banconombre2 ,
                                             string AV96Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV97Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV98Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV100Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV99Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV101Profesionaleswwds_17_banconombre3 ,
                                             string AV102Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV104Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV103Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV105Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV107Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV114Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV113Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV116Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV115Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV117Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV119Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[42];
         Object[] GXv_Object14 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[BancoId], T2.[BancoNombre], T1.[ProfesionalesEsRUT], T1.[EstadosGenericosId], T1.[EstadosTipo], T3.[EstadosGenericosNombre], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesId]";
         sFromString = " FROM (([Profesionales] T1 LEFT JOIN [Banco] T2 ON T2.[BancoId] = T1.[BancoId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosTipo] AND T3.[EstadosGenericosId] = T1.[EstadosGenericosId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int13[0] = 1;
            GXv_int13[1] = 1;
            GXv_int13[2] = 1;
            GXv_int13[3] = 1;
            GXv_int13[4] = 1;
            GXv_int13[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV88Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV88Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV87Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like UPPER(@lV89Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int13[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV87Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like '%' + UPPER(@lV89Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV87Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV90Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV87Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV90Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( AV91Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV94Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV94Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( AV91Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV93Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like UPPER(@lV95Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( AV91Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV93Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like '%' + UPPER(@lV95Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( AV91Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV93Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV96Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( AV91Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV93Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV96Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( AV97Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV100Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV100Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( AV97Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV99Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like UPPER(@lV101Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( AV97Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV99Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like '%' + UPPER(@lV101Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( AV97Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV99Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV102Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( AV97Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV99Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV102Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV103Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV104Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV105Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int13[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int13[24] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV107Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int13[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int13[26] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV109Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int13[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int13[28] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV111Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int13[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int13[30] = 1;
         }
         if ( StringUtil.StrCmp(AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV113Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int13[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV114Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV114Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int13[32] = 1;
         }
         if ( StringUtil.StrCmp(AV114Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV115Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int13[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV116Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV116Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int13[34] = 1;
         }
         if ( StringUtil.StrCmp(AV116Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV117Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int13[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int13[36] = 1;
         }
         if ( StringUtil.StrCmp(AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV119Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int13[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int13[38] = 1;
         }
         if ( StringUtil.StrCmp(AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         if ( AV14OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesEsRUT]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesPrimerNombre] DESC";
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
            sOrderString += " ORDER BY T1.[ProfesionalesSegundoNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesTelefono]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesEmail]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesEmail] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesDireccion]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.[EstadosGenericosNombre]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.[EstadosGenericosNombre] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[ProfesionalesId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_H006C3( IGxContext context ,
                                             string AV85Profesionaleswwds_1_filterfulltext ,
                                             string AV86Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV88Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV87Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV89Profesionaleswwds_5_banconombre1 ,
                                             string AV90Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV91Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV92Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV94Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV93Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV95Profesionaleswwds_11_banconombre2 ,
                                             string AV96Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV97Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV98Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV100Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV99Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV101Profesionaleswwds_17_banconombre3 ,
                                             string AV102Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV104Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV103Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV105Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV107Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV114Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV113Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV116Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV115Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV117Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV119Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[39];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([Profesionales] T1 LEFT JOIN [Banco] T3 ON T3.[BancoId] = T1.[BancoId]) INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV85Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int15[0] = 1;
            GXv_int15[1] = 1;
            GXv_int15[2] = 1;
            GXv_int15[3] = 1;
            GXv_int15[4] = 1;
            GXv_int15[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV88Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV88Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int15[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV87Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV89Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int15[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV87Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV89Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int15[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV87Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV90Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int15[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV87Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV90Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int15[10] = 1;
         }
         if ( AV91Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV94Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV94Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int15[11] = 1;
         }
         if ( AV91Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV93Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV95Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int15[12] = 1;
         }
         if ( AV91Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV93Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV95Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int15[13] = 1;
         }
         if ( AV91Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV93Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV96Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int15[14] = 1;
         }
         if ( AV91Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV92Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV93Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV96Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int15[15] = 1;
         }
         if ( AV97Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV100Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV100Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int15[16] = 1;
         }
         if ( AV97Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV99Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV101Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int15[17] = 1;
         }
         if ( AV97Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV99Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV101Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int15[18] = 1;
         }
         if ( AV97Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV99Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV102Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int15[19] = 1;
         }
         if ( AV97Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV98Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV99Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV102Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int15[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV103Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int15[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV104Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int15[22] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV105Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int15[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int15[24] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV107Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int15[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int15[26] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV109Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int15[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int15[28] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV111Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int15[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int15[30] = 1;
         }
         if ( StringUtil.StrCmp(AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV113Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int15[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV114Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV114Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int15[32] = 1;
         }
         if ( StringUtil.StrCmp(AV114Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV115Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int15[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV116Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV116Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int15[34] = 1;
         }
         if ( StringUtil.StrCmp(AV116Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV117Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int15[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int15[36] = 1;
         }
         if ( StringUtil.StrCmp(AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV119Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int15[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int15[38] = 1;
         }
         if ( StringUtil.StrCmp(AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
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
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H006C2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (short)dynConstraints[47] , (bool)dynConstraints[48] );
               case 1 :
                     return conditional_H006C3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (short)dynConstraints[47] , (bool)dynConstraints[48] );
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
          Object[] prmH006C2;
          prmH006C2 = new Object[] {
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV88Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV89Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV89Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV90Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV90Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV94Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV95Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV95Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV96Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV96Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV101Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV101Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV102Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV102Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV103Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV104Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV105Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV107Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV109Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV111Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV113Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV114Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV115Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV116Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV117Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV119Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH006C3;
          prmH006C3 = new Object[] {
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV85Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV88Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV89Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV89Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV90Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV90Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV94Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV95Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV95Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV96Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV96Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV101Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV101Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV102Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV102Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV103Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV104Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV105Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV106Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV107Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV108Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV109Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV110Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV111Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV112Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV113Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV114Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV115Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV116Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV117Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV118Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV119Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV120Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006C3,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 3);
                ((string[]) buf[7])[0] = rslt.getString(6, 80);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 20);
                ((string[]) buf[12])[0] = rslt.getString(10, 30);
                ((string[]) buf[13])[0] = rslt.getString(11, 30);
                ((string[]) buf[14])[0] = rslt.getString(12, 30);
                ((string[]) buf[15])[0] = rslt.getString(13, 30);
                ((string[]) buf[16])[0] = rslt.getString(14, 20);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
