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
   public class rubrosmedidasrubroswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public rubrosmedidasrubroswc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public rubrosmedidasrubroswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_RubrosId )
      {
         this.AV8RubrosId = aP0_RubrosId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavGridactions = new GXCombobox();
         cmbProfesionalesVerDatPerSol = new GXCombobox();
         cmbProfesionalesPerAltShop = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "RubrosId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV8RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8RubrosId", StringUtil.LTrimStr( (decimal)(AV8RubrosId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV8RubrosId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "RubrosId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "RubrosId");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV16FilterFullText = GetPar( "FilterFullText");
         AV8RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
         AV20ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV54Pgmname = GetPar( "Pgmname");
         AV21TFProfesionalesId = GetPar( "TFProfesionalesId");
         AV22TFProfesionalesId_Sel = GetPar( "TFProfesionalesId_Sel");
         AV23TFProfesionalesPrimerNombre = GetPar( "TFProfesionalesPrimerNombre");
         AV24TFProfesionalesPrimerNombre_Sel = GetPar( "TFProfesionalesPrimerNombre_Sel");
         AV25TFProfesionalesSegundoNombre = GetPar( "TFProfesionalesSegundoNombre");
         AV26TFProfesionalesSegundoNombre_Sel = GetPar( "TFProfesionalesSegundoNombre_Sel");
         AV27TFProfesionalesApellidoPrimero = GetPar( "TFProfesionalesApellidoPrimero");
         AV28TFProfesionalesApellidoPrimero_Sel = GetPar( "TFProfesionalesApellidoPrimero_Sel");
         AV29TFProfesionalesApellidoSegundo = GetPar( "TFProfesionalesApellidoSegundo");
         AV30TFProfesionalesApellidoSegundo_Sel = GetPar( "TFProfesionalesApellidoSegundo_Sel");
         AV31TFProfesionalesTelefono = GetPar( "TFProfesionalesTelefono");
         AV32TFProfesionalesTelefono_Sel = GetPar( "TFProfesionalesTelefono_Sel");
         AV33TFEstadosGenericosNombre = GetPar( "TFEstadosGenericosNombre");
         AV34TFEstadosGenericosNombre_Sel = GetPar( "TFEstadosGenericosNombre_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV36TFProfesionalesVerDatPerSol_Sels);
         AV37TFProfesionalesFeedBackCant = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfesionalesFeedBackCant"), "."), 18, MidpointRounding.ToEven));
         AV38TFProfesionalesFeedBackCant_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFProfesionalesFeedBackCant_To"), "."), 18, MidpointRounding.ToEven));
         AV39TFProfesionalesFeedback = NumberUtil.Val( GetPar( "TFProfesionalesFeedback"), ".");
         AV40TFProfesionalesFeedback_To = NumberUtil.Val( GetPar( "TFProfesionalesFeedback_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV42TFProfesionalesPerAltShop_Sels);
         AV50IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV51IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV53IsAuthorized_EstadosGenericosNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_EstadosGenericosNombre"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8RubrosId, AV20ManageFiltersExecutionStep, AV54Pgmname, AV21TFProfesionalesId, AV22TFProfesionalesId_Sel, AV23TFProfesionalesPrimerNombre, AV24TFProfesionalesPrimerNombre_Sel, AV25TFProfesionalesSegundoNombre, AV26TFProfesionalesSegundoNombre_Sel, AV27TFProfesionalesApellidoPrimero, AV28TFProfesionalesApellidoPrimero_Sel, AV29TFProfesionalesApellidoSegundo, AV30TFProfesionalesApellidoSegundo_Sel, AV31TFProfesionalesTelefono, AV32TFProfesionalesTelefono_Sel, AV33TFEstadosGenericosNombre, AV34TFEstadosGenericosNombre_Sel, AV36TFProfesionalesVerDatPerSol_Sels, AV37TFProfesionalesFeedBackCant, AV38TFProfesionalesFeedBackCant_To, AV39TFProfesionalesFeedback, AV40TFProfesionalesFeedback_To, AV42TFProfesionalesPerAltShop_Sels, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV53IsAuthorized_EstadosGenericosNombre, sPrefix) ;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA292( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV54Pgmname = "RubrosMedidasRubrosWC";
               WS292( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Rubros Medidas Rubros WC", "")) ;
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
         }
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
         context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
         context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "rubrosmedidasrubroswc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8RubrosId,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("rubrosmedidasrubroswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV50IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV51IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV51IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", AV53IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( sPrefix, AV53IsAuthorized_EstadosGenericosNombre, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV48GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV43DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV43DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8RubrosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESID", StringUtil.RTrim( AV21TFProfesionalesId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESID_SEL", StringUtil.RTrim( AV22TFProfesionalesId_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESPRIMERNOMBRE", StringUtil.RTrim( AV23TFProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESPRIMERNOMBRE_SEL", StringUtil.RTrim( AV24TFProfesionalesPrimerNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESSEGUNDONOMBRE", StringUtil.RTrim( AV25TFProfesionalesSegundoNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESSEGUNDONOMBRE_SEL", StringUtil.RTrim( AV26TFProfesionalesSegundoNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESAPELLIDOPRIMERO", StringUtil.RTrim( AV27TFProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESAPELLIDOPRIMERO_SEL", StringUtil.RTrim( AV28TFProfesionalesApellidoPrimero_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESAPELLIDOSEGUNDO", StringUtil.RTrim( AV29TFProfesionalesApellidoSegundo));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESAPELLIDOSEGUNDO_SEL", StringUtil.RTrim( AV30TFProfesionalesApellidoSegundo_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESTELEFONO", StringUtil.RTrim( AV31TFProfesionalesTelefono));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESTELEFONO_SEL", StringUtil.RTrim( AV32TFProfesionalesTelefono_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSGENERICOSNOMBRE", StringUtil.RTrim( AV33TFEstadosGenericosNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFESTADOSGENERICOSNOMBRE_SEL", StringUtil.RTrim( AV34TFEstadosGenericosNombre_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFPROFESIONALESVERDATPERSOL_SELS", AV36TFProfesionalesVerDatPerSol_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFPROFESIONALESVERDATPERSOL_SELS", AV36TFProfesionalesVerDatPerSol_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESFEEDBACKCANT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37TFProfesionalesFeedBackCant), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESFEEDBACKCANT_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38TFProfesionalesFeedBackCant_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESFEEDBACK", StringUtil.LTrim( StringUtil.NToC( AV39TFProfesionalesFeedback, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESFEEDBACK_TO", StringUtil.LTrim( StringUtil.NToC( AV40TFProfesionalesFeedback_To, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFPROFESIONALESPERALTSHOP_SELS", AV42TFProfesionalesPerAltShop_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFPROFESIONALESPERALTSHOP_SELS", AV42TFProfesionalesPerAltShop_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV50IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV51IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV51IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", AV53IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( sPrefix, AV53IsAuthorized_EstadosGenericosNombre, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESVERDATPERSOL_SELSJSON", AV35TFProfesionalesVerDatPerSol_SelsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESPERALTSHOP_SELSJSON", AV41TFProfesionalesPerAltShop_SelsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFESIONALESFEEDBACK", StringUtil.LTrim( StringUtil.NToC( A270ProfesionalesFeedback, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm292( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "RubrosMedidasRubrosWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Rubros Medidas Rubros WC", "") ;
      }

      protected void WB290( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "rubrosmedidasrubroswc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
               context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
               context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
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
            GxWebStd.gx_div_start( context, divTablegridheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_RubrosMedidasRubrosWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_22_292( true) ;
         }
         else
         {
            wb_table1_22_292( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_292e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV46GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV47GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV48GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
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
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV43DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubrosId_Jsonclick, 0, "Attribute", "", "", "", "", edtRubrosId_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_RubrosMedidasRubrosWC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
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
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START292( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Rubros Medidas Rubros WC", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP290( ) ;
            }
         }
      }

      protected void WS292( )
      {
         START292( ) ;
         EVT292( ) ;
      }

      protected void EVT292( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11292 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12292 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13292 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E14292 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E15292 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavGridactions_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP290( ) ;
                              }
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              GXCCtl = "PROFESIONALESFEEDBACK_Enabled_" + sGXsfl_37_idx;
                              Profesionalesfeedback_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
                              AssignProp(sPrefix, false, Profesionalesfeedback_Internalname, "Enabled", StringUtil.BoolToStr( Profesionalesfeedback_Enabled), true);
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV49GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV49GridActions), 4, 0));
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A169ProfesionalesPhoto = cgiGet( edtProfesionalesPhoto_Internalname);
                              AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
                              AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
                              A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
                              A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
                              A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
                              A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
                              A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
                              A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
                              A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A109EstadosGenericosNombre = cgiGet( edtEstadosGenericosNombre_Internalname);
                              cmbProfesionalesVerDatPerSol.Name = cmbProfesionalesVerDatPerSol_Internalname;
                              cmbProfesionalesVerDatPerSol.CurrentValue = cgiGet( cmbProfesionalesVerDatPerSol_Internalname);
                              A267ProfesionalesVerDatPerSol = cgiGet( cmbProfesionalesVerDatPerSol_Internalname);
                              A268ProfesionalesFeedBackCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A269ProfesionalesFeedBackProm = context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackProm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbProfesionalesPerAltShop.Name = cmbProfesionalesPerAltShop_Internalname;
                              cmbProfesionalesPerAltShop.CurrentValue = cgiGet( cmbProfesionalesPerAltShop_Internalname);
                              A436ProfesionalesPerAltShop = cgiGet( cmbProfesionalesPerAltShop_Internalname);
                              n436ProfesionalesPerAltShop = false;
                              GXCCtl = "PROFESIONALESFEEDBACK_" + sGXsfl_37_idx;
                              A270ProfesionalesFeedback = context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E16292 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E17292 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E18292 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E19292 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP290( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE292( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm292( ) ;
            }
         }
      }

      protected void PA292( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rubrosmedidasrubroswc.aspx")), "rubrosmedidasrubroswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rubrosmedidasrubroswc.aspx")))) ;
                  }
                  else
                  {
                     GxWebError = 1;
                     context.HttpContext.Response.StatusDescription = 403.ToString();
                     context.HttpContext.Response.StatusCode = 403;
                     context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                     context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                     context.WriteHtmlText( "<p /><hr />") ;
                     GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  }
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "RubrosId");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( toggleJsOutput )
                     {
                        if ( context.isSpaRequest( ) )
                        {
                           enableJsOutput();
                        }
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
                                       string AV16FilterFullText ,
                                       short AV8RubrosId ,
                                       short AV20ManageFiltersExecutionStep ,
                                       string AV54Pgmname ,
                                       string AV21TFProfesionalesId ,
                                       string AV22TFProfesionalesId_Sel ,
                                       string AV23TFProfesionalesPrimerNombre ,
                                       string AV24TFProfesionalesPrimerNombre_Sel ,
                                       string AV25TFProfesionalesSegundoNombre ,
                                       string AV26TFProfesionalesSegundoNombre_Sel ,
                                       string AV27TFProfesionalesApellidoPrimero ,
                                       string AV28TFProfesionalesApellidoPrimero_Sel ,
                                       string AV29TFProfesionalesApellidoSegundo ,
                                       string AV30TFProfesionalesApellidoSegundo_Sel ,
                                       string AV31TFProfesionalesTelefono ,
                                       string AV32TFProfesionalesTelefono_Sel ,
                                       string AV33TFEstadosGenericosNombre ,
                                       string AV34TFEstadosGenericosNombre_Sel ,
                                       GxSimpleCollection<string> AV36TFProfesionalesVerDatPerSol_Sels ,
                                       long AV37TFProfesionalesFeedBackCant ,
                                       long AV38TFProfesionalesFeedBackCant_To ,
                                       decimal AV39TFProfesionalesFeedback ,
                                       decimal AV40TFProfesionalesFeedback_To ,
                                       GxSimpleCollection<string> AV42TFProfesionalesPerAltShop_Sels ,
                                       bool AV50IsAuthorized_Update ,
                                       bool AV51IsAuthorized_Delete ,
                                       bool AV53IsAuthorized_EstadosGenericosNombre ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF292( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PROFESIONALESID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFESIONALESID", StringUtil.RTrim( A120ProfesionalesId));
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
         RF292( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV54Pgmname = "RubrosMedidasRubrosWC";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV36TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV42TFProfesionalesPerAltShop_Sels ,
                                              AV22TFProfesionalesId_Sel ,
                                              AV21TFProfesionalesId ,
                                              AV24TFProfesionalesPrimerNombre_Sel ,
                                              AV23TFProfesionalesPrimerNombre ,
                                              AV26TFProfesionalesSegundoNombre_Sel ,
                                              AV25TFProfesionalesSegundoNombre ,
                                              AV28TFProfesionalesApellidoPrimero_Sel ,
                                              AV27TFProfesionalesApellidoPrimero ,
                                              AV30TFProfesionalesApellidoSegundo_Sel ,
                                              AV29TFProfesionalesApellidoSegundo ,
                                              AV32TFProfesionalesTelefono_Sel ,
                                              AV31TFProfesionalesTelefono ,
                                              AV34TFEstadosGenericosNombre_Sel ,
                                              AV33TFEstadosGenericosNombre ,
                                              AV36TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV37TFProfesionalesFeedBackCant ,
                                              AV38TFProfesionalesFeedBackCant_To ,
                                              AV39TFProfesionalesFeedback ,
                                              AV40TFProfesionalesFeedback_To ,
                                              AV42TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV16FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV8RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV21TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesId), 20, "%");
         lV23TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFProfesionalesPrimerNombre), 30, "%");
         lV25TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV25TFProfesionalesSegundoNombre), 30, "%");
         lV27TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV27TFProfesionalesApellidoPrimero), 30, "%");
         lV29TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV29TFProfesionalesApellidoSegundo), 30, "%");
         lV31TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV31TFProfesionalesTelefono), 20, "%");
         lV33TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV33TFEstadosGenericosNombre), 80, "%");
         /* Using cursor H00292 */
         pr_default.execute(0, new Object[] {AV8RubrosId, lV21TFProfesionalesId, AV22TFProfesionalesId_Sel, lV23TFProfesionalesPrimerNombre, AV24TFProfesionalesPrimerNombre_Sel, lV25TFProfesionalesSegundoNombre, AV26TFProfesionalesSegundoNombre_Sel, lV27TFProfesionalesApellidoPrimero, AV28TFProfesionalesApellidoPrimero_Sel, lV29TFProfesionalesApellidoSegundo, AV30TFProfesionalesApellidoSegundo_Sel, lV31TFProfesionalesTelefono, AV32TFProfesionalesTelefono_Sel, lV33TFEstadosGenericosNombre, AV34TFEstadosGenericosNombre_Sel, AV37TFProfesionalesFeedBackCant, AV38TFProfesionalesFeedBackCant_To, AV39TFProfesionalesFeedback, AV40TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A121RubrosId = H00292_A121RubrosId[0];
            AssignAttri(sPrefix, false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            A270ProfesionalesFeedback = H00292_A270ProfesionalesFeedback[0];
            A436ProfesionalesPerAltShop = H00292_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = H00292_n436ProfesionalesPerAltShop[0];
            A267ProfesionalesVerDatPerSol = H00292_A267ProfesionalesVerDatPerSol[0];
            A109EstadosGenericosNombre = H00292_A109EstadosGenericosNombre[0];
            A108EstadosGenericosId = H00292_A108EstadosGenericosId[0];
            A107EstadosTipo = H00292_A107EstadosTipo[0];
            A170ProfesionalesTelefono = H00292_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = H00292_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = H00292_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = H00292_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = H00292_A166ProfesionalesPrimerNombre[0];
            A40000ProfesionalesPhoto_GXI = H00292_A40000ProfesionalesPhoto_GXI[0];
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A120ProfesionalesId = H00292_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = H00292_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = H00292_A268ProfesionalesFeedBackCant[0];
            A169ProfesionalesPhoto = H00292_A169ProfesionalesPhoto[0];
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A270ProfesionalesFeedback = H00292_A270ProfesionalesFeedback[0];
            A436ProfesionalesPerAltShop = H00292_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = H00292_n436ProfesionalesPerAltShop[0];
            A267ProfesionalesVerDatPerSol = H00292_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = H00292_A108EstadosGenericosId[0];
            A107EstadosTipo = H00292_A107EstadosTipo[0];
            A170ProfesionalesTelefono = H00292_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = H00292_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = H00292_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = H00292_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = H00292_A166ProfesionalesPrimerNombre[0];
            A40000ProfesionalesPhoto_GXI = H00292_A40000ProfesionalesPhoto_GXI[0];
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A269ProfesionalesFeedBackProm = H00292_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = H00292_A268ProfesionalesFeedBackCant[0];
            A169ProfesionalesPhoto = H00292_A169ProfesionalesPhoto[0];
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A109EstadosGenericosNombre = H00292_A109EstadosGenericosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A109EstadosGenericosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF292( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E17292 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_372( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A267ProfesionalesVerDatPerSol ,
                                                 AV36TFProfesionalesVerDatPerSol_Sels ,
                                                 A436ProfesionalesPerAltShop ,
                                                 AV42TFProfesionalesPerAltShop_Sels ,
                                                 AV22TFProfesionalesId_Sel ,
                                                 AV21TFProfesionalesId ,
                                                 AV24TFProfesionalesPrimerNombre_Sel ,
                                                 AV23TFProfesionalesPrimerNombre ,
                                                 AV26TFProfesionalesSegundoNombre_Sel ,
                                                 AV25TFProfesionalesSegundoNombre ,
                                                 AV28TFProfesionalesApellidoPrimero_Sel ,
                                                 AV27TFProfesionalesApellidoPrimero ,
                                                 AV30TFProfesionalesApellidoSegundo_Sel ,
                                                 AV29TFProfesionalesApellidoSegundo ,
                                                 AV32TFProfesionalesTelefono_Sel ,
                                                 AV31TFProfesionalesTelefono ,
                                                 AV34TFEstadosGenericosNombre_Sel ,
                                                 AV33TFEstadosGenericosNombre ,
                                                 AV36TFProfesionalesVerDatPerSol_Sels.Count ,
                                                 AV37TFProfesionalesFeedBackCant ,
                                                 AV38TFProfesionalesFeedBackCant_To ,
                                                 AV39TFProfesionalesFeedback ,
                                                 AV40TFProfesionalesFeedback_To ,
                                                 AV42TFProfesionalesPerAltShop_Sels.Count ,
                                                 A120ProfesionalesId ,
                                                 A166ProfesionalesPrimerNombre ,
                                                 A191ProfesionalesSegundoNombre ,
                                                 A167ProfesionalesApellidoPrimero ,
                                                 A192ProfesionalesApellidoSegundo ,
                                                 A170ProfesionalesTelefono ,
                                                 A109EstadosGenericosNombre ,
                                                 A268ProfesionalesFeedBackCant ,
                                                 A269ProfesionalesFeedBackProm ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV16FilterFullText ,
                                                 A270ProfesionalesFeedback ,
                                                 AV8RubrosId ,
                                                 A121RubrosId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV21TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesId), 20, "%");
            lV23TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFProfesionalesPrimerNombre), 30, "%");
            lV25TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV25TFProfesionalesSegundoNombre), 30, "%");
            lV27TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV27TFProfesionalesApellidoPrimero), 30, "%");
            lV29TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV29TFProfesionalesApellidoSegundo), 30, "%");
            lV31TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV31TFProfesionalesTelefono), 20, "%");
            lV33TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV33TFEstadosGenericosNombre), 80, "%");
            /* Using cursor H00293 */
            pr_default.execute(1, new Object[] {AV8RubrosId, lV21TFProfesionalesId, AV22TFProfesionalesId_Sel, lV23TFProfesionalesPrimerNombre, AV24TFProfesionalesPrimerNombre_Sel, lV25TFProfesionalesSegundoNombre, AV26TFProfesionalesSegundoNombre_Sel, lV27TFProfesionalesApellidoPrimero, AV28TFProfesionalesApellidoPrimero_Sel, lV29TFProfesionalesApellidoSegundo, AV30TFProfesionalesApellidoSegundo_Sel, lV31TFProfesionalesTelefono, AV32TFProfesionalesTelefono_Sel, lV33TFEstadosGenericosNombre, AV34TFEstadosGenericosNombre_Sel, AV37TFProfesionalesFeedBackCant, AV38TFProfesionalesFeedBackCant_To, AV39TFProfesionalesFeedback, AV40TFProfesionalesFeedback_To});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A121RubrosId = H00293_A121RubrosId[0];
               AssignAttri(sPrefix, false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
               A270ProfesionalesFeedback = H00293_A270ProfesionalesFeedback[0];
               A436ProfesionalesPerAltShop = H00293_A436ProfesionalesPerAltShop[0];
               n436ProfesionalesPerAltShop = H00293_n436ProfesionalesPerAltShop[0];
               A267ProfesionalesVerDatPerSol = H00293_A267ProfesionalesVerDatPerSol[0];
               A109EstadosGenericosNombre = H00293_A109EstadosGenericosNombre[0];
               A108EstadosGenericosId = H00293_A108EstadosGenericosId[0];
               A107EstadosTipo = H00293_A107EstadosTipo[0];
               A170ProfesionalesTelefono = H00293_A170ProfesionalesTelefono[0];
               A192ProfesionalesApellidoSegundo = H00293_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H00293_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H00293_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H00293_A166ProfesionalesPrimerNombre[0];
               A40000ProfesionalesPhoto_GXI = H00293_A40000ProfesionalesPhoto_GXI[0];
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               A120ProfesionalesId = H00293_A120ProfesionalesId[0];
               A269ProfesionalesFeedBackProm = H00293_A269ProfesionalesFeedBackProm[0];
               A268ProfesionalesFeedBackCant = H00293_A268ProfesionalesFeedBackCant[0];
               A169ProfesionalesPhoto = H00293_A169ProfesionalesPhoto[0];
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               A270ProfesionalesFeedback = H00293_A270ProfesionalesFeedback[0];
               A436ProfesionalesPerAltShop = H00293_A436ProfesionalesPerAltShop[0];
               n436ProfesionalesPerAltShop = H00293_n436ProfesionalesPerAltShop[0];
               A267ProfesionalesVerDatPerSol = H00293_A267ProfesionalesVerDatPerSol[0];
               A108EstadosGenericosId = H00293_A108EstadosGenericosId[0];
               A107EstadosTipo = H00293_A107EstadosTipo[0];
               A170ProfesionalesTelefono = H00293_A170ProfesionalesTelefono[0];
               A192ProfesionalesApellidoSegundo = H00293_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H00293_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H00293_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H00293_A166ProfesionalesPrimerNombre[0];
               A40000ProfesionalesPhoto_GXI = H00293_A40000ProfesionalesPhoto_GXI[0];
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               A269ProfesionalesFeedBackProm = H00293_A269ProfesionalesFeedBackProm[0];
               A268ProfesionalesFeedBackCant = H00293_A268ProfesionalesFeedBackCant[0];
               A169ProfesionalesPhoto = H00293_A169ProfesionalesPhoto[0];
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               A109EstadosGenericosNombre = H00293_A109EstadosGenericosNombre[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A109EstadosGenericosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E18292 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WB290( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes292( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV50IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV51IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV51IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", AV53IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( sPrefix, AV53IsAuthorized_EstadosGenericosNombre, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PROFESIONALESID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sPrefix+sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), context));
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8RubrosId, AV20ManageFiltersExecutionStep, AV54Pgmname, AV21TFProfesionalesId, AV22TFProfesionalesId_Sel, AV23TFProfesionalesPrimerNombre, AV24TFProfesionalesPrimerNombre_Sel, AV25TFProfesionalesSegundoNombre, AV26TFProfesionalesSegundoNombre_Sel, AV27TFProfesionalesApellidoPrimero, AV28TFProfesionalesApellidoPrimero_Sel, AV29TFProfesionalesApellidoSegundo, AV30TFProfesionalesApellidoSegundo_Sel, AV31TFProfesionalesTelefono, AV32TFProfesionalesTelefono_Sel, AV33TFEstadosGenericosNombre, AV34TFEstadosGenericosNombre_Sel, AV36TFProfesionalesVerDatPerSol_Sels, AV37TFProfesionalesFeedBackCant, AV38TFProfesionalesFeedBackCant_To, AV39TFProfesionalesFeedback, AV40TFProfesionalesFeedback_To, AV42TFProfesionalesPerAltShop_Sels, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV53IsAuthorized_EstadosGenericosNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8RubrosId, AV20ManageFiltersExecutionStep, AV54Pgmname, AV21TFProfesionalesId, AV22TFProfesionalesId_Sel, AV23TFProfesionalesPrimerNombre, AV24TFProfesionalesPrimerNombre_Sel, AV25TFProfesionalesSegundoNombre, AV26TFProfesionalesSegundoNombre_Sel, AV27TFProfesionalesApellidoPrimero, AV28TFProfesionalesApellidoPrimero_Sel, AV29TFProfesionalesApellidoSegundo, AV30TFProfesionalesApellidoSegundo_Sel, AV31TFProfesionalesTelefono, AV32TFProfesionalesTelefono_Sel, AV33TFEstadosGenericosNombre, AV34TFEstadosGenericosNombre_Sel, AV36TFProfesionalesVerDatPerSol_Sels, AV37TFProfesionalesFeedBackCant, AV38TFProfesionalesFeedBackCant_To, AV39TFProfesionalesFeedback, AV40TFProfesionalesFeedback_To, AV42TFProfesionalesPerAltShop_Sels, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV53IsAuthorized_EstadosGenericosNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8RubrosId, AV20ManageFiltersExecutionStep, AV54Pgmname, AV21TFProfesionalesId, AV22TFProfesionalesId_Sel, AV23TFProfesionalesPrimerNombre, AV24TFProfesionalesPrimerNombre_Sel, AV25TFProfesionalesSegundoNombre, AV26TFProfesionalesSegundoNombre_Sel, AV27TFProfesionalesApellidoPrimero, AV28TFProfesionalesApellidoPrimero_Sel, AV29TFProfesionalesApellidoSegundo, AV30TFProfesionalesApellidoSegundo_Sel, AV31TFProfesionalesTelefono, AV32TFProfesionalesTelefono_Sel, AV33TFEstadosGenericosNombre, AV34TFEstadosGenericosNombre_Sel, AV36TFProfesionalesVerDatPerSol_Sels, AV37TFProfesionalesFeedBackCant, AV38TFProfesionalesFeedBackCant_To, AV39TFProfesionalesFeedback, AV40TFProfesionalesFeedback_To, AV42TFProfesionalesPerAltShop_Sels, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV53IsAuthorized_EstadosGenericosNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8RubrosId, AV20ManageFiltersExecutionStep, AV54Pgmname, AV21TFProfesionalesId, AV22TFProfesionalesId_Sel, AV23TFProfesionalesPrimerNombre, AV24TFProfesionalesPrimerNombre_Sel, AV25TFProfesionalesSegundoNombre, AV26TFProfesionalesSegundoNombre_Sel, AV27TFProfesionalesApellidoPrimero, AV28TFProfesionalesApellidoPrimero_Sel, AV29TFProfesionalesApellidoSegundo, AV30TFProfesionalesApellidoSegundo_Sel, AV31TFProfesionalesTelefono, AV32TFProfesionalesTelefono_Sel, AV33TFEstadosGenericosNombre, AV34TFEstadosGenericosNombre_Sel, AV36TFProfesionalesVerDatPerSol_Sels, AV37TFProfesionalesFeedBackCant, AV38TFProfesionalesFeedBackCant_To, AV39TFProfesionalesFeedback, AV40TFProfesionalesFeedback_To, AV42TFProfesionalesPerAltShop_Sels, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV53IsAuthorized_EstadosGenericosNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8RubrosId, AV20ManageFiltersExecutionStep, AV54Pgmname, AV21TFProfesionalesId, AV22TFProfesionalesId_Sel, AV23TFProfesionalesPrimerNombre, AV24TFProfesionalesPrimerNombre_Sel, AV25TFProfesionalesSegundoNombre, AV26TFProfesionalesSegundoNombre_Sel, AV27TFProfesionalesApellidoPrimero, AV28TFProfesionalesApellidoPrimero_Sel, AV29TFProfesionalesApellidoSegundo, AV30TFProfesionalesApellidoSegundo_Sel, AV31TFProfesionalesTelefono, AV32TFProfesionalesTelefono_Sel, AV33TFEstadosGenericosNombre, AV34TFEstadosGenericosNombre_Sel, AV36TFProfesionalesVerDatPerSol_Sels, AV37TFProfesionalesFeedBackCant, AV38TFProfesionalesFeedBackCant_To, AV39TFProfesionalesFeedback, AV40TFProfesionalesFeedback_To, AV42TFProfesionalesPerAltShop_Sels, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV53IsAuthorized_EstadosGenericosNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV54Pgmname = "RubrosMedidasRubrosWC";
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesPhoto_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         cmbProfesionalesVerDatPerSol.Enabled = 0;
         edtProfesionalesFeedBackCant_Enabled = 0;
         edtProfesionalesFeedBackProm_Enabled = 0;
         cmbProfesionalesPerAltShop.Enabled = 0;
         edtRubrosId_Enabled = 0;
         AssignProp(sPrefix, false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP290( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16292 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV18ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV43DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV46GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV47GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV48GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8RubrosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( sPrefix+"DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( sPrefix+"DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( sPrefix+"GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
         E16292 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16292( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_boolean1 = AV53IsAuthorized_EstadosGenericosNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion", out  GXt_boolean1) ;
         AV53IsAuthorized_EstadosGenericosNombre = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV53IsAuthorized_EstadosGenericosNombre", AV53IsAuthorized_EstadosGenericosNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_ESTADOSGENERICOSNOMBRE", GetSecureSignedToken( sPrefix, AV53IsAuthorized_EstadosGenericosNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtRubrosId_Visible = 0;
         AssignProp(sPrefix, false, edtRubrosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtRubrosId_Visible), 5, 0), true);
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
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV43DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV43DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E17292( )
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
         if ( AV20ManageFiltersExecutionStep == 1 )
         {
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV20ManageFiltersExecutionStep == 2 )
         {
            AV20ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
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
         AV46GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV46GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV46GridCurrentPage), 10, 0));
         AV47GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV47GridPageCount", StringUtil.LTrimStr( (decimal)(AV47GridPageCount), 10, 0));
         GXt_char3 = AV48GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV54Pgmname, out  GXt_char3) ;
         AV48GridAppliedFilters = GXt_char3;
         AssignAttri(sPrefix, false, "AV48GridAppliedFilters", AV48GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E12292( )
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
            AV45PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV45PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E13292( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14292( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesId") == 0 )
            {
               AV21TFProfesionalesId = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV21TFProfesionalesId", AV21TFProfesionalesId);
               AV22TFProfesionalesId_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV22TFProfesionalesId_Sel", AV22TFProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesPrimerNombre") == 0 )
            {
               AV23TFProfesionalesPrimerNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV23TFProfesionalesPrimerNombre", AV23TFProfesionalesPrimerNombre);
               AV24TFProfesionalesPrimerNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV24TFProfesionalesPrimerNombre_Sel", AV24TFProfesionalesPrimerNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesSegundoNombre") == 0 )
            {
               AV25TFProfesionalesSegundoNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV25TFProfesionalesSegundoNombre", AV25TFProfesionalesSegundoNombre);
               AV26TFProfesionalesSegundoNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV26TFProfesionalesSegundoNombre_Sel", AV26TFProfesionalesSegundoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesApellidoPrimero") == 0 )
            {
               AV27TFProfesionalesApellidoPrimero = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV27TFProfesionalesApellidoPrimero", AV27TFProfesionalesApellidoPrimero);
               AV28TFProfesionalesApellidoPrimero_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV28TFProfesionalesApellidoPrimero_Sel", AV28TFProfesionalesApellidoPrimero_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesApellidoSegundo") == 0 )
            {
               AV29TFProfesionalesApellidoSegundo = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV29TFProfesionalesApellidoSegundo", AV29TFProfesionalesApellidoSegundo);
               AV30TFProfesionalesApellidoSegundo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV30TFProfesionalesApellidoSegundo_Sel", AV30TFProfesionalesApellidoSegundo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesTelefono") == 0 )
            {
               AV31TFProfesionalesTelefono = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV31TFProfesionalesTelefono", AV31TFProfesionalesTelefono);
               AV32TFProfesionalesTelefono_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV32TFProfesionalesTelefono_Sel", AV32TFProfesionalesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstadosGenericosNombre") == 0 )
            {
               AV33TFEstadosGenericosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV33TFEstadosGenericosNombre", AV33TFEstadosGenericosNombre);
               AV34TFEstadosGenericosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV34TFEstadosGenericosNombre_Sel", AV34TFEstadosGenericosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesVerDatPerSol") == 0 )
            {
               AV35TFProfesionalesVerDatPerSol_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV35TFProfesionalesVerDatPerSol_SelsJson", AV35TFProfesionalesVerDatPerSol_SelsJson);
               AV36TFProfesionalesVerDatPerSol_Sels.FromJSonString(AV35TFProfesionalesVerDatPerSol_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesFeedBackCant") == 0 )
            {
               AV37TFProfesionalesFeedBackCant = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV37TFProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(AV37TFProfesionalesFeedBackCant), 18, 0));
               AV38TFProfesionalesFeedBackCant_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV38TFProfesionalesFeedBackCant_To", StringUtil.LTrimStr( (decimal)(AV38TFProfesionalesFeedBackCant_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesFeedback") == 0 )
            {
               AV39TFProfesionalesFeedback = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV39TFProfesionalesFeedback", StringUtil.LTrimStr( AV39TFProfesionalesFeedback, 10, 2));
               AV40TFProfesionalesFeedback_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV40TFProfesionalesFeedback_To", StringUtil.LTrimStr( AV40TFProfesionalesFeedback_To, 10, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesPerAltShop") == 0 )
            {
               AV41TFProfesionalesPerAltShop_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV41TFProfesionalesPerAltShop_SelsJson", AV41TFProfesionalesPerAltShop_SelsJson);
               AV42TFProfesionalesPerAltShop_Sels.FromJSonString(AV41TFProfesionalesPerAltShop_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV42TFProfesionalesPerAltShop_Sels", AV42TFProfesionalesPerAltShop_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36TFProfesionalesVerDatPerSol_Sels", AV36TFProfesionalesVerDatPerSol_Sels);
      }

      private void E18292( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV50IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV51IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            edtProfesionalesPrimerNombre_Link = formatLink("profesionalesview.aspx", new object[] {UrlEncode(StringUtil.RTrim(A120ProfesionalesId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ProfesionalesId","TabCode"}) ;
            if ( AV53IsAuthorized_EstadosGenericosNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(A107EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A108EstadosGenericosId,5,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtEstadosGenericosNombre_Link = formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 37;
            }
            sendrow_372( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            context.DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49GridActions), 4, 0));
      }

      protected void E11292( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("RubrosMedidasRubrosWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV54Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("RubrosMedidasRubrosWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char3 = AV19ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "RubrosMedidasRubrosWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV19ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV54Pgmname+"GridState",  AV19ManageFiltersXml) ;
               AV12GridState.FromXml(AV19ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV36TFProfesionalesVerDatPerSol_Sels", AV36TFProfesionalesVerDatPerSol_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV42TFProfesionalesPerAltShop_Sels", AV42TFProfesionalesPerAltShop_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
      }

      protected void E19292( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV49GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV49GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV49GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV49GridActions = 0;
         AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV49GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49GridActions), 4, 0));
         AssignProp(sPrefix, false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E15292( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV50IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Update", out  GXt_boolean1) ;
         AV50IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV50IsAuthorized_Update", AV50IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Update, context));
         GXt_boolean1 = AV51IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Delete", out  GXt_boolean1) ;
         AV51IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV51IsAuthorized_Delete", AV51IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV51IsAuthorized_Delete, context));
         GXt_boolean1 = AV52TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Insert", out  GXt_boolean1) ;
         AV52TempBoolean = GXt_boolean1;
         if ( ! ( AV52TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp(sPrefix, false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV18ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "RubrosMedidasRubrosWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV18ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
         AV21TFProfesionalesId = "";
         AssignAttri(sPrefix, false, "AV21TFProfesionalesId", AV21TFProfesionalesId);
         AV22TFProfesionalesId_Sel = "";
         AssignAttri(sPrefix, false, "AV22TFProfesionalesId_Sel", AV22TFProfesionalesId_Sel);
         AV23TFProfesionalesPrimerNombre = "";
         AssignAttri(sPrefix, false, "AV23TFProfesionalesPrimerNombre", AV23TFProfesionalesPrimerNombre);
         AV24TFProfesionalesPrimerNombre_Sel = "";
         AssignAttri(sPrefix, false, "AV24TFProfesionalesPrimerNombre_Sel", AV24TFProfesionalesPrimerNombre_Sel);
         AV25TFProfesionalesSegundoNombre = "";
         AssignAttri(sPrefix, false, "AV25TFProfesionalesSegundoNombre", AV25TFProfesionalesSegundoNombre);
         AV26TFProfesionalesSegundoNombre_Sel = "";
         AssignAttri(sPrefix, false, "AV26TFProfesionalesSegundoNombre_Sel", AV26TFProfesionalesSegundoNombre_Sel);
         AV27TFProfesionalesApellidoPrimero = "";
         AssignAttri(sPrefix, false, "AV27TFProfesionalesApellidoPrimero", AV27TFProfesionalesApellidoPrimero);
         AV28TFProfesionalesApellidoPrimero_Sel = "";
         AssignAttri(sPrefix, false, "AV28TFProfesionalesApellidoPrimero_Sel", AV28TFProfesionalesApellidoPrimero_Sel);
         AV29TFProfesionalesApellidoSegundo = "";
         AssignAttri(sPrefix, false, "AV29TFProfesionalesApellidoSegundo", AV29TFProfesionalesApellidoSegundo);
         AV30TFProfesionalesApellidoSegundo_Sel = "";
         AssignAttri(sPrefix, false, "AV30TFProfesionalesApellidoSegundo_Sel", AV30TFProfesionalesApellidoSegundo_Sel);
         AV31TFProfesionalesTelefono = "";
         AssignAttri(sPrefix, false, "AV31TFProfesionalesTelefono", AV31TFProfesionalesTelefono);
         AV32TFProfesionalesTelefono_Sel = "";
         AssignAttri(sPrefix, false, "AV32TFProfesionalesTelefono_Sel", AV32TFProfesionalesTelefono_Sel);
         AV33TFEstadosGenericosNombre = "";
         AssignAttri(sPrefix, false, "AV33TFEstadosGenericosNombre", AV33TFEstadosGenericosNombre);
         AV34TFEstadosGenericosNombre_Sel = "";
         AssignAttri(sPrefix, false, "AV34TFEstadosGenericosNombre_Sel", AV34TFEstadosGenericosNombre_Sel);
         AV36TFProfesionalesVerDatPerSol_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37TFProfesionalesFeedBackCant = 0;
         AssignAttri(sPrefix, false, "AV37TFProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(AV37TFProfesionalesFeedBackCant), 18, 0));
         AV38TFProfesionalesFeedBackCant_To = 0;
         AssignAttri(sPrefix, false, "AV38TFProfesionalesFeedBackCant_To", StringUtil.LTrimStr( (decimal)(AV38TFProfesionalesFeedBackCant_To), 18, 0));
         AV39TFProfesionalesFeedback = 0;
         AssignAttri(sPrefix, false, "AV39TFProfesionalesFeedback", StringUtil.LTrimStr( AV39TFProfesionalesFeedback, 10, 2));
         AV40TFProfesionalesFeedback_To = 0;
         AssignAttri(sPrefix, false, "AV40TFProfesionalesFeedback_To", StringUtil.LTrimStr( AV40TFProfesionalesFeedback_To, 10, 2));
         AV42TFProfesionalesPerAltShop_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S192( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         CallWebObject(formatLink("profesionalesview.aspx", new object[] {UrlEncode(StringUtil.RTrim(A120ProfesionalesId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ProfesionalesId","TabCode"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S202( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
         CallWebObject(formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
         CallWebObject(formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get(AV54Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV54Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV17Session.Get(AV54Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV21TFProfesionalesId = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV21TFProfesionalesId", AV21TFProfesionalesId);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV22TFProfesionalesId_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV22TFProfesionalesId_Sel", AV22TFProfesionalesId_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV23TFProfesionalesPrimerNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFProfesionalesPrimerNombre", AV23TFProfesionalesPrimerNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV24TFProfesionalesPrimerNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFProfesionalesPrimerNombre_Sel", AV24TFProfesionalesPrimerNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV25TFProfesionalesSegundoNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFProfesionalesSegundoNombre", AV25TFProfesionalesSegundoNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV26TFProfesionalesSegundoNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV26TFProfesionalesSegundoNombre_Sel", AV26TFProfesionalesSegundoNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV27TFProfesionalesApellidoPrimero = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFProfesionalesApellidoPrimero", AV27TFProfesionalesApellidoPrimero);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV28TFProfesionalesApellidoPrimero_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFProfesionalesApellidoPrimero_Sel", AV28TFProfesionalesApellidoPrimero_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV29TFProfesionalesApellidoSegundo = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29TFProfesionalesApellidoSegundo", AV29TFProfesionalesApellidoSegundo);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV30TFProfesionalesApellidoSegundo_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV30TFProfesionalesApellidoSegundo_Sel", AV30TFProfesionalesApellidoSegundo_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV31TFProfesionalesTelefono = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV31TFProfesionalesTelefono", AV31TFProfesionalesTelefono);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV32TFProfesionalesTelefono_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV32TFProfesionalesTelefono_Sel", AV32TFProfesionalesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV33TFEstadosGenericosNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV33TFEstadosGenericosNombre", AV33TFEstadosGenericosNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV34TFEstadosGenericosNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV34TFEstadosGenericosNombre_Sel", AV34TFEstadosGenericosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESVERDATPERSOL_SEL") == 0 )
            {
               AV35TFProfesionalesVerDatPerSol_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFProfesionalesVerDatPerSol_SelsJson", AV35TFProfesionalesVerDatPerSol_SelsJson);
               AV36TFProfesionalesVerDatPerSol_Sels.FromJSonString(AV35TFProfesionalesVerDatPerSol_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESFEEDBACKCANT") == 0 )
            {
               AV37TFProfesionalesFeedBackCant = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV37TFProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(AV37TFProfesionalesFeedBackCant), 18, 0));
               AV38TFProfesionalesFeedBackCant_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV38TFProfesionalesFeedBackCant_To", StringUtil.LTrimStr( (decimal)(AV38TFProfesionalesFeedBackCant_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESFEEDBACK") == 0 )
            {
               AV39TFProfesionalesFeedback = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV39TFProfesionalesFeedback", StringUtil.LTrimStr( AV39TFProfesionalesFeedback, 10, 2));
               AV40TFProfesionalesFeedback_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV40TFProfesionalesFeedback_To", StringUtil.LTrimStr( AV40TFProfesionalesFeedback_To, 10, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPERALTSHOP_SEL") == 0 )
            {
               AV41TFProfesionalesPerAltShop_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV41TFProfesionalesPerAltShop_SelsJson", AV41TFProfesionalesPerAltShop_SelsJson);
               AV42TFProfesionalesPerAltShop_Sels.FromJSonString(AV41TFProfesionalesPerAltShop_SelsJson, null);
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesId_Sel)),  AV22TFProfesionalesId_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesPrimerNombre_Sel)),  AV24TFProfesionalesPrimerNombre_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesSegundoNombre_Sel)),  AV26TFProfesionalesSegundoNombre_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesApellidoPrimero_Sel)),  AV28TFProfesionalesApellidoPrimero_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFProfesionalesApellidoSegundo_Sel)),  AV30TFProfesionalesApellidoSegundo_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFProfesionalesTelefono_Sel)),  AV32TFProfesionalesTelefono_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEstadosGenericosNombre_Sel)),  AV34TFEstadosGenericosNombre_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV36TFProfesionalesVerDatPerSol_Sels.Count==0),  AV35TFProfesionalesVerDatPerSol_SelsJson, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV42TFProfesionalesPerAltShop_Sels.Count==0),  AV41TFProfesionalesPerAltShop_SelsJson, out  GXt_char12) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|||"+GXt_char12;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesId)),  AV21TFProfesionalesId, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesPrimerNombre)),  AV23TFProfesionalesPrimerNombre, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesSegundoNombre)),  AV25TFProfesionalesSegundoNombre, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesApellidoPrimero)),  AV27TFProfesionalesApellidoPrimero, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProfesionalesApellidoSegundo)),  AV29TFProfesionalesApellidoSegundo, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFProfesionalesTelefono)),  AV31TFProfesionalesTelefono, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEstadosGenericosNombre)),  AV33TFEstadosGenericosNombre, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = GXt_char12+"|"+GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"||"+((0==AV37TFProfesionalesFeedBackCant) ? "" : StringUtil.Str( (decimal)(AV37TFProfesionalesFeedBackCant), 18, 0))+"|"+((Convert.ToDecimal(0)==AV39TFProfesionalesFeedback) ? "" : StringUtil.Str( AV39TFProfesionalesFeedback, 10, 2))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||||||||"+((0==AV38TFProfesionalesFeedBackCant_To) ? "" : StringUtil.Str( (decimal)(AV38TFProfesionalesFeedBackCant_To), 18, 0))+"|"+((Convert.ToDecimal(0)==AV40TFProfesionalesFeedback_To) ? "" : StringUtil.Str( AV40TFProfesionalesFeedback_To, 10, 2))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV17Session.Get(AV54Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESID",  context.GetMessage( "Identidad", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesId)),  0,  AV21TFProfesionalesId,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesId_Sel)),  AV22TFProfesionalesId_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESPRIMERNOMBRE",  context.GetMessage( "Primer Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesPrimerNombre)),  0,  AV23TFProfesionalesPrimerNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesPrimerNombre_Sel)),  AV24TFProfesionalesPrimerNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESSEGUNDONOMBRE",  context.GetMessage( "Segundo Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesSegundoNombre)),  0,  AV25TFProfesionalesSegundoNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesSegundoNombre_Sel)),  AV26TFProfesionalesSegundoNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESAPELLIDOPRIMERO",  context.GetMessage( "Primer Apellido ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesApellidoPrimero)),  0,  AV27TFProfesionalesApellidoPrimero,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesApellidoPrimero_Sel)),  AV28TFProfesionalesApellidoPrimero_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESAPELLIDOSEGUNDO",  context.GetMessage( "Segundo Apellido ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProfesionalesApellidoSegundo)),  0,  AV29TFProfesionalesApellidoSegundo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFProfesionalesApellidoSegundo_Sel)),  AV30TFProfesionalesApellidoSegundo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESTELEFONO",  context.GetMessage( "Teléfono", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFProfesionalesTelefono)),  0,  AV31TFProfesionalesTelefono,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFProfesionalesTelefono_Sel)),  AV32TFProfesionalesTelefono_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFESTADOSGENERICOSNOMBRE",  context.GetMessage( "Estado", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEstadosGenericosNombre)),  0,  AV33TFEstadosGenericosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEstadosGenericosNombre_Sel)),  AV34TFEstadosGenericosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPROFESIONALESVERDATPERSOL_SEL",  context.GetMessage( "Ver datos personales de solicitudes", ""),  !(AV36TFProfesionalesVerDatPerSol_Sels.Count==0),  0,  AV36TFProfesionalesVerDatPerSol_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPROFESIONALESFEEDBACKCANT",  context.GetMessage( "FeedBack", ""),  !((0==AV37TFProfesionalesFeedBackCant)&&(0==AV38TFProfesionalesFeedBackCant_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV37TFProfesionalesFeedBackCant), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV38TFProfesionalesFeedBackCant_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPROFESIONALESFEEDBACK",  "",  !((Convert.ToDecimal(0)==AV39TFProfesionalesFeedback)&&(Convert.ToDecimal(0)==AV40TFProfesionalesFeedback_To)),  0,  StringUtil.Trim( StringUtil.Str( AV39TFProfesionalesFeedback, 10, 2)),  StringUtil.Trim( StringUtil.Str( AV40TFProfesionalesFeedback_To, 10, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPROFESIONALESPERALTSHOP_SEL",  context.GetMessage( "crear Subastas", ""),  !(AV42TFProfesionalesPerAltShop_Sels.Count==0),  0,  AV42TFProfesionalesPerAltShop_Sels.ToJSonString(false),  "") ;
         if ( ! (0==AV8RubrosId) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&RUBROSID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8RubrosId), 4, 0);
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV54Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV54Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "Profesionales";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "RubrosId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8RubrosId), 4, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV17Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table1_22_292( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV18ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_27_292( true) ;
         }
         else
         {
            wb_table2_27_292( false) ;
         }
         return  ;
      }

      protected void wb_table2_27_292e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_292e( true) ;
         }
         else
         {
            wb_table1_22_292e( false) ;
         }
      }

      protected void wb_table2_27_292( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_RubrosMedidasRubrosWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_27_292e( true) ;
         }
         else
         {
            wb_table2_27_292e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8RubrosId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8RubrosId", StringUtil.LTrimStr( (decimal)(AV8RubrosId), 4, 0));
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
         PA292( ) ;
         WS292( ) ;
         WE292( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV8RubrosId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA292( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "rubrosmedidasrubroswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA292( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8RubrosId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8RubrosId", StringUtil.LTrimStr( (decimal)(AV8RubrosId), 4, 0));
         }
         wcpOAV8RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8RubrosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8RubrosId != wcpOAV8RubrosId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8RubrosId = AV8RubrosId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8RubrosId = cgiGet( sPrefix+"AV8RubrosId_CTRL");
         if ( StringUtil.Len( sCtrlAV8RubrosId) > 0 )
         {
            AV8RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8RubrosId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8RubrosId", StringUtil.LTrimStr( (decimal)(AV8RubrosId), 4, 0));
         }
         else
         {
            AV8RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8RubrosId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA292( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS292( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS292( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8RubrosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8RubrosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8RubrosId_CTRL", StringUtil.RTrim( sCtrlAV8RubrosId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE292( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("Rating/rating.min.css", "");
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021102944", true, true, false);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("rubrosmedidasrubroswc.js", "?202673021102944", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
         context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS_"+sGXsfl_37_idx;
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID_"+sGXsfl_37_idx;
         edtProfesionalesPhoto_Internalname = sPrefix+"PROFESIONALESPHOTO_"+sGXsfl_37_idx;
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_37_idx;
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_37_idx;
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_37_idx;
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_37_idx;
         edtProfesionalesTelefono_Internalname = sPrefix+"PROFESIONALESTELEFONO_"+sGXsfl_37_idx;
         edtEstadosTipo_Internalname = sPrefix+"ESTADOSTIPO_"+sGXsfl_37_idx;
         edtEstadosGenericosId_Internalname = sPrefix+"ESTADOSGENERICOSID_"+sGXsfl_37_idx;
         edtEstadosGenericosNombre_Internalname = sPrefix+"ESTADOSGENERICOSNOMBRE_"+sGXsfl_37_idx;
         cmbProfesionalesVerDatPerSol_Internalname = sPrefix+"PROFESIONALESVERDATPERSOL_"+sGXsfl_37_idx;
         edtProfesionalesFeedBackCant_Internalname = sPrefix+"PROFESIONALESFEEDBACKCANT_"+sGXsfl_37_idx;
         edtProfesionalesFeedBackProm_Internalname = sPrefix+"PROFESIONALESFEEDBACKPROM_"+sGXsfl_37_idx;
         Profesionalesfeedback_Internalname = sPrefix+"PROFESIONALESFEEDBACK_"+sGXsfl_37_idx;
         cmbProfesionalesPerAltShop_Internalname = sPrefix+"PROFESIONALESPERALTSHOP_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS_"+sGXsfl_37_fel_idx;
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID_"+sGXsfl_37_fel_idx;
         edtProfesionalesPhoto_Internalname = sPrefix+"PROFESIONALESPHOTO_"+sGXsfl_37_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_37_fel_idx;
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_37_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_37_fel_idx;
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_37_fel_idx;
         edtProfesionalesTelefono_Internalname = sPrefix+"PROFESIONALESTELEFONO_"+sGXsfl_37_fel_idx;
         edtEstadosTipo_Internalname = sPrefix+"ESTADOSTIPO_"+sGXsfl_37_fel_idx;
         edtEstadosGenericosId_Internalname = sPrefix+"ESTADOSGENERICOSID_"+sGXsfl_37_fel_idx;
         edtEstadosGenericosNombre_Internalname = sPrefix+"ESTADOSGENERICOSNOMBRE_"+sGXsfl_37_fel_idx;
         cmbProfesionalesVerDatPerSol_Internalname = sPrefix+"PROFESIONALESVERDATPERSOL_"+sGXsfl_37_fel_idx;
         edtProfesionalesFeedBackCant_Internalname = sPrefix+"PROFESIONALESFEEDBACKCANT_"+sGXsfl_37_fel_idx;
         edtProfesionalesFeedBackProm_Internalname = sPrefix+"PROFESIONALESFEEDBACKPROM_"+sGXsfl_37_fel_idx;
         Profesionalesfeedback_Internalname = sPrefix+"PROFESIONALESFEEDBACK_"+sGXsfl_37_fel_idx;
         cmbProfesionalesPerAltShop_Internalname = sPrefix+"PROFESIONALESPERALTSHOP_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB290( ) ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_37_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV49GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV49GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV49GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV49GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVGRIDACTIONS.CLICK."+sGXsfl_37_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV49GridActions), 4, 0));
            AssignProp(sPrefix, false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A169ProfesionalesPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProfesionalesPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.PathToRelativeUrl( A169ProfesionalesPhoto));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A169ProfesionalesPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtProfesionalesPrimerNombre_Link,(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesSegundoNombre_Internalname,StringUtil.RTrim( A191ProfesionalesSegundoNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesSegundoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoSegundo_Internalname,StringUtil.RTrim( A192ProfesionalesApellidoSegundo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoSegundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesTelefono_Internalname,StringUtil.RTrim( A170ProfesionalesTelefono),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProfesionalesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosTipo_Internalname,StringUtil.RTrim( A107EstadosTipo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosGenericosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosNombre_Internalname,StringUtil.RTrim( A109EstadosGenericosNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtEstadosGenericosNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadosGenericosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "PROFESIONALESVERDATPERSOL_" + sGXsfl_37_idx;
            cmbProfesionalesVerDatPerSol.Name = GXCCtl;
            cmbProfesionalesVerDatPerSol.WebTags = "";
            cmbProfesionalesVerDatPerSol.addItem("S", context.GetMessage( "SI", ""), 0);
            cmbProfesionalesVerDatPerSol.addItem("N", context.GetMessage( "NO", ""), 0);
            if ( cmbProfesionalesVerDatPerSol.ItemCount > 0 )
            {
               A267ProfesionalesVerDatPerSol = cmbProfesionalesVerDatPerSol.getValidValue(A267ProfesionalesVerDatPerSol);
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProfesionalesVerDatPerSol,(string)cmbProfesionalesVerDatPerSol_Internalname,StringUtil.RTrim( A267ProfesionalesVerDatPerSol),(short)1,(string)cmbProfesionalesVerDatPerSol_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProfesionalesVerDatPerSol.CurrentValue = StringUtil.RTrim( A267ProfesionalesVerDatPerSol);
            AssignProp(sPrefix, false, cmbProfesionalesVerDatPerSol_Internalname, "Values", (string)(cmbProfesionalesVerDatPerSol.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesFeedBackCant_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A268ProfesionalesFeedBackCant), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesFeedBackCant_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesFeedBackProm_Internalname,StringUtil.LTrim( StringUtil.NToC( A269ProfesionalesFeedBackProm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A269ProfesionalesFeedBackProm, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesFeedBackProm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td>") ;
            }
            /* User Defined Control */
            GridRow.AddColumnProperties("usercontrol", -1, isAjaxCallMode( ), new Object[] {(string)sPrefix+"PROFESIONALESFEEDBACKContainer"+"_"+sGXsfl_37_idx,(short)1});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "PROFESIONALESPERALTSHOP_" + sGXsfl_37_idx;
            cmbProfesionalesPerAltShop.Name = GXCCtl;
            cmbProfesionalesPerAltShop.WebTags = "";
            cmbProfesionalesPerAltShop.addItem("N", context.GetMessage( "No Permitir", ""), 0);
            cmbProfesionalesPerAltShop.addItem("S", context.GetMessage( "Permitir", ""), 0);
            if ( cmbProfesionalesPerAltShop.ItemCount > 0 )
            {
               A436ProfesionalesPerAltShop = cmbProfesionalesPerAltShop.getValidValue(A436ProfesionalesPerAltShop);
               n436ProfesionalesPerAltShop = false;
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProfesionalesPerAltShop,(string)cmbProfesionalesPerAltShop_Internalname,StringUtil.RTrim( A436ProfesionalesPerAltShop),(short)1,(string)cmbProfesionalesPerAltShop_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProfesionalesPerAltShop.CurrentValue = StringUtil.RTrim( A436ProfesionalesPerAltShop);
            AssignProp(sPrefix, false, cmbProfesionalesPerAltShop_Internalname, "Values", (string)(cmbProfesionalesPerAltShop.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            send_integrity_lvl_hashes292( ) ;
            GXCCtl = "PROFESIONALESFEEDBACK_" + sGXsfl_37_idx;
            GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( A270ProfesionalesFeedback, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
            GXCCtl = "PROFESIONALESFEEDBACK_Enabled_" + sGXsfl_37_idx;
            GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.BoolToStr( Profesionalesfeedback_Enabled));
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
         }
         GXCCtl = "PROFESIONALESVERDATPERSOL_" + sGXsfl_37_idx;
         cmbProfesionalesVerDatPerSol.Name = GXCCtl;
         cmbProfesionalesVerDatPerSol.WebTags = "";
         cmbProfesionalesVerDatPerSol.addItem("S", context.GetMessage( "SI", ""), 0);
         cmbProfesionalesVerDatPerSol.addItem("N", context.GetMessage( "NO", ""), 0);
         if ( cmbProfesionalesVerDatPerSol.ItemCount > 0 )
         {
         }
         GXCCtl = "PROFESIONALESPERALTSHOP_" + sGXsfl_37_idx;
         cmbProfesionalesPerAltShop.Name = GXCCtl;
         cmbProfesionalesPerAltShop.WebTags = "";
         cmbProfesionalesPerAltShop.addItem("N", context.GetMessage( "No Permitir", ""), 0);
         cmbProfesionalesPerAltShop.addItem("S", context.GetMessage( "Permitir", ""), 0);
         if ( cmbProfesionalesPerAltShop.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
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
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Imagen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Primer Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Segundo Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Primer Apellido ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Segundo Apellido ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo de Estados", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Ver datos personales de solicitudes", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "FeedBack", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Feedback", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "crear Subastas", "")) ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A169ProfesionalesPhoto));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A166ProfesionalesPrimerNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtProfesionalesPrimerNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A191ProfesionalesSegundoNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A167ProfesionalesApellidoPrimero)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A192ProfesionalesApellidoSegundo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A170ProfesionalesTelefono)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EstadosTipo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A109EstadosGenericosNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEstadosGenericosNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A267ProfesionalesVerDatPerSol)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A268ProfesionalesFeedBackCant), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A269ProfesionalesFeedBackProm, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A436ProfesionalesPerAltShop)));
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
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         tblTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         tblTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS";
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID";
         edtProfesionalesPhoto_Internalname = sPrefix+"PROFESIONALESPHOTO";
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO";
         edtProfesionalesTelefono_Internalname = sPrefix+"PROFESIONALESTELEFONO";
         edtEstadosTipo_Internalname = sPrefix+"ESTADOSTIPO";
         edtEstadosGenericosId_Internalname = sPrefix+"ESTADOSGENERICOSID";
         edtEstadosGenericosNombre_Internalname = sPrefix+"ESTADOSGENERICOSNOMBRE";
         cmbProfesionalesVerDatPerSol_Internalname = sPrefix+"PROFESIONALESVERDATPERSOL";
         edtProfesionalesFeedBackCant_Internalname = sPrefix+"PROFESIONALESFEEDBACKCANT";
         edtProfesionalesFeedBackProm_Internalname = sPrefix+"PROFESIONALESFEEDBACKPROM";
         Profesionalesfeedback_Internalname = sPrefix+"PROFESIONALESFEEDBACK";
         cmbProfesionalesPerAltShop_Internalname = sPrefix+"PROFESIONALESPERALTSHOP";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtRubrosId_Internalname = sPrefix+"RUBROSID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         cmbProfesionalesPerAltShop_Jsonclick = "";
         Profesionalesfeedback_Enabled = Convert.ToBoolean( 0);
         edtProfesionalesFeedBackProm_Jsonclick = "";
         edtProfesionalesFeedBackCant_Jsonclick = "";
         cmbProfesionalesVerDatPerSol_Jsonclick = "";
         edtEstadosGenericosNombre_Jsonclick = "";
         edtEstadosGenericosNombre_Link = "";
         edtEstadosGenericosId_Jsonclick = "";
         edtEstadosTipo_Jsonclick = "";
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Link = "";
         edtProfesionalesId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtRubrosId_Enabled = 0;
         cmbProfesionalesPerAltShop.Enabled = 0;
         edtProfesionalesFeedBackProm_Enabled = 0;
         edtProfesionalesFeedBackCant_Enabled = 0;
         cmbProfesionalesVerDatPerSol.Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesPhoto_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtRubrosId_Jsonclick = "";
         edtRubrosId_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "||||||||18.0|10.2|";
         Ddo_grid_Datalistproc = "RubrosMedidasRubrosWCGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||||S:SI,N:NO|||N:No Permitir,S:Permitir";
         Ddo_grid_Allowmultipleselection = "|||||||T|||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|FixedValues|||FixedValues";
         Ddo_grid_Includedatalist = "T|T|T|T|T|T|T|T|||T";
         Ddo_grid_Filterisrange = "||||||||T|T|";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character|Character|Character||Numeric|Numeric|";
         Ddo_grid_Includefilter = "T|T|T|T|T|T|T||T|T|";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T|T|T|T||T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8|9||10";
         Ddo_grid_Columnids = "1:ProfesionalesId|3:ProfesionalesPrimerNombre|4:ProfesionalesSegundoNombre|5:ProfesionalesApellidoPrimero|6:ProfesionalesApellidoSegundo|7:ProfesionalesTelefono|10:EstadosGenericosNombre|11:ProfesionalesVerDatPerSol|12:ProfesionalesFeedBackCant|14:ProfesionalesFeedback|15:ProfesionalesPerAltShop";
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
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'sPrefix',type:'char'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV22TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV24TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV26TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV28TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV29TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV30TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV31TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV32TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV33TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV34TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV36TFProfesionalesVerDatPerSol_Sels',fld:'vTFPROFESIONALESVERDATPERSOL_SELS',pic:''},{av:'AV37TFProfesionalesFeedBackCant',fld:'vTFPROFESIONALESFEEDBACKCANT',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV38TFProfesionalesFeedBackCant_To',fld:'vTFPROFESIONALESFEEDBACKCANT_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFProfesionalesFeedback',fld:'vTFPROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV40TFProfesionalesFeedback_To',fld:'vTFPROFESIONALESFEEDBACK_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV42TFProfesionalesPerAltShop_Sels',fld:'vTFPROFESIONALESPERALTSHOP_SELS',pic:''},{av:'AV50IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV46GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV47GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV50IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12292',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV22TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV24TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV26TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV28TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV29TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV30TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV31TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV32TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV33TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV34TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV36TFProfesionalesVerDatPerSol_Sels',fld:'vTFPROFESIONALESVERDATPERSOL_SELS',pic:''},{av:'AV37TFProfesionalesFeedBackCant',fld:'vTFPROFESIONALESFEEDBACKCANT',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV38TFProfesionalesFeedBackCant_To',fld:'vTFPROFESIONALESFEEDBACKCANT_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFProfesionalesFeedback',fld:'vTFPROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV40TFProfesionalesFeedback_To',fld:'vTFPROFESIONALESFEEDBACK_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV42TFProfesionalesPerAltShop_Sels',fld:'vTFPROFESIONALESPERALTSHOP_SELS',pic:''},{av:'AV50IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV46GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV47GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV50IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13292',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV22TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV24TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV26TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV28TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV29TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV30TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV31TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV32TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV33TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV34TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV36TFProfesionalesVerDatPerSol_Sels',fld:'vTFPROFESIONALESVERDATPERSOL_SELS',pic:''},{av:'AV37TFProfesionalesFeedBackCant',fld:'vTFPROFESIONALESFEEDBACKCANT',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV38TFProfesionalesFeedBackCant_To',fld:'vTFPROFESIONALESFEEDBACKCANT_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFProfesionalesFeedback',fld:'vTFPROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV40TFProfesionalesFeedback_To',fld:'vTFPROFESIONALESFEEDBACK_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV42TFProfesionalesPerAltShop_Sels',fld:'vTFPROFESIONALESPERALTSHOP_SELS',pic:''},{av:'AV50IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E14292',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV22TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV24TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV26TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV28TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV29TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV30TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV31TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV32TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV33TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV34TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV36TFProfesionalesVerDatPerSol_Sels',fld:'vTFPROFESIONALESVERDATPERSOL_SELS',pic:''},{av:'AV37TFProfesionalesFeedBackCant',fld:'vTFPROFESIONALESFEEDBACKCANT',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV38TFProfesionalesFeedBackCant_To',fld:'vTFPROFESIONALESFEEDBACKCANT_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFProfesionalesFeedback',fld:'vTFPROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV40TFProfesionalesFeedback_To',fld:'vTFPROFESIONALESFEEDBACK_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV42TFProfesionalesPerAltShop_Sels',fld:'vTFPROFESIONALESPERALTSHOP_SELS',pic:''},{av:'AV50IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV41TFProfesionalesPerAltShop_SelsJson',fld:'vTFPROFESIONALESPERALTSHOP_SELSJSON',pic:'',type:'vchar'},{av:'AV42TFProfesionalesPerAltShop_Sels',fld:'vTFPROFESIONALESPERALTSHOP_SELS',pic:''},{av:'AV39TFProfesionalesFeedback',fld:'vTFPROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV40TFProfesionalesFeedback_To',fld:'vTFPROFESIONALESFEEDBACK_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV37TFProfesionalesFeedBackCant',fld:'vTFPROFESIONALESFEEDBACKCANT',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV38TFProfesionalesFeedBackCant_To',fld:'vTFPROFESIONALESFEEDBACKCANT_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFProfesionalesVerDatPerSol_SelsJson',fld:'vTFPROFESIONALESVERDATPERSOL_SELSJSON',pic:'',type:'vchar'},{av:'AV36TFProfesionalesVerDatPerSol_Sels',fld:'vTFPROFESIONALESVERDATPERSOL_SELS',pic:''},{av:'AV33TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV34TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV31TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV32TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV29TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV30TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV28TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV26TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV24TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV21TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV22TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E18292',iparms:[{av:'AV50IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'AV53IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV49GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtProfesionalesPrimerNombre_Link',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Link'},{av:'edtEstadosGenericosNombre_Link',ctrl:'ESTADOSGENERICOSNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11292',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8RubrosId',fld:'vRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV54Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV22TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV24TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV26TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV28TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV29TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV30TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV31TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV32TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV33TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV34TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV36TFProfesionalesVerDatPerSol_Sels',fld:'vTFPROFESIONALESVERDATPERSOL_SELS',pic:''},{av:'AV37TFProfesionalesFeedBackCant',fld:'vTFPROFESIONALESFEEDBACKCANT',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV38TFProfesionalesFeedBackCant_To',fld:'vTFPROFESIONALESFEEDBACKCANT_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFProfesionalesFeedback',fld:'vTFPROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV40TFProfesionalesFeedback_To',fld:'vTFPROFESIONALESFEEDBACK_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV42TFProfesionalesPerAltShop_Sels',fld:'vTFPROFESIONALESPERALTSHOP_SELS',pic:''},{av:'AV50IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV53IsAuthorized_EstadosGenericosNombre',fld:'vISAUTHORIZED_ESTADOSGENERICOSNOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV35TFProfesionalesVerDatPerSol_SelsJson',fld:'vTFPROFESIONALESVERDATPERSOL_SELSJSON',pic:'',type:'vchar'},{av:'AV41TFProfesionalesPerAltShop_SelsJson',fld:'vTFPROFESIONALESPERALTSHOP_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21TFProfesionalesId',fld:'vTFPROFESIONALESID',pic:'',type:'char'},{av:'AV22TFProfesionalesId_Sel',fld:'vTFPROFESIONALESID_SEL',pic:'',type:'char'},{av:'AV23TFProfesionalesPrimerNombre',fld:'vTFPROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'AV24TFProfesionalesPrimerNombre_Sel',fld:'vTFPROFESIONALESPRIMERNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFProfesionalesSegundoNombre',fld:'vTFPROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'AV26TFProfesionalesSegundoNombre_Sel',fld:'vTFPROFESIONALESSEGUNDONOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFProfesionalesApellidoPrimero',fld:'vTFPROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'AV28TFProfesionalesApellidoPrimero_Sel',fld:'vTFPROFESIONALESAPELLIDOPRIMERO_SEL',pic:'',type:'char'},{av:'AV29TFProfesionalesApellidoSegundo',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'AV30TFProfesionalesApellidoSegundo_Sel',fld:'vTFPROFESIONALESAPELLIDOSEGUNDO_SEL',pic:'',type:'char'},{av:'AV31TFProfesionalesTelefono',fld:'vTFPROFESIONALESTELEFONO',pic:'',type:'char'},{av:'AV32TFProfesionalesTelefono_Sel',fld:'vTFPROFESIONALESTELEFONO_SEL',pic:'',type:'char'},{av:'AV33TFEstadosGenericosNombre',fld:'vTFESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV34TFEstadosGenericosNombre_Sel',fld:'vTFESTADOSGENERICOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV36TFProfesionalesVerDatPerSol_Sels',fld:'vTFPROFESIONALESVERDATPERSOL_SELS',pic:''},{av:'AV37TFProfesionalesFeedBackCant',fld:'vTFPROFESIONALESFEEDBACKCANT',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV38TFProfesionalesFeedBackCant_To',fld:'vTFPROFESIONALESFEEDBACKCANT_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39TFProfesionalesFeedback',fld:'vTFPROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV40TFProfesionalesFeedback_To',fld:'vTFPROFESIONALESFEEDBACK_TO',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV42TFProfesionalesPerAltShop_Sels',fld:'vTFPROFESIONALESPERALTSHOP_SELS',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV41TFProfesionalesPerAltShop_SelsJson',fld:'vTFPROFESIONALESPERALTSHOP_SELSJSON',pic:'',type:'vchar'},{av:'AV35TFProfesionalesVerDatPerSol_SelsJson',fld:'vTFPROFESIONALESVERDATPERSOL_SELSJSON',pic:'',type:'vchar'},{av:'AV46GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV47GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV50IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV51IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E19292',iparms:[{av:'cmbavGridactions'},{av:'AV49GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV49GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E15292',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESPRIMERNOMBRE","{handler:'Valid_Profesionalesprimernombre',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESPRIMERNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESSEGUNDONOMBRE","{handler:'Valid_Profesionalessegundonombre',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESSEGUNDONOMBRE",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESAPELLIDOPRIMERO","{handler:'Valid_Profesionalesapellidoprimero',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESAPELLIDOPRIMERO",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESAPELLIDOSEGUNDO","{handler:'Valid_Profesionalesapellidosegundo',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESAPELLIDOSEGUNDO",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESTELEFONO","{handler:'Valid_Profesionalestelefono',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESTELEFONO",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSTIPO","{handler:'Valid_Estadostipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSTIPO",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSGENERICOSID","{handler:'Valid_Estadosgenericosid',iparms:[]");
         setEventMetadata("VALID_ESTADOSGENERICOSID",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSGENERICOSNOMBRE","{handler:'Valid_Estadosgenericosnombre',iparms:[]");
         setEventMetadata("VALID_ESTADOSGENERICOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESVERDATPERSOL","{handler:'Valid_Profesionalesverdatpersol',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESVERDATPERSOL",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKCANT","{handler:'Valid_Profesionalesfeedbackcant',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKCANT",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESPERALTSHOP","{handler:'Valid_Profesionalesperaltshop',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESPERALTSHOP",",oparms:[]}");
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
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16FilterFullText = "";
         AV54Pgmname = "";
         AV21TFProfesionalesId = "";
         AV22TFProfesionalesId_Sel = "";
         AV23TFProfesionalesPrimerNombre = "";
         AV24TFProfesionalesPrimerNombre_Sel = "";
         AV25TFProfesionalesSegundoNombre = "";
         AV26TFProfesionalesSegundoNombre_Sel = "";
         AV27TFProfesionalesApellidoPrimero = "";
         AV28TFProfesionalesApellidoPrimero_Sel = "";
         AV29TFProfesionalesApellidoSegundo = "";
         AV30TFProfesionalesApellidoSegundo_Sel = "";
         AV31TFProfesionalesTelefono = "";
         AV32TFProfesionalesTelefono_Sel = "";
         AV33TFEstadosGenericosNombre = "";
         AV34TFEstadosGenericosNombre_Sel = "";
         AV36TFProfesionalesVerDatPerSol_Sels = new GxSimpleCollection<string>();
         AV42TFProfesionalesPerAltShop_Sels = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV48GridAppliedFilters = "";
         AV43DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35TFProfesionalesVerDatPerSol_SelsJson = "";
         AV41TFProfesionalesPerAltShop_SelsJson = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtninsert_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         A120ProfesionalesId = "";
         A169ProfesionalesPhoto = "";
         A40000ProfesionalesPhoto_GXI = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A107EstadosTipo = "";
         A109EstadosGenericosNombre = "";
         A267ProfesionalesVerDatPerSol = "";
         A436ProfesionalesPerAltShop = "";
         GXDecQS = "";
         lV21TFProfesionalesId = "";
         lV23TFProfesionalesPrimerNombre = "";
         lV25TFProfesionalesSegundoNombre = "";
         lV27TFProfesionalesApellidoPrimero = "";
         lV29TFProfesionalesApellidoSegundo = "";
         lV31TFProfesionalesTelefono = "";
         lV33TFEstadosGenericosNombre = "";
         H00292_A121RubrosId = new short[1] ;
         H00292_A270ProfesionalesFeedback = new decimal[1] ;
         H00292_A436ProfesionalesPerAltShop = new string[] {""} ;
         H00292_n436ProfesionalesPerAltShop = new bool[] {false} ;
         H00292_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         H00292_A109EstadosGenericosNombre = new string[] {""} ;
         H00292_A108EstadosGenericosId = new int[1] ;
         H00292_A107EstadosTipo = new string[] {""} ;
         H00292_A170ProfesionalesTelefono = new string[] {""} ;
         H00292_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H00292_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00292_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H00292_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00292_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         H00292_A120ProfesionalesId = new string[] {""} ;
         H00292_A269ProfesionalesFeedBackProm = new decimal[1] ;
         H00292_A268ProfesionalesFeedBackCant = new long[1] ;
         H00292_A169ProfesionalesPhoto = new string[] {""} ;
         H00293_A121RubrosId = new short[1] ;
         H00293_A270ProfesionalesFeedback = new decimal[1] ;
         H00293_A436ProfesionalesPerAltShop = new string[] {""} ;
         H00293_n436ProfesionalesPerAltShop = new bool[] {false} ;
         H00293_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         H00293_A109EstadosGenericosNombre = new string[] {""} ;
         H00293_A108EstadosGenericosId = new int[1] ;
         H00293_A107EstadosTipo = new string[] {""} ;
         H00293_A170ProfesionalesTelefono = new string[] {""} ;
         H00293_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H00293_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00293_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H00293_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00293_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         H00293_A120ProfesionalesId = new string[] {""} ;
         H00293_A269ProfesionalesFeedBackProm = new decimal[1] ;
         H00293_A268ProfesionalesFeedBackCant = new long[1] ;
         H00293_A169ProfesionalesPhoto = new string[] {""} ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV19ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV17Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char5 = "";
         GXt_char12 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8RubrosId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubrosmedidasrubroswc__default(),
            new Object[][] {
                new Object[] {
               H00292_A121RubrosId, H00292_A270ProfesionalesFeedback, H00292_A436ProfesionalesPerAltShop, H00292_n436ProfesionalesPerAltShop, H00292_A267ProfesionalesVerDatPerSol, H00292_A109EstadosGenericosNombre, H00292_A108EstadosGenericosId, H00292_A107EstadosTipo, H00292_A170ProfesionalesTelefono, H00292_A192ProfesionalesApellidoSegundo,
               H00292_A167ProfesionalesApellidoPrimero, H00292_A191ProfesionalesSegundoNombre, H00292_A166ProfesionalesPrimerNombre, H00292_A40000ProfesionalesPhoto_GXI, H00292_A120ProfesionalesId, H00292_A269ProfesionalesFeedBackProm, H00292_A268ProfesionalesFeedBackCant, H00292_A169ProfesionalesPhoto
               }
               , new Object[] {
               H00293_A121RubrosId, H00293_A270ProfesionalesFeedback, H00293_A436ProfesionalesPerAltShop, H00293_n436ProfesionalesPerAltShop, H00293_A267ProfesionalesVerDatPerSol, H00293_A109EstadosGenericosNombre, H00293_A108EstadosGenericosId, H00293_A107EstadosTipo, H00293_A170ProfesionalesTelefono, H00293_A192ProfesionalesApellidoSegundo,
               H00293_A167ProfesionalesApellidoPrimero, H00293_A191ProfesionalesSegundoNombre, H00293_A166ProfesionalesPrimerNombre, H00293_A40000ProfesionalesPhoto_GXI, H00293_A120ProfesionalesId, H00293_A269ProfesionalesFeedBackProm, H00293_A268ProfesionalesFeedBackCant, H00293_A169ProfesionalesPhoto
               }
            }
         );
         AV54Pgmname = "RubrosMedidasRubrosWC";
         /* GeneXus formulas. */
         AV54Pgmname = "RubrosMedidasRubrosWC";
      }

      private short AV8RubrosId ;
      private short wcpOAV8RubrosId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV20ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short A121RubrosId ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV49GridActions ;
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
      private int edtRubrosId_Visible ;
      private int A108EstadosGenericosId ;
      private int subGrid_Islastpage ;
      private int AV36TFProfesionalesVerDatPerSol_Sels_Count ;
      private int AV42TFProfesionalesPerAltShop_Sels_Count ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPhoto_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int edtEstadosTipo_Enabled ;
      private int edtEstadosGenericosId_Enabled ;
      private int edtEstadosGenericosNombre_Enabled ;
      private int edtProfesionalesFeedBackCant_Enabled ;
      private int edtProfesionalesFeedBackProm_Enabled ;
      private int edtRubrosId_Enabled ;
      private int AV45PageToGo ;
      private int AV55GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV37TFProfesionalesFeedBackCant ;
      private long AV38TFProfesionalesFeedBackCant_To ;
      private long AV46GridCurrentPage ;
      private long AV47GridPageCount ;
      private long A268ProfesionalesFeedBackCant ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV39TFProfesionalesFeedback ;
      private decimal AV40TFProfesionalesFeedback_To ;
      private decimal A270ProfesionalesFeedback ;
      private decimal A269ProfesionalesFeedBackProm ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_37_idx="0001" ;
      private string AV54Pgmname ;
      private string AV21TFProfesionalesId ;
      private string AV22TFProfesionalesId_Sel ;
      private string AV23TFProfesionalesPrimerNombre ;
      private string AV24TFProfesionalesPrimerNombre_Sel ;
      private string AV25TFProfesionalesSegundoNombre ;
      private string AV26TFProfesionalesSegundoNombre_Sel ;
      private string AV27TFProfesionalesApellidoPrimero ;
      private string AV28TFProfesionalesApellidoPrimero_Sel ;
      private string AV29TFProfesionalesApellidoSegundo ;
      private string AV30TFProfesionalesApellidoSegundo_Sel ;
      private string AV31TFProfesionalesTelefono ;
      private string AV32TFProfesionalesTelefono_Sel ;
      private string AV33TFEstadosGenericosNombre ;
      private string AV34TFEstadosGenericosNombre_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
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
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablegridheader_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string edtRubrosId_Internalname ;
      private string edtRubrosId_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string GXCCtl ;
      private string Profesionalesfeedback_Internalname ;
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Internalname ;
      private string edtProfesionalesPhoto_Internalname ;
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
      private string A107EstadosTipo ;
      private string edtEstadosTipo_Internalname ;
      private string edtEstadosGenericosId_Internalname ;
      private string A109EstadosGenericosNombre ;
      private string edtEstadosGenericosNombre_Internalname ;
      private string cmbProfesionalesVerDatPerSol_Internalname ;
      private string A267ProfesionalesVerDatPerSol ;
      private string edtProfesionalesFeedBackCant_Internalname ;
      private string edtProfesionalesFeedBackProm_Internalname ;
      private string cmbProfesionalesPerAltShop_Internalname ;
      private string A436ProfesionalesPerAltShop ;
      private string GXDecQS ;
      private string edtavFilterfulltext_Internalname ;
      private string lV21TFProfesionalesId ;
      private string lV23TFProfesionalesPrimerNombre ;
      private string lV25TFProfesionalesSegundoNombre ;
      private string lV27TFProfesionalesApellidoPrimero ;
      private string lV29TFProfesionalesApellidoSegundo ;
      private string lV31TFProfesionalesTelefono ;
      private string lV33TFEstadosGenericosNombre ;
      private string edtProfesionalesPrimerNombre_Link ;
      private string edtEstadosGenericosNombre_Link ;
      private string GXt_char3 ;
      private string GXt_char5 ;
      private string GXt_char12 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sCtrlAV8RubrosId ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtProfesionalesId_Jsonclick ;
      private string sImgUrl ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string gxphoneLink ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string edtEstadosTipo_Jsonclick ;
      private string edtEstadosGenericosId_Jsonclick ;
      private string edtEstadosGenericosNombre_Jsonclick ;
      private string cmbProfesionalesVerDatPerSol_Jsonclick ;
      private string edtProfesionalesFeedBackCant_Jsonclick ;
      private string edtProfesionalesFeedBackProm_Jsonclick ;
      private string cmbProfesionalesPerAltShop_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV50IsAuthorized_Update ;
      private bool AV51IsAuthorized_Delete ;
      private bool AV53IsAuthorized_EstadosGenericosNombre ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool Profesionalesfeedback_Enabled ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool n436ProfesionalesPerAltShop ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV52TempBoolean ;
      private bool GXt_boolean1 ;
      private bool A169ProfesionalesPhoto_IsBlob ;
      private string AV35TFProfesionalesVerDatPerSol_SelsJson ;
      private string AV41TFProfesionalesPerAltShop_SelsJson ;
      private string AV19ManageFiltersXml ;
      private string AV16FilterFullText ;
      private string AV48GridAppliedFilters ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string A169ProfesionalesPhoto ;
      private IGxSession AV17Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbProfesionalesVerDatPerSol ;
      private GXCombobox cmbProfesionalesPerAltShop ;
      private GxSimpleCollection<string> AV36TFProfesionalesVerDatPerSol_Sels ;
      private GxSimpleCollection<string> AV42TFProfesionalesPerAltShop_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV18ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV43DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private IDataStoreProvider pr_default ;
      private short[] H00292_A121RubrosId ;
      private decimal[] H00292_A270ProfesionalesFeedback ;
      private string[] H00292_A436ProfesionalesPerAltShop ;
      private bool[] H00292_n436ProfesionalesPerAltShop ;
      private string[] H00292_A267ProfesionalesVerDatPerSol ;
      private string[] H00292_A109EstadosGenericosNombre ;
      private int[] H00292_A108EstadosGenericosId ;
      private string[] H00292_A107EstadosTipo ;
      private string[] H00292_A170ProfesionalesTelefono ;
      private string[] H00292_A192ProfesionalesApellidoSegundo ;
      private string[] H00292_A167ProfesionalesApellidoPrimero ;
      private string[] H00292_A191ProfesionalesSegundoNombre ;
      private string[] H00292_A166ProfesionalesPrimerNombre ;
      private string[] H00292_A40000ProfesionalesPhoto_GXI ;
      private string[] H00292_A120ProfesionalesId ;
      private decimal[] H00292_A269ProfesionalesFeedBackProm ;
      private long[] H00292_A268ProfesionalesFeedBackCant ;
      private string[] H00292_A169ProfesionalesPhoto ;
      private short[] H00293_A121RubrosId ;
      private decimal[] H00293_A270ProfesionalesFeedback ;
      private string[] H00293_A436ProfesionalesPerAltShop ;
      private bool[] H00293_n436ProfesionalesPerAltShop ;
      private string[] H00293_A267ProfesionalesVerDatPerSol ;
      private string[] H00293_A109EstadosGenericosNombre ;
      private int[] H00293_A108EstadosGenericosId ;
      private string[] H00293_A107EstadosTipo ;
      private string[] H00293_A170ProfesionalesTelefono ;
      private string[] H00293_A192ProfesionalesApellidoSegundo ;
      private string[] H00293_A167ProfesionalesApellidoPrimero ;
      private string[] H00293_A191ProfesionalesSegundoNombre ;
      private string[] H00293_A166ProfesionalesPrimerNombre ;
      private string[] H00293_A40000ProfesionalesPhoto_GXI ;
      private string[] H00293_A120ProfesionalesId ;
      private decimal[] H00293_A269ProfesionalesFeedBackProm ;
      private long[] H00293_A268ProfesionalesFeedBackCant ;
      private string[] H00293_A169ProfesionalesPhoto ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class rubrosmedidasrubroswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00292( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV36TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV42TFProfesionalesPerAltShop_Sels ,
                                             string AV22TFProfesionalesId_Sel ,
                                             string AV21TFProfesionalesId ,
                                             string AV24TFProfesionalesPrimerNombre_Sel ,
                                             string AV23TFProfesionalesPrimerNombre ,
                                             string AV26TFProfesionalesSegundoNombre_Sel ,
                                             string AV25TFProfesionalesSegundoNombre ,
                                             string AV28TFProfesionalesApellidoPrimero_Sel ,
                                             string AV27TFProfesionalesApellidoPrimero ,
                                             string AV30TFProfesionalesApellidoSegundo_Sel ,
                                             string AV29TFProfesionalesApellidoSegundo ,
                                             string AV32TFProfesionalesTelefono_Sel ,
                                             string AV31TFProfesionalesTelefono ,
                                             string AV34TFEstadosGenericosNombre_Sel ,
                                             string AV33TFEstadosGenericosNombre ,
                                             int AV36TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV37TFProfesionalesFeedBackCant ,
                                             long AV38TFProfesionalesFeedBackCant_To ,
                                             decimal AV39TFProfesionalesFeedback ,
                                             decimal AV40TFProfesionalesFeedback_To ,
                                             int AV42TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV8RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[19];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesPerAltShop], T2.[ProfesionalesVerDatPerSol], T3.[EstadosGenericosNombre], T2.[EstadosGenericosId], T2.[EstadosTipo], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesPhoto_GXI], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant], T2.[ProfesionalesPhoto] FROM (([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV8RubrosId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV21TFProfesionalesId))");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV22TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int13[2] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV23TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV24TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int13[4] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV25TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int13[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV26TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV27TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int13[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV28TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV28TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV29TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV30TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV30TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( StringUtil.StrCmp(AV30TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV31TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV32TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV32TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( StringUtil.StrCmp(AV32TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEstadosGenericosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEstadosGenericosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV33TFEstadosGenericosNombre))");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEstadosGenericosNombre_Sel)) && ! ( StringUtil.StrCmp(AV34TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV34TFEstadosGenericosNombre_Sel)");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( StringUtil.StrCmp(AV34TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         if ( AV36TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV37TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV37TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( ! (0==AV38TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV38TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV39TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV39TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV40TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV40TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( AV42TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV42TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T1.[ProfesionalesId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T1.[ProfesionalesId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesSegundoNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesTelefono]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T3.[EstadosGenericosNombre]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T3.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesVerDatPerSol]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesVerDatPerSol] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesFeedBackCant]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesFeedBackCant] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesPerAltShop]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesPerAltShop] DESC";
         }
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_H00293( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV36TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV42TFProfesionalesPerAltShop_Sels ,
                                             string AV22TFProfesionalesId_Sel ,
                                             string AV21TFProfesionalesId ,
                                             string AV24TFProfesionalesPrimerNombre_Sel ,
                                             string AV23TFProfesionalesPrimerNombre ,
                                             string AV26TFProfesionalesSegundoNombre_Sel ,
                                             string AV25TFProfesionalesSegundoNombre ,
                                             string AV28TFProfesionalesApellidoPrimero_Sel ,
                                             string AV27TFProfesionalesApellidoPrimero ,
                                             string AV30TFProfesionalesApellidoSegundo_Sel ,
                                             string AV29TFProfesionalesApellidoSegundo ,
                                             string AV32TFProfesionalesTelefono_Sel ,
                                             string AV31TFProfesionalesTelefono ,
                                             string AV34TFEstadosGenericosNombre_Sel ,
                                             string AV33TFEstadosGenericosNombre ,
                                             int AV36TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV37TFProfesionalesFeedBackCant ,
                                             long AV38TFProfesionalesFeedBackCant_To ,
                                             decimal AV39TFProfesionalesFeedback ,
                                             decimal AV40TFProfesionalesFeedback_To ,
                                             int AV42TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV8RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[19];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesPerAltShop], T2.[ProfesionalesVerDatPerSol], T3.[EstadosGenericosNombre], T2.[EstadosGenericosId], T2.[EstadosTipo], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesPhoto_GXI], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant], T2.[ProfesionalesPhoto] FROM (([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV8RubrosId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV21TFProfesionalesId))");
         }
         else
         {
            GXv_int15[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV22TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int15[2] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV23TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int15[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV24TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int15[4] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV25TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int15[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV26TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int15[6] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV27TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int15[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV28TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV28TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int15[8] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV29TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int15[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV30TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV30TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int15[10] = 1;
         }
         if ( StringUtil.StrCmp(AV30TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV31TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int15[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV32TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV32TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int15[12] = 1;
         }
         if ( StringUtil.StrCmp(AV32TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEstadosGenericosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEstadosGenericosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV33TFEstadosGenericosNombre))");
         }
         else
         {
            GXv_int15[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFEstadosGenericosNombre_Sel)) && ! ( StringUtil.StrCmp(AV34TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV34TFEstadosGenericosNombre_Sel)");
         }
         else
         {
            GXv_int15[14] = 1;
         }
         if ( StringUtil.StrCmp(AV34TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         if ( AV36TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV37TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV37TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int15[15] = 1;
         }
         if ( ! (0==AV38TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV38TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int15[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV39TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV39TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int15[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV40TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV40TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int15[18] = 1;
         }
         if ( AV42TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV42TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T1.[ProfesionalesId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T1.[ProfesionalesId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesSegundoNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesTelefono]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T3.[EstadosGenericosNombre]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T3.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesVerDatPerSol]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesVerDatPerSol] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesFeedBackCant]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesFeedBackCant] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesPerAltShop]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RubrosId] DESC, T2.[ProfesionalesPerAltShop] DESC";
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
                     return conditional_H00292(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] , (string)dynConstraints[35] , (decimal)dynConstraints[36] , (short)dynConstraints[37] , (short)dynConstraints[38] );
               case 1 :
                     return conditional_H00293(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] , (string)dynConstraints[35] , (decimal)dynConstraints[36] , (short)dynConstraints[37] , (short)dynConstraints[38] );
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
          Object[] prmH00292;
          prmH00292 = new Object[] {
          new ParDef("@AV8RubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV21TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV22TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV23TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV24TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV25TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV26TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV27TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV28TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV29TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV30TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV31TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV32TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV33TFEstadosGenericosNombre",GXType.Char,80,0) ,
          new ParDef("@AV34TFEstadosGenericosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV37TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV38TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV39TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV40TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmH00293;
          prmH00293 = new Object[] {
          new ParDef("@AV8RubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV21TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV22TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV23TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV24TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV25TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV26TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV27TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV28TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV29TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV30TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV31TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV32TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV33TFEstadosGenericosNombre",GXType.Char,80,0) ,
          new ParDef("@AV34TFEstadosGenericosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV37TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV38TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV39TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV40TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00292", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00292,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00293", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00293,11, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 30);
                ((string[]) buf[10])[0] = rslt.getString(10, 30);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getString(12, 30);
                ((string[]) buf[13])[0] = rslt.getMultimediaUri(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 20);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
                ((long[]) buf[16])[0] = rslt.getLong(16);
                ((string[]) buf[17])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(13));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 30);
                ((string[]) buf[10])[0] = rslt.getString(10, 30);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getString(12, 30);
                ((string[]) buf[13])[0] = rslt.getMultimediaUri(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 20);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
                ((long[]) buf[16])[0] = rslt.getLong(16);
                ((string[]) buf[17])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(13));
                return;
       }
    }

 }

}
