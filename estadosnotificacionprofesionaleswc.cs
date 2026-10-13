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
   public class estadosnotificacionprofesionaleswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public estadosnotificacionprofesionaleswc( )
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

      public estadosnotificacionprofesionaleswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_EstadosTipo ,
                           int aP1_EstadosGenericosId )
      {
         this.AV8EstadosTipo = aP0_EstadosTipo;
         this.AV9EstadosGenericosId = aP1_EstadosGenericosId;
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
         chkProfesionalesEsRUT = new GXCheckbox();
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
               gxfirstwebparm = GetFirstPar( "EstadosTipo");
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
                  AV8EstadosTipo = GetPar( "EstadosTipo");
                  AssignAttri(sPrefix, false, "AV8EstadosTipo", AV8EstadosTipo);
                  AV9EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV9EstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV9EstadosGenericosId), 5, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV8EstadosTipo,(int)AV9EstadosGenericosId});
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
                  gxfirstwebparm = GetFirstPar( "EstadosTipo");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "EstadosTipo");
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
         AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV16OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV17FilterFullText = GetPar( "FilterFullText");
         AV8EstadosTipo = GetPar( "EstadosTipo");
         AV9EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
         AV21ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV34Pgmname = GetPar( "Pgmname");
         AV29IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV31IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV32IsAuthorized_BancoNombre = StringUtil.StrToBool( GetPar( "IsAuthorized_BancoNombre"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV8EstadosTipo, AV9EstadosGenericosId, AV21ManageFiltersExecutionStep, AV34Pgmname, AV29IsAuthorized_Update, AV31IsAuthorized_Delete, AV32IsAuthorized_BancoNombre, sPrefix) ;
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
            PACP2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV34Pgmname = "EstadosNotificacionProfesionalesWC";
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               WSCP2( ) ;
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
            context.SendWebValue( context.GetMessage( "Estados Notificacion Profesionales WC", "")) ;
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
            GXEncryptionTmp = "estadosnotificacionprofesionaleswc.aspx"+UrlEncode(StringUtil.RTrim(AV8EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV9EstadosGenericosId,5,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("estadosnotificacionprofesionaleswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV34Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV34Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV29IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV29IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV31IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV31IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_BANCONOMBRE", AV32IsAuthorized_BancoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_BANCONOMBRE", GetSecureSignedToken( sPrefix, AV32IsAuthorized_BancoNombre, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV16OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV17FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV19ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV19ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV27GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8EstadosTipo", StringUtil.RTrim( wcpOAV8EstadosTipo));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV9EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV34Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV34Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV16OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV29IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV29IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV31IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV31IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_BANCONOMBRE", AV32IsAuthorized_BancoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_BANCONOMBRE", GetSecureSignedToken( sPrefix, AV32IsAuthorized_BancoNombre, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV13GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV13GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vESTADOSTIPO", StringUtil.RTrim( AV8EstadosTipo));
         GxWebStd.gx_hidden_field( context, sPrefix+"vESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseFormCP2( )
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
         return "EstadosNotificacionProfesionalesWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Estados Notificacion Profesionales WC", "") ;
      }

      protected void WBCP0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "estadosnotificacionprofesionaleswc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadosNotificacionProfesionalesWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_22_CP2( true) ;
         }
         else
         {
            wb_table1_22_CP2( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_CP2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV25GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV26GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV27GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo), StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosTipo_Jsonclick, 0, "Attribute", "", "", "", "", edtEstadosTipo_Visible, 0, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EstadosNotificacionProfesionalesWC.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosGenericosId_Jsonclick, 0, "Attribute", "", "", "", "", edtEstadosGenericosId_Visible, 0, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EstadosNotificacionProfesionalesWC.htm");
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

      protected void STARTCP2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Estados Notificacion Profesionales WC", ""), 0) ;
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
               STRUPCP0( ) ;
            }
         }
      }

      protected void WSCP2( )
      {
         STARTCP2( ) ;
         EVTCP2( ) ;
      }

      protected void EVTCP2( )
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
                                 STRUPCP0( ) ;
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
                                 STRUPCP0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11CP2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPCP0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12CP2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPCP0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13CP2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPCP0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E14CP2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPCP0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E15CP2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPCP0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFilterfulltext_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPCP0( ) ;
                              }
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              AV28Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV28Update);
                              AV30Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri(sPrefix, false, edtavDelete_Internalname, AV30Delete);
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A676ProfesionalesEsRUT = StringUtil.StrToBool( cgiGet( chkProfesionalesEsRUT_Internalname));
                              n676ProfesionalesEsRUT = false;
                              A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
                              A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
                              A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
                              A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
                              A169ProfesionalesPhoto = cgiGet( edtProfesionalesPhoto_Internalname);
                              AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
                              AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
                              A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
                              A193ProfesionalesEmail = cgiGet( edtProfesionalesEmail_Internalname);
                              n193ProfesionalesEmail = false;
                              A198ProfesionalesDireccion = cgiGet( edtProfesionalesDireccion_Internalname);
                              cmbProfesionalesVerDatPerSol.Name = cmbProfesionalesVerDatPerSol_Internalname;
                              cmbProfesionalesVerDatPerSol.CurrentValue = cgiGet( cmbProfesionalesVerDatPerSol_Internalname);
                              A267ProfesionalesVerDatPerSol = cgiGet( cmbProfesionalesVerDatPerSol_Internalname);
                              cmbProfesionalesPerAltShop.Name = cmbProfesionalesPerAltShop_Internalname;
                              cmbProfesionalesPerAltShop.CurrentValue = cgiGet( cmbProfesionalesPerAltShop_Internalname);
                              A436ProfesionalesPerAltShop = cgiGet( cmbProfesionalesPerAltShop_Internalname);
                              n436ProfesionalesPerAltShop = false;
                              A196ProfesionalesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesAutoEnumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesAutoEnuZona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A677ProfesionalesExperiencia = cgiGet( edtProfesionalesExperiencia_Internalname);
                              n677ProfesionalesExperiencia = false;
                              A678ProfesionalesAceptoTerminos = context.localUtil.CToT( cgiGet( edtProfesionalesAceptoTerminos_Internalname), 0);
                              n678ProfesionalesAceptoTerminos = false;
                              A679ProfesionalesDeclaroDatosV = context.localUtil.CToT( cgiGet( edtProfesionalesDeclaroDatosV_Internalname), 0);
                              n679ProfesionalesDeclaroDatosV = false;
                              A680ProfesionalesCuentaBancaria = cgiGet( edtProfesionalesCuentaBancaria_Internalname);
                              n680ProfesionalesCuentaBancaria = false;
                              A673BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtBancoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n673BancoId = false;
                              A674BancoNombre = cgiGet( edtBancoNombre_Internalname);
                              A199ProfesionalesFechaAlta = context.localUtil.CToT( cgiGet( edtProfesionalesFechaAlta_Internalname), 0);
                              A200ProfesionalesFechaActualizado = context.localUtil.CToT( cgiGet( edtProfesionalesFechaActualizado_Internalname), 0);
                              A617ProfesionalesLimitOSF = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesLimitOSF_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n617ProfesionalesLimitOSF = false;
                              A268ProfesionalesFeedBackCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A269ProfesionalesFeedBackProm = context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackProm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E16CP2 ();
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E17CP2 ();
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E18CP2 ();
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
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV15OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV16OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
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
                                       STRUPCP0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
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

      protected void WECP2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormCP2( ) ;
            }
         }
      }

      protected void PACP2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "estadosnotificacionprofesionaleswc.aspx")), "estadosnotificacionprofesionaleswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "estadosnotificacionprofesionaleswc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "EstadosTipo");
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
                                       short AV15OrderedBy ,
                                       bool AV16OrderedDsc ,
                                       string AV17FilterFullText ,
                                       string AV8EstadosTipo ,
                                       int AV9EstadosGenericosId ,
                                       short AV21ManageFiltersExecutionStep ,
                                       string AV34Pgmname ,
                                       bool AV29IsAuthorized_Update ,
                                       bool AV31IsAuthorized_Delete ,
                                       bool AV32IsAuthorized_BancoNombre ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFCP2( ) ;
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
         RFCP2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV34Pgmname = "EstadosNotificacionProfesionalesWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV15OrderedBy ,
                                              AV16OrderedDsc ,
                                              AV17FilterFullText ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A267ProfesionalesVerDatPerSol ,
                                              A436ProfesionalesPerAltShop ,
                                              A677ProfesionalesExperiencia ,
                                              A680ProfesionalesCuentaBancaria ,
                                              A673BancoId ,
                                              A674BancoNombre ,
                                              A617ProfesionalesLimitOSF ,
                                              A268ProfesionalesFeedBackCant ,
                                              AV8EstadosTipo ,
                                              AV9EstadosGenericosId ,
                                              A107EstadosTipo ,
                                              A108EstadosGenericosId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor H00CP2 */
         pr_default.execute(0, new Object[] {AV8EstadosTipo, AV9EstadosGenericosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A107EstadosTipo = H00CP2_A107EstadosTipo[0];
            AssignAttri(sPrefix, false, "A107EstadosTipo", A107EstadosTipo);
            A108EstadosGenericosId = H00CP2_A108EstadosGenericosId[0];
            AssignAttri(sPrefix, false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            A269ProfesionalesFeedBackProm = H00CP2_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = H00CP2_A268ProfesionalesFeedBackCant[0];
            A617ProfesionalesLimitOSF = H00CP2_A617ProfesionalesLimitOSF[0];
            n617ProfesionalesLimitOSF = H00CP2_n617ProfesionalesLimitOSF[0];
            A200ProfesionalesFechaActualizado = H00CP2_A200ProfesionalesFechaActualizado[0];
            A199ProfesionalesFechaAlta = H00CP2_A199ProfesionalesFechaAlta[0];
            A674BancoNombre = H00CP2_A674BancoNombre[0];
            A673BancoId = H00CP2_A673BancoId[0];
            n673BancoId = H00CP2_n673BancoId[0];
            A680ProfesionalesCuentaBancaria = H00CP2_A680ProfesionalesCuentaBancaria[0];
            n680ProfesionalesCuentaBancaria = H00CP2_n680ProfesionalesCuentaBancaria[0];
            A679ProfesionalesDeclaroDatosV = H00CP2_A679ProfesionalesDeclaroDatosV[0];
            n679ProfesionalesDeclaroDatosV = H00CP2_n679ProfesionalesDeclaroDatosV[0];
            A678ProfesionalesAceptoTerminos = H00CP2_A678ProfesionalesAceptoTerminos[0];
            n678ProfesionalesAceptoTerminos = H00CP2_n678ProfesionalesAceptoTerminos[0];
            A677ProfesionalesExperiencia = H00CP2_A677ProfesionalesExperiencia[0];
            n677ProfesionalesExperiencia = H00CP2_n677ProfesionalesExperiencia[0];
            A197ProfesionalesAutoEnuZona = H00CP2_A197ProfesionalesAutoEnuZona[0];
            A196ProfesionalesAutoEnumerar = H00CP2_A196ProfesionalesAutoEnumerar[0];
            A436ProfesionalesPerAltShop = H00CP2_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = H00CP2_n436ProfesionalesPerAltShop[0];
            A267ProfesionalesVerDatPerSol = H00CP2_A267ProfesionalesVerDatPerSol[0];
            A198ProfesionalesDireccion = H00CP2_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = H00CP2_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = H00CP2_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = H00CP2_A170ProfesionalesTelefono[0];
            A40000ProfesionalesPhoto_GXI = H00CP2_A40000ProfesionalesPhoto_GXI[0];
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A192ProfesionalesApellidoSegundo = H00CP2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = H00CP2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = H00CP2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = H00CP2_A166ProfesionalesPrimerNombre[0];
            A676ProfesionalesEsRUT = H00CP2_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = H00CP2_n676ProfesionalesEsRUT[0];
            A120ProfesionalesId = H00CP2_A120ProfesionalesId[0];
            A169ProfesionalesPhoto = H00CP2_A169ProfesionalesPhoto[0];
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A674BancoNombre = H00CP2_A674BancoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A193ProfesionalesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A198ProfesionalesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV17FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV17FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV17FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV17FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A677ProfesionalesExperiencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A680ProfesionalesCuentaBancaria) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A673BancoId), 18, 0) , StringUtil.PadR( "%" + AV17FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A674BancoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A617ProfesionalesLimitOSF), 4, 0) , StringUtil.PadR( "%" + AV17FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV17FilterFullText , 254 , "%"),  ' ' ) ) )
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

      protected void RFCP2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E17CP2 ();
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
                                                 AV15OrderedBy ,
                                                 AV16OrderedDsc ,
                                                 AV17FilterFullText ,
                                                 A120ProfesionalesId ,
                                                 A166ProfesionalesPrimerNombre ,
                                                 A191ProfesionalesSegundoNombre ,
                                                 A167ProfesionalesApellidoPrimero ,
                                                 A192ProfesionalesApellidoSegundo ,
                                                 A170ProfesionalesTelefono ,
                                                 A193ProfesionalesEmail ,
                                                 A198ProfesionalesDireccion ,
                                                 A267ProfesionalesVerDatPerSol ,
                                                 A436ProfesionalesPerAltShop ,
                                                 A677ProfesionalesExperiencia ,
                                                 A680ProfesionalesCuentaBancaria ,
                                                 A673BancoId ,
                                                 A674BancoNombre ,
                                                 A617ProfesionalesLimitOSF ,
                                                 A268ProfesionalesFeedBackCant ,
                                                 AV8EstadosTipo ,
                                                 AV9EstadosGenericosId ,
                                                 A107EstadosTipo ,
                                                 A108EstadosGenericosId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            /* Using cursor H00CP3 */
            pr_default.execute(1, new Object[] {AV8EstadosTipo, AV9EstadosGenericosId});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A107EstadosTipo = H00CP3_A107EstadosTipo[0];
               AssignAttri(sPrefix, false, "A107EstadosTipo", A107EstadosTipo);
               A108EstadosGenericosId = H00CP3_A108EstadosGenericosId[0];
               AssignAttri(sPrefix, false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
               A269ProfesionalesFeedBackProm = H00CP3_A269ProfesionalesFeedBackProm[0];
               A268ProfesionalesFeedBackCant = H00CP3_A268ProfesionalesFeedBackCant[0];
               A617ProfesionalesLimitOSF = H00CP3_A617ProfesionalesLimitOSF[0];
               n617ProfesionalesLimitOSF = H00CP3_n617ProfesionalesLimitOSF[0];
               A200ProfesionalesFechaActualizado = H00CP3_A200ProfesionalesFechaActualizado[0];
               A199ProfesionalesFechaAlta = H00CP3_A199ProfesionalesFechaAlta[0];
               A674BancoNombre = H00CP3_A674BancoNombre[0];
               A673BancoId = H00CP3_A673BancoId[0];
               n673BancoId = H00CP3_n673BancoId[0];
               A680ProfesionalesCuentaBancaria = H00CP3_A680ProfesionalesCuentaBancaria[0];
               n680ProfesionalesCuentaBancaria = H00CP3_n680ProfesionalesCuentaBancaria[0];
               A679ProfesionalesDeclaroDatosV = H00CP3_A679ProfesionalesDeclaroDatosV[0];
               n679ProfesionalesDeclaroDatosV = H00CP3_n679ProfesionalesDeclaroDatosV[0];
               A678ProfesionalesAceptoTerminos = H00CP3_A678ProfesionalesAceptoTerminos[0];
               n678ProfesionalesAceptoTerminos = H00CP3_n678ProfesionalesAceptoTerminos[0];
               A677ProfesionalesExperiencia = H00CP3_A677ProfesionalesExperiencia[0];
               n677ProfesionalesExperiencia = H00CP3_n677ProfesionalesExperiencia[0];
               A197ProfesionalesAutoEnuZona = H00CP3_A197ProfesionalesAutoEnuZona[0];
               A196ProfesionalesAutoEnumerar = H00CP3_A196ProfesionalesAutoEnumerar[0];
               A436ProfesionalesPerAltShop = H00CP3_A436ProfesionalesPerAltShop[0];
               n436ProfesionalesPerAltShop = H00CP3_n436ProfesionalesPerAltShop[0];
               A267ProfesionalesVerDatPerSol = H00CP3_A267ProfesionalesVerDatPerSol[0];
               A198ProfesionalesDireccion = H00CP3_A198ProfesionalesDireccion[0];
               A193ProfesionalesEmail = H00CP3_A193ProfesionalesEmail[0];
               n193ProfesionalesEmail = H00CP3_n193ProfesionalesEmail[0];
               A170ProfesionalesTelefono = H00CP3_A170ProfesionalesTelefono[0];
               A40000ProfesionalesPhoto_GXI = H00CP3_A40000ProfesionalesPhoto_GXI[0];
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               A192ProfesionalesApellidoSegundo = H00CP3_A192ProfesionalesApellidoSegundo[0];
               A167ProfesionalesApellidoPrimero = H00CP3_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H00CP3_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H00CP3_A166ProfesionalesPrimerNombre[0];
               A676ProfesionalesEsRUT = H00CP3_A676ProfesionalesEsRUT[0];
               n676ProfesionalesEsRUT = H00CP3_n676ProfesionalesEsRUT[0];
               A120ProfesionalesId = H00CP3_A120ProfesionalesId[0];
               A169ProfesionalesPhoto = H00CP3_A169ProfesionalesPhoto[0];
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
               A674BancoNombre = H00CP3_A674BancoNombre[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A193ProfesionalesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A198ProfesionalesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV17FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV17FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") ==
               0 ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV17FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV17FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A677ProfesionalesExperiencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A680ProfesionalesCuentaBancaria) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A673BancoId), 18, 0) , StringUtil.PadR( "%" + AV17FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A674BancoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV17FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A617ProfesionalesLimitOSF), 4, 0) , StringUtil.PadR( "%" + AV17FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV17FilterFullText , 254 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E18CP2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WBCP0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesCP2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV34Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV34Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV29IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV29IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV31IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV31IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_BANCONOMBRE", AV32IsAuthorized_BancoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_BANCONOMBRE", GetSecureSignedToken( sPrefix, AV32IsAuthorized_BancoNombre, context));
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV8EstadosTipo, AV9EstadosGenericosId, AV21ManageFiltersExecutionStep, AV34Pgmname, AV29IsAuthorized_Update, AV31IsAuthorized_Delete, AV32IsAuthorized_BancoNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV8EstadosTipo, AV9EstadosGenericosId, AV21ManageFiltersExecutionStep, AV34Pgmname, AV29IsAuthorized_Update, AV31IsAuthorized_Delete, AV32IsAuthorized_BancoNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV8EstadosTipo, AV9EstadosGenericosId, AV21ManageFiltersExecutionStep, AV34Pgmname, AV29IsAuthorized_Update, AV31IsAuthorized_Delete, AV32IsAuthorized_BancoNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV8EstadosTipo, AV9EstadosGenericosId, AV21ManageFiltersExecutionStep, AV34Pgmname, AV29IsAuthorized_Update, AV31IsAuthorized_Delete, AV32IsAuthorized_BancoNombre, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV17FilterFullText, AV8EstadosTipo, AV9EstadosGenericosId, AV21ManageFiltersExecutionStep, AV34Pgmname, AV29IsAuthorized_Update, AV31IsAuthorized_Delete, AV32IsAuthorized_BancoNombre, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV34Pgmname = "EstadosNotificacionProfesionalesWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         chkProfesionalesEsRUT.Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesPhoto_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesEmail_Enabled = 0;
         edtProfesionalesDireccion_Enabled = 0;
         cmbProfesionalesVerDatPerSol.Enabled = 0;
         cmbProfesionalesPerAltShop.Enabled = 0;
         edtProfesionalesAutoEnumerar_Enabled = 0;
         edtProfesionalesAutoEnuZona_Enabled = 0;
         edtProfesionalesExperiencia_Enabled = 0;
         edtProfesionalesAceptoTerminos_Enabled = 0;
         edtProfesionalesDeclaroDatosV_Enabled = 0;
         edtProfesionalesCuentaBancaria_Enabled = 0;
         edtBancoId_Enabled = 0;
         edtBancoNombre_Enabled = 0;
         edtProfesionalesFechaAlta_Enabled = 0;
         edtProfesionalesFechaActualizado_Enabled = 0;
         edtProfesionalesLimitOSF_Enabled = 0;
         edtProfesionalesFeedBackCant_Enabled = 0;
         edtProfesionalesFeedBackProm_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         edtEstadosGenericosId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPCP0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16CP2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV19ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV22DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV25GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV26GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV27GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8EstadosTipo = cgiGet( sPrefix+"wcpOAV8EstadosTipo");
            wcpOAV9EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9EstadosGenericosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( sPrefix+"GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV17FilterFullText", AV17FilterFullText);
            A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
            AssignAttri(sPrefix, false, "A107EstadosTipo", A107EstadosTipo);
            A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV15OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV16OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
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
         E16CP2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16CP2( )
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
         GXt_boolean1 = AV32IsAuthorized_BancoNombre;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWBanco", out  GXt_boolean1) ;
         AV32IsAuthorized_BancoNombre = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV32IsAuthorized_BancoNombre", AV32IsAuthorized_BancoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_BANCONOMBRE", GetSecureSignedToken( sPrefix, AV32IsAuthorized_BancoNombre, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtEstadosTipo_Visible = 0;
         AssignProp(sPrefix, false, edtEstadosTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Visible), 5, 0), true);
         edtEstadosGenericosId_Visible = 0;
         AssignProp(sPrefix, false, edtEstadosGenericosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Visible), 5, 0), true);
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
         if ( AV15OrderedBy < 1 )
         {
            AV15OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV22DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV22DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E17CP2( )
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
         if ( AV21ManageFiltersExecutionStep == 1 )
         {
            AV21ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV21ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV21ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV21ManageFiltersExecutionStep == 2 )
         {
            AV21ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV21ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV21ManageFiltersExecutionStep), 1, 0));
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
         AV25GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV25GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV25GridCurrentPage), 10, 0));
         AV26GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV26GridPageCount", StringUtil.LTrimStr( (decimal)(AV26GridPageCount), 10, 0));
         GXt_char3 = AV27GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV34Pgmname, out  GXt_char3) ;
         AV27GridAppliedFilters = GXt_char3;
         AssignAttri(sPrefix, false, "AV27GridAppliedFilters", AV27GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19ManageFiltersData", AV19ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13GridState", AV13GridState);
      }

      protected void E12CP2( )
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
            AV24PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV24PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19ManageFiltersData", AV19ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13GridState", AV13GridState);
      }

      protected void E13CP2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14CP2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            AV16OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E18CP2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV28Update = "<i class=\"fa fa-pen\"></i>";
            AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV28Update);
            if ( AV29IsAuthorized_Update )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
               edtavUpdate_Link = formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            AV30Delete = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavDelete_Internalname, AV30Delete);
            if ( AV31IsAuthorized_Delete )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A120ProfesionalesId));
               edtavDelete_Link = formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            edtProfesionalesPrimerNombre_Link = formatLink("profesionalesview.aspx", new object[] {UrlEncode(StringUtil.RTrim(A120ProfesionalesId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ProfesionalesId","TabCode"}) ;
            if ( AV32IsAuthorized_BancoNombre )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "bancoview.aspx"+UrlEncode(StringUtil.LTrimStr(A673BancoId,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtBancoNombre_Link = formatLink("bancoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
      }

      protected void E11CP2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("EstadosNotificacionProfesionalesWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV34Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV21ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV21ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV21ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("EstadosNotificacionProfesionalesWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV21ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV21ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV21ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char3 = AV20ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "EstadosNotificacionProfesionalesWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV20ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV34Pgmname+"GridState",  AV20ManageFiltersXml) ;
               AV13GridState.FromXml(AV20ManageFiltersXml, null, "", "");
               AV15OrderedBy = AV13GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
               AV16OrderedDsc = AV13GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13GridState", AV13GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV19ManageFiltersData", AV19ManageFiltersData);
      }

      protected void E15CP2( )
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
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV15OrderedBy), 4, 0))+":"+(AV16OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV29IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Update", out  GXt_boolean1) ;
         AV29IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV29IsAuthorized_Update", AV29IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV29IsAuthorized_Update, context));
         if ( ! ( AV29IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV31IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Delete", out  GXt_boolean1) ;
         AV31IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV31IsAuthorized_Delete", AV31IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV31IsAuthorized_Delete, context));
         if ( ! ( AV31IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean1 = AV33TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Insert", out  GXt_boolean1) ;
         AV33TempBoolean = GXt_boolean1;
         if ( ! ( AV33TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp(sPrefix, false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV19ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "EstadosNotificacionProfesionalesWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV19ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri(sPrefix, false, "AV17FilterFullText", AV17FilterFullText);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18Session.Get(AV34Pgmname+"GridState"), "") == 0 )
         {
            AV13GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV34Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV13GridState.FromXml(AV18Session.Get(AV34Pgmname+"GridState"), null, "", "");
         }
         AV15OrderedBy = AV13GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         AV16OrderedDsc = AV13GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV13GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV13GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV35GXV1 = 1;
         while ( AV35GXV1 <= AV13GridState.gxTpr_Filtervalues.Count )
         {
            AV14GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV13GridState.gxTpr_Filtervalues.Item(AV35GXV1));
            if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV17FilterFullText", AV17FilterFullText);
            }
            AV35GXV1 = (int)(AV35GXV1+1);
         }
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV13GridState.FromXml(AV18Session.Get(AV34Pgmname+"GridState"), null, "", "");
         AV13GridState.gxTpr_Orderedby = AV15OrderedBy;
         AV13GridState.gxTpr_Ordereddsc = AV16OrderedDsc;
         AV13GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         AV13GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV34Pgmname+"GridState",  AV13GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11TrnContext.gxTpr_Callerobject = AV34Pgmname;
         AV11TrnContext.gxTpr_Callerondelete = true;
         AV11TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV11TrnContext.gxTpr_Transactionname = "Profesionales";
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV12TrnContextAtt.gxTpr_Attributename = "EstadosTipo";
         AV12TrnContextAtt.gxTpr_Attributevalue = AV8EstadosTipo;
         AV11TrnContext.gxTpr_Attributes.Add(AV12TrnContextAtt, 0);
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV12TrnContextAtt.gxTpr_Attributename = "EstadosGenericosId";
         AV12TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV9EstadosGenericosId), 5, 0);
         AV11TrnContext.gxTpr_Attributes.Add(AV12TrnContextAtt, 0);
         AV18Session.Set("TrnContext", AV11TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table1_22_CP2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV19ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_27_CP2( true) ;
         }
         else
         {
            wb_table2_27_CP2( false) ;
         }
         return  ;
      }

      protected void wb_table2_27_CP2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_CP2e( true) ;
         }
         else
         {
            wb_table1_22_CP2e( false) ;
         }
      }

      protected void wb_table2_27_CP2( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_EstadosNotificacionProfesionalesWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_27_CP2e( true) ;
         }
         else
         {
            wb_table2_27_CP2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8EstadosTipo = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV8EstadosTipo", AV8EstadosTipo);
         AV9EstadosGenericosId = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV9EstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV9EstadosGenericosId), 5, 0));
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
         PACP2( ) ;
         WSCP2( ) ;
         WECP2( ) ;
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
         sCtrlAV8EstadosTipo = (string)((string)getParm(obj,0));
         sCtrlAV9EstadosGenericosId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PACP2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "estadosnotificacionprofesionaleswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PACP2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8EstadosTipo = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV8EstadosTipo", AV8EstadosTipo);
            AV9EstadosGenericosId = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV9EstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV9EstadosGenericosId), 5, 0));
         }
         wcpOAV8EstadosTipo = cgiGet( sPrefix+"wcpOAV8EstadosTipo");
         wcpOAV9EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9EstadosGenericosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV8EstadosTipo, wcpOAV8EstadosTipo) != 0 ) || ( AV9EstadosGenericosId != wcpOAV9EstadosGenericosId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8EstadosTipo = AV8EstadosTipo;
         wcpOAV9EstadosGenericosId = AV9EstadosGenericosId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8EstadosTipo = cgiGet( sPrefix+"AV8EstadosTipo_CTRL");
         if ( StringUtil.Len( sCtrlAV8EstadosTipo) > 0 )
         {
            AV8EstadosTipo = cgiGet( sCtrlAV8EstadosTipo);
            AssignAttri(sPrefix, false, "AV8EstadosTipo", AV8EstadosTipo);
         }
         else
         {
            AV8EstadosTipo = cgiGet( sPrefix+"AV8EstadosTipo_PARM");
         }
         sCtrlAV9EstadosGenericosId = cgiGet( sPrefix+"AV9EstadosGenericosId_CTRL");
         if ( StringUtil.Len( sCtrlAV9EstadosGenericosId) > 0 )
         {
            AV9EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV9EstadosGenericosId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9EstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV9EstadosGenericosId), 5, 0));
         }
         else
         {
            AV9EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV9EstadosGenericosId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PACP2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSCP2( ) ;
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
         WSCP2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8EstadosTipo_PARM", StringUtil.RTrim( AV8EstadosTipo));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8EstadosTipo)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8EstadosTipo_CTRL", StringUtil.RTrim( sCtrlAV8EstadosTipo));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9EstadosGenericosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9EstadosGenericosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9EstadosGenericosId_CTRL", StringUtil.RTrim( sCtrlAV9EstadosGenericosId));
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
         WECP2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202693200556", true, true, false);
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
         context.AddJavascriptSource("estadosnotificacionprofesionaleswc.js", "?202693200556", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
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
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_37_idx;
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID_"+sGXsfl_37_idx;
         chkProfesionalesEsRUT_Internalname = sPrefix+"PROFESIONALESESRUT_"+sGXsfl_37_idx;
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_37_idx;
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_37_idx;
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_37_idx;
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_37_idx;
         edtProfesionalesPhoto_Internalname = sPrefix+"PROFESIONALESPHOTO_"+sGXsfl_37_idx;
         edtProfesionalesTelefono_Internalname = sPrefix+"PROFESIONALESTELEFONO_"+sGXsfl_37_idx;
         edtProfesionalesEmail_Internalname = sPrefix+"PROFESIONALESEMAIL_"+sGXsfl_37_idx;
         edtProfesionalesDireccion_Internalname = sPrefix+"PROFESIONALESDIRECCION_"+sGXsfl_37_idx;
         cmbProfesionalesVerDatPerSol_Internalname = sPrefix+"PROFESIONALESVERDATPERSOL_"+sGXsfl_37_idx;
         cmbProfesionalesPerAltShop_Internalname = sPrefix+"PROFESIONALESPERALTSHOP_"+sGXsfl_37_idx;
         edtProfesionalesAutoEnumerar_Internalname = sPrefix+"PROFESIONALESAUTOENUMERAR_"+sGXsfl_37_idx;
         edtProfesionalesAutoEnuZona_Internalname = sPrefix+"PROFESIONALESAUTOENUZONA_"+sGXsfl_37_idx;
         edtProfesionalesExperiencia_Internalname = sPrefix+"PROFESIONALESEXPERIENCIA_"+sGXsfl_37_idx;
         edtProfesionalesAceptoTerminos_Internalname = sPrefix+"PROFESIONALESACEPTOTERMINOS_"+sGXsfl_37_idx;
         edtProfesionalesDeclaroDatosV_Internalname = sPrefix+"PROFESIONALESDECLARODATOSV_"+sGXsfl_37_idx;
         edtProfesionalesCuentaBancaria_Internalname = sPrefix+"PROFESIONALESCUENTABANCARIA_"+sGXsfl_37_idx;
         edtBancoId_Internalname = sPrefix+"BANCOID_"+sGXsfl_37_idx;
         edtBancoNombre_Internalname = sPrefix+"BANCONOMBRE_"+sGXsfl_37_idx;
         edtProfesionalesFechaAlta_Internalname = sPrefix+"PROFESIONALESFECHAALTA_"+sGXsfl_37_idx;
         edtProfesionalesFechaActualizado_Internalname = sPrefix+"PROFESIONALESFECHAACTUALIZADO_"+sGXsfl_37_idx;
         edtProfesionalesLimitOSF_Internalname = sPrefix+"PROFESIONALESLIMITOSF_"+sGXsfl_37_idx;
         edtProfesionalesFeedBackCant_Internalname = sPrefix+"PROFESIONALESFEEDBACKCANT_"+sGXsfl_37_idx;
         edtProfesionalesFeedBackProm_Internalname = sPrefix+"PROFESIONALESFEEDBACKPROM_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_37_fel_idx;
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID_"+sGXsfl_37_fel_idx;
         chkProfesionalesEsRUT_Internalname = sPrefix+"PROFESIONALESESRUT_"+sGXsfl_37_fel_idx;
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE_"+sGXsfl_37_fel_idx;
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE_"+sGXsfl_37_fel_idx;
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO_"+sGXsfl_37_fel_idx;
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO_"+sGXsfl_37_fel_idx;
         edtProfesionalesPhoto_Internalname = sPrefix+"PROFESIONALESPHOTO_"+sGXsfl_37_fel_idx;
         edtProfesionalesTelefono_Internalname = sPrefix+"PROFESIONALESTELEFONO_"+sGXsfl_37_fel_idx;
         edtProfesionalesEmail_Internalname = sPrefix+"PROFESIONALESEMAIL_"+sGXsfl_37_fel_idx;
         edtProfesionalesDireccion_Internalname = sPrefix+"PROFESIONALESDIRECCION_"+sGXsfl_37_fel_idx;
         cmbProfesionalesVerDatPerSol_Internalname = sPrefix+"PROFESIONALESVERDATPERSOL_"+sGXsfl_37_fel_idx;
         cmbProfesionalesPerAltShop_Internalname = sPrefix+"PROFESIONALESPERALTSHOP_"+sGXsfl_37_fel_idx;
         edtProfesionalesAutoEnumerar_Internalname = sPrefix+"PROFESIONALESAUTOENUMERAR_"+sGXsfl_37_fel_idx;
         edtProfesionalesAutoEnuZona_Internalname = sPrefix+"PROFESIONALESAUTOENUZONA_"+sGXsfl_37_fel_idx;
         edtProfesionalesExperiencia_Internalname = sPrefix+"PROFESIONALESEXPERIENCIA_"+sGXsfl_37_fel_idx;
         edtProfesionalesAceptoTerminos_Internalname = sPrefix+"PROFESIONALESACEPTOTERMINOS_"+sGXsfl_37_fel_idx;
         edtProfesionalesDeclaroDatosV_Internalname = sPrefix+"PROFESIONALESDECLARODATOSV_"+sGXsfl_37_fel_idx;
         edtProfesionalesCuentaBancaria_Internalname = sPrefix+"PROFESIONALESCUENTABANCARIA_"+sGXsfl_37_fel_idx;
         edtBancoId_Internalname = sPrefix+"BANCOID_"+sGXsfl_37_fel_idx;
         edtBancoNombre_Internalname = sPrefix+"BANCONOMBRE_"+sGXsfl_37_fel_idx;
         edtProfesionalesFechaAlta_Internalname = sPrefix+"PROFESIONALESFECHAALTA_"+sGXsfl_37_fel_idx;
         edtProfesionalesFechaActualizado_Internalname = sPrefix+"PROFESIONALESFECHAACTUALIZADO_"+sGXsfl_37_fel_idx;
         edtProfesionalesLimitOSF_Internalname = sPrefix+"PROFESIONALESLIMITOSF_"+sGXsfl_37_fel_idx;
         edtProfesionalesFeedBackCant_Internalname = sPrefix+"PROFESIONALESFEEDBACKCANT_"+sGXsfl_37_fel_idx;
         edtProfesionalesFeedBackProm_Internalname = sPrefix+"PROFESIONALESFEEDBACKPROM_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WBCP0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV28Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",context.GetMessage( "GXM_update", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV30Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "PROFESIONALESESRUT_" + sGXsfl_37_idx;
            chkProfesionalesEsRUT.Name = GXCCtl;
            chkProfesionalesEsRUT.WebTags = "";
            chkProfesionalesEsRUT.Caption = "";
            AssignProp(sPrefix, false, chkProfesionalesEsRUT_Internalname, "TitleCaption", chkProfesionalesEsRUT.Caption, !bGXsfl_37_Refreshing);
            chkProfesionalesEsRUT.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkProfesionalesEsRUT_Internalname,StringUtil.BoolToStr( A676ProfesionalesEsRUT),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPrimerNombre_Internalname,StringUtil.RTrim( A166ProfesionalesPrimerNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtProfesionalesPrimerNombre_Link,(string)"",(string)"",(string)"",(string)edtProfesionalesPrimerNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesSegundoNombre_Internalname,StringUtil.RTrim( A191ProfesionalesSegundoNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesSegundoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoPrimero_Internalname,StringUtil.RTrim( A167ProfesionalesApellidoPrimero),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoPrimero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesApellidoSegundo_Internalname,StringUtil.RTrim( A192ProfesionalesApellidoSegundo),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesApellidoSegundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
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
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A169ProfesionalesPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesTelefono_Internalname,StringUtil.RTrim( A170ProfesionalesTelefono),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProfesionalesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesEmail_Internalname,(string)A193ProfesionalesEmail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A193ProfesionalesEmail,(string)"",(string)"",context.GetMessage( "email@correo.com", ""),(string)edtProfesionalesEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesDireccion_Internalname,(string)A198ProfesionalesDireccion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A198ProfesionalesDireccion),(string)"_blank",(string)"",(string)"",(string)edtProfesionalesDireccion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbProfesionalesVerDatPerSol.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROFESIONALESVERDATPERSOL_" + sGXsfl_37_idx;
               cmbProfesionalesVerDatPerSol.Name = GXCCtl;
               cmbProfesionalesVerDatPerSol.WebTags = "";
               cmbProfesionalesVerDatPerSol.addItem("S", context.GetMessage( "SI", ""), 0);
               cmbProfesionalesVerDatPerSol.addItem("N", context.GetMessage( "NO", ""), 0);
               if ( cmbProfesionalesVerDatPerSol.ItemCount > 0 )
               {
                  A267ProfesionalesVerDatPerSol = cmbProfesionalesVerDatPerSol.getValidValue(A267ProfesionalesVerDatPerSol);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProfesionalesVerDatPerSol,(string)cmbProfesionalesVerDatPerSol_Internalname,StringUtil.RTrim( A267ProfesionalesVerDatPerSol),(short)1,(string)cmbProfesionalesVerDatPerSol_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProfesionalesVerDatPerSol.CurrentValue = StringUtil.RTrim( A267ProfesionalesVerDatPerSol);
            AssignProp(sPrefix, false, cmbProfesionalesVerDatPerSol_Internalname, "Values", (string)(cmbProfesionalesVerDatPerSol.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbProfesionalesPerAltShop.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
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
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProfesionalesPerAltShop,(string)cmbProfesionalesPerAltShop_Internalname,StringUtil.RTrim( A436ProfesionalesPerAltShop),(short)1,(string)cmbProfesionalesPerAltShop_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProfesionalesPerAltShop.CurrentValue = StringUtil.RTrim( A436ProfesionalesPerAltShop);
            AssignProp(sPrefix, false, cmbProfesionalesPerAltShop_Internalname, "Values", (string)(cmbProfesionalesPerAltShop.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesAutoEnumerar_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A196ProfesionalesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A196ProfesionalesAutoEnumerar), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesAutoEnumerar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesAutoEnuZona_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A197ProfesionalesAutoEnuZona), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesAutoEnuZona_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesExperiencia_Internalname,(string)A677ProfesionalesExperiencia,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesExperiencia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesAceptoTerminos_Internalname,context.localUtil.TToC( A678ProfesionalesAceptoTerminos, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A678ProfesionalesAceptoTerminos, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesAceptoTerminos_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesDeclaroDatosV_Internalname,context.localUtil.TToC( A679ProfesionalesDeclaroDatosV, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A679ProfesionalesDeclaroDatosV, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesDeclaroDatosV_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesCuentaBancaria_Internalname,StringUtil.RTrim( A680ProfesionalesCuentaBancaria),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesCuentaBancaria_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"CuentaBancari",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBancoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A673BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A673BancoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBancoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBancoNombre_Internalname,StringUtil.RTrim( A674BancoNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtBancoNombre_Link,(string)"",(string)"",(string)"",(string)edtBancoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesFechaAlta_Internalname,context.localUtil.TToC( A199ProfesionalesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A199ProfesionalesFechaAlta, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesFechaActualizado_Internalname,context.localUtil.TToC( A200ProfesionalesFechaActualizado, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A200ProfesionalesFechaActualizado, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesFechaActualizado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesLimitOSF_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A617ProfesionalesLimitOSF), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A617ProfesionalesLimitOSF), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesLimitOSF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesFeedBackCant_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A268ProfesionalesFeedBackCant), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesFeedBackCant_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesFeedBackProm_Internalname,StringUtil.LTrim( StringUtil.NToC( A269ProfesionalesFeedBackProm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A269ProfesionalesFeedBackProm, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesFeedBackProm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesCP2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PROFESIONALESESRUT_" + sGXsfl_37_idx;
         chkProfesionalesEsRUT.Name = GXCCtl;
         chkProfesionalesEsRUT.WebTags = "";
         chkProfesionalesEsRUT.Caption = "";
         AssignProp(sPrefix, false, chkProfesionalesEsRUT_Internalname, "TitleCaption", chkProfesionalesEsRUT.Caption, !bGXsfl_37_Refreshing);
         chkProfesionalesEsRUT.CheckedValue = "false";
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "El Documento es RUT", "")) ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Imagen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Dirección", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Ver datos personales de solicitudes", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "crear Subastas", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Serial", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Enu Zona", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Experiencia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "los terminos", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "son Verdaderos", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Bancaria", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nro", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre del Banco", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "de Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Actualizado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "sin finalizar", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "FeedBack", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Feedback", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV28Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV30Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A676ProfesionalesEsRUT)));
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
            GridColumn.AddObjectProperty("Value", context.convertURL( A169ProfesionalesPhoto));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A170ProfesionalesTelefono)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A193ProfesionalesEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A198ProfesionalesDireccion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A267ProfesionalesVerDatPerSol)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A436ProfesionalesPerAltShop)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A196ProfesionalesAutoEnumerar), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A677ProfesionalesExperiencia));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A678ProfesionalesAceptoTerminos, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A679ProfesionalesDeclaroDatosV, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A680ProfesionalesCuentaBancaria)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A673BancoId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A674BancoNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtBancoNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A199ProfesionalesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A200ProfesionalesFechaActualizado, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A617ProfesionalesLimitOSF), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A268ProfesionalesFeedBackCant), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A269ProfesionalesFeedBackProm, 18, 2, ".", ""))));
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
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID";
         chkProfesionalesEsRUT_Internalname = sPrefix+"PROFESIONALESESRUT";
         edtProfesionalesPrimerNombre_Internalname = sPrefix+"PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = sPrefix+"PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = sPrefix+"PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = sPrefix+"PROFESIONALESAPELLIDOSEGUNDO";
         edtProfesionalesPhoto_Internalname = sPrefix+"PROFESIONALESPHOTO";
         edtProfesionalesTelefono_Internalname = sPrefix+"PROFESIONALESTELEFONO";
         edtProfesionalesEmail_Internalname = sPrefix+"PROFESIONALESEMAIL";
         edtProfesionalesDireccion_Internalname = sPrefix+"PROFESIONALESDIRECCION";
         cmbProfesionalesVerDatPerSol_Internalname = sPrefix+"PROFESIONALESVERDATPERSOL";
         cmbProfesionalesPerAltShop_Internalname = sPrefix+"PROFESIONALESPERALTSHOP";
         edtProfesionalesAutoEnumerar_Internalname = sPrefix+"PROFESIONALESAUTOENUMERAR";
         edtProfesionalesAutoEnuZona_Internalname = sPrefix+"PROFESIONALESAUTOENUZONA";
         edtProfesionalesExperiencia_Internalname = sPrefix+"PROFESIONALESEXPERIENCIA";
         edtProfesionalesAceptoTerminos_Internalname = sPrefix+"PROFESIONALESACEPTOTERMINOS";
         edtProfesionalesDeclaroDatosV_Internalname = sPrefix+"PROFESIONALESDECLARODATOSV";
         edtProfesionalesCuentaBancaria_Internalname = sPrefix+"PROFESIONALESCUENTABANCARIA";
         edtBancoId_Internalname = sPrefix+"BANCOID";
         edtBancoNombre_Internalname = sPrefix+"BANCONOMBRE";
         edtProfesionalesFechaAlta_Internalname = sPrefix+"PROFESIONALESFECHAALTA";
         edtProfesionalesFechaActualizado_Internalname = sPrefix+"PROFESIONALESFECHAACTUALIZADO";
         edtProfesionalesLimitOSF_Internalname = sPrefix+"PROFESIONALESLIMITOSF";
         edtProfesionalesFeedBackCant_Internalname = sPrefix+"PROFESIONALESFEEDBACKCANT";
         edtProfesionalesFeedBackProm_Internalname = sPrefix+"PROFESIONALESFEEDBACKPROM";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtEstadosTipo_Internalname = sPrefix+"ESTADOSTIPO";
         edtEstadosGenericosId_Internalname = sPrefix+"ESTADOSGENERICOSID";
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
         edtProfesionalesFeedBackProm_Jsonclick = "";
         edtProfesionalesFeedBackCant_Jsonclick = "";
         edtProfesionalesLimitOSF_Jsonclick = "";
         edtProfesionalesFechaActualizado_Jsonclick = "";
         edtProfesionalesFechaAlta_Jsonclick = "";
         edtBancoNombre_Jsonclick = "";
         edtBancoNombre_Link = "";
         edtBancoId_Jsonclick = "";
         edtProfesionalesCuentaBancaria_Jsonclick = "";
         edtProfesionalesDeclaroDatosV_Jsonclick = "";
         edtProfesionalesAceptoTerminos_Jsonclick = "";
         edtProfesionalesExperiencia_Jsonclick = "";
         edtProfesionalesAutoEnuZona_Jsonclick = "";
         edtProfesionalesAutoEnumerar_Jsonclick = "";
         cmbProfesionalesPerAltShop_Jsonclick = "";
         cmbProfesionalesVerDatPerSol_Jsonclick = "";
         edtProfesionalesDireccion_Jsonclick = "";
         edtProfesionalesEmail_Jsonclick = "";
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Link = "";
         chkProfesionalesEsRUT.Caption = "";
         edtProfesionalesId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         edtProfesionalesFeedBackProm_Enabled = 0;
         edtProfesionalesFeedBackCant_Enabled = 0;
         edtProfesionalesLimitOSF_Enabled = 0;
         edtProfesionalesFechaActualizado_Enabled = 0;
         edtProfesionalesFechaAlta_Enabled = 0;
         edtBancoNombre_Enabled = 0;
         edtBancoId_Enabled = 0;
         edtProfesionalesCuentaBancaria_Enabled = 0;
         edtProfesionalesDeclaroDatosV_Enabled = 0;
         edtProfesionalesAceptoTerminos_Enabled = 0;
         edtProfesionalesExperiencia_Enabled = 0;
         edtProfesionalesAutoEnuZona_Enabled = 0;
         edtProfesionalesAutoEnumerar_Enabled = 0;
         cmbProfesionalesPerAltShop.Enabled = 0;
         cmbProfesionalesVerDatPerSol.Enabled = 0;
         edtProfesionalesDireccion_Enabled = 0;
         edtProfesionalesEmail_Enabled = 0;
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesPhoto_Enabled = 0;
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Enabled = 0;
         chkProfesionalesEsRUT.Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtEstadosGenericosId_Jsonclick = "";
         edtEstadosGenericosId_Visible = 1;
         edtEstadosTipo_Jsonclick = "";
         edtEstadosTipo_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;L;;;;;;;;;;;;;;;;;;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19";
         Ddo_grid_Columnids = "2:ProfesionalesId|3:ProfesionalesEsRUT|4:ProfesionalesPrimerNombre|5:ProfesionalesSegundoNombre|6:ProfesionalesApellidoPrimero|7:ProfesionalesApellidoSegundo|9:ProfesionalesTelefono|10:ProfesionalesEmail|11:ProfesionalesDireccion|12:ProfesionalesVerDatPerSol|13:ProfesionalesPerAltShop|16:ProfesionalesExperiencia|17:ProfesionalesAceptoTerminos|18:ProfesionalesDeclaroDatosV|19:ProfesionalesCuentaBancaria|20:BancoId|21:BancoNombre|24:ProfesionalesLimitOSF|25:ProfesionalesFeedBackCant";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV8EstadosTipo',fld:'vESTADOSTIPO',pic:'',type:'char'},{av:'AV9EstadosGenericosId',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'sPrefix',type:'char'},{av:'AV21ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV34Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV29IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV31IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV32IsAuthorized_BancoNombre',fld:'vISAUTHORIZED_BANCONOMBRE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV21ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV25GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV26GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV27GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV29IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV31IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV19ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV13GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12CP2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8EstadosTipo',fld:'vESTADOSTIPO',pic:'',type:'char'},{av:'AV9EstadosGenericosId',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV21ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV34Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV29IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV31IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV32IsAuthorized_BancoNombre',fld:'vISAUTHORIZED_BANCONOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV21ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV25GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV26GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV27GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV29IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV31IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV19ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV13GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13CP2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8EstadosTipo',fld:'vESTADOSTIPO',pic:'',type:'char'},{av:'AV9EstadosGenericosId',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV21ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV34Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV29IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV31IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV32IsAuthorized_BancoNombre',fld:'vISAUTHORIZED_BANCONOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E14CP2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8EstadosTipo',fld:'vESTADOSTIPO',pic:'',type:'char'},{av:'AV9EstadosGenericosId',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV21ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV34Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV29IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV31IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV32IsAuthorized_BancoNombre',fld:'vISAUTHORIZED_BANCONOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E18CP2',iparms:[{av:'AV29IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'AV31IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV32IsAuthorized_BancoNombre',fld:'vISAUTHORIZED_BANCONOMBRE',pic:'',hsh:true,type:'boolean'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV28Update',fld:'vUPDATE',pic:'',type:'char'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV30Delete',fld:'vDELETE',pic:'',type:'char'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtProfesionalesPrimerNombre_Link',ctrl:'PROFESIONALESPRIMERNOMBRE',prop:'Link'},{av:'edtBancoNombre_Link',ctrl:'BANCONOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11CP2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8EstadosTipo',fld:'vESTADOSTIPO',pic:'',type:'char'},{av:'AV9EstadosGenericosId',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV21ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV34Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV29IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV31IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV32IsAuthorized_BancoNombre',fld:'vISAUTHORIZED_BANCONOMBRE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV13GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV21ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV13GridState',fld:'vGRIDSTATE',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV25GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV26GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV27GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV29IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV31IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV19ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E15CP2',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',hsh:true,type:'char'}]");
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
         setEventMetadata("VALID_PROFESIONALESEMAIL","{handler:'Valid_Profesionalesemail',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESEMAIL",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESDIRECCION","{handler:'Valid_Profesionalesdireccion',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESDIRECCION",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESVERDATPERSOL","{handler:'Valid_Profesionalesverdatpersol',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESVERDATPERSOL",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESPERALTSHOP","{handler:'Valid_Profesionalesperaltshop',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESPERALTSHOP",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESEXPERIENCIA","{handler:'Valid_Profesionalesexperiencia',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESEXPERIENCIA",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESCUENTABANCARIA","{handler:'Valid_Profesionalescuentabancaria',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESCUENTABANCARIA",",oparms:[]}");
         setEventMetadata("VALID_BANCOID","{handler:'Valid_Bancoid',iparms:[]");
         setEventMetadata("VALID_BANCOID",",oparms:[]}");
         setEventMetadata("VALID_BANCONOMBRE","{handler:'Valid_Banconombre',iparms:[]");
         setEventMetadata("VALID_BANCONOMBRE",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESLIMITOSF","{handler:'Valid_Profesionaleslimitosf',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESLIMITOSF",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKCANT","{handler:'Valid_Profesionalesfeedbackcant',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKCANT",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Profesionalesfeedbackprom',iparms:[]");
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
         wcpOAV8EstadosTipo = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV17FilterFullText = "";
         AV34Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV19ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV27GridAppliedFilters = "";
         AV22DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
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
         A107EstadosTipo = "";
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV28Update = "";
         AV30Delete = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A169ProfesionalesPhoto = "";
         A40000ProfesionalesPhoto_GXI = "";
         A170ProfesionalesTelefono = "";
         A193ProfesionalesEmail = "";
         A198ProfesionalesDireccion = "";
         A267ProfesionalesVerDatPerSol = "";
         A436ProfesionalesPerAltShop = "";
         A677ProfesionalesExperiencia = "";
         A678ProfesionalesAceptoTerminos = (DateTime)(DateTime.MinValue);
         A679ProfesionalesDeclaroDatosV = (DateTime)(DateTime.MinValue);
         A680ProfesionalesCuentaBancaria = "";
         A674BancoNombre = "";
         A199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         lV17FilterFullText = "";
         H00CP2_A107EstadosTipo = new string[] {""} ;
         H00CP2_A108EstadosGenericosId = new int[1] ;
         H00CP2_A269ProfesionalesFeedBackProm = new decimal[1] ;
         H00CP2_A268ProfesionalesFeedBackCant = new long[1] ;
         H00CP2_A617ProfesionalesLimitOSF = new short[1] ;
         H00CP2_n617ProfesionalesLimitOSF = new bool[] {false} ;
         H00CP2_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         H00CP2_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00CP2_A674BancoNombre = new string[] {""} ;
         H00CP2_A673BancoId = new long[1] ;
         H00CP2_n673BancoId = new bool[] {false} ;
         H00CP2_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         H00CP2_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         H00CP2_A679ProfesionalesDeclaroDatosV = new DateTime[] {DateTime.MinValue} ;
         H00CP2_n679ProfesionalesDeclaroDatosV = new bool[] {false} ;
         H00CP2_A678ProfesionalesAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         H00CP2_n678ProfesionalesAceptoTerminos = new bool[] {false} ;
         H00CP2_A677ProfesionalesExperiencia = new string[] {""} ;
         H00CP2_n677ProfesionalesExperiencia = new bool[] {false} ;
         H00CP2_A197ProfesionalesAutoEnuZona = new short[1] ;
         H00CP2_A196ProfesionalesAutoEnumerar = new short[1] ;
         H00CP2_A436ProfesionalesPerAltShop = new string[] {""} ;
         H00CP2_n436ProfesionalesPerAltShop = new bool[] {false} ;
         H00CP2_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         H00CP2_A198ProfesionalesDireccion = new string[] {""} ;
         H00CP2_A193ProfesionalesEmail = new string[] {""} ;
         H00CP2_n193ProfesionalesEmail = new bool[] {false} ;
         H00CP2_A170ProfesionalesTelefono = new string[] {""} ;
         H00CP2_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         H00CP2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H00CP2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00CP2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H00CP2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00CP2_A676ProfesionalesEsRUT = new bool[] {false} ;
         H00CP2_n676ProfesionalesEsRUT = new bool[] {false} ;
         H00CP2_A120ProfesionalesId = new string[] {""} ;
         H00CP2_A169ProfesionalesPhoto = new string[] {""} ;
         H00CP3_A107EstadosTipo = new string[] {""} ;
         H00CP3_A108EstadosGenericosId = new int[1] ;
         H00CP3_A269ProfesionalesFeedBackProm = new decimal[1] ;
         H00CP3_A268ProfesionalesFeedBackCant = new long[1] ;
         H00CP3_A617ProfesionalesLimitOSF = new short[1] ;
         H00CP3_n617ProfesionalesLimitOSF = new bool[] {false} ;
         H00CP3_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         H00CP3_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00CP3_A674BancoNombre = new string[] {""} ;
         H00CP3_A673BancoId = new long[1] ;
         H00CP3_n673BancoId = new bool[] {false} ;
         H00CP3_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         H00CP3_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         H00CP3_A679ProfesionalesDeclaroDatosV = new DateTime[] {DateTime.MinValue} ;
         H00CP3_n679ProfesionalesDeclaroDatosV = new bool[] {false} ;
         H00CP3_A678ProfesionalesAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         H00CP3_n678ProfesionalesAceptoTerminos = new bool[] {false} ;
         H00CP3_A677ProfesionalesExperiencia = new string[] {""} ;
         H00CP3_n677ProfesionalesExperiencia = new bool[] {false} ;
         H00CP3_A197ProfesionalesAutoEnuZona = new short[1] ;
         H00CP3_A196ProfesionalesAutoEnumerar = new short[1] ;
         H00CP3_A436ProfesionalesPerAltShop = new string[] {""} ;
         H00CP3_n436ProfesionalesPerAltShop = new bool[] {false} ;
         H00CP3_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         H00CP3_A198ProfesionalesDireccion = new string[] {""} ;
         H00CP3_A193ProfesionalesEmail = new string[] {""} ;
         H00CP3_n193ProfesionalesEmail = new bool[] {false} ;
         H00CP3_A170ProfesionalesTelefono = new string[] {""} ;
         H00CP3_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         H00CP3_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         H00CP3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00CP3_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H00CP3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00CP3_A676ProfesionalesEsRUT = new bool[] {false} ;
         H00CP3_n676ProfesionalesEsRUT = new bool[] {false} ;
         H00CP3_A120ProfesionalesId = new string[] {""} ;
         H00CP3_A169ProfesionalesPhoto = new string[] {""} ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV20ManageFiltersXml = "";
         GXt_char3 = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV18Session = context.GetSession();
         AV14GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8EstadosTipo = "";
         sCtrlAV9EstadosGenericosId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sImgUrl = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadosnotificacionprofesionaleswc__default(),
            new Object[][] {
                new Object[] {
               H00CP2_A107EstadosTipo, H00CP2_A108EstadosGenericosId, H00CP2_A269ProfesionalesFeedBackProm, H00CP2_A268ProfesionalesFeedBackCant, H00CP2_A617ProfesionalesLimitOSF, H00CP2_n617ProfesionalesLimitOSF, H00CP2_A200ProfesionalesFechaActualizado, H00CP2_A199ProfesionalesFechaAlta, H00CP2_A674BancoNombre, H00CP2_A673BancoId,
               H00CP2_n673BancoId, H00CP2_A680ProfesionalesCuentaBancaria, H00CP2_n680ProfesionalesCuentaBancaria, H00CP2_A679ProfesionalesDeclaroDatosV, H00CP2_n679ProfesionalesDeclaroDatosV, H00CP2_A678ProfesionalesAceptoTerminos, H00CP2_n678ProfesionalesAceptoTerminos, H00CP2_A677ProfesionalesExperiencia, H00CP2_n677ProfesionalesExperiencia, H00CP2_A197ProfesionalesAutoEnuZona,
               H00CP2_A196ProfesionalesAutoEnumerar, H00CP2_A436ProfesionalesPerAltShop, H00CP2_n436ProfesionalesPerAltShop, H00CP2_A267ProfesionalesVerDatPerSol, H00CP2_A198ProfesionalesDireccion, H00CP2_A193ProfesionalesEmail, H00CP2_n193ProfesionalesEmail, H00CP2_A170ProfesionalesTelefono, H00CP2_A40000ProfesionalesPhoto_GXI, H00CP2_A192ProfesionalesApellidoSegundo,
               H00CP2_A167ProfesionalesApellidoPrimero, H00CP2_A191ProfesionalesSegundoNombre, H00CP2_A166ProfesionalesPrimerNombre, H00CP2_A676ProfesionalesEsRUT, H00CP2_n676ProfesionalesEsRUT, H00CP2_A120ProfesionalesId, H00CP2_A169ProfesionalesPhoto
               }
               , new Object[] {
               H00CP3_A107EstadosTipo, H00CP3_A108EstadosGenericosId, H00CP3_A269ProfesionalesFeedBackProm, H00CP3_A268ProfesionalesFeedBackCant, H00CP3_A617ProfesionalesLimitOSF, H00CP3_n617ProfesionalesLimitOSF, H00CP3_A200ProfesionalesFechaActualizado, H00CP3_A199ProfesionalesFechaAlta, H00CP3_A674BancoNombre, H00CP3_A673BancoId,
               H00CP3_n673BancoId, H00CP3_A680ProfesionalesCuentaBancaria, H00CP3_n680ProfesionalesCuentaBancaria, H00CP3_A679ProfesionalesDeclaroDatosV, H00CP3_n679ProfesionalesDeclaroDatosV, H00CP3_A678ProfesionalesAceptoTerminos, H00CP3_n678ProfesionalesAceptoTerminos, H00CP3_A677ProfesionalesExperiencia, H00CP3_n677ProfesionalesExperiencia, H00CP3_A197ProfesionalesAutoEnuZona,
               H00CP3_A196ProfesionalesAutoEnumerar, H00CP3_A436ProfesionalesPerAltShop, H00CP3_n436ProfesionalesPerAltShop, H00CP3_A267ProfesionalesVerDatPerSol, H00CP3_A198ProfesionalesDireccion, H00CP3_A193ProfesionalesEmail, H00CP3_n193ProfesionalesEmail, H00CP3_A170ProfesionalesTelefono, H00CP3_A40000ProfesionalesPhoto_GXI, H00CP3_A192ProfesionalesApellidoSegundo,
               H00CP3_A167ProfesionalesApellidoPrimero, H00CP3_A191ProfesionalesSegundoNombre, H00CP3_A166ProfesionalesPrimerNombre, H00CP3_A676ProfesionalesEsRUT, H00CP3_n676ProfesionalesEsRUT, H00CP3_A120ProfesionalesId, H00CP3_A169ProfesionalesPhoto
               }
            }
         );
         AV34Pgmname = "EstadosNotificacionProfesionalesWC";
         /* GeneXus formulas. */
         AV34Pgmname = "EstadosNotificacionProfesionalesWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV15OrderedBy ;
      private short AV21ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A196ProfesionalesAutoEnumerar ;
      private short A197ProfesionalesAutoEnuZona ;
      private short A617ProfesionalesLimitOSF ;
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
      private int AV9EstadosGenericosId ;
      private int wcpOAV9EstadosGenericosId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtEstadosTipo_Visible ;
      private int A108EstadosGenericosId ;
      private int edtEstadosGenericosId_Visible ;
      private int subGrid_Islastpage ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtProfesionalesPhoto_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int edtProfesionalesEmail_Enabled ;
      private int edtProfesionalesDireccion_Enabled ;
      private int edtProfesionalesAutoEnumerar_Enabled ;
      private int edtProfesionalesAutoEnuZona_Enabled ;
      private int edtProfesionalesExperiencia_Enabled ;
      private int edtProfesionalesAceptoTerminos_Enabled ;
      private int edtProfesionalesDeclaroDatosV_Enabled ;
      private int edtProfesionalesCuentaBancaria_Enabled ;
      private int edtBancoId_Enabled ;
      private int edtBancoNombre_Enabled ;
      private int edtProfesionalesFechaAlta_Enabled ;
      private int edtProfesionalesFechaActualizado_Enabled ;
      private int edtProfesionalesLimitOSF_Enabled ;
      private int edtProfesionalesFeedBackCant_Enabled ;
      private int edtProfesionalesFeedBackProm_Enabled ;
      private int edtEstadosTipo_Enabled ;
      private int edtEstadosGenericosId_Enabled ;
      private int AV24PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV35GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV25GridCurrentPage ;
      private long AV26GridPageCount ;
      private long A673BancoId ;
      private long A268ProfesionalesFeedBackCant ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A269ProfesionalesFeedBackProm ;
      private string AV8EstadosTipo ;
      private string wcpOAV8EstadosTipo ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_37_idx="0001" ;
      private string AV34Pgmname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
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
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
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
      private string edtEstadosTipo_Internalname ;
      private string A107EstadosTipo ;
      private string edtEstadosTipo_Jsonclick ;
      private string edtEstadosGenericosId_Internalname ;
      private string edtEstadosGenericosId_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavFilterfulltext_Internalname ;
      private string AV28Update ;
      private string AV30Delete ;
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Internalname ;
      private string chkProfesionalesEsRUT_Internalname ;
      private string A166ProfesionalesPrimerNombre ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string A191ProfesionalesSegundoNombre ;
      private string edtProfesionalesSegundoNombre_Internalname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string A192ProfesionalesApellidoSegundo ;
      private string edtProfesionalesApellidoSegundo_Internalname ;
      private string edtProfesionalesPhoto_Internalname ;
      private string A170ProfesionalesTelefono ;
      private string edtProfesionalesTelefono_Internalname ;
      private string edtProfesionalesEmail_Internalname ;
      private string edtProfesionalesDireccion_Internalname ;
      private string cmbProfesionalesVerDatPerSol_Internalname ;
      private string A267ProfesionalesVerDatPerSol ;
      private string cmbProfesionalesPerAltShop_Internalname ;
      private string A436ProfesionalesPerAltShop ;
      private string edtProfesionalesAutoEnumerar_Internalname ;
      private string edtProfesionalesAutoEnuZona_Internalname ;
      private string edtProfesionalesExperiencia_Internalname ;
      private string edtProfesionalesAceptoTerminos_Internalname ;
      private string edtProfesionalesDeclaroDatosV_Internalname ;
      private string A680ProfesionalesCuentaBancaria ;
      private string edtProfesionalesCuentaBancaria_Internalname ;
      private string edtBancoId_Internalname ;
      private string A674BancoNombre ;
      private string edtBancoNombre_Internalname ;
      private string edtProfesionalesFechaAlta_Internalname ;
      private string edtProfesionalesFechaActualizado_Internalname ;
      private string edtProfesionalesLimitOSF_Internalname ;
      private string edtProfesionalesFeedBackCant_Internalname ;
      private string edtProfesionalesFeedBackProm_Internalname ;
      private string GXDecQS ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtProfesionalesPrimerNombre_Link ;
      private string edtBancoNombre_Link ;
      private string GXt_char3 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sCtrlAV8EstadosTipo ;
      private string sCtrlAV9EstadosGenericosId ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtProfesionalesId_Jsonclick ;
      private string GXCCtl ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string sImgUrl ;
      private string gxphoneLink ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string edtProfesionalesEmail_Jsonclick ;
      private string edtProfesionalesDireccion_Jsonclick ;
      private string cmbProfesionalesVerDatPerSol_Jsonclick ;
      private string cmbProfesionalesPerAltShop_Jsonclick ;
      private string edtProfesionalesAutoEnumerar_Jsonclick ;
      private string edtProfesionalesAutoEnuZona_Jsonclick ;
      private string edtProfesionalesExperiencia_Jsonclick ;
      private string edtProfesionalesAceptoTerminos_Jsonclick ;
      private string edtProfesionalesDeclaroDatosV_Jsonclick ;
      private string edtProfesionalesCuentaBancaria_Jsonclick ;
      private string edtBancoId_Jsonclick ;
      private string edtBancoNombre_Jsonclick ;
      private string edtProfesionalesFechaAlta_Jsonclick ;
      private string edtProfesionalesFechaActualizado_Jsonclick ;
      private string edtProfesionalesLimitOSF_Jsonclick ;
      private string edtProfesionalesFeedBackCant_Jsonclick ;
      private string edtProfesionalesFeedBackProm_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A678ProfesionalesAceptoTerminos ;
      private DateTime A679ProfesionalesDeclaroDatosV ;
      private DateTime A199ProfesionalesFechaAlta ;
      private DateTime A200ProfesionalesFechaActualizado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV16OrderedDsc ;
      private bool AV29IsAuthorized_Update ;
      private bool AV31IsAuthorized_Delete ;
      private bool AV32IsAuthorized_BancoNombre ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A676ProfesionalesEsRUT ;
      private bool n676ProfesionalesEsRUT ;
      private bool n193ProfesionalesEmail ;
      private bool n436ProfesionalesPerAltShop ;
      private bool n677ProfesionalesExperiencia ;
      private bool n678ProfesionalesAceptoTerminos ;
      private bool n679ProfesionalesDeclaroDatosV ;
      private bool n680ProfesionalesCuentaBancaria ;
      private bool n673BancoId ;
      private bool n617ProfesionalesLimitOSF ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV33TempBoolean ;
      private bool GXt_boolean1 ;
      private bool A169ProfesionalesPhoto_IsBlob ;
      private string AV20ManageFiltersXml ;
      private string AV17FilterFullText ;
      private string AV27GridAppliedFilters ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string A193ProfesionalesEmail ;
      private string A198ProfesionalesDireccion ;
      private string A677ProfesionalesExperiencia ;
      private string lV17FilterFullText ;
      private string A169ProfesionalesPhoto ;
      private IGxSession AV18Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GXWebForm Form ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkProfesionalesEsRUT ;
      private GXCombobox cmbProfesionalesVerDatPerSol ;
      private GXCombobox cmbProfesionalesPerAltShop ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV19ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV22DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV13GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H00CP2_A107EstadosTipo ;
      private int[] H00CP2_A108EstadosGenericosId ;
      private decimal[] H00CP2_A269ProfesionalesFeedBackProm ;
      private long[] H00CP2_A268ProfesionalesFeedBackCant ;
      private short[] H00CP2_A617ProfesionalesLimitOSF ;
      private bool[] H00CP2_n617ProfesionalesLimitOSF ;
      private DateTime[] H00CP2_A200ProfesionalesFechaActualizado ;
      private DateTime[] H00CP2_A199ProfesionalesFechaAlta ;
      private string[] H00CP2_A674BancoNombre ;
      private long[] H00CP2_A673BancoId ;
      private bool[] H00CP2_n673BancoId ;
      private string[] H00CP2_A680ProfesionalesCuentaBancaria ;
      private bool[] H00CP2_n680ProfesionalesCuentaBancaria ;
      private DateTime[] H00CP2_A679ProfesionalesDeclaroDatosV ;
      private bool[] H00CP2_n679ProfesionalesDeclaroDatosV ;
      private DateTime[] H00CP2_A678ProfesionalesAceptoTerminos ;
      private bool[] H00CP2_n678ProfesionalesAceptoTerminos ;
      private string[] H00CP2_A677ProfesionalesExperiencia ;
      private bool[] H00CP2_n677ProfesionalesExperiencia ;
      private short[] H00CP2_A197ProfesionalesAutoEnuZona ;
      private short[] H00CP2_A196ProfesionalesAutoEnumerar ;
      private string[] H00CP2_A436ProfesionalesPerAltShop ;
      private bool[] H00CP2_n436ProfesionalesPerAltShop ;
      private string[] H00CP2_A267ProfesionalesVerDatPerSol ;
      private string[] H00CP2_A198ProfesionalesDireccion ;
      private string[] H00CP2_A193ProfesionalesEmail ;
      private bool[] H00CP2_n193ProfesionalesEmail ;
      private string[] H00CP2_A170ProfesionalesTelefono ;
      private string[] H00CP2_A40000ProfesionalesPhoto_GXI ;
      private string[] H00CP2_A192ProfesionalesApellidoSegundo ;
      private string[] H00CP2_A167ProfesionalesApellidoPrimero ;
      private string[] H00CP2_A191ProfesionalesSegundoNombre ;
      private string[] H00CP2_A166ProfesionalesPrimerNombre ;
      private bool[] H00CP2_A676ProfesionalesEsRUT ;
      private bool[] H00CP2_n676ProfesionalesEsRUT ;
      private string[] H00CP2_A120ProfesionalesId ;
      private string[] H00CP2_A169ProfesionalesPhoto ;
      private string[] H00CP3_A107EstadosTipo ;
      private int[] H00CP3_A108EstadosGenericosId ;
      private decimal[] H00CP3_A269ProfesionalesFeedBackProm ;
      private long[] H00CP3_A268ProfesionalesFeedBackCant ;
      private short[] H00CP3_A617ProfesionalesLimitOSF ;
      private bool[] H00CP3_n617ProfesionalesLimitOSF ;
      private DateTime[] H00CP3_A200ProfesionalesFechaActualizado ;
      private DateTime[] H00CP3_A199ProfesionalesFechaAlta ;
      private string[] H00CP3_A674BancoNombre ;
      private long[] H00CP3_A673BancoId ;
      private bool[] H00CP3_n673BancoId ;
      private string[] H00CP3_A680ProfesionalesCuentaBancaria ;
      private bool[] H00CP3_n680ProfesionalesCuentaBancaria ;
      private DateTime[] H00CP3_A679ProfesionalesDeclaroDatosV ;
      private bool[] H00CP3_n679ProfesionalesDeclaroDatosV ;
      private DateTime[] H00CP3_A678ProfesionalesAceptoTerminos ;
      private bool[] H00CP3_n678ProfesionalesAceptoTerminos ;
      private string[] H00CP3_A677ProfesionalesExperiencia ;
      private bool[] H00CP3_n677ProfesionalesExperiencia ;
      private short[] H00CP3_A197ProfesionalesAutoEnuZona ;
      private short[] H00CP3_A196ProfesionalesAutoEnumerar ;
      private string[] H00CP3_A436ProfesionalesPerAltShop ;
      private bool[] H00CP3_n436ProfesionalesPerAltShop ;
      private string[] H00CP3_A267ProfesionalesVerDatPerSol ;
      private string[] H00CP3_A198ProfesionalesDireccion ;
      private string[] H00CP3_A193ProfesionalesEmail ;
      private bool[] H00CP3_n193ProfesionalesEmail ;
      private string[] H00CP3_A170ProfesionalesTelefono ;
      private string[] H00CP3_A40000ProfesionalesPhoto_GXI ;
      private string[] H00CP3_A192ProfesionalesApellidoSegundo ;
      private string[] H00CP3_A167ProfesionalesApellidoPrimero ;
      private string[] H00CP3_A191ProfesionalesSegundoNombre ;
      private string[] H00CP3_A166ProfesionalesPrimerNombre ;
      private bool[] H00CP3_A676ProfesionalesEsRUT ;
      private bool[] H00CP3_n676ProfesionalesEsRUT ;
      private string[] H00CP3_A120ProfesionalesId ;
      private string[] H00CP3_A169ProfesionalesPhoto ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV14GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class estadosnotificacionprofesionaleswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00CP2( IGxContext context ,
                                             short AV15OrderedBy ,
                                             bool AV16OrderedDsc ,
                                             string AV17FilterFullText ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             string A436ProfesionalesPerAltShop ,
                                             string A677ProfesionalesExperiencia ,
                                             string A680ProfesionalesCuentaBancaria ,
                                             long A673BancoId ,
                                             string A674BancoNombre ,
                                             short A617ProfesionalesLimitOSF ,
                                             long A268ProfesionalesFeedBackCant ,
                                             string AV8EstadosTipo ,
                                             int AV9EstadosGenericosId ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[2];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesFeedBackProm], T1.[ProfesionalesFeedBackCant], T1.[ProfesionalesLimitOSF], T1.[ProfesionalesFechaActualizado], T1.[ProfesionalesFechaAlta], T2.[BancoNombre], T1.[BancoId], T1.[ProfesionalesCuentaBancaria], T1.[ProfesionalesDeclaroDatosV], T1.[ProfesionalesAceptoTerminos], T1.[ProfesionalesExperiencia], T1.[ProfesionalesAutoEnuZona], T1.[ProfesionalesAutoEnumerar], T1.[ProfesionalesPerAltShop], T1.[ProfesionalesVerDatPerSol], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesPhoto_GXI], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesEsRUT], T1.[ProfesionalesId], T1.[ProfesionalesPhoto] FROM ([Profesionales] T1 LEFT JOIN [Banco] T2 ON T2.[BancoId] = T1.[BancoId])";
         AddWhere(sWhereString, "(T1.[EstadosTipo] = @AV8EstadosTipo and T1.[EstadosGenericosId] = @AV9EstadosGenericosId)");
         scmdbuf += sWhereString;
         if ( ( AV15OrderedBy == 1 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesEsRUT]";
         }
         else if ( ( AV15OrderedBy == 1 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesEsRUT] DESC";
         }
         else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesId]";
         }
         else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesId] DESC";
         }
         else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV15OrderedBy == 4 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesSegundoNombre]";
         }
         else if ( ( AV15OrderedBy == 4 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV15OrderedBy == 5 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV15OrderedBy == 5 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV15OrderedBy == 6 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV15OrderedBy == 6 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV15OrderedBy == 7 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesTelefono]";
         }
         else if ( ( AV15OrderedBy == 7 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesTelefono] DESC";
         }
         else if ( ( AV15OrderedBy == 8 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesEmail]";
         }
         else if ( ( AV15OrderedBy == 8 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesEmail] DESC";
         }
         else if ( ( AV15OrderedBy == 9 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesDireccion]";
         }
         else if ( ( AV15OrderedBy == 9 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesDireccion] DESC";
         }
         else if ( ( AV15OrderedBy == 10 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesVerDatPerSol]";
         }
         else if ( ( AV15OrderedBy == 10 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesVerDatPerSol] DESC";
         }
         else if ( ( AV15OrderedBy == 11 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesPerAltShop]";
         }
         else if ( ( AV15OrderedBy == 11 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesPerAltShop] DESC";
         }
         else if ( ( AV15OrderedBy == 12 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesExperiencia]";
         }
         else if ( ( AV15OrderedBy == 12 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesExperiencia] DESC";
         }
         else if ( ( AV15OrderedBy == 13 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesAceptoTerminos]";
         }
         else if ( ( AV15OrderedBy == 13 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesAceptoTerminos] DESC";
         }
         else if ( ( AV15OrderedBy == 14 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesDeclaroDatosV]";
         }
         else if ( ( AV15OrderedBy == 14 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesDeclaroDatosV] DESC";
         }
         else if ( ( AV15OrderedBy == 15 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesCuentaBancaria]";
         }
         else if ( ( AV15OrderedBy == 15 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesCuentaBancaria] DESC";
         }
         else if ( ( AV15OrderedBy == 16 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[BancoId]";
         }
         else if ( ( AV15OrderedBy == 16 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[BancoId] DESC";
         }
         else if ( ( AV15OrderedBy == 17 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T2.[BancoNombre]";
         }
         else if ( ( AV15OrderedBy == 17 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T2.[BancoNombre] DESC";
         }
         else if ( ( AV15OrderedBy == 18 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesLimitOSF]";
         }
         else if ( ( AV15OrderedBy == 18 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesLimitOSF] DESC";
         }
         else if ( ( AV15OrderedBy == 19 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesFeedBackCant]";
         }
         else if ( ( AV15OrderedBy == 19 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesFeedBackCant] DESC";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00CP3( IGxContext context ,
                                             short AV15OrderedBy ,
                                             bool AV16OrderedDsc ,
                                             string AV17FilterFullText ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             string A436ProfesionalesPerAltShop ,
                                             string A677ProfesionalesExperiencia ,
                                             string A680ProfesionalesCuentaBancaria ,
                                             long A673BancoId ,
                                             string A674BancoNombre ,
                                             short A617ProfesionalesLimitOSF ,
                                             long A268ProfesionalesFeedBackCant ,
                                             string AV8EstadosTipo ,
                                             int AV9EstadosGenericosId ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[2];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesFeedBackProm], T1.[ProfesionalesFeedBackCant], T1.[ProfesionalesLimitOSF], T1.[ProfesionalesFechaActualizado], T1.[ProfesionalesFechaAlta], T2.[BancoNombre], T1.[BancoId], T1.[ProfesionalesCuentaBancaria], T1.[ProfesionalesDeclaroDatosV], T1.[ProfesionalesAceptoTerminos], T1.[ProfesionalesExperiencia], T1.[ProfesionalesAutoEnuZona], T1.[ProfesionalesAutoEnumerar], T1.[ProfesionalesPerAltShop], T1.[ProfesionalesVerDatPerSol], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesPhoto_GXI], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesEsRUT], T1.[ProfesionalesId], T1.[ProfesionalesPhoto] FROM ([Profesionales] T1 LEFT JOIN [Banco] T2 ON T2.[BancoId] = T1.[BancoId])";
         AddWhere(sWhereString, "(T1.[EstadosTipo] = @AV8EstadosTipo and T1.[EstadosGenericosId] = @AV9EstadosGenericosId)");
         scmdbuf += sWhereString;
         if ( ( AV15OrderedBy == 1 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesEsRUT]";
         }
         else if ( ( AV15OrderedBy == 1 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesEsRUT] DESC";
         }
         else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesId]";
         }
         else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesId] DESC";
         }
         else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV15OrderedBy == 4 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesSegundoNombre]";
         }
         else if ( ( AV15OrderedBy == 4 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV15OrderedBy == 5 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV15OrderedBy == 5 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV15OrderedBy == 6 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV15OrderedBy == 6 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV15OrderedBy == 7 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesTelefono]";
         }
         else if ( ( AV15OrderedBy == 7 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesTelefono] DESC";
         }
         else if ( ( AV15OrderedBy == 8 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesEmail]";
         }
         else if ( ( AV15OrderedBy == 8 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesEmail] DESC";
         }
         else if ( ( AV15OrderedBy == 9 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesDireccion]";
         }
         else if ( ( AV15OrderedBy == 9 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesDireccion] DESC";
         }
         else if ( ( AV15OrderedBy == 10 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesVerDatPerSol]";
         }
         else if ( ( AV15OrderedBy == 10 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesVerDatPerSol] DESC";
         }
         else if ( ( AV15OrderedBy == 11 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesPerAltShop]";
         }
         else if ( ( AV15OrderedBy == 11 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesPerAltShop] DESC";
         }
         else if ( ( AV15OrderedBy == 12 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesExperiencia]";
         }
         else if ( ( AV15OrderedBy == 12 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesExperiencia] DESC";
         }
         else if ( ( AV15OrderedBy == 13 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesAceptoTerminos]";
         }
         else if ( ( AV15OrderedBy == 13 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesAceptoTerminos] DESC";
         }
         else if ( ( AV15OrderedBy == 14 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesDeclaroDatosV]";
         }
         else if ( ( AV15OrderedBy == 14 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesDeclaroDatosV] DESC";
         }
         else if ( ( AV15OrderedBy == 15 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesCuentaBancaria]";
         }
         else if ( ( AV15OrderedBy == 15 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesCuentaBancaria] DESC";
         }
         else if ( ( AV15OrderedBy == 16 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[BancoId]";
         }
         else if ( ( AV15OrderedBy == 16 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[BancoId] DESC";
         }
         else if ( ( AV15OrderedBy == 17 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T2.[BancoNombre]";
         }
         else if ( ( AV15OrderedBy == 17 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T2.[BancoNombre] DESC";
         }
         else if ( ( AV15OrderedBy == 18 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesLimitOSF]";
         }
         else if ( ( AV15OrderedBy == 18 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesLimitOSF] DESC";
         }
         else if ( ( AV15OrderedBy == 19 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[ProfesionalesFeedBackCant]";
         }
         else if ( ( AV15OrderedBy == 19 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EstadosTipo] DESC, T1.[EstadosGenericosId] DESC, T1.[ProfesionalesFeedBackCant] DESC";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00CP2(context, (short)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] );
               case 1 :
                     return conditional_H00CP3(context, (short)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] );
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
          Object[] prmH00CP2;
          prmH00CP2 = new Object[] {
          new ParDef("@AV8EstadosTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9EstadosGenericosId",GXType.Int32,5,0)
          };
          Object[] prmH00CP3;
          prmH00CP3 = new Object[] {
          new ParDef("@AV8EstadosTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9EstadosGenericosId",GXType.Int32,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00CP2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00CP2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00CP3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00CP3,11, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 50);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((string[]) buf[17])[0] = rslt.getVarchar(13);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((short[]) buf[19])[0] = rslt.getShort(14);
                ((short[]) buf[20])[0] = rslt.getShort(15);
                ((string[]) buf[21])[0] = rslt.getString(16, 1);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((string[]) buf[23])[0] = rslt.getString(17, 1);
                ((string[]) buf[24])[0] = rslt.getVarchar(18);
                ((string[]) buf[25])[0] = rslt.getVarchar(19);
                ((bool[]) buf[26])[0] = rslt.wasNull(19);
                ((string[]) buf[27])[0] = rslt.getString(20, 20);
                ((string[]) buf[28])[0] = rslt.getMultimediaUri(21);
                ((string[]) buf[29])[0] = rslt.getString(22, 30);
                ((string[]) buf[30])[0] = rslt.getString(23, 30);
                ((string[]) buf[31])[0] = rslt.getString(24, 30);
                ((string[]) buf[32])[0] = rslt.getString(25, 30);
                ((bool[]) buf[33])[0] = rslt.getBool(26);
                ((bool[]) buf[34])[0] = rslt.wasNull(26);
                ((string[]) buf[35])[0] = rslt.getString(27, 20);
                ((string[]) buf[36])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(21));
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 50);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((string[]) buf[17])[0] = rslt.getVarchar(13);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((short[]) buf[19])[0] = rslt.getShort(14);
                ((short[]) buf[20])[0] = rslt.getShort(15);
                ((string[]) buf[21])[0] = rslt.getString(16, 1);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((string[]) buf[23])[0] = rslt.getString(17, 1);
                ((string[]) buf[24])[0] = rslt.getVarchar(18);
                ((string[]) buf[25])[0] = rslt.getVarchar(19);
                ((bool[]) buf[26])[0] = rslt.wasNull(19);
                ((string[]) buf[27])[0] = rslt.getString(20, 20);
                ((string[]) buf[28])[0] = rslt.getMultimediaUri(21);
                ((string[]) buf[29])[0] = rslt.getString(22, 30);
                ((string[]) buf[30])[0] = rslt.getString(23, 30);
                ((string[]) buf[31])[0] = rslt.getString(24, 30);
                ((string[]) buf[32])[0] = rslt.getString(25, 30);
                ((bool[]) buf[33])[0] = rslt.getBool(26);
                ((bool[]) buf[34])[0] = rslt.wasNull(26);
                ((string[]) buf[35])[0] = rslt.getString(27, 20);
                ((string[]) buf[36])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(21));
                return;
       }
    }

 }

}
